using System;
using System.Threading;
using System.Threading.Tasks;

namespace Unity.Services.Authentication.Shared
{
	// Token: 0x02000065 RID: 101
	internal interface IApiClient
	{
		// Token: 0x060002AF RID: 687
		Task<ApiResponse<T>> GetAsync<T>(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060002B0 RID: 688
		Task<ApiResponse> GetAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060002B1 RID: 689
		Task<ApiResponse<T>> PostAsync<T>(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060002B2 RID: 690
		Task<ApiResponse> PostAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060002B3 RID: 691
		Task<ApiResponse<T>> PutAsync<T>(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060002B4 RID: 692
		Task<ApiResponse> PutAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060002B5 RID: 693
		Task<ApiResponse<T>> DeleteAsync<T>(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060002B6 RID: 694
		Task<ApiResponse> DeleteAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060002B7 RID: 695
		Task<ApiResponse<T>> HeadAsync<T>(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060002B8 RID: 696
		Task<ApiResponse> HeadAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060002B9 RID: 697
		Task<ApiResponse<T>> OptionsAsync<T>(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060002BA RID: 698
		Task<ApiResponse> OptionsAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060002BB RID: 699
		Task<ApiResponse<T>> PatchAsync<T>(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = default(CancellationToken));

		// Token: 0x060002BC RID: 700
		Task<ApiResponse> PatchAsync(string path, ApiRequestOptions options, IApiConfiguration configuration = null, CancellationToken cancellationToken = default(CancellationToken));
	}
}
