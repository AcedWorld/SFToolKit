using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace UnityEngine.Rendering
{
	// Token: 0x020000CB RID: 203
	[DebuggerDisplay("{this.GetType().Name} {humanizedData}")]
	[Serializable]
	public struct BitArray64 : IBitArray
	{
		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600066F RID: 1647 RVA: 0x0001F8E4 File Offset: 0x0001DAE4
		public uint capacity
		{
			get
			{
				return 64U;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000670 RID: 1648 RVA: 0x0001F8E8 File Offset: 0x0001DAE8
		public bool allFalse
		{
			get
			{
				return this.data == 0UL;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000671 RID: 1649 RVA: 0x0001F8F4 File Offset: 0x0001DAF4
		public bool allTrue
		{
			get
			{
				return this.data == ulong.MaxValue;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000672 RID: 1650 RVA: 0x0001F900 File Offset: 0x0001DB00
		public string humanizedData
		{
			get
			{
				return Regex.Replace(string.Format("{0, " + this.capacity.ToString() + "}", Convert.ToString((long)this.data, 2)).Replace(' ', '0'), ".{8}", "$0.").TrimEnd('.');
			}
		}

		// Token: 0x17000107 RID: 263
		public bool this[uint index]
		{
			get
			{
				return BitArrayUtilities.Get64(index, this.data);
			}
			set
			{
				BitArrayUtilities.Set64(index, ref this.data, value);
			}
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x0001F977 File Offset: 0x0001DB77
		public BitArray64(ulong initValue)
		{
			this.data = initValue;
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0001F980 File Offset: 0x0001DB80
		public BitArray64(IEnumerable<uint> bitIndexTrue)
		{
			this.data = 0UL;
			if (bitIndexTrue == null)
			{
				return;
			}
			for (int i = bitIndexTrue.Count<uint>() - 1; i >= 0; i--)
			{
				uint num = bitIndexTrue.ElementAt(i);
				if (num < this.capacity)
				{
					this.data |= 1UL << (int)num;
				}
			}
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x0001F9D1 File Offset: 0x0001DBD1
		public static BitArray64 operator ~(BitArray64 a)
		{
			return new BitArray64(~a.data);
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x0001F9DF File Offset: 0x0001DBDF
		public static BitArray64 operator |(BitArray64 a, BitArray64 b)
		{
			return new BitArray64(a.data | b.data);
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x0001F9F3 File Offset: 0x0001DBF3
		public static BitArray64 operator &(BitArray64 a, BitArray64 b)
		{
			return new BitArray64(a.data & b.data);
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x0001FA07 File Offset: 0x0001DC07
		public IBitArray BitAnd(IBitArray other)
		{
			return this & (BitArray64)other;
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x0001FA1F File Offset: 0x0001DC1F
		public IBitArray BitOr(IBitArray other)
		{
			return this | (BitArray64)other;
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x0001FA37 File Offset: 0x0001DC37
		public IBitArray BitNot()
		{
			return ~this;
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x0001FA49 File Offset: 0x0001DC49
		public static bool operator ==(BitArray64 a, BitArray64 b)
		{
			return a.data == b.data;
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x0001FA59 File Offset: 0x0001DC59
		public static bool operator !=(BitArray64 a, BitArray64 b)
		{
			return a.data != b.data;
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x0001FA6C File Offset: 0x0001DC6C
		public override bool Equals(object obj)
		{
			return obj is BitArray64 && ((BitArray64)obj).data == this.data;
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x0001FA8B File Offset: 0x0001DC8B
		public override int GetHashCode()
		{
			return 1768953197 + this.data.GetHashCode();
		}

		// Token: 0x0400046F RID: 1135
		[SerializeField]
		private ulong data;
	}
}
