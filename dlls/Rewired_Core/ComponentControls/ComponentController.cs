using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls
{
	// Token: 0x020003DB RID: 987
	[DisallowMultipleComponent]
	[Serializable]
	public abstract class ComponentController : MonoBehaviour, IComponentController, IRegistrar<IComponentControl>
	{
		// Token: 0x1700094D RID: 2381
		// (get) Token: 0x0600277F RID: 10111 RVA: 0x0001D89C File Offset: 0x0001BA9C
		internal bool wkJdAGGCrmLbaBQylMLnGrSjXEYPB
		{
			get
			{
				return this.IEwGjaJOcmGXWGDFplRqagQgRZQNB;
			}
		}

		// Token: 0x06002780 RID: 10112 RVA: 0x0001D8A4 File Offset: 0x0001BAA4
		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		// Token: 0x06002781 RID: 10113 RVA: 0x0001D8B9 File Offset: 0x0001BAB9
		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			this.ijxYfmnGDOCyhahcWwiRkxdKvctlA = true;
		}

		// Token: 0x06002782 RID: 10114 RVA: 0x0009594C File Offset: 0x00093B4C
		[CustomObfuscation(rename = false)]
		internal virtual void Update()
		{
			if (!this.IEwGjaJOcmGXWGDFplRqagQgRZQNB)
			{
				return;
			}
			for (int i = this._controls.Count - 1; i >= 0; i--)
			{
				IComponentControl componentControl = this._controls[i];
				if (componentControl.IsNullOrDestroyed())
				{
					this._controls.RemoveAt(i);
				}
				else
				{
					componentControl.Update();
				}
			}
		}

		// Token: 0x06002783 RID: 10115 RVA: 0x0001D8C2 File Offset: 0x0001BAC2
		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!this.ijxYfmnGDOCyhahcWwiRkxdKvctlA)
			{
				base.StartCoroutine(this.qbscqWGboqeXGMKQPBofAdFDlVDJA());
				this.ijxYfmnGDOCyhahcWwiRkxdKvctlA = true;
				return;
			}
			this.cUNAZIFwXRGLpvBqnMwyJZaFLXEsA();
		}

		// Token: 0x06002784 RID: 10116 RVA: 0x0001D8E7 File Offset: 0x0001BAE7
		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (!this.IEwGjaJOcmGXWGDFplRqagQgRZQNB)
			{
				return;
			}
			this.WKKxkVMPEQalCfsKsCnuFfGKMTklA();
		}

		// Token: 0x06002785 RID: 10117 RVA: 0x0001D8F8 File Offset: 0x0001BAF8
		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (!this.IEwGjaJOcmGXWGDFplRqagQgRZQNB)
			{
				return;
			}
			this.mPbbNjAfRAhLhHtAGQBsYkzoSdGh();
		}

		// Token: 0x06002786 RID: 10118 RVA: 0x0001D909 File Offset: 0x0001BB09
		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
			this._controls.Clear();
		}

		// Token: 0x06002787 RID: 10119 RVA: 0x000042E2 File Offset: 0x000024E2
		internal virtual bool bvofkoAxqimixQrzNzQSTfAbWDiq()
		{
			return true;
		}

		// Token: 0x06002788 RID: 10120 RVA: 0x0001D916 File Offset: 0x0001BB16
		internal virtual void AprEPOioEjENQKgHEEHgJwJcoeAz()
		{
			this.WKKxkVMPEQalCfsKsCnuFfGKMTklA();
		}

		// Token: 0x06002789 RID: 10121 RVA: 0x00002FF9 File Offset: 0x000011F9
		internal virtual void WKKxkVMPEQalCfsKsCnuFfGKMTklA()
		{
		}

		// Token: 0x0600278A RID: 10122 RVA: 0x0001D91E File Offset: 0x0001BB1E
		void IRegistrar<IComponentControl>.Register(IComponentControl control)
		{
			if (control.IsNullOrDestroyed())
			{
				return;
			}
			ListTools.AddIfUnique<IComponentControl>(this._controls, control);
		}

		// Token: 0x0600278B RID: 10123 RVA: 0x0001D936 File Offset: 0x0001BB36
		void IRegistrar<IComponentControl>.Deregister(IComponentControl control)
		{
			if (control.IsNullOrDestroyed())
			{
				return;
			}
			this._controls.Remove(control);
		}

		// Token: 0x0600278C RID: 10124 RVA: 0x000959A4 File Offset: 0x00093BA4
		public virtual void ClearControlValues()
		{
			if (!this.IEwGjaJOcmGXWGDFplRqagQgRZQNB)
			{
				return;
			}
			for (int i = this._controls.Count - 1; i >= 0; i--)
			{
				if (this._controls[i].IsNullOrDestroyed())
				{
					this._controls.RemoveAt(i);
				}
				else
				{
					this._controls[i].ClearValue();
				}
			}
		}

		// Token: 0x0600278D RID: 10125 RVA: 0x0001D94E File Offset: 0x0001BB4E
		private void cUNAZIFwXRGLpvBqnMwyJZaFLXEsA()
		{
			if (!this.bvofkoAxqimixQrzNzQSTfAbWDiq())
			{
				return;
			}
			this.IEwGjaJOcmGXWGDFplRqagQgRZQNB = true;
			this.AprEPOioEjENQKgHEEHgJwJcoeAz();
		}

		// Token: 0x0600278E RID: 10126 RVA: 0x0001D966 File Offset: 0x0001BB66
		private void mPbbNjAfRAhLhHtAGQBsYkzoSdGh()
		{
			this.wkJdAGGCrmLbaBQylMLnGrSjXEYPB;
		}

		// Token: 0x0600278F RID: 10127 RVA: 0x0001D96F File Offset: 0x0001BB6F
		private IEnumerator qbscqWGboqeXGMKQPBofAdFDlVDJA()
		{
			yield return null;
			this.cUNAZIFwXRGLpvBqnMwyJZaFLXEsA();
			yield break;
		}

		// Token: 0x04001700 RID: 5888
		[NonSerialized]
		private bool IEwGjaJOcmGXWGDFplRqagQgRZQNB;

		// Token: 0x04001701 RID: 5889
		[NonSerialized]
		private bool ijxYfmnGDOCyhahcWwiRkxdKvctlA;

		// Token: 0x04001702 RID: 5890
		private List<IComponentControl> _controls = new List<IComponentControl>(10);
	}
}
