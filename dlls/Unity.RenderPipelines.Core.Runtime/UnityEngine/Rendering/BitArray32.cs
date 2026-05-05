using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace UnityEngine.Rendering
{
	// Token: 0x020000CA RID: 202
	[DebuggerDisplay("{this.GetType().Name} {humanizedData}")]
	[Serializable]
	public struct BitArray32 : IBitArray
	{
		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600065C RID: 1628 RVA: 0x0001F719 File Offset: 0x0001D919
		public uint capacity
		{
			get
			{
				return 32U;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600065D RID: 1629 RVA: 0x0001F71D File Offset: 0x0001D91D
		public bool allFalse
		{
			get
			{
				return this.data == 0U;
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600065E RID: 1630 RVA: 0x0001F728 File Offset: 0x0001D928
		public bool allTrue
		{
			get
			{
				return this.data == uint.MaxValue;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600065F RID: 1631 RVA: 0x0001F733 File Offset: 0x0001D933
		private string humanizedVersion
		{
			get
			{
				return Convert.ToString((long)((ulong)this.data), 2);
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x0001F744 File Offset: 0x0001D944
		public string humanizedData
		{
			get
			{
				return Regex.Replace(string.Format("{0, " + this.capacity.ToString() + "}", Convert.ToString((long)((ulong)this.data), 2)).Replace(' ', '0'), ".{8}", "$0.").TrimEnd('.');
			}
		}

		// Token: 0x17000102 RID: 258
		public bool this[uint index]
		{
			get
			{
				return BitArrayUtilities.Get32(index, this.data);
			}
			set
			{
				BitArrayUtilities.Set32(index, ref this.data, value);
			}
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x0001F7BC File Offset: 0x0001D9BC
		public BitArray32(uint initValue)
		{
			this.data = initValue;
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x0001F7C8 File Offset: 0x0001D9C8
		public BitArray32(IEnumerable<uint> bitIndexTrue)
		{
			this.data = 0U;
			if (bitIndexTrue == null)
			{
				return;
			}
			for (int i = bitIndexTrue.Count<uint>() - 1; i >= 0; i--)
			{
				uint num = bitIndexTrue.ElementAt(i);
				if (num < this.capacity)
				{
					this.data |= 1U << (int)num;
				}
			}
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x0001F817 File Offset: 0x0001DA17
		public IBitArray BitAnd(IBitArray other)
		{
			return this & (BitArray32)other;
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x0001F82F File Offset: 0x0001DA2F
		public IBitArray BitOr(IBitArray other)
		{
			return this | (BitArray32)other;
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x0001F847 File Offset: 0x0001DA47
		public IBitArray BitNot()
		{
			return ~this;
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x0001F859 File Offset: 0x0001DA59
		public static BitArray32 operator ~(BitArray32 a)
		{
			return new BitArray32(~a.data);
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x0001F867 File Offset: 0x0001DA67
		public static BitArray32 operator |(BitArray32 a, BitArray32 b)
		{
			return new BitArray32(a.data | b.data);
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0001F87B File Offset: 0x0001DA7B
		public static BitArray32 operator &(BitArray32 a, BitArray32 b)
		{
			return new BitArray32(a.data & b.data);
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x0001F88F File Offset: 0x0001DA8F
		public static bool operator ==(BitArray32 a, BitArray32 b)
		{
			return a.data == b.data;
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0001F89F File Offset: 0x0001DA9F
		public static bool operator !=(BitArray32 a, BitArray32 b)
		{
			return a.data != b.data;
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0001F8B2 File Offset: 0x0001DAB2
		public override bool Equals(object obj)
		{
			return obj is BitArray32 && ((BitArray32)obj).data == this.data;
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x0001F8D1 File Offset: 0x0001DAD1
		public override int GetHashCode()
		{
			return 1768953197 + this.data.GetHashCode();
		}

		// Token: 0x0400046E RID: 1134
		[SerializeField]
		private uint data;
	}
}
