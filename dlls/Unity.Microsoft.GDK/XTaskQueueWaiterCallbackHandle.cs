using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000197 RID: 407
	public class XTaskQueueWaiterCallbackHandle
	{
		// Token: 0x060009D0 RID: 2512 RVA: 0x0000F090 File Offset: 0x0000D290
		internal XTaskQueueWaiterCallbackHandle(XTaskQueueHandle queue, XTaskQueueCallback callback, IntPtr context)
		{
			this.interop = new XTaskQueueWaiterCallbackHandle(queue, callback, context);
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x060009D1 RID: 2513 RVA: 0x0000F0A6 File Offset: 0x0000D2A6
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x060009D2 RID: 2514 RVA: 0x0000F0B3 File Offset: 0x0000D2B3
		// (set) Token: 0x060009D3 RID: 2515 RVA: 0x0000F0C0 File Offset: 0x0000D2C0
		public ulong Token
		{
			get
			{
				return this.interop.Token;
			}
			set
			{
				this.interop.Token = value;
			}
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x0000F0CE File Offset: 0x0000D2CE
		public void Unregister(XTaskQueueHandle queue)
		{
			this.interop.Unregister(queue);
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x0000F0DC File Offset: 0x0000D2DC
		public void Unregister()
		{
			this.interop.Unregister();
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0000F0E9 File Offset: 0x0000D2E9
		public void Dispose()
		{
			this.interop.Dispose();
		}

		// Token: 0x04000585 RID: 1413
		internal XTaskQueueWaiterCallbackHandle interop;
	}
}
