using System;
using System.Collections.Specialized;
using System.IO;
using UnityWebSocketSharp.Net;

namespace UnityWebSocketSharp
{
	// Token: 0x0200000C RID: 12
	internal class HttpResponse : HttpBase
	{
		// Token: 0x06000087 RID: 135 RVA: 0x00004024 File Offset: 0x00002224
		private HttpResponse(int code, string reason, Version version, NameValueCollection headers) : base(version, headers)
		{
			this._code = code;
			this._reason = reason;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000403D File Offset: 0x0000223D
		internal HttpResponse(int code) : this(code, code.GetStatusDescription())
		{
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000404C File Offset: 0x0000224C
		internal HttpResponse(HttpStatusCode code) : this((int)code)
		{
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00004055 File Offset: 0x00002255
		internal HttpResponse(int code, string reason) : this(code, reason, HttpVersion.Version11, new NameValueCollection())
		{
			base.Headers["Server"] = "websocket-sharp/1.0";
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000407E File Offset: 0x0000227E
		internal HttpResponse(HttpStatusCode code, string reason) : this((int)code, reason)
		{
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600008C RID: 140 RVA: 0x00004088 File Offset: 0x00002288
		internal string StatusLine
		{
			get
			{
				if (this._reason == null)
				{
					return string.Format("HTTP/{0} {1}{2}", base.ProtocolVersion, this._code, HttpBase.CrLf);
				}
				return string.Format("HTTP/{0} {1} {2}{3}", new object[]
				{
					base.ProtocolVersion,
					this._code,
					this._reason,
					HttpBase.CrLf
				});
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600008D RID: 141 RVA: 0x000040F8 File Offset: 0x000022F8
		public bool CloseConnection
		{
			get
			{
				StringComparison comparisonTypeForValue = StringComparison.OrdinalIgnoreCase;
				return base.Headers.Contains("Connection", "close", comparisonTypeForValue);
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600008E RID: 142 RVA: 0x0000411D File Offset: 0x0000231D
		public CookieCollection Cookies
		{
			get
			{
				return base.Headers.GetCookies(true);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600008F RID: 143 RVA: 0x0000412B File Offset: 0x0000232B
		public bool IsProxyAuthenticationRequired
		{
			get
			{
				return this._code == 407;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000090 RID: 144 RVA: 0x0000413A File Offset: 0x0000233A
		public bool IsRedirect
		{
			get
			{
				return this._code == 301 || this._code == 302;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00004158 File Offset: 0x00002358
		public bool IsSuccess
		{
			get
			{
				return this._code >= 200 && this._code <= 299;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00004179 File Offset: 0x00002379
		public bool IsUnauthorized
		{
			get
			{
				return this._code == 401;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00004188 File Offset: 0x00002388
		public bool IsWebSocketResponse
		{
			get
			{
				return base.ProtocolVersion > HttpVersion.Version10 && this._code == 101 && base.Headers.Upgrades("websocket");
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000094 RID: 148 RVA: 0x000041B8 File Offset: 0x000023B8
		public override string MessageHeader
		{
			get
			{
				return this.StatusLine + base.HeaderSection;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000095 RID: 149 RVA: 0x000041CB File Offset: 0x000023CB
		public string Reason
		{
			get
			{
				return this._reason;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000096 RID: 150 RVA: 0x000041D3 File Offset: 0x000023D3
		public int StatusCode
		{
			get
			{
				return this._code;
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000041DB File Offset: 0x000023DB
		internal static HttpResponse CreateCloseResponse(HttpStatusCode code)
		{
			HttpResponse httpResponse = new HttpResponse(code);
			httpResponse.Headers["Connection"] = "close";
			return httpResponse;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000041F8 File Offset: 0x000023F8
		internal static HttpResponse CreateUnauthorizedResponse(string challenge)
		{
			HttpResponse httpResponse = new HttpResponse(HttpStatusCode.Unauthorized);
			httpResponse.Headers["WWW-Authenticate"] = challenge;
			return httpResponse;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004215 File Offset: 0x00002415
		internal static HttpResponse CreateWebSocketHandshakeResponse()
		{
			HttpResponse httpResponse = new HttpResponse(HttpStatusCode.SwitchingProtocols);
			NameValueCollection headers = httpResponse.Headers;
			headers["Upgrade"] = "websocket";
			headers["Connection"] = "Upgrade";
			return httpResponse;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00004244 File Offset: 0x00002444
		internal static HttpResponse Parse(string[] messageHeader)
		{
			int num = messageHeader.Length;
			if (num == 0)
			{
				throw new ArgumentException("An empty response header.");
			}
			string[] array = messageHeader[0].Split(new char[]
			{
				' '
			}, 3);
			int num2 = array.Length;
			if (num2 < 2)
			{
				throw new ArgumentException("It includes an invalid status line.");
			}
			int code = array[1].ToInt32();
			string reason = (num2 == 3) ? array[2] : null;
			Version version = array[0].Substring(5).ToVersion();
			WebHeaderCollection webHeaderCollection = new WebHeaderCollection();
			for (int i = 1; i < num; i++)
			{
				webHeaderCollection.InternalSet(messageHeader[i], true);
			}
			return new HttpResponse(code, reason, version, webHeaderCollection);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000042DB File Offset: 0x000024DB
		internal static HttpResponse ReadResponse(Stream stream, int millisecondsTimeout)
		{
			return HttpBase.Read<HttpResponse>(stream, new Func<string[], HttpResponse>(HttpResponse.Parse), millisecondsTimeout);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000042F0 File Offset: 0x000024F0
		public void SetCookies(CookieCollection cookies)
		{
			if (cookies == null || cookies.Count == 0)
			{
				return;
			}
			NameValueCollection headers = base.Headers;
			foreach (Cookie cookie in cookies.Sorted)
			{
				string value = cookie.ToResponseString();
				headers.Add("Set-Cookie", value);
			}
		}

		// Token: 0x0400002A RID: 42
		private int _code;

		// Token: 0x0400002B RID: 43
		private string _reason;
	}
}
