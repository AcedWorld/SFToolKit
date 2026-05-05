using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Qos.Internal;
using Unity.Services.Qos.Models;
using Unity.Services.Qos.V2.Models;

namespace Unity.Services.Qos.Runner
{
	// Token: 0x02000050 RID: 80
	internal interface IQosRunner
	{
		// Token: 0x0600017C RID: 380
		Task<List<QosResult>> MeasureQosAsync(IList<Unity.Services.Qos.Models.QosServer> servers);

		// Token: 0x0600017D RID: 381
		Task<List<QosAnnotatedResult>> MeasureQosAsync(IList<QosServiceServer> servers);

		// Token: 0x0600017E RID: 382
		Task<List<ValueTuple<Unity.Services.Qos.V2.Models.QosServer, IQosMeasurements>>> MeasureQosV2Async(IList<Unity.Services.Qos.V2.Models.QosServer> servers);
	}
}
