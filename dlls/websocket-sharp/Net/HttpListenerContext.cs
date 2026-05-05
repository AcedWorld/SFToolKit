using System;
using System.Security.Principal;
using System.Text;
using WebSocketSharp.Net.WebSockets;

namespace WebSocketSharp.Net
{
	// Token: 0x02000021 RID: 33
	public sealed class HttpListenerContext
	{
		// Token: 0x06000263 RID: 611 RVA: 0x00010328 File Offset: 0x0000E528
		internal HttpListenerContext(HttpConnection connection)
		{
			this._connection = connection;
			this._errorStatusCode = 400;
			this._request = new HttpListenerRequest(this);
			this._response = new HttpListenerResponse(this);
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000264 RID: 612 RVA: 0x0001035C File Offset: 0x0000E55C
		internal HttpConnection Connection
		{
			get
			{
				return this._connection;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00010374 File Offset: 0x0000E574
		// (set) Token: 0x06000266 RID: 614 RVA: 0x0001038C File Offset: 0x0000E58C
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

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00010398 File Offset: 0x0000E598
		// (set) Token: 0x06000268 RID: 616 RVA: 0x000103B0 File Offset: 0x0000E5B0
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

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000269 RID: 617 RVA: 0x000103BC File Offset: 0x0000E5BC
		internal bool HasErrorMessage
		{
			get
			{
				return this._errorMessage != null;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600026A RID: 618 RVA: 0x000103D8 File Offset: 0x0000E5D8
		// (set) Token: 0x0600026B RID: 619 RVA: 0x000103F0 File Offset: 0x0000E5F0
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

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600026C RID: 620 RVA: 0x000103FC File Offset: 0x0000E5FC
		public HttpListenerRequest Request
		{
			get
			{
				return this._request;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600026D RID: 621 RVA: 0x00010414 File Offset: 0x0000E614
		public HttpListenerResponse Response
		{
			get
			{
				return this._response;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600026E RID: 622 RVA: 0x0001042C File Offset: 0x0000E62C
		// (set) Token: 0x0600026F RID: 623 RVA: 0x00010444 File Offset: 0x0000E644
		public IPrincipal User
		{
			get
			{
				return this._user;
			}
			internal set
			{
				this._user = value;
			}
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00010450 File Offset: 0x0000E650
		private static string createErrorContent(int statusCode, string statusDescription, string message)
		{
			return (message != null && message.Length > 0) ? string.Format("<html><body><h1>{0} {1} ({2})</h1></body></html>", statusCode, statusDescription, message) : string.Format("<html><body><h1>{0} {1}</h1></body></html>", statusCode, statusDescription);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00010494 File Offset: 0x0000E694
		internal HttpListenerWebSocketContext GetWebSocketContext(string protocol)
		{
			this._websocketContext = new HttpListenerWebSocketContext(this, protocol);
			return this._websocketContext;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x000104BC File Offset: 0x0000E6BC
		internal void SendAuthenticationChallenge(AuthenticationSchemes scheme, string realm)
		{
			string value = new AuthenticationChallenge(scheme, realm).ToString();
			this._response.StatusCode = 401;
			this._response.Headers.InternalSet("WWW-Authenticate", value, true);
			this._response.Close();
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0001050C File Offset: 0x0000E70C
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

		// Token: 0x06000274 RID: 628 RVA: 0x000105B8 File Offset: 0x0000E7B8
		internal void Unregister()
		{
			bool flag = this._listener == null;
			if (!flag)
			{
				this._listener.UnregisterContext(this);
			}
		}

		// Token: 0x06000275 RID: 629 RVA: 0x000105E4 File Offset: 0x0000E7E4
		public HttpListenerWebSocketContext AcceptWebSocket(string protocol)
		{
			bool flag = this._websocketContext != null;
			if (flag)
			{
				string message = "The accepting is already in progress.";
				throw new InvalidOperationException(message);
			}
			bool flag2 = protocol != null;
			if (flag2)
			{
				bool flag3 = protocol.Length == 0;
				if (flag3)
				{
					string message2 = "An empty string.";
					throw new ArgumentException(message2, "protocol");
				}
				bool flag4 = !protocol.IsToken();
				if (flag4)
				{
					string message3 = "It contains an invalid character.";
					throw new ArgumentException(message3, "protocol");
				}
			}
			return this.GetWebSocketContext(protocol);
		}

		// Token: 0x040000EB RID: 235
		private HttpConnection _connection;

		// Token: 0x040000EC RID: 236
		private string _errorMessage;

		// Token: 0x040000ED RID: 237
		private int _errorStatusCode;

		// Token: 0x040000EE RID: 238
		private HttpListener _listener;

		// Token: 0x040000EF RID: 239
		private HttpListenerRequest _request;

		// Token: 0x040000F0 RID: 240
		private HttpListenerResponse _response;

		// Token: 0x040000F1 RID: 241
		private IPrincipal _user;

		// Token: 0x040000F2 RID: 242
		private HttpListenerWebSocketContext _websocketContext;
	}
}
