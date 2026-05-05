using System;
using System.IO;

namespace WebSocketSharp.Net
{
	// Token: 0x02000037 RID: 55
	internal class ChunkedRequestStream : RequestStream
	{
		// Token: 0x060003AC RID: 940 RVA: 0x000170BE File Offset: 0x000152BE
		internal ChunkedRequestStream(Stream stream, byte[] buffer, int offset, int count, HttpListenerContext context) : base(stream, buffer, offset, count, -1L)
		{
			this._context = context;
			this._decoder = new ChunkStream((WebHeaderCollection)context.Request.Headers);
		}

		// Token: 0x060003AD RID: 941 RVA: 0x000170F4 File Offset: 0x000152F4
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
				bool flag = readBufferState.Count == 0 || !this._decoder.WantsMore || num == 0;
				if (flag)
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

		// Token: 0x060003AE RID: 942 RVA: 0x00017230 File Offset: 0x00015430
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				string objectName = base.GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			bool flag = buffer == null;
			if (flag)
			{
				throw new ArgumentNullException("buffer");
			}
			bool flag2 = offset < 0;
			if (flag2)
			{
				string message = "A negative value.";
				throw new ArgumentOutOfRangeException("offset", message);
			}
			bool flag3 = count < 0;
			if (flag3)
			{
				string message2 = "A negative value.";
				throw new ArgumentOutOfRangeException("count", message2);
			}
			int num = buffer.Length;
			bool flag4 = offset + count > num;
			if (flag4)
			{
				string message3 = "The sum of 'offset' and 'count' is greater than the length of 'buffer'.";
				throw new ArgumentException(message3);
			}
			HttpStreamAsyncResult httpStreamAsyncResult = new HttpStreamAsyncResult(callback, state);
			bool noMoreData = this._noMoreData;
			IAsyncResult result;
			if (noMoreData)
			{
				httpStreamAsyncResult.Complete();
				result = httpStreamAsyncResult;
			}
			else
			{
				int num2 = this._decoder.Read(buffer, offset, count);
				offset += num2;
				count -= num2;
				bool flag5 = count == 0;
				if (flag5)
				{
					httpStreamAsyncResult.Count = num2;
					httpStreamAsyncResult.Complete();
					result = httpStreamAsyncResult;
				}
				else
				{
					bool flag6 = !this._decoder.WantsMore;
					if (flag6)
					{
						this._noMoreData = (num2 == 0);
						httpStreamAsyncResult.Count = num2;
						httpStreamAsyncResult.Complete();
						result = httpStreamAsyncResult;
					}
					else
					{
						httpStreamAsyncResult.Buffer = new byte[ChunkedRequestStream._bufferLength];
						httpStreamAsyncResult.Offset = 0;
						httpStreamAsyncResult.Count = ChunkedRequestStream._bufferLength;
						ReadBufferState readBufferState = new ReadBufferState(buffer, offset, count, httpStreamAsyncResult);
						readBufferState.InitialCount += num2;
						base.BeginRead(httpStreamAsyncResult.Buffer, httpStreamAsyncResult.Offset, httpStreamAsyncResult.Count, new AsyncCallback(this.onRead), readBufferState);
						result = httpStreamAsyncResult;
					}
				}
			}
			return result;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x000173D4 File Offset: 0x000155D4
		public override void Close()
		{
			bool disposed = this._disposed;
			if (!disposed)
			{
				this._disposed = true;
				base.Close();
			}
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x000173FC File Offset: 0x000155FC
		public override int EndRead(IAsyncResult asyncResult)
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				string objectName = base.GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			bool flag = asyncResult == null;
			if (flag)
			{
				throw new ArgumentNullException("asyncResult");
			}
			HttpStreamAsyncResult httpStreamAsyncResult = asyncResult as HttpStreamAsyncResult;
			bool flag2 = httpStreamAsyncResult == null;
			if (flag2)
			{
				string message = "A wrong IAsyncResult instance.";
				throw new ArgumentException(message, "asyncResult");
			}
			bool flag3 = !httpStreamAsyncResult.IsCompleted;
			if (flag3)
			{
				httpStreamAsyncResult.AsyncWaitHandle.WaitOne();
			}
			bool hasException = httpStreamAsyncResult.HasException;
			if (hasException)
			{
				string message2 = "The I/O operation has been aborted.";
				throw new HttpListenerException(995, message2);
			}
			return httpStreamAsyncResult.Count;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x000174AC File Offset: 0x000156AC
		public override int Read(byte[] buffer, int offset, int count)
		{
			IAsyncResult asyncResult = this.BeginRead(buffer, offset, count, null, null);
			return this.EndRead(asyncResult);
		}

		// Token: 0x04000190 RID: 400
		private static readonly int _bufferLength = 8192;

		// Token: 0x04000191 RID: 401
		private HttpListenerContext _context;

		// Token: 0x04000192 RID: 402
		private ChunkStream _decoder;

		// Token: 0x04000193 RID: 403
		private bool _disposed;

		// Token: 0x04000194 RID: 404
		private bool _noMoreData;
	}
}
