using System;
using Unity.Services.Core.Telemetry.Internal;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x0200005A RID: 90
	internal class ApiTelemetryScopeFactory
	{
		// Token: 0x06000259 RID: 601 RVA: 0x00009238 File Offset: 0x00007438
		public ApiTelemetryScopeFactory(IMetrics metrics)
		{
			this.m_Metrics = metrics;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00009247 File Offset: 0x00007447
		public ApiTelemetryScope Instrument(string api)
		{
			return new ApiTelemetryScope(this.m_Metrics, api);
		}

		// Token: 0x0400011C RID: 284
		private readonly IMetrics m_Metrics;
	}
}
