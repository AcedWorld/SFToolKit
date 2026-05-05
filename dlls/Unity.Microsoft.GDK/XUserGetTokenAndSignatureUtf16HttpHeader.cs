using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020001AE RID: 430
	[MovedFrom("Unity.GameCore")]
	public class XUserGetTokenAndSignatureUtf16HttpHeader
	{
		// Token: 0x06000A1A RID: 2586 RVA: 0x0000F4FE File Offset: 0x0000D6FE
		internal XUserGetTokenAndSignatureUtf16HttpHeader(XUserGetTokenAndSignatureUtf16HttpHeader interop)
		{
			this.interop = interop;
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x0000F50D File Offset: 0x0000D70D
		public XUserGetTokenAndSignatureUtf16HttpHeader()
		{
			this.interop = default(XUserGetTokenAndSignatureUtf16HttpHeader);
		}

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000A1C RID: 2588 RVA: 0x0000F521 File Offset: 0x0000D721
		// (set) Token: 0x06000A1D RID: 2589 RVA: 0x0000F52E File Offset: 0x0000D72E
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

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06000A1E RID: 2590 RVA: 0x0000F53C File Offset: 0x0000D73C
		// (set) Token: 0x06000A1F RID: 2591 RVA: 0x0000F549 File Offset: 0x0000D749
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

		// Token: 0x040005D0 RID: 1488
		internal XUserGetTokenAndSignatureUtf16HttpHeader interop;
	}
}
