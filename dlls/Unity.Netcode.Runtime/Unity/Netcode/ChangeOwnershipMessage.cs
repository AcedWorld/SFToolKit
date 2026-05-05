using System;

namespace Unity.Netcode
{
	// Token: 0x0200005F RID: 95
	internal struct ChangeOwnershipMessage : INetworkMessage, INetworkSerializeByMemcpy
	{
		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000262 RID: 610 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000C10A File Offset: 0x0000A30A
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			BytePacker.WriteValueBitPacked(writer, this.NetworkObjectId);
			BytePacker.WriteValueBitPacked(writer, this.OwnerClientId);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000C124 File Offset: 0x0000A324
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			if (!networkManager.IsClient)
			{
				return false;
			}
			ByteUnpacker.ReadValueBitPacked(reader, out this.NetworkObjectId);
			ByteUnpacker.ReadValueBitPacked(reader, out this.OwnerClientId);
			if (!networkManager.SpawnManager.SpawnedObjects.ContainsKey(this.NetworkObjectId))
			{
				networkManager.DeferredMessageManager.DeferMessage(IDeferredNetworkMessageManager.TriggerType.OnSpawn, this.NetworkObjectId, reader, ref context);
				return false;
			}
			return true;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000C190 File Offset: 0x0000A390
		public void Handle(ref NetworkContext context)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			NetworkObject networkObject = networkManager.SpawnManager.SpawnedObjects[this.NetworkObjectId];
			ulong ownerClientId = networkObject.OwnerClientId;
			networkObject.OwnerClientId = this.OwnerClientId;
			if (ownerClientId == networkManager.LocalClientId)
			{
				networkObject.InvokeBehaviourOnLostOwnership();
			}
			if (this.OwnerClientId != networkManager.LocalClientId && ownerClientId != networkManager.LocalClientId)
			{
				for (int i = 0; i < networkObject.ChildNetworkBehaviours.Count; i++)
				{
					networkObject.ChildNetworkBehaviours[i].UpdateNetworkProperties();
				}
			}
			if (this.OwnerClientId == networkManager.LocalClientId)
			{
				networkObject.InvokeBehaviourOnGainedOwnership();
			}
			if (ownerClientId == networkManager.LocalClientId)
			{
				networkObject.MarkOwnerReadVariablesDirty();
				networkManager.BehaviourUpdater.NetworkBehaviourUpdate(true);
			}
			networkObject.InvokeOwnershipChanged(ownerClientId, this.OwnerClientId);
			networkManager.NetworkMetrics.TrackOwnershipChangeReceived(context.SenderId, networkObject, (long)((ulong)context.MessageSize));
		}

		// Token: 0x04000137 RID: 311
		public ulong NetworkObjectId;

		// Token: 0x04000138 RID: 312
		public ulong OwnerClientId;
	}
}
