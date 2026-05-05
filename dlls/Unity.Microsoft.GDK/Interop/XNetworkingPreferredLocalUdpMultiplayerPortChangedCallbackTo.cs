using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200025D RID: 605
	internal class XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken : XRegistrationToken<XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback>
	{
		// Token: 0x06000E1F RID: 3615 RVA: 0x00011744 File Offset: 0x0000F944
		[MonoPInvokeCallback(typeof(XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback))]
		private static void OnPreferredLocalUdpMultiplayerPortChanged(IntPtr context, ushort preferredLocalUdpMultiplayerPort)
		{
			CallbackWrapper<XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback>;
			callbackWrapper.Callback(callbackWrapper.Context, preferredLocalUdpMultiplayerPort);
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x00011777 File Offset: 0x0000F977
		public XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken(XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback callback, IntPtr context) : base(callback, context, new XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback(XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken.OnPreferredLocalUdpMultiplayerPortChanged))
		{
		}

		// Token: 0x06000E21 RID: 3617 RVA: 0x00011790 File Offset: 0x0000F990
		public bool Unregister(bool wait)
		{
			bool result = true;
			if (this.Token != 0UL)
			{
				result = NativeMethods.XNetworkingUnregisterPreferredLocalUdpMultiplayerPortChanged(this.Token, wait);
				this.Token = 0UL;
			}
			return result;
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x000117BD File Offset: 0x0000F9BD
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister(true);
		}
	}
}
