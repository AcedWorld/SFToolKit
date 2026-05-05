using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.vCharacterController
{
	// Token: 0x020003E0 RID: 992
	[vClassHeader("vCharacter", true, "icon_v2", false, "")]
	[Serializable]
	public class vCharacter : vHealthController, vICharacter, vIHealthController, vIDamageReceiver
	{
		// Token: 0x17000378 RID: 888
		// (get) Token: 0x0600139D RID: 5021 RVA: 0x00066324 File Offset: 0x00064524
		// (set) Token: 0x0600139E RID: 5022 RVA: 0x0006632C File Offset: 0x0006452C
		public Animator animator { get; protected set; }

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x0600139F RID: 5023 RVA: 0x00066335 File Offset: 0x00064535
		// (set) Token: 0x060013A0 RID: 5024 RVA: 0x0006633D File Offset: 0x0006453D
		public bool ragdolled { get; set; }

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x060013A1 RID: 5025 RVA: 0x00066346 File Offset: 0x00064546
		// (set) Token: 0x060013A2 RID: 5026 RVA: 0x0006634E File Offset: 0x0006454E
		public OnActiveRagdoll onActiveRagdoll
		{
			get
			{
				return this._onActiveRagdoll;
			}
			protected set
			{
				this._onActiveRagdoll = value;
			}
		}

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x060013A3 RID: 5027 RVA: 0x00066357 File Offset: 0x00064557
		// (set) Token: 0x060013A4 RID: 5028 RVA: 0x0006635F File Offset: 0x0006455F
		public virtual bool isCrouching
		{
			get
			{
				return this._isCrouching;
			}
			set
			{
				if (value != this._isCrouching)
				{
					if (value)
					{
						this.OnCrouch.Invoke();
					}
					else
					{
						this.OnStandUp.Invoke();
					}
				}
				this._isCrouching = value;
			}
		}

		// Token: 0x060013A5 RID: 5029 RVA: 0x0006638C File Offset: 0x0006458C
		public virtual void Init()
		{
			this.animator = base.GetComponent<Animator>();
			if (this.animator)
			{
				this.hitDirectionHash = new vAnimatorParameter(this.animator, "HitDirection");
				this.reactionIDHash = new vAnimatorParameter(this.animator, "ReactionID");
				this.triggerReactionHash = new vAnimatorParameter(this.animator, "TriggerReaction");
				this.triggerResetStateHash = new vAnimatorParameter(this.animator, "ResetState");
				this.recoilIDHash = new vAnimatorParameter(this.animator, "RecoilID");
				this.triggerRecoilHash = new vAnimatorParameter(this.animator, "TriggerRecoil");
			}
			this.LoadActionControllers(this.debugActionListener);
		}

		// Token: 0x060013A6 RID: 5030 RVA: 0x000020BE File Offset: 0x000002BE
		public virtual void ResetRagdoll()
		{
		}

		// Token: 0x060013A7 RID: 5031 RVA: 0x000020BE File Offset: 0x000002BE
		public virtual void EnableRagdoll()
		{
		}

		// Token: 0x060013A8 RID: 5032 RVA: 0x00066445 File Offset: 0x00064645
		protected virtual void OnTriggerEnter(Collider other)
		{
			this.onActionEnter.Invoke(other);
		}

		// Token: 0x060013A9 RID: 5033 RVA: 0x00066453 File Offset: 0x00064653
		protected virtual void OnTriggerStay(Collider other)
		{
			this.onActionStay.Invoke(other);
		}

		// Token: 0x060013AA RID: 5034 RVA: 0x00066461 File Offset: 0x00064661
		protected virtual void OnTriggerExit(Collider other)
		{
			this.onActionExit.Invoke(other);
		}

		// Token: 0x060013AB RID: 5035 RVA: 0x0006646F File Offset: 0x0006466F
		public override void TakeDamage(vDamage damage)
		{
			base.TakeDamage(damage);
			this.TriggerDamageReaction(damage);
		}

		// Token: 0x060013AC RID: 5036 RVA: 0x00066480 File Offset: 0x00064680
		protected virtual void TriggerDamageReaction(vDamage damage)
		{
			if (this.animator != null && this.animator.enabled && !damage.activeRagdoll && base.currentHealth > 0f)
			{
				if (this.hitDirectionHash.isValid && damage.sender)
				{
					this.animator.SetInteger(this.hitDirectionHash, (int)base.transform.HitAngle(damage.sender.position, true));
				}
				if (damage.hitReaction)
				{
					if (this.reactionIDHash.isValid)
					{
						this.animator.SetInteger(this.reactionIDHash, damage.reaction_id);
					}
					if (this.triggerReactionHash.isValid)
					{
						this.SetTrigger(this.triggerReactionHash);
					}
					if (this.triggerResetStateHash.isValid)
					{
						this.SetTrigger(this.triggerResetStateHash);
					}
				}
				else
				{
					if (this.recoilIDHash.isValid)
					{
						this.animator.SetInteger(this.recoilIDHash, damage.recoil_id);
					}
					if (this.triggerRecoilHash.isValid)
					{
						this.SetTrigger(this.triggerRecoilHash);
					}
					if (this.triggerResetStateHash.isValid)
					{
						this.SetTrigger(this.triggerResetStateHash);
					}
				}
			}
			if (damage.activeRagdoll)
			{
				this.onActiveRagdoll.Invoke(damage);
			}
		}

		// Token: 0x060013AD RID: 5037 RVA: 0x000665F9 File Offset: 0x000647F9
		private IEnumerator SetTriggerRoutine(int trigger)
		{
			this.animator.SetTrigger(trigger);
			yield return new WaitForSeconds(0.1f);
			this.animator.ResetTrigger(trigger);
			yield break;
		}

		// Token: 0x060013AE RID: 5038 RVA: 0x0006660F File Offset: 0x0006480F
		public virtual void SetTrigger(int trigger)
		{
			base.StartCoroutine(this.SetTriggerRoutine(trigger));
		}

		// Token: 0x060013B0 RID: 5040 RVA: 0x0005B662 File Offset: 0x00059862
		Transform vIDamageReceiver.get_transform()
		{
			return base.transform;
		}

		// Token: 0x060013B1 RID: 5041 RVA: 0x0005EB26 File Offset: 0x0005CD26
		GameObject vIDamageReceiver.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x04001943 RID: 6467
		[vEditorToolbar("Health", false, "", false, false)]
		public vCharacter.DeathBy deathBy;

		// Token: 0x04001944 RID: 6468
		public bool removeComponentsAfterDie;

		// Token: 0x04001945 RID: 6469
		[vEditorToolbar("Debug", false, "", false, false, order = 9)]
		[HideInInspector]
		public bool debugActionListener;

		// Token: 0x04001948 RID: 6472
		[vEditorToolbar("Events", false, "", false, false)]
		public UnityEvent OnCrouch;

		// Token: 0x04001949 RID: 6473
		public UnityEvent OnStandUp;

		// Token: 0x0400194A RID: 6474
		[SerializeField]
		protected OnActiveRagdoll _onActiveRagdoll = new OnActiveRagdoll();

		// Token: 0x0400194B RID: 6475
		public UnityEvent onDisableRagdoll;

		// Token: 0x0400194C RID: 6476
		[Header("Check if Character is in Trigger with tag Action")]
		[HideInInspector]
		public OnActionHandle onActionEnter = new OnActionHandle();

		// Token: 0x0400194D RID: 6477
		[HideInInspector]
		public OnActionHandle onActionStay = new OnActionHandle();

		// Token: 0x0400194E RID: 6478
		[HideInInspector]
		public OnActionHandle onActionExit = new OnActionHandle();

		// Token: 0x0400194F RID: 6479
		protected vAnimatorParameter hitDirectionHash;

		// Token: 0x04001950 RID: 6480
		protected vAnimatorParameter reactionIDHash;

		// Token: 0x04001951 RID: 6481
		protected vAnimatorParameter triggerReactionHash;

		// Token: 0x04001952 RID: 6482
		protected vAnimatorParameter triggerResetStateHash;

		// Token: 0x04001953 RID: 6483
		protected vAnimatorParameter recoilIDHash;

		// Token: 0x04001954 RID: 6484
		protected vAnimatorParameter triggerRecoilHash;

		// Token: 0x04001955 RID: 6485
		protected bool isInit;

		// Token: 0x04001956 RID: 6486
		protected bool _isCrouching;

		// Token: 0x020003E1 RID: 993
		public enum DeathBy
		{
			// Token: 0x04001958 RID: 6488
			Animation,
			// Token: 0x04001959 RID: 6489
			AnimationWithRagdoll,
			// Token: 0x0400195A RID: 6490
			Ragdoll
		}
	}
}
