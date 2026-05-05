using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000162 RID: 354
	public class XPackageRegisterPackageInstalledToken
	{
		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000886 RID: 2182 RVA: 0x0000DE5F File Offset: 0x0000C05F
		// (set) Token: 0x06000887 RID: 2183 RVA: 0x0000DE67 File Offset: 0x0000C067
		internal XPackageRegisterPackageInstalledToken interop { get; private set; }

		// Token: 0x06000888 RID: 2184 RVA: 0x0000DE70 File Offset: 0x0000C070
		internal XPackageRegisterPackageInstalledToken(XPackageInstalledCallback callback, IntPtr context)
		{
			this.interop = new XPackageRegisterPackageInstalledToken(callback, context);
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000889 RID: 2185 RVA: 0x0000DE85 File Offset: 0x0000C085
		// (set) Token: 0x0600088A RID: 2186 RVA: 0x0000DE92 File Offset: 0x0000C092
		public ulong Token
		{
			get
			{
				return this.interop.Token;
			}
			set
			{
				this.interop.Token = value;
			}
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x0600088B RID: 2187 RVA: 0x0000DEA0 File Offset: 0x0000C0A0
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x0000DEAD File Offset: 0x0000C0AD
		public bool Unregister(bool wait)
		{
			return this.interop.Unregister(wait);
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x0000DEBB File Offset: 0x0000C0BB
		public void Dispose()
		{
			this.interop.Dispose();
		}
	}
}
