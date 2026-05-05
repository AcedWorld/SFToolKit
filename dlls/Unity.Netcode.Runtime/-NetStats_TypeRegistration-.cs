using System;
using Unity.Multiplayer.Tools.MetricTypes;
using Unity.Multiplayer.Tools.NetStats;

// Token: 0x0200013A RID: 314
public class <NetStats_TypeRegistration>
{
	// Token: 0x060009B8 RID: 2488 RVA: 0x000251C3 File Offset: 0x000233C3
	static void Run()
	{
		EventMetricFactory.RegisterType<NetworkMessageEvent>();
		EventMetricFactory.RegisterType<NamedMessageEvent>();
		EventMetricFactory.RegisterType<UnnamedMessageEvent>();
		EventMetricFactory.RegisterType<NetworkVariableEvent>();
		EventMetricFactory.RegisterType<OwnershipChangeEvent>();
		EventMetricFactory.RegisterType<ObjectSpawnedEvent>();
		EventMetricFactory.RegisterType<ObjectDestroyedEvent>();
		EventMetricFactory.RegisterType<RpcEvent>();
		EventMetricFactory.RegisterType<ServerLogEvent>();
		EventMetricFactory.RegisterType<SceneEventMetric>();
	}
}
