using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200014A RID: 330
	public class SecondHandOnGun : MonoBehaviour
	{
		// Token: 0x06000A2B RID: 2603 RVA: 0x000404E4 File Offset: 0x0003E6E4
		private void Start()
		{
			this.aim.enabled = false;
			this.leftArmIK.enabled = false;
			if (this.grounder != null)
			{
				this.grounder.ik.enabled = false;
			}
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x00040520 File Offset: 0x0003E720
		private void LateUpdate()
		{
			this.leftHandPosRelToRight = this.rightHand.InverseTransformPoint(this.leftHand.position);
			this.leftHandRotRelToRight = Quaternion.Inverse(this.rightHand.rotation) * this.leftHand.rotation;
			if (this.grounder != null)
			{
				this.grounder.ik.solver.Update();
			}
			this.aim.solver.Update();
			this.leftArmIK.solver.IKPosition = this.rightHand.TransformPoint(this.leftHandPosRelToRight + this.leftHandPositionOffset);
			this.leftArmIK.solver.IKRotation = this.rightHand.rotation * Quaternion.Euler(this.leftHandRotationOffset) * this.leftHandRotRelToRight;
			this.leftArmIK.solver.Update();
		}

		// Token: 0x04000985 RID: 2437
		public AimIK aim;

		// Token: 0x04000986 RID: 2438
		public LimbIK leftArmIK;

		// Token: 0x04000987 RID: 2439
		public Transform leftHand;

		// Token: 0x04000988 RID: 2440
		public Transform rightHand;

		// Token: 0x04000989 RID: 2441
		public GrounderFBBIK grounder;

		// Token: 0x0400098A RID: 2442
		public Vector3 leftHandPositionOffset;

		// Token: 0x0400098B RID: 2443
		public Vector3 leftHandRotationOffset;

		// Token: 0x0400098C RID: 2444
		private Vector3 leftHandPosRelToRight;

		// Token: 0x0400098D RID: 2445
		private Quaternion leftHandRotRelToRight;
	}
}
