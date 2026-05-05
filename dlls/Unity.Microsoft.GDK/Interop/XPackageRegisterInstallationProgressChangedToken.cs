using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000266 RID: 614
	internal class XPackageRegisterInstallationProgressChangedToken : XRegistrationToken<XPackageInstallationProgressCallback>
	{
		// Token: 0x06000E2F RID: 3631 RVA: 0x0001184C File Offset: 0x0000FA4C
		[MonoPInvokeCallback(typeof(XPackageInstallationProgressCallback))]
		private static void OnInstallationProgress(IntPtr context, IntPtr monitor)
		{
			CallbackWrapper<XPackageInstallationProgressCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XPackageInstallationProgressCallback>;
			callbackWrapper.Callback(callbackWrapper.Context, monitor);
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x0001187F File Offset: 0x0000FA7F
		public XPackageRegisterInstallationProgressChangedToken(XPackageInstallationMonitorHandle installationProgressChanged, XPackageInstallationProgressCallback callback, IntPtr context) : base(callback, context, new XPackageInstallationProgressCallback(XPackageRegisterInstallationProgressChangedToken.OnInstallationProgress))
		{
			this.installationProgressChanged = installationProgressChanged;
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x0001189C File Offset: 0x0000FA9C
		public bool Unregister(XPackageInstallationMonitorHandle installationProgressChanged, bool wait)
		{
			bool result = true;
			if (this.Token != 0UL)
			{
				result = NativeMethods.XPackageUnregisterInstallationProgressChanged(installationProgressChanged.Handle, this.Token, wait);
				this.Token = 0UL;
			}
			return result;
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x000118CF File Offset: 0x0000FACF
		public bool Unregister(bool wait)
		{
			return this.Unregister(this.installationProgressChanged, true);
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x000118DE File Offset: 0x0000FADE
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister(true);
		}

		// Token: 0x04000851 RID: 2129
		private XPackageInstallationMonitorHandle installationProgressChanged;
	}
}
