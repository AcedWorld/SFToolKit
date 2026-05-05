using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x020001A9 RID: 425
	public class APP_LOCAL_DEVICE_ID
	{
		// Token: 0x060009F4 RID: 2548 RVA: 0x0000F2B2 File Offset: 0x0000D4B2
		internal APP_LOCAL_DEVICE_ID(APP_LOCAL_DEVICE_ID interop)
		{
			this.interop = interop;
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x0000F2C1 File Offset: 0x0000D4C1
		public APP_LOCAL_DEVICE_ID()
		{
			this.interop = default(APP_LOCAL_DEVICE_ID);
		}

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x060009F6 RID: 2550 RVA: 0x0000F2D5 File Offset: 0x0000D4D5
		// (set) Token: 0x060009F7 RID: 2551 RVA: 0x0000F2E2 File Offset: 0x0000D4E2
		public byte[] Value
		{
			get
			{
				return this.interop.value;
			}
			set
			{
				this.interop.value = value;
			}
		}

		// Token: 0x040005C9 RID: 1481
		internal APP_LOCAL_DEVICE_ID interop;
	}
}
