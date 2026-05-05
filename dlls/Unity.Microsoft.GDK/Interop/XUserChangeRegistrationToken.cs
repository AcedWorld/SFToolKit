using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000299 RID: 665
	internal class XUserChangeRegistrationToken : XRegistrationToken<XUserChangeEventCallback>
	{
		// Token: 0x06000E92 RID: 3730 RVA: 0x00011C34 File Offset: 0x0000FE34
		[MonoPInvokeCallback(typeof(XUserChangeEventCallback))]
		private static void OnChangeEvent(IntPtr context, XUserLocalId userLocalId, XUserChangeEvent changeEvent)
		{
			CallbackWrapper<XUserChangeEventCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XUserChangeEventCallback>;
			callbackWrapper.Callback(callbackWrapper.Context, userLocalId, changeEvent);
		}

		// Token: 0x06000E93 RID: 3731 RVA: 0x00011C68 File Offset: 0x0000FE68
		public XUserChangeRegistrationToken(XUserChangeEventCallback callback, IntPtr context) : base(callback, context, new XUserChangeEventCallback(XUserChangeRegistrationToken.OnChangeEvent))
		{
		}

		// Token: 0x06000E94 RID: 3732 RVA: 0x00011C80 File Offset: 0x0000FE80
		public bool Unregister(bool wait)
		{
			bool result = true;
			if (this.Token != 0UL)
			{
				result = NativeMethods.XUserUnregisterForChangeEvent(this.Token, wait);
				this.Token = 0UL;
			}
			return result;
		}

		// Token: 0x06000E95 RID: 3733 RVA: 0x00011CAD File Offset: 0x0000FEAD
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister(true);
		}
	}
}
