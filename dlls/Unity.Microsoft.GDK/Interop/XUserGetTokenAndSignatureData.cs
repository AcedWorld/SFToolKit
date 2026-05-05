using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000295 RID: 661
	internal struct XUserGetTokenAndSignatureData
	{
		// Token: 0x040008CB RID: 2251
		internal ulong tokenSize;

		// Token: 0x040008CC RID: 2252
		internal ulong signatureSize;

		// Token: 0x040008CD RID: 2253
		[MarshalAs(UnmanagedType.LPStr)]
		internal string token;

		// Token: 0x040008CE RID: 2254
		[MarshalAs(UnmanagedType.LPStr)]
		internal string signature;
	}
}
