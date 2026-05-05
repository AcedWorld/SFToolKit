using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Unity.Services.Qos.Http
{
	// Token: 0x0200006B RID: 107
	internal static class UnityWebRequestHelpers
	{
		// Token: 0x060001EF RID: 495 RVA: 0x00007B2C File Offset: 0x00005D2C
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

		// Token: 0x060001F0 RID: 496 RVA: 0x00007B6C File Offset: 0x00005D6C
		internal static HttpClientResponse CreateHttpClientResponse(UnityWebRequestAsyncOperation unityResponse)
		{
			UnityWebRequest webRequest = unityResponse.webRequest;
			return new HttpClientResponse(webRequest.GetResponseHeaders(), webRequest.responseCode, webRequest.result == UnityWebRequest.Result.ProtocolError, webRequest.result == UnityWebRequest.Result.ConnectionError, webRequest.downloadHandler.data, webRequest.error);
		}
	}
}
