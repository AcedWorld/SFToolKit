using System;

namespace Steamworks
{
	// Token: 0x0200001C RID: 28
	public static class SteamNetworkingMessages
	{
		// Token: 0x06000328 RID: 808 RVA: 0x00008B86 File Offset: 0x00006D86
		public static EResult SendMessageToUser(ref SteamNetworkingIdentity identityRemote, IntPtr pubData, uint cubData, int nSendFlags, int nRemoteChannel)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingMessages_SendMessageToUser(CSteamAPIContext.GetSteamNetworkingMessages(), ref identityRemote, pubData, cubData, nSendFlags, nRemoteChannel);
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00008B9D File Offset: 0x00006D9D
		public static int ReceiveMessagesOnChannel(int nLocalChannel, IntPtr[] ppOutMessages, int nMaxMessages)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingMessages_ReceiveMessagesOnChannel(CSteamAPIContext.GetSteamNetworkingMessages(), nLocalChannel, ppOutMessages, nMaxMessages);
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00008BB1 File Offset: 0x00006DB1
		public static bool AcceptSessionWithUser(ref SteamNetworkingIdentity identityRemote)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingMessages_AcceptSessionWithUser(CSteamAPIContext.GetSteamNetworkingMessages(), ref identityRemote);
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00008BC3 File Offset: 0x00006DC3
		public static bool CloseSessionWithUser(ref SteamNetworkingIdentity identityRemote)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingMessages_CloseSessionWithUser(CSteamAPIContext.GetSteamNetworkingMessages(), ref identityRemote);
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00008BD5 File Offset: 0x00006DD5
		public static bool CloseChannelWithUser(ref SteamNetworkingIdentity identityRemote, int nLocalChannel)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingMessages_CloseChannelWithUser(CSteamAPIContext.GetSteamNetworkingMessages(), ref identityRemote, nLocalChannel);
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00008BE8 File Offset: 0x00006DE8
		public static ESteamNetworkingConnectionState GetSessionConnectionInfo(ref SteamNetworkingIdentity identityRemote, out SteamNetConnectionInfo_t pConnectionInfo, out SteamNetConnectionRealTimeStatus_t pQuickStatus)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworkingMessages_GetSessionConnectionInfo(CSteamAPIContext.GetSteamNetworkingMessages(), ref identityRemote, out pConnectionInfo, out pQuickStatus);
		}
	}
}
