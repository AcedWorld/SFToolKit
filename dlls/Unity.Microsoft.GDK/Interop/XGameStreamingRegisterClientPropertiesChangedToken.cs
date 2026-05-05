using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000250 RID: 592
	internal class XGameStreamingRegisterClientPropertiesChangedToken : XRegistrationToken<XGameStreamingClientPropertiesChangedCallback>
	{
		// Token: 0x06000E0E RID: 3598 RVA: 0x00011624 File Offset: 0x0000F824
		[MonoPInvokeCallback(typeof(XGameStreamingClientPropertiesChangedCallback))]
		private static void OnClientPropertiesChanged(IntPtr context, XGameStreamingClientId client, uint updatedPropertiesCount, XGameStreamingClientProperty[] updatedProperties)
		{
			CallbackWrapper<XGameStreamingClientPropertiesChangedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XGameStreamingClientPropertiesChangedCallback>;
			callbackWrapper.Callback(callbackWrapper.Context, client, updatedPropertiesCount, updatedProperties);
		}

		// Token: 0x06000E0F RID: 3599 RVA: 0x00011659 File Offset: 0x0000F859
		public XGameStreamingRegisterClientPropertiesChangedToken(XGameStreamingClientId clientId, XGameStreamingClientPropertiesChangedCallback callback, IntPtr context) : base(callback, context, new XGameStreamingClientPropertiesChangedCallback(XGameStreamingRegisterClientPropertiesChangedToken.OnClientPropertiesChanged))
		{
			this.clientId = clientId;
		}

		// Token: 0x06000E10 RID: 3600 RVA: 0x00011678 File Offset: 0x0000F878
		public bool Unregister(XGameStreamingClientId clientId, bool wait)
		{
			bool result = true;
			if (this.Token != 0UL)
			{
				result = NativeMethods.XGameStreamingUnregisterClientPropertiesChanged(clientId, this.Token, wait);
				this.Token = 0UL;
			}
			return result;
		}

		// Token: 0x06000E11 RID: 3601 RVA: 0x000116A6 File Offset: 0x0000F8A6
		public bool Unregister(bool wait)
		{
			return this.Unregister(this.clientId, wait);
		}

		// Token: 0x06000E12 RID: 3602 RVA: 0x000116B5 File Offset: 0x0000F8B5
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister(true);
		}

		// Token: 0x04000818 RID: 2072
		private XGameStreamingClientId clientId;
	}
}
