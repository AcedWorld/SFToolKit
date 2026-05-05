using System;

namespace Unity.Networking.Transport
{
	// Token: 0x02000047 RID: 71
	public struct InboundSendBuffer
	{
		// Token: 0x06000184 RID: 388 RVA: 0x00008A15 File Offset: 0x00006C15
		public void SetBufferFrombufferWithHeaders()
		{
			this.buffer = this.bufferWithHeaders + this.headerPadding;
			this.bufferLength = this.bufferWithHeadersLength - this.headerPadding;
		}

		// Token: 0x040000F2 RID: 242
		public unsafe byte* buffer;

		// Token: 0x040000F3 RID: 243
		public unsafe byte* bufferWithHeaders;

		// Token: 0x040000F4 RID: 244
		public int bufferLength;

		// Token: 0x040000F5 RID: 245
		public int bufferWithHeadersLength;

		// Token: 0x040000F6 RID: 246
		public int headerPadding;
	}
}
