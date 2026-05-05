using System;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000C1 RID: 193
	internal class UintSerializer : INetworkVariableSerializer<uint>
	{
		// Token: 0x06000477 RID: 1143 RVA: 0x0001474B File Offset: 0x0001294B
		public void Write(FastBufferWriter writer, ref uint value)
		{
			BytePacker.WriteValueBitPacked(writer, value);
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00014755 File Offset: 0x00012955
		public void Read(FastBufferReader reader, ref uint value)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out value);
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0001475E File Offset: 0x0001295E
		public void WriteDelta(FastBufferWriter writer, ref uint value, ref uint previousValue)
		{
			this.Write(writer, ref value);
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00014768 File Offset: 0x00012968
		public void ReadDelta(FastBufferReader reader, ref uint value)
		{
			this.Read(reader, ref value);
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0000FE91 File Offset: 0x0000E091
		void INetworkVariableSerializer<uint>.ReadWithAllocator(FastBufferReader reader, out uint value, Allocator allocator)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x00014772 File Offset: 0x00012972
		public void Duplicate(in uint value, ref uint duplicatedValue)
		{
			duplicatedValue = value;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00014778 File Offset: 0x00012978
		void INetworkVariableSerializer<uint>.Duplicate(in uint value, ref uint duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
