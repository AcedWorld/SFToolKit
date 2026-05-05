using System;
using System.IO;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000027 RID: 39
	internal class ChunkedRequestStream : RequestStream
	{
		// Token: 0x060002C0 RID: 704 RVA: 0x0000D370 File Offset: 0x0000B570
		internal ChunkedRequestStream(Stream innerStream, byte[] initialBuffer, int offset, int count, HttpListenerContext context) : base(innerStream, initialBuffer, offset, count, -1L)
		{
			this._context = context;
			this._decoder = new ChunkStream((WebHeaderCollection)context.Request.Headers);
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x0000D3A3 File Offset: 0x0000B5A3
		internal bool HasRemainingBuffer
		{
			get
			{
				return this._decoder.Count + base.Count > 0;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x0000D3BC File Offset: 0x0000B5BC
		internal byte[] RemainingBuffer
		{
			get
			{
				byte[] result;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					int count = this._decoder.Count;
					if (count > 0)
					{
						memoryStream.Write(this._decoder.EndBuffer, this._decoder.Offset, count);
					}
					count = base.Count;
					if (count > 0)
					{
						memoryStream.Write(base.InitialBuffer, base.Offset, count);
					}
					memoryStream.Close();
					result = memoryStream.ToArray();
				}
				return result;
			}
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000D444 File Offset: 0x0000B644
		private void onRead(IAsyncResult asyncResult)
		{
			ReadBufferState readBufferState = (ReadBufferState)asyncResult.AsyncState;
			HttpStreamAsyncResult asyncResult2 = readBufferState.AsyncResult;
			try
			{
				int num = base.EndRead(asyncResult);
				this._decoder.Write(asyncResult2.Buffer, asyncResult2.Offset, num);
				num = this._decoder.Read(readBufferState.Buffer, readBufferState.Offset, readBufferState.Count);
				readBufferState.Offset += num;
				readBufferState.Count -= num;
				if (readBufferState.Count == 0 || !this._decoder.WantsMore || num == 0)
				{
					this._noMoreData = (!this._decoder.WantsMore && num == 0);
					asyncResult2.Count = readBufferState.InitialCount - readBufferState.Count;
					asyncResult2.Complete();
				}
				else
				{
					base.BeginRead(asyncResult2.Buffer, asyncResult2.Offset, asyncResult2.Count, new AsyncCallback(this.onRead), readBufferState);
				}
			}
			catch (Exception exception)
			{
				this._context.ErrorMessage = "I/O operation aborted";
				this._context.SendError();
				asyncResult2.Complete(exception);
			}
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000D568 File Offset: 0x0000B768
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
			HttpStreamAsyncResult httpStreamAsyncResult = new HttpStreamAsyncResult(callback, state);
			if (this._noMoreData)
			{
				httpStreamAsyncResult.Complete();
				return httpStreamAsyncResult;
			}
			int num2 = this._decoder.Read(buffer, offset, count);
			offset += num2;
			count -= num2;
			if (count == 0)
			{
				httpStreamAsyncResult.Count = num2;
				httpStreamAsyncResult.Complete();
				return httpStreamAsyncResult;
			}
			if (!this._decoder.WantsMore)
			{
				this._noMoreData = (num2 == 0);
				httpStreamAsyncResult.Count = num2;
				httpStreamAsyncResult.Complete();
				return httpStreamAsyncResult;
			}
			httpStreamAsyncResult.Buffer = new byte[ChunkedRequestStream._bufferLength];
			httpStreamAsyncResult.Offset = 0;
			httpStreamAsyncResult.Count = ChunkedRequestStream._bufferLength;
			ReadBufferState readBufferState = new ReadBufferState(buffer, offset, count, httpStreamAsyncResult);
			readBufferState.InitialCount += num2;
			base.BeginRead(httpStreamAsyncResult.Buffer, httpStreamAsyncResult.Offset, httpStreamAsyncResult.Count, new AsyncCallback(this.onRead), readBufferState);
			return httpStreamAsyncResult;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000D6AD File Offset: 0x0000B8AD
		public override void Close()
		{
			if (this._disposed)
			{
				return;
			}
			base.Close();
			this._disposed = true;
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000D6C8 File Offset: 0x0000B8C8
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
			HttpStreamAsyncResult httpStreamAsyncResult = asyncResult as HttpStreamAsyncResult;
			if (httpStreamAsyncResult == null)
			{
				throw new ArgumentException("A wrong IAsyncResult instance.", "asyncResult");
			}
			if (!httpStreamAsyncResult.IsCompleted)
			{
				httpStreamAsyncResult.AsyncWaitHandle.WaitOne();
			}
			if (httpStreamAsyncResult.HasException)
			{
				string message = "The I/O operation has been aborted.";
				throw new HttpListenerException(995, message);
			}
			return httpStreamAsyncResult.Count;
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000D74C File Offset: 0x0000B94C
		public override int Read(byte[] buffer, int offset, int count)
		{
			IAsyncResult asyncResult = this.BeginRead(buffer, offset, count, null, null);
			return this.EndRead(asyncResult);
		}

		// Token: 0x040000F3 RID: 243
		private static readonly int _bufferLength = 8192;

		// Token: 0x040000F4 RID: 244
		private HttpListenerContext _context;

		// Token: 0x040000F5 RID: 245
		private ChunkStream _decoder;

		// Token: 0x040000F6 RID: 246
		private bool _disposed;

		// Token: 0x040000F7 RID: 247
		private bool _noMoreData;
	}
}
