using System;

namespace Steamworks
{
	// Token: 0x0200000B RID: 11
	public static class SteamGameServerNetworking
	{
		// Token: 0x06000121 RID: 289 RVA: 0x00004BCC File Offset: 0x00002DCC
		public static bool SendP2PPacket(CSteamID steamIDRemote, byte[] pubData, uint cubData, EP2PSend eP2PSendType, int nChannel = 0)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_SendP2PPacket(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDRemote, pubData, cubData, eP2PSendType, nChannel);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00004BE3 File Offset: 0x00002DE3
		public static bool IsP2PPacketAvailable(out uint pcubMsgSize, int nChannel = 0)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_IsP2PPacketAvailable(CSteamGameServerAPIContext.GetSteamNetworking(), out pcubMsgSize, nChannel);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00004BF6 File Offset: 0x00002DF6
		public static bool ReadP2PPacket(byte[] pubDest, uint cubDest, out uint pcubMsgSize, out CSteamID psteamIDRemote, int nChannel = 0)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_ReadP2PPacket(CSteamGameServerAPIContext.GetSteamNetworking(), pubDest, cubDest, out pcubMsgSize, out psteamIDRemote, nChannel);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00004C0D File Offset: 0x00002E0D
		public static bool AcceptP2PSessionWithUser(CSteamID steamIDRemote)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_AcceptP2PSessionWithUser(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDRemote);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00004C1F File Offset: 0x00002E1F
		public static bool CloseP2PSessionWithUser(CSteamID steamIDRemote)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_CloseP2PSessionWithUser(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDRemote);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00004C31 File Offset: 0x00002E31
		public static bool CloseP2PChannelWithUser(CSteamID steamIDRemote, int nChannel)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_CloseP2PChannelWithUser(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDRemote, nChannel);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00004C44 File Offset: 0x00002E44
		public static bool GetP2PSessionState(CSteamID steamIDRemote, out P2PSessionState_t pConnectionState)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_GetP2PSessionState(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDRemote, out pConnectionState);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00004C57 File Offset: 0x00002E57
		public static bool AllowP2PPacketRelay(bool bAllow)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_AllowP2PPacketRelay(CSteamGameServerAPIContext.GetSteamNetworking(), bAllow);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00004C69 File Offset: 0x00002E69
		public static SNetListenSocket_t CreateListenSocket(int nVirtualP2PPort, SteamIPAddress_t nIP, ushort nPort, bool bAllowUseOfPacketRelay)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SNetListenSocket_t)NativeMethods.ISteamNetworking_CreateListenSocket(CSteamGameServerAPIContext.GetSteamNetworking(), nVirtualP2PPort, nIP, nPort, bAllowUseOfPacketRelay);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00004C83 File Offset: 0x00002E83
		public static SNetSocket_t CreateP2PConnectionSocket(CSteamID steamIDTarget, int nVirtualPort, int nTimeoutSec, bool bAllowUseOfPacketRelay)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SNetSocket_t)NativeMethods.ISteamNetworking_CreateP2PConnectionSocket(CSteamGameServerAPIContext.GetSteamNetworking(), steamIDTarget, nVirtualPort, nTimeoutSec, bAllowUseOfPacketRelay);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00004C9D File Offset: 0x00002E9D
		public static SNetSocket_t CreateConnectionSocket(SteamIPAddress_t nIP, ushort nPort, int nTimeoutSec)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SNetSocket_t)NativeMethods.ISteamNetworking_CreateConnectionSocket(CSteamGameServerAPIContext.GetSteamNetworking(), nIP, nPort, nTimeoutSec);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00004CB6 File Offset: 0x00002EB6
		public static bool DestroySocket(SNetSocket_t hSocket, bool bNotifyRemoteEnd)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_DestroySocket(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, bNotifyRemoteEnd);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00004CC9 File Offset: 0x00002EC9
		public static bool DestroyListenSocket(SNetListenSocket_t hSocket, bool bNotifyRemoteEnd)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_DestroyListenSocket(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, bNotifyRemoteEnd);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00004CDC File Offset: 0x00002EDC
		public static bool SendDataOnSocket(SNetSocket_t hSocket, byte[] pubData, uint cubData, bool bReliable)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_SendDataOnSocket(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, pubData, cubData, bReliable);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00004CF1 File Offset: 0x00002EF1
		public static bool IsDataAvailableOnSocket(SNetSocket_t hSocket, out uint pcubMsgSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_IsDataAvailableOnSocket(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, out pcubMsgSize);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00004D04 File Offset: 0x00002F04
		public static bool RetrieveDataFromSocket(SNetSocket_t hSocket, byte[] pubDest, uint cubDest, out uint pcubMsgSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_RetrieveDataFromSocket(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, pubDest, cubDest, out pcubMsgSize);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00004D19 File Offset: 0x00002F19
		public static bool IsDataAvailable(SNetListenSocket_t hListenSocket, out uint pcubMsgSize, out SNetSocket_t phSocket)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_IsDataAvailable(CSteamGameServerAPIContext.GetSteamNetworking(), hListenSocket, out pcubMsgSize, out phSocket);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00004D2D File Offset: 0x00002F2D
		public static bool RetrieveData(SNetListenSocket_t hListenSocket, byte[] pubDest, uint cubDest, out uint pcubMsgSize, out SNetSocket_t phSocket)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_RetrieveData(CSteamGameServerAPIContext.GetSteamNetworking(), hListenSocket, pubDest, cubDest, out pcubMsgSize, out phSocket);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00004D44 File Offset: 0x00002F44
		public static bool GetSocketInfo(SNetSocket_t hSocket, out CSteamID pSteamIDRemote, out int peSocketStatus, out SteamIPAddress_t punIPRemote, out ushort punPortRemote)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_GetSocketInfo(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket, out pSteamIDRemote, out peSocketStatus, out punIPRemote, out punPortRemote);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00004D5B File Offset: 0x00002F5B
		public static bool GetListenSocketInfo(SNetListenSocket_t hListenSocket, out SteamIPAddress_t pnIP, out ushort pnPort)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_GetListenSocketInfo(CSteamGameServerAPIContext.GetSteamNetworking(), hListenSocket, out pnIP, out pnPort);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00004D6F File Offset: 0x00002F6F
		public static ESNetSocketConnectionType GetSocketConnectionType(SNetSocket_t hSocket)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_GetSocketConnectionType(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00004D81 File Offset: 0x00002F81
		public static int GetMaxPacketSize(SNetSocket_t hSocket)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamNetworking_GetMaxPacketSize(CSteamGameServerAPIContext.GetSteamNetworking(), hSocket);
		}
	}
}
