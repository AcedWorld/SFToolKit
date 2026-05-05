using System;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000015 RID: 21
	public class JoinLobbyByIdOptions
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000078 RID: 120 RVA: 0x000048A0 File Offset: 0x00002AA0
		// (set) Token: 0x06000079 RID: 121 RVA: 0x000048A8 File Offset: 0x00002AA8
		public Player Player { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600007A RID: 122 RVA: 0x000048B1 File Offset: 0x00002AB1
		// (set) Token: 0x0600007B RID: 123 RVA: 0x000048B9 File Offset: 0x00002AB9
		public string Password { get; set; }
	}
}
