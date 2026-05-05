using System;

namespace Unity.Networking.Transport
{
	// Token: 0x02000048 RID: 72
	public struct InboundRecvBuffer
	{
		// Token: 0x06000185 RID: 389 RVA: 0x00008A40 File Offset: 0x00006C40
		public InboundRecvBuffer Slice(int offset)
		{
			InboundRecvBuffer result;
			result.buffer = this.buffer + offset;
			result.bufferLength = this.bufferLength - offset;
			return result;
		}

		// Token: 0x040000F7 RID: 247
		public unsafe byte* buffer;

		// Token: 0x040000F8 RID: 248
		public int bufferLength;
	}
}
