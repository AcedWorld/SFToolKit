using System;
using System.Threading;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x0200003F RID: 63
	internal class HttpStreamAsyncResult : IAsyncResult
	{
		// Token: 0x0600044E RID: 1102 RVA: 0x000131EA File Offset: 0x000113EA
		internal HttpStreamAsyncResult(AsyncCallback callback, object state)
		{
			this._callback = callback;
			this._state = state;
			this._sync = new object();
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x0001320B File Offset: 0x0001140B
		// (set) Token: 0x06000450 RID: 1104 RVA: 0x00013213 File Offset: 0x00011413
		internal byte[] Buffer
		{
			get
			{
				return this._buffer;
			}
			set
			{
				this._buffer = value;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x0001321C File Offset: 0x0001141C
		// (set) Token: 0x06000452 RID: 1106 RVA: 0x00013224 File Offset: 0x00011424
		internal int Count
		{
			get
			{
				return this._count;
			}
			set
			{
				this._count = value;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x0001322D File Offset: 0x0001142D
		internal Exception Exception
		{
			get
			{
				return this._exception;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000454 RID: 1108 RVA: 0x00013235 File Offset: 0x00011435
		internal bool HasException
		{
			get
			{
				return this._exception != null;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x00013240 File Offset: 0x00011440
		// (set) Token: 0x06000456 RID: 1110 RVA: 0x00013248 File Offset: 0x00011448
		internal int Offset
		{
			get
			{
				return this._offset;
			}
			set
			{
				this._offset = value;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x00013251 File Offset: 0x00011451
		// (set) Token: 0x06000458 RID: 1112 RVA: 0x00013259 File Offset: 0x00011459
		internal int SyncRead
		{
			get
			{
				return this._syncRead;
			}
			set
			{
				this._syncRead = value;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x00013262 File Offset: 0x00011462
		public object AsyncState
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x0600045A RID: 1114 RVA: 0x0001326C File Offset: 0x0001146C
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

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x000132C8 File Offset: 0x000114C8
		public bool CompletedSynchronously
		{
			get
			{
				return this._syncRead == this._count;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x0600045C RID: 1116 RVA: 0x000132D8 File Offset: 0x000114D8
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

		// Token: 0x0600045D RID: 1117 RVA: 0x0001331C File Offset: 0x0001151C
		internal void Complete()
		{
			object sync = this._sync;
			lock (sync)
			{
				if (!this._completed)
				{
					this._completed = true;
					if (this._waitHandle != null)
					{
						this._waitHandle.Set();
					}
					if (this._callback != null)
					{
						this._callback.BeginInvoke(this, delegate(IAsyncResult ar)
						{
							this._callback.EndInvoke(ar);
						}, null);
					}
				}
			}
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x000133A0 File Offset: 0x000115A0
		internal void Complete(Exception exception)
		{
			object sync = this._sync;
			lock (sync)
			{
				if (!this._completed)
				{
					this._completed = true;
					this._exception = exception;
					if (this._waitHandle != null)
					{
						this._waitHandle.Set();
					}
					if (this._callback != null)
					{
						this._callback.BeginInvoke(this, delegate(IAsyncResult ar)
						{
							this._callback.EndInvoke(ar);
						}, null);
					}
				}
			}
		}

		// Token: 0x0400021E RID: 542
		private byte[] _buffer;

		// Token: 0x0400021F RID: 543
		private AsyncCallback _callback;

		// Token: 0x04000220 RID: 544
		private bool _completed;

		// Token: 0x04000221 RID: 545
		private int _count;

		// Token: 0x04000222 RID: 546
		private Exception _exception;

		// Token: 0x04000223 RID: 547
		private int _offset;

		// Token: 0x04000224 RID: 548
		private object _state;

		// Token: 0x04000225 RID: 549
		private object _sync;

		// Token: 0x04000226 RID: 550
		private int _syncRead;

		// Token: 0x04000227 RID: 551
		private ManualResetEvent _waitHandle;
	}
}
