using System;
using Unity.Services.Relay.Http;

namespace Unity.Services.Relay
{
	// Token: 0x02000007 RID: 7
	internal class Response<T> : Response
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000022A5 File Offset: 0x000004A5
		public T Result { get; }

		// Token: 0x0600000D RID: 13 RVA: 0x000022AD File Offset: 0x000004AD
		public Response(HttpClientResponse httpResponse, T result) : base(httpResponse)
		{
			this.Result = result;
		}
	}
}
