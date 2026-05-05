using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Unity.Services.Relay.Http
{
	// Token: 0x02000041 RID: 65
	internal static class UnityWebRequestHelpers
	{
		// Token: 0x06000111 RID: 273 RVA: 0x00004BCC File Offset: 0x00002DCC
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

		// Token: 0x06000112 RID: 274 RVA: 0x00004C0C File Offset: 0x00002E0C
		internal static HttpClientResponse CreateHttpClientResponse(UnityWebRequestAsyncOperation unityResponse)
		{
			UnityWebRequest webRequest = unityResponse.webRequest;
			return new HttpClientResponse(webRequest.GetResponseHeaders(), webRequest.responseCode, webRequest.result == UnityWebRequest.Result.ProtocolError, webRequest.result == UnityWebRequest.Result.ConnectionError, webRequest.downloadHandler.data, webRequest.error);
		}
	}
}
