using System;

namespace Unity.Netcode
{
	// Token: 0x02000053 RID: 83
	internal struct DisconnectReasonMessage : INetworkMessage
	{
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600023C RID: 572 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0000BEB8 File Offset: 0x0000A0B8
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			string s = this.Reason ?? string.Empty;
			BytePacker.WriteValueBitPacked(writer, this.Version);
			if (writer.TryBeginWrite(FastBufferWriter.GetWriteSize(s, false)))
			{
				writer.WriteValue(s, false);
				return;
			}
			writer.WriteValueSafe(string.Empty, false);
			NetworkLog.LogWarning("Disconnect reason didn't fit. Disconnected without sending a reason. Consider shortening the reason string.");
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0000BF12 File Offset: 0x0000A112
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out receivedMessageVersion);
			reader.ReadValueSafe(out this.Reason, false);
			return true;
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0000BF2B File Offset: 0x0000A12B
		public void Handle(ref NetworkContext context)
		{
			((NetworkManager)context.SystemOwner).ConnectionManager.DisconnectReason = this.Reason;
		}

		// Token: 0x0400012B RID: 299
		public string Reason;
	}
}
