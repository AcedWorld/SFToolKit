using System;
using Unity.Collections;
using Unity.Jobs;
using Unity.Networking.QoS;

namespace Unity.Services.Qos.Runner
{
	// Token: 0x0200004F RID: 79
	internal interface IQosJob : IJob
	{
		// Token: 0x06000179 RID: 377
		JobHandle Schedule<T>(JobHandle dependsOn = default(JobHandle)) where T : struct, IJob;

		// Token: 0x0600017A RID: 378
		void Dispose();

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600017B RID: 379
		NativeArray<InternalQosResult> QosResults { get; }
	}
}
