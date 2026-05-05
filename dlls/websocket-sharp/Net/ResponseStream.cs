using System;
using System.IO;
using System.Text;

namespace WebSocketSharp.Net
{
	// Token: 0x02000029 RID: 41
	internal class ResponseStream : Stream
	{
		// Token: 0x0600032B RID: 811 RVA: 0x0001524C File Offset: 0x0001344C
		internal ResponseStream(Stream innerStream, HttpListenerResponse response, bool ignoreWriteExceptions)
		{
			this._innerStream = innerStream;
			this._response = response;
			if (ignoreWriteExceptions)
			{
				this._write = new Action<byte[], int, int>(this.writeWithoutThrowingException);
				this._writeChunked = new Action<byte[], int, int>(this.writeChunkedWithoutThrowingException);
			}
			else
			{
				this._write = new Action<byte[], int, int>(innerStream.Write);
				this._writeChunked = new Action<byte[], int, int>(this.writeChunked);
			}
			this._bodyBuffer = new MemoryStream();
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600032C RID: 812 RVA: 0x000152D0 File Offset: 0x000134D0
		public override bool CanRead
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600032D RID: 813 RVA: 0x000152E4 File Offset: 0x000134E4
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600032E RID: 814 RVA: 0x000152F8 File Offset: 0x000134F8
		public override bool CanWrite
		{
			get
			{
				return !this._disposed;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600032F RID: 815 RVA: 0x0000F9A2 File Offset: 0x0000DBA2
		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000330 RID: 816 RVA: 0x0000F9A2 File Offset: 0x0000DBA2
		// (set) Token: 0x06000331 RID: 817 RVA: 0x0000F9A2 File Offset: 0x0000DBA2
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

		// Token: 0x06000332 RID: 818 RVA: 0x00015314 File Offset: 0x00013514
		private bool flush(bool closing)
		{
			bool flag = !this._response.HeadersSent;
			if (flag)
			{
				bool flag2 = !this.flushHeaders();
				if (flag2)
				{
					return false;
				}
				this._response.HeadersSent = true;
				this._sendChunked = this._response.SendChunked;
				this._writeBody = (this._sendChunked ? this._writeChunked : this._write);
			}
			this.flushBody(closing);
			return true;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00015390 File Offset: 0x00013590
		private void flushBody(bool closing)
		{
			using (this._bodyBuffer)
			{
				long length = this._bodyBuffer.Length;
				bool flag = length > 2147483647L;
				if (flag)
				{
					this._bodyBuffer.Position = 0L;
					int num = 1024;
					byte[] array = new byte[num];
					for (;;)
					{
						int num2 = this._bodyBuffer.Read(array, 0, num);
						bool flag2 = num2 <= 0;
						if (flag2)
						{
							break;
						}
						this._writeBody(array, 0, num2);
					}
				}
				else
				{
					bool flag3 = length > 0L;
					if (flag3)
					{
						this._writeBody(this._bodyBuffer.GetBuffer(), 0, (int)length);
					}
				}
			}
			bool flag4 = !closing;
			if (flag4)
			{
				this._bodyBuffer = new MemoryStream();
			}
			else
			{
				bool sendChunked = this._sendChunked;
				if (sendChunked)
				{
					this._write(ResponseStream._lastChunk, 0, 5);
				}
				this._bodyBuffer = null;
			}
		}

		// Token: 0x06000334 RID: 820 RVA: 0x000154A0 File Offset: 0x000136A0
		private bool flushHeaders()
		{
			bool flag = !this._response.SendChunked;
			if (flag)
			{
				bool flag2 = this._response.ContentLength64 != this._bodyBuffer.Length;
				if (flag2)
				{
					return false;
				}
			}
			string statusLine = this._response.StatusLine;
			WebHeaderCollection fullHeaders = this._response.FullHeaders;
			MemoryStream memoryStream = new MemoryStream();
			Encoding utf = Encoding.UTF8;
			using (StreamWriter streamWriter = new StreamWriter(memoryStream, utf, 256))
			{
				streamWriter.Write(statusLine);
				streamWriter.Write(fullHeaders.ToStringMultiValue(true));
				streamWriter.Flush();
				int num = utf.GetPreamble().Length;
				long num2 = memoryStream.Length - (long)num;
				bool flag3 = num2 > (long)ResponseStream._maxHeadersLength;
				if (flag3)
				{
					return false;
				}
				this._write(memoryStream.GetBuffer(), num, (int)num2);
			}
			this._response.CloseConnection = (fullHeaders["Connection"] == "close");
			return true;
		}

		// Token: 0x06000335 RID: 821 RVA: 0x000155CC File Offset: 0x000137CC
		private static byte[] getChunkSizeBytes(int size)
		{
			string s = string.Format("{0:x}\r\n", size);
			return Encoding.ASCII.GetBytes(s);
		}

		// Token: 0x06000336 RID: 822 RVA: 0x000155FC File Offset: 0x000137FC
		private void writeChunked(byte[] buffer, int offset, int count)
		{
			byte[] chunkSizeBytes = ResponseStream.getChunkSizeBytes(count);
			this._innerStream.Write(chunkSizeBytes, 0, chunkSizeBytes.Length);
			this._innerStream.Write(buffer, offset, count);
			this._innerStream.Write(ResponseStream._crlf, 0, 2);
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00015644 File Offset: 0x00013844
		private void writeChunkedWithoutThrowingException(byte[] buffer, int offset, int count)
		{
			try
			{
				this.writeChunked(buffer, offset, count);
			}
			catch
			{
			}
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00015678 File Offset: 0x00013878
		private void writeWithoutThrowingException(byte[] buffer, int offset, int count)
		{
			try
			{
				this._innerStream.Write(buffer, offset, count);
			}
			catch
			{
			}
		}

		// Token: 0x06000339 RID: 825 RVA: 0x000156B0 File Offset: 0x000138B0
		internal void Close(bool force)
		{
			bool disposed = this._disposed;
			if (!disposed)
			{
				this._disposed = true;
				bool flag = !force;
				if (flag)
				{
					bool flag2 = this.flush(true);
					if (flag2)
					{
						this._response.Close();
						this._response = null;
						this._innerStream = null;
						return;
					}
					this._response.CloseConnection = true;
				}
				bool sendChunked = this._sendChunked;
				if (sendChunked)
				{
					this._write(ResponseStream._lastChunk, 0, 5);
				}
				this._bodyBuffer.Dispose();
				this._response.Abort();
				this._bodyBuffer = null;
				this._response = null;
				this._innerStream = null;
			}
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0001575D File Offset: 0x0001395D
		internal void InternalWrite(byte[] buffer, int offset, int count)
		{
			this._write(buffer, offset, count);
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000F9A2 File Offset: 0x0000DBA2
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00015770 File Offset: 0x00013970
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				string objectName = base.GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			return this._bodyBuffer.BeginWrite(buffer, offset, count, callback, state);
		}

		// Token: 0x0600033D RID: 829 RVA: 0x000157B2 File Offset: 0x000139B2
		public override void Close()
		{
			this.Close(false);
		}

		// Token: 0x0600033E RID: 830 RVA: 0x000157BD File Offset: 0x000139BD
		protected override void Dispose(bool disposing)
		{
			this.Close(!disposing);
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0000F9A2 File Offset: 0x0000DBA2
		public override int EndRead(IAsyncResult asyncResult)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000340 RID: 832 RVA: 0x000157CC File Offset: 0x000139CC
		public override void EndWrite(IAsyncResult asyncResult)
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				string objectName = base.GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			this._bodyBuffer.EndWrite(asyncResult);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00015808 File Offset: 0x00013A08
		public override void Flush()
		{
			bool disposed = this._disposed;
			if (!disposed)
			{
				bool flag = this._sendChunked || this._response.SendChunked;
				bool flag2 = !flag;
				if (!flag2)
				{
					this.flush(false);
				}
			}
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0000F9A2 File Offset: 0x0000DBA2
		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0000F9A2 File Offset: 0x0000DBA2
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0000F9A2 File Offset: 0x0000DBA2
		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0001584C File Offset: 0x00013A4C
		public override void Write(byte[] buffer, int offset, int count)
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				string objectName = base.GetType().ToString();
				throw new ObjectDisposedException(objectName);
			}
			this._bodyBuffer.Write(buffer, offset, count);
		}

		// Token: 0x0400012C RID: 300
		private MemoryStream _bodyBuffer;

		// Token: 0x0400012D RID: 301
		private static readonly byte[] _crlf = new byte[]
		{
			13,
			10
		};

		// Token: 0x0400012E RID: 302
		private bool _disposed;

		// Token: 0x0400012F RID: 303
		private Stream _innerStream;

		// Token: 0x04000130 RID: 304
		private static readonly byte[] _lastChunk = new byte[]
		{
			48,
			13,
			10,
			13,
			10
		};

		// Token: 0x04000131 RID: 305
		private static readonly int _maxHeadersLength = 32768;

		// Token: 0x04000132 RID: 306
		private HttpListenerResponse _response;

		// Token: 0x04000133 RID: 307
		private bool _sendChunked;

		// Token: 0x04000134 RID: 308
		private Action<byte[], int, int> _write;

		// Token: 0x04000135 RID: 309
		private Action<byte[], int, int> _writeBody;

		// Token: 0x04000136 RID: 310
		private Action<byte[], int, int> _writeChunked;
	}
}
