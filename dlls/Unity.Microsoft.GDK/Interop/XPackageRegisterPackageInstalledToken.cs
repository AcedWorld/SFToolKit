using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000265 RID: 613
	internal class XPackageRegisterPackageInstalledToken : XRegistrationToken<XPackageInstalledCallback>
	{
		// Token: 0x06000E2B RID: 3627 RVA: 0x000117C8 File Offset: 0x0000F9C8
		[MonoPInvokeCallback(typeof(XPackageInstalledCallback))]
		private static void OnPackageInstalled(IntPtr context, XPackageDetails details)
		{
			CallbackWrapper<XPackageInstalledCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XPackageInstalledCallback>;
			callbackWrapper.Callback(callbackWrapper.Context, details);
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x000117FB File Offset: 0x0000F9FB
		public XPackageRegisterPackageInstalledToken(XPackageInstalledCallback callback, IntPtr context) : base(callback, context, new XPackageInstalledCallback(XPackageRegisterPackageInstalledToken.OnPackageInstalled))
		{
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x00011814 File Offset: 0x0000FA14
		public bool Unregister(bool wait)
		{
			bool result = true;
			if (this.Token != 0UL)
			{
				result = NativeMethods.XPackageUnregisterPackageInstalled(this.Token, wait);
				this.Token = 0UL;
			}
			return result;
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x00011841 File Offset: 0x0000FA41
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister(true);
		}
	}
}
