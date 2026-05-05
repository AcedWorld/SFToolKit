using System;

namespace Unity.Netcode
{
	// Token: 0x02000065 RID: 101
	internal struct DestroyObjectMessage : INetworkMessage, INetworkSerializeByMemcpy
	{
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600027B RID: 635 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000CC94 File Offset: 0x0000AE94
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			BytePacker.WriteValueBitPacked(writer, this.NetworkObjectId);
			writer.WriteValueSafe<bool>(this.DestroyGameObject, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000CCC4 File Offset: 0x0000AEC4
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			if (!networkManager.IsClient)
			{
				return false;
			}
			ByteUnpacker.ReadValueBitPacked(reader, out this.NetworkObjectId);
			reader.ReadValueSafe<bool>(out this.DestroyGameObject, default(FastBufferWriter.ForPrimitives));
			NetworkObject networkObject;
			if (!networkManager.SpawnManager.SpawnedObjects.TryGetValue(this.NetworkObjectId, out networkObject))
			{
				networkManager.DeferredMessageManager.DeferMessage(IDeferredNetworkMessageManager.TriggerType.OnSpawn, this.NetworkObjectId, reader, ref context);
				return false;
			}
			return true;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000CD3C File Offset: 0x0000AF3C
		public void Handle(ref NetworkContext context)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			NetworkObject networkObject;
			if (!networkManager.SpawnManager.SpawnedObjects.TryGetValue(this.NetworkObjectId, out networkObject))
			{
				return;
			}
			networkManager.NetworkMetrics.TrackObjectDestroyReceived(context.SenderId, networkObject, (long)((ulong)context.MessageSize));
			networkManager.SpawnManager.OnDespawnObject(networkObject, this.DestroyGameObject);
		}

		// Token: 0x04000148 RID: 328
		public ulong NetworkObjectId;

		// Token: 0x04000149 RID: 329
		public bool DestroyGameObject;
	}
}
