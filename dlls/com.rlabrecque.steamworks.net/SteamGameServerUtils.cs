using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000010 RID: 16
	public static class SteamGameServerUtils
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x00006489 File Offset: 0x00004689
		public static uint GetSecondsSinceAppActive()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_GetSecondsSinceAppActive(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0000649A File Offset: 0x0000469A
		public static uint GetSecondsSinceComputerActive()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_GetSecondsSinceComputerActive(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x000064AB File Offset: 0x000046AB
		public static EUniverse GetConnectedUniverse()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_GetConnectedUniverse(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x000064BC File Offset: 0x000046BC
		public static uint GetServerRealTime()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_GetServerRealTime(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x000064CD File Offset: 0x000046CD
		public static string GetIPCountry()
		{
			InteropHelp.TestIfAvailableGameServer();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamUtils_GetIPCountry(CSteamGameServerAPIContext.GetSteamUtils()));
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x000064E3 File Offset: 0x000046E3
		public static bool GetImageSize(int iImage, out uint pnWidth, out uint pnHeight)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_GetImageSize(CSteamGameServerAPIContext.GetSteamUtils(), iImage, out pnWidth, out pnHeight);
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x000064F7 File Offset: 0x000046F7
		public static bool GetImageRGBA(int iImage, byte[] pubDest, int nDestBufferSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_GetImageRGBA(CSteamGameServerAPIContext.GetSteamUtils(), iImage, pubDest, nDestBufferSize);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000650B File Offset: 0x0000470B
		public static byte GetCurrentBatteryPower()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_GetCurrentBatteryPower(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0000651C File Offset: 0x0000471C
		public static AppId_t GetAppID()
		{
			InteropHelp.TestIfAvailableGameServer();
			return (AppId_t)NativeMethods.ISteamUtils_GetAppID(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00006532 File Offset: 0x00004732
		public static void SetOverlayNotificationPosition(ENotificationPosition eNotificationPosition)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamUtils_SetOverlayNotificationPosition(CSteamGameServerAPIContext.GetSteamUtils(), eNotificationPosition);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00006544 File Offset: 0x00004744
		public static bool IsAPICallCompleted(SteamAPICall_t hSteamAPICall, out bool pbFailed)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_IsAPICallCompleted(CSteamGameServerAPIContext.GetSteamUtils(), hSteamAPICall, out pbFailed);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00006557 File Offset: 0x00004757
		public static ESteamAPICallFailure GetAPICallFailureReason(SteamAPICall_t hSteamAPICall)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_GetAPICallFailureReason(CSteamGameServerAPIContext.GetSteamUtils(), hSteamAPICall);
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00006569 File Offset: 0x00004769
		public static bool GetAPICallResult(SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, out bool pbFailed)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_GetAPICallResult(CSteamGameServerAPIContext.GetSteamUtils(), hSteamAPICall, pCallback, cubCallback, iCallbackExpected, out pbFailed);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00006580 File Offset: 0x00004780
		public static uint GetIPCCallCount()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_GetIPCCallCount(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00006591 File Offset: 0x00004791
		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamUtils_SetWarningMessageHook(CSteamGameServerAPIContext.GetSteamUtils(), pFunction);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x000065A3 File Offset: 0x000047A3
		public static bool IsOverlayEnabled()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_IsOverlayEnabled(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x000065B4 File Offset: 0x000047B4
		public static bool BOverlayNeedsPresent()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_BOverlayNeedsPresent(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x000065C8 File Offset: 0x000047C8
		public static SteamAPICall_t CheckFileSignature(string szFileName)
		{
			InteropHelp.TestIfAvailableGameServer();
			SteamAPICall_t result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(szFileName))
			{
				result = (SteamAPICall_t)NativeMethods.ISteamUtils_CheckFileSignature(CSteamGameServerAPIContext.GetSteamUtils(), utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00006610 File Offset: 0x00004810
		public static bool ShowGamepadTextInput(EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText)
		{
			InteropHelp.TestIfAvailableGameServer();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchDescription))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchExistingText))
				{
					result = NativeMethods.ISteamUtils_ShowGamepadTextInput(CSteamGameServerAPIContext.GetSteamUtils(), eInputMode, eLineInputMode, utf8StringHandle, unCharMax, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00006674 File Offset: 0x00004874
		public static uint GetEnteredGamepadTextLength()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_GetEnteredGamepadTextLength(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00006688 File Offset: 0x00004888
		public static bool GetEnteredGamepadTextInput(out string pchText, uint cchText)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchText);
			bool flag = NativeMethods.ISteamUtils_GetEnteredGamepadTextInput(CSteamGameServerAPIContext.GetSteamUtils(), intPtr, cchText);
			pchText = (flag ? InteropHelp.PtrToStringUTF8(intPtr) : null);
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x000066C3 File Offset: 0x000048C3
		public static string GetSteamUILanguage()
		{
			InteropHelp.TestIfAvailableGameServer();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamUtils_GetSteamUILanguage(CSteamGameServerAPIContext.GetSteamUtils()));
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x000066D9 File Offset: 0x000048D9
		public static bool IsSteamRunningInVR()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_IsSteamRunningInVR(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x000066EA File Offset: 0x000048EA
		public static void SetOverlayNotificationInset(int nHorizontalInset, int nVerticalInset)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamUtils_SetOverlayNotificationInset(CSteamGameServerAPIContext.GetSteamUtils(), nHorizontalInset, nVerticalInset);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x000066FD File Offset: 0x000048FD
		public static bool IsSteamInBigPictureMode()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_IsSteamInBigPictureMode(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000670E File Offset: 0x0000490E
		public static void StartVRDashboard()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamUtils_StartVRDashboard(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000671F File Offset: 0x0000491F
		public static bool IsVRHeadsetStreamingEnabled()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_IsVRHeadsetStreamingEnabled(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00006730 File Offset: 0x00004930
		public static void SetVRHeadsetStreamingEnabled(bool bEnabled)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamUtils_SetVRHeadsetStreamingEnabled(CSteamGameServerAPIContext.GetSteamUtils(), bEnabled);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00006742 File Offset: 0x00004942
		public static bool IsSteamChinaLauncher()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_IsSteamChinaLauncher(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00006753 File Offset: 0x00004953
		public static bool InitFilterText(uint unFilterOptions = 0U)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_InitFilterText(CSteamGameServerAPIContext.GetSteamUtils(), unFilterOptions);
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00006768 File Offset: 0x00004968
		public static int FilterText(ETextFilteringContext eContext, CSteamID sourceSteamID, string pchInputMessage, out string pchOutFilteredText, uint nByteSizeOutFilteredText)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal((int)nByteSizeOutFilteredText);
			int result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchInputMessage))
			{
				int num = NativeMethods.ISteamUtils_FilterText(CSteamGameServerAPIContext.GetSteamUtils(), eContext, sourceSteamID, utf8StringHandle, intPtr, nByteSizeOutFilteredText);
				pchOutFilteredText = ((num != -1) ? InteropHelp.PtrToStringUTF8(intPtr) : null);
				Marshal.FreeHGlobal(intPtr);
				result = num;
			}
			return result;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x000067D0 File Offset: 0x000049D0
		public static ESteamIPv6ConnectivityState GetIPv6ConnectivityState(ESteamIPv6ConnectivityProtocol eProtocol)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_GetIPv6ConnectivityState(CSteamGameServerAPIContext.GetSteamUtils(), eProtocol);
		}

		// Token: 0x06000201 RID: 513 RVA: 0x000067E2 File Offset: 0x000049E2
		public static bool IsSteamRunningOnSteamDeck()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_IsSteamRunningOnSteamDeck(CSteamGameServerAPIContext.GetSteamUtils());
		}

		// Token: 0x06000202 RID: 514 RVA: 0x000067F3 File Offset: 0x000049F3
		public static bool ShowFloatingGamepadTextInput(EFloatingGamepadTextInputMode eKeyboardMode, int nTextFieldXPosition, int nTextFieldYPosition, int nTextFieldWidth, int nTextFieldHeight)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_ShowFloatingGamepadTextInput(CSteamGameServerAPIContext.GetSteamUtils(), eKeyboardMode, nTextFieldXPosition, nTextFieldYPosition, nTextFieldWidth, nTextFieldHeight);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000680A File Offset: 0x00004A0A
		public static void SetGameLauncherMode(bool bLauncherMode)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamUtils_SetGameLauncherMode(CSteamGameServerAPIContext.GetSteamUtils(), bLauncherMode);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000681C File Offset: 0x00004A1C
		public static bool DismissFloatingGamepadTextInput()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamUtils_DismissFloatingGamepadTextInput(CSteamGameServerAPIContext.GetSteamUtils());
		}
	}
}
