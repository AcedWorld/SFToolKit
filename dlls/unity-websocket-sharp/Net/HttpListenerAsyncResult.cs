using System;
using System.Threading;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000035 RID: 53
	internal class HttpListenerAsyncResult : IAsyncResult
	{
		// Token: 0x060003B9 RID: 953 RVA: 0x00011576 File Offset: 0x0000F776
		internal HttpListenerAsyncResult(AsyncCallback callback, object state)
		{
			this._callback = callback;
			this._state = state;
			this._sync = new object();
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060003BA RID: 954 RVA: 0x00011597 File Offset: 0x0000F797
		internal HttpListenerContext Context
		{
			get
			{
				if (this._exception != null)
				{
					throw this._exception;
				}
				return this._context;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060003BB RID: 955 RVA: 0x000115AE File Offset: 0x0000F7AE
		// (set) Token: 0x060003BC RID: 956 RVA: 0x000115B6 File Offset: 0x0000F7B6
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

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060003BD RID: 957 RVA: 0x000115BF File Offset: 0x0000F7BF
		internal object SyncRoot
		{
			get
			{
				return this._sync;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060003BE RID: 958 RVA: 0x000115C7 File Offset: 0x0000F7C7
		public object AsyncState
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060003BF RID: 959 RVA: 0x000115D0 File Offset: 0x0000F7D0
		public WaitHandle AsyncWaitHandle
		{
			get
			{
				object sync = this._sync;
				WaitHandle waitHandle;
				lock (sync)
				{
					if (this._waitHandle == null)
					{
						this._waitHandle = new ManualResetEvent(this._completed);
					}
					waitHandle = this._waitHandle;
				}
				return waitHandle;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x0001162C File Offset: 0x0000F82C
		public bool CompletedSynchronously
		{
			get
			{
				return this._completedSynchronously;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x00011634 File Offset: 0x0000F834
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

		// Token: 0x060003C2 RID: 962 RVA: 0x00011678 File Offset: 0x0000F878
		private void complete()
		{
			object sync = this._sync;
			lock (sync)
			{
				this._completed = true;
				if (this._waitHandle != null)
				{
					this._waitHandle.Set();
				}
			}
			if (this._callback == null)
			{
				return;
			}
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

		// Token: 0x060003C3 RID: 963 RVA: 0x000116EC File Offset: 0x0000F8EC
		internal void Complete(Exception exception)
		{
			this._exception = exception;
			this.complete();
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x000116FB File Offset: 0x0000F8FB
		internal void Complete(HttpListenerContext context, bool completedSynchronously)
		{
			this._context = context;
			this._completedSynchronously = completedSynchronously;
			this.complete();
		}

		// Token: 0x0400015F RID: 351
		private AsyncCallback _callback;

		// Token: 0x04000160 RID: 352
		private bool _completed;

		// Token: 0x04000161 RID: 353
		private bool _completedSynchronously;

		// Token: 0x04000162 RID: 354
		private HttpListenerContext _context;

		// Token: 0x04000163 RID: 355
		private bool _endCalled;

		// Token: 0x04000164 RID: 356
		private Exception _exception;

		// Token: 0x04000165 RID: 357
		private object _state;

		// Token: 0x04000166 RID: 358
		private object _sync;

		// Token: 0x04000167 RID: 359
		private ManualResetEvent _waitHandle;
	}
}
