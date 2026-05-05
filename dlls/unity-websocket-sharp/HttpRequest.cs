using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using UnityWebSocketSharp.Net;

namespace UnityWebSocketSharp
{
	// Token: 0x0200000B RID: 11
	internal class HttpRequest : HttpBase
	{
		// Token: 0x06000078 RID: 120 RVA: 0x00003CC7 File Offset: 0x00001EC7
		private HttpRequest(string method, string target, Version version, NameValueCollection headers) : base(version, headers)
		{
			this._method = method;
			this._target = target;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003CE0 File Offset: 0x00001EE0
		internal HttpRequest(string method, string target) : this(method, target, HttpVersion.Version11, new NameValueCollection())
		{
			base.Headers["User-Agent"] = "websocket-sharp/1.0";
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00003D09 File Offset: 0x00001F09
		internal string RequestLine
		{
			get
			{
				return string.Format("{0} {1} HTTP/{2}{3}", new object[]
				{
					this._method,
					this._target,
					base.ProtocolVersion,
					HttpBase.CrLf
				});
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00003D40 File Offset: 0x00001F40
		public AuthenticationResponse AuthenticationResponse
		{
			get
			{
				string text = base.Headers["Authorization"];
				if (text == null || text.Length <= 0)
				{
					return null;
				}
				return AuthenticationResponse.Parse(text);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00003D72 File Offset: 0x00001F72
		public CookieCollection Cookies
		{
			get
			{
				if (this._cookies == null)
				{
					this._cookies = base.Headers.GetCookies(false);
				}
				return this._cookies;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00003D94 File Offset: 0x00001F94
		public string HttpMethod
		{
			get
			{
				return this._method;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00003D9C File Offset: 0x00001F9C
		public bool IsWebSocketRequest
		{
			get
			{
				return this._method == "GET" && base.ProtocolVersion > HttpVersion.Version10 && base.Headers.Upgrades("websocket");
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00003DD4 File Offset: 0x00001FD4
		public override string MessageHeader
		{
			get
			{
				return this.RequestLine + base.HeaderSection;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00003DE7 File Offset: 0x00001FE7
		public string RequestTarget
		{
			get
			{
				return this._target;
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003DF0 File Offset: 0x00001FF0
		internal static HttpRequest CreateConnectRequest(Uri targetUri)
		{
			string dnsSafeHost = targetUri.DnsSafeHost;
			int port = targetUri.Port;
			string text = string.Format("{0}:{1}", dnsSafeHost, port);
			HttpRequest httpRequest = new HttpRequest("CONNECT", text);
			httpRequest.Headers["Host"] = ((port != 80) ? text : dnsSafeHost);
			return httpRequest;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003E44 File Offset: 0x00002044
		internal static HttpRequest CreateWebSocketHandshakeRequest(Uri targetUri)
		{
			HttpRequest httpRequest = new HttpRequest("GET", targetUri.PathAndQuery);
			NameValueCollection headers = httpRequest.Headers;
			int port = targetUri.Port;
			string scheme = targetUri.Scheme;
			bool flag = (port == 80 && scheme == "ws") || (port == 443 && scheme == "wss");
			headers["Host"] = ((!flag) ? targetUri.Authority : targetUri.DnsSafeHost);
			headers["Upgrade"] = "websocket";
			headers["Connection"] = "Upgrade";
			return httpRequest;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003EDC File Offset: 0x000020DC
		internal HttpResponse GetResponse(Stream stream, int millisecondsTimeout)
		{
			base.WriteTo(stream);
			return HttpResponse.ReadResponse(stream, millisecondsTimeout);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003EEC File Offset: 0x000020EC
		internal static HttpRequest Parse(string[] messageHeader)
		{
			int num = messageHeader.Length;
			if (num == 0)
			{
				throw new ArgumentException("An empty request header.");
			}
			string[] array = messageHeader[0].Split(new char[]
			{
				' '
			}, 3);
			if (array.Length != 3)
			{
				throw new ArgumentException("It includes an invalid request line.");
			}
			string method = array[0];
			string target = array[1];
			Version version = array[2].Substring(5).ToVersion();
			WebHeaderCollection webHeaderCollection = new WebHeaderCollection();
			for (int i = 1; i < num; i++)
			{
				webHeaderCollection.InternalSet(messageHeader[i], false);
			}
			return new HttpRequest(method, target, version, webHeaderCollection);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003F73 File Offset: 0x00002173
		internal static HttpRequest ReadRequest(Stream stream, int millisecondsTimeout)
		{
			return HttpBase.Read<HttpRequest>(stream, new Func<string[], HttpRequest>(HttpRequest.Parse), millisecondsTimeout);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003F88 File Offset: 0x00002188
		public void SetCookies(CookieCollection cookies)
		{
			if (cookies == null || cookies.Count == 0)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder(64);
			foreach (Cookie cookie in cookies.Sorted)
			{
				if (!cookie.Expired)
				{
					stringBuilder.AppendFormat("{0}; ", cookie);
				}
			}
			int length = stringBuilder.Length;
			if (length <= 2)
			{
				return;
			}
			stringBuilder.Length = length - 2;
			base.Headers["Cookie"] = stringBuilder.ToString();
		}

		// Token: 0x04000027 RID: 39
		private CookieCollection _cookies;

		// Token: 0x04000028 RID: 40
		private string _method;

		// Token: 0x04000029 RID: 41
		private string _target;
	}
}
