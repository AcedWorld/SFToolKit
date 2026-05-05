using System;
using System.Threading;
using System.Threading.Tasks;
using Unity.Services.Authentication.Shared;

namespace Unity.Services.Authentication.Generated
{
	// Token: 0x02000069 RID: 105
	internal interface IPlayerNamesApi : IApiAccessor
	{
		// Token: 0x060002EB RID: 747
		Task<ApiResponse<Player>> GetNameAsync(string playerId, bool? autoGenerate = null, bool? showMetadata = null, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060002EC RID: 748
		Task<ApiResponse<Player>> UpdateNameAsync(string playerId, UpdateNameRequest updateNameRequest, CancellationToken cancellationToken = default(CancellationToken));
	}
}
