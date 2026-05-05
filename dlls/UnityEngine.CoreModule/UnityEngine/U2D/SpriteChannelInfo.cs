using System;
using UnityEngine.Bindings;

namespace UnityEngine.U2D
{
	// Token: 0x020002B4 RID: 692
	[VisibleToOtherModules]
	internal struct SpriteChannelInfo
	{
		// Token: 0x170005D7 RID: 1495
		// (get) Token: 0x06001D77 RID: 7543 RVA: 0x0003096C File Offset: 0x0002EB6C
		// (set) Token: 0x06001D78 RID: 7544 RVA: 0x00030989 File Offset: 0x0002EB89
		public unsafe void* buffer
		{
			get
			{
				return (void*)this.m_Buffer;
			}
			set
			{
				this.m_Buffer = (IntPtr)value;
			}
		}

		// Token: 0x170005D8 RID: 1496
		// (get) Token: 0x06001D79 RID: 7545 RVA: 0x00030998 File Offset: 0x0002EB98
		// (set) Token: 0x06001D7A RID: 7546 RVA: 0x000309B0 File Offset: 0x0002EBB0
		public int count
		{
			get
			{
				return this.m_Count;
			}
			set
			{
				this.m_Count = value;
			}
		}

		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x06001D7B RID: 7547 RVA: 0x000309BC File Offset: 0x0002EBBC
		// (set) Token: 0x06001D7C RID: 7548 RVA: 0x000309D4 File Offset: 0x0002EBD4
		public int offset
		{
			get
			{
				return this.m_Offset;
			}
			set
			{
				this.m_Offset = value;
			}
		}

		// Token: 0x170005DA RID: 1498
		// (get) Token: 0x06001D7D RID: 7549 RVA: 0x000309E0 File Offset: 0x0002EBE0
		// (set) Token: 0x06001D7E RID: 7550 RVA: 0x000309F8 File Offset: 0x0002EBF8
		public int stride
		{
			get
			{
				return this.m_Stride;
			}
			set
			{
				this.m_Stride = value;
			}
		}

		// Token: 0x040009D0 RID: 2512
		[NativeName("buffer")]
		private IntPtr m_Buffer;

		// Token: 0x040009D1 RID: 2513
		[NativeName("count")]
		private int m_Count;

		// Token: 0x040009D2 RID: 2514
		[NativeName("offset")]
		private int m_Offset;

		// Token: 0x040009D3 RID: 2515
		[NativeName("stride")]
		private int m_Stride;
	}
}
