using System;

namespace Unity.Services.Wire.Protocol.Internal
{
	// Token: 0x02000003 RID: 3
	internal enum CentrifugeErrorCode
	{
		// Token: 0x04000002 RID: 2
		ErrorInternal = 100,
		// Token: 0x04000003 RID: 3
		ErrorUnauthorized,
		// Token: 0x04000004 RID: 4
		ErrorUnknownChannel,
		// Token: 0x04000005 RID: 5
		ErrorPermissionDenied,
		// Token: 0x04000006 RID: 6
		ErrorMethodNotFound,
		// Token: 0x04000007 RID: 7
		ErrorAlreadySubscribed,
		// Token: 0x04000008 RID: 8
		ErrorLimitExceeded,
		// Token: 0x04000009 RID: 9
		ErrorBadRequest,
		// Token: 0x0400000A RID: 10
		ErrorNotAvailable,
		// Token: 0x0400000B RID: 11
		ErrorTokenExpired,
		// Token: 0x0400000C RID: 12
		ErrorExpired,
		// Token: 0x0400000D RID: 13
		ErrorTooManyRequests,
		// Token: 0x0400000E RID: 14
		ErrorUnrecoverablePosition
	}
}
