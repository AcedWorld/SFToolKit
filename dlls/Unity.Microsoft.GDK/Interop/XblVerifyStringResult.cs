using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000231 RID: 561
	internal struct XblVerifyStringResult
	{
		// Token: 0x040007D2 RID: 2002
		internal readonly XblVerifyStringResultCode resultCode;

		// Token: 0x040007D3 RID: 2003
		internal readonly UTF8StringPtr firstOffendingSubstring;
	}
}
