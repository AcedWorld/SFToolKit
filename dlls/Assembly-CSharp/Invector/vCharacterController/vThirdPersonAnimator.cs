using System;
using Invector.vEventSystems;
using UnityEngine;

namespace Invector.vCharacterController
{
	// Token: 0x020003EB RID: 1003
	public class vThirdPersonAnimator : vThirdPersonMotor
	{
		// Token: 0x1700038B RID: 907
		// (get) Token: 0x060013F8 RID: 5112 RVA: 0x00067854 File Offset: 0x00065A54
		// (set) Token: 0x060013F9 RID: 5113 RVA: 0x0006785C File Offset: 0x00065A5C
		public Vector3 lastCharacterPosition { get; protected set; }

		// Token: 0x060013FA RID: 5114 RVA: 0x00067865 File Offset: 0x00065A65
		protected override void Start()
		{
			base.Start();
			this.RegisterAnimatorStateInfos();
		}

		// Token: 0x060013FB RID: 5115 RVA: 0x00067873 File Offset: 0x00065A73
		protected virtual void RegisterAnimatorStateInfos()
		{
			base.animatorStateInfos = new vAnimatorStateInfos(base.GetComponent<Animator>());
			base.animatorStateInfos.RegisterListener();
		}

		// Token: 0x060013FC RID: 5116 RVA: 0x00067891 File Offset: 0x00065A91
		protected virtual void OnEnable()
		{
			if (base.animatorStateInfos.animator != null)
			{
				base.animatorStateInfos.RegisterListener();
			}
		}

		// Token: 0x060013FD RID: 5117 RVA: 0x000678B1 File Offset: 0x00065AB1
		protected virtual void OnDisable()
		{
			base.animatorStateInfos.RemoveListener();
		}

		// Token: 0x060013FE RID: 5118 RVA: 0x000678BE File Offset: 0x00065ABE
		public virtual void UpdateAnimator()
		{
			if (base.animator == null || !base.animator.enabled)
			{
				return;
			}
			this.AnimatorLayerControl();
			this.ActionsControl();
			this.TriggerRandomIdle();
			this.UpdateAnimatorParameters();
			this.DeadAnimation();
		}

		// Token: 0x060013FF RID: 5119 RVA: 0x000678FC File Offset: 0x00065AFC
		public virtual void AnimatorLayerControl()
		{
			this.baseLayerInfo = base.animator.GetCurrentAnimatorStateInfo(base.baseLayer);
			this.underBodyInfo = base.animator.GetCurrentAnimatorStateInfo(base.underBodyLayer);
			this.rightArmInfo = base.animator.GetCurrentAnimatorStateInfo(base.rightArmLayer);
			this.leftArmInfo = base.animator.GetCurrentAnimatorStateInfo(base.leftArmLayer);
			this.upperBodyInfo = base.animator.GetCurrentAnimatorStateInfo(base.upperBodyLayer);
			this.fullBodyInfo = base.animator.GetCurrentAnimatorStateInfo(base.fullbodyLayer);
		}

		// Token: 0x06001400 RID: 5120 RVA: 0x00067994 File Offset: 0x00065B94
		public virtual void ActionsControl()
		{
			this.isRolling = this.IsAnimatorTag("IsRolling");
			this.isTurningOnSpot = this.IsAnimatorTag("TurnOnSpot");
			this.lockAnimMovement = this.IsAnimatorTag("LockMovement");
			this.lockAnimRotation = this.IsAnimatorTag("LockRotation");
			this.customAction = this.IsAnimatorTag("CustomAction");
			this.isInAirborne = this.IsAnimatorTag("Airborne");
		}

		// Token: 0x06001401 RID: 5121 RVA: 0x00067A08 File Offset: 0x00065C08
		public virtual void UpdateAnimatorParameters()
		{
			if (this.disableAnimations)
			{
				return;
			}
			base.animator.SetBool(vAnimatorParameters.IsStrafing, base.isStrafing);
			base.animator.SetBool(vAnimatorParameters.IsSprinting, base.isSprinting);
			base.animator.SetBool(vAnimatorParameters.IsSliding, base.isSliding && !this.isRolling);
			base.animator.SetBool(vAnimatorParameters.IsCrouching, this.isCrouching);
			base.animator.SetBool(vAnimatorParameters.IsGrounded, base.isGrounded);
			base.animator.SetBool(vAnimatorParameters.IsDead, base.isDead);
			base.animator.SetFloat(vAnimatorParameters.GroundDistance, this.groundDistance);
			base.animator.SetFloat(vAnimatorParameters.GroundAngle, this.GroundAngleFromDirection());
			if (!base.isGrounded)
			{
				base.animator.SetFloat(vAnimatorParameters.VerticalVelocity, this.verticalVelocity);
			}
			if (base.isStrafing)
			{
				base.animator.SetFloat(vAnimatorParameters.InputHorizontal, this.horizontalSpeed, this.strafeSpeed.animationSmooth, Time.fixedDeltaTime);
				base.animator.SetFloat(vAnimatorParameters.InputVertical, this.verticalSpeed, this.strafeSpeed.animationSmooth, Time.fixedDeltaTime);
			}
			else
			{
				base.animator.SetFloat(vAnimatorParameters.InputVertical, this.verticalSpeed, this.freeSpeed.animationSmooth, Time.fixedDeltaTime);
				base.animator.SetFloat(vAnimatorParameters.InputHorizontal, 0f, this.freeSpeed.animationSmooth, Time.fixedDeltaTime);
			}
			base.animator.SetFloat(vAnimatorParameters.InputMagnitude, Mathf.LerpUnclamped(this.inputMagnitude, 0f, this.stopMoveWeight), base.isStrafing ? this.strafeSpeed.animationSmooth : this.freeSpeed.animationSmooth, Time.fixedDeltaTime);
			if (this.useLeanMovementAnim && this.inputMagnitude >= 0.1f)
			{
				base.animator.SetFloat(vAnimatorParameters.RotationMagnitude, this.rotationMagnitude, this.leanSmooth, Time.fixedDeltaTime);
				return;
			}
			if (this.useTurnOnSpotAnim && this.inputMagnitude < 0.1f)
			{
				base.animator.SetFloat(vAnimatorParameters.RotationMagnitude, (float)Math.Round((double)this.rotationMagnitude, 2), (this.rotationMagnitude == 0f) ? 0.1f : 0.01f, Time.fixedDeltaTime);
			}
		}

		// Token: 0x06001402 RID: 5122 RVA: 0x00067C70 File Offset: 0x00065E70
		public virtual void SetAnimatorMoveSpeed(vThirdPersonMotor.vMovementSpeed speed)
		{
			Vector3 vector = base.transform.InverseTransformDirection(this.moveDirection);
			this.verticalSpeed = vector.z;
			this.horizontalSpeed = vector.x;
			Vector2 vector2 = new Vector2(this.verticalSpeed, this.horizontalSpeed);
			if (speed.walkByDefault || base.alwaysWalkByDefault)
			{
				this.inputMagnitude = Mathf.Clamp(vector2.magnitude, 0f, base.isSprinting ? 1f : 0.5f);
				return;
			}
			float magnitude = vector2.magnitude;
			this.sprintWeight = Mathf.Lerp(this.sprintWeight, base.isSprinting ? 1f : 0f, (base.isStrafing ? this.strafeSpeed.movementSmooth : this.freeSpeed.movementSmooth) * Time.fixedDeltaTime);
			this.inputMagnitude = Mathf.Clamp(Mathf.Lerp(magnitude, magnitude + 0.5f, this.sprintWeight), 0f, base.isSprinting ? 1.5f : 1f);
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x00067D80 File Offset: 0x00065F80
		public virtual void ResetInputAnimatorParameters()
		{
			base.animator.SetBool(vAnimatorParameters.IsSprinting, false);
			base.animator.SetBool(vAnimatorParameters.IsSliding, false);
			base.animator.SetBool(vAnimatorParameters.IsCrouching, false);
			base.animator.SetBool(vAnimatorParameters.IsGrounded, true);
			base.animator.SetFloat(vAnimatorParameters.GroundDistance, 0f);
			base.animator.SetFloat("InputHorizontal", 0f);
			base.animator.SetFloat("InputVertical", 0f);
			base.animator.SetFloat("InputMagnitude", 0f);
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x00067E28 File Offset: 0x00066028
		protected virtual void TriggerRandomIdle()
		{
			if (this.input != Vector3.zero || this.customAction)
			{
				return;
			}
			if (this.randomIdleTime > 0f)
			{
				if (this.input.sqrMagnitude == 0f && !this.isCrouching && this._capsuleCollider.enabled && base.isGrounded)
				{
					this.randomIdleCount += Time.fixedDeltaTime;
					if (this.randomIdleCount > 10f)
					{
						this.randomIdleCount = 0f;
						base.animator.SetTrigger(vAnimatorParameters.IdleRandomTrigger);
						base.animator.SetInteger(vAnimatorParameters.IdleRandom, Random.Range(1, 4));
						return;
					}
				}
				else
				{
					this.randomIdleCount = 0f;
					base.animator.SetInteger(vAnimatorParameters.IdleRandom, 0);
				}
			}
		}

		// Token: 0x06001405 RID: 5125 RVA: 0x00067F00 File Offset: 0x00066100
		protected virtual void DeadAnimation()
		{
			if (!base.isDead)
			{
				return;
			}
			if (!this.triggerDieBehaviour)
			{
				this.triggerDieBehaviour = true;
				this.DeathBehaviour();
			}
			if (this.deathBy == vCharacter.DeathBy.Animation)
			{
				int layerIndex = 0;
				vAnimatorStateInfos.vStateInfo stateInfoUsingTag = base.animatorStateInfos.GetStateInfoUsingTag("Dead");
				if (stateInfoUsingTag != null && !base.animator.IsInTransition(layerIndex) && stateInfoUsingTag.normalizedTime >= 0.99f && this.groundDistance <= 0.15f)
				{
					base.RemoveComponents();
					return;
				}
			}
			else if (this.deathBy == vCharacter.DeathBy.AnimationWithRagdoll)
			{
				int layerIndex2 = 0;
				vAnimatorStateInfos.vStateInfo stateInfoUsingTag2 = base.animatorStateInfos.GetStateInfoUsingTag("Dead");
				if (stateInfoUsingTag2 != null && !base.animator.IsInTransition(layerIndex2) && stateInfoUsingTag2.normalizedTime >= 0.8f)
				{
					base.onActiveRagdoll.Invoke(null);
					return;
				}
			}
			else if (this.deathBy == vCharacter.DeathBy.Ragdoll)
			{
				base.onActiveRagdoll.Invoke(null);
			}
		}

		// Token: 0x06001406 RID: 5126 RVA: 0x00067FD7 File Offset: 0x000661D7
		public virtual void SetActionState(int value)
		{
			base.animator.SetInteger(vAnimatorParameters.ActionState, value);
		}

		// Token: 0x06001407 RID: 5127 RVA: 0x00067FEC File Offset: 0x000661EC
		public virtual bool IsAnimatorTag(string tag)
		{
			return !(base.animator == null) && ((base.animatorStateInfos != null && base.animatorStateInfos.HasTag(tag)) || this.baseLayerInfo.IsTag(tag) || this.underBodyInfo.IsTag(tag) || this.rightArmInfo.IsTag(tag) || this.leftArmInfo.IsTag(tag) || this.upperBodyInfo.IsTag(tag) || this.fullBodyInfo.IsTag(tag));
		}

		// Token: 0x06001408 RID: 5128 RVA: 0x00068084 File Offset: 0x00066284
		public virtual void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget target, MatchTargetWeightMask weightMask, float normalisedStartTime, float normalisedEndTime)
		{
			if (base.animator.isMatchingTarget || base.animator.IsInTransition(0))
			{
				return;
			}
			if (Mathf.Repeat(base.animator.GetCurrentAnimatorStateInfo(0).normalizedTime, 1f) > normalisedEndTime)
			{
				return;
			}
			base.animator.MatchTarget(matchPosition, matchRotation, target, weightMask, normalisedStartTime, normalisedEndTime);
		}

		// Token: 0x0400198E RID: 6542
		[HideInInspector]
		public Transform matchTarget;

		// Token: 0x0400198F RID: 6543
		private float randomIdleCount;

		// Token: 0x04001990 RID: 6544
		public const float walkSpeed = 0.5f;

		// Token: 0x04001991 RID: 6545
		public const float runningSpeed = 1f;

		// Token: 0x04001992 RID: 6546
		public const float sprintSpeed = 1.5f;

		// Token: 0x04001993 RID: 6547
		private bool triggerDieBehaviour;
	}
}
