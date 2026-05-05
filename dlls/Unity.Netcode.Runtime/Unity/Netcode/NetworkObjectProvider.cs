using System;
using Unity.Multiplayer.Tools;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x020000A9 RID: 169
	internal class NetworkObjectProvider : INetworkObjectProvider
	{
		// Token: 0x060003B0 RID: 944 RVA: 0x0001206E File Offset: 0x0001026E
		public NetworkObjectProvider(NetworkManager networkManager)
		{
			this.m_NetworkManager = networkManager;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00012080 File Offset: 0x00010280
		public Object GetNetworkObject(ulong networkObjectId)
		{
			NetworkObject result;
			if (this.m_NetworkManager.SpawnManager.SpawnedObjects.TryGetValue(networkObjectId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x04000222 RID: 546
		private readonly NetworkManager m_NetworkManager;
	}
}
