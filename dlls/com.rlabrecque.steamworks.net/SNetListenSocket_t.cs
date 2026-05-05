using System;

namespace Steamworks
{
	// Token: 0x020001A4 RID: 420
	[Serializable]
	public struct SNetListenSocket_t : IEquatable<SNetListenSocket_t>, IComparable<SNetListenSocket_t>
	{
		// Token: 0x06000A25 RID: 2597 RVA: 0x0000F32F File Offset: 0x0000D52F
		public SNetListenSocket_t(uint value)
		{
			this.m_SNetListenSocket = value;
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x0000F338 File Offset: 0x0000D538
		public override string ToString()
		{
			return this.m_SNetListenSocket.ToString();
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x0000F345 File Offset: 0x0000D545
		public override bool Equals(object other)
		{
			return other is SNetListenSocket_t && this == (SNetListenSocket_t)other;
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x0000F362 File Offset: 0x0000D562
		public override int GetHashCode()
		{
			return this.m_SNetListenSocket.GetHashCode();
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x0000F36F File Offset: 0x0000D56F
		public static bool operator ==(SNetListenSocket_t x, SNetListenSocket_t y)
		{
			return x.m_SNetListenSocket == y.m_SNetListenSocket;
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x0000F37F File Offset: 0x0000D57F
		public static bool operator !=(SNetListenSocket_t x, SNetListenSocket_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x0000F38B File Offset: 0x0000D58B
		public static explicit operator SNetListenSocket_t(uint value)
		{
			return new SNetListenSocket_t(value);
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x0000F393 File Offset: 0x0000D593
		public static explicit operator uint(SNetListenSocket_t that)
		{
			return that.m_SNetListenSocket;
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x0000F39B File Offset: 0x0000D59B
		public bool Equals(SNetListenSocket_t other)
		{
			return this.m_SNetListenSocket == other.m_SNetListenSocket;
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x0000F3AB File Offset: 0x0000D5AB
		public int CompareTo(SNetListenSocket_t other)
		{
			return this.m_SNetListenSocket.CompareTo(other.m_SNetListenSocket);
		}

		// Token: 0x04000A76 RID: 2678
		public uint m_SNetListenSocket;
	}
}
