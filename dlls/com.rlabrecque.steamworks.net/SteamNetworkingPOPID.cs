using System;

namespace Steamworks
{
	// Token: 0x020001B2 RID: 434
	[Serializable]
	public struct SteamNetworkingPOPID : IEquatable<SteamNetworkingPOPID>, IComparable<SteamNetworkingPOPID>
	{
		// Token: 0x06000A91 RID: 2705 RVA: 0x0000F92F File Offset: 0x0000DB2F
		public SteamNetworkingPOPID(uint value)
		{
			this.m_SteamNetworkingPOPID = value;
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x0000F938 File Offset: 0x0000DB38
		public override string ToString()
		{
			return this.m_SteamNetworkingPOPID.ToString();
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x0000F945 File Offset: 0x0000DB45
		public override bool Equals(object other)
		{
			return other is SteamNetworkingPOPID && this == (SteamNetworkingPOPID)other;
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x0000F962 File Offset: 0x0000DB62
		public override int GetHashCode()
		{
			return this.m_SteamNetworkingPOPID.GetHashCode();
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x0000F96F File Offset: 0x0000DB6F
		public static bool operator ==(SteamNetworkingPOPID x, SteamNetworkingPOPID y)
		{
			return x.m_SteamNetworkingPOPID == y.m_SteamNetworkingPOPID;
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x0000F97F File Offset: 0x0000DB7F
		public static bool operator !=(SteamNetworkingPOPID x, SteamNetworkingPOPID y)
		{
			return !(x == y);
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x0000F98B File Offset: 0x0000DB8B
		public static explicit operator SteamNetworkingPOPID(uint value)
		{
			return new SteamNetworkingPOPID(value);
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x0000F993 File Offset: 0x0000DB93
		public static explicit operator uint(SteamNetworkingPOPID that)
		{
			return that.m_SteamNetworkingPOPID;
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x0000F99B File Offset: 0x0000DB9B
		public bool Equals(SteamNetworkingPOPID other)
		{
			return this.m_SteamNetworkingPOPID == other.m_SteamNetworkingPOPID;
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x0000F9AB File Offset: 0x0000DBAB
		public int CompareTo(SteamNetworkingPOPID other)
		{
			return this.m_SteamNetworkingPOPID.CompareTo(other.m_SteamNetworkingPOPID);
		}

		// Token: 0x04000A9A RID: 2714
		public uint m_SteamNetworkingPOPID;
	}
}
