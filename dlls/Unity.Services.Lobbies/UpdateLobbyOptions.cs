using System;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000024 RID: 36
	public class UpdateLobbyOptions
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000FA RID: 250 RVA: 0x0000507B File Offset: 0x0000327B
		// (set) Token: 0x060000FB RID: 251 RVA: 0x00005083 File Offset: 0x00003283
		public string Name { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000FC RID: 252 RVA: 0x0000508C File Offset: 0x0000328C
		// (set) Token: 0x060000FD RID: 253 RVA: 0x00005094 File Offset: 0x00003294
		public int? MaxPlayers { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000FE RID: 254 RVA: 0x0000509D File Offset: 0x0000329D
		// (set) Token: 0x060000FF RID: 255 RVA: 0x000050A5 File Offset: 0x000032A5
		public bool? IsPrivate { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000100 RID: 256 RVA: 0x000050AE File Offset: 0x000032AE
		// (set) Token: 0x06000101 RID: 257 RVA: 0x000050B6 File Offset: 0x000032B6
		public bool? IsLocked { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000102 RID: 258 RVA: 0x000050BF File Offset: 0x000032BF
		// (set) Token: 0x06000103 RID: 259 RVA: 0x000050C7 File Offset: 0x000032C7
		public string Password { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000104 RID: 260 RVA: 0x000050D0 File Offset: 0x000032D0
		// (set) Token: 0x06000105 RID: 261 RVA: 0x000050D8 File Offset: 0x000032D8
		public Dictionary<string, DataObject> Data { get; set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000106 RID: 262 RVA: 0x000050E1 File Offset: 0x000032E1
		// (set) Token: 0x06000107 RID: 263 RVA: 0x000050E9 File Offset: 0x000032E9
		public string HostId { get; set; }
	}
}
