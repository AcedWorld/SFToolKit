using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000297 RID: 663
	internal struct XUserGetTokenAndSignatureUtf16Data
	{
		// Token: 0x040008D1 RID: 2257
		internal ulong tokenSize;

		// Token: 0x040008D2 RID: 2258
		internal ulong signatureSize;

		// Token: 0x040008D3 RID: 2259
		[MarshalAs(UnmanagedType.LPWStr)]
		internal string token;

		// Token: 0x040008D4 RID: 2260
		[MarshalAs(UnmanagedType.LPWStr)]
		internal string signature;
	}
}
