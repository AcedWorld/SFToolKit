using System;

namespace Steamworks
{
	// Token: 0x020001A6 RID: 422
	[Serializable]
	public struct ISteamNetworkingConnectionSignaling
	{
		// Token: 0x06000A39 RID: 2617 RVA: 0x0000F44D File Offset: 0x0000D64D
		public bool SendSignal(HSteamNetConnection hConn, ref SteamNetConnectionInfo_t info, IntPtr pMsg, int cbMsg)
		{
			return NativeMethods.SteamAPI_ISteamNetworkingConnectionSignaling_SendSignal(ref this, hConn, ref info, pMsg, cbMsg);
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x0000F45A File Offset: 0x0000D65A
		public void Release()
		{
			NativeMethods.SteamAPI_ISteamNetworkingConnectionSignaling_Release(ref this);
		}
	}
}
