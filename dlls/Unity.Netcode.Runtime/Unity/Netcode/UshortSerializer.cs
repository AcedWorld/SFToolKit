using System;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000BF RID: 191
	internal class UshortSerializer : INetworkVariableSerializer<ushort>
	{
		// Token: 0x06000467 RID: 1127 RVA: 0x000146DD File Offset: 0x000128DD
		public void Write(FastBufferWriter writer, ref ushort value)
		{
			BytePacker.WriteValueBitPacked(writer, value);
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x000146E7 File Offset: 0x000128E7
		public void Read(FastBufferReader reader, ref ushort value)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out value);
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x000146F0 File Offset: 0x000128F0
		public void WriteDelta(FastBufferWriter writer, ref ushort value, ref ushort previousValue)
		{
			this.Write(writer, ref value);
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x000146FA File Offset: 0x000128FA
		public void ReadDelta(FastBufferReader reader, ref ushort value)
		{
			this.Read(reader, ref value);
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x0000FE91 File Offset: 0x0000E091
		void INetworkVariableSerializer<ushort>.ReadWithAllocator(FastBufferReader reader, out ushort value, Allocator allocator)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00014704 File Offset: 0x00012904
		public void Duplicate(in ushort value, ref ushort duplicatedValue)
		{
			duplicatedValue = value;
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0001470A File Offset: 0x0001290A
		void INetworkVariableSerializer<ushort>.Duplicate(in ushort value, ref ushort duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
