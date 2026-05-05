using System;

namespace Steamworks
{
	// Token: 0x020001B6 RID: 438
	[Serializable]
	public struct UGCFileWriteStreamHandle_t : IEquatable<UGCFileWriteStreamHandle_t>, IComparable<UGCFileWriteStreamHandle_t>
	{
		// Token: 0x06000ABB RID: 2747 RVA: 0x0000FB87 File Offset: 0x0000DD87
		public UGCFileWriteStreamHandle_t(ulong value)
		{
			this.m_UGCFileWriteStreamHandle = value;
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x0000FB90 File Offset: 0x0000DD90
		public override string ToString()
		{
			return this.m_UGCFileWriteStreamHandle.ToString();
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x0000FB9D File Offset: 0x0000DD9D
		public override bool Equals(object other)
		{
			return other is UGCFileWriteStreamHandle_t && this == (UGCFileWriteStreamHandle_t)other;
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x0000FBBA File Offset: 0x0000DDBA
		public override int GetHashCode()
		{
			return this.m_UGCFileWriteStreamHandle.GetHashCode();
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x0000FBC7 File Offset: 0x0000DDC7
		public static bool operator ==(UGCFileWriteStreamHandle_t x, UGCFileWriteStreamHandle_t y)
		{
			return x.m_UGCFileWriteStreamHandle == y.m_UGCFileWriteStreamHandle;
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x0000FBD7 File Offset: 0x0000DDD7
		public static bool operator !=(UGCFileWriteStreamHandle_t x, UGCFileWriteStreamHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x0000FBE3 File Offset: 0x0000DDE3
		public static explicit operator UGCFileWriteStreamHandle_t(ulong value)
		{
			return new UGCFileWriteStreamHandle_t(value);
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x0000FBEB File Offset: 0x0000DDEB
		public static explicit operator ulong(UGCFileWriteStreamHandle_t that)
		{
			return that.m_UGCFileWriteStreamHandle;
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x0000FBF3 File Offset: 0x0000DDF3
		public bool Equals(UGCFileWriteStreamHandle_t other)
		{
			return this.m_UGCFileWriteStreamHandle == other.m_UGCFileWriteStreamHandle;
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x0000FC03 File Offset: 0x0000DE03
		public int CompareTo(UGCFileWriteStreamHandle_t other)
		{
			return this.m_UGCFileWriteStreamHandle.CompareTo(other.m_UGCFileWriteStreamHandle);
		}

		// Token: 0x04000AA0 RID: 2720
		public static readonly UGCFileWriteStreamHandle_t Invalid = new UGCFileWriteStreamHandle_t(ulong.MaxValue);

		// Token: 0x04000AA1 RID: 2721
		public ulong m_UGCFileWriteStreamHandle;
	}
}
