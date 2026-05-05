using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000037 RID: 55
	public class Actuator : MonoBehaviour
	{
		// Token: 0x06000158 RID: 344 RVA: 0x000086E0 File Offset: 0x000068E0
		private void Start()
		{
			this.r = base.GetComponent<Rigidbody>();
			this.joint = base.GetComponent<ConfigurableJoint>();
			if (this.joint == null)
			{
				Debug.LogError("Actuator requires a ConfigurableJoint!");
				base.enabled = false;
				return;
			}
			Vector3 normalized = Vector3.Cross(this.joint.axis, this.joint.secondaryAxis).normalized;
			Vector3 normalized2 = Vector3.Cross(normalized, this.joint.axis).normalized;
			Quaternion localRotation = base.transform.localRotation;
			Quaternion quaternion = Quaternion.LookRotation(normalized, normalized2);
			this.toJointSpaceInverse = Quaternion.Inverse(quaternion);
			this.toJointSpaceDefault = localRotation * quaternion;
			this.joint.rotationDriveMode = RotationDriveMode.Slerp;
			this.joint.configuredInWorldSpace = false;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x000087A8 File Offset: 0x000069A8
		private void FixedUpdate()
		{
			if (this.r.isKinematic)
			{
				return;
			}
			if (this.spring > 0f)
			{
				this.joint.targetRotation = this.LocalToJointSpace(this.target.localRotation);
			}
			if (this.spring == this.lastSpring && this.damper == this.lastDamper)
			{
				return;
			}
			this.lastSpring = this.spring;
			this.lastDamper = this.damper;
			this.slerpDrive.positionSpring = this.spring;
			this.slerpDrive.positionDamper = this.damper;
			this.slerpDrive.maximumForce = Mathf.Max(this.spring, this.damper);
			this.joint.slerpDrive = this.slerpDrive;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00008870 File Offset: 0x00006A70
		private Quaternion LocalToJointSpace(Quaternion localRotation)
		{
			return this.toJointSpaceInverse * Quaternion.Inverse(localRotation) * this.toJointSpaceDefault;
		}

		// Token: 0x0400011F RID: 287
		public Transform target;

		// Token: 0x04000120 RID: 288
		public float spring = 1000f;

		// Token: 0x04000121 RID: 289
		public float damper = 100f;

		// Token: 0x04000122 RID: 290
		private Rigidbody r;

		// Token: 0x04000123 RID: 291
		private ConfigurableJoint joint;

		// Token: 0x04000124 RID: 292
		private Quaternion toJointSpaceInverse = Quaternion.identity;

		// Token: 0x04000125 RID: 293
		private Quaternion toJointSpaceDefault = Quaternion.identity;

		// Token: 0x04000126 RID: 294
		private JointDrive slerpDrive;

		// Token: 0x04000127 RID: 295
		private float lastSpring;

		// Token: 0x04000128 RID: 296
		private float lastDamper;
	}
}
