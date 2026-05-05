using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Threading;
using UnityWebSocketSharp.Net;
using UnityWebSocketSharp.Net.WebSockets;

namespace UnityWebSocketSharp.Server
{
	// Token: 0x0200001E RID: 30
	internal class WebSocketServer
	{
		// Token: 0x0600020C RID: 524 RVA: 0x0000A4C0 File Offset: 0x000086C0
		public WebSocketServer()
		{
			IPAddress any = IPAddress.Any;
			this.init(any.ToString(), any, 80, false);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000A4E9 File Offset: 0x000086E9
		public WebSocketServer(int port) : this(port, port == 443)
		{
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000A4FC File Offset: 0x000086FC
		public WebSocketServer(string url)
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
			if (!WebSocketServer.tryCreateUri(url, out uri, out message))
			{
				throw new ArgumentException(message, "url");
			}
			string dnsSafeHost = uri.DnsSafeHost;
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
			this.init(dnsSafeHost, ipaddress, uri.Port, uri.Scheme == "wss");
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000A5A8 File Offset: 0x000087A8
		public WebSocketServer(int port, bool secure)
		{
			if (!port.IsPortNumber())
			{
				string message = "Less than 1 or greater than 65535.";
				throw new ArgumentOutOfRangeException("port", message);
			}
			IPAddress any = IPAddress.Any;
			this.init(any.ToString(), any, port, secure);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000A5EA File Offset: 0x000087EA
		public WebSocketServer(IPAddress address, int port) : this(address, port, port == 443)
		{
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000A5FC File Offset: 0x000087FC
		public WebSocketServer(IPAddress address, int port, bool secure)
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
			this.init(address.ToString(), address, port, secure);
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000212 RID: 530 RVA: 0x0000A65E File Offset: 0x0000885E
		public IPAddress Address
		{
			get
			{
				return this._address;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000213 RID: 531 RVA: 0x0000A666 File Offset: 0x00008866
		// (set) Token: 0x06000214 RID: 532 RVA: 0x0000A670 File Offset: 0x00008870
		public AuthenticationSchemes AuthenticationSchemes
		{
			get
			{
				return this._authSchemes;
			}
			set
			{
				object sync = this._sync;
				lock (sync)
				{
					if (this.canSet())
					{
						this._authSchemes = value;
					}
				}
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000215 RID: 533 RVA: 0x0000A6BC File Offset: 0x000088BC
		public bool IsListening
		{
			get
			{
				return this._state == ServerState.Start;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000216 RID: 534 RVA: 0x0000A6C9 File Offset: 0x000088C9
		public bool IsSecure
		{
			get
			{
				return this._secure;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000217 RID: 535 RVA: 0x0000A6D1 File Offset: 0x000088D1
		// (set) Token: 0x06000218 RID: 536 RVA: 0x0000A6DE File Offset: 0x000088DE
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

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000219 RID: 537 RVA: 0x0000A6EC File Offset: 0x000088EC
		public Logger Log
		{
			get
			{
				return this._log;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600021A RID: 538 RVA: 0x0000A6F4 File Offset: 0x000088F4
		public int Port
		{
			get
			{
				return this._port;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600021B RID: 539 RVA: 0x0000A6FC File Offset: 0x000088FC
		// (set) Token: 0x0600021C RID: 540 RVA: 0x0000A704 File Offset: 0x00008904
		public string Realm
		{
			get
			{
				return this._realm;
			}
			set
			{
				object sync = this._sync;
				lock (sync)
				{
					if (this.canSet())
					{
						this._realm = value;
					}
				}
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600021D RID: 541 RVA: 0x0000A750 File Offset: 0x00008950
		// (set) Token: 0x0600021E RID: 542 RVA: 0x0000A758 File Offset: 0x00008958
		public bool ReuseAddress
		{
			get
			{
				return this._reuseAddress;
			}
			set
			{
				object sync = this._sync;
				lock (sync)
				{
					if (this.canSet())
					{
						this._reuseAddress = value;
					}
				}
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600021F RID: 543 RVA: 0x0000A7A4 File Offset: 0x000089A4
		public ServerSslConfiguration SslConfiguration
		{
			get
			{
				if (!this._secure)
				{
					throw new InvalidOperationException("The server does not provide secure connections.");
				}
				return this.getSslConfiguration();
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000220 RID: 544 RVA: 0x0000A7BF File Offset: 0x000089BF
		// (set) Token: 0x06000221 RID: 545 RVA: 0x0000A7C8 File Offset: 0x000089C8
		public Func<IIdentity, NetworkCredential> UserCredentialsFinder
		{
			get
			{
				return this._userCredFinder;
			}
			set
			{
				object sync = this._sync;
				lock (sync)
				{
					if (this.canSet())
					{
						this._userCredFinder = value;
					}
				}
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000222 RID: 546 RVA: 0x0000A814 File Offset: 0x00008A14
		// (set) Token: 0x06000223 RID: 547 RVA: 0x0000A821 File Offset: 0x00008A21
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

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000224 RID: 548 RVA: 0x0000A82F File Offset: 0x00008A2F
		public WebSocketServiceManager WebSocketServices
		{
			get
			{
				return this._services;
			}
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000A838 File Offset: 0x00008A38
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
				this._listener.Stop();
			}
			catch (Exception ex)
			{
				this._log.Fatal(ex.Message);
				this._log.Debug(ex.ToString());
			}
			try
			{
				this._services.Stop(1006, string.Empty);
			}
			catch (Exception ex2)
			{
				this._log.Fatal(ex2.Message);
				this._log.Debug(ex2.ToString());
			}
			this._state = ServerState.Stop;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000A91C File Offset: 0x00008B1C
		private bool authenticateClient(TcpListenerWebSocketContext context)
		{
			if (this._authSchemes == AuthenticationSchemes.Anonymous)
			{
				return true;
			}
			if (this._authSchemes == AuthenticationSchemes.None)
			{
				return false;
			}
			string chal = new AuthenticationChallenge(this._authSchemes, this._realmInUse).ToString();
			int retry = -1;
			Func<bool> auth = null;
			auth = delegate()
			{
				int retry = retry;
				retry++;
				if (retry > 99)
				{
					return false;
				}
				if (context.SetUser(this._authSchemes, this._realmInUse, this._userCredFinder))
				{
					return true;
				}
				context.SendAuthenticationChallenge(chal);
				return auth();
			};
			return auth();
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000A99D File Offset: 0x00008B9D
		private bool canSet()
		{
			return this._state == ServerState.Ready || this._state == ServerState.Stop;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000A9B6 File Offset: 0x00008BB6
		private bool checkHostNameForRequest(string name)
		{
			return !this._dnsStyle || Uri.CheckHostName(name) != UriHostNameType.Dns || name == this._hostname;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000A9D8 File Offset: 0x00008BD8
		private string getRealm()
		{
			string realm = this._realm;
			if (realm == null || realm.Length <= 0)
			{
				return WebSocketServer._defaultRealm;
			}
			return realm;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000A9FF File Offset: 0x00008BFF
		private ServerSslConfiguration getSslConfiguration()
		{
			if (this._sslConfig == null)
			{
				this._sslConfig = new ServerSslConfiguration();
			}
			return this._sslConfig;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000AA1C File Offset: 0x00008C1C
		private void init(string hostname, IPAddress address, int port, bool secure)
		{
			this._hostname = hostname;
			this._address = address;
			this._port = port;
			this._secure = secure;
			this._authSchemes = AuthenticationSchemes.Anonymous;
			this._dnsStyle = (Uri.CheckHostName(hostname) == UriHostNameType.Dns);
			this._listener = new TcpListener(address, port);
			this._log = new Logger();
			this._services = new WebSocketServiceManager(this._log);
			this._sync = new object();
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000AA94 File Offset: 0x00008C94
		private void processRequest(TcpListenerWebSocketContext context)
		{
			if (!this.authenticateClient(context))
			{
				context.Close(HttpStatusCode.Forbidden);
				return;
			}
			Uri requestUri = context.RequestUri;
			if (requestUri == null)
			{
				context.Close(HttpStatusCode.BadRequest);
				return;
			}
			string dnsSafeHost = requestUri.DnsSafeHost;
			if (!this.checkHostNameForRequest(dnsSafeHost))
			{
				context.Close(HttpStatusCode.NotFound);
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

		// Token: 0x0600022D RID: 557 RVA: 0x0000AB40 File Offset: 0x00008D40
		private void receiveRequest()
		{
			for (;;)
			{
				TcpClient cl = null;
				try
				{
					cl = this._listener.AcceptTcpClient();
					ThreadPool.QueueUserWorkItem(delegate(object state)
					{
						try
						{
							TcpListenerWebSocketContext context = new TcpListenerWebSocketContext(cl, null, this._secure, this._sslConfigInUse, this._log);
							this.processRequest(context);
						}
						catch (Exception ex4)
						{
							this._log.Error(ex4.Message);
							this._log.Debug(ex4.ToString());
							cl.Close();
						}
					});
					continue;
				}
				catch (SocketException ex)
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
					if (cl != null)
					{
						cl.Close();
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

		// Token: 0x0600022E RID: 558 RVA: 0x0000AC60 File Offset: 0x00008E60
		private void start()
		{
			object sync = this._sync;
			lock (sync)
			{
				if (this._state != ServerState.Start && this._state != ServerState.ShuttingDown)
				{
					if (this._secure)
					{
						ServerSslConfiguration serverSslConfiguration = new ServerSslConfiguration(this.getSslConfiguration());
						if (serverSslConfiguration.ServerCertificate == null)
						{
							throw new InvalidOperationException("There is no server certificate for secure connection.");
						}
						this._sslConfigInUse = serverSslConfiguration;
					}
					this._realmInUse = this.getRealm();
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

		// Token: 0x0600022F RID: 559 RVA: 0x0000AD2C File Offset: 0x00008F2C
		private void startReceiving()
		{
			if (this._reuseAddress)
			{
				this._listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
			}
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

		// Token: 0x06000230 RID: 560 RVA: 0x0000ADB4 File Offset: 0x00008FB4
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
				int millisecondsTimeout = 5000;
				this.stopReceiving(millisecondsTimeout);
			}
			catch (Exception ex)
			{
				this._log.Fatal(ex.Message);
				this._log.Debug(ex.ToString());
			}
			try
			{
				this._services.Stop(code, reason);
			}
			catch (Exception ex2)
			{
				this._log.Fatal(ex2.Message);
				this._log.Debug(ex2.ToString());
			}
			this._state = ServerState.Stop;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000AE98 File Offset: 0x00009098
		private void stopReceiving(int millisecondsTimeout)
		{
			this._listener.Stop();
			this._receiveThread.Join(millisecondsTimeout);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000AEB2 File Offset: 0x000090B2
		private static bool tryCreateUri(string uriString, out Uri result, out string message)
		{
			if (!uriString.TryCreateWebSocketUri(out result, out message))
			{
				return false;
			}
			if (result.PathAndQuery != "/")
			{
				result = null;
				message = "It includes either or both path and query components.";
				return false;
			}
			return true;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000AEE0 File Offset: 0x000090E0
		public void AddWebSocketService<TBehavior>(string path) where TBehavior : WebSocketBehavior, new()
		{
			this._services.AddService<TBehavior>(path, null);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000AEEF File Offset: 0x000090EF
		public void AddWebSocketService<TBehavior>(string path, Action<TBehavior> initializer) where TBehavior : WebSocketBehavior, new()
		{
			this._services.AddService<TBehavior>(path, initializer);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000AEFE File Offset: 0x000090FE
		public bool RemoveWebSocketService(string path)
		{
			return this._services.RemoveService(path);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000AF0C File Offset: 0x0000910C
		public void Start()
		{
			if (this._state == ServerState.Start || this._state == ServerState.ShuttingDown)
			{
				return;
			}
			this.start();
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000AF2B File Offset: 0x0000912B
		public void Stop()
		{
			if (this._state != ServerState.Start)
			{
				return;
			}
			this.stop(1001, string.Empty);
		}

		// Token: 0x040000C0 RID: 192
		private IPAddress _address;

		// Token: 0x040000C1 RID: 193
		private AuthenticationSchemes _authSchemes;

		// Token: 0x040000C2 RID: 194
		private static readonly string _defaultRealm = "SECRET AREA";

		// Token: 0x040000C3 RID: 195
		private bool _dnsStyle;

		// Token: 0x040000C4 RID: 196
		private string _hostname;

		// Token: 0x040000C5 RID: 197
		private TcpListener _listener;

		// Token: 0x040000C6 RID: 198
		private Logger _log;

		// Token: 0x040000C7 RID: 199
		private int _port;

		// Token: 0x040000C8 RID: 200
		private string _realm;

		// Token: 0x040000C9 RID: 201
		private string _realmInUse;

		// Token: 0x040000CA RID: 202
		private Thread _receiveThread;

		// Token: 0x040000CB RID: 203
		private bool _reuseAddress;

		// Token: 0x040000CC RID: 204
		private bool _secure;

		// Token: 0x040000CD RID: 205
		private WebSocketServiceManager _services;

		// Token: 0x040000CE RID: 206
		private ServerSslConfiguration _sslConfig;

		// Token: 0x040000CF RID: 207
		private ServerSslConfiguration _sslConfigInUse;

		// Token: 0x040000D0 RID: 208
		private volatile ServerState _state;

		// Token: 0x040000D1 RID: 209
		private object _sync;

		// Token: 0x040000D2 RID: 210
		private Func<IIdentity, NetworkCredential> _userCredFinder;
	}
}
