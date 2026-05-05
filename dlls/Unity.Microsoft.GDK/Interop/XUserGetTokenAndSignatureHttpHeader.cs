using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000296 RID: 662
	internal struct XUserGetTokenAndSignatureHttpHeader
	{
		// Token: 0x040008CF RID: 2255
		[MarshalAs(UnmanagedType.LPStr)]
		internal string name;

		// Token: 0x040008D0 RID: 2256
		[MarshalAs(UnmanagedType.LPStr)]
		internal string value;
	}
}
