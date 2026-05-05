using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000013 RID: 19
	internal class StandaloneBrowserUtils : IBrowserUtils
	{
		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600005F RID: 95 RVA: 0x00002C1C File Offset: 0x00000E1C
		// (remove) Token: 0x06000060 RID: 96 RVA: 0x00002C54 File Offset: 0x00000E54
		public event Action<string> AuthCodeReceivedEvent;

		// Token: 0x06000062 RID: 98 RVA: 0x00002C91 File Offset: 0x00000E91
		public string GetRedirectUri()
		{
			return string.Format("http://localhost:{0}/callback", this.m_BoundPort);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002CA8 File Offset: 0x00000EA8
		public bool Bind()
		{
			if (this.m_BoundPort != null)
			{
				return true;
			}
			HttpListener httpListener;
			int value;
			if (HttpUtilities.TryBindListenerOnFreePort(out httpListener, out value))
			{
				this.m_HttpListener = httpListener;
				this.m_BoundPort = new int?(value);
				return true;
			}
			return false;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002CE8 File Offset: 0x00000EE8
		public Task LaunchUrlAsync(string url)
		{
			StandaloneBrowserUtils.<LaunchUrlAsync>d__8 <LaunchUrlAsync>d__;
			<LaunchUrlAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<LaunchUrlAsync>d__.<>4__this = this;
			<LaunchUrlAsync>d__.url = url;
			<LaunchUrlAsync>d__.<>1__state = -1;
			<LaunchUrlAsync>d__.<>t__builder.Start<StandaloneBrowserUtils.<LaunchUrlAsync>d__8>(ref <LaunchUrlAsync>d__);
			return <LaunchUrlAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002D33 File Offset: 0x00000F33
		public void Dismiss()
		{
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00002D38 File Offset: 0x00000F38
		private static void SendBrowserResponse(HttpListenerResponse response, HttpListener http)
		{
			string s = "<html><body><b>DONE!</b><br>(You can return to your app and close this tab/window now)";
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			response.ContentLength64 = (long)bytes.Length;
			Stream responseOutput = response.OutputStream;
			responseOutput.WriteAsync(bytes, 0, bytes.Length).ContinueWith(delegate(Task _)
			{
				responseOutput.Close();
				http.Stop();
			});
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002D9C File Offset: 0x00000F9C
		private static string GetAuthCode(HttpListenerContext context, string state)
		{
			string text = context.Request.QueryString.Get("code");
			string text2 = context.Request.QueryString.Get("error");
			string text3 = context.Request.QueryString.Get("state");
			Uri uri = new Uri(context.Request.Url.AbsoluteUri);
			if (!string.IsNullOrEmpty(text2))
			{
				throw PlayerAccountsExceptionHandler.HandleError(text2, null, null);
			}
			if (string.IsNullOrEmpty(text))
			{
				Dictionary<string, string> dictionary = UriHelper.ParseQueryString(uri.Fragment);
				text = dictionary["code"];
				text3 = dictionary["state"];
			}
			if (text3 != state)
			{
				throw PlayerAccountsException.Create(10101, "Received request with invalid state (" + text3 + ")", null);
			}
			return text;
		}

		// Token: 0x04000043 RID: 67
		private HttpListener m_HttpListener;

		// Token: 0x04000044 RID: 68
		private int? m_BoundPort;
	}
}
