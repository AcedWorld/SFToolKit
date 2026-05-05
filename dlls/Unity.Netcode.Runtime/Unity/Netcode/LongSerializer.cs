using System;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000C2 RID: 194
	internal class LongSerializer : INetworkVariableSerializer<long>
	{
		// Token: 0x0600047F RID: 1151 RVA: 0x00014782 File Offset: 0x00012982
		public void Write(FastBufferWriter writer, ref long value)
		{
			BytePacker.WriteValueBitPacked(writer, value);
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0001478C File Offset: 0x0001298C
		public void Read(FastBufferReader reader, ref long value)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out value);
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00014795 File Offset: 0x00012995
		public void WriteDelta(FastBufferWriter writer, ref long value, ref long previousValue)
		{
			this.Write(writer, ref value);
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0001479F File Offset: 0x0001299F
		public void ReadDelta(FastBufferReader reader, ref long value)
		{
			this.Read(reader, ref value);
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0000FE91 File Offset: 0x0000E091
		void INetworkVariableSerializer<long>.ReadWithAllocator(FastBufferReader reader, out long value, Allocator allocator)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x000147A9 File Offset: 0x000129A9
		public void Duplicate(in long value, ref long duplicatedValue)
		{
			duplicatedValue = value;
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x000147AF File Offset: 0x000129AF
		void INetworkVariableSerializer<long>.Duplicate(in long value, ref long duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
