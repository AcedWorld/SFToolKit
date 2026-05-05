using System;

namespace Unity.Collections
{
	// Token: 0x02000020 RID: 32
	internal sealed class BitField32DebugView
	{
		// Token: 0x060000AF RID: 175 RVA: 0x0000389C File Offset: 0x00001A9C
		public BitField32DebugView(BitField32 bitfield)
		{
			this.BitField = bitfield;
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x000038AC File Offset: 0x00001AAC
		public bool[] Bits
		{
			get
			{
				bool[] array = new bool[32];
				for (int i = 0; i < 32; i++)
				{
					array[i] = this.BitField.IsSet(i);
				}
				return array;
			}
		}

		// Token: 0x0400006A RID: 106
		private BitField32 BitField;
	}
}
