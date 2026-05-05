using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000A2 RID: 162
	[HelpURL("http://www.root-motion.com/finalikdox/html/page9.html")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/Grounder/Grounder IK")]
	public class GrounderIK : Grounder
	{
		// Token: 0x060004E7 RID: 1255 RVA: 0x0001D04F File Offset: 0x0001B24F
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page9.html");
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x0001DC04 File Offset: 0x0001BE04
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_grounder_i_k.html");
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0001DC10 File Offset: 0x0001BE10
		public override void ResetPosition()
		{
			for (int i = 0; i < this.legs.Length; i++)
			{
				this.legs[i].GetIKSolver().IKPosition = this.feet[i].transform.position;
				if (this.legs[i] is LimbIK)
				{
					(this.legs[i] as LimbIK).solver.IKRotation = this.solver.legs[i].transform.rotation;
				}
				this.footRotations[i] = this.feet[i].rotation;
			}
			this.animatedPelvisLocalPosition = this.pelvis.localPosition;
			this.solvedPelvisLocalPosition = this.pelvis.localPosition;
			this.solver.Reset();
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x0001DCDC File Offset: 0x0001BEDC
		private bool IsReadyToInitiate()
		{
			if (this.pelvis == null)
			{
				return false;
			}
			if (this.legs.Length == 0)
			{
				return false;
			}
			foreach (IK ik in this.legs)
			{
				if (ik == null)
				{
					return false;
				}
				if (ik is FullBodyBipedIK)
				{
					base.LogWarning("GrounderIK does not support FullBodyBipedIK, use CCDIK, FABRIK, LimbIK or TrigonometricIK instead. If you want to use FullBodyBipedIK, use the GrounderFBBIK component.");
					return false;
				}
				if (ik is FABRIKRoot)
				{
					base.LogWarning("GrounderIK does not support FABRIKRoot, use CCDIK, FABRIK, LimbIK or TrigonometricIK instead.");
					return false;
				}
				if (ik is AimIK)
				{
					base.LogWarning("GrounderIK does not support AimIK, use CCDIK, FABRIK, LimbIK or TrigonometricIK instead.");
					return false;
				}
			}
			return true;
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0001DD68 File Offset: 0x0001BF68
		private void OnDisable()
		{
			if (!base.initiated)
			{
				return;
			}
			for (int i = 0; i < this.legs.Length; i++)
			{
				if (this.legs[i] != null)
				{
					this.legs[i].GetIKSolver().IKPositionWeight = 0f;
				}
			}
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x0001DDB8 File Offset: 0x0001BFB8
		private void Update()
		{
			this.weight = Mathf.Clamp(this.weight, 0f, 1f);
			if (this.weight <= 0f)
			{
				return;
			}
			this.solved = false;
			if (base.initiated)
			{
				this.rootRotationWeight = Mathf.Clamp(this.rootRotationWeight, 0f, 1f);
				this.rootRotationSpeed = Mathf.Clamp(this.rootRotationSpeed, 0f, this.rootRotationSpeed);
				if (this.characterRoot != null && this.rootRotationSpeed > 0f && this.rootRotationWeight > 0f && this.solver.isGrounded)
				{
					Vector3 vector = this.solver.GetLegsPlaneNormal();
					if (this.rootRotationWeight < 1f)
					{
						vector = Vector3.Slerp(Vector3.up, vector, this.rootRotationWeight);
					}
					Quaternion b = Quaternion.RotateTowards(Quaternion.FromToRotation(base.transform.up, Vector3.up) * this.characterRoot.rotation, Quaternion.FromToRotation(base.transform.up, vector) * this.characterRoot.rotation, this.maxRootRotationAngle);
					if (this.characterRootRigidbody == null)
					{
						this.characterRoot.rotation = Quaternion.Lerp(this.characterRoot.rotation, b, Time.deltaTime * this.rootRotationSpeed);
						return;
					}
					this.characterRootRigidbody.MoveRotation(Quaternion.Lerp(this.characterRoot.rotation, b, Time.deltaTime * this.rootRotationSpeed));
				}
				return;
			}
			if (!this.IsReadyToInitiate())
			{
				return;
			}
			this.Initiate();
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0001DF64 File Offset: 0x0001C164
		private void Initiate()
		{
			this.feet = new Transform[this.legs.Length];
			this.footRotations = new Quaternion[this.legs.Length];
			for (int i = 0; i < this.feet.Length; i++)
			{
				this.footRotations[i] = Quaternion.identity;
			}
			for (int j = 0; j < this.legs.Length; j++)
			{
				IKSolver.Point[] points = this.legs[j].GetIKSolver().GetPoints();
				this.feet[j] = points[points.Length - 1].transform;
				IKSolver iksolver = this.legs[j].GetIKSolver();
				iksolver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(iksolver.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnSolverUpdate));
				IKSolver iksolver2 = this.legs[j].GetIKSolver();
				iksolver2.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(iksolver2.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostSolverUpdate));
			}
			this.animatedPelvisLocalPosition = this.pelvis.localPosition;
			this.solver.Initiate(base.transform, this.feet);
			for (int k = 0; k < this.legs.Length; k++)
			{
				if (this.legs[k] is LegIK)
				{
					this.solver.legs[k].invertFootCenter = true;
				}
			}
			this.characterRootRigidbody = this.characterRoot.GetComponent<Rigidbody>();
			base.initiated = true;
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0001E0CC File Offset: 0x0001C2CC
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
			if (this.solved)
			{
				return;
			}
			if (this.OnPreGrounder != null)
			{
				this.OnPreGrounder();
			}
			if (this.pelvis.localPosition != this.solvedPelvisLocalPosition)
			{
				this.animatedPelvisLocalPosition = this.pelvis.localPosition;
			}
			else
			{
				this.pelvis.localPosition = this.animatedPelvisLocalPosition;
			}
			this.solver.Update();
			for (int i = 0; i < this.legs.Length; i++)
			{
				this.SetLegIK(i);
			}
			this.pelvis.position += this.solver.pelvis.IKOffset * this.weight;
			this.solved = true;
			this.solvedFeet = 0;
			if (this.OnPostGrounder != null)
			{
				this.OnPostGrounder();
			}
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0001E1E0 File Offset: 0x0001C3E0
		private void SetLegIK(int index)
		{
			this.footRotations[index] = this.feet[index].rotation;
			if (this.legs[index] is LegIK)
			{
				(this.legs[index].GetIKSolver() as IKSolverLeg).IKRotation = Quaternion.Slerp(Quaternion.identity, this.solver.legs[index].rotationOffset, this.weight) * this.footRotations[index];
				(this.legs[index].GetIKSolver() as IKSolverLeg).IKRotationWeight = 1f;
			}
			this.legs[index].GetIKSolver().IKPosition = this.solver.legs[index].IKPosition;
			this.legs[index].GetIKSolver().IKPositionWeight = this.weight;
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x0001E2B8 File Offset: 0x0001C4B8
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
			this.solvedFeet++;
			if (this.solvedFeet < this.feet.Length)
			{
				return;
			}
			this.solved = false;
			for (int i = 0; i < this.feet.Length; i++)
			{
				this.feet[i].rotation = Quaternion.Slerp(Quaternion.identity, this.solver.legs[i].rotationOffset, this.weight) * this.footRotations[i];
			}
			this.solvedPelvisLocalPosition = this.pelvis.localPosition;
			if (this.OnPostIK != null)
			{
				this.OnPostIK();
			}
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x0001E37C File Offset: 0x0001C57C
		private void OnDestroy()
		{
			if (base.initiated)
			{
				foreach (IK ik in this.legs)
				{
					if (ik != null)
					{
						IKSolver iksolver = ik.GetIKSolver();
						iksolver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(iksolver.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnSolverUpdate));
						IKSolver iksolver2 = ik.GetIKSolver();
						iksolver2.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(iksolver2.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostSolverUpdate));
					}
				}
			}
		}

		// Token: 0x04000453 RID: 1107
		public IK[] legs;

		// Token: 0x04000454 RID: 1108
		[Tooltip("The pelvis transform. Common ancestor of all the legs.")]
		public Transform pelvis;

		// Token: 0x04000455 RID: 1109
		[Tooltip("The root Transform of the character, with the rigidbody and the collider.")]
		public Transform characterRoot;

		// Token: 0x04000456 RID: 1110
		[Tooltip("The weight of rotating the character root to the ground normal (range: 0 - 1).")]
		[Range(0f, 1f)]
		public float rootRotationWeight;

		// Token: 0x04000457 RID: 1111
		[Tooltip("The speed of rotating the character root to the ground normal (range: 0 - inf).")]
		public float rootRotationSpeed = 5f;

		// Token: 0x04000458 RID: 1112
		[Tooltip("The maximum angle of root rotation (range: 0 - 90).")]
		public float maxRootRotationAngle = 45f;

		// Token: 0x04000459 RID: 1113
		private Transform[] feet = new Transform[0];

		// Token: 0x0400045A RID: 1114
		private Quaternion[] footRotations = new Quaternion[0];

		// Token: 0x0400045B RID: 1115
		private Vector3 animatedPelvisLocalPosition;

		// Token: 0x0400045C RID: 1116
		private Vector3 solvedPelvisLocalPosition;

		// Token: 0x0400045D RID: 1117
		private int solvedFeet;

		// Token: 0x0400045E RID: 1118
		private bool solved;

		// Token: 0x0400045F RID: 1119
		private float lastWeight;

		// Token: 0x04000460 RID: 1120
		private Rigidbody characterRootRigidbody;
	}
}
