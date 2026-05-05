using System;

namespace Unity.Netcode
{
	// Token: 0x02000061 RID: 97
	internal struct ClientDisconnectedMessage : INetworkMessage, INetworkSerializeByMemcpy
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600026A RID: 618 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000C2F0 File Offset: 0x0000A4F0
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			BytePacker.WriteValueBitPacked(writer, this.ClientId);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000C2FE File Offset: 0x0000A4FE
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			if (!((NetworkManager)context.SystemOwner).IsClient)
			{
				return false;
			}
			ByteUnpacker.ReadValueBitPacked(reader, out this.ClientId);
			return true;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000C324 File Offset: 0x0000A524
		public void Handle(ref NetworkContext context)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			networkManager.ConnectionManager.ConnectedClientIds.Remove(this.ClientId);
			if (networkManager.IsConnectedClient)
			{
				networkManager.ConnectionManager.InvokeOnPeerDisconnectedCallback(this.ClientId);
			}
		}

		// Token: 0x0400013A RID: 314
		public ulong ClientId;
	}
}
