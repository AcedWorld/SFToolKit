using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies.Internal
{
	// Token: 0x02000027 RID: 39
	internal interface ILobbyServiceInternal
	{
		// Token: 0x06000117 RID: 279
		Task<Dictionary<string, TokenData>> RequestTokensAsync(string lobbyId, params TokenRequest.TokenTypeOptions[] tokenOptions);

		// Token: 0x06000118 RID: 280
		Dictionary<string, Lobby> GetLobbyCache();
	}
}
