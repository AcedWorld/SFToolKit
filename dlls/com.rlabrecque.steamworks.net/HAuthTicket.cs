using System;

namespace Steamworks
{
	// Token: 0x02000191 RID: 401
	[Serializable]
	public struct HAuthTicket : IEquatable<HAuthTicket>, IComparable<HAuthTicket>
	{
		// Token: 0x06000980 RID: 2432 RVA: 0x0000EA38 File Offset: 0x0000CC38
		public HAuthTicket(uint value)
		{
			this.m_HAuthTicket = value;
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x0000EA41 File Offset: 0x0000CC41
		public override string ToString()
		{
			return this.m_HAuthTicket.ToString();
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x0000EA4E File Offset: 0x0000CC4E
		public override bool Equals(object other)
		{
			return other is HAuthTicket && this == (HAuthTicket)other;
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x0000EA6B File Offset: 0x0000CC6B
		public override int GetHashCode()
		{
			return this.m_HAuthTicket.GetHashCode();
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x0000EA78 File Offset: 0x0000CC78
		public static bool operator ==(HAuthTicket x, HAuthTicket y)
		{
			return x.m_HAuthTicket == y.m_HAuthTicket;
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x0000EA88 File Offset: 0x0000CC88
		public static bool operator !=(HAuthTicket x, HAuthTicket y)
		{
			return !(x == y);
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x0000EA94 File Offset: 0x0000CC94
		public static explicit operator HAuthTicket(uint value)
		{
			return new HAuthTicket(value);
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x0000EA9C File Offset: 0x0000CC9C
		public static explicit operator uint(HAuthTicket that)
		{
			return that.m_HAuthTicket;
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x0000EAA4 File Offset: 0x0000CCA4
		public bool Equals(HAuthTicket other)
		{
			return this.m_HAuthTicket == other.m_HAuthTicket;
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0000EAB4 File Offset: 0x0000CCB4
		public int CompareTo(HAuthTicket other)
		{
			return this.m_HAuthTicket.CompareTo(other.m_HAuthTicket);
		}

		// Token: 0x04000A4E RID: 2638
		public static readonly HAuthTicket Invalid = new HAuthTicket(0U);

		// Token: 0x04000A4F RID: 2639
		public uint m_HAuthTicket;
	}
}
