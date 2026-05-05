using System;
using System.Diagnostics;
using Unity.Mathematics;

namespace Unity.Collections
{
	// Token: 0x0200001F RID: 31
	[DebuggerTypeProxy(typeof(BitField32DebugView))]
	[BurstCompatible]
	public struct BitField32
	{
		// Token: 0x060000A2 RID: 162 RVA: 0x0000377C File Offset: 0x0000197C
		public BitField32(uint initialValue = 0U)
		{
			this.Value = initialValue;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003785 File Offset: 0x00001985
		public void Clear()
		{
			this.Value = 0U;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000378E File Offset: 0x0000198E
		public void SetBits(int pos, bool value)
		{
			this.Value = Bitwise.SetBits(this.Value, pos, 1U, value);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000037A4 File Offset: 0x000019A4
		public void SetBits(int pos, bool value, int numBits)
		{
			uint mask = uint.MaxValue >> 32 - numBits;
			this.Value = Bitwise.SetBits(this.Value, pos, mask, value);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000037D0 File Offset: 0x000019D0
		public uint GetBits(int pos, int numBits = 1)
		{
			uint mask = uint.MaxValue >> 32 - numBits;
			return Bitwise.ExtractBits(this.Value, pos, mask);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000037F4 File Offset: 0x000019F4
		public bool IsSet(int pos)
		{
			return this.GetBits(pos, 1) > 0U;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003801 File Offset: 0x00001A01
		public bool TestNone(int pos, int numBits = 1)
		{
			return this.GetBits(pos, numBits) == 0U;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000380E File Offset: 0x00001A0E
		public bool TestAny(int pos, int numBits = 1)
		{
			return this.GetBits(pos, numBits) > 0U;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000381C File Offset: 0x00001A1C
		public bool TestAll(int pos, int numBits = 1)
		{
			uint num = uint.MaxValue >> 32 - numBits;
			return num == Bitwise.ExtractBits(this.Value, pos, num);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003843 File Offset: 0x00001A43
		public int CountBits()
		{
			return math.countbits(this.Value);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00003850 File Offset: 0x00001A50
		public int CountLeadingZeros()
		{
			return math.lzcnt(this.Value);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000385D File Offset: 0x00001A5D
		public int CountTrailingZeros()
		{
			return math.tzcnt(this.Value);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000386A File Offset: 0x00001A6A
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckArgs(int pos, int numBits)
		{
			if (pos > 31 || numBits == 0 || numBits > 32 || pos + numBits > 32)
			{
				throw new ArgumentException(string.Format("BitField32 invalid arguments: pos {0} (must be 0-31), numBits {1} (must be 1-32).", pos, numBits));
			}
		}

		// Token: 0x04000069 RID: 105
		public uint Value;
	}
}
