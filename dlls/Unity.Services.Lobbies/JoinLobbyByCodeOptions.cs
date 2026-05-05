using System;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000014 RID: 20
	public class JoinLobbyByCodeOptions
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00004876 File Offset: 0x00002A76
		// (set) Token: 0x06000074 RID: 116 RVA: 0x0000487E File Offset: 0x00002A7E
		public Player Player { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00004887 File Offset: 0x00002A87
		// (set) Token: 0x06000076 RID: 118 RVA: 0x0000488F File Offset: 0x00002A8F
		public string Password { get; set; }
	}
}
