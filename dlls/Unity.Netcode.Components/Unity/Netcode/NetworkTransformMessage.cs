using System;
using Unity.Collections;
using Unity.Netcode.Components;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000009 RID: 9
	internal struct NetworkTransformMessage : INetworkMessage
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000024B8 File Offset: 0x000006B8
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000024BB File Offset: 0x000006BB
		private void CopyPayload(ref FastBufferWriter writer)
		{
			writer.WriteBytesSafe(this.m_CurrentReader.GetUnsafePtrAtCurrentPosition(), this.m_CurrentReader.Length - this.m_CurrentReader.Position, 0);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000024E6 File Offset: 0x000006E6
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			if (this.m_CurrentReader.IsInitialized)
			{
				this.CopyPayload(ref writer);
				return;
			}
			BytePacker.WriteValueBitPacked(writer, this.NetworkObjectId);
			BytePacker.WriteValueBitPacked(writer, this.NetworkBehaviourId);
			writer.WriteNetworkSerializable<NetworkTransform.NetworkTransformState>(this.State);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002524 File Offset: 0x00000724
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			NetworkManager networkManager = context.SystemOwner as NetworkManager;
			if (networkManager == null)
			{
				Debug.LogError("[NetworkTransformMessage] System owner context was not of type NetworkManager!");
				return false;
			}
			int position = reader.Position;
			ByteUnpacker.ReadValueBitPacked(reader, out this.NetworkObjectId);
			if (!networkManager.SpawnManager.SpawnedObjects.ContainsKey(this.NetworkObjectId))
			{
				networkManager.DeferredMessageManager.DeferMessage(IDeferredNetworkMessageManager.TriggerType.OnSpawn, this.NetworkObjectId, reader, ref context);
				return false;
			}
			ByteUnpacker.ReadValueBitPacked(reader, out this.NetworkBehaviourId);
			reader.ReadNetworkSerializable<NetworkTransform.NetworkTransformState>(out this.State);
			NetworkObject networkObject = networkManager.SpawnManager.SpawnedObjects[this.NetworkObjectId];
			this.m_ReceiverNetworkTransform = (networkObject.ChildNetworkBehaviours[this.NetworkBehaviourId] as NetworkTransform);
			bool flag = this.m_ReceiverNetworkTransform.IsServerAuthoritative();
			if (!flag && networkManager.IsServer)
			{
				ulong ownerClientId = networkObject.OwnerClientId;
				if (ownerClientId == 0UL)
				{
					return true;
				}
				NetworkDelivery delivery = this.State.IsReliableStateUpdate() ? NetworkDelivery.ReliableSequenced : NetworkDelivery.UnreliableSequenced;
				if (networkManager.ConnectionManager.ConnectedClientsList.Count > (networkManager.IsHost ? 2 : 1))
				{
					NetworkTransformMessage networkTransformMessage = this;
					networkTransformMessage.m_CurrentReader = new FastBufferReader(reader, Allocator.None, -1, 0, Allocator.Temp);
					networkTransformMessage.m_CurrentReader.Seek(position);
					int count = networkManager.ConnectionManager.ConnectedClientsList.Count;
					for (int i = 0; i < count; i++)
					{
						ulong clientId = networkManager.ConnectionManager.ConnectedClientsList[i].ClientId;
						if (clientId != 0UL && (flag || clientId != ownerClientId) && networkObject.Observers.Contains(clientId))
						{
							networkManager.MessageManager.SendMessage<NetworkTransformMessage>(ref networkTransformMessage, delivery, clientId);
						}
					}
					networkTransformMessage.m_CurrentReader.Dispose();
				}
			}
			return true;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000026DC File Offset: 0x000008DC
		public void Handle(ref NetworkContext context)
		{
			if (this.m_ReceiverNetworkTransform == null)
			{
				Debug.LogError("[NetworkTransformMessage][Dropped] Reciever NetworkTransform was not set!");
				return;
			}
			this.m_ReceiverNetworkTransform.TransformStateUpdate(ref this.State);
		}

		// Token: 0x04000017 RID: 23
		public ulong NetworkObjectId;

		// Token: 0x04000018 RID: 24
		public int NetworkBehaviourId;

		// Token: 0x04000019 RID: 25
		public NetworkTransform.NetworkTransformState State;

		// Token: 0x0400001A RID: 26
		private NetworkTransform m_ReceiverNetworkTransform;

		// Token: 0x0400001B RID: 27
		private FastBufferReader m_CurrentReader;
	}
}
