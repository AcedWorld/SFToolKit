using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Threading;
using WebSocketSharp.Net;
using WebSocketSharp.Net.WebSockets;

namespace WebSocketSharp.Server
{
	// Token: 0x02000045 RID: 69
	public class WebSocketServer
	{
		// Token: 0x0600045D RID: 1117 RVA: 0x00019654 File Offset: 0x00017854
		public WebSocketServer()
		{
			IPAddress any = IPAddress.Any;
			this.init(any.ToString(), any, 80, false);
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00019680 File Offset: 0x00017880
		public WebSocketServer(int port) : this(port, port == 443)
		{
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00019694 File Offset: 0x00017894
		public WebSocketServer(string url)
		{
			bool flag = url == null;
			if (flag)
			{
				throw new ArgumentNullException("url");
			}
			bool flag2 = url.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("An empty string.", "url");
			}
			Uri uri;
			string message;
			bool flag3 = !WebSocketServer.tryCreateUri(url, out uri, out message);
			if (flag3)
			{
				throw new ArgumentException(message, "url");
			}
			string dnsSafeHost = uri.DnsSafeHost;
			IPAddress ipaddress = dnsSafeHost.ToIPAddress();
			bool flag4 = ipaddress == null;
			if (flag4)
			{
				message = "The host part could not be converted to an IP address.";
				throw new ArgumentException(message, "url");
			}
			bool flag5 = !ipaddress.IsLocal();
			if (flag5)
			{
				message = "The IP address of the host is not a local IP address.";
				throw new ArgumentException(message, "url");
			}
			this.init(dnsSafeHost, ipaddress, uri.Port, uri.Scheme == "wss");
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x00019768 File Offset: 0x00017968
		public WebSocketServer(int port, bool secure)
		{
			bool flag = !port.IsPortNumber();
			if (flag)
			{
				string message = "It is less than 1 or greater than 65535.";
				throw new ArgumentOutOfRangeException("port", message);
			}
			IPAddress any = IPAddress.Any;
			this.init(any.ToString(), any, port, secure);
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x000197B3 File Offset: 0x000179B3
		public WebSocketServer(IPAddress address, int port) : this(address, port, port == 443)
		{
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x000197C8 File Offset: 0x000179C8
		public WebSocketServer(IPAddress address, int port, bool secure)
		{
			bool flag = address == null;
			if (flag)
			{
				throw new ArgumentNullException("address");
			}
			bool flag2 = !address.IsLocal();
			if (flag2)
			{
				string message = "It is not a local IP address.";
				throw new ArgumentException(message, "address");
			}
			bool flag3 = !port.IsPortNumber();
			if (flag3)
			{
				string message2 = "It is less than 1 or greater than 65535.";
				throw new ArgumentOutOfRangeException("port", message2);
			}
			this.init(address.ToString(), address, port, secure);
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000463 RID: 1123 RVA: 0x00019844 File Offset: 0x00017A44
		public IPAddress Address
		{
			get
			{
				return this._address;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x0001985C File Offset: 0x00017A5C
		// (set) Token: 0x06000465 RID: 1125 RVA: 0x00019874 File Offset: 0x00017A74
		public bool AllowForwardedRequest
		{
			get
			{
				return this._allowForwardedRequest;
			}
			set
			{
				object sync = this._sync;
				lock (sync)
				{
					string message;
					bool flag2 = !this.canSet(out message);
					if (flag2)
					{
						this._log.Warn(message);
					}
					else
					{
						this._allowForwardedRequest = value;
					}
				}
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000466 RID: 1126 RVA: 0x000198DC File Offset: 0x00017ADC
		// (set) Token: 0x06000467 RID: 1127 RVA: 0x000198F4 File Offset: 0x00017AF4
		public WebSocketSharp.Net.AuthenticationSchemes AuthenticationSchemes
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
					string message;
					bool flag2 = !this.canSet(out message);
					if (flag2)
					{
						this._log.Warn(message);
					}
					else
					{
						this._authSchemes = value;
					}
				}
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000468 RID: 1128 RVA: 0x0001995C File Offset: 0x00017B5C
		public bool IsListening
		{
			get
			{
				return this._state == ServerState.Start;
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x0001997C File Offset: 0x00017B7C
		public bool IsSecure
		{
			get
			{
				return this._secure;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x0600046A RID: 1130 RVA: 0x00019994 File Offset: 0x00017B94
		// (set) Token: 0x0600046B RID: 1131 RVA: 0x000199B1 File Offset: 0x00017BB1
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

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x000199C4 File Offset: 0x00017BC4
		public Logger Log
		{
			get
			{
				return this._log;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x0600046D RID: 1133 RVA: 0x000199DC File Offset: 0x00017BDC
		public int Port
		{
			get
			{
				return this._port;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x000199F4 File Offset: 0x00017BF4
		// (set) Token: 0x0600046F RID: 1135 RVA: 0x00019A0C File Offset: 0x00017C0C
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
					string message;
					bool flag2 = !this.canSet(out message);
					if (flag2)
					{
						this._log.Warn(message);
					}
					else
					{
						this._realm = value;
					}
				}
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x00019A74 File Offset: 0x00017C74
		// (set) Token: 0x06000471 RID: 1137 RVA: 0x00019A8C File Offset: 0x00017C8C
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
					string message;
					bool flag2 = !this.canSet(out message);
					if (flag2)
					{
						this._log.Warn(message);
					}
					else
					{
						this._reuseAddress = value;
					}
				}
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x00019AF4 File Offset: 0x00017CF4
		public ServerSslConfiguration SslConfiguration
		{
			get
			{
				bool flag = !this._secure;
				if (flag)
				{
					string message = "The server does not provide secure connections.";
					throw new InvalidOperationException(message);
				}
				return this.getSslConfiguration();
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000473 RID: 1139 RVA: 0x00019B28 File Offset: 0x00017D28
		// (set) Token: 0x06000474 RID: 1140 RVA: 0x00019B40 File Offset: 0x00017D40
		public Func<IIdentity, WebSocketSharp.Net.NetworkCredential> UserCredentialsFinder
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
					string message;
					bool flag2 = !this.canSet(out message);
					if (flag2)
					{
						this._log.Warn(message);
					}
					else
					{
						this._userCredFinder = value;
					}
				}
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x00019BA8 File Offset: 0x00017DA8
		// (set) Token: 0x06000476 RID: 1142 RVA: 0x00019BC5 File Offset: 0x00017DC5
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

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000477 RID: 1143 RVA: 0x00019BD8 File Offset: 0x00017DD8
		public WebSocketServiceManager WebSocketServices
		{
			get
			{
				return this._services;
			}
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00019BF0 File Offset: 0x00017DF0
		private void abort()
		{
			object sync = this._sync;
			lock (sync)
			{
				bool flag2 = this._state != ServerState.Start;
				if (flag2)
				{
					return;
				}
				this._state = ServerState.ShuttingDown;
			}
			try
			{
				try
				{
					this._listener.Stop();
				}
				finally
				{
					this._services.Stop(1006, string.Empty);
				}
			}
			catch
			{
			}
			this._state = ServerState.Stop;
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00019CA0 File Offset: 0x00017EA0
		private bool authenticateClient(TcpListenerWebSocketContext context)
		{
			bool flag = this._authSchemes == WebSocketSharp.Net.AuthenticationSchemes.Anonymous;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this._authSchemes == WebSocketSharp.Net.AuthenticationSchemes.None;
				result = (!flag2 && context.Authenticate(this._authSchemes, this._realmInUse, this._userCredFinder));
			}
			return result;
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00019CF0 File Offset: 0x00017EF0
		private bool canSet(out string message)
		{
			message = null;
			bool flag = this._state == ServerState.Start;
			bool result;
			if (flag)
			{
				message = "The server has already started.";
				result = false;
			}
			else
			{
				bool flag2 = this._state == ServerState.ShuttingDown;
				if (flag2)
				{
					message = "The server is shutting down.";
					result = false;
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00019D3C File Offset: 0x00017F3C
		private bool checkHostNameForRequest(string name)
		{
			return !this._dnsStyle || Uri.CheckHostName(name) != UriHostNameType.Dns || name == this._hostname;
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x00019D70 File Offset: 0x00017F70
		private string getRealm()
		{
			string realm = this._realm;
			return (realm != null && realm.Length > 0) ? realm : WebSocketServer._defaultRealm;
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00019DA0 File Offset: 0x00017FA0
		private ServerSslConfiguration getSslConfiguration()
		{
			bool flag = this._sslConfig == null;
			if (flag)
			{
				this._sslConfig = new ServerSslConfiguration();
			}
			return this._sslConfig;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00019DD0 File Offset: 0x00017FD0
		private void init(string hostname, IPAddress address, int port, bool secure)
		{
			this._hostname = hostname;
			this._address = address;
			this._port = port;
			this._secure = secure;
			this._authSchemes = WebSocketSharp.Net.AuthenticationSchemes.Anonymous;
			this._dnsStyle = (Uri.CheckHostName(hostname) == UriHostNameType.Dns);
			this._listener = new TcpListener(address, port);
			this._log = new Logger();
			this._services = new WebSocketServiceManager(this._log);
			this._sync = new object();
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00019E4C File Offset: 0x0001804C
		private void processRequest(TcpListenerWebSocketContext context)
		{
			bool flag = !this.authenticateClient(context);
			if (flag)
			{
				context.Close(WebSocketSharp.Net.HttpStatusCode.Forbidden);
			}
			else
			{
				Uri requestUri = context.RequestUri;
				bool flag2 = requestUri == null;
				if (flag2)
				{
					context.Close(WebSocketSharp.Net.HttpStatusCode.BadRequest);
				}
				else
				{
					bool flag3 = !this._allowForwardedRequest;
					if (flag3)
					{
						bool flag4 = requestUri.Port != this._port;
						if (flag4)
						{
							context.Close(WebSocketSharp.Net.HttpStatusCode.BadRequest);
							return;
						}
						bool flag5 = !this.checkHostNameForRequest(requestUri.DnsSafeHost);
						if (flag5)
						{
							context.Close(WebSocketSharp.Net.HttpStatusCode.NotFound);
							return;
						}
					}
					string text = requestUri.AbsolutePath;
					bool flag6 = text.IndexOfAny(new char[]
					{
						'%',
						'+'
					}) > -1;
					if (flag6)
					{
						text = HttpUtility.UrlDecode(text, Encoding.UTF8);
					}
					WebSocketServiceHost webSocketServiceHost;
					bool flag7 = !this._services.InternalTryGetServiceHost(text, out webSocketServiceHost);
					if (flag7)
					{
						context.Close(WebSocketSharp.Net.HttpStatusCode.NotImplemented);
					}
					else
					{
						webSocketServiceHost.StartSession(context);
					}
				}
			}
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00019F60 File Offset: 0x00018160
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
						catch (Exception ex3)
						{
							this._log.Error(ex3.Message);
							this._log.Debug(ex3.ToString());
							cl.Close();
						}
					});
				}
				catch (SocketException ex)
				{
					bool flag = this._state == ServerState.ShuttingDown;
					if (flag)
					{
						this._log.Info("The underlying listener is stopped.");
						break;
					}
					this._log.Fatal(ex.Message);
					this._log.Debug(ex.ToString());
					break;
				}
				catch (Exception ex2)
				{
					this._log.Fatal(ex2.Message);
					this._log.Debug(ex2.ToString());
					bool flag2 = cl != null;
					if (flag2)
					{
						cl.Close();
					}
					break;
				}
			}
			bool flag3 = this._state != ServerState.ShuttingDown;
			if (flag3)
			{
				this.abort();
			}
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0001A080 File Offset: 0x00018280
		private void start(ServerSslConfiguration sslConfig)
		{
			object sync = this._sync;
			lock (sync)
			{
				bool flag2 = this._state == ServerState.Start;
				if (flag2)
				{
					this._log.Info("The server has already started.");
				}
				else
				{
					bool flag3 = this._state == ServerState.ShuttingDown;
					if (flag3)
					{
						this._log.Warn("The server is shutting down.");
					}
					else
					{
						this._sslConfigInUse = sslConfig;
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
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0001A160 File Offset: 0x00018360
		private void startReceiving()
		{
			bool reuseAddress = this._reuseAddress;
			if (reuseAddress)
			{
				this._listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
			}
			try
			{
				this._listener.Start();
			}
			catch (Exception innerException)
			{
				string message = "The underlying listener has failed to start.";
				throw new InvalidOperationException(message, innerException);
			}
			this._receiveThread = new Thread(new ThreadStart(this.receiveRequest));
			this._receiveThread.IsBackground = true;
			this._receiveThread.Start();
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0001A1F4 File Offset: 0x000183F4
		private void stop(ushort code, string reason)
		{
			object sync = this._sync;
			lock (sync)
			{
				bool flag2 = this._state == ServerState.ShuttingDown;
				if (flag2)
				{
					this._log.Info("The server is shutting down.");
					return;
				}
				bool flag3 = this._state == ServerState.Stop;
				if (flag3)
				{
					this._log.Info("The server has already stopped.");
					return;
				}
				this._state = ServerState.ShuttingDown;
			}
			try
			{
				bool flag4 = false;
				try
				{
					this.stopReceiving(5000);
				}
				catch
				{
					flag4 = true;
					throw;
				}
				finally
				{
					try
					{
						this._services.Stop(code, reason);
					}
					catch
					{
						bool flag5 = !flag4;
						if (flag5)
						{
							throw;
						}
					}
				}
			}
			finally
			{
				this._state = ServerState.Stop;
			}
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0001A30C File Offset: 0x0001850C
		private void stopReceiving(int millisecondsTimeout)
		{
			try
			{
				this._listener.Stop();
			}
			catch (Exception innerException)
			{
				string message = "The underlying listener has failed to stop.";
				throw new InvalidOperationException(message, innerException);
			}
			this._receiveThread.Join(millisecondsTimeout);
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0001A358 File Offset: 0x00018558
		private static bool tryCreateUri(string uriString, out Uri result, out string message)
		{
			bool flag = !uriString.TryCreateWebSocketUri(out result, out message);
			bool result2;
			if (flag)
			{
				result2 = false;
			}
			else
			{
				bool flag2 = result.PathAndQuery != "/";
				if (flag2)
				{
					result = null;
					message = "It includes either or both path and query components.";
					result2 = false;
				}
				else
				{
					result2 = true;
				}
			}
			return result2;
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0001A3A2 File Offset: 0x000185A2
		public void AddWebSocketService<TBehavior>(string path) where TBehavior : WebSocketBehavior, new()
		{
			this._services.AddService<TBehavior>(path, null);
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x0001A3B3 File Offset: 0x000185B3
		public void AddWebSocketService<TBehavior>(string path, Action<TBehavior> initializer) where TBehavior : WebSocketBehavior, new()
		{
			this._services.AddService<TBehavior>(path, initializer);
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x0001A3C4 File Offset: 0x000185C4
		public bool RemoveWebSocketService(string path)
		{
			return this._services.RemoveService(path);
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0001A3E4 File Offset: 0x000185E4
		public void Start()
		{
			ServerSslConfiguration serverSslConfiguration = null;
			bool secure = this._secure;
			if (secure)
			{
				ServerSslConfiguration sslConfiguration = this.getSslConfiguration();
				serverSslConfiguration = new ServerSslConfiguration(sslConfiguration);
				bool flag = serverSslConfiguration.ServerCertificate == null;
				if (flag)
				{
					string message = "There is no server certificate for secure connection.";
					throw new InvalidOperationException(message);
				}
			}
			bool flag2 = this._state == ServerState.Start;
			if (flag2)
			{
				this._log.Info("The server has already started.");
			}
			else
			{
				bool flag3 = this._state == ServerState.ShuttingDown;
				if (flag3)
				{
					this._log.Warn("The server is shutting down.");
				}
				else
				{
					this.start(serverSslConfiguration);
				}
			}
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0001A480 File Offset: 0x00018680
		public void Stop()
		{
			bool flag = this._state == ServerState.Ready;
			if (flag)
			{
				this._log.Info("The server is not started.");
			}
			else
			{
				bool flag2 = this._state == ServerState.ShuttingDown;
				if (flag2)
				{
					this._log.Info("The server is shutting down.");
				}
				else
				{
					bool flag3 = this._state == ServerState.Stop;
					if (flag3)
					{
						this._log.Info("The server has already stopped.");
					}
					else
					{
						this.stop(1001, string.Empty);
					}
				}
			}
		}

		// Token: 0x04000211 RID: 529
		private IPAddress _address;

		// Token: 0x04000212 RID: 530
		private bool _allowForwardedRequest;

		// Token: 0x04000213 RID: 531
		private WebSocketSharp.Net.AuthenticationSchemes _authSchemes;

		// Token: 0x04000214 RID: 532
		private static readonly string _defaultRealm = "SECRET AREA";

		// Token: 0x04000215 RID: 533
		private bool _dnsStyle;

		// Token: 0x04000216 RID: 534
		private string _hostname;

		// Token: 0x04000217 RID: 535
		private TcpListener _listener;

		// Token: 0x04000218 RID: 536
		private Logger _log;

		// Token: 0x04000219 RID: 537
		private int _port;

		// Token: 0x0400021A RID: 538
		private string _realm;

		// Token: 0x0400021B RID: 539
		private string _realmInUse;

		// Token: 0x0400021C RID: 540
		private Thread _receiveThread;

		// Token: 0x0400021D RID: 541
		private bool _reuseAddress;

		// Token: 0x0400021E RID: 542
		private bool _secure;

		// Token: 0x0400021F RID: 543
		private WebSocketServiceManager _services;

		// Token: 0x04000220 RID: 544
		private ServerSslConfiguration _sslConfig;

		// Token: 0x04000221 RID: 545
		private ServerSslConfiguration _sslConfigInUse;

		// Token: 0x04000222 RID: 546
		private volatile ServerState _state;

		// Token: 0x04000223 RID: 547
		private object _sync;

		// Token: 0x04000224 RID: 548
		private Func<IIdentity, WebSocketSharp.Net.NetworkCredential> _userCredFinder;
	}
}
