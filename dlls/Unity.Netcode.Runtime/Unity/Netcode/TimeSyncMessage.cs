using System;

namespace Unity.Netcode
{
	// Token: 0x02000072 RID: 114
	internal struct TimeSyncMessage : INetworkMessage, INetworkSerializeByMemcpy
	{
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060002AF RID: 687 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000E367 File Offset: 0x0000C567
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			BytePacker.WriteValueBitPacked(writer, this.Tick);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000E375 File Offset: 0x0000C575
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			if (!((NetworkManager)context.SystemOwner).IsClient)
			{
				return false;
			}
			ByteUnpacker.ReadValueBitPacked(reader, out this.Tick);
			return true;
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000E398 File Offset: 0x0000C598
		public void Handle(ref NetworkContext context)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			NetworkTime networkTime = new NetworkTime(networkManager.NetworkTickSystem.TickRate, this.Tick, 0.0);
			networkManager.NetworkTimeSystem.Sync(networkTime.Time, networkManager.NetworkConfig.NetworkTransport.GetCurrentRtt(context.SenderId) / 1000.0);
		}

		// Token: 0x04000176 RID: 374
		public int Tick;
	}
}
