using System;

namespace Steamworks
{
	// Token: 0x020001B9 RID: 441
	[Serializable]
	public struct AccountID_t : IEquatable<AccountID_t>, IComparable<AccountID_t>
	{
		// Token: 0x06000ADC RID: 2780 RVA: 0x0000FD5D File Offset: 0x0000DF5D
		public AccountID_t(uint value)
		{
			this.m_AccountID = value;
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x0000FD66 File Offset: 0x0000DF66
		public override string ToString()
		{
			return this.m_AccountID.ToString();
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x0000FD73 File Offset: 0x0000DF73
		public override bool Equals(object other)
		{
			return other is AccountID_t && this == (AccountID_t)other;
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x0000FD90 File Offset: 0x0000DF90
		public override int GetHashCode()
		{
			return this.m_AccountID.GetHashCode();
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x0000FD9D File Offset: 0x0000DF9D
		public static bool operator ==(AccountID_t x, AccountID_t y)
		{
			return x.m_AccountID == y.m_AccountID;
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x0000FDAD File Offset: 0x0000DFAD
		public static bool operator !=(AccountID_t x, AccountID_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x0000FDB9 File Offset: 0x0000DFB9
		public static explicit operator AccountID_t(uint value)
		{
			return new AccountID_t(value);
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x0000FDC1 File Offset: 0x0000DFC1
		public static explicit operator uint(AccountID_t that)
		{
			return that.m_AccountID;
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x0000FDC9 File Offset: 0x0000DFC9
		public bool Equals(AccountID_t other)
		{
			return this.m_AccountID == other.m_AccountID;
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x0000FDD9 File Offset: 0x0000DFD9
		public int CompareTo(AccountID_t other)
		{
			return this.m_AccountID.CompareTo(other.m_AccountID);
		}

		// Token: 0x04000AA6 RID: 2726
		public uint m_AccountID;
	}
}
