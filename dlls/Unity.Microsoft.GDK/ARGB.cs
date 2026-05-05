using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000015 RID: 21
	public class ARGB
	{
		// Token: 0x06000235 RID: 565 RVA: 0x000085D9 File Offset: 0x000067D9
		internal ARGB(ARGB interopARGB)
		{
			this.interop = interopARGB;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x000085E8 File Offset: 0x000067E8
		public ARGB()
		{
			this.interop = default(ARGB);
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000237 RID: 567 RVA: 0x000085FC File Offset: 0x000067FC
		// (set) Token: 0x06000238 RID: 568 RVA: 0x00008609 File Offset: 0x00006809
		public byte A
		{
			get
			{
				return this.interop.A;
			}
			set
			{
				this.interop.A = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000239 RID: 569 RVA: 0x00008617 File Offset: 0x00006817
		// (set) Token: 0x0600023A RID: 570 RVA: 0x00008624 File Offset: 0x00006824
		public byte R
		{
			get
			{
				return this.interop.R;
			}
			set
			{
				this.interop.R = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600023B RID: 571 RVA: 0x00008632 File Offset: 0x00006832
		// (set) Token: 0x0600023C RID: 572 RVA: 0x0000863F File Offset: 0x0000683F
		public byte G
		{
			get
			{
				return this.interop.G;
			}
			set
			{
				this.interop.G = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600023D RID: 573 RVA: 0x0000864D File Offset: 0x0000684D
		// (set) Token: 0x0600023E RID: 574 RVA: 0x0000865A File Offset: 0x0000685A
		public byte B
		{
			get
			{
				return this.interop.B;
			}
			set
			{
				this.interop.B = value;
			}
		}

		// Token: 0x0400009A RID: 154
		internal ARGB interop;
	}
}
