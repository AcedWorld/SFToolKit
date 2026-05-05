using System;
using System.Collections;
using System.Collections.Generic;

namespace WebSocketSharp.Server
{
	// Token: 0x0200004C RID: 76
	public class WebSocketServiceManager
	{
		// Token: 0x06000514 RID: 1300 RVA: 0x0001D0EC File Offset: 0x0001B2EC
		internal WebSocketServiceManager(Logger log)
		{
			this._log = log;
			this._hosts = new Dictionary<string, WebSocketServiceHost>();
			this._keepClean = true;
			this._state = ServerState.Ready;
			this._sync = ((ICollection)this._hosts).SyncRoot;
			this._waitTime = TimeSpan.FromSeconds(1.0);
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000515 RID: 1301 RVA: 0x0001D14C File Offset: 0x0001B34C
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

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000516 RID: 1302 RVA: 0x0001D198 File Offset: 0x0001B398
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

		// Token: 0x1700018B RID: 395
		public WebSocketServiceHost this[string path]
		{
			get
			{
				bool flag = path == null;
				if (flag)
				{
					throw new ArgumentNullException("path");
				}
				bool flag2 = path.Length == 0;
				if (flag2)
				{
					throw new ArgumentException("An empty string.", "path");
				}
				bool flag3 = path[0] != '/';
				if (flag3)
				{
					string message = "It is not an absolute path.";
					throw new ArgumentException(message, "path");
				}
				bool flag4 = path.IndexOfAny(new char[]
				{
					'?',
					'#'
				}) > -1;
				if (flag4)
				{
					string message2 = "It includes either or both query and fragment components.";
					throw new ArgumentException(message2, "path");
				}
				WebSocketServiceHost result;
				this.InternalTryGetServiceHost(path, out result);
				return result;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x0001D294 File Offset: 0x0001B494
		// (set) Token: 0x06000519 RID: 1305 RVA: 0x0001D2B0 File Offset: 0x0001B4B0
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
					string message;
					bool flag2 = !this.canSet(out message);
					if (flag2)
					{
						this._log.Warn(message);
					}
					else
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

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x0001D364 File Offset: 0x0001B564
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

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0001D3B4 File Offset: 0x0001B5B4
		// (set) Token: 0x0600051C RID: 1308 RVA: 0x0001D3CC File Offset: 0x0001B5CC
		public TimeSpan WaitTime
		{
			get
			{
				return this._waitTime;
			}
			set
			{
				bool flag = value <= TimeSpan.Zero;
				if (flag)
				{
					string message = "It is zero or less.";
					throw new ArgumentOutOfRangeException("value", message);
				}
				object sync = this._sync;
				lock (sync)
				{
					string message2;
					bool flag3 = !this.canSet(out message2);
					if (flag3)
					{
						this._log.Warn(message2);
					}
					else
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

		// Token: 0x0600051D RID: 1309 RVA: 0x0001D4A4 File Offset: 0x0001B6A4
		private bool canSet(out string message)
		{
			message = null;
			bool flag = this._state == ServerState.Start;
			bool result;
			if (flag)
			{
				message = "The server has already started.";
				result = false;
			}
			else
			{
				bool flag2 = this._state == ServerState.ShuttingDown;
				if (flag2)
				{
					message = "The server is shutting down.";
					result = false;
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0001D4F0 File Offset: 0x0001B6F0
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

		// Token: 0x0600051F RID: 1311 RVA: 0x0001D544 File Offset: 0x0001B744
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

		// Token: 0x06000520 RID: 1312 RVA: 0x0001D5D8 File Offset: 0x0001B7D8
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

		// Token: 0x06000521 RID: 1313 RVA: 0x0001D674 File Offset: 0x0001B874
		public void AddService<TBehavior>(string path, Action<TBehavior> initializer) where TBehavior : WebSocketBehavior, new()
		{
			bool flag = path == null;
			if (flag)
			{
				throw new ArgumentNullException("path");
			}
			bool flag2 = path.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			bool flag3 = path[0] != '/';
			if (flag3)
			{
				string message = "It is not an absolute path.";
				throw new ArgumentException(message, "path");
			}
			bool flag4 = path.IndexOfAny(new char[]
			{
				'?',
				'#'
			}) > -1;
			if (flag4)
			{
				string message2 = "It includes either or both query and fragment components.";
				throw new ArgumentException(message2, "path");
			}
			path = path.TrimSlashFromEnd();
			object sync = this._sync;
			lock (sync)
			{
				WebSocketServiceHost webSocketServiceHost;
				bool flag6 = this._hosts.TryGetValue(path, out webSocketServiceHost);
				if (flag6)
				{
					string message3 = "It is already in use.";
					throw new ArgumentException(message3, "path");
				}
				webSocketServiceHost = new WebSocketServiceHost<TBehavior>(path, initializer, this._log);
				bool flag7 = !this._keepClean;
				if (flag7)
				{
					webSocketServiceHost.KeepClean = false;
				}
				bool flag8 = this._waitTime != webSocketServiceHost.WaitTime;
				if (flag8)
				{
					webSocketServiceHost.WaitTime = this._waitTime;
				}
				bool flag9 = this._state == ServerState.Start;
				if (flag9)
				{
					webSocketServiceHost.Start();
				}
				this._hosts.Add(path, webSocketServiceHost);
			}
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0001D7EC File Offset: 0x0001B9EC
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
				bool flag2 = webSocketServiceHost.State == ServerState.Start;
				if (flag2)
				{
					webSocketServiceHost.Stop(1001, string.Empty);
				}
			}
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0001D8A8 File Offset: 0x0001BAA8
		public bool RemoveService(string path)
		{
			bool flag = path == null;
			if (flag)
			{
				throw new ArgumentNullException("path");
			}
			bool flag2 = path.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			bool flag3 = path[0] != '/';
			if (flag3)
			{
				string message = "It is not an absolute path.";
				throw new ArgumentException(message, "path");
			}
			bool flag4 = path.IndexOfAny(new char[]
			{
				'?',
				'#'
			}) > -1;
			if (flag4)
			{
				string message2 = "It includes either or both query and fragment components.";
				throw new ArgumentException(message2, "path");
			}
			path = path.TrimSlashFromEnd();
			object sync = this._sync;
			WebSocketServiceHost webSocketServiceHost;
			lock (sync)
			{
				bool flag6 = !this._hosts.TryGetValue(path, out webSocketServiceHost);
				if (flag6)
				{
					return false;
				}
				this._hosts.Remove(path);
			}
			bool flag7 = webSocketServiceHost.State == ServerState.Start;
			if (flag7)
			{
				webSocketServiceHost.Stop(1001, string.Empty);
			}
			return true;
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0001D9D0 File Offset: 0x0001BBD0
		public bool TryGetServiceHost(string path, out WebSocketServiceHost host)
		{
			bool flag = path == null;
			if (flag)
			{
				throw new ArgumentNullException("path");
			}
			bool flag2 = path.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			bool flag3 = path[0] != '/';
			if (flag3)
			{
				string message = "It is not an absolute path.";
				throw new ArgumentException(message, "path");
			}
			bool flag4 = path.IndexOfAny(new char[]
			{
				'?',
				'#'
			}) > -1;
			if (flag4)
			{
				string message2 = "It includes either or both query and fragment components.";
				throw new ArgumentException(message2, "path");
			}
			return this.InternalTryGetServiceHost(path, out host);
		}

		// Token: 0x0400024B RID: 587
		private Dictionary<string, WebSocketServiceHost> _hosts;

		// Token: 0x0400024C RID: 588
		private volatile bool _keepClean;

		// Token: 0x0400024D RID: 589
		private Logger _log;

		// Token: 0x0400024E RID: 590
		private volatile ServerState _state;

		// Token: 0x0400024F RID: 591
		private object _sync;

		// Token: 0x04000250 RID: 592
		private TimeSpan _waitTime;
	}
}
