using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A6 RID: 166
	[CallbackIdentity(1281)]
	public struct SteamRelayNetworkStatus_t
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000855 RID: 2133 RVA: 0x0000BEDB File Offset: 0x0000A0DB
		// (set) Token: 0x06000856 RID: 2134 RVA: 0x0000BEE8 File Offset: 0x0000A0E8
		public string m_debugMsg
		{
			get
			{
				return InteropHelp.ByteArrayToStringUTF8(this.m_debugMsg_);
			}
			set
			{
				InteropHelp.StringToByteArrayUTF8(value, this.m_debugMsg_, 256);
			}
		}

		// Token: 0x040001BA RID: 442
		public const int k_iCallback = 1281;

		// Token: 0x040001BB RID: 443
		public ESteamNetworkingAvailability m_eAvail;

		// Token: 0x040001BC RID: 444
		public int m_bPingMeasurementInProgress;

		// Token: 0x040001BD RID: 445
		public ESteamNetworkingAvailability m_eAvailNetworkConfig;

		// Token: 0x040001BE RID: 446
		public ESteamNetworkingAvailability m_eAvailAnyRelay;

		// Token: 0x040001BF RID: 447
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		private byte[] m_debugMsg_;
	}
}
