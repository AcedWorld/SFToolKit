using System;
using System.Collections.Generic;
using System.IO;

namespace Unity.Services.Authentication.Shared
{
	// Token: 0x0200005E RID: 94
	internal class ApiRequestOptions
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000275 RID: 629 RVA: 0x00006DD9 File Offset: 0x00004FD9
		// (set) Token: 0x06000276 RID: 630 RVA: 0x00006DE1 File Offset: 0x00004FE1
		public Dictionary<string, string> PathParameters { get; set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000277 RID: 631 RVA: 0x00006DEA File Offset: 0x00004FEA
		// (set) Token: 0x06000278 RID: 632 RVA: 0x00006DF2 File Offset: 0x00004FF2
		public Multimap<string, string> QueryParameters { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000279 RID: 633 RVA: 0x00006DFB File Offset: 0x00004FFB
		// (set) Token: 0x0600027A RID: 634 RVA: 0x00006E03 File Offset: 0x00005003
		public Multimap<string, string> HeaderParameters { get; set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600027B RID: 635 RVA: 0x00006E0C File Offset: 0x0000500C
		// (set) Token: 0x0600027C RID: 636 RVA: 0x00006E14 File Offset: 0x00005014
		public Dictionary<string, string> FormParameters { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600027D RID: 637 RVA: 0x00006E1D File Offset: 0x0000501D
		// (set) Token: 0x0600027E RID: 638 RVA: 0x00006E25 File Offset: 0x00005025
		public Multimap<string, Stream> FileParameters { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600027F RID: 639 RVA: 0x00006E2E File Offset: 0x0000502E
		// (set) Token: 0x06000280 RID: 640 RVA: 0x00006E36 File Offset: 0x00005036
		public string Operation { get; set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000281 RID: 641 RVA: 0x00006E3F File Offset: 0x0000503F
		// (set) Token: 0x06000282 RID: 642 RVA: 0x00006E47 File Offset: 0x00005047
		public object Data { get; set; }

		// Token: 0x06000283 RID: 643 RVA: 0x00006E50 File Offset: 0x00005050
		public ApiRequestOptions()
		{
			this.PathParameters = new Dictionary<string, string>();
			this.QueryParameters = new Multimap<string, string>();
			this.HeaderParameters = new Multimap<string, string>();
			this.FormParameters = new Dictionary<string, string>();
			this.FileParameters = new Multimap<string, Stream>();
		}
	}
}
