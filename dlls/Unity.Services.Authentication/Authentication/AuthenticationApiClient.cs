using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.Services.Authentication.Shared;
using UnityEngine.Networking;

namespace Unity.Services.Authentication
{
	// Token: 0x02000045 RID: 69
	internal class AuthenticationApiClient : IApiClient
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x00005396 File Offset: 0x00003596
		private INetworkConfiguration Configuration { get; }

		// Token: 0x060001A8 RID: 424 RVA: 0x0000539E File Offset: 0x0000359E
		public AuthenticationApiClient(INetworkConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x000053AD File Offset: 0x000035AD
		public Task<ApiResponse> GetAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SendAsync(path, WebRequestVerb.Get, options, configuration, cancellationToken);
		}

		// Token: 0x060001AA RID: 426 RVA: 0x000053BB File Offset: 0x000035BB
		public Task<ApiResponse<T>> GetAsync<T>(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SendAsync<T>(path, WebRequestVerb.Get, options, configuration, cancellationToken);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x000053C9 File Offset: 0x000035C9
		public Task<ApiResponse> PostAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SendAsync(path, WebRequestVerb.Post, options, configuration, cancellationToken);
		}

		// Token: 0x060001AC RID: 428 RVA: 0x000053D7 File Offset: 0x000035D7
		public Task<ApiResponse<T>> PostAsync<T>(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SendAsync<T>(path, WebRequestVerb.Post, options, configuration, cancellationToken);
		}

		// Token: 0x060001AD RID: 429 RVA: 0x000053E5 File Offset: 0x000035E5
		public Task<ApiResponse> PutAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SendAsync(path, WebRequestVerb.Put, options, configuration, cancellationToken);
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000053F3 File Offset: 0x000035F3
		public Task<ApiResponse<T>> PutAsync<T>(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SendAsync<T>(path, WebRequestVerb.Put, options, configuration, cancellationToken);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00005401 File Offset: 0x00003601
		public Task<ApiResponse> DeleteAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SendAsync(path, WebRequestVerb.Delete, options, configuration, cancellationToken);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000540F File Offset: 0x0000360F
		public Task<ApiResponse<T>> DeleteAsync<T>(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SendAsync<T>(path, WebRequestVerb.Delete, options, configuration, cancellationToken);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000541D File Offset: 0x0000361D
		public Task<ApiResponse> HeadAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SendAsync(path, WebRequestVerb.Head, options, configuration, cancellationToken);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000542B File Offset: 0x0000362B
		public Task<ApiResponse<T>> HeadAsync<T>(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SendAsync<T>(path, WebRequestVerb.Head, options, configuration, cancellationToken);
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00005439 File Offset: 0x00003639
		public Task<ApiResponse> OptionsAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SendAsync(path, WebRequestVerb.Options, options, configuration, cancellationToken);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00005447 File Offset: 0x00003647
		public Task<ApiResponse<T>> OptionsAsync<T>(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SendAsync<T>(path, WebRequestVerb.Options, options, configuration, cancellationToken);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00005455 File Offset: 0x00003655
		public Task<ApiResponse> PatchAsync(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SendAsync(path, WebRequestVerb.Patch, options, configuration, cancellationToken);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00005463 File Offset: 0x00003663
		public Task<ApiResponse<T>> PatchAsync<T>(string path, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SendAsync<T>(path, WebRequestVerb.Patch, options, configuration, cancellationToken);
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x00005474 File Offset: 0x00003674
		private Task<ApiResponse> SendAsync(string path, WebRequestVerb method, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			AuthenticationApiClient.<SendAsync>d__18 <SendAsync>d__;
			<SendAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ApiResponse>.Create();
			<SendAsync>d__.<>4__this = this;
			<SendAsync>d__.path = path;
			<SendAsync>d__.method = method;
			<SendAsync>d__.options = options;
			<SendAsync>d__.configuration = configuration;
			<SendAsync>d__.<>1__state = -1;
			<SendAsync>d__.<>t__builder.Start<AuthenticationApiClient.<SendAsync>d__18>(ref <SendAsync>d__);
			return <SendAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000054D8 File Offset: 0x000036D8
		private Task<ApiResponse<T>> SendAsync<T>(string path, WebRequestVerb method, ApiRequestOptions options, IApiConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			AuthenticationApiClient.<SendAsync>d__19<T> <SendAsync>d__;
			<SendAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ApiResponse<T>>.Create();
			<SendAsync>d__.<>4__this = this;
			<SendAsync>d__.path = path;
			<SendAsync>d__.method = method;
			<SendAsync>d__.options = options;
			<SendAsync>d__.configuration = configuration;
			<SendAsync>d__.cancellationToken = cancellationToken;
			<SendAsync>d__.<>1__state = -1;
			<SendAsync>d__.<>t__builder.Start<AuthenticationApiClient.<SendAsync>d__19<T>>(ref <SendAsync>d__);
			return <SendAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00005548 File Offset: 0x00003748
		internal UnityWebRequest BuildWebRequest(string path, WebRequestVerb method, ApiRequestOptions options, IApiConfiguration configuration)
		{
			ApiRequestPathBuilder apiRequestPathBuilder = new ApiRequestPathBuilder(configuration.BasePath, path);
			apiRequestPathBuilder.AddPathParameters(options.PathParameters);
			apiRequestPathBuilder.AddQueryParameters(options.QueryParameters);
			UnityWebRequest unityWebRequest = new UnityWebRequest(apiRequestPathBuilder.GetFullUri(), method.ToString());
			if (configuration.UserAgent != null)
			{
				unityWebRequest.SetRequestHeader("User-Agent", configuration.UserAgent);
			}
			if (configuration.DefaultHeaders != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in configuration.DefaultHeaders)
				{
					unityWebRequest.SetRequestHeader(keyValuePair.Key, keyValuePair.Value);
				}
			}
			if (options.HeaderParameters != null)
			{
				foreach (KeyValuePair<string, IList<string>> keyValuePair2 in options.HeaderParameters)
				{
					foreach (string value in keyValuePair2.Value)
					{
						unityWebRequest.SetRequestHeader(keyValuePair2.Key, value);
					}
				}
			}
			unityWebRequest.timeout = configuration.Timeout;
			if (options.Data != null)
			{
				JsonSerializerSettings settings = new JsonSerializerSettings
				{
					ReferenceLoopHandling = ReferenceLoopHandling.Ignore
				};
				string s = IsolatedJsonConvert.SerializeObject(options.Data, settings);
				unityWebRequest.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(s));
			}
			unityWebRequest.downloadHandler = new DownloadHandlerBuffer();
			return unityWebRequest;
		}
	}
}
