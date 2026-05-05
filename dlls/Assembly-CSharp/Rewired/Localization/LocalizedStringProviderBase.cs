using System;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Localization
{
	// Token: 0x0200029F RID: 671
	public abstract class LocalizedStringProviderBase : MonoBehaviour, ILocalizedStringProvider
	{
		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06000DD9 RID: 3545 RVA: 0x0004AD83 File Offset: 0x00048F83
		// (set) Token: 0x06000DDA RID: 3546 RVA: 0x0004AD8B File Offset: 0x00048F8B
		public virtual bool prefetch
		{
			get
			{
				return this._prefetch;
			}
			set
			{
				this._prefetch = value;
				if (base.gameObject.activeInHierarchy && base.enabled && ReInput.isReady && ReInput.localization.localizedStringProvider == this)
				{
					ReInput.localization.prefetch = value;
				}
			}
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06000DDB RID: 3547
		protected abstract bool initialized { get; }

		// Token: 0x06000DDC RID: 3548 RVA: 0x0004ADC8 File Offset: 0x00048FC8
		protected virtual void OnEnable()
		{
			if (!this.initialized)
			{
				this.Initialize();
			}
			this.TrySetLocalizedStringProvider();
		}

		// Token: 0x06000DDD RID: 3549 RVA: 0x0004ADDF File Offset: 0x00048FDF
		protected virtual void OnDisable()
		{
			if (ReInput.isReady && ReInput.localization.localizedStringProvider == this)
			{
				ReInput.localization.localizedStringProvider = null;
			}
			ReInput.InitializedEvent -= this.TrySetLocalizedStringProvider;
		}

		// Token: 0x06000DDE RID: 3550 RVA: 0x000020BE File Offset: 0x000002BE
		protected virtual void Update()
		{
		}

		// Token: 0x06000DDF RID: 3551 RVA: 0x0004AE14 File Offset: 0x00049014
		protected virtual void TrySetLocalizedStringProvider()
		{
			ReInput.InitializedEvent -= this.TrySetLocalizedStringProvider;
			ReInput.InitializedEvent += this.TrySetLocalizedStringProvider;
			if (!ReInput.isReady)
			{
				return;
			}
			if (!UnityTools.IsNullOrDestroyed<ILocalizedStringProvider>(ReInput.localization.localizedStringProvider))
			{
				Debug.LogWarning("A localized string provider is already set. Only one localized string provider can exist at a time.");
				return;
			}
			ReInput.localization.localizedStringProvider = this;
			ReInput.localization.prefetch = this._prefetch;
		}

		// Token: 0x06000DE0 RID: 3552
		protected abstract bool Initialize();

		// Token: 0x06000DE1 RID: 3553 RVA: 0x0004AE84 File Offset: 0x00049084
		public virtual void Reload()
		{
			this.Initialize();
			if (base.gameObject.activeInHierarchy && base.enabled && ReInput.isReady && ReInput.localization.localizedStringProvider == this)
			{
				ReInput.localization.Reload();
			}
		}

		// Token: 0x06000DE2 RID: 3554
		protected abstract bool TryGetLocalizedString(string key, out string result);

		// Token: 0x06000DE3 RID: 3555 RVA: 0x0004AEC0 File Offset: 0x000490C0
		bool ILocalizedStringProvider.TryGetLocalizedString(string key, out string result)
		{
			return this.TryGetLocalizedString(key, out result);
		}

		// Token: 0x040012C0 RID: 4800
		[SerializeField]
		[Tooltip("Determines if localized strings should be fetched immediately in bulk when available. If false, strings will be fetched when queried.")]
		private bool _prefetch;
	}
}
