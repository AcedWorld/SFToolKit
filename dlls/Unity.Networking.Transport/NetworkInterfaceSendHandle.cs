using System;

namespace Unity.Networking.Transport
{
	// Token: 0x02000019 RID: 25
	public struct NetworkInterfaceSendHandle
	{
		// Token: 0x04000048 RID: 72
		public IntPtr data;

		// Token: 0x04000049 RID: 73
		public int capacity;

		// Token: 0x0400004A RID: 74
		public int size;

		// Token: 0x0400004B RID: 75
		public int id;

		// Token: 0x0400004C RID: 76
		public SendHandleFlags flags;
	}
}
