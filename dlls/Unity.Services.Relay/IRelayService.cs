using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Relay.Models;

namespace Unity.Services.Relay
{
	// Token: 0x0200000F RID: 15
	public interface IRelayService
	{
		// Token: 0x0600002F RID: 47
		Task<Allocation> CreateAllocationAsync(int maxConnections, string region = null);

		// Token: 0x06000030 RID: 48
		Task<string> GetJoinCodeAsync(Guid allocationId);

		// Token: 0x06000031 RID: 49
		Task<JoinAllocation> JoinAllocationAsync(string joinCode);

		// Token: 0x06000032 RID: 50
		Task<List<Region>> ListRegionsAsync();
	}
}
