using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200024F RID: 591
	internal class XGameStreamingConnectionStateChangedToken : XRegistrationToken<XGameStreamingConnectionStateChangedCallback>
	{
		// Token: 0x06000E0A RID: 3594 RVA: 0x000115A0 File Offset: 0x0000F7A0
		[MonoPInvokeCallback(typeof(XGameStreamingConnectionStateChangedCallback))]
		private static void OnConnectionStateChanged(IntPtr context, XGameStreamingClientId client, XGameStreamingConnectionState state)
		{
			CallbackWrapper<XGameStreamingConnectionStateChangedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XGameStreamingConnectionStateChangedCallback>;
			callbackWrapper.Callback(callbackWrapper.Context, client, state);
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x000115D4 File Offset: 0x0000F7D4
		public XGameStreamingConnectionStateChangedToken(XGameStreamingConnectionStateChangedCallback callback, IntPtr context) : base(callback, context, new XGameStreamingConnectionStateChangedCallback(XGameStreamingConnectionStateChangedToken.OnConnectionStateChanged))
		{
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x000115EC File Offset: 0x0000F7EC
		public bool Unregister(bool wait)
		{
			bool result = true;
			if (this.Token != 0UL)
			{
				result = NativeMethods.XGameStreamingUnregisterConnectionStateChanged(this.Token, wait);
				this.Token = 0UL;
			}
			return result;
		}

		// Token: 0x06000E0D RID: 3597 RVA: 0x00011619 File Offset: 0x0000F819
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister(true);
		}
	}
}
