using System;
using System.Threading.Tasks;
using Unity.Services.Relay.Models;
using Unity.Services.Relay.RelayAllocations;

namespace Unity.Services.Relay.Apis.RelayAllocations
{
	// Token: 0x02000051 RID: 81
	internal interface IRelayAllocationsApiClient
	{
		// Token: 0x06000183 RID: 387
		Task<Response<AllocateResponseBody>> CreateAllocationAsync(CreateAllocationRequest request, Configuration operationConfiguration = null);

		// Token: 0x06000184 RID: 388
		Task<Response<JoinCodeResponseBody>> CreateJoincodeAsync(CreateJoincodeRequest request, Configuration operationConfiguration = null);

		// Token: 0x06000185 RID: 389
		Task<Response<JoinResponseBody>> JoinRelayAsync(JoinRelayRequest request, Configuration operationConfiguration = null);

		// Token: 0x06000186 RID: 390
		Task<Response<RegionsResponseBody>> ListRegionsAsync(ListRegionsRequest request, Configuration operationConfiguration = null);
	}
}
