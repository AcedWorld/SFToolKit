using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x0200003A RID: 58
	internal sealed class HttpListenerRequest
	{
		// Token: 0x060003F9 RID: 1017 RVA: 0x00011ED1 File Offset: 0x000100D1
		internal HttpListenerRequest(HttpListenerContext context)
		{
			this._context = context;
			this._connection = context.Connection;
			this._contentLength = -1L;
			this._headers = new WebHeaderCollection();
			this._requestTraceIdentifier = Guid.NewGuid();
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060003FA RID: 1018 RVA: 0x00011F0C File Offset: 0x0001010C
		public string[] AcceptTypes
		{
			get
			{
				string text = this._headers["Accept"];
				if (text == null)
				{
					return null;
				}
				if (this._acceptTypes == null)
				{
					this._acceptTypes = text.SplitHeaderValue(new char[]
					{
						','
					}).TrimEach().ToList<string>().ToArray();
				}
				return this._acceptTypes;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x00011F63 File Offset: 0x00010163
		public int ClientCertificateError
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060003FC RID: 1020 RVA: 0x00011F6A File Offset: 0x0001016A
		public Encoding ContentEncoding
		{
			get
			{
				if (this._contentEncoding == null)
				{
					this._contentEncoding = this.getContentEncoding();
				}
				return this._contentEncoding;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x00011F86 File Offset: 0x00010186
		public long ContentLength64
		{
			get
			{
				return this._contentLength;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060003FE RID: 1022 RVA: 0x00011F8E File Offset: 0x0001018E
		public string ContentType
		{
			get
			{
				return this._headers["Content-Type"];
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x00011FA0 File Offset: 0x000101A0
		public CookieCollection Cookies
		{
			get
			{
				if (this._cookies == null)
				{
					this._cookies = this._headers.GetCookies(false);
				}
				return this._cookies;
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000400 RID: 1024 RVA: 0x00011FC2 File Offset: 0x000101C2
		public bool HasEntityBody
		{
			get
			{
				return this._contentLength > 0L || this._chunked;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000401 RID: 1025 RVA: 0x00011FD6 File Offset: 0x000101D6
		public NameValueCollection Headers
		{
			get
			{
				return this._headers;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x00011FDE File Offset: 0x000101DE
		public string HttpMethod
		{
			get
			{
				return this._httpMethod;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000403 RID: 1027 RVA: 0x00011FE8 File Offset: 0x000101E8
		public Stream InputStream
		{
			get
			{
				if (this._inputStream == null)
				{
					this._inputStream = ((this._contentLength > 0L || this._chunked) ? this._connection.GetRequestStream(this._contentLength, this._chunked) : Stream.Null);
				}
				return this._inputStream;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000404 RID: 1028 RVA: 0x00012039 File Offset: 0x00010239
		public bool IsAuthenticated
		{
			get
			{
				return this._context.User != null;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x00012049 File Offset: 0x00010249
		public bool IsLocal
		{
			get
			{
				return this._connection.IsLocal;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x00012056 File Offset: 0x00010256
		public bool IsSecureConnection
		{
			get
			{
				return this._connection.IsSecure;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000407 RID: 1031 RVA: 0x00012063 File Offset: 0x00010263
		public bool IsWebSocketRequest
		{
			get
			{
				return this._httpMethod == "GET" && this._headers.Upgrades("websocket");
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x00012089 File Offset: 0x00010289
		public bool KeepAlive
		{
			get
			{
				return this._headers.KeepsAlive(this._protocolVersion);
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000409 RID: 1033 RVA: 0x0001209C File Offset: 0x0001029C
		public IPEndPoint LocalEndPoint
		{
			get
			{
				return this._connection.LocalEndPoint;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x000120A9 File Offset: 0x000102A9
		public Version ProtocolVersion
		{
			get
			{
				return this._protocolVersion;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x0600040B RID: 1035 RVA: 0x000120B4 File Offset: 0x000102B4
		public NameValueCollection QueryString
		{
			get
			{
				if (this._queryString == null)
				{
					Uri url = this.Url;
					string query = (url != null) ? url.Query : null;
					this._queryString = QueryStringCollection.Parse(query, HttpListenerRequest._defaultEncoding);
				}
				return this._queryString;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600040C RID: 1036 RVA: 0x000120FA File Offset: 0x000102FA
		public string RawUrl
		{
			get
			{
				return this._rawUrl;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x00012102 File Offset: 0x00010302
		public IPEndPoint RemoteEndPoint
		{
			get
			{
				return this._connection.RemoteEndPoint;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600040E RID: 1038 RVA: 0x0001210F File Offset: 0x0001030F
		public Guid RequestTraceIdentifier
		{
			get
			{
				return this._requestTraceIdentifier;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600040F RID: 1039 RVA: 0x00012117 File Offset: 0x00010317
		public Uri Url
		{
			get
			{
				if (!this._urlSet)
				{
					this._url = HttpUtility.CreateRequestUrl(this._rawUrl, this._userHostName, this.IsWebSocketRequest, this.IsSecureConnection);
					this._urlSet = true;
				}
				return this._url;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000410 RID: 1040 RVA: 0x00012154 File Offset: 0x00010354
		public Uri UrlReferrer
		{
			get
			{
				string text = this._headers["Referer"];
				if (text == null)
				{
					return null;
				}
				if (this._urlReferrer == null)
				{
					this._urlReferrer = text.ToUri();
				}
				return this._urlReferrer;
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x00012197 File Offset: 0x00010397
		public string UserAgent
		{
			get
			{
				return this._headers["User-Agent"];
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000412 RID: 1042 RVA: 0x000121A9 File Offset: 0x000103A9
		public string UserHostAddress
		{
			get
			{
				return this._connection.LocalEndPoint.ToString();
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x000121BB File Offset: 0x000103BB
		public string UserHostName
		{
			get
			{
				return this._userHostName;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x000121C4 File Offset: 0x000103C4
		public string[] UserLanguages
		{
			get
			{
				string text = this._headers["Accept-Language"];
				if (text == null)
				{
					return null;
				}
				if (this._userLanguages == null)
				{
					this._userLanguages = text.Split(',', StringSplitOptions.None).TrimEach().ToList<string>().ToArray();
				}
				return this._userLanguages;
			}
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00012214 File Offset: 0x00010414
		private Encoding getContentEncoding()
		{
			string text = this._headers["Content-Type"];
			if (text == null)
			{
				return HttpListenerRequest._defaultEncoding;
			}
			Encoding result;
			if (!HttpUtility.TryGetEncoding(text, out result))
			{
				return HttpListenerRequest._defaultEncoding;
			}
			return result;
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0001224C File Offset: 0x0001044C
		internal void AddHeader(string headerField)
		{
			char c = headerField[0];
			if (c == ' ' || c == '\t')
			{
				this._context.ErrorMessage = "Invalid header field";
				return;
			}
			int num = headerField.IndexOf(':');
			if (num < 1)
			{
				this._context.ErrorMessage = "Invalid header field";
				return;
			}
			string text = headerField.Substring(0, num).Trim();
			if (text.Length == 0 || !text.IsToken())
			{
				this._context.ErrorMessage = "Invalid header name";
				return;
			}
			string text2 = (num < headerField.Length - 1) ? headerField.Substring(num + 1).Trim() : string.Empty;
			this._headers.InternalSet(text, text2, false);
			string a = text.ToLower(CultureInfo.InvariantCulture);
			if (a == "host")
			{
				if (this._userHostName != null)
				{
					this._context.ErrorMessage = "Invalid Host header";
					return;
				}
				if (text2.Length == 0)
				{
					this._context.ErrorMessage = "Invalid Host header";
					return;
				}
				this._userHostName = text2;
				return;
			}
			else
			{
				if (!(a == "content-length"))
				{
					return;
				}
				if (this._contentLength > -1L)
				{
					this._context.ErrorMessage = "Invalid Content-Length header";
					return;
				}
				long num2;
				if (!long.TryParse(text2, out num2))
				{
					this._context.ErrorMessage = "Invalid Content-Length header";
					return;
				}
				if (num2 < 0L)
				{
					this._context.ErrorMessage = "Invalid Content-Length header";
					return;
				}
				this._contentLength = num2;
				return;
			}
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x000123B4 File Offset: 0x000105B4
		internal void FinishInitialization()
		{
			if (this._userHostName == null)
			{
				this._context.ErrorMessage = "Host header required";
				return;
			}
			string text = this._headers["Transfer-Encoding"];
			if (text != null)
			{
				StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;
				if (!text.Equals("chunked", comparisonType))
				{
					this._context.ErrorStatusCode = 501;
					this._context.ErrorMessage = "Invalid Transfer-Encoding header";
					return;
				}
				this._chunked = true;
			}
			if (this._httpMethod == "POST" || this._httpMethod == "PUT")
			{
				if (this._contentLength == -1L && !this._chunked)
				{
					this._context.ErrorStatusCode = 411;
					this._context.ErrorMessage = "Content-Length header required";
					return;
				}
				if (this._contentLength == 0L && !this._chunked)
				{
					this._context.ErrorStatusCode = 411;
					this._context.ErrorMessage = "Invalid Content-Length header";
					return;
				}
			}
			string text2 = this._headers["Expect"];
			if (text2 != null)
			{
				StringComparison comparisonType2 = StringComparison.OrdinalIgnoreCase;
				if (!text2.Equals("100-continue", comparisonType2))
				{
					this._context.ErrorStatusCode = 417;
					this._context.ErrorMessage = "Invalid Expect header";
					return;
				}
				this._connection.GetResponseStream().InternalWrite(HttpListenerRequest._100continue, 0, HttpListenerRequest._100continue.Length);
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00012510 File Offset: 0x00010710
		internal bool FlushInput()
		{
			Stream inputStream = this.InputStream;
			if (inputStream == Stream.Null)
			{
				return true;
			}
			int num = 2048;
			if (this._contentLength > 0L && this._contentLength < (long)num)
			{
				num = (int)this._contentLength;
			}
			byte[] buffer = new byte[num];
			bool result;
			for (;;)
			{
				try
				{
					IAsyncResult asyncResult = inputStream.BeginRead(buffer, 0, num, null, null);
					if (!asyncResult.IsCompleted)
					{
						int millisecondsTimeout = 100;
						if (!asyncResult.AsyncWaitHandle.WaitOne(millisecondsTimeout))
						{
							result = false;
							break;
						}
					}
					if (inputStream.EndRead(asyncResult) > 0)
					{
						continue;
					}
					result = true;
				}
				catch
				{
					result = false;
				}
				break;
			}
			return result;
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x000125B0 File Offset: 0x000107B0
		internal bool IsUpgradeRequest(string protocol)
		{
			return this._headers.Upgrades(protocol);
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x000125C0 File Offset: 0x000107C0
		internal void SetRequestLine(string requestLine)
		{
			string[] array = requestLine.Split(new char[]
			{
				' '
			}, 3);
			if (array.Length < 3)
			{
				this._context.ErrorMessage = "Invalid request line (parts)";
				return;
			}
			string text = array[0];
			if (text.Length == 0)
			{
				this._context.ErrorMessage = "Invalid request line (method)";
				return;
			}
			if (!text.IsHttpMethod())
			{
				this._context.ErrorStatusCode = 501;
				this._context.ErrorMessage = "Invalid request line (method)";
				return;
			}
			string text2 = array[1];
			if (text2.Length == 0)
			{
				this._context.ErrorMessage = "Invalid request line (target)";
				return;
			}
			string text3 = array[2];
			if (text3.Length != 8)
			{
				this._context.ErrorMessage = "Invalid request line (version)";
				return;
			}
			if (!text3.StartsWith("HTTP/", StringComparison.Ordinal))
			{
				this._context.ErrorMessage = "Invalid request line (version)";
				return;
			}
			Version version;
			if (!text3.Substring(5).TryCreateVersion(out version))
			{
				this._context.ErrorMessage = "Invalid request line (version)";
				return;
			}
			if (version != HttpVersion.Version11)
			{
				this._context.ErrorStatusCode = 505;
				this._context.ErrorMessage = "Invalid request line (version)";
				return;
			}
			this._httpMethod = text;
			this._rawUrl = text2;
			this._protocolVersion = version;
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x000126FD File Offset: 0x000108FD
		public IAsyncResult BeginGetClientCertificate(AsyncCallback requestCallback, object state)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00012704 File Offset: 0x00010904
		public X509Certificate2 EndGetClientCertificate(IAsyncResult asyncResult)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x0001270B File Offset: 0x0001090B
		public X509Certificate2 GetClientCertificate()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00012714 File Offset: 0x00010914
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			string format = "{0} {1} HTTP/{2}\r\n";
			string value = this._headers.ToString();
			stringBuilder.AppendFormat(format, this._httpMethod, this._rawUrl, this._protocolVersion).Append(value);
			return stringBuilder.ToString();
		}

		// Token: 0x04000179 RID: 377
		private static readonly byte[] _100continue = Encoding.ASCII.GetBytes("HTTP/1.1 100 Continue\r\n\r\n");

		// Token: 0x0400017A RID: 378
		private string[] _acceptTypes;

		// Token: 0x0400017B RID: 379
		private bool _chunked;

		// Token: 0x0400017C RID: 380
		private HttpConnection _connection;

		// Token: 0x0400017D RID: 381
		private Encoding _contentEncoding;

		// Token: 0x0400017E RID: 382
		private long _contentLength;

		// Token: 0x0400017F RID: 383
		private HttpListenerContext _context;

		// Token: 0x04000180 RID: 384
		private CookieCollection _cookies;

		// Token: 0x04000181 RID: 385
		private static readonly Encoding _defaultEncoding = Encoding.UTF8;

		// Token: 0x04000182 RID: 386
		private WebHeaderCollection _headers;

		// Token: 0x04000183 RID: 387
		private string _httpMethod;

		// Token: 0x04000184 RID: 388
		private Stream _inputStream;

		// Token: 0x04000185 RID: 389
		private Version _protocolVersion;

		// Token: 0x04000186 RID: 390
		private NameValueCollection _queryString;

		// Token: 0x04000187 RID: 391
		private string _rawUrl;

		// Token: 0x04000188 RID: 392
		private Guid _requestTraceIdentifier;

		// Token: 0x04000189 RID: 393
		private Uri _url;

		// Token: 0x0400018A RID: 394
		private Uri _urlReferrer;

		// Token: 0x0400018B RID: 395
		private bool _urlSet;

		// Token: 0x0400018C RID: 396
		private string _userHostName;

		// Token: 0x0400018D RID: 397
		private string[] _userLanguages;
	}
}
