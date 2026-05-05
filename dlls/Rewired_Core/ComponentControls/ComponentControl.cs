using System;
using System.Collections;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	// Token: 0x020003D9 RID: 985
	[DisallowMultipleComponent]
	[Serializable]
	public abstract class ComponentControl : MonoBehaviour, IComponentControl
	{
		// Token: 0x17000949 RID: 2377
		// (get) Token: 0x06002758 RID: 10072
		internal abstract bool sDyfdeIGxyTDdSPFEMsLcAADnlbVB { get; }

		// Token: 0x1700094A RID: 2378
		// (get) Token: 0x06002759 RID: 10073 RVA: 0x0001D715 File Offset: 0x0001B915
		internal bool veZcaeCyueZWdUyopUIfeodQudJq
		{
			get
			{
				return this.IQwawijwzKvMwQkNnWhrrNlYOcNQ;
			}
		}

		// Token: 0x0600275A RID: 10074 RVA: 0x0001D71D File Offset: 0x0001B91D
		[CustomObfuscation(rename = false)]
		internal ComponentControl()
		{
		}

		// Token: 0x0600275B RID: 10075
		public abstract void ClearValue();

		// Token: 0x0600275C RID: 10076 RVA: 0x0009581C File Offset: 0x00093A1C
		void IComponentControl.Update()
		{
			int frameCount = Time.frameCount;
			if (this._lastUpdateFrame == frameCount)
			{
				return;
			}
			this._lastUpdateFrame = frameCount;
			this.AoHwozRsjiUmhnUZxZinlrstaSL();
		}

		// Token: 0x0600275D RID: 10077 RVA: 0x0001D72C File Offset: 0x0001B92C
		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			this.tSNeZifyDBktguwAeQAsYKNJDDIv = true;
		}

		// Token: 0x0600275E RID: 10078 RVA: 0x00002FF9 File Offset: 0x000011F9
		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		// Token: 0x0600275F RID: 10079 RVA: 0x0001D735 File Offset: 0x0001B935
		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!this.tSNeZifyDBktguwAeQAsYKNJDDIv)
			{
				this.IQwawijwzKvMwQkNnWhrrNlYOcNQ = false;
				base.StartCoroutine(this.AXpqobZWnwwUEcHGMHjLCCmhFkhI());
				this.tSNeZifyDBktguwAeQAsYKNJDDIv = true;
				return;
			}
			if (!Application.isPlaying)
			{
				return;
			}
			this.KSOEMYYyaUHKrCRLYwZwXjWJmuJr();
		}

		// Token: 0x06002760 RID: 10080 RVA: 0x0001D769 File Offset: 0x0001B969
		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			this.pgLNtoIIIMcZVdxMsmmYYcwovxMd();
		}

		// Token: 0x06002761 RID: 10081 RVA: 0x00002FF9 File Offset: 0x000011F9
		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		// Token: 0x06002762 RID: 10082 RVA: 0x0001D779 File Offset: 0x0001B979
		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (!this.IQwawijwzKvMwQkNnWhrrNlYOcNQ)
			{
				return;
			}
			this.PBFmatiBLaIYlGmhFOMnlglPQOEkA();
		}

		// Token: 0x06002763 RID: 10083 RVA: 0x0001D78A File Offset: 0x0001B98A
		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
			if (!this.IQwawijwzKvMwQkNnWhrrNlYOcNQ)
			{
				return;
			}
			this.vJNFjWKnJatBLJDgDEjMGMepcqOC(false, false);
		}

		// Token: 0x06002764 RID: 10084 RVA: 0x0001D78A File Offset: 0x0001B98A
		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
			if (!this.IQwawijwzKvMwQkNnWhrrNlYOcNQ)
			{
				return;
			}
			this.vJNFjWKnJatBLJDgDEjMGMepcqOC(false, false);
		}

		// Token: 0x06002765 RID: 10085 RVA: 0x0001D79E File Offset: 0x0001B99E
		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
			bool iqwawijwzKvMwQkNnWhrrNlYOcNQ = this.IQwawijwzKvMwQkNnWhrrNlYOcNQ;
		}

		// Token: 0x06002766 RID: 10086 RVA: 0x0001D79E File Offset: 0x0001B99E
		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
			bool iqwawijwzKvMwQkNnWhrrNlYOcNQ = this.IQwawijwzKvMwQkNnWhrrNlYOcNQ;
		}

		// Token: 0x06002767 RID: 10087 RVA: 0x00002FF9 File Offset: 0x000011F9
		internal virtual void AoHwozRsjiUmhnUZxZinlrstaSL()
		{
		}

		// Token: 0x06002768 RID: 10088 RVA: 0x0001D7A7 File Offset: 0x0001B9A7
		internal virtual bool ffHwuTrmnsLzfzVoVLncxktdhwuQ()
		{
			this.IQwawijwzKvMwQkNnWhrrNlYOcNQ = false;
			if (!this.vJNFjWKnJatBLJDgDEjMGMepcqOC(true, true))
			{
				return false;
			}
			this._controller.Register(this);
			return true;
		}

		// Token: 0x06002769 RID: 10089 RVA: 0x0001D7C9 File Offset: 0x0001B9C9
		internal virtual void pgLNtoIIIMcZVdxMsmmYYcwovxMd()
		{
			this.ClearValue();
			if (!this._controller.IsNullOrDestroyed())
			{
				this._controller.Deregister(this);
			}
			this.cNZWoxfKivbErakyPToildyvcWAkA();
			this.IQwawijwzKvMwQkNnWhrrNlYOcNQ = false;
		}

		// Token: 0x0600276A RID: 10090 RVA: 0x0001D7F7 File Offset: 0x0001B9F7
		internal virtual void INuthIKcEuhqoHwVvPwrfQAYzEbmA()
		{
			if (this._controller.IsNullOrDestroyed())
			{
				return;
			}
			this.cNZWoxfKivbErakyPToildyvcWAkA();
		}

		// Token: 0x0600276B RID: 10091 RVA: 0x0001D80D File Offset: 0x0001BA0D
		internal virtual void cNZWoxfKivbErakyPToildyvcWAkA()
		{
			this._controller.IsNullOrDestroyed();
		}

		// Token: 0x0600276C RID: 10092 RVA: 0x0001D779 File Offset: 0x0001B979
		internal virtual void FfCSAENAWeppOruWNCWYRiwVBqGj()
		{
			if (!this.IQwawijwzKvMwQkNnWhrrNlYOcNQ)
			{
				return;
			}
			this.PBFmatiBLaIYlGmhFOMnlglPQOEkA();
		}

		// Token: 0x0600276D RID: 10093 RVA: 0x0001D79E File Offset: 0x0001B99E
		internal virtual void ypZrirDpTPdDSbwgBziSLiFRjrJkA()
		{
			bool iqwawijwzKvMwQkNnWhrrNlYOcNQ = this.IQwawijwzKvMwQkNnWhrrNlYOcNQ;
		}

		// Token: 0x0600276E RID: 10094 RVA: 0x00002FF9 File Offset: 0x000011F9
		internal virtual void aldYdGvaUUCtbFsCYThTJjIcModZ()
		{
		}

		// Token: 0x0600276F RID: 10095 RVA: 0x0001D81B File Offset: 0x0001BA1B
		internal bool IUGIIGfBqvDUFgNIMGdfUHjibbKRA()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		// Token: 0x06002770 RID: 10096 RVA: 0x0001D823 File Offset: 0x0001BA23
		internal bool lNeyItEtilEMWcbsGCemarSXLpofb()
		{
			return this == null;
		}

		// Token: 0x06002771 RID: 10097 RVA: 0x0001D82C File Offset: 0x0001BA2C
		internal IComponentController rzibFgeNisiPtdkXZKqxOinxAYdp()
		{
			return this._controller;
		}

		// Token: 0x06002772 RID: 10098
		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		// Token: 0x06002773 RID: 10099
		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		// Token: 0x06002774 RID: 10100 RVA: 0x0001D834 File Offset: 0x0001BA34
		private IEnumerator AXpqobZWnwwUEcHGMHjLCCmhFkhI()
		{
			yield return null;
			if (!this.IUGIIGfBqvDUFgNIMGdfUHjibbKRA())
			{
				yield break;
			}
			this.OnEnable();
			yield break;
		}

		// Token: 0x06002775 RID: 10101 RVA: 0x0001D843 File Offset: 0x0001BA43
		private void KSOEMYYyaUHKrCRLYwZwXjWJmuJr()
		{
			if (!this.ffHwuTrmnsLzfzVoVLncxktdhwuQ())
			{
				return;
			}
			this.aldYdGvaUUCtbFsCYThTJjIcModZ();
			this.IQwawijwzKvMwQkNnWhrrNlYOcNQ = true;
			this.INuthIKcEuhqoHwVvPwrfQAYzEbmA();
		}

		// Token: 0x06002776 RID: 10102 RVA: 0x00095848 File Offset: 0x00093A48
		private bool vJNFjWKnJatBLJDgDEjMGMepcqOC(bool A_1, bool A_2)
		{
			bool flag = false;
			bool result;
			try
			{
				IComponentController componentController = this.FindController();
				if (!this._controller.IsNullOrDestroyed() && this._controller != componentController)
				{
					flag = true;
				}
				this._controller = componentController;
				if (this._controller == null)
				{
					Type type = this.GetRequiredControllerType();
					if (type == null)
					{
						type = typeof(IComponentController);
					}
					if (A_2)
					{
						Logger.LogError(type.Name + " could not be found. You must have a component that extends from " + type.Name + " on this or a parent GameObject.");
					}
					throw new Exception();
				}
				if (!A_1 && flag)
				{
					this.KSOEMYYyaUHKrCRLYwZwXjWJmuJr();
				}
				result = true;
			}
			catch
			{
				this.pgLNtoIIIMcZVdxMsmmYYcwovxMd();
				result = false;
			}
			return result;
		}

		// Token: 0x06002777 RID: 10103 RVA: 0x0001D861 File Offset: 0x0001BA61
		private void PBFmatiBLaIYlGmhFOMnlglPQOEkA()
		{
			this.vJNFjWKnJatBLJDgDEjMGMepcqOC(false, true);
		}

		// Token: 0x06002778 RID: 10104 RVA: 0x0001D86C File Offset: 0x0001BA6C
		private void NaKMuGPPkfJhTjStzPncWFjmzffC()
		{
			if (this.lNeyItEtilEMWcbsGCemarSXLpofb() || !this.IUGIIGfBqvDUFgNIMGdfUHjibbKRA())
			{
				return;
			}
			this.AoHwozRsjiUmhnUZxZinlrstaSL();
		}

		// Token: 0x040016F9 RID: 5881
		private IComponentController _controller;

		// Token: 0x040016FA RID: 5882
		[NonSerialized]
		private bool IQwawijwzKvMwQkNnWhrrNlYOcNQ;

		// Token: 0x040016FB RID: 5883
		[NonSerialized]
		private bool tSNeZifyDBktguwAeQAsYKNJDDIv;

		// Token: 0x040016FC RID: 5884
		private int _lastUpdateFrame = -1;
	}
}
