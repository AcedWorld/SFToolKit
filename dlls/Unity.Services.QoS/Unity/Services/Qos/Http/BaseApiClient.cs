using System;

namespace Unity.Services.Qos.Http
{
	// Token: 0x0200005B RID: 91
	internal abstract class BaseApiClient
	{
		// Token: 0x060001AA RID: 426 RVA: 0x00006BEE File Offset: 0x00004DEE
		public BaseApiClient(IHttpClient httpClient)
		{
			this.HttpClient = (httpClient ?? new HttpClient());
		}

		// Token: 0x040000C9 RID: 201
		protected readonly IHttpClient HttpClient;
	}
}
