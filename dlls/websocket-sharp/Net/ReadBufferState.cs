using System;

namespace WebSocketSharp.Net
{
	// Token: 0x02000034 RID: 52
	internal class ReadBufferState
	{
		// Token: 0x0600039D RID: 925 RVA: 0x00016F3E File Offset: 0x0001513E
		public ReadBufferState(byte[] buffer, int offset, int count, HttpStreamAsyncResult asyncResult)
		{
			this._buffer = buffer;
			this._offset = offset;
			this._count = count;
			this._asyncResult = asyncResult;
			this._initialCount = count;
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600039E RID: 926 RVA: 0x00016F6C File Offset: 0x0001516C
		// (set) Token: 0x0600039F RID: 927 RVA: 0x00016F84 File Offset: 0x00015184
		public HttpStreamAsyncResult AsyncResult
		{
			get
			{
				return this._asyncResult;
			}
			set
			{
				this._asyncResult = value;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x00016F90 File Offset: 0x00015190
		// (set) Token: 0x060003A1 RID: 929 RVA: 0x00016FA8 File Offset: 0x000151A8
		public byte[] Buffer
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

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x00016FB4 File Offset: 0x000151B4
		// (set) Token: 0x060003A3 RID: 931 RVA: 0x00016FCC File Offset: 0x000151CC
		public int Count
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

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x00016FD8 File Offset: 0x000151D8
		// (set) Token: 0x060003A5 RID: 933 RVA: 0x00016FF0 File Offset: 0x000151F0
		public int InitialCount
		{
			get
			{
				return this._initialCount;
			}
			set
			{
				this._initialCount = value;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x00016FFC File Offset: 0x000151FC
		// (set) Token: 0x060003A7 RID: 935 RVA: 0x00017014 File Offset: 0x00015214
		public int Offset
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

		// Token: 0x04000183 RID: 387
		private HttpStreamAsyncResult _asyncResult;

		// Token: 0x04000184 RID: 388
		private byte[] _buffer;

		// Token: 0x04000185 RID: 389
		private int _count;

		// Token: 0x04000186 RID: 390
		private int _initialCount;

		// Token: 0x04000187 RID: 391
		private int _offset;
	}
}
