using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000289 RID: 649
	internal class XTaskQueueMonitorCallbackHandle : XRegistrationToken<XTaskQueueMonitorCallback>
	{
		// Token: 0x06000E6D RID: 3693 RVA: 0x00011B00 File Offset: 0x0000FD00
		[MonoPInvokeCallback(typeof(XTaskQueueMonitorCallback))]
		private static void OnMonitor(IntPtr context, IntPtr queue, XTaskQueuePort port)
		{
			CallbackWrapper<XTaskQueueMonitorCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XTaskQueueMonitorCallback>;
			callbackWrapper.Callback(callbackWrapper.Context, queue, port);
		}

		// Token: 0x06000E6E RID: 3694 RVA: 0x00011B34 File Offset: 0x0000FD34
		public XTaskQueueMonitorCallbackHandle(XTaskQueueHandle queue, XTaskQueueMonitorCallback callback, IntPtr context) : base(callback, context, new XTaskQueueMonitorCallback(XTaskQueueMonitorCallbackHandle.OnMonitor))
		{
			this.queue = queue;
		}

		// Token: 0x06000E6F RID: 3695 RVA: 0x00011B51 File Offset: 0x0000FD51
		public void Unregister(XTaskQueueHandle queue)
		{
			if (this.Token != 0UL)
			{
				NativeMethods.XTaskQueueUnregisterMonitor(queue.Handle, this.Token);
				this.Token = 0UL;
			}
		}

		// Token: 0x06000E70 RID: 3696 RVA: 0x00011B75 File Offset: 0x0000FD75
		public void Unregister()
		{
			this.Unregister(this.queue);
		}

		// Token: 0x06000E71 RID: 3697 RVA: 0x00011B83 File Offset: 0x0000FD83
		protected override void DisposeInternal(bool disposing)
		{
			this.Unregister();
		}

		// Token: 0x040008C4 RID: 2244
		private XTaskQueueHandle queue;
	}
}
