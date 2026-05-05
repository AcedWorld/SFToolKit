using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000017 RID: 23
	public static class SteamGameSearch
	{
		// Token: 0x060002CF RID: 719 RVA: 0x00008254 File Offset: 0x00006454
		public static EGameSearchErrorCode_t AddGameSearchParams(string pchKeyToFind, string pchValuesToFind)
		{
			InteropHelp.TestIfAvailableClient();
			EGameSearchErrorCode_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKeyToFind))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchValuesToFind))
				{
					result = NativeMethods.ISteamGameSearch_AddGameSearchParams(CSteamAPIContext.GetSteamGameSearch(), utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x000082B4 File Offset: 0x000064B4
		public static EGameSearchErrorCode_t SearchForGameWithLobby(CSteamID steamIDLobby, int nPlayerMin, int nPlayerMax)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamGameSearch_SearchForGameWithLobby(CSteamAPIContext.GetSteamGameSearch(), steamIDLobby, nPlayerMin, nPlayerMax);
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x000082C8 File Offset: 0x000064C8
		public static EGameSearchErrorCode_t SearchForGameSolo(int nPlayerMin, int nPlayerMax)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamGameSearch_SearchForGameSolo(CSteamAPIContext.GetSteamGameSearch(), nPlayerMin, nPlayerMax);
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x000082DB File Offset: 0x000064DB
		public static EGameSearchErrorCode_t AcceptGame()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamGameSearch_AcceptGame(CSteamAPIContext.GetSteamGameSearch());
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x000082EC File Offset: 0x000064EC
		public static EGameSearchErrorCode_t DeclineGame()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamGameSearch_DeclineGame(CSteamAPIContext.GetSteamGameSearch());
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00008300 File Offset: 0x00006500
		public static EGameSearchErrorCode_t RetrieveConnectionDetails(CSteamID steamIDHost, out string pchConnectionDetails, int cubConnectionDetails)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cubConnectionDetails);
			EGameSearchErrorCode_t egameSearchErrorCode_t = NativeMethods.ISteamGameSearch_RetrieveConnectionDetails(CSteamAPIContext.GetSteamGameSearch(), steamIDHost, intPtr, cubConnectionDetails);
			pchConnectionDetails = ((egameSearchErrorCode_t != (EGameSearchErrorCode_t)0) ? InteropHelp.PtrToStringUTF8(intPtr) : null);
			Marshal.FreeHGlobal(intPtr);
			return egameSearchErrorCode_t;
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000833C File Offset: 0x0000653C
		public static EGameSearchErrorCode_t EndGameSearch()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamGameSearch_EndGameSearch(CSteamAPIContext.GetSteamGameSearch());
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00008350 File Offset: 0x00006550
		public static EGameSearchErrorCode_t SetGameHostParams(string pchKey, string pchValue)
		{
			InteropHelp.TestIfAvailableClient();
			EGameSearchErrorCode_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchValue))
				{
					result = NativeMethods.ISteamGameSearch_SetGameHostParams(CSteamAPIContext.GetSteamGameSearch(), utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x000083B0 File Offset: 0x000065B0
		public static EGameSearchErrorCode_t SetConnectionDetails(string pchConnectionDetails, int cubConnectionDetails)
		{
			InteropHelp.TestIfAvailableClient();
			EGameSearchErrorCode_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchConnectionDetails))
			{
				result = NativeMethods.ISteamGameSearch_SetConnectionDetails(CSteamAPIContext.GetSteamGameSearch(), utf8StringHandle, cubConnectionDetails);
			}
			return result;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x000083F4 File Offset: 0x000065F4
		public static EGameSearchErrorCode_t RequestPlayersForGame(int nPlayerMin, int nPlayerMax, int nMaxTeamSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamGameSearch_RequestPlayersForGame(CSteamAPIContext.GetSteamGameSearch(), nPlayerMin, nPlayerMax, nMaxTeamSize);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00008408 File Offset: 0x00006608
		public static EGameSearchErrorCode_t HostConfirmGameStart(ulong ullUniqueGameID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamGameSearch_HostConfirmGameStart(CSteamAPIContext.GetSteamGameSearch(), ullUniqueGameID);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000841A File Offset: 0x0000661A
		public static EGameSearchErrorCode_t CancelRequestPlayersForGame()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamGameSearch_CancelRequestPlayersForGame(CSteamAPIContext.GetSteamGameSearch());
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000842B File Offset: 0x0000662B
		public static EGameSearchErrorCode_t SubmitPlayerResult(ulong ullUniqueGameID, CSteamID steamIDPlayer, EPlayerResult_t EPlayerResult)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamGameSearch_SubmitPlayerResult(CSteamAPIContext.GetSteamGameSearch(), ullUniqueGameID, steamIDPlayer, EPlayerResult);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000843F File Offset: 0x0000663F
		public static EGameSearchErrorCode_t EndGame(ulong ullUniqueGameID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamGameSearch_EndGame(CSteamAPIContext.GetSteamGameSearch(), ullUniqueGameID);
		}
	}
}
