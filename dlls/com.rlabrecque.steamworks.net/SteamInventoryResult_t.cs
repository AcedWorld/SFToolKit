using System;

namespace Steamworks
{
	// Token: 0x0200019E RID: 414
	[Serializable]
	public struct SteamInventoryResult_t : IEquatable<SteamInventoryResult_t>, IComparable<SteamInventoryResult_t>
	{
		// Token: 0x060009E5 RID: 2533 RVA: 0x0000EF9B File Offset: 0x0000D19B
		public SteamInventoryResult_t(int value)
		{
			this.m_SteamInventoryResult = value;
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x0000EFA4 File Offset: 0x0000D1A4
		public override string ToString()
		{
			return this.m_SteamInventoryResult.ToString();
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x0000EFB1 File Offset: 0x0000D1B1
		public override bool Equals(object other)
		{
			return other is SteamInventoryResult_t && this == (SteamInventoryResult_t)other;
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x0000EFCE File Offset: 0x0000D1CE
		public override int GetHashCode()
		{
			return this.m_SteamInventoryResult.GetHashCode();
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x0000EFDB File Offset: 0x0000D1DB
		public static bool operator ==(SteamInventoryResult_t x, SteamInventoryResult_t y)
		{
			return x.m_SteamInventoryResult == y.m_SteamInventoryResult;
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x0000EFEB File Offset: 0x0000D1EB
		public static bool operator !=(SteamInventoryResult_t x, SteamInventoryResult_t y)
		{
			return !(x == y);
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x0000EFF7 File Offset: 0x0000D1F7
		public static explicit operator SteamInventoryResult_t(int value)
		{
			return new SteamInventoryResult_t(value);
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x0000EFFF File Offset: 0x0000D1FF
		public static explicit operator int(SteamInventoryResult_t that)
		{
			return that.m_SteamInventoryResult;
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x0000F007 File Offset: 0x0000D207
		public bool Equals(SteamInventoryResult_t other)
		{
			return this.m_SteamInventoryResult == other.m_SteamInventoryResult;
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x0000F017 File Offset: 0x0000D217
		public int CompareTo(SteamInventoryResult_t other)
		{
			return this.m_SteamInventoryResult.CompareTo(other.m_SteamInventoryResult);
		}

		// Token: 0x04000A6B RID: 2667
		public static readonly SteamInventoryResult_t Invalid = new SteamInventoryResult_t(-1);

		// Token: 0x04000A6C RID: 2668
		public int m_SteamInventoryResult;
	}
}
