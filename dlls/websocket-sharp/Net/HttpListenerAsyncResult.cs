using System;
using System.Threading;

namespace WebSocketSharp.Net
{
	// Token: 0x0200003F RID: 63
	internal class HttpListenerAsyncResult : IAsyncResult
	{
		// Token: 0x0600040D RID: 1037 RVA: 0x00018BF7 File Offset: 0x00016DF7
		internal HttpListenerAsyncResult(AsyncCallback callback, object state)
		{
			this._callback = callback;
			this._state = state;
			this._sync = new object();
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600040E RID: 1038 RVA: 0x00018C1C File Offset: 0x00016E1C
		internal HttpListenerContext Context
		{
			get
			{
				bool flag = this._exception != null;
				if (flag)
				{
					throw this._exception;
				}
				return this._context;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x0600040F RID: 1039 RVA: 0x00018C48 File Offset: 0x00016E48
		// (set) Token: 0x06000410 RID: 1040 RVA: 0x00018C60 File Offset: 0x00016E60
		internal bool EndCalled
		{
			get
			{
				return this._endCalled;
			}
			set
			{
				this._endCalled = value;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x00018C6C File Offset: 0x00016E6C
		internal object SyncRoot
		{
			get
			{
				return this._sync;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000412 RID: 1042 RVA: 0x00018C84 File Offset: 0x00016E84
		public object AsyncState
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x00018C9C File Offset: 0x00016E9C
		public WaitHandle AsyncWaitHandle
		{
			get
			{
				object sync = this._sync;
				WaitHandle waitHandle;
				lock (sync)
				{
					bool flag2 = this._waitHandle == null;
					if (flag2)
					{
						this._waitHandle = new ManualResetEvent(this._completed);
					}
					waitHandle = this._waitHandle;
				}
				return waitHandle;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x00018D00 File Offset: 0x00016F00
		public bool CompletedSynchronously
		{
			get
			{
				return this._completedSynchronously;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x00018D18 File Offset: 0x00016F18
		public bool IsCompleted
		{
			get
			{
				object sync = this._sync;
				bool completed;
				lock (sync)
				{
					completed = this._completed;
				}
				return completed;
			}
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00018D60 File Offset: 0x00016F60
		private void complete()
		{
			object sync = this._sync;
			lock (sync)
			{
				this._completed = true;
				bool flag2 = this._waitHandle != null;
				if (flag2)
				{
					this._waitHandle.Set();
				}
			}
			bool flag3 = this._callback == null;
			if (!flag3)
			{
				ThreadPool.QueueUserWorkItem(delegate(object state)
				{
					try
					{
						this._callback(this);
					}
					catch
					{
					}
				}, null);
			}
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00018DE4 File Offset: 0x00016FE4
		internal void Complete(Exception exception)
		{
			this._exception = exception;
			this.complete();
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00018DF5 File Offset: 0x00016FF5
		internal void Complete(HttpListenerContext context, bool completedSynchronously)
		{
			this._context = context;
			this._completedSynchronously = completedSynchronously;
			this.complete();
		}

		// Token: 0x040001AA RID: 426
		private AsyncCallback _callback;

		// Token: 0x040001AB RID: 427
		private bool _completed;

		// Token: 0x040001AC RID: 428
		private bool _completedSynchronously;

		// Token: 0x040001AD RID: 429
		private HttpListenerContext _context;

		// Token: 0x040001AE RID: 430
		private bool _endCalled;

		// Token: 0x040001AF RID: 431
		private Exception _exception;

		// Token: 0x040001B0 RID: 432
		private object _state;

		// Token: 0x040001B1 RID: 433
		private object _sync;

		// Token: 0x040001B2 RID: 434
		private ManualResetEvent _waitHandle;
	}
}
