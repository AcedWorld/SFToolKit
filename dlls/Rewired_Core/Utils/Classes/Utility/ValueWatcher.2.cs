using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004E0 RID: 1248
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		// Token: 0x17000B63 RID: 2915
		// (get) Token: 0x06003219 RID: 12825 RVA: 0x000266C6 File Offset: 0x000248C6
		public override bool changed
		{
			get
			{
				return this.YyKuNFqhmFkpIwcThjPEkxHuPyeV;
			}
		}

		// Token: 0x17000B64 RID: 2916
		// (get) Token: 0x0600321A RID: 12826 RVA: 0x000266CE File Offset: 0x000248CE
		// (set) Token: 0x0600321B RID: 12827 RVA: 0x000266D6 File Offset: 0x000248D6
		public override bool autoTriggerEvent
		{
			get
			{
				return this.WUzegNnPhsAULhirmfoRfjHFkVPhB;
			}
			set
			{
				this.WUzegNnPhsAULhirmfoRfjHFkVPhB = value;
			}
		}

		// Token: 0x17000B65 RID: 2917
		// (get) Token: 0x0600321C RID: 12828 RVA: 0x000266DF File Offset: 0x000248DF
		// (set) Token: 0x0600321D RID: 12829 RVA: 0x000266E7 File Offset: 0x000248E7
		public Func<T> getValueDelegate
		{
			get
			{
				return this.VGnFxyCIHBoJEZgapSvZpyMdaTxFA;
			}
			set
			{
				this.VGnFxyCIHBoJEZgapSvZpyMdaTxFA = value;
			}
		}

		// Token: 0x17000B66 RID: 2918
		// (get) Token: 0x0600321E RID: 12830 RVA: 0x000266F0 File Offset: 0x000248F0
		public T value
		{
			get
			{
				return this.IbkEfEtjHbdpZZSKBHiYFTVHkXUbA;
			}
		}

		// Token: 0x14000070 RID: 112
		// (add) Token: 0x0600321F RID: 12831 RVA: 0x000266F8 File Offset: 0x000248F8
		// (remove) Token: 0x06003220 RID: 12832 RVA: 0x00026711 File Offset: 0x00024911
		public event Action<T> ChangedEvent
		{
			add
			{
				this.NSrcLhHyBHPDcyCLmZHLRcDEVYGD = (Action<T>)Delegate.Combine(this.NSrcLhHyBHPDcyCLmZHLRcDEVYGD, value);
			}
			remove
			{
				this.NSrcLhHyBHPDcyCLmZHLRcDEVYGD = (Action<T>)Delegate.Remove(this.NSrcLhHyBHPDcyCLmZHLRcDEVYGD, value);
			}
		}

		// Token: 0x06003221 RID: 12833 RVA: 0x0002672A File Offset: 0x0002492A
		public ValueWatcher(T A_1, bool A_2)
		{
			this.IbkEfEtjHbdpZZSKBHiYFTVHkXUbA = A_1;
			this.WUzegNnPhsAULhirmfoRfjHFkVPhB = A_2;
		}

		// Token: 0x06003222 RID: 12834 RVA: 0x00026740 File Offset: 0x00024940
		public ValueWatcher(T A_1, Func<T> A_2, bool A_3) : this(A_1, A_3)
		{
			this.VGnFxyCIHBoJEZgapSvZpyMdaTxFA = A_2;
		}

		// Token: 0x06003223 RID: 12835 RVA: 0x000AD1C4 File Offset: 0x000AB3C4
		public override bool Update()
		{
			if (this.VGnFxyCIHBoJEZgapSvZpyMdaTxFA == null)
			{
				return false;
			}
			bool result;
			try
			{
				result = this.Set(this.VGnFxyCIHBoJEZgapSvZpyMdaTxFA());
			}
			catch (Exception ex)
			{
				string str = "An exception was thrown by getValueDelegate.\n";
				Exception ex2 = ex;
				Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
				result = false;
			}
			return result;
		}

		// Token: 0x06003224 RID: 12836 RVA: 0x00026751 File Offset: 0x00024951
		public override bool Use()
		{
			if (!this.YyKuNFqhmFkpIwcThjPEkxHuPyeV)
			{
				return false;
			}
			this.YyKuNFqhmFkpIwcThjPEkxHuPyeV = false;
			return true;
		}

		// Token: 0x06003225 RID: 12837 RVA: 0x000AD224 File Offset: 0x000AB424
		public override bool TriggerEvent()
		{
			if (!this.YyKuNFqhmFkpIwcThjPEkxHuPyeV)
			{
				return false;
			}
			if (this.NSrcLhHyBHPDcyCLmZHLRcDEVYGD == null)
			{
				return true;
			}
			bool result;
			try
			{
				this.Use();
				this.NSrcLhHyBHPDcyCLmZHLRcDEVYGD(this.IbkEfEtjHbdpZZSKBHiYFTVHkXUbA);
				result = true;
			}
			catch (Exception ex)
			{
				string str = "An exception was thrown by ValueChangedEvent handler.\n";
				Exception ex2 = ex;
				Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
				result = false;
			}
			return result;
		}

		// Token: 0x06003226 RID: 12838 RVA: 0x00026765 File Offset: 0x00024965
		public bool Set(T value)
		{
			if (ValueWatcher<T>.CMufCdaooaDuCBsdMrwsvcQAxUUkA.Equals(this.IbkEfEtjHbdpZZSKBHiYFTVHkXUbA, value))
			{
				return false;
			}
			this.IbkEfEtjHbdpZZSKBHiYFTVHkXUbA = value;
			this.YyKuNFqhmFkpIwcThjPEkxHuPyeV = true;
			if (this.WUzegNnPhsAULhirmfoRfjHFkVPhB)
			{
				this.TriggerEvent();
			}
			return true;
		}

		// Token: 0x06003227 RID: 12839 RVA: 0x000AD294 File Offset: 0x000AB494
		public override void AddEventListener(ValueWatcher.fqHUsVqcogYvzYMdHoOEIYSpSUiS eventType, Delegate listener)
		{
			if (eventType != ValueWatcher.fqHUsVqcogYvzYMdHoOEIYSpSUiS.ValueChanged)
			{
				throw new NotImplementedException();
			}
			if (!(listener is Action<T>))
			{
				throw new ArgumentException("listener must be of type Action<" + typeof(T).Name + ">");
			}
			this.ChangedEvent += (Action<T>)listener;
		}

		// Token: 0x06003228 RID: 12840 RVA: 0x000AD2E4 File Offset: 0x000AB4E4
		public override void RemoveEventListener(ValueWatcher.fqHUsVqcogYvzYMdHoOEIYSpSUiS eventType, Delegate listener)
		{
			if (eventType != ValueWatcher.fqHUsVqcogYvzYMdHoOEIYSpSUiS.ValueChanged)
			{
				throw new NotImplementedException();
			}
			if (!(listener is Action<T>))
			{
				throw new ArgumentException("listener must be of type Action<" + typeof(T).Name + ">");
			}
			this.ChangedEvent -= (Action<T>)listener;
		}

		// Token: 0x04001B61 RID: 7009
		private static IEqualityComparer<T> CMufCdaooaDuCBsdMrwsvcQAxUUkA = EqualityComparerNoAlloc<T>.Default;

		// Token: 0x04001B62 RID: 7010
		private bool YyKuNFqhmFkpIwcThjPEkxHuPyeV;

		// Token: 0x04001B63 RID: 7011
		private T IbkEfEtjHbdpZZSKBHiYFTVHkXUbA;

		// Token: 0x04001B64 RID: 7012
		private bool WUzegNnPhsAULhirmfoRfjHFkVPhB;

		// Token: 0x04001B65 RID: 7013
		private Func<T> VGnFxyCIHBoJEZgapSvZpyMdaTxFA;

		// Token: 0x04001B66 RID: 7014
		private Action<T> NSrcLhHyBHPDcyCLmZHLRcDEVYGD;
	}
}
