using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000033 RID: 51
	[CallbackIdentity(332)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GameServerChangeRequested_t
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000843 RID: 2115 RVA: 0x0000BDC5 File Offset: 0x00009FC5
		// (set) Token: 0x06000844 RID: 2116 RVA: 0x0000BDD2 File Offset: 0x00009FD2
		public string m_rgchServer
		{
			get
			{
				return InteropHelp.ByteArrayToStringUTF8(this.m_rgchServer_);
			}
			set
			{
				InteropHelp.StringToByteArrayUTF8(value, this.m_rgchServer_, 64);
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000845 RID: 2117 RVA: 0x0000BDE2 File Offset: 0x00009FE2
		// (set) Token: 0x06000846 RID: 2118 RVA: 0x0000BDEF File Offset: 0x00009FEF
		public string m_rgchPassword
		{
			get
			{
				return InteropHelp.ByteArrayToStringUTF8(this.m_rgchPassword_);
			}
			set
			{
				InteropHelp.StringToByteArrayUTF8(value, this.m_rgchPassword_, 64);
			}
		}

		// Token: 0x04000023 RID: 35
		public const int k_iCallback = 332;

		// Token: 0x04000024 RID: 36
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		private byte[] m_rgchServer_;

		// Token: 0x04000025 RID: 37
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		private byte[] m_rgchPassword_;
	}
}
