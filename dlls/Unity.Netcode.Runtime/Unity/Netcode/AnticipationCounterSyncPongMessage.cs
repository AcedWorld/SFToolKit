using System;

namespace Unity.Netcode
{
	// Token: 0x0200005E RID: 94
	internal struct AnticipationCounterSyncPongMessage : INetworkMessage
	{
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600025E RID: 606 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000C068 File Offset: 0x0000A268
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			BytePacker.WriteValuePacked(writer, this.Counter);
			writer.WriteValueSafe<double>(this.Time, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000C098 File Offset: 0x0000A298
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			if (!((NetworkManager)context.SystemOwner).IsClient)
			{
				return false;
			}
			ByteUnpacker.ReadValuePacked(reader, out this.Counter);
			reader.ReadValueSafe<double>(out this.Time, default(FastBufferWriter.ForPrimitives));
			return true;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000C0DC File Offset: 0x0000A2DC
		public void Handle(ref NetworkContext context)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			networkManager.AnticipationSystem.LastAnticipationAck = this.Counter;
			networkManager.AnticipationSystem.LastAnticipationAckTime = this.Time;
		}

		// Token: 0x04000135 RID: 309
		public ulong Counter;

		// Token: 0x04000136 RID: 310
		public double Time;
	}
}
