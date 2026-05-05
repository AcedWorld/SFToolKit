using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200027E RID: 638
	internal class GameLicenseChangedCallbackToken : XRegistrationToken<XStoreGameLicenseChangedCallback>
	{
		// Token: 0x06000E4C RID: 3660 RVA: 0x000118E8 File Offset: 0x0000FAE8
		[MonoPInvokeCallback(typeof(XStoreGameLicenseChangedCallback))]
		private static void OnGameLicenseChanged(IntPtr context)
		{
			CallbackWrapper<XStoreGameLicenseChangedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XStoreGameLicenseChangedCallback>;
			callbackWrapper.Callback(callbackWrapper.Context);
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x0001191A File Offset: 0x0000FB1A
		public GameLicenseChangedCallbackToken(XStoreContext storeContext, XStoreGameLicenseChangedCallback callback, IntPtr context) : base(callback, context, new XStoreGameLicenseChangedCallback(GameLicenseChangedCallbackToken.OnGameLicenseChanged))
		{
			this.storeContext = storeContext;
		}

		// Token: 0x06000E4E RID: 3662 RVA: 0x00011938 File Offset: 0x0000FB38
		public bool Unregister(bool wait)
		{
			bool result = true;
			if (this.Token != 0UL)
			{
				result = NativeMethods.XStoreUnregisterGameLicenseChanged(this.storeContext.Handle, this.Token, wait);
				this.Token = 0UL;
			}
			return result;
		}

		// Token: 0x06000E4F RID: 3663 RVA: 0x00011970 File Offset: 0x0000FB70
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister(true);
		}

		// Token: 0x040008B6 RID: 2230
		private XStoreContext storeContext;
	}
}
