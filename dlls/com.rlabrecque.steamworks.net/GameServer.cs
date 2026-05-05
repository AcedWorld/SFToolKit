using System;

namespace Steamworks
{
	// Token: 0x02000187 RID: 391
	public static class GameServer
	{
		// Token: 0x060008DF RID: 2271 RVA: 0x0000D588 File Offset: 0x0000B788
		public static bool Init(uint unIP, ushort usGamePort, ushort usQueryPort, EServerMode eServerMode, string pchVersionString)
		{
			InteropHelp.TestIfPlatformSupported();
			bool flag;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchVersionString))
			{
				flag = NativeMethods.SteamInternal_GameServer_Init(unIP, 0, usGamePort, usQueryPort, eServerMode, utf8StringHandle);
			}
			if (flag)
			{
				flag = CSteamGameServerAPIContext.Init();
			}
			if (flag)
			{
				CallbackDispatcher.Initialize();
			}
			return flag;
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x0000D5DC File Offset: 0x0000B7DC
		public static void Shutdown()
		{
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamGameServer_Shutdown();
			CSteamGameServerAPIContext.Clear();
			CallbackDispatcher.Shutdown();
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x0000D5F2 File Offset: 0x0000B7F2
		public static void RunCallbacks()
		{
			CallbackDispatcher.RunFrame(true);
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x0000D5FA File Offset: 0x0000B7FA
		public static void ReleaseCurrentThreadMemory()
		{
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamGameServer_ReleaseCurrentThreadMemory();
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x0000D606 File Offset: 0x0000B806
		public static bool BSecure()
		{
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.SteamGameServer_BSecure();
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x0000D612 File Offset: 0x0000B812
		public static CSteamID GetSteamID()
		{
			InteropHelp.TestIfPlatformSupported();
			return (CSteamID)NativeMethods.SteamGameServer_GetSteamID();
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x0000D623 File Offset: 0x0000B823
		public static HSteamPipe GetHSteamPipe()
		{
			InteropHelp.TestIfPlatformSupported();
			return (HSteamPipe)NativeMethods.SteamGameServer_GetHSteamPipe();
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x0000D634 File Offset: 0x0000B834
		public static HSteamUser GetHSteamUser()
		{
			InteropHelp.TestIfPlatformSupported();
			return (HSteamUser)NativeMethods.SteamGameServer_GetHSteamUser();
		}
	}
}
