using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000270 RID: 624
	internal struct XStoreImage
	{
		// Token: 0x0400085D RID: 2141
		[MarshalAs(UnmanagedType.LPStr)]
		internal string uri;

		// Token: 0x0400085E RID: 2142
		internal uint height;

		// Token: 0x0400085F RID: 2143
		internal uint width;

		// Token: 0x04000860 RID: 2144
		[MarshalAs(UnmanagedType.LPStr)]
		internal string caption;

		// Token: 0x04000861 RID: 2145
		[MarshalAs(UnmanagedType.LPStr)]
		internal string imagePurposeTag;
	}
}
