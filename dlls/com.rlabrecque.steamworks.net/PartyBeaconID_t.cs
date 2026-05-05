using System;

namespace Steamworks
{
	// Token: 0x020001BC RID: 444
	[Serializable]
	public struct PartyBeaconID_t : IEquatable<PartyBeaconID_t>, IComparable<PartyBeaconID_t>
	{
		// Token: 0x06000AFC RID: 2812 RVA: 0x0000FF24 File Offset: 0x0000E124
		public PartyBeaconID_t(ulong value)
		{
			this.m_PartyBeaconID = value;
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x0000FF2D File Offset: 0x0000E12D
		public override string ToString()
		{
			return this.m_PartyBeaconID.ToString();
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x0000FF3A File Offset: 0x0000E13A
		public override bool Equals(object other)
		{
			return other is PartyBeaconID_t && this == (PartyBeaconID_t)other;
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x0000FF57 File Offset: 0x0000E157
		public override int GetHashCode()
		{
			return this.m_PartyBeaconID.GetHashCode();
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x0000FF64 File Offset: 0x0000E164
		public static bool operator ==(PartyBeaconID_t x, PartyBeaconID_t y)
		{
			return x.m_PartyBeaconID == y.m_PartyBeaconID;
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x0000FF74 File Offset: 0x0000E174
		public static bool operator !=(PartyBeaconID_t x, PartyBeaconID_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x0000FF80 File Offset: 0x0000E180
		public static explicit operator PartyBeaconID_t(ulong value)
		{
			return new PartyBeaconID_t(value);
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x0000FF88 File Offset: 0x0000E188
		public static explicit operator ulong(PartyBeaconID_t that)
		{
			return that.m_PartyBeaconID;
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x0000FF90 File Offset: 0x0000E190
		public bool Equals(PartyBeaconID_t other)
		{
			return this.m_PartyBeaconID == other.m_PartyBeaconID;
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x0000FFA0 File Offset: 0x0000E1A0
		public int CompareTo(PartyBeaconID_t other)
		{
			return this.m_PartyBeaconID.CompareTo(other.m_PartyBeaconID);
		}

		// Token: 0x04000AAB RID: 2731
		public static readonly PartyBeaconID_t Invalid = new PartyBeaconID_t(0UL);

		// Token: 0x04000AAC RID: 2732
		public ulong m_PartyBeaconID;
	}
}
