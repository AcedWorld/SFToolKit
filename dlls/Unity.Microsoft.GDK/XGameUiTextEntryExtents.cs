using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000147 RID: 327
	public class XGameUiTextEntryExtents
	{
		// Token: 0x060007F8 RID: 2040 RVA: 0x0000D6B9 File Offset: 0x0000B8B9
		internal XGameUiTextEntryExtents(XGameUiTextEntryExtents interop)
		{
			this.interop = interop;
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x0000D6C8 File Offset: 0x0000B8C8
		public XGameUiTextEntryExtents()
		{
			this.interop = default(XGameUiTextEntryExtents);
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x060007FA RID: 2042 RVA: 0x0000D6DC File Offset: 0x0000B8DC
		// (set) Token: 0x060007FB RID: 2043 RVA: 0x0000D6E9 File Offset: 0x0000B8E9
		public float Left
		{
			get
			{
				return this.interop.left;
			}
			set
			{
				this.interop.left = value;
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x060007FC RID: 2044 RVA: 0x0000D6F7 File Offset: 0x0000B8F7
		// (set) Token: 0x060007FD RID: 2045 RVA: 0x0000D704 File Offset: 0x0000B904
		public float Top
		{
			get
			{
				return this.interop.top;
			}
			set
			{
				this.interop.top = value;
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x060007FE RID: 2046 RVA: 0x0000D712 File Offset: 0x0000B912
		// (set) Token: 0x060007FF RID: 2047 RVA: 0x0000D71F File Offset: 0x0000B91F
		public float Right
		{
			get
			{
				return this.interop.right;
			}
			set
			{
				this.interop.right = value;
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000800 RID: 2048 RVA: 0x0000D72D File Offset: 0x0000B92D
		// (set) Token: 0x06000801 RID: 2049 RVA: 0x0000D73A File Offset: 0x0000B93A
		public float Bottom
		{
			get
			{
				return this.interop.bottom;
			}
			set
			{
				this.interop.bottom = value;
			}
		}

		// Token: 0x040004D5 RID: 1237
		internal XGameUiTextEntryExtents interop;
	}
}
