using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;

namespace WebSocketSharp.Net.WebSockets
{
	// Token: 0x02000043 RID: 67
	internal class TcpListenerWebSocketContext : WebSocketContext
	{
		// Token: 0x06000431 RID: 1073 RVA: 0x00019174 File Offset: 0x00017374
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
			this._request = HttpRequest.Read(this._stream, 90000);
			this._websocket = new WebSocket(this, protocol);
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x00019234 File Offset: 0x00017434
		internal Logger Log
		{
			get
			{
				return this._log;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x0001924C File Offset: 0x0001744C
		internal Stream Stream
		{
			get
			{
				return this._stream;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x00019264 File Offset: 0x00017464
		public override CookieCollection CookieCollection
		{
			get
			{
				return this._request.Cookies;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x00019284 File Offset: 0x00017484
		public override NameValueCollection Headers
		{
			get
			{
				return this._request.Headers;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000436 RID: 1078 RVA: 0x000192A4 File Offset: 0x000174A4
		public override string Host
		{
			get
			{
				return this._request.Headers["Host"];
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x000192CC File Offset: 0x000174CC
		public override bool IsAuthenticated
		{
			get
			{
				return this._user != null;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000438 RID: 1080 RVA: 0x000192E8 File Offset: 0x000174E8
		public override bool IsLocal
		{
			get
			{
				return this.UserEndPoint.Address.IsLocal();
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x0001930C File Offset: 0x0001750C
		public override bool IsSecureConnection
		{
			get
			{
				return this._secure;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x00019324 File Offset: 0x00017524
		public override bool IsWebSocketRequest
		{
			get
			{
				return this._request.IsWebSocketRequest;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x00019344 File Offset: 0x00017544
		public override string Origin
		{
			get
			{
				return this._request.Headers["Origin"];
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x0001936C File Offset: 0x0001756C
		public override NameValueCollection QueryString
		{
			get
			{
				bool flag = this._queryString == null;
				if (flag)
				{
					Uri requestUri = this.RequestUri;
					this._queryString = QueryStringCollection.Parse((requestUri != null) ? requestUri.Query : null, Encoding.UTF8);
				}
				return this._queryString;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x000193BC File Offset: 0x000175BC
		public override Uri RequestUri
		{
			get
			{
				bool flag = this._requestUri == null;
				if (flag)
				{
					this._requestUri = HttpUtility.CreateRequestUrl(this._request.RequestUri, this._request.Headers["Host"], this._request.IsWebSocketRequest, this._secure);
				}
				return this._requestUri;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600043E RID: 1086 RVA: 0x00019424 File Offset: 0x00017624
		public override string SecWebSocketKey
		{
			get
			{
				return this._request.Headers["Sec-WebSocket-Key"];
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x0001944C File Offset: 0x0001764C
		public override IEnumerable<string> SecWebSocketProtocols
		{
			get
			{
				string val = this._request.Headers["Sec-WebSocket-Protocol"];
				bool flag = val == null || val.Length == 0;
				if (flag)
				{
					yield break;
				}
				foreach (string elm in val.Split(new char[]
				{
					','
				}))
				{
					string protocol = elm.Trim();
					bool flag2 = protocol.Length == 0;
					if (!flag2)
					{
						yield return protocol;
						protocol = null;
						elm = null;
					}
				}
				string[] array = null;
				yield break;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x0001946C File Offset: 0x0001766C
		public override string SecWebSocketVersion
		{
			get
			{
				return this._request.Headers["Sec-WebSocket-Version"];
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x00019494 File Offset: 0x00017694
		public override IPEndPoint ServerEndPoint
		{
			get
			{
				return (IPEndPoint)this._serverEndPoint;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x000194B4 File Offset: 0x000176B4
		public override IPrincipal User
		{
			get
			{
				return this._user;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x000194CC File Offset: 0x000176CC
		public override IPEndPoint UserEndPoint
		{
			get
			{
				return (IPEndPoint)this._userEndPoint;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000444 RID: 1092 RVA: 0x000194EC File Offset: 0x000176EC
		public override WebSocket WebSocket
		{
			get
			{
				return this._websocket;
			}
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00019504 File Offset: 0x00017704
		private HttpRequest sendAuthenticationChallenge(string challenge)
		{
			HttpResponse httpResponse = HttpResponse.CreateUnauthorizedResponse(challenge);
			byte[] array = httpResponse.ToByteArray();
			this._stream.Write(array, 0, array.Length);
			return HttpRequest.Read(this._stream, 15000);
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00019548 File Offset: 0x00017748
		internal bool Authenticate(AuthenticationSchemes scheme, string realm, Func<IIdentity, NetworkCredential> credentialsFinder)
		{
			string chal = new AuthenticationChallenge(scheme, realm).ToString();
			int retry = -1;
			Func<bool> auth = null;
			auth = delegate()
			{
				int retry = retry;
				retry++;
				bool flag = retry > 99;
				bool result;
				if (flag)
				{
					result = false;
				}
				else
				{
					IPrincipal principal = HttpUtility.CreateUser(this._request.Headers["Authorization"], scheme, realm, this._request.HttpMethod, credentialsFinder);
					bool flag2 = principal != null && principal.Identity.IsAuthenticated;
					if (flag2)
					{
						this._user = principal;
						result = true;
					}
					else
					{
						this._request = this.sendAuthenticationChallenge(chal);
						result = auth();
					}
				}
				return result;
			};
			return auth();
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x000195C3 File Offset: 0x000177C3
		internal void Close()
		{
			this._stream.Close();
			this._tcpClient.Close();
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x000195E0 File Offset: 0x000177E0
		internal void Close(HttpStatusCode code)
		{
			HttpResponse httpResponse = HttpResponse.CreateCloseResponse(code);
			byte[] array = httpResponse.ToByteArray();
			this._stream.Write(array, 0, array.Length);
			this._stream.Close();
			this._tcpClient.Close();
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00019628 File Offset: 0x00017828
		public override string ToString()
		{
			return this._request.ToString();
		}

		// Token: 0x04000206 RID: 518
		private Logger _log;

		// Token: 0x04000207 RID: 519
		private NameValueCollection _queryString;

		// Token: 0x04000208 RID: 520
		private HttpRequest _request;

		// Token: 0x04000209 RID: 521
		private Uri _requestUri;

		// Token: 0x0400020A RID: 522
		private bool _secure;

		// Token: 0x0400020B RID: 523
		private EndPoint _serverEndPoint;

		// Token: 0x0400020C RID: 524
		private Stream _stream;

		// Token: 0x0400020D RID: 525
		private TcpClient _tcpClient;

		// Token: 0x0400020E RID: 526
		private IPrincipal _user;

		// Token: 0x0400020F RID: 527
		private EndPoint _userEndPoint;

		// Token: 0x04000210 RID: 528
		private WebSocket _websocket;
	}
}
