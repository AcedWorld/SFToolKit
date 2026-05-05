using System;
using System.Collections.Generic;

namespace Unity.Netcode
{
	// Token: 0x0200001E RID: 30
	public class NetworkBehaviourUpdater
	{
		// Token: 0x060000E3 RID: 227 RVA: 0x00006770 File Offset: 0x00004970
		internal void AddForUpdate(NetworkObject networkObject)
		{
			this.m_PendingDirtyNetworkObjects.Add(networkObject);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00006780 File Offset: 0x00004980
		internal void NetworkBehaviourUpdate(bool forceSend = false)
		{
			this.m_DirtyNetworkObjects.UnionWith(this.m_PendingDirtyNetworkObjects);
			this.m_PendingDirtyNetworkObjects.Clear();
			this.m_DirtyNetworkObjects.RemoveWhere((NetworkObject sobj) => sobj == null);
			if (this.m_ConnectionManager.LocalClient.IsServer)
			{
				using (HashSet<NetworkObject>.Enumerator enumerator = this.m_DirtyNetworkObjects.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						NetworkObject networkObject = enumerator.Current;
						for (int i = 0; i < networkObject.ChildNetworkBehaviours.Count; i++)
						{
							networkObject.ChildNetworkBehaviours[i].PreVariableUpdate();
						}
						for (int j = 0; j < this.m_ConnectionManager.ConnectedClientsList.Count; j++)
						{
							NetworkClient networkClient = this.m_ConnectionManager.ConnectedClientsList[j];
							if (networkObject.IsNetworkVisibleTo(networkClient.ClientId))
							{
								for (int k = 0; k < networkObject.ChildNetworkBehaviours.Count; k++)
								{
									networkObject.ChildNetworkBehaviours[k].NetworkVariableUpdate(networkClient.ClientId, k, forceSend);
								}
							}
						}
					}
					goto IL_1C8;
				}
			}
			foreach (NetworkObject networkObject2 in this.m_DirtyNetworkObjects)
			{
				if (networkObject2.IsOwner)
				{
					for (int l = 0; l < networkObject2.ChildNetworkBehaviours.Count; l++)
					{
						networkObject2.ChildNetworkBehaviours[l].PreVariableUpdate();
					}
					for (int m = 0; m < networkObject2.ChildNetworkBehaviours.Count; m++)
					{
						networkObject2.ChildNetworkBehaviours[m].NetworkVariableUpdate(0UL, m, forceSend);
					}
				}
			}
			IL_1C8:
			foreach (NetworkObject networkObject3 in this.m_DirtyNetworkObjects)
			{
				for (int n = 0; n < networkObject3.ChildNetworkBehaviours.Count; n++)
				{
					NetworkBehaviour networkBehaviour = networkObject3.ChildNetworkBehaviours[n];
					for (int num = 0; num < networkBehaviour.NetworkVariableFields.Count; num++)
					{
						networkBehaviour.NetworkVariableFields[num].NetworkUpdaterCheck = true;
						if (networkBehaviour.NetworkVariableFields[num].IsDirty() && !networkBehaviour.NetworkVariableIndexesToResetSet.Contains(num))
						{
							networkBehaviour.NetworkVariableIndexesToResetSet.Add(num);
							networkBehaviour.NetworkVariableIndexesToReset.Add(num);
						}
						networkBehaviour.NetworkVariableFields[num].NetworkUpdaterCheck = false;
					}
				}
			}
			foreach (NetworkObject networkObject4 in this.m_DirtyNetworkObjects)
			{
				networkObject4.PostNetworkVariableWrite(forceSend);
				networkObject4.PreviousOwnerId = networkObject4.OwnerClientId;
			}
			this.m_DirtyNetworkObjects.Clear();
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00006AC0 File Offset: 0x00004CC0
		internal void Initialize(NetworkManager networkManager)
		{
			this.m_NetworkManager = networkManager;
			this.m_ConnectionManager = networkManager.ConnectionManager;
			this.m_NetworkManager.NetworkTickSystem.Tick += this.NetworkBehaviourUpdater_Tick;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00006AF1 File Offset: 0x00004CF1
		internal void Shutdown()
		{
			this.m_NetworkManager.NetworkTickSystem.Tick -= this.NetworkBehaviourUpdater_Tick;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00006B0F File Offset: 0x00004D0F
		private void NetworkBehaviourUpdater_Tick()
		{
			this.NetworkBehaviourUpdate(false);
			this.m_NetworkManager.SpawnManager.HandleNetworkObjectShow();
		}

		// Token: 0x04000086 RID: 134
		private NetworkManager m_NetworkManager;

		// Token: 0x04000087 RID: 135
		private NetworkConnectionManager m_ConnectionManager;

		// Token: 0x04000088 RID: 136
		private HashSet<NetworkObject> m_DirtyNetworkObjects = new HashSet<NetworkObject>();

		// Token: 0x04000089 RID: 137
		private HashSet<NetworkObject> m_PendingDirtyNetworkObjects = new HashSet<NetworkObject>();
	}
}
