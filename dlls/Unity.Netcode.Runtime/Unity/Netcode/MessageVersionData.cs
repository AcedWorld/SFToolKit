using System;

namespace Unity.Netcode
{
	// Token: 0x02000066 RID: 102
	internal struct MessageVersionData
	{
		// Token: 0x0600027F RID: 639 RVA: 0x0000CD9C File Offset: 0x0000AF9C
		public void Serialize(FastBufferWriter writer)
		{
			writer.WriteValueSafe<uint>(this.Hash, default(FastBufferWriter.ForPrimitives));
			BytePacker.WriteValueBitPacked(writer, this.Version);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000CDCC File Offset: 0x0000AFCC
		public void Deserialize(FastBufferReader reader)
		{
			reader.ReadValueSafe<uint>(out this.Hash, default(FastBufferWriter.ForPrimitives));
			ByteUnpacker.ReadValueBitPacked(reader, out this.Version);
		}

		// Token: 0x0400014A RID: 330
		public uint Hash;

		// Token: 0x0400014B RID: 331
		public int Version;
	}
}
