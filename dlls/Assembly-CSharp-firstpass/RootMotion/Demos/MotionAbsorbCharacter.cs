using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200016D RID: 365
	public class MotionAbsorbCharacter : MonoBehaviour
	{
		// Token: 0x06000AB5 RID: 2741 RVA: 0x0004466A File Offset: 0x0004286A
		private void Start()
		{
			this.cubeDefaultPosition = this.cube.position;
			this.cubeRigidbody = this.cube.GetComponent<Rigidbody>();
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x00044690 File Offset: 0x00042890
		private void Update()
		{
			this.info = this.animator.GetCurrentAnimatorStateInfo(0);
			this.motionAbsorb.weight = this.motionAbsorbWeight.Evaluate(this.info.normalizedTime - (float)((int)this.info.normalizedTime));
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x000446E0 File Offset: 0x000428E0
		private void SwingStart()
		{
			this.cubeRigidbody.MovePosition(this.cubeDefaultPosition + Random.insideUnitSphere * this.cubeRandomPosition);
			this.cubeRigidbody.MoveRotation(Quaternion.identity);
			this.cubeRigidbody.velocity = Vector3.zero;
			this.cubeRigidbody.angularVelocity = Vector3.zero;
		}

		// Token: 0x04000A83 RID: 2691
		public Animator animator;

		// Token: 0x04000A84 RID: 2692
		public MotionAbsorb motionAbsorb;

		// Token: 0x04000A85 RID: 2693
		public Transform cube;

		// Token: 0x04000A86 RID: 2694
		public float cubeRandomPosition = 0.1f;

		// Token: 0x04000A87 RID: 2695
		public AnimationCurve motionAbsorbWeight;

		// Token: 0x04000A88 RID: 2696
		private Vector3 cubeDefaultPosition;

		// Token: 0x04000A89 RID: 2697
		private AnimatorStateInfo info;

		// Token: 0x04000A8A RID: 2698
		private Rigidbody cubeRigidbody;
	}
}
