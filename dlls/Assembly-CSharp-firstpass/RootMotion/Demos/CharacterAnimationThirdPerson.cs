using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001BB RID: 443
	public class CharacterAnimationThirdPerson : CharacterAnimationBase
	{
		// Token: 0x06000BE3 RID: 3043 RVA: 0x000498D7 File Offset: 0x00047AD7
		protected override void Start()
		{
			base.Start();
			this.animator = base.GetComponent<Animator>();
			this.lastForward = base.transform.forward;
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x000498FC File Offset: 0x00047AFC
		public override Vector3 GetPivotPoint()
		{
			return this.animator.pivotPosition;
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000BE5 RID: 3045 RVA: 0x0004990C File Offset: 0x00047B0C
		public override bool animationGrounded
		{
			get
			{
				return this.animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded Directional") || this.animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded Strafe");
			}
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x00049950 File Offset: 0x00047B50
		protected virtual void Update()
		{
			if (Time.deltaTime == 0f)
			{
				return;
			}
			this.animatePhysics = (this.animator.updateMode == AnimatorUpdateMode.AnimatePhysics);
			if (this.characterController.animState.jump && !this.lastJump)
			{
				float value = (float)((Mathf.Repeat(this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime + this.runCycleLegOffset, 1f) < 0.5f) ? 1 : -1) * this.characterController.animState.moveDirection.z;
				this.animator.SetFloat("JumpLeg", value);
			}
			this.lastJump = this.characterController.animState.jump;
			float num = -base.GetAngleFromForward(this.lastForward) - this.deltaAngle;
			this.deltaAngle = 0f;
			this.lastForward = base.transform.forward;
			num *= this.turnSensitivity * 0.01f;
			num = Mathf.Clamp(num / Time.deltaTime, -1f, 1f);
			this.animator.SetFloat("Turn", Mathf.Lerp(this.animator.GetFloat("Turn"), num, Time.deltaTime * this.turnSpeed));
			this.animator.SetFloat("Forward", this.characterController.animState.moveDirection.z);
			this.animator.SetFloat("Right", this.characterController.animState.moveDirection.x);
			this.animator.SetBool("Crouch", this.characterController.animState.crouch);
			this.animator.SetBool("OnGround", this.characterController.animState.onGround);
			this.animator.SetBool("IsStrafing", this.characterController.animState.isStrafing);
			if (!this.characterController.animState.onGround)
			{
				this.animator.SetFloat("Jump", this.characterController.animState.yVelocity);
			}
			if (this.characterController.doubleJumpEnabled)
			{
				this.animator.SetBool("DoubleJump", this.characterController.animState.doubleJump);
			}
			this.characterController.animState.doubleJump = false;
			if (this.characterController.animState.onGround && this.characterController.animState.moveDirection.z > 0f)
			{
				this.animator.speed = this.animSpeedMultiplier;
				return;
			}
			this.animator.speed = 1f;
		}

		// Token: 0x06000BE7 RID: 3047 RVA: 0x00049BFC File Offset: 0x00047DFC
		private void OnAnimatorMove()
		{
			Vector3 vector = this.animator.deltaRotation * Vector3.forward;
			this.deltaAngle += Mathf.Atan2(vector.x, vector.z) * 57.29578f;
			if (this.characterController.fullRootMotion)
			{
				this.characterController.transform.position += this.animator.deltaPosition;
				this.characterController.transform.rotation *= this.animator.deltaRotation;
				return;
			}
			this.characterController.Move(this.animator.deltaPosition, this.animator.deltaRotation);
		}

		// Token: 0x04000BFE RID: 3070
		public CharacterThirdPerson characterController;

		// Token: 0x04000BFF RID: 3071
		[SerializeField]
		private float turnSensitivity = 0.2f;

		// Token: 0x04000C00 RID: 3072
		[SerializeField]
		private float turnSpeed = 5f;

		// Token: 0x04000C01 RID: 3073
		[SerializeField]
		private float runCycleLegOffset = 0.2f;

		// Token: 0x04000C02 RID: 3074
		[Range(0.1f, 3f)]
		[SerializeField]
		private float animSpeedMultiplier = 1f;

		// Token: 0x04000C03 RID: 3075
		protected Animator animator;

		// Token: 0x04000C04 RID: 3076
		private Vector3 lastForward;

		// Token: 0x04000C05 RID: 3077
		private const string groundedDirectional = "Grounded Directional";

		// Token: 0x04000C06 RID: 3078
		private const string groundedStrafe = "Grounded Strafe";

		// Token: 0x04000C07 RID: 3079
		private float deltaAngle;

		// Token: 0x04000C08 RID: 3080
		private float jumpLeg;

		// Token: 0x04000C09 RID: 3081
		private bool lastJump;
	}
}
