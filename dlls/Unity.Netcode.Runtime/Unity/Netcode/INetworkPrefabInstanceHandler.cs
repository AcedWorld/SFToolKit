using System;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000112 RID: 274
	public interface INetworkPrefabInstanceHandler
	{
		// Token: 0x0600089E RID: 2206
		NetworkObject Instantiate(ulong ownerClientId, Vector3 position, Quaternion rotation);

		// Token: 0x0600089F RID: 2207
		void Destroy(NetworkObject networkObject);
	}
}
