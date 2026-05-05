using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x02000059 RID: 89
	internal static class UnityWebRequestHelpers
	{
		// Token: 0x06000257 RID: 599 RVA: 0x000091B0 File Offset: 0x000073B0
		public static TaskAwaiter<HttpClientResponse> GetAwaiter(this UnityWebRequestAsyncOperation asyncOp)
		{
			TaskCompletionSource<HttpClientResponse> tcs = new TaskCompletionSource<HttpClientResponse>();
			asyncOp.completed += delegate(AsyncOperation obj)
			{
				HttpClientResponse result = UnityWebRequestHelpers.CreateHttpClientResponse((UnityWebRequestAsyncOperation)obj);
				tcs.SetResult(result);
			};
			return tcs.Task.GetAwaiter();
		}

		// Token: 0x06000258 RID: 600 RVA: 0x000091F0 File Offset: 0x000073F0
		internal static HttpClientResponse CreateHttpClientResponse(UnityWebRequestAsyncOperation unityResponse)
		{
			UnityWebRequest webRequest = unityResponse.webRequest;
			return new HttpClientResponse(webRequest.GetResponseHeaders(), webRequest.responseCode, webRequest.result == UnityWebRequest.Result.ProtocolError, webRequest.result == UnityWebRequest.Result.ConnectionError, webRequest.downloadHandler.data, webRequest.error);
		}
	}
}
