using System;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000022 RID: 34
	public class QueryLobbiesOptions
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x00004FDB File Offset: 0x000031DB
		// (set) Token: 0x060000E9 RID: 233 RVA: 0x00004FE3 File Offset: 0x000031E3
		public int Count { get; set; } = 10;

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00004FEC File Offset: 0x000031EC
		// (set) Token: 0x060000EB RID: 235 RVA: 0x00004FF4 File Offset: 0x000031F4
		public int Skip { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00004FFD File Offset: 0x000031FD
		// (set) Token: 0x060000ED RID: 237 RVA: 0x00005005 File Offset: 0x00003205
		public bool SampleResults { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000EE RID: 238 RVA: 0x0000500E File Offset: 0x0000320E
		// (set) Token: 0x060000EF RID: 239 RVA: 0x00005016 File Offset: 0x00003216
		public List<QueryFilter> Filters { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x0000501F File Offset: 0x0000321F
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x00005027 File Offset: 0x00003227
		public List<QueryOrder> Order { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00005030 File Offset: 0x00003230
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x00005038 File Offset: 0x00003238
		public string ContinuationToken { get; set; }
	}
}
