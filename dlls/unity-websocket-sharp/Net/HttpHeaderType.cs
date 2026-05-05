using System;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000033 RID: 51
	[Flags]
	internal enum HttpHeaderType
	{
		// Token: 0x04000145 RID: 325
		Unspecified = 0,
		// Token: 0x04000146 RID: 326
		Request = 1,
		// Token: 0x04000147 RID: 327
		Response = 2,
		// Token: 0x04000148 RID: 328
		Restricted = 4,
		// Token: 0x04000149 RID: 329
		MultiValue = 8,
		// Token: 0x0400014A RID: 330
		MultiValueInRequest = 16,
		// Token: 0x0400014B RID: 331
		MultiValueInResponse = 32
	}
}
