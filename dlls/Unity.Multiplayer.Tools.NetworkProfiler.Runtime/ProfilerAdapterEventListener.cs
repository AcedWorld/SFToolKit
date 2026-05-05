using System;
using System.Diagnostics;
using Unity.Multiplayer.Tools.Adapters;
using Unity.Multiplayer.Tools.NetStats;
using UnityEngine;

namespace Unity.Multiplayer.Tools.NetworkProfiler.Runtime
{
	// Token: 0x0200000F RID: 15
	internal static class ProfilerAdapterEventListener
	{
		// Token: 0x06000028 RID: 40 RVA: 0x000027B8 File Offset: 0x000009B8
		[RuntimeInitializeOnLoadMethod]
		private static void SubscribeToAdapterAndMetricEvents()
		{
			NetworkAdapters.SubscribeToAll(new Action<INetworkAdapter>(ProfilerAdapterEventListener.OnAdapterAdded), new Action<INetworkAdapter>(ProfilerAdapterEventListener.OnAdapterRemoved));
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000027D8 File Offset: 0x000009D8
		private static void OnAdapterAdded(INetworkAdapter adapter)
		{
			IMetricCollectionEvent component = adapter.GetComponent<IMetricCollectionEvent>();
			if (component != null)
			{
				component.MetricCollectionEvent += ProfilerAdapterEventListener.OnMetricsReceived;
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002804 File Offset: 0x00000A04
		private static void OnAdapterRemoved(INetworkAdapter adapter)
		{
			IMetricCollectionEvent component = adapter.GetComponent<IMetricCollectionEvent>();
			if (component != null)
			{
				component.MetricCollectionEvent -= ProfilerAdapterEventListener.OnMetricsReceived;
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000282D File Offset: 0x00000A2D
		private static void OnMetricsReceived(MetricCollection metricCollection)
		{
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002830 File Offset: 0x00000A30
		[Conditional("ENABLE_PROFILER")]
		private static void PopulateProfilerIfEnabled(MetricCollection collection)
		{
			ProfilerCounters.Instance.UpdateFromMetrics(collection);
			using (ProfilerAdapterEventListener.s_NetStatSerializer.Serialize(collection))
			{
			}
		}

		// Token: 0x0400001F RID: 31
		private static readonly NetStatSerializer s_NetStatSerializer = new NetStatSerializer();
	}
}
