using System;

namespace Steamworks
{
	// Token: 0x020001BB RID: 443
	[Serializable]
	public struct DepotId_t : IEquatable<DepotId_t>, IComparable<DepotId_t>
	{
		// Token: 0x06000AF1 RID: 2801 RVA: 0x0000FE88 File Offset: 0x0000E088
		public DepotId_t(uint value)
		{
			this.m_DepotId = value;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x0000FE91 File Offset: 0x0000E091
		public override string ToString()
		{
			return this.m_DepotId.ToString();
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0000FE9E File Offset: 0x0000E09E
		public override bool Equals(object other)
		{
			return other is DepotId_t && this == (DepotId_t)other;
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x0000FEBB File Offset: 0x0000E0BB
		public override int GetHashCode()
		{
			return this.m_DepotId.GetHashCode();
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x0000FEC8 File Offset: 0x0000E0C8
		public static bool operator ==(DepotId_t x, DepotId_t y)
		{
			return x.m_DepotId == y.m_DepotId;
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x0000FED8 File Offset: 0x0000E0D8
		public static bool operator !=(DepotId_t x, DepotId_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x0000FEE4 File Offset: 0x0000E0E4
		public static explicit operator DepotId_t(uint value)
		{
			return new DepotId_t(value);
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x0000FEEC File Offset: 0x0000E0EC
		public static explicit operator uint(DepotId_t that)
		{
			return that.m_DepotId;
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0000FEF4 File Offset: 0x0000E0F4
		public bool Equals(DepotId_t other)
		{
			return this.m_DepotId == other.m_DepotId;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x0000FF04 File Offset: 0x0000E104
		public int CompareTo(DepotId_t other)
		{
			return this.m_DepotId.CompareTo(other.m_DepotId);
		}

		// Token: 0x04000AA9 RID: 2729
		public static readonly DepotId_t Invalid = new DepotId_t(0U);

		// Token: 0x04000AAA RID: 2730
		public uint m_DepotId;
	}
}
