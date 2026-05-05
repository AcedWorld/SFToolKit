using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net
{
	// Token: 0x020006CD RID: 1741
	internal class WebRequestStream : WebConnectionStream
	{
		// Token: 0x0600380C RID: 14348 RVA: 0x000C5478 File Offset: 0x000C3678
		public WebRequestStream(WebConnection connection, WebOperation operation, Stream stream, WebConnectionTunnel tunnel) : base(connection, operation)
		{
			this.InnerStream = stream;
			this.allowBuffering = operation.Request.InternalAllowBuffering;
			this.sendChunked = (operation.Request.SendChunked && operation.WriteBuffer == null);
			if (!this.sendChunked && this.allowBuffering && operation.WriteBuffer == null)
			{
				this.writeBuffer = new MemoryStream();
			}
			this.KeepAlive = base.Request.KeepAlive;
			if (((tunnel != null) ? tunnel.ProxyVersion : null) != null && ((tunnel != null) ? tunnel.ProxyVersion : null) != HttpVersion.Version11)
			{
				this.KeepAlive = 0;
			}
		}

		// Token: 0x17000BBF RID: 3007
		// (get) Token: 0x0600380D RID: 14349 RVA: 0x000C552F File Offset: 0x000C372F
		internal Stream InnerStream { get; }

		// Token: 0x17000BC0 RID: 3008
		// (get) Token: 0x0600380E RID: 14350 RVA: 0x000C5537 File Offset: 0x000C3737
		public bool KeepAlive { get; }

		// Token: 0x17000BC1 RID: 3009
		// (get) Token: 0x0600380F RID: 14351 RVA: 0x00003062 File Offset: 0x00001262
		public override bool CanRead
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000BC2 RID: 3010
		// (get) Token: 0x06003810 RID: 14352 RVA: 0x0000390E File Offset: 0x00001B0E
		public override bool CanWrite
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000BC3 RID: 3011
		// (get) Token: 0x06003811 RID: 14353 RVA: 0x000C553F File Offset: 0x000C373F
		// (set) Token: 0x06003812 RID: 14354 RVA: 0x000C5547 File Offset: 0x000C3747
		internal bool SendChunked
		{
			get
			{
				return this.sendChunked;
			}
			set
			{
				this.sendChunked = value;
			}
		}

		// Token: 0x17000BC4 RID: 3012
		// (get) Token: 0x06003813 RID: 14355 RVA: 0x000C5550 File Offset: 0x000C3750
		internal bool HasWriteBuffer
		{
			get
			{
				return base.Operation.WriteBuffer != null || this.writeBuffer != null;
			}
		}

		// Token: 0x17000BC5 RID: 3013
		// (get) Token: 0x06003814 RID: 14356 RVA: 0x000C556A File Offset: 0x000C376A
		internal int WriteBufferLength
		{
			get
			{
				if (base.Operation.WriteBuffer != null)
				{
					return base.Operation.WriteBuffer.Size;
				}
				if (this.writeBuffer != null)
				{
					return (int)this.writeBuffer.Length;
				}
				return -1;
			}
		}

		// Token: 0x06003815 RID: 14357 RVA: 0x000C55A0 File Offset: 0x000C37A0
		internal BufferOffsetSize GetWriteBuffer()
		{
			if (base.Operation.WriteBuffer != null)
			{
				return base.Operation.WriteBuffer;
			}
			if (this.writeBuffer == null || this.writeBuffer.Length == 0L)
			{
				return null;
			}
			return new BufferOffsetSize(this.writeBuffer.GetBuffer(), 0, (int)this.writeBuffer.Length, false);
		}

		// Token: 0x06003816 RID: 14358 RVA: 0x000C55FC File Offset: 0x000C37FC
		private Task FinishWriting(CancellationToken cancellationToken)
		{
			WebRequestStream.<FinishWriting>d__31 <FinishWriting>d__;
			<FinishWriting>d__.<>4__this = this;
			<FinishWriting>d__.cancellationToken = cancellationToken;
			<FinishWriting>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<FinishWriting>d__.<>1__state = -1;
			<FinishWriting>d__.<>t__builder.Start<WebRequestStream.<FinishWriting>d__31>(ref <FinishWriting>d__);
			return <FinishWriting>d__.<>t__builder.Task;
		}

		// Token: 0x06003817 RID: 14359 RVA: 0x000C5648 File Offset: 0x000C3848
		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int num = buffer.Length;
			if (offset < 0 || num < offset)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0 || num - offset < count)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled(cancellationToken);
			}
			base.Operation.ThrowIfClosedOrDisposed(cancellationToken);
			if (base.Operation.WriteBuffer != null)
			{
				throw new InvalidOperationException();
			}
			WebCompletionSource webCompletionSource = new WebCompletionSource();
			if (Interlocked.CompareExchange<WebCompletionSource>(ref this.pendingWrite, webCompletionSource, null) != null)
			{
				throw new InvalidOperationException(SR.GetString("Cannot re-call BeginGetRequestStream/BeginGetResponse while a previous call is still in progress."));
			}
			return this.WriteAsyncInner(buffer, offset, count, webCompletionSource, cancellationToken);
		}

		// Token: 0x06003818 RID: 14360 RVA: 0x000C56F4 File Offset: 0x000C38F4
		private Task WriteAsyncInner(byte[] buffer, int offset, int size, WebCompletionSource completion, CancellationToken cancellationToken)
		{
			WebRequestStream.<WriteAsyncInner>d__33 <WriteAsyncInner>d__;
			<WriteAsyncInner>d__.<>4__this = this;
			<WriteAsyncInner>d__.buffer = buffer;
			<WriteAsyncInner>d__.offset = offset;
			<WriteAsyncInner>d__.size = size;
			<WriteAsyncInner>d__.completion = completion;
			<WriteAsyncInner>d__.cancellationToken = cancellationToken;
			<WriteAsyncInner>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteAsyncInner>d__.<>1__state = -1;
			<WriteAsyncInner>d__.<>t__builder.Start<WebRequestStream.<WriteAsyncInner>d__33>(ref <WriteAsyncInner>d__);
			return <WriteAsyncInner>d__.<>t__builder.Task;
		}

		// Token: 0x06003819 RID: 14361 RVA: 0x000C5764 File Offset: 0x000C3964
		private Task ProcessWrite(byte[] buffer, int offset, int size, CancellationToken cancellationToken)
		{
			WebRequestStream.<ProcessWrite>d__34 <ProcessWrite>d__;
			<ProcessWrite>d__.<>4__this = this;
			<ProcessWrite>d__.buffer = buffer;
			<ProcessWrite>d__.offset = offset;
			<ProcessWrite>d__.size = size;
			<ProcessWrite>d__.cancellationToken = cancellationToken;
			<ProcessWrite>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<ProcessWrite>d__.<>1__state = -1;
			<ProcessWrite>d__.<>t__builder.Start<WebRequestStream.<ProcessWrite>d__34>(ref <ProcessWrite>d__);
			return <ProcessWrite>d__.<>t__builder.Task;
		}

		// Token: 0x0600381A RID: 14362 RVA: 0x000C57C8 File Offset: 0x000C39C8
		private void CheckWriteOverflow(long contentLength, long totalWritten, long size)
		{
			if (contentLength == -1L)
			{
				return;
			}
			long num = contentLength - totalWritten;
			if (size > num)
			{
				this.KillBuffer();
				this.closed = true;
				ProtocolViolationException ex = new ProtocolViolationException("The number of bytes to be written is greater than the specified ContentLength.");
				base.Operation.CompleteRequestWritten(this, ex);
				throw ex;
			}
		}

		// Token: 0x0600381B RID: 14363 RVA: 0x000C580C File Offset: 0x000C3A0C
		internal Task Initialize(CancellationToken cancellationToken)
		{
			WebRequestStream.<Initialize>d__36 <Initialize>d__;
			<Initialize>d__.<>4__this = this;
			<Initialize>d__.cancellationToken = cancellationToken;
			<Initialize>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Initialize>d__.<>1__state = -1;
			<Initialize>d__.<>t__builder.Start<WebRequestStream.<Initialize>d__36>(ref <Initialize>d__);
			return <Initialize>d__.<>t__builder.Task;
		}

		// Token: 0x0600381C RID: 14364 RVA: 0x000C5858 File Offset: 0x000C3A58
		private Task SetHeadersAsync(bool setInternalLength, CancellationToken cancellationToken)
		{
			WebRequestStream.<SetHeadersAsync>d__37 <SetHeadersAsync>d__;
			<SetHeadersAsync>d__.<>4__this = this;
			<SetHeadersAsync>d__.setInternalLength = setInternalLength;
			<SetHeadersAsync>d__.cancellationToken = cancellationToken;
			<SetHeadersAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SetHeadersAsync>d__.<>1__state = -1;
			<SetHeadersAsync>d__.<>t__builder.Start<WebRequestStream.<SetHeadersAsync>d__37>(ref <SetHeadersAsync>d__);
			return <SetHeadersAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600381D RID: 14365 RVA: 0x000C58AC File Offset: 0x000C3AAC
		internal Task WriteRequestAsync(CancellationToken cancellationToken)
		{
			WebRequestStream.<WriteRequestAsync>d__38 <WriteRequestAsync>d__;
			<WriteRequestAsync>d__.<>4__this = this;
			<WriteRequestAsync>d__.cancellationToken = cancellationToken;
			<WriteRequestAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteRequestAsync>d__.<>1__state = -1;
			<WriteRequestAsync>d__.<>t__builder.Start<WebRequestStream.<WriteRequestAsync>d__38>(ref <WriteRequestAsync>d__);
			return <WriteRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600381E RID: 14366 RVA: 0x000C58F8 File Offset: 0x000C3AF8
		private Task WriteChunkTrailer_inner(CancellationToken cancellationToken)
		{
			WebRequestStream.<WriteChunkTrailer_inner>d__39 <WriteChunkTrailer_inner>d__;
			<WriteChunkTrailer_inner>d__.<>4__this = this;
			<WriteChunkTrailer_inner>d__.cancellationToken = cancellationToken;
			<WriteChunkTrailer_inner>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteChunkTrailer_inner>d__.<>1__state = -1;
			<WriteChunkTrailer_inner>d__.<>t__builder.Start<WebRequestStream.<WriteChunkTrailer_inner>d__39>(ref <WriteChunkTrailer_inner>d__);
			return <WriteChunkTrailer_inner>d__.<>t__builder.Task;
		}

		// Token: 0x0600381F RID: 14367 RVA: 0x000C5944 File Offset: 0x000C3B44
		private Task WriteChunkTrailer()
		{
			WebRequestStream.<WriteChunkTrailer>d__40 <WriteChunkTrailer>d__;
			<WriteChunkTrailer>d__.<>4__this = this;
			<WriteChunkTrailer>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteChunkTrailer>d__.<>1__state = -1;
			<WriteChunkTrailer>d__.<>t__builder.Start<WebRequestStream.<WriteChunkTrailer>d__40>(ref <WriteChunkTrailer>d__);
			return <WriteChunkTrailer>d__.<>t__builder.Task;
		}

		// Token: 0x06003820 RID: 14368 RVA: 0x000C5987 File Offset: 0x000C3B87
		internal void KillBuffer()
		{
			this.writeBuffer = null;
		}

		// Token: 0x06003821 RID: 14369 RVA: 0x000C5990 File Offset: 0x000C3B90
		public override Task<int> ReadAsync(byte[] buffer, int offset, int size, CancellationToken cancellationToken)
		{
			return Task.FromException<int>(new NotSupportedException("The stream does not support reading."));
		}

		// Token: 0x06003822 RID: 14370 RVA: 0x00011ECF File Offset: 0x000100CF
		protected override bool TryReadFromBufferedContent(byte[] buffer, int offset, int count, out int result)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x06003823 RID: 14371 RVA: 0x000C59A4 File Offset: 0x000C3BA4
		protected override void Close_internal(ref bool disposed)
		{
			if (disposed)
			{
				return;
			}
			disposed = true;
			if (this.sendChunked)
			{
				this.WriteChunkTrailer().Wait();
				return;
			}
			if (!this.allowBuffering || this.requestWritten)
			{
				base.Operation.CompleteRequestWritten(this, null);
				return;
			}
			long contentLength = base.Request.ContentLength;
			if (!this.sendChunked && !base.Operation.IsNtlmChallenge && contentLength != -1L && this.totalWritten != contentLength)
			{
				IOException innerException = new IOException("Cannot close the stream until all bytes are written");
				this.closed = true;
				disposed = true;
				WebException ex = new WebException("Request was cancelled.", WebExceptionStatus.RequestCanceled, WebExceptionInternalStatus.RequestFatal, innerException);
				base.Operation.CompleteRequestWritten(this, ex);
				throw ex;
			}
			disposed = true;
			base.Operation.CompleteRequestWritten(this, null);
		}

		// Token: 0x040020CE RID: 8398
		private static byte[] crlf = new byte[]
		{
			13,
			10
		};

		// Token: 0x040020CF RID: 8399
		private MemoryStream writeBuffer;

		// Token: 0x040020D0 RID: 8400
		private bool requestWritten;

		// Token: 0x040020D1 RID: 8401
		private bool allowBuffering;

		// Token: 0x040020D2 RID: 8402
		private bool sendChunked;

		// Token: 0x040020D3 RID: 8403
		private WebCompletionSource pendingWrite;

		// Token: 0x040020D4 RID: 8404
		private long totalWritten;

		// Token: 0x040020D5 RID: 8405
		private byte[] headers;

		// Token: 0x040020D6 RID: 8406
		private bool headersSent;

		// Token: 0x040020D7 RID: 8407
		private int completeRequestWritten;

		// Token: 0x040020D8 RID: 8408
		private int chunkTrailerWritten;

		// Token: 0x040020D9 RID: 8409
		internal readonly string ME;
	}
}
