using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x0200004C RID: 76
	internal class HttpClient : IHttpClient
	{
		// Token: 0x06000213 RID: 531 RVA: 0x000082B8 File Offset: 0x000064B8
		public Task<HttpClientResponse> MakeRequestAsync(string method, string url, byte[] body, Dictionary<string, string> headers, int requestTimeout)
		{
			HttpClient.<MakeRequestAsync>d__1 <MakeRequestAsync>d__;
			<MakeRequestAsync>d__.<>t__builder = AsyncTaskMethodBuilder<HttpClientResponse>.Create();
			<MakeRequestAsync>d__.<>4__this = this;
			<MakeRequestAsync>d__.method = method;
			<MakeRequestAsync>d__.url = url;
			<MakeRequestAsync>d__.body = body;
			<MakeRequestAsync>d__.headers = headers;
			<MakeRequestAsync>d__.requestTimeout = requestTimeout;
			<MakeRequestAsync>d__.<>1__state = -1;
			<MakeRequestAsync>d__.<>t__builder.Start<HttpClient.<MakeRequestAsync>d__1>(ref <MakeRequestAsync>d__);
			return <MakeRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00008328 File Offset: 0x00006528
		public Task<HttpClientResponse> MakeRequestAsync(string method, string url, List<IMultipartFormSection> body, Dictionary<string, string> headers, int requestTimeout, string boundary = null)
		{
			HttpClient.<MakeRequestAsync>d__2 <MakeRequestAsync>d__;
			<MakeRequestAsync>d__.<>t__builder = AsyncTaskMethodBuilder<HttpClientResponse>.Create();
			<MakeRequestAsync>d__.<>4__this = this;
			<MakeRequestAsync>d__.method = method;
			<MakeRequestAsync>d__.url = url;
			<MakeRequestAsync>d__.body = body;
			<MakeRequestAsync>d__.headers = headers;
			<MakeRequestAsync>d__.requestTimeout = requestTimeout;
			<MakeRequestAsync>d__.boundary = boundary;
			<MakeRequestAsync>d__.<>1__state = -1;
			<MakeRequestAsync>d__.<>t__builder.Start<HttpClient.<MakeRequestAsync>d__2>(ref <MakeRequestAsync>d__);
			return <MakeRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x000083A0 File Offset: 0x000065A0
		private Task<HttpClientResponse> CreateWebRequestAsync(string method, string url, byte[] body, IDictionary<string, string> headers, int requestTimeout)
		{
			HttpClient.<CreateWebRequestAsync>d__3 <CreateWebRequestAsync>d__;
			<CreateWebRequestAsync>d__.<>t__builder = AsyncTaskMethodBuilder<HttpClientResponse>.Create();
			<CreateWebRequestAsync>d__.<>4__this = this;
			<CreateWebRequestAsync>d__.method = method;
			<CreateWebRequestAsync>d__.url = url;
			<CreateWebRequestAsync>d__.body = body;
			<CreateWebRequestAsync>d__.headers = headers;
			<CreateWebRequestAsync>d__.requestTimeout = requestTimeout;
			<CreateWebRequestAsync>d__.<>1__state = -1;
			<CreateWebRequestAsync>d__.<>t__builder.Start<HttpClient.<CreateWebRequestAsync>d__3>(ref <CreateWebRequestAsync>d__);
			return <CreateWebRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00008410 File Offset: 0x00006610
		private Task<HttpClientResponse> CreateHttpClientResponse(string method, string url, byte[] body, IDictionary<string, string> headers, int requestTimeout)
		{
			HttpClient.<CreateHttpClientResponse>d__4 <CreateHttpClientResponse>d__;
			<CreateHttpClientResponse>d__.<>t__builder = AsyncTaskMethodBuilder<HttpClientResponse>.Create();
			<CreateHttpClientResponse>d__.<>4__this = this;
			<CreateHttpClientResponse>d__.method = method;
			<CreateHttpClientResponse>d__.url = url;
			<CreateHttpClientResponse>d__.body = body;
			<CreateHttpClientResponse>d__.headers = headers;
			<CreateHttpClientResponse>d__.requestTimeout = requestTimeout;
			<CreateHttpClientResponse>d__.<>1__state = -1;
			<CreateHttpClientResponse>d__.<>t__builder.Start<HttpClient.<CreateHttpClientResponse>d__4>(ref <CreateHttpClientResponse>d__);
			return <CreateHttpClientResponse>d__.<>t__builder.Task;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00008480 File Offset: 0x00006680
		private Task<HttpClientResponse> CreateWebRequestAsync(string method, string url, List<IMultipartFormSection> body, IDictionary<string, string> headers, int requestTimeout, string boundary = null)
		{
			HttpClient.<CreateWebRequestAsync>d__5 <CreateWebRequestAsync>d__;
			<CreateWebRequestAsync>d__.<>t__builder = AsyncTaskMethodBuilder<HttpClientResponse>.Create();
			<CreateWebRequestAsync>d__.<>4__this = this;
			<CreateWebRequestAsync>d__.method = method;
			<CreateWebRequestAsync>d__.url = url;
			<CreateWebRequestAsync>d__.body = body;
			<CreateWebRequestAsync>d__.headers = headers;
			<CreateWebRequestAsync>d__.requestTimeout = requestTimeout;
			<CreateWebRequestAsync>d__.boundary = boundary;
			<CreateWebRequestAsync>d__.<>1__state = -1;
			<CreateWebRequestAsync>d__.<>t__builder.Start<HttpClient.<CreateWebRequestAsync>d__5>(ref <CreateWebRequestAsync>d__);
			return <CreateWebRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000218 RID: 536 RVA: 0x000084F8 File Offset: 0x000066F8
		private static UnityWebRequest SetupMultipartRequest(UnityWebRequest request, List<IMultipartFormSection> multipartFormSections, byte[] boundary)
		{
			byte[] data = null;
			if (multipartFormSections != null && multipartFormSections.Count != 0)
			{
				data = UnityWebRequest.SerializeFormSections(multipartFormSections, boundary);
			}
			request.uploadHandler = new UploadHandlerRaw(data)
			{
				contentType = "multipart/form-data; boundary=" + Encoding.UTF8.GetString(boundary, 0, boundary.Length)
			};
			request.downloadHandler = new DownloadHandlerBuffer();
			return request;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00008554 File Offset: 0x00006754
		private UnityWebRequestAsyncOperation SendWebRequest(UnityWebRequest request)
		{
			return request.SendWebRequest();
		}
	}
}
