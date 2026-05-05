using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using WebSocketSharp.Net;

namespace WebSocketSharp
{
	// Token: 0x02000017 RID: 23
	internal class HttpResponse : HttpBase
	{
		// Token: 0x0600018D RID: 397 RVA: 0x0000B3DF File Offset: 0x000095DF
		private HttpResponse(string code, string reason, Version version, NameValueCollection headers) : base(version, headers)
		{
			this._code = code;
			this._reason = reason;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000B3FA File Offset: 0x000095FA
		internal HttpResponse(HttpStatusCode code) : this(code, code.GetDescription())
		{
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000B40C File Offset: 0x0000960C
		internal HttpResponse(HttpStatusCode code, string reason)
		{
			int num = (int)code;
			this..ctor(num.ToString(), reason, HttpVersion.Version11, new NameValueCollection());
			base.Headers["Server"] = "websocket-sharp/1.0";
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000190 RID: 400 RVA: 0x0000B44C File Offset: 0x0000964C
		public CookieCollection Cookies
		{
			get
			{
				return base.Headers.GetCookies(true);
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000191 RID: 401 RVA: 0x0000B46C File Offset: 0x0000966C
		public bool HasConnectionClose
		{
			get
			{
				StringComparison comparisonTypeForValue = StringComparison.OrdinalIgnoreCase;
				return base.Headers.Contains("Connection", "close", comparisonTypeForValue);
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000192 RID: 402 RVA: 0x0000B498 File Offset: 0x00009698
		public bool IsProxyAuthenticationRequired
		{
			get
			{
				return this._code == "407";
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000193 RID: 403 RVA: 0x0000B4BC File Offset: 0x000096BC
		public bool IsRedirect
		{
			get
			{
				return this._code == "301" || this._code == "302";
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000194 RID: 404 RVA: 0x0000B4F4 File Offset: 0x000096F4
		public bool IsUnauthorized
		{
			get
			{
				return this._code == "401";
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000195 RID: 405 RVA: 0x0000B518 File Offset: 0x00009718
		public bool IsWebSocketResponse
		{
			get
			{
				return base.ProtocolVersion > HttpVersion.Version10 && this._code == "101" && base.Headers.Upgrades("websocket");
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000196 RID: 406 RVA: 0x0000B564 File Offset: 0x00009764
		public string Reason
		{
			get
			{
				return this._reason;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000197 RID: 407 RVA: 0x0000B57C File Offset: 0x0000977C
		public string StatusCode
		{
			get
			{
				return this._code;
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000B594 File Offset: 0x00009794
		internal static HttpResponse CreateCloseResponse(HttpStatusCode code)
		{
			HttpResponse httpResponse = new HttpResponse(code);
			httpResponse.Headers["Connection"] = "close";
			return httpResponse;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000B5C4 File Offset: 0x000097C4
		internal static HttpResponse CreateUnauthorizedResponse(string challenge)
		{
			HttpResponse httpResponse = new HttpResponse(HttpStatusCode.Unauthorized);
			httpResponse.Headers["WWW-Authenticate"] = challenge;
			return httpResponse;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000B5F4 File Offset: 0x000097F4
		internal static HttpResponse CreateWebSocketResponse()
		{
			HttpResponse httpResponse = new HttpResponse(HttpStatusCode.SwitchingProtocols);
			NameValueCollection headers = httpResponse.Headers;
			headers["Upgrade"] = "websocket";
			headers["Connection"] = "Upgrade";
			return httpResponse;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000B638 File Offset: 0x00009838
		internal static HttpResponse Parse(string[] headerParts)
		{
			string[] array = headerParts[0].Split(new char[]
			{
				' '
			}, 3);
			bool flag = array.Length != 3;
			if (flag)
			{
				throw new ArgumentException("Invalid status line: " + headerParts[0]);
			}
			WebHeaderCollection webHeaderCollection = new WebHeaderCollection();
			for (int i = 1; i < headerParts.Length; i++)
			{
				webHeaderCollection.InternalSet(headerParts[i], true);
			}
			return new HttpResponse(array[1], array[2], new Version(array[0].Substring(5)), webHeaderCollection);
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0000B6C0 File Offset: 0x000098C0
		internal static HttpResponse Read(Stream stream, int millisecondsTimeout)
		{
			return HttpBase.Read<HttpResponse>(stream, new Func<string[], HttpResponse>(HttpResponse.Parse), millisecondsTimeout);
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000B6E8 File Offset: 0x000098E8
		public void SetCookies(CookieCollection cookies)
		{
			bool flag = cookies == null || cookies.Count == 0;
			if (!flag)
			{
				NameValueCollection headers = base.Headers;
				foreach (Cookie cookie in cookies.Sorted)
				{
					headers.Add("Set-Cookie", cookie.ToResponseString());
				}
			}
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0000B760 File Offset: 0x00009960
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.AppendFormat("HTTP/{0} {1} {2}{3}", new object[]
			{
				base.ProtocolVersion,
				this._code,
				this._reason,
				"\r\n"
			});
			NameValueCollection headers = base.Headers;
			foreach (string text in headers.AllKeys)
			{
				stringBuilder.AppendFormat("{0}: {1}{2}", text, headers[text], "\r\n");
			}
			stringBuilder.Append("\r\n");
			string entityBody = base.EntityBody;
			bool flag = entityBody.Length > 0;
			if (flag)
			{
				stringBuilder.Append(entityBody);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000093 RID: 147
		private string _code;

		// Token: 0x04000094 RID: 148
		private string _reason;
	}
}
