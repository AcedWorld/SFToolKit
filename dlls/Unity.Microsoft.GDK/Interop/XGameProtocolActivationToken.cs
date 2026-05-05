using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000242 RID: 578
	internal class XGameProtocolActivationToken : XRegistrationToken<XGameProtocolActivationCallback>
	{
		// Token: 0x06000DFA RID: 3578 RVA: 0x0001151C File Offset: 0x0000F71C
		[MonoPInvokeCallback(typeof(XGameProtocolActivationCallback))]
		private static void OnProtocolActivation(IntPtr context, string protocolUri)
		{
			CallbackWrapper<XGameProtocolActivationCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XGameProtocolActivationCallback>;
			callbackWrapper.Callback(callbackWrapper.Context, protocolUri);
		}

		// Token: 0x06000DFB RID: 3579 RVA: 0x0001154F File Offset: 0x0000F74F
		public XGameProtocolActivationToken(XGameProtocolActivationCallback callback, IntPtr context) : base(callback, context, new XGameProtocolActivationCallback(XGameProtocolActivationToken.OnProtocolActivation))
		{
		}

		// Token: 0x06000DFC RID: 3580 RVA: 0x00011568 File Offset: 0x0000F768
		public bool Unregister(bool wait)
		{
			bool result = true;
			if (this.Token != 0UL)
			{
				result = NativeMethods.XGameProtocolUnregisterForActivation(this.Token, wait);
				this.Token = 0UL;
			}
			return result;
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x00011595 File Offset: 0x0000F795
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister(true);
		}
	}
}
