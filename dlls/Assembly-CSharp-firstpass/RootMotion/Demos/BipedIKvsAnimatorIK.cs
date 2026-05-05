using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200014D RID: 333
	public class BipedIKvsAnimatorIK : MonoBehaviour
	{
		// Token: 0x06000A37 RID: 2615 RVA: 0x000409C0 File Offset: 0x0003EBC0
		private void OnAnimatorIK(int layer)
		{
			this.animator.transform.rotation = this.bipedIK.transform.rotation;
			Vector3 b = this.animator.transform.position - this.bipedIK.transform.position;
			this.lookAtTargetAnimator.position = this.lookAtTargetBiped.position + b;
			this.bipedIK.SetLookAtPosition(this.lookAtTargetBiped.position);
			this.bipedIK.SetLookAtWeight(this.lookAtWeight, this.lookAtBodyWeight, this.lookAtHeadWeight, this.lookAtEyesWeight, this.lookAtClampWeight, this.lookAtClampWeightHead, this.lookAtClampWeightEyes);
			this.animator.SetLookAtPosition(this.lookAtTargetAnimator.position);
			this.animator.SetLookAtWeight(this.lookAtWeight, this.lookAtBodyWeight, this.lookAtHeadWeight, this.lookAtEyesWeight, this.lookAtClampWeight);
			this.footTargetAnimator.position = this.footTargetBiped.position + b;
			this.footTargetAnimator.rotation = this.footTargetBiped.rotation;
			this.bipedIK.SetIKPosition(AvatarIKGoal.LeftFoot, this.footTargetBiped.position);
			this.bipedIK.SetIKRotation(AvatarIKGoal.LeftFoot, this.footTargetBiped.rotation);
			this.bipedIK.SetIKPositionWeight(AvatarIKGoal.LeftFoot, this.footPositionWeight);
			this.bipedIK.SetIKRotationWeight(AvatarIKGoal.LeftFoot, this.footRotationWeight);
			this.animator.SetIKPosition(AvatarIKGoal.LeftFoot, this.footTargetAnimator.position);
			this.animator.SetIKRotation(AvatarIKGoal.LeftFoot, this.footTargetAnimator.rotation);
			this.animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, this.footPositionWeight);
			this.animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, this.footRotationWeight);
			this.handTargetAnimator.position = this.handTargetBiped.position + b;
			this.handTargetAnimator.rotation = this.handTargetBiped.rotation;
			this.bipedIK.SetIKPosition(AvatarIKGoal.LeftHand, this.handTargetBiped.position);
			this.bipedIK.SetIKRotation(AvatarIKGoal.LeftHand, this.handTargetBiped.rotation);
			this.bipedIK.SetIKPositionWeight(AvatarIKGoal.LeftHand, this.handPositionWeight);
			this.bipedIK.SetIKRotationWeight(AvatarIKGoal.LeftHand, this.handRotationWeight);
			this.animator.SetIKPosition(AvatarIKGoal.LeftHand, this.handTargetAnimator.position);
			this.animator.SetIKRotation(AvatarIKGoal.LeftHand, this.handTargetAnimator.rotation);
			this.animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, this.handPositionWeight);
			this.animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, this.handRotationWeight);
		}

		// Token: 0x0400099E RID: 2462
		[LargeHeader("References")]
		public Animator animator;

		// Token: 0x0400099F RID: 2463
		public BipedIK bipedIK;

		// Token: 0x040009A0 RID: 2464
		[LargeHeader("Look At")]
		public Transform lookAtTargetBiped;

		// Token: 0x040009A1 RID: 2465
		public Transform lookAtTargetAnimator;

		// Token: 0x040009A2 RID: 2466
		[Range(0f, 1f)]
		public float lookAtWeight = 1f;

		// Token: 0x040009A3 RID: 2467
		[Range(0f, 1f)]
		public float lookAtBodyWeight = 1f;

		// Token: 0x040009A4 RID: 2468
		[Range(0f, 1f)]
		public float lookAtHeadWeight = 1f;

		// Token: 0x040009A5 RID: 2469
		[Range(0f, 1f)]
		public float lookAtEyesWeight = 1f;

		// Token: 0x040009A6 RID: 2470
		[Range(0f, 1f)]
		public float lookAtClampWeight = 0.5f;

		// Token: 0x040009A7 RID: 2471
		[Range(0f, 1f)]
		public float lookAtClampWeightHead = 0.5f;

		// Token: 0x040009A8 RID: 2472
		[Range(0f, 1f)]
		public float lookAtClampWeightEyes = 0.5f;

		// Token: 0x040009A9 RID: 2473
		[LargeHeader("Foot")]
		public Transform footTargetBiped;

		// Token: 0x040009AA RID: 2474
		public Transform footTargetAnimator;

		// Token: 0x040009AB RID: 2475
		[Range(0f, 1f)]
		public float footPositionWeight;

		// Token: 0x040009AC RID: 2476
		[Range(0f, 1f)]
		public float footRotationWeight;

		// Token: 0x040009AD RID: 2477
		[LargeHeader("Hand")]
		public Transform handTargetBiped;

		// Token: 0x040009AE RID: 2478
		public Transform handTargetAnimator;

		// Token: 0x040009AF RID: 2479
		[Range(0f, 1f)]
		public float handPositionWeight;

		// Token: 0x040009B0 RID: 2480
		[Range(0f, 1f)]
		public float handRotationWeight;
	}
}
