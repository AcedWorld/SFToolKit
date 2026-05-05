using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001D8 RID: 472
	internal class XMetadataPurgedToken : XRegistrationToken<XAppCaptureMetadataPurgedCallback>
	{
		// Token: 0x06000C12 RID: 3090 RVA: 0x00010244 File Offset: 0x0000E444
		[MonoPInvokeCallback(typeof(XAppCaptureMetadataPurgedCallback))]
		private static void OnXMetadataPurged(IntPtr context)
		{
			CallbackWrapper<XAppCaptureMetadataPurgedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XAppCaptureMetadataPurgedCallback>;
			callbackWrapper.Callback(callbackWrapper.Context);
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x00010276 File Offset: 0x0000E476
		public XMetadataPurgedToken(XAppCaptureMetadataPurgedCallback callback, IntPtr context) : base(callback, context, new XAppCaptureMetadataPurgedCallback(XMetadataPurgedToken.OnXMetadataPurged))
		{
		}

		// Token: 0x06000C14 RID: 3092 RVA: 0x0001028C File Offset: 0x0000E48C
		public bool Unregister(bool wait)
		{
			bool result = true;
			if (this.Token != 0UL)
			{
				result = NativeMethods.XAppCaptureUnRegisterMetadataPurged(this.Token, wait);
				this.Token = 0UL;
			}
			return result;
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x000102B9 File Offset: 0x0000E4B9
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister(true);
		}
	}
}
