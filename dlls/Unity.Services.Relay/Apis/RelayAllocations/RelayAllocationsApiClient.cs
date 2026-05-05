using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Services.Authentication.Internal;
using Unity.Services.Relay.Http;
using Unity.Services.Relay.Models;
using Unity.Services.Relay.RelayAllocations;

namespace Unity.Services.Relay.Apis.RelayAllocations
{
	// Token: 0x02000052 RID: 82
	internal class RelayAllocationsApiClient : BaseApiClient, IRelayAllocationsApiClient
	{
		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000187 RID: 391 RVA: 0x00005B44 File Offset: 0x00003D44
		// (set) Token: 0x06000188 RID: 392 RVA: 0x00005B76 File Offset: 0x00003D76
		public Configuration Configuration
		{
			get
			{
				Configuration b = new Configuration("https://relay-allocations.services.api.unity.com", new int?(10), new int?(4), null);
				return Configuration.MergeConfigurations(this._configuration, b);
			}
			set
			{
				this._configuration = value;
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00005B7F File Offset: 0x00003D7F
		public RelayAllocationsApiClient(IHttpClient httpClient, IAccessToken accessToken, Configuration configuration = null) : base(httpClient)
		{
			this._configuration = configuration;
			this._accessToken = accessToken;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00005B98 File Offset: 0x00003D98
		public Task<Response<AllocateResponseBody>> CreateAllocationAsync(CreateAllocationRequest request, Configuration operationConfiguration = null)
		{
			RelayAllocationsApiClient.<CreateAllocationAsync>d__7 <CreateAllocationAsync>d__;
			<CreateAllocationAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<AllocateResponseBody>>.Create();
			<CreateAllocationAsync>d__.<>4__this = this;
			<CreateAllocationAsync>d__.request = request;
			<CreateAllocationAsync>d__.operationConfiguration = operationConfiguration;
			<CreateAllocationAsync>d__.<>1__state = -1;
			<CreateAllocationAsync>d__.<>t__builder.Start<RelayAllocationsApiClient.<CreateAllocationAsync>d__7>(ref <CreateAllocationAsync>d__);
			return <CreateAllocationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00005BEC File Offset: 0x00003DEC
		public Task<Response<JoinCodeResponseBody>> CreateJoincodeAsync(CreateJoincodeRequest request, Configuration operationConfiguration = null)
		{
			RelayAllocationsApiClient.<CreateJoincodeAsync>d__8 <CreateJoincodeAsync>d__;
			<CreateJoincodeAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<JoinCodeResponseBody>>.Create();
			<CreateJoincodeAsync>d__.<>4__this = this;
			<CreateJoincodeAsync>d__.request = request;
			<CreateJoincodeAsync>d__.operationConfiguration = operationConfiguration;
			<CreateJoincodeAsync>d__.<>1__state = -1;
			<CreateJoincodeAsync>d__.<>t__builder.Start<RelayAllocationsApiClient.<CreateJoincodeAsync>d__8>(ref <CreateJoincodeAsync>d__);
			return <CreateJoincodeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00005C40 File Offset: 0x00003E40
		public Task<Response<JoinResponseBody>> JoinRelayAsync(JoinRelayRequest request, Configuration operationConfiguration = null)
		{
			RelayAllocationsApiClient.<JoinRelayAsync>d__9 <JoinRelayAsync>d__;
			<JoinRelayAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<JoinResponseBody>>.Create();
			<JoinRelayAsync>d__.<>4__this = this;
			<JoinRelayAsync>d__.request = request;
			<JoinRelayAsync>d__.operationConfiguration = operationConfiguration;
			<JoinRelayAsync>d__.<>1__state = -1;
			<JoinRelayAsync>d__.<>t__builder.Start<RelayAllocationsApiClient.<JoinRelayAsync>d__9>(ref <JoinRelayAsync>d__);
			return <JoinRelayAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00005C94 File Offset: 0x00003E94
		public Task<Response<RegionsResponseBody>> ListRegionsAsync(ListRegionsRequest request, Configuration operationConfiguration = null)
		{
			RelayAllocationsApiClient.<ListRegionsAsync>d__10 <ListRegionsAsync>d__;
			<ListRegionsAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Response<RegionsResponseBody>>.Create();
			<ListRegionsAsync>d__.<>4__this = this;
			<ListRegionsAsync>d__.request = request;
			<ListRegionsAsync>d__.operationConfiguration = operationConfiguration;
			<ListRegionsAsync>d__.<>1__state = -1;
			<ListRegionsAsync>d__.<>t__builder.Start<RelayAllocationsApiClient.<ListRegionsAsync>d__10>(ref <ListRegionsAsync>d__);
			return <ListRegionsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x040000B0 RID: 176
		private IAccessToken _accessToken;

		// Token: 0x040000B1 RID: 177
		private const int _baseTimeout = 10;

		// Token: 0x040000B2 RID: 178
		private Configuration _configuration;
	}
}
