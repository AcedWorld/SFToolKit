using System;

namespace Steamworks
{
	// Token: 0x020001A5 RID: 421
	[Serializable]
	public struct SNetSocket_t : IEquatable<SNetSocket_t>, IComparable<SNetSocket_t>
	{
		// Token: 0x06000A2F RID: 2607 RVA: 0x0000F3BE File Offset: 0x0000D5BE
		public SNetSocket_t(uint value)
		{
			this.m_SNetSocket = value;
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x0000F3C7 File Offset: 0x0000D5C7
		public override string ToString()
		{
			return this.m_SNetSocket.ToString();
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x0000F3D4 File Offset: 0x0000D5D4
		public override bool Equals(object other)
		{
			return other is SNetSocket_t && this == (SNetSocket_t)other;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x0000F3F1 File Offset: 0x0000D5F1
		public override int GetHashCode()
		{
			return this.m_SNetSocket.GetHashCode();
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x0000F3FE File Offset: 0x0000D5FE
		public static bool operator ==(SNetSocket_t x, SNetSocket_t y)
		{
			return x.m_SNetSocket == y.m_SNetSocket;
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x0000F40E File Offset: 0x0000D60E
		public static bool operator !=(SNetSocket_t x, SNetSocket_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x0000F41A File Offset: 0x0000D61A
		public static explicit operator SNetSocket_t(uint value)
		{
			return new SNetSocket_t(value);
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x0000F422 File Offset: 0x0000D622
		public static explicit operator uint(SNetSocket_t that)
		{
			return that.m_SNetSocket;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x0000F42A File Offset: 0x0000D62A
		public bool Equals(SNetSocket_t other)
		{
			return this.m_SNetSocket == other.m_SNetSocket;
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x0000F43A File Offset: 0x0000D63A
		public int CompareTo(SNetSocket_t other)
		{
			return this.m_SNetSocket.CompareTo(other.m_SNetSocket);
		}

		// Token: 0x04000A77 RID: 2679
		public uint m_SNetSocket;
	}
}
