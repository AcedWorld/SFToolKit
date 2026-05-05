using System;
using Unity.Collections;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000032 RID: 50
	internal interface INetStatSerializer
	{
		// Token: 0x06000141 RID: 321
		NativeArray<byte> Serialize(MetricCollection metricCollection);

		// Token: 0x06000142 RID: 322
		MetricCollection Deserialize(NativeArray<byte> bytes);
	}
}
