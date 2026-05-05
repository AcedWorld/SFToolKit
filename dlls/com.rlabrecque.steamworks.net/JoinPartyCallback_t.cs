using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000089 RID: 137
	[CallbackIdentity(5301)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct JoinPartyCallback_t
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000851 RID: 2129 RVA: 0x0000BE9B File Offset: 0x0000A09B
		// (set) Token: 0x06000852 RID: 2130 RVA: 0x0000BEA8 File Offset: 0x0000A0A8
		public string m_rgchConnectString
		{
			get
			{
				return InteropHelp.ByteArrayToStringUTF8(this.m_rgchConnectString_);
			}
			set
			{
				InteropHelp.StringToByteArrayUTF8(value, this.m_rgchConnectString_, 256);
			}
		}

		// Token: 0x0400017F RID: 383
		public const int k_iCallback = 5301;

		// Token: 0x04000180 RID: 384
		public EResult m_eResult;

		// Token: 0x04000181 RID: 385
		public PartyBeaconID_t m_ulBeaconID;

		// Token: 0x04000182 RID: 386
		public CSteamID m_SteamIDBeaconOwner;

		// Token: 0x04000183 RID: 387
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		private byte[] m_rgchConnectString_;
	}
}
