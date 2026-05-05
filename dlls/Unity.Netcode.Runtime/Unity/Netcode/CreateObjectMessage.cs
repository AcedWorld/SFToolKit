using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000064 RID: 100
	internal struct CreateObjectMessage : INetworkMessage
	{
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000276 RID: 630 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000CB62 File Offset: 0x0000AD62
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			this.ObjectInfo.Serialize(writer);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000CB70 File Offset: 0x0000AD70
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			if (!networkManager.IsClient)
			{
				return false;
			}
			this.ObjectInfo.Deserialize(reader);
			if (!networkManager.NetworkConfig.ForceSamePrefabs && !networkManager.SpawnManager.HasPrefab(this.ObjectInfo))
			{
				networkManager.DeferredMessageManager.DeferMessage(IDeferredNetworkMessageManager.TriggerType.OnAddPrefab, (ulong)this.ObjectInfo.Hash, reader, ref context);
				return false;
			}
			this.m_ReceivedNetworkVariableData = reader;
			return true;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000CBE4 File Offset: 0x0000ADE4
		public void Handle(ref NetworkContext context)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			if (networkManager.SceneManager.ShouldDeferCreateObject())
			{
				networkManager.SceneManager.DeferCreateObject(context.SenderId, context.MessageSize, this.ObjectInfo, this.m_ReceivedNetworkVariableData);
				return;
			}
			CreateObjectMessage.CreateObject(ref networkManager, context.SenderId, context.MessageSize, this.ObjectInfo, this.m_ReceivedNetworkVariableData);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000CC50 File Offset: 0x0000AE50
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void CreateObject(ref NetworkManager networkManager, ulong senderId, uint messageSize, NetworkObject.SceneObject sceneObject, FastBufferReader networkVariableData)
		{
			try
			{
				NetworkObject networkObject = NetworkObject.AddSceneObject(sceneObject, networkVariableData, networkManager);
				networkManager.NetworkMetrics.TrackObjectSpawnReceived(senderId, networkObject, (long)((ulong)messageSize));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		// Token: 0x04000146 RID: 326
		public NetworkObject.SceneObject ObjectInfo;

		// Token: 0x04000147 RID: 327
		private FastBufferReader m_ReceivedNetworkVariableData;
	}
}
