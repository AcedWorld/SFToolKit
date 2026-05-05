using System;
using UnityWebSocketSharp.Net.WebSockets;

namespace UnityWebSocketSharp.Server
{
	// Token: 0x0200001F RID: 31
	internal abstract class WebSocketServiceHost
	{
		// Token: 0x06000238 RID: 568 RVA: 0x0000AF49 File Offset: 0x00009149
		protected WebSocketServiceHost(string path, Logger log)
		{
			this._path = path;
			this._log = log;
			this._sessions = new WebSocketSessionManager(log);
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000239 RID: 569 RVA: 0x0000AF6B File Offset: 0x0000916B
		internal ServerState State
		{
			get
			{
				return this._sessions.State;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600023A RID: 570 RVA: 0x0000AF78 File Offset: 0x00009178
		protected Logger Log
		{
			get
			{
				return this._log;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600023B RID: 571 RVA: 0x0000AF80 File Offset: 0x00009180
		// (set) Token: 0x0600023C RID: 572 RVA: 0x0000AF8D File Offset: 0x0000918D
		public bool KeepClean
		{
			get
			{
				return this._sessions.KeepClean;
			}
			set
			{
				this._sessions.KeepClean = value;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600023D RID: 573 RVA: 0x0000AF9B File Offset: 0x0000919B
		public string Path
		{
			get
			{
				return this._path;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600023E RID: 574 RVA: 0x0000AFA3 File Offset: 0x000091A3
		public WebSocketSessionManager Sessions
		{
			get
			{
				return this._sessions;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600023F RID: 575
		public abstract Type BehaviorType { get; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000240 RID: 576 RVA: 0x0000AFAB File Offset: 0x000091AB
		// (set) Token: 0x06000241 RID: 577 RVA: 0x0000AFB8 File Offset: 0x000091B8
		public TimeSpan WaitTime
		{
			get
			{
				return this._sessions.WaitTime;
			}
			set
			{
				this._sessions.WaitTime = value;
			}
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000AFC6 File Offset: 0x000091C6
		internal void Start()
		{
			this._sessions.Start();
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000AFD3 File Offset: 0x000091D3
		internal void StartSession(WebSocketContext context)
		{
			this.CreateSession().Start(context, this._sessions);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000AFE7 File Offset: 0x000091E7
		internal void Stop(ushort code, string reason)
		{
			this._sessions.Stop(code, reason);
		}

		// Token: 0x06000245 RID: 581
		protected abstract WebSocketBehavior CreateSession();

		// Token: 0x040000D3 RID: 211
		private Logger _log;

		// Token: 0x040000D4 RID: 212
		private string _path;

		// Token: 0x040000D5 RID: 213
		private WebSocketSessionManager _sessions;
	}
}
