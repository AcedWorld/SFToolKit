using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Services.Relay.Models;

namespace Unity.Services.Relay
{
	// Token: 0x02000014 RID: 20
	internal class WrappedRelayService : IRelayService, IRelayServiceSDK, IRelayServiceSDKConfiguration
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002642 File Offset: 0x00000842
		// (set) Token: 0x06000037 RID: 55 RVA: 0x0000264A File Offset: 0x0000084A
		internal IRelayServiceSdk m_RelayService { get; set; }

		// Token: 0x06000038 RID: 56 RVA: 0x00002653 File Offset: 0x00000853
		internal WrappedRelayService(IRelayServiceSdk relayService)
		{
			this.m_RelayService = relayService;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002664 File Offset: 0x00000864
		public Task<Allocation> CreateAllocationAsync(int maxConnections, string region = null)
		{
			WrappedRelayService.<CreateAllocationAsync>d__6 <CreateAllocationAsync>d__;
			<CreateAllocationAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Allocation>.Create();
			<CreateAllocationAsync>d__.<>4__this = this;
			<CreateAllocationAsync>d__.maxConnections = maxConnections;
			<CreateAllocationAsync>d__.region = region;
			<CreateAllocationAsync>d__.<>1__state = -1;
			<CreateAllocationAsync>d__.<>t__builder.Start<WrappedRelayService.<CreateAllocationAsync>d__6>(ref <CreateAllocationAsync>d__);
			return <CreateAllocationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000026B8 File Offset: 0x000008B8
		public Task<string> GetJoinCodeAsync(Guid allocationId)
		{
			WrappedRelayService.<GetJoinCodeAsync>d__7 <GetJoinCodeAsync>d__;
			<GetJoinCodeAsync>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<GetJoinCodeAsync>d__.<>4__this = this;
			<GetJoinCodeAsync>d__.allocationId = allocationId;
			<GetJoinCodeAsync>d__.<>1__state = -1;
			<GetJoinCodeAsync>d__.<>t__builder.Start<WrappedRelayService.<GetJoinCodeAsync>d__7>(ref <GetJoinCodeAsync>d__);
			return <GetJoinCodeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002704 File Offset: 0x00000904
		public Task<JoinAllocation> JoinAllocationAsync(string joinCode)
		{
			WrappedRelayService.<JoinAllocationAsync>d__8 <JoinAllocationAsync>d__;
			<JoinAllocationAsync>d__.<>t__builder = AsyncTaskMethodBuilder<JoinAllocation>.Create();
			<JoinAllocationAsync>d__.<>4__this = this;
			<JoinAllocationAsync>d__.joinCode = joinCode;
			<JoinAllocationAsync>d__.<>1__state = -1;
			<JoinAllocationAsync>d__.<>t__builder.Start<WrappedRelayService.<JoinAllocationAsync>d__8>(ref <JoinAllocationAsync>d__);
			return <JoinAllocationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002750 File Offset: 0x00000950
		public Task<List<Region>> ListRegionsAsync()
		{
			WrappedRelayService.<ListRegionsAsync>d__9 <ListRegionsAsync>d__;
			<ListRegionsAsync>d__.<>t__builder = AsyncTaskMethodBuilder<List<Region>>.Create();
			<ListRegionsAsync>d__.<>4__this = this;
			<ListRegionsAsync>d__.<>1__state = -1;
			<ListRegionsAsync>d__.<>t__builder.Start<WrappedRelayService.<ListRegionsAsync>d__9>(ref <ListRegionsAsync>d__);
			return <ListRegionsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002793 File Offset: 0x00000993
		public void SetAllocationsServiceBasePath(string allocationsBasePath)
		{
			this.m_RelayService.Configuration.BasePath = allocationsBasePath;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000027A6 File Offset: 0x000009A6
		private void EnsureSignedIn()
		{
			if (this.m_RelayService.AccessToken.AccessToken == null)
			{
				throw new RelayServiceException(RelayExceptionReason.Unauthorized, "You are not signed in to the Authentication Service. Please sign in.");
			}
		}

		// Token: 0x04000047 RID: 71
		private const string QosRelayServiceName = "relay";
	}
}
