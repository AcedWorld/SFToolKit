using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000113 RID: 275
	public class NetworkPrefabHandler
	{
		// Token: 0x060008A0 RID: 2208 RVA: 0x000201D7 File Offset: 0x0001E3D7
		internal static string PrefabDebugHelper(NetworkPrefab networkPrefab)
		{
			return "NetworkPrefab \"" + networkPrefab.Prefab.name + "\"";
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x000201F3 File Offset: 0x0001E3F3
		public bool AddHandler(GameObject networkPrefabAsset, INetworkPrefabInstanceHandler instanceHandler)
		{
			return this.AddHandler(networkPrefabAsset.GetComponent<NetworkObject>().GlobalObjectIdHash, instanceHandler);
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x00020207 File Offset: 0x0001E407
		public bool AddHandler(NetworkObject prefabAssetNetworkObject, INetworkPrefabInstanceHandler instanceHandler)
		{
			return this.AddHandler(prefabAssetNetworkObject.GlobalObjectIdHash, instanceHandler);
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x00020216 File Offset: 0x0001E416
		public bool AddHandler(uint globalObjectIdHash, INetworkPrefabInstanceHandler instanceHandler)
		{
			if (!this.m_PrefabAssetToPrefabHandler.ContainsKey(globalObjectIdHash))
			{
				this.m_PrefabAssetToPrefabHandler.Add(globalObjectIdHash, instanceHandler);
				return true;
			}
			return false;
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x00020238 File Offset: 0x0001E438
		public void RegisterHostGlobalObjectIdHashValues(GameObject sourceNetworkPrefab, List<GameObject> networkPrefabOverrides)
		{
			if (!NetworkManager.Singleton.IsListening)
			{
				throw new Exception("You can only call RegisterHostGlobalObjectIdHashValues once NetworkManager is listening!");
			}
			if (NetworkManager.Singleton.IsHost)
			{
				NetworkObject component = sourceNetworkPrefab.GetComponent<NetworkObject>();
				if (sourceNetworkPrefab != null)
				{
					uint globalObjectIdHash = component.GlobalObjectIdHash;
					using (List<GameObject>.Enumerator enumerator = networkPrefabOverrides.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							NetworkObject networkObject;
							if (!enumerator.Current.TryGetComponent<NetworkObject>(out networkObject))
							{
								throw new Exception(networkObject.name + " does not have a NetworkObject component!");
							}
							if (!this.m_PrefabInstanceToPrefabAsset.ContainsKey(networkObject.GlobalObjectIdHash))
							{
								this.m_PrefabInstanceToPrefabAsset.Add(networkObject.GlobalObjectIdHash, globalObjectIdHash);
							}
							else
							{
								Debug.LogWarning(networkObject.name + " appears to be a duplicate entry!");
							}
						}
						return;
					}
				}
				throw new Exception(sourceNetworkPrefab.name + " does not have a NetworkObject component!");
			}
			throw new Exception("You should only call RegisterHostGlobalObjectIdHashValues as a Host!");
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x00020340 File Offset: 0x0001E540
		public bool RemoveHandler(GameObject networkPrefabAsset)
		{
			return this.RemoveHandler(networkPrefabAsset.GetComponent<NetworkObject>().GlobalObjectIdHash);
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x00020353 File Offset: 0x0001E553
		public bool RemoveHandler(NetworkObject networkObject)
		{
			return this.RemoveHandler(networkObject.GlobalObjectIdHash);
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x00020364 File Offset: 0x0001E564
		public bool RemoveHandler(uint globalObjectIdHash)
		{
			if (this.m_PrefabInstanceToPrefabAsset.ContainsValue(globalObjectIdHash))
			{
				uint key = 0U;
				foreach (KeyValuePair<uint, uint> keyValuePair in this.m_PrefabInstanceToPrefabAsset)
				{
					if (keyValuePair.Value == globalObjectIdHash)
					{
						key = keyValuePair.Key;
						break;
					}
				}
				this.m_PrefabInstanceToPrefabAsset.Remove(key);
			}
			return this.m_PrefabAssetToPrefabHandler.Remove(globalObjectIdHash);
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x000203F0 File Offset: 0x0001E5F0
		internal bool ContainsHandler(GameObject networkPrefab)
		{
			return this.ContainsHandler(networkPrefab.GetComponent<NetworkObject>().GlobalObjectIdHash);
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x00020403 File Offset: 0x0001E603
		internal bool ContainsHandler(NetworkObject networkObject)
		{
			return this.ContainsHandler(networkObject.GlobalObjectIdHash);
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x00020411 File Offset: 0x0001E611
		internal bool ContainsHandler(uint networkPrefabHash)
		{
			return this.m_PrefabAssetToPrefabHandler.ContainsKey(networkPrefabHash) || this.m_PrefabInstanceToPrefabAsset.ContainsKey(networkPrefabHash);
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x00020430 File Offset: 0x0001E630
		internal uint GetSourceGlobalObjectIdHash(uint networkPrefabHash)
		{
			if (this.m_PrefabAssetToPrefabHandler.ContainsKey(networkPrefabHash))
			{
				return networkPrefabHash;
			}
			uint result;
			if (this.m_PrefabInstanceToPrefabAsset.TryGetValue(networkPrefabHash, out result))
			{
				return result;
			}
			return 0U;
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x00020460 File Offset: 0x0001E660
		internal NetworkObject HandleNetworkPrefabSpawn(uint networkPrefabAssetHash, ulong ownerClientId, Vector3 position, Quaternion rotation)
		{
			INetworkPrefabInstanceHandler networkPrefabInstanceHandler;
			if (this.m_PrefabAssetToPrefabHandler.TryGetValue(networkPrefabAssetHash, out networkPrefabInstanceHandler))
			{
				NetworkObject networkObject = networkPrefabInstanceHandler.Instantiate(ownerClientId, position, rotation);
				if (networkObject != null && !this.m_PrefabInstanceToPrefabAsset.ContainsKey(networkObject.GlobalObjectIdHash))
				{
					this.m_PrefabInstanceToPrefabAsset.Add(networkObject.GlobalObjectIdHash, networkPrefabAssetHash);
				}
				return networkObject;
			}
			return null;
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x000204BC File Offset: 0x0001E6BC
		internal void HandleNetworkPrefabDestroy(NetworkObject networkObjectInstance)
		{
			uint globalObjectIdHash = networkObjectInstance.GlobalObjectIdHash;
			uint key;
			INetworkPrefabInstanceHandler networkPrefabInstanceHandler2;
			if (this.m_PrefabInstanceToPrefabAsset.TryGetValue(globalObjectIdHash, out key))
			{
				INetworkPrefabInstanceHandler networkPrefabInstanceHandler;
				if (this.m_PrefabAssetToPrefabHandler.TryGetValue(key, out networkPrefabInstanceHandler))
				{
					networkPrefabInstanceHandler.Destroy(networkObjectInstance);
					return;
				}
			}
			else if (this.m_PrefabAssetToPrefabHandler.TryGetValue(globalObjectIdHash, out networkPrefabInstanceHandler2))
			{
				networkPrefabInstanceHandler2.Destroy(networkObjectInstance);
			}
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x00020510 File Offset: 0x0001E710
		public GameObject GetNetworkPrefabOverride(GameObject gameObject)
		{
			NetworkObject networkObject;
			if (gameObject.TryGetComponent<NetworkObject>(out networkObject) && this.m_NetworkManager.NetworkConfig.Prefabs.NetworkPrefabOverrideLinks.ContainsKey(networkObject.GlobalObjectIdHash))
			{
				NetworkPrefabOverride @override = this.m_NetworkManager.NetworkConfig.Prefabs.NetworkPrefabOverrideLinks[networkObject.GlobalObjectIdHash].Override;
				if (@override - NetworkPrefabOverride.Prefab <= 1)
				{
					return this.m_NetworkManager.NetworkConfig.Prefabs.NetworkPrefabOverrideLinks[networkObject.GlobalObjectIdHash].OverridingTargetPrefab;
				}
			}
			return gameObject;
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x0002059C File Offset: 0x0001E79C
		public void AddNetworkPrefab(GameObject prefab)
		{
			if (this.m_NetworkManager.IsListening && this.m_NetworkManager.NetworkConfig.ForceSamePrefabs)
			{
				throw new Exception("All prefabs must be registered before starting NetworkManager when ForceSamePrefabs is enabled.");
			}
			NetworkObject component = prefab.GetComponent<NetworkObject>();
			if (!component)
			{
				throw new Exception("All NetworkPrefabs must contain a NetworkObject component.");
			}
			NetworkPrefab networkPrefab = new NetworkPrefab
			{
				Prefab = prefab
			};
			bool flag = this.m_NetworkManager.NetworkConfig.Prefabs.Add(networkPrefab);
			if (this.m_NetworkManager.IsListening && flag)
			{
				this.m_NetworkManager.DeferredMessageManager.ProcessTriggers(IDeferredNetworkMessageManager.TriggerType.OnAddPrefab, (ulong)component.GlobalObjectIdHash);
			}
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x00020638 File Offset: 0x0001E838
		public void RemoveNetworkPrefab(GameObject prefab)
		{
			if (this.m_NetworkManager.IsListening && this.m_NetworkManager.NetworkConfig.ForceSamePrefabs)
			{
				throw new Exception("Prefabs cannot be removed after starting NetworkManager when ForceSamePrefabs is enabled.");
			}
			uint globalObjectIdHash = prefab.GetComponent<NetworkObject>().GlobalObjectIdHash;
			this.m_NetworkManager.NetworkConfig.Prefabs.Remove(prefab);
			if (this.ContainsHandler(globalObjectIdHash))
			{
				this.RemoveHandler(globalObjectIdHash);
			}
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x000206A4 File Offset: 0x0001E8A4
		internal void RegisterPlayerPrefab()
		{
			NetworkConfig networkConfig = this.m_NetworkManager.NetworkConfig;
			if (networkConfig.PlayerPrefab != null)
			{
				NetworkObject networkObject;
				if (networkConfig.PlayerPrefab.TryGetComponent<NetworkObject>(out networkObject))
				{
					if (!networkConfig.Prefabs.NetworkPrefabOverrideLinks.ContainsKey(networkObject.GlobalObjectIdHash))
					{
						this.AddNetworkPrefab(networkConfig.PlayerPrefab);
						return;
					}
				}
				else
				{
					Debug.LogError("PlayerPrefab (\"" + networkConfig.PlayerPrefab.name + "\") has no NetworkObject assigned to it!.");
				}
			}
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x0002071E File Offset: 0x0001E91E
		internal void Initialize(NetworkManager networkManager)
		{
			this.m_NetworkManager = networkManager;
		}

		// Token: 0x04000333 RID: 819
		private NetworkManager m_NetworkManager;

		// Token: 0x04000334 RID: 820
		private readonly Dictionary<uint, INetworkPrefabInstanceHandler> m_PrefabAssetToPrefabHandler = new Dictionary<uint, INetworkPrefabInstanceHandler>();

		// Token: 0x04000335 RID: 821
		private readonly Dictionary<uint, uint> m_PrefabInstanceToPrefabAsset = new Dictionary<uint, uint>();
	}
}
