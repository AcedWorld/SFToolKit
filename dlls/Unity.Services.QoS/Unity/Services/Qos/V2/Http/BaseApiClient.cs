using System;

namespace Unity.Services.Qos.V2.Http
{
	// Token: 0x0200002A RID: 42
	internal abstract class BaseApiClient
	{
		// Token: 0x060000AF RID: 175 RVA: 0x00004756 File Offset: 0x00002956
		public BaseApiClient(IHttpClient httpClient)
		{
			this.HttpClient = (httpClient ?? new HttpClient());
		}

		// Token: 0x04000085 RID: 133
		protected readonly IHttpClient HttpClient;
	}
}
