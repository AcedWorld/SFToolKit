using System;
using System.IO;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000049 RID: 73
	internal class ResponseStream : Stream
	{
		// Token: 0x060004BD RID: 1213 RVA: 0x00015CB8 File Offset: 0x00013EB8
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

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x00015D32 File Offset: 0x00013F32
		public override bool CanRead
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060004BF RID: 1215 RVA: 0x00015D35 File Offset: 0x00013F35
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x00015D38 File Offset: 0x00013F38
		public override bool CanWrite
		{
			get
			{
				return !this._disposed;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x00015D43 File Offset: 0x00013F43
		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060004C2 RID: 1218 RVA: 0x00015D4A File Offset: 0x00013F4A
		// (set) Token: 0x060004C3 RID: 1219 RVA: 0x00015D51 File Offset: 0x00013F51
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

		// Token: 0x060004C4 RID: 1220 RVA: 0x00015D58 File Offset: 0x00013F58
		private bool flush(bool closing)
		{
			if (!this._response.HeadersSent)
			{
				if (!this.flushHeaders())
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

		// Token: 0x060004C5 RID: 1221 RVA: 0x00015DC0 File Offset: 0x00013FC0
		private void flushBody(bool closing)
		{
			using (this._bodyBuffer)
			{
				long length = this._bodyBuffer.Length;
				if (length > 2147483647L)
				{
					this._bodyBuffer.Position = 0L;
					int num = 1024;
					byte[] array = new byte[num];
					for (;;)
					{
						int num2 = this._bodyBuffer.Read(array, 0, num);
						if (num2 <= 0)
						{
							break;
						}
						this._writeBody(array, 0, num2);
					}
				}
				else if (length > 0L)
				{
					this._writeBody(this._bodyBuffer.GetBuffer(), 0, (int)length);
				}
			}
			if (!closing)
			{
				this._bodyBuffer = new MemoryStream();
				return;
			}
			if (this._sendChunked)
			{
				this._write(ResponseStream._lastChunk, 0, 5);
			}
			this._bodyBuffer = null;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00015E98 File Offset: 0x00014098
		private bool flushHeaders()
		{
			if (!this._response.SendChunked && this._response.ContentLength64 != this._bodyBuffer.Length)
			{
				return false;
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
				if (num2 > (long)ResponseStream._maxHeadersLength)
				{
					return false;
				}
				this._write(memoryStream.GetBuffer(), num, (int)num2);
			}
			this._response.CloseConnection = (fullHeaders["Connection"] == "close");
			return true;
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x00015F98 File Offset: 0x00014198
		private static byte[] getChunkSizeBytes(int size)
		{
			string s = string.Format("{0:x}\r\n", size);
			return Encoding.ASCII.GetBytes(s);
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00015FC4 File Offset: 0x000141C4
		private void writeChunked(byte[] buffer, int offset, int count)
		{
			byte[] chunkSizeBytes = ResponseStream.getChunkSizeBytes(count);
			this._innerStream.Write(chunkSizeBytes, 0, chunkSizeBytes.Length);
			this._innerStream.Write(buffer, offset, count);
			this._innerStream.Write(ResponseStream._crlf, 0, 2);
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00016008 File Offset: 0x00014208
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

		// Token: 0x060004CA RID: 1226 RVA: 0x00016034 File Offset: 0x00014234
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

		// Token: 0x060004CB RID: 1227 RVA: 0x00016064 File Offset: 0x00014264
		internal void Close(bool force)
		{
			if (this._disposed)
			{
				return;
			}
			this._disposed = true;
			if (!force)
			{
				if (this.flush(true))
				{
					this._response.Close();
					this._response = null;
					this._innerStream = null;
					return;
				}
				this._response.CloseConnection = true;
			}
			if (this._sendChunked)
			{
				this._write(ResponseStream._lastChunk, 0, 5);
			}
			this._bodyBuffer.Dispose();
			this._response.Abort();
			this._bodyBuffer = null;
			this._response = null;
			this._innerStream = null;
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x000160F8 File Offset: 0x000142F8
		internal void InternalWrite(byte[] buffer, int offset, int count)
		{
			this._write(buffer, offset, count);
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00016108 File Offset: 0x00014308
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0001610F File Offset: 0x0001430F
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException(base.GetType().ToString());
			}
			return this._bodyBuffer.BeginWrite(buffer, offset, count, callback, state);
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0001613C File Offset: 0x0001433C
		public override void Close()
		{
			this.Close(false);
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00016145 File Offset: 0x00014345
		protected override void Dispose(bool disposing)
		{
			this.Close(!disposing);
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00016151 File Offset: 0x00014351
		public override int EndRead(IAsyncResult asyncResult)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00016158 File Offset: 0x00014358
		public override void EndWrite(IAsyncResult asyncResult)
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException(base.GetType().ToString());
			}
			this._bodyBuffer.EndWrite(asyncResult);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0001617F File Offset: 0x0001437F
		public override void Flush()
		{
			if (this._disposed)
			{
				return;
			}
			if (!this._sendChunked && !this._response.SendChunked)
			{
				return;
			}
			this.flush(false);
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x000161AB File Offset: 0x000143AB
		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x000161B2 File Offset: 0x000143B2
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x000161B9 File Offset: 0x000143B9
		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x000161C0 File Offset: 0x000143C0
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException(base.GetType().ToString());
			}
			this._bodyBuffer.Write(buffer, offset, count);
		}

		// Token: 0x0400024A RID: 586
		private MemoryStream _bodyBuffer;

		// Token: 0x0400024B RID: 587
		private static readonly byte[] _crlf = new byte[]
		{
			13,
			10
		};

		// Token: 0x0400024C RID: 588
		private bool _disposed;

		// Token: 0x0400024D RID: 589
		private Stream _innerStream;

		// Token: 0x0400024E RID: 590
		private static readonly byte[] _lastChunk = new byte[]
		{
			48,
			13,
			10,
			13,
			10
		};

		// Token: 0x0400024F RID: 591
		private static readonly int _maxHeadersLength = 32768;

		// Token: 0x04000250 RID: 592
		private HttpListenerResponse _response;

		// Token: 0x04000251 RID: 593
		private bool _sendChunked;

		// Token: 0x04000252 RID: 594
		private Action<byte[], int, int> _write;

		// Token: 0x04000253 RID: 595
		private Action<byte[], int, int> _writeBody;

		// Token: 0x04000254 RID: 596
		private Action<byte[], int, int> _writeChunked;
	}
}
