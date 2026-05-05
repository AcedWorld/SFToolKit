using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Invector
{
	// Token: 0x02000362 RID: 866
	[vClassHeader("HealthController", true, "icon_v2", false, "", iconName = "HealthControllerIcon")]
	public class vHealthController : vMonoBehaviour, vIHealthController, vIDamageReceiver
	{
		// Token: 0x17000344 RID: 836
		// (get) Token: 0x06001189 RID: 4489 RVA: 0x0005E6A3 File Offset: 0x0005C8A3
		// (set) Token: 0x0600118A RID: 4490 RVA: 0x0005E6AB File Offset: 0x0005C8AB
		public int MaxHealth
		{
			get
			{
				return this.maxHealth;
			}
			protected set
			{
				this.maxHealth = value;
			}
		}

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x0600118B RID: 4491 RVA: 0x0005E6B4 File Offset: 0x0005C8B4
		// (set) Token: 0x0600118C RID: 4492 RVA: 0x0005E6BC File Offset: 0x0005C8BC
		public float currentHealth
		{
			get
			{
				return this._currentHealth;
			}
			protected set
			{
				if (this._currentHealth != value)
				{
					this._currentHealth = value;
					this.onChangeHealth.Invoke(this._currentHealth);
				}
				if (!this._isDead && this._currentHealth <= 0f)
				{
					this._isDead = true;
					this.onDead.Invoke(base.gameObject);
					return;
				}
				if (this.isDead && this._currentHealth > 0f)
				{
					this._isDead = false;
				}
			}
		}

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x0600118D RID: 4493 RVA: 0x0005E734 File Offset: 0x0005C934
		// (set) Token: 0x0600118E RID: 4494 RVA: 0x0005E769 File Offset: 0x0005C969
		public bool isDead
		{
			get
			{
				if (!this._isDead && this.currentHealth <= 0f)
				{
					this._isDead = true;
					this.onDead.Invoke(base.gameObject);
				}
				return this._isDead;
			}
			set
			{
				this._isDead = value;
			}
		}

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x0600118F RID: 4495 RVA: 0x0005E772 File Offset: 0x0005C972
		// (set) Token: 0x06001190 RID: 4496 RVA: 0x0005E77A File Offset: 0x0005C97A
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

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06001191 RID: 4497 RVA: 0x0005E783 File Offset: 0x0005C983
		// (set) Token: 0x06001192 RID: 4498 RVA: 0x0005E78B File Offset: 0x0005C98B
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

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06001193 RID: 4499 RVA: 0x0005E794 File Offset: 0x0005C994
		// (set) Token: 0x06001194 RID: 4500 RVA: 0x0005E79C File Offset: 0x0005C99C
		public OnDead onDead
		{
			get
			{
				return this._onDead;
			}
			protected set
			{
				this._onDead = value;
			}
		}

		// Token: 0x06001195 RID: 4501 RVA: 0x0005E7A5 File Offset: 0x0005C9A5
		protected virtual void Start()
		{
			if (this.fillHealthOnStart)
			{
				this.currentHealth = (float)this.maxHealth;
			}
			this.currentHealthRecoveryDelay = this.healthRecoveryDelay;
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06001196 RID: 4502 RVA: 0x0005E7C8 File Offset: 0x0005C9C8
		protected virtual bool canRecoverHealth
		{
			get
			{
				return this.currentHealth >= 0f && this.healthRecovery > 0f && this.currentHealth < (float)this.maxHealth;
			}
		}

		// Token: 0x06001197 RID: 4503 RVA: 0x0005E7F5 File Offset: 0x0005C9F5
		protected virtual IEnumerator RecoverHealth()
		{
			this.inHealthRecovery = true;
			while (this.canRecoverHealth && !this.isDead)
			{
				this.HealthRecovery();
				yield return null;
			}
			this.inHealthRecovery = false;
			yield break;
		}

		// Token: 0x06001198 RID: 4504 RVA: 0x0005E804 File Offset: 0x0005CA04
		protected virtual void HealthRecovery()
		{
			if (!this.canRecoverHealth || this.isDead)
			{
				return;
			}
			if (this.currentHealthRecoveryDelay > 0f)
			{
				this.currentHealthRecoveryDelay -= Time.deltaTime;
				return;
			}
			if (this.currentHealth > (float)this.maxHealth)
			{
				this.currentHealth = (float)this.maxHealth;
			}
			if (this.currentHealth < (float)this.maxHealth)
			{
				this.currentHealth += this.healthRecovery * Time.deltaTime;
			}
		}

		// Token: 0x06001199 RID: 4505 RVA: 0x0005E888 File Offset: 0x0005CA88
		public virtual void AddHealth(int value)
		{
			this.currentHealth += (float)value;
			this.currentHealth = Mathf.Clamp(this.currentHealth, 0f, (float)this.maxHealth);
			if (!this.isDead && this.currentHealth <= 0f)
			{
				this.isDead = true;
				this.onDead.Invoke(base.gameObject);
			}
			this.HandleCheckHealthEvents();
		}

		// Token: 0x0600119A RID: 4506 RVA: 0x0005E8F4 File Offset: 0x0005CAF4
		public virtual void ChangeHealth(int value)
		{
			this.currentHealth = (float)value;
			this.currentHealth = Mathf.Clamp(this.currentHealth, 0f, (float)this.maxHealth);
			if (!this.isDead && this.currentHealth <= 0f)
			{
				this.isDead = true;
				this.onDead.Invoke(base.gameObject);
			}
			this.HandleCheckHealthEvents();
		}

		// Token: 0x0600119B RID: 4507 RVA: 0x0005E959 File Offset: 0x0005CB59
		public virtual void ResetHealth(float health)
		{
			this.currentHealth = health;
			this.onResetHealth.Invoke();
			if (this.isDead)
			{
				this.isDead = false;
			}
		}

		// Token: 0x0600119C RID: 4508 RVA: 0x0005E97C File Offset: 0x0005CB7C
		public virtual void ResetHealth()
		{
			this.currentHealth = (float)this.maxHealth;
			this.onResetHealth.Invoke();
			if (this.isDead)
			{
				this.isDead = false;
			}
		}

		// Token: 0x0600119D RID: 4509 RVA: 0x0005E9A5 File Offset: 0x0005CBA5
		public virtual void ChangeMaxHealth(int value)
		{
			this.maxHealth += value;
			if (this.maxHealth < 0)
			{
				this.maxHealth = 0;
			}
		}

		// Token: 0x0600119E RID: 4510 RVA: 0x0005E9C5 File Offset: 0x0005CBC5
		public virtual void SetHealthRecovery(float value)
		{
			this.healthRecovery = value;
			base.StartCoroutine(this.RecoverHealth());
		}

		// Token: 0x0600119F RID: 4511 RVA: 0x0005E9DC File Offset: 0x0005CBDC
		public virtual void TakeDamage(vDamage damage)
		{
			if (damage != null)
			{
				this.onStartReceiveDamage.Invoke(damage);
				this.currentHealthRecoveryDelay = ((this.currentHealth <= 0f) ? 0f : this.healthRecoveryDelay);
				if (this.currentHealth > 0f && !this.isImmortal)
				{
					this.currentHealth -= damage.damageValue;
				}
				if (damage.damageValue > 0f)
				{
					this.onReceiveDamage.Invoke(damage);
				}
				this.HandleCheckHealthEvents();
			}
		}

		// Token: 0x060011A0 RID: 4512 RVA: 0x0005EA60 File Offset: 0x0005CC60
		protected virtual void HandleCheckHealthEvents()
		{
			List<vHealthController.CheckHealthEvent> list = this.checkHealthEvents.FindAll((vHealthController.CheckHealthEvent e) => (e.healthCompare == vHealthController.CheckHealthEvent.HealthCompare.Equals && this.currentHealth.Equals((float)e.healthToCheck)) || (e.healthCompare == vHealthController.CheckHealthEvent.HealthCompare.HigherThan && this.currentHealth > (float)e.healthToCheck) || (e.healthCompare == vHealthController.CheckHealthEvent.HealthCompare.LessThan && this.currentHealth < (float)e.healthToCheck));
			for (int i = 0; i < list.Count; i++)
			{
				list[i].OnCheckHealth.Invoke();
			}
			if (this.currentHealth < (float)this.maxHealth && base.gameObject.activeInHierarchy && !this.inHealthRecovery)
			{
				base.StartCoroutine(this.RecoverHealth());
			}
		}

		// Token: 0x060011A2 RID: 4514 RVA: 0x0005B662 File Offset: 0x00059862
		Transform vIDamageReceiver.get_transform()
		{
			return base.transform;
		}

		// Token: 0x060011A3 RID: 4515 RVA: 0x0005EB26 File Offset: 0x0005CD26
		GameObject vIDamageReceiver.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x04001788 RID: 6024
		[vEditorToolbar("Health", false, "", false, false, order = 0)]
		[SerializeField]
		[vReadOnly(true)]
		protected bool _isDead;

		// Token: 0x04001789 RID: 6025
		[vBarDisplay("maxHealth", false)]
		[SerializeField]
		protected float _currentHealth;

		// Token: 0x0400178A RID: 6026
		public bool isImmortal;

		// Token: 0x0400178B RID: 6027
		[vHelpBox("If you want to start with different value, uncheck this and make sure that the current health has a value greater zero", vHelpBoxAttribute.MessageType.None)]
		public bool fillHealthOnStart = true;

		// Token: 0x0400178C RID: 6028
		public int maxHealth = 100;

		// Token: 0x0400178D RID: 6029
		public float healthRecovery;

		// Token: 0x0400178E RID: 6030
		public float healthRecoveryDelay;

		// Token: 0x0400178F RID: 6031
		[HideInInspector]
		public float currentHealthRecoveryDelay;

		// Token: 0x04001790 RID: 6032
		[vEditorToolbar("Events", false, "", false, false, order = 100)]
		public List<vHealthController.CheckHealthEvent> checkHealthEvents = new List<vHealthController.CheckHealthEvent>();

		// Token: 0x04001791 RID: 6033
		[SerializeField]
		protected OnReceiveDamage _onStartReceiveDamage = new OnReceiveDamage();

		// Token: 0x04001792 RID: 6034
		[SerializeField]
		protected OnReceiveDamage _onReceiveDamage = new OnReceiveDamage();

		// Token: 0x04001793 RID: 6035
		[SerializeField]
		protected OnDead _onDead = new OnDead();

		// Token: 0x04001794 RID: 6036
		public vHealthController.ValueChangedEvent onChangeHealth;

		// Token: 0x04001795 RID: 6037
		public UnityEvent onResetHealth;

		// Token: 0x04001796 RID: 6038
		internal bool inHealthRecovery;

		// Token: 0x02000363 RID: 867
		[Serializable]
		public class CheckHealthEvent
		{
			// Token: 0x04001797 RID: 6039
			public int healthToCheck;

			// Token: 0x04001798 RID: 6040
			public bool disableEventOnCheck;

			// Token: 0x04001799 RID: 6041
			public vHealthController.CheckHealthEvent.HealthCompare healthCompare;

			// Token: 0x0400179A RID: 6042
			public UnityEvent OnCheckHealth;

			// Token: 0x02000364 RID: 868
			public enum HealthCompare
			{
				// Token: 0x0400179C RID: 6044
				Equals,
				// Token: 0x0400179D RID: 6045
				HigherThan,
				// Token: 0x0400179E RID: 6046
				LessThan
			}
		}

		// Token: 0x02000365 RID: 869
		[Serializable]
		public class ValueChangedEvent : UnityEvent<float>
		{
		}
	}
}
