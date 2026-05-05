using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net
{
	// Token: 0x02000683 RID: 1667
	internal class FixedSizeReadStream : WebReadStream
	{
		// Token: 0x17000A95 RID: 2709
		// (get) Token: 0x0600348D RID: 13453 RVA: 0x000B79EF File Offset: 0x000B5BEF
		public long ContentLength { get; }

		// Token: 0x0600348E RID: 13454 RVA: 0x000B79F7 File Offset: 0x000B5BF7
		public FixedSizeReadStream(WebOperation operation, Stream innerStream, long contentLength) : base(operation, innerStream)
		{
			this.ContentLength = contentLength;
		}

		// Token: 0x0600348F RID: 13455 RVA: 0x000B7A08 File Offset: 0x000B5C08
		protected override Task<int> ProcessReadAsync(byte[] buffer, int offset, int size, CancellationToken cancellationToken)
		{
			FixedSizeReadStream.<ProcessReadAsync>d__5 <ProcessReadAsync>d__;
			<ProcessReadAsync>d__.<>4__this = this;
			<ProcessReadAsync>d__.buffer = buffer;
			<ProcessReadAsync>d__.offset = offset;
			<ProcessReadAsync>d__.size = size;
			<ProcessReadAsync>d__.cancellationToken = cancellationToken;
			<ProcessReadAsync>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<ProcessReadAsync>d__.<>1__state = -1;
			<ProcessReadAsync>d__.<>t__builder.Start<FixedSizeReadStream.<ProcessReadAsync>d__5>(ref <ProcessReadAsync>d__);
			return <ProcessReadAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04001EA1 RID: 7841
		private long position;
	}
}
