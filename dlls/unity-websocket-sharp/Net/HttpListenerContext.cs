using System;
using System.Security.Principal;
using System.Text;
using UnityWebSocketSharp.Net.WebSockets;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000036 RID: 54
	internal sealed class HttpListenerContext
	{
		// Token: 0x060003C6 RID: 966 RVA: 0x00011744 File Offset: 0x0000F944
		internal HttpListenerContext(HttpConnection connection)
		{
			this._connection = connection;
			this._errorStatusCode = 400;
			this._request = new HttpListenerRequest(this);
			this._response = new HttpListenerResponse(this);
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x00011776 File Offset: 0x0000F976
		internal HttpConnection Connection
		{
			get
			{
				return this._connection;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x0001177E File Offset: 0x0000F97E
		// (set) Token: 0x060003C9 RID: 969 RVA: 0x00011786 File Offset: 0x0000F986
		internal string ErrorMessage
		{
			get
			{
				return this._errorMessage;
			}
			set
			{
				this._errorMessage = value;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060003CA RID: 970 RVA: 0x0001178F File Offset: 0x0000F98F
		// (set) Token: 0x060003CB RID: 971 RVA: 0x00011797 File Offset: 0x0000F997
		internal int ErrorStatusCode
		{
			get
			{
				return this._errorStatusCode;
			}
			set
			{
				this._errorStatusCode = value;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060003CC RID: 972 RVA: 0x000117A0 File Offset: 0x0000F9A0
		internal bool HasErrorMessage
		{
			get
			{
				return this._errorMessage != null;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060003CD RID: 973 RVA: 0x000117AB File Offset: 0x0000F9AB
		// (set) Token: 0x060003CE RID: 974 RVA: 0x000117B3 File Offset: 0x0000F9B3
		internal HttpListener Listener
		{
			get
			{
				return this._listener;
			}
			set
			{
				this._listener = value;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060003CF RID: 975 RVA: 0x000117BC File Offset: 0x0000F9BC
		public HttpListenerRequest Request
		{
			get
			{
				return this._request;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x000117C4 File Offset: 0x0000F9C4
		public HttpListenerResponse Response
		{
			get
			{
				return this._response;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x000117CC File Offset: 0x0000F9CC
		public IPrincipal User
		{
			get
			{
				return this._user;
			}
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x000117D4 File Offset: 0x0000F9D4
		private static string createErrorContent(int statusCode, string statusDescription, string message)
		{
			if (message == null || message.Length <= 0)
			{
				return string.Format("<html><body><h1>{0} {1}</h1></body></html>", statusCode, statusDescription);
			}
			return string.Format("<html><body><h1>{0} {1} ({2})</h1></body></html>", statusCode, statusDescription, message);
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00011806 File Offset: 0x0000FA06
		internal HttpListenerWebSocketContext GetWebSocketContext(string protocol)
		{
			this._websocketContext = new HttpListenerWebSocketContext(this, protocol);
			return this._websocketContext;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0001181C File Offset: 0x0000FA1C
		internal void SendAuthenticationChallenge(AuthenticationSchemes scheme, string realm)
		{
			this._response.StatusCode = 401;
			string value = new AuthenticationChallenge(scheme, realm).ToString();
			this._response.Headers.InternalSet("WWW-Authenticate", value, true);
			this._response.Close();
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x00011868 File Offset: 0x0000FA68
		internal void SendError()
		{
			try
			{
				this._response.StatusCode = this._errorStatusCode;
				this._response.ContentType = "text/html";
				string s = HttpListenerContext.createErrorContent(this._errorStatusCode, this._response.StatusDescription, this._errorMessage);
				Encoding utf = Encoding.UTF8;
				byte[] bytes = utf.GetBytes(s);
				this._response.ContentEncoding = utf;
				this._response.ContentLength64 = (long)bytes.Length;
				this._response.Close(bytes, true);
			}
			catch
			{
				this._connection.Close(true);
			}
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0001190C File Offset: 0x0000FB0C
		internal void SendError(int statusCode)
		{
			this._errorStatusCode = statusCode;
			this.SendError();
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0001191B File Offset: 0x0000FB1B
		internal void SendError(int statusCode, string message)
		{
			this._errorStatusCode = statusCode;
			this._errorMessage = message;
			this.SendError();
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00011934 File Offset: 0x0000FB34
		internal bool SetUser(AuthenticationSchemes scheme, string realm, Func<IIdentity, NetworkCredential> credentialsFinder)
		{
			IPrincipal principal = HttpUtility.CreateUser(this._request.Headers["Authorization"], scheme, realm, this._request.HttpMethod, credentialsFinder);
			if (principal == null)
			{
				return false;
			}
			if (!principal.Identity.IsAuthenticated)
			{
				return false;
			}
			this._user = principal;
			return true;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00011986 File Offset: 0x0000FB86
		internal void Unregister()
		{
			if (this._listener == null)
			{
				return;
			}
			this._listener.UnregisterContext(this);
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0001199D File Offset: 0x0000FB9D
		public HttpListenerWebSocketContext AcceptWebSocket(string protocol)
		{
			return this.AcceptWebSocket(protocol, null);
		}

		// Token: 0x060003DB RID: 987 RVA: 0x000119A8 File Offset: 0x0000FBA8
		public HttpListenerWebSocketContext AcceptWebSocket(string protocol, Action<WebSocket> initializer)
		{
			if (this._websocketContext != null)
			{
				throw new InvalidOperationException("The method has already been done.");
			}
			if (!this._request.IsWebSocketRequest)
			{
				throw new InvalidOperationException("The request is not a WebSocket handshake request.");
			}
			if (protocol != null)
			{
				if (protocol.Length == 0)
				{
					throw new ArgumentException("An empty string.", "protocol");
				}
				if (!protocol.IsToken())
				{
					throw new ArgumentException("It contains an invalid character.", "protocol");
				}
			}
			HttpListenerWebSocketContext webSocketContext = this.GetWebSocketContext(protocol);
			WebSocket webSocket = webSocketContext.WebSocket;
			if (initializer != null)
			{
				try
				{
					initializer(webSocket);
				}
				catch (Exception innerException)
				{
					if (webSocket.ReadyState == WebSocketState.New)
					{
						this._websocketContext = null;
					}
					throw new ArgumentException("It caused an exception.", "initializer", innerException);
				}
			}
			webSocket.Accept();
			return webSocketContext;
		}

		// Token: 0x04000168 RID: 360
		private HttpConnection _connection;

		// Token: 0x04000169 RID: 361
		private string _errorMessage;

		// Token: 0x0400016A RID: 362
		private int _errorStatusCode;

		// Token: 0x0400016B RID: 363
		private HttpListener _listener;

		// Token: 0x0400016C RID: 364
		private HttpListenerRequest _request;

		// Token: 0x0400016D RID: 365
		private HttpListenerResponse _response;

		// Token: 0x0400016E RID: 366
		private IPrincipal _user;

		// Token: 0x0400016F RID: 367
		private HttpListenerWebSocketContext _websocketContext;
	}
}
