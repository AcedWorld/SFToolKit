using System;

namespace Steamworks
{
	// Token: 0x020001A2 RID: 418
	[Serializable]
	public struct HServerListRequest : IEquatable<HServerListRequest>
	{
		// Token: 0x06000A10 RID: 2576 RVA: 0x0000F200 File Offset: 0x0000D400
		public HServerListRequest(IntPtr value)
		{
			this.m_HServerListRequest = value;
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x0000F209 File Offset: 0x0000D409
		public override string ToString()
		{
			return this.m_HServerListRequest.ToString();
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x0000F216 File Offset: 0x0000D416
		public override bool Equals(object other)
		{
			return other is HServerListRequest && this == (HServerListRequest)other;
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x0000F233 File Offset: 0x0000D433
		public override int GetHashCode()
		{
			return this.m_HServerListRequest.GetHashCode();
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x0000F240 File Offset: 0x0000D440
		public static bool operator ==(HServerListRequest x, HServerListRequest y)
		{
			return x.m_HServerListRequest == y.m_HServerListRequest;
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x0000F253 File Offset: 0x0000D453
		public static bool operator !=(HServerListRequest x, HServerListRequest y)
		{
			return !(x == y);
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x0000F25F File Offset: 0x0000D45F
		public static explicit operator HServerListRequest(IntPtr value)
		{
			return new HServerListRequest(value);
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x0000F267 File Offset: 0x0000D467
		public static explicit operator IntPtr(HServerListRequest that)
		{
			return that.m_HServerListRequest;
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x0000F26F File Offset: 0x0000D46F
		public bool Equals(HServerListRequest other)
		{
			return this.m_HServerListRequest == other.m_HServerListRequest;
		}

		// Token: 0x04000A72 RID: 2674
		public static readonly HServerListRequest Invalid = new HServerListRequest(IntPtr.Zero);

		// Token: 0x04000A73 RID: 2675
		public IntPtr m_HServerListRequest;
	}
}
