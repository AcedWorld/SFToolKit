using System;
using System.Collections.Generic;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x02000062 RID: 98
	internal struct ConnectionApprovedMessage : INetworkMessage
	{
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600026E RID: 622 RVA: 0x0000C36D File Offset: 0x0000A56D
		public int Version
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000C370 File Offset: 0x0000A570
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			BytePacker.WriteValueBitPacked(writer, this.MessageVersions.Length);
			foreach (MessageVersionData messageVersionData in this.MessageVersions)
			{
				messageVersionData.Serialize(writer);
			}
			BytePacker.WriteValueBitPacked(writer, this.OwnerClientId);
			BytePacker.WriteValueBitPacked(writer, this.NetworkTick);
			if (targetVersion >= 1)
			{
				writer.WriteValueSafe<ulong>(this.ConnectedClientIds, default(FastBufferWriter.ForGeneric));
			}
			uint num = 0U;
			if (this.SpawnedObjectsList != null)
			{
				int position = writer.Position;
				writer.Seek(writer.Position + FastBufferWriter.GetWriteSize<uint>(num, default(FastBufferWriter.ForStructs)));
				foreach (NetworkObject networkObject in this.SpawnedObjectsList)
				{
					if (networkObject.SpawnWithObservers && (networkObject.CheckObjectVisibility == null || networkObject.CheckObjectVisibility(this.OwnerClientId)))
					{
						networkObject.Observers.Add(this.OwnerClientId);
						networkObject.GetMessageSceneObject(this.OwnerClientId).Serialize(writer);
						num += 1U;
					}
				}
				writer.Seek(position);
				writer.WriteValueSafe<uint>(num, default(FastBufferWriter.ForPrimitives));
				writer.Seek(writer.Length);
				return;
			}
			writer.WriteValueSafe<uint>(num, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000C50C File Offset: 0x0000A70C
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			if (!networkManager.IsClient)
			{
				return false;
			}
			int num;
			ByteUnpacker.ReadValueBitPacked(reader, out num);
			NativeArray<uint> serverMessageOrder = new NativeArray<uint>(num, Allocator.Temp, NativeArrayOptions.ClearMemory);
			for (int i = 0; i < num; i++)
			{
				MessageVersionData messageVersionData = default(MessageVersionData);
				messageVersionData.Deserialize(reader);
				networkManager.ConnectionManager.MessageManager.SetVersion(context.SenderId, messageVersionData.Hash, messageVersionData.Version);
				serverMessageOrder[i] = messageVersionData.Hash;
				if (networkManager.ConnectionManager.MessageManager.GetMessageForHash(messageVersionData.Hash) == typeof(ConnectionApprovedMessage))
				{
					receivedMessageVersion = messageVersionData.Version;
				}
			}
			networkManager.ConnectionManager.MessageManager.SetServerMessageOrder(serverMessageOrder);
			serverMessageOrder.Dispose();
			ByteUnpacker.ReadValueBitPacked(reader, out this.OwnerClientId);
			ByteUnpacker.ReadValueBitPacked(reader, out this.NetworkTick);
			if (receivedMessageVersion >= 1)
			{
				reader.ReadValueSafe<ulong>(out this.ConnectedClientIds, Allocator.TempJob, default(FastBufferWriter.ForGeneric));
			}
			else
			{
				this.ConnectedClientIds = new NativeArray<ulong>(0, Allocator.TempJob, NativeArrayOptions.ClearMemory);
			}
			this.m_ReceivedSceneObjectData = reader;
			return true;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000C628 File Offset: 0x0000A828
		public void Handle(ref NetworkContext context)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			networkManager.LocalClientId = this.OwnerClientId;
			networkManager.MessageManager.SetLocalClientId(networkManager.LocalClientId);
			networkManager.NetworkMetrics.SetConnectionId(networkManager.LocalClientId);
			NetworkTime networkTime = new NetworkTime(networkManager.NetworkTickSystem.TickRate, this.NetworkTick, 0.0);
			networkManager.NetworkTimeSystem.Reset(networkTime.Time, 0.15000000596046448);
			networkManager.NetworkTickSystem.Reset(networkManager.NetworkTimeSystem.LocalTime, networkManager.NetworkTimeSystem.ServerTime);
			networkManager.ConnectionManager.LocalClient.SetRole(false, true, networkManager);
			networkManager.ConnectionManager.LocalClient.IsApproved = true;
			networkManager.ConnectionManager.LocalClient.ClientId = this.OwnerClientId;
			networkManager.ConnectionManager.StopClientApprovalCoroutine();
			networkManager.ConnectionManager.ConnectedClientIds.Clear();
			foreach (ulong item in this.ConnectedClientIds)
			{
				networkManager.ConnectionManager.ConnectedClientIds.Add(item);
			}
			if (!networkManager.NetworkConfig.EnableSceneManagement)
			{
				networkManager.SpawnManager.DestroySceneObjects();
				uint num;
				this.m_ReceivedSceneObjectData.ReadValueSafe<uint>(out num, default(FastBufferWriter.ForPrimitives));
				ushort num2 = 0;
				while ((uint)num2 < num)
				{
					NetworkObject.SceneObject sceneObject = default(NetworkObject.SceneObject);
					sceneObject.Deserialize(this.m_ReceivedSceneObjectData);
					NetworkObject.AddSceneObject(sceneObject, this.m_ReceivedSceneObjectData, networkManager);
					num2 += 1;
				}
				networkManager.IsConnectedClient = true;
				networkManager.ConnectionManager.InvokeOnClientConnectedCallback(context.SenderId);
				foreach (NetworkObject networkObject in networkManager.SpawnManager.SpawnedObjectsList)
				{
					networkObject.InternalNetworkSessionSynchronized();
				}
			}
			this.ConnectedClientIds.Dispose();
		}

		// Token: 0x0400013B RID: 315
		private const int k_VersionAddClientIds = 1;

		// Token: 0x0400013C RID: 316
		public ulong OwnerClientId;

		// Token: 0x0400013D RID: 317
		public int NetworkTick;

		// Token: 0x0400013E RID: 318
		public HashSet<NetworkObject> SpawnedObjectsList;

		// Token: 0x0400013F RID: 319
		private FastBufferReader m_ReceivedSceneObjectData;

		// Token: 0x04000140 RID: 320
		public NativeArray<MessageVersionData> MessageVersions;

		// Token: 0x04000141 RID: 321
		public NativeArray<ulong> ConnectedClientIds;
	}
}
