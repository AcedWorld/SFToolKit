using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000163 RID: 355
	public class XPackageRegisterInstallationProgressChangedToken
	{
		// Token: 0x17000262 RID: 610
		// (get) Token: 0x0600088E RID: 2190 RVA: 0x0000DEC8 File Offset: 0x0000C0C8
		// (set) Token: 0x0600088F RID: 2191 RVA: 0x0000DED0 File Offset: 0x0000C0D0
		internal XPackageRegisterInstallationProgressChangedToken interop { get; private set; }

		// Token: 0x06000890 RID: 2192 RVA: 0x0000DED9 File Offset: 0x0000C0D9
		internal XPackageRegisterInstallationProgressChangedToken(XPackageInstallationMonitorHandle handle, XPackageInstallationProgressCallback callback, IntPtr context)
		{
			this.interop = new XPackageRegisterInstallationProgressChangedToken(handle, callback, context);
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000891 RID: 2193 RVA: 0x0000DEEF File Offset: 0x0000C0EF
		// (set) Token: 0x06000892 RID: 2194 RVA: 0x0000DEFC File Offset: 0x0000C0FC
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

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000893 RID: 2195 RVA: 0x0000DF0A File Offset: 0x0000C10A
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x0000DF17 File Offset: 0x0000C117
		public bool Unregister(XPackageInstallationMonitorHandle installationMonitor, bool wait)
		{
			return this.interop.Unregister(installationMonitor, wait);
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x0000DF26 File Offset: 0x0000C126
		public void Dispose()
		{
			this.interop.Dispose();
		}
	}
}
