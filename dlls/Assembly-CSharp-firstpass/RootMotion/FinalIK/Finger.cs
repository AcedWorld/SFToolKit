using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x0200009A RID: 154
	[Serializable]
	public class Finger
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x0001C59F File Offset: 0x0001A79F
		// (set) Token: 0x060004A3 RID: 1187 RVA: 0x0001C5A7 File Offset: 0x0001A7A7
		public bool initiated { get; private set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x0001C5B0 File Offset: 0x0001A7B0
		// (set) Token: 0x060004A5 RID: 1189 RVA: 0x0001C5BD File Offset: 0x0001A7BD
		public Vector3 IKPosition
		{
			get
			{
				return this.solver.IKPosition;
			}
			set
			{
				this.solver.IKPosition = value;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x0001C5CB File Offset: 0x0001A7CB
		// (set) Token: 0x060004A7 RID: 1191 RVA: 0x0001C5D8 File Offset: 0x0001A7D8
		public Quaternion IKRotation
		{
			get
			{
				return this.solver.IKRotation;
			}
			set
			{
				this.solver.IKRotation = value;
			}
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x0001C5E6 File Offset: 0x0001A7E6
		public bool IsValid(ref string errorMessage)
		{
			if (this.bone1 == null || this.bone2 == null || this.tip == null)
			{
				errorMessage = "One of the bones in the Finger Rig is null, can not initiate solvers.";
				return false;
			}
			return true;
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x0001C61C File Offset: 0x0001A81C
		public void Initiate(Transform hand, int index)
		{
			this.initiated = false;
			string empty = string.Empty;
			if (!this.IsValid(ref empty))
			{
				Warning.Log(empty, hand, false);
				return;
			}
			this.solver = new IKSolverLimb();
			this.solver.IKPositionWeight = this.weight;
			this.solver.bendModifier = IKSolverLimb.BendModifier.Target;
			this.solver.bendModifierWeight = 1f;
			this.defaultBendNormal = -Vector3.Cross(this.tip.position - this.bone1.position, this.bone2.position - this.bone1.position).normalized;
			this.solver.bendNormal = this.defaultBendNormal;
			Vector3 point = Vector3.Cross(this.bone2.position - this.bone1.position, this.tip.position - this.bone1.position);
			this.bone1Axis = Quaternion.Inverse(this.bone1.rotation) * point;
			this.tipAxis = Quaternion.Inverse(this.tip.rotation) * point;
			Vector3 vector = this.bone2.position - this.bone1.position;
			Vector3 point2 = -Vector3.Cross(this.tip.position - this.bone1.position, this.bone2.position - this.bone1.position);
			Vector3.OrthoNormalize(ref vector, ref point2);
			this.bone1TwistAxis = Quaternion.Inverse(this.bone1.rotation) * point2;
			this.IKPosition = this.tip.position;
			this.IKRotation = this.tip.rotation;
			if (this.bone3 != null)
			{
				this.bone3RelativeToTarget = Quaternion.Inverse(this.IKRotation) * this.bone3.rotation;
				this.bone3DefaultLocalPosition = this.bone3.localPosition;
				this.bone3DefaultLocalRotation = this.bone3.localRotation;
			}
			this.solver.SetChain(this.bone1, this.bone2, this.tip, hand);
			this.solver.Initiate(hand);
			this.initiated = true;
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x0001C87C File Offset: 0x0001AA7C
		public void FixTransforms()
		{
			if (!this.initiated)
			{
				return;
			}
			if (this.weight <= 0f)
			{
				return;
			}
			this.solver.FixTransforms();
			if (this.bone3 != null)
			{
				this.bone3.localPosition = this.bone3DefaultLocalPosition;
				this.bone3.localRotation = this.bone3DefaultLocalRotation;
			}
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x0001C8DC File Offset: 0x0001AADC
		public void StoreDefaultLocalState()
		{
			if (!this.initiated)
			{
				return;
			}
			this.solver.StoreDefaultLocalState();
			if (this.bone3 != null)
			{
				this.bone3DefaultLocalPosition = this.bone3.localPosition;
				this.bone3DefaultLocalRotation = this.bone3.localRotation;
			}
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x0001C930 File Offset: 0x0001AB30
		public void Update(float masterWeight)
		{
			if (!this.initiated)
			{
				return;
			}
			float num = this.weight * masterWeight;
			if (num <= 0f)
			{
				return;
			}
			this.solver.target = this.target;
			if (this.target != null)
			{
				this.IKPosition = this.target.position;
				this.IKRotation = this.target.rotation;
			}
			if (this.rotationDOF == Finger.DOF.One)
			{
				Quaternion lhs = Quaternion.FromToRotation(this.IKRotation * this.tipAxis, this.bone1.rotation * this.bone1Axis);
				this.IKRotation = lhs * this.IKRotation;
			}
			if (this.bone3 != null)
			{
				if (num * this.rotationWeight >= 1f)
				{
					this.bone3.rotation = this.IKRotation * this.bone3RelativeToTarget;
				}
				else
				{
					this.bone3.rotation = Quaternion.Lerp(this.bone3.rotation, this.IKRotation * this.bone3RelativeToTarget, num * this.rotationWeight);
				}
			}
			this.solver.IKPositionWeight = num;
			this.solver.IKRotationWeight = this.rotationWeight;
			this.solver.Update();
			if (this.fixBone1Twist)
			{
				Quaternion rotation = this.bone2.rotation;
				Vector3 vector = Quaternion.Inverse(Quaternion.LookRotation(this.bone1.rotation * this.bone1TwistAxis, this.bone2.position - this.bone1.position)) * this.solver.bendNormal;
				float angle = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
				this.bone1.rotation = Quaternion.AngleAxis(angle, this.bone2.position - this.bone1.position) * this.bone1.rotation;
				this.bone2.rotation = rotation;
			}
		}

		// Token: 0x04000422 RID: 1058
		[Tooltip("Master Weight for the finger.")]
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x04000423 RID: 1059
		[Tooltip("The weight of rotating the finger tip and bending the finger to the target.")]
		[Range(0f, 1f)]
		public float rotationWeight = 1f;

		// Token: 0x04000424 RID: 1060
		[Tooltip("Rotational degrees of freedom. When set to 'One' the fingers will be able to be rotated only around a single axis. When 3, all 3 axes are free to rotate around.")]
		public Finger.DOF rotationDOF;

		// Token: 0x04000425 RID: 1061
		[Tooltip("If enabled, keeps bone1 twist angle fixed relative to bone2.")]
		public bool fixBone1Twist;

		// Token: 0x04000426 RID: 1062
		[Tooltip("The first bone of the finger.")]
		public Transform bone1;

		// Token: 0x04000427 RID: 1063
		[Tooltip("The second bone of the finger.")]
		public Transform bone2;

		// Token: 0x04000428 RID: 1064
		[Tooltip("The (optional) third bone of the finger. This can be ignored for thumbs.")]
		public Transform bone3;

		// Token: 0x04000429 RID: 1065
		[Tooltip("The fingertip object. If your character doesn't have tip bones, you can create an empty GameObject and parent it to the last bone in the finger. Place it to the tip of the finger.")]
		public Transform tip;

		// Token: 0x0400042A RID: 1066
		[Tooltip("The IK target (optional, can use IKPosition and IKRotation directly).")]
		public Transform target;

		// Token: 0x0400042C RID: 1068
		private IKSolverLimb solver;

		// Token: 0x0400042D RID: 1069
		private Quaternion bone3RelativeToTarget;

		// Token: 0x0400042E RID: 1070
		private Vector3 bone3DefaultLocalPosition;

		// Token: 0x0400042F RID: 1071
		private Quaternion bone3DefaultLocalRotation;

		// Token: 0x04000430 RID: 1072
		private Vector3 bone1Axis;

		// Token: 0x04000431 RID: 1073
		private Vector3 tipAxis;

		// Token: 0x04000432 RID: 1074
		private Vector3 bone1TwistAxis;

		// Token: 0x04000433 RID: 1075
		private Vector3 defaultBendNormal;

		// Token: 0x0200009B RID: 155
		[Serializable]
		public enum DOF
		{
			// Token: 0x04000435 RID: 1077
			One,
			// Token: 0x04000436 RID: 1078
			Three
		}
	}
}
