using System;

namespace Steamworks
{
	// Token: 0x020001C5 RID: 453
	[Serializable]
	public struct HSteamUser : IEquatable<HSteamUser>, IComparable<HSteamUser>
	{
		// Token: 0x06000B55 RID: 2901 RVA: 0x000105B5 File Offset: 0x0000E7B5
		public HSteamUser(int value)
		{
			this.m_HSteamUser = value;
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x000105BE File Offset: 0x0000E7BE
		public override string ToString()
		{
			return this.m_HSteamUser.ToString();
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x000105CB File Offset: 0x0000E7CB
		public override bool Equals(object other)
		{
			return other is HSteamUser && this == (HSteamUser)other;
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x000105E8 File Offset: 0x0000E7E8
		public override int GetHashCode()
		{
			return this.m_HSteamUser.GetHashCode();
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x000105F5 File Offset: 0x0000E7F5
		public static bool operator ==(HSteamUser x, HSteamUser y)
		{
			return x.m_HSteamUser == y.m_HSteamUser;
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x00010605 File Offset: 0x0000E805
		public static bool operator !=(HSteamUser x, HSteamUser y)
		{
			return !(x == y);
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x00010611 File Offset: 0x0000E811
		public static explicit operator HSteamUser(int value)
		{
			return new HSteamUser(value);
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x00010619 File Offset: 0x0000E819
		public static explicit operator int(HSteamUser that)
		{
			return that.m_HSteamUser;
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x00010621 File Offset: 0x0000E821
		public bool Equals(HSteamUser other)
		{
			return this.m_HSteamUser == other.m_HSteamUser;
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x00010631 File Offset: 0x0000E831
		public int CompareTo(HSteamUser other)
		{
			return this.m_HSteamUser.CompareTo(other.m_HSteamUser);
		}

		// Token: 0x04000ABA RID: 2746
		public int m_HSteamUser;
	}
}
