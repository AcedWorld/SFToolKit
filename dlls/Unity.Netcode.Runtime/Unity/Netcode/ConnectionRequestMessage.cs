using System;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x02000063 RID: 99
	internal struct ConnectionRequestMessage : INetworkMessage
	{
		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000272 RID: 626 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000C844 File Offset: 0x0000AA44
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			BytePacker.WriteValueBitPacked(writer, this.MessageVersions.Length);
			foreach (MessageVersionData messageVersionData in this.MessageVersions)
			{
				messageVersionData.Serialize(writer);
			}
			if (this.ShouldSendConnectionData)
			{
				writer.WriteValueSafe<ulong>(this.ConfigHash, default(FastBufferWriter.ForPrimitives));
				writer.WriteValueSafe<byte>(this.ConnectionData, default(FastBufferWriter.ForPrimitives));
				return;
			}
			writer.WriteValueSafe<ulong>(this.ConfigHash, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000C8F4 File Offset: 0x0000AAF4
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			if (!networkManager.IsServer)
			{
				return false;
			}
			int num;
			ByteUnpacker.ReadValueBitPacked(reader, out num);
			for (int i = 0; i < num; i++)
			{
				MessageVersionData messageVersionData = default(MessageVersionData);
				messageVersionData.Deserialize(reader);
				networkManager.ConnectionManager.MessageManager.SetVersion(context.SenderId, messageVersionData.Hash, messageVersionData.Version);
				if (networkManager.ConnectionManager.MessageManager.GetMessageForHash(messageVersionData.Hash) == typeof(ConnectionRequestMessage))
				{
					receivedMessageVersion = messageVersionData.Version;
				}
			}
			if (networkManager.NetworkConfig.ConnectionApproval)
			{
				if (!reader.TryBeginRead(FastBufferWriter.GetWriteSize<ulong>(this.ConfigHash, default(FastBufferWriter.ForStructs)) + FastBufferWriter.GetWriteSize<int>()))
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("Incomplete connection request message given config - possible NetworkConfig mismatch.");
					}
					networkManager.DisconnectClient(context.SenderId);
					return false;
				}
				reader.ReadValue<ulong>(out this.ConfigHash, default(FastBufferWriter.ForPrimitives));
				if (!networkManager.NetworkConfig.CompareConfig(this.ConfigHash))
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("NetworkConfig mismatch. The configuration between the server and client does not match");
					}
					networkManager.DisconnectClient(context.SenderId);
					return false;
				}
				reader.ReadValueSafe<byte>(out this.ConnectionData, default(FastBufferWriter.ForPrimitives));
			}
			else
			{
				if (!reader.TryBeginRead(FastBufferWriter.GetWriteSize<ulong>(this.ConfigHash, default(FastBufferWriter.ForStructs))))
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("Incomplete connection request message.");
					}
					networkManager.DisconnectClient(context.SenderId);
					return false;
				}
				reader.ReadValue<ulong>(out this.ConfigHash, default(FastBufferWriter.ForPrimitives));
				if (!networkManager.NetworkConfig.CompareConfig(this.ConfigHash))
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("NetworkConfig mismatch. The configuration between the server and client does not match");
					}
					networkManager.DisconnectClient(context.SenderId);
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000CAD0 File Offset: 0x0000ACD0
		public void Handle(ref NetworkContext context)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			ulong senderId = context.SenderId;
			PendingClient pendingClient;
			if (networkManager.ConnectionManager.PendingClients.TryGetValue(senderId, out pendingClient))
			{
				pendingClient.ConnectionState = PendingClient.State.PendingApproval;
			}
			if (networkManager.NetworkConfig.ConnectionApproval)
			{
				ConnectionRequestMessage connectionRequestMessage = this;
				networkManager.ConnectionManager.ApproveConnection(ref connectionRequestMessage, ref context);
				return;
			}
			NetworkManager.ConnectionApprovalResponse response = new NetworkManager.ConnectionApprovalResponse
			{
				Approved = true,
				CreatePlayerObject = (networkManager.NetworkConfig.PlayerPrefab != null)
			};
			networkManager.ConnectionManager.HandleConnectionApproval(senderId, response);
		}

		// Token: 0x04000142 RID: 322
		public ulong ConfigHash;

		// Token: 0x04000143 RID: 323
		public byte[] ConnectionData;

		// Token: 0x04000144 RID: 324
		public bool ShouldSendConnectionData;

		// Token: 0x04000145 RID: 325
		public NativeArray<MessageVersionData> MessageVersions;
	}
}
