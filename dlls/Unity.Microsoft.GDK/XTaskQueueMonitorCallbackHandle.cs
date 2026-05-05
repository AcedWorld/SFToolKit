using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000198 RID: 408
	public class XTaskQueueMonitorCallbackHandle
	{
		// Token: 0x060009D7 RID: 2519 RVA: 0x0000F0F6 File Offset: 0x0000D2F6
		internal XTaskQueueMonitorCallbackHandle(XTaskQueueHandle queue, XTaskQueueMonitorCallback callback, IntPtr context)
		{
			this.interop = new XTaskQueueMonitorCallbackHandle(queue, callback, context);
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x060009D8 RID: 2520 RVA: 0x0000F10C File Offset: 0x0000D30C
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x060009D9 RID: 2521 RVA: 0x0000F119 File Offset: 0x0000D319
		// (set) Token: 0x060009DA RID: 2522 RVA: 0x0000F126 File Offset: 0x0000D326
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

		// Token: 0x060009DB RID: 2523 RVA: 0x0000F134 File Offset: 0x0000D334
		public void Unregister(XTaskQueueHandle queue)
		{
			this.interop.Unregister(queue);
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x0000F142 File Offset: 0x0000D342
		public void Unregister()
		{
			this.interop.Unregister();
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x0000F14F File Offset: 0x0000D34F
		public void Dispose()
		{
			this.interop.Dispose();
		}

		// Token: 0x04000586 RID: 1414
		internal XTaskQueueMonitorCallbackHandle interop;
	}
}
