using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Principal;

namespace WebSocketSharp.Net.WebSockets
{
	// Token: 0x02000042 RID: 66
	public class HttpListenerWebSocketContext : WebSocketContext
	{
		// Token: 0x0600041A RID: 1050 RVA: 0x00018E44 File Offset: 0x00017044
		internal HttpListenerWebSocketContext(HttpListenerContext context, string protocol)
		{
			this._context = context;
			this._websocket = new WebSocket(this, protocol);
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600041B RID: 1051 RVA: 0x00018E64 File Offset: 0x00017064
		internal Logger Log
		{
			get
			{
				return this._context.Listener.Log;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x00018E88 File Offset: 0x00017088
		internal Stream Stream
		{
			get
			{
				return this._context.Connection.Stream;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x00018EAC File Offset: 0x000170AC
		public override CookieCollection CookieCollection
		{
			get
			{
				return this._context.Request.Cookies;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x00018ED0 File Offset: 0x000170D0
		public override NameValueCollection Headers
		{
			get
			{
				return this._context.Request.Headers;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x00018EF4 File Offset: 0x000170F4
		public override string Host
		{
			get
			{
				return this._context.Request.UserHostName;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x00018F18 File Offset: 0x00017118
		public override bool IsAuthenticated
		{
			get
			{
				return this._context.Request.IsAuthenticated;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x00018F3C File Offset: 0x0001713C
		public override bool IsLocal
		{
			get
			{
				return this._context.Request.IsLocal;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000422 RID: 1058 RVA: 0x00018F60 File Offset: 0x00017160
		public override bool IsSecureConnection
		{
			get
			{
				return this._context.Request.IsSecureConnection;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x00018F84 File Offset: 0x00017184
		public override bool IsWebSocketRequest
		{
			get
			{
				return this._context.Request.IsWebSocketRequest;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x00018FA8 File Offset: 0x000171A8
		public override string Origin
		{
			get
			{
				return this._context.Request.Headers["Origin"];
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x00018FD4 File Offset: 0x000171D4
		public override NameValueCollection QueryString
		{
			get
			{
				return this._context.Request.QueryString;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x00018FF8 File Offset: 0x000171F8
		public override Uri RequestUri
		{
			get
			{
				return this._context.Request.Url;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x0001901C File Offset: 0x0001721C
		public override string SecWebSocketKey
		{
			get
			{
				return this._context.Request.Headers["Sec-WebSocket-Key"];
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000428 RID: 1064 RVA: 0x00019048 File Offset: 0x00017248
		public override IEnumerable<string> SecWebSocketProtocols
		{
			get
			{
				string val = this._context.Request.Headers["Sec-WebSocket-Protocol"];
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

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x00019068 File Offset: 0x00017268
		public override string SecWebSocketVersion
		{
			get
			{
				return this._context.Request.Headers["Sec-WebSocket-Version"];
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x00019094 File Offset: 0x00017294
		public override IPEndPoint ServerEndPoint
		{
			get
			{
				return this._context.Request.LocalEndPoint;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x000190B8 File Offset: 0x000172B8
		public override IPrincipal User
		{
			get
			{
				return this._context.User;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x000190D8 File Offset: 0x000172D8
		public override IPEndPoint UserEndPoint
		{
			get
			{
				return this._context.Request.RemoteEndPoint;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x000190FC File Offset: 0x000172FC
		public override WebSocket WebSocket
		{
			get
			{
				return this._websocket;
			}
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x00019114 File Offset: 0x00017314
		internal void Close()
		{
			this._context.Connection.Close(true);
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00019129 File Offset: 0x00017329
		internal void Close(HttpStatusCode code)
		{
			this._context.Response.StatusCode = (int)code;
			this._context.Response.Close();
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00019150 File Offset: 0x00017350
		public override string ToString()
		{
			return this._context.Request.ToString();
		}

		// Token: 0x04000204 RID: 516
		private HttpListenerContext _context;

		// Token: 0x04000205 RID: 517
		private WebSocket _websocket;
	}
}
