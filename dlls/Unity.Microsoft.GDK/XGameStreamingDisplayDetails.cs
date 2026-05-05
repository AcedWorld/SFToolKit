using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000139 RID: 313
	public class XGameStreamingDisplayDetails
	{
		// Token: 0x060007BB RID: 1979 RVA: 0x0000D3AC File Offset: 0x0000B5AC
		internal XGameStreamingDisplayDetails(XGameStreamingDisplayDetails interop)
		{
			this._interop = interop;
			this.rect = new RECT(interop.safeArea);
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0000D3CC File Offset: 0x0000B5CC
		public XGameStreamingDisplayDetails()
		{
			this._interop = default(XGameStreamingDisplayDetails);
			this.rect = new RECT();
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x060007BD RID: 1981 RVA: 0x0000D3EB File Offset: 0x0000B5EB
		internal XGameStreamingDisplayDetails interop
		{
			get
			{
				this._interop.safeArea = this.rect.interop;
				return this._interop;
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x060007BE RID: 1982 RVA: 0x0000D409 File Offset: 0x0000B609
		// (set) Token: 0x060007BF RID: 1983 RVA: 0x0000D416 File Offset: 0x0000B616
		public uint PreferredWidth
		{
			get
			{
				return this._interop.preferredWidth;
			}
			set
			{
				this._interop.preferredWidth = value;
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x060007C0 RID: 1984 RVA: 0x0000D424 File Offset: 0x0000B624
		// (set) Token: 0x060007C1 RID: 1985 RVA: 0x0000D431 File Offset: 0x0000B631
		public uint PreferredHeight
		{
			get
			{
				return this._interop.preferredHeight;
			}
			set
			{
				this._interop.preferredHeight = value;
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x060007C2 RID: 1986 RVA: 0x0000D43F File Offset: 0x0000B63F
		// (set) Token: 0x060007C3 RID: 1987 RVA: 0x0000D447 File Offset: 0x0000B647
		public RECT SafeArea
		{
			get
			{
				return this.rect;
			}
			set
			{
				this.rect = value;
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x060007C4 RID: 1988 RVA: 0x0000D450 File Offset: 0x0000B650
		// (set) Token: 0x060007C5 RID: 1989 RVA: 0x0000D45D File Offset: 0x0000B65D
		public uint MaxPixels
		{
			get
			{
				return this._interop.maxPixels;
			}
			set
			{
				this._interop.maxPixels = value;
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x060007C6 RID: 1990 RVA: 0x0000D46B File Offset: 0x0000B66B
		// (set) Token: 0x060007C7 RID: 1991 RVA: 0x0000D478 File Offset: 0x0000B678
		public uint MaxWidth
		{
			get
			{
				return this._interop.maxWidth;
			}
			set
			{
				this._interop.maxWidth = value;
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x060007C8 RID: 1992 RVA: 0x0000D486 File Offset: 0x0000B686
		// (set) Token: 0x060007C9 RID: 1993 RVA: 0x0000D493 File Offset: 0x0000B693
		public uint MaxHeight
		{
			get
			{
				return this._interop.maxHeight;
			}
			set
			{
				this._interop.maxHeight = value;
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x060007CA RID: 1994 RVA: 0x0000D4A1 File Offset: 0x0000B6A1
		// (set) Token: 0x060007CB RID: 1995 RVA: 0x0000D4AE File Offset: 0x0000B6AE
		public XGameStreamingVideoFlags Flags
		{
			get
			{
				return this._interop.flags;
			}
			set
			{
				this._interop.flags = value;
			}
		}

		// Token: 0x040004AD RID: 1197
		internal XGameStreamingDisplayDetails _interop;

		// Token: 0x040004AE RID: 1198
		internal RECT rect;
	}
}
