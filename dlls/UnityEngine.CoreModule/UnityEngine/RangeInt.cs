using System;

namespace UnityEngine
{
	// Token: 0x02000253 RID: 595
	public struct RangeInt
	{
		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06001963 RID: 6499 RVA: 0x0002A728 File Offset: 0x00028928
		public int end
		{
			get
			{
				return this.start + this.length;
			}
		}

		// Token: 0x06001964 RID: 6500 RVA: 0x0002A747 File Offset: 0x00028947
		public RangeInt(int start, int length)
		{
			this.start = start;
			this.length = length;
		}

		// Token: 0x040008CE RID: 2254
		public int start;

		// Token: 0x040008CF RID: 2255
		public int length;
	}
}
