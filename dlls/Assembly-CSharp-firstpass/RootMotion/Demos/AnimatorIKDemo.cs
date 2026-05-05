using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200018D RID: 397
	[RequireComponent(typeof(Animator))]
	public class AnimatorIKDemo : MonoBehaviour
	{
		// Token: 0x06000B2D RID: 2861 RVA: 0x00046E98 File Offset: 0x00045098
		private void Start()
		{
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x00046EA6 File Offset: 0x000450A6
		private void OnAnimatorIK(int layer)
		{
			this.animator.SetIKPosition(AvatarIKGoal.LeftHand, this.leftHandIKTarget.position);
			this.animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
		}

		// Token: 0x04000B2B RID: 2859
		public Transform leftHandIKTarget;

		// Token: 0x04000B2C RID: 2860
		private Animator animator;
	}
}
