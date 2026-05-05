using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace UnityEngine.Rendering
{
	// Token: 0x020000C8 RID: 200
	[DebuggerDisplay("{this.GetType().Name} {humanizedData}")]
	[Serializable]
	public struct BitArray8 : IBitArray
	{
		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000638 RID: 1592 RVA: 0x0001F3AC File Offset: 0x0001D5AC
		public uint capacity
		{
			get
			{
				return 8U;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000639 RID: 1593 RVA: 0x0001F3AF File Offset: 0x0001D5AF
		public bool allFalse
		{
			get
			{
				return this.data == 0;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600063A RID: 1594 RVA: 0x0001F3BA File Offset: 0x0001D5BA
		public bool allTrue
		{
			get
			{
				return this.data == byte.MaxValue;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600063B RID: 1595 RVA: 0x0001F3CC File Offset: 0x0001D5CC
		public string humanizedData
		{
			get
			{
				return string.Format("{0, " + this.capacity.ToString() + "}", Convert.ToString(this.data, 2)).Replace(' ', '0');
			}
		}

		// Token: 0x170000F7 RID: 247
		public bool this[uint index]
		{
			get
			{
				return BitArrayUtilities.Get8(index, this.data);
			}
			set
			{
				BitArrayUtilities.Set8(index, ref this.data, value);
			}
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x0001F42D File Offset: 0x0001D62D
		public BitArray8(byte initValue)
		{
			this.data = initValue;
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x0001F438 File Offset: 0x0001D638
		public BitArray8(IEnumerable<uint> bitIndexTrue)
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
					this.data |= (byte)(1 << (int)num);
				}
			}
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x0001F489 File Offset: 0x0001D689
		public static BitArray8 operator ~(BitArray8 a)
		{
			return new BitArray8(~a.data);
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x0001F498 File Offset: 0x0001D698
		public static BitArray8 operator |(BitArray8 a, BitArray8 b)
		{
			return new BitArray8(a.data | b.data);
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x0001F4AD File Offset: 0x0001D6AD
		public static BitArray8 operator &(BitArray8 a, BitArray8 b)
		{
			return new BitArray8(a.data & b.data);
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x0001F4C2 File Offset: 0x0001D6C2
		public IBitArray BitAnd(IBitArray other)
		{
			return this & (BitArray8)other;
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0001F4DA File Offset: 0x0001D6DA
		public IBitArray BitOr(IBitArray other)
		{
			return this | (BitArray8)other;
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x0001F4F2 File Offset: 0x0001D6F2
		public IBitArray BitNot()
		{
			return ~this;
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x0001F504 File Offset: 0x0001D704
		public static bool operator ==(BitArray8 a, BitArray8 b)
		{
			return a.data == b.data;
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x0001F514 File Offset: 0x0001D714
		public static bool operator !=(BitArray8 a, BitArray8 b)
		{
			return a.data != b.data;
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x0001F527 File Offset: 0x0001D727
		public override bool Equals(object obj)
		{
			return obj is BitArray8 && ((BitArray8)obj).data == this.data;
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x0001F546 File Offset: 0x0001D746
		public override int GetHashCode()
		{
			return 1768953197 + this.data.GetHashCode();
		}

		// Token: 0x0400046C RID: 1132
		[SerializeField]
		private byte data;
	}
}
