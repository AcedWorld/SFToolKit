using System;
using Unity.Services.Qos.V2.Http;

namespace Unity.Services.Qos.V2
{
	// Token: 0x02000021 RID: 33
	internal class Response<T> : Response
	{
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000085 RID: 133 RVA: 0x000040B1 File Offset: 0x000022B1
		public T Result { get; }

		// Token: 0x06000086 RID: 134 RVA: 0x000040B9 File Offset: 0x000022B9
		public Response(HttpClientResponse httpResponse, T result) : base(httpResponse)
		{
			this.Result = result;
		}
	}
}
