using System;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000069 RID: 105
	internal struct ParentSyncMessage : INetworkMessage
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600028A RID: 650 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600028B RID: 651 RVA: 0x0000D920 File Offset: 0x0000BB20
		// (set) Token: 0x0600028C RID: 652 RVA: 0x0000D92E File Offset: 0x0000BB2E
		public bool WorldPositionStays
		{
			get
			{
				return ByteUtility.GetBit(this.m_BitField, 0);
			}
			set
			{
				ByteUtility.SetBit(ref this.m_BitField, 0, value);
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600028D RID: 653 RVA: 0x0000D93D File Offset: 0x0000BB3D
		// (set) Token: 0x0600028E RID: 654 RVA: 0x0000D94B File Offset: 0x0000BB4B
		public bool IsLatestParentSet
		{
			get
			{
				return ByteUtility.GetBit(this.m_BitField, 1);
			}
			set
			{
				ByteUtility.SetBit(ref this.m_BitField, 1, value);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600028F RID: 655 RVA: 0x0000D95A File Offset: 0x0000BB5A
		// (set) Token: 0x06000290 RID: 656 RVA: 0x0000D968 File Offset: 0x0000BB68
		public bool RemoveParent
		{
			get
			{
				return ByteUtility.GetBit(this.m_BitField, 2);
			}
			set
			{
				ByteUtility.SetBit(ref this.m_BitField, 2, value);
			}
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000D978 File Offset: 0x0000BB78
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			BytePacker.WriteValueBitPacked(writer, this.NetworkObjectId);
			writer.WriteValueSafe<byte>(this.m_BitField, default(FastBufferWriter.ForPrimitives));
			if (!this.RemoveParent && this.IsLatestParentSet)
			{
				BytePacker.WriteValueBitPacked(writer, this.LatestParent.Value);
			}
			writer.WriteValueSafe(this.Position);
			writer.WriteValueSafe(this.Rotation);
			writer.WriteValueSafe(this.Scale);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000D9F0 File Offset: 0x0000BBF0
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			if (!networkManager.IsClient)
			{
				return false;
			}
			ByteUnpacker.ReadValueBitPacked(reader, out this.NetworkObjectId);
			reader.ReadValueSafe<byte>(out this.m_BitField, default(FastBufferWriter.ForPrimitives));
			if (!this.RemoveParent && this.IsLatestParentSet)
			{
				ulong value;
				ByteUnpacker.ReadValueBitPacked(reader, out value);
				this.LatestParent = new ulong?(value);
			}
			reader.ReadValueSafe(out this.Position);
			reader.ReadValueSafe(out this.Rotation);
			reader.ReadValueSafe(out this.Scale);
			if (!networkManager.SpawnManager.SpawnedObjects.ContainsKey(this.NetworkObjectId))
			{
				networkManager.DeferredMessageManager.DeferMessage(IDeferredNetworkMessageManager.TriggerType.OnSpawn, this.NetworkObjectId, reader, ref context);
				return false;
			}
			return true;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000DAB0 File Offset: 0x0000BCB0
		public void Handle(ref NetworkContext context)
		{
			NetworkObject networkObject = ((NetworkManager)context.SystemOwner).SpawnManager.SpawnedObjects[this.NetworkObjectId];
			networkObject.SetNetworkParenting(this.LatestParent, this.WorldPositionStays);
			networkObject.ApplyNetworkParenting(this.RemoveParent, false, false);
			if (!this.WorldPositionStays)
			{
				networkObject.transform.localPosition = this.Position;
				networkObject.transform.localRotation = this.Rotation;
			}
			else
			{
				networkObject.transform.position = this.Position;
				networkObject.transform.rotation = this.Rotation;
			}
			networkObject.transform.localScale = this.Scale;
		}

		// Token: 0x0400015C RID: 348
		public ulong NetworkObjectId;

		// Token: 0x0400015D RID: 349
		private byte m_BitField;

		// Token: 0x0400015E RID: 350
		public ulong? LatestParent;

		// Token: 0x0400015F RID: 351
		public Vector3 Position;

		// Token: 0x04000160 RID: 352
		public Quaternion Rotation;

		// Token: 0x04000161 RID: 353
		public Vector3 Scale;
	}
}
