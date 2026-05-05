using System;

namespace Unity.Networking.Transport.Utilities
{
	// Token: 0x020000C6 RID: 198
	public static class SequenceHelpers
	{
		// Token: 0x060002F5 RID: 757 RVA: 0x00010F86 File Offset: 0x0000F186
		public static int AbsDistance(ushort lhs, ushort rhs)
		{
			if (SequenceHelpers.GreaterThan16(lhs, rhs))
			{
				if (lhs <= rhs)
				{
					return (int)(lhs + ushort.MaxValue + 1 - rhs);
				}
				return (int)(lhs - rhs);
			}
			else
			{
				if (rhs < lhs)
				{
					return (int)(rhs + ushort.MaxValue + 1 - lhs);
				}
				return (int)(rhs - lhs);
			}
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00010FB8 File Offset: 0x0000F1B8
		public static bool IsNewer(uint current, uint old)
		{
			return old - current >= 2147483648U;
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00010FC7 File Offset: 0x0000F1C7
		public static bool GreaterThan16(ushort lhs, ushort rhs)
		{
			return (lhs > rhs && lhs - rhs <= 32767) || (lhs < rhs && rhs - lhs > 32767);
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00010FE9 File Offset: 0x0000F1E9
		public static bool LessThan16(ushort lhs, ushort rhs)
		{
			return SequenceHelpers.GreaterThan16(rhs, lhs);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00010FF2 File Offset: 0x0000F1F2
		public static bool StalePacket(ushort sequence, ushort oldSequence, ushort windowSize)
		{
			return SequenceHelpers.LessThan16(sequence, oldSequence - windowSize);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00011000 File Offset: 0x0000F200
		public static string BitMaskToString(uint mask)
		{
			char[] array = new char[32];
			for (int i = 31; i >= 0; i--)
			{
				array[i] = (((mask & 1U) != 0U) ? '1' : '0');
				mask >>= 1;
			}
			return new string(array);
		}
	}
}
