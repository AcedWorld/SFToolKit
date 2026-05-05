using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x0200009F RID: 159
	[HelpURL("http://www.root-motion.com/finalikdox/html/page9.html")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/Grounder/Grounder Biped")]
	public class GrounderBipedIK : Grounder
	{
		// Token: 0x060004CA RID: 1226 RVA: 0x0001D04F File Offset: 0x0001B24F
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page9.html");
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0001D05B File Offset: 0x0001B25B
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_grounder_biped_i_k.html");
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x0001D067 File Offset: 0x0001B267
		public override void ResetPosition()
		{
			this.solver.Reset();
			this.spineOffset = Vector3.zero;
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0001D080 File Offset: 0x0001B280
		private bool IsReadyToInitiate()
		{
			return !(this.ik == null) && this.ik.solvers.leftFoot.initiated && this.ik.solvers.rightFoot.initiated;
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0001D0D0 File Offset: 0x0001B2D0
		private void Update()
		{
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

		// Token: 0x060004CF RID: 1231 RVA: 0x0001D120 File Offset: 0x0001B320
		private void Initiate()
		{
			this.feet = new Transform[2];
			this.footRotations = new Quaternion[2];
			this.feet[0] = this.ik.references.leftFoot;
			this.feet[1] = this.ik.references.rightFoot;
			this.footRotations[0] = Quaternion.identity;
			this.footRotations[1] = Quaternion.identity;
			IKSolverFABRIK spine = this.ik.solvers.spine;
			spine.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(spine.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnSolverUpdate));
			IKSolverLimb rightFoot = this.ik.solvers.rightFoot;
			rightFoot.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(rightFoot.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostSolverUpdate));
			this.animatedPelvisLocalPosition = this.ik.references.pelvis.localPosition;
			this.solver.Initiate(this.ik.references.root, this.feet);
			base.initiated = true;
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0001D23C File Offset: 0x0001B43C
		private void OnDisable()
		{
			if (!base.initiated)
			{
				return;
			}
			this.ik.solvers.leftFoot.IKPositionWeight = 0f;
			this.ik.solvers.rightFoot.IKPositionWeight = 0f;
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x0001D27C File Offset: 0x0001B47C
		private void OnSolverUpdate()
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.weight <= 0f)
			{
				if (this.lastWeight <= 0f)
				{
					return;
				}
				this.OnDisable();
			}
			this.lastWeight = this.weight;
			if (this.OnPreGrounder != null)
			{
				this.OnPreGrounder();
			}
			if (this.ik.references.pelvis.localPosition != this.solvedPelvisLocalPosition)
			{
				this.animatedPelvisLocalPosition = this.ik.references.pelvis.localPosition;
			}
			else
			{
				this.ik.references.pelvis.localPosition = this.animatedPelvisLocalPosition;
			}
			this.solver.Update();
			this.ik.references.pelvis.position += this.solver.pelvis.IKOffset * this.weight;
			this.SetLegIK(this.ik.solvers.leftFoot, 0);
			this.SetLegIK(this.ik.solvers.rightFoot, 1);
			if (this.spineBend != 0f && this.ik.references.spine.Length != 0)
			{
				this.spineSpeed = Mathf.Clamp(this.spineSpeed, 0f, this.spineSpeed);
				Vector3 a = base.GetSpineOffsetTarget() * this.weight;
				this.spineOffset = Vector3.Lerp(this.spineOffset, a * this.spineBend, Time.deltaTime * this.spineSpeed);
				Quaternion rotation = this.ik.references.leftUpperArm.rotation;
				Quaternion rotation2 = this.ik.references.rightUpperArm.rotation;
				Vector3 up = this.solver.up;
				Quaternion lhs = Quaternion.FromToRotation(up, up + this.spineOffset);
				this.ik.references.spine[0].rotation = lhs * this.ik.references.spine[0].rotation;
				this.ik.references.leftUpperArm.rotation = rotation;
				this.ik.references.rightUpperArm.rotation = rotation2;
				this.ik.solvers.lookAt.SetDirty();
			}
			if (this.OnPostGrounder != null)
			{
				this.OnPostGrounder();
			}
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x0001D4EE File Offset: 0x0001B6EE
		private void SetLegIK(IKSolverLimb limb, int index)
		{
			this.footRotations[index] = this.feet[index].rotation;
			limb.IKPosition = this.solver.legs[index].IKPosition;
			limb.IKPositionWeight = this.weight;
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0001D530 File Offset: 0x0001B730
		private void OnPostSolverUpdate()
		{
			if (this.weight <= 0f)
			{
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			for (int i = 0; i < this.feet.Length; i++)
			{
				this.feet[i].rotation = Quaternion.Slerp(Quaternion.identity, this.solver.legs[i].rotationOffset, this.weight) * this.footRotations[i];
			}
			this.solvedPelvisLocalPosition = this.ik.references.pelvis.localPosition;
			if (this.OnPostIK != null)
			{
				this.OnPostIK();
			}
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0001D5D8 File Offset: 0x0001B7D8
		private void OnDestroy()
		{
			if (base.initiated && this.ik != null)
			{
				IKSolverFABRIK spine = this.ik.solvers.spine;
				spine.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(spine.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnSolverUpdate));
				IKSolverLimb rightFoot = this.ik.solvers.rightFoot;
				rightFoot.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(rightFoot.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostSolverUpdate));
			}
		}

		// Token: 0x04000440 RID: 1088
		[Tooltip("The BipedIK componet.")]
		public BipedIK ik;

		// Token: 0x04000441 RID: 1089
		[Tooltip("The amount of spine bending towards upward slopes.")]
		public float spineBend = 7f;

		// Token: 0x04000442 RID: 1090
		[Tooltip("The interpolation speed of spine bending.")]
		public float spineSpeed = 3f;

		// Token: 0x04000443 RID: 1091
		private Transform[] feet = new Transform[2];

		// Token: 0x04000444 RID: 1092
		private Quaternion[] footRotations = new Quaternion[2];

		// Token: 0x04000445 RID: 1093
		private Vector3 animatedPelvisLocalPosition;

		// Token: 0x04000446 RID: 1094
		private Vector3 solvedPelvisLocalPosition;

		// Token: 0x04000447 RID: 1095
		private Vector3 spineOffset;

		// Token: 0x04000448 RID: 1096
		private float lastWeight;
	}
}
