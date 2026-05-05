using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000253 RID: 595
	internal struct XGameUiWebAuthenticationResultData
	{
		// Token: 0x04000819 RID: 2073
		internal uint responseStatus;

		// Token: 0x0400081A RID: 2074
		internal ulong responseCompletionUriSize;

		// Token: 0x0400081B RID: 2075
		[MarshalAs(UnmanagedType.LPStr)]
		internal string responseCompletionUri;
	}
}
