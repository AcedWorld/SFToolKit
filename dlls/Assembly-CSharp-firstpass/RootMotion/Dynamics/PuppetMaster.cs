using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000063 RID: 99
	[HelpURL("https://www.youtube.com/watch?v=LYusqeqHAUc")]
	[AddComponentMenu("Scripts/RootMotion.Dynamics/PuppetMaster/Puppet Master")]
	public class PuppetMaster : MonoBehaviour
	{
		// Token: 0x060002E3 RID: 739 RVA: 0x0001011E File Offset: 0x0000E31E
		[ContextMenu("User Manual (Setup)")]
		private void OpenUserManualSetup()
		{
			Application.OpenURL("http://root-motion.com/puppetmasterdox/html/page4.html");
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0001012A File Offset: 0x0000E32A
		[ContextMenu("User Manual (Component)")]
		private void OpenUserManualComponent()
		{
			Application.OpenURL("http://root-motion.com/puppetmasterdox/html/page5.html");
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00010136 File Offset: 0x0000E336
		[ContextMenu("User Manual (Performance)")]
		private void OpenUserManualPerformance()
		{
			Application.OpenURL("http://root-motion.com/puppetmasterdox/html/page8.html");
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00010142 File Offset: 0x0000E342
		[ContextMenu("Scrpt Reference")]
		private void OpenScriptReference()
		{
			Application.OpenURL("http://root-motion.com/puppetmasterdox/html/class_root_motion_1_1_dynamics_1_1_puppet_master.html");
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0001014E File Offset: 0x0000E34E
		[ContextMenu("TUTORIAL VIDEO (SETUP)")]
		private void OpenSetupTutorial()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=mIN9bxJgfOU&index=2&list=PLVxSIA1OaTOuE2SB9NUbckQ9r2hTg4mvL");
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0001015A File Offset: 0x0000E35A
		[ContextMenu("TUTORIAL VIDEO (COMPONENT)")]
		private void OpenComponentTutorial()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=LYusqeqHAUc");
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00010166 File Offset: 0x0000E366
		private void ResetStateSettings()
		{
			this.stateSettings = PuppetMaster.StateSettings.Default;
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00010174 File Offset: 0x0000E374
		// (set) Token: 0x060002EB RID: 747 RVA: 0x000101DD File Offset: 0x0000E3DD
		public Animator targetAnimator
		{
			get
			{
				if (this._targetAnimator == null)
				{
					this._targetAnimator = this.targetRoot.GetComponentInChildren<Animator>();
				}
				if (this._targetAnimator == null && this.targetRoot.parent != null)
				{
					this._targetAnimator = this.targetRoot.parent.GetComponentInChildren<Animator>();
				}
				return this._targetAnimator;
			}
			set
			{
				this._targetAnimator = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060002EC RID: 748 RVA: 0x000101E6 File Offset: 0x0000E3E6
		// (set) Token: 0x060002ED RID: 749 RVA: 0x000101EE File Offset: 0x0000E3EE
		public Animation targetAnimation { get; private set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060002EE RID: 750 RVA: 0x000101F7 File Offset: 0x0000E3F7
		public bool isActive
		{
			get
			{
				return base.gameObject.activeInHierarchy && this.initiated && (this.activeMode == PuppetMaster.Mode.Active || this.isBlending);
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060002EF RID: 751 RVA: 0x00010220 File Offset: 0x0000E420
		// (set) Token: 0x060002F0 RID: 752 RVA: 0x00010228 File Offset: 0x0000E428
		public bool initiated { get; private set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x00010231 File Offset: 0x0000E431
		public PuppetMaster.UpdateMode updateMode
		{
			get
			{
				if (this.targetUpdateMode != AnimatorUpdateMode.AnimatePhysics)
				{
					return PuppetMaster.UpdateMode.Normal;
				}
				if (!this.isLegacy)
				{
					return PuppetMaster.UpdateMode.FixedUpdate;
				}
				return PuppetMaster.UpdateMode.AnimatePhysics;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x00010249 File Offset: 0x0000E449
		public bool controlsAnimator
		{
			get
			{
				return base.isActiveAndEnabled && this.isActive && this.initiated && this.updateMode == PuppetMaster.UpdateMode.FixedUpdate;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x0001026E File Offset: 0x0000E46E
		public bool isBlending
		{
			get
			{
				return this.isSwitchingMode || this.isSwitchingState;
			}
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x00010280 File Offset: 0x0000E480
		public void thumpRebuild()
		{
			Muscle[] array = this.defaultMuscles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RebuildMT();
			}
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x000102AA File Offset: 0x0000E4AA
		public void DisableKill()
		{
			this.isKilling = false;
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x000102B3 File Offset: 0x0000E4B3
		public void Teleport(Vector3 position, Quaternion rotation, bool moveToTarget)
		{
			this.teleport = true;
			this.teleportPosition = position;
			this.teleportRotation = rotation;
			this.teleportMoveToTarget = moveToTarget;
			if (this.activeMode == PuppetMaster.Mode.Disabled)
			{
				this.Read();
			}
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x000102E0 File Offset: 0x0000E4E0
		public void SetInternalCollisionsManual(bool collide, bool useInternalCollisionIgnores)
		{
			for (int i = 0; i < this.muscles.Length; i++)
			{
				for (int j = i; j < this.muscles.Length; j++)
				{
					if (i != j)
					{
						if (collide)
						{
							this.muscles[i].ResetInternalCollisions(this.muscles[j], useInternalCollisionIgnores);
						}
						else
						{
							this.muscles[i].IgnoreInternalCollisions(this.muscles[j]);
						}
					}
				}
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00010348 File Offset: 0x0000E548
		public void SetAngularLimitsManual(bool limited)
		{
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (!this.muscles[i].state.isDisconnected)
				{
					this.muscles[i].IgnoreAngularLimits(!limited);
				}
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x0001038D File Offset: 0x0000E58D
		private bool autoSimulate
		{
			get
			{
				return Physics.autoSimulation;
			}
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00010394 File Offset: 0x0000E594
		private void OnDisable()
		{
			if (!base.gameObject.activeInHierarchy && this.initiated && Application.isPlaying)
			{
				Muscle[] array = this.muscles;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Reset();
				}
			}
			this.isSwitchingMode = false;
			this.activeState = this.state;
			this.isKilling = false;
			this.freezeFlag = false;
			this.hasBeenDisabled = true;
		}

		// Token: 0x060002FB RID: 763 RVA: 0x00010404 File Offset: 0x0000E604
		private void OnEnable()
		{
			if (base.gameObject.activeInHierarchy && this.initiated && this.hasBeenDisabled && Application.isPlaying)
			{
				this.isSwitchingMode = false;
				this.activeMode = this.mode;
				this.lastMode = this.mode;
				this.mappingBlend = ((this.mode == PuppetMaster.Mode.Active) ? 1f : 0f);
				this.activeState = this.state;
				this.lastState = this.state;
				this.isKilling = false;
				this.freezeFlag = false;
				this.SetAnimationEnabled(this.state == PuppetMaster.State.Alive);
				if (this.state == PuppetMaster.State.Alive && this.targetAnimator != null && this.targetAnimator.gameObject.activeInHierarchy)
				{
					this.targetAnimator.Update(0.001f);
				}
				foreach (Muscle muscle in this.muscles)
				{
					muscle.state.pinWeightMlp = ((this.state == PuppetMaster.State.Alive) ? 1f : 0f);
					muscle.state.muscleWeightMlp = ((this.state == PuppetMaster.State.Alive) ? 1f : this.stateSettings.deadMuscleWeight);
					muscle.state.muscleDamperAdd = 0f;
				}
				BehaviourBase[] array2;
				if (this.state != PuppetMaster.State.Frozen && this.mode != PuppetMaster.Mode.Disabled)
				{
					this.ActivateRagdoll(this.mode == PuppetMaster.Mode.Kinematic);
					array2 = this.behaviours;
					for (int i = 0; i < array2.Length; i++)
					{
						array2[i].gameObject.SetActive(true);
					}
				}
				else
				{
					Muscle[] array = this.muscles;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].joint.gameObject.SetActive(false);
					}
					if (this.state == PuppetMaster.State.Frozen)
					{
						foreach (BehaviourBase behaviourBase in this.behaviours)
						{
							if (behaviourBase.gameObject.activeSelf)
							{
								behaviourBase.deactivated = true;
								behaviourBase.gameObject.SetActive(false);
							}
						}
						if (this.stateSettings.freezePermanently)
						{
							if (this.behaviours.Length != 0 && this.behaviours[0] != null)
							{
								Object.Destroy(this.behaviours[0].transform.parent.gameObject);
							}
							Object.Destroy(base.gameObject);
							return;
						}
					}
				}
				array2 = this.behaviours;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].OnReactivate();
				}
			}
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00010673 File Offset: 0x0000E873
		private void Awake()
		{
			if (this.muscles.Length == 0)
			{
				return;
			}
			this.Initiate();
			if (!this.initiated)
			{
				this.awakeFailed = true;
			}
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00010694 File Offset: 0x0000E894
		public void Start()
		{
			if (!this.initiated && !this.awakeFailed)
			{
				this.Initiate();
			}
			if (!this.initiated)
			{
				return;
			}
			SolverManager[] componentsInChildren = this.targetRoot.GetComponentsInChildren<SolverManager>();
			this.solvers.AddRange(componentsInChildren);
		}

		// Token: 0x060002FE RID: 766 RVA: 0x000106D8 File Offset: 0x0000E8D8
		public Transform FindTargetRootRecursive(Transform t)
		{
			if (t.parent == null)
			{
				return null;
			}
			using (IEnumerator enumerator = t.parent.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if ((Transform)enumerator.Current == base.transform)
					{
						return t;
					}
				}
			}
			return this.FindTargetRootRecursive(t.parent);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00010758 File Offset: 0x0000E958
		private void Initiate()
		{
			this.initiated = false;
			if (this.muscles.Length != 0 && this.muscles[0].target != null && this.targetRoot == null)
			{
				this.targetRoot = this.FindTargetRootRecursive(this.muscles[0].target);
			}
			if (this.targetRoot != null && this.targetAnimator == null)
			{
				this.targetAnimator = this.targetRoot.GetComponentInChildren<Animator>();
				if (this.targetAnimator == null)
				{
					this.targetAnimation = this.targetRoot.GetComponentInChildren<Animation>();
				}
			}
			if (!this.IsValid(true))
			{
				return;
			}
			if (this.humanoidConfig != null && this.targetAnimator != null && this.targetAnimator.isHuman)
			{
				this.humanoidConfig.ApplyTo(this);
			}
			this.isLegacy = (this.targetAnimator == null && this.targetAnimation != null);
			this.behaviours = base.transform.GetComponentsInChildren<BehaviourBase>();
			if (this.behaviours.Length == 0 && base.transform.parent != null)
			{
				this.behaviours = base.transform.parent.GetComponentsInChildren<BehaviourBase>();
			}
			for (int i = 0; i < this.muscles.Length; i++)
			{
				this.muscles[i].Initiate(this.muscles);
				if (this.behaviours.Length != 0)
				{
					this.muscles[i].broadcaster = this.muscles[i].joint.gameObject.GetComponent<MuscleCollisionBroadcaster>();
					if (this.muscles[i].broadcaster == null)
					{
						this.muscles[i].broadcaster = this.muscles[i].joint.gameObject.AddComponent<MuscleCollisionBroadcaster>();
					}
					this.muscles[i].broadcaster.puppetMaster = this;
					this.muscles[i].broadcaster.muscleIndex = i;
				}
				this.muscles[i].jointBreakBroadcaster = this.muscles[i].joint.gameObject.GetComponent<JointBreakBroadcaster>();
				if (this.muscles[i].jointBreakBroadcaster == null)
				{
					this.muscles[i].jointBreakBroadcaster = this.muscles[i].joint.gameObject.AddComponent<JointBreakBroadcaster>();
				}
				this.muscles[i].jointBreakBroadcaster.puppetMaster = this;
				this.muscles[i].jointBreakBroadcaster.muscleIndex = i;
			}
			this.UpdateHierarchies();
			PropMuscle[] array = this.propMuscles;
			for (int j = 0; j < array.Length; j++)
			{
				array[j].OnInitiate();
			}
			this.hierarchyIsFlat = this.HierarchyIsFlat();
			this.FlagInternalCollisionsForUpdate();
			this.FlagAngularLimitsForUpdate();
			this.initiated = true;
			BehaviourBase[] array2 = this.behaviours;
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j].puppetMaster = this;
			}
			array2 = this.behaviours;
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j].Initiate();
			}
			this.SwitchStates();
			this.SwitchModes();
			Muscle[] array3 = this.muscles;
			for (int j = 0; j < array3.Length; j++)
			{
				array3[j].Read();
			}
			this.StoreTargetMappedState();
			if (Singleton<PuppetMasterSettings>.instance != null)
			{
				Singleton<PuppetMasterSettings>.instance.Register(this);
			}
			bool flag = false;
			foreach (BehaviourBase behaviourBase in this.behaviours)
			{
				if (behaviourBase is BehaviourPuppet && behaviourBase.enabled)
				{
					this.ActivateBehaviour(behaviourBase);
					flag = true;
					break;
				}
			}
			if (!flag && this.behaviours.Length != 0)
			{
				foreach (BehaviourBase behaviourBase2 in this.behaviours)
				{
					if (behaviourBase2.enabled)
					{
						this.ActivateBehaviour(behaviourBase2);
						break;
					}
				}
			}
			this.defaultMuscles = (Muscle[])this.muscles.Clone();
			if (this.OnPostInitiate != null)
			{
				this.OnPostInitiate();
			}
			if (!this.autoSimulate)
			{
				base.enabled = false;
			}
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00010B60 File Offset: 0x0000ED60
		private void ActivateBehaviour(BehaviourBase behaviour)
		{
			foreach (BehaviourBase behaviourBase in this.behaviours)
			{
				behaviourBase.enabled = (behaviourBase == behaviour);
				if (behaviourBase.enabled)
				{
					behaviourBase.Activate();
				}
			}
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00010BA1 File Offset: 0x0000EDA1
		private void OnDestroy()
		{
			if (Singleton<PuppetMasterSettings>.instance != null)
			{
				Singleton<PuppetMasterSettings>.instance.Unregister(this);
			}
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00010BBC File Offset: 0x0000EDBC
		private bool IsInterpolated()
		{
			if (!this.initiated)
			{
				return false;
			}
			Muscle[] array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].rigidbody.interpolation != RigidbodyInterpolation.None)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00010BFC File Offset: 0x0000EDFC
		private void OnRebuild()
		{
			this.rebuildFlag = false;
			if (this.activeMode == PuppetMaster.Mode.Disabled)
			{
				Debug.LogError("Can not rebuild a puppet in Disabled mode");
				return;
			}
			this.rebuildPelvisPos = this.defaultMuscles[0].target.position;
			this.rebuildPelvisRot = this.defaultMuscles[0].target.rotation;
			Muscle[] array = this.defaultMuscles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Rebuild();
			}
			foreach (Muscle muscle in this.defaultMuscles)
			{
				if (!this.ContainsJoint(muscle.joint))
				{
					this.AddMuscle(muscle.joint, muscle.target, muscle.rebuildConnectedBody, muscle.rebuildTargetParent, null, false, true);
				}
			}
			this.FlagInternalCollisionsForUpdate();
			this.FlagAngularLimitsForUpdate();
			BehaviourBase[] array2 = this.behaviours;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].OnReactivate();
			}
			this.onPostRebuildFlag = true;
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00010CEC File Offset: 0x0000EEEC
		public void OnPreSimulate(float deltaTime)
		{
			this.simulationDeltaTime = deltaTime;
			foreach (BehaviourBase behaviourBase in this.behaviours)
			{
				behaviourBase.UpdateB(deltaTime);
				behaviourBase.FixedUpdateB(deltaTime);
			}
			if (!this.initiated)
			{
				return;
			}
			if (this.rebuildFlag)
			{
				this.OnRebuild();
			}
			PropMuscle[] array2 = this.propMuscles;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].OnUpdate();
			}
			this.ProcessDisconnects();
			this.ProcessReconnects();
			if (this.muscles.Length == 0)
			{
				return;
			}
			this.interpolated = this.IsInterpolated();
			if (!this.isActive)
			{
				if (this.teleport)
				{
					this.Read();
				}
				return;
			}
			this.pinWeight = Mathf.Clamp(this.pinWeight, 0f, 1f);
			this.muscleWeight = Mathf.Clamp(this.muscleWeight, 0f, 1f);
			this.muscleSpring = Mathf.Clamp(this.muscleSpring, 0f, this.muscleSpring);
			this.muscleDamper = Mathf.Clamp(this.muscleDamper, 0f, this.muscleDamper);
			this.pinPow = Mathf.Clamp(this.pinPow, 1f, 8f);
			this.pinDistanceFalloff = Mathf.Max(this.pinDistanceFalloff, 0f);
			this.FixTargetTransforms();
			if (this.targetAnimator != null)
			{
				if (this.targetAnimator.enabled)
				{
					this.targetAnimator.enabled = false;
				}
				this.targetAnimator.Update(deltaTime);
			}
			foreach (SolverManager solverManager in this.solvers)
			{
				if (solverManager != null)
				{
					solverManager.UpdateSolverExternal();
				}
			}
			if (this.OnRead != null)
			{
				this.OnRead();
			}
			BehaviourBase[] array = this.behaviours;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnRead(deltaTime);
			}
			this.Read();
			if (!this.isFrozen)
			{
				this.UpdateInternalCollisions();
				this.UpdateAngularLimits();
				if (this.solverIterationCount != this.lastSolverIterationCount)
				{
					for (int j = 0; j < this.muscles.Length; j++)
					{
						this.muscles[j].rigidbody.solverIterations = this.solverIterationCount;
					}
					this.lastSolverIterationCount = this.solverIterationCount;
				}
				for (int k = 0; k < this.muscles.Length; k++)
				{
					this.muscles[k].Update(this.pinWeight, this.muscleWeight, this.muscleSpring, this.muscleDamper, this.pinPow, this.pinDistanceFalloff, true, this.angularPinning, deltaTime);
				}
			}
			if (this.updateMode == PuppetMaster.UpdateMode.AnimatePhysics)
			{
				this.FixTargetTransforms();
			}
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00010FB4 File Offset: 0x0000F1B4
		public void OnPostSimulate()
		{
			BehaviourBase[] array = this.behaviours;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].LateUpdateB(this.simulationDeltaTime);
			}
			if (this.muscles.Length == 0)
			{
				return;
			}
			if (this.initiated)
			{
				this.SwitchStates();
				this.SwitchModes();
				if (!this.isFrozen)
				{
					this.mappingWeight = Mathf.Clamp(this.mappingWeight, 0f, 1f);
					float num = this.mappingWeight * this.mappingBlend;
					if (num > 0f)
					{
						if (this.isActive)
						{
							for (int j = 0; j < this.muscles.Length; j++)
							{
								this.muscles[j].Map(num);
							}
						}
					}
					else if (this.activeMode == PuppetMaster.Mode.Kinematic)
					{
						this.MoveToTarget();
					}
					array = this.behaviours;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].OnWrite(this.simulationDeltaTime);
					}
					if (this.OnWrite != null)
					{
						this.OnWrite();
					}
					this.StoreTargetMappedState();
					Muscle[] array2 = this.muscles;
					for (int i = 0; i < array2.Length; i++)
					{
						array2[i].CalculateMappedVelocity();
					}
				}
				if (this.mapDisconnectedMuscles)
				{
					for (int k = 0; k < this.muscles.Length; k++)
					{
						this.muscles[k].MapDisconnected();
					}
				}
				if (this.freezeFlag)
				{
					this.OnFreezeFlag();
				}
			}
			if (this.onPostRebuildFlag)
			{
				this.defaultMuscles[0].target.position = this.rebuildPelvisPos;
				this.defaultMuscles[0].target.rotation = this.rebuildPelvisRot;
				foreach (Muscle muscle in this.muscles)
				{
					muscle.MoveToTarget();
					muscle.ClearVelocities();
				}
				this.onPostRebuildFlag = false;
			}
			if (this.OnPostLateUpdate != null)
			{
				this.OnPostLateUpdate();
			}
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0001118C File Offset: 0x0000F38C
		protected virtual void FixedUpdate()
		{
			BehaviourBase[] array = this.behaviours;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].FixedUpdateB(Time.deltaTime);
			}
			if (!this.initiated)
			{
				return;
			}
			if (!this.autoSimulate)
			{
				return;
			}
			if (this.rebuildFlag)
			{
				this.OnRebuild();
			}
			PropMuscle[] array2 = this.propMuscles;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].OnUpdate();
			}
			this.ProcessDisconnects();
			this.ProcessReconnects();
			if (this.muscles.Length == 0)
			{
				return;
			}
			this.interpolated = this.IsInterpolated();
			this.fixedFrame = true;
			if (!this.isActive)
			{
				if (this.teleport)
				{
					this.Read();
				}
				return;
			}
			this.pinWeight = Mathf.Clamp(this.pinWeight, 0f, 1f);
			this.muscleWeight = Mathf.Clamp(this.muscleWeight, 0f, 1f);
			this.muscleSpring = Mathf.Clamp(this.muscleSpring, 0f, this.muscleSpring);
			this.muscleDamper = Mathf.Clamp(this.muscleDamper, 0f, this.muscleDamper);
			this.pinPow = Mathf.Clamp(this.pinPow, 1f, 8f);
			this.pinDistanceFalloff = Mathf.Max(this.pinDistanceFalloff, 0f);
			if (this.updateMode == PuppetMaster.UpdateMode.FixedUpdate)
			{
				this.FixTargetTransforms();
				if (this.targetAnimator.enabled || (!this.targetAnimator.enabled && this.animatorDisabled))
				{
					this.targetAnimator.enabled = false;
					this.animatorDisabled = true;
					this.targetAnimator.Update(Time.fixedDeltaTime);
				}
				else
				{
					this.animatorDisabled = false;
					this.targetAnimator.enabled = false;
				}
				foreach (SolverManager solverManager in this.solvers)
				{
					if (solverManager != null)
					{
						solverManager.UpdateSolverExternal();
					}
				}
				if (this.OnRead != null)
				{
					this.OnRead();
				}
				array = this.behaviours;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].OnRead(Time.deltaTime);
				}
				this.Read();
				this.readInFixedUpdate = true;
			}
			if (!this.isFrozen)
			{
				this.UpdateInternalCollisions();
				this.UpdateAngularLimits();
				if (this.solverIterationCount != this.lastSolverIterationCount)
				{
					for (int j = 0; j < this.muscles.Length; j++)
					{
						this.muscles[j].rigidbody.solverIterations = this.solverIterationCount;
					}
					this.lastSolverIterationCount = this.solverIterationCount;
				}
				for (int k = 0; k < this.muscles.Length; k++)
				{
					this.muscles[k].Update(this.pinWeight, this.muscleWeight, this.muscleSpring, this.muscleDamper, this.pinPow, this.pinDistanceFalloff, true, this.angularPinning, Time.fixedDeltaTime);
				}
			}
			if (this.updateMode == PuppetMaster.UpdateMode.AnimatePhysics)
			{
				this.FixTargetTransforms();
			}
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0001149C File Offset: 0x0000F69C
		protected virtual void Update()
		{
			BehaviourBase[] array = this.behaviours;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].UpdateB(Time.deltaTime);
			}
			if (!this.initiated)
			{
				return;
			}
			if (!this.autoSimulate)
			{
				return;
			}
			if (this.muscles.Length == 0)
			{
				return;
			}
			if (this.animatorDisabled)
			{
				this.targetAnimator.enabled = true;
				this.animatorDisabled = false;
			}
			if (this.updateMode != PuppetMaster.UpdateMode.Normal)
			{
				return;
			}
			this.FixTargetTransforms();
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00011514 File Offset: 0x0000F714
		protected virtual void LateUpdate()
		{
			BehaviourBase[] array = this.behaviours;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].LateUpdateB(Time.deltaTime);
			}
			if (!this.autoSimulate)
			{
				return;
			}
			if (this.muscles.Length == 0)
			{
				return;
			}
			this.OnLateUpdate();
			if (this.onPostRebuildFlag)
			{
				this.defaultMuscles[0].target.position = this.rebuildPelvisPos;
				this.defaultMuscles[0].target.rotation = this.rebuildPelvisRot;
				foreach (Muscle muscle in this.muscles)
				{
					muscle.MoveToTarget();
					muscle.ClearVelocities();
				}
				this.onPostRebuildFlag = false;
			}
			if (this.OnPostLateUpdate != null)
			{
				this.OnPostLateUpdate();
			}
		}

		// Token: 0x06000309 RID: 777 RVA: 0x000115D4 File Offset: 0x0000F7D4
		protected virtual void OnLateUpdate()
		{
			if (!this.initiated)
			{
				return;
			}
			if (this.animatorDisabled)
			{
				this.targetAnimator.enabled = true;
				this.animatorDisabled = false;
			}
			object obj = this.updateMode == PuppetMaster.UpdateMode.Normal || (!this.readInFixedUpdate && this.fixedFrame);
			this.readInFixedUpdate = false;
			object obj2 = obj;
			bool flag = obj2 != null && this.isActive;
			if (obj2 != null)
			{
				if (this.OnRead != null)
				{
					this.OnRead();
				}
				BehaviourBase[] array = this.behaviours;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].OnRead(Time.deltaTime);
				}
			}
			if (flag)
			{
				this.Read();
			}
			this.SwitchStates();
			this.SwitchModes();
			PuppetMaster.UpdateMode updateMode = this.updateMode;
			if (updateMode != PuppetMaster.UpdateMode.AnimatePhysics)
			{
				if (updateMode == PuppetMaster.UpdateMode.FixedUpdate && !this.fixedFrame && !this.interpolated)
				{
					return;
				}
			}
			else if (!this.fixedFrame && !this.interpolated)
			{
				return;
			}
			this.fixedFrame = false;
			if (!this.isFrozen)
			{
				this.mappingWeight = Mathf.Clamp(this.mappingWeight, 0f, 1f);
				float num = this.mappingWeight * this.mappingBlend;
				if (num > 0f)
				{
					if (this.isActive)
					{
						for (int j = 0; j < this.muscles.Length; j++)
						{
							this.muscles[j].Map(num);
						}
					}
				}
				else if (this.activeMode == PuppetMaster.Mode.Kinematic)
				{
					this.MoveToTarget();
				}
				BehaviourBase[] array = this.behaviours;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].OnWrite(Time.deltaTime);
				}
				if (this.OnWrite != null)
				{
					this.OnWrite();
				}
				this.StoreTargetMappedState();
				Muscle[] array2 = this.muscles;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].CalculateMappedVelocity();
				}
			}
			if (this.mapDisconnectedMuscles)
			{
				for (int k = 0; k < this.muscles.Length; k++)
				{
					this.muscles[k].MapDisconnected();
				}
			}
			if (this.freezeFlag)
			{
				this.OnFreezeFlag();
			}
		}

		// Token: 0x0600030A RID: 778 RVA: 0x000117D0 File Offset: 0x0000F9D0
		private void MoveToTarget()
		{
			if (Singleton<PuppetMasterSettings>.instance == null || (Singleton<PuppetMasterSettings>.instance != null && Singleton<PuppetMasterSettings>.instance.UpdateMoveToTarget(this)))
			{
				Muscle[] array = this.muscles;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].MoveToTarget();
				}
			}
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00011824 File Offset: 0x0000FA24
		private void Read()
		{
			Muscle[] array;
			if (this.teleport)
			{
				GameObject gameObject = new GameObject();
				gameObject.transform.position = ((base.transform.parent != null) ? base.transform.parent.position : Vector3.zero);
				gameObject.transform.rotation = ((base.transform.parent != null) ? base.transform.parent.rotation : Quaternion.identity);
				Transform parent = base.transform.parent;
				Transform parent2 = this.targetRoot.parent;
				base.transform.parent = gameObject.transform;
				this.targetRoot.parent = gameObject.transform;
				Vector3 position = base.transform.parent.position;
				Quaternion quaternion = QuaTools.FromToRotation(this.targetRoot.rotation, this.teleportRotation);
				base.transform.parent.rotation = quaternion * base.transform.parent.rotation;
				Vector3 vector = this.teleportPosition - this.targetRoot.position;
				base.transform.parent.position += vector;
				base.transform.parent = parent;
				this.targetRoot.parent = parent2;
				Object.Destroy(gameObject);
				this.muscles[0].targetMappedPosition = position + quaternion * (this.muscles[0].targetMappedPosition - position) + vector;
				this.muscles[0].targetSampledPosition = position + quaternion * (this.muscles[0].targetSampledPosition - position) + vector;
				this.muscles[0].targetMappedRotation = quaternion * this.muscles[0].targetMappedRotation;
				this.muscles[0].targetSampledRotation = quaternion * this.muscles[0].targetSampledRotation;
				if (this.teleportMoveToTarget)
				{
					array = this.muscles;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].MoveToTarget();
					}
				}
				array = this.muscles;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].ClearVelocities();
				}
				BehaviourBase[] array2 = this.behaviours;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].OnTeleport(quaternion, vector, position, this.teleportMoveToTarget);
				}
				this.teleport = false;
			}
			if (!this.isAlive)
			{
				return;
			}
			array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Read();
			}
			if (this.isAlive && this.updateJointAnchors)
			{
				for (int j = 0; j < this.muscles.Length; j++)
				{
					this.muscles[j].UpdateAnchor(this.supportTranslationAnimation);
				}
			}
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00011B28 File Offset: 0x0000FD28
		private void FixTargetTransforms()
		{
			if (!this.isAlive)
			{
				return;
			}
			if (this.OnFixTransforms != null)
			{
				this.OnFixTransforms();
			}
			BehaviourBase[] array = this.behaviours;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnFixTransforms();
			}
			if (!this.fixTargetTransforms && !this.hasProp)
			{
				return;
			}
			if (!this.isActive)
			{
				return;
			}
			this.mappingWeight = Mathf.Clamp(this.mappingWeight, 0f, 1f);
			if (this.mappingWeight * this.mappingBlend <= 0f)
			{
				return;
			}
			for (int j = 0; j < this.muscles.Length; j++)
			{
				if (this.fixTargetTransforms || this.muscles[j].props.group == Muscle.Group.Prop)
				{
					this.muscles[j].FixTargetTransforms();
				}
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600030D RID: 781 RVA: 0x00011BF5 File Offset: 0x0000FDF5
		private AnimatorUpdateMode targetUpdateMode
		{
			get
			{
				if (this.targetAnimator != null)
				{
					return this.targetAnimator.updateMode;
				}
				if (!(this.targetAnimation != null))
				{
					return AnimatorUpdateMode.Normal;
				}
				if (!this.targetAnimation.animatePhysics)
				{
					return AnimatorUpdateMode.Normal;
				}
				return AnimatorUpdateMode.AnimatePhysics;
			}
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00011C34 File Offset: 0x0000FE34
		private void VisualizeTargetPose()
		{
			if (!this.visualizeTargetPose)
			{
				return;
			}
			if (!Application.isEditor)
			{
				return;
			}
			if (!this.isActive)
			{
				return;
			}
			foreach (Muscle muscle in this.muscles)
			{
				if (muscle.joint.connectedBody != null && muscle.connectedBodyTarget != null)
				{
					Debug.DrawLine(muscle.target.position, muscle.connectedBodyTarget.position, Color.cyan);
					bool flag = true;
					foreach (Muscle muscle2 in this.muscles)
					{
						if (muscle != muscle2 && muscle2.joint.connectedBody == muscle.rigidbody)
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						this.VisualizeHierarchy(muscle.target, Color.cyan);
					}
				}
			}
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00011D18 File Offset: 0x0000FF18
		private void VisualizeHierarchy(Transform t, Color color)
		{
			for (int i = 0; i < t.childCount; i++)
			{
				Debug.DrawLine(t.position, t.GetChild(i).position, color);
				this.VisualizeHierarchy(t.GetChild(i), color);
			}
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00011D5C File Offset: 0x0000FF5C
		public void FlagInternalCollisionsForUpdate()
		{
			if (this.manualInternalCollisionControl)
			{
				return;
			}
			this.internalCollisionsEnabled = !this.internalCollisions;
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00011D76 File Offset: 0x0000FF76
		private void UpdateInternalCollisions()
		{
			if (this.manualInternalCollisionControl)
			{
				return;
			}
			if (this.internalCollisionsEnabled == this.internalCollisions)
			{
				return;
			}
			if (this.internalCollisions)
			{
				this.ResetInternalCollisions();
				return;
			}
			this.IgnoreInternalCollisions();
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00011DA8 File Offset: 0x0000FFA8
		public void UpdateInternalCollisions(Muscle m)
		{
			if (this.manualInternalCollisionControl)
			{
				return;
			}
			foreach (Muscle muscle in this.muscles)
			{
				if (muscle != m)
				{
					if (this.internalCollisions)
					{
						m.ResetInternalCollisions(muscle, true);
					}
					else
					{
						m.IgnoreInternalCollisions(muscle);
					}
				}
			}
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00011DF4 File Offset: 0x0000FFF4
		private void IgnoreInternalCollisions()
		{
			if (this.manualInternalCollisionControl)
			{
				return;
			}
			for (int i = 0; i < this.muscles.Length; i++)
			{
				for (int j = i; j < this.muscles.Length; j++)
				{
					if (i != j)
					{
						this.muscles[i].IgnoreInternalCollisions(this.muscles[j]);
					}
				}
			}
			this.internalCollisions = false;
			this.internalCollisionsEnabled = false;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00011E58 File Offset: 0x00010058
		public void IgnoreInternalCollisions(Muscle m)
		{
			if (this.manualInternalCollisionControl)
			{
				return;
			}
			foreach (Muscle muscle in this.muscles)
			{
				if (muscle != m)
				{
					m.IgnoreInternalCollisions(muscle);
				}
			}
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00011E94 File Offset: 0x00010094
		private void ResetInternalCollisions()
		{
			if (this.manualInternalCollisionControl)
			{
				return;
			}
			for (int i = 0; i < this.muscles.Length; i++)
			{
				for (int j = i; j < this.muscles.Length; j++)
				{
					if (i != j)
					{
						this.muscles[i].ResetInternalCollisions(this.muscles[j], true);
					}
				}
			}
			this.internalCollisions = true;
			this.internalCollisionsEnabled = true;
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00011EF8 File Offset: 0x000100F8
		public void ResetInternalCollisions(Muscle m, bool useInternalCollisionIgnores)
		{
			if (this.manualInternalCollisionControl)
			{
				return;
			}
			foreach (Muscle muscle in this.muscles)
			{
				if (muscle != m)
				{
					m.ResetInternalCollisions(muscle, useInternalCollisionIgnores);
				}
			}
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00011F33 File Offset: 0x00010133
		public void FlagAngularLimitsForUpdate()
		{
			if (this.manualAngularLimitControl)
			{
				return;
			}
			this.angularLimitsEnabled = !this.angularLimits;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00011F50 File Offset: 0x00010150
		private void UpdateAngularLimits()
		{
			if (this.manualAngularLimitControl)
			{
				return;
			}
			if (this.angularLimitsEnabled == this.angularLimits)
			{
				return;
			}
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (!this.muscles[i].state.isDisconnected)
				{
					this.muscles[i].IgnoreAngularLimits(!this.angularLimits);
				}
			}
			this.angularLimitsEnabled = this.angularLimits;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00011FC0 File Offset: 0x000101C0
		public bool AddPropMuscle(ConfigurableJoint addPropMuscleTo, Vector3 position, Quaternion rotation, Vector3 additionalPinOffset, Transform targetParent = null, PuppetMasterProp initiateWithProp = null)
		{
			if (!this.initiated)
			{
				Debug.LogError("Can not add Prop Muscle to PuppetMaster that has not been initiated! Please use Start() instead of Awake() or PuppetMaster.OnPostInitiate delegate to call AddPropMuscle.", base.transform);
				return false;
			}
			if (!(addPropMuscleTo != null))
			{
				Debug.LogError("Please assign the ConfigurableJoint of the muscle you wish to add the Prop Muscle to.", base.transform);
				return false;
			}
			bool flag = this.HierarchyIsFlat();
			Muscle muscle = this.GetMuscle(addPropMuscleTo);
			if (muscle != null)
			{
				GameObject gameObject = new GameObject("Prop Muscle " + addPropMuscleTo.name);
				gameObject.layer = addPropMuscleTo.gameObject.layer;
				gameObject.transform.parent = (flag ? base.transform : addPropMuscleTo.transform);
				gameObject.transform.position = position;
				gameObject.transform.rotation = rotation;
				gameObject.AddComponent<Rigidbody>();
				GameObject gameObject2 = new GameObject("Prop Muscle Target " + addPropMuscleTo.name);
				gameObject2.gameObject.layer = muscle.target.gameObject.layer;
				gameObject2.transform.parent = ((targetParent != null) ? targetParent : muscle.target);
				gameObject2.transform.position = gameObject.transform.position;
				gameObject2.transform.rotation = gameObject.transform.rotation;
				ConfigurableJoint configurableJoint = gameObject.AddComponent<ConfigurableJoint>();
				configurableJoint.xMotion = ConfigurableJointMotion.Locked;
				configurableJoint.yMotion = ConfigurableJointMotion.Locked;
				configurableJoint.zMotion = ConfigurableJointMotion.Locked;
				configurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
				configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
				configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
				Muscle.Props props = new Muscle.Props();
				props.group = Muscle.Group.Prop;
				this.AddMuscle(configurableJoint, gameObject2.transform, addPropMuscleTo.GetComponent<Rigidbody>(), (targetParent != null) ? targetParent : muscle.target, props, false, true);
				this.muscles[this.muscles.Length - 1].isPropMuscle = true;
				PropMuscle propMuscle = gameObject.AddComponent<PropMuscle>();
				propMuscle.puppetMaster = this;
				propMuscle.additionalPinOffset = additionalPinOffset;
				propMuscle.currentProp = initiateWithProp;
				if (additionalPinOffset != Vector3.zero)
				{
					propMuscle.AddAdditionalPin();
				}
				Array.Resize<PropMuscle>(ref this.propMuscles, this.propMuscles.Length + 1);
				this.propMuscles[this.propMuscles.Length - 1] = propMuscle;
				propMuscle.OnInitiate();
				return true;
			}
			Debug.LogError("Can't add Prop Muscle to a ConfigurableJoint that is not in the list of PuppetMaster.muscles.", base.transform);
			return false;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x000121FC File Offset: 0x000103FC
		public bool IsDisconnecting(int muscleIndex)
		{
			return this.disconnectMuscleFlags[muscleIndex];
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00012206 File Offset: 0x00010406
		public bool IsReconnecting(int muscleIndex)
		{
			return this.reconnectMuscleFlags[muscleIndex];
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00012210 File Offset: 0x00010410
		public void DisconnectMuscleRecursive(int index, MuscleDisconnectMode disconnectMode = MuscleDisconnectMode.Sever, bool deactivate = false)
		{
			if (index < 0 || index >= this.muscles.Length)
			{
				Debug.LogError("PuppetMaster.DisconnectMuscleRecursive() called with out of range index: " + index.ToString(), base.transform);
				return;
			}
			this.disconnectMuscleFlags[index] = true;
			this.muscleDisconnectModes[index] = disconnectMode;
			this.disconnectDeactivateFlags[index] = deactivate;
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00012264 File Offset: 0x00010464
		public void ReconnectMuscleRecursive(int index)
		{
			if (index < 0 || index >= this.muscles.Length)
			{
				Debug.LogError("PuppetMaster.ReconnectMuscleRecursive() called with out of range index: " + index.ToString(), base.transform);
				return;
			}
			if (index > 0)
			{
				index = this.GetHighestDisconnectedParentIndex(index);
			}
			this.reconnectMuscleFlags[index] = true;
			if (this.muscles[index].state.resetFlag)
			{
				this.muscles[index].joint.gameObject.SetActive(false);
			}
			for (int i = 0; i < this.muscles[index].childIndexes.Length; i++)
			{
				int num = this.muscles[index].childIndexes[i];
				if (this.muscles[num].state.resetFlag)
				{
					this.muscles[num].joint.gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00012338 File Offset: 0x00010538
		public void AddMuscle(ConfigurableJoint joint, Transform target, Rigidbody connectTo, Transform targetParent, Muscle.Props muscleProps = null, bool forceTreeHierarchy = false, bool forceLayers = true)
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			if (!this.initiated)
			{
				Debug.LogWarning("PuppetMaster has not been initiated.", base.transform);
				return;
			}
			if (this.ContainsJoint(joint))
			{
				Debug.LogWarning("Joint " + joint.name + " is already used by a Muscle", base.transform);
				return;
			}
			if (target == null)
			{
				Debug.LogWarning("AddMuscle was called with a null 'target' reference.", base.transform);
				return;
			}
			if (connectTo == joint.GetComponent<Rigidbody>())
			{
				Debug.LogWarning("ConnectTo is the joint's own Rigidbody, can not add muscle.", base.transform);
				return;
			}
			if (this.activeMode == PuppetMaster.Mode.Disabled)
			{
				Debug.LogWarning("Adding muscles to disabled PuppetMasters is not currently supported.", base.transform);
				return;
			}
			if (muscleProps == null)
			{
				muscleProps = new Muscle.Props();
			}
			Muscle muscle = new Muscle();
			muscle.props = muscleProps;
			muscle.joint = joint;
			muscle.target = target;
			muscle.joint.transform.parent = (((this.hierarchyIsFlat || connectTo == null) && !forceTreeHierarchy) ? base.transform : connectTo.transform);
			AnimationBlocker component = target.GetComponent<AnimationBlocker>();
			if (component != null)
			{
				Object.Destroy(component);
			}
			if (forceLayers)
			{
				joint.gameObject.layer = base.gameObject.layer;
				target.gameObject.layer = this.targetRoot.gameObject.layer;
			}
			if (connectTo != null)
			{
				muscle.target.parent = targetParent;
				Vector3 position = this.GetMuscle(connectTo).transform.InverseTransformPoint(muscle.target.position);
				Quaternion rhs = Quaternion.Inverse(this.GetMuscle(connectTo).transform.rotation) * muscle.target.rotation;
				joint.transform.position = connectTo.transform.TransformPoint(position);
				joint.transform.rotation = connectTo.transform.rotation * rhs;
				joint.connectedBody = connectTo;
				joint.xMotion = ConfigurableJointMotion.Locked;
				joint.yMotion = ConfigurableJointMotion.Locked;
				joint.zMotion = ConfigurableJointMotion.Locked;
			}
			muscle.Initiate(this.muscles);
			if (connectTo != null)
			{
				muscle.rigidbody.velocity = connectTo.velocity;
				muscle.rigidbody.angularVelocity = connectTo.angularVelocity;
			}
			if (!this.internalCollisions)
			{
				for (int i = 0; i < this.muscles.Length; i++)
				{
					muscle.IgnoreInternalCollisions(this.muscles[i]);
				}
			}
			Array.Resize<Muscle>(ref this.muscles, this.muscles.Length + 1);
			this.muscles[this.muscles.Length - 1] = muscle;
			muscle.index = this.muscles.Length - 1;
			muscle.IgnoreAngularLimits(!this.angularLimits);
			if (this.behaviours.Length != 0)
			{
				muscle.broadcaster = muscle.joint.gameObject.AddComponent<MuscleCollisionBroadcaster>();
				muscle.broadcaster.puppetMaster = this;
				muscle.broadcaster.muscleIndex = this.muscles.Length - 1;
			}
			muscle.jointBreakBroadcaster = muscle.joint.gameObject.AddComponent<JointBreakBroadcaster>();
			muscle.jointBreakBroadcaster.puppetMaster = this;
			muscle.jointBreakBroadcaster.muscleIndex = this.muscles.Length - 1;
			this.UpdateHierarchies();
			this.CheckMassVariation(100f, true);
			BehaviourBase[] array = this.behaviours;
			for (int j = 0; j < array.Length; j++)
			{
				array[j].OnMuscleAdded(muscle);
			}
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00012690 File Offset: 0x00010890
		public void Rebuild()
		{
			this.rebuildFlag = true;
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0001269C File Offset: 0x0001089C
		public void RemoveMuscleRecursive(ConfigurableJoint joint, bool attachTarget, bool blockTargetAnimation = false, MuscleRemoveMode removeMode = MuscleRemoveMode.Sever)
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			if (joint == null)
			{
				Debug.LogWarning("RemoveMuscleRecursive was called with a null 'joint' reference.", base.transform);
				return;
			}
			if (!this.ContainsJoint(joint))
			{
				Debug.LogWarning("No Muscle with the specified joint was found, can not remove muscle.", base.transform);
				return;
			}
			int muscleIndex = this.GetMuscleIndex(joint);
			Muscle[] array = new Muscle[this.muscles.Length - (this.muscles[muscleIndex].childIndexes.Length + 1)];
			int num = 0;
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (i != muscleIndex && !this.muscles[muscleIndex].childFlags[i])
				{
					array[num] = this.muscles[i];
					num++;
				}
				else
				{
					if (this.muscles[i].broadcaster != null)
					{
						this.muscles[i].broadcaster.enabled = false;
						Object.Destroy(this.muscles[i].broadcaster);
					}
					if (this.muscles[i].jointBreakBroadcaster != null)
					{
						this.muscles[i].jointBreakBroadcaster.enabled = false;
						Object.Destroy(this.muscles[i].jointBreakBroadcaster);
					}
				}
			}
			switch (removeMode)
			{
			case MuscleRemoveMode.Sever:
				this.DisconnectJoint(this.muscles[muscleIndex].joint);
				for (int j = 0; j < this.muscles[muscleIndex].childIndexes.Length; j++)
				{
					this.KillJoint(this.muscles[this.muscles[muscleIndex].childIndexes[j]].joint);
				}
				break;
			case MuscleRemoveMode.Explode:
				this.DisconnectJoint(this.muscles[muscleIndex].joint);
				for (int k = 0; k < this.muscles[muscleIndex].childIndexes.Length; k++)
				{
					this.DisconnectJoint(this.muscles[this.muscles[muscleIndex].childIndexes[k]].joint);
				}
				break;
			case MuscleRemoveMode.Numb:
				this.KillJoint(this.muscles[muscleIndex].joint);
				for (int l = 0; l < this.muscles[muscleIndex].childIndexes.Length; l++)
				{
					this.KillJoint(this.muscles[this.muscles[muscleIndex].childIndexes[l]].joint);
				}
				break;
			}
			this.muscles[muscleIndex].transform.parent = null;
			for (int m = 0; m < this.muscles[muscleIndex].childIndexes.Length; m++)
			{
				if (removeMode == MuscleRemoveMode.Explode || this.muscles[this.muscles[muscleIndex].childIndexes[m]].transform.parent == base.transform)
				{
					this.muscles[this.muscles[muscleIndex].childIndexes[m]].transform.parent = null;
				}
			}
			foreach (BehaviourBase behaviourBase in this.behaviours)
			{
				behaviourBase.OnMuscleRemoved(this.muscles[muscleIndex]);
				for (int num2 = 0; num2 < this.muscles[muscleIndex].childIndexes.Length; num2++)
				{
					Muscle m2 = this.muscles[this.muscles[muscleIndex].childIndexes[num2]];
					behaviourBase.OnMuscleRemoved(m2);
				}
			}
			if (attachTarget)
			{
				this.muscles[muscleIndex].target.parent = this.muscles[muscleIndex].transform;
				this.muscles[muscleIndex].target.position = this.muscles[muscleIndex].transform.position;
				this.muscles[muscleIndex].target.rotation = this.muscles[muscleIndex].transform.rotation * this.muscles[muscleIndex].targetRotationRelative;
				for (int num3 = 0; num3 < this.muscles[muscleIndex].childIndexes.Length; num3++)
				{
					Muscle muscle = this.muscles[this.muscles[muscleIndex].childIndexes[num3]];
					muscle.target.parent = muscle.transform;
					muscle.target.position = muscle.transform.position;
					muscle.target.rotation = muscle.transform.rotation;
				}
			}
			if (blockTargetAnimation)
			{
				if (this.muscles[muscleIndex].target.gameObject.GetComponent<AnimationBlocker>() == null)
				{
					this.muscles[muscleIndex].target.gameObject.AddComponent<AnimationBlocker>();
				}
				for (int num4 = 0; num4 < this.muscles[muscleIndex].childIndexes.Length; num4++)
				{
					Muscle muscle2 = this.muscles[this.muscles[muscleIndex].childIndexes[num4]];
					if (muscle2.target.gameObject.GetComponent<AnimationBlocker>() == null)
					{
						muscle2.target.gameObject.AddComponent<AnimationBlocker>();
					}
				}
			}
			if (this.OnMuscleRemoved != null)
			{
				this.OnMuscleRemoved(this.muscles[muscleIndex]);
			}
			for (int num5 = 0; num5 < this.muscles[muscleIndex].childIndexes.Length; num5++)
			{
				Muscle muscle3 = this.muscles[this.muscles[muscleIndex].childIndexes[num5]];
				if (this.OnMuscleRemoved != null)
				{
					this.OnMuscleRemoved(muscle3);
				}
			}
			if (!this.internalCollisionsEnabled)
			{
				foreach (Muscle muscle4 in array)
				{
					muscle4.ResetInternalCollisions(this.muscles[muscleIndex], false);
					for (int num6 = 0; num6 < this.muscles[muscleIndex].childIndexes.Length; num6++)
					{
						muscle4.ResetInternalCollisions(this.muscles[num6], false);
					}
				}
			}
			this.muscles = array;
			this.UpdateHierarchies();
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00012C42 File Offset: 0x00010E42
		public void ReplaceMuscle(ConfigurableJoint oldJoint, ConfigurableJoint newJoint)
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			Debug.LogWarning("@todo", base.transform);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00012C42 File Offset: 0x00010E42
		public void SetMuscles(Muscle[] newMuscles)
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			Debug.LogWarning("@todo", base.transform);
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00012C42 File Offset: 0x00010E42
		public void DisableMuscleRecursive(ConfigurableJoint joint)
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			Debug.LogWarning("@todo", base.transform);
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00012C42 File Offset: 0x00010E42
		public void EnableMuscleRecursive(ConfigurableJoint joint)
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			Debug.LogWarning("@todo", base.transform);
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00012C60 File Offset: 0x00010E60
		[ContextMenu("Flatten Muscle Hierarchy")]
		public void FlattenHierarchy()
		{
			foreach (Muscle muscle in this.muscles)
			{
				if (muscle.joint != null)
				{
					muscle.joint.transform.parent = base.transform;
				}
			}
			this.hierarchyIsFlat = true;
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00012CB4 File Offset: 0x00010EB4
		[ContextMenu("Tree Muscle Hierarchy")]
		public void TreeHierarchy()
		{
			foreach (Muscle muscle in this.muscles)
			{
				if (muscle.joint != null)
				{
					muscle.joint.transform.parent = ((muscle.joint.connectedBody != null) ? muscle.joint.connectedBody.transform : base.transform);
				}
			}
			this.hierarchyIsFlat = false;
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00012D2C File Offset: 0x00010F2C
		[ContextMenu("Fix Muscle Positions")]
		public void FixMusclePositions()
		{
			foreach (Muscle muscle in this.muscles)
			{
				if (muscle.joint != null && muscle.target != null)
				{
					muscle.joint.transform.position = muscle.target.position;
				}
			}
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00012D8C File Offset: 0x00010F8C
		[ContextMenu("Fix Muscle Positions and Rotations")]
		public void FixMusclePositionsAndRotations()
		{
			foreach (Muscle muscle in this.muscles)
			{
				if (muscle.joint != null && muscle.target != null)
				{
					muscle.joint.transform.position = muscle.target.position;
					muscle.joint.transform.rotation = muscle.target.rotation;
				}
			}
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00012E04 File Offset: 0x00011004
		public bool HierarchyIsFlat()
		{
			Muscle[] array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].joint.transform.parent != base.transform)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00012E48 File Offset: 0x00011048
		private int GetHighestDisconnectedParentIndex(int index)
		{
			for (int i = this.muscles[index].parentIndexes.Length - 1; i > -1; i--)
			{
				int num = this.muscles[index].parentIndexes[i];
				if (this.muscles[num].state.isDisconnected)
				{
					return num;
				}
			}
			return index;
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00012E98 File Offset: 0x00011098
		private void ProcessDisconnects()
		{
			for (int i = 0; i < this.disconnectMuscleFlags.Length; i++)
			{
				if (this.disconnectMuscleFlags[i])
				{
					this.OnDisconnectMuscleRecursive(i, this.muscleDisconnectModes[i], this.disconnectDeactivateFlags[i]);
				}
			}
			for (int j = 0; j < this.disconnectMuscleFlags.Length; j++)
			{
				this.disconnectMuscleFlags[j] = false;
				this.disconnectDeactivateFlags[j] = false;
			}
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00012F00 File Offset: 0x00011100
		private void ProcessReconnects()
		{
			for (int i = 0; i < this.reconnectMuscleFlags.Length; i++)
			{
				if (this.reconnectMuscleFlags[i])
				{
					this.OnReconnectMuscleRecursive(i);
				}
			}
			for (int j = 0; j < this.reconnectMuscleFlags.Length; j++)
			{
				this.reconnectMuscleFlags[j] = false;
			}
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00012F50 File Offset: 0x00011150
		private void OnDisconnectMuscleRecursive(int index, MuscleDisconnectMode disconnectMode = MuscleDisconnectMode.Sever, bool deactivate = false)
		{
			if (!this.muscles[index].joint.gameObject.activeInHierarchy || deactivate)
			{
				this.muscles[index].state.resetFlag = true;
			}
			for (int i = 0; i < this.muscles[index].childIndexes.Length; i++)
			{
				int num = this.muscles[index].childIndexes[i];
				if (!this.muscles[num].joint.gameObject.activeInHierarchy || deactivate)
				{
					this.muscles[num].state.resetFlag = true;
				}
			}
			this.DisconnectMuscle(this.muscles[index], true, deactivate);
			for (int j = 0; j < this.muscles[index].childIndexes.Length; j++)
			{
				int num2 = this.muscles[index].childIndexes[j];
				bool flag = disconnectMode == MuscleDisconnectMode.Sever && this.muscles[num2].state.isDisconnected;
				if (disconnectMode == MuscleDisconnectMode.Explode && this.muscles[num2].joint.xMotion != ConfigurableJointMotion.Free)
				{
					flag = false;
				}
				if (!flag)
				{
					this.DisconnectMuscle(this.muscles[num2], disconnectMode == MuscleDisconnectMode.Explode, deactivate);
				}
			}
			if (!this.muscles[0].state.isDisconnected)
			{
				bool flag2 = true;
				for (int k = 1; k < this.muscles.Length; k++)
				{
					if (!this.muscles[k].state.isDisconnected)
					{
						return;
					}
					if (flag2)
					{
						this.DisconnectMuscleRecursive(0, MuscleDisconnectMode.Sever, false);
					}
				}
			}
		}

		// Token: 0x0600032E RID: 814 RVA: 0x000130C4 File Offset: 0x000112C4
		private void DisconnectMuscle(Muscle m, bool sever, bool deactivate)
		{
			m.state.pinWeightMlp = 0f;
			m.state.muscleWeightMlp = 0f;
			m.state.muscleDamperAdd = 0f;
			m.state.muscleDamperMlp = 0f;
			m.state.mappingWeightMlp = 0f;
			m.state.maxForceMlp = 0f;
			m.state.immunity = 0f;
			m.state.impulseMlp = 1f;
			if (sever)
			{
				m.joint.xMotion = ConfigurableJointMotion.Free;
				m.joint.yMotion = ConfigurableJointMotion.Free;
				m.joint.zMotion = ConfigurableJointMotion.Free;
				m.IgnoreAngularLimits(true);
				if (!this.hierarchyIsFlat)
				{
					m.joint.transform.parent = base.transform;
				}
			}
			else
			{
				m.IgnoreAngularLimits(false);
			}
			bool flag = !m.joint.gameObject.activeInHierarchy || m.rigidbody.isKinematic;
			if (this.activeState == PuppetMaster.State.Frozen)
			{
				flag = false;
			}
			if (!m.joint.gameObject.activeInHierarchy && !deactivate)
			{
				m.MoveToTarget();
				m.joint.gameObject.SetActive(true);
			}
			m.SetKinematic(false);
			JointDrive slerpDrive = default(JointDrive);
			slerpDrive.positionSpring = 0f;
			slerpDrive.maximumForce = 0f;
			slerpDrive.positionDamper = 0f;
			m.joint.slerpDrive = slerpDrive;
			if (!deactivate)
			{
				for (int i = 0; i < this.muscles.Length; i++)
				{
					if (this.muscles[i] != m && !this.muscles[i].state.isDisconnected)
					{
						foreach (Collider collider in m.colliders)
						{
							foreach (Collider collider2 in this.muscles[i].colliders)
							{
								if (collider.enabled && collider2.enabled)
								{
									Physics.IgnoreCollision(collider, collider2, false);
								}
							}
						}
					}
				}
				if (flag)
				{
					m.rigidbody.velocity = m.mappedVelocity;
					m.rigidbody.angularVelocity = m.mappedAngularVelocity;
				}
			}
			else
			{
				m.joint.gameObject.SetActive(false);
			}
			if (m.isPropMuscle)
			{
				PropMuscle component = m.joint.GetComponent<PropMuscle>();
				if (component.activeProp != null)
				{
					component.currentProp = null;
				}
			}
			m.state.isDisconnected = true;
			BehaviourBase[] array = this.behaviours;
			for (int j = 0; j < array.Length; j++)
			{
				array[j].OnMuscleDisconnected(m);
			}
			if (this.OnMuscleDisconnected != null)
			{
				this.OnMuscleDisconnected(m);
			}
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0001338C File Offset: 0x0001158C
		private void OnReconnectMuscleRecursive(int index)
		{
			if (index == 0)
			{
				this.state = PuppetMaster.State.Alive;
				foreach (Muscle muscle in this.muscles)
				{
					if (!muscle.isPropMuscle)
					{
						muscle.state.isDisconnected = false;
						muscle.FixTargetTransforms();
					}
				}
				foreach (Muscle muscle2 in this.muscles)
				{
					if (!muscle2.isPropMuscle)
					{
						muscle2.Reset();
						muscle2.Read();
						muscle2.ClearVelocities();
					}
				}
			}
			this.ReconnectMuscle(this.muscles[index]);
			for (int j = 0; j < this.muscles[index].childIndexes.Length; j++)
			{
				int num = this.muscles[index].childIndexes[j];
				if (!this.muscles[num].isPropMuscle)
				{
					this.ReconnectMuscle(this.muscles[num]);
				}
			}
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00013468 File Offset: 0x00011668
		private void ReconnectMuscle(Muscle m)
		{
			m.state.isDisconnected = false;
			if (this.activeState != PuppetMaster.State.Frozen && !m.isPropMuscle)
			{
				m.target.position = m.targetAnimatedPosition;
				m.target.rotation = m.targetAnimatedWorldRotation;
			}
			if (m != this.muscles[0])
			{
				m.joint.xMotion = ConfigurableJointMotion.Locked;
				m.joint.yMotion = ConfigurableJointMotion.Locked;
				m.joint.zMotion = ConfigurableJointMotion.Locked;
				if (!this.hierarchyIsFlat && m.joint.connectedBody != null)
				{
					m.transform.parent = m.joint.connectedBody.transform;
				}
			}
			bool flag = false;
			if (m.joint.connectedBody != null && !m.joint.connectedBody.gameObject.activeInHierarchy)
			{
				flag = true;
			}
			if (m.joint.connectedBody == null && (this.activeMode == PuppetMaster.Mode.Disabled || this.activeState == PuppetMaster.State.Frozen))
			{
				flag = true;
			}
			if (flag)
			{
				m.joint.gameObject.SetActive(false);
			}
			else if (!m.joint.gameObject.activeInHierarchy || m.state.resetFlag)
			{
				m.Reset();
				m.joint.gameObject.SetActive(true);
			}
			else if (this.activeState != PuppetMaster.State.Frozen)
			{
				m.MoveToTarget();
			}
			if (this.activeMode == PuppetMaster.Mode.Kinematic)
			{
				m.SetKinematic(true);
			}
			if (this.activeState == PuppetMaster.State.Dead)
			{
				m.ResetTargetLocalPosition();
				m.SetMuscleRotation(this.muscleWeight * this.stateSettings.deadMuscleWeight, this.muscleSpring, this.muscleDamper + this.stateSettings.deadMuscleDamper);
			}
			m.state.resetFlag = false;
			m.ClearVelocities();
			m.state.pinWeightMlp = 1f;
			m.state.muscleWeightMlp = 1f;
			m.state.muscleDamperMlp = 1f;
			m.state.maxForceMlp = 1f;
			m.state.mappingWeightMlp = 1f;
			this.UpdateInternalCollisions(m);
			m.IgnoreAngularLimits(!this.angularLimits);
			BehaviourBase[] array = this.behaviours;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnMuscleReconnected(m);
			}
			if (this.OnMuscleReconnected != null)
			{
				this.OnMuscleReconnected(m);
			}
		}

		// Token: 0x06000331 RID: 817 RVA: 0x000136C4 File Offset: 0x000118C4
		private void AddIndexesRecursive(int index, ref int[] indexes)
		{
			int num = indexes.Length;
			Array.Resize<int>(ref indexes, indexes.Length + 1 + this.muscles[index].childIndexes.Length);
			indexes[num] = index;
			if (this.muscles[index].childIndexes.Length == 0)
			{
				return;
			}
			for (int i = 0; i < this.muscles[index].childIndexes.Length; i++)
			{
				this.AddIndexesRecursive(this.muscles[index].childIndexes[i], ref indexes);
			}
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00013738 File Offset: 0x00011938
		private void DisconnectJoint(ConfigurableJoint joint)
		{
			if (this.mode == PuppetMaster.Mode.Disabled)
			{
				joint.gameObject.SetActive(true);
			}
			joint.connectedBody = null;
			this.KillJoint(joint);
			joint.xMotion = ConfigurableJointMotion.Free;
			joint.yMotion = ConfigurableJointMotion.Free;
			joint.zMotion = ConfigurableJointMotion.Free;
			joint.angularXMotion = ConfigurableJointMotion.Free;
			joint.angularYMotion = ConfigurableJointMotion.Free;
			joint.angularZMotion = ConfigurableJointMotion.Free;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00013794 File Offset: 0x00011994
		private void KillJoint(ConfigurableJoint joint)
		{
			joint.targetRotation = Quaternion.identity;
			joint.slerpDrive = new JointDrive
			{
				positionSpring = 0f,
				positionDamper = 0f
			};
		}

		// Token: 0x06000334 RID: 820 RVA: 0x000137D3 File Offset: 0x000119D3
		public void SwitchToActiveMode()
		{
			this.mode = PuppetMaster.Mode.Active;
		}

		// Token: 0x06000335 RID: 821 RVA: 0x000137DC File Offset: 0x000119DC
		public void SwitchToKinematicMode()
		{
			this.mode = PuppetMaster.Mode.Kinematic;
		}

		// Token: 0x06000336 RID: 822 RVA: 0x000137E5 File Offset: 0x000119E5
		public void SwitchToDisabledMode()
		{
			this.mode = PuppetMaster.Mode.Disabled;
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000337 RID: 823 RVA: 0x000137EE File Offset: 0x000119EE
		// (set) Token: 0x06000338 RID: 824 RVA: 0x000137F6 File Offset: 0x000119F6
		public bool isSwitchingMode { get; private set; }

		// Token: 0x06000339 RID: 825 RVA: 0x00013800 File Offset: 0x00011A00
		public void DisableImmediately()
		{
			this.mappingBlend = 0f;
			this.isSwitchingMode = false;
			this.mode = PuppetMaster.Mode.Disabled;
			this.activeMode = this.mode;
			this.lastMode = this.mode;
			Muscle[] array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].rigidbody.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00013868 File Offset: 0x00011A68
		protected virtual void SwitchModes()
		{
			if (!this.initiated)
			{
				return;
			}
			if (this.isKilling)
			{
				this.mode = PuppetMaster.Mode.Active;
			}
			if (!this.isAlive)
			{
				this.mode = PuppetMaster.Mode.Active;
			}
			BehaviourBase[] array = this.behaviours;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].forceActive)
				{
					this.mode = PuppetMaster.Mode.Active;
					break;
				}
			}
			if (this.mode == this.lastMode)
			{
				return;
			}
			if (this.isSwitchingMode)
			{
				return;
			}
			if (this.isKilling && this.mode != PuppetMaster.Mode.Active)
			{
				return;
			}
			if (this.state != PuppetMaster.State.Alive && this.mode != PuppetMaster.Mode.Active)
			{
				return;
			}
			this.isSwitchingMode = true;
			if (this.lastMode == PuppetMaster.Mode.Disabled)
			{
				if (this.mode == PuppetMaster.Mode.Kinematic)
				{
					this.DisabledToKinematic();
				}
				else if (this.mode == PuppetMaster.Mode.Active)
				{
					base.StartCoroutine(this.DisabledToActive());
				}
			}
			else if (this.lastMode == PuppetMaster.Mode.Kinematic)
			{
				if (this.mode == PuppetMaster.Mode.Disabled)
				{
					this.KinematicToDisabled();
				}
				else if (this.mode == PuppetMaster.Mode.Active)
				{
					base.StartCoroutine(this.KinematicToActive());
				}
			}
			else if (this.lastMode == PuppetMaster.Mode.Active)
			{
				if (this.mode == PuppetMaster.Mode.Disabled)
				{
					base.StartCoroutine(this.ActiveToDisabled());
				}
				else if (this.mode == PuppetMaster.Mode.Kinematic)
				{
					base.StartCoroutine(this.ActiveToKinematic());
				}
			}
			this.lastMode = this.mode;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x000139AC File Offset: 0x00011BAC
		private void DisabledToKinematic()
		{
			foreach (Muscle muscle in this.muscles)
			{
				if (!muscle.state.isDisconnected)
				{
					muscle.Reset();
				}
			}
			foreach (Muscle muscle2 in this.muscles)
			{
				if (!muscle2.state.isDisconnected)
				{
					muscle2.rigidbody.gameObject.SetActive(true);
					muscle2.SetKinematic(true);
				}
			}
			this.FlagInternalCollisionsForUpdate();
			foreach (Muscle muscle3 in this.muscles)
			{
				if (!muscle3.state.isDisconnected)
				{
					muscle3.MoveToTarget();
				}
			}
			this.activeMode = PuppetMaster.Mode.Kinematic;
			this.isSwitchingMode = false;
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00013A66 File Offset: 0x00011C66
		private IEnumerator DisabledToActive()
		{
			foreach (Muscle muscle in this.muscles)
			{
				if (!muscle.state.isDisconnected)
				{
					muscle.Reset();
				}
			}
			foreach (Muscle muscle2 in this.muscles)
			{
				if (!muscle2.state.isDisconnected)
				{
					muscle2.rigidbody.gameObject.SetActive(true);
					muscle2.SetKinematic(false);
					muscle2.rigidbody.WakeUp();
					muscle2.rigidbody.velocity = muscle2.mappedVelocity;
					muscle2.rigidbody.angularVelocity = muscle2.mappedAngularVelocity;
				}
			}
			this.FlagInternalCollisionsForUpdate();
			foreach (Muscle muscle3 in this.muscles)
			{
				if (!muscle3.state.isDisconnected)
				{
					muscle3.MoveToTarget();
				}
			}
			this.Read();
			if (this.blendTime > 0f)
			{
				while (this.mappingBlend < 1f)
				{
					this.mappingBlend = Mathf.Clamp(this.mappingBlend + Time.deltaTime / this.blendTime, 0f, 1f);
					yield return null;
				}
			}
			else
			{
				this.mappingBlend = 1f;
			}
			this.activeMode = PuppetMaster.Mode.Active;
			this.isSwitchingMode = false;
			yield break;
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00013A78 File Offset: 0x00011C78
		private void KinematicToDisabled()
		{
			foreach (Muscle muscle in this.muscles)
			{
				if (!muscle.state.isDisconnected)
				{
					muscle.rigidbody.gameObject.SetActive(false);
				}
			}
			this.activeMode = PuppetMaster.Mode.Disabled;
			this.isSwitchingMode = false;
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00013ACA File Offset: 0x00011CCA
		private IEnumerator KinematicToActive()
		{
			foreach (Muscle muscle in this.muscles)
			{
				if (!muscle.state.isDisconnected)
				{
					muscle.SetKinematic(false);
					muscle.rigidbody.WakeUp();
					muscle.rigidbody.velocity = muscle.mappedVelocity;
					muscle.rigidbody.angularVelocity = muscle.mappedAngularVelocity;
				}
			}
			foreach (Muscle muscle2 in this.muscles)
			{
				if (!muscle2.state.isDisconnected)
				{
					muscle2.MoveToTarget();
				}
			}
			this.Read();
			if (this.blendTime > 0f)
			{
				while (this.mappingBlend < 1f)
				{
					this.mappingBlend = Mathf.Clamp(this.mappingBlend + Time.deltaTime / this.blendTime, 0f, 1f);
					yield return null;
				}
			}
			else
			{
				this.mappingBlend = 1f;
			}
			this.activeMode = PuppetMaster.Mode.Active;
			this.isSwitchingMode = false;
			yield break;
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00013AD9 File Offset: 0x00011CD9
		private IEnumerator ActiveToDisabled()
		{
			if (this.blendTime > 0f)
			{
				while (this.mappingBlend > 0f)
				{
					this.mappingBlend = Mathf.Max(this.mappingBlend - Time.deltaTime / this.blendTime, 0f);
					yield return null;
				}
			}
			else
			{
				this.mappingBlend = 0f;
			}
			foreach (Muscle muscle in this.muscles)
			{
				if (!muscle.state.isDisconnected)
				{
					muscle.rigidbody.gameObject.SetActive(false);
				}
			}
			this.activeMode = PuppetMaster.Mode.Disabled;
			this.isSwitchingMode = false;
			yield break;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00013AE8 File Offset: 0x00011CE8
		private IEnumerator ActiveToKinematic()
		{
			if (this.blendTime > 0f)
			{
				while (this.mappingBlend > 0f)
				{
					this.mappingBlend = Mathf.Max(this.mappingBlend - Time.deltaTime / this.blendTime, 0f);
					yield return null;
				}
			}
			else
			{
				this.mappingBlend = 0f;
			}
			foreach (Muscle muscle in this.muscles)
			{
				if (!muscle.state.isDisconnected)
				{
					muscle.SetKinematic(true);
				}
			}
			foreach (Muscle muscle2 in this.muscles)
			{
				if (!muscle2.state.isDisconnected)
				{
					muscle2.MoveToTarget();
				}
			}
			this.activeMode = PuppetMaster.Mode.Kinematic;
			this.isSwitchingMode = false;
			yield break;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00013AF8 File Offset: 0x00011CF8
		public void SetMuscleWeights(Muscle.Group group, float muscleWeight, float pinWeight = 1f, float mappingWeight = 1f, float muscleDamper = 1f)
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			foreach (Muscle muscle in this.muscles)
			{
				if (muscle.props.group == group)
				{
					muscle.props.muscleWeight = muscleWeight;
					muscle.props.pinWeight = pinWeight;
					muscle.props.mappingWeight = mappingWeight;
					muscle.props.muscleDamper = muscleDamper;
				}
			}
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00013B68 File Offset: 0x00011D68
		public void SetMuscleWeights(Transform target, float muscleWeight, float pinWeight = 1f, float mappingWeight = 1f, float muscleDamper = 1f)
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			int muscleIndex = this.GetMuscleIndex(target);
			if (muscleIndex == -1)
			{
				return;
			}
			this.SetMuscleWeights(muscleIndex, muscleWeight, pinWeight, mappingWeight, muscleDamper);
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00013B98 File Offset: 0x00011D98
		public void SetMuscleWeights(HumanBodyBones humanBodyBone, float muscleWeight, float pinWeight = 1f, float mappingWeight = 1f, float muscleDamper = 1f)
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			int muscleIndex = this.GetMuscleIndex(humanBodyBone);
			if (muscleIndex == -1)
			{
				return;
			}
			this.SetMuscleWeights(muscleIndex, muscleWeight, pinWeight, mappingWeight, muscleDamper);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00013BC8 File Offset: 0x00011DC8
		public void SetMuscleWeightsRecursive(Transform target, float muscleWeight, float pinWeight = 1f, float mappingWeight = 1f, float muscleDamper = 1f)
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (this.muscles[i].target == target)
				{
					this.SetMuscleWeightsRecursive(i, muscleWeight, pinWeight, mappingWeight, muscleDamper);
					return;
				}
			}
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00013C14 File Offset: 0x00011E14
		public void SetMuscleWeightsRecursive(int muscleIndex, float muscleWeight, float pinWeight = 1f, float mappingWeight = 1f, float muscleDamper = 1f)
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			this.SetMuscleWeights(muscleIndex, muscleWeight, pinWeight, mappingWeight, muscleDamper);
			for (int i = 0; i < this.muscles[muscleIndex].childIndexes.Length; i++)
			{
				int muscleIndex2 = this.muscles[muscleIndex].childIndexes[i];
				this.SetMuscleWeights(muscleIndex2, muscleWeight, pinWeight, mappingWeight, muscleDamper);
			}
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00013C70 File Offset: 0x00011E70
		public void SetMuscleWeightsRecursive(HumanBodyBones humanBodyBone, float muscleWeight, float pinWeight = 1f, float mappingWeight = 1f, float muscleDamper = 1f)
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			int muscleIndex = this.GetMuscleIndex(humanBodyBone);
			if (muscleIndex == -1)
			{
				return;
			}
			this.SetMuscleWeightsRecursive(muscleIndex, muscleWeight, pinWeight, mappingWeight, muscleDamper);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00013CA0 File Offset: 0x00011EA0
		public void SetMuscleWeights(int muscleIndex, float muscleWeight, float pinWeight, float mappingWeight, float muscleDamper)
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			if ((float)muscleIndex < 0f || muscleIndex >= this.muscles.Length)
			{
				Debug.LogWarning("Muscle index out of range (" + muscleIndex.ToString() + ").", base.transform);
				return;
			}
			this.muscles[muscleIndex].props.muscleWeight = muscleWeight;
			this.muscles[muscleIndex].props.pinWeight = pinWeight;
			this.muscles[muscleIndex].props.mappingWeight = mappingWeight;
			this.muscles[muscleIndex].props.muscleDamper = muscleDamper;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00013D3C File Offset: 0x00011F3C
		public Muscle GetMuscle(Transform target)
		{
			int muscleIndex = this.GetMuscleIndex(target);
			if (muscleIndex == -1)
			{
				return null;
			}
			return this.muscles[muscleIndex];
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00013D60 File Offset: 0x00011F60
		public Muscle GetMuscle(Rigidbody rigidbody)
		{
			int muscleIndex = this.GetMuscleIndex(rigidbody);
			if (muscleIndex == -1)
			{
				return null;
			}
			return this.muscles[muscleIndex];
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00013D84 File Offset: 0x00011F84
		public Muscle GetMuscle(ConfigurableJoint joint)
		{
			int muscleIndex = this.GetMuscleIndex(joint);
			if (muscleIndex == -1)
			{
				return null;
			}
			return this.muscles[muscleIndex];
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00013DA8 File Offset: 0x00011FA8
		public bool ContainsJoint(ConfigurableJoint joint)
		{
			if (!this.CheckIfInitiated())
			{
				return false;
			}
			Muscle[] array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].joint == joint)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00013DE8 File Offset: 0x00011FE8
		public int GetMuscleIndex(HumanBodyBones humanBodyBone)
		{
			if (!this.CheckIfInitiated())
			{
				return -1;
			}
			if (this.targetAnimator == null)
			{
				Debug.LogWarning("PuppetMaster 'Target Root' has no Animator component on it nor on its children.", base.transform);
				return -1;
			}
			if (!this.targetAnimator.isHuman)
			{
				Debug.LogWarning("PuppetMaster target's Animator does not belong to a Humanoid, can hot get human muscle index.", base.transform);
				return -1;
			}
			Transform boneTransform = this.targetAnimator.GetBoneTransform(humanBodyBone);
			if (boneTransform == null)
			{
				Debug.LogWarning("PuppetMaster target's Avatar does not contain a bone Transform for " + humanBodyBone.ToString(), base.transform);
				return -1;
			}
			return this.GetMuscleIndex(boneTransform);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00013E80 File Offset: 0x00012080
		public int GetMuscleIndex(Transform target)
		{
			if (!this.CheckIfInitiated())
			{
				return -1;
			}
			if (target == null)
			{
				Debug.LogWarning("Target is null, can not get muscle index.", base.transform);
				return -1;
			}
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (this.muscles[i].target == target)
				{
					return i;
				}
			}
			Debug.LogWarning("No muscle with target " + target.name + "found on the PuppetMaster.", base.transform);
			return -1;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00013F00 File Offset: 0x00012100
		public int GetMuscleIndex(Rigidbody rigidbody)
		{
			if (!this.CheckIfInitiated())
			{
				return -1;
			}
			if (rigidbody == null)
			{
				Debug.LogWarning("Rigidbody is null, can not get muscle index.", base.transform);
				return -1;
			}
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (this.muscles[i].rigidbody == rigidbody)
				{
					return i;
				}
			}
			Debug.LogWarning("No muscle with Rigidbody " + rigidbody.name + "found on the PuppetMaster.", base.transform);
			return -1;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00013F80 File Offset: 0x00012180
		public int GetMuscleIndex(ConfigurableJoint joint)
		{
			if (joint == null)
			{
				Debug.LogWarning("Joint is null, can not get muscle index.", base.transform);
				return -1;
			}
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (this.muscles[i].joint == joint)
				{
					return i;
				}
			}
			Debug.LogWarning("No muscle with Joint " + joint.name + "found on the PuppetMaster.", base.transform);
			return -1;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00013FF3 File Offset: 0x000121F3
		public static PuppetMaster SetUp(Transform target, Transform ragdoll, int characterControllerLayer, int ragdollLayer)
		{
			if (ragdoll != target)
			{
				PuppetMaster puppetMaster = ragdoll.gameObject.AddComponent<PuppetMaster>();
				puppetMaster.SetUpTo(target, characterControllerLayer, ragdollLayer);
				return puppetMaster;
			}
			return PuppetMaster.SetUp(ragdoll, characterControllerLayer, ragdollLayer);
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0001401B File Offset: 0x0001221B
		public static PuppetMaster SetUp(Transform target, int characterControllerLayer, int ragdollLayer)
		{
			PuppetMaster puppetMaster = Object.Instantiate<GameObject>(target.gameObject, target.position, target.rotation).transform.gameObject.AddComponent<PuppetMaster>();
			puppetMaster.SetUpTo(target, characterControllerLayer, ragdollLayer);
			PuppetMaster.RemoveRagdollComponents(target, characterControllerLayer);
			return puppetMaster;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00014054 File Offset: 0x00012254
		public static PuppetMaster SetUp(Transform target, int characterControllerLayer, int ragdollLayer, params BehaviourBase[] behaviourPrefabs)
		{
			Transform transform = Object.Instantiate<GameObject>(target.gameObject, target.position, target.rotation).transform;
			for (int i = 0; i < behaviourPrefabs.Length; i++)
			{
				Object.Instantiate<BehaviourBase>(behaviourPrefabs[i], transform);
			}
			PuppetMaster puppetMaster = transform.gameObject.AddComponent<PuppetMaster>();
			puppetMaster.SetUpTo(target, characterControllerLayer, ragdollLayer);
			PuppetMaster.RemoveRagdollComponents(target, characterControllerLayer);
			return puppetMaster;
		}

		// Token: 0x06000353 RID: 851 RVA: 0x000140B4 File Offset: 0x000122B4
		public void SetUpTo(Transform setUpTo, int characterControllerLayer, int ragdollLayer)
		{
			if (setUpTo == null)
			{
				Debug.LogWarning("SetUpTo is null. Can not set the PuppetMaster up to a null Transform.", base.transform);
				return;
			}
			if (setUpTo == base.transform)
			{
				setUpTo = Object.Instantiate<GameObject>(setUpTo.gameObject, setUpTo.position, setUpTo.rotation).transform;
				setUpTo.name = base.name;
				PuppetMaster.RemoveRagdollComponents(setUpTo, characterControllerLayer);
			}
			this.RemoveUnnecessaryBones();
			Component[] array = base.GetComponentsInChildren<Component>();
			for (int i = 0; i < array.Length; i++)
			{
				if (!(array[i] is PuppetMaster) && !(array[i] is Transform) && !(array[i] is Rigidbody) && !(array[i] is BoxCollider) && !(array[i] is CapsuleCollider) && !(array[i] is SphereCollider) && !(array[i] is MeshCollider) && !(array[i] is Joint) && !(array[i] is Animator))
				{
					Object.DestroyImmediate(array[i]);
				}
			}
			Animator[] componentsInChildren = base.GetComponentsInChildren<Animator>();
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				Object.DestroyImmediate(componentsInChildren[j]);
			}
			array = base.transform.GetComponents<Component>();
			for (int k = 0; k < array.Length; k++)
			{
				if (!(array[k] is PuppetMaster) && !(array[k] is Transform))
				{
					Object.DestroyImmediate(array[k]);
				}
			}
			foreach (Rigidbody rigidbody in base.transform.GetComponentsInChildren<Rigidbody>())
			{
				if (rigidbody.transform != base.transform && rigidbody.GetComponent<ConfigurableJoint>() == null)
				{
					rigidbody.gameObject.AddComponent<ConfigurableJoint>();
				}
			}
			this.targetRoot = setUpTo;
			this.SetUpMuscles(setUpTo);
			base.name = "PuppetMaster";
			Transform transform = (setUpTo.parent == null || setUpTo.parent != base.transform.parent || setUpTo.parent.name != setUpTo.name + " Root") ? new GameObject(setUpTo.name + " Root").transform : setUpTo.parent;
			transform.parent = base.transform.parent;
			Transform transform2 = new GameObject("Behaviours").transform;
			Comments comments = transform2.gameObject.GetComponent<Comments>();
			if (comments == null)
			{
				comments = transform2.gameObject.AddComponent<Comments>();
			}
			comments.text = "All Puppet Behaviours should be parented to this GameObject, the PuppetMaster will automatically find them from here. All Puppet Behaviours have been designed so that they could be simply copied from one character to another without changing any references. It is important because they contain a lot of parameters and would be otherwise tedious to set up and tweak.";
			transform.position = setUpTo.position;
			transform.rotation = setUpTo.rotation;
			transform2.position = setUpTo.position;
			transform2.rotation = setUpTo.rotation;
			base.transform.position = setUpTo.position;
			base.transform.rotation = setUpTo.rotation;
			transform2.parent = transform;
			base.transform.parent = transform;
			setUpTo.parent = transform;
			this.targetRoot.gameObject.layer = characterControllerLayer;
			Transform[] componentsInChildren3 = base.GetComponentsInChildren<Transform>();
			for (int l = 0; l < componentsInChildren3.Length; l++)
			{
				componentsInChildren3[l].gameObject.layer = ragdollLayer;
			}
			Physics.IgnoreLayerCollision(characterControllerLayer, ragdollLayer);
		}

		// Token: 0x06000354 RID: 852 RVA: 0x000143E4 File Offset: 0x000125E4
		public static void RemoveRagdollComponents(Transform target, int characterControllerLayer)
		{
			if (target == null)
			{
				return;
			}
			Rigidbody[] componentsInChildren = target.GetComponentsInChildren<Rigidbody>();
			Cloth[] componentsInChildren2 = target.GetComponentsInChildren<Cloth>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].gameObject != target.gameObject)
				{
					Joint component = componentsInChildren[i].GetComponent<Joint>();
					Collider component2 = componentsInChildren[i].GetComponent<Collider>();
					if (component != null)
					{
						Object.DestroyImmediate(component);
					}
					if (component2 != null)
					{
						if (!PuppetMaster.IsClothCollider(component2, componentsInChildren2))
						{
							Object.DestroyImmediate(component2);
						}
						else
						{
							component2.gameObject.layer = characterControllerLayer;
						}
					}
					Object.DestroyImmediate(componentsInChildren[i]);
				}
			}
			Collider[] componentsInChildren3 = target.GetComponentsInChildren<Collider>();
			for (int j = 0; j < componentsInChildren3.Length; j++)
			{
				if (componentsInChildren3[j].transform != target && !PuppetMaster.IsClothCollider(componentsInChildren3[j], componentsInChildren2))
				{
					Object.DestroyImmediate(componentsInChildren3[j]);
				}
			}
			PuppetMaster component3 = target.GetComponent<PuppetMaster>();
			if (component3 != null)
			{
				Object.DestroyImmediate(component3);
			}
		}

		// Token: 0x06000355 RID: 853 RVA: 0x000144E0 File Offset: 0x000126E0
		private void SetUpMuscles(Transform setUpTo)
		{
			ConfigurableJoint[] componentsInChildren = base.transform.GetComponentsInChildren<ConfigurableJoint>();
			if (componentsInChildren.Length == 0)
			{
				Debug.LogWarning("No ConfigurableJoints found, can not build PuppetMaster. Please create ConfigurableJoints to connect the ragdoll bones together.", base.transform);
				return;
			}
			Animator componentInChildren = this.targetRoot.GetComponentInChildren<Animator>();
			Transform[] componentsInChildren2 = setUpTo.GetComponentsInChildren<Transform>();
			this.muscles = new Muscle[componentsInChildren.Length];
			int num = -1;
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				this.muscles[i] = new Muscle();
				this.muscles[i].joint = componentsInChildren[i];
				this.muscles[i].name = componentsInChildren[i].name;
				this.muscles[i].props = new Muscle.Props(1f, 1f, 1f, 1f, Muscle.Group.Hips);
				if (this.muscles[i].joint.connectedBody == null && num == -1)
				{
					num = i;
				}
				Transform[] array = componentsInChildren2;
				int j = 0;
				while (j < array.Length)
				{
					Transform transform = array[j];
					if (transform.name == componentsInChildren[i].name)
					{
						this.muscles[i].target = transform;
						if (componentInChildren != null)
						{
							this.muscles[i].props.group = PuppetMaster.FindGroup(componentInChildren, this.muscles[i].target);
							break;
						}
						break;
					}
					else
					{
						j++;
					}
				}
			}
			if (num != 0)
			{
				Muscle muscle = this.muscles[0];
				Muscle muscle2 = this.muscles[num];
				this.muscles[num] = muscle;
				this.muscles[0] = muscle2;
			}
			bool flag = true;
			foreach (Muscle muscle3 in this.muscles)
			{
				if (muscle3.target == null)
				{
					Debug.LogWarning("No target Transform found for PuppetMaster muscle " + muscle3.joint.name + ". Please assign manually.", base.transform);
				}
				if (muscle3.props.group != this.muscles[0].props.group)
				{
					flag = false;
				}
			}
			if (flag)
			{
				Debug.LogWarning("Muscle groups need to be assigned in the PuppetMaster!", base.transform);
			}
		}

		// Token: 0x06000356 RID: 854 RVA: 0x000146FC File Offset: 0x000128FC
		private static Muscle.Group FindGroup(Animator animator, Transform t)
		{
			if (!animator.isHuman)
			{
				return Muscle.Group.Hips;
			}
			if (t == animator.GetBoneTransform(HumanBodyBones.Chest))
			{
				return Muscle.Group.Spine;
			}
			if (t == animator.GetBoneTransform(HumanBodyBones.Head))
			{
				return Muscle.Group.Head;
			}
			if (t == animator.GetBoneTransform(HumanBodyBones.Hips))
			{
				return Muscle.Group.Hips;
			}
			if (t == animator.GetBoneTransform(HumanBodyBones.LeftFoot))
			{
				return Muscle.Group.Foot;
			}
			if (t == animator.GetBoneTransform(HumanBodyBones.LeftHand))
			{
				return Muscle.Group.Hand;
			}
			if (t == animator.GetBoneTransform(HumanBodyBones.LeftLowerArm))
			{
				return Muscle.Group.Arm;
			}
			if (t == animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg))
			{
				return Muscle.Group.Leg;
			}
			if (t == animator.GetBoneTransform(HumanBodyBones.LeftUpperArm))
			{
				return Muscle.Group.Arm;
			}
			if (t == animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg))
			{
				return Muscle.Group.Leg;
			}
			if (t == animator.GetBoneTransform(HumanBodyBones.RightFoot))
			{
				return Muscle.Group.Foot;
			}
			if (t == animator.GetBoneTransform(HumanBodyBones.RightHand))
			{
				return Muscle.Group.Hand;
			}
			if (t == animator.GetBoneTransform(HumanBodyBones.RightLowerArm))
			{
				return Muscle.Group.Arm;
			}
			if (t == animator.GetBoneTransform(HumanBodyBones.RightLowerLeg))
			{
				return Muscle.Group.Leg;
			}
			if (t == animator.GetBoneTransform(HumanBodyBones.RightUpperArm))
			{
				return Muscle.Group.Arm;
			}
			if (t == animator.GetBoneTransform(HumanBodyBones.RightUpperLeg))
			{
				return Muscle.Group.Leg;
			}
			return Muscle.Group.Spine;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0001481C File Offset: 0x00012A1C
		private void RemoveUnnecessaryBones()
		{
			Transform[] componentsInChildren = base.GetComponentsInChildren<Transform>();
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				bool flag = false;
				if (componentsInChildren[i].GetComponent<Rigidbody>() != null || componentsInChildren[i].GetComponent<ConfigurableJoint>() != null)
				{
					flag = true;
				}
				if (componentsInChildren[i].GetComponent<Collider>() != null && componentsInChildren[i].GetComponent<Rigidbody>() == null)
				{
					flag = true;
				}
				if (componentsInChildren[i].GetComponent<CharacterController>() != null)
				{
					flag = false;
				}
				if (!flag)
				{
					Transform[] array = new Transform[componentsInChildren[i].childCount];
					for (int j = 0; j < array.Length; j++)
					{
						array[j] = componentsInChildren[i].GetChild(j);
					}
					for (int k = 0; k < array.Length; k++)
					{
						array[k].parent = componentsInChildren[i].parent;
					}
					Object.DestroyImmediate(componentsInChildren[i].gameObject);
				}
			}
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00014900 File Offset: 0x00012B00
		private static bool IsClothCollider(Collider collider, Cloth[] cloths)
		{
			if (cloths == null)
			{
				return false;
			}
			foreach (Cloth cloth in cloths)
			{
				if (cloth == null)
				{
					return false;
				}
				foreach (CapsuleCollider capsuleCollider in cloth.capsuleColliders)
				{
					if (capsuleCollider != null && capsuleCollider.gameObject == collider.gameObject)
					{
						return true;
					}
				}
				foreach (ClothSphereColliderPair clothSphereColliderPair in cloth.sphereColliders)
				{
					if (clothSphereColliderPair.first != null && clothSphereColliderPair.first.gameObject == collider.gameObject)
					{
						return true;
					}
					if (clothSphereColliderPair.second != null && clothSphereColliderPair.second.gameObject == collider.gameObject)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000359 RID: 857 RVA: 0x000149F1 File Offset: 0x00012BF1
		public bool isSwitchingState
		{
			get
			{
				return this.activeState != this.state;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600035A RID: 858 RVA: 0x00014A04 File Offset: 0x00012C04
		// (set) Token: 0x0600035B RID: 859 RVA: 0x00014A0C File Offset: 0x00012C0C
		public bool isKilling { get; private set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600035C RID: 860 RVA: 0x00014A15 File Offset: 0x00012C15
		public bool isAlive
		{
			get
			{
				return this.activeState == PuppetMaster.State.Alive;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600035D RID: 861 RVA: 0x00014A20 File Offset: 0x00012C20
		public bool isFrozen
		{
			get
			{
				return this.activeState == PuppetMaster.State.Frozen;
			}
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00014A2B File Offset: 0x00012C2B
		public void Kill()
		{
			this.state = PuppetMaster.State.Dead;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00014A34 File Offset: 0x00012C34
		public void Kill(PuppetMaster.StateSettings stateSettings)
		{
			this.stateSettings = stateSettings;
			this.state = PuppetMaster.State.Dead;
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00014A44 File Offset: 0x00012C44
		public void Freeze()
		{
			this.state = PuppetMaster.State.Frozen;
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00014A4D File Offset: 0x00012C4D
		public void Freeze(PuppetMaster.StateSettings stateSettings)
		{
			this.stateSettings = stateSettings;
			this.state = PuppetMaster.State.Frozen;
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00014A5D File Offset: 0x00012C5D
		public void Resurrect()
		{
			this.state = PuppetMaster.State.Alive;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00014A68 File Offset: 0x00012C68
		protected virtual void SwitchStates()
		{
			if (this.state == this.lastState)
			{
				return;
			}
			if (this.isKilling)
			{
				return;
			}
			if (this.freezeFlag)
			{
				if (this.state == PuppetMaster.State.Alive)
				{
					this.activeState = PuppetMaster.State.Dead;
					this.lastState = PuppetMaster.State.Dead;
					this.freezeFlag = false;
				}
				else if (this.state == PuppetMaster.State.Dead)
				{
					this.lastState = PuppetMaster.State.Dead;
					this.freezeFlag = false;
					return;
				}
				if (this.freezeFlag)
				{
					return;
				}
			}
			if (this.lastState == PuppetMaster.State.Alive)
			{
				if (this.state == PuppetMaster.State.Dead)
				{
					base.StartCoroutine(this.AliveToDead(false));
				}
				else if (this.state == PuppetMaster.State.Frozen)
				{
					base.StartCoroutine(this.AliveToDead(true));
				}
			}
			else if (this.lastState == PuppetMaster.State.Dead)
			{
				if (this.state == PuppetMaster.State.Alive)
				{
					this.DeadToAlive();
				}
				else if (this.state == PuppetMaster.State.Frozen)
				{
					this.DeadToFrozen();
				}
			}
			else if (this.lastState == PuppetMaster.State.Frozen)
			{
				if (this.state == PuppetMaster.State.Alive)
				{
					this.FrozenToAlive();
				}
				else if (this.state == PuppetMaster.State.Dead)
				{
					this.FrozenToDead();
				}
			}
			this.lastState = this.state;
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00014B6D File Offset: 0x00012D6D
		private IEnumerator AliveToDead(bool freeze)
		{
			this.isKilling = true;
			this.mode = PuppetMaster.Mode.Active;
			if (this.stateSettings.enableAngularLimitsOnKill && !this.angularLimits)
			{
				this.angularLimits = true;
				this.angularLimitsEnabledOnKill = true;
			}
			if (this.stateSettings.enableInternalCollisionsOnKill && !this.internalCollisions)
			{
				this.internalCollisions = true;
				this.internalCollisionsEnabledOnKill = true;
			}
			foreach (Muscle muscle in this.muscles)
			{
				if (!muscle.state.isDisconnected)
				{
					muscle.state.pinWeightMlp = 0f;
					muscle.state.muscleDamperAdd = this.stateSettings.deadMuscleDamper;
					muscle.rigidbody.velocity = muscle.mappedVelocity;
					muscle.rigidbody.angularVelocity = muscle.mappedAngularVelocity;
				}
			}
			float range = this.muscles[0].state.muscleWeightMlp - this.stateSettings.deadMuscleWeight;
			BehaviourBase[] array2 = this.behaviours;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].KillStart();
			}
			Muscle[] array;
			if (this.stateSettings.killDuration > 0f && range > 0f)
			{
				float mW = this.muscles[0].state.muscleWeightMlp;
				while (mW > this.stateSettings.deadMuscleWeight)
				{
					mW = Mathf.Max(mW - Time.deltaTime * (range / this.stateSettings.killDuration), this.stateSettings.deadMuscleWeight);
					array = this.muscles;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].state.muscleWeightMlp = mW;
					}
					yield return null;
				}
			}
			array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].state.muscleWeightMlp = this.stateSettings.deadMuscleWeight;
			}
			this.SetAnimationEnabled(false);
			this.isKilling = false;
			this.activeState = PuppetMaster.State.Dead;
			if (freeze)
			{
				this.freezeFlag = true;
			}
			array2 = this.behaviours;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].KillEnd();
			}
			if (this.OnDeath != null)
			{
				this.OnDeath();
			}
			yield break;
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00014B84 File Offset: 0x00012D84
		private void OnFreezeFlag()
		{
			if (!this.CanFreeze())
			{
				return;
			}
			this.SetAnimationEnabled(false);
			Muscle[] array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].joint.gameObject.SetActive(false);
			}
			foreach (BehaviourBase behaviourBase in this.behaviours)
			{
				behaviourBase.Freeze();
				if (behaviourBase.gameObject.activeSelf)
				{
					behaviourBase.deactivated = true;
					behaviourBase.gameObject.SetActive(false);
				}
			}
			this.freezeFlag = false;
			this.activeState = PuppetMaster.State.Frozen;
			if (this.OnFreeze != null)
			{
				this.OnFreeze();
			}
			if (this.stateSettings.freezePermanently)
			{
				if (this.behaviours.Length != 0 && this.behaviours[0] != null)
				{
					Object.Destroy(this.behaviours[0].transform.parent.gameObject);
				}
				Object.Destroy(base.gameObject);
			}
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00014C78 File Offset: 0x00012E78
		private void DeadToAlive()
		{
			foreach (Muscle muscle in this.muscles)
			{
				muscle.state.pinWeightMlp = 1f;
				muscle.state.muscleWeightMlp = 1f;
				muscle.state.muscleDamperAdd = 0f;
			}
			if (this.angularLimitsEnabledOnKill)
			{
				this.angularLimits = false;
				this.angularLimitsEnabledOnKill = false;
			}
			if (this.internalCollisionsEnabledOnKill)
			{
				this.internalCollisions = false;
				this.internalCollisionsEnabledOnKill = false;
			}
			BehaviourBase[] array2 = this.behaviours;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Resurrect();
			}
			this.SetAnimationEnabled(true);
			this.activeState = PuppetMaster.State.Alive;
			if (this.OnResurrection != null)
			{
				this.OnResurrection();
			}
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00014D36 File Offset: 0x00012F36
		private void SetAnimationEnabled(bool to)
		{
			this.animatorDisabled = false;
			if (this.targetAnimator != null)
			{
				this.targetAnimator.enabled = to;
			}
			if (this.targetAnimation != null)
			{
				this.targetAnimation.enabled = to;
			}
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00014D73 File Offset: 0x00012F73
		private void DeadToFrozen()
		{
			this.freezeFlag = true;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00014D7C File Offset: 0x00012F7C
		private void FrozenToAlive()
		{
			this.freezeFlag = false;
			foreach (Muscle muscle in this.muscles)
			{
				muscle.state.pinWeightMlp = 1f;
				muscle.state.muscleWeightMlp = 1f;
				muscle.state.muscleDamperAdd = 0f;
			}
			if (this.angularLimitsEnabledOnKill)
			{
				this.angularLimits = false;
				this.angularLimitsEnabledOnKill = false;
			}
			if (this.internalCollisionsEnabledOnKill)
			{
				this.internalCollisions = false;
				this.internalCollisionsEnabledOnKill = false;
			}
			this.ActivateRagdoll(false);
			foreach (BehaviourBase behaviourBase in this.behaviours)
			{
				behaviourBase.Unfreeze();
				behaviourBase.Resurrect();
				if (behaviourBase.deactivated)
				{
					behaviourBase.gameObject.SetActive(true);
				}
			}
			if (this.targetAnimator != null)
			{
				this.targetAnimator.enabled = true;
			}
			if (this.targetAnimation != null)
			{
				this.targetAnimation.enabled = true;
			}
			this.activeState = PuppetMaster.State.Alive;
			if (this.OnUnfreeze != null)
			{
				this.OnUnfreeze();
			}
			if (this.OnResurrection != null)
			{
				this.OnResurrection();
			}
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00014EA4 File Offset: 0x000130A4
		private void FrozenToDead()
		{
			this.freezeFlag = false;
			this.ActivateRagdoll(false);
			foreach (BehaviourBase behaviourBase in this.behaviours)
			{
				behaviourBase.Unfreeze();
				if (behaviourBase.deactivated)
				{
					behaviourBase.gameObject.SetActive(true);
				}
			}
			this.activeState = PuppetMaster.State.Dead;
			if (this.OnUnfreeze != null)
			{
				this.OnUnfreeze();
			}
		}

		// Token: 0x0600036B RID: 875 RVA: 0x00014F0C File Offset: 0x0001310C
		private void ActivateRagdoll(bool kinematic = false)
		{
			Muscle[] array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Reset();
			}
			foreach (Muscle muscle in this.muscles)
			{
				muscle.joint.gameObject.SetActive(true);
				if (kinematic)
				{
					muscle.rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
				}
				muscle.SetKinematic(kinematic);
				muscle.rigidbody.velocity = Vector3.zero;
				muscle.rigidbody.angularVelocity = Vector3.zero;
			}
			this.FlagInternalCollisionsForUpdate();
			this.Read();
			array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].MoveToTarget();
			}
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00014FC0 File Offset: 0x000131C0
		private bool CanFreeze()
		{
			Muscle[] array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].rigidbody.velocity.sqrMagnitude > this.stateSettings.maxFreezeSqrVelocity)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00015008 File Offset: 0x00013208
		public void SampleTargetMappedState()
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			this.sampleTargetMappedState = true;
			if (!this.targetMappedStateStored)
			{
				this.sampleTargetMappedState = true;
				return;
			}
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (i == 0)
				{
					this.muscles[i].targetSampledPosition = this.muscles[i].targetMappedPosition;
				}
				this.muscles[i].targetSampledRotation = this.muscles[i].targetMappedRotation;
			}
			this.targetMappedStateSampled = true;
		}

		// Token: 0x0600036E RID: 878 RVA: 0x00015088 File Offset: 0x00013288
		public void FixTargetToSampledState(float weight)
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			if (weight <= 0f)
			{
				return;
			}
			if (!this.targetMappedStateSampled)
			{
				return;
			}
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (i == 0)
				{
					this.muscles[i].target.position = Vector3.Lerp(this.muscles[i].target.position, this.muscles[i].targetSampledPosition, weight);
				}
				this.muscles[i].target.rotation = Quaternion.Lerp(this.muscles[i].target.rotation, this.muscles[i].targetSampledRotation, weight);
			}
			foreach (Muscle muscle in this.muscles)
			{
				muscle.positionOffset = muscle.target.position - muscle.rigidbody.position;
			}
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00015170 File Offset: 0x00013370
		public void StoreTargetMappedState()
		{
			if (!this.CheckIfInitiated())
			{
				return;
			}
			if (!this.storeTargetMappedState)
			{
				return;
			}
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (i == 0)
				{
					this.muscles[i].StoreTargetMappedPosition();
				}
				this.muscles[i].StoreTargetMappedRotation();
			}
			this.targetMappedStateStored = true;
			if (this.sampleTargetMappedState)
			{
				this.SampleTargetMappedState();
			}
			this.sampleTargetMappedState = false;
		}

		// Token: 0x06000370 RID: 880 RVA: 0x000151DC File Offset: 0x000133DC
		private void UpdateHierarchies()
		{
			for (int i = 0; i < this.muscles.Length; i++)
			{
				this.muscles[i].index = i;
				if (this.muscles[i].broadcaster != null)
				{
					this.muscles[i].broadcaster.muscleIndex = i;
				}
				if (this.muscles[i].jointBreakBroadcaster != null)
				{
					this.muscles[i].jointBreakBroadcaster.muscleIndex = i;
				}
			}
			this.targetMappedStateStored = false;
			this.targetMappedStateSampled = false;
			this.AssignParentAndChildIndexes();
			this.AssignKinshipDegrees();
			this.UpdateBroadcasterMuscleIndexes();
			if (this.disconnectMuscleFlags.Length != this.muscles.Length)
			{
				Array.Resize<bool>(ref this.disconnectMuscleFlags, this.muscles.Length);
				Array.Resize<MuscleDisconnectMode>(ref this.muscleDisconnectModes, this.muscles.Length);
				Array.Resize<bool>(ref this.disconnectDeactivateFlags, this.muscles.Length);
				Array.Resize<bool>(ref this.reconnectMuscleFlags, this.muscles.Length);
			}
			this.propMuscles = base.GetComponentsInChildren<PropMuscle>();
			this.hasProp = this.HasProp();
			if (this.OnHierarchyChanged != null)
			{
				this.OnHierarchyChanged();
			}
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00015304 File Offset: 0x00013504
		private bool HasProp()
		{
			Muscle[] array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].props.group == Muscle.Group.Prop)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0001533C File Offset: 0x0001353C
		private void UpdateBroadcasterMuscleIndexes()
		{
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (this.muscles[i].broadcaster != null)
				{
					this.muscles[i].broadcaster.muscleIndex = i;
				}
				if (this.muscles[i].jointBreakBroadcaster != null)
				{
					this.muscles[i].jointBreakBroadcaster.muscleIndex = i;
				}
			}
		}

		// Token: 0x06000373 RID: 883 RVA: 0x000153AC File Offset: 0x000135AC
		private void AssignParentAndChildIndexes()
		{
			for (int i = 0; i < this.muscles.Length; i++)
			{
				this.muscles[i].parentIndexes = new int[0];
				if (this.muscles[i].joint.connectedBody != null)
				{
					this.AddToParentsRecursive(this.muscles[i].joint.connectedBody.GetComponent<ConfigurableJoint>(), ref this.muscles[i].parentIndexes);
				}
				this.muscles[i].childIndexes = new int[0];
				this.muscles[i].childFlags = new bool[this.muscles.Length];
				for (int j = 0; j < this.muscles.Length; j++)
				{
					if (i != j && this.muscles[j].joint.connectedBody == this.muscles[i].rigidbody)
					{
						this.AddToChildrenRecursive(this.muscles[j].joint, ref this.muscles[i].childIndexes, ref this.muscles[i].childFlags);
					}
				}
			}
		}

		// Token: 0x06000374 RID: 884 RVA: 0x000154C0 File Offset: 0x000136C0
		private void AddToParentsRecursive(ConfigurableJoint joint, ref int[] indexes)
		{
			if (joint == null)
			{
				return;
			}
			int muscleIndexLowLevel = this.GetMuscleIndexLowLevel(joint);
			if (muscleIndexLowLevel == -1)
			{
				return;
			}
			Array.Resize<int>(ref indexes, indexes.Length + 1);
			indexes[indexes.Length - 1] = muscleIndexLowLevel;
			if (joint.connectedBody == null)
			{
				return;
			}
			this.AddToParentsRecursive(joint.connectedBody.GetComponent<ConfigurableJoint>(), ref indexes);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0001551C File Offset: 0x0001371C
		private void AddToChildrenRecursive(ConfigurableJoint joint, ref int[] indexes, ref bool[] childFlags)
		{
			if (joint == null)
			{
				return;
			}
			int muscleIndexLowLevel = this.GetMuscleIndexLowLevel(joint);
			if (muscleIndexLowLevel == -1)
			{
				return;
			}
			Array.Resize<int>(ref indexes, indexes.Length + 1);
			indexes[indexes.Length - 1] = muscleIndexLowLevel;
			childFlags[muscleIndexLowLevel] = true;
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (i != muscleIndexLowLevel && this.muscles[i].joint.connectedBody == joint.GetComponent<Rigidbody>())
				{
					this.AddToChildrenRecursive(this.muscles[i].joint, ref indexes, ref childFlags);
				}
			}
		}

		// Token: 0x06000376 RID: 886 RVA: 0x000155A8 File Offset: 0x000137A8
		private void AssignKinshipDegrees()
		{
			for (int i = 0; i < this.muscles.Length; i++)
			{
				this.muscles[i].kinshipDegrees = new int[this.muscles.Length];
				this.AssignKinshipsDownRecursive(ref this.muscles[i].kinshipDegrees, 1, i);
				this.AssignKinshipsUpRecursive(ref this.muscles[i].kinshipDegrees, 1, i);
			}
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0001560C File Offset: 0x0001380C
		private void AssignKinshipsDownRecursive(ref int[] kinshipDegrees, int degree, int index)
		{
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (i != index && this.muscles[i].joint.connectedBody == this.muscles[index].rigidbody)
				{
					kinshipDegrees[i] = degree;
					this.AssignKinshipsDownRecursive(ref kinshipDegrees, degree + 1, i);
				}
			}
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00015668 File Offset: 0x00013868
		private void AssignKinshipsUpRecursive(ref int[] kinshipDegrees, int degree, int index)
		{
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (i != index && this.muscles[i].rigidbody == this.muscles[index].joint.connectedBody)
				{
					kinshipDegrees[i] = degree;
					this.AssignKinshipsUpRecursive(ref kinshipDegrees, degree + 1, i);
					for (int j = 0; j < this.muscles.Length; j++)
					{
						if (j != i && j != index && this.muscles[j].joint.connectedBody == this.muscles[i].rigidbody)
						{
							kinshipDegrees[j] = degree + 1;
							this.AssignKinshipsDownRecursive(ref kinshipDegrees, degree + 2, j);
						}
					}
				}
			}
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00015720 File Offset: 0x00013920
		private int GetMuscleIndexLowLevel(ConfigurableJoint joint)
		{
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (this.muscles[i].joint == joint)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600037A RID: 890 RVA: 0x00015758 File Offset: 0x00013958
		public bool IsValid(bool log)
		{
			if (this.muscles == null)
			{
				if (log)
				{
					Debug.LogError("PuppetMaster Muscles is null.", base.transform);
				}
				return false;
			}
			if (this.muscles.Length == 0)
			{
				if (log)
				{
					Debug.LogError("PuppetMaster has no muscles.", base.transform);
				}
				return false;
			}
			for (int i = 0; i < this.muscles.Length; i++)
			{
				if (this.muscles[i] == null)
				{
					if (log)
					{
						Debug.LogError("Muscle is null, PuppetMaster muscle setup is invalid.", base.transform);
					}
					return false;
				}
				if (!this.muscles[i].IsValid(log))
				{
					return false;
				}
			}
			if (this.targetRoot == null)
			{
				if (log)
				{
					Debug.LogError("'Target Root' of PuppetMaster is null.");
				}
				return false;
			}
			base.transform.position = this.targetRoot.position;
			foreach (Muscle muscle in this.muscles)
			{
				muscle.joint.transform.SetPositionAndRotation(muscle.target.position, muscle.target.rotation);
			}
			Physics.SyncTransforms();
			if (this.muscles[0].joint.connectedBody != null && this.muscles.Length > 1)
			{
				for (int k = 1; k < this.muscles.Length; k++)
				{
					if (this.muscles[k].joint.GetComponent<Rigidbody>() == this.muscles[0].joint.connectedBody)
					{
						if (log)
						{
							Debug.LogError("The first muscle needs to be the one that all the others are connected to (the hips).", base.transform);
						}
						return false;
					}
				}
			}
			for (int l = 0; l < this.muscles.Length; l++)
			{
				if (Vector3.SqrMagnitude(this.muscles[l].joint.transform.position - this.muscles[l].target.position) > 0.001f)
				{
					if (log)
					{
						Debug.LogError("The position of each muscle needs to match with the position of its target. Muscle '" + this.muscles[l].joint.name + "' position does not match with its target. Right-click on the PuppetMaster component's header and select 'Fix Muscle Positions' from the context menu.", this.muscles[l].joint.transform);
					}
					return false;
				}
			}
			this.CheckMassVariation(100f, true);
			return true;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00015980 File Offset: 0x00013B80
		private bool CheckMassVariation(float threshold, bool log)
		{
			float num = float.PositiveInfinity;
			float num2 = 0f;
			for (int i = 0; i < this.muscles.Length; i++)
			{
				float mass = this.muscles[i].joint.GetComponent<Rigidbody>().mass;
				if (mass < num)
				{
					num = mass;
				}
				if (mass > num2)
				{
					num2 = mass;
				}
			}
			if (num2 / num > threshold)
			{
				if (log)
				{
					Debug.LogWarning(string.Concat(new string[]
					{
						"Mass variation between the Rigidbodies in the ragdoll is more than ",
						threshold.ToString(),
						" times. This might cause instability and unwanted results with Rigidbodies connected by Joints. Min mass: ",
						num.ToString(),
						", max mass: ",
						num2.ToString()
					}), base.transform);
				}
				return false;
			}
			return true;
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00015A28 File Offset: 0x00013C28
		private bool CheckIfInitiated()
		{
			if (!this.initiated)
			{
				Debug.LogError("PuppetMaster has not been initiated yet.");
			}
			return this.initiated;
		}

		// Token: 0x040002A2 RID: 674
		[Tooltip("Humanoid Config allows you to easily share PuppetMaster properties, including individual muscle props between Humanoid puppets.")]
		public PuppetMasterHumanoidConfig humanoidConfig;

		// Token: 0x040002A3 RID: 675
		public Transform targetRoot;

		// Token: 0x040002A4 RID: 676
		[LargeHeader("Simulation")]
		[Tooltip("Sets/sets the state of the puppet (Alive, Dead or Frozen). Frozen means the ragdoll will be deactivated once it comes to stop in dead state.")]
		public PuppetMaster.State state;

		// Token: 0x040002A5 RID: 677
		[ContextMenuItem("Reset To Default", "ResetStateSettings")]
		[Tooltip("Settings for killing and freezing the puppet.")]
		public PuppetMaster.StateSettings stateSettings = PuppetMaster.StateSettings.Default;

		// Token: 0x040002A6 RID: 678
		[Tooltip("Active mode means all muscles are active and the character is physically simulated. Kinematic mode sets rigidbody.isKinematic to true for all the muscles and simply updates their position/rotation to match the target's. Disabled mode disables the ragdoll. Switching modes is done by simply changing this value, blending in/out will be handled automatically by the PuppetMaster.")]
		public PuppetMaster.Mode mode;

		// Token: 0x040002A7 RID: 679
		[Tooltip("The time of blending when switching from Active to Kinematic/Disabled or from Kinematic/Disabled to Active. Switching from Kinematic to Disabled or vice versa will be done instantly.")]
		public float blendTime = 0.1f;

		// Token: 0x040002A8 RID: 680
		[Tooltip("If true, will fix the target character's Transforms to their default local positions and rotations in each update cycle to avoid drifting from additive reading-writing. Use this only if the target contains unanimated bones.")]
		public bool fixTargetTransforms = true;

		// Token: 0x040002A9 RID: 681
		[Tooltip("Rigidbody.solverIterationCount for the muscles of this Puppet.")]
		public int solverIterationCount = 6;

		// Token: 0x040002AA RID: 682
		[Tooltip("If true, will draw the target's pose as green lines in the Scene view. This runs in the Editor only. If you wish to profile PuppetMaster, switch this off.")]
		public bool visualizeTargetPose = true;

		// Token: 0x040002AB RID: 683
		[LargeHeader("Master Weights")]
		[Tooltip("The weight of mapping the animated character to the ragdoll pose.")]
		[Range(0f, 1f)]
		public float mappingWeight = 1f;

		// Token: 0x040002AC RID: 684
		[Tooltip("The weight of pinning the muscles to the position of their animated targets using simple AddForce.")]
		[Range(0f, 1f)]
		public float pinWeight = 1f;

		// Token: 0x040002AD RID: 685
		[Tooltip("The normalized strength of the muscles.")]
		[Range(0f, 1f)]
		public float muscleWeight = 1f;

		// Token: 0x040002AE RID: 686
		[LargeHeader("Joint and Muscle Settings")]
		[Tooltip("The positionSpring of the ConfigurableJoints' Slerp Drive.")]
		public float muscleSpring = 100f;

		// Token: 0x040002AF RID: 687
		[Tooltip("The positionDamper of the ConfigurableJoints' Slerp Drive.")]
		public float muscleDamper;

		// Token: 0x040002B0 RID: 688
		[Tooltip("Adjusts the slope of the pinWeight curve. Has effect only while interpolating pinWeight from 0 to 1 and back.")]
		[Range(1f, 8f)]
		public float pinPow = 4f;

		// Token: 0x040002B1 RID: 689
		[Tooltip("Reduces pinning force the farther away the target is. Bigger value loosens the pinning, resulting in sloppier behaviour.")]
		[Range(0f, 100f)]
		public float pinDistanceFalloff = 5f;

		// Token: 0x040002B2 RID: 690
		[Tooltip("If disabled, only world space AddForce will be used to pin the ragdoll to the animation while 'Pin Weight' > 0. If enabled, AddTorque will also be used for rotational pinning. Keep it disabled if you don't see any noticeable improvement from it to avoid wasting CPU resources.")]
		public bool angularPinning;

		// Token: 0x040002B3 RID: 691
		[Tooltip("When the target has animated bones between the muscle bones, the joint anchors need to be updated in every update cycle because the muscles' targets move relative to each other in position space. This gives much more accurate results, but is computationally expensive so consider leaving it off.")]
		public bool updateJointAnchors = true;

		// Token: 0x040002B4 RID: 692
		[Tooltip("Enable this if any of the target's bones has translation animation.")]
		public bool supportTranslationAnimation;

		// Token: 0x040002B5 RID: 693
		[Tooltip("Should the joints use angular limits? If the PuppetMaster fails to match the target's pose, it might be because the joint limits are too stiff and do not allow for such motion. Uncheck this to see if the limits are clamping the range of your puppet's animation. Since the joints are actuated, most PuppetMaster simulations will not actually require using joint limits at all.")]
		public bool angularLimits;

		// Token: 0x040002B6 RID: 694
		[Tooltip("Should the muscles collide with each other? Consider leaving this off while the puppet is pinned for performance and better accuracy.  Since the joints are actuated, most PuppetMaster simulations will not actually require internal collisions at all.")]
		public bool internalCollisions;

		// Token: 0x040002B7 RID: 695
		[LargeHeader("Individual Muscle Settings")]
		[Tooltip("The Muscles managed by this PuppetMaster.")]
		public Muscle[] muscles = new Muscle[0];

		// Token: 0x040002B8 RID: 696
		[HideInInspector]
		public PropMuscle[] propMuscles = new PropMuscle[0];

		// Token: 0x040002B9 RID: 697
		public PuppetMaster.UpdateDelegate OnPostInitiate;

		// Token: 0x040002BA RID: 698
		public PuppetMaster.UpdateDelegate OnRead;

		// Token: 0x040002BB RID: 699
		public PuppetMaster.UpdateDelegate OnWrite;

		// Token: 0x040002BC RID: 700
		public PuppetMaster.UpdateDelegate OnPostLateUpdate;

		// Token: 0x040002BD RID: 701
		public PuppetMaster.UpdateDelegate OnFixTransforms;

		// Token: 0x040002BE RID: 702
		public PuppetMaster.UpdateDelegate OnHierarchyChanged;

		// Token: 0x040002BF RID: 703
		public PuppetMaster.MuscleDelegate OnMuscleRemoved;

		// Token: 0x040002C0 RID: 704
		public PuppetMaster.MuscleDelegate OnMuscleDisconnected;

		// Token: 0x040002C1 RID: 705
		public PuppetMaster.MuscleDelegate OnMuscleReconnected;

		// Token: 0x040002C2 RID: 706
		private Animator _targetAnimator;

		// Token: 0x040002C4 RID: 708
		[HideInInspector]
		[NonSerialized]
		public BehaviourBase[] behaviours = new BehaviourBase[0];

		// Token: 0x040002C6 RID: 710
		[HideInInspector]
		public List<SolverManager> solvers = new List<SolverManager>();

		// Token: 0x040002C7 RID: 711
		[HideInInspector]
		[NonSerialized]
		public bool manualInternalCollisionControl;

		// Token: 0x040002C8 RID: 712
		[HideInInspector]
		[NonSerialized]
		public bool manualAngularLimitControl;

		// Token: 0x040002C9 RID: 713
		[HideInInspector]
		public bool mapDisconnectedMuscles = true;

		// Token: 0x040002CA RID: 714
		private bool internalCollisionsEnabled = true;

		// Token: 0x040002CB RID: 715
		private bool angularLimitsEnabled = true;

		// Token: 0x040002CC RID: 716
		private bool fixedFrame;

		// Token: 0x040002CD RID: 717
		private int lastSolverIterationCount;

		// Token: 0x040002CE RID: 718
		private bool isLegacy;

		// Token: 0x040002CF RID: 719
		private bool animatorDisabled;

		// Token: 0x040002D0 RID: 720
		private bool awakeFailed;

		// Token: 0x040002D1 RID: 721
		private bool interpolated;

		// Token: 0x040002D2 RID: 722
		private bool freezeFlag;

		// Token: 0x040002D3 RID: 723
		private bool hasBeenDisabled;

		// Token: 0x040002D4 RID: 724
		private bool hierarchyIsFlat;

		// Token: 0x040002D5 RID: 725
		private bool teleport;

		// Token: 0x040002D6 RID: 726
		private Vector3 teleportPosition;

		// Token: 0x040002D7 RID: 727
		private Quaternion teleportRotation = Quaternion.identity;

		// Token: 0x040002D8 RID: 728
		private bool teleportMoveToTarget;

		// Token: 0x040002D9 RID: 729
		private bool rebuildFlag;

		// Token: 0x040002DA RID: 730
		private bool onPostRebuildFlag;

		// Token: 0x040002DB RID: 731
		private bool[] disconnectMuscleFlags = new bool[0];

		// Token: 0x040002DC RID: 732
		private MuscleDisconnectMode[] muscleDisconnectModes = new MuscleDisconnectMode[0];

		// Token: 0x040002DD RID: 733
		private bool[] disconnectDeactivateFlags = new bool[0];

		// Token: 0x040002DE RID: 734
		private bool[] reconnectMuscleFlags = new bool[0];

		// Token: 0x040002DF RID: 735
		private Muscle[] defaultMuscles = new Muscle[0];

		// Token: 0x040002E0 RID: 736
		private Vector3 rebuildPelvisPos;

		// Token: 0x040002E1 RID: 737
		private Quaternion rebuildPelvisRot = Quaternion.identity;

		// Token: 0x040002E2 RID: 738
		private float simulationDeltaTime;

		// Token: 0x040002E3 RID: 739
		private bool readInFixedUpdate;

		// Token: 0x040002E5 RID: 741
		private PuppetMaster.Mode activeMode;

		// Token: 0x040002E6 RID: 742
		private PuppetMaster.Mode lastMode;

		// Token: 0x040002E7 RID: 743
		private float mappingBlend = 1f;

		// Token: 0x040002E9 RID: 745
		public PuppetMaster.UpdateDelegate OnFreeze;

		// Token: 0x040002EA RID: 746
		public PuppetMaster.UpdateDelegate OnUnfreeze;

		// Token: 0x040002EB RID: 747
		public PuppetMaster.UpdateDelegate OnDeath;

		// Token: 0x040002EC RID: 748
		public PuppetMaster.UpdateDelegate OnResurrection;

		// Token: 0x040002ED RID: 749
		private PuppetMaster.State activeState;

		// Token: 0x040002EE RID: 750
		private PuppetMaster.State lastState;

		// Token: 0x040002EF RID: 751
		private bool angularLimitsEnabledOnKill;

		// Token: 0x040002F0 RID: 752
		private bool internalCollisionsEnabledOnKill;

		// Token: 0x040002F1 RID: 753
		private bool animationDisabledbyStates;

		// Token: 0x040002F2 RID: 754
		[HideInInspector]
		public bool storeTargetMappedState = true;

		// Token: 0x040002F3 RID: 755
		private bool targetMappedStateStored;

		// Token: 0x040002F4 RID: 756
		private bool targetMappedStateSampled;

		// Token: 0x040002F5 RID: 757
		private bool sampleTargetMappedState;

		// Token: 0x040002F6 RID: 758
		private bool hasProp;

		// Token: 0x02000064 RID: 100
		[Serializable]
		public enum Mode
		{
			// Token: 0x040002F8 RID: 760
			Active,
			// Token: 0x040002F9 RID: 761
			Kinematic,
			// Token: 0x040002FA RID: 762
			Disabled
		}

		// Token: 0x02000065 RID: 101
		// (Invoke) Token: 0x0600037F RID: 895
		public delegate void UpdateDelegate();

		// Token: 0x02000066 RID: 102
		// (Invoke) Token: 0x06000383 RID: 899
		public delegate void MuscleDelegate(Muscle muscle);

		// Token: 0x02000067 RID: 103
		[Serializable]
		public enum UpdateMode
		{
			// Token: 0x040002FC RID: 764
			Normal,
			// Token: 0x040002FD RID: 765
			AnimatePhysics,
			// Token: 0x040002FE RID: 766
			FixedUpdate
		}

		// Token: 0x02000068 RID: 104
		[Serializable]
		public enum State
		{
			// Token: 0x04000300 RID: 768
			Alive,
			// Token: 0x04000301 RID: 769
			Dead,
			// Token: 0x04000302 RID: 770
			Frozen
		}

		// Token: 0x02000069 RID: 105
		[Serializable]
		public struct StateSettings
		{
			// Token: 0x06000386 RID: 902 RVA: 0x00015B73 File Offset: 0x00013D73
			public StateSettings(float killDuration, float deadMuscleWeight = 0.01f, float deadMuscleDamper = 2f, float maxFreezeSqrVelocity = 0.02f, bool freezePermanently = false, bool enableAngularLimitsOnKill = true, bool enableInternalCollisionsOnKill = true)
			{
				this.killDuration = killDuration;
				this.deadMuscleWeight = deadMuscleWeight;
				this.deadMuscleDamper = deadMuscleDamper;
				this.maxFreezeSqrVelocity = maxFreezeSqrVelocity;
				this.freezePermanently = freezePermanently;
				this.enableAngularLimitsOnKill = enableAngularLimitsOnKill;
				this.enableInternalCollisionsOnKill = enableInternalCollisionsOnKill;
			}

			// Token: 0x1700005A RID: 90
			// (get) Token: 0x06000387 RID: 903 RVA: 0x00015BAA File Offset: 0x00013DAA
			public static PuppetMaster.StateSettings Default
			{
				get
				{
					return new PuppetMaster.StateSettings(1f, 0.01f, 2f, 0.02f, false, true, true);
				}
			}

			// Token: 0x04000303 RID: 771
			[Tooltip("How much does it take to weigh out muscle weight to deadMuscleWeight?")]
			public float killDuration;

			// Token: 0x04000304 RID: 772
			[Tooltip("The muscle weight mlp while the puppet is Dead.")]
			public float deadMuscleWeight;

			// Token: 0x04000305 RID: 773
			[Tooltip("The muscle damper add while the puppet is Dead.")]
			public float deadMuscleDamper;

			// Token: 0x04000306 RID: 774
			[Tooltip("The max square velocity of the ragdoll bones for freezing the puppet.")]
			public float maxFreezeSqrVelocity;

			// Token: 0x04000307 RID: 775
			[Tooltip("If true, PuppetMaster, all its behaviours and the ragdoll will be destroyed when the puppet is frozen.")]
			public bool freezePermanently;

			// Token: 0x04000308 RID: 776
			[Tooltip("If true, will enable angular limits when killing the puppet.")]
			public bool enableAngularLimitsOnKill;

			// Token: 0x04000309 RID: 777
			[Tooltip("If true, will enable internal collisions when killing the puppet.")]
			public bool enableInternalCollisionsOnKill;
		}
	}
}
