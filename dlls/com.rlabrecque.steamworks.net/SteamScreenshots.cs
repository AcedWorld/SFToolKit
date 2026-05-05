using System;

namespace Steamworks
{
	// Token: 0x02000022 RID: 34
	public static class SteamScreenshots
	{
		// Token: 0x060003C0 RID: 960 RVA: 0x00009EE0 File Offset: 0x000080E0
		public static ScreenshotHandle WriteScreenshot(byte[] pubRGB, uint cubRGB, int nWidth, int nHeight)
		{
			InteropHelp.TestIfAvailableClient();
			return (ScreenshotHandle)NativeMethods.ISteamScreenshots_WriteScreenshot(CSteamAPIContext.GetSteamScreenshots(), pubRGB, cubRGB, nWidth, nHeight);
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00009EFC File Offset: 0x000080FC
		public static ScreenshotHandle AddScreenshotToLibrary(string pchFilename, string pchThumbnailFilename, int nWidth, int nHeight)
		{
			InteropHelp.TestIfAvailableClient();
			ScreenshotHandle result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchFilename))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchThumbnailFilename))
				{
					result = (ScreenshotHandle)NativeMethods.ISteamScreenshots_AddScreenshotToLibrary(CSteamAPIContext.GetSteamScreenshots(), utf8StringHandle, utf8StringHandle2, nWidth, nHeight);
				}
			}
			return result;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00009F64 File Offset: 0x00008164
		public static void TriggerScreenshot()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamScreenshots_TriggerScreenshot(CSteamAPIContext.GetSteamScreenshots());
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00009F75 File Offset: 0x00008175
		public static void HookScreenshots(bool bHook)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamScreenshots_HookScreenshots(CSteamAPIContext.GetSteamScreenshots(), bHook);
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00009F88 File Offset: 0x00008188
		public static bool SetLocation(ScreenshotHandle hScreenshot, string pchLocation)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchLocation))
			{
				result = NativeMethods.ISteamScreenshots_SetLocation(CSteamAPIContext.GetSteamScreenshots(), hScreenshot, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00009FCC File Offset: 0x000081CC
		public static bool TagUser(ScreenshotHandle hScreenshot, CSteamID steamID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamScreenshots_TagUser(CSteamAPIContext.GetSteamScreenshots(), hScreenshot, steamID);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00009FDF File Offset: 0x000081DF
		public static bool TagPublishedFile(ScreenshotHandle hScreenshot, PublishedFileId_t unPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamScreenshots_TagPublishedFile(CSteamAPIContext.GetSteamScreenshots(), hScreenshot, unPublishedFileID);
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00009FF2 File Offset: 0x000081F2
		public static bool IsScreenshotsHooked()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamScreenshots_IsScreenshotsHooked(CSteamAPIContext.GetSteamScreenshots());
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0000A004 File Offset: 0x00008204
		public static ScreenshotHandle AddVRScreenshotToLibrary(EVRScreenshotType eType, string pchFilename, string pchVRFilename)
		{
			InteropHelp.TestIfAvailableClient();
			ScreenshotHandle result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchFilename))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchVRFilename))
				{
					result = (ScreenshotHandle)NativeMethods.ISteamScreenshots_AddVRScreenshotToLibrary(CSteamAPIContext.GetSteamScreenshots(), eType, utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}
	}
}
