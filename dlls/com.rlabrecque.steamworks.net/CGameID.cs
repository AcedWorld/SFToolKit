using System;

namespace Steamworks
{
	// Token: 0x0200018F RID: 399
	[Serializable]
	public struct CGameID : IEquatable<CGameID>, IComparable<CGameID>
	{
		// Token: 0x06000940 RID: 2368 RVA: 0x0000E3FF File Offset: 0x0000C5FF
		public CGameID(ulong GameID)
		{
			this.m_GameID = GameID;
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x0000E408 File Offset: 0x0000C608
		public CGameID(AppId_t nAppID)
		{
			this.m_GameID = 0UL;
			this.SetAppID(nAppID);
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x0000E419 File Offset: 0x0000C619
		public CGameID(AppId_t nAppID, uint nModID)
		{
			this.m_GameID = 0UL;
			this.SetAppID(nAppID);
			this.SetType(CGameID.EGameIDType.k_EGameIDTypeGameMod);
			this.SetModID(nModID);
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0000E438 File Offset: 0x0000C638
		public bool IsSteamApp()
		{
			return this.Type() == CGameID.EGameIDType.k_EGameIDTypeApp;
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x0000E443 File Offset: 0x0000C643
		public bool IsMod()
		{
			return this.Type() == CGameID.EGameIDType.k_EGameIDTypeGameMod;
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x0000E44E File Offset: 0x0000C64E
		public bool IsShortcut()
		{
			return this.Type() == CGameID.EGameIDType.k_EGameIDTypeShortcut;
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x0000E459 File Offset: 0x0000C659
		public bool IsP2PFile()
		{
			return this.Type() == CGameID.EGameIDType.k_EGameIDTypeP2P;
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x0000E464 File Offset: 0x0000C664
		public AppId_t AppID()
		{
			return new AppId_t((uint)(this.m_GameID & 16777215UL));
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x0000E479 File Offset: 0x0000C679
		public CGameID.EGameIDType Type()
		{
			return (CGameID.EGameIDType)(this.m_GameID >> 24 & 255UL);
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x0000E48C File Offset: 0x0000C68C
		public uint ModID()
		{
			return (uint)(this.m_GameID >> 32 & (ulong)-1);
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x0000E49C File Offset: 0x0000C69C
		public bool IsValid()
		{
			switch (this.Type())
			{
			case CGameID.EGameIDType.k_EGameIDTypeApp:
				return this.AppID() != AppId_t.Invalid;
			case CGameID.EGameIDType.k_EGameIDTypeGameMod:
				return this.AppID() != AppId_t.Invalid && (this.ModID() & 2147483648U) > 0U;
			case CGameID.EGameIDType.k_EGameIDTypeShortcut:
				return (this.ModID() & 2147483648U) > 0U;
			case CGameID.EGameIDType.k_EGameIDTypeP2P:
				return this.AppID() == AppId_t.Invalid && (this.ModID() & 2147483648U) > 0U;
			default:
				return false;
			}
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x0000E532 File Offset: 0x0000C732
		public void Reset()
		{
			this.m_GameID = 0UL;
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x0000E53C File Offset: 0x0000C73C
		public void Set(ulong GameID)
		{
			this.m_GameID = GameID;
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x0000E545 File Offset: 0x0000C745
		private void SetAppID(AppId_t other)
		{
			this.m_GameID = ((this.m_GameID & 18446744073692774400UL) | ((ulong)((uint)other) & 16777215UL));
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x0000E569 File Offset: 0x0000C769
		private void SetType(CGameID.EGameIDType other)
		{
			this.m_GameID = ((this.m_GameID & 18446744069431361535UL) | (ulong)((ulong)((long)other & 255L) << 24));
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x0000E58E File Offset: 0x0000C78E
		private void SetModID(uint other)
		{
			this.m_GameID = ((this.m_GameID & (ulong)-1) | ((ulong)other & (ulong)-1) << 32);
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x0000E5A8 File Offset: 0x0000C7A8
		public override string ToString()
		{
			return this.m_GameID.ToString();
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x0000E5B5 File Offset: 0x0000C7B5
		public override bool Equals(object other)
		{
			return other is CGameID && this == (CGameID)other;
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x0000E5D2 File Offset: 0x0000C7D2
		public override int GetHashCode()
		{
			return this.m_GameID.GetHashCode();
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x0000E5DF File Offset: 0x0000C7DF
		public static bool operator ==(CGameID x, CGameID y)
		{
			return x.m_GameID == y.m_GameID;
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x0000E5EF File Offset: 0x0000C7EF
		public static bool operator !=(CGameID x, CGameID y)
		{
			return !(x == y);
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x0000E5FB File Offset: 0x0000C7FB
		public static explicit operator CGameID(ulong value)
		{
			return new CGameID(value);
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x0000E603 File Offset: 0x0000C803
		public static explicit operator ulong(CGameID that)
		{
			return that.m_GameID;
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x0000E60B File Offset: 0x0000C80B
		public bool Equals(CGameID other)
		{
			return this.m_GameID == other.m_GameID;
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x0000E61B File Offset: 0x0000C81B
		public int CompareTo(CGameID other)
		{
			return this.m_GameID.CompareTo(other.m_GameID);
		}

		// Token: 0x04000A47 RID: 2631
		public ulong m_GameID;

		// Token: 0x020001E8 RID: 488
		public enum EGameIDType
		{
			// Token: 0x04000ADA RID: 2778
			k_EGameIDTypeApp,
			// Token: 0x04000ADB RID: 2779
			k_EGameIDTypeGameMod,
			// Token: 0x04000ADC RID: 2780
			k_EGameIDTypeShortcut,
			// Token: 0x04000ADD RID: 2781
			k_EGameIDTypeP2P
		}
	}
}
