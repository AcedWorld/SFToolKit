using System;

namespace Steamworks
{
	// Token: 0x020001BD RID: 445
	[Serializable]
	public struct RTime32 : IEquatable<RTime32>, IComparable<RTime32>
	{
		// Token: 0x06000B07 RID: 2823 RVA: 0x0000FFC1 File Offset: 0x0000E1C1
		public RTime32(uint value)
		{
			this.m_RTime32 = value;
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x0000FFCA File Offset: 0x0000E1CA
		public override string ToString()
		{
			return this.m_RTime32.ToString();
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x0000FFD7 File Offset: 0x0000E1D7
		public override bool Equals(object other)
		{
			return other is RTime32 && this == (RTime32)other;
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x0000FFF4 File Offset: 0x0000E1F4
		public override int GetHashCode()
		{
			return this.m_RTime32.GetHashCode();
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x00010001 File Offset: 0x0000E201
		public static bool operator ==(RTime32 x, RTime32 y)
		{
			return x.m_RTime32 == y.m_RTime32;
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x00010011 File Offset: 0x0000E211
		public static bool operator !=(RTime32 x, RTime32 y)
		{
			return !(x == y);
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x0001001D File Offset: 0x0000E21D
		public static explicit operator RTime32(uint value)
		{
			return new RTime32(value);
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x00010025 File Offset: 0x0000E225
		public static explicit operator uint(RTime32 that)
		{
			return that.m_RTime32;
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x0001002D File Offset: 0x0000E22D
		public bool Equals(RTime32 other)
		{
			return this.m_RTime32 == other.m_RTime32;
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x0001003D File Offset: 0x0000E23D
		public int CompareTo(RTime32 other)
		{
			return this.m_RTime32.CompareTo(other.m_RTime32);
		}

		// Token: 0x04000AAD RID: 2733
		public uint m_RTime32;
	}
}
