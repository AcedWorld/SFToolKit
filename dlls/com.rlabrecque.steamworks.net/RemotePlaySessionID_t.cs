using System;

namespace Steamworks
{
	// Token: 0x020001B3 RID: 435
	[Serializable]
	public struct RemotePlaySessionID_t : IEquatable<RemotePlaySessionID_t>, IComparable<RemotePlaySessionID_t>
	{
		// Token: 0x06000A9B RID: 2715 RVA: 0x0000F9BE File Offset: 0x0000DBBE
		public RemotePlaySessionID_t(uint value)
		{
			this.m_RemotePlaySessionID = value;
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x0000F9C7 File Offset: 0x0000DBC7
		public override string ToString()
		{
			return this.m_RemotePlaySessionID.ToString();
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x0000F9D4 File Offset: 0x0000DBD4
		public override bool Equals(object other)
		{
			return other is RemotePlaySessionID_t && this == (RemotePlaySessionID_t)other;
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x0000F9F1 File Offset: 0x0000DBF1
		public override int GetHashCode()
		{
			return this.m_RemotePlaySessionID.GetHashCode();
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x0000F9FE File Offset: 0x0000DBFE
		public static bool operator ==(RemotePlaySessionID_t x, RemotePlaySessionID_t y)
		{
			return x.m_RemotePlaySessionID == y.m_RemotePlaySessionID;
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x0000FA0E File Offset: 0x0000DC0E
		public static bool operator !=(RemotePlaySessionID_t x, RemotePlaySessionID_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x0000FA1A File Offset: 0x0000DC1A
		public static explicit operator RemotePlaySessionID_t(uint value)
		{
			return new RemotePlaySessionID_t(value);
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x0000FA22 File Offset: 0x0000DC22
		public static explicit operator uint(RemotePlaySessionID_t that)
		{
			return that.m_RemotePlaySessionID;
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x0000FA2A File Offset: 0x0000DC2A
		public bool Equals(RemotePlaySessionID_t other)
		{
			return this.m_RemotePlaySessionID == other.m_RemotePlaySessionID;
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x0000FA3A File Offset: 0x0000DC3A
		public int CompareTo(RemotePlaySessionID_t other)
		{
			return this.m_RemotePlaySessionID.CompareTo(other.m_RemotePlaySessionID);
		}

		// Token: 0x04000A9B RID: 2715
		public uint m_RemotePlaySessionID;
	}
}
