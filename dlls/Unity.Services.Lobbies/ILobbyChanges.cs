using System;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies
{
	// Token: 0x0200001B RID: 27
	public interface ILobbyChanges
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000091 RID: 145
		bool LobbyDeleted { get; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000092 RID: 146
		ChangedLobbyValue<string> Name { get; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000093 RID: 147
		ChangedLobbyValue<bool> IsPrivate { get; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000094 RID: 148
		ChangedLobbyValue<bool> IsLocked { get; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000095 RID: 149
		ChangedLobbyValue<bool> HasPassword { get; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000096 RID: 150
		ChangedLobbyValue<int> AvailableSlots { get; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000097 RID: 151
		ChangedLobbyValue<int> MaxPlayers { get; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000098 RID: 152
		ChangedOrRemovedLobbyValue<Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>> Data { get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000099 RID: 153
		ChangedLobbyValue<List<int>> PlayerLeft { get; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600009A RID: 154
		ChangedLobbyValue<List<LobbyPlayerJoined>> PlayerJoined { get; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600009B RID: 155
		ChangedLobbyValue<Dictionary<int, LobbyPlayerChanges>> PlayerData { get; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600009C RID: 156
		ChangedLobbyValue<string> HostId { get; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600009D RID: 157
		ChangedLobbyValue<int> Version { get; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600009E RID: 158
		ChangedLobbyValue<DateTime> LastUpdated { get; }

		// Token: 0x0600009F RID: 159
		void ApplyToLobby(Lobby lobby);
	}
}
