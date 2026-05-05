using System;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies
{
	// Token: 0x0200000E RID: 14
	public class CreateLobbyOptions
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00004784 File Offset: 0x00002984
		// (set) Token: 0x06000051 RID: 81 RVA: 0x0000478C File Offset: 0x0000298C
		public bool? IsPrivate { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00004795 File Offset: 0x00002995
		// (set) Token: 0x06000053 RID: 83 RVA: 0x0000479D File Offset: 0x0000299D
		public string Password { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000054 RID: 84 RVA: 0x000047A6 File Offset: 0x000029A6
		// (set) Token: 0x06000055 RID: 85 RVA: 0x000047AE File Offset: 0x000029AE
		public bool? IsLocked { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000056 RID: 86 RVA: 0x000047B7 File Offset: 0x000029B7
		// (set) Token: 0x06000057 RID: 87 RVA: 0x000047BF File Offset: 0x000029BF
		public Player Player { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000058 RID: 88 RVA: 0x000047C8 File Offset: 0x000029C8
		// (set) Token: 0x06000059 RID: 89 RVA: 0x000047D0 File Offset: 0x000029D0
		public Dictionary<string, DataObject> Data { get; set; }
	}
}
