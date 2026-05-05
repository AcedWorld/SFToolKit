using System;

namespace Unity.Collections
{
	// Token: 0x02000022 RID: 34
	internal sealed class BitField64DebugView
	{
		// Token: 0x060000BE RID: 190 RVA: 0x00003A05 File Offset: 0x00001C05
		public BitField64DebugView(BitField64 data)
		{
			this.Data = data;
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00003A14 File Offset: 0x00001C14
		public bool[] Bits
		{
			get
			{
				bool[] array = new bool[64];
				for (int i = 0; i < 64; i++)
				{
					array[i] = this.Data.IsSet(i);
				}
				return array;
			}
		}

		// Token: 0x0400006C RID: 108
		private BitField64 Data;
	}
}
