using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Services.Core.Telemetry.Internal;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x0200005B RID: 91
	internal sealed class ApiTelemetryScope : IDisposable
	{
		// Token: 0x0600025B RID: 603 RVA: 0x00009255 File Offset: 0x00007455
		public ApiTelemetryScope(IMetrics metrics, string api)
		{
			this.m_Metrics = metrics;
			this.m_Tags = new Dictionary<string, string>
			{
				{
					"api",
					api
				}
			};
			this.m_Stopwatch = new Stopwatch();
			this.m_Stopwatch.Start();
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00009291 File Offset: 0x00007491
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x000092A0 File Offset: 0x000074A0
		private void Dispose(bool disposing)
		{
			if (this.m_Disposed)
			{
				return;
			}
			this.m_Disposed = true;
			if (disposing)
			{
				this.m_Stopwatch.Stop();
				this.m_Metrics.SendHistogramMetric("http_request_ms", (double)this.m_Stopwatch.ElapsedMilliseconds, this.m_Tags);
			}
		}

		// Token: 0x0400011D RID: 285
		private const string k_RequestLatencyMetric = "http_request_ms";

		// Token: 0x0400011E RID: 286
		private const string k_ApiTag = "api";

		// Token: 0x0400011F RID: 287
		private readonly IMetrics m_Metrics;

		// Token: 0x04000120 RID: 288
		private readonly Dictionary<string, string> m_Tags;

		// Token: 0x04000121 RID: 289
		private readonly Stopwatch m_Stopwatch;

		// Token: 0x04000122 RID: 290
		private bool m_Disposed;
	}
}
