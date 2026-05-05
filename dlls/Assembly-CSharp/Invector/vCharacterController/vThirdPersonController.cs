using System;
using System.Collections;
using UnityEngine;

namespace Invector.vCharacterController
{
	// Token: 0x020003ED RID: 1005
	[vClassHeader("THIRD PERSON CONTROLLER", true, "icon_v2", false, "", iconName = "controllerIcon")]
	public class vThirdPersonController : vThirdPersonAnimator
	{
		// Token: 0x0600140B RID: 5131 RVA: 0x00068207 File Offset: 0x00066407
		public virtual void MoveToPosition(Transform targetPosition)
		{
			this.MoveToPosition(targetPosition.position);
		}

		// Token: 0x0600140C RID: 5132 RVA: 0x00068218 File Offset: 0x00066418
		public virtual void MoveToPosition(Vector3 targetPosition)
		{
			Vector3 vector = targetPosition - base.transform.position;
			vector.y = 0f;
			if (vector.magnitude < 0.1f)
			{
				this.input = Vector3.zero;
				this.moveDirection = Vector3.zero;
				return;
			}
			this.input = base.transform.InverseTransformDirection(vector.normalized);
			this.moveDirection = vector.normalized;
		}

		// Token: 0x0600140D RID: 5133 RVA: 0x00068290 File Offset: 0x00066490
		public virtual void ControlAnimatorRootMotion()
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.isRolling)
			{
				this.RollBehavior();
				return;
			}
			if (this.customAction || this.lockAnimMovement)
			{
				this.StopCharacterWithLerp();
				base.transform.position = base.animator.rootPosition;
				base.transform.rotation = base.animator.rootRotation;
			}
			if (this.useRootMotion)
			{
				this.MoveCharacter(this.moveDirection);
			}
		}

		// Token: 0x0600140E RID: 5134 RVA: 0x0006830C File Offset: 0x0006650C
		protected new void OnDisable()
		{
			base.isGrounded = false;
			this.isInAirborne = false;
			this.JumpCoroutineStarted = false;
			this.isJumping = false;
			base.isSprinting = false;
			this.verticalVelocity = 0f;
			this.sprintWeight = 0f;
			this.horizontalSpeed = 0f;
			this.verticalSpeed = 0f;
			this.moveDirection = Vector3.zero;
			this.input = Vector3.zero;
			this.inputSmooth = Vector3.zero;
			if (!this._rigidbody.isKinematic)
			{
				this._rigidbody.velocity = Vector3.zero;
			}
			this.inputMagnitude = 0f;
			this.moveSpeed = 0f;
			base.animator.SetFloat(vAnimatorParameters.InputMagnitude, 0f, 0.25f, Time.fixedDeltaTime);
			base.animator.SetFloat(vAnimatorParameters.InputVertical, 0f, 0.25f, Time.fixedDeltaTime);
			base.animator.SetFloat(vAnimatorParameters.InputHorizontal, 0f, 0.25f, Time.fixedDeltaTime);
			base.animator.SetFloat(vAnimatorParameters.RotationMagnitude, 0f, 0.25f, Time.fixedDeltaTime);
			base.StopCoroutine(this.DelayToJump());
		}

		// Token: 0x0600140F RID: 5135 RVA: 0x00068444 File Offset: 0x00066644
		protected new void OnEnable()
		{
			this._rigidbody = base.GetComponent<Rigidbody>();
			this._rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
			this.JumpCoroutineStarted = false;
		}

		// Token: 0x06001410 RID: 5136 RVA: 0x00068468 File Offset: 0x00066668
		public virtual void ControlLocomotionType()
		{
			if (this.lockAnimMovement || this.lockMovement || this.customAction)
			{
				return;
			}
			if (!this.lockSetMoveSpeed)
			{
				if ((this.locomotionType.Equals(vThirdPersonMotor.LocomotionType.FreeWithStrafe) && !base.isStrafing) || this.locomotionType.Equals(vThirdPersonMotor.LocomotionType.OnlyFree))
				{
					this.SetControllerMoveSpeed(this.freeSpeed);
					this.SetAnimatorMoveSpeed(this.freeSpeed);
				}
				else if (this.locomotionType.Equals(vThirdPersonMotor.LocomotionType.OnlyStrafe) || (this.locomotionType.Equals(vThirdPersonMotor.LocomotionType.FreeWithStrafe) && base.isStrafing))
				{
					base.isStrafing = true;
					this.SetControllerMoveSpeed(this.strafeSpeed);
					this.SetAnimatorMoveSpeed(this.strafeSpeed);
				}
			}
			if (!this.useRootMotion)
			{
				this.MoveCharacter(this.moveDirection);
			}
		}

		// Token: 0x06001411 RID: 5137 RVA: 0x0006855C File Offset: 0x0006675C
		public virtual void ControlRotationType()
		{
			if (this.lockAnimRotation || this.lockRotation || this.customAction || this.isRolling)
			{
				return;
			}
			if (this.input != Vector3.zero || (base.isStrafing ? this.strafeSpeed.rotateWithCamera : this.freeSpeed.rotateWithCamera))
			{
				if (this.lockAnimMovement)
				{
					this.inputSmooth = Vector3.Lerp(this.inputSmooth, this.input, (base.isStrafing ? this.strafeSpeed.movementSmooth : this.freeSpeed.movementSmooth) * Time.deltaTime);
				}
				Vector3 direction = (((base.isStrafing && base.isGrounded && (!base.isSprinting || !this.sprintOnlyFree)) || (this.freeSpeed.rotateWithCamera && this.input == Vector3.zero)) && this.rotateTarget) ? this.rotateTarget.forward : this.moveDirection;
				this.RotateToDirection(direction);
			}
		}

		// Token: 0x06001412 RID: 5138 RVA: 0x00068670 File Offset: 0x00066870
		public virtual void ControlKeepDirection()
		{
			if (!this.keepDirection)
			{
				this.oldInput = this.input;
				return;
			}
			if ((this.input.magnitude < 0.01f || Vector3.Distance(this.oldInput, this.input) > 0.9f) && this.keepDirection)
			{
				this.keepDirection = false;
			}
		}

		// Token: 0x06001413 RID: 5139 RVA: 0x000686CC File Offset: 0x000668CC
		public virtual void UpdateMoveDirection(Transform referenceTransform = null)
		{
			if (this.isRolling && !this.rollControl)
			{
				this.moveDirection = Vector3.Lerp(this.moveDirection, Vector3.zero, (base.isStrafing ? this.strafeSpeed.movementSmooth : this.freeSpeed.movementSmooth) * Time.deltaTime);
				return;
			}
			if (referenceTransform && !this.rotateByWorld)
			{
				Vector3 right = referenceTransform.right;
				right.y = 0f;
				Vector3 a = Quaternion.AngleAxis(-90f, Vector3.up) * right;
				this.moveDirection = this.inputSmooth.x * right + this.inputSmooth.z * a;
				return;
			}
			this.moveDirection = new Vector3(this.inputSmooth.x, 0f, this.inputSmooth.z);
		}

		// Token: 0x06001414 RID: 5140 RVA: 0x000687B4 File Offset: 0x000669B4
		public virtual void Sprint(bool value)
		{
			bool flag = (!this.isCrouching || (!base.inCrouchArea && this.CanExitCrouch())) && (this.currentStamina > 0f && base.hasMovementInput) && (!base.isStrafing || ((double)this.horizontalSpeed < 0.5 && (double)this.horizontalSpeed > -0.5 && this.verticalSpeed > 0.1f) || this.sprintOnlyFree);
			if (value && flag)
			{
				if (this.currentStamina > (this.finishStaminaOnSprint ? this.sprintStamina : 0f) && base.hasMovementInput)
				{
					this.finishStaminaOnSprint = false;
					if (base.isGrounded && this.useContinuousSprint)
					{
						this.isCrouching = false;
						base.isSprinting = !base.isSprinting;
						if (base.isSprinting)
						{
							this.OnStartSprinting.Invoke();
							base.alwaysWalkByDefault = false;
							return;
						}
						this.OnFinishSprinting.Invoke();
						return;
					}
					else if (!base.isSprinting)
					{
						this.OnStartSprinting.Invoke();
						base.alwaysWalkByDefault = false;
						base.isSprinting = true;
						return;
					}
				}
				else if (!this.useContinuousSprint && base.isSprinting)
				{
					if (this.currentStamina <= 0f)
					{
						this.finishStaminaOnSprint = true;
						this.OnFinishSprintingByStamina.Invoke();
					}
					base.isSprinting = false;
					this.OnFinishSprinting.Invoke();
					return;
				}
			}
			else if (base.isSprinting && (!this.useContinuousSprint || !flag))
			{
				if (this.currentStamina <= 0f)
				{
					this.finishStaminaOnSprint = true;
					this.OnFinishSprintingByStamina.Invoke();
				}
				base.isSprinting = false;
				this.OnFinishSprinting.Invoke();
			}
		}

		// Token: 0x06001415 RID: 5141 RVA: 0x00068966 File Offset: 0x00066B66
		public virtual void Crouch()
		{
			if (base.isGrounded && !this.customAction)
			{
				this.AutoCrouch();
				if (this.isCrouching && this.CanExitCrouch())
				{
					this.isCrouching = false;
					return;
				}
				this.isCrouching = true;
				base.isSprinting = false;
			}
		}

		// Token: 0x06001416 RID: 5142 RVA: 0x000689A4 File Offset: 0x00066BA4
		public virtual void Strafe()
		{
			base.isStrafing = !base.isStrafing;
		}

		// Token: 0x06001417 RID: 5143 RVA: 0x000689B8 File Offset: 0x00066BB8
		public virtual void Jump(bool consumeStamina = false)
		{
			this.jumpCounter = this.jumpTimer;
			this.OnJump.Invoke();
			if (this.input.sqrMagnitude < 0.1f)
			{
				this.JumpCoroutineStarted = true;
				base.StartCoroutine(this.DelayToJump());
				base.animator.CrossFadeInFixedTime("Jump", 0.3f);
			}
			else
			{
				this.JumpCoroutineStarted = true;
				base.StartCoroutine(this.DelayToJump());
				base.animator.CrossFadeInFixedTime("JumpMove", 0.3f);
			}
			if (consumeStamina)
			{
				this.ReduceStamina(this.jumpStamina, false);
				this.currentStaminaRecoveryDelay = 1f;
			}
		}

		// Token: 0x06001418 RID: 5144 RVA: 0x00068A5D File Offset: 0x00066C5D
		protected IEnumerator DelayToJump()
		{
			yield return new WaitForSeconds(this.jumpStandingDelay);
			if (this.JumpCoroutineStarted)
			{
				this.isJumping = true;
				this.JumpCoroutineStarted = false;
			}
			yield break;
		}

		// Token: 0x06001419 RID: 5145 RVA: 0x00068A6C File Offset: 0x00066C6C
		public virtual void Roll()
		{
			this.OnRoll.Invoke();
			this.isRolling = true;
			base.animator.CrossFadeInFixedTime("Roll", this.rollTransition, base.baseLayer);
			this.ReduceStamina(this.rollStamina, false);
			this.currentStaminaRecoveryDelay = 2f;
		}

		// Token: 0x0600141A RID: 5146 RVA: 0x00068ABF File Offset: 0x00066CBF
		protected override void OnTriggerStay(Collider other)
		{
			base.OnTriggerStay(other);
		}

		// Token: 0x0600141B RID: 5147 RVA: 0x00068AC8 File Offset: 0x00066CC8
		protected override void OnTriggerExit(Collider other)
		{
			base.OnTriggerExit(other);
		}

		// Token: 0x040019A7 RID: 6567
		private bool JumpCoroutineStarted;
	}
}
