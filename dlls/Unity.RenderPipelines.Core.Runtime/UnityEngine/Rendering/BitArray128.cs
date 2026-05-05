using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace UnityEngine.Rendering
{
	// Token: 0x020000CC RID: 204
	[DebuggerDisplay("{this.GetType().Name} {humanizedData}")]
	[Serializable]
	public struct BitArray128 : IBitArray
	{
		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x0001FA9E File Offset: 0x0001DC9E
		public uint capacity
		{
			get
			{
				return 128U;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000682 RID: 1666 RVA: 0x0001FAA5 File Offset: 0x0001DCA5
		public bool allFalse
		{
			get
			{
				return this.data1 == 0UL && this.data2 == 0UL;
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000683 RID: 1667 RVA: 0x0001FABB File Offset: 0x0001DCBB
		public bool allTrue
		{
			get
			{
				return this.data1 == ulong.MaxValue && this.data2 == ulong.MaxValue;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x0001FAD4 File Offset: 0x0001DCD4
		public string humanizedData
		{
			get
			{
				return Regex.Replace(string.Format("{0, " + 64U.ToString() + "}", Convert.ToString((long)this.data2, 2)).Replace(' ', '0'), ".{8}", "$0.") + Regex.Replace(string.Format("{0, " + 64U.ToString() + "}", Convert.ToString((long)this.data1, 2)).Replace(' ', '0'), ".{8}", "$0.").TrimEnd('.');
			}
		}

		// Token: 0x1700010C RID: 268
		public bool this[uint index]
		{
			get
			{
				return BitArrayUtilities.Get128(index, this.data1, this.data2);
			}
			set
			{
				BitArrayUtilities.Set128(index, ref this.data1, ref this.data2, value);
			}
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0001FB9A File Offset: 0x0001DD9A
		public BitArray128(ulong initValue1, ulong initValue2)
		{
			this.data1 = initValue1;
			this.data2 = initValue2;
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x0001FBAC File Offset: 0x0001DDAC
		public BitArray128(IEnumerable<uint> bitIndexTrue)
		{
			this.data1 = (this.data2 = 0UL);
			if (bitIndexTrue == null)
			{
				return;
			}
			for (int i = bitIndexTrue.Count<uint>() - 1; i >= 0; i--)
			{
				uint num = bitIndexTrue.ElementAt(i);
				if (num < 64U)
				{
					this.data1 |= 1UL << (int)num;
				}
				else if (num < this.capacity)
				{
					this.data2 |= 1UL << (int)(num - 64U);
				}
			}
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0001FC24 File Offset: 0x0001DE24
		public static BitArray128 operator ~(BitArray128 a)
		{
			return new BitArray128(~a.data1, ~a.data2);
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0001FC39 File Offset: 0x0001DE39
		public static BitArray128 operator |(BitArray128 a, BitArray128 b)
		{
			return new BitArray128(a.data1 | b.data1, a.data2 | b.data2);
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x0001FC5A File Offset: 0x0001DE5A
		public static BitArray128 operator &(BitArray128 a, BitArray128 b)
		{
			return new BitArray128(a.data1 & b.data1, a.data2 & b.data2);
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0001FC7B File Offset: 0x0001DE7B
		public IBitArray BitAnd(IBitArray other)
		{
			return this & (BitArray128)other;
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x0001FC93 File Offset: 0x0001DE93
		public IBitArray BitOr(IBitArray other)
		{
			return this | (BitArray128)other;
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0001FCAB File Offset: 0x0001DEAB
		public IBitArray BitNot()
		{
			return ~this;
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0001FCBD File Offset: 0x0001DEBD
		public static bool operator ==(BitArray128 a, BitArray128 b)
		{
			return a.data1 == b.data1 && a.data2 == b.data2;
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0001FCDD File Offset: 0x0001DEDD
		public static bool operator !=(BitArray128 a, BitArray128 b)
		{
			return a.data1 != b.data1 || a.data2 != b.data2;
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0001FD00 File Offset: 0x0001DF00
		public override bool Equals(object obj)
		{
			return obj is BitArray128 && this.data1.Equals(((BitArray128)obj).data1) && this.data2.Equals(((BitArray128)obj).data2);
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0001FD3A File Offset: 0x0001DF3A
		public override int GetHashCode()
		{
			return (1755735569 * -1521134295 + this.data1.GetHashCode()) * -1521134295 + this.data2.GetHashCode();
		}

		// Token: 0x04000470 RID: 1136
		[SerializeField]
		private ulong data1;

		// Token: 0x04000471 RID: 1137
		[SerializeField]
		private ulong data2;
	}
}
