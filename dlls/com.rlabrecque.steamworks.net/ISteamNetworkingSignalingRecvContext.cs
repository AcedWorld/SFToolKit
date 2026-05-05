using System;

namespace Steamworks
{
	// Token: 0x020001A7 RID: 423
	[Serializable]
	public struct ISteamNetworkingSignalingRecvContext
	{
		// Token: 0x06000A3B RID: 2619 RVA: 0x0000F462 File Offset: 0x0000D662
		public IntPtr OnConnectRequest(HSteamNetConnection hConn, ref SteamNetworkingIdentity identityPeer, int nLocalVirtualPort)
		{
			return NativeMethods.SteamAPI_ISteamNetworkingSignalingRecvContext_OnConnectRequest(ref this, hConn, ref identityPeer, nLocalVirtualPort);
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x0000F46D File Offset: 0x0000D66D
		public void SendRejectionSignal(ref SteamNetworkingIdentity identityPeer, IntPtr pMsg, int cbMsg)
		{
			NativeMethods.SteamAPI_ISteamNetworkingSignalingRecvContext_SendRejectionSignal(ref this, ref identityPeer, pMsg, cbMsg);
		}
	}
}
