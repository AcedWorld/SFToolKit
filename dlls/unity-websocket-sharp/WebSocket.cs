using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using UnityWebSocketSharp.Net;
using UnityWebSocketSharp.Net.WebSockets;

namespace UnityWebSocketSharp
{
	// Token: 0x02000015 RID: 21
	internal class WebSocket : IDisposable
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x00004A74 File Offset: 0x00002C74
		internal WebSocket(HttpListenerWebSocketContext context, string protocol)
		{
			this._context = context;
			this._protocol = protocol;
			this._closeContext = new Action(context.Close);
			this._log = context.Log;
			this._message = new Action<MessageEventArgs>(this.messages);
			this._secure = context.IsSecureConnection;
			this._stream = context.Stream;
			this._waitTime = TimeSpan.FromSeconds(1.0);
			this.init();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004AFC File Offset: 0x00002CFC
		internal WebSocket(TcpListenerWebSocketContext context, string protocol)
		{
			this._context = context;
			this._protocol = protocol;
			this._closeContext = new Action(context.Close);
			this._log = context.Log;
			this._message = new Action<MessageEventArgs>(this.messages);
			this._secure = context.IsSecureConnection;
			this._stream = context.Stream;
			this._waitTime = TimeSpan.FromSeconds(1.0);
			this.init();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00004B84 File Offset: 0x00002D84
		public WebSocket(string url, params string[] protocols)
		{
			if (url == null)
			{
				throw new ArgumentNullException("url");
			}
			if (url.Length == 0)
			{
				throw new ArgumentException("An empty string.", "url");
			}
			string message;
			if (!url.TryCreateWebSocketUri(out this._uri, out message))
			{
				throw new ArgumentException(message, "url");
			}
			if (protocols != null && protocols.Length != 0)
			{
				if (!WebSocket.checkProtocols(protocols, out message))
				{
					throw new ArgumentException(message, "protocols");
				}
				this._protocols = protocols;
			}
			this._base64Key = WebSocket.CreateBase64Key();
			this._client = true;
			this._log = new Logger();
			this._message = new Action<MessageEventArgs>(this.messagec);
			this._retryCountForConnect = -1;
			this._secure = (this._uri.Scheme == "wss");
			this._waitTime = TimeSpan.FromSeconds(5.0);
			this.init();
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00004C6A File Offset: 0x00002E6A
		internal CookieCollection CookieCollection
		{
			get
			{
				return this._cookies;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x00004C72 File Offset: 0x00002E72
		// (set) Token: 0x060000D5 RID: 213 RVA: 0x00004C7A File Offset: 0x00002E7A
		internal Func<WebSocketContext, string> CustomHandshakeRequestChecker
		{
			get
			{
				return this._handshakeRequestChecker;
			}
			set
			{
				this._handshakeRequestChecker = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00004C83 File Offset: 0x00002E83
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x00004C8B File Offset: 0x00002E8B
		internal bool IgnoreExtensions
		{
			get
			{
				return this._ignoreExtensions;
			}
			set
			{
				this._ignoreExtensions = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00004C94 File Offset: 0x00002E94
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x00004C9C File Offset: 0x00002E9C
		public CompressionMethod Compression
		{
			get
			{
				return this._compression;
			}
			set
			{
				if (!this._client)
				{
					throw new InvalidOperationException("The interface is not for the client.");
				}
				object forState = this._forState;
				lock (forState)
				{
					if (this.canSet())
					{
						this._compression = value;
					}
				}
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00004CFC File Offset: 0x00002EFC
		public IEnumerable<Cookie> Cookies
		{
			get
			{
				object obj = this._cookies.SyncRoot;
				lock (obj)
				{
					foreach (Cookie cookie in this._cookies)
					{
						yield return cookie;
					}
					IEnumerator<Cookie> enumerator = null;
				}
				obj = null;
				yield break;
				yield break;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00004D0C File Offset: 0x00002F0C
		public NetworkCredential Credentials
		{
			get
			{
				return this._credentials;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00004D14 File Offset: 0x00002F14
		// (set) Token: 0x060000DD RID: 221 RVA: 0x00004D1C File Offset: 0x00002F1C
		public bool EmitOnPing
		{
			get
			{
				return this._emitOnPing;
			}
			set
			{
				this._emitOnPing = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00004D25 File Offset: 0x00002F25
		// (set) Token: 0x060000DF RID: 223 RVA: 0x00004D30 File Offset: 0x00002F30
		public bool EnableRedirection
		{
			get
			{
				return this._enableRedirection;
			}
			set
			{
				if (!this._client)
				{
					throw new InvalidOperationException("The interface is not for the client.");
				}
				object forState = this._forState;
				lock (forState)
				{
					if (this.canSet())
					{
						this._enableRedirection = value;
					}
				}
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00004D90 File Offset: 0x00002F90
		public string Extensions
		{
			get
			{
				return this._extensions ?? string.Empty;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00004DA1 File Offset: 0x00002FA1
		public bool IsAlive
		{
			get
			{
				return this.ping(WebSocket.EmptyBytes);
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00004DAE File Offset: 0x00002FAE
		public bool IsSecure
		{
			get
			{
				return this._secure;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00004DB6 File Offset: 0x00002FB6
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x00004DC0 File Offset: 0x00002FC0
		public Logger Log
		{
			get
			{
				return this._log;
			}
			internal set
			{
				this._log = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00004DCB File Offset: 0x00002FCB
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x00004DD4 File Offset: 0x00002FD4
		public string Origin
		{
			get
			{
				return this._origin;
			}
			set
			{
				if (!this._client)
				{
					throw new InvalidOperationException("The interface is not for the client.");
				}
				if (!value.IsNullOrEmpty())
				{
					Uri uri;
					if (!Uri.TryCreate(value, UriKind.Absolute, out uri))
					{
						throw new ArgumentException("Not an absolute URI string.", "value");
					}
					if (uri.Segments.Length > 1)
					{
						throw new ArgumentException("It includes the path segments.", "value");
					}
				}
				object forState = this._forState;
				lock (forState)
				{
					if (this.canSet())
					{
						this._origin = ((!value.IsNullOrEmpty()) ? value.TrimEnd('/') : value);
					}
				}
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00004E84 File Offset: 0x00003084
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x00004E95 File Offset: 0x00003095
		public string Protocol
		{
			get
			{
				return this._protocol ?? string.Empty;
			}
			internal set
			{
				this._protocol = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00004E9E File Offset: 0x0000309E
		public WebSocketState ReadyState
		{
			get
			{
				return this._readyState;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00004EA8 File Offset: 0x000030A8
		public ClientSslConfiguration SslConfiguration
		{
			get
			{
				if (!this._client)
				{
					throw new InvalidOperationException("The interface is not for the client.");
				}
				if (!this._secure)
				{
					throw new InvalidOperationException("The interface does not use a secure connection.");
				}
				return this.getSslConfiguration();
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00004ED6 File Offset: 0x000030D6
		public Uri Url
		{
			get
			{
				if (!this._client)
				{
					return this._context.RequestUri;
				}
				return this._uri;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00004EF2 File Offset: 0x000030F2
		// (set) Token: 0x060000ED RID: 237 RVA: 0x00004EFC File Offset: 0x000030FC
		public TimeSpan WaitTime
		{
			get
			{
				return this._waitTime;
			}
			set
			{
				if (value <= TimeSpan.Zero)
				{
					string message = "Zero or less.";
					throw new ArgumentOutOfRangeException("value", message);
				}
				object forState = this._forState;
				lock (forState)
				{
					if (this.canSet())
					{
						this._waitTime = value;
					}
				}
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060000EE RID: 238 RVA: 0x00004F68 File Offset: 0x00003168
		// (remove) Token: 0x060000EF RID: 239 RVA: 0x00004FA0 File Offset: 0x000031A0
		public event EventHandler<CloseEventArgs> OnClose;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000F0 RID: 240 RVA: 0x00004FD8 File Offset: 0x000031D8
		// (remove) Token: 0x060000F1 RID: 241 RVA: 0x00005010 File Offset: 0x00003210
		public event EventHandler<ErrorEventArgs> OnError;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060000F2 RID: 242 RVA: 0x00005048 File Offset: 0x00003248
		// (remove) Token: 0x060000F3 RID: 243 RVA: 0x00005080 File Offset: 0x00003280
		public event EventHandler<MessageEventArgs> OnMessage;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060000F4 RID: 244 RVA: 0x000050B8 File Offset: 0x000032B8
		// (remove) Token: 0x060000F5 RID: 245 RVA: 0x000050F0 File Offset: 0x000032F0
		public event EventHandler OnOpen;

		// Token: 0x060000F6 RID: 246 RVA: 0x00005128 File Offset: 0x00003328
		private void abort(string reason, Exception exception)
		{
			ushort code = (exception is WebSocketException) ? ((WebSocketException)exception).Code : 1006;
			this.abort(code, reason);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00005158 File Offset: 0x00003358
		private void abort(ushort code, string reason)
		{
			PayloadData payloadData = new PayloadData(code, reason);
			this.close(payloadData, false, false);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00005178 File Offset: 0x00003378
		private bool accept()
		{
			object forState = this._forState;
			bool result;
			lock (forState)
			{
				if (this._readyState == WebSocketState.Open)
				{
					this._log.Trace("The connection has already been established.");
					result = false;
				}
				else if (this._readyState == WebSocketState.Closing)
				{
					this._log.Error("The close process is in progress.");
					this.error("An error has occurred before accepting.", null);
					result = false;
				}
				else if (this._readyState == WebSocketState.Closed)
				{
					this._log.Error("The connection has been closed.");
					this.error("An error has occurred before accepting.", null);
					result = false;
				}
				else
				{
					this._readyState = WebSocketState.Connecting;
					bool flag2 = false;
					try
					{
						flag2 = this.acceptHandshake();
					}
					catch (Exception ex)
					{
						this._log.Fatal(ex.Message);
						this._log.Debug(ex.ToString());
						this.abort(1011, "An exception has occurred while accepting.");
					}
					if (!flag2)
					{
						result = false;
					}
					else
					{
						this._readyState = WebSocketState.Open;
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x000052A4 File Offset: 0x000034A4
		private bool acceptHandshake()
		{
			string message;
			if (!this.checkHandshakeRequest(this._context, out message))
			{
				this._log.Error(message);
				this._log.Debug(this._context.ToString());
				this.refuseHandshake(1002, "A handshake error has occurred.");
				return false;
			}
			if (!this.customCheckHandshakeRequest(this._context, out message))
			{
				this._log.Error(message);
				this._log.Debug(this._context.ToString());
				this.refuseHandshake(1002, "A handshake error has occurred.");
				return false;
			}
			this._base64Key = this._context.Headers["Sec-WebSocket-Key"];
			if (this._protocol != null && !this._context.SecWebSocketProtocols.Contains((string p) => p == this._protocol))
			{
				this._protocol = null;
			}
			if (!this._ignoreExtensions)
			{
				string value = this._context.Headers["Sec-WebSocket-Extensions"];
				this.processSecWebSocketExtensionsClientHeader(value);
			}
			this.createHandshakeResponse().WriteTo(this._stream);
			return true;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000053C0 File Offset: 0x000035C0
		private bool canSet()
		{
			return this._readyState == WebSocketState.New || this._readyState == WebSocketState.Closed;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x000053DC File Offset: 0x000035DC
		private bool checkHandshakeRequest(WebSocketContext context, out string message)
		{
			message = null;
			if (!context.IsWebSocketRequest)
			{
				message = "Not a WebSocket handshake request.";
				return false;
			}
			NameValueCollection headers = context.Headers;
			string text = headers["Sec-WebSocket-Key"];
			if (text == null)
			{
				message = "The Sec-WebSocket-Key header is non-existent.";
				return false;
			}
			if (text.Length == 0)
			{
				message = "The Sec-WebSocket-Key header is invalid.";
				return false;
			}
			string text2 = headers["Sec-WebSocket-Version"];
			if (text2 == null)
			{
				message = "The Sec-WebSocket-Version header is non-existent.";
				return false;
			}
			if (text2 != "13")
			{
				message = "The Sec-WebSocket-Version header is invalid.";
				return false;
			}
			string text3 = headers["Sec-WebSocket-Protocol"];
			if (text3 != null && text3.Length == 0)
			{
				message = "The Sec-WebSocket-Protocol header is invalid.";
				return false;
			}
			if (!this._ignoreExtensions)
			{
				string text4 = headers["Sec-WebSocket-Extensions"];
				if (text4 != null && text4.Length == 0)
				{
					message = "The Sec-WebSocket-Extensions header is invalid.";
					return false;
				}
			}
			return true;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000054A8 File Offset: 0x000036A8
		private bool checkHandshakeResponse(HttpResponse response, out string message)
		{
			message = null;
			if (response.IsRedirect)
			{
				message = "The redirection is indicated.";
				return false;
			}
			if (response.IsUnauthorized)
			{
				message = "The authentication is required.";
				return false;
			}
			if (!response.IsWebSocketResponse)
			{
				message = "Not a WebSocket handshake response.";
				return false;
			}
			NameValueCollection headers = response.Headers;
			string text = headers["Sec-WebSocket-Accept"];
			if (text == null)
			{
				message = "The Sec-WebSocket-Accept header is non-existent.";
				return false;
			}
			if (text != WebSocket.CreateResponseKey(this._base64Key))
			{
				message = "The Sec-WebSocket-Accept header is invalid.";
				return false;
			}
			string text2 = headers["Sec-WebSocket-Version"];
			if (text2 != null && text2 != "13")
			{
				message = "The Sec-WebSocket-Version header is invalid.";
				return false;
			}
			string subp = headers["Sec-WebSocket-Protocol"];
			if (subp == null)
			{
				if (this._protocolsRequested)
				{
					message = "The Sec-WebSocket-Protocol header is non-existent.";
					return false;
				}
			}
			else if (!this._protocolsRequested || subp.Length <= 0 || !this._protocols.Contains((string p) => p == subp))
			{
				message = "The Sec-WebSocket-Protocol header is invalid.";
				return false;
			}
			string text3 = headers["Sec-WebSocket-Extensions"];
			if (text3 != null && !this.validateSecWebSocketExtensionsServerHeader(text3))
			{
				message = "The Sec-WebSocket-Extensions header is invalid.";
				return false;
			}
			return true;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000055DC File Offset: 0x000037DC
		private static bool checkProtocols(string[] protocols, out string message)
		{
			message = null;
			Func<string, bool> condition = (string p) => p.IsNullOrEmpty() || !p.IsToken();
			if (protocols.Contains(condition))
			{
				message = "It contains a value that is not a token.";
				return false;
			}
			if (protocols.ContainsTwice())
			{
				message = "It contains a value twice.";
				return false;
			}
			return true;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00005630 File Offset: 0x00003830
		private bool checkProxyConnectResponse(HttpResponse response, out string message)
		{
			message = null;
			if (response.IsProxyAuthenticationRequired)
			{
				message = "The proxy authentication is required.";
				return false;
			}
			if (!response.IsSuccess)
			{
				message = "The proxy has failed a connection to the requested URL.";
				return false;
			}
			return true;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00005658 File Offset: 0x00003858
		private bool checkReceivedFrame(WebSocketFrame frame, out string message)
		{
			message = null;
			if (frame.IsMasked)
			{
				if (this._client)
				{
					message = "A frame from the server is masked.";
					return false;
				}
			}
			else if (!this._client)
			{
				message = "A frame from a client is not masked.";
				return false;
			}
			if (frame.IsCompressed)
			{
				if (this._compression == CompressionMethod.None)
				{
					message = "A frame is compressed without any agreement for it.";
					return false;
				}
				if (!frame.IsData)
				{
					message = "A non data frame is compressed.";
					return false;
				}
			}
			if (frame.IsData && this._inContinuation)
			{
				message = "A data frame was received while receiving continuation frames.";
				return false;
			}
			if (frame.IsControl)
			{
				if (frame.Fin == Fin.More)
				{
					message = "A control frame is fragmented.";
					return false;
				}
				if (frame.PayloadLength > 125)
				{
					message = "The payload length of a control frame is greater than 125.";
					return false;
				}
			}
			if (frame.Rsv2 == Rsv.On)
			{
				message = "The RSV2 of a frame is non-zero without any negotiation for it.";
				return false;
			}
			if (frame.Rsv3 == Rsv.On)
			{
				message = "The RSV3 of a frame is non-zero without any negotiation for it.";
				return false;
			}
			return true;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00005728 File Offset: 0x00003928
		private void close(ushort code, string reason)
		{
			if (this._readyState == WebSocketState.Closing)
			{
				this._log.Trace("The close process is already in progress.");
				return;
			}
			if (this._readyState == WebSocketState.Closed)
			{
				this._log.Trace("The connection has already been closed.");
				return;
			}
			if (code == 1005)
			{
				this.close(PayloadData.Empty, true, false);
				return;
			}
			PayloadData payloadData = new PayloadData(code, reason);
			bool send = !code.IsReservedStatusCode();
			this.close(payloadData, send, false);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000057A4 File Offset: 0x000039A4
		private void close(PayloadData payloadData, bool send, bool received)
		{
			object forState = this._forState;
			lock (forState)
			{
				if (this._readyState == WebSocketState.Closing)
				{
					this._log.Trace("The close process is already in progress.");
					return;
				}
				if (this._readyState == WebSocketState.Closed)
				{
					this._log.Trace("The connection has already been closed.");
					return;
				}
				send = (send && this._readyState == WebSocketState.Open);
				this._readyState = WebSocketState.Closing;
			}
			this._log.Trace("Begin closing the connection.");
			bool clean = this.closeHandshake(payloadData, send, received);
			this.releaseResources();
			this._log.Trace("End closing the connection.");
			this._readyState = WebSocketState.Closed;
			CloseEventArgs e = new CloseEventArgs(payloadData, clean);
			try
			{
				this.OnClose.Emit(this, e);
			}
			catch (Exception ex)
			{
				this._log.Error(ex.Message);
				this._log.Debug(ex.ToString());
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000058CC File Offset: 0x00003ACC
		private void closeAsync(ushort code, string reason)
		{
			if (this._readyState == WebSocketState.Closing)
			{
				this._log.Trace("The close process is already in progress.");
				return;
			}
			if (this._readyState == WebSocketState.Closed)
			{
				this._log.Trace("The connection has already been closed.");
				return;
			}
			if (code == 1005)
			{
				this.closeAsync(PayloadData.Empty, true, false);
				return;
			}
			PayloadData payloadData = new PayloadData(code, reason);
			bool send = !code.IsReservedStatusCode();
			this.closeAsync(payloadData, send, false);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00005948 File Offset: 0x00003B48
		private void closeAsync(PayloadData payloadData, bool send, bool received)
		{
			Action<PayloadData, bool, bool> closer = new Action<PayloadData, bool, bool>(this.close);
			closer.BeginInvoke(payloadData, send, received, delegate(IAsyncResult ar)
			{
				closer.EndInvoke(ar);
			}, null);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000598C File Offset: 0x00003B8C
		private bool closeHandshake(PayloadData payloadData, bool send, bool received)
		{
			bool flag = false;
			if (send)
			{
				WebSocketFrame webSocketFrame = WebSocketFrame.CreateCloseFrame(payloadData, this._client);
				byte[] bytes = webSocketFrame.ToArray();
				flag = this.sendBytes(bytes);
				if (this._client)
				{
					webSocketFrame.Unmask();
				}
			}
			if (!received && flag && this._receivingExited != null)
			{
				received = this._receivingExited.WaitOne(this._waitTime);
			}
			bool flag2 = flag && received;
			string message = string.Format("The closing was clean? {0} (sent: {1} received: {2})", flag2, flag, received);
			this._log.Debug(message);
			return flag2;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00005A24 File Offset: 0x00003C24
		private bool connect()
		{
			if (this._readyState == WebSocketState.Connecting)
			{
				this._log.Trace("The connect process is in progress.");
				return false;
			}
			object forState = this._forState;
			bool result;
			lock (forState)
			{
				if (this._readyState == WebSocketState.Open)
				{
					this._log.Trace("The connection has already been established.");
					result = false;
				}
				else if (this._readyState == WebSocketState.Closing)
				{
					this._log.Error("The close process is in progress.");
					this.error("An error has occurred before connecting.", null);
					result = false;
				}
				else if (this._retryCountForConnect >= WebSocket._maxRetryCountForConnect)
				{
					this._log.Error("An opportunity for reconnecting has been lost.");
					this.error("An error has occurred before connecting.", null);
					result = false;
				}
				else
				{
					this._retryCountForConnect++;
					this._readyState = WebSocketState.Connecting;
					bool flag2 = false;
					try
					{
						flag2 = this.doHandshake();
					}
					catch (Exception ex)
					{
						this._log.Fatal(ex.Message);
						this._log.Debug(ex.ToString());
						this.abort("An exception has occurred while connecting.", ex);
					}
					if (!flag2)
					{
						result = false;
					}
					else
					{
						this._retryCountForConnect = -1;
						this._readyState = WebSocketState.Open;
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00005B9C File Offset: 0x00003D9C
		private AuthenticationResponse createAuthenticationResponse()
		{
			if (this._credentials == null)
			{
				return null;
			}
			if (this._authChallenge != null)
			{
				AuthenticationResponse authenticationResponse = new AuthenticationResponse(this._authChallenge, this._credentials, this._nonceCount);
				this._nonceCount = authenticationResponse.NonceCount;
				return authenticationResponse;
			}
			if (!this._preAuth)
			{
				return null;
			}
			return new AuthenticationResponse(this._credentials);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00005BF8 File Offset: 0x00003DF8
		private string createExtensions()
		{
			StringBuilder stringBuilder = new StringBuilder(80);
			if (this._compression != CompressionMethod.None)
			{
				string arg = this._compression.ToExtensionString(new string[]
				{
					"server_no_context_takeover",
					"client_no_context_takeover"
				});
				stringBuilder.AppendFormat("{0}, ", arg);
			}
			int length = stringBuilder.Length;
			if (length <= 2)
			{
				return null;
			}
			stringBuilder.Length = length - 2;
			return stringBuilder.ToString();
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00005C60 File Offset: 0x00003E60
		private HttpResponse createHandshakeFailureResponse()
		{
			HttpResponse httpResponse = HttpResponse.CreateCloseResponse(HttpStatusCode.BadRequest);
			httpResponse.Headers["Sec-WebSocket-Version"] = "13";
			return httpResponse;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00005C84 File Offset: 0x00003E84
		private HttpRequest createHandshakeRequest()
		{
			HttpRequest httpRequest = HttpRequest.CreateWebSocketHandshakeRequest(this._uri);
			NameValueCollection headers = httpRequest.Headers;
			headers["Sec-WebSocket-Key"] = this._base64Key;
			headers["Sec-WebSocket-Version"] = "13";
			if (!this._origin.IsNullOrEmpty())
			{
				headers["Origin"] = this._origin;
			}
			if (this._protocols != null)
			{
				headers["Sec-WebSocket-Protocol"] = this._protocols.ToString(", ");
				this._protocolsRequested = true;
			}
			string text = this.createExtensions();
			if (text != null)
			{
				headers["Sec-WebSocket-Extensions"] = text;
				this._extensionsRequested = true;
			}
			AuthenticationResponse authenticationResponse = this.createAuthenticationResponse();
			if (authenticationResponse != null)
			{
				headers["Authorization"] = authenticationResponse.ToString();
			}
			if (this._cookies.Count > 0)
			{
				httpRequest.SetCookies(this._cookies);
			}
			return httpRequest;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00005D60 File Offset: 0x00003F60
		private HttpResponse createHandshakeResponse()
		{
			HttpResponse httpResponse = HttpResponse.CreateWebSocketHandshakeResponse();
			NameValueCollection headers = httpResponse.Headers;
			headers["Sec-WebSocket-Accept"] = WebSocket.CreateResponseKey(this._base64Key);
			if (this._protocol != null)
			{
				headers["Sec-WebSocket-Protocol"] = this._protocol;
			}
			if (this._extensions != null)
			{
				headers["Sec-WebSocket-Extensions"] = this._extensions;
			}
			if (this._cookies.Count > 0)
			{
				httpResponse.SetCookies(this._cookies);
			}
			return httpResponse;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00005DDD File Offset: 0x00003FDD
		private bool customCheckHandshakeRequest(WebSocketContext context, out string message)
		{
			message = null;
			if (this._handshakeRequestChecker == null)
			{
				return true;
			}
			message = this._handshakeRequestChecker(context);
			return message == null;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00005E00 File Offset: 0x00004000
		private MessageEventArgs dequeueFromMessageEventQueue()
		{
			object forMessageEventQueue = this._forMessageEventQueue;
			MessageEventArgs result;
			lock (forMessageEventQueue)
			{
				result = ((this._messageEventQueue.Count > 0) ? this._messageEventQueue.Dequeue() : null);
			}
			return result;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00005E58 File Offset: 0x00004058
		private bool doHandshake()
		{
			this.setClientStream();
			HttpResponse httpResponse = this.sendHandshakeRequest();
			string message;
			if (!this.checkHandshakeResponse(httpResponse, out message))
			{
				this._log.Error(message);
				this._log.Debug(httpResponse.ToString());
				this.abort(1002, "A handshake error has occurred.");
				return false;
			}
			if (this._protocolsRequested)
			{
				this._protocol = httpResponse.Headers["Sec-WebSocket-Protocol"];
			}
			if (this._extensionsRequested)
			{
				string text = httpResponse.Headers["Sec-WebSocket-Extensions"];
				if (text == null)
				{
					this._compression = CompressionMethod.None;
				}
				else
				{
					this._extensions = text;
				}
			}
			CookieCollection cookies = httpResponse.Cookies;
			if (cookies.Count > 0)
			{
				this._cookies.SetOrRemove(cookies);
			}
			return true;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00005F18 File Offset: 0x00004118
		private void enqueueToMessageEventQueue(MessageEventArgs e)
		{
			object forMessageEventQueue = this._forMessageEventQueue;
			lock (forMessageEventQueue)
			{
				this._messageEventQueue.Enqueue(e);
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00005F60 File Offset: 0x00004160
		private void error(string message, Exception exception)
		{
			ErrorEventArgs e = new ErrorEventArgs(message, exception);
			try
			{
				this.OnError.Emit(this, e);
			}
			catch (Exception ex)
			{
				this._log.Error(ex.Message);
				this._log.Debug(ex.ToString());
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00005FC0 File Offset: 0x000041C0
		private ClientSslConfiguration getSslConfiguration()
		{
			if (this._sslConfig == null)
			{
				this._sslConfig = new ClientSslConfiguration(this._uri.DnsSafeHost);
			}
			return this._sslConfig;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00005FE8 File Offset: 0x000041E8
		private void init()
		{
			this._compression = CompressionMethod.None;
			this._cookies = new CookieCollection();
			this._forPing = new object();
			this._forSend = new object();
			this._forState = new object();
			this._messageEventQueue = new Queue<MessageEventArgs>();
			this._forMessageEventQueue = ((ICollection)this._messageEventQueue).SyncRoot;
			this._readyState = WebSocketState.New;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00006050 File Offset: 0x00004250
		private void message()
		{
			MessageEventArgs obj = null;
			object forMessageEventQueue = this._forMessageEventQueue;
			lock (forMessageEventQueue)
			{
				if (this._inMessage)
				{
					return;
				}
				if (this._messageEventQueue.Count == 0)
				{
					return;
				}
				if (this._readyState != WebSocketState.Open)
				{
					return;
				}
				obj = this._messageEventQueue.Dequeue();
				this._inMessage = true;
			}
			this._message(obj);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000060D8 File Offset: 0x000042D8
		private void messagec(MessageEventArgs e)
		{
			for (;;)
			{
				try
				{
					this.OnMessage.Emit(this, e);
				}
				catch (Exception ex)
				{
					this._log.Error(ex.Message);
					this._log.Debug(ex.ToString());
					this.error("An exception has occurred during an OnMessage event.", ex);
				}
				object forMessageEventQueue = this._forMessageEventQueue;
				lock (forMessageEventQueue)
				{
					if (this._messageEventQueue.Count == 0)
					{
						this._inMessage = false;
					}
					else
					{
						if (this._readyState == WebSocketState.Open)
						{
							e = this._messageEventQueue.Dequeue();
							continue;
						}
						this._inMessage = false;
					}
				}
				break;
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000061A4 File Offset: 0x000043A4
		private void messages(MessageEventArgs e)
		{
			try
			{
				this.OnMessage.Emit(this, e);
			}
			catch (Exception ex)
			{
				this._log.Error(ex.Message);
				this._log.Debug(ex.ToString());
				this.error("An exception has occurred during an OnMessage event.", ex);
			}
			object forMessageEventQueue = this._forMessageEventQueue;
			lock (forMessageEventQueue)
			{
				if (this._messageEventQueue.Count == 0)
				{
					this._inMessage = false;
					return;
				}
				if (this._readyState != WebSocketState.Open)
				{
					this._inMessage = false;
					return;
				}
				e = this._messageEventQueue.Dequeue();
			}
			ThreadPool.QueueUserWorkItem(delegate(object state)
			{
				this.messages(e);
			});
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00006298 File Offset: 0x00004498
		private void open()
		{
			this._inMessage = true;
			this.startReceiving();
			try
			{
				this.OnOpen.Emit(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				this._log.Error(ex.Message);
				this._log.Debug(ex.ToString());
				this.error("An exception has occurred during the OnOpen event.", ex);
			}
			MessageEventArgs obj = null;
			object forMessageEventQueue = this._forMessageEventQueue;
			lock (forMessageEventQueue)
			{
				if (this._messageEventQueue.Count == 0)
				{
					this._inMessage = false;
					return;
				}
				if (this._readyState != WebSocketState.Open)
				{
					this._inMessage = false;
					return;
				}
				obj = this._messageEventQueue.Dequeue();
			}
			this._message.BeginInvoke(obj, delegate(IAsyncResult ar)
			{
				this._message.EndInvoke(ar);
			}, null);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000638C File Offset: 0x0000458C
		private bool ping(byte[] data)
		{
			if (this._readyState != WebSocketState.Open)
			{
				return false;
			}
			ManualResetEvent pongReceived = this._pongReceived;
			if (pongReceived == null)
			{
				return false;
			}
			object forPing = this._forPing;
			bool result;
			lock (forPing)
			{
				try
				{
					pongReceived.Reset();
					if (!this.send(Fin.Final, Opcode.Ping, data, false))
					{
						result = false;
					}
					else
					{
						result = pongReceived.WaitOne(this._waitTime);
					}
				}
				catch (ObjectDisposedException)
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00006418 File Offset: 0x00004618
		private bool processCloseFrame(WebSocketFrame frame)
		{
			PayloadData payloadData = frame.PayloadData;
			bool send = !payloadData.HasReservedCode;
			this.close(payloadData, send, true);
			return false;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00006440 File Offset: 0x00004640
		private bool processDataFrame(WebSocketFrame frame)
		{
			MessageEventArgs e = frame.IsCompressed ? new MessageEventArgs(frame.Opcode, frame.PayloadData.ApplicationData.Decompress(this._compression)) : new MessageEventArgs(frame);
			this.enqueueToMessageEventQueue(e);
			return true;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00006488 File Offset: 0x00004688
		private bool processFragmentFrame(WebSocketFrame frame)
		{
			if (!this._inContinuation)
			{
				if (frame.IsContinuation)
				{
					return true;
				}
				this._fragmentsOpcode = frame.Opcode;
				this._fragmentsCompressed = frame.IsCompressed;
				this._fragmentsBuffer = new MemoryStream();
				this._inContinuation = true;
			}
			this._fragmentsBuffer.WriteBytes(frame.PayloadData.ApplicationData, 1024);
			if (frame.IsFinal)
			{
				using (this._fragmentsBuffer)
				{
					byte[] rawData = this._fragmentsCompressed ? this._fragmentsBuffer.DecompressToArray(this._compression) : this._fragmentsBuffer.ToArray();
					MessageEventArgs e = new MessageEventArgs(this._fragmentsOpcode, rawData);
					this.enqueueToMessageEventQueue(e);
				}
				this._fragmentsBuffer = null;
				this._inContinuation = false;
			}
			return true;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00006564 File Offset: 0x00004764
		private bool processPingFrame(WebSocketFrame frame)
		{
			this._log.Trace("A ping was received.");
			WebSocketFrame webSocketFrame = WebSocketFrame.CreatePongFrame(frame.PayloadData, this._client);
			object forState = this._forState;
			lock (forState)
			{
				if (this._readyState != WebSocketState.Open)
				{
					this._log.Trace("A pong to this ping cannot be sent.");
					return true;
				}
				byte[] bytes = webSocketFrame.ToArray();
				if (!this.sendBytes(bytes))
				{
					return false;
				}
			}
			this._log.Trace("A pong to this ping has been sent.");
			if (this._emitOnPing)
			{
				if (this._client)
				{
					webSocketFrame.Unmask();
				}
				MessageEventArgs e = new MessageEventArgs(frame);
				this.enqueueToMessageEventQueue(e);
			}
			return true;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00006638 File Offset: 0x00004838
		private bool processPongFrame(WebSocketFrame frame)
		{
			this._log.Trace("A pong was received.");
			try
			{
				this._pongReceived.Set();
			}
			catch (NullReferenceException)
			{
				return false;
			}
			catch (ObjectDisposedException)
			{
				return false;
			}
			this._log.Trace("It has been signaled.");
			return true;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000066A0 File Offset: 0x000048A0
		private bool processReceivedFrame(WebSocketFrame frame)
		{
			string message;
			if (!this.checkReceivedFrame(frame, out message))
			{
				this._log.Error(message);
				this._log.Debug(frame.ToString(false));
				this.abort(1002, "An error has occurred while receiving.");
				return false;
			}
			frame.Unmask();
			if (frame.IsFragment)
			{
				return this.processFragmentFrame(frame);
			}
			if (frame.IsData)
			{
				return this.processDataFrame(frame);
			}
			if (frame.IsPing)
			{
				return this.processPingFrame(frame);
			}
			if (frame.IsPong)
			{
				return this.processPongFrame(frame);
			}
			if (!frame.IsClose)
			{
				return this.processUnsupportedFrame(frame);
			}
			return this.processCloseFrame(frame);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000674C File Offset: 0x0000494C
		private void processSecWebSocketExtensionsClientHeader(string value)
		{
			if (value == null)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder(80);
			bool flag = false;
			foreach (string text in value.SplitHeaderValue(new char[]
			{
				','
			}))
			{
				string text2 = text.Trim();
				if (text2.Length != 0 && !flag && text2.IsCompressionExtension(CompressionMethod.Deflate))
				{
					this._compression = CompressionMethod.Deflate;
					string arg = this._compression.ToExtensionString(new string[]
					{
						"client_no_context_takeover",
						"server_no_context_takeover"
					});
					stringBuilder.AppendFormat("{0}, ", arg);
					flag = true;
				}
			}
			int length = stringBuilder.Length;
			if (length <= 2)
			{
				return;
			}
			stringBuilder.Length = length - 2;
			this._extensions = stringBuilder.ToString();
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00006824 File Offset: 0x00004A24
		private bool processUnsupportedFrame(WebSocketFrame frame)
		{
			this._log.Fatal("An unsupported frame was received.");
			this._log.Debug(frame.ToString(false));
			this.abort(1003, "There is no way to handle it.");
			return false;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000685D File Offset: 0x00004A5D
		private void refuseHandshake(ushort code, string reason)
		{
			this.createHandshakeFailureResponse().WriteTo(this._stream);
			this.abort(code, reason);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00006878 File Offset: 0x00004A78
		private void releaseClientResources()
		{
			if (this._stream != null)
			{
				this._stream.Dispose();
				this._stream = null;
			}
			if (this._tcpClient != null)
			{
				this._tcpClient.Close();
				this._tcpClient = null;
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000068B0 File Offset: 0x00004AB0
		private void releaseCommonResources()
		{
			if (this._fragmentsBuffer != null)
			{
				this._fragmentsBuffer.Dispose();
				this._fragmentsBuffer = null;
				this._inContinuation = false;
			}
			if (this._pongReceived != null)
			{
				this._pongReceived.Close();
				this._pongReceived = null;
			}
			if (this._receivingExited != null)
			{
				this._receivingExited.Close();
				this._receivingExited = null;
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00006912 File Offset: 0x00004B12
		private void releaseResources()
		{
			if (this._client)
			{
				this.releaseClientResources();
			}
			else
			{
				this.releaseServerResources();
			}
			this.releaseCommonResources();
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00006930 File Offset: 0x00004B30
		private void releaseServerResources()
		{
			if (this._closeContext != null)
			{
				this._closeContext();
				this._closeContext = null;
			}
			this._stream = null;
			this._context = null;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000695C File Offset: 0x00004B5C
		private bool send(byte[] rawFrame)
		{
			object forState = this._forState;
			bool result;
			lock (forState)
			{
				if (this._readyState != WebSocketState.Open)
				{
					this._log.Error("The current state of the interface is not Open.");
					result = false;
				}
				else
				{
					result = this.sendBytes(rawFrame);
				}
			}
			return result;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000069C0 File Offset: 0x00004BC0
		private bool send(Opcode opcode, Stream sourceStream)
		{
			object forSend = this._forSend;
			bool result;
			lock (forSend)
			{
				Stream stream = sourceStream;
				bool flag2 = false;
				bool flag3 = false;
				try
				{
					if (this._compression != CompressionMethod.None)
					{
						stream = sourceStream.Compress(this._compression);
						flag2 = true;
					}
					flag3 = this.send(opcode, stream, flag2);
					if (!flag3)
					{
						this.error("A send has failed.", null);
					}
				}
				catch (Exception ex)
				{
					this._log.Error(ex.Message);
					this._log.Debug(ex.ToString());
					this.error("An exception has occurred during a send.", ex);
				}
				finally
				{
					if (flag2)
					{
						stream.Dispose();
					}
					sourceStream.Dispose();
				}
				result = flag3;
			}
			return result;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00006A9C File Offset: 0x00004C9C
		private bool send(Opcode opcode, Stream dataStream, bool compressed)
		{
			long length = dataStream.Length;
			if (length == 0L)
			{
				return this.send(Fin.Final, opcode, WebSocket.EmptyBytes, false);
			}
			long num = length / (long)WebSocket.FragmentLength;
			int num2 = (int)(length % (long)WebSocket.FragmentLength);
			byte[] array;
			if (num == 0L)
			{
				array = new byte[num2];
				return dataStream.Read(array, 0, num2) == num2 && this.send(Fin.Final, opcode, array, compressed);
			}
			if (num == 1L && num2 == 0)
			{
				array = new byte[WebSocket.FragmentLength];
				return dataStream.Read(array, 0, WebSocket.FragmentLength) == WebSocket.FragmentLength && this.send(Fin.Final, opcode, array, compressed);
			}
			array = new byte[WebSocket.FragmentLength];
			if (dataStream.Read(array, 0, WebSocket.FragmentLength) != WebSocket.FragmentLength || !this.send(Fin.More, opcode, array, compressed))
			{
				return false;
			}
			long num3 = (num2 == 0) ? (num - 2L) : (num - 1L);
			for (long num4 = 0L; num4 < num3; num4 += 1L)
			{
				if (dataStream.Read(array, 0, WebSocket.FragmentLength) != WebSocket.FragmentLength || !this.send(Fin.More, Opcode.Cont, array, false))
				{
					return false;
				}
			}
			if (num2 == 0)
			{
				num2 = WebSocket.FragmentLength;
			}
			else
			{
				array = new byte[num2];
			}
			return dataStream.Read(array, 0, num2) == num2 && this.send(Fin.Final, Opcode.Cont, array, false);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00006BD0 File Offset: 0x00004DD0
		private bool send(Fin fin, Opcode opcode, byte[] data, bool compressed)
		{
			byte[] rawFrame = new WebSocketFrame(fin, opcode, data, compressed, this._client).ToArray();
			return this.send(rawFrame);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00006BFC File Offset: 0x00004DFC
		private void sendAsync(Opcode opcode, Stream sourceStream, Action<bool> completed)
		{
			Func<Opcode, Stream, bool> sender = new Func<Opcode, Stream, bool>(this.send);
			sender.BeginInvoke(opcode, sourceStream, delegate(IAsyncResult ar)
			{
				try
				{
					bool obj = sender.EndInvoke(ar);
					if (completed != null)
					{
						completed(obj);
					}
				}
				catch (Exception ex)
				{
					this._log.Error(ex.Message);
					this._log.Debug(ex.ToString());
					this.error("An exception has occurred during the callback for an async send.", ex);
				}
			}, null);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00006C4C File Offset: 0x00004E4C
		private bool sendBytes(byte[] bytes)
		{
			try
			{
				this._stream.Write(bytes, 0, bytes.Length);
			}
			catch (Exception ex)
			{
				this._log.Error(ex.Message);
				this._log.Debug(ex.ToString());
				return false;
			}
			return true;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00006CAC File Offset: 0x00004EAC
		private HttpResponse sendHandshakeRequest()
		{
			HttpRequest httpRequest = this.createHandshakeRequest();
			int millisecondsTimeout = 90000;
			HttpResponse response = httpRequest.GetResponse(this._stream, millisecondsTimeout);
			if (response.IsUnauthorized)
			{
				string value = response.Headers["WWW-Authenticate"];
				if (value.IsNullOrEmpty())
				{
					this._log.Debug("No authentication challenge is specified.");
					return response;
				}
				AuthenticationChallenge authenticationChallenge = AuthenticationChallenge.Parse(value);
				if (authenticationChallenge == null)
				{
					this._log.Debug("An invalid authentication challenge is specified.");
					return response;
				}
				this._authChallenge = authenticationChallenge;
				if (this._credentials == null)
				{
					return response;
				}
				AuthenticationResponse authenticationResponse = new AuthenticationResponse(this._authChallenge, this._credentials, this._nonceCount);
				this._nonceCount = authenticationResponse.NonceCount;
				httpRequest.Headers["Authorization"] = authenticationResponse.ToString();
				if (response.CloseConnection)
				{
					this.releaseClientResources();
					this.setClientStream();
				}
				millisecondsTimeout = 15000;
				response = httpRequest.GetResponse(this._stream, millisecondsTimeout);
			}
			if (!response.IsRedirect)
			{
				return response;
			}
			if (!this._enableRedirection)
			{
				return response;
			}
			string text = response.Headers["Location"];
			if (text.IsNullOrEmpty())
			{
				this._log.Debug("No URL to redirect is located.");
				return response;
			}
			Uri uri;
			string text2;
			if (!text.TryCreateWebSocketUri(out uri, out text2))
			{
				this._log.Debug("An invalid URL to redirect is located.");
				return response;
			}
			this.releaseClientResources();
			this._uri = uri;
			this._secure = (uri.Scheme == "wss");
			this.setClientStream();
			return this.sendHandshakeRequest();
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00006E3C File Offset: 0x0000503C
		private HttpResponse sendProxyConnectRequest()
		{
			HttpRequest httpRequest = HttpRequest.CreateConnectRequest(this._uri);
			int millisecondsTimeout = 90000;
			HttpResponse response = httpRequest.GetResponse(this._stream, millisecondsTimeout);
			if (response.IsProxyAuthenticationRequired)
			{
				if (this._proxyCredentials == null)
				{
					return response;
				}
				string value = response.Headers["Proxy-Authenticate"];
				if (value.IsNullOrEmpty())
				{
					this._log.Debug("No proxy authentication challenge is specified.");
					return response;
				}
				AuthenticationChallenge authenticationChallenge = AuthenticationChallenge.Parse(value);
				if (authenticationChallenge == null)
				{
					this._log.Debug("An invalid proxy authentication challenge is specified.");
					return response;
				}
				AuthenticationResponse authenticationResponse = new AuthenticationResponse(authenticationChallenge, this._proxyCredentials, 0U);
				httpRequest.Headers["Proxy-Authorization"] = authenticationResponse.ToString();
				if (response.CloseConnection)
				{
					this.releaseClientResources();
					this._tcpClient = new TcpClient(this._proxyUri.DnsSafeHost, this._proxyUri.Port);
					this._stream = this._tcpClient.GetStream();
				}
				millisecondsTimeout = 15000;
				response = httpRequest.GetResponse(this._stream, millisecondsTimeout);
			}
			return response;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00006F48 File Offset: 0x00005148
		private void setClientStream()
		{
			if (this._proxyUri != null)
			{
				this._tcpClient = new TcpClient(this._proxyUri.DnsSafeHost, this._proxyUri.Port);
				this._stream = this._tcpClient.GetStream();
				HttpResponse response = this.sendProxyConnectRequest();
				string message;
				if (!this.checkProxyConnectResponse(response, out message))
				{
					throw new WebSocketException(message);
				}
			}
			else
			{
				this._tcpClient = new TcpClient(this._uri.DnsSafeHost, this._uri.Port);
				this._stream = this._tcpClient.GetStream();
			}
			if (this._secure)
			{
				ClientSslConfiguration sslConfiguration = this.getSslConfiguration();
				string targetHost = sslConfiguration.TargetHost;
				if (targetHost != this._uri.DnsSafeHost)
				{
					string message2 = "An invalid host name is specified.";
					throw new WebSocketException(CloseStatusCode.TlsHandshakeFailure, message2);
				}
				try
				{
					SslStream sslStream = new SslStream(this._stream, false, sslConfiguration.ServerCertificateValidationCallback, sslConfiguration.ClientCertificateSelectionCallback);
					sslStream.AuthenticateAsClient(targetHost, sslConfiguration.ClientCertificates, sslConfiguration.EnabledSslProtocols, sslConfiguration.CheckCertificateRevocation);
					this._stream = sslStream;
				}
				catch (Exception innerException)
				{
					throw new WebSocketException(CloseStatusCode.TlsHandshakeFailure, innerException);
				}
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00007080 File Offset: 0x00005280
		private void startReceiving()
		{
			if (this._messageEventQueue.Count > 0)
			{
				this._messageEventQueue.Clear();
			}
			this._pongReceived = new ManualResetEvent(false);
			this._receivingExited = new ManualResetEvent(false);
			Action receive = null;
			Action<WebSocketFrame> <>9__1;
			Action<Exception> <>9__2;
			receive = delegate()
			{
				Stream stream = this._stream;
				bool unmask = false;
				Action<WebSocketFrame> completed;
				if ((completed = <>9__1) == null)
				{
					completed = (<>9__1 = delegate(WebSocketFrame frame)
					{
						if (!this.processReceivedFrame(frame) || this._readyState == WebSocketState.Closed)
						{
							ManualResetEvent receivingExited = this._receivingExited;
							if (receivingExited != null)
							{
								receivingExited.Set();
							}
							return;
						}
						receive();
						if (this._inMessage)
						{
							return;
						}
						this.message();
					});
				}
				Action<Exception> error;
				if ((error = <>9__2) == null)
				{
					error = (<>9__2 = delegate(Exception ex)
					{
						this._log.Fatal(ex.Message);
						this._log.Debug(ex.ToString());
						this.abort("An exception has occurred while receiving.", ex);
					});
				}
				WebSocketFrame.ReadFrameAsync(stream, unmask, completed, error);
			};
			receive();
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000070F0 File Offset: 0x000052F0
		private bool validateSecWebSocketExtensionsServerHeader(string value)
		{
			if (!this._extensionsRequested)
			{
				return false;
			}
			if (value.Length == 0)
			{
				return false;
			}
			bool flag = this._compression > CompressionMethod.None;
			foreach (string text in value.SplitHeaderValue(new char[]
			{
				','
			}))
			{
				string text2 = text.Trim();
				if (!flag || !text2.IsCompressionExtension(this._compression))
				{
					return false;
				}
				string param1 = "server_no_context_takeover";
				string param2 = "client_no_context_takeover";
				if (!text2.Contains(param1))
				{
					return false;
				}
				string name = this._compression.ToExtensionString(Array.Empty<string>());
				if (text2.SplitHeaderValue(new char[]
				{
					';'
				}).Contains(delegate(string t)
				{
					t = t.Trim();
					return !(t == name) && !(t == param1) && !(t == param2);
				}))
				{
					return false;
				}
				flag = false;
			}
			return true;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000071FC File Offset: 0x000053FC
		internal void Accept()
		{
			if (!this.accept())
			{
				return;
			}
			this.open();
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00007210 File Offset: 0x00005410
		internal void AcceptAsync()
		{
			Func<bool> acceptor = new Func<bool>(this.accept);
			acceptor.BeginInvoke(delegate(IAsyncResult ar)
			{
				if (!acceptor.EndInvoke(ar))
				{
					return;
				}
				this.open();
			}, null);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00007258 File Offset: 0x00005458
		internal void Close(PayloadData payloadData, byte[] rawFrame)
		{
			object forState = this._forState;
			lock (forState)
			{
				if (this._readyState == WebSocketState.Closing)
				{
					this._log.Trace("The close process is already in progress.");
					return;
				}
				if (this._readyState == WebSocketState.Closed)
				{
					this._log.Trace("The connection has already been closed.");
					return;
				}
				this._readyState = WebSocketState.Closing;
			}
			this._log.Trace("Begin closing the connection.");
			bool flag2 = rawFrame != null && this.sendBytes(rawFrame);
			bool flag3 = flag2 && this._receivingExited != null && this._receivingExited.WaitOne(this._waitTime);
			bool flag4 = flag2 && flag3;
			string message = string.Format("The closing was clean? {0} (sent: {1} received: {2})", flag4, flag2, flag3);
			this._log.Debug(message);
			this.releaseServerResources();
			this.releaseCommonResources();
			this._log.Trace("End closing the connection.");
			this._readyState = WebSocketState.Closed;
			CloseEventArgs e = new CloseEventArgs(payloadData, flag4);
			try
			{
				this.OnClose.Emit(this, e);
			}
			catch (Exception ex)
			{
				this._log.Error(ex.Message);
				this._log.Debug(ex.ToString());
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000073CC File Offset: 0x000055CC
		internal static string CreateBase64Key()
		{
			byte[] array = new byte[16];
			WebSocket.RandomNumber.GetBytes(array);
			return Convert.ToBase64String(array);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x000073F4 File Offset: 0x000055F4
		internal static string CreateResponseKey(string base64Key)
		{
			HashAlgorithm hashAlgorithm = new SHA1CryptoServiceProvider();
			byte[] utf8EncodedBytes = (base64Key + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11").GetUTF8EncodedBytes();
			return Convert.ToBase64String(hashAlgorithm.ComputeHash(utf8EncodedBytes));
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00007424 File Offset: 0x00005624
		internal bool Ping(byte[] rawFrame)
		{
			if (this._readyState != WebSocketState.Open)
			{
				return false;
			}
			ManualResetEvent pongReceived = this._pongReceived;
			if (pongReceived == null)
			{
				return false;
			}
			object forPing = this._forPing;
			bool result;
			lock (forPing)
			{
				try
				{
					pongReceived.Reset();
					if (!this.send(rawFrame))
					{
						result = false;
					}
					else
					{
						result = pongReceived.WaitOne(this._waitTime);
					}
				}
				catch (ObjectDisposedException)
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000074AC File Offset: 0x000056AC
		internal void Send(Opcode opcode, byte[] data, Dictionary<CompressionMethod, byte[]> cache)
		{
			object forSend = this._forSend;
			lock (forSend)
			{
				byte[] array;
				if (!cache.TryGetValue(this._compression, out array))
				{
					array = new WebSocketFrame(Fin.Final, opcode, data.Compress(this._compression), this._compression > CompressionMethod.None, false).ToArray();
					cache.Add(this._compression, array);
				}
				this.send(array);
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00007530 File Offset: 0x00005730
		internal void Send(Opcode opcode, Stream sourceStream, Dictionary<CompressionMethod, Stream> cache)
		{
			object forSend = this._forSend;
			lock (forSend)
			{
				Stream stream;
				if (!cache.TryGetValue(this._compression, out stream))
				{
					stream = sourceStream.Compress(this._compression);
					cache.Add(this._compression, stream);
				}
				else
				{
					stream.Position = 0L;
				}
				this.send(opcode, stream, this._compression > CompressionMethod.None);
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000075B0 File Offset: 0x000057B0
		public void Close()
		{
			this.close(1005, string.Empty);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000075C2 File Offset: 0x000057C2
		public void Close(ushort code)
		{
			this.Close(code, string.Empty);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x000075D0 File Offset: 0x000057D0
		public void Close(CloseStatusCode code)
		{
			this.Close(code, string.Empty);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x000075E0 File Offset: 0x000057E0
		public void Close(ushort code, string reason)
		{
			if (!code.IsCloseStatusCode())
			{
				string message = "Less than 1000 or greater than 4999.";
				throw new ArgumentOutOfRangeException("code", message);
			}
			if (this._client && code == 1011)
			{
				throw new ArgumentException("1011 cannot be used.", "code");
			}
			if (!this._client && code == 1010)
			{
				throw new ArgumentException("1010 cannot be used.", "code");
			}
			if (reason.IsNullOrEmpty())
			{
				this.close(code, string.Empty);
				return;
			}
			if (code == 1005)
			{
				throw new ArgumentException("1005 cannot be used.", "code");
			}
			byte[] array;
			if (!reason.TryGetUTF8EncodedBytes(out array))
			{
				throw new ArgumentException("It could not be UTF-8-encoded.", "reason");
			}
			if (array.Length > 123)
			{
				string message2 = "Its size is greater than 123 bytes.";
				throw new ArgumentOutOfRangeException("reason", message2);
			}
			this.close(code, reason);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x000076B0 File Offset: 0x000058B0
		public void Close(CloseStatusCode code, string reason)
		{
			if (this._client && code == CloseStatusCode.ServerError)
			{
				throw new ArgumentException("ServerError cannot be used.", "code");
			}
			if (!this._client && code == CloseStatusCode.MandatoryExtension)
			{
				throw new ArgumentException("MandatoryExtension cannot be used.", "code");
			}
			if (reason.IsNullOrEmpty())
			{
				this.close((ushort)code, string.Empty);
				return;
			}
			if (code == CloseStatusCode.NoStatus)
			{
				throw new ArgumentException("NoStatus cannot be used.", "code");
			}
			byte[] array;
			if (!reason.TryGetUTF8EncodedBytes(out array))
			{
				throw new ArgumentException("It could not be UTF-8-encoded.", "reason");
			}
			if (array.Length > 123)
			{
				string message = "Its size is greater than 123 bytes.";
				throw new ArgumentOutOfRangeException("reason", message);
			}
			this.close((ushort)code, reason);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00007765 File Offset: 0x00005965
		public void CloseAsync()
		{
			this.closeAsync(1005, string.Empty);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00007777 File Offset: 0x00005977
		public void CloseAsync(ushort code)
		{
			this.CloseAsync(code, string.Empty);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00007785 File Offset: 0x00005985
		public void CloseAsync(CloseStatusCode code)
		{
			this.CloseAsync(code, string.Empty);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00007794 File Offset: 0x00005994
		public void CloseAsync(ushort code, string reason)
		{
			if (!code.IsCloseStatusCode())
			{
				string message = "Less than 1000 or greater than 4999.";
				throw new ArgumentOutOfRangeException("code", message);
			}
			if (this._client && code == 1011)
			{
				throw new ArgumentException("1011 cannot be used.", "code");
			}
			if (!this._client && code == 1010)
			{
				throw new ArgumentException("1010 cannot be used.", "code");
			}
			if (reason.IsNullOrEmpty())
			{
				this.closeAsync(code, string.Empty);
				return;
			}
			if (code == 1005)
			{
				throw new ArgumentException("1005 cannot be used.", "code");
			}
			byte[] array;
			if (!reason.TryGetUTF8EncodedBytes(out array))
			{
				throw new ArgumentException("It could not be UTF-8-encoded.", "reason");
			}
			if (array.Length > 123)
			{
				string message2 = "Its size is greater than 123 bytes.";
				throw new ArgumentOutOfRangeException("reason", message2);
			}
			this.closeAsync(code, reason);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00007864 File Offset: 0x00005A64
		public void CloseAsync(CloseStatusCode code, string reason)
		{
			if (this._client && code == CloseStatusCode.ServerError)
			{
				throw new ArgumentException("ServerError cannot be used.", "code");
			}
			if (!this._client && code == CloseStatusCode.MandatoryExtension)
			{
				throw new ArgumentException("MandatoryExtension cannot be used.", "code");
			}
			if (reason.IsNullOrEmpty())
			{
				this.closeAsync((ushort)code, string.Empty);
				return;
			}
			if (code == CloseStatusCode.NoStatus)
			{
				throw new ArgumentException("NoStatus cannot be used.", "code");
			}
			byte[] array;
			if (!reason.TryGetUTF8EncodedBytes(out array))
			{
				throw new ArgumentException("It could not be UTF-8-encoded.", "reason");
			}
			if (array.Length > 123)
			{
				string message = "Its size is greater than 123 bytes.";
				throw new ArgumentOutOfRangeException("reason", message);
			}
			this.closeAsync((ushort)code, reason);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00007919 File Offset: 0x00005B19
		public void Connect()
		{
			if (!this._client)
			{
				throw new InvalidOperationException("The interface is not for the client.");
			}
			if (this._retryCountForConnect >= WebSocket._maxRetryCountForConnect)
			{
				throw new InvalidOperationException("A series of reconnecting has failed.");
			}
			if (!this.connect())
			{
				return;
			}
			this.open();
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00007958 File Offset: 0x00005B58
		public void ConnectAsync()
		{
			if (!this._client)
			{
				throw new InvalidOperationException("The interface is not for the client.");
			}
			if (this._retryCountForConnect >= WebSocket._maxRetryCountForConnect)
			{
				throw new InvalidOperationException("A series of reconnecting has failed.");
			}
			Func<bool> connector = new Func<bool>(this.connect);
			connector.BeginInvoke(delegate(IAsyncResult ar)
			{
				if (!connector.EndInvoke(ar))
				{
					return;
				}
				this.open();
			}, null);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x000079C8 File Offset: 0x00005BC8
		public bool Ping()
		{
			return this.ping(WebSocket.EmptyBytes);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x000079D8 File Offset: 0x00005BD8
		public bool Ping(string message)
		{
			if (message.IsNullOrEmpty())
			{
				return this.ping(WebSocket.EmptyBytes);
			}
			byte[] array;
			if (!message.TryGetUTF8EncodedBytes(out array))
			{
				throw new ArgumentException("It could not be UTF-8-encoded.", "message");
			}
			if (array.Length > 125)
			{
				string message2 = "Its size is greater than 125 bytes.";
				throw new ArgumentOutOfRangeException("message", message2);
			}
			return this.ping(array);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00007A33 File Offset: 0x00005C33
		public void Send(byte[] data)
		{
			if (this._readyState != WebSocketState.Open)
			{
				throw new InvalidOperationException("The current state of the interface is not Open.");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			this.send(Opcode.Binary, new MemoryStream(data));
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00007A68 File Offset: 0x00005C68
		public void Send(FileInfo fileInfo)
		{
			if (this._readyState != WebSocketState.Open)
			{
				throw new InvalidOperationException("The current state of the interface is not Open.");
			}
			if (fileInfo == null)
			{
				throw new ArgumentNullException("fileInfo");
			}
			if (!fileInfo.Exists)
			{
				throw new ArgumentException("The file does not exist.", "fileInfo");
			}
			FileStream sourceStream;
			if (!fileInfo.TryOpenRead(out sourceStream))
			{
				throw new ArgumentException("The file could not be opened.", "fileInfo");
			}
			this.send(Opcode.Binary, sourceStream);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00007AD4 File Offset: 0x00005CD4
		public void Send(string data)
		{
			if (this._readyState != WebSocketState.Open)
			{
				throw new InvalidOperationException("The current state of the interface is not Open.");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			byte[] buffer;
			if (!data.TryGetUTF8EncodedBytes(out buffer))
			{
				throw new ArgumentException("It could not be UTF-8-encoded.", "data");
			}
			this.send(Opcode.Text, new MemoryStream(buffer));
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00007B30 File Offset: 0x00005D30
		public void Send(Stream stream, int length)
		{
			if (this._readyState != WebSocketState.Open)
			{
				throw new InvalidOperationException("The current state of the interface is not Open.");
			}
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream.CanRead)
			{
				throw new ArgumentException("It cannot be read.", "stream");
			}
			if (length < 1)
			{
				throw new ArgumentException("Less than 1.", "length");
			}
			byte[] array = stream.ReadBytes(length);
			int num = array.Length;
			if (num == 0)
			{
				throw new ArgumentException("No data could be read from it.", "stream");
			}
			if (num < length)
			{
				string message = string.Format("Only {0} byte(s) of data could be read from the stream.", num);
				this._log.Warn(message);
			}
			this.send(Opcode.Binary, new MemoryStream(array));
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00007BDD File Offset: 0x00005DDD
		public void SendAsync(byte[] data, Action<bool> completed)
		{
			if (this._readyState != WebSocketState.Open)
			{
				throw new InvalidOperationException("The current state of the interface is not Open.");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			this.sendAsync(Opcode.Binary, new MemoryStream(data), completed);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00007C14 File Offset: 0x00005E14
		public void SendAsync(FileInfo fileInfo, Action<bool> completed)
		{
			if (this._readyState != WebSocketState.Open)
			{
				throw new InvalidOperationException("The current state of the interface is not Open.");
			}
			if (fileInfo == null)
			{
				throw new ArgumentNullException("fileInfo");
			}
			if (!fileInfo.Exists)
			{
				throw new ArgumentException("The file does not exist.", "fileInfo");
			}
			FileStream sourceStream;
			if (!fileInfo.TryOpenRead(out sourceStream))
			{
				throw new ArgumentException("The file could not be opened.", "fileInfo");
			}
			this.sendAsync(Opcode.Binary, sourceStream, completed);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00007C80 File Offset: 0x00005E80
		public void SendAsync(string data, Action<bool> completed)
		{
			if (this._readyState != WebSocketState.Open)
			{
				throw new InvalidOperationException("The current state of the interface is not Open.");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			byte[] buffer;
			if (!data.TryGetUTF8EncodedBytes(out buffer))
			{
				throw new ArgumentException("It could not be UTF-8-encoded.", "data");
			}
			this.sendAsync(Opcode.Text, new MemoryStream(buffer), completed);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00007CDC File Offset: 0x00005EDC
		public void SendAsync(Stream stream, int length, Action<bool> completed)
		{
			if (this._readyState != WebSocketState.Open)
			{
				throw new InvalidOperationException("The current state of the interface is not Open.");
			}
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream.CanRead)
			{
				throw new ArgumentException("It cannot be read.", "stream");
			}
			if (length < 1)
			{
				throw new ArgumentException("Less than 1.", "length");
			}
			byte[] array = stream.ReadBytes(length);
			int num = array.Length;
			if (num == 0)
			{
				throw new ArgumentException("No data could be read from it.", "stream");
			}
			if (num < length)
			{
				string message = string.Format("Only {0} byte(s) of data could be read from the stream.", num);
				this._log.Warn(message);
			}
			this.sendAsync(Opcode.Binary, new MemoryStream(array), completed);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00007D8C File Offset: 0x00005F8C
		public void SetCookie(Cookie cookie)
		{
			if (!this._client)
			{
				throw new InvalidOperationException("The interface is not for the client.");
			}
			if (cookie == null)
			{
				throw new ArgumentNullException("cookie");
			}
			object forState = this._forState;
			lock (forState)
			{
				if (this.canSet())
				{
					object syncRoot = this._cookies.SyncRoot;
					lock (syncRoot)
					{
						this._cookies.SetOrRemove(cookie);
					}
				}
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00007E2C File Offset: 0x0000602C
		public void SetCredentials(string username, string password, bool preAuth)
		{
			if (!this._client)
			{
				throw new InvalidOperationException("The interface is not for the client.");
			}
			if (!username.IsNullOrEmpty() && (username.Contains(':') || !username.IsText()))
			{
				throw new ArgumentException("It contains an invalid character.", "username");
			}
			if (!password.IsNullOrEmpty() && !password.IsText())
			{
				throw new ArgumentException("It contains an invalid character.", "password");
			}
			object forState = this._forState;
			lock (forState)
			{
				if (this.canSet())
				{
					if (username.IsNullOrEmpty())
					{
						this._credentials = null;
						this._preAuth = false;
					}
					else
					{
						this._credentials = new NetworkCredential(username, password, this._uri.PathAndQuery, Array.Empty<string>());
						this._preAuth = preAuth;
					}
				}
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00007F0C File Offset: 0x0000610C
		public void SetProxy(string url, string username, string password)
		{
			if (!this._client)
			{
				throw new InvalidOperationException("The interface is not for the client.");
			}
			Uri uri = null;
			if (!url.IsNullOrEmpty())
			{
				if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
				{
					throw new ArgumentException("Not an absolute URI string.", "url");
				}
				if (uri.Scheme != "http")
				{
					throw new ArgumentException("The scheme part is not http.", "url");
				}
				if (uri.Segments.Length > 1)
				{
					throw new ArgumentException("It includes the path segments.", "url");
				}
			}
			if (!username.IsNullOrEmpty() && (username.Contains(':') || !username.IsText()))
			{
				throw new ArgumentException("It contains an invalid character.", "username");
			}
			if (!password.IsNullOrEmpty() && !password.IsText())
			{
				throw new ArgumentException("It contains an invalid character.", "password");
			}
			object forState = this._forState;
			lock (forState)
			{
				if (this.canSet())
				{
					if (url.IsNullOrEmpty())
					{
						this._proxyUri = null;
						this._proxyCredentials = null;
					}
					else
					{
						this._proxyUri = uri;
						this._proxyCredentials = ((!username.IsNullOrEmpty()) ? new NetworkCredential(username, password, string.Format("{0}:{1}", this._uri.DnsSafeHost, this._uri.Port), Array.Empty<string>()) : null);
					}
				}
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00008070 File Offset: 0x00006270
		void IDisposable.Dispose()
		{
			this.close(1001, string.Empty);
		}

		// Token: 0x04000052 RID: 82
		private AuthenticationChallenge _authChallenge;

		// Token: 0x04000053 RID: 83
		private string _base64Key;

		// Token: 0x04000054 RID: 84
		private bool _client;

		// Token: 0x04000055 RID: 85
		private Action _closeContext;

		// Token: 0x04000056 RID: 86
		private CompressionMethod _compression;

		// Token: 0x04000057 RID: 87
		private WebSocketContext _context;

		// Token: 0x04000058 RID: 88
		private CookieCollection _cookies;

		// Token: 0x04000059 RID: 89
		private NetworkCredential _credentials;

		// Token: 0x0400005A RID: 90
		private bool _emitOnPing;

		// Token: 0x0400005B RID: 91
		private bool _enableRedirection;

		// Token: 0x0400005C RID: 92
		private string _extensions;

		// Token: 0x0400005D RID: 93
		private bool _extensionsRequested;

		// Token: 0x0400005E RID: 94
		private object _forMessageEventQueue;

		// Token: 0x0400005F RID: 95
		private object _forPing;

		// Token: 0x04000060 RID: 96
		private object _forSend;

		// Token: 0x04000061 RID: 97
		private object _forState;

		// Token: 0x04000062 RID: 98
		private MemoryStream _fragmentsBuffer;

		// Token: 0x04000063 RID: 99
		private bool _fragmentsCompressed;

		// Token: 0x04000064 RID: 100
		private Opcode _fragmentsOpcode;

		// Token: 0x04000065 RID: 101
		private const string _guid = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";

		// Token: 0x04000066 RID: 102
		private Func<WebSocketContext, string> _handshakeRequestChecker;

		// Token: 0x04000067 RID: 103
		private bool _ignoreExtensions;

		// Token: 0x04000068 RID: 104
		private bool _inContinuation;

		// Token: 0x04000069 RID: 105
		private volatile bool _inMessage;

		// Token: 0x0400006A RID: 106
		private volatile Logger _log;

		// Token: 0x0400006B RID: 107
		private static readonly int _maxRetryCountForConnect = 10;

		// Token: 0x0400006C RID: 108
		private Action<MessageEventArgs> _message;

		// Token: 0x0400006D RID: 109
		private Queue<MessageEventArgs> _messageEventQueue;

		// Token: 0x0400006E RID: 110
		private uint _nonceCount;

		// Token: 0x0400006F RID: 111
		private string _origin;

		// Token: 0x04000070 RID: 112
		private ManualResetEvent _pongReceived;

		// Token: 0x04000071 RID: 113
		private bool _preAuth;

		// Token: 0x04000072 RID: 114
		private string _protocol;

		// Token: 0x04000073 RID: 115
		private string[] _protocols;

		// Token: 0x04000074 RID: 116
		private bool _protocolsRequested;

		// Token: 0x04000075 RID: 117
		private NetworkCredential _proxyCredentials;

		// Token: 0x04000076 RID: 118
		private Uri _proxyUri;

		// Token: 0x04000077 RID: 119
		private volatile WebSocketState _readyState;

		// Token: 0x04000078 RID: 120
		private ManualResetEvent _receivingExited;

		// Token: 0x04000079 RID: 121
		private int _retryCountForConnect;

		// Token: 0x0400007A RID: 122
		private bool _secure;

		// Token: 0x0400007B RID: 123
		private ClientSslConfiguration _sslConfig;

		// Token: 0x0400007C RID: 124
		private Stream _stream;

		// Token: 0x0400007D RID: 125
		private TcpClient _tcpClient;

		// Token: 0x0400007E RID: 126
		private Uri _uri;

		// Token: 0x0400007F RID: 127
		private const string _version = "13";

		// Token: 0x04000080 RID: 128
		private TimeSpan _waitTime;

		// Token: 0x04000081 RID: 129
		internal static readonly byte[] EmptyBytes = new byte[0];

		// Token: 0x04000082 RID: 130
		internal static readonly int FragmentLength = 1016;

		// Token: 0x04000083 RID: 131
		internal static readonly RandomNumberGenerator RandomNumber = new RNGCryptoServiceProvider();
	}
}
