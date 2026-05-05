using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Lobbies.Lobby;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies.Apis.Lobby
{
	// Token: 0x02000078 RID: 120
	internal interface ILobbyApiClient
	{
		// Token: 0x0600033B RID: 827
		Task<Response<Lobby>> BulkUpdateLobbyAsync(BulkUpdateLobbyRequest request, Configuration operationConfiguration = null);

		// Token: 0x0600033C RID: 828
		Task<Response<Lobby>> CreateLobbyAsync(CreateLobbyRequest request, Configuration operationConfiguration = null);

		// Token: 0x0600033D RID: 829
		Task<Response<Lobby>> CreateOrJoinLobbyAsync(CreateOrJoinLobbyRequest request, Configuration operationConfiguration = null);

		// Token: 0x0600033E RID: 830
		Task<Response> DeleteLobbyAsync(DeleteLobbyRequest request, Configuration operationConfiguration = null);

		// Token: 0x0600033F RID: 831
		Task<Response<List<string>>> GetHostedLobbiesAsync(GetHostedLobbiesRequest request, Configuration operationConfiguration = null);

		// Token: 0x06000340 RID: 832
		Task<Response<List<string>>> GetJoinedLobbiesAsync(GetJoinedLobbiesRequest request, Configuration operationConfiguration = null);

		// Token: 0x06000341 RID: 833
		Task<Response<Lobby>> GetLobbyAsync(GetLobbyRequest request, Configuration operationConfiguration = null);

		// Token: 0x06000342 RID: 834
		Task<Response> HeartbeatAsync(HeartbeatRequest request, Configuration operationConfiguration = null);

		// Token: 0x06000343 RID: 835
		Task<Response<Lobby>> JoinLobbyByCodeAsync(JoinLobbyByCodeRequest request, Configuration operationConfiguration = null);

		// Token: 0x06000344 RID: 836
		Task<Response<Lobby>> JoinLobbyByIdAsync(JoinLobbyByIdRequest request, Configuration operationConfiguration = null);

		// Token: 0x06000345 RID: 837
		Task<Response<QueryResponse>> QueryLobbiesAsync(QueryLobbiesRequest request, Configuration operationConfiguration = null);

		// Token: 0x06000346 RID: 838
		Task<Response<Lobby>> QuickJoinLobbyAsync(QuickJoinLobbyRequest request, Configuration operationConfiguration = null);

		// Token: 0x06000347 RID: 839
		Task<Response<Lobby>> ReconnectAsync(ReconnectRequest request, Configuration operationConfiguration = null);

		// Token: 0x06000348 RID: 840
		Task<Response> RemovePlayerAsync(RemovePlayerRequest request, Configuration operationConfiguration = null);

		// Token: 0x06000349 RID: 841
		Task<Response<Dictionary<string, TokenData>>> RequestTokensAsync(RequestTokensRequest request, Configuration operationConfiguration = null);

		// Token: 0x0600034A RID: 842
		Task<Response<Lobby>> UpdateLobbyAsync(UpdateLobbyRequest request, Configuration operationConfiguration = null);

		// Token: 0x0600034B RID: 843
		Task<Response<Lobby>> UpdatePlayerAsync(UpdatePlayerRequest request, Configuration operationConfiguration = null);
	}
}
