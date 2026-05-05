using System;
using System.Collections.Generic;
using Unity.Services.Relay.Http;

namespace Unity.Services.Relay
{
	// Token: 0x02000006 RID: 6
	internal class Response
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000008 RID: 8 RVA: 0x0000226C File Offset: 0x0000046C
		public Dictionary<string, string> Headers { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002274 File Offset: 0x00000474
		// (set) Token: 0x0600000A RID: 10 RVA: 0x0000227C File Offset: 0x0000047C
		public long Status { get; set; }

		// Token: 0x0600000B RID: 11 RVA: 0x00002285 File Offset: 0x00000485
		public Response(HttpClientResponse httpResponse)
		{
			this.Headers = httpResponse.Headers;
			this.Status = httpResponse.StatusCode;
		}
	}
}
