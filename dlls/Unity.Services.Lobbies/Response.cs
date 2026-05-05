using System;
using System.Collections.Generic;
using Unity.Services.Lobbies.Http;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000008 RID: 8
	internal class Response
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000038 RID: 56 RVA: 0x000045F0 File Offset: 0x000027F0
		public Dictionary<string, string> Headers { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000045F8 File Offset: 0x000027F8
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00004600 File Offset: 0x00002800
		public long Status { get; set; }

		// Token: 0x0600003B RID: 59 RVA: 0x00004609 File Offset: 0x00002809
		public Response(HttpClientResponse httpResponse)
		{
			this.Headers = httpResponse.Headers;
			this.Status = httpResponse.StatusCode;
		}
	}
}
