using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Unity.Services.Authentication
{
	// Token: 0x0200004C RID: 76
	internal class WebRequest
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001FD RID: 509 RVA: 0x0000605E File Offset: 0x0000425E
		internal INetworkConfiguration Configuration { get; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001FE RID: 510 RVA: 0x00006066 File Offset: 0x00004266
		// (set) Token: 0x060001FF RID: 511 RVA: 0x0000606E File Offset: 0x0000426E
		internal int Retries { get; private set; }

		// Token: 0x06000200 RID: 512 RVA: 0x00006078 File Offset: 0x00004278
		internal WebRequest(INetworkConfiguration configuration, WebRequestVerb verb, string url, IDictionary<string, string> headers, string payload, string payloadContentType)
		{
			this.Configuration = configuration;
			this.m_Verb = verb;
			this.m_Url = url;
			this.m_Headers = headers;
			this.m_Payload = payload;
			this.m_PayloadContentType = payloadContentType;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x000060CA File Offset: 0x000042CA
		internal Task SendAsync()
		{
			return this.SendAttemptAsync(new TaskCompletionSource<string>());
		}

		// Token: 0x06000202 RID: 514 RVA: 0x000060D8 File Offset: 0x000042D8
		internal Task<T> SendAsync<T>()
		{
			WebRequest.<SendAsync>d__15<T> <SendAsync>d__;
			<SendAsync>d__.<>t__builder = AsyncTaskMethodBuilder<T>.Create();
			<SendAsync>d__.<>4__this = this;
			<SendAsync>d__.<>1__state = -1;
			<SendAsync>d__.<>t__builder.Start<WebRequest.<SendAsync>d__15<T>>(ref <SendAsync>d__);
			return <SendAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000611C File Offset: 0x0000431C
		private Task<string> SendAttemptAsync(TaskCompletionSource<string> tcs)
		{
			try
			{
				UnityWebRequest request = this.Build();
				request.SendWebRequest().completed += delegate(AsyncOperation operation)
				{
					WebRequest <>4__this = this;
					TaskCompletionSource<string> tcs2 = tcs;
					long responseCode = request.responseCode;
					bool isNetworkError = this.RequestHasNetworkError(request);
					bool isServerError = this.RequestHasServerError(request);
					string error = request.error;
					DownloadHandler downloadHandler = request.downloadHandler;
					<>4__this.RequestCompleted(tcs2, responseCode, isNetworkError, isServerError, error, (downloadHandler != null) ? downloadHandler.text : null, request.GetResponseHeaders());
					request.Dispose();
				};
			}
			catch (Exception exception)
			{
				tcs.SetException(exception);
			}
			return tcs.Task;
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00006194 File Offset: 0x00004394
		internal UnityWebRequest Build()
		{
			UnityWebRequest unityWebRequest;
			switch (this.m_Verb)
			{
			case WebRequestVerb.Delete:
				unityWebRequest = UnityWebRequest.Delete(this.m_Url);
				unityWebRequest.downloadHandler = new DownloadHandlerBuffer();
				goto IL_129;
			case WebRequestVerb.Get:
				unityWebRequest = UnityWebRequest.Get(this.m_Url);
				goto IL_129;
			case WebRequestVerb.Post:
				if (string.IsNullOrEmpty(this.m_Payload))
				{
					unityWebRequest = UnityWebRequest.PostWwwForm(this.m_Url, string.Empty);
					goto IL_129;
				}
				unityWebRequest = new UnityWebRequest(this.m_Url, "POST")
				{
					uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(this.m_Payload)),
					downloadHandler = new DownloadHandlerBuffer()
				};
				goto IL_129;
			case WebRequestVerb.Put:
				if (string.IsNullOrEmpty(this.m_Payload))
				{
					throw new ArgumentException("PUT payload cannot be empty.");
				}
				unityWebRequest = new UnityWebRequest(this.m_Url, "PUT")
				{
					uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(this.m_Payload)),
					downloadHandler = new DownloadHandlerBuffer()
				};
				goto IL_129;
			}
			throw new ArgumentException("Unknown verb " + this.m_Verb.ToString());
			IL_129:
			if (!string.IsNullOrEmpty(this.m_PayloadContentType))
			{
				unityWebRequest.SetRequestHeader("Content-Type", this.m_PayloadContentType);
			}
			if (this.m_Headers != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in this.m_Headers)
				{
					unityWebRequest.SetRequestHeader(keyValuePair.Key, keyValuePair.Value);
				}
			}
			unityWebRequest.timeout = this.Configuration.Timeout;
			return unityWebRequest;
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00006350 File Offset: 0x00004550
		internal void RequestCompleted(TaskCompletionSource<string> tcs, long responseCode, bool isNetworkError, bool isServerError, string errorText, string bodyText, IDictionary<string, string> headers)
		{
			if (isNetworkError && this.Retries < this.Configuration.Retries)
			{
				Logger.LogWarning("Network error detected, retrying...");
				int retries = this.Retries;
				this.Retries = retries + 1;
				this.SendAttemptAsync(tcs);
				return;
			}
			if (isNetworkError || isServerError)
			{
				string text = (isServerError && !string.IsNullOrEmpty(bodyText)) ? bodyText : errorText;
				WebRequestException exception = new WebRequestException(isNetworkError, isServerError, false, responseCode, text, headers);
				tcs.SetException(exception);
				Logger.LogWarning("Request completed with error: " + text);
				return;
			}
			tcs.SetResult(bodyText);
		}

		// Token: 0x06000206 RID: 518 RVA: 0x000063DE File Offset: 0x000045DE
		private bool RequestHasServerError(UnityWebRequest request)
		{
			return request.responseCode >= 400L;
		}

		// Token: 0x06000207 RID: 519 RVA: 0x000063F1 File Offset: 0x000045F1
		private bool RequestHasNetworkError(UnityWebRequest request)
		{
			return request.result == UnityWebRequest.Result.ConnectionError && request.error != "Redirect limit exceeded";
		}

		// Token: 0x040000F9 RID: 249
		private readonly WebRequestVerb m_Verb;

		// Token: 0x040000FA RID: 250
		private readonly string m_Url;

		// Token: 0x040000FB RID: 251
		private readonly IDictionary<string, string> m_Headers;

		// Token: 0x040000FC RID: 252
		private readonly string m_Payload;

		// Token: 0x040000FD RID: 253
		private readonly string m_PayloadContentType;

		// Token: 0x040000FE RID: 254
		private readonly JsonSerializerSettings m_JsonSerializerSettings = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Ignore
		};
	}
}
