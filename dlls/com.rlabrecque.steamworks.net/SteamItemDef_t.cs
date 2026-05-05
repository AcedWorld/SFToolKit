using System;

namespace Steamworks
{
	// Token: 0x020001A0 RID: 416
	[Serializable]
	public struct SteamItemDef_t : IEquatable<SteamItemDef_t>, IComparable<SteamItemDef_t>
	{
		// Token: 0x060009FB RID: 2555 RVA: 0x0000F0D4 File Offset: 0x0000D2D4
		public SteamItemDef_t(int value)
		{
			this.m_SteamItemDef = value;
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x0000F0DD File Offset: 0x0000D2DD
		public override string ToString()
		{
			return this.m_SteamItemDef.ToString();
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x0000F0EA File Offset: 0x0000D2EA
		public override bool Equals(object other)
		{
			return other is SteamItemDef_t && this == (SteamItemDef_t)other;
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x0000F107 File Offset: 0x0000D307
		public override int GetHashCode()
		{
			return this.m_SteamItemDef.GetHashCode();
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x0000F114 File Offset: 0x0000D314
		public static bool operator ==(SteamItemDef_t x, SteamItemDef_t y)
		{
			return x.m_SteamItemDef == y.m_SteamItemDef;
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x0000F124 File Offset: 0x0000D324
		public static bool operator !=(SteamItemDef_t x, SteamItemDef_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x0000F130 File Offset: 0x0000D330
		public static explicit operator SteamItemDef_t(int value)
		{
			return new SteamItemDef_t(value);
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x0000F138 File Offset: 0x0000D338
		public static explicit operator int(SteamItemDef_t that)
		{
			return that.m_SteamItemDef;
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x0000F140 File Offset: 0x0000D340
		public bool Equals(SteamItemDef_t other)
		{
			return this.m_SteamItemDef == other.m_SteamItemDef;
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x0000F150 File Offset: 0x0000D350
		public int CompareTo(SteamItemDef_t other)
		{
			return this.m_SteamItemDef.CompareTo(other.m_SteamItemDef);
		}

		// Token: 0x04000A6F RID: 2671
		public int m_SteamItemDef;
	}
}
