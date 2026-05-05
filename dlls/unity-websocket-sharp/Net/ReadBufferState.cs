using System;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000047 RID: 71
	internal class ReadBufferState
	{
		// Token: 0x0600049C RID: 1180 RVA: 0x0001586F File Offset: 0x00013A6F
		public ReadBufferState(byte[] buffer, int offset, int count, HttpStreamAsyncResult asyncResult)
		{
			this._buffer = buffer;
			this._offset = offset;
			this._count = count;
			this._asyncResult = asyncResult;
			this._initialCount = count;
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x0001589B File Offset: 0x00013A9B
		// (set) Token: 0x0600049E RID: 1182 RVA: 0x000158A3 File Offset: 0x00013AA3
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

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x000158AC File Offset: 0x00013AAC
		// (set) Token: 0x060004A0 RID: 1184 RVA: 0x000158B4 File Offset: 0x00013AB4
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

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x000158BD File Offset: 0x00013ABD
		// (set) Token: 0x060004A2 RID: 1186 RVA: 0x000158C5 File Offset: 0x00013AC5
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

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x000158CE File Offset: 0x00013ACE
		// (set) Token: 0x060004A4 RID: 1188 RVA: 0x000158D6 File Offset: 0x00013AD6
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

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x000158DF File Offset: 0x00013ADF
		// (set) Token: 0x060004A6 RID: 1190 RVA: 0x000158E7 File Offset: 0x00013AE7
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

		// Token: 0x0400023F RID: 575
		private HttpStreamAsyncResult _asyncResult;

		// Token: 0x04000240 RID: 576
		private byte[] _buffer;

		// Token: 0x04000241 RID: 577
		private int _count;

		// Token: 0x04000242 RID: 578
		private int _initialCount;

		// Token: 0x04000243 RID: 579
		private int _offset;
	}
}
