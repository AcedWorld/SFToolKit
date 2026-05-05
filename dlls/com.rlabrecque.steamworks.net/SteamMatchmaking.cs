using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000015 RID: 21
	public static class SteamMatchmaking
	{
		// Token: 0x06000298 RID: 664 RVA: 0x00007B2C File Offset: 0x00005D2C
		public static int GetFavoriteGameCount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetFavoriteGameCount(CSteamAPIContext.GetSteamMatchmaking());
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00007B3D File Offset: 0x00005D3D
		public static bool GetFavoriteGame(int iGame, out AppId_t pnAppID, out uint pnIP, out ushort pnConnPort, out ushort pnQueryPort, out uint punFlags, out uint pRTime32LastPlayedOnServer)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetFavoriteGame(CSteamAPIContext.GetSteamMatchmaking(), iGame, out pnAppID, out pnIP, out pnConnPort, out pnQueryPort, out punFlags, out pRTime32LastPlayedOnServer);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00007B58 File Offset: 0x00005D58
		public static int AddFavoriteGame(AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags, uint rTime32LastPlayedOnServer)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_AddFavoriteGame(CSteamAPIContext.GetSteamMatchmaking(), nAppID, nIP, nConnPort, nQueryPort, unFlags, rTime32LastPlayedOnServer);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00007B71 File Offset: 0x00005D71
		public static bool RemoveFavoriteGame(AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_RemoveFavoriteGame(CSteamAPIContext.GetSteamMatchmaking(), nAppID, nIP, nConnPort, nQueryPort, unFlags);
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00007B88 File Offset: 0x00005D88
		public static SteamAPICall_t RequestLobbyList()
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamMatchmaking_RequestLobbyList(CSteamAPIContext.GetSteamMatchmaking());
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00007BA0 File Offset: 0x00005DA0
		public static void AddRequestLobbyListStringFilter(string pchKeyToMatch, string pchValueToMatch, ELobbyComparison eComparisonType)
		{
			InteropHelp.TestIfAvailableClient();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKeyToMatch))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchValueToMatch))
				{
					NativeMethods.ISteamMatchmaking_AddRequestLobbyListStringFilter(CSteamAPIContext.GetSteamMatchmaking(), utf8StringHandle, utf8StringHandle2, eComparisonType);
				}
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00007C00 File Offset: 0x00005E00
		public static void AddRequestLobbyListNumericalFilter(string pchKeyToMatch, int nValueToMatch, ELobbyComparison eComparisonType)
		{
			InteropHelp.TestIfAvailableClient();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKeyToMatch))
			{
				NativeMethods.ISteamMatchmaking_AddRequestLobbyListNumericalFilter(CSteamAPIContext.GetSteamMatchmaking(), utf8StringHandle, nValueToMatch, eComparisonType);
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00007C44 File Offset: 0x00005E44
		public static void AddRequestLobbyListNearValueFilter(string pchKeyToMatch, int nValueToBeCloseTo)
		{
			InteropHelp.TestIfAvailableClient();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKeyToMatch))
			{
				NativeMethods.ISteamMatchmaking_AddRequestLobbyListNearValueFilter(CSteamAPIContext.GetSteamMatchmaking(), utf8StringHandle, nValueToBeCloseTo);
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00007C88 File Offset: 0x00005E88
		public static void AddRequestLobbyListFilterSlotsAvailable(int nSlotsAvailable)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_AddRequestLobbyListFilterSlotsAvailable(CSteamAPIContext.GetSteamMatchmaking(), nSlotsAvailable);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00007C9A File Offset: 0x00005E9A
		public static void AddRequestLobbyListDistanceFilter(ELobbyDistanceFilter eLobbyDistanceFilter)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_AddRequestLobbyListDistanceFilter(CSteamAPIContext.GetSteamMatchmaking(), eLobbyDistanceFilter);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00007CAC File Offset: 0x00005EAC
		public static void AddRequestLobbyListResultCountFilter(int cMaxResults)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_AddRequestLobbyListResultCountFilter(CSteamAPIContext.GetSteamMatchmaking(), cMaxResults);
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00007CBE File Offset: 0x00005EBE
		public static void AddRequestLobbyListCompatibleMembersFilter(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_AddRequestLobbyListCompatibleMembersFilter(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00007CD0 File Offset: 0x00005ED0
		public static CSteamID GetLobbyByIndex(int iLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamMatchmaking_GetLobbyByIndex(CSteamAPIContext.GetSteamMatchmaking(), iLobby);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00007CE7 File Offset: 0x00005EE7
		public static SteamAPICall_t CreateLobby(ELobbyType eLobbyType, int cMaxMembers)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamMatchmaking_CreateLobby(CSteamAPIContext.GetSteamMatchmaking(), eLobbyType, cMaxMembers);
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00007CFF File Offset: 0x00005EFF
		public static SteamAPICall_t JoinLobby(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamMatchmaking_JoinLobby(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00007D16 File Offset: 0x00005F16
		public static void LeaveLobby(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_LeaveLobby(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00007D28 File Offset: 0x00005F28
		public static bool InviteUserToLobby(CSteamID steamIDLobby, CSteamID steamIDInvitee)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_InviteUserToLobby(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, steamIDInvitee);
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00007D3B File Offset: 0x00005F3B
		public static int GetNumLobbyMembers(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetNumLobbyMembers(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00007D4D File Offset: 0x00005F4D
		public static CSteamID GetLobbyMemberByIndex(CSteamID steamIDLobby, int iMember)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamMatchmaking_GetLobbyMemberByIndex(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, iMember);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00007D68 File Offset: 0x00005F68
		public static string GetLobbyData(CSteamID steamIDLobby, string pchKey)
		{
			InteropHelp.TestIfAvailableClient();
			string result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				result = InteropHelp.PtrToStringUTF8(NativeMethods.ISteamMatchmaking_GetLobbyData(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, utf8StringHandle));
			}
			return result;
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00007DB0 File Offset: 0x00005FB0
		public static bool SetLobbyData(CSteamID steamIDLobby, string pchKey, string pchValue)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchValue))
				{
					result = NativeMethods.ISteamMatchmaking_SetLobbyData(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00007E14 File Offset: 0x00006014
		public static int GetLobbyDataCount(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetLobbyDataCount(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00007E28 File Offset: 0x00006028
		public static bool GetLobbyDataByIndex(CSteamID steamIDLobby, int iLobbyData, out string pchKey, int cchKeyBufferSize, out string pchValue, int cchValueBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cchKeyBufferSize);
			IntPtr intPtr2 = Marshal.AllocHGlobal(cchValueBufferSize);
			bool flag = NativeMethods.ISteamMatchmaking_GetLobbyDataByIndex(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, iLobbyData, intPtr, cchKeyBufferSize, intPtr2, cchValueBufferSize);
			pchKey = (flag ? InteropHelp.PtrToStringUTF8(intPtr) : null);
			Marshal.FreeHGlobal(intPtr);
			pchValue = (flag ? InteropHelp.PtrToStringUTF8(intPtr2) : null);
			Marshal.FreeHGlobal(intPtr2);
			return flag;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00007E88 File Offset: 0x00006088
		public static bool DeleteLobbyData(CSteamID steamIDLobby, string pchKey)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				result = NativeMethods.ISteamMatchmaking_DeleteLobbyData(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00007ECC File Offset: 0x000060CC
		public static string GetLobbyMemberData(CSteamID steamIDLobby, CSteamID steamIDUser, string pchKey)
		{
			InteropHelp.TestIfAvailableClient();
			string result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				result = InteropHelp.PtrToStringUTF8(NativeMethods.ISteamMatchmaking_GetLobbyMemberData(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, steamIDUser, utf8StringHandle));
			}
			return result;
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00007F18 File Offset: 0x00006118
		public static void SetLobbyMemberData(CSteamID steamIDLobby, string pchKey, string pchValue)
		{
			InteropHelp.TestIfAvailableClient();
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchValue))
				{
					NativeMethods.ISteamMatchmaking_SetLobbyMemberData(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, utf8StringHandle, utf8StringHandle2);
				}
			}
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00007F78 File Offset: 0x00006178
		public static bool SendLobbyChatMsg(CSteamID steamIDLobby, byte[] pvMsgBody, int cubMsgBody)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SendLobbyChatMsg(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, pvMsgBody, cubMsgBody);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00007F8C File Offset: 0x0000618C
		public static int GetLobbyChatEntry(CSteamID steamIDLobby, int iChatID, out CSteamID pSteamIDUser, byte[] pvData, int cubData, out EChatEntryType peChatEntryType)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetLobbyChatEntry(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, iChatID, out pSteamIDUser, pvData, cubData, out peChatEntryType);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00007FA5 File Offset: 0x000061A5
		public static bool RequestLobbyData(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_RequestLobbyData(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00007FB7 File Offset: 0x000061B7
		public static void SetLobbyGameServer(CSteamID steamIDLobby, uint unGameServerIP, ushort unGameServerPort, CSteamID steamIDGameServer)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_SetLobbyGameServer(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, unGameServerIP, unGameServerPort, steamIDGameServer);
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00007FCC File Offset: 0x000061CC
		public static bool GetLobbyGameServer(CSteamID steamIDLobby, out uint punGameServerIP, out ushort punGameServerPort, out CSteamID psteamIDGameServer)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetLobbyGameServer(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, out punGameServerIP, out punGameServerPort, out psteamIDGameServer);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00007FE1 File Offset: 0x000061E1
		public static bool SetLobbyMemberLimit(CSteamID steamIDLobby, int cMaxMembers)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLobbyMemberLimit(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, cMaxMembers);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00007FF4 File Offset: 0x000061F4
		public static int GetLobbyMemberLimit(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetLobbyMemberLimit(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00008006 File Offset: 0x00006206
		public static bool SetLobbyType(CSteamID steamIDLobby, ELobbyType eLobbyType)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLobbyType(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, eLobbyType);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00008019 File Offset: 0x00006219
		public static bool SetLobbyJoinable(CSteamID steamIDLobby, bool bLobbyJoinable)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLobbyJoinable(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, bLobbyJoinable);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000802C File Offset: 0x0000622C
		public static CSteamID GetLobbyOwner(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamMatchmaking_GetLobbyOwner(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00008043 File Offset: 0x00006243
		public static bool SetLobbyOwner(CSteamID steamIDLobby, CSteamID steamIDNewOwner)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLobbyOwner(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, steamIDNewOwner);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00008056 File Offset: 0x00006256
		public static bool SetLinkedLobby(CSteamID steamIDLobby, CSteamID steamIDLobbyDependent)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLinkedLobby(CSteamAPIContext.GetSteamMatchmaking(), steamIDLobby, steamIDLobbyDependent);
		}
	}
}
