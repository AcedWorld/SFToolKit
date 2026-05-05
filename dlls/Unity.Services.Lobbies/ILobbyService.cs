using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000011 RID: 17
	public interface ILobbyService
	{
		// Token: 0x06000062 RID: 98
		Task<Lobby> CreateLobbyAsync(string lobbyName, int maxPlayers, CreateLobbyOptions options = null);

		// Token: 0x06000063 RID: 99
		Task<Lobby> CreateOrJoinLobbyAsync(string lobbyId, string lobbyName, int maxPlayers, CreateLobbyOptions options = null);

		// Token: 0x06000064 RID: 100
		Task<ILobbyEvents> SubscribeToLobbyEventsAsync(string lobbyId, LobbyEventCallbacks callbacks);

		// Token: 0x06000065 RID: 101
		Task DeleteLobbyAsync(string lobbyId);

		// Token: 0x06000066 RID: 102
		Task<List<string>> GetJoinedLobbiesAsync();

		// Token: 0x06000067 RID: 103
		Task<Lobby> GetLobbyAsync(string lobbyId);

		// Token: 0x06000068 RID: 104
		Task SendHeartbeatPingAsync(string lobbyId);

		// Token: 0x06000069 RID: 105
		Task<Lobby> JoinLobbyByCodeAsync(string lobbyCode, JoinLobbyByCodeOptions options = null);

		// Token: 0x0600006A RID: 106
		Task<Lobby> JoinLobbyByIdAsync(string lobbyId, JoinLobbyByIdOptions options = null);

		// Token: 0x0600006B RID: 107
		Task<QueryResponse> QueryLobbiesAsync(QueryLobbiesOptions options = null);

		// Token: 0x0600006C RID: 108
		Task<Lobby> QuickJoinLobbyAsync(QuickJoinLobbyOptions options = null);

		// Token: 0x0600006D RID: 109
		Task RemovePlayerAsync(string lobbyId, string playerId);

		// Token: 0x0600006E RID: 110
		Task<Lobby> UpdateLobbyAsync(string lobbyId, UpdateLobbyOptions options);

		// Token: 0x0600006F RID: 111
		Task<Lobby> UpdatePlayerAsync(string lobbyId, string playerId, UpdatePlayerOptions options);

		// Token: 0x06000070 RID: 112
		Task<Lobby> ReconnectToLobbyAsync(string lobbyId);
	}
}
