using System;
using UnityEngine;

namespace Rewired.ComponentControls
{
	// Token: 0x020003EF RID: 1007
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Controls/Touch Controller")]
	[Serializable]
	public sealed class TouchController : CustomController
	{
		// Token: 0x17000988 RID: 2440
		// (get) Token: 0x06002883 RID: 10371 RVA: 0x0001E990 File Offset: 0x0001CB90
		// (set) Token: 0x06002884 RID: 10372 RVA: 0x0001E998 File Offset: 0x0001CB98
		public bool disableMouseInputWhenEnabled
		{
			get
			{
				return this._disableMouseInputWhenEnabled;
			}
			set
			{
				if (this._disableMouseInputWhenEnabled == value)
				{
					return;
				}
				this._disableMouseInputWhenEnabled = value;
				this.zxnoVPBRzEBpjBfWZGglftqxbgow();
			}
		}

		// Token: 0x17000989 RID: 2441
		// (get) Token: 0x06002885 RID: 10373 RVA: 0x0001E9B1 File Offset: 0x0001CBB1
		// (set) Token: 0x06002886 RID: 10374 RVA: 0x0001E9B9 File Offset: 0x0001CBB9
		public bool useCustomController
		{
			get
			{
				return this._useCustomController;
			}
			set
			{
				if (this._useCustomController == value)
				{
					return;
				}
				this._useCustomController = value;
				this.zxnoVPBRzEBpjBfWZGglftqxbgow();
				if (value)
				{
					this.HnHSTUdDNAuYHJqLUuoKrmGoPBpR();
				}
			}
		}

		// Token: 0x06002887 RID: 10375 RVA: 0x0001E9DC File Offset: 0x0001CBDC
		[CustomObfuscation(rename = false)]
		private TouchController()
		{
		}

		// Token: 0x06002888 RID: 10376 RVA: 0x0001E9F2 File Offset: 0x0001CBF2
		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (!base.wkJdAGGCrmLbaBQylMLnGrSjXEYPB)
			{
				return;
			}
			if (ReInput.isReady)
			{
				this.rnesxqQORskuVFXJXbWYglccLUfw(true);
			}
		}

		// Token: 0x06002889 RID: 10377 RVA: 0x0001EA11 File Offset: 0x0001CC11
		internal bool puEPQbYnlXUnCnHZWdebxuqlIdNE()
		{
			if (!base.OnInitialize())
			{
				return false;
			}
			if (ReInput.isReady)
			{
				this.wTUeLQhmKVKIpeAUcYYmXsDceazAc = ReInput.controllers.Mouse.enabled;
				this.rnesxqQORskuVFXJXbWYglccLUfw(false);
			}
			return true;
		}

		// Token: 0x0600288A RID: 10378 RVA: 0x0001E9B1 File Offset: 0x0001CBB1
		[CustomObfuscation(rename = false)]
		internal override bool GetUseCustomController()
		{
			return this._useCustomController;
		}

		// Token: 0x0600288B RID: 10379 RVA: 0x0001EA41 File Offset: 0x0001CC41
		[CustomObfuscation(rename = false)]
		internal override void SetUseCustomController(bool value)
		{
			this._useCustomController = value;
		}

		// Token: 0x0600288C RID: 10380 RVA: 0x0001EA4A File Offset: 0x0001CC4A
		private void rnesxqQORskuVFXJXbWYglccLUfw(bool A_1)
		{
			if (!this._disableMouseInputWhenEnabled)
			{
				return;
			}
			if (A_1)
			{
				ReInput.controllers.Mouse.enabled = this.wTUeLQhmKVKIpeAUcYYmXsDceazAc;
				return;
			}
			ReInput.controllers.Mouse.enabled = false;
		}

		// Token: 0x0600288D RID: 10381 RVA: 0x00002FF9 File Offset: 0x000011F9
		private void zxnoVPBRzEBpjBfWZGglftqxbgow()
		{
		}

		// Token: 0x0600288E RID: 10382 RVA: 0x0001EA7E File Offset: 0x0001CC7E
		private bool HnHSTUdDNAuYHJqLUuoKrmGoPBpR()
		{
			if (ReInput.isReady)
			{
				return true;
			}
			Logger.LogError("Rewired is not initialized. You must have an enabled Rewired Input Manager in the scene if using a Touch Controller. Custom Controller support will be disabled on this Touch Controller.");
			this.SetUseCustomController(false);
			return false;
		}

		// Token: 0x04001762 RID: 5986
		[Tooltip("If true, disables mouse input when the Touch Controller script is enabled or GameObject is activated and re-enables mouse input when the script is disabled or GameObject is deactivated. This is useful for disabling Mouse Look controls when using touch controls in an FPS for example.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _disableMouseInputWhenEnabled = true;

		// Token: 0x04001763 RID: 5987
		[Tooltip("If true, a Custom Controller will be populated with the data from this controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useCustomController = true;

		// Token: 0x04001764 RID: 5988
		[NonSerialized]
		private bool wTUeLQhmKVKIpeAUcYYmXsDceazAc;
	}
}
