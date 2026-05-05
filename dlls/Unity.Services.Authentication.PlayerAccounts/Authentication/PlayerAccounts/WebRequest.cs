using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000020 RID: 32
	internal class WebRequest
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000098 RID: 152 RVA: 0x0000342B File Offset: 0x0000162B
		internal INetworkConfiguration Configuration { get; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00003433 File Offset: 0x00001633
		// (set) Token: 0x0600009A RID: 154 RVA: 0x0000343B File Offset: 0x0000163B
		internal int Retries { get; private set; }

		// Token: 0x0600009B RID: 155 RVA: 0x00003444 File Offset: 0x00001644
		internal WebRequest(INetworkConfiguration configuration, WebRequestVerb verb, string url, IDictionary<string, string> headers, string payload, string payloadContentType)
		{
			this.Configuration = configuration;
			this.m_Verb = verb;
			this.m_Url = url;
			this.m_Headers = headers;
			this.m_Payload = payload;
			this.m_PayloadContentType = payloadContentType;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003496 File Offset: 0x00001696
		internal Task SendAsync()
		{
			return this.SendAttemptAsync(new TaskCompletionSource<string>());
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000034A4 File Offset: 0x000016A4
		internal Task<T> SendAsync<T>()
		{
			WebRequest.<SendAsync>d__15<T> <SendAsync>d__;
			<SendAsync>d__.<>t__builder = AsyncTaskMethodBuilder<T>.Create();
			<SendAsync>d__.<>4__this = this;
			<SendAsync>d__.<>1__state = -1;
			<SendAsync>d__.<>t__builder.Start<WebRequest.<SendAsync>d__15<T>>(ref <SendAsync>d__);
			return <SendAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000034E8 File Offset: 0x000016E8
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

		// Token: 0x0600009F RID: 159 RVA: 0x00003560 File Offset: 0x00001760
		internal UnityWebRequest Build()
		{
			UnityWebRequest unityWebRequest;
			switch (this.m_Verb)
			{
			case WebRequestVerb.Get:
				unityWebRequest = UnityWebRequest.Get(this.m_Url);
				break;
			case WebRequestVerb.Post:
				if (string.IsNullOrEmpty(this.m_Payload))
				{
					unityWebRequest = UnityWebRequest.PostWwwForm(this.m_Url, string.Empty);
				}
				else
				{
					unityWebRequest = new UnityWebRequest(this.m_Url, "POST")
					{
						uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(this.m_Payload)),
						downloadHandler = new DownloadHandlerBuffer()
					};
				}
				break;
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
				break;
			case WebRequestVerb.Delete:
				unityWebRequest = UnityWebRequest.Delete(this.m_Url);
				unityWebRequest.downloadHandler = new DownloadHandlerBuffer();
				break;
			default:
				throw new ArgumentException("Unknown verb " + this.m_Verb.ToString());
			}
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

		// Token: 0x060000A0 RID: 160 RVA: 0x00003710 File Offset: 0x00001910
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

		// Token: 0x060000A1 RID: 161 RVA: 0x0000379E File Offset: 0x0000199E
		private bool RequestHasServerError(UnityWebRequest request)
		{
			return request.responseCode >= 400L;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000037B1 File Offset: 0x000019B1
		private bool RequestHasNetworkError(UnityWebRequest request)
		{
			return request.result == UnityWebRequest.Result.ConnectionError && request.error != "Redirect limit exceeded";
		}

		// Token: 0x0400005D RID: 93
		private readonly WebRequestVerb m_Verb;

		// Token: 0x0400005E RID: 94
		private readonly string m_Url;

		// Token: 0x0400005F RID: 95
		private readonly IDictionary<string, string> m_Headers;

		// Token: 0x04000060 RID: 96
		private readonly string m_Payload;

		// Token: 0x04000061 RID: 97
		private readonly string m_PayloadContentType;

		// Token: 0x04000062 RID: 98
		private readonly JsonSerializerSettings m_JsonSerializerSettings = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Ignore
		};
	}
}
