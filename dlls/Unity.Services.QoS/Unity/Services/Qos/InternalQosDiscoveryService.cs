using System;
using Unity.Services.Authentication.Internal;
using Unity.Services.Qos.Apis.QosDiscovery;
using Unity.Services.Qos.Http;

namespace Unity.Services.Qos
{
	// Token: 0x02000014 RID: 20
	internal class InternalQosDiscoveryService
	{
		// Token: 0x06000053 RID: 83 RVA: 0x000037D1 File Offset: 0x000019D1
		internal InternalQosDiscoveryService(string host, HttpClient httpClient, IAccessToken accessToken = null)
		{
			this.Configuration = new Configuration(host, new int?(10), new int?(4), null);
			this.QosDiscoveryApi = new QosDiscoveryApiClient(httpClient, accessToken, this.Configuration);
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00003806 File Offset: 0x00001A06
		// (set) Token: 0x06000055 RID: 85 RVA: 0x0000380E File Offset: 0x00001A0E
		public IQosDiscoveryApiClient QosDiscoveryApi { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00003817 File Offset: 0x00001A17
		// (set) Token: 0x06000057 RID: 87 RVA: 0x0000381F File Offset: 0x00001A1F
		public Configuration Configuration { get; set; }

		// Token: 0x0400004D RID: 77
		private const int RequestTimeout = 10;

		// Token: 0x0400004E RID: 78
		private const int NumRetries = 4;
	}
}
