using System;
using System.IO;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using UnityWebSocketSharp.Net;
using UnityWebSocketSharp.Net.WebSockets;

namespace UnityWebSocketSharp.Server
{
	// Token: 0x0200001A RID: 26
	internal class HttpServer
	{
		// Token: 0x0600019A RID: 410 RVA: 0x00008E3D File Offset: 0x0000703D
		public HttpServer()
		{
			this.init("*", IPAddress.Any, 80, false);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00008E58 File Offset: 0x00007058
		public HttpServer(int port) : this(port, port == 443)
		{
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00008E6C File Offset: 0x0000706C
		public HttpServer(string url)
		{
			if (url == null)
			{
				throw new ArgumentNullException("url");
			}
			if (url.Length == 0)
			{
				throw new ArgumentException("An empty string.", "url");
			}
			Uri uri;
			string message;
			if (!HttpServer.tryCreateUri(url, out uri, out message))
			{
				throw new ArgumentException(message, "url");
			}
			string dnsSafeHost = uri.GetDnsSafeHost(true);
			IPAddress ipaddress = dnsSafeHost.ToIPAddress();
			if (ipaddress == null)
			{
				message = "The host part could not be converted to an IP address.";
				throw new ArgumentException(message, "url");
			}
			if (!ipaddress.IsLocal())
			{
				message = "The IP address of the host is not a local IP address.";
				throw new ArgumentException(message, "url");
			}
			this.init(dnsSafeHost, ipaddress, uri.Port, uri.Scheme == "https");
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00008F1C File Offset: 0x0000711C
		public HttpServer(int port, bool secure)
		{
			if (!port.IsPortNumber())
			{
				string message = "Less than 1 or greater than 65535.";
				throw new ArgumentOutOfRangeException("port", message);
			}
			this.init("*", IPAddress.Any, port, secure);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00008F5B File Offset: 0x0000715B
		public HttpServer(IPAddress address, int port) : this(address, port, port == 443)
		{
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00008F70 File Offset: 0x00007170
		public HttpServer(IPAddress address, int port, bool secure)
		{
			if (address == null)
			{
				throw new ArgumentNullException("address");
			}
			if (!address.IsLocal())
			{
				throw new ArgumentException("Not a local IP address.", "address");
			}
			if (!port.IsPortNumber())
			{
				string message = "Less than 1 or greater than 65535.";
				throw new ArgumentOutOfRangeException("port", message);
			}
			this.init(address.ToString(true), address, port, secure);
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00008FD3 File Offset: 0x000071D3
		public IPAddress Address
		{
			get
			{
				return this._address;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00008FDB File Offset: 0x000071DB
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x00008FE8 File Offset: 0x000071E8
		public AuthenticationSchemes AuthenticationSchemes
		{
			get
			{
				return this._listener.AuthenticationSchemes;
			}
			set
			{
				object sync = this._sync;
				lock (sync)
				{
					if (this.canSet())
					{
						this._listener.AuthenticationSchemes = value;
					}
				}
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00009038 File Offset: 0x00007238
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x00009040 File Offset: 0x00007240
		public string DocumentRootPath
		{
			get
			{
				return this._docRootPath;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length == 0)
				{
					throw new ArgumentException("An empty string.", "value");
				}
				value = value.TrimSlashOrBackslashFromEnd();
				if (value == "/")
				{
					throw new ArgumentException("An absolute root.", "value");
				}
				if (value == "\\")
				{
					throw new ArgumentException("An absolute root.", "value");
				}
				if (value.Length == 2 && value[1] == ':')
				{
					throw new ArgumentException("An absolute root.", "value");
				}
				string text = null;
				try
				{
					text = Path.GetFullPath(value);
				}
				catch (Exception innerException)
				{
					throw new ArgumentException("An invalid path string.", "value", innerException);
				}
				if (text == "/")
				{
					throw new ArgumentException("An absolute root.", "value");
				}
				text = text.TrimSlashOrBackslashFromEnd();
				if (text.Length == 2 && text[1] == ':')
				{
					throw new ArgumentException("An absolute root.", "value");
				}
				object sync = this._sync;
				lock (sync)
				{
					if (this.canSet())
					{
						this._docRootPath = value;
					}
				}
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00009188 File Offset: 0x00007388
		public bool IsListening
		{
			get
			{
				return this._state == ServerState.Start;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x00009195 File Offset: 0x00007395
		public bool IsSecure
		{
			get
			{
				return this._secure;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x0000919D File Offset: 0x0000739D
		// (set) Token: 0x060001A8 RID: 424 RVA: 0x000091AA File Offset: 0x000073AA
		public bool KeepClean
		{
			get
			{
				return this._services.KeepClean;
			}
			set
			{
				this._services.KeepClean = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x000091B8 File Offset: 0x000073B8
		public Logger Log
		{
			get
			{
				return this._log;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001AA RID: 426 RVA: 0x000091C0 File Offset: 0x000073C0
		public int Port
		{
			get
			{
				return this._port;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001AB RID: 427 RVA: 0x000091C8 File Offset: 0x000073C8
		// (set) Token: 0x060001AC RID: 428 RVA: 0x000091D8 File Offset: 0x000073D8
		public string Realm
		{
			get
			{
				return this._listener.Realm;
			}
			set
			{
				object sync = this._sync;
				lock (sync)
				{
					if (this.canSet())
					{
						this._listener.Realm = value;
					}
				}
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001AD RID: 429 RVA: 0x00009228 File Offset: 0x00007428
		// (set) Token: 0x060001AE RID: 430 RVA: 0x00009238 File Offset: 0x00007438
		public bool ReuseAddress
		{
			get
			{
				return this._listener.ReuseAddress;
			}
			set
			{
				object sync = this._sync;
				lock (sync)
				{
					if (this.canSet())
					{
						this._listener.ReuseAddress = value;
					}
				}
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001AF RID: 431 RVA: 0x00009288 File Offset: 0x00007488
		public ServerSslConfiguration SslConfiguration
		{
			get
			{
				if (!this._secure)
				{
					throw new InvalidOperationException("The server does not provide secure connections.");
				}
				return this._listener.SslConfiguration;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x000092A8 File Offset: 0x000074A8
		// (set) Token: 0x060001B1 RID: 433 RVA: 0x000092B8 File Offset: 0x000074B8
		public Func<IIdentity, NetworkCredential> UserCredentialsFinder
		{
			get
			{
				return this._listener.UserCredentialsFinder;
			}
			set
			{
				object sync = this._sync;
				lock (sync)
				{
					if (this.canSet())
					{
						this._listener.UserCredentialsFinder = value;
					}
				}
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x00009308 File Offset: 0x00007508
		// (set) Token: 0x060001B3 RID: 435 RVA: 0x00009315 File Offset: 0x00007515
		public TimeSpan WaitTime
		{
			get
			{
				return this._services.WaitTime;
			}
			set
			{
				this._services.WaitTime = value;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x00009323 File Offset: 0x00007523
		public WebSocketServiceManager WebSocketServices
		{
			get
			{
				return this._services;
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060001B5 RID: 437 RVA: 0x0000932C File Offset: 0x0000752C
		// (remove) Token: 0x060001B6 RID: 438 RVA: 0x00009364 File Offset: 0x00007564
		public event EventHandler<HttpRequestEventArgs> OnConnect;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060001B7 RID: 439 RVA: 0x0000939C File Offset: 0x0000759C
		// (remove) Token: 0x060001B8 RID: 440 RVA: 0x000093D4 File Offset: 0x000075D4
		public event EventHandler<HttpRequestEventArgs> OnDelete;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060001B9 RID: 441 RVA: 0x0000940C File Offset: 0x0000760C
		// (remove) Token: 0x060001BA RID: 442 RVA: 0x00009444 File Offset: 0x00007644
		public event EventHandler<HttpRequestEventArgs> OnGet;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060001BB RID: 443 RVA: 0x0000947C File Offset: 0x0000767C
		// (remove) Token: 0x060001BC RID: 444 RVA: 0x000094B4 File Offset: 0x000076B4
		public event EventHandler<HttpRequestEventArgs> OnHead;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060001BD RID: 445 RVA: 0x000094EC File Offset: 0x000076EC
		// (remove) Token: 0x060001BE RID: 446 RVA: 0x00009524 File Offset: 0x00007724
		public event EventHandler<HttpRequestEventArgs> OnOptions;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060001BF RID: 447 RVA: 0x0000955C File Offset: 0x0000775C
		// (remove) Token: 0x060001C0 RID: 448 RVA: 0x00009594 File Offset: 0x00007794
		public event EventHandler<HttpRequestEventArgs> OnPost;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060001C1 RID: 449 RVA: 0x000095CC File Offset: 0x000077CC
		// (remove) Token: 0x060001C2 RID: 450 RVA: 0x00009604 File Offset: 0x00007804
		public event EventHandler<HttpRequestEventArgs> OnPut;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060001C3 RID: 451 RVA: 0x0000963C File Offset: 0x0000783C
		// (remove) Token: 0x060001C4 RID: 452 RVA: 0x00009674 File Offset: 0x00007874
		public event EventHandler<HttpRequestEventArgs> OnTrace;

		// Token: 0x060001C5 RID: 453 RVA: 0x000096AC File Offset: 0x000078AC
		private void abort()
		{
			object sync = this._sync;
			lock (sync)
			{
				if (this._state != ServerState.Start)
				{
					return;
				}
				this._state = ServerState.ShuttingDown;
			}
			try
			{
				this._services.Stop(1006, string.Empty);
			}
			catch (Exception ex)
			{
				this._log.Fatal(ex.Message);
				this._log.Debug(ex.ToString());
			}
			try
			{
				this._listener.Abort();
			}
			catch (Exception ex2)
			{
				this._log.Fatal(ex2.Message);
				this._log.Debug(ex2.ToString());
			}
			this._state = ServerState.Stop;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00009790 File Offset: 0x00007990
		private bool canSet()
		{
			return this._state == ServerState.Ready || this._state == ServerState.Stop;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x000097AC File Offset: 0x000079AC
		private bool checkCertificate(out string message)
		{
			message = null;
			bool flag = this._listener.SslConfiguration.ServerCertificate != null;
			string certificateFolderPath = this._listener.CertificateFolderPath;
			bool flag2 = EndPointListener.CertificateExists(this._port, certificateFolderPath);
			if (!flag && !flag2)
			{
				message = "There is no server certificate for secure connection.";
				return false;
			}
			if (flag && flag2)
			{
				string message2 = "The server certificate associated with the port is used.";
				this._log.Warn(message2);
			}
			return true;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00009810 File Offset: 0x00007A10
		private static HttpListener createListener(string hostname, int port, bool secure)
		{
			HttpListener httpListener = new HttpListener();
			string arg = secure ? "https" : "http";
			string uriPrefix = string.Format("{0}://{1}:{2}/", arg, hostname, port);
			httpListener.Prefixes.Add(uriPrefix);
			return httpListener;
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00009854 File Offset: 0x00007A54
		private void init(string hostname, IPAddress address, int port, bool secure)
		{
			this._hostname = hostname;
			this._address = address;
			this._port = port;
			this._secure = secure;
			this._docRootPath = "./Public";
			this._listener = HttpServer.createListener(this._hostname, this._port, this._secure);
			this._log = this._listener.Log;
			this._services = new WebSocketServiceManager(this._log);
			this._sync = new object();
		}

		// Token: 0x060001CA RID: 458 RVA: 0x000098D4 File Offset: 0x00007AD4
		private void processRequest(HttpListenerContext context)
		{
			string httpMethod = context.Request.HttpMethod;
			EventHandler<HttpRequestEventArgs> eventHandler = (httpMethod == "GET") ? this.OnGet : ((httpMethod == "HEAD") ? this.OnHead : ((httpMethod == "POST") ? this.OnPost : ((httpMethod == "PUT") ? this.OnPut : ((httpMethod == "DELETE") ? this.OnDelete : ((httpMethod == "CONNECT") ? this.OnConnect : ((httpMethod == "OPTIONS") ? this.OnOptions : ((httpMethod == "TRACE") ? this.OnTrace : null)))))));
			if (eventHandler == null)
			{
				context.ErrorStatusCode = 501;
				context.SendError();
				return;
			}
			HttpRequestEventArgs e = new HttpRequestEventArgs(context, this._docRootPath);
			eventHandler(this, e);
			context.Response.Close();
		}

		// Token: 0x060001CB RID: 459 RVA: 0x000099D4 File Offset: 0x00007BD4
		private void processRequest(HttpListenerWebSocketContext context)
		{
			Uri requestUri = context.RequestUri;
			if (requestUri == null)
			{
				context.Close(HttpStatusCode.BadRequest);
				return;
			}
			string text = requestUri.AbsolutePath;
			if (text.IndexOfAny(new char[]
			{
				'%',
				'+'
			}) > -1)
			{
				text = HttpUtility.UrlDecode(text, Encoding.UTF8);
			}
			WebSocketServiceHost webSocketServiceHost;
			if (!this._services.InternalTryGetServiceHost(text, out webSocketServiceHost))
			{
				context.Close(HttpStatusCode.NotImplemented);
				return;
			}
			webSocketServiceHost.StartSession(context);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00009A4C File Offset: 0x00007C4C
		private void receiveRequest()
		{
			for (;;)
			{
				HttpListenerContext ctx = null;
				try
				{
					ctx = this._listener.GetContext();
					ThreadPool.QueueUserWorkItem(delegate(object state)
					{
						try
						{
							if (ctx.Request.IsUpgradeRequest("websocket"))
							{
								this.processRequest(ctx.GetWebSocketContext(null));
							}
							else
							{
								this.processRequest(ctx);
							}
						}
						catch (Exception ex4)
						{
							this._log.Error(ex4.Message);
							this._log.Debug(ex4.ToString());
							ctx.Connection.Close(true);
						}
					});
					continue;
				}
				catch (HttpListenerException ex)
				{
					if (this._state == ServerState.ShuttingDown)
					{
						return;
					}
					this._log.Fatal(ex.Message);
					this._log.Debug(ex.ToString());
				}
				catch (InvalidOperationException ex2)
				{
					if (this._state == ServerState.ShuttingDown)
					{
						return;
					}
					this._log.Fatal(ex2.Message);
					this._log.Debug(ex2.ToString());
				}
				catch (Exception ex3)
				{
					this._log.Fatal(ex3.Message);
					this._log.Debug(ex3.ToString());
					if (ctx != null)
					{
						ctx.Connection.Close(true);
					}
					if (this._state == ServerState.ShuttingDown)
					{
						return;
					}
				}
				break;
			}
			this.abort();
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00009B74 File Offset: 0x00007D74
		private void start()
		{
			object sync = this._sync;
			lock (sync)
			{
				if (this._state != ServerState.Start && this._state != ServerState.ShuttingDown)
				{
					string message;
					if (this._secure && !this.checkCertificate(out message))
					{
						throw new InvalidOperationException(message);
					}
					this._services.Start();
					try
					{
						this.startReceiving();
					}
					catch
					{
						this._services.Stop(1011, string.Empty);
						throw;
					}
					this._state = ServerState.Start;
				}
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00009C20 File Offset: 0x00007E20
		private void startReceiving()
		{
			try
			{
				this._listener.Start();
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException("The underlying listener has failed to start.", innerException);
			}
			ThreadStart start = new ThreadStart(this.receiveRequest);
			this._receiveThread = new Thread(start);
			this._receiveThread.IsBackground = true;
			this._receiveThread.Start();
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00009C88 File Offset: 0x00007E88
		private void stop(ushort code, string reason)
		{
			object sync = this._sync;
			lock (sync)
			{
				if (this._state != ServerState.Start)
				{
					return;
				}
				this._state = ServerState.ShuttingDown;
			}
			try
			{
				this._services.Stop(code, reason);
			}
			catch (Exception ex)
			{
				this._log.Fatal(ex.Message);
				this._log.Debug(ex.ToString());
			}
			try
			{
				int millisecondsTimeout = 5000;
				this.stopReceiving(millisecondsTimeout);
			}
			catch (Exception ex2)
			{
				this._log.Fatal(ex2.Message);
				this._log.Debug(ex2.ToString());
			}
			this._state = ServerState.Stop;
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00009D6C File Offset: 0x00007F6C
		private void stopReceiving(int millisecondsTimeout)
		{
			this._listener.Stop();
			this._receiveThread.Join(millisecondsTimeout);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00009D88 File Offset: 0x00007F88
		private static bool tryCreateUri(string uriString, out Uri result, out string message)
		{
			result = null;
			message = null;
			Uri uri = uriString.ToUri();
			if (uri == null)
			{
				message = "An invalid URI string.";
				return false;
			}
			if (!uri.IsAbsoluteUri)
			{
				message = "A relative URI.";
				return false;
			}
			string scheme = uri.Scheme;
			if (!(scheme == "http") && !(scheme == "https"))
			{
				message = "The scheme part is not 'http' or 'https'.";
				return false;
			}
			if (uri.PathAndQuery != "/")
			{
				message = "It includes either or both path and query components.";
				return false;
			}
			if (uri.Fragment.Length > 0)
			{
				message = "It includes the fragment component.";
				return false;
			}
			if (uri.Port == 0)
			{
				message = "The port part is zero.";
				return false;
			}
			result = uri;
			return true;
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00009E39 File Offset: 0x00008039
		public void AddWebSocketService<TBehavior>(string path) where TBehavior : WebSocketBehavior, new()
		{
			this._services.AddService<TBehavior>(path, null);
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00009E48 File Offset: 0x00008048
		public void AddWebSocketService<TBehavior>(string path, Action<TBehavior> initializer) where TBehavior : WebSocketBehavior, new()
		{
			this._services.AddService<TBehavior>(path, initializer);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00009E57 File Offset: 0x00008057
		public bool RemoveWebSocketService(string path)
		{
			return this._services.RemoveService(path);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00009E65 File Offset: 0x00008065
		public void Start()
		{
			if (this._state == ServerState.Start || this._state == ServerState.ShuttingDown)
			{
				return;
			}
			this.start();
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00009E84 File Offset: 0x00008084
		public void Stop()
		{
			if (this._state != ServerState.Start)
			{
				return;
			}
			this.stop(1001, string.Empty);
		}

		// Token: 0x0400009D RID: 157
		private IPAddress _address;

		// Token: 0x0400009E RID: 158
		private string _docRootPath;

		// Token: 0x0400009F RID: 159
		private string _hostname;

		// Token: 0x040000A0 RID: 160
		private HttpListener _listener;

		// Token: 0x040000A1 RID: 161
		private Logger _log;

		// Token: 0x040000A2 RID: 162
		private int _port;

		// Token: 0x040000A3 RID: 163
		private Thread _receiveThread;

		// Token: 0x040000A4 RID: 164
		private bool _secure;

		// Token: 0x040000A5 RID: 165
		private WebSocketServiceManager _services;

		// Token: 0x040000A6 RID: 166
		private volatile ServerState _state;

		// Token: 0x040000A7 RID: 167
		private object _sync;
	}
}
