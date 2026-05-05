using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x0200003B RID: 59
	internal sealed class HttpListenerResponse : IDisposable
	{
		// Token: 0x0600041F RID: 1055 RVA: 0x0001275F File Offset: 0x0001095F
		internal HttpListenerResponse(HttpListenerContext context)
		{
			this._context = context;
			this._keepAlive = true;
			this._statusCode = 200;
			this._statusDescription = "OK";
			this._version = HttpVersion.Version11;
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x00012796 File Offset: 0x00010996
		// (set) Token: 0x06000421 RID: 1057 RVA: 0x0001279E File Offset: 0x0001099E
		internal bool CloseConnection
		{
			get
			{
				return this._closeConnection;
			}
			set
			{
				this._closeConnection = value;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000422 RID: 1058 RVA: 0x000127A8 File Offset: 0x000109A8
		internal WebHeaderCollection FullHeaders
		{
			get
			{
				WebHeaderCollection webHeaderCollection = new WebHeaderCollection(HttpHeaderType.Response, true);
				if (this._headers != null)
				{
					webHeaderCollection.Add(this._headers);
				}
				if (this._contentType != null)
				{
					webHeaderCollection.InternalSet("Content-Type", HttpListenerResponse.createContentTypeHeaderText(this._contentType, this._contentEncoding), true);
				}
				if (webHeaderCollection["Server"] == null)
				{
					webHeaderCollection.InternalSet("Server", "websocket-sharp/1.0", true);
				}
				if (webHeaderCollection["Date"] == null)
				{
					webHeaderCollection.InternalSet("Date", DateTime.UtcNow.ToString("r", CultureInfo.InvariantCulture), true);
				}
				if (this._sendChunked)
				{
					webHeaderCollection.InternalSet("Transfer-Encoding", "chunked", true);
				}
				else
				{
					webHeaderCollection.InternalSet("Content-Length", this._contentLength.ToString(CultureInfo.InvariantCulture), true);
				}
				bool flag = !this._context.Request.KeepAlive || !this._keepAlive || this._statusCode == 400 || this._statusCode == 408 || this._statusCode == 411 || this._statusCode == 413 || this._statusCode == 414 || this._statusCode == 500 || this._statusCode == 503;
				int reuses = this._context.Connection.Reuses;
				if (flag || reuses >= 100)
				{
					webHeaderCollection.InternalSet("Connection", "close", true);
				}
				else
				{
					webHeaderCollection.InternalSet("Keep-Alive", string.Format("timeout=15,max={0}", 100 - reuses), true);
					if (this._context.Request.ProtocolVersion < HttpVersion.Version11)
					{
						webHeaderCollection.InternalSet("Connection", "keep-alive", true);
					}
				}
				if (this._redirectLocation != null)
				{
					webHeaderCollection.InternalSet("Location", this._redirectLocation.AbsoluteUri, true);
				}
				if (this._cookies != null)
				{
					foreach (Cookie cookie in this._cookies)
					{
						webHeaderCollection.InternalSet("Set-Cookie", cookie.ToResponseString(), true);
					}
				}
				return webHeaderCollection;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x000129E8 File Offset: 0x00010BE8
		// (set) Token: 0x06000424 RID: 1060 RVA: 0x000129F0 File Offset: 0x00010BF0
		internal bool HeadersSent
		{
			get
			{
				return this._headersSent;
			}
			set
			{
				this._headersSent = value;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x000129F9 File Offset: 0x00010BF9
		internal string StatusLine
		{
			get
			{
				return string.Format("HTTP/{0} {1} {2}\r\n", this._version, this._statusCode, this._statusDescription);
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x00012A1C File Offset: 0x00010C1C
		// (set) Token: 0x06000427 RID: 1063 RVA: 0x00012A24 File Offset: 0x00010C24
		public Encoding ContentEncoding
		{
			get
			{
				return this._contentEncoding;
			}
			set
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(base.GetType().ToString());
				}
				if (this._headersSent)
				{
					throw new InvalidOperationException("The response is already being sent.");
				}
				this._contentEncoding = value;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000428 RID: 1064 RVA: 0x00012A59 File Offset: 0x00010C59
		// (set) Token: 0x06000429 RID: 1065 RVA: 0x00012A64 File Offset: 0x00010C64
		public long ContentLength64
		{
			get
			{
				return this._contentLength;
			}
			set
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(base.GetType().ToString());
				}
				if (this._headersSent)
				{
					throw new InvalidOperationException("The response is already being sent.");
				}
				if (value < 0L)
				{
					throw new ArgumentOutOfRangeException("Less than zero.", "value");
				}
				this._contentLength = value;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x00012AB9 File Offset: 0x00010CB9
		// (set) Token: 0x0600042B RID: 1067 RVA: 0x00012AC4 File Offset: 0x00010CC4
		public string ContentType
		{
			get
			{
				return this._contentType;
			}
			set
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(base.GetType().ToString());
				}
				if (this._headersSent)
				{
					throw new InvalidOperationException("The response is already being sent.");
				}
				if (value == null)
				{
					this._contentType = null;
					return;
				}
				if (value.Length == 0)
				{
					throw new ArgumentException("An empty string.", "value");
				}
				if (!HttpListenerResponse.isValidForContentType(value))
				{
					throw new ArgumentException("It contains an invalid character.", "value");
				}
				this._contentType = value;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x00012B3F File Offset: 0x00010D3F
		// (set) Token: 0x0600042D RID: 1069 RVA: 0x00012B5A File Offset: 0x00010D5A
		public CookieCollection Cookies
		{
			get
			{
				if (this._cookies == null)
				{
					this._cookies = new CookieCollection();
				}
				return this._cookies;
			}
			set
			{
				this._cookies = value;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x0600042E RID: 1070 RVA: 0x00012B63 File Offset: 0x00010D63
		// (set) Token: 0x0600042F RID: 1071 RVA: 0x00012B80 File Offset: 0x00010D80
		public WebHeaderCollection Headers
		{
			get
			{
				if (this._headers == null)
				{
					this._headers = new WebHeaderCollection(HttpHeaderType.Response, false);
				}
				return this._headers;
			}
			set
			{
				if (value == null)
				{
					this._headers = null;
					return;
				}
				if (value.State != HttpHeaderType.Response)
				{
					throw new InvalidOperationException("The value is not valid for a response.");
				}
				this._headers = value;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x00012BA8 File Offset: 0x00010DA8
		// (set) Token: 0x06000431 RID: 1073 RVA: 0x00012BB0 File Offset: 0x00010DB0
		public bool KeepAlive
		{
			get
			{
				return this._keepAlive;
			}
			set
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(base.GetType().ToString());
				}
				if (this._headersSent)
				{
					throw new InvalidOperationException("The response is already being sent.");
				}
				this._keepAlive = value;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x00012BE5 File Offset: 0x00010DE5
		public Stream OutputStream
		{
			get
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(base.GetType().ToString());
				}
				if (this._outputStream == null)
				{
					this._outputStream = this._context.Connection.GetResponseStream();
				}
				return this._outputStream;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x00012C24 File Offset: 0x00010E24
		public Version ProtocolVersion
		{
			get
			{
				return this._version;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x00012C2C File Offset: 0x00010E2C
		// (set) Token: 0x06000435 RID: 1077 RVA: 0x00012C4C File Offset: 0x00010E4C
		public string RedirectLocation
		{
			get
			{
				if (!(this._redirectLocation != null))
				{
					return null;
				}
				return this._redirectLocation.OriginalString;
			}
			set
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(base.GetType().ToString());
				}
				if (this._headersSent)
				{
					throw new InvalidOperationException("The response is already being sent.");
				}
				if (value == null)
				{
					this._redirectLocation = null;
					return;
				}
				if (value.Length == 0)
				{
					throw new ArgumentException("An empty string.", "value");
				}
				Uri redirectLocation;
				if (!Uri.TryCreate(value, UriKind.Absolute, out redirectLocation))
				{
					throw new ArgumentException("Not an absolute URL.", "value");
				}
				this._redirectLocation = redirectLocation;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000436 RID: 1078 RVA: 0x00012CCA File Offset: 0x00010ECA
		// (set) Token: 0x06000437 RID: 1079 RVA: 0x00012CD2 File Offset: 0x00010ED2
		public bool SendChunked
		{
			get
			{
				return this._sendChunked;
			}
			set
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(base.GetType().ToString());
				}
				if (this._headersSent)
				{
					throw new InvalidOperationException("The response is already being sent.");
				}
				this._sendChunked = value;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000438 RID: 1080 RVA: 0x00012D07 File Offset: 0x00010F07
		// (set) Token: 0x06000439 RID: 1081 RVA: 0x00012D10 File Offset: 0x00010F10
		public int StatusCode
		{
			get
			{
				return this._statusCode;
			}
			set
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(base.GetType().ToString());
				}
				if (this._headersSent)
				{
					throw new InvalidOperationException("The response is already being sent.");
				}
				if (value < 100 || value > 999)
				{
					throw new ProtocolViolationException("A value is not between 100 and 999 inclusive.");
				}
				this._statusCode = value;
				this._statusDescription = value.GetStatusDescription();
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x00012D74 File Offset: 0x00010F74
		// (set) Token: 0x0600043B RID: 1083 RVA: 0x00012D7C File Offset: 0x00010F7C
		public string StatusDescription
		{
			get
			{
				return this._statusDescription;
			}
			set
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(base.GetType().ToString());
				}
				if (this._headersSent)
				{
					throw new InvalidOperationException("The response is already being sent.");
				}
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length == 0)
				{
					this._statusDescription = this._statusCode.GetStatusDescription();
					return;
				}
				if (!HttpListenerResponse.isValidForStatusDescription(value))
				{
					throw new ArgumentException("It contains an invalid character.", "value");
				}
				this._statusDescription = value;
			}
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00012DFC File Offset: 0x00010FFC
		private bool canSetCookie(Cookie cookie)
		{
			List<Cookie> list = this.findCookie(cookie).ToList<Cookie>();
			if (list.Count == 0)
			{
				return true;
			}
			int version = cookie.Version;
			using (List<Cookie>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Version == version)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00012E70 File Offset: 0x00011070
		private void close(bool force)
		{
			this._disposed = true;
			this._context.Connection.Close(force);
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00012E8C File Offset: 0x0001108C
		private void close(byte[] responseEntity, int bufferLength, bool willBlock)
		{
			Stream outputStream = this.OutputStream;
			if (willBlock)
			{
				outputStream.WriteBytes(responseEntity, bufferLength);
				this.close(false);
				return;
			}
			outputStream.WriteBytesAsync(responseEntity, bufferLength, delegate
			{
				this.close(false);
			}, null);
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00012EC8 File Offset: 0x000110C8
		private static string createContentTypeHeaderText(string value, Encoding encoding)
		{
			if (value.IndexOf("charset=", StringComparison.Ordinal) > -1)
			{
				return value;
			}
			if (encoding == null)
			{
				return value;
			}
			return string.Format("{0}; charset={1}", value, encoding.WebName);
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00012EF1 File Offset: 0x000110F1
		private IEnumerable<Cookie> findCookie(Cookie cookie)
		{
			if (this._cookies == null || this._cookies.Count == 0)
			{
				yield break;
			}
			foreach (Cookie cookie2 in this._cookies)
			{
				if (cookie2.EqualsWithoutValueAndVersion(cookie))
				{
					yield return cookie2;
				}
			}
			IEnumerator<Cookie> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00012F08 File Offset: 0x00011108
		private static bool isValidForContentType(string value)
		{
			foreach (char c in value)
			{
				if (c < ' ')
				{
					return false;
				}
				if (c > '~')
				{
					return false;
				}
				if ("()<>@:\\[]?{}".IndexOf(c) > -1)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00012F50 File Offset: 0x00011150
		private static bool isValidForStatusDescription(string value)
		{
			foreach (char c in value)
			{
				if (c < ' ')
				{
					return false;
				}
				if (c > '~')
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00012F87 File Offset: 0x00011187
		public void Abort()
		{
			if (this._disposed)
			{
				return;
			}
			this.close(true);
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00012F99 File Offset: 0x00011199
		public void AppendCookie(Cookie cookie)
		{
			this.Cookies.Add(cookie);
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00012FA7 File Offset: 0x000111A7
		public void AppendHeader(string name, string value)
		{
			this.Headers.Add(name, value);
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00012FB6 File Offset: 0x000111B6
		public void Close()
		{
			if (this._disposed)
			{
				return;
			}
			this.close(false);
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00012FC8 File Offset: 0x000111C8
		public void Close(byte[] responseEntity, bool willBlock)
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException(base.GetType().ToString());
			}
			if (responseEntity == null)
			{
				throw new ArgumentNullException("responseEntity");
			}
			long num = (long)responseEntity.Length;
			if (num > 2147483647L)
			{
				this.close(responseEntity, 1024, willBlock);
				return;
			}
			Stream stream = this.OutputStream;
			if (willBlock)
			{
				stream.Write(responseEntity, 0, (int)num);
				this.close(false);
				return;
			}
			stream.BeginWrite(responseEntity, 0, (int)num, delegate(IAsyncResult ar)
			{
				stream.EndWrite(ar);
				this.close(false);
			}, null);
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00013068 File Offset: 0x00011268
		public void CopyFrom(HttpListenerResponse templateResponse)
		{
			if (templateResponse == null)
			{
				throw new ArgumentNullException("templateResponse");
			}
			WebHeaderCollection headers = templateResponse._headers;
			if (headers != null)
			{
				if (this._headers != null)
				{
					this._headers.Clear();
				}
				this.Headers.Add(headers);
			}
			else
			{
				this._headers = null;
			}
			this._contentLength = templateResponse._contentLength;
			this._statusCode = templateResponse._statusCode;
			this._statusDescription = templateResponse._statusDescription;
			this._keepAlive = templateResponse._keepAlive;
			this._version = templateResponse._version;
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x000130F4 File Offset: 0x000112F4
		public void Redirect(string url)
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException(base.GetType().ToString());
			}
			if (this._headersSent)
			{
				throw new InvalidOperationException("The response is already being sent.");
			}
			if (url == null)
			{
				throw new ArgumentNullException("url");
			}
			if (url.Length == 0)
			{
				throw new ArgumentException("An empty string.", "url");
			}
			Uri redirectLocation;
			if (!Uri.TryCreate(url, UriKind.Absolute, out redirectLocation))
			{
				throw new ArgumentException("Not an absolute URL.", "url");
			}
			this._redirectLocation = redirectLocation;
			this._statusCode = 302;
			this._statusDescription = "Found";
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0001318B File Offset: 0x0001138B
		public void SetCookie(Cookie cookie)
		{
			if (cookie == null)
			{
				throw new ArgumentNullException("cookie");
			}
			if (!this.canSetCookie(cookie))
			{
				throw new ArgumentException("It cannot be updated.", "cookie");
			}
			this.Cookies.Add(cookie);
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x000131C0 File Offset: 0x000113C0
		public void SetHeader(string name, string value)
		{
			this.Headers.Set(name, value);
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x000131CF File Offset: 0x000113CF
		void IDisposable.Dispose()
		{
			if (this._disposed)
			{
				return;
			}
			this.close(true);
		}

		// Token: 0x0400018E RID: 398
		private bool _closeConnection;

		// Token: 0x0400018F RID: 399
		private Encoding _contentEncoding;

		// Token: 0x04000190 RID: 400
		private long _contentLength;

		// Token: 0x04000191 RID: 401
		private string _contentType;

		// Token: 0x04000192 RID: 402
		private HttpListenerContext _context;

		// Token: 0x04000193 RID: 403
		private CookieCollection _cookies;

		// Token: 0x04000194 RID: 404
		private bool _disposed;

		// Token: 0x04000195 RID: 405
		private WebHeaderCollection _headers;

		// Token: 0x04000196 RID: 406
		private bool _headersSent;

		// Token: 0x04000197 RID: 407
		private bool _keepAlive;

		// Token: 0x04000198 RID: 408
		private ResponseStream _outputStream;

		// Token: 0x04000199 RID: 409
		private Uri _redirectLocation;

		// Token: 0x0400019A RID: 410
		private bool _sendChunked;

		// Token: 0x0400019B RID: 411
		private int _statusCode;

		// Token: 0x0400019C RID: 412
		private string _statusDescription;

		// Token: 0x0400019D RID: 413
		private Version _version;
	}
}
