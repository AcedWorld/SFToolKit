using System;

namespace Unity.Netcode
{
	// Token: 0x02000070 RID: 112
	internal struct SceneEventMessage : INetworkMessage
	{
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000E230 File Offset: 0x0000C430
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			this.EventData.Serialize(writer);
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000E23E File Offset: 0x0000C43E
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			this.m_ReceivedData = reader;
			return true;
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000E248 File Offset: 0x0000C448
		public void Handle(ref NetworkContext context)
		{
			((NetworkManager)context.SystemOwner).SceneManager.HandleSceneEvent(context.SenderId, this.m_ReceivedData);
		}

		// Token: 0x04000172 RID: 370
		public SceneEventData EventData;

		// Token: 0x04000173 RID: 371
		private FastBufferReader m_ReceivedData;
	}
}
