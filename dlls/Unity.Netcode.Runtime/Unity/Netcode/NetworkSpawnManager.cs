using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000114 RID: 276
	public class NetworkSpawnManager
	{
		// Token: 0x060008B4 RID: 2228 RVA: 0x00020745 File Offset: 0x0001E945
		internal void MarkObjectForShowingTo(NetworkObject networkObject, ulong clientId)
		{
			if (!this.ObjectsToShowToClient.ContainsKey(clientId))
			{
				this.ObjectsToShowToClient.Add(clientId, new List<NetworkObject>());
			}
			this.ObjectsToShowToClient[clientId].Add(networkObject);
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x00020778 File Offset: 0x0001E978
		internal bool RemoveObjectFromShowingTo(NetworkObject networkObject, ulong clientId)
		{
			bool flag = false;
			if (!this.ObjectsToShowToClient.ContainsKey(clientId))
			{
				return false;
			}
			while (this.ObjectsToShowToClient[clientId].Contains(networkObject))
			{
				Debug.LogWarning("Object was shown and hidden from the same client in the same Network frame. As a result, the client will _not_ receive a NetworkSpawn");
				this.ObjectsToShowToClient[clientId].Remove(networkObject);
				flag = true;
			}
			if (flag)
			{
				networkObject.Observers.Remove(clientId);
			}
			return flag;
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x000207DC File Offset: 0x0001E9DC
		internal void UpdateOwnershipTable(NetworkObject networkObject, ulong newOwner, bool isRemoving = false)
		{
			ulong num = newOwner;
			if (this.m_ObjectToOwnershipTable.ContainsKey(networkObject.NetworkObjectId))
			{
				num = this.m_ObjectToOwnershipTable[networkObject.NetworkObjectId];
				if (isRemoving)
				{
					this.m_ObjectToOwnershipTable.Remove(networkObject.NetworkObjectId);
				}
				else
				{
					this.m_ObjectToOwnershipTable[networkObject.NetworkObjectId] = newOwner;
				}
			}
			else
			{
				this.m_ObjectToOwnershipTable.Add(networkObject.NetworkObjectId, newOwner);
			}
			if (num != newOwner && this.OwnershipToObjectsTable.ContainsKey(num))
			{
				if (!this.OwnershipToObjectsTable[num].ContainsKey(networkObject.NetworkObjectId))
				{
					throw new Exception(string.Format("Client-ID {0} had a partial {1} entry! Potentially corrupted {2}?", num, "m_ObjectToOwnershipTable", "OwnershipToObjectsTable"));
				}
				this.OwnershipToObjectsTable[num].Remove(networkObject.NetworkObjectId);
				if (isRemoving)
				{
					return;
				}
			}
			if (!this.OwnershipToObjectsTable.ContainsKey(newOwner))
			{
				this.OwnershipToObjectsTable.Add(newOwner, new Dictionary<ulong, NetworkObject>());
			}
			if (!this.OwnershipToObjectsTable[newOwner].ContainsKey(networkObject.NetworkObjectId))
			{
				this.OwnershipToObjectsTable[newOwner].Add(networkObject.NetworkObjectId, networkObject);
				return;
			}
			if (isRemoving)
			{
				this.OwnershipToObjectsTable[num].Remove(networkObject.NetworkObjectId);
				return;
			}
			if (this.NetworkManager.LogLevel == LogLevel.Developer)
			{
				NetworkLog.LogWarning(string.Format("Setting ownership twice? Client-ID {0} already owns NetworkObject ID {1}!", num, networkObject.NetworkObjectId));
			}
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x0002094E File Offset: 0x0001EB4E
		public List<NetworkObject> GetClientOwnedObjects(ulong clientId)
		{
			if (!this.OwnershipToObjectsTable.ContainsKey(clientId))
			{
				this.OwnershipToObjectsTable.Add(clientId, new Dictionary<ulong, NetworkObject>());
			}
			return this.OwnershipToObjectsTable[clientId].Values.ToList<NetworkObject>();
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060008B8 RID: 2232 RVA: 0x00020985 File Offset: 0x0001EB85
		public NetworkManager NetworkManager { get; }

		// Token: 0x060008B9 RID: 2233 RVA: 0x00020990 File Offset: 0x0001EB90
		internal ulong GetNetworkObjectId()
		{
			if (this.ReleasedNetworkObjectIds.Count > 0 && this.NetworkManager.NetworkConfig.RecycleNetworkIds && this.NetworkManager.RealTimeProvider.UnscaledTime - this.ReleasedNetworkObjectIds.Peek().ReleaseTime >= this.NetworkManager.NetworkConfig.NetworkIdRecycleDelay)
			{
				return this.ReleasedNetworkObjectIds.Dequeue().NetworkId;
			}
			this.m_NetworkObjectIdCounter += 1UL;
			return this.m_NetworkObjectIdCounter;
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x00020A16 File Offset: 0x0001EC16
		public NetworkObject GetLocalPlayerObject()
		{
			return this.GetPlayerNetworkObject(this.NetworkManager.LocalClientId);
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x00020A2C File Offset: 0x0001EC2C
		public NetworkObject GetPlayerNetworkObject(ulong clientId)
		{
			if (!this.NetworkManager.IsServer && this.NetworkManager.LocalClientId != clientId)
			{
				throw new NotServerException("Only the server can find player objects from other clients.");
			}
			NetworkClient networkClient;
			if (this.TryGetNetworkClient(clientId, out networkClient))
			{
				return networkClient.PlayerObject;
			}
			return null;
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x00020A74 File Offset: 0x0001EC74
		private bool TryGetNetworkClient(ulong clientId, out NetworkClient networkClient)
		{
			if (this.NetworkManager.IsServer)
			{
				return this.NetworkManager.ConnectedClients.TryGetValue(clientId, out networkClient);
			}
			if (this.NetworkManager.LocalClient != null && clientId == this.NetworkManager.LocalClient.ClientId)
			{
				networkClient = this.NetworkManager.LocalClient;
				return true;
			}
			networkClient = null;
			return false;
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x00020AD4 File Offset: 0x0001ECD4
		internal void RemoveOwnership(NetworkObject networkObject)
		{
			this.ChangeOwnership(networkObject, 0UL);
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x00020AE0 File Offset: 0x0001ECE0
		internal void ChangeOwnership(NetworkObject networkObject, ulong clientId)
		{
			if (this.m_LastChangeInOwnership.ContainsKey(networkObject.NetworkObjectId) && this.m_LastChangeInOwnership[networkObject.NetworkObjectId] > Time.realtimeSinceStartup)
			{
				bool flag = false;
				for (int i = 0; i < networkObject.ChildNetworkBehaviours.Count; i++)
				{
					flag = (networkObject.ChildNetworkBehaviours[i].NetworkVariableFields.Count > 0);
					if (flag)
					{
						break;
					}
				}
				if (flag && this.NetworkManager.LogLevel == LogLevel.Developer)
				{
					NetworkLog.LogWarningServer(string.Format("[Rapid Ownership Change Detected][Potential Loss in State] Detected a rapid change in ownership that exceeds a frequency less than {0}x the current network tick rate! Provide at least {1}x the current network tick rate between ownership changes to avoid NetworkVariable state loss.", 6, 6));
				}
			}
			if (!this.NetworkManager.IsServer)
			{
				throw new NotServerException("Only the server can change ownership");
			}
			if (!networkObject.IsSpawned)
			{
				throw new SpawnStateException("Object is not spawned");
			}
			networkObject.PreviousOwnerId = networkObject.OwnerClientId;
			networkObject.OwnerClientId = clientId;
			networkObject.InvokeBehaviourOnLostOwnership();
			this.UpdateOwnershipTable(networkObject, networkObject.OwnerClientId, false);
			networkObject.InvokeBehaviourOnGainedOwnership();
			if (networkObject.PreviousOwnerId == this.NetworkManager.LocalClientId)
			{
				networkObject.MarkOwnerReadVariablesDirty();
				this.NetworkManager.BehaviourUpdater.NetworkBehaviourUpdate(true);
			}
			ChangeOwnershipMessage changeOwnershipMessage = new ChangeOwnershipMessage
			{
				NetworkObjectId = networkObject.NetworkObjectId,
				OwnerClientId = networkObject.OwnerClientId
			};
			foreach (KeyValuePair<ulong, NetworkClient> keyValuePair in this.NetworkManager.ConnectedClients)
			{
				if (networkObject.IsNetworkVisibleTo(keyValuePair.Value.ClientId))
				{
					int num = this.NetworkManager.ConnectionManager.SendMessage<ChangeOwnershipMessage>(ref changeOwnershipMessage, NetworkDelivery.ReliableSequenced, keyValuePair.Value.ClientId);
					this.NetworkManager.NetworkMetrics.TrackOwnershipChangeSent(keyValuePair.Key, networkObject, (long)num);
				}
			}
			networkObject.InvokeOwnershipChanged(networkObject.PreviousOwnerId, clientId);
			if (!this.m_LastChangeInOwnership.ContainsKey(networkObject.NetworkObjectId))
			{
				this.m_LastChangeInOwnership.Add(networkObject.NetworkObjectId, 0f);
			}
			float num2 = 1f / this.NetworkManager.NetworkConfig.TickRate;
			this.m_LastChangeInOwnership[networkObject.NetworkObjectId] = Time.realtimeSinceStartup + num2 * 6f;
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00020D20 File Offset: 0x0001EF20
		internal bool HasPrefab(NetworkObject.SceneObject sceneObject)
		{
			if (this.NetworkManager.NetworkConfig.EnableSceneManagement && sceneObject.IsSceneObject)
			{
				return this.NetworkManager.SceneManager.GetSceneRelativeInSceneNetworkObject(sceneObject.Hash, new int?(sceneObject.NetworkSceneHandle)) != null;
			}
			if (this.NetworkManager.PrefabHandler.ContainsHandler(sceneObject.Hash))
			{
				return true;
			}
			NetworkPrefab networkPrefab;
			if (!this.NetworkManager.NetworkConfig.Prefabs.NetworkPrefabOverrideLinks.TryGetValue(sceneObject.Hash, out networkPrefab))
			{
				return false;
			}
			NetworkPrefabOverride @override = networkPrefab.Override;
			if (@override == NetworkPrefabOverride.None || @override - NetworkPrefabOverride.Prefab > 1)
			{
				return networkPrefab.Prefab != null;
			}
			return networkPrefab.OverridingTargetPrefab != null;
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x00020DDC File Offset: 0x0001EFDC
		public NetworkObject InstantiateAndSpawn(NetworkObject networkPrefab, ulong ownerClientId = 0UL, bool destroyWithScene = false, bool isPlayerObject = false, bool forceOverride = false, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion))
		{
			if (networkPrefab == null)
			{
				Debug.LogError(NetworkSpawnManager.InstantiateAndSpawnErrors[NetworkSpawnManager.InstantiateAndSpawnErrorTypes.NetworkPrefabNull]);
				return null;
			}
			if (!this.NetworkManager.IsServer)
			{
				Debug.LogError(NetworkSpawnManager.InstantiateAndSpawnErrors[NetworkSpawnManager.InstantiateAndSpawnErrorTypes.NotAuthority]);
				return null;
			}
			if (this.NetworkManager.ShutdownInProgress)
			{
				Debug.LogWarning(NetworkSpawnManager.InstantiateAndSpawnErrors[NetworkSpawnManager.InstantiateAndSpawnErrorTypes.InvokedWhenShuttingDown]);
				return null;
			}
			if (!this.NetworkManager.NetworkConfig.Prefabs.Contains(networkPrefab.gameObject))
			{
				Debug.LogError(NetworkSpawnManager.InstantiateAndSpawnErrors[NetworkSpawnManager.InstantiateAndSpawnErrorTypes.NotRegisteredNetworkPrefab]);
				return null;
			}
			return this.InstantiateAndSpawnNoParameterChecks(networkPrefab, ownerClientId, destroyWithScene, isPlayerObject, forceOverride, position, rotation);
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x00020E84 File Offset: 0x0001F084
		internal NetworkObject InstantiateAndSpawnNoParameterChecks(NetworkObject networkPrefab, ulong ownerClientId = 0UL, bool destroyWithScene = false, bool isPlayerObject = false, bool forceOverride = false, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion))
		{
			NetworkObject networkObject;
			if (forceOverride || this.NetworkManager.IsHost || this.NetworkManager.PrefabHandler.ContainsHandler(networkPrefab.GlobalObjectIdHash))
			{
				networkObject = this.GetNetworkObjectToSpawn(networkPrefab.GlobalObjectIdHash, ownerClientId, new Vector3?(position), new Quaternion?(rotation), false);
			}
			else
			{
				networkObject = this.InstantiateNetworkPrefab(networkPrefab.gameObject, networkPrefab.GlobalObjectIdHash, new Vector3?(position), new Quaternion?(rotation));
			}
			if (networkObject == null)
			{
				Debug.LogError("Failed to instantiate and spawn " + networkPrefab.name + "!");
				return null;
			}
			networkObject.IsPlayerObject = isPlayerObject;
			networkObject.transform.position = position;
			networkObject.transform.rotation = rotation;
			if (isPlayerObject)
			{
				networkObject.SpawnAsPlayerObject(ownerClientId, destroyWithScene);
			}
			else
			{
				networkObject.SpawnWithOwnership(ownerClientId, destroyWithScene);
			}
			return networkObject;
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x00020F5C File Offset: 0x0001F15C
		internal NetworkObject GetNetworkObjectToSpawn(uint globalObjectIdHash, ulong ownerId, Vector3? position, Quaternion? rotation, bool isScenePlaced = false)
		{
			NetworkObject networkObject = null;
			if (this.NetworkManager.PrefabHandler.ContainsHandler(globalObjectIdHash))
			{
				networkObject = this.NetworkManager.PrefabHandler.HandleNetworkPrefabSpawn(globalObjectIdHash, ownerId, position.GetValueOrDefault(), rotation.GetValueOrDefault());
				networkObject.NetworkManagerOwner = this.NetworkManager;
			}
			else
			{
				GameObject gameObject = null;
				bool flag = !this.NetworkManager.NetworkConfig.EnableSceneManagement && isScenePlaced;
				if (this.NetworkManager.NetworkConfig.Prefabs.NetworkPrefabOverrideLinks.ContainsKey(globalObjectIdHash))
				{
					NetworkPrefab networkPrefab = this.NetworkManager.NetworkConfig.Prefabs.NetworkPrefabOverrideLinks[globalObjectIdHash];
					NetworkPrefabOverride @override = networkPrefab.Override;
					if (@override == NetworkPrefabOverride.None || @override - NetworkPrefabOverride.Prefab > 1)
					{
						gameObject = networkPrefab.Prefab;
					}
					else if (flag)
					{
						gameObject = (networkPrefab.SourcePrefabToOverride ? networkPrefab.SourcePrefabToOverride : networkPrefab.Prefab);
					}
					else
					{
						gameObject = this.NetworkManager.NetworkConfig.Prefabs.NetworkPrefabOverrideLinks[globalObjectIdHash].OverridingTargetPrefab;
					}
				}
				if (gameObject == null)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
					{
						NetworkLog.LogError(string.Format("Failed to create object locally. [{0}={1}]. {2} could not be found. Is the prefab registered with {3}?", new object[]
						{
							"globalObjectIdHash",
							globalObjectIdHash,
							"NetworkPrefab",
							"NetworkManager"
						}));
					}
				}
				else
				{
					networkObject = this.InstantiateNetworkPrefab(gameObject, globalObjectIdHash, position, rotation);
				}
			}
			return networkObject;
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x000210B8 File Offset: 0x0001F2B8
		internal NetworkObject InstantiateNetworkPrefab(GameObject networkPrefab, uint prefabGlobalObjectIdHash, Vector3? position, Quaternion? rotation)
		{
			NetworkObject component = Object.Instantiate<GameObject>(networkPrefab).GetComponent<NetworkObject>();
			component.transform.position = (position ?? component.transform.position);
			component.transform.rotation = (rotation ?? component.transform.rotation);
			component.NetworkManagerOwner = this.NetworkManager;
			component.PrefabGlobalObjectIdHash = prefabGlobalObjectIdHash;
			return component;
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x0002113C File Offset: 0x0001F33C
		internal NetworkObject CreateLocalNetworkObject(NetworkObject.SceneObject sceneObject)
		{
			uint hash = sceneObject.Hash;
			Vector3 vector = sceneObject.HasTransform ? sceneObject.Transform.Position : default(Vector3);
			Quaternion quaternion = sceneObject.HasTransform ? sceneObject.Transform.Rotation : default(Quaternion);
			Vector3 localScale = sceneObject.HasTransform ? sceneObject.Transform.Scale : default(Vector3);
			ulong value = sceneObject.HasParent ? sceneObject.ParentObjectId : 0UL;
			bool flag = !sceneObject.HasParent || sceneObject.WorldPositionStays;
			bool flag2 = false;
			NetworkObject networkObject;
			if (!this.NetworkManager.NetworkConfig.EnableSceneManagement || !sceneObject.IsSceneObject)
			{
				networkObject = this.GetNetworkObjectToSpawn(sceneObject.Hash, sceneObject.OwnerClientId, new Vector3?(vector), new Quaternion?(quaternion), sceneObject.IsSceneObject);
			}
			else
			{
				networkObject = this.NetworkManager.SceneManager.GetSceneRelativeInSceneNetworkObject(hash, new int?(sceneObject.NetworkSceneHandle));
				if (networkObject == null && NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogError(string.Format("{0} hash was not found! In-Scene placed {1} soft synchronization failure for Hash: {2}!", "NetworkPrefab", "NetworkObject", hash));
				}
				if (networkObject != null && !networkObject.gameObject.activeInHierarchy)
				{
					networkObject.gameObject.SetActive(true);
				}
			}
			if (networkObject != null)
			{
				networkObject.DestroyWithScene = sceneObject.DestroyWithScene;
				networkObject.NetworkSceneHandle = sceneObject.NetworkSceneHandle;
				bool flag3 = false;
				if (sceneObject.IsSceneObject && networkObject.transform.parent != null)
				{
					NetworkObject component = networkObject.transform.parent.GetComponent<NetworkObject>();
					if (!sceneObject.HasParent && component)
					{
						networkObject.ApplyNetworkParenting(true, true, false);
					}
					else if (sceneObject.HasParent && !component)
					{
						flag3 = true;
					}
				}
				if (sceneObject.HasTransform && !flag2)
				{
					if ((flag && !flag3) || !networkObject.AutoObjectParentSync)
					{
						networkObject.transform.position = vector;
						networkObject.transform.rotation = quaternion;
					}
					else
					{
						networkObject.transform.localPosition = vector;
						networkObject.transform.localRotation = quaternion;
					}
					if (!sceneObject.IsPlayerObject)
					{
						networkObject.transform.localScale = localScale;
					}
				}
				if (sceneObject.HasParent)
				{
					ulong? latestParent = null;
					if (sceneObject.IsLatestParentSet)
					{
						latestParent = new ulong?(value);
					}
					networkObject.SetNetworkParenting(latestParent, flag);
				}
				if (!sceneObject.IsSceneObject && NetworkSceneManager.IsSpawnedObjectsPendingInDontDestroyOnLoad)
				{
					Object.DontDestroyOnLoad(networkObject.gameObject);
				}
			}
			return networkObject;
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x000213CC File Offset: 0x0001F5CC
		internal void SpawnNetworkObjectLocally(NetworkObject networkObject, ulong networkId, bool sceneObject, bool playerObject, ulong ownerClientId, bool destroyWithScene)
		{
			if (networkObject == null)
			{
				throw new ArgumentNullException("networkObject", "Cannot spawn null object");
			}
			if (networkObject.IsSpawned)
			{
				throw new SpawnStateException("Object is already spawned");
			}
			if (!sceneObject && networkObject.GetComponentsInChildren<NetworkObject>().Length > 1)
			{
				Debug.LogError("Spawning NetworkObjects with nested NetworkObjects is only supported for scene objects. Child NetworkObjects will not be spawned over the network!");
			}
			networkObject.InvokeBehaviourNetworkPreSpawn();
			this.SpawnNetworkObjectLocallyCommon(networkObject, networkId, sceneObject, playerObject, ownerClientId, destroyWithScene);
			networkObject.InvokeBehaviourNetworkPostSpawn();
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x00021438 File Offset: 0x0001F638
		internal void SpawnNetworkObjectLocally(NetworkObject networkObject, in NetworkObject.SceneObject sceneObject, bool destroyWithScene)
		{
			if (networkObject == null)
			{
				throw new ArgumentNullException("networkObject", "Cannot spawn null object");
			}
			if (networkObject.IsSpawned)
			{
				throw new SpawnStateException("Object is already spawned");
			}
			ulong networkObjectId = sceneObject.NetworkObjectId;
			NetworkObject.SceneObject sceneObject2 = sceneObject;
			bool isSceneObject = sceneObject2.IsSceneObject;
			sceneObject2 = sceneObject;
			this.SpawnNetworkObjectLocallyCommon(networkObject, networkObjectId, isSceneObject, sceneObject2.IsPlayerObject, sceneObject.OwnerClientId, destroyWithScene);
			networkObject.InvokeBehaviourNetworkPostSpawn();
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x000214A8 File Offset: 0x0001F6A8
		private void SpawnNetworkObjectLocallyCommon(NetworkObject networkObject, ulong networkId, bool sceneObject, bool playerObject, ulong ownerClientId, bool destroyWithScene)
		{
			if (this.SpawnedObjects.ContainsKey(networkId))
			{
				Debug.LogWarning(string.Format("Trying to spawn {0} {1} that already exists!", "NetworkObjectId", networkId));
				return;
			}
			networkObject.IsSpawned = true;
			networkObject.IsSceneObject = new bool?(sceneObject);
			bool? isSceneObject = networkObject.IsSceneObject;
			bool flag = false;
			if (!(isSceneObject.GetValueOrDefault() == flag & isSceneObject != null) && networkObject.SceneOriginHandle == 0)
			{
				networkObject.SceneOrigin = networkObject.gameObject.scene;
			}
			if (networkObject.NetworkManagerOwner != this.NetworkManager)
			{
				networkObject.NetworkManagerOwner = this.NetworkManager;
			}
			networkObject.NetworkObjectId = networkId;
			networkObject.DestroyWithScene = (sceneObject || destroyWithScene);
			networkObject.OwnerClientId = ownerClientId;
			networkObject.IsPlayerObject = playerObject;
			this.SpawnedObjects.Add(networkObject.NetworkObjectId, networkObject);
			this.SpawnedObjectsList.Add(networkObject);
			if (this.NetworkManager.IsServer)
			{
				if (playerObject)
				{
					if (this.NetworkManager.ConnectedClients[ownerClientId].PlayerObject != null)
					{
						this.NetworkManager.ConnectedClients[ownerClientId].PlayerObject.IsPlayerObject = false;
					}
					this.NetworkManager.ConnectedClients[ownerClientId].PlayerObject = networkObject;
				}
			}
			else if (ownerClientId == this.NetworkManager.LocalClientId && playerObject)
			{
				if (this.NetworkManager.LocalClient.PlayerObject != null)
				{
					this.NetworkManager.LocalClient.PlayerObject.IsPlayerObject = false;
				}
				this.NetworkManager.LocalClient.PlayerObject = networkObject;
			}
			if (this.NetworkManager.IsServer && networkObject.SpawnWithObservers)
			{
				for (int i = 0; i < this.NetworkManager.ConnectedClientsList.Count; i++)
				{
					if (networkObject.CheckObjectVisibility == null || networkObject.CheckObjectVisibility(this.NetworkManager.ConnectedClientsList[i].ClientId))
					{
						networkObject.Observers.Add(this.NetworkManager.ConnectedClientsList[i].ClientId);
					}
				}
			}
			networkObject.ApplyNetworkParenting(false, false, false);
			NetworkObject.CheckOrphanChildren();
			networkObject.InvokeBehaviourNetworkSpawn();
			this.NetworkManager.DeferredMessageManager.ProcessTriggers(IDeferredNetworkMessageManager.TriggerType.OnSpawn, networkId);
			foreach (NetworkObject networkObject2 in networkObject.GetComponentsInChildren<NetworkObject>())
			{
				if (networkObject2.IsSceneObject == null || networkObject2.IsSceneObject.Value)
				{
					networkObject2.IsSceneObject = new bool?(sceneObject);
				}
			}
			if (!sceneObject)
			{
				networkObject.SubscribeToActiveSceneForSynch();
			}
			if (networkObject.IsSceneObject.Value && networkObject.InScenePlacedSourceGlobalObjectIdHash != 0U)
			{
				networkObject.PrefabGlobalObjectIdHash = networkObject.InScenePlacedSourceGlobalObjectIdHash;
			}
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x00021764 File Offset: 0x0001F964
		internal void SendSpawnCallForObject(ulong clientId, NetworkObject networkObject)
		{
			if (clientId == 0UL)
			{
				return;
			}
			CreateObjectMessage createObjectMessage = new CreateObjectMessage
			{
				ObjectInfo = networkObject.GetMessageSceneObject(clientId)
			};
			int num = this.NetworkManager.ConnectionManager.SendMessage<CreateObjectMessage>(ref createObjectMessage, NetworkDelivery.ReliableFragmentedSequenced, clientId);
			this.NetworkManager.NetworkMetrics.TrackObjectSpawnSent(clientId, networkObject, (long)num);
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x000217B8 File Offset: 0x0001F9B8
		internal ulong? GetSpawnParentId(NetworkObject networkObject)
		{
			NetworkObject networkObject2 = null;
			if (!networkObject.AlwaysReplicateAsRoot && networkObject.transform.parent != null)
			{
				networkObject2 = networkObject.transform.parent.GetComponent<NetworkObject>();
			}
			if (networkObject2 == null)
			{
				return null;
			}
			return new ulong?(networkObject2.NetworkObjectId);
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x00021811 File Offset: 0x0001FA11
		internal void DespawnObject(NetworkObject networkObject, bool destroyObject = false)
		{
			if (!networkObject.IsSpawned)
			{
				throw new SpawnStateException("Object is not spawned");
			}
			if (!this.NetworkManager.IsServer)
			{
				throw new NotServerException("Only server can despawn objects");
			}
			this.OnDespawnObject(networkObject, destroyObject);
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x00021848 File Offset: 0x0001FA48
		internal void ServerResetShudownStateForSceneObjects()
		{
			foreach (NetworkObject networkObject in Object.FindObjectsOfType<NetworkObject>().Where(delegate(NetworkObject c)
			{
				if (c.IsSceneObject != null)
				{
					bool? isSceneObject = c.IsSceneObject;
					bool flag = true;
					return isSceneObject.GetValueOrDefault() == flag & isSceneObject != null;
				}
				return false;
			}))
			{
				networkObject.IsSpawned = false;
				networkObject.DestroyWithScene = false;
				networkObject.IsSceneObject = null;
			}
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x000218CC File Offset: 0x0001FACC
		internal void ServerDestroySpawnedSceneObjects()
		{
			foreach (NetworkObject networkObject in this.SpawnedObjectsList.ToList<NetworkObject>())
			{
				if (networkObject.IsSceneObject != null && networkObject.IsSceneObject.Value && networkObject.DestroyWithScene && networkObject.gameObject.scene != this.NetworkManager.SceneManager.DontDestroyOnLoadScene)
				{
					this.SpawnedObjectsList.Remove(networkObject);
					Object.Destroy(networkObject.gameObject);
				}
			}
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x00021980 File Offset: 0x0001FB80
		internal void DespawnAndDestroyNetworkObjects()
		{
			NetworkObject[] array = Object.FindObjectsOfType<NetworkObject>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].NetworkManager == this.NetworkManager)
				{
					if (this.NetworkManager.PrefabHandler.ContainsHandler(array[i]))
					{
						this.OnDespawnObject(array[i], false);
						this.NetworkManager.PrefabHandler.HandleNetworkPrefabDestroy(array[i]);
					}
					else
					{
						bool flag = array[i].IsSceneObject != null && (array[i].IsSceneObject == null || !array[i].IsSceneObject.Value);
						if (flag)
						{
							foreach (NetworkObject networkObject in array[i].GetComponentsInChildren<NetworkObject>())
							{
								if (!(networkObject == array[i]) && networkObject.IsSceneObject != null && networkObject.IsSceneObject.Value)
								{
									networkObject.TryRemoveParent(networkObject.WorldPositionStays());
								}
							}
						}
						if (array[i].IsSpawned)
						{
							this.OnDespawnObject(array[i], flag);
						}
						else if (flag)
						{
							Object.Destroy(array[i].gameObject);
						}
					}
				}
			}
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x00021AC0 File Offset: 0x0001FCC0
		internal void DestroySceneObjects()
		{
			NetworkObject[] array = Object.FindObjectsOfType<NetworkObject>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].NetworkManager == this.NetworkManager && (array[i].IsSceneObject == null || array[i].IsSceneObject.Value))
				{
					if (this.NetworkManager.PrefabHandler.ContainsHandler(array[i]))
					{
						this.NetworkManager.PrefabHandler.HandleNetworkPrefabDestroy(array[i]);
						if (this.SpawnedObjects.ContainsKey(array[i].NetworkObjectId))
						{
							this.OnDespawnObject(array[i], false);
						}
					}
					else
					{
						Object.Destroy(array[i].gameObject);
					}
				}
			}
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x00021B78 File Offset: 0x0001FD78
		internal void ServerSpawnSceneObjectsOnStartSweep()
		{
			NetworkObject[] array = Object.FindObjectsOfType<NetworkObject>();
			List<NetworkObject> list = new List<NetworkObject>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].NetworkManager == this.NetworkManager && (array[i].IsSceneObject == null || (array[i].IsSceneObject != null && array[i].IsSceneObject.Value)))
				{
					list.Add(array[i]);
				}
			}
			foreach (NetworkObject networkObject in list)
			{
				this.SpawnNetworkObjectLocally(networkObject, this.GetNetworkObjectId(), true, false, networkObject.OwnerClientId, true);
			}
			foreach (NetworkObject networkObject2 in list)
			{
				networkObject2.InternalInSceneNetworkObjectsSpawned();
			}
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x00021C84 File Offset: 0x0001FE84
		internal void OnDespawnObject(NetworkObject networkObject, bool destroyGameObject)
		{
			if (this.NetworkManager == null)
			{
				return;
			}
			if (networkObject == null)
			{
				Debug.LogWarning("Trying to destroy network object but it is null");
				return;
			}
			if (!this.SpawnedObjects.ContainsKey(networkObject.NetworkObjectId))
			{
				Debug.LogWarning(string.Format("Trying to destroy object {0} but it doesn't seem to exist anymore!", networkObject.NetworkObjectId));
				return;
			}
			if (!this.NetworkManager.ShutdownInProgress && this.NetworkManager.IsServer)
			{
				foreach (NetworkObject networkObject2 in this.SpawnedObjectsList)
				{
					ulong? networkParenting = networkObject2.GetNetworkParenting();
					if (networkParenting != null && networkParenting.Value == networkObject.NetworkObjectId)
					{
						if (!networkObject2.TryRemoveParentCachedWorldPositionStays() && NetworkLog.CurrentLogLevel <= LogLevel.Normal)
						{
							NetworkLog.LogError(string.Format("{0} #{1} could not be moved to the root when its parent {2} #{3} was being destroyed", new object[]
							{
								"NetworkObject",
								networkObject2.NetworkObjectId,
								"NetworkObject",
								networkObject.NetworkObjectId
							}));
						}
						if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
						{
							NetworkLog.LogWarning(string.Format("{0} #{1} moved to the root because its parent {2} #{3} is destroyed", new object[]
							{
								"NetworkObject",
								networkObject2.NetworkObjectId,
								"NetworkObject",
								networkObject.NetworkObjectId
							}));
						}
					}
				}
			}
			networkObject.InvokeBehaviourNetworkDespawn();
			if (this.NetworkManager != null && this.NetworkManager.IsServer)
			{
				if (this.NetworkManager.NetworkConfig.RecycleNetworkIds)
				{
					this.ReleasedNetworkObjectIds.Enqueue(new ReleasedNetworkId
					{
						NetworkId = networkObject.NetworkObjectId,
						ReleaseTime = this.NetworkManager.RealTimeProvider.UnscaledTime
					});
				}
				if (networkObject != null && this.NetworkManager.ConnectedClientsList.Count > 0)
				{
					this.m_TargetClientIds.Clear();
					foreach (ulong num in this.NetworkManager.ConnectedClientsIds)
					{
						if (networkObject.IsNetworkVisibleTo(num))
						{
							this.m_TargetClientIds.Add(num);
						}
					}
					DestroyObjectMessage destroyObjectMessage = default(DestroyObjectMessage);
					destroyObjectMessage.NetworkObjectId = networkObject.NetworkObjectId;
					bool? isSceneObject = networkObject.IsSceneObject;
					bool flag = false;
					destroyObjectMessage.DestroyGameObject = ((isSceneObject.GetValueOrDefault() == flag & isSceneObject != null) || destroyGameObject);
					DestroyObjectMessage destroyObjectMessage2 = destroyObjectMessage;
					int num2 = this.NetworkManager.ConnectionManager.SendMessage<DestroyObjectMessage, List<ulong>>(ref destroyObjectMessage2, NetworkDelivery.ReliableSequenced, this.m_TargetClientIds);
					foreach (ulong receiverClientId in this.m_TargetClientIds)
					{
						this.NetworkManager.NetworkMetrics.TrackObjectDestroySent(receiverClientId, networkObject, (long)num2);
					}
				}
			}
			networkObject.IsSpawned = false;
			if (this.SpawnedObjects.Remove(networkObject.NetworkObjectId))
			{
				this.SpawnedObjectsList.Remove(networkObject);
			}
			networkObject.Observers.Clear();
			GameObject gameObject = networkObject.gameObject;
			if (destroyGameObject && gameObject != null)
			{
				if (this.NetworkManager.PrefabHandler.ContainsHandler(networkObject))
				{
					this.NetworkManager.PrefabHandler.HandleNetworkPrefabDestroy(networkObject);
					return;
				}
				Object.Destroy(gameObject);
			}
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x00022020 File Offset: 0x00020220
		internal void UpdateObservedNetworkObjects(ulong clientId)
		{
			foreach (NetworkObject networkObject in this.SpawnedObjectsList)
			{
				if (networkObject.CheckObjectVisibility == null)
				{
					if (networkObject.SpawnWithObservers || clientId == 0UL)
					{
						networkObject.Observers.Add(clientId);
					}
				}
				else if (networkObject.CheckObjectVisibility(clientId))
				{
					networkObject.Observers.Add(clientId);
				}
				else
				{
					networkObject.Observers.Remove(clientId);
				}
			}
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x000220B8 File Offset: 0x000202B8
		internal void HandleNetworkObjectShow()
		{
			foreach (KeyValuePair<ulong, List<NetworkObject>> keyValuePair in this.ObjectsToShowToClient)
			{
				ulong key = keyValuePair.Key;
				foreach (NetworkObject networkObject in keyValuePair.Value)
				{
					if (networkObject != null && networkObject.IsSpawned)
					{
						try
						{
							this.SendSpawnCallForObject(key, networkObject);
						}
						catch (Exception exception)
						{
							if (this.NetworkManager.LogLevel <= LogLevel.Developer)
							{
								Debug.LogException(exception);
							}
						}
					}
				}
			}
			this.ObjectsToShowToClient.Clear();
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x0002219C File Offset: 0x0002039C
		internal NetworkSpawnManager(NetworkManager networkManager)
		{
			this.NetworkManager = networkManager;
		}

		// Token: 0x04000336 RID: 822
		internal Dictionary<ulong, List<NetworkObject>> ObjectsToShowToClient = new Dictionary<ulong, List<NetworkObject>>();

		// Token: 0x04000337 RID: 823
		public readonly Dictionary<ulong, NetworkObject> SpawnedObjects = new Dictionary<ulong, NetworkObject>();

		// Token: 0x04000338 RID: 824
		public readonly HashSet<NetworkObject> SpawnedObjectsList = new HashSet<NetworkObject>();

		// Token: 0x04000339 RID: 825
		public readonly Dictionary<ulong, Dictionary<ulong, NetworkObject>> OwnershipToObjectsTable = new Dictionary<ulong, Dictionary<ulong, NetworkObject>>();

		// Token: 0x0400033A RID: 826
		private Dictionary<ulong, ulong> m_ObjectToOwnershipTable = new Dictionary<ulong, ulong>();

		// Token: 0x0400033C RID: 828
		internal readonly Queue<ReleasedNetworkId> ReleasedNetworkObjectIds = new Queue<ReleasedNetworkId>();

		// Token: 0x0400033D RID: 829
		private ulong m_NetworkObjectIdCounter;

		// Token: 0x0400033E RID: 830
		private List<ulong> m_TargetClientIds = new List<ulong>();

		// Token: 0x0400033F RID: 831
		private Dictionary<ulong, float> m_LastChangeInOwnership = new Dictionary<ulong, float>();

		// Token: 0x04000340 RID: 832
		private const int k_MaximumTickOwnershipChangeMultiplier = 6;

		// Token: 0x04000341 RID: 833
		internal static readonly Dictionary<NetworkSpawnManager.InstantiateAndSpawnErrorTypes, string> InstantiateAndSpawnErrors = new Dictionary<NetworkSpawnManager.InstantiateAndSpawnErrorTypes, string>(new KeyValuePair<NetworkSpawnManager.InstantiateAndSpawnErrorTypes, string>[]
		{
			new KeyValuePair<NetworkSpawnManager.InstantiateAndSpawnErrorTypes, string>(NetworkSpawnManager.InstantiateAndSpawnErrorTypes.NetworkPrefabNull, "The NetworkObject prefab parameter was null!"),
			new KeyValuePair<NetworkSpawnManager.InstantiateAndSpawnErrorTypes, string>(NetworkSpawnManager.InstantiateAndSpawnErrorTypes.NotAuthority, "Only the server has authority to InstantiateAndSpawn!"),
			new KeyValuePair<NetworkSpawnManager.InstantiateAndSpawnErrorTypes, string>(NetworkSpawnManager.InstantiateAndSpawnErrorTypes.InvokedWhenShuttingDown, "Invoking InstantiateAndSpawn while shutting down! Calls to InstantiateAndSpawn will be ignored."),
			new KeyValuePair<NetworkSpawnManager.InstantiateAndSpawnErrorTypes, string>(NetworkSpawnManager.InstantiateAndSpawnErrorTypes.NotRegisteredNetworkPrefab, "The NetworkObject parameter is not a registered network prefab. Did you forget to register it or are you trying to instantiate and spawn an instance of a network prefab?"),
			new KeyValuePair<NetworkSpawnManager.InstantiateAndSpawnErrorTypes, string>(NetworkSpawnManager.InstantiateAndSpawnErrorTypes.NetworkManagerNull, "The NetworkManager parameter was null!"),
			new KeyValuePair<NetworkSpawnManager.InstantiateAndSpawnErrorTypes, string>(NetworkSpawnManager.InstantiateAndSpawnErrorTypes.NoActiveSession, "You can only invoke this method when you are connected to an existing/in-progress network session!")
		});

		// Token: 0x02000115 RID: 277
		internal enum InstantiateAndSpawnErrorTypes
		{
			// Token: 0x04000343 RID: 835
			NetworkPrefabNull,
			// Token: 0x04000344 RID: 836
			NotAuthority,
			// Token: 0x04000345 RID: 837
			InvokedWhenShuttingDown,
			// Token: 0x04000346 RID: 838
			NotRegisteredNetworkPrefab,
			// Token: 0x04000347 RID: 839
			NetworkManagerNull,
			// Token: 0x04000348 RID: 840
			NoActiveSession
		}
	}
}
