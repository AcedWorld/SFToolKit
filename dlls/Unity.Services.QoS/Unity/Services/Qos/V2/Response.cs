using System;
using System.Collections.Generic;
using Unity.Services.Qos.V2.Http;

namespace Unity.Services.Qos.V2
{
	// Token: 0x02000020 RID: 32
	internal class Response
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00004078 File Offset: 0x00002278
		public Dictionary<string, string> Headers { get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00004080 File Offset: 0x00002280
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00004088 File Offset: 0x00002288
		public long Status { get; set; }

		// Token: 0x06000084 RID: 132 RVA: 0x00004091 File Offset: 0x00002291
		public Response(HttpClientResponse httpResponse)
		{
			this.Headers = httpResponse.Headers;
			this.Status = httpResponse.StatusCode;
		}
	}
}
