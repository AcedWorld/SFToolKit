using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000240 RID: 576
	internal class XGameInviteRegistrationToken : XRegistrationToken<XGameInviteEventCallback>
	{
		// Token: 0x06000DF2 RID: 3570 RVA: 0x00011498 File Offset: 0x0000F698
		[MonoPInvokeCallback(typeof(XGameInviteEventCallback))]
		private static void OnInvite(IntPtr context, string inviteUri)
		{
			CallbackWrapper<XGameInviteEventCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XGameInviteEventCallback>;
			callbackWrapper.Callback(callbackWrapper.Context, inviteUri);
		}

		// Token: 0x06000DF3 RID: 3571 RVA: 0x000114CB File Offset: 0x0000F6CB
		internal XGameInviteRegistrationToken(XGameInviteEventCallback callback, IntPtr context) : base(callback, context, new XGameInviteEventCallback(XGameInviteRegistrationToken.OnInvite))
		{
		}

		// Token: 0x06000DF4 RID: 3572 RVA: 0x000114E4 File Offset: 0x0000F6E4
		public bool Unregister(bool wait)
		{
			bool result = true;
			if (this.Token != 0UL)
			{
				result = NativeMethods.XGameInviteUnregisterForEvent(this.Token, wait);
				this.Token = 0UL;
			}
			return result;
		}

		// Token: 0x06000DF5 RID: 3573 RVA: 0x00011511 File Offset: 0x0000F711
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister(true);
		}
	}
}
