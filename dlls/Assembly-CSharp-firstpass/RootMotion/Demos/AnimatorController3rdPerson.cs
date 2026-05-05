using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000156 RID: 342
	public class AnimatorController3rdPerson : MonoBehaviour
	{
		// Token: 0x06000A5C RID: 2652 RVA: 0x00041D40 File Offset: 0x0003FF40
		protected virtual void Start()
		{
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x00041D50 File Offset: 0x0003FF50
		private void OnAnimatorMove()
		{
			this.velocity = Vector3.Lerp(this.velocity, base.transform.rotation * Vector3.ClampMagnitude(this.moveInput, 1f) * this.moveSpeed, Time.deltaTime * this.blendSpeed);
			base.transform.position += Vector3.Lerp(this.velocity * Time.deltaTime, this.animator.deltaPosition, this.rootMotionWeight);
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x00041DE4 File Offset: 0x0003FFE4
		public virtual void Move(Vector3 moveInput, bool isMoving, Vector3 faceDirection, Vector3 aimTarget)
		{
			this.moveInput = moveInput;
			Vector3 vector = base.transform.InverseTransformDirection(faceDirection);
			float num = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
			float num2 = num * Time.deltaTime * this.rotateSpeed;
			if (num > this.maxAngle)
			{
				num2 = Mathf.Clamp(num2, num - this.maxAngle, num2);
			}
			if (num < -this.maxAngle)
			{
				num2 = Mathf.Clamp(num2, num2, num + this.maxAngle);
			}
			base.transform.Rotate(Vector3.up, num2);
			this.moveBlend = Vector3.Lerp(this.moveBlend, moveInput, Time.deltaTime * this.blendSpeed);
			this.animator.SetFloat("X", this.moveBlend.x);
			this.animator.SetFloat("Z", this.moveBlend.z);
			this.animator.SetBool("IsMoving", isMoving);
		}

		// Token: 0x040009F1 RID: 2545
		public float rotateSpeed = 7f;

		// Token: 0x040009F2 RID: 2546
		public float blendSpeed = 10f;

		// Token: 0x040009F3 RID: 2547
		public float maxAngle = 90f;

		// Token: 0x040009F4 RID: 2548
		public float moveSpeed = 1.5f;

		// Token: 0x040009F5 RID: 2549
		public float rootMotionWeight;

		// Token: 0x040009F6 RID: 2550
		protected Animator animator;

		// Token: 0x040009F7 RID: 2551
		protected Vector3 moveBlend;

		// Token: 0x040009F8 RID: 2552
		protected Vector3 moveInput;

		// Token: 0x040009F9 RID: 2553
		protected Vector3 velocity;
	}
}
