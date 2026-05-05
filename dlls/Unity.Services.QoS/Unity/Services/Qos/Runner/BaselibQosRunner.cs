using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Networking.QoS;
using Unity.Services.Qos.Internal;
using Unity.Services.Qos.Models;
using Unity.Services.Qos.V2.Models;

namespace Unity.Services.Qos.Runner
{
	// Token: 0x0200004E RID: 78
	internal class BaselibQosRunner : IQosRunner
	{
		// Token: 0x0600016F RID: 367 RVA: 0x0000618C File Offset: 0x0000438C
		public BaselibQosRunner(QosJobProvider qosJobProvider = null, DnsResolver dnsResolver = null)
		{
			if (qosJobProvider != null)
			{
				this._qosJobProvider = qosJobProvider;
			}
			if (dnsResolver != null)
			{
				this._dnsResolver = dnsResolver;
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000061EC File Offset: 0x000043EC
		public Task<List<QosResult>> MeasureQosAsync(IList<Unity.Services.Qos.Models.QosServer> servers)
		{
			BaselibQosRunner.<MeasureQosAsync>d__3 <MeasureQosAsync>d__;
			<MeasureQosAsync>d__.<>t__builder = AsyncTaskMethodBuilder<List<QosResult>>.Create();
			<MeasureQosAsync>d__.<>4__this = this;
			<MeasureQosAsync>d__.servers = servers;
			<MeasureQosAsync>d__.<>1__state = -1;
			<MeasureQosAsync>d__.<>t__builder.Start<BaselibQosRunner.<MeasureQosAsync>d__3>(ref <MeasureQosAsync>d__);
			return <MeasureQosAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00006238 File Offset: 0x00004438
		public Task<List<QosAnnotatedResult>> MeasureQosAsync(IList<QosServiceServer> servers)
		{
			BaselibQosRunner.<MeasureQosAsync>d__4 <MeasureQosAsync>d__;
			<MeasureQosAsync>d__.<>t__builder = AsyncTaskMethodBuilder<List<QosAnnotatedResult>>.Create();
			<MeasureQosAsync>d__.<>4__this = this;
			<MeasureQosAsync>d__.servers = servers;
			<MeasureQosAsync>d__.<>1__state = -1;
			<MeasureQosAsync>d__.<>t__builder.Start<BaselibQosRunner.<MeasureQosAsync>d__4>(ref <MeasureQosAsync>d__);
			return <MeasureQosAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00006284 File Offset: 0x00004484
		public Task<List<ValueTuple<Unity.Services.Qos.V2.Models.QosServer, IQosMeasurements>>> MeasureQosV2Async(IList<Unity.Services.Qos.V2.Models.QosServer> servers)
		{
			BaselibQosRunner.<MeasureQosV2Async>d__6 <MeasureQosV2Async>d__;
			<MeasureQosV2Async>d__.<>t__builder = AsyncTaskMethodBuilder<List<ValueTuple<Unity.Services.Qos.V2.Models.QosServer, IQosMeasurements>>>.Create();
			<MeasureQosV2Async>d__.<>4__this = this;
			<MeasureQosV2Async>d__.servers = servers;
			<MeasureQosV2Async>d__.<>1__state = -1;
			<MeasureQosV2Async>d__.<>t__builder.Start<BaselibQosRunner.<MeasureQosV2Async>d__6>(ref <MeasureQosV2Async>d__);
			return <MeasureQosV2Async>d__.<>t__builder.Task;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x000062D0 File Offset: 0x000044D0
		private Task<IQosJob> RunQosJob(List<UcgQosServer> convertedServers)
		{
			BaselibQosRunner.<RunQosJob>d__7 <RunQosJob>d__;
			<RunQosJob>d__.<>t__builder = AsyncTaskMethodBuilder<IQosJob>.Create();
			<RunQosJob>d__.<>4__this = this;
			<RunQosJob>d__.convertedServers = convertedServers;
			<RunQosJob>d__.<>1__state = -1;
			<RunQosJob>d__.<>t__builder.Start<BaselibQosRunner.<RunQosJob>d__7>(ref <RunQosJob>d__);
			return <RunQosJob>d__.<>t__builder.Task;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000631C File Offset: 0x0000451C
		private Task<UcgQosServer?> ToUcgFormat(Unity.Services.Qos.Models.QosServer server)
		{
			BaselibQosRunner.<ToUcgFormat>d__8 <ToUcgFormat>d__;
			<ToUcgFormat>d__.<>t__builder = AsyncTaskMethodBuilder<UcgQosServer?>.Create();
			<ToUcgFormat>d__.<>4__this = this;
			<ToUcgFormat>d__.server = server;
			<ToUcgFormat>d__.<>1__state = -1;
			<ToUcgFormat>d__.<>t__builder.Start<BaselibQosRunner.<ToUcgFormat>d__8>(ref <ToUcgFormat>d__);
			return <ToUcgFormat>d__.<>t__builder.Task;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00006368 File Offset: 0x00004568
		private Task<UcgQosServer?> ToUcgFormat(QosServiceServer server)
		{
			BaselibQosRunner.<ToUcgFormat>d__9 <ToUcgFormat>d__;
			<ToUcgFormat>d__.<>t__builder = AsyncTaskMethodBuilder<UcgQosServer?>.Create();
			<ToUcgFormat>d__.<>4__this = this;
			<ToUcgFormat>d__.server = server;
			<ToUcgFormat>d__.<>1__state = -1;
			<ToUcgFormat>d__.<>t__builder.Start<BaselibQosRunner.<ToUcgFormat>d__9>(ref <ToUcgFormat>d__);
			return <ToUcgFormat>d__.<>t__builder.Task;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000063B4 File Offset: 0x000045B4
		private Task<UcgQosServer?> ToUcgFormat(string serverEndpoint, string serverRegion)
		{
			BaselibQosRunner.<ToUcgFormat>d__10 <ToUcgFormat>d__;
			<ToUcgFormat>d__.<>t__builder = AsyncTaskMethodBuilder<UcgQosServer?>.Create();
			<ToUcgFormat>d__.<>4__this = this;
			<ToUcgFormat>d__.serverEndpoint = serverEndpoint;
			<ToUcgFormat>d__.serverRegion = serverRegion;
			<ToUcgFormat>d__.<>1__state = -1;
			<ToUcgFormat>d__.<>t__builder.Start<BaselibQosRunner.<ToUcgFormat>d__10>(ref <ToUcgFormat>d__);
			return <ToUcgFormat>d__.<>t__builder.Task;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00006408 File Offset: 0x00004608
		private static List<QosResult> ParseResults(IEnumerable<InternalQosResult> ucgResults, IEnumerable<Unity.Services.Qos.Models.QosServer> servers)
		{
			List<QosResult> list = new List<QosResult>();
			List<QosResult> result;
			using (IEnumerator<Unity.Services.Qos.Models.QosServer> enumerator = servers.GetEnumerator())
			{
				foreach (InternalQosResult internalQosResult in ucgResults)
				{
					enumerator.MoveNext();
					if (enumerator.Current == null)
					{
						break;
					}
					int averageLatencyMs = (int)((internalQosResult.AverageLatencyMs > 2147483647U) ? 2147483647U : internalQosResult.AverageLatencyMs);
					list.Add(new QosResult
					{
						Region = enumerator.Current.Region,
						AverageLatencyMs = averageLatencyMs,
						PacketLossPercent = internalQosResult.PacketLoss
					});
				}
				result = list;
			}
			return result;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000064DC File Offset: 0x000046DC
		private static List<QosAnnotatedResult> ParseResults(IEnumerable<InternalQosResult> ucgResults, IEnumerable<QosServiceServer> servers)
		{
			List<QosAnnotatedResult> list = new List<QosAnnotatedResult>();
			List<QosAnnotatedResult> result;
			using (IEnumerator<QosServiceServer> enumerator = servers.GetEnumerator())
			{
				foreach (InternalQosResult internalQosResult in ucgResults)
				{
					enumerator.MoveNext();
					if (enumerator.Current == null)
					{
						break;
					}
					int averageLatencyMs = (int)((internalQosResult.AverageLatencyMs > 2147483647U) ? 2147483647U : internalQosResult.AverageLatencyMs);
					list.Add(new QosAnnotatedResult
					{
						Region = enumerator.Current.Region,
						AverageLatencyMs = averageLatencyMs,
						PacketLossPercent = internalQosResult.PacketLoss,
						Annotations = enumerator.Current.Annotations
					});
				}
				result = list;
			}
			return result;
		}

		// Token: 0x040000B0 RID: 176
		private QosJobProvider _qosJobProvider = (IList<UcgQosServer> servers, string title) => new QosJob(servers, title, 5U, 10000UL, 500UL, 10U, 1U, 10U);

		// Token: 0x040000B1 RID: 177
		private DnsResolver _dnsResolver = new DnsResolver(Dns.GetHostAddressesAsync);

		// Token: 0x02000097 RID: 151
		internal struct QosMeasurementImpl : IQosMeasurements
		{
			// Token: 0x060002B5 RID: 693 RVA: 0x0000A37E File Offset: 0x0000857E
			public QosMeasurementImpl(int averageLatencyMs, float packetLossPercent)
			{
				this.AverageLatencyMs = averageLatencyMs;
				this.PacketLossPercent = packetLossPercent;
			}

			// Token: 0x17000093 RID: 147
			// (get) Token: 0x060002B6 RID: 694 RVA: 0x0000A38E File Offset: 0x0000858E
			public readonly int AverageLatencyMs { get; }

			// Token: 0x17000094 RID: 148
			// (get) Token: 0x060002B7 RID: 695 RVA: 0x0000A396 File Offset: 0x00008596
			public readonly float PacketLossPercent { get; }
		}
	}
}
