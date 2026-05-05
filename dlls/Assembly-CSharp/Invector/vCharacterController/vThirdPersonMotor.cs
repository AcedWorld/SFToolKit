using System;
using System.Collections;
using Invector.vEventSystems;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.vCharacterController
{
	// Token: 0x020003F6 RID: 1014
	public class vThirdPersonMotor : vCharacter, vIAnimatorStateInfoController
	{
		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06001471 RID: 5233 RVA: 0x00069A3A File Offset: 0x00067C3A
		// (set) Token: 0x06001472 RID: 5234 RVA: 0x00069A42 File Offset: 0x00067C42
		public vAnimatorStateInfos animatorStateInfos
		{
			get
			{
				return this._animatorStateInfos;
			}
			protected set
			{
				this._animatorStateInfos = value;
			}
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06001473 RID: 5235 RVA: 0x00069A4B File Offset: 0x00067C4B
		// (set) Token: 0x06001474 RID: 5236 RVA: 0x00069A65 File Offset: 0x00067C65
		public bool isStrafing
		{
			get
			{
				return (!this.sprintOnlyFree || !this.isSprinting) && this._isStrafing;
			}
			set
			{
				this._isStrafing = value;
			}
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06001475 RID: 5237 RVA: 0x00069A6E File Offset: 0x00067C6E
		// (set) Token: 0x06001476 RID: 5238 RVA: 0x00069A76 File Offset: 0x00067C76
		public bool isGrounded { get; set; }

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06001477 RID: 5239 RVA: 0x00069A7F File Offset: 0x00067C7F
		// (set) Token: 0x06001478 RID: 5240 RVA: 0x00069A87 File Offset: 0x00067C87
		public bool disableCheckGround { get; set; }

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06001479 RID: 5241 RVA: 0x00069A90 File Offset: 0x00067C90
		// (set) Token: 0x0600147A RID: 5242 RVA: 0x00069A98 File Offset: 0x00067C98
		public bool inCrouchArea { get; protected set; }

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x0600147B RID: 5243 RVA: 0x00069AA1 File Offset: 0x00067CA1
		// (set) Token: 0x0600147C RID: 5244 RVA: 0x00069AA9 File Offset: 0x00067CA9
		public bool isSprinting { get; set; }

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x0600147D RID: 5245 RVA: 0x00069AB2 File Offset: 0x00067CB2
		// (set) Token: 0x0600147E RID: 5246 RVA: 0x00069ABA File Offset: 0x00067CBA
		public bool isSliding { get; protected set; }

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x0600147F RID: 5247 RVA: 0x00069AC3 File Offset: 0x00067CC3
		// (set) Token: 0x06001480 RID: 5248 RVA: 0x00069ACB File Offset: 0x00067CCB
		public bool autoCrouch { get; protected set; }

		// Token: 0x06001481 RID: 5249 RVA: 0x00069AD4 File Offset: 0x00067CD4
		protected void RemoveComponents()
		{
			if (!this.removeComponentsAfterDie)
			{
				return;
			}
			if (this._capsuleCollider != null)
			{
				Object.Destroy(this._capsuleCollider);
			}
			if (this._rigidbody != null)
			{
				Object.Destroy(this._rigidbody);
			}
			if (base.animator != null)
			{
				Object.Destroy(base.animator);
			}
			MonoBehaviour[] components = base.GetComponents<MonoBehaviour>();
			for (int i = 0; i < components.Length; i++)
			{
				Object.Destroy(components[i]);
			}
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06001482 RID: 5250 RVA: 0x00069B52 File Offset: 0x00067D52
		// (set) Token: 0x06001483 RID: 5251 RVA: 0x00069B5A File Offset: 0x00067D5A
		public PhysicMaterial currentMaterialPhysics { get; protected set; }

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06001484 RID: 5252 RVA: 0x00069B63 File Offset: 0x00067D63
		public int baseLayer
		{
			get
			{
				return base.animator.GetLayerIndex("Base Layer");
			}
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06001485 RID: 5253 RVA: 0x00069B75 File Offset: 0x00067D75
		public int underBodyLayer
		{
			get
			{
				return base.animator.GetLayerIndex("UnderBody");
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06001486 RID: 5254 RVA: 0x00069B87 File Offset: 0x00067D87
		public int rightArmLayer
		{
			get
			{
				return base.animator.GetLayerIndex("RightArm");
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06001487 RID: 5255 RVA: 0x00069B99 File Offset: 0x00067D99
		public int leftArmLayer
		{
			get
			{
				return base.animator.GetLayerIndex("LeftArm");
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06001488 RID: 5256 RVA: 0x00069BAB File Offset: 0x00067DAB
		public int upperBodyLayer
		{
			get
			{
				return base.animator.GetLayerIndex("UpperBody");
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06001489 RID: 5257 RVA: 0x00069BBD File Offset: 0x00067DBD
		public int fullbodyLayer
		{
			get
			{
				return base.animator.GetLayerIndex("FullBody");
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x0600148A RID: 5258 RVA: 0x00069BCF File Offset: 0x00067DCF
		// (set) Token: 0x0600148B RID: 5259 RVA: 0x00069BD7 File Offset: 0x00067DD7
		public float colliderRadiusDefault { get; protected set; }

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x0600148C RID: 5260 RVA: 0x00069BE0 File Offset: 0x00067DE0
		// (set) Token: 0x0600148D RID: 5261 RVA: 0x00069BE8 File Offset: 0x00067DE8
		public float colliderHeightDefault { get; protected set; }

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x0600148E RID: 5262 RVA: 0x00069BF1 File Offset: 0x00067DF1
		// (set) Token: 0x0600148F RID: 5263 RVA: 0x00069BF9 File Offset: 0x00067DF9
		public Vector3 colliderCenterDefault { get; protected set; }

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06001490 RID: 5264 RVA: 0x00069C02 File Offset: 0x00067E02
		protected virtual bool _canApplyFallDamage
		{
			get
			{
				return !this.blockApplyFallDamage && this.jumpMultiplier <= 1f && !this.customAction;
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06001491 RID: 5265 RVA: 0x00069C24 File Offset: 0x00067E24
		// (set) Token: 0x06001492 RID: 5266 RVA: 0x00069C2C File Offset: 0x00067E2C
		public bool alwaysWalkByDefault { get; set; }

		// Token: 0x06001493 RID: 5267 RVA: 0x000020BE File Offset: 0x000002BE
		private void Awake()
		{
		}

		// Token: 0x06001494 RID: 5268 RVA: 0x00069C35 File Offset: 0x00067E35
		protected override void Start()
		{
			base.Start();
			this.heightReached = base.transform.position.y;
		}

		// Token: 0x06001495 RID: 5269 RVA: 0x00069C54 File Offset: 0x00067E54
		public override void Init()
		{
			base.Init();
			base.animator.updateMode = AnimatorUpdateMode.Normal;
			this.frictionPhysics = new PhysicMaterial();
			this.frictionPhysics.name = "frictionPhysics";
			this.frictionPhysics.staticFriction = 0.25f;
			this.frictionPhysics.dynamicFriction = 0.25f;
			this.frictionPhysics.frictionCombine = PhysicMaterialCombine.Multiply;
			this.maxFrictionPhysics = new PhysicMaterial();
			this.maxFrictionPhysics.name = "maxFrictionPhysics";
			this.maxFrictionPhysics.staticFriction = 1f;
			this.maxFrictionPhysics.dynamicFriction = 1f;
			this.maxFrictionPhysics.frictionCombine = PhysicMaterialCombine.Maximum;
			this.slippyPhysics = new PhysicMaterial();
			this.slippyPhysics.name = "slippyPhysics";
			this.slippyPhysics.staticFriction = 0f;
			this.slippyPhysics.dynamicFriction = 0f;
			this.slippyPhysics.frictionCombine = PhysicMaterialCombine.Minimum;
			this._rigidbody = base.GetComponent<Rigidbody>();
			this._capsuleCollider = base.GetComponent<CapsuleCollider>();
			this.colliderCenter = (this.colliderCenterDefault = this._capsuleCollider.center);
			this.colliderRadius = (this.colliderRadiusDefault = this._capsuleCollider.radius);
			this.colliderHeight = (this.colliderHeightDefault = this._capsuleCollider.height);
			Collider[] componentsInChildren = base.GetComponentsInChildren<Collider>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Physics.IgnoreCollision(this._capsuleCollider, componentsInChildren[i]);
			}
			if (this.fillHealthOnStart)
			{
				base.currentHealth = (float)this.maxHealth;
			}
			this.currentHealthRecoveryDelay = this.healthRecoveryDelay;
			this.currentStamina = this.maxStamina;
			this.ResetJumpMultiplier();
			this.isGrounded = true;
			this.ResetControllerSpeedMultiplier();
		}

		// Token: 0x06001496 RID: 5270 RVA: 0x00069E11 File Offset: 0x00068011
		public virtual void UpdateMotor()
		{
			this.CheckHealth();
			this.CheckStamina();
			this.CheckGround();
			this.SlideMovementBehavior();
			this.CheckRagdoll();
			this.ControlCapsuleHeight();
			this.ControlJumpBehaviour();
			this.AirControl();
			this.StaminaRecovery();
			this.CalculateRotationMagnitude();
		}

		// Token: 0x06001497 RID: 5271 RVA: 0x00069E50 File Offset: 0x00068050
		public override void TakeDamage(vDamage damage)
		{
			if (base.currentHealth <= 0f || this.IgnoreDamageRolling())
			{
				if (damage.activeRagdoll && !this.IgnoreDamageActiveRagdollRolling())
				{
					base.onActiveRagdoll.Invoke(damage);
				}
				return;
			}
			if (damage.activeRagdoll && this.IgnoreDamageActiveRagdollRolling())
			{
				damage.activeRagdoll = false;
			}
			base.TakeDamage(damage);
		}

		// Token: 0x06001498 RID: 5272 RVA: 0x00069EAD File Offset: 0x000680AD
		protected virtual bool IgnoreDamageRolling()
		{
			return this.noDamageWhileRolling && this.isRolling;
		}

		// Token: 0x06001499 RID: 5273 RVA: 0x00069EBF File Offset: 0x000680BF
		protected virtual bool IgnoreDamageActiveRagdollRolling()
		{
			return this.noActiveRagdollWhileRolling && this.isRolling;
		}

		// Token: 0x0600149A RID: 5274 RVA: 0x00069ED1 File Offset: 0x000680D1
		protected override void TriggerDamageReaction(vDamage damage)
		{
			if (!this.customAction)
			{
				base.TriggerDamageReaction(damage);
				return;
			}
			if (damage.activeRagdoll)
			{
				base.onActiveRagdoll.Invoke(damage);
			}
		}

		// Token: 0x0600149B RID: 5275 RVA: 0x00069EF8 File Offset: 0x000680F8
		public virtual void ReduceStamina(float value, bool accumulative)
		{
			if (this.customAction)
			{
				return;
			}
			if (accumulative)
			{
				this.currentStamina -= value * Time.fixedDeltaTime;
			}
			else
			{
				this.currentStamina -= value;
			}
			if (this.currentStamina < 0f)
			{
				this.currentStamina = 0f;
				this.OnStaminaEnd.Invoke();
			}
		}

		// Token: 0x0600149C RID: 5276 RVA: 0x00069F58 File Offset: 0x00068158
		public virtual void ChangeStamina(int value)
		{
			this.currentStamina += (float)value;
			this.currentStamina = Mathf.Clamp(this.currentStamina, 0f, this.maxStamina);
		}

		// Token: 0x0600149D RID: 5277 RVA: 0x00069F85 File Offset: 0x00068185
		public virtual void ChangeMaxStamina(int value)
		{
			this.maxStamina += (float)value;
			if (this.maxStamina < 0f)
			{
				this.maxStamina = 0f;
			}
		}

		// Token: 0x0600149E RID: 5278 RVA: 0x00069FAE File Offset: 0x000681AE
		public virtual void DeathBehaviour()
		{
			this.lockAnimMovement = true;
			base.animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
			if (this.deathBy == vCharacter.DeathBy.Animation || this.deathBy == vCharacter.DeathBy.AnimationWithRagdoll)
			{
				base.animator.SetBool("isDead", true);
			}
		}

		// Token: 0x0600149F RID: 5279 RVA: 0x00069FE5 File Offset: 0x000681E5
		private void CheckHealth()
		{
			if (base.isDead && base.currentHealth > 0f)
			{
				base.isDead = false;
			}
		}

		// Token: 0x060014A0 RID: 5280 RVA: 0x0006A003 File Offset: 0x00068203
		private void CheckStamina()
		{
			if (this.isSprinting)
			{
				this.currentStaminaRecoveryDelay = 0.25f;
				this.ReduceStamina(this.sprintStamina, true);
			}
		}

		// Token: 0x060014A1 RID: 5281 RVA: 0x0006A028 File Offset: 0x00068228
		public void StaminaRecovery()
		{
			if (this.currentStaminaRecoveryDelay > 0f)
			{
				this.currentStaminaRecoveryDelay -= Time.fixedDeltaTime;
				return;
			}
			if (this.currentStamina > this.maxStamina)
			{
				this.currentStamina = this.maxStamina;
			}
			if (this.currentStamina < this.maxStamina)
			{
				this.currentStamina += this.staminaRecovery;
			}
		}

		// Token: 0x060014A2 RID: 5282 RVA: 0x0006A090 File Offset: 0x00068290
		protected virtual void CalculateRotationMagnitude()
		{
			Vector3 eulerAngle = base.transform.eulerAngles - this.lastCharacterAngle;
			if ((double)eulerAngle.sqrMagnitude < 0.01)
			{
				this.lastCharacterAngle = base.transform.eulerAngles;
				this.rotationMagnitude = 0f;
				return;
			}
			float num = eulerAngle.NormalizeAngle().y / (this.isStrafing ? this.strafeSpeed.rotationSpeed : this.freeSpeed.rotationSpeed);
			this.rotationMagnitude = (float)Math.Round((double)num, 2);
			this.lastCharacterAngle = base.transform.eulerAngles;
		}

		// Token: 0x060014A3 RID: 5283 RVA: 0x0006A131 File Offset: 0x00068331
		public virtual void SetControllerSpeedMultiplier(float speed)
		{
			this.speedMultiplier = 0f;
		}

		// Token: 0x060014A4 RID: 5284 RVA: 0x0006A13E File Offset: 0x0006833E
		public virtual void ResetControllerSpeedMultiplier()
		{
			this.speedMultiplier = this.defaultSpeedMultiplier;
		}

		// Token: 0x060014A5 RID: 5285 RVA: 0x0006A14C File Offset: 0x0006834C
		public virtual void SetControllerMoveSpeed(vThirdPersonMotor.vMovementSpeed speed)
		{
			if (this.isCrouching)
			{
				this.moveSpeed = Mathf.Lerp(this.moveSpeed, speed.crouchSpeed, speed.movementSmooth * Time.fixedDeltaTime);
				return;
			}
			if (speed.walkByDefault || this.alwaysWalkByDefault)
			{
				this.moveSpeed = Mathf.Lerp(this.moveSpeed, this.isSprinting ? speed.runningSpeed : speed.walkSpeed, speed.movementSmooth * Time.fixedDeltaTime);
				return;
			}
			this.moveSpeed = Mathf.Lerp(this.moveSpeed, this.isSprinting ? speed.sprintSpeed : speed.runningSpeed, speed.movementSmooth * Time.fixedDeltaTime);
		}

		// Token: 0x060014A6 RID: 5286 RVA: 0x0006A1FC File Offset: 0x000683FC
		public virtual void MoveCharacter(Vector3 _direction)
		{
			this.inputSmooth = Vector3.Lerp(this.inputSmooth, this.input, (this.isStrafing ? this.strafeSpeed.movementSmooth : this.freeSpeed.movementSmooth) * (this.useRootMotion ? vTime.deltaTime : vTime.fixedDeltaTime));
			if (this.isSliding || base.ragdolled || !this.isGrounded || this.isJumping || Time.timeScale == 0f)
			{
				return;
			}
			_direction.y = 0f;
			_direction = _direction.normalized * Mathf.Clamp(_direction.magnitude, 0f, 1f);
			Vector3 vector = ((this.useRootMotion ? base.animator.rootPosition : this._rigidbody.position) + _direction * (this.moveSpeed * this.speedMultiplier) * (this.useRootMotion ? vTime.deltaTime : vTime.fixedDeltaTime) - base.transform.position) / (this.useRootMotion ? vTime.deltaTime : vTime.fixedDeltaTime);
			bool flag = true;
			this.SnapToGround(ref vector, ref flag);
			this.steepSlopeAhead = this.CheckForSlope(ref vector);
			if (!this.steepSlopeAhead)
			{
				this.CalculateStepOffset(_direction.normalized, ref vector, ref flag);
			}
			this.CheckStopMove(ref vector);
			if (flag)
			{
				vector.y = this._rigidbody.velocity.y;
			}
			if (float.IsNaN(vector.x) || float.IsNaN(vector.y) || float.IsNaN(vector.z))
			{
				vector = Vector3.zero;
			}
			this._rigidbody.velocity = vector;
		}

		// Token: 0x060014A7 RID: 5287 RVA: 0x0006A3BC File Offset: 0x000685BC
		protected virtual void CheckStopMove(ref Vector3 targetVelocity)
		{
			Vector3 start = base.transform.position + base.transform.up * this.colliderRadiusDefault;
			Vector3 vector = this.moveDirection.normalized;
			vector = Vector3.ProjectOnPlane(vector, this.groundHit.normal);
			float colliderRadiusDefault = this.colliderRadiusDefault;
			float num = this.isStrafing ? this.strafeSpeed.movementSmooth : this.freeSpeed.movementSmooth;
			bool flag = this.isGrounded && !this.isJumping && !this.isInAirborne && !this.applyingStepOffset && !this.customAction;
			float b;
			RaycastHit raycastHit;
			if (this.steepSlopeAhead)
			{
				b = 1f * this._slopeSidewaysSmooth;
			}
			else if (flag && this.CheckStopMove(vector, out raycastHit))
			{
				if (Vector3.Angle(vector, -raycastHit.normal) < this.slopeLimit)
				{
					float num2 = raycastHit.distance - this.colliderRadiusDefault;
					b = 1f - num2;
				}
				else
				{
					b = -0.01f;
				}
				if (this.debugWindow)
				{
					Debug.DrawLine(start, raycastHit.point, Color.cyan);
				}
			}
			else
			{
				b = -0.01f;
			}
			this.stopMoveWeight = Mathf.Lerp(this.stopMoveWeight, b, num * Time.deltaTime);
			this.stopMoveWeight = Mathf.Clamp(this.stopMoveWeight, 0f, 1f);
			targetVelocity = Vector3.LerpUnclamped(targetVelocity, Vector3.zero, this.stopMoveWeight);
		}

		// Token: 0x060014A8 RID: 5288 RVA: 0x0006A540 File Offset: 0x00068740
		protected virtual bool CheckStopMove(Vector3 direction, out RaycastHit hit)
		{
			Vector3 vector = base.transform.position + base.transform.up * this.colliderRadiusDefault;
			float maxDistance = this.colliderRadiusDefault + this.stopMoveRayDistance;
			vThirdPersonMotor.StopMoveCheckMethod stopMoveCheckMethod = this.stopMoveCheckMethod;
			if (stopMoveCheckMethod - vThirdPersonMotor.StopMoveCheckMethod.SphereCast <= 1)
			{
				Vector3 point = vector + base.transform.up * this.slopeLimitHeight;
				Vector3 point2 = vector + base.transform.up * (this.stopMoveMaxHeight - this._capsuleCollider.radius);
				return Physics.CapsuleCast(point, point2, this._capsuleCollider.radius, direction, out hit, maxDistance, this.stopMoveLayer);
			}
			return Physics.Raycast(vector, direction, out hit, maxDistance, this.stopMoveLayer);
		}

		// Token: 0x060014A9 RID: 5289 RVA: 0x0006A60C File Offset: 0x0006880C
		protected virtual void SnapToGround(ref Vector3 targetVelocity, ref bool useVerticalVelocity)
		{
			if (!this.useSnapGround || this.disableCheckGround || this.isRolling)
			{
				return;
			}
			if (this.groundDistance < this.groundMinDistance * 0.2f || this.applyingStepOffset)
			{
				return;
			}
			if (this.isGrounded && this.groundHit.collider != null && this.GroundAngle() <= this.slopeLimit && !this.disableCheckGround && !this.isSliding && !this.isJumping && !this.customAction && this.input.magnitude > 0.1f && !this.isInAirborne)
			{
				float num = Mathf.Max(0f, this.groundDistance);
				Vector3 b = base.transform.up * (-num * this.snapPower / Time.fixedDeltaTime);
				targetVelocity = (targetVelocity + b).normalized * targetVelocity.magnitude;
				useVerticalVelocity = false;
			}
		}

		// Token: 0x060014AA RID: 5290 RVA: 0x0006A714 File Offset: 0x00068914
		private void CalculateStepOffset(Vector3 moveDir, ref Vector3 targetVelocity, ref bool useVerticalVelocity)
		{
			if (this.useStepOffset && this.isGrounded && !this.disableCheckGround && !this.isSliding && !this.isJumping && !this.customAction && !this.isInAirborne)
			{
				Vector3 onNormal = Vector3.Lerp(base.transform.forward, moveDir.normalized, this.inputSmooth.magnitude);
				float d = this._capsuleCollider.radius + this.stepOffsetDistance;
				float d2 = this.stepOffsetMaxHeight + 0.01f + this._capsuleCollider.radius * 0.5f;
				Vector3 vector = base.transform.position + base.transform.up * (this.stepOffsetMinHeight + 0.05f);
				Vector3 end = vector + onNormal.normalized * d;
				if (Physics.Linecast(vector, end, out this.stepOffsetHit, this.groundLayer))
				{
					if (this.debugWindow)
					{
						Debug.DrawLine(vector, this.stepOffsetHit.point);
					}
					d = this.stepOffsetHit.distance + 0.1f;
				}
				if (Physics.SphereCast(new Ray(base.transform.position + base.transform.up * d2 + onNormal.normalized * d, Vector3.down), this._capsuleCollider.radius * 0.5f, out this.stepOffsetHit, this.stepOffsetMaxHeight - this.stepOffsetMinHeight, this.groundLayer) && this.stepOffsetHit.point.y > base.transform.position.y)
				{
					onNormal = this.stepOffsetHit.point - base.transform.position;
					onNormal.Normalize();
					targetVelocity = Vector3.Project(targetVelocity, onNormal);
					this.applyingStepOffset = true;
					useVerticalVelocity = false;
					return;
				}
			}
			this.applyingStepOffset = false;
		}

		// Token: 0x060014AB RID: 5291 RVA: 0x0006A928 File Offset: 0x00068B28
		public virtual void StopCharacterWithLerp()
		{
			this.isSprinting = false;
			this.sprintWeight = 0f;
			this.horizontalSpeed = 0f;
			this.verticalSpeed = 0f;
			this.moveDirection = Vector3.zero;
			this.input = Vector3.Lerp(this.input, Vector3.zero, 2f * Time.fixedDeltaTime);
			this.inputSmooth = Vector3.Lerp(this.inputSmooth, Vector3.zero, 2f * Time.fixedDeltaTime);
			this._rigidbody.velocity = Vector3.Lerp(this._rigidbody.velocity, Vector3.zero, 4f * Time.fixedDeltaTime);
			this.inputMagnitude = Mathf.Lerp(this.inputMagnitude, 0f, 2f * Time.fixedDeltaTime);
			this.moveSpeed = Mathf.Lerp(this.moveSpeed, 0f, 2f * Time.fixedDeltaTime);
			base.animator.SetFloat(vAnimatorParameters.InputMagnitude, 0f, 0.2f, Time.fixedDeltaTime);
			base.animator.SetFloat(vAnimatorParameters.InputVertical, 0f, 0.2f, Time.fixedDeltaTime);
			base.animator.SetFloat(vAnimatorParameters.InputHorizontal, 0f, 0.2f, Time.fixedDeltaTime);
			base.animator.SetFloat(vAnimatorParameters.RotationMagnitude, 0f, 0.2f, Time.fixedDeltaTime);
		}

		// Token: 0x060014AC RID: 5292 RVA: 0x0006AA94 File Offset: 0x00068C94
		public virtual void StopCharacter()
		{
			this.isSprinting = false;
			this.sprintWeight = 0f;
			this.horizontalSpeed = 0f;
			this.verticalSpeed = 0f;
			this.moveDirection = Vector3.zero;
			this.input = Vector3.zero;
			this.inputSmooth = Vector3.zero;
			this._rigidbody.velocity = Vector3.zero;
			this.inputMagnitude = 0f;
			this.moveSpeed = 0f;
			base.animator.SetFloat(vAnimatorParameters.InputMagnitude, 0f, 0.25f, Time.fixedDeltaTime);
			base.animator.SetFloat(vAnimatorParameters.InputVertical, 0f, 0.25f, Time.fixedDeltaTime);
			base.animator.SetFloat(vAnimatorParameters.InputHorizontal, 0f, 0.25f, Time.fixedDeltaTime);
			base.animator.SetFloat(vAnimatorParameters.RotationMagnitude, 0f, 0.25f, Time.fixedDeltaTime);
		}

		// Token: 0x060014AD RID: 5293 RVA: 0x0006AB8C File Offset: 0x00068D8C
		public virtual void RotateToPosition(Vector3 position)
		{
			this.RotateToDirection((position - base.transform.position).normalized);
		}

		// Token: 0x060014AE RID: 5294 RVA: 0x0006ABB8 File Offset: 0x00068DB8
		public virtual void RotateToDirection(Vector3 direction)
		{
			this.RotateToDirection(direction, this.isStrafing ? this.strafeSpeed.rotationSpeed : this.freeSpeed.rotationSpeed);
		}

		// Token: 0x060014AF RID: 5295 RVA: 0x0006ABE4 File Offset: 0x00068DE4
		public virtual void RotateToDirection(Vector3 direction, float rotationSpeed)
		{
			if (this.lockAnimRotation || this.customAction || (!this.jumpAndRotate && !this.isGrounded) || base.ragdolled || this.isSliding)
			{
				return;
			}
			direction.y = 0f;
			if (direction.normalized.magnitude == 0f)
			{
				direction = base.transform.forward;
			}
			Vector3 vector = base.transform.rotation.eulerAngles.NormalizeAngle();
			Vector3 vector2 = Quaternion.LookRotation(direction.normalized).eulerAngles.NormalizeAngle();
			vector.y = Mathf.LerpAngle(vector.y, vector2.y, rotationSpeed * Time.fixedDeltaTime);
			Quaternion rotation = Quaternion.Euler(vector);
			base.transform.rotation = rotation;
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x060014B0 RID: 5296 RVA: 0x0006ACB8 File Offset: 0x00068EB8
		public bool hasMovementInput
		{
			get
			{
				return this.inputSmooth.sqrMagnitude + this.input.sqrMagnitude > 0.1f || (this.input - this.inputSmooth).sqrMagnitude > 0.1f;
			}
		}

		// Token: 0x060014B1 RID: 5297 RVA: 0x0006AD08 File Offset: 0x00068F08
		protected virtual void ControlJumpBehaviour()
		{
			if (!this.isJumping)
			{
				return;
			}
			this.jumpCounter -= Time.fixedDeltaTime;
			if (this.jumpCounter <= 0f)
			{
				this.jumpCounter = 0f;
				this.isJumping = false;
			}
			Vector3 velocity = this._rigidbody.velocity;
			velocity.y = this.jumpHeight * this.jumpMultiplier;
			this._rigidbody.velocity = velocity;
		}

		// Token: 0x060014B2 RID: 5298 RVA: 0x0006AD7B File Offset: 0x00068F7B
		public virtual void SetJumpMultiplier(float jumpMultiplier, float timeToReset = 1f)
		{
			this.jumpMultiplier = jumpMultiplier;
			if (this.timeToResetJumpMultiplier <= 0f)
			{
				this.timeToResetJumpMultiplier = timeToReset;
				base.StartCoroutine(this.ResetJumpMultiplierRoutine());
				return;
			}
			this.timeToResetJumpMultiplier = timeToReset;
		}

		// Token: 0x060014B3 RID: 5299 RVA: 0x0006ADAD File Offset: 0x00068FAD
		public virtual void ResetJumpMultiplier()
		{
			base.StopCoroutine("ResetJumpMultiplierRoutine");
			this.timeToResetJumpMultiplier = 0f;
			this.jumpMultiplier = 1f;
		}

		// Token: 0x060014B4 RID: 5300 RVA: 0x0006ADD0 File Offset: 0x00068FD0
		protected IEnumerator ResetJumpMultiplierRoutine()
		{
			while (this.timeToResetJumpMultiplier > 0f && this.jumpMultiplier != 1f)
			{
				this.timeToResetJumpMultiplier -= Time.fixedDeltaTime;
				yield return null;
			}
			this.jumpMultiplier = 1f;
			yield break;
		}

		// Token: 0x060014B5 RID: 5301 RVA: 0x0006ADE0 File Offset: 0x00068FE0
		public virtual void AirControl()
		{
			if ((this.isGrounded && !this.isJumping) || this.isSliding)
			{
				return;
			}
			if (base.transform.position.y > this.heightReached)
			{
				this.heightReached = base.transform.position.y;
			}
			this.inputSmooth = Vector3.Lerp(this.inputSmooth, this.input, this.airSmooth * Time.fixedDeltaTime);
			if (this.jumpWithRigidbodyForce && !this.isGrounded)
			{
				this._rigidbody.AddForce(this.moveDirection * this.airSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
				return;
			}
			this.moveDirection.y = 0f;
			this.moveDirection.x = Mathf.Clamp(this.moveDirection.x, -1f, 1f);
			this.moveDirection.z = Mathf.Clamp(this.moveDirection.z, -1f, 1f);
			Vector3 b = (this._rigidbody.position + this.moveDirection * this.airSpeed * Time.fixedDeltaTime - base.transform.position) / Time.fixedDeltaTime;
			b.y = this._rigidbody.velocity.y;
			this._rigidbody.velocity = Vector3.Lerp(this._rigidbody.velocity, b, this.airSmooth * Time.fixedDeltaTime);
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x060014B6 RID: 5302 RVA: 0x0006AF70 File Offset: 0x00069170
		protected virtual bool jumpFwdCondition
		{
			get
			{
				Vector3 vector = base.transform.position + this._capsuleCollider.center + Vector3.up * -this._capsuleCollider.height * 0.5f;
				Vector3 point = vector + Vector3.up * this._capsuleCollider.height;
				return Physics.CapsuleCastAll(vector, point, this._capsuleCollider.radius * 0.5f, base.transform.forward, 0.6f, this.groundLayer).Length == 0;
			}
		}

		// Token: 0x060014B7 RID: 5303 RVA: 0x0006B00F File Offset: 0x0006920F
		public virtual void UseAutoCrouch(bool value)
		{
			this.autoCrouch = value;
		}

		// Token: 0x060014B8 RID: 5304 RVA: 0x0006B018 File Offset: 0x00069218
		public virtual void AutoCrouch()
		{
			if (this.autoCrouch)
			{
				this.isCrouching = true;
			}
			if (this.autoCrouch && !this.inCrouchArea && this.CanExitCrouch())
			{
				this.autoCrouch = false;
				this.isCrouching = false;
			}
		}

		// Token: 0x060014B9 RID: 5305 RVA: 0x0006B050 File Offset: 0x00069250
		public virtual bool CanExitCrouch()
		{
			if (this.isCrouching)
			{
				float radius = this._capsuleCollider.radius * 0.9f;
				Vector3 origin = base.transform.position + Vector3.up * (this.colliderHeight * 0.5f - this.colliderRadius);
				return !Physics.SphereCast(new Ray(origin, Vector3.up), radius, out this.groundHit, this.crouchHeadDetect - this.colliderRadius * 0.1f, this.autoCrouchLayer);
			}
			return true;
		}

		// Token: 0x060014BA RID: 5306 RVA: 0x0006B0E1 File Offset: 0x000692E1
		protected virtual void AutoCrouchExit(Collider other)
		{
			if (other.CompareTag("AutoCrouch"))
			{
				this.inCrouchArea = false;
			}
		}

		// Token: 0x060014BB RID: 5307 RVA: 0x0006B0F7 File Offset: 0x000692F7
		protected virtual void CheckForAutoCrouch(Collider other)
		{
			if (other.gameObject.CompareTag("AutoCrouch"))
			{
				this.autoCrouch = true;
				this.inCrouchArea = true;
			}
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x060014BC RID: 5308 RVA: 0x0006B119 File Offset: 0x00069319
		internal bool canRollAgain
		{
			get
			{
				return this.isRolling && this.animatorStateInfos.GetCurrentNormalizedTime(0) >= this.timeToRollAgain;
			}
		}

		// Token: 0x060014BD RID: 5309 RVA: 0x0006B13C File Offset: 0x0006933C
		protected virtual void RollBehavior()
		{
			if (!this.isRolling)
			{
				return;
			}
			if (this.rollControl)
			{
				this.inputSmooth = Vector3.Lerp(this.inputSmooth, this.input, (this.isStrafing ? this.strafeSpeed.movementSmooth : this.freeSpeed.movementSmooth) * Time.deltaTime);
			}
			this.RotateToDirection(this.moveDirection, this.rollRotationSpeed);
			Vector3 velocity = (this.useRollRootMotion ? new Vector3(base.animator.deltaPosition.x, 0f, base.animator.deltaPosition.z) : (base.transform.forward * Time.deltaTime)) * ((this.rollSpeed > 0f) ? this.rollSpeed : 1f) / Time.deltaTime * (1f - this.stopMoveWeight);
			if (this.rollUseGravity && base.animator.GetNormalizedTime(this.baseLayer, 2) >= this.rollUseGravityTime)
			{
				velocity.y = this._rigidbody.velocity.y;
			}
			this._rigidbody.velocity = velocity;
		}

		// Token: 0x060014BE RID: 5310 RVA: 0x0006B274 File Offset: 0x00069474
		protected virtual void CheckGround()
		{
			this.CheckGroundDistance();
			this.SlideOnSteepSlope();
			this.ControlMaterialPhysics();
			if (base.isDead || this.customAction || this.disableCheckGround || this.isSliding)
			{
				this.isGrounded = true;
				this.heightReached = base.transform.position.y;
				return;
			}
			if (this.groundDistance <= this.groundMinDistance || this.applyingStepOffset)
			{
				this.CheckFallDamage();
				this.isGrounded = true;
				if (!this.useSnapGround && !this.applyingStepOffset && !this.isJumping && this.groundDistance > 0.05f && this.extraGravity != 0f)
				{
					this._rigidbody.AddForce(base.transform.up * (this.extraGravity * 2f * Time.fixedDeltaTime), ForceMode.VelocityChange);
				}
				this.heightReached = base.transform.position.y;
				return;
			}
			if (this.groundDistance >= this.groundMaxDistance)
			{
				this.isGrounded = false;
				this.verticalVelocity = this._rigidbody.velocity.y;
				if (!this.applyingStepOffset && !this.isJumping && this.extraGravity != 0f)
				{
					this._rigidbody.AddForce(base.transform.up * this.extraGravity * Time.fixedDeltaTime, ForceMode.VelocityChange);
					return;
				}
			}
			else if (!this.applyingStepOffset && !this.isJumping && this.extraGravity != 0f)
			{
				this._rigidbody.AddForce(base.transform.up * (this.extraGravity * 2f * Time.fixedDeltaTime), ForceMode.VelocityChange);
			}
		}

		// Token: 0x060014BF RID: 5311 RVA: 0x0006B434 File Offset: 0x00069634
		protected virtual void CheckFallDamage()
		{
			if (this.isGrounded || this.verticalVelocity > this.fallMinVerticalVelocity || !this._canApplyFallDamage || this.fallMinHeight == 0f || this.fallDamage == 0f)
			{
				return;
			}
			float num = this.heightReached - base.transform.position.y;
			num -= this.fallMinHeight;
			if (num > 0f)
			{
				int value = (int)(this.fallDamage * num);
				this.TakeDamage(new vDamage(value, true));
			}
		}

		// Token: 0x060014C0 RID: 5312 RVA: 0x0006B4BC File Offset: 0x000696BC
		private void ControlMaterialPhysics()
		{
			PhysicMaterial currentMaterialPhysics = this.currentMaterialPhysics;
			if (this.isGrounded && this.input.magnitude < 0.1f && !this.isSliding && currentMaterialPhysics != this.maxFrictionPhysics)
			{
				currentMaterialPhysics = this.maxFrictionPhysics;
			}
			else if (this.isGrounded && this.input.magnitude > 0.1f && !this.isSliding && currentMaterialPhysics != this.frictionPhysics)
			{
				currentMaterialPhysics = this.frictionPhysics;
			}
			else if (currentMaterialPhysics != this.slippyPhysics && (this.isSliding || !this.isGrounded))
			{
				currentMaterialPhysics = this.slippyPhysics;
			}
			if (this.currentMaterialPhysics != currentMaterialPhysics)
			{
				this._capsuleCollider.material = currentMaterialPhysics;
				this.currentMaterialPhysics = currentMaterialPhysics;
			}
		}

		// Token: 0x060014C1 RID: 5313 RVA: 0x0006B588 File Offset: 0x00069788
		protected virtual void CheckGroundDistance()
		{
			if (base.isDead)
			{
				return;
			}
			if (this._capsuleCollider != null)
			{
				float radius = this._capsuleCollider.radius * 0.9f;
				float num = this.groundDetectionDistance;
				if (Physics.Raycast(new Ray(base.transform.position + new Vector3(0f, this.colliderHeight / 2f, 0f), Vector3.down), out this.groundHit, this.colliderHeight / 2f + num, this.groundLayer) && !this.groundHit.collider.isTrigger)
				{
					num = base.transform.position.y - this.groundHit.point.y;
				}
				if (this.groundCheckMethod == vThirdPersonMotor.GroundCheckMethod.High && num >= this.groundMinDistance)
				{
					Vector3 origin = base.transform.position + Vector3.up * this._capsuleCollider.radius;
					if (Physics.SphereCast(new Ray(origin, -Vector3.up), radius, out this.groundHit, this._capsuleCollider.radius + this.groundMaxDistance, this.groundLayer) && !this.groundHit.collider.isTrigger)
					{
						Physics.Linecast(this.groundHit.point + Vector3.up * 0.1f, this.groundHit.point + Vector3.down * 0.15f, out this.groundHit, this.groundLayer);
						float num2 = base.transform.position.y - this.groundHit.point.y;
						if (num > num2)
						{
							num = num2;
						}
					}
				}
				this.groundDistance = (float)Math.Round((double)num, 2);
			}
		}

		// Token: 0x060014C2 RID: 5314 RVA: 0x0006B771 File Offset: 0x00069971
		public virtual float GroundAngle()
		{
			return Vector3.Angle(this.groundHit.normal, Vector3.up);
		}

		// Token: 0x060014C3 RID: 5315 RVA: 0x0006B788 File Offset: 0x00069988
		public virtual float GroundAngleFromDirection()
		{
			return Vector3.Angle((this.isStrafing && this.input.magnitude > 0f) ? (base.transform.right * this.input.x + base.transform.forward * this.input.z).normalized : base.transform.forward, this.groundHit.normal) - 90f;
		}

		// Token: 0x060014C4 RID: 5316 RVA: 0x0006B818 File Offset: 0x00069A18
		protected virtual void AlignWithSurface()
		{
			Ray ray = new Ray(base.transform.position, -base.transform.up);
			Quaternion b = base.transform.rotation;
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit, 1.5f, this.groundLayer))
			{
				b = Quaternion.FromToRotation(base.transform.up, raycastHit.normal) * base.transform.localRotation;
			}
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, 10f * Time.fixedDeltaTime);
		}

		// Token: 0x060014C5 RID: 5317 RVA: 0x0006B8BC File Offset: 0x00069ABC
		protected bool CheckForSlope(ref Vector3 targetVelocity)
		{
			if (this.debugWindow)
			{
				Debug.DrawLine(base.transform.position + Vector3.up * (this._capsuleCollider.height * this.slopeLimitHeight), base.transform.position + this.moveDirection.normalized * (this.steepSlopeAhead ? (this._capsuleCollider.radius + this.slopeMaxDistance) : (this._capsuleCollider.radius + this.slopeMinDistance)), Color.red, 0.01f);
			}
			if (!this.useSlopeLimit || this.moveDirection.magnitude == 0f || targetVelocity.magnitude == 0f)
			{
				this._slopeSidewaysSmooth = 1f;
				return false;
			}
			if (Physics.Linecast(base.transform.position + Vector3.up * (this._capsuleCollider.height * this.slopeLimitHeight), base.transform.position + this.moveDirection.normalized * (this.steepSlopeAhead ? (this._capsuleCollider.radius + this.slopeMaxDistance) : (this._capsuleCollider.radius + this.slopeMinDistance)), out this.slopeHitInfo, this.groundLayer))
			{
				float num = Vector3.Angle(Vector3.up, this.slopeHitInfo.normal);
				if (num > this.slopeLimit && num < 85f)
				{
					Vector3 normal = this.slopeHitInfo.normal;
					normal.y = 0f;
					Vector3 vector = targetVelocity.normalized.AngleFormOtherDirection(-normal.normalized);
					Vector3 a = Quaternion.AngleAxis((vector.y > 0f) ? 90f : -90f, Vector3.up) * normal.normalized * targetVelocity.magnitude;
					if (Mathf.Abs(vector.y) > this.stopSlopeMargin)
					{
						this._slopeSidewaysSmooth = Mathf.Clamp(this._slopeSidewaysSmooth - Time.deltaTime * this.slopeSidewaysSmooth, 0f, 1f);
					}
					else
					{
						this._slopeSidewaysSmooth = 1f;
					}
					targetVelocity = Vector3.Lerp(a, Vector3.zero, this._slopeSidewaysSmooth);
					return true;
				}
			}
			this._slopeSidewaysSmooth = 1f;
			return false;
		}

		// Token: 0x060014C6 RID: 5318 RVA: 0x0006BB2C File Offset: 0x00069D2C
		protected virtual void SlideOnSteepSlope()
		{
			if (this.useSlide && this.isGrounded && this.GroundAngle() > this.slopeLimit && !this.disableCheckGround)
			{
				if (this._slidingEnterTime > 0f && !this.isSliding)
				{
					this._slidingEnterTime -= Time.fixedDeltaTime;
					return;
				}
				Vector3 normal = this.groundHit.normal;
				normal.y = 0f;
				Vector3 normalized = Vector3.ProjectOnPlane(normal.normalized, this.groundHit.normal).normalized;
				if (!Physics.Raycast(base.transform.position + Vector3.up * this.groundMinDistance, normalized, this.groundMaxDistance, this.groundLayer))
				{
					this.isSliding = true;
					return;
				}
			}
			else
			{
				this._rotateSlopeEnterTime = this.rotateSlopeEnterTime;
				this._slidingEnterTime = (this.isGrounded ? this.slidingEnterTime : 0f);
				this.isSliding = false;
			}
		}

		// Token: 0x060014C7 RID: 5319 RVA: 0x0006BC3C File Offset: 0x00069E3C
		protected virtual void SlideMovementBehavior()
		{
			if (!this.isSliding)
			{
				return;
			}
			Vector3 normal = this.groundHit.normal;
			normal.y = 0f;
			Vector3 normalized = Vector3.ProjectOnPlane(normal.normalized, this.groundHit.normal).normalized;
			if (this.debugWindow)
			{
				Debug.DrawRay(base.transform.position, normalized * this.slideDownVelocity);
			}
			this._rigidbody.velocity = Vector3.Lerp(this._rigidbody.velocity, normalized * this.slideDownVelocity, this.slideDownSmooth * Time.fixedDeltaTime);
			normalized.y = 0f;
			if (this._rotateSlopeEnterTime <= 0f)
			{
				Quaternion rot = Quaternion.LookRotation(Vector3.RotateTowards(base.transform.forward, normalized, this.rotateDownSlopeSmooth * Time.fixedDeltaTime, 0f));
				this._rigidbody.MoveRotation(rot);
				Vector3 vector = base.transform.InverseTransformDirection(this.moveDirection);
				vector.y = 0f;
				vector.z = 0f;
				vector = base.transform.TransformDirection(vector);
				if (this.debugWindow)
				{
					Debug.DrawRay(base.transform.position, vector * this.slideSidewaysVelocity, Color.blue);
				}
				this._rigidbody.AddForce(vector * this.slideSidewaysVelocity, ForceMode.VelocityChange);
				if (this.debugWindow)
				{
					Debug.DrawRay(base.transform.position, Vector3.ProjectOnPlane(normal.normalized, this.groundHit.normal).normalized, Color.blue);
					Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(90f, this.groundHit.normal) * Vector3.ProjectOnPlane(normal.normalized, this.groundHit.normal).normalized, Color.red);
					Debug.DrawRay(base.transform.position, base.transform.TransformDirection(vector.normalized * 2f), Color.green);
					return;
				}
			}
			else
			{
				this._rotateSlopeEnterTime -= Time.fixedDeltaTime;
			}
		}

		// Token: 0x060014C8 RID: 5320 RVA: 0x0006BE80 File Offset: 0x0006A080
		public virtual void ControlCapsuleHeight()
		{
			if (this.isCrouching && !this.isRolling)
			{
				this._capsuleCollider.center = this.colliderCenter / this.crouchHeightReduction;
				this._capsuleCollider.height = this.colliderHeight / this.crouchHeightReduction;
				this._capsuleCollider.radius = this.colliderRadius * this.crouchColliderRadius;
				return;
			}
			if (this.isRolling || (this.isRolling && this.isCrouching))
			{
				this._capsuleCollider.center = this.colliderCenter / this.rollHeightReduction;
				this._capsuleCollider.height = this.colliderHeight / this.rollHeightReduction;
				this._capsuleCollider.radius = this.colliderRadius * this.rollColliderRadius;
				return;
			}
			this._capsuleCollider.center = this.colliderCenter;
			this._capsuleCollider.radius = this.colliderRadius;
			this._capsuleCollider.height = this.colliderHeight;
		}

		// Token: 0x060014C9 RID: 5321 RVA: 0x0006BF82 File Offset: 0x0006A182
		public void ResetCapsule()
		{
			this.colliderCenter = this.colliderCenterDefault;
			this.colliderRadius = this.colliderRadiusDefault;
			this.colliderHeight = this.colliderHeightDefault;
		}

		// Token: 0x060014CA RID: 5322 RVA: 0x0006BFA8 File Offset: 0x0006A1A8
		public virtual void DisableGravityAndCollision()
		{
			base.animator.SetFloat("InputHorizontal", 0f);
			base.animator.SetFloat("InputVertical", 0f);
			base.animator.SetFloat("VerticalVelocity", 0f);
			this._rigidbody.useGravity = false;
			this._rigidbody.isKinematic = true;
			this._capsuleCollider.isTrigger = true;
			this._rigidbody.velocity = Vector3.zero;
		}

		// Token: 0x060014CB RID: 5323 RVA: 0x0006C028 File Offset: 0x0006A228
		public virtual void EnableGravityAndCollision()
		{
			this._capsuleCollider.isTrigger = false;
			this._rigidbody.useGravity = true;
			this._rigidbody.isKinematic = false;
		}

		// Token: 0x060014CC RID: 5324 RVA: 0x0006C050 File Offset: 0x0006A250
		protected virtual void CheckRagdoll()
		{
			if (this.ragdollVelocity == 0f)
			{
				return;
			}
			if (this.verticalVelocity <= this.ragdollVelocity && this.groundDistance <= 0.1f && this._canApplyFallDamage && !base.ragdolled)
			{
				base.onActiveRagdoll.Invoke(null);
			}
		}

		// Token: 0x060014CD RID: 5325 RVA: 0x0006C0A4 File Offset: 0x0006A2A4
		public override void ResetRagdoll()
		{
			this.onDisableRagdoll.Invoke();
			this.verticalVelocity = 0f;
			base.ragdolled = false;
			this._rigidbody.WakeUp();
			this._rigidbody.useGravity = true;
			this._rigidbody.isKinematic = false;
			this._capsuleCollider.isTrigger = false;
			this._capsuleCollider.enabled = true;
		}

		// Token: 0x060014CE RID: 5326 RVA: 0x0006C10C File Offset: 0x0006A30C
		public override void EnableRagdoll()
		{
			this.StopCharacter();
			base.animator.SetFloat("InputHorizontal", 0f);
			base.animator.SetFloat("InputVertical", 0f);
			base.animator.SetFloat("InputMagnitude", 0f);
			base.animator.SetFloat("VerticalVelocity", 0f);
			base.ragdolled = true;
			this._capsuleCollider.isTrigger = true;
			this._rigidbody.useGravity = false;
			this._rigidbody.isKinematic = true;
			this.lockAnimMovement = true;
		}

		// Token: 0x060014CF RID: 5327 RVA: 0x0006C1A8 File Offset: 0x0006A3A8
		public virtual string DebugInfo(string additionalText = "")
		{
			string result = string.Empty;
			if (this.debugWindow)
			{
				float smoothDeltaTime = Time.smoothDeltaTime;
				result = string.Concat(new string[]
				{
					" \nFPS ",
					(1f / smoothDeltaTime).ToString("#,##0 fps"),
					"\nHealth = ",
					base.currentHealth.ToString(),
					"\nInput Vertical = ",
					this.inputSmooth.z.ToString("0.0"),
					"\nInput Horizontal = ",
					this.inputSmooth.x.ToString("0.0"),
					"\nInput Magnitude = ",
					this.inputMagnitude.ToString("0.0"),
					"\nRotation Magnitude = ",
					this.rotationMagnitude.ToString("0.0"),
					"\nVertical Velocity = ",
					this.verticalVelocity.ToString("0.00"),
					"\nCurrent MoveSpeed = ",
					this.moveSpeed.ToString("0.00"),
					"\nGround Distance = ",
					this.groundDistance.ToString("0.00"),
					"\nGround Angle = ",
					this.GroundAngleFromDirection().ToString("0.00"),
					"\nIs Grounded = ",
					this.BoolToRichText(this.isGrounded),
					"\nIs Strafing = ",
					this.BoolToRichText(this.isStrafing),
					"\nIs Trigger = ",
					this.BoolToRichText(this._capsuleCollider.isTrigger),
					"\nUse Gravity = ",
					this.BoolToRichText(this._rigidbody.useGravity),
					"\nIs Kinematic = ",
					this.BoolToRichText(this._rigidbody.isKinematic),
					"\nLock Movement = ",
					this.BoolToRichText(this.lockMovement),
					"\nLock AnimMov = ",
					this.BoolToRichText(this.lockAnimMovement),
					"\nLock Rotation = ",
					this.BoolToRichText(this.lockRotation),
					"\nLock AnimRot = ",
					this.BoolToRichText(this.lockAnimRotation),
					"\n--- Actions Bools ---\nIs Sliding = ",
					this.BoolToRichText(this.isSliding),
					"\nIs Sprinting = ",
					this.BoolToRichText(this.isSprinting),
					"\nIs Crouching = ",
					this.BoolToRichText(this.isCrouching),
					"\nIs Rolling = ",
					this.BoolToRichText(this.isRolling),
					"\nIs Jumping = ",
					this.BoolToRichText(this.isJumping),
					"\nIs Airborne = ",
					this.BoolToRichText(this.isInAirborne),
					"\nIs Ragdolled = ",
					this.BoolToRichText(base.ragdolled),
					"\nCustomAction = ",
					this.BoolToRichText(this.customAction),
					"\n",
					additionalText
				});
			}
			return result;
		}

		// Token: 0x060014D0 RID: 5328 RVA: 0x0006C4C8 File Offset: 0x0006A6C8
		protected virtual string BoolToRichText(bool value)
		{
			if (!value)
			{
				return "<color=red> False </color>";
			}
			return "<color=yellow> True </color>";
		}

		// Token: 0x060014D1 RID: 5329 RVA: 0x0006C4D8 File Offset: 0x0006A6D8
		protected virtual void OnDrawGizmos()
		{
			if (Application.isPlaying && this.debugWindow)
			{
				Vector3 origin = base.transform.position + Vector3.up * (this.colliderHeight * 0.5f - this.colliderRadius);
				Ray ray = new Ray(origin, Vector3.up);
				Gizmos.DrawWireSphere(ray.GetPoint(this.crouchHeadDetect - this.colliderRadius * 0.1f), this.colliderRadius * 0.9f);
			}
		}

		// Token: 0x040019DE RID: 6622
		[vEditorToolbar("Stamina", false, "", false, false, order = 2)]
		public float maxStamina = 200f;

		// Token: 0x040019DF RID: 6623
		public float staminaRecovery = 1.2f;

		// Token: 0x040019E0 RID: 6624
		internal float currentStamina;

		// Token: 0x040019E1 RID: 6625
		internal float currentStaminaRecoveryDelay;

		// Token: 0x040019E2 RID: 6626
		public float sprintStamina = 30f;

		// Token: 0x040019E3 RID: 6627
		public float jumpStamina = 30f;

		// Token: 0x040019E4 RID: 6628
		public float rollStamina = 25f;

		// Token: 0x040019E5 RID: 6629
		[vEditorToolbar("Events", false, "", false, false, order = 7)]
		public UnityEvent OnRoll;

		// Token: 0x040019E6 RID: 6630
		public UnityEvent OnJump;

		// Token: 0x040019E7 RID: 6631
		public UnityEvent OnStartSprinting;

		// Token: 0x040019E8 RID: 6632
		public UnityEvent OnFinishSprinting;

		// Token: 0x040019E9 RID: 6633
		public UnityEvent OnFinishSprintingByStamina;

		// Token: 0x040019EA RID: 6634
		public UnityEvent OnStaminaEnd;

		// Token: 0x040019EB RID: 6635
		[vEditorToolbar("Crouch", false, "", false, false, order = 3)]
		[Range(1f, 2.5f)]
		public float crouchHeightReduction = 2f;

		// Token: 0x040019EC RID: 6636
		[Range(1f, 2f)]
		public float crouchColliderRadius = 1.5f;

		// Token: 0x040019ED RID: 6637
		[Tooltip("What objects can make the character auto crouch")]
		public LayerMask autoCrouchLayer = 1;

		// Token: 0x040019EE RID: 6638
		[Tooltip("[SPHERECAST] ADJUST IN PLAY MODE - White Spherecast put just above the head, this will make the character Auto-Crouch if something hit the sphere.")]
		public float crouchHeadDetect = 0.95f;

		// Token: 0x040019EF RID: 6639
		[vEditorToolbar("Locomotion", false, "", false, false, order = 0)]
		[vSeparator("Movement Settings", "")]
		[Tooltip("Multiply the current speed of the controller rigidbody velocity")]
		public float speedMultiplier;

		// Token: 0x040019F0 RID: 6640
		[Tooltip("Use this to rotate the character using the World axis, or false to use the camera axis - CHECK for Isometric Camera")]
		public bool rotateByWorld;

		// Token: 0x040019F1 RID: 6641
		[vHelpBox("FreeLocomotion: Rotate on any direction regardless of the camera \nStrafeLocomotion: Move always facing foward (extra directional animations)", vHelpBoxAttribute.MessageType.None)]
		public vThirdPersonMotor.LocomotionType locomotionType;

		// Token: 0x040019F2 RID: 6642
		public vThirdPersonMotor.vMovementSpeed freeSpeed;

		// Token: 0x040019F3 RID: 6643
		public vThirdPersonMotor.vMovementSpeed strafeSpeed;

		// Token: 0x040019F4 RID: 6644
		[vSeparator("Extra Animation Settings", "")]
		[Tooltip("Use it for debug purposes")]
		public bool disableAnimations;

		// Token: 0x040019F5 RID: 6645
		[Tooltip("Turn off if you have 'in place' animations and use this values above to move the character, or use with root motion as extra speed")]
		[vHelpBox("When 'Use RootMotion' is checked, make sure to reset all speeds to zero to use the original root motion velocity.", vHelpBoxAttribute.MessageType.None)]
		public bool useRootMotion;

		// Token: 0x040019F6 RID: 6646
		[Tooltip("While in Free Locomotion the character will lean to left/right when steering")]
		public bool useLeanMovementAnim = true;

		// Token: 0x040019F7 RID: 6647
		[Tooltip("Smooth value for the Lean Movement animation")]
		[Range(0.01f, 0.1f)]
		public float leanSmooth = 0.05f;

		// Token: 0x040019F8 RID: 6648
		[Tooltip("Check this to use the TurnOnSpot animations while the character is stading still and rotating in place")]
		public bool useTurnOnSpotAnim = true;

		// Token: 0x040019F9 RID: 6649
		[Tooltip("Put your Random Idle animations at the AnimatorController and select a value to randomize, 0 is disable.")]
		public float randomIdleTime;

		// Token: 0x040019FA RID: 6650
		internal bool ignoreAnimatorMovement;

		// Token: 0x040019FB RID: 6651
		[vSeparator("Extra Movement Settings", "")]
		[Tooltip("Check This to use sprint on press button to your Character run until the stamina finish or movement stops\nIf uncheck your Character will sprint as long as the SprintInput is pressed or the stamina finishes")]
		public bool useContinuousSprint = true;

		// Token: 0x040019FC RID: 6652
		[Tooltip("Check this to sprint always in free movement")]
		public bool sprintOnlyFree = true;

		// Token: 0x040019FD RID: 6653
		[vEditorToolbar("Jump / Airborne", false, "", false, false, order = 3)]
		[vHelpBox("Jump only works via Rigidbody Physics, if you want Jump that use only RootMotion make sure to use the AnimatorTag 'CustomAction' ", vHelpBoxAttribute.MessageType.None)]
		[vSeparator("Jump", "")]
		[Tooltip("Use the currently Rigidbody Velocity to influence on the Jump Distance")]
		public bool jumpWithRigidbodyForce;

		// Token: 0x040019FE RID: 6654
		[Tooltip("Rotate or not while airborne")]
		public bool jumpAndRotate = true;

		// Token: 0x040019FF RID: 6655
		[Tooltip("How much time the character will be jumping")]
		public float jumpTimer = 0.3f;

		// Token: 0x04001A00 RID: 6656
		[Tooltip("Delay to match the animation anticipation")]
		public float jumpStandingDelay = 0.25f;

		// Token: 0x04001A01 RID: 6657
		internal float jumpCounter;

		// Token: 0x04001A02 RID: 6658
		[Tooltip("Add Extra jump height, if you want to jump only with Root Motion leave the value with 0.")]
		public float jumpHeight = 4f;

		// Token: 0x04001A03 RID: 6659
		[vSeparator("Falling", "")]
		[Tooltip("Speed that the character will move while airborne")]
		public float airSpeed = 5f;

		// Token: 0x04001A04 RID: 6660
		[Tooltip("Smoothness of the direction while airborne")]
		public float airSmooth = 6f;

		// Token: 0x04001A05 RID: 6661
		[Tooltip("Apply extra gravity when the character is not grounded")]
		public float extraGravity = -10f;

		// Token: 0x04001A06 RID: 6662
		[Tooltip("Limit of the vertival velocity when Falling")]
		public float limitFallVelocity = -15f;

		// Token: 0x04001A07 RID: 6663
		[Tooltip("Turn the Ragdoll On when falling at high speed (check VerticalVelocity) - leave the value with 0 if you don't want this feature")]
		public float ragdollVelocity = -15f;

		// Token: 0x04001A08 RID: 6664
		[vSeparator("Fall Damage", "")]
		public float fallMinHeight = 6f;

		// Token: 0x04001A09 RID: 6665
		public float fallMinVerticalVelocity = -10f;

		// Token: 0x04001A0A RID: 6666
		public float fallDamage = 10f;

		// Token: 0x04001A0B RID: 6667
		[vEditorToolbar("Roll", false, "", false, false, order = 4)]
		public bool useRollRootMotion = true;

		// Token: 0x04001A0C RID: 6668
		[Tooltip("Animation Transition from current animation to Roll")]
		public float rollTransition = 0.25f;

		// Token: 0x04001A0D RID: 6669
		[Range(1f, 2.5f)]
		public float rollHeightReduction = 1.6f;

		// Token: 0x04001A0E RID: 6670
		[Range(1f, 2f)]
		public float rollColliderRadius = 1.5f;

		// Token: 0x04001A0F RID: 6671
		[Tooltip("Can control the Roll Direction")]
		public bool rollControl = true;

		// Token: 0x04001A10 RID: 6672
		[Tooltip("Speed of the Roll Movement")]
		public float rollSpeed;

		// Token: 0x04001A11 RID: 6673
		[Tooltip("Speed of the Roll Rotation")]
		public float rollRotationSpeed = 20f;

		// Token: 0x04001A12 RID: 6674
		[vHideInInspector("Roll use gravity inflence", false)]
		public bool rollUseGravity = true;

		// Token: 0x04001A13 RID: 6675
		[vHideInInspector("rollUseGravity", false)]
		[Tooltip("Normalized Time of the roll animation to enable gravity influence")]
		public float rollUseGravityTime = 0.2f;

		// Token: 0x04001A14 RID: 6676
		[Tooltip("Use the normalized time of the animation to know when you can roll again")]
		[Range(0f, 1f)]
		public float timeToRollAgain = 0.75f;

		// Token: 0x04001A15 RID: 6677
		[Tooltip("Ignore all damage while is rolling, include Damage that ignore defence")]
		public bool noDamageWhileRolling = true;

		// Token: 0x04001A16 RID: 6678
		[Tooltip("Ignore damage that needs to activate ragdoll")]
		public bool noActiveRagdollWhileRolling = true;

		// Token: 0x04001A17 RID: 6679
		[vEditorToolbar("Grounded", false, "", false, false, order = 3)]
		[vSeparator("Ground", "")]
		[Tooltip("Layers that the character can walk on")]
		public LayerMask groundLayer = 1;

		// Token: 0x04001A18 RID: 6680
		[Tooltip("Ground Check Method To check ground Distance and ground angle\n*Simple: Use just a single Raycast\n*Normal: Use Raycast and SphereCast\n*Complex: Use SphereCastAll")]
		public vThirdPersonMotor.GroundCheckMethod groundCheckMethod = vThirdPersonMotor.GroundCheckMethod.High;

		// Token: 0x04001A19 RID: 6681
		[Tooltip("The length of the Ray cast to detect ground ")]
		public float groundDetectionDistance = 10f;

		// Token: 0x04001A1A RID: 6682
		[Tooltip("Snaps the capsule collider to the ground surface, recommend when using complex terrains or inclined ramps")]
		public bool useSnapGround = true;

		// Token: 0x04001A1B RID: 6683
		[Range(0f, 1f)]
		public float snapPower = 0.5f;

		// Token: 0x04001A1C RID: 6684
		[Tooltip("Distance to became not grounded")]
		[Range(0f, 10f)]
		public float groundMinDistance = 0.1f;

		// Token: 0x04001A1D RID: 6685
		[Range(0f, 10f)]
		public float groundMaxDistance = 0.5f;

		// Token: 0x04001A1E RID: 6686
		[Tooltip("Max angle to walk")]
		[vSeparator("StopMove", "")]
		public LayerMask stopMoveLayer;

		// Token: 0x04001A1F RID: 6687
		[vHelpBox("Character will stop moving, ex: walls - set the layer to nothing to not use", vHelpBoxAttribute.MessageType.None)]
		public float stopMoveRayDistance = 1f;

		// Token: 0x04001A20 RID: 6688
		public float stopMoveMaxHeight = 1.6f;

		// Token: 0x04001A21 RID: 6689
		public vThirdPersonMotor.StopMoveCheckMethod stopMoveCheckMethod;

		// Token: 0x04001A22 RID: 6690
		[vSeparator("Slope Limit", "")]
		public bool useSlopeLimit = true;

		// Token: 0x04001A23 RID: 6691
		[Range(30f, 80f)]
		public float slopeLimit = 75f;

		// Token: 0x04001A24 RID: 6692
		public float stopSlopeMargin = 20f;

		// Token: 0x04001A25 RID: 6693
		public float slopeSidewaysSmooth = 2f;

		// Token: 0x04001A26 RID: 6694
		public float slopeMinDistance;

		// Token: 0x04001A27 RID: 6695
		public float slopeMaxDistance = 1.5f;

		// Token: 0x04001A28 RID: 6696
		public float slopeLimitHeight = 0.2f;

		// Token: 0x04001A29 RID: 6697
		protected float _slopeSidewaysSmooth;

		// Token: 0x04001A2A RID: 6698
		[HideInInspector]
		public bool steepSlopeAhead;

		// Token: 0x04001A2B RID: 6699
		[vSeparator("Slide On Slopes", "")]
		public bool useSlide = true;

		// Token: 0x04001A2C RID: 6700
		[Tooltip("Velocity to slide down when on a slope limit ramp")]
		[Range(0f, 30f)]
		public float slideDownVelocity = 10f;

		// Token: 0x04001A2D RID: 6701
		[Tooltip("Smooth to slide down the controller")]
		public float slideDownSmooth = 2f;

		// Token: 0x04001A2E RID: 6702
		[Tooltip("Velocity to slide sideways when on a slope limit ramp")]
		[Range(0f, 1f)]
		public float slideSidewaysVelocity = 0.5f;

		// Token: 0x04001A2F RID: 6703
		[Range(0f, 1f)]
		[Tooltip("Delay to start sliding once the character is standing on a slope")]
		public float slidingEnterTime = 0.2f;

		// Token: 0x04001A30 RID: 6704
		internal float _slidingEnterTime;

		// Token: 0x04001A31 RID: 6705
		[Range(0f, 1f)]
		[Tooltip("Delay to rotate once the character started sliding")]
		public float rotateSlopeEnterTime = 0.1f;

		// Token: 0x04001A32 RID: 6706
		[Tooltip("Smooth to rotate the controller")]
		public float rotateDownSlopeSmooth = 8f;

		// Token: 0x04001A33 RID: 6707
		internal float _rotateSlopeEnterTime;

		// Token: 0x04001A34 RID: 6708
		[vSeparator("Step Offset", "")]
		public bool useStepOffset = true;

		// Token: 0x04001A35 RID: 6709
		[Tooltip("Offset max height to walk on steps - YELLOW Raycast in front of the legs")]
		[Range(0f, 1f)]
		public float stepOffsetMaxHeight = 0.5f;

		// Token: 0x04001A36 RID: 6710
		[Tooltip("Offset min height to walk on steps. Make sure to keep slight above the floor - YELLOW Raycast in front of the legs")]
		[Range(0f, 1f)]
		public float stepOffsetMinHeight;

		// Token: 0x04001A37 RID: 6711
		[Tooltip("Offset distance to walk on steps - YELLOW Raycast in front of the legs")]
		[Range(0f, 1f)]
		public float stepOffsetDistance = 0.1f;

		// Token: 0x04001A38 RID: 6712
		internal float stopMoveWeight;

		// Token: 0x04001A39 RID: 6713
		internal float sprintWeight;

		// Token: 0x04001A3A RID: 6714
		internal float groundDistance;

		// Token: 0x04001A3B RID: 6715
		public RaycastHit groundHit;

		// Token: 0x04001A3C RID: 6716
		[vEditorToolbar("Debug", false, "", false, false, order = 9)]
		[Header("--- Debug Info ---")]
		public bool debugWindow;

		// Token: 0x04001A3D RID: 6717
		public vAnimatorStateInfos _animatorStateInfos;

		// Token: 0x04001A44 RID: 6724
		internal bool isRolling;

		// Token: 0x04001A45 RID: 6725
		internal bool isJumping;

		// Token: 0x04001A46 RID: 6726
		internal bool isInAirborne;

		// Token: 0x04001A47 RID: 6727
		internal bool isTurningOnSpot;

		// Token: 0x04001A48 RID: 6728
		internal bool customAction;

		// Token: 0x04001A49 RID: 6729
		internal Rigidbody _rigidbody;

		// Token: 0x04001A4A RID: 6730
		internal PhysicMaterial frictionPhysics;

		// Token: 0x04001A4B RID: 6731
		internal PhysicMaterial maxFrictionPhysics;

		// Token: 0x04001A4C RID: 6732
		internal PhysicMaterial slippyPhysics;

		// Token: 0x04001A4D RID: 6733
		internal CapsuleCollider _capsuleCollider;

		// Token: 0x04001A4F RID: 6735
		internal float defaultSpeedMultiplier;

		// Token: 0x04001A50 RID: 6736
		internal float inputMagnitude;

		// Token: 0x04001A51 RID: 6737
		internal float rotationMagnitude;

		// Token: 0x04001A52 RID: 6738
		internal float verticalSpeed;

		// Token: 0x04001A53 RID: 6739
		internal float horizontalSpeed;

		// Token: 0x04001A54 RID: 6740
		internal bool invertVerticalSpeed;

		// Token: 0x04001A55 RID: 6741
		internal bool invertHorizontalSpeed;

		// Token: 0x04001A56 RID: 6742
		internal float moveSpeed;

		// Token: 0x04001A57 RID: 6743
		internal float verticalVelocity;

		// Token: 0x04001A58 RID: 6744
		internal float colliderRadius;

		// Token: 0x04001A59 RID: 6745
		internal float colliderHeight;

		// Token: 0x04001A5A RID: 6746
		internal float jumpMultiplier = 1f;

		// Token: 0x04001A5B RID: 6747
		internal float timeToResetJumpMultiplier;

		// Token: 0x04001A5C RID: 6748
		internal float heightReached;

		// Token: 0x04001A5D RID: 6749
		internal bool lockMovement;

		// Token: 0x04001A5E RID: 6750
		internal bool lockRotation;

		// Token: 0x04001A5F RID: 6751
		internal bool lockSetMoveSpeed;

		// Token: 0x04001A60 RID: 6752
		internal bool _isStrafing;

		// Token: 0x04001A61 RID: 6753
		internal bool lockInStrafe;

		// Token: 0x04001A62 RID: 6754
		internal bool forceRootMotion;

		// Token: 0x04001A63 RID: 6755
		internal bool keepDirection;

		// Token: 0x04001A64 RID: 6756
		internal bool finishStaminaOnSprint;

		// Token: 0x04001A65 RID: 6757
		[HideInInspector]
		public bool applyingStepOffset;

		// Token: 0x04001A66 RID: 6758
		protected internal bool lockAnimMovement;

		// Token: 0x04001A67 RID: 6759
		protected internal bool lockAnimRotation;

		// Token: 0x04001A68 RID: 6760
		protected Vector3 lastCharacterAngle;

		// Token: 0x04001A69 RID: 6761
		internal Transform rotateTarget;

		// Token: 0x04001A6A RID: 6762
		internal Vector3 input;

		// Token: 0x04001A6B RID: 6763
		internal Vector3 oldInput;

		// Token: 0x04001A6C RID: 6764
		internal Vector3 colliderCenter;

		// Token: 0x04001A6D RID: 6765
		[HideInInspector]
		public Vector3 inputSmooth;

		// Token: 0x04001A6E RID: 6766
		[HideInInspector]
		public Vector3 moveDirection;

		// Token: 0x04001A6F RID: 6767
		public RaycastHit stepOffsetHit;

		// Token: 0x04001A70 RID: 6768
		public RaycastHit slopeHitInfo;

		// Token: 0x04001A71 RID: 6769
		internal AnimatorStateInfo baseLayerInfo;

		// Token: 0x04001A72 RID: 6770
		internal AnimatorStateInfo underBodyInfo;

		// Token: 0x04001A73 RID: 6771
		internal AnimatorStateInfo rightArmInfo;

		// Token: 0x04001A74 RID: 6772
		internal AnimatorStateInfo leftArmInfo;

		// Token: 0x04001A75 RID: 6773
		internal AnimatorStateInfo fullBodyInfo;

		// Token: 0x04001A76 RID: 6774
		internal AnimatorStateInfo upperBodyInfo;

		// Token: 0x04001A7B RID: 6779
		internal bool blockApplyFallDamage;

		// Token: 0x020003F7 RID: 1015
		public enum LocomotionType
		{
			// Token: 0x04001A7D RID: 6781
			FreeWithStrafe,
			// Token: 0x04001A7E RID: 6782
			OnlyStrafe,
			// Token: 0x04001A7F RID: 6783
			OnlyFree
		}

		// Token: 0x020003F8 RID: 1016
		public enum GroundCheckMethod
		{
			// Token: 0x04001A81 RID: 6785
			Low,
			// Token: 0x04001A82 RID: 6786
			High
		}

		// Token: 0x020003F9 RID: 1017
		public enum StopMoveCheckMethod
		{
			// Token: 0x04001A84 RID: 6788
			RayCast,
			// Token: 0x04001A85 RID: 6789
			SphereCast,
			// Token: 0x04001A86 RID: 6790
			CapsuleCast
		}

		// Token: 0x020003FA RID: 1018
		[Serializable]
		public class vMovementSpeed
		{
			// Token: 0x04001A87 RID: 6791
			[vHelpBox("Higher means faster/responsive movement, lower means smooth movement", vHelpBoxAttribute.MessageType.None)]
			[Range(1f, 20f)]
			public float movementSmooth = 6f;

			// Token: 0x04001A88 RID: 6792
			[vHelpBox("Lower means faster transitions between animations, higher means slower", vHelpBoxAttribute.MessageType.None)]
			[Range(0f, 1f)]
			public float animationSmooth = 0.2f;

			// Token: 0x04001A89 RID: 6793
			[Tooltip("Rotation speed of the character")]
			public float rotationSpeed = 20f;

			// Token: 0x04001A8A RID: 6794
			[Tooltip("Character will limit the movement to walk instead of running")]
			public bool walkByDefault;

			// Token: 0x04001A8B RID: 6795
			[Tooltip("Rotate with the Camera forward when standing idle")]
			public bool rotateWithCamera;

			// Token: 0x04001A8C RID: 6796
			[Tooltip("Speed to Walk using rigidbody or extra speed if you're using RootMotion")]
			public float walkSpeed = 2f;

			// Token: 0x04001A8D RID: 6797
			[Tooltip("Speed to Run using rigidbody or extra speed if you're using RootMotion")]
			public float runningSpeed = 4f;

			// Token: 0x04001A8E RID: 6798
			[Tooltip("Speed to Sprint using rigidbody or extra speed if you're using RootMotion")]
			public float sprintSpeed = 6f;

			// Token: 0x04001A8F RID: 6799
			[Tooltip("Speed to Crouch using rigidbody or extra speed if you're using RootMotion")]
			public float crouchSpeed = 2f;
		}
	}
}
