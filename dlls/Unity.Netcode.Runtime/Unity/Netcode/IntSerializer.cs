using System;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000C0 RID: 192
	internal class IntSerializer : INetworkVariableSerializer<int>
	{
		// Token: 0x0600046F RID: 1135 RVA: 0x00014714 File Offset: 0x00012914
		public void Write(FastBufferWriter writer, ref int value)
		{
			BytePacker.WriteValueBitPacked(writer, value);
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0001471E File Offset: 0x0001291E
		public void Read(FastBufferReader reader, ref int value)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out value);
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00014727 File Offset: 0x00012927
		public void WriteDelta(FastBufferWriter writer, ref int value, ref int previousValue)
		{
			this.Write(writer, ref value);
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00014731 File Offset: 0x00012931
		public void ReadDelta(FastBufferReader reader, ref int value)
		{
			this.Read(reader, ref value);
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0000FE91 File Offset: 0x0000E091
		void INetworkVariableSerializer<int>.ReadWithAllocator(FastBufferReader reader, out int value, Allocator allocator)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0001473B File Offset: 0x0001293B
		public void Duplicate(in int value, ref int duplicatedValue)
		{
			duplicatedValue = value;
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00014741 File Offset: 0x00012941
		void INetworkVariableSerializer<int>.Duplicate(in int value, ref int duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
