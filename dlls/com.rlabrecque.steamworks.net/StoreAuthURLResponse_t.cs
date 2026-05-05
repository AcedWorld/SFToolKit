using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E3 RID: 227
	[CallbackIdentity(165)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct StoreAuthURLResponse_t
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000869 RID: 2153 RVA: 0x0000C01B File Offset: 0x0000A21B
		// (set) Token: 0x0600086A RID: 2154 RVA: 0x0000C028 File Offset: 0x0000A228
		public string m_szURL
		{
			get
			{
				return InteropHelp.ByteArrayToStringUTF8(this.m_szURL_);
			}
			set
			{
				InteropHelp.StringToByteArrayUTF8(value, this.m_szURL_, 512);
			}
		}

		// Token: 0x040002AF RID: 687
		public const int k_iCallback = 165;

		// Token: 0x040002B0 RID: 688
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
		private byte[] m_szURL_;
	}
}
