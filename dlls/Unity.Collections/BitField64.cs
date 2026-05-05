using System;
using System.Diagnostics;
using Unity.Mathematics;

namespace Unity.Collections
{
	// Token: 0x02000021 RID: 33
	[DebuggerTypeProxy(typeof(BitField64DebugView))]
	[BurstCompatible]
	public struct BitField64
	{
		// Token: 0x060000B1 RID: 177 RVA: 0x000038DE File Offset: 0x00001ADE
		public BitField64(ulong initialValue = 0UL)
		{
			this.Value = initialValue;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000038E7 File Offset: 0x00001AE7
		public void Clear()
		{
			this.Value = 0UL;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000038F1 File Offset: 0x00001AF1
		public void SetBits(int pos, bool value)
		{
			this.Value = Bitwise.SetBits(this.Value, pos, 1UL, value);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00003908 File Offset: 0x00001B08
		public void SetBits(int pos, bool value, int numBits = 1)
		{
			ulong mask = ulong.MaxValue >> 64 - numBits;
			this.Value = Bitwise.SetBits(this.Value, pos, mask, value);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00003934 File Offset: 0x00001B34
		public ulong GetBits(int pos, int numBits = 1)
		{
			ulong mask = ulong.MaxValue >> 64 - numBits;
			return Bitwise.ExtractBits(this.Value, pos, mask);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003959 File Offset: 0x00001B59
		public bool IsSet(int pos)
		{
			return this.GetBits(pos, 1) > 0UL;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003967 File Offset: 0x00001B67
		public bool TestNone(int pos, int numBits = 1)
		{
			return this.GetBits(pos, numBits) == 0UL;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003975 File Offset: 0x00001B75
		public bool TestAny(int pos, int numBits = 1)
		{
			return this.GetBits(pos, numBits) > 0UL;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00003984 File Offset: 0x00001B84
		public bool TestAll(int pos, int numBits = 1)
		{
			ulong num = ulong.MaxValue >> 64 - numBits;
			return num == Bitwise.ExtractBits(this.Value, pos, num);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000039AC File Offset: 0x00001BAC
		public int CountBits()
		{
			return math.countbits(this.Value);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000039B9 File Offset: 0x00001BB9
		public int CountLeadingZeros()
		{
			return math.lzcnt(this.Value);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000039C6 File Offset: 0x00001BC6
		public int CountTrailingZeros()
		{
			return math.tzcnt(this.Value);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000039D3 File Offset: 0x00001BD3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckArgs(int pos, int numBits)
		{
			if (pos > 63 || numBits == 0 || numBits > 64 || pos + numBits > 64)
			{
				throw new ArgumentException(string.Format("BitField32 invalid arguments: pos {0} (must be 0-63), numBits {1} (must be 1-64).", pos, numBits));
			}
		}

		// Token: 0x0400006B RID: 107
		public ulong Value;
	}
}
