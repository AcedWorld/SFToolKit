using System;
using Unity.Services.Qos.Http;

namespace Unity.Services.Qos
{
	// Token: 0x02000012 RID: 18
	internal class Response<T> : Response
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000049 RID: 73 RVA: 0x0000362F File Offset: 0x0000182F
		public T Result { get; }

		// Token: 0x0600004A RID: 74 RVA: 0x00003637 File Offset: 0x00001837
		public Response(HttpClientResponse httpResponse, T result) : base(httpResponse)
		{
			this.Result = result;
		}
	}
}
