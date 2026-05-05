using System;
using System.Collections.Generic;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x0200006A RID: 106
	internal struct ProxyMessage : INetworkMessage
	{
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000294 RID: 660 RVA: 0x0000DB60 File Offset: 0x0000BD60
		public int Version
		{
			get
			{
				return default(RpcMessage).Version;
			}
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000DB7C File Offset: 0x0000BD7C
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			writer.WriteValueSafe<ulong>(this.TargetClientIds, default(FastBufferWriter.ForGeneric));
			BytePacker.WriteValuePacked<NetworkDelivery>(writer, this.Delivery);
			this.WrappedMessage.Serialize(writer, targetVersion);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000DBB8 File Offset: 0x0000BDB8
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			reader.ReadValueSafe<ulong>(out this.TargetClientIds, Allocator.Temp, default(FastBufferWriter.ForGeneric));
			ByteUnpacker.ReadValuePacked<NetworkDelivery>(reader, out this.Delivery);
			this.WrappedMessage = default(RpcMessage);
			this.WrappedMessage.Deserialize(reader, ref context, receivedMessageVersion);
			return true;
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000DC04 File Offset: 0x0000BE04
		public void Handle(ref NetworkContext context)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			NetworkObject networkObject;
			if (!networkManager.SpawnManager.SpawnedObjects.TryGetValue(this.WrappedMessage.Metadata.NetworkObjectId, out networkObject))
			{
				if (networkManager.LogLevel == LogLevel.Developer)
				{
					NetworkLog.LogWarning(string.Format("[{0}, {1}, {2}] An RPC called on a {3} that is not in the spawned objects list. Please make sure the {4} is spawned before calling RPCs.", new object[]
					{
						this.WrappedMessage.Metadata.NetworkObjectId,
						this.WrappedMessage.Metadata.NetworkBehaviourId,
						this.WrappedMessage.Metadata.NetworkRpcMethodId,
						"NetworkObject",
						"NetworkObject"
					}));
				}
				return;
			}
			HashSet<ulong> observers = networkObject.Observers;
			NativeList<ulong> nativeList = new NativeList<ulong>(Allocator.Temp);
			for (int i = 0; i < this.TargetClientIds.Length; i++)
			{
				if (observers.Contains(this.TargetClientIds[i]))
				{
					if (this.TargetClientIds[i] == 0UL)
					{
						this.WrappedMessage.Handle(ref context);
					}
					else
					{
						ulong num = this.TargetClientIds[i];
						nativeList.Add(num);
					}
				}
			}
			this.WrappedMessage.WriteBuffer = new FastBufferWriter(this.WrappedMessage.ReadBuffer.Length, Allocator.Temp, -1);
			using (this.WrappedMessage.WriteBuffer)
			{
				this.WrappedMessage.WriteBuffer.WriteBytesSafe(this.WrappedMessage.ReadBuffer.GetUnsafePtr(), this.WrappedMessage.ReadBuffer.Length, 0);
				networkManager.MessageManager.SendMessage<RpcMessage>(ref this.WrappedMessage, this.Delivery, nativeList);
			}
		}

		// Token: 0x04000162 RID: 354
		public NativeArray<ulong> TargetClientIds;

		// Token: 0x04000163 RID: 355
		public NetworkDelivery Delivery;

		// Token: 0x04000164 RID: 356
		public RpcMessage WrappedMessage;
	}
}
