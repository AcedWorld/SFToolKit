using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace WebSocketSharp.Net
{
	// Token: 0x02000025 RID: 37
	public sealed class HttpListenerResponse : IDisposable
	{
		// Token: 0x060002AD RID: 685 RVA: 0x0001146E File Offset: 0x0000F66E
		internal HttpListenerResponse(HttpListenerContext context)
		{
			this._context = context;
			this._keepAlive = true;
			this._statusCode = 200;
			this._statusDescription = "OK";
			this._version = HttpVersion.Version11;
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002AE RID: 686 RVA: 0x000114A8 File Offset: 0x0000F6A8
		// (set) Token: 0x060002AF RID: 687 RVA: 0x000114C0 File Offset: 0x0000F6C0
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

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x000114CC File Offset: 0x0000F6CC
		internal WebHeaderCollection FullHeaders
		{
			get
			{
				WebHeaderCollection webHeaderCollection = new WebHeaderCollection(HttpHeaderType.Response, true);
				bool flag = this._headers != null;
				if (flag)
				{
					webHeaderCollection.Add(this._headers);
				}
				bool flag2 = this._contentType != null;
				if (flag2)
				{
					webHeaderCollection.InternalSet("Content-Type", HttpListenerResponse.createContentTypeHeaderText(this._contentType, this._contentEncoding), true);
				}
				bool flag3 = webHeaderCollection["Server"] == null;
				if (flag3)
				{
					webHeaderCollection.InternalSet("Server", "websocket-sharp/1.0", true);
				}
				bool flag4 = webHeaderCollection["Date"] == null;
				if (flag4)
				{
					webHeaderCollection.InternalSet("Date", DateTime.UtcNow.ToString("r", CultureInfo.InvariantCulture), true);
				}
				bool sendChunked = this._sendChunked;
				if (sendChunked)
				{
					webHeaderCollection.InternalSet("Transfer-Encoding", "chunked", true);
				}
				else
				{
					webHeaderCollection.InternalSet("Content-Length", this._contentLength.ToString(CultureInfo.InvariantCulture), true);
				}
				bool flag5 = !this._context.Request.KeepAlive || !this._keepAlive || this._statusCode == 400 || this._statusCode == 408 || this._statusCode == 411 || this._statusCode == 413 || this._statusCode == 414 || this._statusCode == 500 || this._statusCode == 503;
				int reuses = this._context.Connection.Reuses;
				bool flag6 = flag5 || reuses >= 100;
				if (flag6)
				{
					webHeaderCollection.InternalSet("Connection", "close", true);
				}
				else
				{
					webHeaderCollection.InternalSet("Keep-Alive", string.Format("timeout=15,max={0}", 100 - reuses), true);
					bool flag7 = this._context.Request.ProtocolVersion < HttpVersion.Version11;
					if (flag7)
					{
						webHeaderCollection.InternalSet("Connection", "keep-alive", true);
					}
				}
				bool flag8 = this._redirectLocation != null;
				if (flag8)
				{
					webHeaderCollection.InternalSet("Location", this._redirectLocation.AbsoluteUri, true);
				}
				bool flag9 = this._cookies != null;
				if (flag9)
				{
					foreach (Cookie cookie in this._cookies)
					{
						webHeaderCollection.InternalSet("Set-Cookie", cookie.ToResponseString(), true);
					}
				}
				return webHeaderCollection;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x00011770 File Offset: 0x0000F970
		// (set) Token: 0x060002B2 RID: 690 RVA: 0x00011788 File Offset: 0x0000F988
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

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x00011794 File Offset: 0x0000F994
		internal string StatusLine
		{
			get
			{
				return string.Format("HTTP/{0} {1} {2}\r\n", this._version, this._statusCode, this._statusDescription);
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x000117C8 File Offset: 0x0000F9C8
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x000117E0 File Offset: 0x0000F9E0
		public Encoding ContentEncoding
		{
			get
			{
				return this._contentEncoding;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					string objectName = base.GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				bool headersSent = this._headersSent;
				if (headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				this._contentEncoding = value;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x0001182C File Offset: 0x0000FA2C
		// (set) Token: 0x060002B7 RID: 695 RVA: 0x00011844 File Offset: 0x0000FA44
		public long ContentLength64
		{
			get
			{
				return this._contentLength;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					string objectName = base.GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				bool headersSent = this._headersSent;
				if (headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				bool flag = value < 0L;
				if (flag)
				{
					string paramName = "Less than zero.";
					throw new ArgumentOutOfRangeException(paramName, "value");
				}
				this._contentLength = value;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x000118B0 File Offset: 0x0000FAB0
		// (set) Token: 0x060002B9 RID: 697 RVA: 0x000118C8 File Offset: 0x0000FAC8
		public string ContentType
		{
			get
			{
				return this._contentType;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					string objectName = base.GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				bool headersSent = this._headersSent;
				if (headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				bool flag = value == null;
				if (flag)
				{
					this._contentType = null;
				}
				else
				{
					bool flag2 = value.Length == 0;
					if (flag2)
					{
						string message2 = "An empty string.";
						throw new ArgumentException(message2, "value");
					}
					bool flag3 = !HttpListenerResponse.isValidForContentType(value);
					if (flag3)
					{
						string message3 = "It contains an invalid character.";
						throw new ArgumentException(message3, "value");
					}
					this._contentType = value;
				}
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00011970 File Offset: 0x0000FB70
		// (set) Token: 0x060002BB RID: 699 RVA: 0x000119A0 File Offset: 0x0000FBA0
		public CookieCollection Cookies
		{
			get
			{
				bool flag = this._cookies == null;
				if (flag)
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

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060002BC RID: 700 RVA: 0x000119AC File Offset: 0x0000FBAC
		// (set) Token: 0x060002BD RID: 701 RVA: 0x000119E0 File Offset: 0x0000FBE0
		public WebHeaderCollection Headers
		{
			get
			{
				bool flag = this._headers == null;
				if (flag)
				{
					this._headers = new WebHeaderCollection(HttpHeaderType.Response, false);
				}
				return this._headers;
			}
			set
			{
				bool flag = value == null;
				if (flag)
				{
					this._headers = null;
				}
				else
				{
					bool flag2 = value.State != HttpHeaderType.Response;
					if (flag2)
					{
						string message = "The value is not valid for a response.";
						throw new InvalidOperationException(message);
					}
					this._headers = value;
				}
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060002BE RID: 702 RVA: 0x00011A28 File Offset: 0x0000FC28
		// (set) Token: 0x060002BF RID: 703 RVA: 0x00011A40 File Offset: 0x0000FC40
		public bool KeepAlive
		{
			get
			{
				return this._keepAlive;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					string objectName = base.GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				bool headersSent = this._headersSent;
				if (headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				this._keepAlive = value;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x00011A8C File Offset: 0x0000FC8C
		public Stream OutputStream
		{
			get
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					string objectName = base.GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				bool flag = this._outputStream == null;
				if (flag)
				{
					this._outputStream = this._context.Connection.GetResponseStream();
				}
				return this._outputStream;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x00011AE8 File Offset: 0x0000FCE8
		public Version ProtocolVersion
		{
			get
			{
				return this._version;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x00011B00 File Offset: 0x0000FD00
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x00011B30 File Offset: 0x0000FD30
		public string RedirectLocation
		{
			get
			{
				return (this._redirectLocation != null) ? this._redirectLocation.OriginalString : null;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					string objectName = base.GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				bool headersSent = this._headersSent;
				if (headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				bool flag = value == null;
				if (flag)
				{
					this._redirectLocation = null;
				}
				else
				{
					bool flag2 = value.Length == 0;
					if (flag2)
					{
						string message2 = "An empty string.";
						throw new ArgumentException(message2, "value");
					}
					Uri redirectLocation;
					bool flag3 = !Uri.TryCreate(value, UriKind.Absolute, out redirectLocation);
					if (flag3)
					{
						string message3 = "Not an absolute URL.";
						throw new ArgumentException(message3, "value");
					}
					this._redirectLocation = redirectLocation;
				}
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00011BDC File Offset: 0x0000FDDC
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x00011BF4 File Offset: 0x0000FDF4
		public bool SendChunked
		{
			get
			{
				return this._sendChunked;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					string objectName = base.GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				bool headersSent = this._headersSent;
				if (headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				this._sendChunked = value;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x00011C40 File Offset: 0x0000FE40
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x00011C58 File Offset: 0x0000FE58
		public int StatusCode
		{
			get
			{
				return this._statusCode;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					string objectName = base.GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				bool headersSent = this._headersSent;
				if (headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				bool flag = value < 100 || value > 999;
				if (flag)
				{
					string message2 = "A value is not between 100 and 999 inclusive.";
					throw new ProtocolViolationException(message2);
				}
				this._statusCode = value;
				this._statusDescription = value.GetStatusDescription();
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x00011CD8 File Offset: 0x0000FED8
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x00011CF0 File Offset: 0x0000FEF0
		public string StatusDescription
		{
			get
			{
				return this._statusDescription;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					string objectName = base.GetType().ToString();
					throw new ObjectDisposedException(objectName);
				}
				bool headersSent = this._headersSent;
				if (headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				bool flag = value == null;
				if (flag)
				{
					throw new ArgumentNullException("value");
				}
				bool flag2 = value.Length == 0;
				if (flag2)
				{
					this._statusDescription = this._statusCode.GetStatusDescription();
				}
				else
				{
					bool flag3 = !HttpListenerResponse.isValidForStatusDescription(value);
					if (flag3)
					{
						string message2 = "It contains an invalid character.";
						throw new ArgumentException(message2, "value");
					}
					this._statusDescription = value;
				}
			}
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00011D98 File Offset: 0x0000FF98
		private bool canSetCookie(Cookie cookie)
		{
			List<Cookie> list = this.findCookie(cookie).ToList<Cookie>();
			bool flag = list.Count == 0;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				int version = cookie.Version;
				foreach (Cookie cookie2 in list)
				{
					bool flag2 = cookie2.Version == version;
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00011E24 File Offset: 0x00010024
		private void close(bool force)
		{
			this._disposed = true;
			this._context.Connection.Close(force);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00011E40 File Offset: 0x00010040
		private void close(byte[] responseEntity, int bufferLength, bool willBlock)
		{
			Stream outputStream = this.OutputStream;
			if (willBlock)
			{
				outputStream.WriteBytes(responseEntity, bufferLength);
				this.close(false);
			}
			else
			{
				outputStream.WriteBytesAsync(responseEntity, bufferLength, delegate
				{
					this.close(false);
				}, null);
			}
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00011E84 File Offset: 0x00010084
		private static string createContentTypeHeaderText(string value, Encoding encoding)
		{
			bool flag = value.IndexOf("charset=", StringComparison.Ordinal) > -1;
			string result;
			if (flag)
			{
				result = value;
			}
			else
			{
				bool flag2 = encoding == null;
				if (flag2)
				{
					result = value;
				}
				else
				{
					result = string.Format("{0}; charset={1}", value, encoding.WebName);
				}
			}
			return result;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00011ECA File Offset: 0x000100CA
		private IEnumerable<Cookie> findCookie(Cookie cookie)
		{
			bool flag = this._cookies == null || this._cookies.Count == 0;
			if (flag)
			{
				yield break;
			}
			foreach (Cookie c in this._cookies)
			{
				bool flag2 = c.EqualsWithoutValueAndVersion(cookie);
				if (flag2)
				{
					yield return c;
				}
				c = null;
			}
			IEnumerator<Cookie> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00011EE4 File Offset: 0x000100E4
		private static bool isValidForContentType(string value)
		{
			int i = 0;
			while (i < value.Length)
			{
				char c = value[i];
				bool flag = c < ' ';
				bool result;
				if (flag)
				{
					result = false;
				}
				else
				{
					bool flag2 = c > '~';
					if (flag2)
					{
						result = false;
					}
					else
					{
						bool flag3 = "()<>@:\\[]?{}".IndexOf(c) > -1;
						if (!flag3)
						{
							i++;
							continue;
						}
						result = false;
					}
				}
				return result;
			}
			return true;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00011F50 File Offset: 0x00010150
		private static bool isValidForStatusDescription(string value)
		{
			int i = 0;
			while (i < value.Length)
			{
				char c = value[i];
				bool flag = c < ' ';
				bool result;
				if (flag)
				{
					result = false;
				}
				else
				{
					bool flag2 = c > '~';
					if (!flag2)
					{
						i++;
						continue;
					}
					result = false;
				}
				return result;
			}
			return true;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00011FA4 File Offset: 0x000101A4
		public void Abort()
		{
			bool disposed = this._disposed;
			if (!disposed)
			{
				this.close(true);
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00011FC6 File Offset: 0x000101C6
		public void AppendCookie(Cookie cookie)
		{
			this.Cookies.Add(cookie);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00011FD6 File Offset: 0x000101D6
		public void AppendHeader(string name, string value)
		{
			this.Headers.Add(name, value);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00011FE8 File Offset: 0x000101E8
		public void Close()
		{
			bool disposed = this._disposed;
			if (!disposed)
			{
				this.close(false);
			}
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0001200C File Offset: 0x0001020C
		public void Close(byte[] responseEntity, bool willBlock)
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				string objectName = base.GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			bool flag = responseEntity == null;
			if (flag)
			{
				throw new ArgumentNullException("responseEntity");
			}
			long num = (long)responseEntity.Length;
			bool flag2 = num > 2147483647L;
			if (flag2)
			{
				this.close(responseEntity, 1024, willBlock);
			}
			else
			{
				Stream stream = this.OutputStream;
				if (willBlock)
				{
					stream.Write(responseEntity, 0, (int)num);
					this.close(false);
				}
				else
				{
					stream.BeginWrite(responseEntity, 0, (int)num, delegate(IAsyncResult ar)
					{
						stream.EndWrite(ar);
						this.close(false);
					}, null);
				}
			}
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x000120CC File Offset: 0x000102CC
		public void CopyFrom(HttpListenerResponse templateResponse)
		{
			bool flag = templateResponse == null;
			if (flag)
			{
				throw new ArgumentNullException("templateResponse");
			}
			WebHeaderCollection headers = templateResponse._headers;
			bool flag2 = headers != null;
			if (flag2)
			{
				bool flag3 = this._headers != null;
				if (flag3)
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

		// Token: 0x060002D7 RID: 727 RVA: 0x0001216C File Offset: 0x0001036C
		public void Redirect(string url)
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				string objectName = base.GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			bool headersSent = this._headersSent;
			if (headersSent)
			{
				string message = "The response is already being sent.";
				throw new InvalidOperationException(message);
			}
			bool flag = url == null;
			if (flag)
			{
				throw new ArgumentNullException("url");
			}
			bool flag2 = url.Length == 0;
			if (flag2)
			{
				string message2 = "An empty string.";
				throw new ArgumentException(message2, "url");
			}
			Uri redirectLocation;
			bool flag3 = !Uri.TryCreate(url, UriKind.Absolute, out redirectLocation);
			if (flag3)
			{
				string message3 = "Not an absolute URL.";
				throw new ArgumentException(message3, "url");
			}
			this._redirectLocation = redirectLocation;
			this._statusCode = 302;
			this._statusDescription = "Found";
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00012230 File Offset: 0x00010430
		public void SetCookie(Cookie cookie)
		{
			bool flag = cookie == null;
			if (flag)
			{
				throw new ArgumentNullException("cookie");
			}
			bool flag2 = !this.canSetCookie(cookie);
			if (flag2)
			{
				string message = "It cannot be updated.";
				throw new ArgumentException(message, "cookie");
			}
			this.Cookies.Add(cookie);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0001227F File Offset: 0x0001047F
		public void SetHeader(string name, string value)
		{
			this.Headers.Set(name, value);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00012290 File Offset: 0x00010490
		void IDisposable.Dispose()
		{
			bool disposed = this._disposed;
			if (!disposed)
			{
				this.close(true);
			}
		}

		// Token: 0x04000109 RID: 265
		private bool _closeConnection;

		// Token: 0x0400010A RID: 266
		private Encoding _contentEncoding;

		// Token: 0x0400010B RID: 267
		private long _contentLength;

		// Token: 0x0400010C RID: 268
		private string _contentType;

		// Token: 0x0400010D RID: 269
		private HttpListenerContext _context;

		// Token: 0x0400010E RID: 270
		private CookieCollection _cookies;

		// Token: 0x0400010F RID: 271
		private bool _disposed;

		// Token: 0x04000110 RID: 272
		private WebHeaderCollection _headers;

		// Token: 0x04000111 RID: 273
		private bool _headersSent;

		// Token: 0x04000112 RID: 274
		private bool _keepAlive;

		// Token: 0x04000113 RID: 275
		private ResponseStream _outputStream;

		// Token: 0x04000114 RID: 276
		private Uri _redirectLocation;

		// Token: 0x04000115 RID: 277
		private bool _sendChunked;

		// Token: 0x04000116 RID: 278
		private int _statusCode;

		// Token: 0x04000117 RID: 279
		private string _statusDescription;

		// Token: 0x04000118 RID: 280
		private Version _version;
	}
}
