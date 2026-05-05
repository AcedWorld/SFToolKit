using System;

namespace Unity.Netcode
{
	// Token: 0x0200005D RID: 93
	internal struct AnticipationCounterSyncPingMessage : INetworkMessage
	{
		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600025A RID: 602 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000BF7C File Offset: 0x0000A17C
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			BytePacker.WriteValuePacked(writer, this.Counter);
			writer.WriteValueSafe<double>(this.Time, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000BFAC File Offset: 0x0000A1AC
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			if (!((NetworkManager)context.SystemOwner).IsServer)
			{
				return false;
			}
			ByteUnpacker.ReadValuePacked(reader, out this.Counter);
			reader.ReadValueSafe<double>(out this.Time, default(FastBufferWriter.ForPrimitives));
			return true;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000BFF0 File Offset: 0x0000A1F0
		public void Handle(ref NetworkContext context)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			if (networkManager.IsListening && !networkManager.ShutdownInProgress && networkManager.ConnectedClients.ContainsKey(context.SenderId))
			{
				AnticipationCounterSyncPongMessage anticipationCounterSyncPongMessage = new AnticipationCounterSyncPongMessage
				{
					Counter = this.Counter,
					Time = this.Time
				};
				networkManager.MessageManager.SendMessage<AnticipationCounterSyncPongMessage>(ref anticipationCounterSyncPongMessage, NetworkDelivery.Reliable, context.SenderId);
			}
		}

		// Token: 0x04000133 RID: 307
		public ulong Counter;

		// Token: 0x04000134 RID: 308
		public double Time;
	}
}
