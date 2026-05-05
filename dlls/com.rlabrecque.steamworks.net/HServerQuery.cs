using System;

namespace Steamworks
{
	// Token: 0x020001A3 RID: 419
	[Serializable]
	public struct HServerQuery : IEquatable<HServerQuery>, IComparable<HServerQuery>
	{
		// Token: 0x06000A1A RID: 2586 RVA: 0x0000F293 File Offset: 0x0000D493
		public HServerQuery(int value)
		{
			this.m_HServerQuery = value;
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x0000F29C File Offset: 0x0000D49C
		public override string ToString()
		{
			return this.m_HServerQuery.ToString();
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x0000F2A9 File Offset: 0x0000D4A9
		public override bool Equals(object other)
		{
			return other is HServerQuery && this == (HServerQuery)other;
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x0000F2C6 File Offset: 0x0000D4C6
		public override int GetHashCode()
		{
			return this.m_HServerQuery.GetHashCode();
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x0000F2D3 File Offset: 0x0000D4D3
		public static bool operator ==(HServerQuery x, HServerQuery y)
		{
			return x.m_HServerQuery == y.m_HServerQuery;
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x0000F2E3 File Offset: 0x0000D4E3
		public static bool operator !=(HServerQuery x, HServerQuery y)
		{
			return !(x == y);
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x0000F2EF File Offset: 0x0000D4EF
		public static explicit operator HServerQuery(int value)
		{
			return new HServerQuery(value);
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x0000F2F7 File Offset: 0x0000D4F7
		public static explicit operator int(HServerQuery that)
		{
			return that.m_HServerQuery;
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x0000F2FF File Offset: 0x0000D4FF
		public bool Equals(HServerQuery other)
		{
			return this.m_HServerQuery == other.m_HServerQuery;
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x0000F30F File Offset: 0x0000D50F
		public int CompareTo(HServerQuery other)
		{
			return this.m_HServerQuery.CompareTo(other.m_HServerQuery);
		}

		// Token: 0x04000A74 RID: 2676
		public static readonly HServerQuery Invalid = new HServerQuery(-1);

		// Token: 0x04000A75 RID: 2677
		public int m_HServerQuery;
	}
}
