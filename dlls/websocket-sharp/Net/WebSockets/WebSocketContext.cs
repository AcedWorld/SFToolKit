using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Security.Principal;

namespace WebSocketSharp.Net.WebSockets
{
	// Token: 0x02000044 RID: 68
	public abstract class WebSocketContext
	{
		// Token: 0x17000144 RID: 324
		// (get) Token: 0x0600044B RID: 1099
		public abstract CookieCollection CookieCollection { get; }

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x0600044C RID: 1100
		public abstract NameValueCollection Headers { get; }

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x0600044D RID: 1101
		public abstract string Host { get; }

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x0600044E RID: 1102
		public abstract bool IsAuthenticated { get; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x0600044F RID: 1103
		public abstract bool IsLocal { get; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000450 RID: 1104
		public abstract bool IsSecureConnection { get; }

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000451 RID: 1105
		public abstract bool IsWebSocketRequest { get; }

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000452 RID: 1106
		public abstract string Origin { get; }

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000453 RID: 1107
		public abstract NameValueCollection QueryString { get; }

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000454 RID: 1108
		public abstract Uri RequestUri { get; }

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000455 RID: 1109
		public abstract string SecWebSocketKey { get; }

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000456 RID: 1110
		public abstract IEnumerable<string> SecWebSocketProtocols { get; }

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000457 RID: 1111
		public abstract string SecWebSocketVersion { get; }

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000458 RID: 1112
		public abstract IPEndPoint ServerEndPoint { get; }

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000459 RID: 1113
		public abstract IPrincipal User { get; }

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x0600045A RID: 1114
		public abstract IPEndPoint UserEndPoint { get; }

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x0600045B RID: 1115
		public abstract WebSocket WebSocket { get; }
	}
}
