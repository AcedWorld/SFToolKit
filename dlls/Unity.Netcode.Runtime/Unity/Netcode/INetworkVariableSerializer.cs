using System;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000BD RID: 189
	internal interface INetworkVariableSerializer<T>
	{
		// Token: 0x06000459 RID: 1113
		void Write(FastBufferWriter writer, ref T value);

		// Token: 0x0600045A RID: 1114
		void Read(FastBufferReader reader, ref T value);

		// Token: 0x0600045B RID: 1115
		void WriteDelta(FastBufferWriter writer, ref T value, ref T previousValue);

		// Token: 0x0600045C RID: 1116
		void ReadDelta(FastBufferReader reader, ref T value);

		// Token: 0x0600045D RID: 1117
		void ReadWithAllocator(FastBufferReader reader, out T value, Allocator allocator);

		// Token: 0x0600045E RID: 1118
		void Duplicate(in T value, ref T duplicatedValue);
	}
}
