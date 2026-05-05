using System;
using System.Threading;

namespace WebSocketSharp.Net
{
	// Token: 0x02000026 RID: 38
	internal class HttpStreamAsyncResult : IAsyncResult
	{
		// Token: 0x060002DC RID: 732 RVA: 0x000122BC File Offset: 0x000104BC
		internal HttpStreamAsyncResult(AsyncCallback callback, object state)
		{
			this._callback = callback;
			this._state = state;
			this._sync = new object();
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060002DD RID: 733 RVA: 0x000122E0 File Offset: 0x000104E0
		// (set) Token: 0x060002DE RID: 734 RVA: 0x000122F8 File Offset: 0x000104F8
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

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060002DF RID: 735 RVA: 0x00012304 File Offset: 0x00010504
		// (set) Token: 0x060002E0 RID: 736 RVA: 0x0001231C File Offset: 0x0001051C
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

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x00012328 File Offset: 0x00010528
		internal Exception Exception
		{
			get
			{
				return this._exception;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x00012340 File Offset: 0x00010540
		internal bool HasException
		{
			get
			{
				return this._exception != null;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x0001235C File Offset: 0x0001055C
		// (set) Token: 0x060002E4 RID: 740 RVA: 0x00012374 File Offset: 0x00010574
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

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x00012380 File Offset: 0x00010580
		// (set) Token: 0x060002E6 RID: 742 RVA: 0x00012398 File Offset: 0x00010598
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

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x000123A4 File Offset: 0x000105A4
		public object AsyncState
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x000123BC File Offset: 0x000105BC
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

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x00012420 File Offset: 0x00010620
		public bool CompletedSynchronously
		{
			get
			{
				return this._syncRead == this._count;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00012440 File Offset: 0x00010640
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

		// Token: 0x060002EB RID: 747 RVA: 0x00012488 File Offset: 0x00010688
		internal void Complete()
		{
			object sync = this._sync;
			lock (sync)
			{
				bool completed = this._completed;
				if (!completed)
				{
					this._completed = true;
					bool flag2 = this._waitHandle != null;
					if (flag2)
					{
						this._waitHandle.Set();
					}
					bool flag3 = this._callback != null;
					if (flag3)
					{
						this._callback.BeginInvoke(this, delegate(IAsyncResult ar)
						{
							this._callback.EndInvoke(ar);
						}, null);
					}
				}
			}
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0001251C File Offset: 0x0001071C
		internal void Complete(Exception exception)
		{
			object sync = this._sync;
			lock (sync)
			{
				bool completed = this._completed;
				if (!completed)
				{
					this._completed = true;
					this._exception = exception;
					bool flag2 = this._waitHandle != null;
					if (flag2)
					{
						this._waitHandle.Set();
					}
					bool flag3 = this._callback != null;
					if (flag3)
					{
						this._callback.BeginInvoke(this, delegate(IAsyncResult ar)
						{
							this._callback.EndInvoke(ar);
						}, null);
					}
				}
			}
		}

		// Token: 0x04000119 RID: 281
		private byte[] _buffer;

		// Token: 0x0400011A RID: 282
		private AsyncCallback _callback;

		// Token: 0x0400011B RID: 283
		private bool _completed;

		// Token: 0x0400011C RID: 284
		private int _count;

		// Token: 0x0400011D RID: 285
		private Exception _exception;

		// Token: 0x0400011E RID: 286
		private int _offset;

		// Token: 0x0400011F RID: 287
		private object _state;

		// Token: 0x04000120 RID: 288
		private object _sync;

		// Token: 0x04000121 RID: 289
		private int _syncRead;

		// Token: 0x04000122 RID: 290
		private ManualResetEvent _waitHandle;
	}
}
