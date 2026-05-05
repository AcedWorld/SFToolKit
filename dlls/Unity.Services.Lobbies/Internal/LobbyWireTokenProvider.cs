using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Services.Wire.Internal;

namespace Unity.Services.Lobbies.Internal
{
	// Token: 0x02000029 RID: 41
	internal class LobbyWireTokenProvider : IChannelTokenProvider
	{
		// Token: 0x06000124 RID: 292 RVA: 0x00005550 File Offset: 0x00003750
		internal LobbyWireTokenProvider(string lobbyId, WrappedLobbyService lobbyService)
		{
			if (lobbyId == null)
			{
				Logger.LogError("LobbyWireTokenProvider is invalid as its lobbyId is null!");
			}
			if (lobbyService == null)
			{
				Logger.LogError("LobbyWireTokenProvider is invalid as its lobbyService is null!");
			}
			this.lobbyId = lobbyId;
			this.lobbyService = lobbyService;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00005580 File Offset: 0x00003780
		public Task<ChannelToken> GetTokenAsync()
		{
			LobbyWireTokenProvider.<GetTokenAsync>d__3 <GetTokenAsync>d__;
			<GetTokenAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ChannelToken>.Create();
			<GetTokenAsync>d__.<>4__this = this;
			<GetTokenAsync>d__.<>1__state = -1;
			<GetTokenAsync>d__.<>t__builder.Start<LobbyWireTokenProvider.<GetTokenAsync>d__3>(ref <GetTokenAsync>d__);
			return <GetTokenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x040000A5 RID: 165
		private string lobbyId;

		// Token: 0x040000A6 RID: 166
		private WrappedLobbyService lobbyService;
	}
}
