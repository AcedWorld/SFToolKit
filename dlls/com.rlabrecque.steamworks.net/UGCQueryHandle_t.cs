using System;

namespace Steamworks
{
	// Token: 0x020001C0 RID: 448
	[Serializable]
	public struct UGCQueryHandle_t : IEquatable<UGCQueryHandle_t>, IComparable<UGCQueryHandle_t>
	{
		// Token: 0x06000B21 RID: 2849 RVA: 0x000102CE File Offset: 0x0000E4CE
		public UGCQueryHandle_t(ulong value)
		{
			this.m_UGCQueryHandle = value;
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x000102D7 File Offset: 0x0000E4D7
		public override string ToString()
		{
			return this.m_UGCQueryHandle.ToString();
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x000102E4 File Offset: 0x0000E4E4
		public override bool Equals(object other)
		{
			return other is UGCQueryHandle_t && this == (UGCQueryHandle_t)other;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x00010301 File Offset: 0x0000E501
		public override int GetHashCode()
		{
			return this.m_UGCQueryHandle.GetHashCode();
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0001030E File Offset: 0x0000E50E
		public static bool operator ==(UGCQueryHandle_t x, UGCQueryHandle_t y)
		{
			return x.m_UGCQueryHandle == y.m_UGCQueryHandle;
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0001031E File Offset: 0x0000E51E
		public static bool operator !=(UGCQueryHandle_t x, UGCQueryHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x0001032A File Offset: 0x0000E52A
		public static explicit operator UGCQueryHandle_t(ulong value)
		{
			return new UGCQueryHandle_t(value);
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x00010332 File Offset: 0x0000E532
		public static explicit operator ulong(UGCQueryHandle_t that)
		{
			return that.m_UGCQueryHandle;
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0001033A File Offset: 0x0000E53A
		public bool Equals(UGCQueryHandle_t other)
		{
			return this.m_UGCQueryHandle == other.m_UGCQueryHandle;
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x0001034A File Offset: 0x0000E54A
		public int CompareTo(UGCQueryHandle_t other)
		{
			return this.m_UGCQueryHandle.CompareTo(other.m_UGCQueryHandle);
		}

		// Token: 0x04000AB3 RID: 2739
		public static readonly UGCQueryHandle_t Invalid = new UGCQueryHandle_t(ulong.MaxValue);

		// Token: 0x04000AB4 RID: 2740
		public ulong m_UGCQueryHandle;
	}
}
