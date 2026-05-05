using System;
using Unity.Services.Lobbies.Http;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000009 RID: 9
	internal class Response<T> : Response
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00004629 File Offset: 0x00002829
		public T Result { get; }

		// Token: 0x0600003D RID: 61 RVA: 0x00004631 File Offset: 0x00002831
		public Response(HttpClientResponse httpResponse, T result) : base(httpResponse)
		{
			this.Result = result;
		}
	}
}
