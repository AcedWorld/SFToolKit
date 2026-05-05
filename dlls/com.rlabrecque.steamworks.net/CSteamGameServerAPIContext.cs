using System;

namespace Steamworks
{
	// Token: 0x0200018A RID: 394
	internal static class CSteamGameServerAPIContext
	{
		// Token: 0x0600090E RID: 2318 RVA: 0x0000DD74 File Offset: 0x0000BF74
		internal static void Clear()
		{
			CSteamGameServerAPIContext.m_pSteamClient = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamGameServer = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamUtils = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamNetworking = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamGameServerStats = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamHTTP = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamInventory = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamUGC = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamNetworkingUtils = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamNetworkingSockets = IntPtr.Zero;
			CSteamGameServerAPIContext.m_pSteamNetworkingMessages = IntPtr.Zero;
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x0000DDF0 File Offset: 0x0000BFF0
		internal static bool Init()
		{
			HSteamUser hsteamUser = GameServer.GetHSteamUser();
			HSteamPipe hsteamPipe = GameServer.GetHSteamPipe();
			if (hsteamPipe == (HSteamPipe)0)
			{
				return false;
			}
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle("SteamClient020"))
			{
				CSteamGameServerAPIContext.m_pSteamClient = NativeMethods.SteamInternal_CreateInterface(utf8StringHandle);
			}
			if (CSteamGameServerAPIContext.m_pSteamClient == IntPtr.Zero)
			{
				return false;
			}
			CSteamGameServerAPIContext.m_pSteamGameServer = SteamGameServerClient.GetISteamGameServer(hsteamUser, hsteamPipe, "SteamGameServer014");
			if (CSteamGameServerAPIContext.m_pSteamGameServer == IntPtr.Zero)
			{
				return false;
			}
			CSteamGameServerAPIContext.m_pSteamUtils = SteamGameServerClient.GetISteamUtils(hsteamPipe, "SteamUtils010");
			if (CSteamGameServerAPIContext.m_pSteamUtils == IntPtr.Zero)
			{
				return false;
			}
			CSteamGameServerAPIContext.m_pSteamNetworking = SteamGameServerClient.GetISteamNetworking(hsteamUser, hsteamPipe, "SteamNetworking006");
			if (CSteamGameServerAPIContext.m_pSteamNetworking == IntPtr.Zero)
			{
				return false;
			}
			CSteamGameServerAPIContext.m_pSteamGameServerStats = SteamGameServerClient.GetISteamGameServerStats(hsteamUser, hsteamPipe, "SteamGameServerStats001");
			if (CSteamGameServerAPIContext.m_pSteamGameServerStats == IntPtr.Zero)
			{
				return false;
			}
			CSteamGameServerAPIContext.m_pSteamHTTP = SteamGameServerClient.GetISteamHTTP(hsteamUser, hsteamPipe, "STEAMHTTP_INTERFACE_VERSION003");
			if (CSteamGameServerAPIContext.m_pSteamHTTP == IntPtr.Zero)
			{
				return false;
			}
			CSteamGameServerAPIContext.m_pSteamInventory = SteamGameServerClient.GetISteamInventory(hsteamUser, hsteamPipe, "STEAMINVENTORY_INTERFACE_V003");
			if (CSteamGameServerAPIContext.m_pSteamInventory == IntPtr.Zero)
			{
				return false;
			}
			CSteamGameServerAPIContext.m_pSteamUGC = SteamGameServerClient.GetISteamUGC(hsteamUser, hsteamPipe, "STEAMUGC_INTERFACE_VERSION016");
			if (CSteamGameServerAPIContext.m_pSteamUGC == IntPtr.Zero)
			{
				return false;
			}
			using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle("SteamNetworkingUtils004"))
			{
				CSteamGameServerAPIContext.m_pSteamNetworkingUtils = ((NativeMethods.SteamInternal_FindOrCreateUserInterface(hsteamUser, utf8StringHandle2) != IntPtr.Zero) ? NativeMethods.SteamInternal_FindOrCreateUserInterface(hsteamUser, utf8StringHandle2) : NativeMethods.SteamInternal_FindOrCreateGameServerInterface(hsteamUser, utf8StringHandle2));
			}
			if (CSteamGameServerAPIContext.m_pSteamNetworkingUtils == IntPtr.Zero)
			{
				return false;
			}
			using (InteropHelp.UTF8StringHandle utf8StringHandle3 = new InteropHelp.UTF8StringHandle("SteamNetworkingSockets012"))
			{
				CSteamGameServerAPIContext.m_pSteamNetworkingSockets = NativeMethods.SteamInternal_FindOrCreateGameServerInterface(hsteamUser, utf8StringHandle3);
			}
			if (CSteamGameServerAPIContext.m_pSteamNetworkingSockets == IntPtr.Zero)
			{
				return false;
			}
			using (InteropHelp.UTF8StringHandle utf8StringHandle4 = new InteropHelp.UTF8StringHandle("SteamNetworkingMessages002"))
			{
				CSteamGameServerAPIContext.m_pSteamNetworkingMessages = NativeMethods.SteamInternal_FindOrCreateGameServerInterface(hsteamUser, utf8StringHandle4);
			}
			return !(CSteamGameServerAPIContext.m_pSteamNetworkingMessages == IntPtr.Zero);
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0000E044 File Offset: 0x0000C244
		internal static IntPtr GetSteamClient()
		{
			return CSteamGameServerAPIContext.m_pSteamClient;
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x0000E04B File Offset: 0x0000C24B
		internal static IntPtr GetSteamGameServer()
		{
			return CSteamGameServerAPIContext.m_pSteamGameServer;
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x0000E052 File Offset: 0x0000C252
		internal static IntPtr GetSteamUtils()
		{
			return CSteamGameServerAPIContext.m_pSteamUtils;
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x0000E059 File Offset: 0x0000C259
		internal static IntPtr GetSteamNetworking()
		{
			return CSteamGameServerAPIContext.m_pSteamNetworking;
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x0000E060 File Offset: 0x0000C260
		internal static IntPtr GetSteamGameServerStats()
		{
			return CSteamGameServerAPIContext.m_pSteamGameServerStats;
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x0000E067 File Offset: 0x0000C267
		internal static IntPtr GetSteamHTTP()
		{
			return CSteamGameServerAPIContext.m_pSteamHTTP;
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0000E06E File Offset: 0x0000C26E
		internal static IntPtr GetSteamInventory()
		{
			return CSteamGameServerAPIContext.m_pSteamInventory;
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x0000E075 File Offset: 0x0000C275
		internal static IntPtr GetSteamUGC()
		{
			return CSteamGameServerAPIContext.m_pSteamUGC;
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x0000E07C File Offset: 0x0000C27C
		internal static IntPtr GetSteamNetworkingUtils()
		{
			return CSteamGameServerAPIContext.m_pSteamNetworkingUtils;
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x0000E083 File Offset: 0x0000C283
		internal static IntPtr GetSteamNetworkingSockets()
		{
			return CSteamGameServerAPIContext.m_pSteamNetworkingSockets;
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x0000E08A File Offset: 0x0000C28A
		internal static IntPtr GetSteamNetworkingMessages()
		{
			return CSteamGameServerAPIContext.m_pSteamNetworkingMessages;
		}

		// Token: 0x04000A27 RID: 2599
		private static IntPtr m_pSteamClient;

		// Token: 0x04000A28 RID: 2600
		private static IntPtr m_pSteamGameServer;

		// Token: 0x04000A29 RID: 2601
		private static IntPtr m_pSteamUtils;

		// Token: 0x04000A2A RID: 2602
		private static IntPtr m_pSteamNetworking;

		// Token: 0x04000A2B RID: 2603
		private static IntPtr m_pSteamGameServerStats;

		// Token: 0x04000A2C RID: 2604
		private static IntPtr m_pSteamHTTP;

		// Token: 0x04000A2D RID: 2605
		private static IntPtr m_pSteamInventory;

		// Token: 0x04000A2E RID: 2606
		private static IntPtr m_pSteamUGC;

		// Token: 0x04000A2F RID: 2607
		private static IntPtr m_pSteamNetworkingUtils;

		// Token: 0x04000A30 RID: 2608
		private static IntPtr m_pSteamNetworkingSockets;

		// Token: 0x04000A31 RID: 2609
		private static IntPtr m_pSteamNetworkingMessages;
	}
}
