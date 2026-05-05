using System;

namespace Unity.Services.Relay.Http
{
	// Token: 0x02000031 RID: 49
	internal abstract class BaseApiClient
	{
		// Token: 0x060000CC RID: 204 RVA: 0x00003C8F File Offset: 0x00001E8F
		public BaseApiClient(IHttpClient httpClient)
		{
			this.HttpClient = (httpClient ?? new HttpClient());
		}

		// Token: 0x04000089 RID: 137
		protected readonly IHttpClient HttpClient;
	}
}
