using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000191 RID: 401
	public class XSystemHandleCallbackHandle
	{
		// Token: 0x060009BE RID: 2494 RVA: 0x0000F039 File Offset: 0x0000D239
		internal XSystemHandleCallbackHandle(XSystemHandleCallback callback, IntPtr context)
		{
			this.interop = new XSystemHandleCallbackHandle(callback, context);
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x060009BF RID: 2495 RVA: 0x0000F04E File Offset: 0x0000D24E
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x060009C0 RID: 2496 RVA: 0x0000F05B File Offset: 0x0000D25B
		// (set) Token: 0x060009C1 RID: 2497 RVA: 0x0000F068 File Offset: 0x0000D268
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

		// Token: 0x060009C2 RID: 2498 RVA: 0x0000F076 File Offset: 0x0000D276
		public void Unregister()
		{
			this.interop.Unregister();
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x0000F083 File Offset: 0x0000D283
		public void Dispose()
		{
			this.interop.Dispose();
		}

		// Token: 0x0400057C RID: 1404
		internal XSystemHandleCallbackHandle interop;
	}
}
