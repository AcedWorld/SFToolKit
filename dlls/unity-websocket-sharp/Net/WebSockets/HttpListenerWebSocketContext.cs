using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Principal;

namespace UnityWebSocketSharp.Net.WebSockets
{
	// Token: 0x0200004C RID: 76
	internal class HttpListenerWebSocketContext : WebSocketContext
	{
		// Token: 0x06000519 RID: 1305 RVA: 0x000171F1 File Offset: 0x000153F1
		internal HttpListenerWebSocketContext(HttpListenerContext context, string protocol)
		{
			this._context = context;
			this._websocket = new WebSocket(this, protocol);
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x0001720D File Offset: 0x0001540D
		internal Logger Log
		{
			get
			{
				return this._context.Listener.Log;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0001721F File Offset: 0x0001541F
		internal Stream Stream
		{
			get
			{
				return this._context.Connection.Stream;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x00017231 File Offset: 0x00015431
		public override CookieCollection CookieCollection
		{
			get
			{
				return this._context.Request.Cookies;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x00017243 File Offset: 0x00015443
		public override NameValueCollection Headers
		{
			get
			{
				return this._context.Request.Headers;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x0600051E RID: 1310 RVA: 0x00017255 File Offset: 0x00015455
		public override string Host
		{
			get
			{
				return this._context.Request.UserHostName;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x0600051F RID: 1311 RVA: 0x00017267 File Offset: 0x00015467
		public override bool IsAuthenticated
		{
			get
			{
				return this._context.Request.IsAuthenticated;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000520 RID: 1312 RVA: 0x00017279 File Offset: 0x00015479
		public override bool IsLocal
		{
			get
			{
				return this._context.Request.IsLocal;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000521 RID: 1313 RVA: 0x0001728B File Offset: 0x0001548B
		public override bool IsSecureConnection
		{
			get
			{
				return this._context.Request.IsSecureConnection;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000522 RID: 1314 RVA: 0x0001729D File Offset: 0x0001549D
		public override bool IsWebSocketRequest
		{
			get
			{
				return this._context.Request.IsWebSocketRequest;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000523 RID: 1315 RVA: 0x000172AF File Offset: 0x000154AF
		public override string Origin
		{
			get
			{
				return this._context.Request.Headers["Origin"];
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000524 RID: 1316 RVA: 0x000172CB File Offset: 0x000154CB
		public override NameValueCollection QueryString
		{
			get
			{
				return this._context.Request.QueryString;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000525 RID: 1317 RVA: 0x000172DD File Offset: 0x000154DD
		public override Uri RequestUri
		{
			get
			{
				return this._context.Request.Url;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000526 RID: 1318 RVA: 0x000172EF File Offset: 0x000154EF
		public override string SecWebSocketKey
		{
			get
			{
				return this._context.Request.Headers["Sec-WebSocket-Key"];
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000527 RID: 1319 RVA: 0x0001730B File Offset: 0x0001550B
		public override IEnumerable<string> SecWebSocketProtocols
		{
			get
			{
				string text = this._context.Request.Headers["Sec-WebSocket-Protocol"];
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

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000528 RID: 1320 RVA: 0x0001731B File Offset: 0x0001551B
		public override string SecWebSocketVersion
		{
			get
			{
				return this._context.Request.Headers["Sec-WebSocket-Version"];
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000529 RID: 1321 RVA: 0x00017337 File Offset: 0x00015537
		public override IPEndPoint ServerEndPoint
		{
			get
			{
				return this._context.Request.LocalEndPoint;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x0600052A RID: 1322 RVA: 0x00017349 File Offset: 0x00015549
		public override IPrincipal User
		{
			get
			{
				return this._context.User;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x0600052B RID: 1323 RVA: 0x00017356 File Offset: 0x00015556
		public override IPEndPoint UserEndPoint
		{
			get
			{
				return this._context.Request.RemoteEndPoint;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x0600052C RID: 1324 RVA: 0x00017368 File Offset: 0x00015568
		public override WebSocket WebSocket
		{
			get
			{
				return this._websocket;
			}
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x00017370 File Offset: 0x00015570
		internal void Close()
		{
			this._context.Connection.Close(true);
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x00017383 File Offset: 0x00015583
		internal void Close(HttpStatusCode code)
		{
			this._context.Response.StatusCode = (int)code;
			this._context.Response.Close();
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x000173A6 File Offset: 0x000155A6
		public override string ToString()
		{
			return this._context.Request.ToString();
		}

		// Token: 0x0400025D RID: 605
		private HttpListenerContext _context;

		// Token: 0x0400025E RID: 606
		private WebSocket _websocket;
	}
}
