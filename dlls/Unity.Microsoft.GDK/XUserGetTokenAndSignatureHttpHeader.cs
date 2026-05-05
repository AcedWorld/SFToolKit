using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x020001AC RID: 428
	public class XUserGetTokenAndSignatureHttpHeader
	{
		// Token: 0x06000A0A RID: 2570 RVA: 0x0000F416 File Offset: 0x0000D616
		internal XUserGetTokenAndSignatureHttpHeader(XUserGetTokenAndSignatureHttpHeader interop)
		{
			this.interop = interop;
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x0000F425 File Offset: 0x0000D625
		public XUserGetTokenAndSignatureHttpHeader()
		{
			this.interop = default(XUserGetTokenAndSignatureHttpHeader);
		}

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06000A0C RID: 2572 RVA: 0x0000F439 File Offset: 0x0000D639
		// (set) Token: 0x06000A0D RID: 2573 RVA: 0x0000F446 File Offset: 0x0000D646
		public string Name
		{
			get
			{
				return this.interop.name;
			}
			set
			{
				this.interop.name = value;
			}
		}

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x06000A0E RID: 2574 RVA: 0x0000F454 File Offset: 0x0000D654
		// (set) Token: 0x06000A0F RID: 2575 RVA: 0x0000F461 File Offset: 0x0000D661
		public string Value
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

		// Token: 0x040005CE RID: 1486
		internal XUserGetTokenAndSignatureHttpHeader interop;
	}
}
