using System;
using System.Threading;
using System.Threading.Tasks;
using Unity.Services.Authentication.Shared;
using UnityEngine;
using UnityEngine.Networking;

namespace Unity.Services.Authentication
{
	// Token: 0x02000047 RID: 71
	internal static class AuthenticationWebRequestUtils
	{
		// Token: 0x060001D5 RID: 469 RVA: 0x00005B88 File Offset: 0x00003D88
		public static Task<ApiResponse> SendWebRequestAsync(this UnityWebRequest request)
		{
			TaskCompletionSource<ApiResponse> tcs = new TaskCompletionSource<ApiResponse>();
			UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = request.SendWebRequest();
			if (unityWebRequestAsyncOperation.isDone)
			{
				AuthenticationWebRequestUtils.ProcessResponse(tcs, request);
			}
			else
			{
				unityWebRequestAsyncOperation.completed += delegate(AsyncOperation asyncOperation)
				{
					AuthenticationWebRequestUtils.ProcessResponse(tcs, request);
				};
			}
			return tcs.Task;
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00005BF4 File Offset: 0x00003DF4
		public static Task<ApiResponse<T>> SendWebRequestAsync<T>(this UnityWebRequest request, CancellationToken cancellationToken)
		{
			TaskCompletionSource<ApiResponse<T>> tcs = new TaskCompletionSource<ApiResponse<T>>();
			cancellationToken.Register(delegate()
			{
				tcs.SetCanceled();
			});
			UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = request.SendWebRequest();
			if (unityWebRequestAsyncOperation.isDone)
			{
				AuthenticationWebRequestUtils.ProcessResponse<T>(tcs, request);
			}
			else
			{
				unityWebRequestAsyncOperation.completed += delegate(AsyncOperation asyncOperation)
				{
					AuthenticationWebRequestUtils.ProcessResponse<T>(tcs, request);
				};
			}
			return tcs.Task;
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00005C74 File Offset: 0x00003E74
		private static void ProcessResponse(TaskCompletionSource<ApiResponse> tcs, UnityWebRequest request)
		{
			ApiResponse apiResponse = new ApiResponse();
			apiResponse.StatusCode = (int)request.responseCode;
			apiResponse.ErrorText = request.error;
			DownloadHandler downloadHandler = request.downloadHandler;
			apiResponse.RawContent = ((downloadHandler != null) ? downloadHandler.text : null);
			ApiResponse apiResponse2 = apiResponse;
			string error = request.error;
			string str = "\n";
			DownloadHandler downloadHandler2 = request.downloadHandler;
			string message = error + str + ((downloadHandler2 != null) ? downloadHandler2.text : null);
			if (AuthenticationWebRequestUtils.IsNetworkError(request))
			{
				tcs.SetException(new ApiException(ApiExceptionType.Network, message, apiResponse2));
				return;
			}
			if (AuthenticationWebRequestUtils.IsHttpError(request))
			{
				tcs.SetException(new ApiException(ApiExceptionType.Http, message, apiResponse2));
				return;
			}
			tcs.SetResult(apiResponse2);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00005D10 File Offset: 0x00003F10
		private static void ProcessResponse<T>(TaskCompletionSource<ApiResponse<T>> tcs, UnityWebRequest request)
		{
			ApiResponse<T> apiResponse = new ApiResponse<T>();
			apiResponse.StatusCode = (int)request.responseCode;
			apiResponse.ErrorText = request.error;
			DownloadHandler downloadHandler = request.downloadHandler;
			apiResponse.RawContent = ((downloadHandler != null) ? downloadHandler.text : null);
			ApiResponse<T> apiResponse2 = apiResponse;
			string error = request.error;
			string str = "\n";
			DownloadHandler downloadHandler2 = request.downloadHandler;
			string message = error + str + ((downloadHandler2 != null) ? downloadHandler2.text : null);
			if (AuthenticationWebRequestUtils.IsNetworkError(request))
			{
				tcs.SetException(new ApiException(ApiExceptionType.Network, message, apiResponse2));
				return;
			}
			if (AuthenticationWebRequestUtils.IsHttpError(request))
			{
				tcs.SetException(new ApiException(ApiExceptionType.Http, message, apiResponse2));
				return;
			}
			try
			{
				DownloadHandler downloadHandler3 = request.downloadHandler;
				if (!string.IsNullOrEmpty((downloadHandler3 != null) ? downloadHandler3.text : null))
				{
					ApiResponse<T> apiResponse3 = apiResponse2;
					DownloadHandler downloadHandler4 = request.downloadHandler;
					apiResponse3.Data = IsolatedJsonConvert.DeserializeObject<T>((downloadHandler4 != null) ? downloadHandler4.text : null, SerializerSettings.DefaultSerializerSettings);
				}
			}
			catch (Exception)
			{
				tcs.SetException(new ApiException(ApiExceptionType.Deserialization, string.Format("Deserialization of type '{0}' failed.", typeof(T)), apiResponse2));
				return;
			}
			tcs.SetResult(apiResponse2);
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00005E20 File Offset: 0x00004020
		public static bool IsNetworkError(UnityWebRequest request)
		{
			return request.responseCode >= 500L;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00005E33 File Offset: 0x00004033
		public static bool IsHttpError(UnityWebRequest request)
		{
			return request.responseCode >= 400L && request.responseCode < 500L;
		}
	}
}
