using System;

namespace Steamworks
{
	// Token: 0x0200019F RID: 415
	[Serializable]
	public struct SteamInventoryUpdateHandle_t : IEquatable<SteamInventoryUpdateHandle_t>, IComparable<SteamInventoryUpdateHandle_t>
	{
		// Token: 0x060009F0 RID: 2544 RVA: 0x0000F037 File Offset: 0x0000D237
		public SteamInventoryUpdateHandle_t(ulong value)
		{
			this.m_SteamInventoryUpdateHandle = value;
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x0000F040 File Offset: 0x0000D240
		public override string ToString()
		{
			return this.m_SteamInventoryUpdateHandle.ToString();
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x0000F04D File Offset: 0x0000D24D
		public override bool Equals(object other)
		{
			return other is SteamInventoryUpdateHandle_t && this == (SteamInventoryUpdateHandle_t)other;
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x0000F06A File Offset: 0x0000D26A
		public override int GetHashCode()
		{
			return this.m_SteamInventoryUpdateHandle.GetHashCode();
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x0000F077 File Offset: 0x0000D277
		public static bool operator ==(SteamInventoryUpdateHandle_t x, SteamInventoryUpdateHandle_t y)
		{
			return x.m_SteamInventoryUpdateHandle == y.m_SteamInventoryUpdateHandle;
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x0000F087 File Offset: 0x0000D287
		public static bool operator !=(SteamInventoryUpdateHandle_t x, SteamInventoryUpdateHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x0000F093 File Offset: 0x0000D293
		public static explicit operator SteamInventoryUpdateHandle_t(ulong value)
		{
			return new SteamInventoryUpdateHandle_t(value);
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x0000F09B File Offset: 0x0000D29B
		public static explicit operator ulong(SteamInventoryUpdateHandle_t that)
		{
			return that.m_SteamInventoryUpdateHandle;
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x0000F0A3 File Offset: 0x0000D2A3
		public bool Equals(SteamInventoryUpdateHandle_t other)
		{
			return this.m_SteamInventoryUpdateHandle == other.m_SteamInventoryUpdateHandle;
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x0000F0B3 File Offset: 0x0000D2B3
		public int CompareTo(SteamInventoryUpdateHandle_t other)
		{
			return this.m_SteamInventoryUpdateHandle.CompareTo(other.m_SteamInventoryUpdateHandle);
		}

		// Token: 0x04000A6D RID: 2669
		public static readonly SteamInventoryUpdateHandle_t Invalid = new SteamInventoryUpdateHandle_t(ulong.MaxValue);

		// Token: 0x04000A6E RID: 2670
		public ulong m_SteamInventoryUpdateHandle;
	}
}
