using System;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000020 RID: 32
	public struct LobbyPlayerJoined
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00004F7B File Offset: 0x0000317B
		public readonly int PlayerIndex { get; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00004F83 File Offset: 0x00003183
		public readonly Player Player { get; }

		// Token: 0x060000E2 RID: 226 RVA: 0x00004F8B File Offset: 0x0000318B
		public LobbyPlayerJoined(int index, Player player)
		{
			this.PlayerIndex = index;
			this.Player = player;
		}
	}
}
