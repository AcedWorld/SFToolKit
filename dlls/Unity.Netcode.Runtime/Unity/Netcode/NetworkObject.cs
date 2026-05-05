using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.Netcode
{
	// Token: 0x02000028 RID: 40
	[AddComponentMenu("Netcode/Network Object", -99)]
	[DisallowMultipleComponent]
	public sealed class NetworkObject : MonoBehaviour
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000161 RID: 353 RVA: 0x00007E51 File Offset: 0x00006051
		[HideInInspector]
		public uint PrefabIdHash
		{
			get
			{
				return this.GlobalObjectIdHash;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00007E59 File Offset: 0x00006059
		public NetworkManager NetworkManager
		{
			get
			{
				return this.NetworkManagerOwner ?? NetworkManager.Singleton;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00007E6A File Offset: 0x0000606A
		// (set) Token: 0x06000164 RID: 356 RVA: 0x00007E72 File Offset: 0x00006072
		public ulong NetworkObjectId { get; internal set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00007E7B File Offset: 0x0000607B
		// (set) Token: 0x06000166 RID: 358 RVA: 0x00007E83 File Offset: 0x00006083
		public ulong OwnerClientId { get; internal set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00007E8C File Offset: 0x0000608C
		// (set) Token: 0x06000168 RID: 360 RVA: 0x00007E94 File Offset: 0x00006094
		public bool IsPlayerObject { get; internal set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000169 RID: 361 RVA: 0x00007E9D File Offset: 0x0000609D
		public bool IsLocalPlayer
		{
			get
			{
				return this.NetworkManager != null && this.IsPlayerObject && this.OwnerClientId == this.NetworkManager.LocalClientId;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600016A RID: 362 RVA: 0x00007ECA File Offset: 0x000060CA
		public bool IsOwner
		{
			get
			{
				return this.NetworkManager != null && this.OwnerClientId == this.NetworkManager.LocalClientId;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00007EEF File Offset: 0x000060EF
		public bool IsOwnedByServer
		{
			get
			{
				return this.NetworkManager != null && this.OwnerClientId == 0UL;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600016C RID: 364 RVA: 0x00007F0B File Offset: 0x0000610B
		// (set) Token: 0x0600016D RID: 365 RVA: 0x00007F13 File Offset: 0x00006113
		public bool IsSpawned { get; internal set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00007F1C File Offset: 0x0000611C
		// (set) Token: 0x0600016F RID: 367 RVA: 0x00007F24 File Offset: 0x00006124
		public bool? IsSceneObject { get; internal set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000170 RID: 368 RVA: 0x00007F2D File Offset: 0x0000612D
		// (set) Token: 0x06000171 RID: 369 RVA: 0x00007F35 File Offset: 0x00006135
		public bool DestroyWithScene { get; set; }

		// Token: 0x06000172 RID: 370 RVA: 0x00007F40 File Offset: 0x00006140
		internal string GetNameForMetrics()
		{
			string result;
			if ((result = this.m_CachedNameForMetrics) == null)
			{
				result = (this.m_CachedNameForMetrics = base.name);
			}
			return result;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00007F66 File Offset: 0x00006166
		public HashSet<ulong>.Enumerator GetObservers()
		{
			if (!this.IsSpawned)
			{
				return this.m_EmptyULongHashSet.GetEnumerator();
			}
			return this.Observers.GetEnumerator();
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00007F87 File Offset: 0x00006187
		public bool IsNetworkVisibleTo(ulong clientId)
		{
			return this.IsSpawned && this.Observers.Contains(clientId);
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000175 RID: 373 RVA: 0x00007F9F File Offset: 0x0000619F
		// (set) Token: 0x06000176 RID: 374 RVA: 0x00007FA7 File Offset: 0x000061A7
		internal Scene SceneOrigin
		{
			get
			{
				return this.m_SceneOrigin;
			}
			set
			{
				if (this.SceneOriginHandle == 0 && value.IsValid() && value.isLoaded)
				{
					this.m_SceneOrigin = value;
					this.SceneOriginHandle = value.handle;
				}
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00007FD8 File Offset: 0x000061D8
		internal int GetSceneOriginHandle()
		{
			if (this.SceneOriginHandle == 0 && this.IsSpawned)
			{
				bool? isSceneObject = this.IsSceneObject;
				bool flag = false;
				if (!(isSceneObject.GetValueOrDefault() == flag & isSceneObject != null))
				{
					throw new Exception("GetSceneOriginHandle called when SceneOriginHandle is still zero but the NetworkObject is already spawned!");
				}
			}
			if (this.SceneOriginHandle == 0)
			{
				return base.gameObject.scene.handle;
			}
			return this.SceneOriginHandle;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000803F File Offset: 0x0000623F
		private void Awake()
		{
			this.m_ChildNetworkBehaviours = null;
			this.SetCachedParent(base.transform.parent);
			this.SceneOrigin = base.gameObject.scene;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000806C File Offset: 0x0000626C
		public void NetworkShow(ulong clientId)
		{
			if (!this.IsSpawned)
			{
				throw new SpawnStateException("Object is not spawned");
			}
			if (!this.NetworkManager.IsServer)
			{
				throw new NotServerException("Only server can change visibility");
			}
			if (this.Observers.Contains(clientId))
			{
				throw new VisibilityChangeException("The object is already visible");
			}
			if (this.CheckObjectVisibility != null && !this.CheckObjectVisibility(clientId))
			{
				if (this.NetworkManager.LogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning(string.Format("[NetworkShow] Trying to make {0} {1} visible to client ({2}) but {3} returned false!", new object[]
					{
						"NetworkObject",
						base.gameObject.name,
						clientId,
						"CheckObjectVisibility"
					}));
				}
				return;
			}
			this.NetworkManager.SpawnManager.MarkObjectForShowingTo(this, clientId);
			this.Observers.Add(clientId);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00008140 File Offset: 0x00006340
		public static void NetworkShow(List<NetworkObject> networkObjects, ulong clientId)
		{
			if (networkObjects == null || networkObjects.Count == 0)
			{
				throw new ArgumentNullException("At least one NetworkObject has to be provided");
			}
			NetworkManager networkManager = networkObjects[0].NetworkManager;
			if (!networkManager.IsServer)
			{
				throw new NotServerException("Only server can change visibility");
			}
			for (int i = 0; i < networkObjects.Count; i++)
			{
				if (!networkObjects[i].IsSpawned)
				{
					throw new SpawnStateException("Object is not spawned");
				}
				if (networkObjects[i].Observers.Contains(clientId))
				{
					throw new VisibilityChangeException(string.Format("{0} with NetworkId: {1} is already visible", "NetworkObject", networkObjects[i].NetworkObjectId));
				}
				if (networkObjects[i].NetworkManager != networkManager)
				{
					throw new ArgumentNullException("All NetworkObjects must belong to the same NetworkManager");
				}
			}
			foreach (NetworkObject networkObject in networkObjects)
			{
				networkObject.NetworkShow(clientId);
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00008248 File Offset: 0x00006448
		public void NetworkHide(ulong clientId)
		{
			if (!this.IsSpawned)
			{
				throw new SpawnStateException("Object is not spawned");
			}
			if (!this.NetworkManager.IsServer)
			{
				throw new NotServerException("Only server can change visibility");
			}
			if (clientId == 0UL)
			{
				throw new VisibilityChangeException("Cannot hide an object from the server");
			}
			if (!this.NetworkManager.SpawnManager.RemoveObjectFromShowingTo(this, clientId))
			{
				if (!this.Observers.Contains(clientId))
				{
					throw new VisibilityChangeException("The object is already hidden");
				}
				this.Observers.Remove(clientId);
				DestroyObjectMessage destroyObjectMessage = new DestroyObjectMessage
				{
					NetworkObjectId = this.NetworkObjectId,
					DestroyGameObject = !this.IsSceneObject.Value
				};
				int num = this.NetworkManager.ConnectionManager.SendMessage<DestroyObjectMessage>(ref destroyObjectMessage, NetworkDelivery.ReliableSequenced, clientId);
				this.NetworkManager.NetworkMetrics.TrackObjectDestroySent(clientId, this, (long)num);
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00008320 File Offset: 0x00006520
		public static void NetworkHide(List<NetworkObject> networkObjects, ulong clientId)
		{
			if (networkObjects == null || networkObjects.Count == 0)
			{
				throw new ArgumentNullException("At least one NetworkObject has to be provided");
			}
			NetworkManager networkManager = networkObjects[0].NetworkManager;
			if (!networkManager.IsServer)
			{
				throw new NotServerException("Only server can change visibility");
			}
			if (clientId == 0UL)
			{
				throw new VisibilityChangeException("Cannot hide an object from the server");
			}
			for (int i = 0; i < networkObjects.Count; i++)
			{
				if (!networkObjects[i].IsSpawned)
				{
					throw new SpawnStateException("Object is not spawned");
				}
				if (!networkObjects[i].Observers.Contains(clientId))
				{
					throw new VisibilityChangeException(string.Format("{0} with {1}: {2} is already hidden", "NetworkObject", "NetworkObjectId", networkObjects[i].NetworkObjectId));
				}
				if (networkObjects[i].NetworkManager != networkManager)
				{
					throw new ArgumentNullException("All NetworkObjects must belong to the same NetworkManager");
				}
			}
			foreach (NetworkObject networkObject in networkObjects)
			{
				networkObject.NetworkHide(clientId);
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000843C File Offset: 0x0000663C
		private void OnDestroy()
		{
			if (!this.NetworkManager)
			{
				return;
			}
			if (this.NetworkManager.IsListening && !this.NetworkManager.IsServer && this.IsSpawned && (this.IsSceneObject == null || !this.IsSceneObject.Value) && !this.NetworkManager.ShutdownInProgress)
			{
				if (this.NetworkManager.LogLevel <= LogLevel.Error)
				{
					NetworkLog.LogErrorServer(string.Format("[Invalid Destroy][{0}][NetworkObjectId:{1}] Destroy a spawned {2} on a non-host client is not valid. Call {3} or {4} on the server/host instead.", new object[]
					{
						base.gameObject.name,
						this.NetworkObjectId,
						"NetworkObject",
						"Destroy",
						"Despawn"
					}));
				}
				return;
			}
			NetworkObject networkObject;
			if (this.NetworkManager.SpawnManager != null && this.NetworkManager.SpawnManager.SpawnedObjects.TryGetValue(this.NetworkObjectId, out networkObject) && this == networkObject)
			{
				this.NetworkManager.SpawnManager.OnDespawnObject(networkObject, false);
			}
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00008550 File Offset: 0x00006750
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void SpawnInternal(bool destroyWithScene, ulong ownerClientId, bool playerObject)
		{
			if (!this.NetworkManager.IsListening)
			{
				throw new NotListeningException("NetworkManager is not listening, start a server or host before spawning objects");
			}
			if (!this.NetworkManager.IsServer)
			{
				throw new NotServerException("Only server can spawn NetworkObjects");
			}
			this.NetworkManager.SpawnManager.SpawnNetworkObjectLocally(this, this.NetworkManager.SpawnManager.GetNetworkObjectId(), this.IsSceneObject != null && this.IsSceneObject.Value, playerObject, ownerClientId, destroyWithScene);
			for (int i = 0; i < this.NetworkManager.ConnectedClientsList.Count; i++)
			{
				if (this.Observers.Contains(this.NetworkManager.ConnectedClientsList[i].ClientId))
				{
					this.NetworkManager.SpawnManager.SendSpawnCallForObject(this.NetworkManager.ConnectedClientsList[i].ClientId, this);
				}
			}
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00008638 File Offset: 0x00006838
		public static NetworkObject InstantiateAndSpawn(GameObject networkPrefab, NetworkManager networkManager, ulong ownerClientId = 0UL, bool destroyWithScene = false, bool isPlayerObject = false, bool forceOverride = false, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion))
		{
			NetworkObject component = networkPrefab.GetComponent<NetworkObject>();
			if (component == null)
			{
				Debug.LogError("The NetworkPrefab " + networkPrefab.name + " does not have a NetworkObject component!");
				return null;
			}
			return component.InstantiateAndSpawn(networkManager, ownerClientId, destroyWithScene, isPlayerObject, forceOverride, position, rotation);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00008684 File Offset: 0x00006884
		public NetworkObject InstantiateAndSpawn(NetworkManager networkManager, ulong ownerClientId = 0UL, bool destroyWithScene = false, bool isPlayerObject = false, bool forceOverride = false, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion))
		{
			if (networkManager == null)
			{
				Debug.LogError(NetworkSpawnManager.InstantiateAndSpawnErrors[NetworkSpawnManager.InstantiateAndSpawnErrorTypes.NetworkManagerNull]);
				return null;
			}
			if (!networkManager.IsListening)
			{
				Debug.LogError(NetworkSpawnManager.InstantiateAndSpawnErrors[NetworkSpawnManager.InstantiateAndSpawnErrorTypes.NoActiveSession]);
				return null;
			}
			if (!networkManager.IsServer)
			{
				Debug.LogError(NetworkSpawnManager.InstantiateAndSpawnErrors[NetworkSpawnManager.InstantiateAndSpawnErrorTypes.NotAuthority]);
				return null;
			}
			if (this.NetworkManager.ShutdownInProgress)
			{
				Debug.LogWarning(NetworkSpawnManager.InstantiateAndSpawnErrors[NetworkSpawnManager.InstantiateAndSpawnErrorTypes.InvokedWhenShuttingDown]);
				return null;
			}
			if (!this.NetworkManager.NetworkConfig.Prefabs.Contains(base.gameObject))
			{
				Debug.LogError(NetworkSpawnManager.InstantiateAndSpawnErrors[NetworkSpawnManager.InstantiateAndSpawnErrorTypes.NotRegisteredNetworkPrefab]);
				return null;
			}
			return this.NetworkManager.SpawnManager.InstantiateAndSpawnNoParameterChecks(this, ownerClientId, destroyWithScene, isPlayerObject, forceOverride, position, rotation);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00008749 File Offset: 0x00006949
		public void Spawn(bool destroyWithScene = false)
		{
			this.SpawnInternal(destroyWithScene, 0UL, false);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00008755 File Offset: 0x00006955
		public void SpawnWithOwnership(ulong clientId, bool destroyWithScene = false)
		{
			this.SpawnInternal(destroyWithScene, clientId, false);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00008760 File Offset: 0x00006960
		public void SpawnAsPlayerObject(ulong clientId, bool destroyWithScene = false)
		{
			this.SpawnInternal(destroyWithScene, clientId, true);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000876B File Offset: 0x0000696B
		public void Despawn(bool destroy = true)
		{
			this.MarkVariablesDirty(false);
			this.NetworkManager.SpawnManager.DespawnObject(this, destroy);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00008786 File Offset: 0x00006986
		public void RemoveOwnership()
		{
			this.NetworkManager.SpawnManager.RemoveOwnership(this);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00008799 File Offset: 0x00006999
		public void ChangeOwnership(ulong newOwnerClientId)
		{
			this.NetworkManager.SpawnManager.ChangeOwnership(this, newOwnerClientId);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x000087B0 File Offset: 0x000069B0
		internal void InvokeBehaviourOnLostOwnership()
		{
			if (!this.NetworkManager.IsServer)
			{
				this.NetworkManager.SpawnManager.UpdateOwnershipTable(this, this.OwnerClientId, true);
			}
			for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
			{
				this.ChildNetworkBehaviours[i].InternalOnLostOwnership();
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000880C File Offset: 0x00006A0C
		internal void InvokeBehaviourOnGainedOwnership()
		{
			if (!this.NetworkManager.IsServer && this.NetworkManager.LocalClientId == this.OwnerClientId)
			{
				this.NetworkManager.SpawnManager.UpdateOwnershipTable(this, this.OwnerClientId, false);
			}
			for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
			{
				if (this.ChildNetworkBehaviours[i].gameObject.activeInHierarchy)
				{
					this.ChildNetworkBehaviours[i].InternalOnGainedOwnership();
				}
				else
				{
					Debug.LogWarning(this.ChildNetworkBehaviours[i].gameObject.name + " is disabled! Netcode for GameObjects does not support disabled NetworkBehaviours! The " + this.ChildNetworkBehaviours[i].GetType().Name + " component was skipped during ownership assignment!");
				}
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000088D4 File Offset: 0x00006AD4
		internal void InvokeOwnershipChanged(ulong previous, ulong next)
		{
			for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
			{
				if (this.ChildNetworkBehaviours[i].gameObject.activeInHierarchy)
				{
					this.ChildNetworkBehaviours[i].InternalOnOwnershipChanged(previous, next);
				}
				else
				{
					Debug.LogWarning(this.ChildNetworkBehaviours[i].gameObject.name + " is disabled! Netcode for GameObjects does not support disabled NetworkBehaviours! The " + this.ChildNetworkBehaviours[i].GetType().Name + " component was skipped during ownership assignment!");
				}
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00008964 File Offset: 0x00006B64
		internal void InvokeBehaviourOnNetworkObjectParentChanged(NetworkObject parentNetworkObject)
		{
			for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
			{
				this.ChildNetworkBehaviours[i].OnNetworkObjectParentChanged(parentNetworkObject);
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00008999 File Offset: 0x00006B99
		public bool WorldPositionStays()
		{
			return this.m_CachedWorldPositionStays;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000089A1 File Offset: 0x00006BA1
		internal void SetCachedParent(Transform parentTransform)
		{
			this.m_CachedParent = parentTransform;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x000089AA File Offset: 0x00006BAA
		internal Transform GetCachedParent()
		{
			return this.m_CachedParent;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x000089B2 File Offset: 0x00006BB2
		internal ulong? GetNetworkParenting()
		{
			return this.m_LatestParent;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x000089BA File Offset: 0x00006BBA
		internal void SetNetworkParenting(ulong? latestParent, bool worldPositionStays)
		{
			this.m_LatestParent = latestParent;
			this.m_CachedWorldPositionStays = worldPositionStays;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x000089CC File Offset: 0x00006BCC
		public bool TrySetParent(Transform parent, bool worldPositionStays = true)
		{
			if (parent == null)
			{
				return this.TrySetParent(null, worldPositionStays);
			}
			NetworkObject component = parent.GetComponent<NetworkObject>();
			return !(component == null) && this.TrySetParent(component, worldPositionStays);
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00008A08 File Offset: 0x00006C08
		public bool TrySetParent(GameObject parent, bool worldPositionStays = true)
		{
			if (parent == null)
			{
				return this.TrySetParent(null, worldPositionStays);
			}
			NetworkObject component = parent.GetComponent<NetworkObject>();
			return !(component == null) && this.TrySetParent(component, worldPositionStays);
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00008A41 File Offset: 0x00006C41
		internal bool TryRemoveParentCachedWorldPositionStays()
		{
			return this.TrySetParent(null, this.m_CachedWorldPositionStays);
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00008A50 File Offset: 0x00006C50
		public bool TryRemoveParent(bool worldPositionStays = true)
		{
			return this.TrySetParent(null, worldPositionStays);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00008A5C File Offset: 0x00006C5C
		public bool TrySetParent(NetworkObject parent, bool worldPositionStays = true)
		{
			if (!this.AutoObjectParentSync)
			{
				return false;
			}
			if (this.NetworkManager == null || !this.NetworkManager.IsListening)
			{
				return false;
			}
			if (!this.NetworkManager.IsServer && !this.NetworkManager.ShutdownInProgress)
			{
				return false;
			}
			if (parent != null && (this.IsSpawned ^ parent.IsSpawned))
			{
				return false;
			}
			this.m_CachedWorldPositionStays = worldPositionStays;
			if (parent == null)
			{
				base.transform.SetParent(null, worldPositionStays);
			}
			else
			{
				base.transform.SetParent(parent.transform, worldPositionStays);
			}
			return true;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00008AF8 File Offset: 0x00006CF8
		private unsafe void OnTransformParentChanged()
		{
			if (!this.AutoObjectParentSync)
			{
				return;
			}
			if (base.transform.parent == this.m_CachedParent)
			{
				return;
			}
			if (this.NetworkManager == null || !this.NetworkManager.IsListening)
			{
				base.transform.parent = this.m_CachedParent;
				Debug.LogException(new NotListeningException("NetworkManager is not listening, start a server or host before reparenting"));
				return;
			}
			if (!this.NetworkManager.IsServer)
			{
				if (!this.NetworkManager.ShutdownInProgress)
				{
					base.transform.parent = this.m_CachedParent;
					Debug.LogException(new NotServerException("Only the server can reparent NetworkObjects"));
					return;
				}
				if (base.transform.parent == null)
				{
					this.m_LatestParent = null;
					this.m_CachedParent = null;
					this.InvokeBehaviourOnNetworkObjectParentChanged(null);
				}
				return;
			}
			else
			{
				if (this.IsSpawned)
				{
					bool removeParent = false;
					Transform parent = base.transform.parent;
					if (parent != null)
					{
						NetworkObject networkObject;
						if (!base.transform.parent.TryGetComponent<NetworkObject>(out networkObject))
						{
							base.transform.parent = this.m_CachedParent;
							Debug.LogException(new InvalidParentException("Invalid parenting, NetworkObject moved under a non-NetworkObject parent"));
							return;
						}
						if (!networkObject.IsSpawned)
						{
							base.transform.parent = this.m_CachedParent;
							Debug.LogException(new SpawnStateException("NetworkObject can only be reparented under another spawned NetworkObject"));
							return;
						}
						this.m_LatestParent = new ulong?(networkObject.NetworkObjectId);
					}
					else
					{
						this.m_LatestParent = null;
						removeParent = (this.m_CachedParent != null);
					}
					this.ApplyNetworkParenting(removeParent, false, false);
					ParentSyncMessage parentSyncMessage = new ParentSyncMessage
					{
						NetworkObjectId = this.NetworkObjectId,
						IsLatestParentSet = (this.m_LatestParent != null && this.m_LatestParent != null),
						LatestParent = this.m_LatestParent,
						RemoveParent = removeParent,
						WorldPositionStays = this.m_CachedWorldPositionStays,
						Position = (this.m_CachedWorldPositionStays ? base.transform.position : base.transform.localPosition),
						Rotation = (this.m_CachedWorldPositionStays ? base.transform.rotation : base.transform.localRotation),
						Scale = base.transform.localScale
					};
					if (parent == null)
					{
						this.m_CachedWorldPositionStays = true;
					}
					int count = this.NetworkManager.ConnectedClientsIds.Count;
					ulong* ptr = stackalloc ulong[checked(unchecked((UIntPtr)count) * 8)];
					int numClientIds = 0;
					foreach (ulong num in this.NetworkManager.ConnectedClientsIds)
					{
						if (this.Observers.Contains(num))
						{
							ptr[(IntPtr)(numClientIds++) * 8] = num;
						}
					}
					this.NetworkManager.ConnectionManager.SendMessage<ParentSyncMessage>(ref parentSyncMessage, NetworkDelivery.ReliableSequenced, ptr, numClientIds);
					return;
				}
				if (base.transform.parent == null)
				{
					this.m_LatestParent = null;
					this.m_CachedParent = null;
					this.InvokeBehaviourOnNetworkObjectParentChanged(null);
					return;
				}
				base.transform.parent = this.m_CachedParent;
				Debug.LogException(new SpawnStateException("NetworkObject can only be reparented after being spawned"));
				return;
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00008E34 File Offset: 0x00007034
		internal bool ApplyNetworkParenting(bool removeParent = false, bool ignoreNotSpawned = false, bool orphanedChildPass = false)
		{
			if (!this.AutoObjectParentSync)
			{
				return false;
			}
			if (!this.IsSpawned && !ignoreNotSpawned)
			{
				return false;
			}
			bool flag = this.IsSceneObject != null && this.IsSceneObject.Value;
			if (base.transform.parent != null && !removeParent && this.m_LatestParent == null && flag)
			{
				NetworkObject component = base.transform.parent.GetComponent<NetworkObject>();
				if (component == null)
				{
					this.m_CachedWorldPositionStays = false;
					return true;
				}
				if (!component.IsSpawned)
				{
					NetworkObject.OrphanChildren.Add(this);
					return false;
				}
				this.SetNetworkParenting(new ulong?(component.NetworkObjectId), false);
				this.m_CachedParent = component.transform;
				return true;
			}
			else
			{
				if (removeParent || this.m_LatestParent == null)
				{
					this.m_CachedParent = null;
					base.transform.SetParent(null, this.m_CachedWorldPositionStays);
					this.InvokeBehaviourOnNetworkObjectParentChanged(null);
					return true;
				}
				if (this.m_LatestParent != null && !this.NetworkManager.SpawnManager.SpawnedObjects.ContainsKey(this.m_LatestParent.Value))
				{
					NetworkObject.OrphanChildren.Add(this);
					return false;
				}
				NetworkObject networkObject = this.NetworkManager.SpawnManager.SpawnedObjects[this.m_LatestParent.Value];
				if (orphanedChildPass && NetworkObject.OrphanChildren.Contains(networkObject))
				{
					return false;
				}
				this.m_CachedParent = networkObject.transform;
				base.transform.SetParent(networkObject.transform, this.m_CachedWorldPositionStays);
				this.InvokeBehaviourOnNetworkObjectParentChanged(networkObject);
				return true;
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00008FCC File Offset: 0x000071CC
		internal static void CheckOrphanChildren()
		{
			List<NetworkObject> list = new List<NetworkObject>();
			foreach (NetworkObject networkObject in NetworkObject.OrphanChildren)
			{
				if (networkObject.ApplyNetworkParenting(false, false, true))
				{
					list.Add(networkObject);
				}
			}
			foreach (NetworkObject item in list)
			{
				NetworkObject.OrphanChildren.Remove(item);
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00009074 File Offset: 0x00007274
		internal void InvokeBehaviourNetworkPreSpawn()
		{
			NetworkManager networkManager = this.NetworkManager;
			for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
			{
				if (this.ChildNetworkBehaviours[i].gameObject.activeInHierarchy)
				{
					this.ChildNetworkBehaviours[i].NetworkPreSpawn(ref networkManager);
				}
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000090CC File Offset: 0x000072CC
		internal void InvokeBehaviourNetworkSpawn()
		{
			this.NetworkManager.SpawnManager.UpdateOwnershipTable(this, this.OwnerClientId, false);
			for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
			{
				if (this.ChildNetworkBehaviours[i].gameObject.activeInHierarchy)
				{
					this.ChildNetworkBehaviours[i].InternalOnNetworkSpawn();
				}
				else
				{
					Debug.LogWarning(this.ChildNetworkBehaviours[i].gameObject.name + " is disabled! Netcode for GameObjects does not support spawning disabled NetworkBehaviours! The " + this.ChildNetworkBehaviours[i].GetType().Name + " component was skipped during spawn!");
				}
			}
			for (int j = 0; j < this.ChildNetworkBehaviours.Count; j++)
			{
				if (this.ChildNetworkBehaviours[j].gameObject.activeInHierarchy)
				{
					this.ChildNetworkBehaviours[j].VisibleOnNetworkSpawn();
				}
			}
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000091B4 File Offset: 0x000073B4
		internal void InvokeBehaviourNetworkPostSpawn()
		{
			for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
			{
				if (this.ChildNetworkBehaviours[i].gameObject.activeInHierarchy)
				{
					this.ChildNetworkBehaviours[i].NetworkPostSpawn();
				}
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00009200 File Offset: 0x00007400
		internal void InternalNetworkSessionSynchronized()
		{
			for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
			{
				if (this.ChildNetworkBehaviours[i].gameObject.activeInHierarchy)
				{
					this.ChildNetworkBehaviours[i].NetworkSessionSynchronized();
				}
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0000924C File Offset: 0x0000744C
		internal void InternalInSceneNetworkObjectsSpawned()
		{
			for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
			{
				if (this.ChildNetworkBehaviours[i].gameObject.activeInHierarchy)
				{
					this.ChildNetworkBehaviours[i].InSceneNetworkObjectsSpawned();
				}
			}
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00009298 File Offset: 0x00007498
		internal void InvokeBehaviourNetworkDespawn()
		{
			this.NetworkManager.SpawnManager.UpdateOwnershipTable(this, this.OwnerClientId, true);
			for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
			{
				this.ChildNetworkBehaviours[i].InternalOnNetworkDespawn();
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600019E RID: 414 RVA: 0x000092E4 File Offset: 0x000074E4
		internal List<NetworkBehaviour> ChildNetworkBehaviours
		{
			get
			{
				if (this.m_ChildNetworkBehaviours != null)
				{
					return this.m_ChildNetworkBehaviours;
				}
				this.m_ChildNetworkBehaviours = new List<NetworkBehaviour>();
				NetworkBehaviour[] componentsInChildren = base.GetComponentsInChildren<NetworkBehaviour>(true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					if (componentsInChildren[i].NetworkObject == this)
					{
						this.m_ChildNetworkBehaviours.Add(componentsInChildren[i]);
					}
				}
				return this.m_ChildNetworkBehaviours;
			}
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00009348 File Offset: 0x00007548
		internal void WriteNetworkVariableData(FastBufferWriter writer, ulong targetClientId)
		{
			for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
			{
				NetworkBehaviour networkBehaviour = this.ChildNetworkBehaviours[i];
				networkBehaviour.InitializeVariables();
				networkBehaviour.WriteNetworkVariableData(writer, targetClientId);
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00009384 File Offset: 0x00007584
		internal void MarkVariablesDirty(bool dirty)
		{
			for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
			{
				this.ChildNetworkBehaviours[i].MarkVariablesDirty(dirty);
			}
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x000093BC File Offset: 0x000075BC
		internal void MarkOwnerReadVariablesDirty()
		{
			for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
			{
				this.ChildNetworkBehaviours[i].MarkOwnerReadVariablesDirty();
			}
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x000093F0 File Offset: 0x000075F0
		internal static void VerifyParentingStatus()
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Normal && NetworkObject.OrphanChildren.Count > 0)
			{
				NetworkLog.LogWarning(string.Format("{0} ({1}) children not resolved to parents by the end of frame", "NetworkObject", NetworkObject.OrphanChildren.Count));
			}
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000942C File Offset: 0x0000762C
		internal void SetNetworkVariableData(FastBufferReader reader, ulong clientId)
		{
			for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
			{
				NetworkBehaviour networkBehaviour = this.ChildNetworkBehaviours[i];
				networkBehaviour.InitializeVariables();
				networkBehaviour.SetNetworkVariableData(reader, clientId);
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00009468 File Offset: 0x00007668
		internal ushort GetNetworkBehaviourOrderIndex(NetworkBehaviour instance)
		{
			if ((int)instance.NetworkBehaviourIdCache < this.ChildNetworkBehaviours.Count)
			{
				if (this.ChildNetworkBehaviours[(int)instance.NetworkBehaviourIdCache] == instance)
				{
					return instance.NetworkBehaviourIdCache;
				}
				instance.NetworkBehaviourIdCache = 0;
			}
			ushort num = 0;
			while ((int)num < this.ChildNetworkBehaviours.Count)
			{
				if (this.ChildNetworkBehaviours[(int)num] == instance)
				{
					instance.NetworkBehaviourIdCache = num;
					return num;
				}
				num += 1;
			}
			return 0;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x000094E4 File Offset: 0x000076E4
		public NetworkBehaviour GetNetworkBehaviourAtOrderIndex(ushort index)
		{
			if ((int)index >= this.ChildNetworkBehaviours.Count)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogError(string.Format("{0} index {1} was out of bounds for {2}. NetworkBehaviours must be the same, and in the same order, between server and client.", "NetworkBehaviour", index, base.name));
				}
				if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append("Known child NetworkBehaviours:");
					for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
					{
						NetworkBehaviour networkBehaviour = this.ChildNetworkBehaviours[i];
						stringBuilder.Append(string.Format(" [{0}] {1}", i, networkBehaviour.__getTypeName()));
						stringBuilder.Append((i < this.ChildNetworkBehaviours.Count - 1) ? "," : ".");
					}
					NetworkLog.LogInfo(stringBuilder.ToString());
				}
				return null;
			}
			return this.ChildNetworkBehaviours[(int)index];
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000095C4 File Offset: 0x000077C4
		internal void PostNetworkVariableWrite(bool forceSend)
		{
			for (int i = 0; i < this.ChildNetworkBehaviours.Count; i++)
			{
				this.ChildNetworkBehaviours[i].PostNetworkVariableWrite(forceSend);
			}
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000095FC File Offset: 0x000077FC
		internal void SynchronizeNetworkBehaviours<T>(ref BufferSerializer<T> serializer, ulong targetClientId = 0UL) where T : IReaderWriter
		{
			if (serializer.IsWriter)
			{
				FastBufferWriter fastBufferWriter = serializer.GetFastBufferWriter();
				int position = fastBufferWriter.Position;
				ushort num = 0;
				fastBufferWriter.WriteValueSafe<ushort>(num, default(FastBufferWriter.ForPrimitives));
				int position2 = fastBufferWriter.Position;
				this.WriteNetworkVariableData(fastBufferWriter, targetClientId);
				int position3 = fastBufferWriter.Position;
				byte b = 0;
				fastBufferWriter.WriteValueSafe<byte>(b, default(FastBufferWriter.ForPrimitives));
				byte b2 = 0;
				using (List<NetworkBehaviour>.Enumerator enumerator = this.ChildNetworkBehaviours.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Synchronize<T>(ref serializer, targetClientId))
						{
							b2 += 1;
						}
					}
				}
				int position4 = fastBufferWriter.Position;
				fastBufferWriter.Seek(position);
				ushort num2 = (ushort)(position4 - position2);
				fastBufferWriter.WriteValueSafe<ushort>(num2, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.Seek(position3);
				fastBufferWriter.WriteValueSafe<byte>(b2, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.Seek(position4);
				return;
			}
			FastBufferReader fastBufferReader = serializer.GetFastBufferReader();
			ushort num3;
			fastBufferReader.ReadValueSafe<ushort>(out num3, default(FastBufferWriter.ForPrimitives));
			int position5 = fastBufferReader.Position;
			this.SetNetworkVariableData(fastBufferReader, targetClientId);
			byte b3;
			fastBufferReader.ReadValueSafe<byte>(out b3, default(FastBufferWriter.ForPrimitives));
			ushort index = 0;
			for (int i = 0; i < (int)b3; i++)
			{
				serializer.SerializeValue<ushort>(ref index, default(FastBufferWriter.ForPrimitives));
				this.GetNetworkBehaviourAtOrderIndex(index).Synchronize<T>(ref serializer, targetClientId);
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00009780 File Offset: 0x00007980
		internal NetworkObject.SceneObject GetMessageSceneObject(ulong targetClientId)
		{
			NetworkObject.SceneObject result = new NetworkObject.SceneObject
			{
				NetworkObjectId = this.NetworkObjectId,
				OwnerClientId = this.OwnerClientId,
				IsPlayerObject = this.IsPlayerObject,
				IsSceneObject = (this.IsSceneObject ?? true),
				DestroyWithScene = this.DestroyWithScene,
				Hash = this.HostCheckForGlobalObjectIdHashOverride(),
				OwnerObject = this,
				TargetClientId = targetClientId
			};
			NetworkObject networkObject = null;
			if (!this.AlwaysReplicateAsRoot && base.transform.parent != null)
			{
				networkObject = base.transform.parent.GetComponent<NetworkObject>();
				if (networkObject == null && result.IsSceneObject)
				{
					result.HasParent = true;
					result.WorldPositionStays = this.m_CachedWorldPositionStays;
				}
			}
			if (networkObject != null)
			{
				result.HasParent = true;
				result.ParentObjectId = networkObject.NetworkObjectId;
				result.WorldPositionStays = this.m_CachedWorldPositionStays;
				ulong? networkParenting = this.GetNetworkParenting();
				bool flag = networkParenting != null && networkParenting != null;
				result.IsLatestParentSet = flag;
				if (flag)
				{
					result.LatestParent = new ulong?(networkParenting.Value);
				}
			}
			if (this.IncludeTransformWhenSpawning == null || this.IncludeTransformWhenSpawning(this.OwnerClientId))
			{
				result.HasTransform = this.SynchronizeTransform;
				bool flag2 = result.HasParent && !this.m_CachedWorldPositionStays;
				bool flag3 = result.HasParent && !this.m_CachedWorldPositionStays;
				if (result.IsSceneObject)
				{
					flag3 = result.HasParent;
				}
				if (!this.AutoObjectParentSync)
				{
					flag2 = false;
					flag3 = result.HasParent;
				}
				result.Transform = new NetworkObject.SceneObject.TransformData
				{
					Position = (flag2 ? base.transform.localPosition : base.transform.position),
					Rotation = (flag2 ? base.transform.localRotation : base.transform.rotation),
					Scale = (flag3 ? base.transform.localScale : base.transform.lossyScale)
				};
			}
			return result;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x000099C0 File Offset: 0x00007BC0
		internal static NetworkObject AddSceneObject(in NetworkObject.SceneObject sceneObject, FastBufferReader reader, NetworkManager networkManager)
		{
			NetworkObject networkObject = networkManager.SpawnManager.CreateLocalNetworkObject(sceneObject);
			if (networkObject == null)
			{
				if (networkManager.LogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogError(string.Format("Failed to spawn {0} for Hash {1}.", "NetworkObject", sceneObject.Hash));
				}
				try
				{
					ushort num;
					reader.ReadValueSafe<ushort>(out num, default(FastBufferWriter.ForPrimitives));
					reader.Seek(reader.Position + (int)num);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				return null;
			}
			networkObject.OwnerClientId = sceneObject.OwnerClientId;
			networkObject.InvokeBehaviourNetworkPreSpawn();
			BufferSerializer<BufferSerializerReader> bufferSerializer = new BufferSerializer<BufferSerializerReader>(new BufferSerializerReader(reader));
			networkObject.SynchronizeNetworkBehaviours<BufferSerializerReader>(ref bufferSerializer, networkManager.LocalClientId);
			NetworkSpawnManager spawnManager = networkManager.SpawnManager;
			NetworkObject networkObject2 = networkObject;
			NetworkObject.SceneObject sceneObject2 = sceneObject;
			spawnManager.SpawnNetworkObjectLocally(networkObject2, sceneObject, sceneObject2.DestroyWithScene);
			return networkObject;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00009A98 File Offset: 0x00007C98
		internal void SubscribeToActiveSceneForSynch()
		{
			if (this.ActiveSceneSynchronization && this.IsSceneObject != null && !this.IsSceneObject.Value)
			{
				SceneManager.activeSceneChanged -= this.CurrentlyActiveSceneChanged;
				SceneManager.activeSceneChanged += this.CurrentlyActiveSceneChanged;
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00009AF0 File Offset: 0x00007CF0
		private void CurrentlyActiveSceneChanged(Scene current, Scene next)
		{
			if (!(this.NetworkManager == null) && !this.NetworkManager.ShutdownInProgress && this.IsSpawned)
			{
				bool? isSceneObject = this.IsSceneObject;
				bool flag = false;
				if (isSceneObject.GetValueOrDefault() == flag & isSceneObject != null)
				{
					if (this.ActiveSceneSynchronization && this.IsSceneObject != null && !this.IsSceneObject.Value && base.gameObject.scene != next && base.gameObject.transform.parent == null)
					{
						SceneManager.MoveGameObjectToScene(base.gameObject, next);
						this.SceneChangedUpdate(next, false);
					}
					return;
				}
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00009BA8 File Offset: 0x00007DA8
		internal void SceneChangedUpdate(Scene scene, bool notify = false)
		{
			if (this.NetworkManager.SceneManager == null)
			{
				return;
			}
			this.SceneOriginHandle = scene.handle;
			if (!this.NetworkManager.IsServer && this.NetworkManager.SceneManager.ClientSceneHandleToServerSceneHandle.ContainsKey(this.SceneOriginHandle))
			{
				this.NetworkSceneHandle = this.NetworkManager.SceneManager.ClientSceneHandleToServerSceneHandle[this.SceneOriginHandle];
			}
			else if (this.NetworkManager.IsServer)
			{
				this.NetworkSceneHandle = this.SceneOriginHandle;
			}
			else if (this.NetworkManager.LogLevel == LogLevel.Developer)
			{
				NetworkLog.LogWarningServer(string.Format("[Client-{0}][{1}] Server - ", this.NetworkManager.LocalClientId, base.gameObject.name) + string.Format("client scene mismatch detected! Client-side scene handle ({0}) for scene ({1})", this.SceneOriginHandle, base.gameObject.scene.name) + "has no associated server side (network) scene handle!");
			}
			Action onMigratedToNewScene = this.OnMigratedToNewScene;
			if (onMigratedToNewScene != null)
			{
				onMigratedToNewScene();
			}
			if (this.NetworkManager.IsServer && notify && base.transform.parent == null)
			{
				this.NetworkManager.SceneManager.NotifyNetworkObjectSceneChanged(this);
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00009CE8 File Offset: 0x00007EE8
		private void Update()
		{
			if (this.SceneMigrationSynchronization && !(this.NetworkManager == null) && !this.NetworkManager.ShutdownInProgress && this.IsSpawned)
			{
				bool? isSceneObject = this.IsSceneObject;
				bool flag = false;
				if ((isSceneObject.GetValueOrDefault() == flag & isSceneObject != null) && base.gameObject.scene.handle != this.SceneOriginHandle)
				{
					this.SceneChangedUpdate(base.gameObject.scene, true);
					return;
				}
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00009D6C File Offset: 0x00007F6C
		internal uint HostCheckForGlobalObjectIdHashOverride()
		{
			if (this.NetworkManager.IsServer)
			{
				if (this.NetworkManager.PrefabHandler.ContainsHandler(this))
				{
					uint sourceGlobalObjectIdHash = this.NetworkManager.PrefabHandler.GetSourceGlobalObjectIdHash(this.GlobalObjectIdHash);
					if (sourceGlobalObjectIdHash != 0U)
					{
						return sourceGlobalObjectIdHash;
					}
					return this.GlobalObjectIdHash;
				}
				else
				{
					if (!this.NetworkManager.NetworkConfig.EnableSceneManagement && this.IsSceneObject.Value && this.InScenePlacedSourceGlobalObjectIdHash != 0U)
					{
						return this.InScenePlacedSourceGlobalObjectIdHash;
					}
					if (!this.IsSceneObject.Value && this.GlobalObjectIdHash != this.PrefabGlobalObjectIdHash)
					{
						if (this.PrefabGlobalObjectIdHash != 0U)
						{
							return this.PrefabGlobalObjectIdHash;
						}
						if (this.NetworkManager.NetworkConfig.Prefabs.OverrideToNetworkPrefab.ContainsKey(this.GlobalObjectIdHash))
						{
							return this.NetworkManager.NetworkConfig.Prefabs.OverrideToNetworkPrefab[this.GlobalObjectIdHash];
						}
					}
				}
			}
			return this.GlobalObjectIdHash;
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00009E68 File Offset: 0x00008068
		internal void OnNetworkBehaviourDestroyed(NetworkBehaviour networkBehaviour)
		{
			if (networkBehaviour.IsSpawned && this.IsSpawned)
			{
				if (this.NetworkManager.LogLevel == LogLevel.Developer)
				{
					NetworkLog.LogWarning(string.Concat(new string[]
					{
						"NetworkBehaviour-",
						networkBehaviour.name,
						" is being destroyed while NetworkObject-",
						base.name,
						" is still spawned! (could break state synchronization)"
					}));
				}
				this.ChildNetworkBehaviours.Remove(networkBehaviour);
			}
		}

		// Token: 0x040000C1 RID: 193
		[HideInInspector]
		[SerializeField]
		internal uint GlobalObjectIdHash;

		// Token: 0x040000C2 RID: 194
		internal uint PrefabGlobalObjectIdHash;

		// Token: 0x040000C3 RID: 195
		[HideInInspector]
		[SerializeField]
		internal uint InScenePlacedSourceGlobalObjectIdHash;

		// Token: 0x040000C4 RID: 196
		internal NetworkManager NetworkManagerOwner;

		// Token: 0x040000C7 RID: 199
		internal ulong PreviousOwnerId;

		// Token: 0x040000C8 RID: 200
		public bool AlwaysReplicateAsRoot;

		// Token: 0x040000CA RID: 202
		public bool SynchronizeTransform = true;

		// Token: 0x040000CE RID: 206
		public bool ActiveSceneSynchronization;

		// Token: 0x040000CF RID: 207
		public bool SceneMigrationSynchronization = true;

		// Token: 0x040000D0 RID: 208
		public Action OnMigratedToNewScene;

		// Token: 0x040000D1 RID: 209
		[Tooltip("When false, the NetworkObject will spawn with no observers initially. (default is true)")]
		public bool SpawnWithObservers = true;

		// Token: 0x040000D2 RID: 210
		public NetworkObject.VisibilityDelegate CheckObjectVisibility;

		// Token: 0x040000D3 RID: 211
		public NetworkObject.SpawnDelegate IncludeTransformWhenSpawning;

		// Token: 0x040000D4 RID: 212
		public bool DontDestroyWithOwner;

		// Token: 0x040000D5 RID: 213
		public bool AutoObjectParentSync = true;

		// Token: 0x040000D6 RID: 214
		internal readonly HashSet<ulong> Observers = new HashSet<ulong>();

		// Token: 0x040000D7 RID: 215
		private string m_CachedNameForMetrics;

		// Token: 0x040000D8 RID: 216
		private readonly HashSet<ulong> m_EmptyULongHashSet = new HashSet<ulong>();

		// Token: 0x040000D9 RID: 217
		internal int SceneOriginHandle;

		// Token: 0x040000DA RID: 218
		internal int NetworkSceneHandle;

		// Token: 0x040000DB RID: 219
		private Scene m_SceneOrigin;

		// Token: 0x040000DC RID: 220
		private ulong? m_LatestParent;

		// Token: 0x040000DD RID: 221
		private Transform m_CachedParent;

		// Token: 0x040000DE RID: 222
		private bool m_CachedWorldPositionStays = true;

		// Token: 0x040000DF RID: 223
		internal static HashSet<NetworkObject> OrphanChildren = new HashSet<NetworkObject>();

		// Token: 0x040000E0 RID: 224
		private List<NetworkBehaviour> m_ChildNetworkBehaviours;

		// Token: 0x02000029 RID: 41
		// (Invoke) Token: 0x060001B3 RID: 435
		public delegate bool VisibilityDelegate(ulong clientId);

		// Token: 0x0200002A RID: 42
		// (Invoke) Token: 0x060001B7 RID: 439
		public delegate bool SpawnDelegate(ulong clientId);

		// Token: 0x0200002B RID: 43
		internal struct SceneObject
		{
			// Token: 0x17000053 RID: 83
			// (get) Token: 0x060001BA RID: 442 RVA: 0x00009F34 File Offset: 0x00008134
			// (set) Token: 0x060001BB RID: 443 RVA: 0x00009F42 File Offset: 0x00008142
			public bool IsPlayerObject
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

			// Token: 0x17000054 RID: 84
			// (get) Token: 0x060001BC RID: 444 RVA: 0x00009F51 File Offset: 0x00008151
			// (set) Token: 0x060001BD RID: 445 RVA: 0x00009F5F File Offset: 0x0000815F
			public bool HasParent
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

			// Token: 0x17000055 RID: 85
			// (get) Token: 0x060001BE RID: 446 RVA: 0x00009F6E File Offset: 0x0000816E
			// (set) Token: 0x060001BF RID: 447 RVA: 0x00009F7C File Offset: 0x0000817C
			public bool IsSceneObject
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

			// Token: 0x17000056 RID: 86
			// (get) Token: 0x060001C0 RID: 448 RVA: 0x00009F8B File Offset: 0x0000818B
			// (set) Token: 0x060001C1 RID: 449 RVA: 0x00009F99 File Offset: 0x00008199
			public bool HasTransform
			{
				get
				{
					return ByteUtility.GetBit(this.m_BitField, 3);
				}
				set
				{
					ByteUtility.SetBit(ref this.m_BitField, 3, value);
				}
			}

			// Token: 0x17000057 RID: 87
			// (get) Token: 0x060001C2 RID: 450 RVA: 0x00009FA8 File Offset: 0x000081A8
			// (set) Token: 0x060001C3 RID: 451 RVA: 0x00009FB6 File Offset: 0x000081B6
			public bool IsLatestParentSet
			{
				get
				{
					return ByteUtility.GetBit(this.m_BitField, 4);
				}
				set
				{
					ByteUtility.SetBit(ref this.m_BitField, 4, value);
				}
			}

			// Token: 0x17000058 RID: 88
			// (get) Token: 0x060001C4 RID: 452 RVA: 0x00009FC5 File Offset: 0x000081C5
			// (set) Token: 0x060001C5 RID: 453 RVA: 0x00009FD3 File Offset: 0x000081D3
			public bool WorldPositionStays
			{
				get
				{
					return ByteUtility.GetBit(this.m_BitField, 5);
				}
				set
				{
					ByteUtility.SetBit(ref this.m_BitField, 5, value);
				}
			}

			// Token: 0x17000059 RID: 89
			// (get) Token: 0x060001C6 RID: 454 RVA: 0x00009FE2 File Offset: 0x000081E2
			// (set) Token: 0x060001C7 RID: 455 RVA: 0x00009FF0 File Offset: 0x000081F0
			public bool DestroyWithScene
			{
				get
				{
					return ByteUtility.GetBit(this.m_BitField, 6);
				}
				set
				{
					ByteUtility.SetBit(ref this.m_BitField, 6, value);
				}
			}

			// Token: 0x060001C8 RID: 456 RVA: 0x0000A000 File Offset: 0x00008200
			public void Serialize(FastBufferWriter writer)
			{
				writer.WriteValueSafe<byte>(this.m_BitField, default(FastBufferWriter.ForPrimitives));
				writer.WriteValueSafe<uint>(this.Hash, default(FastBufferWriter.ForPrimitives));
				BytePacker.WriteValueBitPacked(writer, this.NetworkObjectId);
				BytePacker.WriteValueBitPacked(writer, this.OwnerClientId);
				if (this.HasParent)
				{
					BytePacker.WriteValueBitPacked(writer, this.ParentObjectId);
					if (this.IsLatestParentSet)
					{
						BytePacker.WriteValueBitPacked(writer, this.LatestParent.Value);
					}
				}
				int num = 0;
				num += (this.HasTransform ? FastBufferWriter.GetWriteSize<NetworkObject.SceneObject.TransformData>() : 0);
				num += FastBufferWriter.GetWriteSize<int>();
				if (!writer.TryBeginWrite(num))
				{
					throw new OverflowException("Could not serialize SceneObject: Out of buffer space.");
				}
				if (this.HasTransform)
				{
					writer.WriteValue<NetworkObject.SceneObject.TransformData>(this.Transform, default(FastBufferWriter.ForStructs));
				}
				int sceneOriginHandle = this.OwnerObject.GetSceneOriginHandle();
				writer.WriteValue<int>(sceneOriginHandle, default(FastBufferWriter.ForPrimitives));
				BufferSerializer<BufferSerializerWriter> bufferSerializer = new BufferSerializer<BufferSerializerWriter>(new BufferSerializerWriter(writer));
				this.OwnerObject.SynchronizeNetworkBehaviours<BufferSerializerWriter>(ref bufferSerializer, this.TargetClientId);
			}

			// Token: 0x060001C9 RID: 457 RVA: 0x0000A110 File Offset: 0x00008310
			public void Deserialize(FastBufferReader reader)
			{
				reader.ReadValueSafe<byte>(out this.m_BitField, default(FastBufferWriter.ForPrimitives));
				reader.ReadValueSafe<uint>(out this.Hash, default(FastBufferWriter.ForPrimitives));
				ByteUnpacker.ReadValueBitPacked(reader, out this.NetworkObjectId);
				ByteUnpacker.ReadValueBitPacked(reader, out this.OwnerClientId);
				if (this.HasParent)
				{
					ByteUnpacker.ReadValueBitPacked(reader, out this.ParentObjectId);
					if (this.IsLatestParentSet)
					{
						ulong value;
						ByteUnpacker.ReadValueBitPacked(reader, out value);
						this.LatestParent = new ulong?(value);
					}
				}
				int num = 0;
				num += (this.HasTransform ? FastBufferWriter.GetWriteSize<NetworkObject.SceneObject.TransformData>() : 0);
				num += FastBufferWriter.GetWriteSize<int>();
				if (!reader.TryBeginRead(num))
				{
					throw new OverflowException("Could not deserialize SceneObject: Reading past the end of the buffer");
				}
				if (this.HasTransform)
				{
					reader.ReadValue<NetworkObject.SceneObject.TransformData>(out this.Transform, default(FastBufferWriter.ForStructs));
				}
				reader.ReadValue<int>(out this.NetworkSceneHandle, default(FastBufferWriter.ForPrimitives));
			}

			// Token: 0x040000E1 RID: 225
			private byte m_BitField;

			// Token: 0x040000E2 RID: 226
			public uint Hash;

			// Token: 0x040000E3 RID: 227
			public ulong NetworkObjectId;

			// Token: 0x040000E4 RID: 228
			public ulong OwnerClientId;

			// Token: 0x040000E5 RID: 229
			public ulong ParentObjectId;

			// Token: 0x040000E6 RID: 230
			public NetworkObject.SceneObject.TransformData Transform;

			// Token: 0x040000E7 RID: 231
			public ulong? LatestParent;

			// Token: 0x040000E8 RID: 232
			public NetworkObject OwnerObject;

			// Token: 0x040000E9 RID: 233
			public ulong TargetClientId;

			// Token: 0x040000EA RID: 234
			public int NetworkSceneHandle;

			// Token: 0x0200002C RID: 44
			public struct TransformData : INetworkSerializeByMemcpy
			{
				// Token: 0x040000EB RID: 235
				public Vector3 Position;

				// Token: 0x040000EC RID: 236
				public Quaternion Rotation;

				// Token: 0x040000ED RID: 237
				public Vector3 Scale;
			}
		}
	}
}
