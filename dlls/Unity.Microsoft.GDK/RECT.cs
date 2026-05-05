using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000138 RID: 312
	public class RECT
	{
		// Token: 0x060007B1 RID: 1969 RVA: 0x0000D31D File Offset: 0x0000B51D
		internal RECT(RECT interop)
		{
			this.interop = interop;
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x0000D32C File Offset: 0x0000B52C
		public RECT()
		{
			this.interop = default(RECT);
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x060007B3 RID: 1971 RVA: 0x0000D340 File Offset: 0x0000B540
		// (set) Token: 0x060007B4 RID: 1972 RVA: 0x0000D34D File Offset: 0x0000B54D
		public uint Left
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

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x060007B5 RID: 1973 RVA: 0x0000D35B File Offset: 0x0000B55B
		// (set) Token: 0x060007B6 RID: 1974 RVA: 0x0000D368 File Offset: 0x0000B568
		public uint Top
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

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x060007B7 RID: 1975 RVA: 0x0000D376 File Offset: 0x0000B576
		// (set) Token: 0x060007B8 RID: 1976 RVA: 0x0000D383 File Offset: 0x0000B583
		public uint Right
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

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x060007B9 RID: 1977 RVA: 0x0000D391 File Offset: 0x0000B591
		// (set) Token: 0x060007BA RID: 1978 RVA: 0x0000D39E File Offset: 0x0000B59E
		public uint Bottom
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

		// Token: 0x040004AC RID: 1196
		internal RECT interop;
	}
}
