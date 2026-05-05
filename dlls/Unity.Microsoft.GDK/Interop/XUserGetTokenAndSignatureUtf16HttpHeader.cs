using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000298 RID: 664
	internal struct XUserGetTokenAndSignatureUtf16HttpHeader
	{
		// Token: 0x040008D5 RID: 2261
		[MarshalAs(UnmanagedType.LPWStr)]
		internal string name;

		// Token: 0x040008D6 RID: 2262
		[MarshalAs(UnmanagedType.LPWStr)]
		internal string value;
	}
}
