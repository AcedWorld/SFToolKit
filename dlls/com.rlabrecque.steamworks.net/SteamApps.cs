using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000004 RID: 4
	public static class SteamApps
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002177 File Offset: 0x00000377
		public static bool BIsSubscribed()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsSubscribed(CSteamAPIContext.GetSteamApps());
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002188 File Offset: 0x00000388
		public static bool BIsLowViolence()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsLowViolence(CSteamAPIContext.GetSteamApps());
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002199 File Offset: 0x00000399
		public static bool BIsCybercafe()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsCybercafe(CSteamAPIContext.GetSteamApps());
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000021AA File Offset: 0x000003AA
		public static bool BIsVACBanned()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsVACBanned(CSteamAPIContext.GetSteamApps());
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000021BB File Offset: 0x000003BB
		public static string GetCurrentGameLanguage()
		{
			InteropHelp.TestIfAvailableClient();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamApps_GetCurrentGameLanguage(CSteamAPIContext.GetSteamApps()));
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000021D1 File Offset: 0x000003D1
		public static string GetAvailableGameLanguages()
		{
			InteropHelp.TestIfAvailableClient();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamApps_GetAvailableGameLanguages(CSteamAPIContext.GetSteamApps()));
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000021E7 File Offset: 0x000003E7
		public static bool BIsSubscribedApp(AppId_t appID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsSubscribedApp(CSteamAPIContext.GetSteamApps(), appID);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021F9 File Offset: 0x000003F9
		public static bool BIsDlcInstalled(AppId_t appID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsDlcInstalled(CSteamAPIContext.GetSteamApps(), appID);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000220B File Offset: 0x0000040B
		public static uint GetEarliestPurchaseUnixTime(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_GetEarliestPurchaseUnixTime(CSteamAPIContext.GetSteamApps(), nAppID);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000221D File Offset: 0x0000041D
		public static bool BIsSubscribedFromFreeWeekend()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsSubscribedFromFreeWeekend(CSteamAPIContext.GetSteamApps());
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000222E File Offset: 0x0000042E
		public static int GetDLCCount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_GetDLCCount(CSteamAPIContext.GetSteamApps());
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002240 File Offset: 0x00000440
		public static bool BGetDLCDataByIndex(int iDLC, out AppId_t pAppID, out bool pbAvailable, out string pchName, int cchNameBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cchNameBufferSize);
			bool flag = NativeMethods.ISteamApps_BGetDLCDataByIndex(CSteamAPIContext.GetSteamApps(), iDLC, out pAppID, out pbAvailable, intPtr, cchNameBufferSize);
			pchName = (flag ? InteropHelp.PtrToStringUTF8(intPtr) : null);
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002280 File Offset: 0x00000480
		public static void InstallDLC(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamApps_InstallDLC(CSteamAPIContext.GetSteamApps(), nAppID);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002292 File Offset: 0x00000492
		public static void UninstallDLC(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamApps_UninstallDLC(CSteamAPIContext.GetSteamApps(), nAppID);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000022A4 File Offset: 0x000004A4
		public static void RequestAppProofOfPurchaseKey(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamApps_RequestAppProofOfPurchaseKey(CSteamAPIContext.GetSteamApps(), nAppID);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000022B8 File Offset: 0x000004B8
		public static bool GetCurrentBetaName(out string pchName, int cchNameBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cchNameBufferSize);
			bool flag = NativeMethods.ISteamApps_GetCurrentBetaName(CSteamAPIContext.GetSteamApps(), intPtr, cchNameBufferSize);
			pchName = (flag ? InteropHelp.PtrToStringUTF8(intPtr) : null);
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000022F3 File Offset: 0x000004F3
		public static bool MarkContentCorrupt(bool bMissingFilesOnly)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_MarkContentCorrupt(CSteamAPIContext.GetSteamApps(), bMissingFilesOnly);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002305 File Offset: 0x00000505
		public static uint GetInstalledDepots(AppId_t appID, DepotId_t[] pvecDepots, uint cMaxDepots)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_GetInstalledDepots(CSteamAPIContext.GetSteamApps(), appID, pvecDepots, cMaxDepots);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000231C File Offset: 0x0000051C
		public static uint GetAppInstallDir(AppId_t appID, out string pchFolder, uint cchFolderBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchFolderBufferSize);
			uint num = NativeMethods.ISteamApps_GetAppInstallDir(CSteamAPIContext.GetSteamApps(), appID, intPtr, cchFolderBufferSize);
			pchFolder = ((num != 0U) ? InteropHelp.PtrToStringUTF8(intPtr) : null);
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002358 File Offset: 0x00000558
		public static bool BIsAppInstalled(AppId_t appID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsAppInstalled(CSteamAPIContext.GetSteamApps(), appID);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000236A File Offset: 0x0000056A
		public static CSteamID GetAppOwner()
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamApps_GetAppOwner(CSteamAPIContext.GetSteamApps());
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002380 File Offset: 0x00000580
		public static string GetLaunchQueryParam(string pchKey)
		{
			InteropHelp.TestIfAvailableClient();
			string result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchKey))
			{
				result = InteropHelp.PtrToStringUTF8(NativeMethods.ISteamApps_GetLaunchQueryParam(CSteamAPIContext.GetSteamApps(), utf8StringHandle));
			}
			return result;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000023C8 File Offset: 0x000005C8
		public static bool GetDlcDownloadProgress(AppId_t nAppID, out ulong punBytesDownloaded, out ulong punBytesTotal)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_GetDlcDownloadProgress(CSteamAPIContext.GetSteamApps(), nAppID, out punBytesDownloaded, out punBytesTotal);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000023DC File Offset: 0x000005DC
		public static int GetAppBuildId()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_GetAppBuildId(CSteamAPIContext.GetSteamApps());
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000023ED File Offset: 0x000005ED
		public static void RequestAllProofOfPurchaseKeys()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamApps_RequestAllProofOfPurchaseKeys(CSteamAPIContext.GetSteamApps());
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002400 File Offset: 0x00000600
		public static SteamAPICall_t GetFileDetails(string pszFileName)
		{
			InteropHelp.TestIfAvailableClient();
			SteamAPICall_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pszFileName))
			{
				result = (SteamAPICall_t)NativeMethods.ISteamApps_GetFileDetails(CSteamAPIContext.GetSteamApps(), utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002448 File Offset: 0x00000648
		public static int GetLaunchCommandLine(out string pszCommandLine, int cubCommandLine)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cubCommandLine);
			int num = NativeMethods.ISteamApps_GetLaunchCommandLine(CSteamAPIContext.GetSteamApps(), intPtr, cubCommandLine);
			pszCommandLine = ((num != -1) ? InteropHelp.PtrToStringUTF8(intPtr) : null);
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002484 File Offset: 0x00000684
		public static bool BIsSubscribedFromFamilySharing()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsSubscribedFromFamilySharing(CSteamAPIContext.GetSteamApps());
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002495 File Offset: 0x00000695
		public static bool BIsTimedTrial(out uint punSecondsAllowed, out uint punSecondsPlayed)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsTimedTrial(CSteamAPIContext.GetSteamApps(), out punSecondsAllowed, out punSecondsPlayed);
		}
	}
}
