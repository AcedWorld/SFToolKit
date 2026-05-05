using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200029B RID: 667
	internal class XUserDeviceAssociationChangedRegistrationToken : XRegistrationToken<XUserDeviceAssociationChangedCallback>
	{
		// Token: 0x06000E9A RID: 3738 RVA: 0x00011D3C File Offset: 0x0000FF3C
		[MonoPInvokeCallback(typeof(XUserDeviceAssociationChangedCallback))]
		private static void DeviceAssociationChanged(IntPtr context, ref XUserDeviceAssociationChange change)
		{
			CallbackWrapper<XUserDeviceAssociationChangedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XUserDeviceAssociationChangedCallback>;
			callbackWrapper.Callback(callbackWrapper.Context, ref change);
		}

		// Token: 0x06000E9B RID: 3739 RVA: 0x00011D6F File Offset: 0x0000FF6F
		public XUserDeviceAssociationChangedRegistrationToken(XUserDeviceAssociationChangedCallback callback, IntPtr context) : base(callback, context, new XUserDeviceAssociationChangedCallback(XUserDeviceAssociationChangedRegistrationToken.DeviceAssociationChanged))
		{
		}

		// Token: 0x06000E9C RID: 3740 RVA: 0x00011D88 File Offset: 0x0000FF88
		public bool Unregister(bool wait)
		{
			bool result = true;
			if (this.Token != 0UL)
			{
				result = NativeMethods.XUserUnregisterForDeviceAssociationChanged(this.Token, wait);
				this.Token = 0UL;
			}
			return result;
		}

		// Token: 0x06000E9D RID: 3741 RVA: 0x00011DB5 File Offset: 0x0000FFB5
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister(true);
		}
	}
}
