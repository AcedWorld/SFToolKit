using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200028A RID: 650
	internal class XTaskQueueCallbackHandle : XRegistrationToken<XTaskQueueCallback>
	{
		// Token: 0x06000E72 RID: 3698 RVA: 0x00011B8C File Offset: 0x0000FD8C
		[MonoPInvokeCallback(typeof(XTaskQueueCallback))]
		private static void OnCallback(IntPtr context, bool canceled)
		{
			CallbackWrapper<XTaskQueueCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XTaskQueueCallback>;
			callbackWrapper.Callback(callbackWrapper.Context, canceled);
		}

		// Token: 0x06000E73 RID: 3699 RVA: 0x00011BBF File Offset: 0x0000FDBF
		public XTaskQueueCallbackHandle(XTaskQueueCallback callback, IntPtr context) : base(callback, context, new XTaskQueueCallback(XTaskQueueCallbackHandle.OnCallback))
		{
		}

		// Token: 0x06000E74 RID: 3700 RVA: 0x00011BD5 File Offset: 0x0000FDD5
		protected override void DisposeInternal(bool disposing)
		{
		}
	}
}
