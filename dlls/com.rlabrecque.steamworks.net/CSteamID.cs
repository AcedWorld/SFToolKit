using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000190 RID: 400
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct CSteamID : IEquatable<CSteamID>, IComparable<CSteamID>
	{
		// Token: 0x06000959 RID: 2393 RVA: 0x0000E62E File Offset: 0x0000C82E
		public CSteamID(AccountID_t unAccountID, EUniverse eUniverse, EAccountType eAccountType)
		{
			this.m_SteamID = 0UL;
			this.Set(unAccountID, eUniverse, eAccountType);
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0000E641 File Offset: 0x0000C841
		public CSteamID(AccountID_t unAccountID, uint unAccountInstance, EUniverse eUniverse, EAccountType eAccountType)
		{
			this.m_SteamID = 0UL;
			this.InstancedSet(unAccountID, unAccountInstance, eUniverse, eAccountType);
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0000E656 File Offset: 0x0000C856
		public CSteamID(ulong ulSteamID)
		{
			this.m_SteamID = ulSteamID;
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0000E65F File Offset: 0x0000C85F
		public void Set(AccountID_t unAccountID, EUniverse eUniverse, EAccountType eAccountType)
		{
			this.SetAccountID(unAccountID);
			this.SetEUniverse(eUniverse);
			this.SetEAccountType(eAccountType);
			if (eAccountType == EAccountType.k_EAccountTypeClan || eAccountType == EAccountType.k_EAccountTypeGameServer)
			{
				this.SetAccountInstance(0U);
				return;
			}
			this.SetAccountInstance(1U);
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0000E68D File Offset: 0x0000C88D
		public void InstancedSet(AccountID_t unAccountID, uint unInstance, EUniverse eUniverse, EAccountType eAccountType)
		{
			this.SetAccountID(unAccountID);
			this.SetEUniverse(eUniverse);
			this.SetEAccountType(eAccountType);
			this.SetAccountInstance(unInstance);
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0000E6AC File Offset: 0x0000C8AC
		public void Clear()
		{
			this.m_SteamID = 0UL;
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0000E6B6 File Offset: 0x0000C8B6
		public void CreateBlankAnonLogon(EUniverse eUniverse)
		{
			this.SetAccountID(new AccountID_t(0U));
			this.SetEUniverse(eUniverse);
			this.SetEAccountType(EAccountType.k_EAccountTypeAnonGameServer);
			this.SetAccountInstance(0U);
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x0000E6D9 File Offset: 0x0000C8D9
		public void CreateBlankAnonUserLogon(EUniverse eUniverse)
		{
			this.SetAccountID(new AccountID_t(0U));
			this.SetEUniverse(eUniverse);
			this.SetEAccountType(EAccountType.k_EAccountTypeAnonUser);
			this.SetAccountInstance(0U);
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x0000E6FD File Offset: 0x0000C8FD
		public bool BBlankAnonAccount()
		{
			return this.GetAccountID() == new AccountID_t(0U) && this.BAnonAccount() && this.GetUnAccountInstance() == 0U;
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x0000E725 File Offset: 0x0000C925
		public bool BGameServerAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeGameServer || this.GetEAccountType() == EAccountType.k_EAccountTypeAnonGameServer;
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x0000E73B File Offset: 0x0000C93B
		public bool BPersistentGameServerAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeGameServer;
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x0000E746 File Offset: 0x0000C946
		public bool BAnonGameServerAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeAnonGameServer;
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x0000E751 File Offset: 0x0000C951
		public bool BContentServerAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeContentServer;
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x0000E75C File Offset: 0x0000C95C
		public bool BClanAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeClan;
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x0000E767 File Offset: 0x0000C967
		public bool BChatAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeChat;
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0000E772 File Offset: 0x0000C972
		public bool IsLobby()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeChat && (this.GetUnAccountInstance() & 262144U) > 0U;
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x0000E78E File Offset: 0x0000C98E
		public bool BIndividualAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeIndividual || this.GetEAccountType() == EAccountType.k_EAccountTypeConsoleUser;
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x0000E7A5 File Offset: 0x0000C9A5
		public bool BAnonAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeAnonUser || this.GetEAccountType() == EAccountType.k_EAccountTypeAnonGameServer;
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x0000E7BC File Offset: 0x0000C9BC
		public bool BAnonUserAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeAnonUser;
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x0000E7C8 File Offset: 0x0000C9C8
		public bool BConsoleUserAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeConsoleUser;
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0000E7D4 File Offset: 0x0000C9D4
		public void SetAccountID(AccountID_t other)
		{
			this.m_SteamID = ((this.m_SteamID & 18446744069414584320UL) | ((ulong)((uint)other) & (ulong)-1));
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0000E7F7 File Offset: 0x0000C9F7
		public void SetAccountInstance(uint other)
		{
			this.m_SteamID = ((this.m_SteamID & 18442240478377148415UL) | ((ulong)other & 1048575UL) << 32);
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0000E81C File Offset: 0x0000CA1C
		public void SetEAccountType(EAccountType other)
		{
			this.m_SteamID = ((this.m_SteamID & 18379190079298994175UL) | (ulong)((ulong)((long)other & 15L) << 52));
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x0000E83E File Offset: 0x0000CA3E
		public void SetEUniverse(EUniverse other)
		{
			this.m_SteamID = ((this.m_SteamID & 72057594037927935UL) | (ulong)((ulong)((long)other & 255L) << 56));
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0000E863 File Offset: 0x0000CA63
		public AccountID_t GetAccountID()
		{
			return new AccountID_t((uint)(this.m_SteamID & (ulong)-1));
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x0000E874 File Offset: 0x0000CA74
		public uint GetUnAccountInstance()
		{
			return (uint)(this.m_SteamID >> 32 & 1048575UL);
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x0000E887 File Offset: 0x0000CA87
		public EAccountType GetEAccountType()
		{
			return (EAccountType)(this.m_SteamID >> 52 & 15UL);
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x0000E897 File Offset: 0x0000CA97
		public EUniverse GetEUniverse()
		{
			return (EUniverse)(this.m_SteamID >> 56 & 255UL);
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x0000E8AC File Offset: 0x0000CAAC
		public bool IsValid()
		{
			return this.GetEAccountType() > EAccountType.k_EAccountTypeInvalid && this.GetEAccountType() < EAccountType.k_EAccountTypeMax && this.GetEUniverse() > EUniverse.k_EUniverseInvalid && this.GetEUniverse() < EUniverse.k_EUniverseMax && (this.GetEAccountType() != EAccountType.k_EAccountTypeIndividual || (!(this.GetAccountID() == new AccountID_t(0U)) && this.GetUnAccountInstance() <= 1U)) && (this.GetEAccountType() != EAccountType.k_EAccountTypeClan || (!(this.GetAccountID() == new AccountID_t(0U)) && this.GetUnAccountInstance() == 0U)) && (this.GetEAccountType() != EAccountType.k_EAccountTypeGameServer || !(this.GetAccountID() == new AccountID_t(0U)));
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x0000E94E File Offset: 0x0000CB4E
		public override string ToString()
		{
			return this.m_SteamID.ToString();
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0000E95B File Offset: 0x0000CB5B
		public override bool Equals(object other)
		{
			return other is CSteamID && this == (CSteamID)other;
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x0000E978 File Offset: 0x0000CB78
		public override int GetHashCode()
		{
			return this.m_SteamID.GetHashCode();
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0000E985 File Offset: 0x0000CB85
		public static bool operator ==(CSteamID x, CSteamID y)
		{
			return x.m_SteamID == y.m_SteamID;
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x0000E995 File Offset: 0x0000CB95
		public static bool operator !=(CSteamID x, CSteamID y)
		{
			return !(x == y);
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x0000E9A1 File Offset: 0x0000CBA1
		public static explicit operator CSteamID(ulong value)
		{
			return new CSteamID(value);
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x0000E9A9 File Offset: 0x0000CBA9
		public static explicit operator ulong(CSteamID that)
		{
			return that.m_SteamID;
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0000E9B1 File Offset: 0x0000CBB1
		public bool Equals(CSteamID other)
		{
			return this.m_SteamID == other.m_SteamID;
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0000E9C1 File Offset: 0x0000CBC1
		public int CompareTo(CSteamID other)
		{
			return this.m_SteamID.CompareTo(other.m_SteamID);
		}

		// Token: 0x04000A48 RID: 2632
		public static readonly CSteamID Nil = default(CSteamID);

		// Token: 0x04000A49 RID: 2633
		public static readonly CSteamID OutofDateGS = new CSteamID(new AccountID_t(0U), 0U, EUniverse.k_EUniverseInvalid, EAccountType.k_EAccountTypeInvalid);

		// Token: 0x04000A4A RID: 2634
		public static readonly CSteamID LanModeGS = new CSteamID(new AccountID_t(0U), 0U, EUniverse.k_EUniversePublic, EAccountType.k_EAccountTypeInvalid);

		// Token: 0x04000A4B RID: 2635
		public static readonly CSteamID NotInitYetGS = new CSteamID(new AccountID_t(1U), 0U, EUniverse.k_EUniverseInvalid, EAccountType.k_EAccountTypeInvalid);

		// Token: 0x04000A4C RID: 2636
		public static readonly CSteamID NonSteamGS = new CSteamID(new AccountID_t(2U), 0U, EUniverse.k_EUniverseInvalid, EAccountType.k_EAccountTypeInvalid);

		// Token: 0x04000A4D RID: 2637
		public ulong m_SteamID;
	}
}
