using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000042 RID: 66
	[HelpURL("http://root-motion.com/puppetmasterdox/html/page10.html")]
	[AddComponentMenu("Scripts/RootMotion.Dynamics/PuppetMaster/Behaviours/BehaviourPuppet")]
	public class BehaviourPuppet : BehaviourBase
	{
		// Token: 0x060001B6 RID: 438 RVA: 0x00009723 File Offset: 0x00007923
		protected override string GetTypeSpring()
		{
			return "BehaviourPuppet";
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0000972A File Offset: 0x0000792A
		[ContextMenu("User Manual")]
		private void OpenUserManual()
		{
			Application.OpenURL("http://root-motion.com/puppetmasterdox/html/page10.html");
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00009736 File Offset: 0x00007936
		[ContextMenu("Scrpt Reference")]
		private void OpenScriptReference()
		{
			Application.OpenURL("http://root-motion.com/puppetmasterdox/html/class_root_motion_1_1_dynamics_1_1_behaviour_puppet.html");
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00009742 File Offset: 0x00007942
		// (set) Token: 0x060001BA RID: 442 RVA: 0x0000974A File Offset: 0x0000794A
		public BehaviourPuppet.State state { get; private set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00009753 File Offset: 0x00007953
		// (set) Token: 0x060001BC RID: 444 RVA: 0x0000975B File Offset: 0x0000795B
		public Vector3 platformVelocity { get; set; }

		// Token: 0x060001BD RID: 445 RVA: 0x00009764 File Offset: 0x00007964
		public override void OnReactivate()
		{
			this.state = ((this.puppetMaster.state == PuppetMaster.State.Alive) ? BehaviourPuppet.State.Puppet : BehaviourPuppet.State.Unpinned);
			this.getUpTimer = 0f;
			this.unpinnedTimer = 0f;
			this.getupAnimationBlendWeight = 0f;
			this.getUpTargetFixed = false;
			this.getupDisabled = (this.puppetMaster.state > PuppetMaster.State.Alive);
			this.state = ((this.puppetMaster.state == PuppetMaster.State.Alive) ? BehaviourPuppet.State.Puppet : BehaviourPuppet.State.Unpinned);
			foreach (Muscle muscle in this.puppetMaster.muscles)
			{
				if (!muscle.state.isDisconnected)
				{
					this.SetColliders(muscle, this.state == BehaviourPuppet.State.Unpinned);
				}
			}
			base.enabled = true;
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000981D File Offset: 0x00007A1D
		public void Reset(Vector3 position, Quaternion rotation)
		{
			Debug.LogWarning("BehaviourPuppet.Reset has been deprecated, please use PuppetMaster.Teleport instead.");
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00009829 File Offset: 0x00007A29
		public void SetHasCollided(bool to)
		{
			this.hasCollidedSinceGetUp = to;
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00009832 File Offset: 0x00007A32
		public override void OnTeleport(Quaternion deltaRotation, Vector3 deltaPosition, Vector3 pivot, bool moveToTarget)
		{
			this.getUpPosition = pivot + deltaRotation * (this.getUpPosition - pivot) + deltaPosition;
			if (moveToTarget)
			{
				this.getupAnimationBlendWeight = 0f;
			}
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00009867 File Offset: 0x00007A67
		public void OnDisable()
		{
			this.unpinnedTimer = 0f;
			this.getUpTimer = 0f;
			this.getupDisabled = true;
			this.getUpTargetFixed = false;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00009890 File Offset: 0x00007A90
		protected override void OnInitiate()
		{
			BehaviourPuppet.CollisionResistanceMultiplier[] array = this.collisionResistanceMultipliers;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].layers == 0)
				{
					Debug.LogWarning("BehaviourPuppet has a Collision Resistance Multiplier that's layers is set to Nothing. Please add some layers.", base.transform);
				}
			}
			int num = 0;
			foreach (Muscle muscle in this.puppetMaster.muscles)
			{
				if (muscle.joint.gameObject.layer == this.puppetMaster.targetRoot.gameObject.layer)
				{
					Debug.LogError("One of the ragdoll bones is on the same layer as the animated character. This might make the ragdoll collide with the character controller.");
				}
				if (!Physics.GetIgnoreLayerCollision(muscle.joint.gameObject.layer, this.puppetMaster.targetRoot.gameObject.layer))
				{
					Debug.LogError(string.Concat(new string[]
					{
						"The ragdoll layer (",
						muscle.joint.gameObject.layer.ToString(),
						") and the character controller layer (",
						this.puppetMaster.targetRoot.gameObject.layer.ToString(),
						") are not set to ignore each other in Edit/Project Settings/Physics/Layer Collision Matrix. This might cause the ragdoll bones to collide with the character controller."
					}));
				}
				if (muscle.props.group == Muscle.Group.Hips)
				{
					num++;
				}
				if (num > 1)
				{
					Debug.LogError("BehaviourPuppet found more than 1 muscle with 'Hips' group. Please expand the 'Muscles' array on the bottom of PuppetMaster and assign all muscles to the appropriate groups.", base.transform);
				}
			}
			this.hipsForward = new Vector3(0.003583335f, 0.5754859f, 0.8178042f);
			this.hipsUp = new Vector3(-0.01943771f, 0.8176947f, -0.5753238f);
			this.state = BehaviourPuppet.State.Unpinned;
			this.eventsEnabled = true;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00009A2C File Offset: 0x00007C2C
		protected override void OnActivate()
		{
			bool flag = true;
			if (this.puppetMaster.pinWeight > 0f)
			{
				Muscle[] muscles = this.puppetMaster.muscles;
				for (int i = 0; i < muscles.Length; i++)
				{
					if (muscles[i].state.pinWeightMlp > 0.5f)
					{
						flag = false;
						break;
					}
				}
			}
			bool flag2 = this.eventsEnabled;
			this.eventsEnabled = false;
			if (flag)
			{
				this.SetState(BehaviourPuppet.State.Unpinned);
			}
			else
			{
				this.SetState(BehaviourPuppet.State.Puppet);
			}
			this.eventsEnabled = flag2;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00009AA8 File Offset: 0x00007CA8
		public override void KillStart()
		{
			this.getupDisabled = true;
			foreach (Muscle muscle in this.puppetMaster.muscles)
			{
				if (!muscle.state.isDisconnected)
				{
					muscle.state.pinWeightMlp = 0f;
					if (this.hasBoosted)
					{
						muscle.state.immunity = 0f;
					}
					this.SetColliders(muscle, true);
				}
			}
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00009B17 File Offset: 0x00007D17
		public override void KillEnd()
		{
			this.SetState(BehaviourPuppet.State.Unpinned);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00009B20 File Offset: 0x00007D20
		public void PuppetTwo()
		{
			this.state = BehaviourPuppet.State.Puppet;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00009B2C File Offset: 0x00007D2C
		public override void Resurrect()
		{
			this.getupDisabled = false;
			if (this.state == BehaviourPuppet.State.Unpinned)
			{
				this.getUpTimer = float.PositiveInfinity;
				this.unpinnedTimer = float.PositiveInfinity;
				this.getupAnimationBlendWeight = 0f;
				Muscle[] muscles = this.puppetMaster.muscles;
				for (int i = 0; i < muscles.Length; i++)
				{
					muscles[i].state.pinWeightMlp = 0f;
				}
			}
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00009B96 File Offset: 0x00007D96
		protected override void OnDeactivate()
		{
			this.state = BehaviourPuppet.State.Unpinned;
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00009BA0 File Offset: 0x00007DA0
		protected override void OnFixedUpdate(float deltaTime)
		{
			this.collisions = 0;
			if (this.dropPropFlag)
			{
				base.RemovePropMuscles();
				PropMuscle[] propMuscles = this.puppetMaster.propMuscles;
				for (int i = 0; i < propMuscles.Length; i++)
				{
					propMuscles[i].currentProp = null;
				}
				this.dropPropFlag = false;
			}
			if (!this.puppetMaster.isActive && !this.puppetMaster.isSwitchingMode)
			{
				this.SetState(BehaviourPuppet.State.Puppet);
				return;
			}
			if (!this.puppetMaster.isAlive)
			{
				foreach (Muscle muscle in this.puppetMaster.muscles)
				{
					if (!muscle.state.isDisconnected)
					{
						muscle.state.pinWeightMlp = 0f;
						muscle.state.mappingWeightMlp = Mathf.MoveTowards(muscle.state.mappingWeightMlp, 1f, deltaTime * 5f);
					}
				}
				return;
			}
			if (this.hasBoosted)
			{
				foreach (Muscle muscle2 in this.puppetMaster.muscles)
				{
					if (!muscle2.state.isDisconnected)
					{
						muscle2.state.immunity = Mathf.MoveTowards(muscle2.state.immunity, 0f, deltaTime * this.boostFalloff);
						muscle2.state.impulseMlp = Mathf.Lerp(muscle2.state.impulseMlp, 1f, deltaTime * this.boostFalloff);
					}
				}
			}
			if (this.state == BehaviourPuppet.State.Unpinned)
			{
				this.unpinnedTimer += deltaTime;
				if (this.unpinnedTimer >= this.getUpDelay && this.canGetUp && !this.getupDisabled && (this.puppetMaster.muscles[0].rigidbody.velocity - this.platformVelocity).sqrMagnitude < this.maxGetUpVelocity * this.maxGetUpVelocity)
				{
					Vector3 point = new Vector3(0f, -0.15f, 0f);
					this.MoveTarget(this.puppetMaster.muscles[0].rigidbody.position + this.puppetMaster.targetRoot.rotation * point);
					this.RotateTarget(Quaternion.Euler(0f, this.puppetMaster.targetRoot.eulerAngles.y, 0f));
					this.SetState(BehaviourPuppet.State.GetUp);
					return;
				}
				foreach (Muscle muscle3 in this.puppetMaster.muscles)
				{
					if (!muscle3.state.isDisconnected)
					{
						muscle3.state.pinWeightMlp = 0f;
						muscle3.state.mappingWeightMlp = Mathf.MoveTowards(muscle3.state.mappingWeightMlp, 1f, deltaTime * this.masterProps.mappingBlendSpeed);
					}
				}
			}
			if (this.hasCollidedSinceGetUp && Time.time > this.lastCollisionTime + 3f)
			{
				this.hasCollidedSinceGetUp = false;
			}
			if (this.state != BehaviourPuppet.State.Unpinned && !this.puppetMaster.isKilling)
			{
				if (this.knockOutDistance != this.lastKnockOutDistance)
				{
					this.knockOutDistanceSqr = Mathf.Sqrt(this.knockOutDistance);
					this.lastKnockOutDistance = this.knockOutDistance;
				}
				foreach (Muscle muscle4 in this.puppetMaster.muscles)
				{
					BehaviourPuppet.MuscleProps props = this.GetProps(muscle4.props.group);
					float num = 1f;
					if (this.state == BehaviourPuppet.State.GetUp)
					{
						num = Mathf.Lerp(this.getUpKnockOutDistanceMlp, num, muscle4.state.pinWeightMlp);
					}
					float num2 = this.unpinnedMuscleKnockout ? muscle4.positionOffset.sqrMagnitude : (muscle4.positionOffset.sqrMagnitude * muscle4.props.pinWeight * this.puppetMaster.pinWeight);
					if (this.puppetMaster.pinWeight < 1f)
					{
						this.hasCollidedSinceGetUp = true;
						this.lastCollisionTime = Time.time;
					}
					float num3 = muscle4.state.pinWeightMlp * muscle4.props.pinWeight * this.puppetMaster.pinWeight;
					if (this.hasCollidedSinceGetUp && !muscle4.state.isDisconnected && !this.puppetMaster.isBlending && num2 > 0f && num3 <= this.pinWeightThreshold && num2 > props.knockOutDistance * this.knockOutDistanceSqr * num)
					{
						if (this.state != BehaviourPuppet.State.GetUp || this.getUpTargetFixed)
						{
							this.SetState(BehaviourPuppet.State.Unpinned);
						}
						return;
					}
					if (!muscle4.state.isDisconnected)
					{
						muscle4.state.muscleWeightMlp = Mathf.Lerp(this.unpinnedMuscleWeightMlp, 1f, muscle4.state.pinWeightMlp);
						if (this.state == BehaviourPuppet.State.GetUp)
						{
							muscle4.state.muscleDamperAdd = 0f;
						}
						if (!this.puppetMaster.isKilling)
						{
							float num4 = 1f;
							if (this.state == BehaviourPuppet.State.GetUp)
							{
								num4 = Mathf.Lerp(this.getUpRegainPinSpeedMlp, 1f, muscle4.state.pinWeightMlp);
							}
							Muscle muscle5 = muscle4;
							muscle5.state.pinWeightMlp = muscle5.state.pinWeightMlp + deltaTime * props.regainPinSpeed * this.regainPinSpeed * num4;
						}
					}
				}
				float num5 = 1f;
				foreach (Muscle muscle6 in this.puppetMaster.muscles)
				{
					if ((muscle6.props.group == Muscle.Group.Leg || muscle6.props.group == Muscle.Group.Foot) && !muscle6.state.isDisconnected && muscle6.state.pinWeightMlp < num5)
					{
						num5 = muscle6.state.pinWeightMlp;
					}
				}
				foreach (Muscle muscle7 in this.puppetMaster.muscles)
				{
					muscle7.state.pinWeightMlp = Mathf.Clamp(muscle7.state.pinWeightMlp, 0f, num5 * 5f);
				}
			}
			if (this.state == BehaviourPuppet.State.GetUp)
			{
				this.getUpTimer += deltaTime;
				if (this.getUpTimer > this.minGetUpDuration)
				{
					this.getUpTimer = 0f;
					this.SetState(BehaviourPuppet.State.Puppet);
				}
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000A1D0 File Offset: 0x000083D0
		protected override void OnLateUpdate(float deltaTime)
		{
			base.forceActive = (this.state > BehaviourPuppet.State.Puppet);
			if (!this.puppetMaster.isAlive)
			{
				return;
			}
			if (this.masterProps.normalMode != this.lastNormalMode)
			{
				if (this.lastNormalMode == BehaviourPuppet.NormalMode.Unmapped)
				{
					Muscle[] muscles = this.puppetMaster.muscles;
					for (int i = 0; i < muscles.Length; i++)
					{
						muscles[i].state.mappingWeightMlp = 1f;
					}
				}
				if (this.lastNormalMode == BehaviourPuppet.NormalMode.Kinematic && this.puppetMaster.mode == PuppetMaster.Mode.Kinematic)
				{
					this.puppetMaster.mode = PuppetMaster.Mode.Active;
				}
				this.lastNormalMode = this.masterProps.normalMode;
			}
			BehaviourPuppet.NormalMode normalMode = this.masterProps.normalMode;
			if (normalMode != BehaviourPuppet.NormalMode.Unmapped)
			{
				if (normalMode != BehaviourPuppet.NormalMode.Kinematic)
				{
					return;
				}
				if (this.SetKinematic())
				{
					this.puppetMaster.mode = PuppetMaster.Mode.Kinematic;
				}
			}
			else if (this.puppetMaster.isActive)
			{
				bool flag = this.puppetMaster.pinWeight < 1f;
				for (int j = 0; j < this.puppetMaster.muscles.Length; j++)
				{
					this.BlendMuscleMapping(j, ref flag, deltaTime);
				}
				return;
			}
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0000A2E8 File Offset: 0x000084E8
		private bool SetKinematic()
		{
			if (!this.puppetMaster.isActive)
			{
				return false;
			}
			if (this.state != BehaviourPuppet.State.Puppet)
			{
				return false;
			}
			if (this.puppetMaster.isBlending)
			{
				return false;
			}
			if (this.getupAnimationBlendWeight > 0f)
			{
				return false;
			}
			if (!this.puppetMaster.isAlive)
			{
				return false;
			}
			foreach (Muscle muscle in this.puppetMaster.muscles)
			{
				if (!muscle.state.isDisconnected && muscle.state.pinWeightMlp < 1f)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000A37C File Offset: 0x0000857C
		protected override void OnReadBehaviour(float deltaTime)
		{
			if (!base.enabled)
			{
				return;
			}
			if (!this.puppetMaster.isFrozen && this.state == BehaviourPuppet.State.Unpinned && this.puppetMaster.isActive && !this.puppetMaster.isBlending && !this.puppetMaster.muscles[0].state.isDisconnected && this.puppetMaster.muscles[0].state.mappingWeightMlp >= 1f)
			{
				if ((this.puppetMaster.muscles[0].rigidbody.velocity - this.platformVelocity).sqrMagnitude < this.maxGetUpVelocity * this.maxGetUpVelocity)
				{
					Vector3 point = new Vector3(0f, -0.15f, 0f);
					this.MoveTarget(this.puppetMaster.muscles[0].rigidbody.position + this.puppetMaster.targetRoot.rotation * point);
					this.RotateTarget(Quaternion.Euler(0f, this.puppetMaster.targetRoot.eulerAngles.y, 0f));
				}
				else
				{
					this.MoveTarget(this.MainPlayerParent.transform.position);
				}
				this.getUpPosition = this.puppetMaster.targetRoot.position;
			}
			if ((this.state == BehaviourPuppet.State.GetUp && this.getUpTimer < this.minGetUpDuration * 0.1f) || this.getupAnimationBlendWeight > 0f)
			{
				Vector3 b = Vector3.Project(this.puppetMaster.targetRoot.position - this.getUpPosition, this.puppetMaster.targetRoot.up);
				this.getUpPosition += b;
				this.getUpPosition += this.platformVelocity * deltaTime;
				this.MoveTarget(this.getUpPosition);
			}
			if (this.getupAnimationBlendWeight > 0f)
			{
				this.getupAnimationBlendWeight = Mathf.MoveTowards(this.getupAnimationBlendWeight, 0f, deltaTime);
				if (this.getupAnimationBlendWeight < 0.01f)
				{
					this.getupAnimationBlendWeight = 0f;
				}
				this.puppetMaster.muscles[0].targetSampledPosition += this.platformVelocity * deltaTime;
				this.puppetMaster.FixTargetToSampledState(Interp.Float(this.getupAnimationBlendWeight, InterpolationMode.InOutCubic));
			}
			this.getUpTargetFixed = true;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000A608 File Offset: 0x00008808
		private void BlendMuscleMapping(int muscleIndex, ref bool to, float deltaTime)
		{
			if (this.puppetMaster.muscles[muscleIndex].state.pinWeightMlp < 1f)
			{
				to = true;
			}
			BehaviourPuppet.MuscleProps props = this.GetProps(this.puppetMaster.muscles[muscleIndex].props.group);
			float target = to ? ((this.state == BehaviourPuppet.State.Puppet) ? props.maxMappingWeight : 1f) : props.minMappingWeight;
			this.puppetMaster.muscles[muscleIndex].state.mappingWeightMlp = Mathf.MoveTowards(this.puppetMaster.muscles[muscleIndex].state.mappingWeightMlp, target, deltaTime * this.masterProps.mappingBlendSpeed);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000A6B7 File Offset: 0x000088B7
		public override void OnMuscleAdded(Muscle m)
		{
			base.OnMuscleAdded(m);
			this.SetColliders(m, this.state == BehaviourPuppet.State.Unpinned);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000A6D0 File Offset: 0x000088D0
		public override void OnMuscleRemoved(Muscle m)
		{
			base.OnMuscleRemoved(m);
			this.SetColliders(m, true);
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000A6E1 File Offset: 0x000088E1
		protected void MoveTarget(Vector3 position)
		{
			if (!this.canMoveTarget)
			{
				return;
			}
			position.y += 8E-05f;
			this.puppetMaster.targetRoot.position = position;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000A70D File Offset: 0x0000890D
		protected void RotateTarget(Quaternion rotation)
		{
			if (!this.canMoveTarget)
			{
				return;
			}
			this.puppetMaster.targetRoot.rotation = rotation;
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000A729 File Offset: 0x00008929
		protected override void GroundTarget(LayerMask layers)
		{
			if (this.canMoveTarget)
			{
				base.GroundTarget(layers);
			}
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000A73C File Offset: 0x0000893C
		private void OnDrawGizmosSelected()
		{
			for (int i = 0; i < this.groupOverrides.Length; i++)
			{
				this.groupOverrides[i].name = string.Empty;
				if (this.groupOverrides[i].groups.Length != 0)
				{
					for (int j = 0; j < this.groupOverrides[i].groups.Length; j++)
					{
						if (j > 0)
						{
							BehaviourPuppet.MusclePropsGroup[] array = this.groupOverrides;
							int num = i;
							array[num].name = array[num].name + ", ";
						}
						BehaviourPuppet.MusclePropsGroup[] array2 = this.groupOverrides;
						int num2 = i;
						array2[num2].name = array2[num2].name + this.groupOverrides[i].groups[j].ToString();
					}
				}
			}
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000A808 File Offset: 0x00008A08
		public void Boost(float immunity, float impulseMlp)
		{
			this.hasBoosted = true;
			for (int i = 0; i < this.puppetMaster.muscles.Length; i++)
			{
				this.Boost(i, immunity, impulseMlp);
			}
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000A83D File Offset: 0x00008A3D
		public void Boost(int muscleIndex, float immunity, float impulseMlp)
		{
			this.hasBoosted = true;
			this.BoostImmunity(muscleIndex, immunity);
			this.BoostImpulseMlp(muscleIndex, impulseMlp);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000A858 File Offset: 0x00008A58
		public void Boost(int muscleIndex, float immunity, float impulseMlp, float boostParents, float boostChildren)
		{
			this.hasBoosted = true;
			if (boostParents <= 0f && boostChildren <= 0f)
			{
				this.Boost(muscleIndex, immunity, impulseMlp);
				return;
			}
			for (int i = 0; i < this.puppetMaster.muscles.Length; i++)
			{
				float falloff = this.GetFalloff(i, muscleIndex, boostParents, boostChildren);
				this.Boost(i, immunity * falloff, impulseMlp * falloff);
			}
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0000A8BC File Offset: 0x00008ABC
		public void BoostImmunity(float immunity)
		{
			this.hasBoosted = true;
			if (immunity < 0f)
			{
				return;
			}
			for (int i = 0; i < this.puppetMaster.muscles.Length; i++)
			{
				this.BoostImmunity(i, immunity);
			}
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000A8FC File Offset: 0x00008AFC
		public void BoostImmunity(int muscleIndex, float immunity)
		{
			this.hasBoosted = true;
			this.puppetMaster.muscles[muscleIndex].state.immunity = Mathf.Clamp(immunity, this.puppetMaster.muscles[muscleIndex].state.immunity, 1f);
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0000A94C File Offset: 0x00008B4C
		public void BoostImmunity(int muscleIndex, float immunity, float boostParents, float boostChildren)
		{
			this.hasBoosted = true;
			for (int i = 0; i < this.puppetMaster.muscles.Length; i++)
			{
				float falloff = this.GetFalloff(i, muscleIndex, boostParents, boostChildren);
				this.BoostImmunity(i, immunity * falloff);
			}
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0000A990 File Offset: 0x00008B90
		public void BoostImpulseMlp(float impulseMlp)
		{
			this.hasBoosted = true;
			for (int i = 0; i < this.puppetMaster.muscles.Length; i++)
			{
				this.BoostImpulseMlp(i, impulseMlp);
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0000A9C4 File Offset: 0x00008BC4
		public void BoostImpulseMlp(int muscleIndex, float impulseMlp)
		{
			this.hasBoosted = true;
			this.puppetMaster.muscles[muscleIndex].state.impulseMlp = Mathf.Max(impulseMlp, this.puppetMaster.muscles[muscleIndex].state.impulseMlp);
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0000AA04 File Offset: 0x00008C04
		public void BoostImpulseMlp(int muscleIndex, float impulseMlp, float boostParents, float boostChildren)
		{
			this.hasBoosted = true;
			for (int i = 0; i < this.puppetMaster.muscles.Length; i++)
			{
				float falloff = this.GetFalloff(i, muscleIndex, boostParents, boostChildren);
				this.BoostImpulseMlp(i, impulseMlp * falloff);
			}
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00009B17 File Offset: 0x00007D17
		public void Unpin()
		{
			this.SetState(BehaviourPuppet.State.Unpinned);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0000AA48 File Offset: 0x00008C48
		protected override void OnMuscleHitBehaviour(MuscleHit hit)
		{
			if (this.masterProps.normalMode == BehaviourPuppet.NormalMode.Kinematic)
			{
				this.puppetMaster.mode = PuppetMaster.Mode.Active;
			}
			this.UnPin(hit.muscleIndex, hit.unPin);
			this.puppetMaster.muscles[hit.muscleIndex].SetKinematic(false);
			this.puppetMaster.muscles[hit.muscleIndex].rigidbody.AddForceAtPosition(hit.force, hit.position);
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0000AAC4 File Offset: 0x00008CC4
		protected override void OnMuscleCollisionBehaviour(MuscleCollision m)
		{
			if (this.OnCollision != null)
			{
				this.OnCollision(m);
			}
			if (!base.enabled)
			{
				return;
			}
			if (this.state == BehaviourPuppet.State.Unpinned)
			{
				return;
			}
			if (this.collisions > this.maxCollisions)
			{
				return;
			}
			if (!LayerMaskExtensions.Contains(this.collisionLayers, m.collision.collider.gameObject.layer))
			{
				return;
			}
			if (LayerMaskExtensions.Contains(this.groundLayers, m.collision.collider.gameObject.layer))
			{
				if (this.state == BehaviourPuppet.State.GetUp)
				{
					return;
				}
				if (this.puppetMaster.muscles[m.muscleIndex].props.group == Muscle.Group.Foot)
				{
					return;
				}
			}
			if (this.masterProps.normalMode == BehaviourPuppet.NormalMode.Kinematic && !this.puppetMaster.isActive && !this.masterProps.activateOnStaticCollisions && m.collision.gameObject.isStatic)
			{
				return;
			}
			if (this.puppetMaster.muscles[m.muscleIndex].rigidbody.isKinematic && m.collision.collider.attachedRigidbody != null && m.collision.collider.attachedRigidbody.isKinematic)
			{
				if (this.masterProps.normalMode == BehaviourPuppet.NormalMode.Kinematic && this.puppetMaster.mode == PuppetMaster.Mode.Kinematic)
				{
					this.puppetMaster.mode = PuppetMaster.Mode.Active;
					return;
				}
			}
			else
			{
				float num = this.collisionThreshold;
				float num2 = this.GetImpulse(m, ref num);
				float num3 = (Singleton<PuppetMasterSettings>.instance != null) ? (1f + (float)Singleton<PuppetMasterSettings>.instance.currentlyActivePuppets * Singleton<PuppetMasterSettings>.instance.activePuppetCollisionThresholdMlp) : 1f;
				float num4 = num * num3;
				if (num2 <= num4)
				{
					return;
				}
				this.collisions++;
				if (m.collision.collider.attachedRigidbody != null)
				{
					this.broadcaster = m.collision.collider.attachedRigidbody.GetComponent<MuscleCollisionBroadcaster>();
					if (this.broadcaster != null && this.broadcaster.muscleIndex < this.broadcaster.puppetMaster.muscles.Length)
					{
						num2 *= this.broadcaster.puppetMaster.muscles[this.broadcaster.muscleIndex].state.impulseMlp;
					}
				}
				if (this.OnCollisionImpulse != null)
				{
					this.OnCollisionImpulse(m, num2);
				}
				if (this.Activate(m.collision, num2))
				{
					this.puppetMaster.mode = PuppetMaster.Mode.Active;
				}
				this.UnPin(m.muscleIndex, num2);
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0000AD4C File Offset: 0x00008F4C
		private float GetImpulse(MuscleCollision m, ref float layerThreshold)
		{
			float num = m.collision.impulse.sqrMagnitude;
			num /= this.puppetMaster.muscles[m.muscleIndex].rigidbody.mass;
			num *= 0.3f;
			foreach (BehaviourPuppet.CollisionResistanceMultiplier collisionResistanceMultiplier in this.collisionResistanceMultipliers)
			{
				if (LayerMaskExtensions.Contains(collisionResistanceMultiplier.layers, m.collision.collider.gameObject.layer))
				{
					if (collisionResistanceMultiplier.multiplier <= 0f)
					{
						num = float.PositiveInfinity;
					}
					else
					{
						num /= collisionResistanceMultiplier.multiplier;
					}
					layerThreshold = collisionResistanceMultiplier.collisionThreshold;
					break;
				}
			}
			return num;
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0000AE04 File Offset: 0x00009004
		public void UnPin(int muscleIndex, float unpin)
		{
			if (muscleIndex >= this.puppetMaster.muscles.Length)
			{
				return;
			}
			BehaviourPuppet.MuscleProps props = this.GetProps(this.puppetMaster.muscles[muscleIndex].props.group);
			for (int i = 0; i < this.puppetMaster.muscles.Length; i++)
			{
				this.UnPinMuscle(i, unpin * this.GetFalloff(i, muscleIndex, props.unpinParents, props.unpinChildren, props.unpinGroup));
			}
			this.hasCollidedSinceGetUp = true;
			this.lastCollisionTime = Time.time;
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0000AE90 File Offset: 0x00009090
		private void UnPinMuscle(int muscleIndex, float unpin)
		{
			if (unpin <= 0f)
			{
				return;
			}
			if (this.puppetMaster.muscles[muscleIndex].state.immunity >= 1f)
			{
				return;
			}
			BehaviourPuppet.MuscleProps props = this.GetProps(this.puppetMaster.muscles[muscleIndex].props.group);
			float num = 1f;
			if (this.state == BehaviourPuppet.State.GetUp)
			{
				num = Mathf.Lerp(this.getUpCollisionResistanceMlp, 1f, this.puppetMaster.muscles[muscleIndex].state.pinWeightMlp);
			}
			float num2 = (this.collisionResistance.mode == Weight.Mode.Float) ? this.collisionResistance.floatValue : this.collisionResistance.GetValue(this.puppetMaster.muscles[muscleIndex].targetVelocity.magnitude);
			float num3 = unpin / (props.collisionResistance * num2 * num);
			num3 *= 1f - this.puppetMaster.muscles[muscleIndex].state.immunity;
			if (!this.puppetMaster.muscles[muscleIndex].state.isDisconnected)
			{
				this.puppetMaster.muscles[muscleIndex].state.pinWeightMlp = Mathf.Max(this.puppetMaster.muscles[muscleIndex].state.pinWeightMlp - num3, props.minPinWeight);
			}
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0000AFDC File Offset: 0x000091DC
		private bool Activate(Collision collision, float impulse)
		{
			return this.masterProps.normalMode == BehaviourPuppet.NormalMode.Kinematic && this.puppetMaster.mode == PuppetMaster.Mode.Kinematic && impulse >= this.masterProps.activateOnImpulse && (!collision.gameObject.isStatic || this.masterProps.activateOnStaticCollisions);
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000B034 File Offset: 0x00009234
		public bool IsProne()
		{
			if (this.isQuadruped)
			{
				return Vector3.Dot(this.puppetMaster.muscles[0].transform.rotation * this.hipsUp, this.puppetMaster.targetRoot.right) > 0f;
			}
			return Vector3.Dot(this.puppetMaster.muscles[0].transform.rotation * this.hipsForward, this.puppetMaster.targetRoot.up) < 0f;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0000B0C8 File Offset: 0x000092C8
		private float GetFalloff(int i, int muscleIndex, float falloffParents, float falloffChildren)
		{
			if (i == muscleIndex)
			{
				return 1f;
			}
			bool flag = this.puppetMaster.muscles[muscleIndex].childFlags[i];
			int num = this.puppetMaster.muscles[muscleIndex].kinshipDegrees[i];
			return Mathf.Pow(flag ? falloffChildren : falloffParents, (float)num);
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0000B118 File Offset: 0x00009318
		private float GetFalloff(int i, int muscleIndex, float falloffParents, float falloffChildren, float falloffGroup)
		{
			float num = this.GetFalloff(i, muscleIndex, falloffParents, falloffChildren);
			if (falloffGroup > 0f && i != muscleIndex && this.InGroup(this.puppetMaster.muscles[i].props.group, this.puppetMaster.muscles[muscleIndex].props.group))
			{
				num = Mathf.Max(num, falloffGroup);
			}
			return num;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0000B180 File Offset: 0x00009380
		private bool InGroup(Muscle.Group group1, Muscle.Group group2)
		{
			if (group1 == group2)
			{
				return true;
			}
			foreach (BehaviourPuppet.MusclePropsGroup musclePropsGroup in this.groupOverrides)
			{
				Muscle.Group[] groups = musclePropsGroup.groups;
				for (int j = 0; j < groups.Length; j++)
				{
					if (groups[j] == group1)
					{
						Muscle.Group[] groups2 = musclePropsGroup.groups;
						for (int k = 0; k < groups2.Length; k++)
						{
							if (groups2[k] == group2)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000B1F8 File Offset: 0x000093F8
		private BehaviourPuppet.MuscleProps GetProps(Muscle.Group group)
		{
			foreach (BehaviourPuppet.MusclePropsGroup musclePropsGroup in this.groupOverrides)
			{
				Muscle.Group[] groups = musclePropsGroup.groups;
				for (int j = 0; j < groups.Length; j++)
				{
					if (groups[j] == group)
					{
						return musclePropsGroup.props;
					}
				}
			}
			return this.defaults;
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x0000B24F File Offset: 0x0000944F
		// (set) Token: 0x060001EA RID: 490 RVA: 0x0000B257 File Offset: 0x00009457
		public Vector3 getUpPosition { get; set; }

		// Token: 0x060001EB RID: 491 RVA: 0x0000B260 File Offset: 0x00009460
		public void SetState(BehaviourPuppet.State newState)
		{
			if (this.state == newState)
			{
				return;
			}
			switch (newState)
			{
			case BehaviourPuppet.State.Puppet:
				this.puppetMaster.SampleTargetMappedState();
				this.unpinnedTimer = 0f;
				this.getUpTimer = 0f;
				this.hasCollidedSinceGetUp = false;
				if (this.state == BehaviourPuppet.State.Unpinned)
				{
					foreach (Muscle muscle in this.puppetMaster.muscles)
					{
						if (!muscle.state.isDisconnected)
						{
							muscle.state.pinWeightMlp = 1f;
							muscle.state.muscleWeightMlp = 1f;
							muscle.state.muscleDamperAdd = 0f;
							muscle.positionOffset = Vector3.zero;
							this.SetColliders(muscle, false);
						}
					}
				}
				this.state = BehaviourPuppet.State.Puppet;
				if (this.eventsEnabled)
				{
					this.onRegainBalance.Trigger(this.puppetMaster, true);
					if (this.onRegainBalance.switchBehaviour)
					{
						return;
					}
				}
				break;
			case BehaviourPuppet.State.Unpinned:
			{
				this.unpinnedTimer = 0f;
				this.getUpTimer = 0f;
				this.getupAnimationBlendWeight = 0f;
				foreach (Muscle muscle2 in this.puppetMaster.muscles)
				{
					if (this.hasBoosted)
					{
						muscle2.state.immunity = 0f;
					}
					if (this.maxRigidbodyVelocity != float.PositiveInfinity)
					{
						muscle2.rigidbody.velocity = Vector3.ClampMagnitude(muscle2.rigidbody.velocity, this.maxRigidbodyVelocity);
						muscle2.mappedVelocity = Vector3.ClampMagnitude(muscle2.mappedVelocity, this.maxRigidbodyVelocity);
					}
					this.SetColliders(muscle2, true);
				}
				if (this.dropProps)
				{
					this.dropPropFlag = true;
				}
				foreach (Muscle muscle3 in this.puppetMaster.muscles)
				{
					if (!muscle3.state.isDisconnected)
					{
						muscle3.state.muscleWeightMlp = (this.puppetMaster.isAlive ? this.unpinnedMuscleWeightMlp : this.puppetMaster.stateSettings.deadMuscleWeight);
					}
				}
				this.onLoseBalance.Trigger(this.puppetMaster, this.puppetMaster.isAlive);
				if (this.onLoseBalance.switchBehaviour)
				{
					this.state = BehaviourPuppet.State.Unpinned;
					return;
				}
				if (this.state == BehaviourPuppet.State.Puppet)
				{
					this.onLoseBalanceFromPuppet.Trigger(this.puppetMaster, this.puppetMaster.isAlive);
					if (this.onLoseBalanceFromPuppet.switchBehaviour)
					{
						this.state = BehaviourPuppet.State.Unpinned;
						return;
					}
				}
				else
				{
					this.onLoseBalanceFromGetUp.Trigger(this.puppetMaster, this.puppetMaster.isAlive);
					if (this.onLoseBalanceFromGetUp.switchBehaviour)
					{
						this.state = BehaviourPuppet.State.Unpinned;
						return;
					}
				}
				Muscle[] muscles = this.puppetMaster.muscles;
				for (int i = 0; i < muscles.Length; i++)
				{
					muscles[i].state.pinWeightMlp = 0f;
				}
				break;
			}
			case BehaviourPuppet.State.GetUp:
			{
				this.unpinnedTimer = 0f;
				this.getUpTimer = 0f;
				this.hasCollidedSinceGetUp = false;
				bool flag = this.IsProne();
				this.state = BehaviourPuppet.State.GetUp;
				if (flag)
				{
					this.onGetUpProne.Trigger(this.puppetMaster, true);
					if (this.onGetUpProne.switchBehaviour)
					{
						return;
					}
				}
				else
				{
					this.onGetUpSupine.Trigger(this.puppetMaster, true);
					if (this.onGetUpSupine.switchBehaviour)
					{
						return;
					}
				}
				foreach (Muscle muscle4 in this.puppetMaster.muscles)
				{
					if (!muscle4.state.isDisconnected)
					{
						this.SetColliders(muscle4, false);
					}
				}
				if (this.isQuadruped)
				{
					Vector3 forward = this.puppetMaster.muscles[0].rigidbody.rotation * this.hipsForward;
					Vector3 up = this.puppetMaster.targetRoot.up;
					Vector3.OrthoNormalize(ref up, ref forward);
					this.RotateTarget(Quaternion.LookRotation(forward, this.puppetMaster.targetRoot.up));
				}
				else
				{
					Vector3 vector = this.puppetMaster.muscles[0].rigidbody.rotation * this.hipsUp;
					Vector3 up2 = this.puppetMaster.targetRoot.up;
					Vector3.OrthoNormalize(ref up2, ref vector);
					this.RotateTarget(Quaternion.LookRotation(flag ? vector : (-vector), this.puppetMaster.targetRoot.up));
				}
				this.puppetMaster.SampleTargetMappedState();
				if (!flag)
				{
					Vector3 vector2 = this.getUpOffsetSupine;
				}
				else
				{
					Vector3 vector3 = this.getUpOffsetProne;
				}
				this.GroundTarget(this.groundLayers);
				this.getUpPosition = this.puppetMaster.targetRoot.position;
				this.getupAnimationBlendWeight = 1f;
				this.getUpTargetFixed = false;
				break;
			}
			}
			this.state = newState;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0000B714 File Offset: 0x00009914
		public void SetColliders(bool unpinned)
		{
			foreach (Muscle m in this.puppetMaster.muscles)
			{
				this.SetColliders(m, unpinned);
			}
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0000B748 File Offset: 0x00009948
		public void SetColliders(Muscle m, bool unpinned)
		{
			BehaviourPuppet.MuscleProps props = this.GetProps(m.props.group);
			if (unpinned)
			{
				foreach (Collider collider in m.colliders)
				{
					collider.material = ((props.unpinnedMaterial != null) ? props.unpinnedMaterial : this.defaults.unpinnedMaterial);
					if (props.disableColliders)
					{
						collider.enabled = true;
					}
				}
				return;
			}
			foreach (Collider collider2 in m.colliders)
			{
				collider2.material = ((props.puppetMaterial != null) ? props.puppetMaterial : this.defaults.puppetMaterial);
				if (props.disableColliders)
				{
					Vector3 inertiaTensor = m.rigidbody.inertiaTensor;
					collider2.enabled = false;
					m.rigidbody.inertiaTensor = inertiaTensor;
				}
			}
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0000B826 File Offset: 0x00009A26
		public override void OnMuscleDisconnected(Muscle m)
		{
			base.OnMuscleDisconnected(m);
			this.SetColliders(m, true);
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0000B838 File Offset: 0x00009A38
		public override void OnMuscleReconnected(Muscle m)
		{
			base.OnMuscleReconnected(m);
			if (m == this.puppetMaster.muscles[0])
			{
				this.SetState(BehaviourPuppet.State.Puppet);
			}
			float num = (this.state == BehaviourPuppet.State.Puppet) ? 1f : 0f;
			m.state.pinWeightMlp = num;
			m.state.muscleWeightMlp = num;
			m.state.muscleDamperMlp = num;
			m.state.maxForceMlp = 1f;
			m.state.mappingWeightMlp = 1f;
			this.SetColliders(m, this.state == BehaviourPuppet.State.Unpinned);
		}

		// Token: 0x04000166 RID: 358
		public GameObject MainPlayerParent;

		// Token: 0x04000167 RID: 359
		private const string typeSpring = "BehaviourPuppet";

		// Token: 0x04000168 RID: 360
		[LargeHeader("Collision And Recovery")]
		public BehaviourPuppet.MasterProps masterProps = new BehaviourPuppet.MasterProps();

		// Token: 0x04000169 RID: 361
		[Tooltip("Will ground the target to those layers when getting up.")]
		public LayerMask groundLayers;

		// Token: 0x0400016A RID: 362
		[Tooltip("Will unpin the muscles that collide with those layers.")]
		public LayerMask collisionLayers;

		// Token: 0x0400016B RID: 363
		[Tooltip("The collision impulse sqrMagnitude threshold under which collisions will be ignored.")]
		public float collisionThreshold;

		// Token: 0x0400016C RID: 364
		public Weight collisionResistance = new Weight(3f, "Smaller value means more unpinning from collisions so the characters get knocked out more easily. If using a curve, the value will be evaluated by each muscle's target velocity magnitude. This can be used to make collision resistance higher while the character moves or animates faster.");

		// Token: 0x0400016D RID: 365
		[Tooltip("Multiplies collision resistance for the specified layers.")]
		public BehaviourPuppet.CollisionResistanceMultiplier[] collisionResistanceMultipliers;

		// Token: 0x0400016E RID: 366
		[Tooltip("An optimisation. Will only process up to this number of collisions per physics step.")]
		[Range(1f, 30f)]
		public int maxCollisions = 30;

		// Token: 0x0400016F RID: 367
		[Tooltip("How fast will the muscles of this group regain their pin weight?")]
		[Range(0.001f, 10f)]
		public float regainPinSpeed = 1f;

		// Token: 0x04000170 RID: 368
		[Tooltip("'Boosting' is a term used for making muscles temporarily immune to collisions and/or deal more damage to the muscles of other characters. That is done by increasing Muscle.State.immunity and Muscle.State.impulseMlp. For example when you set muscle.state.immunity to 1, boostFalloff will determine how fast this value will fall back to normal (0). Use BehaviourPuppet.BoostImmunity() and BehaviourPuppet.BoostImpulseMlp() for boosting from your own scripts. It is helpful for making the puppet stronger and deliever more punch while playing a melee hitting/kicking animation.")]
		public float boostFalloff = 1f;

		// Token: 0x04000171 RID: 369
		[LargeHeader("Muscle Group Properties")]
		[Tooltip("The default muscle properties. If there are no 'Group Overrides', this will be used for all muscles.")]
		public BehaviourPuppet.MuscleProps defaults;

		// Token: 0x04000172 RID: 370
		[Tooltip("Overriding default muscle properties for some muscle groups (for example making the feet stiffer or the hands looser).")]
		public BehaviourPuppet.MusclePropsGroup[] groupOverrides;

		// Token: 0x04000173 RID: 371
		[LargeHeader("Losing Balance")]
		[Tooltip("If the distance from the muscle to its target is larger than this value, the character will be knocked out.")]
		[Range(0.001f, 10f)]
		public float knockOutDistance = 1f;

		// Token: 0x04000174 RID: 372
		[Tooltip("Smaller value makes the muscles weaker when the puppet is knocked out.")]
		[Range(0f, 1f)]
		public float unpinnedMuscleWeightMlp = 0.3f;

		// Token: 0x04000175 RID: 373
		[Tooltip("Most character controllers apply supernatural accelerations to characters when changing running direction or jumping. It will require major pinning forces to be applied on the ragdoll to keep up with that acceleration. When a puppet collides with something at that point and is unpinned, those forces might shoot the puppet off to space. This variable limits the velocity of the ragdoll's Rigidbodies when the puppet is unpinned.")]
		public float maxRigidbodyVelocity = 10f;

		// Token: 0x04000176 RID: 374
		[Tooltip("If a muscle has drifted farther than 'Knock Out Distance', will only unpin the puppet if its pin weight is less than this value. Lowering this value will make puppets less likely to lose balance on minor collisions.")]
		[Range(0f, 1f)]
		public float pinWeightThreshold = 1f;

		// Token: 0x04000177 RID: 375
		[Tooltip("If false, will not unbalance the puppet by muscles that have their pin weight set to 0 in PuppetMaster muscle settings.")]
		public bool unpinnedMuscleKnockout = true;

		// Token: 0x04000178 RID: 376
		[Tooltip("If true, all muscles of the 'Prop' group will be detached from the puppet when it loses balance.")]
		public bool dropProps;

		// Token: 0x04000179 RID: 377
		[LargeHeader("Getting Up")]
		[Tooltip("If true, GetUp state will be triggerred automatically after 'Get Up Delay' and when the velocity of the hip muscle is less than 'Max Get Up Velocity'.")]
		public bool canGetUp = true;

		// Token: 0x0400017A RID: 378
		[Tooltip("Minimum delay for getting up after loosing balance. After that time has passed, will wait for the velocity of the hip muscle to come down below 'Max Get Up Velocity' and then switch to the GetUp state.")]
		public float getUpDelay = 5f;

		// Token: 0x0400017B RID: 379
		[Tooltip("The duration of blending the animation target from the ragdoll pose to the getting up animation once the GetUp state has been triggered.")]
		public float blendToAnimationTime = 0.2f;

		// Token: 0x0400017C RID: 380
		[Tooltip("Will not get up before the velocity of the hip muscle has come down to this value.")]
		public float maxGetUpVelocity = 0.3f;

		// Token: 0x0400017D RID: 381
		[Tooltip("The duration of the 'GetUp' state after which it switches to the 'Puppetä state.")]
		public float minGetUpDuration = 1f;

		// Token: 0x0400017E RID: 382
		[Tooltip("Collision resistance multiplier while in the GetUp state. Increasing this will prevent the character from loosing balance again immediatelly after going from Unpinned to GetUp state.")]
		public float getUpCollisionResistanceMlp = 2f;

		// Token: 0x0400017F RID: 383
		[Tooltip("Regain pin weight speed multiplier while in the GetUp state. Increasing this will prevent the character from loosing balance again immediatelly after going from Unpinned to GetUp state.")]
		public float getUpRegainPinSpeedMlp = 2f;

		// Token: 0x04000180 RID: 384
		[Tooltip("Knock out distance multiplier while in the GetUp state. Increasing this will prevent the character from loosing balance again immediatelly after going from Unpinned to GetUp state.")]
		public float getUpKnockOutDistanceMlp = 10f;

		// Token: 0x04000181 RID: 385
		[Tooltip("Offset of the target character (in character rotation space) from the hip bone when initiating getting up animation from a prone pose. Tweak this value if your character slides a bit when starting to get up.")]
		public Vector3 getUpOffsetProne;

		// Token: 0x04000182 RID: 386
		[Tooltip("Offset of the target character (in character rotation space) from the hip bone when initiating getting up animation from a supine pose. Tweak this value if your character slides a bit when starting to get up.")]
		public Vector3 getUpOffsetSupine;

		// Token: 0x04000183 RID: 387
		[Tooltip("If enabled, onGetUpProne will be called when laying on the right side and onGetUpSupine when on the left side.")]
		public bool isQuadruped;

		// Token: 0x04000184 RID: 388
		[LargeHeader("Events")]
		[Tooltip("Called when the character starts getting up from a prone pose (facing down) or from the right side when 'Is Quadruped' is enabled.")]
		public BehaviourBase.PuppetEvent onGetUpProne;

		// Token: 0x04000185 RID: 389
		[Tooltip("Called when the character starts getting up from a supine pose (facing up) or from the left side when 'Is Quadruped' is enabled.")]
		public BehaviourBase.PuppetEvent onGetUpSupine;

		// Token: 0x04000186 RID: 390
		[Tooltip("Called when the character is knocked out (loses balance). Doesn't matter from which state.")]
		public BehaviourBase.PuppetEvent onLoseBalance;

		// Token: 0x04000187 RID: 391
		[Tooltip("Called when the character is knocked out (loses balance) only from the normal Puppet state.")]
		public BehaviourBase.PuppetEvent onLoseBalanceFromPuppet;

		// Token: 0x04000188 RID: 392
		[Tooltip("Called when the character is knocked out (loses balance) only from the GetUp state.")]
		public BehaviourBase.PuppetEvent onLoseBalanceFromGetUp;

		// Token: 0x04000189 RID: 393
		[Tooltip("Called when the character has fully recovered and switched to the Puppet state.")]
		public BehaviourBase.PuppetEvent onRegainBalance;

		// Token: 0x0400018A RID: 394
		public BehaviourBase.CollisionDelegate OnCollision;

		// Token: 0x0400018B RID: 395
		public BehaviourPuppet.CollisionImpulseDelegate OnCollisionImpulse;

		// Token: 0x0400018E RID: 398
		[HideInInspector]
		public bool canMoveTarget = true;

		// Token: 0x0400018F RID: 399
		private float unpinnedTimer;

		// Token: 0x04000190 RID: 400
		private float getUpTimer;

		// Token: 0x04000191 RID: 401
		private Vector3 hipsForward;

		// Token: 0x04000192 RID: 402
		private Vector3 hipsUp;

		// Token: 0x04000193 RID: 403
		private float getupAnimationBlendWeight;

		// Token: 0x04000194 RID: 404
		private bool getUpTargetFixed;

		// Token: 0x04000195 RID: 405
		private BehaviourPuppet.NormalMode lastNormalMode;

		// Token: 0x04000196 RID: 406
		private int collisions;

		// Token: 0x04000197 RID: 407
		private bool eventsEnabled;

		// Token: 0x04000198 RID: 408
		private float lastKnockOutDistance;

		// Token: 0x04000199 RID: 409
		private float knockOutDistanceSqr;

		// Token: 0x0400019A RID: 410
		private bool getupDisabled;

		// Token: 0x0400019B RID: 411
		private bool hasCollidedSinceGetUp;

		// Token: 0x0400019C RID: 412
		private float lastCollisionTime;

		// Token: 0x0400019D RID: 413
		private bool hasBoosted;

		// Token: 0x0400019E RID: 414
		private MuscleCollisionBroadcaster broadcaster;

		// Token: 0x040001A0 RID: 416
		private bool dropPropFlag;

		// Token: 0x02000043 RID: 67
		[Serializable]
		public enum State
		{
			// Token: 0x040001A2 RID: 418
			Puppet,
			// Token: 0x040001A3 RID: 419
			Unpinned,
			// Token: 0x040001A4 RID: 420
			GetUp
		}

		// Token: 0x02000044 RID: 68
		[Serializable]
		public enum NormalMode
		{
			// Token: 0x040001A6 RID: 422
			Active,
			// Token: 0x040001A7 RID: 423
			Unmapped,
			// Token: 0x040001A8 RID: 424
			Kinematic
		}

		// Token: 0x02000045 RID: 69
		[Serializable]
		public class MasterProps
		{
			// Token: 0x040001A9 RID: 425
			public BehaviourPuppet.NormalMode normalMode;

			// Token: 0x040001AA RID: 426
			public float mappingBlendSpeed = 10f;

			// Token: 0x040001AB RID: 427
			public bool activateOnStaticCollisions;

			// Token: 0x040001AC RID: 428
			public float activateOnImpulse;
		}

		// Token: 0x02000046 RID: 70
		[Serializable]
		public struct MuscleProps
		{
			// Token: 0x040001AD RID: 429
			[Tooltip("How much will collisions with muscles of this group unpin parent muscles?")]
			[Range(0f, 1f)]
			public float unpinParents;

			// Token: 0x040001AE RID: 430
			[Tooltip("How much will collisions with muscles of this group unpin child muscles?")]
			[Range(0f, 1f)]
			public float unpinChildren;

			// Token: 0x040001AF RID: 431
			[Tooltip("How much will collisions with muscles of this group unpin muscles of the same group?")]
			[Range(0f, 1f)]
			public float unpinGroup;

			// Token: 0x040001B0 RID: 432
			[Tooltip("If 1, muscles of this group will always be mapped to the ragdoll.")]
			[Range(0f, 1f)]
			public float minMappingWeight;

			// Token: 0x040001B1 RID: 433
			[Tooltip("If 0, muscles of this group will not be mapped to the ragdoll pose even if they are unpinned.")]
			[Range(0f, 1f)]
			public float maxMappingWeight;

			// Token: 0x040001B2 RID: 434
			[Tooltip("Defines minimum pin weight for the muscles. Muscle pin weight can’t be reduced beyond this value when damage occurs from collisions.")]
			[Range(0f, 1f)]
			public float minPinWeight;

			// Token: 0x040001B3 RID: 435
			[Tooltip("If true, muscles of this group will have their colliders disabled while in puppet state (not unbalanced nor getting up).")]
			public bool disableColliders;

			// Token: 0x040001B4 RID: 436
			[Tooltip("How fast will muscles of this group regain their pin weight (multiplier)?")]
			public float regainPinSpeed;

			// Token: 0x040001B5 RID: 437
			[Tooltip("Smaller value means more unpinning from collisions (multiplier).")]
			public float collisionResistance;

			// Token: 0x040001B6 RID: 438
			[Tooltip("If the distance from the muscle to its target is larger than this value, the character will be knocked out.")]
			public float knockOutDistance;

			// Token: 0x040001B7 RID: 439
			[Tooltip("The PhysicsMaterial applied to the muscles while the character is in Puppet or GetUp state. Using a lower friction material reduces the risk of muscles getting stuck and pulled out of their joints.")]
			public PhysicMaterial puppetMaterial;

			// Token: 0x040001B8 RID: 440
			[Tooltip("The PhysicsMaterial applied to the muscles while the character is in Unpinned state.")]
			public PhysicMaterial unpinnedMaterial;
		}

		// Token: 0x02000047 RID: 71
		[Serializable]
		public struct MusclePropsGroup
		{
			// Token: 0x040001B9 RID: 441
			[HideInInspector]
			public string name;

			// Token: 0x040001BA RID: 442
			[Tooltip("Muscle groups to which those properties apply.")]
			public Muscle.Group[] groups;

			// Token: 0x040001BB RID: 443
			[Tooltip("The muscle properties for those muscle groups.")]
			public BehaviourPuppet.MuscleProps props;
		}

		// Token: 0x02000048 RID: 72
		[Serializable]
		public struct CollisionResistanceMultiplier
		{
			// Token: 0x040001BC RID: 444
			public LayerMask layers;

			// Token: 0x040001BD RID: 445
			[Tooltip("Multiplier for the 'Collision Resistance' for these layers.")]
			public float multiplier;

			// Token: 0x040001BE RID: 446
			[Tooltip("Overrides 'Collision Threshold' for these layers.")]
			public float collisionThreshold;
		}

		// Token: 0x02000049 RID: 73
		// (Invoke) Token: 0x060001F3 RID: 499
		public delegate void CollisionImpulseDelegate(MuscleCollision m, float impulse);
	}
}
