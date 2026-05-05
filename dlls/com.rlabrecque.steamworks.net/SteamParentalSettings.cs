using System;

namespace Steamworks
{
	// Token: 0x0200001F RID: 31
	public static class SteamParentalSettings
	{
		// Token: 0x06000378 RID: 888 RVA: 0x0000937C File Offset: 0x0000757C
		public static bool BIsParentalLockEnabled()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParentalSettings_BIsParentalLockEnabled(CSteamAPIContext.GetSteamParentalSettings());
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0000938D File Offset: 0x0000758D
		public static bool BIsParentalLockLocked()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParentalSettings_BIsParentalLockLocked(CSteamAPIContext.GetSteamParentalSettings());
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000939E File Offset: 0x0000759E
		public static bool BIsAppBlocked(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParentalSettings_BIsAppBlocked(CSteamAPIContext.GetSteamParentalSettings(), nAppID);
		}

		// Token: 0x0600037B RID: 891 RVA: 0x000093B0 File Offset: 0x000075B0
		public static bool BIsAppInBlockList(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParentalSettings_BIsAppInBlockList(CSteamAPIContext.GetSteamParentalSettings(), nAppID);
		}

		// Token: 0x0600037C RID: 892 RVA: 0x000093C2 File Offset: 0x000075C2
		public static bool BIsFeatureBlocked(EParentalFeature eFeature)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParentalSettings_BIsFeatureBlocked(CSteamAPIContext.GetSteamParentalSettings(), eFeature);
		}

		// Token: 0x0600037D RID: 893 RVA: 0x000093D4 File Offset: 0x000075D4
		public static bool BIsFeatureInBlockList(EParentalFeature eFeature)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamParentalSettings_BIsFeatureInBlockList(CSteamAPIContext.GetSteamParentalSettings(), eFeature);
		}
	}
}
