using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200006A RID: 106
	[CallbackIdentity(4527)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_BrowserRestarted_t
	{
		// Token: 0x040000FA RID: 250
		public const int k_iCallback = 4527;

		// Token: 0x040000FB RID: 251
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040000FC RID: 252
		public HHTMLBrowser unOldBrowserHandle;
	}
}
