using System;

namespace Steamworks
{
	// Token: 0x02000194 RID: 404
	[Serializable]
	public struct FriendsGroupID_t : IEquatable<FriendsGroupID_t>, IComparable<FriendsGroupID_t>
	{
		// Token: 0x0600098D RID: 2445 RVA: 0x0000EAEF File Offset: 0x0000CCEF
		public FriendsGroupID_t(short value)
		{
			this.m_FriendsGroupID = value;
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x0000EAF8 File Offset: 0x0000CCF8
		public override string ToString()
		{
			return this.m_FriendsGroupID.ToString();
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0000EB05 File Offset: 0x0000CD05
		public override bool Equals(object other)
		{
			return other is FriendsGroupID_t && this == (FriendsGroupID_t)other;
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x0000EB22 File Offset: 0x0000CD22
		public override int GetHashCode()
		{
			return this.m_FriendsGroupID.GetHashCode();
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x0000EB2F File Offset: 0x0000CD2F
		public static bool operator ==(FriendsGroupID_t x, FriendsGroupID_t y)
		{
			return x.m_FriendsGroupID == y.m_FriendsGroupID;
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x0000EB3F File Offset: 0x0000CD3F
		public static bool operator !=(FriendsGroupID_t x, FriendsGroupID_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x0000EB4B File Offset: 0x0000CD4B
		public static explicit operator FriendsGroupID_t(short value)
		{
			return new FriendsGroupID_t(value);
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x0000EB53 File Offset: 0x0000CD53
		public static explicit operator short(FriendsGroupID_t that)
		{
			return that.m_FriendsGroupID;
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0000EB5B File Offset: 0x0000CD5B
		public bool Equals(FriendsGroupID_t other)
		{
			return this.m_FriendsGroupID == other.m_FriendsGroupID;
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0000EB6B File Offset: 0x0000CD6B
		public int CompareTo(FriendsGroupID_t other)
		{
			return this.m_FriendsGroupID.CompareTo(other.m_FriendsGroupID);
		}

		// Token: 0x04000A5C RID: 2652
		public static readonly FriendsGroupID_t Invalid = new FriendsGroupID_t(-1);

		// Token: 0x04000A5D RID: 2653
		public short m_FriendsGroupID;
	}
}
