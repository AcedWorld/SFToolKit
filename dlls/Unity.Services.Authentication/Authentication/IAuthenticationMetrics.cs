using System;

namespace Unity.Services.Authentication
{
	// Token: 0x0200000F RID: 15
	internal interface IAuthenticationMetrics
	{
		// Token: 0x06000106 RID: 262
		void SendNetworkErrorMetric();

		// Token: 0x06000107 RID: 263
		void SendExpiredSessionMetric();

		// Token: 0x06000108 RID: 264
		void SendClientInvalidStateExceptionMetric();

		// Token: 0x06000109 RID: 265
		void SendUnlinkExternalIdNotFoundExceptionMetric();

		// Token: 0x0600010A RID: 266
		void SendClientSessionTokenNotExistsExceptionMetric();
	}
}
