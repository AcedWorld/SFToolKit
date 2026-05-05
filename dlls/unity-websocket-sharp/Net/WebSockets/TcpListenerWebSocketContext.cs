using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;

namespace UnityWebSocketSharp.Net.WebSockets
{
	// Token: 0x0200004D RID: 77
	internal class TcpListenerWebSocketContext : WebSocketContext
	{
		// Token: 0x06000530 RID: 1328 RVA: 0x000173B8 File Offset: 0x000155B8
		internal TcpListenerWebSocketContext(TcpClient tcpClient, string protocol, bool secure, ServerSslConfiguration sslConfig, Logger log)
		{
			this._tcpClient = tcpClient;
			this._secure = secure;
			this._log = log;
			NetworkStream stream = tcpClient.GetStream();
			if (secure)
			{
				SslStream sslStream = new SslStream(stream, false, sslConfig.ClientCertificateValidationCallback);
				sslStream.AuthenticateAsServer(sslConfig.ServerCertificate, sslConfig.ClientCertificateRequired, sslConfig.EnabledSslProtocols, sslConfig.CheckCertificateRevocation);
				this._stream = sslStream;
			}
			else
			{
				this._stream = stream;
			}
			Socket client = tcpClient.Client;
			this._serverEndPoint = client.LocalEndPoint;
			this._userEndPoint = client.RemoteEndPoint;
			this._request = HttpRequest.ReadRequest(this._stream, 90000);
			this._websocket = new WebSocket(this, protocol);
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000531 RID: 1329 RVA: 0x0001746E File Offset: 0x0001566E
		internal Logger Log
		{
			get
			{
				return this._log;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000532 RID: 1330 RVA: 0x00017476 File Offset: 0x00015676
		internal Stream Stream
		{
			get
			{
				return this._stream;
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000533 RID: 1331 RVA: 0x0001747E File Offset: 0x0001567E
		public override CookieCollection CookieCollection
		{
			get
			{
				return this._request.Cookies;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000534 RID: 1332 RVA: 0x0001748B File Offset: 0x0001568B
		public override NameValueCollection Headers
		{
			get
			{
				return this._request.Headers;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000535 RID: 1333 RVA: 0x00017498 File Offset: 0x00015698
		public override string Host
		{
			get
			{
				return this._request.Headers["Host"];
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x000174AF File Offset: 0x000156AF
		public override bool IsAuthenticated
		{
			get
			{
				return this._user != null;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x000174BA File Offset: 0x000156BA
		public override bool IsLocal
		{
			get
			{
				return this.UserEndPoint.Address.IsLocal();
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x000174CC File Offset: 0x000156CC
		public override bool IsSecureConnection
		{
			get
			{
				return this._secure;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000539 RID: 1337 RVA: 0x000174D4 File Offset: 0x000156D4
		public override bool IsWebSocketRequest
		{
			get
			{
				return this._request.IsWebSocketRequest;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x000174E1 File Offset: 0x000156E1
		public override string Origin
		{
			get
			{
				return this._request.Headers["Origin"];
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x0600053B RID: 1339 RVA: 0x000174F8 File Offset: 0x000156F8
		public override NameValueCollection QueryString
		{
			get
			{
				if (this._queryString == null)
				{
					Uri requestUri = this.RequestUri;
					string query = (requestUri != null) ? requestUri.Query : null;
					this._queryString = QueryStringCollection.Parse(query, Encoding.UTF8);
				}
				return this._queryString;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600053C RID: 1340 RVA: 0x00017540 File Offset: 0x00015740
		public override Uri RequestUri
		{
			get
			{
				if (this._requestUri == null)
				{
					this._requestUri = HttpUtility.CreateRequestUrl(this._request.RequestTarget, this._request.Headers["Host"], this._request.IsWebSocketRequest, this._secure);
				}
				return this._requestUri;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x0600053D RID: 1341 RVA: 0x0001759D File Offset: 0x0001579D
		public override string SecWebSocketKey
		{
			get
			{
				return this._request.Headers["Sec-WebSocket-Key"];
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x0600053E RID: 1342 RVA: 0x000175B4 File Offset: 0x000157B4
		public override IEnumerable<string> SecWebSocketProtocols
		{
			get
			{
				string text = this._request.Headers["Sec-WebSocket-Protocol"];
				if (text == null || text.Length == 0)
				{
					yield break;
				}
				string[] array = text.Split(',', StringSplitOptions.None);
				for (int i = 0; i < array.Length; i++)
				{
					string text2 = array[i].Trim();
					if (text2.Length != 0)
					{
						yield return text2;
					}
				}
				array = null;
				yield break;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x0600053F RID: 1343 RVA: 0x000175C4 File Offset: 0x000157C4
		public override string SecWebSocketVersion
		{
			get
			{
				return this._request.Headers["Sec-WebSocket-Version"];
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000540 RID: 1344 RVA: 0x000175DB File Offset: 0x000157DB
		public override IPEndPoint ServerEndPoint
		{
			get
			{
				return (IPEndPoint)this._serverEndPoint;
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000541 RID: 1345 RVA: 0x000175E8 File Offset: 0x000157E8
		public override IPrincipal User
		{
			get
			{
				return this._user;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x000175F0 File Offset: 0x000157F0
		public override IPEndPoint UserEndPoint
		{
			get
			{
				return (IPEndPoint)this._userEndPoint;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000543 RID: 1347 RVA: 0x000175FD File Offset: 0x000157FD
		public override WebSocket WebSocket
		{
			get
			{
				return this._websocket;
			}
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x00017605 File Offset: 0x00015805
		internal void Close()
		{
			this._stream.Close();
			this._tcpClient.Close();
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0001761D File Offset: 0x0001581D
		internal void Close(HttpStatusCode code)
		{
			HttpResponse.CreateCloseResponse(code).WriteTo(this._stream);
			this._stream.Close();
			this._tcpClient.Close();
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x00017646 File Offset: 0x00015846
		internal void SendAuthenticationChallenge(string challenge)
		{
			HttpResponse.CreateUnauthorizedResponse(challenge).WriteTo(this._stream);
			this._request = HttpRequest.ReadRequest(this._stream, 15000);
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x00017670 File Offset: 0x00015870
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

		// Token: 0x06000548 RID: 1352 RVA: 0x000176C2 File Offset: 0x000158C2
		public override string ToString()
		{
			return this._request.ToString();
		}

		// Token: 0x0400025F RID: 607
		private Logger _log;

		// Token: 0x04000260 RID: 608
		private NameValueCollection _queryString;

		// Token: 0x04000261 RID: 609
		private HttpRequest _request;

		// Token: 0x04000262 RID: 610
		private Uri _requestUri;

		// Token: 0x04000263 RID: 611
		private bool _secure;

		// Token: 0x04000264 RID: 612
		private EndPoint _serverEndPoint;

		// Token: 0x04000265 RID: 613
		private Stream _stream;

		// Token: 0x04000266 RID: 614
		private TcpClient _tcpClient;

		// Token: 0x04000267 RID: 615
		private IPrincipal _user;

		// Token: 0x04000268 RID: 616
		private EndPoint _userEndPoint;

		// Token: 0x04000269 RID: 617
		private WebSocket _websocket;
	}
}
