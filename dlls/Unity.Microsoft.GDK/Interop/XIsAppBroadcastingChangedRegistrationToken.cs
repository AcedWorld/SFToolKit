using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001D7 RID: 471
	internal class XIsAppBroadcastingChangedRegistrationToken : XRegistrationToken<XAppBroadcastMonitorCallback>
	{
		// Token: 0x06000C0E RID: 3086 RVA: 0x000101C4 File Offset: 0x0000E3C4
		[MonoPInvokeCallback(typeof(XAppBroadcastMonitorCallback))]
		private static void OnIsAppBroadcastingChanged(IntPtr context)
		{
			CallbackWrapper<XAppBroadcastMonitorCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XAppBroadcastMonitorCallback>;
			callbackWrapper.Callback(callbackWrapper.Context);
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x000101F6 File Offset: 0x0000E3F6
		public XIsAppBroadcastingChangedRegistrationToken(XAppBroadcastMonitorCallback callback, IntPtr context) : base(callback, context, new XAppBroadcastMonitorCallback(XIsAppBroadcastingChangedRegistrationToken.OnIsAppBroadcastingChanged))
		{
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x0001020C File Offset: 0x0000E40C
		public bool Unregister(bool wait)
		{
			bool result = true;
			if (this.Token != 0UL)
			{
				result = NativeMethods.XAppBroadcastUnregisterIsAppBroadcastingChanged(this.Token, wait);
				this.Token = 0UL;
			}
			return result;
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x00010239 File Offset: 0x0000E439
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister(true);
		}
	}
}
