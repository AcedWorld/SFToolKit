using System;

namespace Steamworks
{
	// Token: 0x020001AB RID: 427
	[Serializable]
	public struct HSteamNetPollGroup : IEquatable<HSteamNetPollGroup>, IComparable<HSteamNetPollGroup>
	{
		// Token: 0x06000A57 RID: 2647 RVA: 0x0000F5B0 File Offset: 0x0000D7B0
		public HSteamNetPollGroup(uint value)
		{
			this.m_HSteamNetPollGroup = value;
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x0000F5B9 File Offset: 0x0000D7B9
		public override string ToString()
		{
			return this.m_HSteamNetPollGroup.ToString();
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x0000F5C6 File Offset: 0x0000D7C6
		public override bool Equals(object other)
		{
			return other is HSteamNetPollGroup && this == (HSteamNetPollGroup)other;
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x0000F5E3 File Offset: 0x0000D7E3
		public override int GetHashCode()
		{
			return this.m_HSteamNetPollGroup.GetHashCode();
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x0000F5F0 File Offset: 0x0000D7F0
		public static bool operator ==(HSteamNetPollGroup x, HSteamNetPollGroup y)
		{
			return x.m_HSteamNetPollGroup == y.m_HSteamNetPollGroup;
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x0000F600 File Offset: 0x0000D800
		public static bool operator !=(HSteamNetPollGroup x, HSteamNetPollGroup y)
		{
			return !(x == y);
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x0000F60C File Offset: 0x0000D80C
		public static explicit operator HSteamNetPollGroup(uint value)
		{
			return new HSteamNetPollGroup(value);
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x0000F614 File Offset: 0x0000D814
		public static explicit operator uint(HSteamNetPollGroup that)
		{
			return that.m_HSteamNetPollGroup;
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x0000F61C File Offset: 0x0000D81C
		public bool Equals(HSteamNetPollGroup other)
		{
			return this.m_HSteamNetPollGroup == other.m_HSteamNetPollGroup;
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x0000F62C File Offset: 0x0000D82C
		public int CompareTo(HSteamNetPollGroup other)
		{
			return this.m_HSteamNetPollGroup.CompareTo(other.m_HSteamNetPollGroup);
		}

		// Token: 0x04000A7C RID: 2684
		public static readonly HSteamNetPollGroup Invalid = new HSteamNetPollGroup(0U);

		// Token: 0x04000A7D RID: 2685
		public uint m_HSteamNetPollGroup;
	}
}
