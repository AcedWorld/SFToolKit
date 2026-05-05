using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace UnityEngine.Rendering
{
	// Token: 0x020000C9 RID: 201
	[DebuggerDisplay("{this.GetType().Name} {humanizedData}")]
	[Serializable]
	public struct BitArray16 : IBitArray
	{
		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x0600064A RID: 1610 RVA: 0x0001F559 File Offset: 0x0001D759
		public uint capacity
		{
			get
			{
				return 16U;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600064B RID: 1611 RVA: 0x0001F55D File Offset: 0x0001D75D
		public bool allFalse
		{
			get
			{
				return this.data == 0;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x0600064C RID: 1612 RVA: 0x0001F568 File Offset: 0x0001D768
		public bool allTrue
		{
			get
			{
				return this.data == ushort.MaxValue;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x0600064D RID: 1613 RVA: 0x0001F578 File Offset: 0x0001D778
		public string humanizedData
		{
			get
			{
				return Regex.Replace(string.Format("{0, " + this.capacity.ToString() + "}", Convert.ToString((int)this.data, 2)).Replace(' ', '0'), ".{8}", "$0.").TrimEnd('.');
			}
		}

		// Token: 0x170000FC RID: 252
		public bool this[uint index]
		{
			get
			{
				return BitArrayUtilities.Get16(index, this.data);
			}
			set
			{
				BitArrayUtilities.Set16(index, ref this.data, value);
			}
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0001F5EF File Offset: 0x0001D7EF
		public BitArray16(ushort initValue)
		{
			this.data = initValue;
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x0001F5F8 File Offset: 0x0001D7F8
		public BitArray16(IEnumerable<uint> bitIndexTrue)
		{
			this.data = 0;
			if (bitIndexTrue == null)
			{
				return;
			}
			for (int i = bitIndexTrue.Count<uint>() - 1; i >= 0; i--)
			{
				uint num = bitIndexTrue.ElementAt(i);
				if (num < this.capacity)
				{
					this.data |= (ushort)(1 << (int)num);
				}
			}
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0001F649 File Offset: 0x0001D849
		public static BitArray16 operator ~(BitArray16 a)
		{
			return new BitArray16(~a.data);
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x0001F658 File Offset: 0x0001D858
		public static BitArray16 operator |(BitArray16 a, BitArray16 b)
		{
			return new BitArray16(a.data | b.data);
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x0001F66D File Offset: 0x0001D86D
		public static BitArray16 operator &(BitArray16 a, BitArray16 b)
		{
			return new BitArray16(a.data & b.data);
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x0001F682 File Offset: 0x0001D882
		public IBitArray BitAnd(IBitArray other)
		{
			return this & (BitArray16)other;
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0001F69A File Offset: 0x0001D89A
		public IBitArray BitOr(IBitArray other)
		{
			return this | (BitArray16)other;
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x0001F6B2 File Offset: 0x0001D8B2
		public IBitArray BitNot()
		{
			return ~this;
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x0001F6C4 File Offset: 0x0001D8C4
		public static bool operator ==(BitArray16 a, BitArray16 b)
		{
			return a.data == b.data;
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0001F6D4 File Offset: 0x0001D8D4
		public static bool operator !=(BitArray16 a, BitArray16 b)
		{
			return a.data != b.data;
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0001F6E7 File Offset: 0x0001D8E7
		public override bool Equals(object obj)
		{
			return obj is BitArray16 && ((BitArray16)obj).data == this.data;
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0001F706 File Offset: 0x0001D906
		public override int GetHashCode()
		{
			return 1768953197 + this.data.GetHashCode();
		}

		// Token: 0x0400046D RID: 1133
		[SerializeField]
		private ushort data;
	}
}
