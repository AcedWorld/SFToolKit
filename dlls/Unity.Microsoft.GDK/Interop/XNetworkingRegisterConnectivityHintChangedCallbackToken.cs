using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200025C RID: 604
	internal class XNetworkingRegisterConnectivityHintChangedCallbackToken : XRegistrationToken<XNetworkingConnectivityHintChangedCallback>
	{
		// Token: 0x06000E1B RID: 3611 RVA: 0x000116C0 File Offset: 0x0000F8C0
		[MonoPInvokeCallback(typeof(XNetworkingConnectivityHintChangedCallback))]
		private static void OnConnectivityHintChanged(IntPtr context, XNetworkingConnectivityHint connectivityHint)
		{
			CallbackWrapper<XNetworkingConnectivityHintChangedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XNetworkingConnectivityHintChangedCallback>;
			callbackWrapper.Callback(callbackWrapper.Context, connectivityHint);
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x000116F3 File Offset: 0x0000F8F3
		public XNetworkingRegisterConnectivityHintChangedCallbackToken(XNetworkingConnectivityHintChangedCallback callback, IntPtr context) : base(callback, context, new XNetworkingConnectivityHintChangedCallback(XNetworkingRegisterConnectivityHintChangedCallbackToken.OnConnectivityHintChanged))
		{
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x0001170C File Offset: 0x0000F90C
		public bool Unregister(bool wait)
		{
			bool result = true;
			if (this.Token != 0UL)
			{
				result = NativeMethods.XNetworkingUnregisterConnectivityHintChanged(this.Token, wait);
				this.Token = 0UL;
			}
			return result;
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x00011739 File Offset: 0x0000F939
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister(true);
		}
	}
}
