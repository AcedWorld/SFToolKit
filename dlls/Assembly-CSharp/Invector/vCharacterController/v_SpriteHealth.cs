using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Invector.vCharacterController
{
	// Token: 0x020003FC RID: 1020
	[vClassHeader("SpriteHealth", "Assign your canvas object in the 'healthBar' field to hide and only display when receive damage - leave it empty if you want to display the healthbar all the time.", openClose = false)]
	public class v_SpriteHealth : vMonoBehaviour
	{
		// Token: 0x060014DA RID: 5338 RVA: 0x0006C8E0 File Offset: 0x0006AAE0
		private void Start()
		{
			this.cameraMain = (Camera.main ? Camera.main.transform : null);
			this.healthControl = base.transform.GetComponentInParent<vHealthController>();
			if (this.healthControl == null)
			{
				Debug.LogWarning("The character must have a ICharacter Interface");
				Object.Destroy(base.gameObject);
			}
			this.healthControl.onReceiveDamage.AddListener(new UnityAction<vDamage>(this.Damage));
			this._healthSlider.maxValue = (float)this.healthControl.maxHealth;
			this._healthSlider.value = this._healthSlider.maxValue;
			this._damageDelay.maxValue = (float)this.healthControl.maxHealth;
			this._damageDelay.value = this._healthSlider.maxValue;
			this._damageCounter.text = string.Empty;
			if (this.healthBar)
			{
				this.healthBar.SetActive(false);
			}
		}

		// Token: 0x060014DB RID: 5339 RVA: 0x0006C9E0 File Offset: 0x0006ABE0
		private void SpriteBehaviour()
		{
			if (this.lookToCamera && this.cameraMain != null)
			{
				base.transform.LookAt(this.cameraMain.position, Vector3.up);
			}
			if (this.healthControl == null || this.healthControl.currentHealth <= 0f)
			{
				Object.Destroy(base.gameObject);
			}
			this._healthSlider.value = this.healthControl.currentHealth;
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x0006CA5F File Offset: 0x0006AC5F
		private void Update()
		{
			if (!this.healthBar)
			{
				this.SpriteBehaviour();
			}
		}

		// Token: 0x060014DD RID: 5341 RVA: 0x0006CA74 File Offset: 0x0006AC74
		public void Damage(vDamage damage)
		{
			try
			{
				this.damage += damage.damageValue;
				this._damageCounter.text = this.damage.ToString("00") + ((this._showDamageType && !string.IsNullOrEmpty(damage.damageType)) ? (" : by " + damage.damageType) : "");
				this._healthSlider.value -= damage.damageValue;
				if (!this.inDelay && this.healthControl && this.healthControl.gameObject.activeInHierarchy)
				{
					base.StartCoroutine(this.DamageDelay());
				}
			}
			catch
			{
				Object.Destroy(this);
			}
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x0006CB48 File Offset: 0x0006AD48
		private IEnumerator DamageDelay()
		{
			this.inDelay = true;
			if (this.healthBar)
			{
				this.SpriteBehaviour();
			}
			if (this.healthBar)
			{
				this.healthBar.SetActive(true);
			}
			while (this._damageDelay.value > this._healthSlider.value)
			{
				if (this.healthBar)
				{
					this.SpriteBehaviour();
				}
				this._damageDelay.value -= this._smoothDamageDelay;
				yield return null;
			}
			this.inDelay = false;
			yield return new WaitForSeconds(this._damageCounterTimer);
			this.damage = 0f;
			this._damageCounter.text = string.Empty;
			if (this.healthBar)
			{
				this.healthBar.SetActive(false);
			}
			yield break;
		}

		// Token: 0x04001A93 RID: 6803
		[Tooltip("UI to show on receive damage")]
		[SerializeField]
		protected GameObject healthBar;

		// Token: 0x04001A94 RID: 6804
		public bool lookToCamera = true;

		// Token: 0x04001A95 RID: 6805
		[Header("UI properties")]
		[SerializeField]
		protected Slider _healthSlider;

		// Token: 0x04001A96 RID: 6806
		[SerializeField]
		protected Slider _damageDelay;

		// Token: 0x04001A97 RID: 6807
		[SerializeField]
		protected float _smoothDamageDelay;

		// Token: 0x04001A98 RID: 6808
		[SerializeField]
		protected Text _damageCounter;

		// Token: 0x04001A99 RID: 6809
		[SerializeField]
		protected float _damageCounterTimer = 1.5f;

		// Token: 0x04001A9A RID: 6810
		[SerializeField]
		protected bool _showDamageType = true;

		// Token: 0x04001A9B RID: 6811
		private vHealthController healthControl;

		// Token: 0x04001A9C RID: 6812
		private bool inDelay;

		// Token: 0x04001A9D RID: 6813
		private float damage;

		// Token: 0x04001A9E RID: 6814
		private float currentSmoothDamage;

		// Token: 0x04001A9F RID: 6815
		internal Transform cameraMain;
	}
}
