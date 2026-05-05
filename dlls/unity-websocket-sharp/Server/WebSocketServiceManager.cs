using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityWebSocketSharp.Server
{
	// Token: 0x02000021 RID: 33
	internal class WebSocketServiceManager
	{
		// Token: 0x0600024A RID: 586 RVA: 0x0000B078 File Offset: 0x00009278
		internal WebSocketServiceManager(Logger log)
		{
			this._log = log;
			this._hosts = new Dictionary<string, WebSocketServiceHost>();
			this._keepClean = true;
			this._state = ServerState.Ready;
			this._sync = ((ICollection)this._hosts).SyncRoot;
			this._waitTime = TimeSpan.FromSeconds(1.0);
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600024B RID: 587 RVA: 0x0000B0D4 File Offset: 0x000092D4
		public int Count
		{
			get
			{
				object sync = this._sync;
				int count;
				lock (sync)
				{
					count = this._hosts.Count;
				}
				return count;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600024C RID: 588 RVA: 0x0000B11C File Offset: 0x0000931C
		public IEnumerable<WebSocketServiceHost> Hosts
		{
			get
			{
				object sync = this._sync;
				IEnumerable<WebSocketServiceHost> result;
				lock (sync)
				{
					result = this._hosts.Values.ToList<WebSocketServiceHost>();
				}
				return result;
			}
		}

		// Token: 0x1700009A RID: 154
		public WebSocketServiceHost this[string path]
		{
			get
			{
				if (path == null)
				{
					throw new ArgumentNullException("path");
				}
				if (path.Length == 0)
				{
					throw new ArgumentException("An empty string.", "path");
				}
				if (path[0] != '/')
				{
					throw new ArgumentException("Not an absolute path.", "path");
				}
				if (path.IndexOfAny(new char[]
				{
					'?',
					'#'
				}) > -1)
				{
					throw new ArgumentException("It includes either or both query and fragment components.", "path");
				}
				WebSocketServiceHost result;
				this.InternalTryGetServiceHost(path, out result);
				return result;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600024E RID: 590 RVA: 0x0000B1EA File Offset: 0x000093EA
		// (set) Token: 0x0600024F RID: 591 RVA: 0x0000B1F4 File Offset: 0x000093F4
		public bool KeepClean
		{
			get
			{
				return this._keepClean;
			}
			set
			{
				object sync = this._sync;
				lock (sync)
				{
					if (this.canSet())
					{
						foreach (WebSocketServiceHost webSocketServiceHost in this._hosts.Values)
						{
							webSocketServiceHost.KeepClean = value;
						}
						this._keepClean = value;
					}
				}
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000250 RID: 592 RVA: 0x0000B288 File Offset: 0x00009488
		public IEnumerable<string> Paths
		{
			get
			{
				object sync = this._sync;
				IEnumerable<string> result;
				lock (sync)
				{
					result = this._hosts.Keys.ToList<string>();
				}
				return result;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000251 RID: 593 RVA: 0x0000B2D4 File Offset: 0x000094D4
		// (set) Token: 0x06000252 RID: 594 RVA: 0x0000B2DC File Offset: 0x000094DC
		public TimeSpan WaitTime
		{
			get
			{
				return this._waitTime;
			}
			set
			{
				if (value <= TimeSpan.Zero)
				{
					string message = "Zero or less.";
					throw new ArgumentOutOfRangeException("value", message);
				}
				object sync = this._sync;
				lock (sync)
				{
					if (this.canSet())
					{
						foreach (WebSocketServiceHost webSocketServiceHost in this._hosts.Values)
						{
							webSocketServiceHost.WaitTime = value;
						}
						this._waitTime = value;
					}
				}
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000B38C File Offset: 0x0000958C
		private bool canSet()
		{
			return this._state == ServerState.Ready || this._state == ServerState.Stop;
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000B3A8 File Offset: 0x000095A8
		internal bool InternalTryGetServiceHost(string path, out WebSocketServiceHost host)
		{
			path = path.TrimSlashFromEnd();
			object sync = this._sync;
			bool result;
			lock (sync)
			{
				result = this._hosts.TryGetValue(path, out host);
			}
			return result;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000B3FC File Offset: 0x000095FC
		internal void Start()
		{
			object sync = this._sync;
			lock (sync)
			{
				foreach (WebSocketServiceHost webSocketServiceHost in this._hosts.Values)
				{
					webSocketServiceHost.Start();
				}
				this._state = ServerState.Start;
			}
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000B484 File Offset: 0x00009684
		internal void Stop(ushort code, string reason)
		{
			object sync = this._sync;
			lock (sync)
			{
				this._state = ServerState.ShuttingDown;
				foreach (WebSocketServiceHost webSocketServiceHost in this._hosts.Values)
				{
					webSocketServiceHost.Stop(code, reason);
				}
				this._state = ServerState.Stop;
			}
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000B518 File Offset: 0x00009718
		public void AddService<TBehavior>(string path, Action<TBehavior> initializer) where TBehavior : WebSocketBehavior, new()
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			if (path[0] != '/')
			{
				throw new ArgumentException("Not an absolute path.", "path");
			}
			if (path.IndexOfAny(new char[]
			{
				'?',
				'#'
			}) > -1)
			{
				throw new ArgumentException("It includes either or both query and fragment components.", "path");
			}
			path = path.TrimSlashFromEnd();
			object sync = this._sync;
			lock (sync)
			{
				WebSocketServiceHost webSocketServiceHost;
				if (this._hosts.TryGetValue(path, out webSocketServiceHost))
				{
					throw new ArgumentException("It is already in use.", "path");
				}
				webSocketServiceHost = new WebSocketServiceHost<TBehavior>(path, initializer, this._log);
				if (!this._keepClean)
				{
					webSocketServiceHost.KeepClean = false;
				}
				if (this._waitTime != webSocketServiceHost.WaitTime)
				{
					webSocketServiceHost.WaitTime = this._waitTime;
				}
				if (this._state == ServerState.Start)
				{
					webSocketServiceHost.Start();
				}
				this._hosts.Add(path, webSocketServiceHost);
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000B640 File Offset: 0x00009840
		public void Clear()
		{
			List<WebSocketServiceHost> list = null;
			object sync = this._sync;
			lock (sync)
			{
				list = this._hosts.Values.ToList<WebSocketServiceHost>();
				this._hosts.Clear();
			}
			foreach (WebSocketServiceHost webSocketServiceHost in list)
			{
				if (webSocketServiceHost.State == ServerState.Start)
				{
					webSocketServiceHost.Stop(1001, string.Empty);
				}
			}
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000B6EC File Offset: 0x000098EC
		public bool RemoveService(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			if (path[0] != '/')
			{
				throw new ArgumentException("Not an absolute path.", "path");
			}
			if (path.IndexOfAny(new char[]
			{
				'?',
				'#'
			}) > -1)
			{
				throw new ArgumentException("It includes either or both query and fragment components.", "path");
			}
			path = path.TrimSlashFromEnd();
			object sync = this._sync;
			WebSocketServiceHost webSocketServiceHost;
			lock (sync)
			{
				if (!this._hosts.TryGetValue(path, out webSocketServiceHost))
				{
					return false;
				}
				this._hosts.Remove(path);
			}
			if (webSocketServiceHost.State == ServerState.Start)
			{
				webSocketServiceHost.Stop(1001, string.Empty);
			}
			return true;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000B7D8 File Offset: 0x000099D8
		public bool TryGetServiceHost(string path, out WebSocketServiceHost host)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			if (path[0] != '/')
			{
				throw new ArgumentException("Not an absolute path.", "path");
			}
			if (path.IndexOfAny(new char[]
			{
				'?',
				'#'
			}) > -1)
			{
				throw new ArgumentException("It includes either or both query and fragment components.", "path");
			}
			return this.InternalTryGetServiceHost(path, out host);
		}

		// Token: 0x040000D7 RID: 215
		private Dictionary<string, WebSocketServiceHost> _hosts;

		// Token: 0x040000D8 RID: 216
		private volatile bool _keepClean;

		// Token: 0x040000D9 RID: 217
		private Logger _log;

		// Token: 0x040000DA RID: 218
		private volatile ServerState _state;

		// Token: 0x040000DB RID: 219
		private object _sync;

		// Token: 0x040000DC RID: 220
		private TimeSpan _waitTime;
	}
}
