using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using WebSocketSharp.Net;
using WebSocketSharp.Net.WebSockets;

namespace WebSocketSharp.Server
{
	// Token: 0x02000046 RID: 70
	public class HttpServer
	{
		// Token: 0x0600048B RID: 1163 RVA: 0x0001A508 File Offset: 0x00018708
		public HttpServer()
		{
			this.init("*", IPAddress.Any, 80, false);
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0001A526 File Offset: 0x00018726
		public HttpServer(int port) : this(port, port == 443)
		{
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x0001A53C File Offset: 0x0001873C
		public HttpServer(string url)
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
			bool flag3 = !HttpServer.tryCreateUri(url, out uri, out message);
			if (flag3)
			{
				throw new ArgumentException(message, "url");
			}
			string dnsSafeHost = uri.GetDnsSafeHost(true);
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
			this.init(dnsSafeHost, ipaddress, uri.Port, uri.Scheme == "https");
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0001A614 File Offset: 0x00018814
		public HttpServer(int port, bool secure)
		{
			bool flag = !port.IsPortNumber();
			if (flag)
			{
				string message = "It is less than 1 or greater than 65535.";
				throw new ArgumentOutOfRangeException("port", message);
			}
			this.init("*", IPAddress.Any, port, secure);
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0001A65C File Offset: 0x0001885C
		public HttpServer(IPAddress address, int port) : this(address, port, port == 443)
		{
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0001A670 File Offset: 0x00018870
		public HttpServer(IPAddress address, int port, bool secure)
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
			this.init(address.ToString(true), address, port, secure);
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x0001A6EC File Offset: 0x000188EC
		public IPAddress Address
		{
			get
			{
				return this._address;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000492 RID: 1170 RVA: 0x0001A704 File Offset: 0x00018904
		// (set) Token: 0x06000493 RID: 1171 RVA: 0x0001A724 File Offset: 0x00018924
		public WebSocketSharp.Net.AuthenticationSchemes AuthenticationSchemes
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
					string message;
					bool flag2 = !this.canSet(out message);
					if (flag2)
					{
						this._log.Warn(message);
					}
					else
					{
						this._listener.AuthenticationSchemes = value;
					}
				}
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000494 RID: 1172 RVA: 0x0001A790 File Offset: 0x00018990
		// (set) Token: 0x06000495 RID: 1173 RVA: 0x0001A7A8 File Offset: 0x000189A8
		public string DocumentRootPath
		{
			get
			{
				return this._docRootPath;
			}
			set
			{
				bool flag = value == null;
				if (flag)
				{
					throw new ArgumentNullException("value");
				}
				bool flag2 = value.Length == 0;
				if (flag2)
				{
					throw new ArgumentException("An empty string.", "value");
				}
				value = value.TrimSlashOrBackslashFromEnd();
				bool flag3 = value == "/";
				if (flag3)
				{
					throw new ArgumentException("An absolute root.", "value");
				}
				bool flag4 = value == "\\";
				if (flag4)
				{
					throw new ArgumentException("An absolute root.", "value");
				}
				bool flag5 = value.Length == 2 && value[1] == ':';
				if (flag5)
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
				bool flag6 = text == "/";
				if (flag6)
				{
					throw new ArgumentException("An absolute root.", "value");
				}
				text = text.TrimSlashOrBackslashFromEnd();
				bool flag7 = text.Length == 2 && text[1] == ':';
				if (flag7)
				{
					throw new ArgumentException("An absolute root.", "value");
				}
				object sync = this._sync;
				lock (sync)
				{
					string message;
					bool flag9 = !this.canSet(out message);
					if (flag9)
					{
						this._log.Warn(message);
					}
					else
					{
						this._docRootPath = value;
					}
				}
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000496 RID: 1174 RVA: 0x0001A940 File Offset: 0x00018B40
		public bool IsListening
		{
			get
			{
				return this._state == ServerState.Start;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x0001A960 File Offset: 0x00018B60
		public bool IsSecure
		{
			get
			{
				return this._secure;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x0001A978 File Offset: 0x00018B78
		// (set) Token: 0x06000499 RID: 1177 RVA: 0x0001A995 File Offset: 0x00018B95
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

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x0600049A RID: 1178 RVA: 0x0001A9A8 File Offset: 0x00018BA8
		public Logger Log
		{
			get
			{
				return this._log;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x0600049B RID: 1179 RVA: 0x0001A9C0 File Offset: 0x00018BC0
		public int Port
		{
			get
			{
				return this._port;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600049C RID: 1180 RVA: 0x0001A9D8 File Offset: 0x00018BD8
		// (set) Token: 0x0600049D RID: 1181 RVA: 0x0001A9F8 File Offset: 0x00018BF8
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
					string message;
					bool flag2 = !this.canSet(out message);
					if (flag2)
					{
						this._log.Warn(message);
					}
					else
					{
						this._listener.Realm = value;
					}
				}
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x0600049E RID: 1182 RVA: 0x0001AA64 File Offset: 0x00018C64
		// (set) Token: 0x0600049F RID: 1183 RVA: 0x0001AA84 File Offset: 0x00018C84
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
					string message;
					bool flag2 = !this.canSet(out message);
					if (flag2)
					{
						this._log.Warn(message);
					}
					else
					{
						this._listener.ReuseAddress = value;
					}
				}
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060004A0 RID: 1184 RVA: 0x0001AAF0 File Offset: 0x00018CF0
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
				return this._listener.SslConfiguration;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x0001AB28 File Offset: 0x00018D28
		// (set) Token: 0x060004A2 RID: 1186 RVA: 0x0001AB48 File Offset: 0x00018D48
		public Func<IIdentity, WebSocketSharp.Net.NetworkCredential> UserCredentialsFinder
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
					string message;
					bool flag2 = !this.canSet(out message);
					if (flag2)
					{
						this._log.Warn(message);
					}
					else
					{
						this._listener.UserCredentialsFinder = value;
					}
				}
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x0001ABB4 File Offset: 0x00018DB4
		// (set) Token: 0x060004A4 RID: 1188 RVA: 0x0001ABD1 File Offset: 0x00018DD1
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

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x0001ABE4 File Offset: 0x00018DE4
		public WebSocketServiceManager WebSocketServices
		{
			get
			{
				return this._services;
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060004A6 RID: 1190 RVA: 0x0001ABFC File Offset: 0x00018DFC
		// (remove) Token: 0x060004A7 RID: 1191 RVA: 0x0001AC34 File Offset: 0x00018E34
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<HttpRequestEventArgs> OnConnect;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060004A8 RID: 1192 RVA: 0x0001AC6C File Offset: 0x00018E6C
		// (remove) Token: 0x060004A9 RID: 1193 RVA: 0x0001ACA4 File Offset: 0x00018EA4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<HttpRequestEventArgs> OnDelete;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060004AA RID: 1194 RVA: 0x0001ACDC File Offset: 0x00018EDC
		// (remove) Token: 0x060004AB RID: 1195 RVA: 0x0001AD14 File Offset: 0x00018F14
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<HttpRequestEventArgs> OnGet;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060004AC RID: 1196 RVA: 0x0001AD4C File Offset: 0x00018F4C
		// (remove) Token: 0x060004AD RID: 1197 RVA: 0x0001AD84 File Offset: 0x00018F84
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<HttpRequestEventArgs> OnHead;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060004AE RID: 1198 RVA: 0x0001ADBC File Offset: 0x00018FBC
		// (remove) Token: 0x060004AF RID: 1199 RVA: 0x0001ADF4 File Offset: 0x00018FF4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<HttpRequestEventArgs> OnOptions;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060004B0 RID: 1200 RVA: 0x0001AE2C File Offset: 0x0001902C
		// (remove) Token: 0x060004B1 RID: 1201 RVA: 0x0001AE64 File Offset: 0x00019064
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<HttpRequestEventArgs> OnPost;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060004B2 RID: 1202 RVA: 0x0001AE9C File Offset: 0x0001909C
		// (remove) Token: 0x060004B3 RID: 1203 RVA: 0x0001AED4 File Offset: 0x000190D4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<HttpRequestEventArgs> OnPut;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060004B4 RID: 1204 RVA: 0x0001AF0C File Offset: 0x0001910C
		// (remove) Token: 0x060004B5 RID: 1205 RVA: 0x0001AF44 File Offset: 0x00019144
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<HttpRequestEventArgs> OnTrace;

		// Token: 0x060004B6 RID: 1206 RVA: 0x0001AF7C File Offset: 0x0001917C
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
					this._services.Stop(1006, string.Empty);
				}
				finally
				{
					this._listener.Abort();
				}
			}
			catch
			{
			}
			this._state = ServerState.Stop;
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x0001B02C File Offset: 0x0001922C
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

		// Token: 0x060004B8 RID: 1208 RVA: 0x0001B078 File Offset: 0x00019278
		private bool checkCertificate(out string message)
		{
			message = null;
			bool flag = this._listener.SslConfiguration.ServerCertificate != null;
			string certificateFolderPath = this._listener.CertificateFolderPath;
			bool flag2 = EndPointListener.CertificateExists(this._port, certificateFolderPath);
			bool flag3 = flag || flag2;
			bool flag4 = !flag3;
			bool result;
			if (flag4)
			{
				message = "There is no server certificate for secure connection.";
				result = false;
			}
			else
			{
				bool flag5 = flag && flag2;
				bool flag6 = flag5;
				if (flag6)
				{
					string message2 = "The server certificate associated with the port is used.";
					this._log.Warn(message2);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0001B0FC File Offset: 0x000192FC
		private static WebSocketSharp.Net.HttpListener createListener(string hostname, int port, bool secure)
		{
			WebSocketSharp.Net.HttpListener httpListener = new WebSocketSharp.Net.HttpListener();
			string arg = secure ? "https" : "http";
			string uriPrefix = string.Format("{0}://{1}:{2}/", arg, hostname, port);
			httpListener.Prefixes.Add(uriPrefix);
			return httpListener;
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0001B148 File Offset: 0x00019348
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

		// Token: 0x060004BB RID: 1211 RVA: 0x0001B1C8 File Offset: 0x000193C8
		private void processRequest(WebSocketSharp.Net.HttpListenerContext context)
		{
			string httpMethod = context.Request.HttpMethod;
			EventHandler<HttpRequestEventArgs> eventHandler = (httpMethod == "GET") ? this.OnGet : ((httpMethod == "HEAD") ? this.OnHead : ((httpMethod == "POST") ? this.OnPost : ((httpMethod == "PUT") ? this.OnPut : ((httpMethod == "DELETE") ? this.OnDelete : ((httpMethod == "CONNECT") ? this.OnConnect : ((httpMethod == "OPTIONS") ? this.OnOptions : ((httpMethod == "TRACE") ? this.OnTrace : null)))))));
			bool flag = eventHandler == null;
			if (flag)
			{
				context.ErrorStatusCode = 501;
				context.SendError();
			}
			else
			{
				HttpRequestEventArgs e = new HttpRequestEventArgs(context, this._docRootPath);
				eventHandler(this, e);
				context.Response.Close();
			}
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0001B2D4 File Offset: 0x000194D4
		private void processRequest(HttpListenerWebSocketContext context)
		{
			Uri requestUri = context.RequestUri;
			bool flag = requestUri == null;
			if (flag)
			{
				context.Close(WebSocketSharp.Net.HttpStatusCode.BadRequest);
			}
			else
			{
				string text = requestUri.AbsolutePath;
				bool flag2 = text.IndexOfAny(new char[]
				{
					'%',
					'+'
				}) > -1;
				if (flag2)
				{
					text = HttpUtility.UrlDecode(text, Encoding.UTF8);
				}
				WebSocketServiceHost webSocketServiceHost;
				bool flag3 = !this._services.InternalTryGetServiceHost(text, out webSocketServiceHost);
				if (flag3)
				{
					context.Close(WebSocketSharp.Net.HttpStatusCode.NotImplemented);
				}
				else
				{
					webSocketServiceHost.StartSession(context);
				}
			}
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0001B364 File Offset: 0x00019564
		private void receiveRequest()
		{
			for (;;)
			{
				WebSocketSharp.Net.HttpListenerContext ctx = null;
				try
				{
					ctx = this._listener.GetContext();
					ThreadPool.QueueUserWorkItem(delegate(object state)
					{
						try
						{
							bool flag3 = ctx.Request.IsUpgradeRequest("websocket");
							if (flag3)
							{
								this.processRequest(ctx.GetWebSocketContext(null));
							}
							else
							{
								this.processRequest(ctx);
							}
						}
						catch (Exception ex2)
						{
							this._log.Fatal(ex2.Message);
							this._log.Debug(ex2.ToString());
							ctx.Connection.Close(true);
						}
					});
				}
				catch (WebSocketSharp.Net.HttpListenerException)
				{
					this._log.Info("The underlying listener is stopped.");
					break;
				}
				catch (InvalidOperationException)
				{
					this._log.Info("The underlying listener is stopped.");
					break;
				}
				catch (Exception ex)
				{
					this._log.Fatal(ex.Message);
					this._log.Debug(ex.ToString());
					bool flag = ctx != null;
					if (flag)
					{
						ctx.Connection.Close(true);
					}
					break;
				}
			}
			bool flag2 = this._state != ServerState.ShuttingDown;
			if (flag2)
			{
				this.abort();
			}
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0001B470 File Offset: 0x00019670
		private void start()
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

		// Token: 0x060004BF RID: 1215 RVA: 0x0001B53C File Offset: 0x0001973C
		private void startReceiving()
		{
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

		// Token: 0x060004C0 RID: 1216 RVA: 0x0001B5AC File Offset: 0x000197AC
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
					this._services.Stop(code, reason);
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
						this.stopReceiving(5000);
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

		// Token: 0x060004C1 RID: 1217 RVA: 0x0001B6C4 File Offset: 0x000198C4
		private void stopReceiving(int millisecondsTimeout)
		{
			this._listener.Stop();
			this._receiveThread.Join(millisecondsTimeout);
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0001B6E0 File Offset: 0x000198E0
		private static bool tryCreateUri(string uriString, out Uri result, out string message)
		{
			result = null;
			message = null;
			Uri uri = uriString.ToUri();
			bool flag = uri == null;
			bool result2;
			if (flag)
			{
				message = "An invalid URI string.";
				result2 = false;
			}
			else
			{
				bool flag2 = !uri.IsAbsoluteUri;
				if (flag2)
				{
					message = "A relative URI.";
					result2 = false;
				}
				else
				{
					string scheme = uri.Scheme;
					bool flag3 = scheme == "http" || scheme == "https";
					bool flag4 = !flag3;
					if (flag4)
					{
						message = "The scheme part is not 'http' or 'https'.";
						result2 = false;
					}
					else
					{
						bool flag5 = uri.PathAndQuery != "/";
						if (flag5)
						{
							message = "It includes either or both path and query components.";
							result2 = false;
						}
						else
						{
							bool flag6 = uri.Fragment.Length > 0;
							if (flag6)
							{
								message = "It includes the fragment component.";
								result2 = false;
							}
							else
							{
								bool flag7 = uri.Port == 0;
								if (flag7)
								{
									message = "The port part is zero.";
									result2 = false;
								}
								else
								{
									result = uri;
									result2 = true;
								}
							}
						}
					}
				}
			}
			return result2;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0001B7D9 File Offset: 0x000199D9
		public void AddWebSocketService<TBehavior>(string path) where TBehavior : WebSocketBehavior, new()
		{
			this._services.AddService<TBehavior>(path, null);
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x0001B7EA File Offset: 0x000199EA
		public void AddWebSocketService<TBehavior>(string path, Action<TBehavior> initializer) where TBehavior : WebSocketBehavior, new()
		{
			this._services.AddService<TBehavior>(path, initializer);
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0001B7FC File Offset: 0x000199FC
		public bool RemoveWebSocketService(string path)
		{
			return this._services.RemoveService(path);
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0001B81C File Offset: 0x00019A1C
		public void Start()
		{
			bool secure = this._secure;
			if (secure)
			{
				string message;
				bool flag = !this.checkCertificate(out message);
				if (flag)
				{
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
					this.start();
				}
			}
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0001B89C File Offset: 0x00019A9C
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

		// Token: 0x04000225 RID: 549
		private IPAddress _address;

		// Token: 0x04000226 RID: 550
		private string _docRootPath;

		// Token: 0x04000227 RID: 551
		private string _hostname;

		// Token: 0x04000228 RID: 552
		private WebSocketSharp.Net.HttpListener _listener;

		// Token: 0x04000229 RID: 553
		private Logger _log;

		// Token: 0x0400022A RID: 554
		private int _port;

		// Token: 0x0400022B RID: 555
		private Thread _receiveThread;

		// Token: 0x0400022C RID: 556
		private bool _secure;

		// Token: 0x0400022D RID: 557
		private WebSocketServiceManager _services;

		// Token: 0x0400022E RID: 558
		private volatile ServerState _state;

		// Token: 0x0400022F RID: 559
		private object _sync;
	}
}
