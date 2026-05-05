using System;
using Unity.Services.Core.Internal;

namespace Unity.Services.Core.Networking.Internal
{
	// Token: 0x0200001D RID: 29
	internal interface IHttpClient : IServiceComponent
	{
		// Token: 0x0600004D RID: 77
		string GetBaseUrlFor(string serviceId);

		// Token: 0x0600004E RID: 78
		HttpOptions GetDefaultOptionsFor(string serviceId);

		// Token: 0x0600004F RID: 79
		HttpRequest CreateRequestForService(string serviceId, string resourcePath);

		// Token: 0x06000050 RID: 80
		IAsyncOperation<ReadOnlyHttpResponse> Send(HttpRequest request);
	}
}
