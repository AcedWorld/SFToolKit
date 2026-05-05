using System;

namespace Steamworks
{
	// Token: 0x020001C2 RID: 450
	[Serializable]
	public struct SteamLeaderboardEntries_t : IEquatable<SteamLeaderboardEntries_t>, IComparable<SteamLeaderboardEntries_t>
	{
		// Token: 0x06000B37 RID: 2871 RVA: 0x00010408 File Offset: 0x0000E608
		public SteamLeaderboardEntries_t(ulong value)
		{
			this.m_SteamLeaderboardEntries = value;
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x00010411 File Offset: 0x0000E611
		public override string ToString()
		{
			return this.m_SteamLeaderboardEntries.ToString();
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x0001041E File Offset: 0x0000E61E
		public override bool Equals(object other)
		{
			return other is SteamLeaderboardEntries_t && this == (SteamLeaderboardEntries_t)other;
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x0001043B File Offset: 0x0000E63B
		public override int GetHashCode()
		{
			return this.m_SteamLeaderboardEntries.GetHashCode();
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x00010448 File Offset: 0x0000E648
		public static bool operator ==(SteamLeaderboardEntries_t x, SteamLeaderboardEntries_t y)
		{
			return x.m_SteamLeaderboardEntries == y.m_SteamLeaderboardEntries;
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x00010458 File Offset: 0x0000E658
		public static bool operator !=(SteamLeaderboardEntries_t x, SteamLeaderboardEntries_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x00010464 File Offset: 0x0000E664
		public static explicit operator SteamLeaderboardEntries_t(ulong value)
		{
			return new SteamLeaderboardEntries_t(value);
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x0001046C File Offset: 0x0000E66C
		public static explicit operator ulong(SteamLeaderboardEntries_t that)
		{
			return that.m_SteamLeaderboardEntries;
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x00010474 File Offset: 0x0000E674
		public bool Equals(SteamLeaderboardEntries_t other)
		{
			return this.m_SteamLeaderboardEntries == other.m_SteamLeaderboardEntries;
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x00010484 File Offset: 0x0000E684
		public int CompareTo(SteamLeaderboardEntries_t other)
		{
			return this.m_SteamLeaderboardEntries.CompareTo(other.m_SteamLeaderboardEntries);
		}

		// Token: 0x04000AB7 RID: 2743
		public ulong m_SteamLeaderboardEntries;
	}
}
