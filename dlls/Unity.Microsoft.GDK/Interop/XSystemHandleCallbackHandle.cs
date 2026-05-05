using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000287 RID: 647
	internal class XSystemHandleCallbackHandle : XRegistrationToken<XSystemHandleCallback>
	{
		// Token: 0x06000E64 RID: 3684 RVA: 0x00011A10 File Offset: 0x0000FC10
		[MonoPInvokeCallback(typeof(XSystemHandleCallback))]
		private static void OnHandle(IntPtr handle, XSystemHandleType type, XSystemHandleCallbackReason reason, IntPtr context)
		{
			CallbackWrapper<XSystemHandleCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XSystemHandleCallback>;
			callbackWrapper.Callback(handle, type, reason, callbackWrapper.Context);
		}

		// Token: 0x06000E65 RID: 3685 RVA: 0x00011A45 File Offset: 0x0000FC45
		public XSystemHandleCallbackHandle(XSystemHandleCallback callback, IntPtr context) : base(callback, context, new XSystemHandleCallback(XSystemHandleCallbackHandle.OnHandle))
		{
		}

		// Token: 0x06000E66 RID: 3686 RVA: 0x00011A5B File Offset: 0x0000FC5B
		public void Unregister()
		{
			NativeMethods.XSystemHandleTrack(null, IntPtr.Zero);
		}

		// Token: 0x06000E67 RID: 3687 RVA: 0x00011A69 File Offset: 0x0000FC69
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister();
		}
	}
}
