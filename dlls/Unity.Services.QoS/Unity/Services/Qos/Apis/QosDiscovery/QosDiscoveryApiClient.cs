using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Services.Authentication.Internal;
using Unity.Services.Qos.Http;
using Unity.Services.Qos.Models;
using Unity.Services.Qos.QosDiscovery;

namespace Unity.Services.Qos.Apis.QosDiscovery
{
	// Token: 0x0200007A RID: 122
	internal class QosDiscoveryApiClient : BaseApiClient, IQosDiscoveryApiClient
	{
		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600025D RID: 605 RVA: 0x00008914 File Offset: 0x00006B14
		// (set) Token: 0x0600025E RID: 606 RVA: 0x00008946 File Offset: 0x00006B46
		public Configuration Configuration
		{
			get
			{
				Configuration b = new Configuration("https://qos-discovery.services.api.unity.com", new int?(10), new int?(4), null);
				return Configuration.MergeConfigurations(this._configuration, b);
			}
			set
			{
				this._configuration = value;
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000894F File Offset: 0x00006B4F
		public QosDiscoveryApiClient(IHttpClient httpClient, IAccessToken accessToken, Configuration configuration = null) : base(httpClient)
		{
			this._configuration = configuration;
			this._accessToken = accessToken;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00008968 File Offset: 0x00006B68
		public Task<Response<QosServersResponseBody>> GetServersAsync(GetServersRequest request, Configuration operationConfiguration = null)
		{
			QosDiscoveryApiClient.<GetServersAsync>d__7 <GetServersAsync>d__;
			<GetServersAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<QosServersResponseBody>>.Create();
			<GetServersAsync>d__.<>4__this = this;
			<GetServersAsync>d__.request = request;
			<GetServersAsync>d__.operationConfiguration = operationConfiguration;
			<GetServersAsync>d__.<>1__state = -1;
			<GetServersAsync>d__.<>t__builder.Start<QosDiscoveryApiClient.<GetServersAsync>d__7>(ref <GetServersAsync>d__);
			return <GetServersAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x000089BC File Offset: 0x00006BBC
		public Task<Response<QosServiceServersResponseBody>> GetServiceServersAsync(GetServiceServersRequest request, Configuration operationConfiguration = null)
		{
			QosDiscoveryApiClient.<GetServiceServersAsync>d__8 <GetServiceServersAsync>d__;
			<GetServiceServersAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<QosServiceServersResponseBody>>.Create();
			<GetServiceServersAsync>d__.<>4__this = this;
			<GetServiceServersAsync>d__.request = request;
			<GetServiceServersAsync>d__.operationConfiguration = operationConfiguration;
			<GetServiceServersAsync>d__.<>1__state = -1;
			<GetServiceServersAsync>d__.<>t__builder.Start<QosDiscoveryApiClient.<GetServiceServersAsync>d__8>(ref <GetServiceServersAsync>d__);
			return <GetServiceServersAsync>d__.<>t__builder.Task;
		}

		// Token: 0x040000F2 RID: 242
		private IAccessToken _accessToken;

		// Token: 0x040000F3 RID: 243
		private const int _baseTimeout = 10;

		// Token: 0x040000F4 RID: 244
		private Configuration _configuration;
	}
}
