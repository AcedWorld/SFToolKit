using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200028B RID: 651
	internal class XTaskQueueTerminateCallbackHandle : XRegistrationToken<XTaskQueueTerminatedCallback>
	{
		// Token: 0x06000E75 RID: 3701 RVA: 0x00011BD8 File Offset: 0x0000FDD8
		[MonoPInvokeCallback(typeof(XTaskQueueTerminatedCallback))]
		private static void OnTerminate(IntPtr context)
		{
			CallbackWrapper<XTaskQueueTerminatedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XTaskQueueTerminatedCallback>;
			callbackWrapper.Callback(callbackWrapper.Context);
		}

		// Token: 0x06000E76 RID: 3702 RVA: 0x00011C0A File Offset: 0x0000FE0A
		public XTaskQueueTerminateCallbackHandle(XTaskQueueTerminatedCallback callback, IntPtr context) : base(callback, context, new XTaskQueueTerminatedCallback(XTaskQueueTerminateCallbackHandle.OnTerminate))
		{
		}

		// Token: 0x06000E77 RID: 3703 RVA: 0x00011C20 File Offset: 0x0000FE20
		protected override void DisposeInternal(bool disposing)
		{
		}
	}
}
