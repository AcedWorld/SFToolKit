using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200027F RID: 639
	internal class PackageLicenseLostCallbackToken : XRegistrationToken<XStorePackageLicenseLostCallback>
	{
		// Token: 0x06000E50 RID: 3664 RVA: 0x0001197C File Offset: 0x0000FB7C
		[MonoPInvokeCallback(typeof(XStorePackageLicenseLostCallback))]
		private static void OnPackageLicenseLostCallback(IntPtr context)
		{
			CallbackWrapper<XStorePackageLicenseLostCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XStorePackageLicenseLostCallback>;
			callbackWrapper.Callback(callbackWrapper.Context);
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x000119AE File Offset: 0x0000FBAE
		public PackageLicenseLostCallbackToken(XStoreLicense licenseHandle, XStorePackageLicenseLostCallback callback, IntPtr context) : base(callback, context, new XStorePackageLicenseLostCallback(PackageLicenseLostCallbackToken.OnPackageLicenseLostCallback))
		{
			this.licenseHandle = licenseHandle;
		}

		// Token: 0x06000E52 RID: 3666 RVA: 0x000119CC File Offset: 0x0000FBCC
		public bool Unregister(bool wait)
		{
			bool result = true;
			if (this.Token != 0UL)
			{
				result = NativeMethods.XStoreUnregisterPackageLicenseLost(this.licenseHandle.Handle, this.Token, wait);
				this.Token = 0UL;
			}
			return result;
		}

		// Token: 0x06000E53 RID: 3667 RVA: 0x00011A04 File Offset: 0x0000FC04
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister(true);
		}

		// Token: 0x040008B7 RID: 2231
		private XStoreLicense licenseHandle;
	}
}
