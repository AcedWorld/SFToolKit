using System;
using System.Threading.Tasks;
using Unity.Services.Qos.V2.Models;
using Unity.Services.Qos.V2.QosDiscovery;

namespace Unity.Services.Qos.V2.Apis.QosDiscovery
{
	// Token: 0x02000048 RID: 72
	internal interface IQosDiscoveryApiClient
	{
		// Token: 0x0600015D RID: 349
		Task<Response<QosServersResponseBody>> GetAllServersAsync(GetAllServersRequest request, Configuration operationConfiguration = null);
	}
}
