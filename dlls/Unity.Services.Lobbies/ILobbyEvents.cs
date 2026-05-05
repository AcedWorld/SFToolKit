using System;
using System.Threading.Tasks;

namespace Unity.Services.Lobbies
{
	// Token: 0x0200001C RID: 28
	public interface ILobbyEvents
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000A0 RID: 160
		LobbyEventCallbacks Callbacks { get; }

		// Token: 0x060000A1 RID: 161
		Task SubscribeAsync();

		// Token: 0x060000A2 RID: 162
		Task UnsubscribeAsync();
	}
}
