using System;

namespace Steamworks
{
	// Token: 0x020001B4 RID: 436
	[Serializable]
	public struct PublishedFileId_t : IEquatable<PublishedFileId_t>, IComparable<PublishedFileId_t>
	{
		// Token: 0x06000AA5 RID: 2725 RVA: 0x0000FA4D File Offset: 0x0000DC4D
		public PublishedFileId_t(ulong value)
		{
			this.m_PublishedFileId = value;
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x0000FA56 File Offset: 0x0000DC56
		public override string ToString()
		{
			return this.m_PublishedFileId.ToString();
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x0000FA63 File Offset: 0x0000DC63
		public override bool Equals(object other)
		{
			return other is PublishedFileId_t && this == (PublishedFileId_t)other;
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x0000FA80 File Offset: 0x0000DC80
		public override int GetHashCode()
		{
			return this.m_PublishedFileId.GetHashCode();
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x0000FA8D File Offset: 0x0000DC8D
		public static bool operator ==(PublishedFileId_t x, PublishedFileId_t y)
		{
			return x.m_PublishedFileId == y.m_PublishedFileId;
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x0000FA9D File Offset: 0x0000DC9D
		public static bool operator !=(PublishedFileId_t x, PublishedFileId_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x0000FAA9 File Offset: 0x0000DCA9
		public static explicit operator PublishedFileId_t(ulong value)
		{
			return new PublishedFileId_t(value);
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x0000FAB1 File Offset: 0x0000DCB1
		public static explicit operator ulong(PublishedFileId_t that)
		{
			return that.m_PublishedFileId;
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x0000FAB9 File Offset: 0x0000DCB9
		public bool Equals(PublishedFileId_t other)
		{
			return this.m_PublishedFileId == other.m_PublishedFileId;
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x0000FAC9 File Offset: 0x0000DCC9
		public int CompareTo(PublishedFileId_t other)
		{
			return this.m_PublishedFileId.CompareTo(other.m_PublishedFileId);
		}

		// Token: 0x04000A9C RID: 2716
		public static readonly PublishedFileId_t Invalid = new PublishedFileId_t(0UL);

		// Token: 0x04000A9D RID: 2717
		public ulong m_PublishedFileId;
	}
}
