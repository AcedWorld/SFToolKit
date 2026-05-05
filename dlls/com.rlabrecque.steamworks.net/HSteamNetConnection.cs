using System;

namespace Steamworks
{
	// Token: 0x020001AA RID: 426
	[Serializable]
	public struct HSteamNetConnection : IEquatable<HSteamNetConnection>, IComparable<HSteamNetConnection>
	{
		// Token: 0x06000A4C RID: 2636 RVA: 0x0000F514 File Offset: 0x0000D714
		public HSteamNetConnection(uint value)
		{
			this.m_HSteamNetConnection = value;
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x0000F51D File Offset: 0x0000D71D
		public override string ToString()
		{
			return this.m_HSteamNetConnection.ToString();
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x0000F52A File Offset: 0x0000D72A
		public override bool Equals(object other)
		{
			return other is HSteamNetConnection && this == (HSteamNetConnection)other;
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x0000F547 File Offset: 0x0000D747
		public override int GetHashCode()
		{
			return this.m_HSteamNetConnection.GetHashCode();
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x0000F554 File Offset: 0x0000D754
		public static bool operator ==(HSteamNetConnection x, HSteamNetConnection y)
		{
			return x.m_HSteamNetConnection == y.m_HSteamNetConnection;
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x0000F564 File Offset: 0x0000D764
		public static bool operator !=(HSteamNetConnection x, HSteamNetConnection y)
		{
			return !(x == y);
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x0000F570 File Offset: 0x0000D770
		public static explicit operator HSteamNetConnection(uint value)
		{
			return new HSteamNetConnection(value);
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x0000F578 File Offset: 0x0000D778
		public static explicit operator uint(HSteamNetConnection that)
		{
			return that.m_HSteamNetConnection;
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x0000F580 File Offset: 0x0000D780
		public bool Equals(HSteamNetConnection other)
		{
			return this.m_HSteamNetConnection == other.m_HSteamNetConnection;
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x0000F590 File Offset: 0x0000D790
		public int CompareTo(HSteamNetConnection other)
		{
			return this.m_HSteamNetConnection.CompareTo(other.m_HSteamNetConnection);
		}

		// Token: 0x04000A7A RID: 2682
		public static readonly HSteamNetConnection Invalid = new HSteamNetConnection(0U);

		// Token: 0x04000A7B RID: 2683
		public uint m_HSteamNetConnection;
	}
}
