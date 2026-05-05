using System;
using Unity.Multiplayer.Tools.MetricEvents;
using UnityEngine;

namespace Unity.Multiplayer.Tools.Adapters.Ngo1
{
	// Token: 0x02000006 RID: 6
	internal static class Ngo1AdapterInitializer
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00002265 File Offset: 0x00000465
		[RuntimeInitializeOnLoadMethod]
		private static void InitializeAdapter()
		{
			Ngo1Adapter ngo1Adapter = new Ngo1Adapter();
			MetricEventPublisher.OnMetricsReceived += ngo1Adapter.OnMetricsReceived;
			NetworkAdapters.AddAdapter(ngo1Adapter);
		}
	}
}
