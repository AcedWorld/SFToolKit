using System;
using Unity.Multiplayer.Tools.MetricTypes;
using Unity.Multiplayer.Tools.NetStats;

// Token: 0x02000009 RID: 9
public class <NetStats_TypeRegistration>
{
	// Token: 0x06000040 RID: 64 RVA: 0x000026AD File Offset: 0x000008AD
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
