using System;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000025 RID: 37
	public class UpdatePlayerOptions
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000109 RID: 265 RVA: 0x000050FA File Offset: 0x000032FA
		// (set) Token: 0x0600010A RID: 266 RVA: 0x00005102 File Offset: 0x00003302
		public string ConnectionInfo { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600010B RID: 267 RVA: 0x0000510B File Offset: 0x0000330B
		// (set) Token: 0x0600010C RID: 268 RVA: 0x00005113 File Offset: 0x00003313
		public Dictionary<string, PlayerDataObject> Data { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600010D RID: 269 RVA: 0x0000511C File Offset: 0x0000331C
		// (set) Token: 0x0600010E RID: 270 RVA: 0x00005124 File Offset: 0x00003324
		public string AllocationId { get; set; }
	}
}
