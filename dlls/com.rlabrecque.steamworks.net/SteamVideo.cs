using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000027 RID: 39
	public static class SteamVideo
	{
		// Token: 0x06000490 RID: 1168 RVA: 0x0000BD31 File Offset: 0x00009F31
		public static void GetVideoURL(AppId_t unVideoAppID)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamVideo_GetVideoURL(CSteamAPIContext.GetSteamVideo(), unVideoAppID);
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0000BD43 File Offset: 0x00009F43
		public static bool IsBroadcasting(out int pnNumViewers)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamVideo_IsBroadcasting(CSteamAPIContext.GetSteamVideo(), out pnNumViewers);
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0000BD55 File Offset: 0x00009F55
		public static void GetOPFSettings(AppId_t unVideoAppID)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamVideo_GetOPFSettings(CSteamAPIContext.GetSteamVideo(), unVideoAppID);
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0000BD68 File Offset: 0x00009F68
		public static bool GetOPFStringForApp(AppId_t unVideoAppID, out string pchBuffer, ref int pnBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(pnBufferSize);
			bool flag = NativeMethods.ISteamVideo_GetOPFStringForApp(CSteamAPIContext.GetSteamVideo(), unVideoAppID, intPtr, ref pnBufferSize);
			pchBuffer = (flag ? InteropHelp.PtrToStringUTF8(intPtr) : null);
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}
	}
}
