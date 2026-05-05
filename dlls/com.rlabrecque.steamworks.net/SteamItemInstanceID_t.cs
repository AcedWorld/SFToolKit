using System;

namespace Steamworks
{
	// Token: 0x020001A1 RID: 417
	[Serializable]
	public struct SteamItemInstanceID_t : IEquatable<SteamItemInstanceID_t>, IComparable<SteamItemInstanceID_t>
	{
		// Token: 0x06000A05 RID: 2565 RVA: 0x0000F163 File Offset: 0x0000D363
		public SteamItemInstanceID_t(ulong value)
		{
			this.m_SteamItemInstanceID = value;
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x0000F16C File Offset: 0x0000D36C
		public override string ToString()
		{
			return this.m_SteamItemInstanceID.ToString();
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x0000F179 File Offset: 0x0000D379
		public override bool Equals(object other)
		{
			return other is SteamItemInstanceID_t && this == (SteamItemInstanceID_t)other;
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x0000F196 File Offset: 0x0000D396
		public override int GetHashCode()
		{
			return this.m_SteamItemInstanceID.GetHashCode();
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x0000F1A3 File Offset: 0x0000D3A3
		public static bool operator ==(SteamItemInstanceID_t x, SteamItemInstanceID_t y)
		{
			return x.m_SteamItemInstanceID == y.m_SteamItemInstanceID;
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x0000F1B3 File Offset: 0x0000D3B3
		public static bool operator !=(SteamItemInstanceID_t x, SteamItemInstanceID_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x0000F1BF File Offset: 0x0000D3BF
		public static explicit operator SteamItemInstanceID_t(ulong value)
		{
			return new SteamItemInstanceID_t(value);
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x0000F1C7 File Offset: 0x0000D3C7
		public static explicit operator ulong(SteamItemInstanceID_t that)
		{
			return that.m_SteamItemInstanceID;
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x0000F1CF File Offset: 0x0000D3CF
		public bool Equals(SteamItemInstanceID_t other)
		{
			return this.m_SteamItemInstanceID == other.m_SteamItemInstanceID;
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x0000F1DF File Offset: 0x0000D3DF
		public int CompareTo(SteamItemInstanceID_t other)
		{
			return this.m_SteamItemInstanceID.CompareTo(other.m_SteamItemInstanceID);
		}

		// Token: 0x04000A70 RID: 2672
		public static readonly SteamItemInstanceID_t Invalid = new SteamItemInstanceID_t(ulong.MaxValue);

		// Token: 0x04000A71 RID: 2673
		public ulong m_SteamItemInstanceID;
	}
}
