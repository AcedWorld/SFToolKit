using System;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x02000046 RID: 70
	internal abstract class BaseApiClient
	{
		// Token: 0x06000203 RID: 515 RVA: 0x00008197 File Offset: 0x00006397
		public BaseApiClient(IHttpClient httpClient)
		{
			this.HttpClient = (httpClient ?? new HttpClient());
		}

		// Token: 0x04000107 RID: 263
		protected readonly IHttpClient HttpClient;
	}
}
