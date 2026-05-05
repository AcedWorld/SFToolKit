using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E2 RID: 226
	[CallbackIdentity(164)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GameWebCallback_t
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000867 RID: 2151 RVA: 0x0000BFFB File Offset: 0x0000A1FB
		// (set) Token: 0x06000868 RID: 2152 RVA: 0x0000C008 File Offset: 0x0000A208
		public string m_szURL
		{
			get
			{
				return InteropHelp.ByteArrayToStringUTF8(this.m_szURL_);
			}
			set
			{
				InteropHelp.StringToByteArrayUTF8(value, this.m_szURL_, 256);
			}
		}

		// Token: 0x040002AD RID: 685
		public const int k_iCallback = 164;

		// Token: 0x040002AE RID: 686
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		private byte[] m_szURL_;
	}
}
