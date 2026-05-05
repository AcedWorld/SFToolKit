using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Localization
{
	// Token: 0x0200043B RID: 1083
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class LocalizedString
	{
		// Token: 0x17000A53 RID: 2643
		// (get) Token: 0x06002B91 RID: 11153 RVA: 0x000216C4 File Offset: 0x0001F8C4
		public bool hasCachedValue
		{
			get
			{
				return this.EVArVmaKTTdkQQDMywABqvEernnC;
			}
		}

		// Token: 0x17000A54 RID: 2644
		// (get) Token: 0x06002B92 RID: 11154 RVA: 0x000216CC File Offset: 0x0001F8CC
		// (set) Token: 0x06002B93 RID: 11155 RVA: 0x000216D4 File Offset: 0x0001F8D4
		public string cachedValue
		{
			get
			{
				return this.pkBtVltibnhNqBixLRQPmOwtdkhtA;
			}
			set
			{
				this.EVArVmaKTTdkQQDMywABqvEernnC = true;
				this.pkBtVltibnhNqBixLRQPmOwtdkhtA = value;
			}
		}

		// Token: 0x06002B94 RID: 11156 RVA: 0x000216E4 File Offset: 0x0001F8E4
		public LocalizedString()
		{
			this.XdBsXXtygqzioLFJqIvepuDxXSxH = 0U;
			this.AMWCLGRXRiTLZreeqhawiJlXujik = 0U;
		}

		// Token: 0x06002B95 RID: 11157 RVA: 0x000216FA File Offset: 0x0001F8FA
		public LocalizedString(LocalizedString A_1)
		{
			this.XdBsXXtygqzioLFJqIvepuDxXSxH = A_1.XdBsXXtygqzioLFJqIvepuDxXSxH;
			this.AMWCLGRXRiTLZreeqhawiJlXujik = A_1.AMWCLGRXRiTLZreeqhawiJlXujik;
			this.pkBtVltibnhNqBixLRQPmOwtdkhtA = A_1.pkBtVltibnhNqBixLRQPmOwtdkhtA;
			this.EVArVmaKTTdkQQDMywABqvEernnC = A_1.EVArVmaKTTdkQQDMywABqvEernnC;
		}

		// Token: 0x06002B96 RID: 11158 RVA: 0x00021732 File Offset: 0x0001F932
		public void Clear()
		{
			this.XdBsXXtygqzioLFJqIvepuDxXSxH = 0U;
			this.AMWCLGRXRiTLZreeqhawiJlXujik = 0U;
			this.pkBtVltibnhNqBixLRQPmOwtdkhtA = null;
			this.EVArVmaKTTdkQQDMywABqvEernnC = false;
		}

		// Token: 0x06002B97 RID: 11159 RVA: 0x0009CC08 File Offset: 0x0009AE08
		public bool TryGetLocalizedValue(string key, ILocalizedStringProvider localizer, uint localizerVersion, uint userVersion, out bool versionChanged, out string result)
		{
			versionChanged = (this.XdBsXXtygqzioLFJqIvepuDxXSxH != ((localizer != null) ? localizerVersion : 0U) || userVersion != this.AMWCLGRXRiTLZreeqhawiJlXujik);
			if (versionChanged)
			{
				this.Clear();
				this.XdBsXXtygqzioLFJqIvepuDxXSxH = localizerVersion;
				this.AMWCLGRXRiTLZreeqhawiJlXujik = userVersion;
			}
			if (!versionChanged || localizer == null)
			{
				result = (this.EVArVmaKTTdkQQDMywABqvEernnC ? this.pkBtVltibnhNqBixLRQPmOwtdkhtA : null);
				return this.EVArVmaKTTdkQQDMywABqvEernnC;
			}
			if (string.IsNullOrEmpty(key))
			{
				result = null;
				return false;
			}
			try
			{
				this.EVArVmaKTTdkQQDMywABqvEernnC = (localizer.TryGetLocalizedString(key, out this.pkBtVltibnhNqBixLRQPmOwtdkhtA) && !string.IsNullOrEmpty(this.pkBtVltibnhNqBixLRQPmOwtdkhtA));
			}
			catch (Exception exception)
			{
				ReInput.HandleExternalInterfaceException(typeof(ILocalizedStringProvider).Name + ".TryGetLocalizedString", exception);
			}
			result = (this.EVArVmaKTTdkQQDMywABqvEernnC ? this.pkBtVltibnhNqBixLRQPmOwtdkhtA : null);
			return this.EVArVmaKTTdkQQDMywABqvEernnC;
		}

		// Token: 0x040018C7 RID: 6343
		public const uint INVALID_VERSION = 0U;

		// Token: 0x040018C8 RID: 6344
		private uint XdBsXXtygqzioLFJqIvepuDxXSxH;

		// Token: 0x040018C9 RID: 6345
		private uint AMWCLGRXRiTLZreeqhawiJlXujik;

		// Token: 0x040018CA RID: 6346
		private string pkBtVltibnhNqBixLRQPmOwtdkhtA;

		// Token: 0x040018CB RID: 6347
		private bool EVArVmaKTTdkQQDMywABqvEernnC;
	}
}
