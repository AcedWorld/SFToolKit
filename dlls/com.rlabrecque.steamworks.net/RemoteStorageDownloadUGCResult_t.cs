using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B2 RID: 178
	[CallbackIdentity(1317)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageDownloadUGCResult_t
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000859 RID: 2137 RVA: 0x0000BF1B File Offset: 0x0000A11B
		// (set) Token: 0x0600085A RID: 2138 RVA: 0x0000BF28 File Offset: 0x0000A128
		public string m_pchFileName
		{
			get
			{
				return InteropHelp.ByteArrayToStringUTF8(this.m_pchFileName_);
			}
			set
			{
				InteropHelp.StringToByteArrayUTF8(value, this.m_pchFileName_, 260);
			}
		}

		// Token: 0x040001E5 RID: 485
		public const int k_iCallback = 1317;

		// Token: 0x040001E6 RID: 486
		public EResult m_eResult;

		// Token: 0x040001E7 RID: 487
		public UGCHandle_t m_hFile;

		// Token: 0x040001E8 RID: 488
		public AppId_t m_nAppID;

		// Token: 0x040001E9 RID: 489
		public int m_nSizeInBytes;

		// Token: 0x040001EA RID: 490
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
		private byte[] m_pchFileName_;

		// Token: 0x040001EB RID: 491
		public ulong m_ulSteamIDOwner;
	}
}
