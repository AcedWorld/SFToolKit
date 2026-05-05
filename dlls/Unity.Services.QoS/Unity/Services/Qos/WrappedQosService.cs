using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Services.Authentication.Internal;
using Unity.Services.Core.Telemetry.Internal;
using Unity.Services.Qos.Apis.QosDiscovery;
using Unity.Services.Qos.Internal;
using Unity.Services.Qos.Runner;
using Unity.Services.Qos.V2.Apis.QosDiscovery;
using Unity.Services.Qos.V2.Models;

namespace Unity.Services.Qos
{
	// Token: 0x0200001C RID: 28
	internal class WrappedQosService : IQosService
	{
		// Token: 0x06000068 RID: 104 RVA: 0x0000384E File Offset: 0x00001A4E
		internal WrappedQosService(Unity.Services.Qos.Apis.QosDiscovery.IQosDiscoveryApiClient qosDiscoveryApiClient, Unity.Services.Qos.V2.Apis.QosDiscovery.IQosDiscoveryApiClient qosDiscoveryApiClientV2, IQosRunner qosRunner, IAccessToken accessToken, IMetrics metrics)
		{
			this._qosDiscoveryApiClient = qosDiscoveryApiClient;
			this._qosDiscoveryApiClientV2 = qosDiscoveryApiClientV2;
			this._qosRunner = qosRunner;
			this._accessToken = accessToken;
			this._metrics = metrics;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003888 File Offset: 0x00001A88
		public Task<IList<IQosResult>> GetSortedQosResultsAsync(string service, IList<string> regions)
		{
			WrappedQosService.<GetSortedQosResultsAsync>d__18 <GetSortedQosResultsAsync>d__;
			<GetSortedQosResultsAsync>d__.<>t__builder = AsyncTaskMethodBuilder<IList<IQosResult>>.Create();
			<GetSortedQosResultsAsync>d__.<>4__this = this;
			<GetSortedQosResultsAsync>d__.service = service;
			<GetSortedQosResultsAsync>d__.regions = regions;
			<GetSortedQosResultsAsync>d__.<>1__state = -1;
			<GetSortedQosResultsAsync>d__.<>t__builder.Start<WrappedQosService.<GetSortedQosResultsAsync>d__18>(ref <GetSortedQosResultsAsync>d__);
			return <GetSortedQosResultsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000038DC File Offset: 0x00001ADC
		internal Task<IList<QosResult>> GetSortedInternalQosResultsAsync(string service, IList<string> regions)
		{
			WrappedQosService.<GetSortedInternalQosResultsAsync>d__19 <GetSortedInternalQosResultsAsync>d__;
			<GetSortedInternalQosResultsAsync>d__.<>t__builder = AsyncTaskMethodBuilder<IList<QosResult>>.Create();
			<GetSortedInternalQosResultsAsync>d__.<>4__this = this;
			<GetSortedInternalQosResultsAsync>d__.service = service;
			<GetSortedInternalQosResultsAsync>d__.regions = regions;
			<GetSortedInternalQosResultsAsync>d__.<>1__state = -1;
			<GetSortedInternalQosResultsAsync>d__.<>t__builder.Start<WrappedQosService.<GetSortedInternalQosResultsAsync>d__19>(ref <GetSortedInternalQosResultsAsync>d__);
			return <GetSortedInternalQosResultsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003930 File Offset: 0x00001B30
		private List<QosResult> SortResults(IList<QosResult> results)
		{
			return (from q in results
			orderby q.AverageLatencyMs, q.PacketLossPercent
			select q).ToList<QosResult>();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000398C File Offset: 0x00001B8C
		public Task<IList<IQosAnnotatedResult>> GetSortedRelayQosResultsAsync(IList<string> regions)
		{
			WrappedQosService.<GetSortedRelayQosResultsAsync>d__21 <GetSortedRelayQosResultsAsync>d__;
			<GetSortedRelayQosResultsAsync>d__.<>t__builder = AsyncTaskMethodBuilder<IList<IQosAnnotatedResult>>.Create();
			<GetSortedRelayQosResultsAsync>d__.<>4__this = this;
			<GetSortedRelayQosResultsAsync>d__.regions = regions;
			<GetSortedRelayQosResultsAsync>d__.<>1__state = -1;
			<GetSortedRelayQosResultsAsync>d__.<>t__builder.Start<WrappedQosService.<GetSortedRelayQosResultsAsync>d__21>(ref <GetSortedRelayQosResultsAsync>d__);
			return <GetSortedRelayQosResultsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000039D8 File Offset: 0x00001BD8
		public Task<IList<IQosAnnotatedResult>> GetSortedMultiplayQosResultsAsync(IList<string> fleet)
		{
			WrappedQosService.<GetSortedMultiplayQosResultsAsync>d__22 <GetSortedMultiplayQosResultsAsync>d__;
			<GetSortedMultiplayQosResultsAsync>d__.<>t__builder = AsyncTaskMethodBuilder<IList<IQosAnnotatedResult>>.Create();
			<GetSortedMultiplayQosResultsAsync>d__.<>4__this = this;
			<GetSortedMultiplayQosResultsAsync>d__.fleet = fleet;
			<GetSortedMultiplayQosResultsAsync>d__.<>1__state = -1;
			<GetSortedMultiplayQosResultsAsync>d__.<>t__builder.Start<WrappedQosService.<GetSortedMultiplayQosResultsAsync>d__22>(ref <GetSortedMultiplayQosResultsAsync>d__);
			return <GetSortedMultiplayQosResultsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003A24 File Offset: 0x00001C24
		public Task<IList<QosServer>> GetAllServersAsync()
		{
			WrappedQosService.<GetAllServersAsync>d__23 <GetAllServersAsync>d__;
			<GetAllServersAsync>d__.<>t__builder = AsyncTaskMethodBuilder<IList<QosServer>>.Create();
			<GetAllServersAsync>d__.<>4__this = this;
			<GetAllServersAsync>d__.<>1__state = -1;
			<GetAllServersAsync>d__.<>t__builder.Start<WrappedQosService.<GetAllServersAsync>d__23>(ref <GetAllServersAsync>d__);
			return <GetAllServersAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003A68 File Offset: 0x00001C68
		public Task<IList<ValueTuple<QosServer, IQosMeasurements>>> GetQosResultsAsync(IList<QosServer> servers)
		{
			WrappedQosService.<GetQosResultsAsync>d__24 <GetQosResultsAsync>d__;
			<GetQosResultsAsync>d__.<>t__builder = AsyncTaskMethodBuilder<IList<ValueTuple<QosServer, IQosMeasurements>>>.Create();
			<GetQosResultsAsync>d__.<>4__this = this;
			<GetQosResultsAsync>d__.servers = servers;
			<GetQosResultsAsync>d__.<>1__state = -1;
			<GetQosResultsAsync>d__.<>t__builder.Start<WrappedQosService.<GetQosResultsAsync>d__24>(ref <GetQosResultsAsync>d__);
			return <GetQosResultsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003AB4 File Offset: 0x00001CB4
		private void SendResultsMetricsV2(IReadOnlyCollection<ValueTuple<QosServer, IQosMeasurements>> qosResults)
		{
			this.SendResultsMetricsV2ForService(qosResults, (QosServer qs) => qs.Annotations.RelayRegionId, "relay");
			this.SendResultsMetricsV2ForService(qosResults, (QosServer qs) => qs.Annotations.MultiplayRegionId, "multiplay");
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003B18 File Offset: 0x00001D18
		private void SendResultsMetricsV2ForService(IReadOnlyCollection<ValueTuple<QosServer, IQosMeasurements>> allResults, Func<QosServer, List<string>> regionGetter, string service)
		{
			List<ValueTuple<QosServer, IQosMeasurements>> list = (from t in allResults
			where regionGetter(t.Item1) != null && regionGetter(t.Item1).Count > 0
			orderby t.Item2.AverageLatencyMs, t.Item2.PacketLossPercent
			select t).ToList<ValueTuple<QosServer, IQosMeasurements>>();
			for (int i = 0; i < list.Count; i++)
			{
				ValueTuple<QosServer, IQosMeasurements> valueTuple = list[i];
				this.SendResultMetrics(service, this._latestCountryForTelemetry, this._latestRegionForTelemetry, regionGetter(valueTuple.Item1)[0], valueTuple.Item2.AverageLatencyMs, valueTuple.Item2.PacketLossPercent, i == 0);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003BF0 File Offset: 0x00001DF0
		internal Task<IList<IQosAnnotatedResult>> GetSortedInternalServiceQosResultsAsync(string service, IList<string> regions, IList<string> fleet)
		{
			WrappedQosService.<GetSortedInternalServiceQosResultsAsync>d__27 <GetSortedInternalServiceQosResultsAsync>d__;
			<GetSortedInternalServiceQosResultsAsync>d__.<>t__builder = AsyncTaskMethodBuilder<IList<IQosAnnotatedResult>>.Create();
			<GetSortedInternalServiceQosResultsAsync>d__.<>4__this = this;
			<GetSortedInternalServiceQosResultsAsync>d__.service = service;
			<GetSortedInternalServiceQosResultsAsync>d__.regions = regions;
			<GetSortedInternalServiceQosResultsAsync>d__.fleet = fleet;
			<GetSortedInternalServiceQosResultsAsync>d__.<>1__state = -1;
			<GetSortedInternalServiceQosResultsAsync>d__.<>t__builder.Start<WrappedQosService.<GetSortedInternalServiceQosResultsAsync>d__27>(ref <GetSortedInternalServiceQosResultsAsync>d__);
			return <GetSortedInternalServiceQosResultsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003C4C File Offset: 0x00001E4C
		private List<IQosAnnotatedResult> SortServiceResults(IList<QosAnnotatedResult> results)
		{
			return (from q in (from q in results
			where q.AverageLatencyMs != int.MaxValue && (double)q.PacketLossPercent >= 0.0 && (double)q.PacketLossPercent < 1.0
			group q by q.Region into q
			select new QosResult(q.Key, (int)Math.Round((from x in q
			select x.AverageLatencyMs).Average()), (from x in q
			select x.PacketLossPercent).Average(), (from x in q
			select x.Annotations).First<Dictionary<string, List<string>>>())).ToList<IQosAnnotatedResult>()
			orderby q.AverageLatencyMs, q.PacketLossPercent
			select q).ToList<IQosAnnotatedResult>();
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003D18 File Offset: 0x00001F18
		private void SendResultsMetrics(IList<QosResult> sortedResults, string service, Response discoveryResponse)
		{
			string clientCountry;
			discoveryResponse.Headers.TryGetValue("X-Client-Country", out clientCountry);
			string clientRegion;
			discoveryResponse.Headers.TryGetValue("X-Client-Region", out clientRegion);
			for (int i = 0; i < sortedResults.Count; i++)
			{
				QosResult qosResult = sortedResults[i];
				this.SendResultMetrics(service, clientCountry, clientRegion, qosResult.Region, qosResult.AverageLatencyMs, qosResult.PacketLossPercent, i == 0);
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003D84 File Offset: 0x00001F84
		private void SendResultsMetrics(IList<IQosResult> sortedResults, string service, Response discoveryResponse)
		{
			string clientCountry;
			discoveryResponse.Headers.TryGetValue("X-Client-Country", out clientCountry);
			string clientRegion;
			discoveryResponse.Headers.TryGetValue("X-Client-Region", out clientRegion);
			for (int i = 0; i < sortedResults.Count; i++)
			{
				IQosResult qosResult = sortedResults[i];
				this.SendResultMetrics(service, clientCountry, clientRegion, qosResult.Region, qosResult.AverageLatencyMs, qosResult.PacketLossPercent, i == 0);
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003DF0 File Offset: 0x00001FF0
		private void SendResultMetrics(string service, string clientCountry, string clientRegion, string region, int averageLatencyMs, float packetLossPercent, bool isBest)
		{
			IDictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("qos_service_name", service);
			dictionary.Add("qos_service_region", region);
			if (!string.IsNullOrEmpty(clientCountry))
			{
				dictionary.Add("qos_client_country", clientCountry);
			}
			if (!string.IsNullOrEmpty(clientRegion))
			{
				dictionary.Add("qos_client_region", clientRegion);
			}
			if (isBest)
			{
				dictionary.Add("qos_best_result", "true");
			}
			this._metrics.SendHistogramMetric("qos_result_latency_ms", (double)averageLatencyMs, dictionary);
			this._metrics.SendHistogramMetric("qos_result_packet_loss", (double)packetLossPercent, dictionary);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003E80 File Offset: 0x00002080
		private IQosResult MapToPublicQosResult(QosResult internalQosResult)
		{
			return new QosResult(internalQosResult.Region, internalQosResult.AverageLatencyMs, internalQosResult.PacketLossPercent, null);
		}

		// Token: 0x04000053 RID: 83
		private const string ResultLatencyMetricName = "qos_result_latency_ms";

		// Token: 0x04000054 RID: 84
		private const string ResultPacketLossMetricName = "qos_result_packet_loss";

		// Token: 0x04000055 RID: 85
		private const string MetricServiceNameLabelName = "qos_service_name";

		// Token: 0x04000056 RID: 86
		private const string MetricServiceRegionLabelName = "qos_service_region";

		// Token: 0x04000057 RID: 87
		private const string MetricClientCountryLabelName = "qos_client_country";

		// Token: 0x04000058 RID: 88
		private const string MetricClientRegionLabelName = "qos_client_region";

		// Token: 0x04000059 RID: 89
		private const string MetricClientBestResultLabelName = "qos_best_result";

		// Token: 0x0400005A RID: 90
		private const string MetricClientBestResultLabelTrueValue = "true";

		// Token: 0x0400005B RID: 91
		private Unity.Services.Qos.Apis.QosDiscovery.IQosDiscoveryApiClient _qosDiscoveryApiClient;

		// Token: 0x0400005C RID: 92
		private Unity.Services.Qos.V2.Apis.QosDiscovery.IQosDiscoveryApiClient _qosDiscoveryApiClientV2;

		// Token: 0x0400005D RID: 93
		private IQosRunner _qosRunner;

		// Token: 0x0400005E RID: 94
		private IAccessToken _accessToken;

		// Token: 0x0400005F RID: 95
		private IMetrics _metrics;

		// Token: 0x04000060 RID: 96
		private string _latestCountryForTelemetry;

		// Token: 0x04000061 RID: 97
		private string _latestRegionForTelemetry;

		// Token: 0x04000062 RID: 98
		private string _getAllServersEtag = "";

		// Token: 0x04000063 RID: 99
		private IList<QosServer> _getAllServersCached;
	}
}
