using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Services.Authentication.Internal;
using Unity.Services.Lobbies.Http;
using Unity.Services.Lobbies.Lobby;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies.Apis.Lobby
{
	// Token: 0x02000079 RID: 121
	internal class LobbyApiClient : BaseApiClient, ILobbyApiClient
	{
		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600034C RID: 844 RVA: 0x0000BE38 File Offset: 0x0000A038
		// (set) Token: 0x0600034D RID: 845 RVA: 0x0000BE6A File Offset: 0x0000A06A
		public Configuration Configuration
		{
			get
			{
				Configuration b = new Configuration("https://lobby.services.api.unity.com/v1", new int?(10), new int?(4), null);
				return Configuration.MergeConfigurations(this._configuration, b);
			}
			set
			{
				this._configuration = value;
			}
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0000BE73 File Offset: 0x0000A073
		public LobbyApiClient(IHttpClient httpClient, IAccessToken accessToken, Configuration configuration = null) : base(httpClient)
		{
			this._configuration = configuration;
			this._accessToken = accessToken;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000BE8C File Offset: 0x0000A08C
		public Task<Response<Lobby>> BulkUpdateLobbyAsync(BulkUpdateLobbyRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<BulkUpdateLobbyAsync>d__7 <BulkUpdateLobbyAsync>d__;
			<BulkUpdateLobbyAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<Lobby>>.Create();
			<BulkUpdateLobbyAsync>d__.<>4__this = this;
			<BulkUpdateLobbyAsync>d__.request = request;
			<BulkUpdateLobbyAsync>d__.operationConfiguration = operationConfiguration;
			<BulkUpdateLobbyAsync>d__.<>1__state = -1;
			<BulkUpdateLobbyAsync>d__.<>t__builder.Start<LobbyApiClient.<BulkUpdateLobbyAsync>d__7>(ref <BulkUpdateLobbyAsync>d__);
			return <BulkUpdateLobbyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0000BEE0 File Offset: 0x0000A0E0
		public Task<Response<Lobby>> CreateLobbyAsync(CreateLobbyRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<CreateLobbyAsync>d__8 <CreateLobbyAsync>d__;
			<CreateLobbyAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<Lobby>>.Create();
			<CreateLobbyAsync>d__.<>4__this = this;
			<CreateLobbyAsync>d__.request = request;
			<CreateLobbyAsync>d__.operationConfiguration = operationConfiguration;
			<CreateLobbyAsync>d__.<>1__state = -1;
			<CreateLobbyAsync>d__.<>t__builder.Start<LobbyApiClient.<CreateLobbyAsync>d__8>(ref <CreateLobbyAsync>d__);
			return <CreateLobbyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000BF34 File Offset: 0x0000A134
		public Task<Response<Lobby>> CreateOrJoinLobbyAsync(CreateOrJoinLobbyRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<CreateOrJoinLobbyAsync>d__9 <CreateOrJoinLobbyAsync>d__;
			<CreateOrJoinLobbyAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<Lobby>>.Create();
			<CreateOrJoinLobbyAsync>d__.<>4__this = this;
			<CreateOrJoinLobbyAsync>d__.request = request;
			<CreateOrJoinLobbyAsync>d__.operationConfiguration = operationConfiguration;
			<CreateOrJoinLobbyAsync>d__.<>1__state = -1;
			<CreateOrJoinLobbyAsync>d__.<>t__builder.Start<LobbyApiClient.<CreateOrJoinLobbyAsync>d__9>(ref <CreateOrJoinLobbyAsync>d__);
			return <CreateOrJoinLobbyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000BF88 File Offset: 0x0000A188
		public Task<Response> DeleteLobbyAsync(DeleteLobbyRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<DeleteLobbyAsync>d__10 <DeleteLobbyAsync>d__;
			<DeleteLobbyAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response>.Create();
			<DeleteLobbyAsync>d__.<>4__this = this;
			<DeleteLobbyAsync>d__.request = request;
			<DeleteLobbyAsync>d__.operationConfiguration = operationConfiguration;
			<DeleteLobbyAsync>d__.<>1__state = -1;
			<DeleteLobbyAsync>d__.<>t__builder.Start<LobbyApiClient.<DeleteLobbyAsync>d__10>(ref <DeleteLobbyAsync>d__);
			return <DeleteLobbyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000BFDC File Offset: 0x0000A1DC
		public Task<Response<List<string>>> GetHostedLobbiesAsync(GetHostedLobbiesRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<GetHostedLobbiesAsync>d__11 <GetHostedLobbiesAsync>d__;
			<GetHostedLobbiesAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<List<string>>>.Create();
			<GetHostedLobbiesAsync>d__.<>4__this = this;
			<GetHostedLobbiesAsync>d__.request = request;
			<GetHostedLobbiesAsync>d__.operationConfiguration = operationConfiguration;
			<GetHostedLobbiesAsync>d__.<>1__state = -1;
			<GetHostedLobbiesAsync>d__.<>t__builder.Start<LobbyApiClient.<GetHostedLobbiesAsync>d__11>(ref <GetHostedLobbiesAsync>d__);
			return <GetHostedLobbiesAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0000C030 File Offset: 0x0000A230
		public Task<Response<List<string>>> GetJoinedLobbiesAsync(GetJoinedLobbiesRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<GetJoinedLobbiesAsync>d__12 <GetJoinedLobbiesAsync>d__;
			<GetJoinedLobbiesAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<List<string>>>.Create();
			<GetJoinedLobbiesAsync>d__.<>4__this = this;
			<GetJoinedLobbiesAsync>d__.request = request;
			<GetJoinedLobbiesAsync>d__.operationConfiguration = operationConfiguration;
			<GetJoinedLobbiesAsync>d__.<>1__state = -1;
			<GetJoinedLobbiesAsync>d__.<>t__builder.Start<LobbyApiClient.<GetJoinedLobbiesAsync>d__12>(ref <GetJoinedLobbiesAsync>d__);
			return <GetJoinedLobbiesAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0000C084 File Offset: 0x0000A284
		public Task<Response<Lobby>> GetLobbyAsync(GetLobbyRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<GetLobbyAsync>d__13 <GetLobbyAsync>d__;
			<GetLobbyAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<Lobby>>.Create();
			<GetLobbyAsync>d__.<>4__this = this;
			<GetLobbyAsync>d__.request = request;
			<GetLobbyAsync>d__.operationConfiguration = operationConfiguration;
			<GetLobbyAsync>d__.<>1__state = -1;
			<GetLobbyAsync>d__.<>t__builder.Start<LobbyApiClient.<GetLobbyAsync>d__13>(ref <GetLobbyAsync>d__);
			return <GetLobbyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000C0D8 File Offset: 0x0000A2D8
		public Task<Response> HeartbeatAsync(HeartbeatRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<HeartbeatAsync>d__14 <HeartbeatAsync>d__;
			<HeartbeatAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response>.Create();
			<HeartbeatAsync>d__.<>4__this = this;
			<HeartbeatAsync>d__.request = request;
			<HeartbeatAsync>d__.operationConfiguration = operationConfiguration;
			<HeartbeatAsync>d__.<>1__state = -1;
			<HeartbeatAsync>d__.<>t__builder.Start<LobbyApiClient.<HeartbeatAsync>d__14>(ref <HeartbeatAsync>d__);
			return <HeartbeatAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000C12C File Offset: 0x0000A32C
		public Task<Response<Lobby>> JoinLobbyByCodeAsync(JoinLobbyByCodeRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<JoinLobbyByCodeAsync>d__15 <JoinLobbyByCodeAsync>d__;
			<JoinLobbyByCodeAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<Lobby>>.Create();
			<JoinLobbyByCodeAsync>d__.<>4__this = this;
			<JoinLobbyByCodeAsync>d__.request = request;
			<JoinLobbyByCodeAsync>d__.operationConfiguration = operationConfiguration;
			<JoinLobbyByCodeAsync>d__.<>1__state = -1;
			<JoinLobbyByCodeAsync>d__.<>t__builder.Start<LobbyApiClient.<JoinLobbyByCodeAsync>d__15>(ref <JoinLobbyByCodeAsync>d__);
			return <JoinLobbyByCodeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0000C180 File Offset: 0x0000A380
		public Task<Response<Lobby>> JoinLobbyByIdAsync(JoinLobbyByIdRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<JoinLobbyByIdAsync>d__16 <JoinLobbyByIdAsync>d__;
			<JoinLobbyByIdAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<Lobby>>.Create();
			<JoinLobbyByIdAsync>d__.<>4__this = this;
			<JoinLobbyByIdAsync>d__.request = request;
			<JoinLobbyByIdAsync>d__.operationConfiguration = operationConfiguration;
			<JoinLobbyByIdAsync>d__.<>1__state = -1;
			<JoinLobbyByIdAsync>d__.<>t__builder.Start<LobbyApiClient.<JoinLobbyByIdAsync>d__16>(ref <JoinLobbyByIdAsync>d__);
			return <JoinLobbyByIdAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000C1D4 File Offset: 0x0000A3D4
		public Task<Response<QueryResponse>> QueryLobbiesAsync(QueryLobbiesRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<QueryLobbiesAsync>d__17 <QueryLobbiesAsync>d__;
			<QueryLobbiesAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<QueryResponse>>.Create();
			<QueryLobbiesAsync>d__.<>4__this = this;
			<QueryLobbiesAsync>d__.request = request;
			<QueryLobbiesAsync>d__.operationConfiguration = operationConfiguration;
			<QueryLobbiesAsync>d__.<>1__state = -1;
			<QueryLobbiesAsync>d__.<>t__builder.Start<LobbyApiClient.<QueryLobbiesAsync>d__17>(ref <QueryLobbiesAsync>d__);
			return <QueryLobbiesAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000C228 File Offset: 0x0000A428
		public Task<Response<Lobby>> QuickJoinLobbyAsync(QuickJoinLobbyRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<QuickJoinLobbyAsync>d__18 <QuickJoinLobbyAsync>d__;
			<QuickJoinLobbyAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<Lobby>>.Create();
			<QuickJoinLobbyAsync>d__.<>4__this = this;
			<QuickJoinLobbyAsync>d__.request = request;
			<QuickJoinLobbyAsync>d__.operationConfiguration = operationConfiguration;
			<QuickJoinLobbyAsync>d__.<>1__state = -1;
			<QuickJoinLobbyAsync>d__.<>t__builder.Start<LobbyApiClient.<QuickJoinLobbyAsync>d__18>(ref <QuickJoinLobbyAsync>d__);
			return <QuickJoinLobbyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0000C27C File Offset: 0x0000A47C
		public Task<Response<Lobby>> ReconnectAsync(ReconnectRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<ReconnectAsync>d__19 <ReconnectAsync>d__;
			<ReconnectAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<Lobby>>.Create();
			<ReconnectAsync>d__.<>4__this = this;
			<ReconnectAsync>d__.request = request;
			<ReconnectAsync>d__.operationConfiguration = operationConfiguration;
			<ReconnectAsync>d__.<>1__state = -1;
			<ReconnectAsync>d__.<>t__builder.Start<LobbyApiClient.<ReconnectAsync>d__19>(ref <ReconnectAsync>d__);
			return <ReconnectAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000C2D0 File Offset: 0x0000A4D0
		public Task<Response> RemovePlayerAsync(RemovePlayerRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<RemovePlayerAsync>d__20 <RemovePlayerAsync>d__;
			<RemovePlayerAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response>.Create();
			<RemovePlayerAsync>d__.<>4__this = this;
			<RemovePlayerAsync>d__.request = request;
			<RemovePlayerAsync>d__.operationConfiguration = operationConfiguration;
			<RemovePlayerAsync>d__.<>1__state = -1;
			<RemovePlayerAsync>d__.<>t__builder.Start<LobbyApiClient.<RemovePlayerAsync>d__20>(ref <RemovePlayerAsync>d__);
			return <RemovePlayerAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0000C324 File Offset: 0x0000A524
		public Task<Response<Dictionary<string, TokenData>>> RequestTokensAsync(RequestTokensRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<RequestTokensAsync>d__21 <RequestTokensAsync>d__;
			<RequestTokensAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<Dictionary<string, TokenData>>>.Create();
			<RequestTokensAsync>d__.<>4__this = this;
			<RequestTokensAsync>d__.request = request;
			<RequestTokensAsync>d__.operationConfiguration = operationConfiguration;
			<RequestTokensAsync>d__.<>1__state = -1;
			<RequestTokensAsync>d__.<>t__builder.Start<LobbyApiClient.<RequestTokensAsync>d__21>(ref <RequestTokensAsync>d__);
			return <RequestTokensAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000C378 File Offset: 0x0000A578
		public Task<Response<Lobby>> UpdateLobbyAsync(UpdateLobbyRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<UpdateLobbyAsync>d__22 <UpdateLobbyAsync>d__;
			<UpdateLobbyAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<Lobby>>.Create();
			<UpdateLobbyAsync>d__.<>4__this = this;
			<UpdateLobbyAsync>d__.request = request;
			<UpdateLobbyAsync>d__.operationConfiguration = operationConfiguration;
			<UpdateLobbyAsync>d__.<>1__state = -1;
			<UpdateLobbyAsync>d__.<>t__builder.Start<LobbyApiClient.<UpdateLobbyAsync>d__22>(ref <UpdateLobbyAsync>d__);
			return <UpdateLobbyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0000C3CC File Offset: 0x0000A5CC
		public Task<Response<Lobby>> UpdatePlayerAsync(UpdatePlayerRequest request, Configuration operationConfiguration = null)
		{
			LobbyApiClient.<UpdatePlayerAsync>d__23 <UpdatePlayerAsync>d__;
			<UpdatePlayerAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<Lobby>>.Create();
			<UpdatePlayerAsync>d__.<>4__this = this;
			<UpdatePlayerAsync>d__.request = request;
			<UpdatePlayerAsync>d__.operationConfiguration = operationConfiguration;
			<UpdatePlayerAsync>d__.<>1__state = -1;
			<UpdatePlayerAsync>d__.<>t__builder.Start<LobbyApiClient.<UpdatePlayerAsync>d__23>(ref <UpdatePlayerAsync>d__);
			return <UpdatePlayerAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04000181 RID: 385
		private IAccessToken _accessToken;

		// Token: 0x04000182 RID: 386
		private const int _baseTimeout = 10;

		// Token: 0x04000183 RID: 387
		private Configuration _configuration;
	}
}
