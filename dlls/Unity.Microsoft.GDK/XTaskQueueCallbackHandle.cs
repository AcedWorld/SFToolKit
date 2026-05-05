using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000199 RID: 409
	public class XTaskQueueCallbackHandle
	{
		// Token: 0x060009DE RID: 2526 RVA: 0x0000F15C File Offset: 0x0000D35C
		internal XTaskQueueCallbackHandle(XTaskQueueCallback callback, IntPtr context)
		{
			this.interop = new XTaskQueueCallbackHandle(callback, context);
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x060009DF RID: 2527 RVA: 0x0000F171 File Offset: 0x0000D371
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x060009E0 RID: 2528 RVA: 0x0000F17E File Offset: 0x0000D37E
		// (set) Token: 0x060009E1 RID: 2529 RVA: 0x0000F18B File Offset: 0x0000D38B
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

		// Token: 0x060009E2 RID: 2530 RVA: 0x0000F199 File Offset: 0x0000D399
		public void Dispose()
		{
			this.interop.Dispose();
		}

		// Token: 0x04000587 RID: 1415
		internal XTaskQueueCallbackHandle interop;
	}
}
