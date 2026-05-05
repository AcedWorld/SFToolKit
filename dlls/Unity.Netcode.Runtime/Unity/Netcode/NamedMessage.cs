using System;

namespace Unity.Netcode
{
	// Token: 0x02000067 RID: 103
	internal struct NamedMessage : INetworkMessage
	{
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000281 RID: 641 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000CDFC File Offset: 0x0000AFFC
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			writer.WriteValueSafe<ulong>(this.Hash, default(FastBufferWriter.ForPrimitives));
			writer.WriteBytesSafe(this.SendData.GetUnsafePtr(), this.SendData.Length, 0);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000CE40 File Offset: 0x0000B040
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			reader.ReadValueSafe<ulong>(out this.Hash, default(FastBufferWriter.ForPrimitives));
			this.m_ReceiveData = reader;
			return true;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000CE6C File Offset: 0x0000B06C
		public void Handle(ref NetworkContext context)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			if (!networkManager.ShutdownInProgress && networkManager.CustomMessagingManager != null)
			{
				networkManager.CustomMessagingManager.InvokeNamedMessage(this.Hash, context.SenderId, this.m_ReceiveData, context.SerializedHeaderSize);
			}
		}

		// Token: 0x0400014C RID: 332
		public ulong Hash;

		// Token: 0x0400014D RID: 333
		public FastBufferWriter SendData;

		// Token: 0x0400014E RID: 334
		private FastBufferReader m_ReceiveData;
	}
}
