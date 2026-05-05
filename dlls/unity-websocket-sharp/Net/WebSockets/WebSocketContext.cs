using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Security.Principal;

namespace UnityWebSocketSharp.Net.WebSockets
{
	// Token: 0x0200004E RID: 78
	internal abstract class WebSocketContext
	{
		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600054A RID: 1354
		public abstract CookieCollection CookieCollection { get; }

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x0600054B RID: 1355
		public abstract NameValueCollection Headers { get; }

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x0600054C RID: 1356
		public abstract string Host { get; }

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x0600054D RID: 1357
		public abstract bool IsAuthenticated { get; }

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x0600054E RID: 1358
		public abstract bool IsLocal { get; }

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x0600054F RID: 1359
		public abstract bool IsSecureConnection { get; }

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000550 RID: 1360
		public abstract bool IsWebSocketRequest { get; }

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000551 RID: 1361
		public abstract string Origin { get; }

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000552 RID: 1362
		public abstract NameValueCollection QueryString { get; }

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000553 RID: 1363
		public abstract Uri RequestUri { get; }

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000554 RID: 1364
		public abstract string SecWebSocketKey { get; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000555 RID: 1365
		public abstract IEnumerable<string> SecWebSocketProtocols { get; }

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000556 RID: 1366
		public abstract string SecWebSocketVersion { get; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000557 RID: 1367
		public abstract IPEndPoint ServerEndPoint { get; }

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000558 RID: 1368
		public abstract IPrincipal User { get; }

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000559 RID: 1369
		public abstract IPEndPoint UserEndPoint { get; }

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x0600055A RID: 1370
		public abstract WebSocket WebSocket { get; }
	}
}
