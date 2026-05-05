using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000173 RID: 371
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamNetConnectionInfo_t
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600087C RID: 2172 RVA: 0x0000C14B File Offset: 0x0000A34B
		// (set) Token: 0x0600087D RID: 2173 RVA: 0x0000C158 File Offset: 0x0000A358
		public string m_szEndDebug
		{
			get
			{
				return InteropHelp.ByteArrayToStringUTF8(this.m_szEndDebug_);
			}
			set
			{
				InteropHelp.StringToByteArrayUTF8(value, this.m_szEndDebug_, 128);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600087E RID: 2174 RVA: 0x0000C16B File Offset: 0x0000A36B
		// (set) Token: 0x0600087F RID: 2175 RVA: 0x0000C178 File Offset: 0x0000A378
		public string m_szConnectionDescription
		{
			get
			{
				return InteropHelp.ByteArrayToStringUTF8(this.m_szConnectionDescription_);
			}
			set
			{
				InteropHelp.StringToByteArrayUTF8(value, this.m_szConnectionDescription_, 128);
			}
		}

		// Token: 0x040009C1 RID: 2497
		public SteamNetworkingIdentity m_identityRemote;

		// Token: 0x040009C2 RID: 2498
		public long m_nUserData;

		// Token: 0x040009C3 RID: 2499
		public HSteamListenSocket m_hListenSocket;

		// Token: 0x040009C4 RID: 2500
		public SteamNetworkingIPAddr m_addrRemote;

		// Token: 0x040009C5 RID: 2501
		public ushort m__pad1;

		// Token: 0x040009C6 RID: 2502
		public SteamNetworkingPOPID m_idPOPRemote;

		// Token: 0x040009C7 RID: 2503
		public SteamNetworkingPOPID m_idPOPRelay;

		// Token: 0x040009C8 RID: 2504
		public ESteamNetworkingConnectionState m_eState;

		// Token: 0x040009C9 RID: 2505
		public int m_eEndReason;

		// Token: 0x040009CA RID: 2506
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		private byte[] m_szEndDebug_;

		// Token: 0x040009CB RID: 2507
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		private byte[] m_szConnectionDescription_;

		// Token: 0x040009CC RID: 2508
		public int m_nFlags;

		// Token: 0x040009CD RID: 2509
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 63)]
		public uint[] reserved;
	}
}
