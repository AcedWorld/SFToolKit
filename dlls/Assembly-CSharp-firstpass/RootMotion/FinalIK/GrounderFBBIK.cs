using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000A0 RID: 160
	[HelpURL("https://www.youtube.com/watch?v=9MiZiaJorws&index=6&list=PLVxSIA1OaTOu8Nos3CalXbJ2DrKnntMv6")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/Grounder/Grounder Full Body Biped")]
	public class GrounderFBBIK : Grounder
	{
		// Token: 0x060004D6 RID: 1238 RVA: 0x0001D693 File Offset: 0x0001B893
		[ContextMenu("TUTORIAL VIDEO")]
		private void OpenTutorial()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=9MiZiaJorws&index=6&list=PLVxSIA1OaTOu8Nos3CalXbJ2DrKnntMv6");
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x0001D04F File Offset: 0x0001B24F
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page9.html");
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x0001D69F File Offset: 0x0001B89F
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_grounder_f_b_b_i_k.html");
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x0001D6AB File Offset: 0x0001B8AB
		public override void ResetPosition()
		{
			this.solver.Reset();
			this.spineOffset = Vector3.zero;
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0001D6C3 File Offset: 0x0001B8C3
		private bool IsReadyToInitiate()
		{
			return !(this.ik == null) && this.ik.solver.initiated;
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0001D6EC File Offset: 0x0001B8EC
		private void Update()
		{
			this.firstSolve = true;
			this.weight = Mathf.Clamp(this.weight, 0f, 1f);
			if (this.weight <= 0f)
			{
				return;
			}
			if (base.initiated)
			{
				return;
			}
			if (!this.IsReadyToInitiate())
			{
				return;
			}
			this.Initiate();
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0001D741 File Offset: 0x0001B941
		private void FixedUpdate()
		{
			this.firstSolve = true;
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0001D741 File Offset: 0x0001B941
		private void LateUpdate()
		{
			this.firstSolve = true;
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0001D74C File Offset: 0x0001B94C
		private void Initiate()
		{
			this.ik.solver.leftLegMapping.maintainRotationWeight = 1f;
			this.ik.solver.rightLegMapping.maintainRotationWeight = 1f;
			this.feet = new Transform[2];
			this.feet[0] = this.ik.solver.leftFootEffector.bone;
			this.feet[1] = this.ik.solver.rightFootEffector.bone;
			IKSolverFullBodyBiped solver = this.ik.solver;
			solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnSolverUpdate));
			IKSolverFullBodyBiped solver2 = this.ik.solver;
			solver2.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver2.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostSolverUpdate));
			this.solver.Initiate(this.ik.references.root, this.feet);
			base.initiated = true;
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x0001D854 File Offset: 0x0001BA54
		private void OnSolverUpdate()
		{
			if (!this.firstSolve)
			{
				return;
			}
			this.firstSolve = false;
			if (!base.enabled)
			{
				return;
			}
			if (this.weight <= 0f)
			{
				return;
			}
			if (this.OnPreGrounder != null)
			{
				this.OnPreGrounder();
			}
			this.solver.Update();
			this.ik.references.pelvis.position += this.solver.pelvis.IKOffset * this.weight;
			this.SetLegIK(this.ik.solver.leftFootEffector, this.solver.legs[0]);
			this.SetLegIK(this.ik.solver.rightFootEffector, this.solver.legs[1]);
			if (this.spineBend != 0f)
			{
				this.spineSpeed = Mathf.Clamp(this.spineSpeed, 0f, this.spineSpeed);
				Vector3 a = base.GetSpineOffsetTarget() * this.weight;
				this.spineOffset = Vector3.Lerp(this.spineOffset, a * this.spineBend, Time.deltaTime * this.spineSpeed);
				Vector3 a2 = this.ik.references.root.up * this.spineOffset.magnitude;
				for (int i = 0; i < this.spine.Length; i++)
				{
					this.ik.solver.GetEffector(this.spine[i].effectorType).positionOffset += this.spineOffset * this.spine[i].horizontalWeight + a2 * this.spine[i].verticalWeight;
				}
			}
			if (this.OnPostGrounder != null)
			{
				this.OnPostGrounder();
			}
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x0001DA38 File Offset: 0x0001BC38
		private void SetLegIK(IKEffector effector, Grounding.Leg leg)
		{
			effector.positionOffset += (leg.IKPosition - effector.bone.position) * this.weight;
			effector.bone.rotation = Quaternion.Slerp(Quaternion.identity, leg.rotationOffset, this.weight) * effector.bone.rotation;
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x0001DAA8 File Offset: 0x0001BCA8
		private void OnDrawGizmosSelected()
		{
			if (this.ik == null)
			{
				this.ik = base.GetComponent<FullBodyBipedIK>();
			}
			if (this.ik == null)
			{
				this.ik = base.GetComponentInParent<FullBodyBipedIK>();
			}
			if (this.ik == null)
			{
				this.ik = base.GetComponentInChildren<FullBodyBipedIK>();
			}
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0001DB03 File Offset: 0x0001BD03
		private void OnPostSolverUpdate()
		{
			if (this.OnPostIK != null)
			{
				this.OnPostIK();
			}
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0001DB18 File Offset: 0x0001BD18
		private void OnDestroy()
		{
			if (base.initiated && this.ik != null)
			{
				IKSolverFullBodyBiped solver = this.ik.solver;
				solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnSolverUpdate));
				IKSolverFullBodyBiped solver2 = this.ik.solver;
				solver2.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver2.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostSolverUpdate));
			}
		}

		// Token: 0x04000449 RID: 1097
		[Tooltip("Reference to the FBBIK componet.")]
		public FullBodyBipedIK ik;

		// Token: 0x0400044A RID: 1098
		[Tooltip("The amount of spine bending towards upward slopes.")]
		public float spineBend = 2f;

		// Token: 0x0400044B RID: 1099
		[Tooltip("The interpolation speed of spine bending.")]
		public float spineSpeed = 3f;

		// Token: 0x0400044C RID: 1100
		public GrounderFBBIK.SpineEffector[] spine = new GrounderFBBIK.SpineEffector[0];

		// Token: 0x0400044D RID: 1101
		private Transform[] feet = new Transform[2];

		// Token: 0x0400044E RID: 1102
		private Vector3 spineOffset;

		// Token: 0x0400044F RID: 1103
		private bool firstSolve;

		// Token: 0x020000A1 RID: 161
		[Serializable]
		public class SpineEffector
		{
			// Token: 0x060004E5 RID: 1253 RVA: 0x0001DBC9 File Offset: 0x0001BDC9
			public SpineEffector()
			{
			}

			// Token: 0x060004E6 RID: 1254 RVA: 0x0001DBDC File Offset: 0x0001BDDC
			public SpineEffector(FullBodyBipedEffector effectorType, float horizontalWeight, float verticalWeight)
			{
				this.effectorType = effectorType;
				this.horizontalWeight = horizontalWeight;
				this.verticalWeight = verticalWeight;
			}

			// Token: 0x04000450 RID: 1104
			[Tooltip("The type of the effector.")]
			public FullBodyBipedEffector effectorType;

			// Token: 0x04000451 RID: 1105
			[Tooltip("The weight of horizontal bend offset towards the slope.")]
			public float horizontalWeight = 1f;

			// Token: 0x04000452 RID: 1106
			[Tooltip("The vertical bend offset weight.")]
			public float verticalWeight;
		}
	}
}
