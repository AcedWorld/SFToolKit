using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Services.Authentication.Internal;
using Unity.Services.Qos.V2.Http;
using Unity.Services.Qos.V2.Models;
using Unity.Services.Qos.V2.QosDiscovery;

namespace Unity.Services.Qos.V2.Apis.QosDiscovery
{
	// Token: 0x02000049 RID: 73
	internal class QosDiscoveryApiClient : BaseApiClient, IQosDiscoveryApiClient
	{
		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600015E RID: 350 RVA: 0x0000609C File Offset: 0x0000429C
		// (set) Token: 0x0600015F RID: 351 RVA: 0x000060CE File Offset: 0x000042CE
		public Configuration Configuration
		{
			get
			{
				Configuration b = new Configuration("http://localhost", new int?(10), new int?(4), null);
				return Configuration.MergeConfigurations(this._configuration, b);
			}
			set
			{
				this._configuration = value;
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x000060D7 File Offset: 0x000042D7
		public QosDiscoveryApiClient(IHttpClient httpClient, IAccessToken accessToken, Configuration configuration = null) : base(httpClient)
		{
			this._configuration = configuration;
			this._accessToken = accessToken;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x000060F0 File Offset: 0x000042F0
		public Task<Response<QosServersResponseBody>> GetAllServersAsync(GetAllServersRequest request, Configuration operationConfiguration = null)
		{
			QosDiscoveryApiClient.<GetAllServersAsync>d__7 <GetAllServersAsync>d__;
			<GetAllServersAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<QosServersResponseBody>>.Create();
			<GetAllServersAsync>d__.<>4__this = this;
			<GetAllServersAsync>d__.request = request;
			<GetAllServersAsync>d__.operationConfiguration = operationConfiguration;
			<GetAllServersAsync>d__.<>1__state = -1;
			<GetAllServersAsync>d__.<>t__builder.Start<QosDiscoveryApiClient.<GetAllServersAsync>d__7>(ref <GetAllServersAsync>d__);
			return <GetAllServersAsync>d__.<>t__builder.Task;
		}

		// Token: 0x040000A9 RID: 169
		private IAccessToken _accessToken;

		// Token: 0x040000AA RID: 170
		private const int _baseTimeout = 10;

		// Token: 0x040000AB RID: 171
		private Configuration _configuration;
	}
}
