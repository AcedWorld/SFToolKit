using System;

namespace Unity.Netcode
{
	// Token: 0x02000060 RID: 96
	internal struct ClientConnectedMessage : INetworkMessage, INetworkSerializeByMemcpy
	{
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000266 RID: 614 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000C275 File Offset: 0x0000A475
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			BytePacker.WriteValueBitPacked(writer, this.ClientId);
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000C283 File Offset: 0x0000A483
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			if (!((NetworkManager)context.SystemOwner).IsClient)
			{
				return false;
			}
			ByteUnpacker.ReadValueBitPacked(reader, out this.ClientId);
			return true;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000C2A8 File Offset: 0x0000A4A8
		public void Handle(ref NetworkContext context)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			networkManager.ConnectionManager.ConnectedClientIds.Add(this.ClientId);
			if (networkManager.IsConnectedClient)
			{
				networkManager.ConnectionManager.InvokeOnPeerConnectedCallback(this.ClientId);
			}
		}

		// Token: 0x04000139 RID: 313
		public ulong ClientId;
	}
}
