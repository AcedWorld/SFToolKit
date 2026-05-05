using System;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000023 RID: 35
	public class QuickJoinLobbyOptions
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00005051 File Offset: 0x00003251
		// (set) Token: 0x060000F6 RID: 246 RVA: 0x00005059 File Offset: 0x00003259
		public Player Player { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x00005062 File Offset: 0x00003262
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x0000506A File Offset: 0x0000326A
		public List<QueryFilter> Filter { get; set; }
	}
}
