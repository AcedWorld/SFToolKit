using System;
using Unity.Collections;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000014 RID: 20
	internal interface IMetric
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600004E RID: 78
		string Name { get; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004F RID: 79
		MetricId Id { get; }

		// Token: 0x06000050 RID: 80
		int GetWriteSize();

		// Token: 0x06000051 RID: 81
		void Write(FastBufferWriter writer);

		// Token: 0x06000052 RID: 82
		void Read(FastBufferReader reader);

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000053 RID: 83
		MetricContainerType MetricContainerType { get; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000054 RID: 84
		FixedString128Bytes FactoryTypeName { get; }
	}
}
