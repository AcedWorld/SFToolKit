using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000181 RID: 385
	public class XStoreConsumableResult
	{
		// Token: 0x06000962 RID: 2402 RVA: 0x0000EBC4 File Offset: 0x0000CDC4
		internal XStoreConsumableResult(XStoreConsumableResult interop)
		{
			this.interop = interop;
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x0000EBD3 File Offset: 0x0000CDD3
		public XStoreConsumableResult()
		{
			this.interop = default(XStoreConsumableResult);
		}

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06000964 RID: 2404 RVA: 0x0000EBE7 File Offset: 0x0000CDE7
		// (set) Token: 0x06000965 RID: 2405 RVA: 0x0000EBF4 File Offset: 0x0000CDF4
		public uint Quantity
		{
			get
			{
				return this.interop.quantity;
			}
			set
			{
				this.interop.quantity = value;
			}
		}

		// Token: 0x04000552 RID: 1362
		internal XStoreConsumableResult interop;
	}
}
