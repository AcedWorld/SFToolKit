using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Unity.Services.Authentication.Shared;

namespace Unity.Services.Authentication.Generated
{
	// Token: 0x0200006A RID: 106
	internal class PlayerNamesApi : IPlayerNamesApi, IApiAccessor
	{
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002ED RID: 749 RVA: 0x0000773F File Offset: 0x0000593F
		public IApiClient Client { get; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00007747 File Offset: 0x00005947
		public IApiConfiguration Configuration { get; }

		// Token: 0x060002EF RID: 751 RVA: 0x0000774F File Offset: 0x0000594F
		public PlayerNamesApi(IApiClient apiClient)
		{
			if (apiClient == null)
			{
				throw new ArgumentNullException("apiClient");
			}
			this.Client = apiClient;
			this.Configuration = new ApiConfiguration
			{
				BasePath = "https://social.services.api.unity.com/v1"
			};
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00007782 File Offset: 0x00005982
		public PlayerNamesApi(IApiClient apiClient, IApiConfiguration apiConfiguration)
		{
			if (apiClient == null)
			{
				throw new ArgumentNullException("apiClient");
			}
			if (apiConfiguration == null)
			{
				throw new ArgumentNullException("apiConfiguration");
			}
			this.Client = apiClient;
			this.Configuration = apiConfiguration;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x000077B4 File Offset: 0x000059B4
		public string GetBasePath()
		{
			return this.Configuration.BasePath;
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x000077C4 File Offset: 0x000059C4
		public Task<ApiResponse<Player>> GetNameAsync(string playerId, bool? autoGenerate = null, bool? showMetadata = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			PlayerNamesApi.<GetNameAsync>d__9 <GetNameAsync>d__;
			<GetNameAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ApiResponse<Player>>.Create();
			<GetNameAsync>d__.<>4__this = this;
			<GetNameAsync>d__.playerId = playerId;
			<GetNameAsync>d__.autoGenerate = autoGenerate;
			<GetNameAsync>d__.showMetadata = showMetadata;
			<GetNameAsync>d__.cancellationToken = cancellationToken;
			<GetNameAsync>d__.<>1__state = -1;
			<GetNameAsync>d__.<>t__builder.Start<PlayerNamesApi.<GetNameAsync>d__9>(ref <GetNameAsync>d__);
			return <GetNameAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00007828 File Offset: 0x00005A28
		public Task<ApiResponse<Player>> UpdateNameAsync(string playerId, UpdateNameRequest updateNameRequest, CancellationToken cancellationToken = default(CancellationToken))
		{
			PlayerNamesApi.<UpdateNameAsync>d__10 <UpdateNameAsync>d__;
			<UpdateNameAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ApiResponse<Player>>.Create();
			<UpdateNameAsync>d__.<>4__this = this;
			<UpdateNameAsync>d__.playerId = playerId;
			<UpdateNameAsync>d__.updateNameRequest = updateNameRequest;
			<UpdateNameAsync>d__.cancellationToken = cancellationToken;
			<UpdateNameAsync>d__.<>1__state = -1;
			<UpdateNameAsync>d__.<>t__builder.Start<PlayerNamesApi.<UpdateNameAsync>d__10>(ref <UpdateNameAsync>d__);
			return <UpdateNameAsync>d__.<>t__builder.Task;
		}
	}
}
