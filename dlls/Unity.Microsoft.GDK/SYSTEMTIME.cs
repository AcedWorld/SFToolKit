using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000025 RID: 37
	public class SYSTEMTIME
	{
		// Token: 0x060002DC RID: 732 RVA: 0x00008FB4 File Offset: 0x000071B4
		internal SYSTEMTIME(SYSTEMTIME interop)
		{
			this.interop = interop;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00008FC3 File Offset: 0x000071C3
		public SYSTEMTIME()
		{
			this.interop = default(SYSTEMTIME);
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060002DE RID: 734 RVA: 0x00008FD7 File Offset: 0x000071D7
		// (set) Token: 0x060002DF RID: 735 RVA: 0x00008FE4 File Offset: 0x000071E4
		public ushort WYear
		{
			get
			{
				return this.interop.wYear;
			}
			set
			{
				this.interop.wYear = value;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00008FF2 File Offset: 0x000071F2
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x00008FFF File Offset: 0x000071FF
		public ushort WMonth
		{
			get
			{
				return this.interop.wMonth;
			}
			set
			{
				this.interop.wMonth = value;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x0000900D File Offset: 0x0000720D
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x0000901A File Offset: 0x0000721A
		public ushort WDayOfWeek
		{
			get
			{
				return this.interop.wDayOfWeek;
			}
			set
			{
				this.interop.wDayOfWeek = value;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x00009028 File Offset: 0x00007228
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x00009035 File Offset: 0x00007235
		public ushort WDay
		{
			get
			{
				return this.interop.wDay;
			}
			set
			{
				this.interop.wDay = value;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060002E6 RID: 742 RVA: 0x00009043 File Offset: 0x00007243
		// (set) Token: 0x060002E7 RID: 743 RVA: 0x00009050 File Offset: 0x00007250
		public ushort WHour
		{
			get
			{
				return this.interop.wHour;
			}
			set
			{
				this.interop.wHour = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x0000905E File Offset: 0x0000725E
		// (set) Token: 0x060002E9 RID: 745 RVA: 0x0000906B File Offset: 0x0000726B
		public ushort WMinute
		{
			get
			{
				return this.interop.wMinute;
			}
			set
			{
				this.interop.wMinute = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00009079 File Offset: 0x00007279
		// (set) Token: 0x060002EB RID: 747 RVA: 0x00009086 File Offset: 0x00007286
		public ushort WSecond
		{
			get
			{
				return this.interop.wSecond;
			}
			set
			{
				this.interop.wSecond = value;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00009094 File Offset: 0x00007294
		// (set) Token: 0x060002ED RID: 749 RVA: 0x000090A1 File Offset: 0x000072A1
		public ushort WMilliseconds
		{
			get
			{
				return this.interop.wMilliseconds;
			}
			set
			{
				this.interop.wMilliseconds = value;
			}
		}

		// Token: 0x040000B8 RID: 184
		internal SYSTEMTIME interop;
	}
}
