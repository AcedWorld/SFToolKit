using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Unity.Services.Qos.V2.Http
{
	// Token: 0x0200003B RID: 59
	internal static class UnityWebRequestHelpers
	{
		// Token: 0x060000F7 RID: 247 RVA: 0x00005560 File Offset: 0x00003760
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

		// Token: 0x060000F8 RID: 248 RVA: 0x000055A0 File Offset: 0x000037A0
		internal static HttpClientResponse CreateHttpClientResponse(UnityWebRequestAsyncOperation unityResponse)
		{
			UnityWebRequest webRequest = unityResponse.webRequest;
			return new HttpClientResponse(webRequest.GetResponseHeaders(), webRequest.responseCode, webRequest.result == UnityWebRequest.Result.ProtocolError, webRequest.result == UnityWebRequest.Result.ConnectionError, webRequest.downloadHandler.data, webRequest.error);
		}
	}
}
