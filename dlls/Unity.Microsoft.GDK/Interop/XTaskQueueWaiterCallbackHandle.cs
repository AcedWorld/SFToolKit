using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000288 RID: 648
	internal class XTaskQueueWaiterCallbackHandle : XRegistrationToken<XTaskQueueCallback>
	{
		// Token: 0x06000E68 RID: 3688 RVA: 0x00011A74 File Offset: 0x0000FC74
		[MonoPInvokeCallback(typeof(XTaskQueueCallback))]
		private static void OnWaiter(IntPtr context, bool canceled)
		{
			CallbackWrapper<XTaskQueueCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XTaskQueueCallback>;
			callbackWrapper.Callback(callbackWrapper.Context, canceled);
		}

		// Token: 0x06000E69 RID: 3689 RVA: 0x00011AA7 File Offset: 0x0000FCA7
		public XTaskQueueWaiterCallbackHandle(XTaskQueueHandle queue, XTaskQueueCallback callback, IntPtr context) : base(callback, context, new XTaskQueueCallback(XTaskQueueWaiterCallbackHandle.OnWaiter))
		{
			this.queue = queue;
		}

		// Token: 0x06000E6A RID: 3690 RVA: 0x00011AC4 File Offset: 0x0000FCC4
		public void Unregister(XTaskQueueHandle queue)
		{
			if (this.Token != 0UL)
			{
				NativeMethods.XTaskQueueUnregisterWaiter(queue.Handle, this.Token);
				this.Token = 0UL;
			}
		}

		// Token: 0x06000E6B RID: 3691 RVA: 0x00011AE8 File Offset: 0x0000FCE8
		public void Unregister()
		{
			this.Unregister(this.queue);
		}

		// Token: 0x06000E6C RID: 3692 RVA: 0x00011AF6 File Offset: 0x0000FCF6
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister();
		}

		// Token: 0x040008C3 RID: 2243
		private XTaskQueueHandle queue;
	}
}
