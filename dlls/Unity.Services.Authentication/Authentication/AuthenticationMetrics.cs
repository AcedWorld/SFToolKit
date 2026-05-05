using System;
using Unity.Services.Core.Telemetry.Internal;

namespace Unity.Services.Authentication
{
	// Token: 0x0200000E RID: 14
	internal class AuthenticationMetrics : IAuthenticationMetrics
	{
		// Token: 0x06000100 RID: 256 RVA: 0x000046EC File Offset: 0x000028EC
		internal AuthenticationMetrics(IMetricsFactory metricsFactory)
		{
			this.m_Metrics = metricsFactory.Create("com.unity.services.authentication");
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00004705 File Offset: 0x00002905
		public void SendNetworkErrorMetric()
		{
			this.m_Metrics.SendSumMetric("network_error_event", 1.0, null);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00004721 File Offset: 0x00002921
		public void SendExpiredSessionMetric()
		{
			this.m_Metrics.SendSumMetric("expired_session_event", 1.0, null);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000473D File Offset: 0x0000293D
		public void SendClientInvalidStateExceptionMetric()
		{
			this.m_Metrics.SendSumMetric("client_invalid_state_exception_event", 1.0, null);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00004759 File Offset: 0x00002959
		public void SendUnlinkExternalIdNotFoundExceptionMetric()
		{
			this.m_Metrics.SendSumMetric("unlink_external_id_not_found_exception_event", 1.0, null);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00004775 File Offset: 0x00002975
		public void SendClientSessionTokenNotExistsExceptionMetric()
		{
			this.m_Metrics.SendSumMetric("client_session_token_not_exists_exception_event", 1.0, null);
		}

		// Token: 0x0400003F RID: 63
		private const string k_PackageName = "com.unity.services.authentication";

		// Token: 0x04000040 RID: 64
		private const string k_NetworkErrorKey = "network_error_event";

		// Token: 0x04000041 RID: 65
		private const string k_ExpiredSessionKey = "expired_session_event";

		// Token: 0x04000042 RID: 66
		private const string k_ClientInvalidStateExceptionKey = "client_invalid_state_exception_event";

		// Token: 0x04000043 RID: 67
		private const string k_UnlinkExternalIdNotFoundExceptionKey = "unlink_external_id_not_found_exception_event";

		// Token: 0x04000044 RID: 68
		private const string k_ClientSessionTokenNotExistsExceptionKey = "client_session_token_not_exists_exception_event";

		// Token: 0x04000045 RID: 69
		private readonly IMetrics m_Metrics;
	}
}
