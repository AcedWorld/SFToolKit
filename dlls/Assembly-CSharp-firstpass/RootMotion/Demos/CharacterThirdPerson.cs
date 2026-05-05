using System;
using System.Collections;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001BD RID: 445
	public class CharacterThirdPerson : CharacterBase
	{
		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000BF4 RID: 3060 RVA: 0x0004A079 File Offset: 0x00048279
		// (set) Token: 0x06000BF5 RID: 3061 RVA: 0x0004A081 File Offset: 0x00048281
		public bool fullRootMotion { get; set; }

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000BF6 RID: 3062 RVA: 0x0004A08A File Offset: 0x0004828A
		// (set) Token: 0x06000BF7 RID: 3063 RVA: 0x0004A092 File Offset: 0x00048292
		public bool onGround { get; private set; }

		// Token: 0x06000BF8 RID: 3064 RVA: 0x0004A09C File Offset: 0x0004829C
		protected override void Start()
		{
			base.Start();
			this.animator = base.GetComponent<Animator>();
			if (this.animator == null)
			{
				this.animator = this.characterAnimation.GetComponent<Animator>();
			}
			this.wallNormal = -this.gravity.normalized;
			this.onGround = true;
			this.animState.onGround = true;
			if (this.cam != null)
			{
				this.cam.enabled = false;
			}
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x0004A11D File Offset: 0x0004831D
		private void OnAnimatorMove()
		{
			this.Move(this.animator.deltaPosition, this.animator.deltaRotation);
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x0004A13B File Offset: 0x0004833B
		public override void Move(Vector3 deltaPosition, Quaternion deltaRotation)
		{
			this.fixedDeltaTime += Time.deltaTime;
			this.fixedDeltaPosition += deltaPosition;
			this.fixedDeltaRotation *= deltaRotation;
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x0004A174 File Offset: 0x00048374
		private void FixedUpdate()
		{
			this.gravity = (this.fullRootMotion ? Vector3.zero : base.GetGravity());
			this.verticalVelocity = V3Tools.ExtractVertical(this.r.velocity, this.gravity, 1f);
			this.velocityY = this.verticalVelocity.magnitude;
			if (Vector3.Dot(this.verticalVelocity, this.gravity) > 0f)
			{
				this.velocityY = -this.velocityY;
			}
			this.r.interpolation = (this.smoothPhysics ? RigidbodyInterpolation.Interpolate : RigidbodyInterpolation.None);
			this.characterAnimation.smoothFollow = this.smoothPhysics;
			this.MoveFixed(this.fixedDeltaPosition);
			this.fixedDeltaTime = 0f;
			this.fixedDeltaPosition = Vector3.zero;
			this.r.MoveRotation(base.transform.rotation * this.fixedDeltaRotation);
			this.fixedDeltaRotation = Quaternion.identity;
			this.Rotate();
			this.GroundCheck();
			if (this.userControl.state.move == Vector3.zero && this.groundDistance < this.airborneThreshold * 0.5f)
			{
				base.HighFriction();
			}
			else
			{
				base.ZeroFriction();
			}
			bool flag = !this.fullRootMotion && this.onGround && this.userControl.state.move == Vector3.zero && this.r.velocity.magnitude < 0.5f && this.groundDistance < this.airborneThreshold * 0.5f;
			if (this.gravityTarget != null)
			{
				this.r.useGravity = false;
				if (!flag)
				{
					this.r.AddForce(this.gravity);
				}
			}
			if (flag)
			{
				this.r.useGravity = false;
				this.r.velocity = Vector3.zero;
			}
			else if (this.gravityTarget == null)
			{
				this.r.useGravity = true;
			}
			if (this.onGround)
			{
				this.animState.jump = this.Jump();
				this.jumpReleased = false;
				this.doubleJumped = false;
			}
			else
			{
				if (!this.userControl.state.jump)
				{
					this.jumpReleased = true;
				}
				if (this.jumpReleased && this.userControl.state.jump && !this.doubleJumped && this.doubleJumpEnabled)
				{
					this.jumpEndTime = Time.time + 0.1f;
					this.animState.doubleJump = true;
					Vector3 velocity = this.userControl.state.move * this.airSpeed;
					this.r.velocity = velocity;
					this.r.velocity += base.transform.up * this.jumpPower * this.doubleJumpPowerMlp;
					this.doubleJumped = true;
				}
			}
			base.ScaleCapsule(this.userControl.state.crouch ? this.crouchCapsuleScaleMlp : 1f);
			this.fixedFrame = true;
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x0004A4A4 File Offset: 0x000486A4
		protected virtual void Update()
		{
			this.animState.onGround = this.onGround;
			this.animState.moveDirection = this.GetMoveDirection();
			this.animState.yVelocity = Mathf.Lerp(this.animState.yVelocity, this.velocityY, Time.deltaTime * 10f);
			this.animState.crouch = this.userControl.state.crouch;
			this.animState.isStrafing = (this.moveMode == CharacterThirdPerson.MoveMode.Strafe);
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x0004A530 File Offset: 0x00048730
		protected virtual void LateUpdate()
		{
			if (this.cam == null)
			{
				return;
			}
			this.cam.UpdateInput();
			if (!this.fixedFrame && this.r.interpolation == RigidbodyInterpolation.None)
			{
				return;
			}
			this.cam.UpdateTransform((this.r.interpolation == RigidbodyInterpolation.None) ? Time.fixedDeltaTime : Time.deltaTime);
			this.fixedFrame = false;
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x0004A598 File Offset: 0x00048798
		private void MoveFixed(Vector3 deltaPosition)
		{
			this.WallRun();
			Vector3 vector = (this.fixedDeltaTime > 0f) ? (deltaPosition / this.fixedDeltaTime) : Vector3.zero;
			if (!this.fullRootMotion)
			{
				vector += V3Tools.ExtractHorizontal(this.platformVelocity, this.gravity, 1f);
				if (this.onGround)
				{
					if (this.velocityToGroundTangentWeight > 0f)
					{
						Quaternion b = Quaternion.FromToRotation(base.transform.up, this.normal);
						vector = Quaternion.Lerp(Quaternion.identity, b, this.velocityToGroundTangentWeight) * vector;
					}
				}
				else
				{
					Vector3 b2 = V3Tools.ExtractHorizontal(this.userControl.state.move * this.airSpeed, this.gravity, 1f);
					vector = Vector3.Lerp(this.r.velocity, b2, Time.deltaTime * this.airControl);
				}
				if (this.onGround && Time.time > this.jumpEndTime)
				{
					this.r.velocity = this.r.velocity - base.transform.up * this.stickyForce * Time.deltaTime;
				}
				Vector3 vector2 = V3Tools.ExtractVertical(this.r.velocity, this.gravity, 1f);
				Vector3 a = V3Tools.ExtractHorizontal(vector, this.gravity, 1f);
				if (this.onGround && Vector3.Dot(vector2, this.gravity) < 0f)
				{
					vector2 = Vector3.ClampMagnitude(vector2, this.maxVerticalVelocityOnGround);
				}
				this.r.velocity = a + vector2;
			}
			else
			{
				this.r.velocity = vector;
			}
			this.forwardMlp = 1f;
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x0004A758 File Offset: 0x00048958
		private void WallRun()
		{
			bool flag = this.CanWallRun();
			if (this.wallRunWeight > 0f && !flag)
			{
				this.wallRunEndTime = Time.time;
			}
			if (Time.time < this.wallRunEndTime + 0.5f)
			{
				flag = false;
			}
			this.wallRunWeight = Mathf.MoveTowards(this.wallRunWeight, flag ? 1f : 0f, Time.deltaTime * this.wallRunWeightSpeed);
			if (this.wallRunWeight <= 0f && this.lastWallRunWeight > 0f)
			{
				Vector3 forward = V3Tools.ExtractHorizontal(base.transform.forward, this.gravity, 1f);
				base.transform.rotation = Quaternion.LookRotation(forward, -this.gravity);
				this.wallNormal = -this.gravity.normalized;
			}
			this.lastWallRunWeight = this.wallRunWeight;
			if (this.wallRunWeight <= 0f)
			{
				return;
			}
			if (this.onGround && this.velocityY < 0f)
			{
				this.r.velocity = V3Tools.ExtractHorizontal(this.r.velocity, this.gravity, 1f);
			}
			Vector3 vector = V3Tools.ExtractHorizontal(base.transform.forward, this.gravity, 1f);
			RaycastHit raycastHit = default(RaycastHit);
			raycastHit.normal = -this.gravity.normalized;
			Physics.Raycast(this.onGround ? base.transform.position : this.capsule.bounds.center, vector, out raycastHit, 3f, this.wallRunLayers);
			this.wallNormal = Vector3.Lerp(this.wallNormal, raycastHit.normal, Time.deltaTime * this.wallRunRotationSpeed);
			this.wallNormal = Vector3.RotateTowards(-this.gravity.normalized, this.wallNormal, this.wallRunMaxRotationAngle * 0.017453292f, 0f);
			Vector3 forward2 = base.transform.forward;
			Vector3 vector2 = this.wallNormal;
			Vector3.OrthoNormalize(ref vector2, ref forward2);
			base.transform.rotation = Quaternion.Slerp(Quaternion.LookRotation(vector, -this.gravity), Quaternion.LookRotation(forward2, this.wallNormal), this.wallRunWeight);
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x0004A9AC File Offset: 0x00048BAC
		private bool CanWallRun()
		{
			return !this.fullRootMotion && Time.time >= this.jumpEndTime - 0.1f && Time.time <= this.jumpEndTime - 0.1f + this.wallRunMaxLength && this.velocityY >= this.wallRunMinVelocityY && this.userControl.state.move.magnitude >= this.wallRunMinMoveMag;
		}

		// Token: 0x06000C01 RID: 3073 RVA: 0x0004AA24 File Offset: 0x00048C24
		private Vector3 GetMoveDirection()
		{
			CharacterThirdPerson.MoveMode moveMode = this.moveMode;
			if (moveMode == CharacterThirdPerson.MoveMode.Directional)
			{
				this.moveDirection = Vector3.SmoothDamp(this.moveDirection, new Vector3(0f, 0f, this.userControl.state.move.magnitude), ref this.moveDirectionVelocity, this.smoothAccelerationTime);
				this.moveDirection = Vector3.MoveTowards(this.moveDirection, new Vector3(0f, 0f, this.userControl.state.move.magnitude), Time.deltaTime * this.linearAccelerationSpeed);
				return this.moveDirection * this.forwardMlp;
			}
			if (moveMode != CharacterThirdPerson.MoveMode.Strafe)
			{
				return Vector3.zero;
			}
			this.moveDirection = Vector3.SmoothDamp(this.moveDirection, this.userControl.state.move, ref this.moveDirectionVelocity, this.smoothAccelerationTime);
			this.moveDirection = Vector3.MoveTowards(this.moveDirection, this.userControl.state.move, Time.deltaTime * this.linearAccelerationSpeed);
			return base.transform.InverseTransformDirection(this.moveDirection);
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x0004AB4C File Offset: 0x00048D4C
		protected virtual void Rotate()
		{
			if (this.gravityTarget != null)
			{
				this.r.MoveRotation(Quaternion.FromToRotation(base.transform.up, base.transform.position - this.gravityTarget.position) * base.transform.rotation);
			}
			if (this.platformAngularVelocity != Vector3.zero)
			{
				this.r.MoveRotation(Quaternion.Euler(this.platformAngularVelocity) * base.transform.rotation);
			}
			float num = base.GetAngleFromForward(this.GetForwardDirection());
			if (this.userControl.state.move == Vector3.zero)
			{
				num *= (1.01f - Mathf.Abs(num) / 180f) * this.stationaryTurnSpeedMlp;
			}
			this.r.MoveRotation(Quaternion.AngleAxis(num * Time.deltaTime * this.turnSpeed, base.transform.up) * this.r.rotation);
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x0004AC64 File Offset: 0x00048E64
		private Vector3 GetForwardDirection()
		{
			bool flag = this.userControl.state.move != Vector3.zero;
			CharacterThirdPerson.MoveMode moveMode = this.moveMode;
			if (moveMode != CharacterThirdPerson.MoveMode.Directional)
			{
				if (moveMode != CharacterThirdPerson.MoveMode.Strafe)
				{
					return Vector3.zero;
				}
				if (flag)
				{
					return this.userControl.state.lookPos - this.r.position;
				}
				if (!this.lookInCameraDirection)
				{
					return base.transform.forward;
				}
				return this.userControl.state.lookPos - this.r.position;
			}
			else
			{
				if (flag)
				{
					return this.userControl.state.move;
				}
				if (!this.lookInCameraDirection)
				{
					return base.transform.forward;
				}
				return this.userControl.state.lookPos - this.r.position;
			}
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x0004AD48 File Offset: 0x00048F48
		protected virtual bool Jump()
		{
			if (!this.userControl.state.jump)
			{
				return false;
			}
			if (this.userControl.state.crouch)
			{
				return false;
			}
			if (!this.characterAnimation.animationGrounded)
			{
				return false;
			}
			if (Time.time < this.lastAirTime + this.jumpRepeatDelayTime)
			{
				return false;
			}
			this.onGround = false;
			this.jumpEndTime = Time.time + 0.1f;
			Vector3 vector = this.userControl.state.move * this.airSpeed;
			vector += base.transform.up * this.jumpPower;
			if (this.smoothJump)
			{
				base.StopAllCoroutines();
				base.StartCoroutine(this.JumpSmooth(vector - this.r.velocity));
			}
			else
			{
				this.r.velocity = vector;
			}
			return true;
		}

		// Token: 0x06000C05 RID: 3077 RVA: 0x0004AE2E File Offset: 0x0004902E
		private IEnumerator JumpSmooth(Vector3 jumpVelocity)
		{
			int steps = 0;
			int stepsToTake = 3;
			while (steps < stepsToTake)
			{
				this.r.AddForce(jumpVelocity / (float)stepsToTake, ForceMode.VelocityChange);
				int num = steps;
				steps = num + 1;
				yield return new WaitForFixedUpdate();
			}
			yield break;
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x0004AE44 File Offset: 0x00049044
		private void GroundCheck()
		{
			Vector3 b = Vector3.zero;
			this.platformAngularVelocity = Vector3.zero;
			float num = 0f;
			this.hit = this.GetSpherecastHit();
			this.normal = base.transform.up;
			this.groundDistance = Vector3.Project(this.r.position - this.hit.point, base.transform.up).magnitude;
			if (Time.time > this.jumpEndTime && this.velocityY < this.jumpPower * 0.5f)
			{
				bool onGround = this.onGround;
				this.onGround = false;
				float num2 = (!onGround) ? (this.airborneThreshold * 0.5f) : this.airborneThreshold;
				float magnitude = V3Tools.ExtractHorizontal(this.r.velocity, this.gravity, 1f).magnitude;
				if (this.groundDistance < num2)
				{
					num = this.groundStickyEffect * magnitude * num2;
					if (this.hit.rigidbody != null)
					{
						b = this.hit.rigidbody.GetPointVelocity(this.hit.point);
						this.platformAngularVelocity = Vector3.Project(this.hit.rigidbody.angularVelocity, base.transform.up);
					}
					this.onGround = true;
				}
			}
			this.platformVelocity = Vector3.Lerp(this.platformVelocity, b, Time.deltaTime * this.platformFriction);
			if (this.fullRootMotion)
			{
				this.stickyForce = 0f;
			}
			this.stickyForce = num;
			if (!this.onGround)
			{
				this.lastAirTime = Time.time;
			}
		}

		// Token: 0x04000C18 RID: 3096
		[Header("References")]
		public CharacterAnimationBase characterAnimation;

		// Token: 0x04000C19 RID: 3097
		public UserControlThirdPerson userControl;

		// Token: 0x04000C1A RID: 3098
		public CameraController cam;

		// Token: 0x04000C1B RID: 3099
		[Header("Movement")]
		public CharacterThirdPerson.MoveMode moveMode;

		// Token: 0x04000C1C RID: 3100
		public bool smoothPhysics = true;

		// Token: 0x04000C1D RID: 3101
		public float smoothAccelerationTime = 0.2f;

		// Token: 0x04000C1E RID: 3102
		public float linearAccelerationSpeed = 3f;

		// Token: 0x04000C1F RID: 3103
		public float platformFriction = 7f;

		// Token: 0x04000C20 RID: 3104
		public float groundStickyEffect = 4f;

		// Token: 0x04000C21 RID: 3105
		public float maxVerticalVelocityOnGround = 3f;

		// Token: 0x04000C22 RID: 3106
		public float velocityToGroundTangentWeight;

		// Token: 0x04000C23 RID: 3107
		[Header("Rotation")]
		public bool lookInCameraDirection;

		// Token: 0x04000C24 RID: 3108
		public float turnSpeed = 5f;

		// Token: 0x04000C25 RID: 3109
		public float stationaryTurnSpeedMlp = 1f;

		// Token: 0x04000C26 RID: 3110
		[Header("Jumping and Falling")]
		public bool smoothJump = true;

		// Token: 0x04000C27 RID: 3111
		public float airSpeed = 6f;

		// Token: 0x04000C28 RID: 3112
		public float airControl = 2f;

		// Token: 0x04000C29 RID: 3113
		public float jumpPower = 12f;

		// Token: 0x04000C2A RID: 3114
		public float jumpRepeatDelayTime;

		// Token: 0x04000C2B RID: 3115
		public bool doubleJumpEnabled;

		// Token: 0x04000C2C RID: 3116
		public float doubleJumpPowerMlp = 1f;

		// Token: 0x04000C2D RID: 3117
		[Header("Wall Running")]
		public LayerMask wallRunLayers;

		// Token: 0x04000C2E RID: 3118
		public float wallRunMaxLength = 1f;

		// Token: 0x04000C2F RID: 3119
		public float wallRunMinMoveMag = 0.6f;

		// Token: 0x04000C30 RID: 3120
		public float wallRunMinVelocityY = -1f;

		// Token: 0x04000C31 RID: 3121
		public float wallRunRotationSpeed = 1.5f;

		// Token: 0x04000C32 RID: 3122
		public float wallRunMaxRotationAngle = 70f;

		// Token: 0x04000C33 RID: 3123
		public float wallRunWeightSpeed = 5f;

		// Token: 0x04000C34 RID: 3124
		[Header("Crouching")]
		public float crouchCapsuleScaleMlp = 0.6f;

		// Token: 0x04000C37 RID: 3127
		public CharacterThirdPerson.AnimState animState;

		// Token: 0x04000C38 RID: 3128
		protected Vector3 moveDirection;

		// Token: 0x04000C39 RID: 3129
		private Animator animator;

		// Token: 0x04000C3A RID: 3130
		private Vector3 normal;

		// Token: 0x04000C3B RID: 3131
		private Vector3 platformVelocity;

		// Token: 0x04000C3C RID: 3132
		private Vector3 platformAngularVelocity;

		// Token: 0x04000C3D RID: 3133
		private RaycastHit hit;

		// Token: 0x04000C3E RID: 3134
		private float jumpLeg;

		// Token: 0x04000C3F RID: 3135
		private float jumpEndTime;

		// Token: 0x04000C40 RID: 3136
		private float forwardMlp;

		// Token: 0x04000C41 RID: 3137
		private float groundDistance;

		// Token: 0x04000C42 RID: 3138
		private float lastAirTime;

		// Token: 0x04000C43 RID: 3139
		private float stickyForce;

		// Token: 0x04000C44 RID: 3140
		private Vector3 wallNormal = Vector3.up;

		// Token: 0x04000C45 RID: 3141
		private Vector3 moveDirectionVelocity;

		// Token: 0x04000C46 RID: 3142
		private float wallRunWeight;

		// Token: 0x04000C47 RID: 3143
		private float lastWallRunWeight;

		// Token: 0x04000C48 RID: 3144
		private float fixedDeltaTime;

		// Token: 0x04000C49 RID: 3145
		private Vector3 fixedDeltaPosition;

		// Token: 0x04000C4A RID: 3146
		private Quaternion fixedDeltaRotation = Quaternion.identity;

		// Token: 0x04000C4B RID: 3147
		private bool fixedFrame;

		// Token: 0x04000C4C RID: 3148
		private float wallRunEndTime;

		// Token: 0x04000C4D RID: 3149
		private Vector3 gravity;

		// Token: 0x04000C4E RID: 3150
		private Vector3 verticalVelocity;

		// Token: 0x04000C4F RID: 3151
		private float velocityY;

		// Token: 0x04000C50 RID: 3152
		private bool doubleJumped;

		// Token: 0x04000C51 RID: 3153
		private bool jumpReleased;

		// Token: 0x020001BE RID: 446
		[Serializable]
		public enum MoveMode
		{
			// Token: 0x04000C53 RID: 3155
			Directional,
			// Token: 0x04000C54 RID: 3156
			Strafe
		}

		// Token: 0x020001BF RID: 447
		public struct AnimState
		{
			// Token: 0x04000C55 RID: 3157
			public Vector3 moveDirection;

			// Token: 0x04000C56 RID: 3158
			public bool jump;

			// Token: 0x04000C57 RID: 3159
			public bool crouch;

			// Token: 0x04000C58 RID: 3160
			public bool onGround;

			// Token: 0x04000C59 RID: 3161
			public bool isStrafing;

			// Token: 0x04000C5A RID: 3162
			public float yVelocity;

			// Token: 0x04000C5B RID: 3163
			public bool doubleJump;
		}
	}
}
