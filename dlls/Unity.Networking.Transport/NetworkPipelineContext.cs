using System;

namespace Unity.Networking.Transport
{
	// Token: 0x02000049 RID: 73
	public struct NetworkPipelineContext
	{
		// Token: 0x040000F9 RID: 249
		public unsafe byte* staticInstanceBuffer;

		// Token: 0x040000FA RID: 250
		public unsafe byte* internalSharedProcessBuffer;

		// Token: 0x040000FB RID: 251
		public unsafe byte* internalProcessBuffer;

		// Token: 0x040000FC RID: 252
		public DataStreamWriter header;

		// Token: 0x040000FD RID: 253
		public long timestamp;

		// Token: 0x040000FE RID: 254
		public int staticInstanceBufferLength;

		// Token: 0x040000FF RID: 255
		public int internalSharedProcessBufferLength;

		// Token: 0x04000100 RID: 256
		public int internalProcessBufferLength;

		// Token: 0x04000101 RID: 257
		public int accumulatedHeaderCapacity;
	}
}
