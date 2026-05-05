using System;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000BE RID: 190
	internal class ShortSerializer : INetworkVariableSerializer<short>
	{
		// Token: 0x0600045F RID: 1119 RVA: 0x000146A6 File Offset: 0x000128A6
		public void Write(FastBufferWriter writer, ref short value)
		{
			BytePacker.WriteValueBitPacked(writer, value);
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x000146B0 File Offset: 0x000128B0
		public void Read(FastBufferReader reader, ref short value)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out value);
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x000146B9 File Offset: 0x000128B9
		public void WriteDelta(FastBufferWriter writer, ref short value, ref short previousValue)
		{
			this.Write(writer, ref value);
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x000146C3 File Offset: 0x000128C3
		public void ReadDelta(FastBufferReader reader, ref short value)
		{
			this.Read(reader, ref value);
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0000FE91 File Offset: 0x0000E091
		void INetworkVariableSerializer<short>.ReadWithAllocator(FastBufferReader reader, out short value, Allocator allocator)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x000146CD File Offset: 0x000128CD
		public void Duplicate(in short value, ref short duplicatedValue)
		{
			duplicatedValue = value;
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x000146D3 File Offset: 0x000128D3
		void INetworkVariableSerializer<short>.Duplicate(in short value, ref short duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
