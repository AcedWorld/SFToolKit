using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000075 RID: 117
	[Serializable]
	public class MuscleLite
	{
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x000166A3 File Offset: 0x000148A3
		// (set) Token: 0x060003B2 RID: 946 RVA: 0x000166AB File Offset: 0x000148AB
		public Transform transform { get; private set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060003B3 RID: 947 RVA: 0x000166B4 File Offset: 0x000148B4
		// (set) Token: 0x060003B4 RID: 948 RVA: 0x000166BC File Offset: 0x000148BC
		public Rigidbody rigidbody { get; private set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x000166C5 File Offset: 0x000148C5
		// (set) Token: 0x060003B6 RID: 950 RVA: 0x000166CD File Offset: 0x000148CD
		public Vector3 positionOffset { get; private set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x000166D6 File Offset: 0x000148D6
		// (set) Token: 0x060003B8 RID: 952 RVA: 0x000166DE File Offset: 0x000148DE
		public int index { get; private set; }

		// Token: 0x060003B9 RID: 953 RVA: 0x000166E8 File Offset: 0x000148E8
		public void Initiate(MuscleLite[] colleagues)
		{
			this.name = this.joint.name;
			this.transform = this.joint.transform;
			this.rigidbody = this.joint.GetComponent<Rigidbody>();
			if (this.joint.connectedBody != null)
			{
				for (int i = 0; i < colleagues.Length; i++)
				{
					if (colleagues[i].joint.GetComponent<Rigidbody>() == this.joint.connectedBody)
					{
						this.connectedBodyTarget = colleagues[i].target;
					}
					if (colleagues[i] == this)
					{
						this.index = i;
					}
				}
				this.joint.autoConfigureConnectedAnchor = false;
				this.connectedBodyTransform = this.joint.connectedBody.transform;
				this.directTargetParent = (this.target.parent == this.connectedBodyTarget);
			}
			this.targetParent = ((this.connectedBodyTarget != null) ? this.connectedBodyTarget : this.target.parent);
			this.toParentSpace = Quaternion.Inverse(this.targetParentRotation) * this.parentRotation;
			Vector3 normalized = Vector3.Cross(this.joint.axis, this.joint.secondaryAxis).normalized;
			Vector3 normalized2 = Vector3.Cross(normalized, this.joint.axis).normalized;
			this.defaultLocalRotation = this.localRotation;
			Quaternion quaternion = Quaternion.LookRotation(normalized, normalized2);
			this.toJointSpaceInverse = Quaternion.Inverse(quaternion);
			this.toJointSpaceDefault = this.defaultLocalRotation * quaternion;
			this.joint.rotationDriveMode = RotationDriveMode.Slerp;
			this.joint.configuredInWorldSpace = false;
			this.defaultTargetLocalPosition = this.target.localPosition;
			this.defaultTargetLocalRotation = this.target.localRotation;
			this.targetAnimatedCenterOfMass = V3Tools.TransformPointUnscaled(this.target, this.rigidbody.centerOfMass);
			if (this.joint.connectedBody == null)
			{
				this.defaultPosition = this.transform.localPosition;
				this.defaultRotation = this.transform.localRotation;
			}
			else
			{
				this.defaultPosition = this.joint.connectedBody.transform.InverseTransformPoint(this.transform.position);
				this.defaultRotation = Quaternion.Inverse(this.joint.connectedBody.transform.rotation) * this.transform.rotation;
			}
			this.rigidbody.isKinematic = false;
			this.Read();
			this.initiated = true;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00016971 File Offset: 0x00014B71
		public void FixTargetTransforms()
		{
			if (!this.initiated)
			{
				return;
			}
			this.target.localRotation = this.defaultTargetLocalRotation;
			this.target.localPosition = this.defaultTargetLocalPosition;
		}

		// Token: 0x060003BB RID: 955 RVA: 0x000169A0 File Offset: 0x00014BA0
		public void Reset()
		{
			if (!this.initiated)
			{
				return;
			}
			if (this.joint == null)
			{
				return;
			}
			if (this.joint.connectedBody == null)
			{
				this.transform.localPosition = this.defaultPosition;
				this.transform.localRotation = this.defaultRotation;
			}
			else
			{
				this.transform.position = this.joint.connectedBody.transform.TransformPoint(this.defaultPosition);
				this.transform.rotation = this.joint.connectedBody.transform.rotation * this.defaultRotation;
			}
			this.lastRotationDamper = -1f;
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00016A58 File Offset: 0x00014C58
		public void MoveToTarget()
		{
			if (!this.initiated)
			{
				return;
			}
			this.transform.SetPositionAndRotation(this.target.position, this.target.rotation);
			this.rigidbody.MovePosition(this.transform.position);
			this.rigidbody.MoveRotation(this.transform.rotation);
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00016ABC File Offset: 0x00014CBC
		public void ClearVelocities()
		{
			this.rigidbody.velocity = Vector3.zero;
			this.rigidbody.angularVelocity = Vector3.zero;
			this.targetVelocity = Vector3.zero;
			this.targetAnimatedCenterOfMass = V3Tools.TransformPointUnscaled(this.target, this.rigidbody.centerOfMass);
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00016B10 File Offset: 0x00014D10
		public void Read()
		{
			Vector3 a = V3Tools.TransformPointUnscaled(this.target, this.rigidbody.centerOfMass);
			this.targetVelocity = (a - this.targetAnimatedCenterOfMass) / Time.deltaTime;
			this.targetAnimatedCenterOfMass = a;
			if (this.joint.connectedBody != null)
			{
				this.targetAnimatedRotation = this.targetLocalRotation;
			}
			this.targetAnimatedWorldRotation = this.target.rotation;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00016B87 File Offset: 0x00014D87
		public void Update(float pinWeightMaster, float muscleWeightMaster, float muscleSpring, float muscleDamper, bool angularPinning)
		{
			this.Pin(pinWeightMaster, 4f, 0f, angularPinning);
			this.MuscleRotation(muscleWeightMaster, muscleSpring, muscleDamper);
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00016BA8 File Offset: 0x00014DA8
		private void Pin(float pinWeightMaster, float pinPow, float pinDistanceFalloff, bool angularPinning)
		{
			this.positionOffset = this.targetAnimatedCenterOfMass - this.rigidbody.worldCenterOfMass;
			if (float.IsNaN(this.positionOffset.x))
			{
				this.positionOffset = Vector3.zero;
			}
			float num = pinWeightMaster * this.pinWeightMlp;
			if (num <= 0f)
			{
				return;
			}
			num = Mathf.Pow(num, pinPow);
			if (Time.deltaTime > 0f)
			{
				this.positionOffset /= Time.deltaTime;
			}
			Vector3 vector = -this.rigidbody.velocity + this.targetVelocity + this.positionOffset;
			vector *= num;
			if (pinDistanceFalloff > 0f)
			{
				vector /= 1f + this.positionOffset.sqrMagnitude * pinDistanceFalloff;
			}
			this.rigidbody.AddForce(vector, ForceMode.VelocityChange);
			if (angularPinning)
			{
				Vector3 vector2 = PhysXTools.GetAngularAcceleration(this.rigidbody.rotation, this.targetAnimatedWorldRotation);
				vector2 -= this.rigidbody.angularVelocity;
				vector2 *= num;
				this.rigidbody.AddTorque(vector2, ForceMode.VelocityChange);
			}
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00016CD0 File Offset: 0x00014ED0
		private void MuscleRotation(float muscleWeightMaster, float muscleSpring, float muscleDamper)
		{
			float num = muscleWeightMaster * muscleSpring * this.muscleWeightMlp * 10f;
			if (this.joint.connectedBody == null)
			{
				num = 0f;
			}
			else if (num > 0f)
			{
				this.joint.targetRotation = this.LocalToJointSpace(this.targetAnimatedRotation);
			}
			float num2 = muscleDamper * this.muscleDamperMlp;
			if (num == this.lastJointDriveRotationWeight && num2 == this.lastRotationDamper)
			{
				return;
			}
			this.lastJointDriveRotationWeight = num;
			this.lastRotationDamper = num2;
			this.slerpDrive.positionSpring = num;
			this.slerpDrive.maximumForce = Mathf.Max(num, num2);
			this.slerpDrive.positionDamper = num2;
			this.joint.slerpDrive = this.slerpDrive;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00016D90 File Offset: 0x00014F90
		public void Map(float masterWeight)
		{
			float num = masterWeight * this.mappingWeightMlp;
			if (num <= 0f)
			{
				return;
			}
			Quaternion quaternion = this.transform.rotation;
			Vector3 position = this.transform.position;
			if (num >= 1f)
			{
				if (this.connectedBodyTransform != null)
				{
					Vector3 position2 = this.connectedBodyTransform.InverseTransformPoint(this.transform.position);
					position = this.connectedBodyTarget.TransformPoint(position2);
				}
				this.target.SetPositionAndRotation(position, quaternion);
				return;
			}
			quaternion = Quaternion.Lerp(this.target.rotation, quaternion, num);
			if (this.connectedBodyTransform != null)
			{
				Vector3 position3 = this.connectedBodyTransform.InverseTransformPoint(this.transform.position);
				position = Vector3.Lerp(this.target.position, this.connectedBodyTarget.TransformPoint(position3), num);
			}
			else
			{
				position = Vector3.Lerp(this.target.position, this.transform.position, num);
			}
			this.target.SetPositionAndRotation(position, quaternion);
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00016E94 File Offset: 0x00015094
		public void UpdateAnchor(bool supportTranslationAnimation)
		{
			if (this.joint.connectedBody == null || this.connectedBodyTarget == null)
			{
				return;
			}
			if (this.directTargetParent && !supportTranslationAnimation)
			{
				return;
			}
			Vector3 a = this.joint.connectedAnchor = MuscleLite.InverseTransformPointUnscaled(this.connectedBodyTarget.position, this.connectedBodyTarget.rotation * this.toParentSpace, this.target.position);
			float d = 1f / this.connectedBodyTransform.lossyScale.x;
			this.joint.connectedAnchor = a * d;
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x00016F38 File Offset: 0x00015138
		private Quaternion localRotation
		{
			get
			{
				return Quaternion.Inverse(this.parentRotation) * this.transform.rotation;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x00016F55 File Offset: 0x00015155
		private Quaternion targetLocalRotation
		{
			get
			{
				return Quaternion.Inverse(this.targetParentRotation * this.toParentSpace) * this.target.rotation;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x00016F80 File Offset: 0x00015180
		private Quaternion parentRotation
		{
			get
			{
				if (this.joint.connectedBody != null)
				{
					return this.joint.connectedBody.rotation;
				}
				if (this.transform.parent == null)
				{
					return Quaternion.identity;
				}
				return this.transform.parent.rotation;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x00016FDA File Offset: 0x000151DA
		private Quaternion targetParentRotation
		{
			get
			{
				if (this.targetParent == null)
				{
					return Quaternion.identity;
				}
				return this.targetParent.rotation;
			}
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00016FFB File Offset: 0x000151FB
		private Quaternion LocalToJointSpace(Quaternion localRotation)
		{
			return this.toJointSpaceInverse * Quaternion.Inverse(localRotation) * this.toJointSpaceDefault;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0000E1BD File Offset: 0x0000C3BD
		private static Vector3 InverseTransformPointUnscaled(Vector3 position, Quaternion rotation, Vector3 point)
		{
			return Quaternion.Inverse(rotation) * (point - position);
		}

		// Token: 0x0400033C RID: 828
		[HideInInspector]
		public string name;

		// Token: 0x0400033D RID: 829
		public ConfigurableJoint joint;

		// Token: 0x0400033E RID: 830
		public Transform target;

		// Token: 0x0400033F RID: 831
		public float pinWeightMlp = 1f;

		// Token: 0x04000340 RID: 832
		public float muscleWeightMlp = 1f;

		// Token: 0x04000341 RID: 833
		public float muscleDamperMlp = 1f;

		// Token: 0x04000342 RID: 834
		public float mappingWeightMlp = 1f;

		// Token: 0x04000347 RID: 839
		private JointDrive slerpDrive;

		// Token: 0x04000348 RID: 840
		private Quaternion defaultLocalRotation = Quaternion.identity;

		// Token: 0x04000349 RID: 841
		private Quaternion toJointSpaceInverse = Quaternion.identity;

		// Token: 0x0400034A RID: 842
		private Quaternion toJointSpaceDefault = Quaternion.identity;

		// Token: 0x0400034B RID: 843
		private Quaternion targetAnimatedRotation = Quaternion.identity;

		// Token: 0x0400034C RID: 844
		private Quaternion defaultTargetLocalRotation = Quaternion.identity;

		// Token: 0x0400034D RID: 845
		private Quaternion toParentSpace = Quaternion.identity;

		// Token: 0x0400034E RID: 846
		private Quaternion targetAnimatedWorldRotation = Quaternion.identity;

		// Token: 0x0400034F RID: 847
		private Quaternion defaultRotation = Quaternion.identity;

		// Token: 0x04000350 RID: 848
		private Vector3 defaultPosition;

		// Token: 0x04000351 RID: 849
		private Vector3 defaultTargetLocalPosition;

		// Token: 0x04000352 RID: 850
		private float lastJointDriveRotationWeight;

		// Token: 0x04000353 RID: 851
		private float lastRotationDamper;

		// Token: 0x04000354 RID: 852
		private bool initiated;

		// Token: 0x04000355 RID: 853
		private Transform connectedBodyTarget;

		// Token: 0x04000356 RID: 854
		private Transform connectedBodyTransform;

		// Token: 0x04000357 RID: 855
		private Transform targetParent;

		// Token: 0x04000358 RID: 856
		private bool directTargetParent;

		// Token: 0x04000359 RID: 857
		private Vector3 targetVelocity;

		// Token: 0x0400035A RID: 858
		private Vector3 targetAnimatedCenterOfMass;
	}
}
