using System;
using System.Threading.Tasks;
using Unity.Services.Qos.Models;
using Unity.Services.Qos.QosDiscovery;

namespace Unity.Services.Qos.Apis.QosDiscovery
{
	// Token: 0x02000079 RID: 121
	internal interface IQosDiscoveryApiClient
	{
		// Token: 0x0600025B RID: 603
		Task<Response<QosServersResponseBody>> GetServersAsync(GetServersRequest request, Configuration operationConfiguration = null);

		// Token: 0x0600025C RID: 604
		Task<Response<QosServiceServersResponseBody>> GetServiceServersAsync(GetServiceServersRequest request, Configuration operationConfiguration = null);
	}
}
