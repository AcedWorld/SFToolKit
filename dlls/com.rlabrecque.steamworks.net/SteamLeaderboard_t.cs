using System;

namespace Steamworks
{
	// Token: 0x020001C3 RID: 451
	[Serializable]
	public struct SteamLeaderboard_t : IEquatable<SteamLeaderboard_t>, IComparable<SteamLeaderboard_t>
	{
		// Token: 0x06000B41 RID: 2881 RVA: 0x00010497 File Offset: 0x0000E697
		public SteamLeaderboard_t(ulong value)
		{
			this.m_SteamLeaderboard = value;
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x000104A0 File Offset: 0x0000E6A0
		public override string ToString()
		{
			return this.m_SteamLeaderboard.ToString();
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x000104AD File Offset: 0x0000E6AD
		public override bool Equals(object other)
		{
			return other is SteamLeaderboard_t && this == (SteamLeaderboard_t)other;
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x000104CA File Offset: 0x0000E6CA
		public override int GetHashCode()
		{
			return this.m_SteamLeaderboard.GetHashCode();
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x000104D7 File Offset: 0x0000E6D7
		public static bool operator ==(SteamLeaderboard_t x, SteamLeaderboard_t y)
		{
			return x.m_SteamLeaderboard == y.m_SteamLeaderboard;
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x000104E7 File Offset: 0x0000E6E7
		public static bool operator !=(SteamLeaderboard_t x, SteamLeaderboard_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x000104F3 File Offset: 0x0000E6F3
		public static explicit operator SteamLeaderboard_t(ulong value)
		{
			return new SteamLeaderboard_t(value);
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x000104FB File Offset: 0x0000E6FB
		public static explicit operator ulong(SteamLeaderboard_t that)
		{
			return that.m_SteamLeaderboard;
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x00010503 File Offset: 0x0000E703
		public bool Equals(SteamLeaderboard_t other)
		{
			return this.m_SteamLeaderboard == other.m_SteamLeaderboard;
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x00010513 File Offset: 0x0000E713
		public int CompareTo(SteamLeaderboard_t other)
		{
			return this.m_SteamLeaderboard.CompareTo(other.m_SteamLeaderboard);
		}

		// Token: 0x04000AB8 RID: 2744
		public ulong m_SteamLeaderboard;
	}
}
