using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net
{
	// Token: 0x020006A5 RID: 1701
	internal class MonoChunkStream : WebReadStream
	{
		// Token: 0x17000B45 RID: 2885
		// (get) Token: 0x06003674 RID: 13940 RVA: 0x000BF2C1 File Offset: 0x000BD4C1
		protected WebHeaderCollection Headers { get; }

		// Token: 0x17000B46 RID: 2886
		// (get) Token: 0x06003675 RID: 13941 RVA: 0x000BF2C9 File Offset: 0x000BD4C9
		protected MonoChunkParser Decoder { get; }

		// Token: 0x06003676 RID: 13942 RVA: 0x000BF2D1 File Offset: 0x000BD4D1
		public MonoChunkStream(WebOperation operation, Stream innerStream, WebHeaderCollection headers) : base(operation, innerStream)
		{
			this.Headers = headers;
			this.Decoder = new MonoChunkParser(headers);
		}

		// Token: 0x06003677 RID: 13943 RVA: 0x000BF2F0 File Offset: 0x000BD4F0
		protected override Task<int> ProcessReadAsync(byte[] buffer, int offset, int size, CancellationToken cancellationToken)
		{
			MonoChunkStream.<ProcessReadAsync>d__7 <ProcessReadAsync>d__;
			<ProcessReadAsync>d__.<>4__this = this;
			<ProcessReadAsync>d__.buffer = buffer;
			<ProcessReadAsync>d__.offset = offset;
			<ProcessReadAsync>d__.size = size;
			<ProcessReadAsync>d__.cancellationToken = cancellationToken;
			<ProcessReadAsync>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<ProcessReadAsync>d__.<>1__state = -1;
			<ProcessReadAsync>d__.<>t__builder.Start<MonoChunkStream.<ProcessReadAsync>d__7>(ref <ProcessReadAsync>d__);
			return <ProcessReadAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06003678 RID: 13944 RVA: 0x000BF354 File Offset: 0x000BD554
		internal override Task FinishReading(CancellationToken cancellationToken)
		{
			MonoChunkStream.<FinishReading>d__8 <FinishReading>d__;
			<FinishReading>d__.<>4__this = this;
			<FinishReading>d__.cancellationToken = cancellationToken;
			<FinishReading>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<FinishReading>d__.<>1__state = -1;
			<FinishReading>d__.<>t__builder.Start<MonoChunkStream.<FinishReading>d__8>(ref <FinishReading>d__);
			return <FinishReading>d__.<>t__builder.Task;
		}

		// Token: 0x06003679 RID: 13945 RVA: 0x000BF39F File Offset: 0x000BD59F
		private static void ThrowExpectingChunkTrailer()
		{
			throw new WebException("Expecting chunk trailer.", null, WebExceptionStatus.ServerProtocolViolation, null);
		}
	}
}
