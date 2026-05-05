using System;
using System.IO;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000048 RID: 72
	internal class RequestStream : Stream
	{
		// Token: 0x060004A7 RID: 1191 RVA: 0x000158F0 File Offset: 0x00013AF0
		internal RequestStream(Stream innerStream, byte[] initialBuffer, int offset, int count, long contentLength)
		{
			this._innerStream = innerStream;
			this._initialBuffer = initialBuffer;
			this._offset = offset;
			this._count = count;
			this._bodyLeft = contentLength;
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x0001591D File Offset: 0x00013B1D
		internal int Count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060004A9 RID: 1193 RVA: 0x00015925 File Offset: 0x00013B25
		internal byte[] InitialBuffer
		{
			get
			{
				return this._initialBuffer;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x0001592D File Offset: 0x00013B2D
		internal int Offset
		{
			get
			{
				return this._offset;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x00015935 File Offset: 0x00013B35
		public override bool CanRead
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x00015938 File Offset: 0x00013B38
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x0001593B File Offset: 0x00013B3B
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x0001593E File Offset: 0x00013B3E
		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060004AF RID: 1199 RVA: 0x00015945 File Offset: 0x00013B45
		// (set) Token: 0x060004B0 RID: 1200 RVA: 0x0001594C File Offset: 0x00013B4C
		public override long Position
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00015954 File Offset: 0x00013B54
		private int fillFromInitialBuffer(byte[] buffer, int offset, int count)
		{
			if (this._bodyLeft == 0L)
			{
				return -1;
			}
			if (this._count == 0)
			{
				return 0;
			}
			if (count > this._count)
			{
				count = this._count;
			}
			if (this._bodyLeft > 0L && this._bodyLeft < (long)count)
			{
				count = (int)this._bodyLeft;
			}
			Buffer.BlockCopy(this._initialBuffer, this._offset, buffer, offset, count);
			this._offset += count;
			this._count -= count;
			if (this._bodyLeft > 0L)
			{
				this._bodyLeft -= (long)count;
			}
			return count;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x000159F0 File Offset: 0x00013BF0
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException(base.GetType().ToString());
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				string message = "A negative value.";
				throw new ArgumentOutOfRangeException("offset", message);
			}
			if (count < 0)
			{
				string message2 = "A negative value.";
				throw new ArgumentOutOfRangeException("count", message2);
			}
			int num = buffer.Length;
			if (offset + count > num)
			{
				throw new ArgumentException("The sum of 'offset' and 'count' is greater than the length of 'buffer'.");
			}
			if (count == 0)
			{
				return this._innerStream.BeginRead(buffer, offset, 0, callback, state);
			}
			int num2 = this.fillFromInitialBuffer(buffer, offset, count);
			if (num2 != 0)
			{
				HttpStreamAsyncResult httpStreamAsyncResult = new HttpStreamAsyncResult(callback, state);
				httpStreamAsyncResult.Buffer = buffer;
				httpStreamAsyncResult.Offset = offset;
				httpStreamAsyncResult.Count = count;
				httpStreamAsyncResult.SyncRead = ((num2 > 0) ? num2 : 0);
				httpStreamAsyncResult.Complete();
				return httpStreamAsyncResult;
			}
			if (this._bodyLeft > 0L && this._bodyLeft < (long)count)
			{
				count = (int)this._bodyLeft;
			}
			return this._innerStream.BeginRead(buffer, offset, count, callback, state);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00015AEA File Offset: 0x00013CEA
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00015AF1 File Offset: 0x00013CF1
		public override void Close()
		{
			this._disposed = true;
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00015AFC File Offset: 0x00013CFC
		public override int EndRead(IAsyncResult asyncResult)
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException(base.GetType().ToString());
			}
			if (asyncResult == null)
			{
				throw new ArgumentNullException("asyncResult");
			}
			if (asyncResult is HttpStreamAsyncResult)
			{
				HttpStreamAsyncResult httpStreamAsyncResult = (HttpStreamAsyncResult)asyncResult;
				if (!httpStreamAsyncResult.IsCompleted)
				{
					httpStreamAsyncResult.AsyncWaitHandle.WaitOne();
				}
				return httpStreamAsyncResult.SyncRead;
			}
			int num = this._innerStream.EndRead(asyncResult);
			if (num > 0 && this._bodyLeft > 0L)
			{
				this._bodyLeft -= (long)num;
			}
			return num;
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00015B85 File Offset: 0x00013D85
		public override void EndWrite(IAsyncResult asyncResult)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00015B8C File Offset: 0x00013D8C
		public override void Flush()
		{
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00015B90 File Offset: 0x00013D90
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException(base.GetType().ToString());
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				string message = "A negative value.";
				throw new ArgumentOutOfRangeException("offset", message);
			}
			if (count < 0)
			{
				string message2 = "A negative value.";
				throw new ArgumentOutOfRangeException("count", message2);
			}
			int num = buffer.Length;
			if (offset + count > num)
			{
				throw new ArgumentException("The sum of 'offset' and 'count' is greater than the length of 'buffer'.");
			}
			if (count == 0)
			{
				return 0;
			}
			int num2 = this.fillFromInitialBuffer(buffer, offset, count);
			if (num2 == -1)
			{
				return 0;
			}
			if (num2 > 0)
			{
				return num2;
			}
			if (this._bodyLeft > 0L && this._bodyLeft < (long)count)
			{
				count = (int)this._bodyLeft;
			}
			num2 = this._innerStream.Read(buffer, offset, count);
			if (num2 > 0 && this._bodyLeft > 0L)
			{
				this._bodyLeft -= (long)num2;
			}
			return num2;
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00015C6A File Offset: 0x00013E6A
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x00015C71 File Offset: 0x00013E71
		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x00015C78 File Offset: 0x00013E78
		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		// Token: 0x04000244 RID: 580
		private long _bodyLeft;

		// Token: 0x04000245 RID: 581
		private int _count;

		// Token: 0x04000246 RID: 582
		private bool _disposed;

		// Token: 0x04000247 RID: 583
		private byte[] _initialBuffer;

		// Token: 0x04000248 RID: 584
		private Stream _innerStream;

		// Token: 0x04000249 RID: 585
		private int _offset;
	}
}
