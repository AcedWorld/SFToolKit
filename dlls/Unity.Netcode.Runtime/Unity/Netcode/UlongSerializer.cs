using System;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000C3 RID: 195
	internal class UlongSerializer : INetworkVariableSerializer<ulong>
	{
		// Token: 0x06000487 RID: 1159 RVA: 0x000147B9 File Offset: 0x000129B9
		public void Write(FastBufferWriter writer, ref ulong value)
		{
			BytePacker.WriteValueBitPacked(writer, value);
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x000147C3 File Offset: 0x000129C3
		public void Read(FastBufferReader reader, ref ulong value)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out value);
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x000147CC File Offset: 0x000129CC
		public void WriteDelta(FastBufferWriter writer, ref ulong value, ref ulong previousValue)
		{
			this.Write(writer, ref value);
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x000147D6 File Offset: 0x000129D6
		public void ReadDelta(FastBufferReader reader, ref ulong value)
		{
			this.Read(reader, ref value);
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0000FE91 File Offset: 0x0000E091
		void INetworkVariableSerializer<ulong>.ReadWithAllocator(FastBufferReader reader, out ulong value, Allocator allocator)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x000147A9 File Offset: 0x000129A9
		public void Duplicate(in ulong value, ref ulong duplicatedValue)
		{
			duplicatedValue = value;
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x000147E0 File Offset: 0x000129E0
		void INetworkVariableSerializer<ulong>.Duplicate(in ulong value, ref ulong duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
