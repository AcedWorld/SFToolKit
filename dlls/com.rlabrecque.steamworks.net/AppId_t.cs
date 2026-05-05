using System;

namespace Steamworks
{
	// Token: 0x020001BA RID: 442
	[Serializable]
	public struct AppId_t : IEquatable<AppId_t>, IComparable<AppId_t>
	{
		// Token: 0x06000AE6 RID: 2790 RVA: 0x0000FDEC File Offset: 0x0000DFEC
		public AppId_t(uint value)
		{
			this.m_AppId = value;
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x0000FDF5 File Offset: 0x0000DFF5
		public override string ToString()
		{
			return this.m_AppId.ToString();
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x0000FE02 File Offset: 0x0000E002
		public override bool Equals(object other)
		{
			return other is AppId_t && this == (AppId_t)other;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x0000FE1F File Offset: 0x0000E01F
		public override int GetHashCode()
		{
			return this.m_AppId.GetHashCode();
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x0000FE2C File Offset: 0x0000E02C
		public static bool operator ==(AppId_t x, AppId_t y)
		{
			return x.m_AppId == y.m_AppId;
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x0000FE3C File Offset: 0x0000E03C
		public static bool operator !=(AppId_t x, AppId_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0000FE48 File Offset: 0x0000E048
		public static explicit operator AppId_t(uint value)
		{
			return new AppId_t(value);
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x0000FE50 File Offset: 0x0000E050
		public static explicit operator uint(AppId_t that)
		{
			return that.m_AppId;
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x0000FE58 File Offset: 0x0000E058
		public bool Equals(AppId_t other)
		{
			return this.m_AppId == other.m_AppId;
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x0000FE68 File Offset: 0x0000E068
		public int CompareTo(AppId_t other)
		{
			return this.m_AppId.CompareTo(other.m_AppId);
		}

		// Token: 0x04000AA7 RID: 2727
		public static readonly AppId_t Invalid = new AppId_t(0U);

		// Token: 0x04000AA8 RID: 2728
		public uint m_AppId;
	}
}
