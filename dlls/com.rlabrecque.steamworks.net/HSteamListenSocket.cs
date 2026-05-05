using System;

namespace Steamworks
{
	// Token: 0x020001A9 RID: 425
	[Serializable]
	public struct HSteamListenSocket : IEquatable<HSteamListenSocket>, IComparable<HSteamListenSocket>
	{
		// Token: 0x06000A41 RID: 2625 RVA: 0x0000F478 File Offset: 0x0000D678
		public HSteamListenSocket(uint value)
		{
			this.m_HSteamListenSocket = value;
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x0000F481 File Offset: 0x0000D681
		public override string ToString()
		{
			return this.m_HSteamListenSocket.ToString();
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x0000F48E File Offset: 0x0000D68E
		public override bool Equals(object other)
		{
			return other is HSteamListenSocket && this == (HSteamListenSocket)other;
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x0000F4AB File Offset: 0x0000D6AB
		public override int GetHashCode()
		{
			return this.m_HSteamListenSocket.GetHashCode();
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x0000F4B8 File Offset: 0x0000D6B8
		public static bool operator ==(HSteamListenSocket x, HSteamListenSocket y)
		{
			return x.m_HSteamListenSocket == y.m_HSteamListenSocket;
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x0000F4C8 File Offset: 0x0000D6C8
		public static bool operator !=(HSteamListenSocket x, HSteamListenSocket y)
		{
			return !(x == y);
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x0000F4D4 File Offset: 0x0000D6D4
		public static explicit operator HSteamListenSocket(uint value)
		{
			return new HSteamListenSocket(value);
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x0000F4DC File Offset: 0x0000D6DC
		public static explicit operator uint(HSteamListenSocket that)
		{
			return that.m_HSteamListenSocket;
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x0000F4E4 File Offset: 0x0000D6E4
		public bool Equals(HSteamListenSocket other)
		{
			return this.m_HSteamListenSocket == other.m_HSteamListenSocket;
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x0000F4F4 File Offset: 0x0000D6F4
		public int CompareTo(HSteamListenSocket other)
		{
			return this.m_HSteamListenSocket.CompareTo(other.m_HSteamListenSocket);
		}

		// Token: 0x04000A78 RID: 2680
		public static readonly HSteamListenSocket Invalid = new HSteamListenSocket(0U);

		// Token: 0x04000A79 RID: 2681
		public uint m_HSteamListenSocket;
	}
}
