using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000A3 RID: 163
	[HelpURL("http://www.root-motion.com/finalikdox/html/page9.html")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/Grounder/Grounder Quadruped")]
	public class GrounderQuadruped : Grounder
	{
		// Token: 0x060004F3 RID: 1267 RVA: 0x0001D04F File Offset: 0x0001B24F
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page9.html");
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0001E437 File Offset: 0x0001C637
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_grounder_quadruped.html");
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x0001E444 File Offset: 0x0001C644
		public override void ResetPosition()
		{
			for (int i = 0; i < this.legs.Length; i++)
			{
				this.legs[i].GetIKSolver().IKPosition = this.feet[i].transform.position;
				if (this.legs[i] is LimbIK)
				{
					(this.legs[i] as LimbIK).solver.IKRotation = this.solver.legs[i].transform.rotation;
				}
			}
			this.solver.Reset();
			this.forelegSolver.Reset();
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x0001E4E0 File Offset: 0x0001C6E0
		private bool IsReadyToInitiate()
		{
			return !(this.pelvis == null) && !(this.lastSpineBone == null) && this.legs.Length != 0 && this.forelegs.Length != 0 && !(this.characterRoot == null) && this.IsReadyToInitiateLegs(this.legs) && this.IsReadyToInitiateLegs(this.forelegs);
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0001E554 File Offset: 0x0001C754
		private bool IsReadyToInitiateLegs(IK[] ikComponents)
		{
			foreach (IK ik in ikComponents)
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

		// Token: 0x060004F8 RID: 1272 RVA: 0x0001E5C0 File Offset: 0x0001C7C0
		private void OnDisable()
		{
			if (!base.initiated)
			{
				return;
			}
			for (int i = 0; i < this.feet.Length; i++)
			{
				if (this.feet[i].solver != null)
				{
					this.feet[i].solver.IKPositionWeight = 0f;
				}
			}
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x0001E618 File Offset: 0x0001C818
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
				return;
			}
			if (!this.IsReadyToInitiate())
			{
				return;
			}
			this.Initiate();
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0001E670 File Offset: 0x0001C870
		private void Initiate()
		{
			this.feet = new GrounderQuadruped.Foot[this.legs.Length + this.forelegs.Length];
			Transform[] array = this.InitiateFeet(this.legs, ref this.feet, 0);
			Transform[] array2 = this.InitiateFeet(this.forelegs, ref this.feet, this.legs.Length);
			this.animatedPelvisLocalPosition = this.pelvis.localPosition;
			this.animatedPelvisLocalRotation = this.pelvis.localRotation;
			if (this.head != null)
			{
				this.animatedHeadLocalRotation = this.head.localRotation;
			}
			this.forefeetRoot = new GameObject().transform;
			this.forefeetRoot.parent = base.transform;
			this.forefeetRoot.name = "Forefeet Root";
			this.solver.Initiate(base.transform, array);
			this.forelegSolver.Initiate(this.forefeetRoot, array2);
			for (int i = 0; i < array.Length; i++)
			{
				this.feet[i].leg = this.solver.legs[i];
			}
			for (int j = 0; j < array2.Length; j++)
			{
				this.feet[j + this.legs.Length].leg = this.forelegSolver.legs[j];
			}
			this.characterRootRigidbody = this.characterRoot.GetComponent<Rigidbody>();
			base.initiated = true;
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0001E7D8 File Offset: 0x0001C9D8
		private Transform[] InitiateFeet(IK[] ikComponents, ref GrounderQuadruped.Foot[] f, int indexOffset)
		{
			Transform[] array = new Transform[ikComponents.Length];
			for (int i = 0; i < ikComponents.Length; i++)
			{
				IKSolver.Point[] points = ikComponents[i].GetIKSolver().GetPoints();
				f[i + indexOffset] = new GrounderQuadruped.Foot(ikComponents[i].GetIKSolver(), points[points.Length - 1].transform);
				array[i] = f[i + indexOffset].transform;
				IKSolver solver = f[i + indexOffset].solver;
				solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnSolverUpdate));
				IKSolver solver2 = f[i + indexOffset].solver;
				solver2.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver2.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostSolverUpdate));
			}
			return array;
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x0001E8A8 File Offset: 0x0001CAA8
		private void LateUpdate()
		{
			if (this.weight <= 0f)
			{
				return;
			}
			this.rootRotationWeight = Mathf.Clamp(this.rootRotationWeight, 0f, 1f);
			this.minRootRotation = Mathf.Clamp(this.minRootRotation, -90f, this.maxRootRotation);
			this.maxRootRotation = Mathf.Clamp(this.maxRootRotation, this.minRootRotation, 90f);
			this.rootRotationSpeed = Mathf.Clamp(this.rootRotationSpeed, 0f, this.rootRotationSpeed);
			this.maxLegOffset = Mathf.Clamp(this.maxLegOffset, 0f, this.maxLegOffset);
			this.maxForeLegOffset = Mathf.Clamp(this.maxForeLegOffset, 0f, this.maxForeLegOffset);
			this.maintainHeadRotationWeight = Mathf.Clamp(this.maintainHeadRotationWeight, 0f, 1f);
			this.RootRotation();
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x0001E98C File Offset: 0x0001CB8C
		private void RootRotation()
		{
			if (this.rootRotationWeight <= 0f)
			{
				return;
			}
			if (this.rootRotationSpeed <= 0f)
			{
				return;
			}
			this.solver.rotateSolver = true;
			this.forelegSolver.rotateSolver = true;
			Vector3 forward = this.characterRoot.forward;
			Vector3 vector = -this.gravity;
			Vector3.OrthoNormalize(ref vector, ref forward);
			Quaternion quaternion = Quaternion.LookRotation(forward, -this.gravity);
			Vector3 point = this.forelegSolver.rootHit.point - this.solver.rootHit.point;
			Vector3 vector2 = Quaternion.Inverse(quaternion) * point;
			float num = Mathf.Atan2(vector2.y, vector2.z) * 57.29578f;
			num = Mathf.Clamp(num * this.rootRotationWeight, this.minRootRotation, this.maxRootRotation);
			this.angle = Mathf.Lerp(this.angle, num, Time.deltaTime * this.rootRotationSpeed);
			if (this.characterRootRigidbody == null)
			{
				this.characterRoot.rotation = Quaternion.Slerp(this.characterRoot.rotation, Quaternion.AngleAxis(-this.angle, this.characterRoot.right) * quaternion, this.weight);
				return;
			}
			this.characterRootRigidbody.MoveRotation(Quaternion.Slerp(this.characterRoot.rotation, Quaternion.AngleAxis(-this.angle, this.characterRoot.right) * quaternion, this.weight));
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x0001EB20 File Offset: 0x0001CD20
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
			if (this.pelvis.localRotation != this.solvedPelvisLocalRotation)
			{
				this.animatedPelvisLocalRotation = this.pelvis.localRotation;
			}
			else
			{
				this.pelvis.localRotation = this.animatedPelvisLocalRotation;
			}
			if (this.head != null)
			{
				if (this.head.localRotation != this.solvedHeadLocalRotation)
				{
					this.animatedHeadLocalRotation = this.head.localRotation;
				}
				else
				{
					this.head.localRotation = this.animatedHeadLocalRotation;
				}
			}
			for (int i = 0; i < this.feet.Length; i++)
			{
				this.feet[i].rotation = this.feet[i].transform.rotation;
			}
			if (this.head != null)
			{
				this.headRotation = this.head.rotation;
			}
			this.UpdateForefeetRoot();
			this.solver.Update();
			this.forelegSolver.Update();
			this.pelvis.position += this.solver.pelvis.IKOffset * this.weight;
			Vector3 fromDirection = this.lastSpineBone.position - this.pelvis.position;
			Vector3 toDirection = this.lastSpineBone.position + this.forelegSolver.root.up * Mathf.Clamp(this.forelegSolver.pelvis.heightOffset, float.NegativeInfinity, 0f) - this.solver.root.up * this.solver.pelvis.heightOffset - this.pelvis.position;
			Quaternion b = Quaternion.FromToRotation(fromDirection, toDirection);
			this.pelvis.rotation = Quaternion.Slerp(Quaternion.identity, b, this.weight) * this.pelvis.rotation;
			for (int j = 0; j < this.feet.Length; j++)
			{
				this.SetFootIK(this.feet[j], (j < 2) ? this.maxLegOffset : this.maxForeLegOffset);
			}
			this.solved = true;
			this.solvedFeet = 0;
			if (this.OnPostGrounder != null)
			{
				this.OnPostGrounder();
			}
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x0001EE0C File Offset: 0x0001D00C
		private void UpdateForefeetRoot()
		{
			Vector3 a = Vector3.zero;
			for (int i = 0; i < this.forelegSolver.legs.Length; i++)
			{
				a += this.forelegSolver.legs[i].transform.position;
			}
			a /= (float)this.forelegs.Length;
			Vector3 vector = a - base.transform.position;
			Vector3 up = base.transform.up;
			Vector3 vector2 = vector;
			Vector3.OrthoNormalize(ref up, ref vector2);
			this.forefeetRoot.position = base.transform.position + vector2.normalized * vector.magnitude;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0001EEC4 File Offset: 0x0001D0C4
		private void SetFootIK(GrounderQuadruped.Foot foot, float maxOffset)
		{
			Vector3 vector = foot.leg.IKPosition - foot.transform.position;
			foot.solver.IKPosition = foot.transform.position + Vector3.ClampMagnitude(vector, maxOffset);
			foot.solver.IKPositionWeight = this.weight;
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0001EF20 File Offset: 0x0001D120
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
			for (int i = 0; i < this.feet.Length; i++)
			{
				this.feet[i].transform.rotation = Quaternion.Slerp(Quaternion.identity, this.feet[i].leg.rotationOffset, this.weight) * this.feet[i].rotation;
			}
			if (this.head != null)
			{
				this.head.rotation = Quaternion.Lerp(this.head.rotation, this.headRotation, this.maintainHeadRotationWeight * this.weight);
			}
			this.solvedPelvisLocalPosition = this.pelvis.localPosition;
			this.solvedPelvisLocalRotation = this.pelvis.localRotation;
			if (this.head != null)
			{
				this.solvedHeadLocalRotation = this.head.localRotation;
			}
			if (this.OnPostIK != null)
			{
				this.OnPostIK();
			}
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0001F058 File Offset: 0x0001D258
		private void OnDestroy()
		{
			if (base.initiated)
			{
				this.DestroyLegs(this.legs);
				this.DestroyLegs(this.forelegs);
			}
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0001F07C File Offset: 0x0001D27C
		private void DestroyLegs(IK[] ikComponents)
		{
			foreach (IK ik in ikComponents)
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

		// Token: 0x04000461 RID: 1121
		[Tooltip("The Grounding solver for the forelegs.")]
		public Grounding forelegSolver = new Grounding();

		// Token: 0x04000462 RID: 1122
		[Tooltip("The weight of rotating the character root to the ground angle (range: 0 - 1).")]
		[Range(0f, 1f)]
		public float rootRotationWeight = 0.5f;

		// Token: 0x04000463 RID: 1123
		[Tooltip("The maximum angle of rotating the quadruped downwards (going downhill, range: -90 - 0).")]
		[Range(-90f, 0f)]
		public float minRootRotation = -25f;

		// Token: 0x04000464 RID: 1124
		[Tooltip("The maximum angle of rotating the quadruped upwards (going uphill, range: 0 - 90).")]
		[Range(0f, 90f)]
		public float maxRootRotation = 45f;

		// Token: 0x04000465 RID: 1125
		[Tooltip("The speed of interpolating the character root rotation (range: 0 - inf).")]
		public float rootRotationSpeed = 5f;

		// Token: 0x04000466 RID: 1126
		[Tooltip("The maximum IK offset for the legs (range: 0 - inf).")]
		public float maxLegOffset = 0.5f;

		// Token: 0x04000467 RID: 1127
		[Tooltip("The maximum IK offset for the forelegs (range: 0 - inf).")]
		public float maxForeLegOffset = 0.5f;

		// Token: 0x04000468 RID: 1128
		[Tooltip("The weight of maintaining the head's rotation as it was before solving the Grounding (range: 0 - 1).")]
		[Range(0f, 1f)]
		public float maintainHeadRotationWeight = 0.5f;

		// Token: 0x04000469 RID: 1129
		[Tooltip("The root Transform of the character, with the rigidbody and the collider.")]
		public Transform characterRoot;

		// Token: 0x0400046A RID: 1130
		[Tooltip("The pelvis transform. Common ancestor of both legs and the spine.")]
		public Transform pelvis;

		// Token: 0x0400046B RID: 1131
		[Tooltip("The last bone in the spine that is the common parent for both forelegs.")]
		public Transform lastSpineBone;

		// Token: 0x0400046C RID: 1132
		[Tooltip("The head (optional, if you intend to maintain its rotation).")]
		public Transform head;

		// Token: 0x0400046D RID: 1133
		public IK[] legs;

		// Token: 0x0400046E RID: 1134
		public IK[] forelegs;

		// Token: 0x0400046F RID: 1135
		[HideInInspector]
		public Vector3 gravity = Vector3.down;

		// Token: 0x04000470 RID: 1136
		private GrounderQuadruped.Foot[] feet = new GrounderQuadruped.Foot[0];

		// Token: 0x04000471 RID: 1137
		private Vector3 animatedPelvisLocalPosition;

		// Token: 0x04000472 RID: 1138
		private Quaternion animatedPelvisLocalRotation;

		// Token: 0x04000473 RID: 1139
		private Quaternion animatedHeadLocalRotation;

		// Token: 0x04000474 RID: 1140
		private Vector3 solvedPelvisLocalPosition;

		// Token: 0x04000475 RID: 1141
		private Quaternion solvedPelvisLocalRotation;

		// Token: 0x04000476 RID: 1142
		private Quaternion solvedHeadLocalRotation;

		// Token: 0x04000477 RID: 1143
		private int solvedFeet;

		// Token: 0x04000478 RID: 1144
		private bool solved;

		// Token: 0x04000479 RID: 1145
		private float angle;

		// Token: 0x0400047A RID: 1146
		private Transform forefeetRoot;

		// Token: 0x0400047B RID: 1147
		private Quaternion headRotation;

		// Token: 0x0400047C RID: 1148
		private float lastWeight;

		// Token: 0x0400047D RID: 1149
		private Rigidbody characterRootRigidbody;

		// Token: 0x020000A4 RID: 164
		public struct Foot
		{
			// Token: 0x06000505 RID: 1285 RVA: 0x0001F176 File Offset: 0x0001D376
			public Foot(IKSolver solver, Transform transform)
			{
				this.solver = solver;
				this.transform = transform;
				this.leg = null;
				this.rotation = transform.rotation;
			}

			// Token: 0x0400047E RID: 1150
			public IKSolver solver;

			// Token: 0x0400047F RID: 1151
			public Transform transform;

			// Token: 0x04000480 RID: 1152
			public Quaternion rotation;

			// Token: 0x04000481 RID: 1153
			public Grounding.Leg leg;
		}
	}
}
