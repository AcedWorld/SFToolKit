using System;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies
{
	// Token: 0x0200001F RID: 31
	public class LobbyPlayerChanges
	{
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00004EF6 File Offset: 0x000030F6
		public int PlayerIndex { get; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00004EFE File Offset: 0x000030FE
		// (set) Token: 0x060000DA RID: 218 RVA: 0x00004F06 File Offset: 0x00003106
		public ChangedLobbyValue<string> ConnectionInfoChanged { get; internal set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00004F0F File Offset: 0x0000310F
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00004F17 File Offset: 0x00003117
		public ChangedLobbyValue<DateTime> LastUpdatedChanged { get; internal set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00004F20 File Offset: 0x00003120
		// (set) Token: 0x060000DE RID: 222 RVA: 0x00004F28 File Offset: 0x00003128
		public ChangedOrRemovedLobbyValue<Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>> ChangedData { get; internal set; }

		// Token: 0x060000DF RID: 223 RVA: 0x00004F34 File Offset: 0x00003134
		public LobbyPlayerChanges(int index)
		{
			this.PlayerIndex = index;
			this.ConnectionInfoChanged = default(ChangedLobbyValue<string>);
			this.LastUpdatedChanged = default(ChangedLobbyValue<DateTime>);
			this.ChangedData = default(ChangedOrRemovedLobbyValue<Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>>);
		}
	}
}
