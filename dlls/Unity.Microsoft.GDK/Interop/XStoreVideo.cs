using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000275 RID: 629
	internal struct XStoreVideo
	{
		// Token: 0x0400087B RID: 2171
		[MarshalAs(UnmanagedType.LPStr)]
		internal string uri;

		// Token: 0x0400087C RID: 2172
		internal uint height;

		// Token: 0x0400087D RID: 2173
		internal uint width;

		// Token: 0x0400087E RID: 2174
		[MarshalAs(UnmanagedType.LPStr)]
		internal string caption;

		// Token: 0x0400087F RID: 2175
		[MarshalAs(UnmanagedType.LPStr)]
		internal string videoPurposeTag;

		// Token: 0x04000880 RID: 2176
		internal XStoreImage previewImage;
	}
}
