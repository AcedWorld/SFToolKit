using System;
using WebSocketSharp.Net.WebSockets;

namespace WebSocketSharp.Server
{
	// Token: 0x02000047 RID: 71
	public abstract class WebSocketServiceHost
	{
		// Token: 0x060004C8 RID: 1224 RVA: 0x0001B924 File Offset: 0x00019B24
		protected WebSocketServiceHost(string path, Logger log)
		{
			this._path = path;
			this._log = log;
			this._sessions = new WebSocketSessionManager(log);
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060004C9 RID: 1225 RVA: 0x0001B948 File Offset: 0x00019B48
		internal ServerState State
		{
			get
			{
				return this._sessions.State;
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x0001B968 File Offset: 0x00019B68
		protected Logger Log
		{
			get
			{
				return this._log;
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x0001B980 File Offset: 0x00019B80
		// (set) Token: 0x060004CC RID: 1228 RVA: 0x0001B99D File Offset: 0x00019B9D
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

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x0001B9B0 File Offset: 0x00019BB0
		public string Path
		{
			get
			{
				return this._path;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x0001B9C8 File Offset: 0x00019BC8
		public WebSocketSessionManager Sessions
		{
			get
			{
				return this._sessions;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060004CF RID: 1231
		public abstract Type BehaviorType { get; }

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x0001B9E0 File Offset: 0x00019BE0
		// (set) Token: 0x060004D1 RID: 1233 RVA: 0x0001B9FD File Offset: 0x00019BFD
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

		// Token: 0x060004D2 RID: 1234 RVA: 0x0001BA0D File Offset: 0x00019C0D
		internal void Start()
		{
			this._sessions.Start();
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0001BA1C File Offset: 0x00019C1C
		internal void StartSession(WebSocketContext context)
		{
			this.CreateSession().Start(context, this._sessions);
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0001BA32 File Offset: 0x00019C32
		internal void Stop(ushort code, string reason)
		{
			this._sessions.Stop(code, reason);
		}

		// Token: 0x060004D5 RID: 1237
		protected abstract WebSocketBehavior CreateSession();

		// Token: 0x04000238 RID: 568
		private Logger _log;

		// Token: 0x04000239 RID: 569
		private string _path;

		// Token: 0x0400023A RID: 570
		private WebSocketSessionManager _sessions;
	}
}
