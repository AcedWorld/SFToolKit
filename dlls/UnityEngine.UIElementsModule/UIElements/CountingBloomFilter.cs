using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine.UIElements
{
	// Token: 0x02000150 RID: 336
	internal struct CountingBloomFilter
	{
		// Token: 0x06000AE6 RID: 2790 RVA: 0x0002BE4C File Offset: 0x0002A04C
		private unsafe void AdjustSlot(uint index, bool increment)
		{
			if (increment)
			{
				bool flag = *(ref this.m_Counters.FixedElementField + (UIntPtr)index) != byte.MaxValue;
				if (flag)
				{
					ref byte ptr = ref this.m_Counters.FixedElementField + (UIntPtr)index;
					ptr += 1;
				}
			}
			else
			{
				bool flag2 = *(ref this.m_Counters.FixedElementField + (UIntPtr)index) > 0;
				if (flag2)
				{
					ref byte ptr2 = ref this.m_Counters.FixedElementField + (UIntPtr)index;
					ptr2 -= 1;
				}
			}
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x0002BEC0 File Offset: 0x0002A0C0
		private uint Hash1(uint hash)
		{
			return hash & 16383U;
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x0002BEDC File Offset: 0x0002A0DC
		private uint Hash2(uint hash)
		{
			return hash >> 14 & 16383U;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x0002BEF8 File Offset: 0x0002A0F8
		private unsafe bool IsSlotEmpty(uint index)
		{
			return *(ref this.m_Counters.FixedElementField + (UIntPtr)index) == 0;
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x0002BF1C File Offset: 0x0002A11C
		public void InsertHash(uint hash)
		{
			this.AdjustSlot(this.Hash1(hash), true);
			this.AdjustSlot(this.Hash2(hash), true);
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x0002BF3D File Offset: 0x0002A13D
		public void RemoveHash(uint hash)
		{
			this.AdjustSlot(this.Hash1(hash), false);
			this.AdjustSlot(this.Hash2(hash), false);
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0002BF60 File Offset: 0x0002A160
		public bool ContainsHash(uint hash)
		{
			return !this.IsSlotEmpty(this.Hash1(hash)) && !this.IsSlotEmpty(this.Hash2(hash));
		}

		// Token: 0x04000532 RID: 1330
		private const int KEY_SIZE = 14;

		// Token: 0x04000533 RID: 1331
		private const uint ARRAY_SIZE = 16384U;

		// Token: 0x04000534 RID: 1332
		private const int KEY_MASK = 16383;

		// Token: 0x04000535 RID: 1333
		[FixedBuffer(typeof(byte), 16384)]
		private CountingBloomFilter.<m_Counters>e__FixedBuffer m_Counters;

		// Token: 0x02000151 RID: 337
		[UnsafeValueType]
		[CompilerGenerated]
		[StructLayout(LayoutKind.Sequential, Size = 16384)]
		public struct <m_Counters>e__FixedBuffer
		{
			// Token: 0x04000536 RID: 1334
			public byte FixedElementField;
		}
	}
}
