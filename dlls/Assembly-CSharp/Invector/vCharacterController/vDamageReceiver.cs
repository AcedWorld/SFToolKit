using System;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.vCharacterController
{
	// Token: 0x02000405 RID: 1029
	[vClassHeader("DAMAGE RECEIVER", "You can add damage multiplier for example causing twice damage on Headshots", openClose = false)]
	public class vDamageReceiver : vMonoBehaviour, vIDamageReceiver
	{
		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x0600151F RID: 5407 RVA: 0x0006EA6B File Offset: 0x0006CC6B
		// (set) Token: 0x06001520 RID: 5408 RVA: 0x0006EA73 File Offset: 0x0006CC73
		public OnReceiveDamage onStartReceiveDamage
		{
			get
			{
				return this._onStartReceiveDamage;
			}
			protected set
			{
				this._onStartReceiveDamage = value;
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06001521 RID: 5409 RVA: 0x0006EA7C File Offset: 0x0006CC7C
		// (set) Token: 0x06001522 RID: 5410 RVA: 0x0006EA84 File Offset: 0x0006CC84
		public OnReceiveDamage onReceiveDamage
		{
			get
			{
				return this._onReceiveDamage;
			}
			protected set
			{
				this._onReceiveDamage = value;
			}
		}

		// Token: 0x06001523 RID: 5411 RVA: 0x0006EA8D File Offset: 0x0006CC8D
		protected virtual void Start()
		{
			this.ragdoll = base.GetComponentInParent<vRagdoll>();
		}

		// Token: 0x06001524 RID: 5412 RVA: 0x0006EA9B File Offset: 0x0006CC9B
		protected virtual void OnCollisionEnter(Collision collision)
		{
			if (collision != null && this.ragdoll && this.ragdoll.isActive)
			{
				this.ragdoll.OnRagdollCollisionEnter(new vRagdollCollision(base.gameObject, collision));
			}
		}

		// Token: 0x06001525 RID: 5413 RVA: 0x0006EAD4 File Offset: 0x0006CCD4
		public virtual void TakeDamage(vDamage damage)
		{
			if (this.healthController == null && this.targetReceiver)
			{
				this.healthController = this.targetReceiver.GetComponent<vIHealthController>();
			}
			else if (this.healthController == null)
			{
				this.healthController = base.GetComponentInParent<vIHealthController>();
			}
			if (this.healthController != null)
			{
				this.onStartReceiveDamage.Invoke(damage);
				vDamage vDamage = this.ApplyDamageModifiers(damage);
				this.healthController.TakeDamage(vDamage);
				this.onReceiveDamage.Invoke(vDamage);
			}
		}

		// Token: 0x06001526 RID: 5414 RVA: 0x0006EB54 File Offset: 0x0006CD54
		public virtual vDamage ApplyDamageModifiers(vDamage damage)
		{
			float num = (this.useRandomValues && !this.fixedValues) ? Random.Range(this.minDamageMultiplier, this.maxDamageMultiplier) : ((this.useRandomValues && this.fixedValues) ? (this.randomChange ? this.maxDamageMultiplier : this.minDamageMultiplier) : this.damageMultiplier);
			vDamage vDamage = new vDamage(damage);
			vDamage.damageValue *= (float)((int)num);
			if (num == this.maxDamageMultiplier)
			{
				this.OnGetMaxValue.Invoke();
			}
			this.OverrideReaction(ref vDamage);
			return vDamage;
		}

		// Token: 0x06001527 RID: 5415 RVA: 0x0006EBE8 File Offset: 0x0006CDE8
		protected virtual void OverrideReaction(ref vDamage damage)
		{
			if (this.overrideReactionID)
			{
				if (this.useRandomValues && !this.fixedValues)
				{
					damage.reaction_id = Random.Range(this.minReactionID, this.maxReactionID);
					return;
				}
				if (this.useRandomValues && this.fixedValues)
				{
					damage.reaction_id = (this.randomChange ? this.maxReactionID : this.minReactionID);
					return;
				}
				damage.reaction_id = this.reactionID;
			}
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06001528 RID: 5416 RVA: 0x0006EC61 File Offset: 0x0006CE61
		protected virtual bool randomChange
		{
			get
			{
				return Random.Range(0f, 100f) < this.changeToMaxValue;
			}
		}

		// Token: 0x0600152A RID: 5418 RVA: 0x0005B662 File Offset: 0x00059862
		Transform vIDamageReceiver.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0600152B RID: 5419 RVA: 0x0005EB26 File Offset: 0x0005CD26
		GameObject vIDamageReceiver.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x04001AF5 RID: 6901
		[vEditorToolbar("Default", false, "", false, false)]
		public float damageMultiplier = 1f;

		// Token: 0x04001AF6 RID: 6902
		[HideInInspector]
		public vRagdoll ragdoll;

		// Token: 0x04001AF7 RID: 6903
		public bool overrideReactionID;

		// Token: 0x04001AF8 RID: 6904
		[vHideInInspector("overrideReactionID", false)]
		public int reactionID;

		// Token: 0x04001AF9 RID: 6905
		[vEditorToolbar("Random", false, "", false, false)]
		public bool useRandomValues;

		// Token: 0x04001AFA RID: 6906
		[vHideInInspector("useRandomValues", false)]
		public bool fixedValues;

		// Token: 0x04001AFB RID: 6907
		[vHideInInspector("useRandomValues", false)]
		public float minDamageMultiplier;

		// Token: 0x04001AFC RID: 6908
		[vHideInInspector("useRandomValues", false)]
		public float maxDamageMultiplier;

		// Token: 0x04001AFD RID: 6909
		[vHideInInspector("useRandomValues", false)]
		public int minReactionID;

		// Token: 0x04001AFE RID: 6910
		[vHideInInspector("useRandomValues", false)]
		public int maxReactionID;

		// Token: 0x04001AFF RID: 6911
		[vHideInInspector("useRandomValues;fixedValues", false)]
		[Tooltip("Change Between 0 and 100")]
		public float changeToMaxValue;

		// Token: 0x04001B00 RID: 6912
		public GameObject targetReceiver;

		// Token: 0x04001B01 RID: 6913
		public vIHealthController healthController;

		// Token: 0x04001B02 RID: 6914
		[SerializeField]
		protected OnReceiveDamage _onStartReceiveDamage = new OnReceiveDamage();

		// Token: 0x04001B03 RID: 6915
		[SerializeField]
		protected OnReceiveDamage _onReceiveDamage = new OnReceiveDamage();

		// Token: 0x04001B04 RID: 6916
		public UnityEvent OnGetMaxValue;
	}
}
