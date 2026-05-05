using System;
using Unity.Services.Authentication.Internal;
using Unity.Services.Core.Configuration.Internal;
using Unity.Services.Qos.Internal;
using Unity.Services.Relay.Apis.RelayAllocations;
using Unity.Services.Relay.Http;

namespace Unity.Services.Relay
{
	// Token: 0x02000009 RID: 9
	internal class InternalRelayService : IRelayServiceSdk
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000011 RID: 17 RVA: 0x0000233E File Offset: 0x0000053E
		// (set) Token: 0x06000012 RID: 18 RVA: 0x00002346 File Offset: 0x00000546
		public IRelayAllocationsApiClient AllocationsApi { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000013 RID: 19 RVA: 0x0000234F File Offset: 0x0000054F
		// (set) Token: 0x06000014 RID: 20 RVA: 0x00002357 File Offset: 0x00000557
		public Configuration Configuration { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002360 File Offset: 0x00000560
		// (set) Token: 0x06000016 RID: 22 RVA: 0x00002368 File Offset: 0x00000568
		public IAccessToken AccessToken { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002371 File Offset: 0x00000571
		// (set) Token: 0x06000018 RID: 24 RVA: 0x00002379 File Offset: 0x00000579
		public IQosResults QosResults { get; set; }

		// Token: 0x06000019 RID: 25 RVA: 0x00002384 File Offset: 0x00000584
		public InternalRelayService(HttpClient httpClient, IProjectConfiguration projectConfiguration = null, IAccessToken accessToken = null, IQosResults qosResults = null)
		{
			this.AllocationsApi = new RelayAllocationsApiClient(httpClient, accessToken, null);
			this.Configuration = new Configuration(this.GetHost(projectConfiguration), new int?(10), new int?(4), null);
			this.AccessToken = accessToken;
			this.QosResults = qosResults;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000023D4 File Offset: 0x000005D4
		private string GetHost(IProjectConfiguration projectConfiguration)
		{
			if (((projectConfiguration != null) ? projectConfiguration.GetString("com.unity.services.core.cloud-environment", null) : null) == "staging")
			{
				return "https://relay-allocations-stg.services.api.unity.com";
			}
			return "https://relay-allocations.services.api.unity.com";
		}

		// Token: 0x04000009 RID: 9
		private const string k_CloudEnvironmentKey = "com.unity.services.core.cloud-environment";

		// Token: 0x0400000A RID: 10
		private const string k_StagingEnvironment = "staging";
	}
}
