using System;
using System.Runtime.InteropServices;

namespace Unity.Networking.Transport
{
	// Token: 0x0200003C RID: 60
	[StructLayout(LayoutKind.Explicit)]
	public struct NetworkEvent
	{
		// Token: 0x040000CC RID: 204
		[FieldOffset(0)]
		internal NetworkEvent.Type type;

		// Token: 0x040000CD RID: 205
		[FieldOffset(2)]
		internal short pipelineId;

		// Token: 0x040000CE RID: 206
		[FieldOffset(4)]
		internal int connectionId;

		// Token: 0x040000CF RID: 207
		[FieldOffset(8)]
		internal int status;

		// Token: 0x040000D0 RID: 208
		[FieldOffset(8)]
		internal int offset;

		// Token: 0x040000D1 RID: 209
		[FieldOffset(12)]
		internal int size;

		// Token: 0x0200003D RID: 61
		public enum Type : short
		{
			// Token: 0x040000D3 RID: 211
			Empty,
			// Token: 0x040000D4 RID: 212
			Data,
			// Token: 0x040000D5 RID: 213
			Connect,
			// Token: 0x040000D6 RID: 214
			Disconnect
		}
	}
}
