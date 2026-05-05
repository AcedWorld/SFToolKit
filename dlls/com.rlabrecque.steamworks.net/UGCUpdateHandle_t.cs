using System;

namespace Steamworks
{
	// Token: 0x020001C1 RID: 449
	[Serializable]
	public struct UGCUpdateHandle_t : IEquatable<UGCUpdateHandle_t>, IComparable<UGCUpdateHandle_t>
	{
		// Token: 0x06000B2C RID: 2860 RVA: 0x0001036B File Offset: 0x0000E56B
		public UGCUpdateHandle_t(ulong value)
		{
			this.m_UGCUpdateHandle = value;
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x00010374 File Offset: 0x0000E574
		public override string ToString()
		{
			return this.m_UGCUpdateHandle.ToString();
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x00010381 File Offset: 0x0000E581
		public override bool Equals(object other)
		{
			return other is UGCUpdateHandle_t && this == (UGCUpdateHandle_t)other;
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0001039E File Offset: 0x0000E59E
		public override int GetHashCode()
		{
			return this.m_UGCUpdateHandle.GetHashCode();
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x000103AB File Offset: 0x0000E5AB
		public static bool operator ==(UGCUpdateHandle_t x, UGCUpdateHandle_t y)
		{
			return x.m_UGCUpdateHandle == y.m_UGCUpdateHandle;
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x000103BB File Offset: 0x0000E5BB
		public static bool operator !=(UGCUpdateHandle_t x, UGCUpdateHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x000103C7 File Offset: 0x0000E5C7
		public static explicit operator UGCUpdateHandle_t(ulong value)
		{
			return new UGCUpdateHandle_t(value);
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x000103CF File Offset: 0x0000E5CF
		public static explicit operator ulong(UGCUpdateHandle_t that)
		{
			return that.m_UGCUpdateHandle;
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x000103D7 File Offset: 0x0000E5D7
		public bool Equals(UGCUpdateHandle_t other)
		{
			return this.m_UGCUpdateHandle == other.m_UGCUpdateHandle;
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x000103E7 File Offset: 0x0000E5E7
		public int CompareTo(UGCUpdateHandle_t other)
		{
			return this.m_UGCUpdateHandle.CompareTo(other.m_UGCUpdateHandle);
		}

		// Token: 0x04000AB5 RID: 2741
		public static readonly UGCUpdateHandle_t Invalid = new UGCUpdateHandle_t(ulong.MaxValue);

		// Token: 0x04000AB6 RID: 2742
		public ulong m_UGCUpdateHandle;
	}
}
