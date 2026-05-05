using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200029A RID: 666
	internal class XUserDefaultAudioEndpointUtf16RegistrationToken : XRegistrationToken<XUserDefaultAudioEndpointUtf16ChangedCallback>
	{
		// Token: 0x06000E96 RID: 3734 RVA: 0x00011CB8 File Offset: 0x0000FEB8
		[MonoPInvokeCallback(typeof(XUserDefaultAudioEndpointUtf16ChangedCallback))]
		private static void OnDefaultAudioEndpointUtf16Changed(IntPtr context, XUserLocalId user, XUserDefaultAudioEndpointKind defaultAudioEndpointKind, string endpointIdUtf16)
		{
			CallbackWrapper<XUserDefaultAudioEndpointUtf16ChangedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XUserDefaultAudioEndpointUtf16ChangedCallback>;
			callbackWrapper.Callback(callbackWrapper.Context, user, defaultAudioEndpointKind, endpointIdUtf16);
		}

		// Token: 0x06000E97 RID: 3735 RVA: 0x00011CED File Offset: 0x0000FEED
		public XUserDefaultAudioEndpointUtf16RegistrationToken(XUserDefaultAudioEndpointUtf16ChangedCallback callback, IntPtr context) : base(callback, context, new XUserDefaultAudioEndpointUtf16ChangedCallback(XUserDefaultAudioEndpointUtf16RegistrationToken.OnDefaultAudioEndpointUtf16Changed))
		{
		}

		// Token: 0x06000E98 RID: 3736 RVA: 0x00011D04 File Offset: 0x0000FF04
		public bool Unregister(bool wait)
		{
			bool result = true;
			if (this.Token != 0UL)
			{
				result = NativeMethods.XUserUnregisterForDefaultAudioEndpointUtf16Changed(this.Token, wait);
				this.Token = 0UL;
			}
			return result;
		}

		// Token: 0x06000E99 RID: 3737 RVA: 0x00011D31 File Offset: 0x0000FF31
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister(true);
		}
	}
}
