using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000044 RID: 68
	[CallbackIdentity(349)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct OverlayBrowserProtocolNavigation_t
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000849 RID: 2121 RVA: 0x0000BE1F File Offset: 0x0000A01F
		// (set) Token: 0x0600084A RID: 2122 RVA: 0x0000BE2C File Offset: 0x0000A02C
		public string rgchURI
		{
			get
			{
				return InteropHelp.ByteArrayToStringUTF8(this.rgchURI_);
			}
			set
			{
				InteropHelp.StringToByteArrayUTF8(value, this.rgchURI_, 1024);
			}
		}

		// Token: 0x0400005E RID: 94
		public const int k_iCallback = 349;

		// Token: 0x0400005F RID: 95
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
		private byte[] rgchURI_;
	}
}
