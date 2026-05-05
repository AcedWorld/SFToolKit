using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Services.Lobbies.Http;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies.Internal
{
	// Token: 0x0200002A RID: 42
	internal class WrappedLobbyService : ILobbyService, ILobbyServiceSDK, ILobbyServiceSDKConfiguration, ILobbyServiceInternal
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000126 RID: 294 RVA: 0x000055C3 File Offset: 0x000037C3
		internal Dictionary<string, Lobby> JoinedLobbyCache { get; }

		// Token: 0x06000127 RID: 295 RVA: 0x000055CB File Offset: 0x000037CB
		internal WrappedLobbyService(ILobbyServiceSdk lobbyService)
		{
			this.m_LobbyService = lobbyService;
			this.m_TelemetryScopeFactory = new ApiTelemetryScopeFactory(lobbyService.Metrics);
			this.JoinedLobbyCache = new Dictionary<string, Lobby>();
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000055F8 File Offset: 0x000037F8
		public Task<Lobby> CreateLobbyAsync(string lobbyName, int maxPlayers, CreateLobbyOptions options = null)
		{
			WrappedLobbyService.<CreateLobbyAsync>d__9 <CreateLobbyAsync>d__;
			<CreateLobbyAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Lobby>.Create();
			<CreateLobbyAsync>d__.<>4__this = this;
			<CreateLobbyAsync>d__.lobbyName = lobbyName;
			<CreateLobbyAsync>d__.maxPlayers = maxPlayers;
			<CreateLobbyAsync>d__.options = options;
			<CreateLobbyAsync>d__.<>1__state = -1;
			<CreateLobbyAsync>d__.<>t__builder.Start<WrappedLobbyService.<CreateLobbyAsync>d__9>(ref <CreateLobbyAsync>d__);
			return <CreateLobbyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00005654 File Offset: 0x00003854
		public Task<Lobby> CreateOrJoinLobbyAsync(string lobbyId, string lobbyName, int maxPlayers, CreateLobbyOptions createOptions = null)
		{
			WrappedLobbyService.<CreateOrJoinLobbyAsync>d__10 <CreateOrJoinLobbyAsync>d__;
			<CreateOrJoinLobbyAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Lobby>.Create();
			<CreateOrJoinLobbyAsync>d__.<>4__this = this;
			<CreateOrJoinLobbyAsync>d__.lobbyId = lobbyId;
			<CreateOrJoinLobbyAsync>d__.lobbyName = lobbyName;
			<CreateOrJoinLobbyAsync>d__.maxPlayers = maxPlayers;
			<CreateOrJoinLobbyAsync>d__.createOptions = createOptions;
			<CreateOrJoinLobbyAsync>d__.<>1__state = -1;
			<CreateOrJoinLobbyAsync>d__.<>t__builder.Start<WrappedLobbyService.<CreateOrJoinLobbyAsync>d__10>(ref <CreateOrJoinLobbyAsync>d__);
			return <CreateOrJoinLobbyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000056B8 File Offset: 0x000038B8
		public Task<ILobbyEvents> SubscribeToLobbyEventsAsync(string lobbyId, LobbyEventCallbacks lobbyEventCallbacks)
		{
			WrappedLobbyService.<SubscribeToLobbyEventsAsync>d__11 <SubscribeToLobbyEventsAsync>d__;
			<SubscribeToLobbyEventsAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ILobbyEvents>.Create();
			<SubscribeToLobbyEventsAsync>d__.<>4__this = this;
			<SubscribeToLobbyEventsAsync>d__.lobbyId = lobbyId;
			<SubscribeToLobbyEventsAsync>d__.lobbyEventCallbacks = lobbyEventCallbacks;
			<SubscribeToLobbyEventsAsync>d__.<>1__state = -1;
			<SubscribeToLobbyEventsAsync>d__.<>t__builder.Start<WrappedLobbyService.<SubscribeToLobbyEventsAsync>d__11>(ref <SubscribeToLobbyEventsAsync>d__);
			return <SubscribeToLobbyEventsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000570C File Offset: 0x0000390C
		public Task DeleteLobbyAsync(string lobbyId)
		{
			WrappedLobbyService.<DeleteLobbyAsync>d__12 <DeleteLobbyAsync>d__;
			<DeleteLobbyAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<DeleteLobbyAsync>d__.<>4__this = this;
			<DeleteLobbyAsync>d__.lobbyId = lobbyId;
			<DeleteLobbyAsync>d__.<>1__state = -1;
			<DeleteLobbyAsync>d__.<>t__builder.Start<WrappedLobbyService.<DeleteLobbyAsync>d__12>(ref <DeleteLobbyAsync>d__);
			return <DeleteLobbyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00005758 File Offset: 0x00003958
		public Task<List<string>> GetJoinedLobbiesAsync()
		{
			WrappedLobbyService.<GetJoinedLobbiesAsync>d__13 <GetJoinedLobbiesAsync>d__;
			<GetJoinedLobbiesAsync>d__.<>t__builder = AsyncTaskMethodBuilder<List<string>>.Create();
			<GetJoinedLobbiesAsync>d__.<>4__this = this;
			<GetJoinedLobbiesAsync>d__.<>1__state = -1;
			<GetJoinedLobbiesAsync>d__.<>t__builder.Start<WrappedLobbyService.<GetJoinedLobbiesAsync>d__13>(ref <GetJoinedLobbiesAsync>d__);
			return <GetJoinedLobbiesAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000579C File Offset: 0x0000399C
		public Task<Lobby> GetLobbyAsync(string lobbyId)
		{
			WrappedLobbyService.<GetLobbyAsync>d__14 <GetLobbyAsync>d__;
			<GetLobbyAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Lobby>.Create();
			<GetLobbyAsync>d__.<>4__this = this;
			<GetLobbyAsync>d__.lobbyId = lobbyId;
			<GetLobbyAsync>d__.<>1__state = -1;
			<GetLobbyAsync>d__.<>t__builder.Start<WrappedLobbyService.<GetLobbyAsync>d__14>(ref <GetLobbyAsync>d__);
			return <GetLobbyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000057E8 File Offset: 0x000039E8
		public Task SendHeartbeatPingAsync(string lobbyId)
		{
			WrappedLobbyService.<SendHeartbeatPingAsync>d__15 <SendHeartbeatPingAsync>d__;
			<SendHeartbeatPingAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SendHeartbeatPingAsync>d__.<>4__this = this;
			<SendHeartbeatPingAsync>d__.lobbyId = lobbyId;
			<SendHeartbeatPingAsync>d__.<>1__state = -1;
			<SendHeartbeatPingAsync>d__.<>t__builder.Start<WrappedLobbyService.<SendHeartbeatPingAsync>d__15>(ref <SendHeartbeatPingAsync>d__);
			return <SendHeartbeatPingAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00005834 File Offset: 0x00003A34
		public Task<Lobby> JoinLobbyByCodeAsync(string lobbyCode, JoinLobbyByCodeOptions options = null)
		{
			WrappedLobbyService.<JoinLobbyByCodeAsync>d__16 <JoinLobbyByCodeAsync>d__;
			<JoinLobbyByCodeAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Lobby>.Create();
			<JoinLobbyByCodeAsync>d__.<>4__this = this;
			<JoinLobbyByCodeAsync>d__.lobbyCode = lobbyCode;
			<JoinLobbyByCodeAsync>d__.options = options;
			<JoinLobbyByCodeAsync>d__.<>1__state = -1;
			<JoinLobbyByCodeAsync>d__.<>t__builder.Start<WrappedLobbyService.<JoinLobbyByCodeAsync>d__16>(ref <JoinLobbyByCodeAsync>d__);
			return <JoinLobbyByCodeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00005888 File Offset: 0x00003A88
		public Task<Lobby> JoinLobbyByIdAsync(string lobbyId, JoinLobbyByIdOptions options = null)
		{
			WrappedLobbyService.<JoinLobbyByIdAsync>d__17 <JoinLobbyByIdAsync>d__;
			<JoinLobbyByIdAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Lobby>.Create();
			<JoinLobbyByIdAsync>d__.<>4__this = this;
			<JoinLobbyByIdAsync>d__.lobbyId = lobbyId;
			<JoinLobbyByIdAsync>d__.options = options;
			<JoinLobbyByIdAsync>d__.<>1__state = -1;
			<JoinLobbyByIdAsync>d__.<>t__builder.Start<WrappedLobbyService.<JoinLobbyByIdAsync>d__17>(ref <JoinLobbyByIdAsync>d__);
			return <JoinLobbyByIdAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x000058DC File Offset: 0x00003ADC
		public Task<QueryResponse> QueryLobbiesAsync(QueryLobbiesOptions options = null)
		{
			WrappedLobbyService.<QueryLobbiesAsync>d__18 <QueryLobbiesAsync>d__;
			<QueryLobbiesAsync>d__.<>t__builder = AsyncTaskMethodBuilder<QueryResponse>.Create();
			<QueryLobbiesAsync>d__.<>4__this = this;
			<QueryLobbiesAsync>d__.options = options;
			<QueryLobbiesAsync>d__.<>1__state = -1;
			<QueryLobbiesAsync>d__.<>t__builder.Start<WrappedLobbyService.<QueryLobbiesAsync>d__18>(ref <QueryLobbiesAsync>d__);
			return <QueryLobbiesAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00005928 File Offset: 0x00003B28
		public Task<Lobby> QuickJoinLobbyAsync(QuickJoinLobbyOptions options = null)
		{
			WrappedLobbyService.<QuickJoinLobbyAsync>d__19 <QuickJoinLobbyAsync>d__;
			<QuickJoinLobbyAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Lobby>.Create();
			<QuickJoinLobbyAsync>d__.<>4__this = this;
			<QuickJoinLobbyAsync>d__.options = options;
			<QuickJoinLobbyAsync>d__.<>1__state = -1;
			<QuickJoinLobbyAsync>d__.<>t__builder.Start<WrappedLobbyService.<QuickJoinLobbyAsync>d__19>(ref <QuickJoinLobbyAsync>d__);
			return <QuickJoinLobbyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00005974 File Offset: 0x00003B74
		public Task RemovePlayerAsync(string lobbyId, string playerId)
		{
			WrappedLobbyService.<RemovePlayerAsync>d__20 <RemovePlayerAsync>d__;
			<RemovePlayerAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<RemovePlayerAsync>d__.<>4__this = this;
			<RemovePlayerAsync>d__.lobbyId = lobbyId;
			<RemovePlayerAsync>d__.playerId = playerId;
			<RemovePlayerAsync>d__.<>1__state = -1;
			<RemovePlayerAsync>d__.<>t__builder.Start<WrappedLobbyService.<RemovePlayerAsync>d__20>(ref <RemovePlayerAsync>d__);
			return <RemovePlayerAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x000059C8 File Offset: 0x00003BC8
		public Task<Lobby> UpdateLobbyAsync(string lobbyId, UpdateLobbyOptions options)
		{
			WrappedLobbyService.<UpdateLobbyAsync>d__21 <UpdateLobbyAsync>d__;
			<UpdateLobbyAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Lobby>.Create();
			<UpdateLobbyAsync>d__.<>4__this = this;
			<UpdateLobbyAsync>d__.lobbyId = lobbyId;
			<UpdateLobbyAsync>d__.options = options;
			<UpdateLobbyAsync>d__.<>1__state = -1;
			<UpdateLobbyAsync>d__.<>t__builder.Start<WrappedLobbyService.<UpdateLobbyAsync>d__21>(ref <UpdateLobbyAsync>d__);
			return <UpdateLobbyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00005A1C File Offset: 0x00003C1C
		public Task<Lobby> UpdatePlayerAsync(string lobbyId, string playerId, UpdatePlayerOptions options)
		{
			WrappedLobbyService.<UpdatePlayerAsync>d__22 <UpdatePlayerAsync>d__;
			<UpdatePlayerAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Lobby>.Create();
			<UpdatePlayerAsync>d__.<>4__this = this;
			<UpdatePlayerAsync>d__.lobbyId = lobbyId;
			<UpdatePlayerAsync>d__.playerId = playerId;
			<UpdatePlayerAsync>d__.options = options;
			<UpdatePlayerAsync>d__.<>1__state = -1;
			<UpdatePlayerAsync>d__.<>t__builder.Start<WrappedLobbyService.<UpdatePlayerAsync>d__22>(ref <UpdatePlayerAsync>d__);
			return <UpdatePlayerAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00005A78 File Offset: 0x00003C78
		public Task<Lobby> ReconnectToLobbyAsync(string lobbyId)
		{
			WrappedLobbyService.<ReconnectToLobbyAsync>d__23 <ReconnectToLobbyAsync>d__;
			<ReconnectToLobbyAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Lobby>.Create();
			<ReconnectToLobbyAsync>d__.<>4__this = this;
			<ReconnectToLobbyAsync>d__.lobbyId = lobbyId;
			<ReconnectToLobbyAsync>d__.<>1__state = -1;
			<ReconnectToLobbyAsync>d__.<>t__builder.Start<WrappedLobbyService.<ReconnectToLobbyAsync>d__23>(ref <ReconnectToLobbyAsync>d__);
			return <ReconnectToLobbyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00005AC4 File Offset: 0x00003CC4
		public Task<Dictionary<string, TokenData>> RequestTokensAsync(string lobbyId, params TokenRequest.TokenTypeOptions[] tokenOptions)
		{
			WrappedLobbyService.<RequestTokensAsync>d__24 <RequestTokensAsync>d__;
			<RequestTokensAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Dictionary<string, TokenData>>.Create();
			<RequestTokensAsync>d__.<>4__this = this;
			<RequestTokensAsync>d__.lobbyId = lobbyId;
			<RequestTokensAsync>d__.tokenOptions = tokenOptions;
			<RequestTokensAsync>d__.<>1__state = -1;
			<RequestTokensAsync>d__.<>t__builder.Start<WrappedLobbyService.<RequestTokensAsync>d__24>(ref <RequestTokensAsync>d__);
			return <RequestTokensAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00005B17 File Offset: 0x00003D17
		public void SetBasePath(string basePath)
		{
			this.m_LobbyService.Configuration.BasePath = basePath;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00005B2A File Offset: 0x00003D2A
		public void EnableLocalPlayerLobbyEvents(bool enabled)
		{
			this.m_LocalPlayerLobbyEventsEnabled = enabled;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00005B34 File Offset: 0x00003D34
		private Task<Response> TryCatchRequest<TRequest>(string api, Func<TRequest, Configuration, Task<Response>> func, TRequest request)
		{
			WrappedLobbyService.<TryCatchRequest>d__27<TRequest> <TryCatchRequest>d__;
			<TryCatchRequest>d__.<>t__builder = AsyncTaskMethodBuilder<Response>.Create();
			<TryCatchRequest>d__.<>4__this = this;
			<TryCatchRequest>d__.api = api;
			<TryCatchRequest>d__.func = func;
			<TryCatchRequest>d__.request = request;
			<TryCatchRequest>d__.<>1__state = -1;
			<TryCatchRequest>d__.<>t__builder.Start<WrappedLobbyService.<TryCatchRequest>d__27<TRequest>>(ref <TryCatchRequest>d__);
			return <TryCatchRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00005B90 File Offset: 0x00003D90
		private Task<Response<TReturn>> TryCatchRequest<TRequest, TReturn>(string api, Func<TRequest, Configuration, Task<Response<TReturn>>> func, TRequest request)
		{
			WrappedLobbyService.<TryCatchRequest>d__28<TRequest, TReturn> <TryCatchRequest>d__;
			<TryCatchRequest>d__.<>t__builder = AsyncTaskMethodBuilder<Response<TReturn>>.Create();
			<TryCatchRequest>d__.<>4__this = this;
			<TryCatchRequest>d__.api = api;
			<TryCatchRequest>d__.func = func;
			<TryCatchRequest>d__.request = request;
			<TryCatchRequest>d__.<>1__state = -1;
			<TryCatchRequest>d__.<>t__builder.Start<WrappedLobbyService.<TryCatchRequest>d__28<TRequest, TReturn>>(ref <TryCatchRequest>d__);
			return <TryCatchRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00005BEC File Offset: 0x00003DEC
		private void ResolveErrorWrapping(LobbyExceptionReason reason, Exception exception = null)
		{
			if (reason == LobbyExceptionReason.Unknown)
			{
				throw new LobbyServiceException(reason, "Something went wrong.", exception);
			}
			LobbyExceptionReason lobbyExceptionReason;
			if (this.TryMapCommonErrorCodeToLobbyExceptionReason((int)reason, out lobbyExceptionReason))
			{
				reason = lobbyExceptionReason;
			}
			HttpException<ErrorStatus> httpException = exception as HttpException<ErrorStatus>;
			if (httpException != null)
			{
				string text = httpException.ActualError.Detail;
				if (httpException.ActualError.Details != null && httpException.ActualError.Details.Any<Detail>())
				{
					text = text + "\n" + string.Join(", ", from d in httpException.ActualError.Details
					select d.Message);
				}
				throw new LobbyServiceException(reason, text, httpException);
			}
			throw new LobbyServiceException(reason, exception.Message, exception);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00005CAC File Offset: 0x00003EAC
		private bool TryMapCommonErrorCodeToLobbyExceptionReason(int code, out LobbyExceptionReason reason)
		{
			if (code < 100)
			{
				if (code != 0)
				{
					if (code != 3)
					{
						switch (code)
						{
						case 50:
							reason = LobbyExceptionReason.RateLimited;
							return true;
						case 53:
							reason = LobbyExceptionReason.Forbidden;
							return true;
						case 54:
							reason = LobbyExceptionReason.EntityNotFound;
							return true;
						case 55:
							reason = LobbyExceptionReason.InvalidArgument;
							return true;
						}
						reason = LobbyExceptionReason.UnknownErrorCode;
					}
					else
					{
						reason = LobbyExceptionReason.ServiceUnavailable;
					}
				}
				else
				{
					reason = LobbyExceptionReason.Unknown;
				}
				return true;
			}
			reason = LobbyExceptionReason.Unknown;
			return false;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00005D2C File Offset: 0x00003F2C
		private Task<Lobby> LobbyConflictResolver(Player player, string lobbyId = null, LobbyServiceException e = null)
		{
			WrappedLobbyService.<LobbyConflictResolver>d__31 <LobbyConflictResolver>d__;
			<LobbyConflictResolver>d__.<>t__builder = AsyncTaskMethodBuilder<Lobby>.Create();
			<LobbyConflictResolver>d__.<>4__this = this;
			<LobbyConflictResolver>d__.player = player;
			<LobbyConflictResolver>d__.lobbyId = lobbyId;
			<LobbyConflictResolver>d__.e = e;
			<LobbyConflictResolver>d__.<>1__state = -1;
			<LobbyConflictResolver>d__.<>t__builder.Start<WrappedLobbyService.<LobbyConflictResolver>d__31>(ref <LobbyConflictResolver>d__);
			return <LobbyConflictResolver>d__.<>t__builder.Task;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00005D88 File Offset: 0x00003F88
		private bool IsPlayerDataEqual(Player a, Player b)
		{
			bool flag = a.Id == b.Id;
			flag &= (a.ConnectionInfo == b.ConnectionInfo);
			flag &= (a.AllocationId == b.AllocationId);
			flag &= (a.Joined == b.Joined);
			flag &= (a.LastUpdated == b.LastUpdated);
			Dictionary<string, PlayerDataObject>.KeyCollection keys = a.Data.Keys;
			Dictionary<string, PlayerDataObject>.KeyCollection keys2 = b.Data.Keys;
			bool flag2 = keys.All(new Func<string, bool>(keys2.Contains<string>)) && keys.Count == keys2.Count;
			flag = (flag && flag2);
			if (!flag)
			{
				return false;
			}
			foreach (string key in keys)
			{
				PlayerDataObject playerDataObject = a.Data[key];
				PlayerDataObject playerDataObject2 = b.Data[key];
				flag &= (playerDataObject.Value == playerDataObject2.Value);
				flag &= (playerDataObject.Visibility == playerDataObject2.Visibility);
			}
			return flag;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00005EC4 File Offset: 0x000040C4
		private void AddOrUpdateLobbyCache(Lobby newLobby)
		{
			this.JoinedLobbyCache[newLobby.Id] = WrappedLobbyService.CloneLobbyHelper(newLobby);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00005EE0 File Offset: 0x000040E0
		internal static Lobby CloneLobbyHelper(Lobby otherLobby)
		{
			Lobby lobby = new Lobby(null, null, null, null, null, 0, 0, false, false, null, null, null, default(DateTime), default(DateTime), 0, false);
			lobby.Version = otherLobby.Version;
			lobby.Id = otherLobby.Id;
			lobby.Name = otherLobby.Name;
			lobby.AvailableSlots = otherLobby.AvailableSlots;
			lobby.HasPassword = otherLobby.HasPassword;
			if (otherLobby.Players != null)
			{
				lobby.Players = new List<Player>();
				foreach (Player player in otherLobby.Players)
				{
					Player player2 = new Player(null, null, null, null, default(DateTime), default(DateTime), null)
					{
						Id = player.Id,
						AllocationId = player.AllocationId,
						Joined = player.Joined,
						ConnectionInfo = player.ConnectionInfo,
						LastUpdated = player.LastUpdated,
						Profile = player.Profile
					};
					if (player.Data != null)
					{
						player2.Data = new Dictionary<string, PlayerDataObject>();
						foreach (KeyValuePair<string, PlayerDataObject> keyValuePair in player.Data)
						{
							player2.Data[keyValuePair.Key] = new PlayerDataObject(keyValuePair.Value.Visibility, keyValuePair.Value.Value);
						}
					}
					lobby.Players.Add(player2);
				}
			}
			if (otherLobby.Data != null)
			{
				lobby.Data = new Dictionary<string, DataObject>();
				foreach (KeyValuePair<string, DataObject> keyValuePair2 in otherLobby.Data)
				{
					lobby.Data[keyValuePair2.Key] = new DataObject(keyValuePair2.Value.Visibility, keyValuePair2.Value.Value, keyValuePair2.Value.Index);
				}
			}
			lobby.Upid = otherLobby.Upid;
			lobby.EnvironmentId = otherLobby.EnvironmentId;
			lobby.HostId = otherLobby.HostId;
			lobby.IsLocked = otherLobby.IsLocked;
			lobby.IsPrivate = otherLobby.IsPrivate;
			lobby.LobbyCode = otherLobby.LobbyCode;
			lobby.MaxPlayers = otherLobby.MaxPlayers;
			lobby.Created = otherLobby.Created;
			lobby.LastUpdated = otherLobby.LastUpdated;
			return lobby;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000061BC File Offset: 0x000043BC
		public Dictionary<string, Lobby> GetLobbyCache()
		{
			return this.JoinedLobbyCache;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x000061C4 File Offset: 0x000043C4
		private CreateRequest ConvertCreateOptionsToRequest(string lobbyName, int maxPlayers, CreateLobbyOptions options)
		{
			return new CreateRequest(lobbyName, maxPlayers, (options != null) ? options.IsPrivate : null, (options != null) ? options.IsLocked : null, (options != null) ? options.Player : null, (options != null) ? options.Data : null, (options != null) ? options.Password : null);
		}

		// Token: 0x040000A7 RID: 167
		private const int k_CommonErrorCodeRange = 100;

		// Token: 0x040000A8 RID: 168
		internal ILobbyServiceSdk m_LobbyService;

		// Token: 0x040000A9 RID: 169
		private readonly ApiTelemetryScopeFactory m_TelemetryScopeFactory;

		// Token: 0x040000AA RID: 170
		private bool m_LocalPlayerLobbyEventsEnabled;

		// Token: 0x040000AB RID: 171
		internal const int LOBBY_ERROR_MIN_RANGE = 16000;
	}
}
