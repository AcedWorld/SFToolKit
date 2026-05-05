using System;

namespace Steamworks
{
	// Token: 0x020001B1 RID: 433
	[Serializable]
	public struct SteamNetworkingMicroseconds : IEquatable<SteamNetworkingMicroseconds>, IComparable<SteamNetworkingMicroseconds>
	{
		// Token: 0x06000A87 RID: 2695 RVA: 0x0000F8A0 File Offset: 0x0000DAA0
		public SteamNetworkingMicroseconds(long value)
		{
			this.m_SteamNetworkingMicroseconds = value;
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x0000F8A9 File Offset: 0x0000DAA9
		public override string ToString()
		{
			return this.m_SteamNetworkingMicroseconds.ToString();
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x0000F8B6 File Offset: 0x0000DAB6
		public override bool Equals(object other)
		{
			return other is SteamNetworkingMicroseconds && this == (SteamNetworkingMicroseconds)other;
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x0000F8D3 File Offset: 0x0000DAD3
		public override int GetHashCode()
		{
			return this.m_SteamNetworkingMicroseconds.GetHashCode();
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x0000F8E0 File Offset: 0x0000DAE0
		public static bool operator ==(SteamNetworkingMicroseconds x, SteamNetworkingMicroseconds y)
		{
			return x.m_SteamNetworkingMicroseconds == y.m_SteamNetworkingMicroseconds;
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x0000F8F0 File Offset: 0x0000DAF0
		public static bool operator !=(SteamNetworkingMicroseconds x, SteamNetworkingMicroseconds y)
		{
			return !(x == y);
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x0000F8FC File Offset: 0x0000DAFC
		public static explicit operator SteamNetworkingMicroseconds(long value)
		{
			return new SteamNetworkingMicroseconds(value);
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x0000F904 File Offset: 0x0000DB04
		public static explicit operator long(SteamNetworkingMicroseconds that)
		{
			return that.m_SteamNetworkingMicroseconds;
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x0000F90C File Offset: 0x0000DB0C
		public bool Equals(SteamNetworkingMicroseconds other)
		{
			return this.m_SteamNetworkingMicroseconds == other.m_SteamNetworkingMicroseconds;
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x0000F91C File Offset: 0x0000DB1C
		public int CompareTo(SteamNetworkingMicroseconds other)
		{
			return this.m_SteamNetworkingMicroseconds.CompareTo(other.m_SteamNetworkingMicroseconds);
		}

		// Token: 0x04000A99 RID: 2713
		public long m_SteamNetworkingMicroseconds;
	}
}
