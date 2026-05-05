using System;

namespace Unity.Netcode
{
	// Token: 0x02000073 RID: 115
	internal struct UnnamedMessage : INetworkMessage
	{
		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000E406 File Offset: 0x0000C606
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			writer.WriteBytesSafe(this.SendData.GetUnsafePtr(), this.SendData.Length, 0);
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000E426 File Offset: 0x0000C626
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			this.m_ReceivedData = reader;
			return true;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000E430 File Offset: 0x0000C630
		public void Handle(ref NetworkContext context)
		{
			((NetworkManager)context.SystemOwner).CustomMessagingManager.InvokeUnnamedMessage(context.SenderId, this.m_ReceivedData, context.SerializedHeaderSize);
		}

		// Token: 0x04000177 RID: 375
		public FastBufferWriter SendData;

		// Token: 0x04000178 RID: 376
		private FastBufferReader m_ReceivedData;
	}
}
