using System;

namespace Unity.Netcode
{
	// Token: 0x02000071 RID: 113
	internal struct ServerLogMessage : INetworkMessage
	{
		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060002AB RID: 683 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000E26C File Offset: 0x0000C46C
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			writer.WriteValueSafe<NetworkLog.LogType>(this.LogType, default(FastBufferWriter.ForEnums));
			BytePacker.WriteValuePacked(writer, this.Message);
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000E29C File Offset: 0x0000C49C
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			if (networkManager.IsServer && networkManager.NetworkConfig.EnableNetworkLogs)
			{
				reader.ReadValueSafe<NetworkLog.LogType>(out this.LogType, default(FastBufferWriter.ForEnums));
				ByteUnpacker.ReadValuePacked(reader, out this.Message);
				return true;
			}
			return false;
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000E2F0 File Offset: 0x0000C4F0
		public void Handle(ref NetworkContext context)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			ulong senderId = context.SenderId;
			networkManager.NetworkMetrics.TrackServerLogReceived(senderId, (uint)this.LogType, (long)((ulong)context.MessageSize));
			switch (this.LogType)
			{
			case NetworkLog.LogType.Info:
				NetworkLog.LogInfoServerLocal(this.Message, senderId);
				return;
			case NetworkLog.LogType.Warning:
				NetworkLog.LogWarningServerLocal(this.Message, senderId);
				return;
			case NetworkLog.LogType.Error:
				NetworkLog.LogErrorServerLocal(this.Message, senderId);
				return;
			default:
				return;
			}
		}

		// Token: 0x04000174 RID: 372
		public NetworkLog.LogType LogType;

		// Token: 0x04000175 RID: 373
		public string Message;
	}
}
