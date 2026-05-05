using System;

namespace Steamworks
{
	// Token: 0x020001B5 RID: 437
	[Serializable]
	public struct PublishedFileUpdateHandle_t : IEquatable<PublishedFileUpdateHandle_t>, IComparable<PublishedFileUpdateHandle_t>
	{
		// Token: 0x06000AB0 RID: 2736 RVA: 0x0000FAEA File Offset: 0x0000DCEA
		public PublishedFileUpdateHandle_t(ulong value)
		{
			this.m_PublishedFileUpdateHandle = value;
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x0000FAF3 File Offset: 0x0000DCF3
		public override string ToString()
		{
			return this.m_PublishedFileUpdateHandle.ToString();
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x0000FB00 File Offset: 0x0000DD00
		public override bool Equals(object other)
		{
			return other is PublishedFileUpdateHandle_t && this == (PublishedFileUpdateHandle_t)other;
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x0000FB1D File Offset: 0x0000DD1D
		public override int GetHashCode()
		{
			return this.m_PublishedFileUpdateHandle.GetHashCode();
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x0000FB2A File Offset: 0x0000DD2A
		public static bool operator ==(PublishedFileUpdateHandle_t x, PublishedFileUpdateHandle_t y)
		{
			return x.m_PublishedFileUpdateHandle == y.m_PublishedFileUpdateHandle;
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x0000FB3A File Offset: 0x0000DD3A
		public static bool operator !=(PublishedFileUpdateHandle_t x, PublishedFileUpdateHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x0000FB46 File Offset: 0x0000DD46
		public static explicit operator PublishedFileUpdateHandle_t(ulong value)
		{
			return new PublishedFileUpdateHandle_t(value);
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x0000FB4E File Offset: 0x0000DD4E
		public static explicit operator ulong(PublishedFileUpdateHandle_t that)
		{
			return that.m_PublishedFileUpdateHandle;
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x0000FB56 File Offset: 0x0000DD56
		public bool Equals(PublishedFileUpdateHandle_t other)
		{
			return this.m_PublishedFileUpdateHandle == other.m_PublishedFileUpdateHandle;
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x0000FB66 File Offset: 0x0000DD66
		public int CompareTo(PublishedFileUpdateHandle_t other)
		{
			return this.m_PublishedFileUpdateHandle.CompareTo(other.m_PublishedFileUpdateHandle);
		}

		// Token: 0x04000A9E RID: 2718
		public static readonly PublishedFileUpdateHandle_t Invalid = new PublishedFileUpdateHandle_t(ulong.MaxValue);

		// Token: 0x04000A9F RID: 2719
		public ulong m_PublishedFileUpdateHandle;
	}
}
