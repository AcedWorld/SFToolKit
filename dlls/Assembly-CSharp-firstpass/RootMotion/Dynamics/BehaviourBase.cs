using System;
using UnityEngine;
using UnityEngine.Events;

namespace RootMotion.Dynamics
{
	// Token: 0x02000039 RID: 57
	public abstract class BehaviourBase : MonoBehaviour
	{
		// Token: 0x0600015E RID: 350
		public abstract void OnReactivate();

		// Token: 0x0600015F RID: 351 RVA: 0x0000223E File Offset: 0x0000043E
		public virtual void Resurrect()
		{
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000223E File Offset: 0x0000043E
		public virtual void Freeze()
		{
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000223E File Offset: 0x0000043E
		public virtual void Unfreeze()
		{
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000223E File Offset: 0x0000043E
		public virtual void KillStart()
		{
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000223E File Offset: 0x0000043E
		public virtual void KillEnd()
		{
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000223E File Offset: 0x0000043E
		public virtual void OnTeleport(Quaternion deltaRotation, Vector3 deltaPosition, Vector3 pivot, bool moveToTarget)
		{
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000223E File Offset: 0x0000043E
		public virtual void OnMuscleDisconnected(Muscle m)
		{
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000223E File Offset: 0x0000043E
		public virtual void OnMuscleReconnected(Muscle m)
		{
		}

		// Token: 0x06000167 RID: 359 RVA: 0x000088E4 File Offset: 0x00006AE4
		public virtual void OnMuscleAdded(Muscle m)
		{
			if (this.OnHierarchyChanged != null)
			{
				this.OnHierarchyChanged();
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000088E4 File Offset: 0x00006AE4
		public virtual void OnMuscleRemoved(Muscle m)
		{
			if (this.OnHierarchyChanged != null)
			{
				this.OnHierarchyChanged();
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnActivate()
		{
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnDeactivate()
		{
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnInitiate()
		{
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnFixedUpdate(float deltaTime)
		{
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnUpdate(float deltaTime)
		{
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnLateUpdate(float deltaTime)
		{
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnReadBehaviour(float deltaTime)
		{
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnWriteBehaviour(float deltaTime)
		{
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnDrawGizmosBehaviour()
		{
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnFixTransformsBehaviour()
		{
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnMuscleHitBehaviour(MuscleHit hit)
		{
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnMuscleCollisionBehaviour(MuscleCollision collision)
		{
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnMuscleCollisionExitBehaviour(MuscleCollision collision)
		{
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000176 RID: 374 RVA: 0x000088F9 File Offset: 0x00006AF9
		// (set) Token: 0x06000177 RID: 375 RVA: 0x00008901 File Offset: 0x00006B01
		public bool forceActive { get; protected set; }

		// Token: 0x06000178 RID: 376 RVA: 0x0000890A File Offset: 0x00006B0A
		public void Initiate()
		{
			this.initiated = true;
			if (this.OnPreInitiate != null)
			{
				this.OnPreInitiate();
			}
			this.OnInitiate();
			if (this.OnPostInitiate != null)
			{
				this.OnPostInitiate();
			}
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000893F File Offset: 0x00006B3F
		public void OnFixTransforms()
		{
			if (!this.initiated)
			{
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			if (this.OnPreFixTransforms != null)
			{
				this.OnPreFixTransforms();
			}
			this.OnFixTransformsBehaviour();
			if (this.OnPostFixTransforms != null)
			{
				this.OnPostFixTransforms();
			}
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00008980 File Offset: 0x00006B80
		public void OnRead(float deltaTime)
		{
			if (!this.initiated)
			{
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			if (this.OnPreRead != null)
			{
				this.OnPreRead(deltaTime);
			}
			this.OnReadBehaviour(deltaTime);
			if (this.OnPostRead != null)
			{
				this.OnPostRead(deltaTime);
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x000089D0 File Offset: 0x00006BD0
		public void OnWrite(float deltaTime)
		{
			if (!this.initiated)
			{
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			if (this.OnPreWrite != null)
			{
				this.OnPreWrite(deltaTime);
			}
			this.OnWriteBehaviour(deltaTime);
			if (this.OnPostWrite != null)
			{
				this.OnPostWrite(deltaTime);
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00008A1E File Offset: 0x00006C1E
		public void OnMuscleHit(MuscleHit hit)
		{
			if (!this.initiated)
			{
				return;
			}
			if (this.OnPreMuscleHit != null)
			{
				this.OnPreMuscleHit(hit);
			}
			this.OnMuscleHitBehaviour(hit);
			if (this.OnPostMuscleHit != null)
			{
				this.OnPostMuscleHit(hit);
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00008A58 File Offset: 0x00006C58
		public void OnMuscleCollision(MuscleCollision collision)
		{
			if (!this.initiated)
			{
				return;
			}
			if (this.OnPreMuscleCollision != null)
			{
				this.OnPreMuscleCollision(collision);
			}
			this.OnMuscleCollisionBehaviour(collision);
			if (this.OnPostMuscleCollision != null)
			{
				this.OnPostMuscleCollision(collision);
			}
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00008A92 File Offset: 0x00006C92
		public void OnMuscleCollisionExit(MuscleCollision collision)
		{
			if (!this.initiated)
			{
				return;
			}
			if (this.OnPreMuscleCollisionExit != null)
			{
				this.OnPreMuscleCollisionExit(collision);
			}
			this.OnMuscleCollisionExitBehaviour(collision);
			if (this.OnPostMuscleCollisionExit != null)
			{
				this.OnPostMuscleCollisionExit(collision);
			}
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00008ACC File Offset: 0x00006CCC
		public void Activate()
		{
			foreach (BehaviourBase behaviourBase in this.puppetMaster.behaviours)
			{
				behaviourBase.enabled = (behaviourBase == this);
			}
			if (this.OnPreActivate != null)
			{
				this.OnPreActivate();
			}
			this.OnActivate();
			if (this.OnPostActivate != null)
			{
				this.OnPostActivate();
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00008B2E File Offset: 0x00006D2E
		private void OnDisable()
		{
			if (!this.initiated)
			{
				return;
			}
			if (this.OnPreDeactivate != null)
			{
				this.OnPreDeactivate();
			}
			this.OnDeactivate();
			if (this.OnPostDeactivate != null)
			{
				this.OnPostDeactivate();
			}
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00008B68 File Offset: 0x00006D68
		public void FixedUpdateB(float deltaTime)
		{
			if (!this.initiated)
			{
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			if (this.puppetMaster.muscles.Length == 0)
			{
				return;
			}
			if (this.OnPreFixedUpdate != null && base.enabled)
			{
				this.OnPreFixedUpdate(deltaTime);
			}
			this.OnFixedUpdate(deltaTime);
			if (this.OnPostFixedUpdate != null && base.enabled)
			{
				this.OnPostFixedUpdate(deltaTime);
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00008BD8 File Offset: 0x00006DD8
		public void UpdateB(float deltaTime)
		{
			if (!this.initiated)
			{
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			if (this.puppetMaster.muscles.Length == 0)
			{
				return;
			}
			if (this.OnPreUpdate != null && base.enabled)
			{
				this.OnPreUpdate(deltaTime);
			}
			this.OnUpdate(deltaTime);
			if (this.OnPostUpdate != null && base.enabled)
			{
				this.OnPostUpdate(deltaTime);
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00008C48 File Offset: 0x00006E48
		public void LateUpdateB(float deltaTime)
		{
			if (!this.initiated)
			{
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			if (this.puppetMaster.muscles.Length == 0)
			{
				return;
			}
			if (this.OnPreLateUpdate != null && base.enabled)
			{
				this.OnPreLateUpdate(deltaTime);
			}
			this.OnLateUpdate(deltaTime);
			if (this.OnPostLateUpdate != null && base.enabled)
			{
				this.OnPostLateUpdate(deltaTime);
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00008CB5 File Offset: 0x00006EB5
		protected virtual void OnDrawGizmos()
		{
			if (!this.initiated)
			{
				return;
			}
			this.OnDrawGizmosBehaviour();
			if (this.OnPostDrawGizmos != null)
			{
				this.OnPostDrawGizmos();
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00008CD9 File Offset: 0x00006ED9
		protected virtual string GetTypeSpring()
		{
			return "BehaviourBase";
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00008CE0 File Offset: 0x00006EE0
		protected void RotateTargetToRootMuscle()
		{
			Vector3 point = Quaternion.Inverse(this.puppetMaster.muscles[0].target.rotation) * this.puppetMaster.targetRoot.forward;
			Vector3 forward = this.puppetMaster.muscles[0].rigidbody.rotation * point;
			forward.y = 0f;
			this.puppetMaster.targetRoot.rotation = Quaternion.LookRotation(forward);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00008D60 File Offset: 0x00006F60
		protected void TranslateTargetToRootMuscle(float maintainY)
		{
			this.puppetMaster.muscles[0].target.position = new Vector3(this.puppetMaster.muscles[0].transform.position.x, Mathf.Lerp(this.puppetMaster.muscles[0].transform.position.y, this.puppetMaster.muscles[0].target.position.y, maintainY), this.puppetMaster.muscles[0].transform.position.z);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00008E00 File Offset: 0x00007000
		protected void RemovePropMuscles()
		{
			while (this.ContainsRemovablePropMuscle())
			{
				for (int i = 0; i < this.puppetMaster.muscles.Length; i++)
				{
					if (this.puppetMaster.muscles[i].props.group == Muscle.Group.Prop && !this.puppetMaster.muscles[i].isPropMuscle)
					{
						this.puppetMaster.RemoveMuscleRecursive(this.puppetMaster.muscles[i].joint, true, false, MuscleRemoveMode.Sever);
						break;
					}
				}
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00008E80 File Offset: 0x00007080
		protected virtual void GroundTarget(LayerMask layers)
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(new Ray(this.puppetMaster.targetRoot.position + this.puppetMaster.targetRoot.up, -this.puppetMaster.targetRoot.up), out raycastHit, 4f, layers))
			{
				if (!float.IsNaN(raycastHit.point.x) && !float.IsNaN(raycastHit.point.y) && !float.IsNaN(raycastHit.point.z))
				{
					this.puppetMaster.targetRoot.position = raycastHit.point;
					return;
				}
				Debug.LogWarning("Raycasting against a large collider has produced a NaN hit point.", base.transform);
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00008F44 File Offset: 0x00007144
		protected bool ContainsRemovablePropMuscle()
		{
			foreach (Muscle muscle in this.puppetMaster.muscles)
			{
				if (muscle.props.group == Muscle.Group.Prop && !muscle.isPropMuscle)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x04000129 RID: 297
		[HideInInspector]
		public PuppetMaster puppetMaster;

		// Token: 0x0400012A RID: 298
		public BehaviourBase.BehaviourDelegate OnPreActivate;

		// Token: 0x0400012B RID: 299
		public BehaviourBase.BehaviourDelegate OnPreInitiate;

		// Token: 0x0400012C RID: 300
		public BehaviourBase.BehaviourUpdateDelegate OnPreFixedUpdate;

		// Token: 0x0400012D RID: 301
		public BehaviourBase.BehaviourUpdateDelegate OnPreUpdate;

		// Token: 0x0400012E RID: 302
		public BehaviourBase.BehaviourUpdateDelegate OnPreLateUpdate;

		// Token: 0x0400012F RID: 303
		public BehaviourBase.BehaviourUpdateDelegate OnPreRead;

		// Token: 0x04000130 RID: 304
		public BehaviourBase.BehaviourUpdateDelegate OnPreWrite;

		// Token: 0x04000131 RID: 305
		public BehaviourBase.BehaviourDelegate OnPreDeactivate;

		// Token: 0x04000132 RID: 306
		public BehaviourBase.BehaviourDelegate OnPreFixTransforms;

		// Token: 0x04000133 RID: 307
		public BehaviourBase.HitDelegate OnPreMuscleHit;

		// Token: 0x04000134 RID: 308
		public BehaviourBase.CollisionDelegate OnPreMuscleCollision;

		// Token: 0x04000135 RID: 309
		public BehaviourBase.CollisionDelegate OnPreMuscleCollisionExit;

		// Token: 0x04000136 RID: 310
		public BehaviourBase.BehaviourDelegate OnHierarchyChanged;

		// Token: 0x04000137 RID: 311
		public BehaviourBase.BehaviourDelegate OnPostActivate;

		// Token: 0x04000138 RID: 312
		public BehaviourBase.BehaviourDelegate OnPostInitiate;

		// Token: 0x04000139 RID: 313
		public BehaviourBase.BehaviourUpdateDelegate OnPostFixedUpdate;

		// Token: 0x0400013A RID: 314
		public BehaviourBase.BehaviourUpdateDelegate OnPostUpdate;

		// Token: 0x0400013B RID: 315
		public BehaviourBase.BehaviourUpdateDelegate OnPostLateUpdate;

		// Token: 0x0400013C RID: 316
		public BehaviourBase.BehaviourUpdateDelegate OnPostRead;

		// Token: 0x0400013D RID: 317
		public BehaviourBase.BehaviourUpdateDelegate OnPostWrite;

		// Token: 0x0400013E RID: 318
		public BehaviourBase.BehaviourDelegate OnPostDeactivate;

		// Token: 0x0400013F RID: 319
		public BehaviourBase.BehaviourDelegate OnPostDrawGizmos;

		// Token: 0x04000140 RID: 320
		public BehaviourBase.BehaviourDelegate OnPostFixTransforms;

		// Token: 0x04000141 RID: 321
		public BehaviourBase.HitDelegate OnPostMuscleHit;

		// Token: 0x04000142 RID: 322
		public BehaviourBase.CollisionDelegate OnPostMuscleCollision;

		// Token: 0x04000143 RID: 323
		public BehaviourBase.CollisionDelegate OnPostMuscleCollisionExit;

		// Token: 0x04000144 RID: 324
		[HideInInspector]
		public bool deactivated;

		// Token: 0x04000146 RID: 326
		private bool initiated;

		// Token: 0x04000147 RID: 327
		private const string typeSpringBase = "BehaviourBase";

		// Token: 0x0200003A RID: 58
		// (Invoke) Token: 0x0600018D RID: 397
		public delegate void BehaviourDelegate();

		// Token: 0x0200003B RID: 59
		// (Invoke) Token: 0x06000191 RID: 401
		public delegate void BehaviourUpdateDelegate(float deltaTime);

		// Token: 0x0200003C RID: 60
		// (Invoke) Token: 0x06000195 RID: 405
		public delegate void HitDelegate(MuscleHit hit);

		// Token: 0x0200003D RID: 61
		// (Invoke) Token: 0x06000199 RID: 409
		public delegate void CollisionDelegate(MuscleCollision collision);

		// Token: 0x0200003E RID: 62
		[Serializable]
		public struct PuppetEvent
		{
			// Token: 0x1700001A RID: 26
			// (get) Token: 0x0600019C RID: 412 RVA: 0x00008F88 File Offset: 0x00007188
			public bool switchBehaviour
			{
				get
				{
					return this.switchToBehaviour != string.Empty && this.switchToBehaviour != "";
				}
			}

			// Token: 0x0600019D RID: 413 RVA: 0x00008FB0 File Offset: 0x000071B0
			public void Trigger(PuppetMaster puppetMaster, bool switchBehaviourEnabled = true)
			{
				this.unityEvent.Invoke();
				BehaviourBase.AnimatorEvent[] array = this.animations;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Activate(puppetMaster.targetAnimator, puppetMaster.targetAnimation);
				}
				if (this.switchBehaviour)
				{
					bool flag = false;
					foreach (BehaviourBase behaviourBase in puppetMaster.behaviours)
					{
						if (behaviourBase != null && behaviourBase.GetTypeSpring() == this.switchToBehaviour)
						{
							flag = true;
							behaviourBase.Activate();
							break;
						}
					}
					if (!flag)
					{
						Debug.LogError("No Puppet Behaviour of type '" + this.switchToBehaviour + "' was found. Can not switch to the behaviour, please check the spelling (also for empty spaces).");
					}
				}
			}

			// Token: 0x04000148 RID: 328
			[Tooltip("Another Puppet Behaviour to switch to on this event. This must be the exact Type of the the Behaviour, careful with spelling.")]
			public string switchToBehaviour;

			// Token: 0x04000149 RID: 329
			[Tooltip("Animations to cross-fade to on this event. This is separate from the UnityEvent below because UnityEvents can't handle calls with more than one parameter such as Animator.CrossFade.")]
			public BehaviourBase.AnimatorEvent[] animations;

			// Token: 0x0400014A RID: 330
			[Tooltip("The UnityEvent to invoke on this event.")]
			public UnityEvent unityEvent;

			// Token: 0x0400014B RID: 331
			private const string empty = "";
		}

		// Token: 0x0200003F RID: 63
		[Serializable]
		public class AnimatorEvent
		{
			// Token: 0x0600019E RID: 414 RVA: 0x0000905B File Offset: 0x0000725B
			public void Activate(Animator animator, Animation animation)
			{
				if (animator != null)
				{
					this.Activate(animator);
				}
				if (animation != null)
				{
					this.Activate(animation);
				}
			}

			// Token: 0x0600019F RID: 415 RVA: 0x00009080 File Offset: 0x00007280
			private void Activate(Animator animator)
			{
				if (this.animationState == "")
				{
					return;
				}
				if (this.resetNormalizedTime)
				{
					if (this.crossfadeTime > 0f)
					{
						animator.CrossFadeInFixedTime(this.animationState, this.crossfadeTime, this.layer, 0f);
						return;
					}
					animator.Play(this.animationState, this.layer, 0f);
					return;
				}
				else
				{
					if (this.crossfadeTime > 0f)
					{
						animator.CrossFadeInFixedTime(this.animationState, this.crossfadeTime, this.layer);
						return;
					}
					animator.Play(this.animationState, this.layer);
					return;
				}
			}

			// Token: 0x060001A0 RID: 416 RVA: 0x00009124 File Offset: 0x00007324
			private void Activate(Animation animation)
			{
				if (this.animationState == "")
				{
					return;
				}
				if (this.resetNormalizedTime)
				{
					animation[this.animationState].normalizedTime = 0f;
				}
				animation[this.animationState].layer = this.layer;
				animation.CrossFade(this.animationState, this.crossfadeTime);
			}

			// Token: 0x0400014C RID: 332
			public string animationState;

			// Token: 0x0400014D RID: 333
			public float crossfadeTime = 0.3f;

			// Token: 0x0400014E RID: 334
			public int layer;

			// Token: 0x0400014F RID: 335
			public bool resetNormalizedTime;

			// Token: 0x04000150 RID: 336
			private const string empty = "";
		}
	}
}
