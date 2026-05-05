using System;

namespace Steamworks
{
	// Token: 0x020001BE RID: 446
	[Serializable]
	public struct SteamAPICall_t : IEquatable<SteamAPICall_t>, IComparable<SteamAPICall_t>
	{
		// Token: 0x06000B11 RID: 2833 RVA: 0x00010050 File Offset: 0x0000E250
		public SteamAPICall_t(ulong value)
		{
			this.m_SteamAPICall = value;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x00010059 File Offset: 0x0000E259
		public override string ToString()
		{
			return this.m_SteamAPICall.ToString();
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x00010066 File Offset: 0x0000E266
		public override bool Equals(object other)
		{
			return other is SteamAPICall_t && this == (SteamAPICall_t)other;
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x00010083 File Offset: 0x0000E283
		public override int GetHashCode()
		{
			return this.m_SteamAPICall.GetHashCode();
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x00010090 File Offset: 0x0000E290
		public static bool operator ==(SteamAPICall_t x, SteamAPICall_t y)
		{
			return x.m_SteamAPICall == y.m_SteamAPICall;
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x000100A0 File Offset: 0x0000E2A0
		public static bool operator !=(SteamAPICall_t x, SteamAPICall_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x000100AC File Offset: 0x0000E2AC
		public static explicit operator SteamAPICall_t(ulong value)
		{
			return new SteamAPICall_t(value);
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x000100B4 File Offset: 0x0000E2B4
		public static explicit operator ulong(SteamAPICall_t that)
		{
			return that.m_SteamAPICall;
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x000100BC File Offset: 0x0000E2BC
		public bool Equals(SteamAPICall_t other)
		{
			return this.m_SteamAPICall == other.m_SteamAPICall;
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x000100CC File Offset: 0x0000E2CC
		public int CompareTo(SteamAPICall_t other)
		{
			return this.m_SteamAPICall.CompareTo(other.m_SteamAPICall);
		}

		// Token: 0x04000AAE RID: 2734
		public static readonly SteamAPICall_t Invalid = new SteamAPICall_t(0UL);

		// Token: 0x04000AAF RID: 2735
		public ulong m_SteamAPICall;
	}
}
