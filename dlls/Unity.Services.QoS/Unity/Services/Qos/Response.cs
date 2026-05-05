using System;
using System.Collections.Generic;
using Unity.Services.Qos.Http;

namespace Unity.Services.Qos
{
	// Token: 0x02000011 RID: 17
	internal class Response
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000035F6 File Offset: 0x000017F6
		public Dictionary<string, string> Headers { get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000046 RID: 70 RVA: 0x000035FE File Offset: 0x000017FE
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00003606 File Offset: 0x00001806
		public long Status { get; set; }

		// Token: 0x06000048 RID: 72 RVA: 0x0000360F File Offset: 0x0000180F
		public Response(HttpClientResponse httpResponse)
		{
			this.Headers = httpResponse.Headers;
			this.Status = httpResponse.StatusCode;
		}
	}
}
