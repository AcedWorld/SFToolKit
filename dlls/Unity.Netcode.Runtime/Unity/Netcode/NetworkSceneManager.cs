using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.Netcode
{
	// Token: 0x020000E0 RID: 224
	public class NetworkSceneManager : IDisposable
	{
		// Token: 0x14000014 RID: 20
		// (add) Token: 0x0600055C RID: 1372 RVA: 0x000165C0 File Offset: 0x000147C0
		// (remove) Token: 0x0600055D RID: 1373 RVA: 0x000165F8 File Offset: 0x000147F8
		public event NetworkSceneManager.SceneEventDelegate OnSceneEvent;

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x0600055E RID: 1374 RVA: 0x00016630 File Offset: 0x00014830
		// (remove) Token: 0x0600055F RID: 1375 RVA: 0x00016668 File Offset: 0x00014868
		public event NetworkSceneManager.OnLoadDelegateHandler OnLoad;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000560 RID: 1376 RVA: 0x000166A0 File Offset: 0x000148A0
		// (remove) Token: 0x06000561 RID: 1377 RVA: 0x000166D8 File Offset: 0x000148D8
		public event NetworkSceneManager.OnUnloadDelegateHandler OnUnload;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000562 RID: 1378 RVA: 0x00016710 File Offset: 0x00014910
		// (remove) Token: 0x06000563 RID: 1379 RVA: 0x00016748 File Offset: 0x00014948
		public event NetworkSceneManager.OnSynchronizeDelegateHandler OnSynchronize;

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000564 RID: 1380 RVA: 0x00016780 File Offset: 0x00014980
		// (remove) Token: 0x06000565 RID: 1381 RVA: 0x000167B8 File Offset: 0x000149B8
		public event NetworkSceneManager.OnEventCompletedDelegateHandler OnLoadEventCompleted;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000566 RID: 1382 RVA: 0x000167F0 File Offset: 0x000149F0
		// (remove) Token: 0x06000567 RID: 1383 RVA: 0x00016828 File Offset: 0x00014A28
		public event NetworkSceneManager.OnEventCompletedDelegateHandler OnUnloadEventCompleted;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06000568 RID: 1384 RVA: 0x00016860 File Offset: 0x00014A60
		// (remove) Token: 0x06000569 RID: 1385 RVA: 0x00016898 File Offset: 0x00014A98
		public event NetworkSceneManager.OnLoadCompleteDelegateHandler OnLoadComplete;

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x0600056A RID: 1386 RVA: 0x000168D0 File Offset: 0x00014AD0
		// (remove) Token: 0x0600056B RID: 1387 RVA: 0x00016908 File Offset: 0x00014B08
		public event NetworkSceneManager.OnUnloadCompleteDelegateHandler OnUnloadComplete;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x0600056C RID: 1388 RVA: 0x00016940 File Offset: 0x00014B40
		// (remove) Token: 0x0600056D RID: 1389 RVA: 0x00016978 File Offset: 0x00014B78
		public event NetworkSceneManager.OnSynchronizeCompleteDelegateHandler OnSynchronizeComplete;

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x000169AD File Offset: 0x00014BAD
		// (set) Token: 0x0600056F RID: 1391 RVA: 0x000169B5 File Offset: 0x00014BB5
		public bool ActiveSceneSynchronizationEnabled
		{
			get
			{
				return this.m_ActiveSceneSynchronizationEnabled;
			}
			set
			{
				if (this.m_ActiveSceneSynchronizationEnabled != value)
				{
					this.m_ActiveSceneSynchronizationEnabled = value;
					if (this.m_ActiveSceneSynchronizationEnabled)
					{
						SceneManager.activeSceneChanged += this.SceneManager_ActiveSceneChanged;
						return;
					}
					SceneManager.activeSceneChanged -= this.SceneManager_ActiveSceneChanged;
				}
			}
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x000169F4 File Offset: 0x00014BF4
		internal bool UpdateServerClientSceneHandle(int serverHandle, int clientHandle, Scene localScene)
		{
			if (this.ServerSceneHandleToClientSceneHandle.ContainsKey(serverHandle))
			{
				return false;
			}
			this.ServerSceneHandleToClientSceneHandle.Add(serverHandle, clientHandle);
			if (!this.ClientSceneHandleToServerSceneHandle.ContainsKey(clientHandle))
			{
				this.ClientSceneHandleToServerSceneHandle.Add(clientHandle, serverHandle);
				if (!this.ScenesLoaded.ContainsKey(clientHandle))
				{
					this.ScenesLoaded.Add(clientHandle, localScene);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x00016A5C File Offset: 0x00014C5C
		internal bool RemoveServerClientSceneHandle(int serverHandle, int clientHandle)
		{
			if (!this.ServerSceneHandleToClientSceneHandle.ContainsKey(serverHandle))
			{
				return false;
			}
			this.ServerSceneHandleToClientSceneHandle.Remove(serverHandle);
			if (!this.ClientSceneHandleToServerSceneHandle.ContainsKey(clientHandle))
			{
				return false;
			}
			this.ClientSceneHandleToServerSceneHandle.Remove(clientHandle);
			if (this.ScenesLoaded.ContainsKey(clientHandle))
			{
				this.ScenesLoaded.Remove(clientHandle);
				return true;
			}
			return false;
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000572 RID: 1394 RVA: 0x00016AC7 File Offset: 0x00014CC7
		// (set) Token: 0x06000573 RID: 1395 RVA: 0x00016ACF File Offset: 0x00014CCF
		public LoadSceneMode ClientSynchronizationMode { get; internal set; }

		// Token: 0x06000574 RID: 1396 RVA: 0x00016AD8 File Offset: 0x00014CD8
		public void Dispose()
		{
			SceneManager.activeSceneChanged -= this.SceneManager_ActiveSceneChanged;
			NetworkSceneManager.SceneUnloadEventHandler.Shutdown();
			foreach (KeyValuePair<uint, SceneEventData> keyValuePair in this.SceneEventDataStore)
			{
				if (NetworkLog.CurrentLogLevel == LogLevel.Developer)
				{
					NetworkLog.LogInfo(string.Format("{0} is disposing {1} '{2}'.", "SceneEventDataStore", "SceneEventId", keyValuePair.Key));
				}
				keyValuePair.Value.Dispose();
			}
			this.SceneEventDataStore.Clear();
			this.SceneEventDataStore = null;
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x00016B84 File Offset: 0x00014D84
		internal SceneEventData BeginSceneEvent()
		{
			SceneEventData sceneEventData = new SceneEventData(this.NetworkManager);
			this.SceneEventDataStore.Add(sceneEventData.SceneEventId, sceneEventData);
			return sceneEventData;
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x00016BB0 File Offset: 0x00014DB0
		internal void EndSceneEvent(uint sceneEventId)
		{
			if (this.SceneEventDataStore.ContainsKey(sceneEventId))
			{
				this.SceneEventDataStore[sceneEventId].Dispose();
				this.SceneEventDataStore.Remove(sceneEventId);
				return;
			}
			Debug.LogWarning(string.Format("Trying to dispose and remove SceneEventData Id '{0}' that no longer exists!", sceneEventId));
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x00016C00 File Offset: 0x00014E00
		internal bool ShouldDeferCreateObject()
		{
			if (!this.NetworkManager.NetworkConfig.EnableSceneManagement || this.NetworkManager.IsServer)
			{
				return false;
			}
			bool flag = false;
			bool flag2 = false;
			foreach (KeyValuePair<uint, SceneEventData> keyValuePair in this.SceneEventDataStore)
			{
				if (keyValuePair.Value.SceneEventType == SceneEventType.Synchronize)
				{
					flag = true;
				}
				if (keyValuePair.Value.SceneEventType == SceneEventType.Load && keyValuePair.Value.LoadSceneMode == this.DeferLoadingFilter)
				{
					flag2 = true;
				}
			}
			return (flag && this.ClientSynchronizationMode == LoadSceneMode.Single) || (!flag && flag2);
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x00016CBC File Offset: 0x00014EBC
		internal string GetSceneNameFromPath(string scenePath)
		{
			int num = scenePath.LastIndexOf("/", StringComparison.Ordinal) + 1;
			int num2 = scenePath.LastIndexOf(".", StringComparison.Ordinal);
			return scenePath.Substring(num, num2 - num);
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x00016CF0 File Offset: 0x00014EF0
		internal void GenerateScenesInBuild()
		{
			this.HashToBuildIndex.Clear();
			this.BuildIndexToHash.Clear();
			for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
			{
				string scenePathByBuildIndex = SceneUtility.GetScenePathByBuildIndex(i);
				uint num = scenePathByBuildIndex.Hash32();
				int buildIndexByScenePath = SceneUtility.GetBuildIndexByScenePath(scenePathByBuildIndex);
				if (!this.HashToBuildIndex.ContainsKey(num))
				{
					this.HashToBuildIndex.Add(num, buildIndexByScenePath);
					this.BuildIndexToHash.Add(buildIndexByScenePath, num);
				}
				else
				{
					Debug.LogError("NetworkSceneManager is skipping duplicate scene path entry " + scenePathByBuildIndex + ". Make sure your scenes in build list does not contain duplicates!");
				}
			}
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x00016D77 File Offset: 0x00014F77
		internal string SceneNameFromHash(uint sceneHash)
		{
			if (sceneHash == 0U)
			{
				return "No Scene";
			}
			return this.GetSceneNameFromPath(this.ScenePathFromHash(sceneHash));
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x00016D90 File Offset: 0x00014F90
		internal string ScenePathFromHash(uint sceneHash)
		{
			if (this.HashToBuildIndex.ContainsKey(sceneHash))
			{
				return SceneUtility.GetScenePathByBuildIndex(this.HashToBuildIndex[sceneHash]);
			}
			throw new Exception(string.Format("Scene Hash {0} does not exist in the {1} table!  Verify that all scenes requiring", sceneHash, "HashToBuildIndex") + " server to client synchronization are in the scenes in build list.");
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x00016DE4 File Offset: 0x00014FE4
		internal uint SceneHashFromNameOrPath(string sceneNameOrPath)
		{
			int buildIndexByScenePath = SceneUtility.GetBuildIndexByScenePath(sceneNameOrPath);
			if (buildIndexByScenePath < 0)
			{
				throw new Exception("Scene '" + sceneNameOrPath + "' couldn't be loaded because it has not been added to the build settings scenes in build list.");
			}
			if (this.BuildIndexToHash.ContainsKey(buildIndexByScenePath))
			{
				return this.BuildIndexToHash[buildIndexByScenePath];
			}
			throw new Exception(string.Format("Scene '{0}' has a build index of {1} that does not exist in the {2} table!", sceneNameOrPath, buildIndexByScenePath, "BuildIndexToHash"));
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00016E48 File Offset: 0x00015048
		public void DisableValidationWarnings(bool disabled)
		{
			this.m_DisableValidationWarningMessages = disabled;
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x00016E54 File Offset: 0x00015054
		public void SetClientSynchronizationMode(LoadSceneMode mode)
		{
			NetworkManager networkManager = this.NetworkManager;
			this.SceneManagerHandler.SetClientSynchronizationMode(ref networkManager, mode);
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x00016E78 File Offset: 0x00015078
		internal NetworkSceneManager(NetworkManager networkManager)
		{
			this.NetworkManager = networkManager;
			this.SceneEventDataStore = new Dictionary<uint, SceneEventData>();
			this.GenerateScenesInBuild();
			this.DontDestroyOnLoadScene = networkManager.gameObject.scene;
			if (networkManager.IsServer && networkManager.NetworkConfig.EnableSceneManagement)
			{
				for (int i = 0; i < SceneManager.sceneCount; i++)
				{
					Scene sceneAt = SceneManager.GetSceneAt(i);
					this.ScenesLoaded.Add(sceneAt.handle, sceneAt);
				}
				this.SceneManagerHandler.PopulateLoadedScenes(ref this.ScenesLoaded, this.NetworkManager);
			}
			this.UpdateServerClientSceneHandle(this.DontDestroyOnLoadScene.handle, this.DontDestroyOnLoadScene.handle, this.DontDestroyOnLoadScene);
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x00016FB4 File Offset: 0x000151B4
		private void SceneManager_ActiveSceneChanged(Scene current, Scene next)
		{
			if (this.NetworkManager.ConnectedClientsIds.Count <= (this.NetworkManager.IsHost ? 1 : 0))
			{
				return;
			}
			foreach (KeyValuePair<Guid, SceneEventProgress> keyValuePair in this.SceneEventProgressTracking)
			{
				if (!keyValuePair.Value.HasTimedOut() && keyValuePair.Value.Status == SceneEventProgressStatus.Started)
				{
					return;
				}
			}
			if (this.BuildIndexToHash.ContainsKey(next.buildIndex))
			{
				SceneEventData sceneEventData = this.BeginSceneEvent();
				sceneEventData.SceneEventType = SceneEventType.ActiveSceneChanged;
				sceneEventData.ActiveSceneHash = this.BuildIndexToHash[next.buildIndex];
				this.SendSceneEventData(sceneEventData.SceneEventId, (from c in this.NetworkManager.ConnectedClientsIds
				where c > 0UL
				select c).ToArray<ulong>());
				this.EndSceneEvent(sceneEventData.SceneEventId);
			}
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x000170D0 File Offset: 0x000152D0
		internal bool ValidateSceneBeforeLoading(uint sceneHash, LoadSceneMode loadSceneMode)
		{
			string text = this.SceneNameFromHash(sceneHash);
			int buildIndexByScenePath = SceneUtility.GetBuildIndexByScenePath(text);
			return this.ValidateSceneBeforeLoading(buildIndexByScenePath, text, loadSceneMode);
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x000170F8 File Offset: 0x000152F8
		internal bool ValidateSceneBeforeLoading(int sceneIndex, string sceneName, LoadSceneMode loadSceneMode)
		{
			bool flag = true;
			if (this.VerifySceneBeforeLoading != null)
			{
				flag = this.VerifySceneBeforeLoading(sceneIndex, sceneName, loadSceneMode);
			}
			if (!flag && !this.m_DisableValidationWarningMessages)
			{
				string text = "Client";
				if (this.NetworkManager.IsServer)
				{
					text = (this.NetworkManager.IsHost ? "Host" : "Server");
				}
				Debug.LogWarning(string.Format("Scene {0} of Scenes in Build Index {1} being loaded in {2} mode failed validation on the {3}!", new object[]
				{
					sceneName,
					sceneIndex,
					loadSceneMode,
					text
				}));
			}
			return flag;
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x00017188 File Offset: 0x00015388
		internal Scene GetAndAddNewlyLoadedSceneByName(string sceneName)
		{
			if (this.OverrideGetAndAddNewlyLoadedSceneByName != null)
			{
				return this.OverrideGetAndAddNewlyLoadedSceneByName(sceneName);
			}
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				if (sceneAt.name == sceneName && !this.ScenesLoaded.ContainsKey(sceneAt.handle))
				{
					this.ScenesLoaded.Add(sceneAt.handle, sceneAt);
					this.SceneManagerHandler.StartTrackingScene(sceneAt, true, this.NetworkManager);
					return sceneAt;
				}
			}
			throw new Exception("Failed to find any loaded scene named " + sceneName + "!");
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x00017224 File Offset: 0x00015424
		internal void SetTheSceneBeingSynchronized(int serverSceneHandle)
		{
			if (this.ServerSceneHandleToClientSceneHandle.ContainsKey(serverSceneHandle))
			{
				int num = this.ServerSceneHandleToClientSceneHandle[serverSceneHandle];
				if (this.SceneBeingSynchronized.IsValid() && this.SceneBeingSynchronized.isLoaded && this.SceneBeingSynchronized.handle == num)
				{
					return;
				}
				this.SceneBeingSynchronized = (this.ScenesLoaded.ContainsKey(num) ? this.ScenesLoaded[num] : default(Scene));
				if (!this.SceneBeingSynchronized.IsValid() || !this.SceneBeingSynchronized.isLoaded)
				{
					this.SceneBeingSynchronized = SceneManager.GetActiveScene();
					Debug.LogWarning("[NetworkSceneManager- ScenesLoaded] Could not find the appropriate scene to set as being synchronized! Using the currently active scene.");
					return;
				}
			}
			else
			{
				if (serverSceneHandle == this.DontDestroyOnLoadScene.handle)
				{
					this.SceneBeingSynchronized = this.NetworkManager.gameObject.scene;
					return;
				}
				this.SceneBeingSynchronized = SceneManager.GetActiveScene();
				Debug.LogWarning("[SceneEventData- Scene Handle Mismatch] serverSceneHandle could not be found in ServerSceneHandleToClientSceneHandle. Using the currently active scene.");
			}
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00017310 File Offset: 0x00015510
		internal NetworkObject GetSceneRelativeInSceneNetworkObject(uint globalObjectIdHash, int? networkSceneHandle)
		{
			if (this.ScenePlacedObjects.ContainsKey(globalObjectIdHash))
			{
				int key = this.SceneBeingSynchronized.handle;
				if (networkSceneHandle != null && networkSceneHandle.Value != 0)
				{
					key = this.ServerSceneHandleToClientSceneHandle[networkSceneHandle.Value];
				}
				if (this.ScenePlacedObjects[globalObjectIdHash].ContainsKey(key))
				{
					return this.ScenePlacedObjects[globalObjectIdHash][key];
				}
			}
			return null;
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x00017384 File Offset: 0x00015584
		private void SendSceneEventData(uint sceneEventId, ulong[] targetClientIds)
		{
			if (targetClientIds.Length == 0)
			{
				return;
			}
			SceneEventMessage sceneEventMessage = new SceneEventMessage
			{
				EventData = this.SceneEventDataStore[sceneEventId]
			};
			int num = this.NetworkManager.ConnectionManager.SendMessage<SceneEventMessage, ulong[]>(ref sceneEventMessage, NetworkDelivery.ReliableFragmentedSequenced, targetClientIds);
			this.NetworkManager.NetworkMetrics.TrackSceneEventSent(targetClientIds, (uint)this.SceneEventDataStore[sceneEventId].SceneEventType, this.SceneNameFromHash(this.SceneEventDataStore[sceneEventId].SceneHash), (long)num);
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00017404 File Offset: 0x00015604
		private SceneEventProgress ValidateSceneEventUnloading(Scene scene)
		{
			if (!this.NetworkManager.NetworkConfig.EnableSceneManagement)
			{
				Debug.LogWarning("LoadScene was called, but EnableSceneManagement was not enabled! Enable EnableSceneManagement prior to starting a client, host, or server prior to using NetworkSceneManager!");
				return new SceneEventProgress(null, SceneEventProgressStatus.SceneManagementNotEnabled);
			}
			if (!this.NetworkManager.IsServer)
			{
				Debug.LogWarning("[ServerOnlyAction][Unload] Clients cannot invoke the UnloadScene method!");
				return new SceneEventProgress(null, SceneEventProgressStatus.ServerOnlyAction);
			}
			if (!scene.isLoaded)
			{
				Debug.LogWarning("UnloadScene was called, but the scene " + scene.name + " is not currently loaded!");
				return new SceneEventProgress(null, SceneEventProgressStatus.SceneNotLoaded);
			}
			return this.ValidateSceneEvent(scene.name, true);
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00017490 File Offset: 0x00015690
		private SceneEventProgress ValidateSceneEventLoading(string sceneName)
		{
			if (!this.NetworkManager.NetworkConfig.EnableSceneManagement)
			{
				Debug.LogWarning("LoadScene was called, but EnableSceneManagement was not enabled! Enable EnableSceneManagement prior to starting a client, host, or server prior to using NetworkSceneManager!");
				return new SceneEventProgress(null, SceneEventProgressStatus.SceneManagementNotEnabled);
			}
			if (!this.NetworkManager.IsServer)
			{
				Debug.LogWarning("[ServerOnlyAction][Load] Clients cannot invoke the LoadScene method!");
				return new SceneEventProgress(null, SceneEventProgressStatus.ServerOnlyAction);
			}
			return this.ValidateSceneEvent(sceneName, false);
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x000174E8 File Offset: 0x000156E8
		private SceneEventProgress ValidateSceneEvent(string sceneName, bool isUnloading = false)
		{
			if (this.m_IsSceneEventActive)
			{
				return new SceneEventProgress(null, SceneEventProgressStatus.SceneEventInProgress);
			}
			if (SceneUtility.GetBuildIndexByScenePath(sceneName) == -1)
			{
				Debug.LogError("Scene '" + sceneName + "' couldn't be loaded because it has not been added to the build settings scenes in build list.");
				return new SceneEventProgress(null, SceneEventProgressStatus.InvalidSceneName);
			}
			SceneEventProgress sceneEventProgress = new SceneEventProgress(this.NetworkManager, SceneEventProgressStatus.Started)
			{
				SceneHash = this.SceneHashFromNameOrPath(sceneName)
			};
			this.SceneEventProgressTracking.Add(sceneEventProgress.Guid, sceneEventProgress);
			this.m_IsSceneEventActive = true;
			sceneEventProgress.OnComplete = new SceneEventProgress.OnCompletedDelegate(this.OnSceneEventProgressCompleted);
			return sceneEventProgress;
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00017574 File Offset: 0x00015774
		private bool OnSceneEventProgressCompleted(SceneEventProgress sceneEventProgress)
		{
			SceneEventData sceneEventData = this.BeginSceneEvent();
			List<ulong> clientsWithStatus = sceneEventProgress.GetClientsWithStatus(true);
			List<ulong> clientsWithStatus2 = sceneEventProgress.GetClientsWithStatus(false);
			sceneEventData.SceneEventProgressId = sceneEventProgress.Guid;
			sceneEventData.SceneHash = sceneEventProgress.SceneHash;
			sceneEventData.SceneEventType = sceneEventProgress.SceneEventType;
			sceneEventData.ClientsCompleted = clientsWithStatus;
			sceneEventData.LoadSceneMode = sceneEventProgress.LoadSceneMode;
			sceneEventData.ClientsTimedOut = clientsWithStatus2;
			SceneEventMessage sceneEventMessage = new SceneEventMessage
			{
				EventData = sceneEventData
			};
			NetworkConnectionManager connectionManager = this.NetworkManager.ConnectionManager;
			NetworkDelivery delivery = NetworkDelivery.ReliableFragmentedSequenced;
			IReadOnlyList<ulong> connectedClientsIds = this.NetworkManager.ConnectedClientsIds;
			int num = connectionManager.SendMessage<SceneEventMessage, IReadOnlyList<ulong>>(ref sceneEventMessage, delivery, connectedClientsIds);
			this.NetworkManager.NetworkMetrics.TrackSceneEventSent(this.NetworkManager.ConnectedClientsIds, (uint)sceneEventProgress.SceneEventType, this.SceneNameFromHash(sceneEventProgress.SceneHash), (long)num);
			NetworkSceneManager.SceneEventDelegate onSceneEvent = this.OnSceneEvent;
			if (onSceneEvent != null)
			{
				onSceneEvent(new SceneEvent
				{
					SceneEventType = sceneEventProgress.SceneEventType,
					SceneName = this.SceneNameFromHash(sceneEventProgress.SceneHash),
					ClientId = 0UL,
					LoadSceneMode = sceneEventProgress.LoadSceneMode,
					ClientsThatCompleted = clientsWithStatus,
					ClientsThatTimedOut = clientsWithStatus2
				});
			}
			if (sceneEventData.SceneEventType == SceneEventType.LoadEventCompleted)
			{
				NetworkSceneManager.OnEventCompletedDelegateHandler onLoadEventCompleted = this.OnLoadEventCompleted;
				if (onLoadEventCompleted != null)
				{
					onLoadEventCompleted(this.SceneNameFromHash(sceneEventProgress.SceneHash), sceneEventProgress.LoadSceneMode, sceneEventData.ClientsCompleted, sceneEventData.ClientsTimedOut);
				}
			}
			else
			{
				NetworkSceneManager.OnEventCompletedDelegateHandler onUnloadEventCompleted = this.OnUnloadEventCompleted;
				if (onUnloadEventCompleted != null)
				{
					onUnloadEventCompleted(this.SceneNameFromHash(sceneEventProgress.SceneHash), sceneEventProgress.LoadSceneMode, sceneEventData.ClientsCompleted, sceneEventData.ClientsTimedOut);
				}
			}
			this.EndSceneEvent(sceneEventData.SceneEventId);
			return true;
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00017710 File Offset: 0x00015910
		public SceneEventProgressStatus UnloadScene(Scene scene)
		{
			string name = scene.name;
			int handle = scene.handle;
			if (!scene.isLoaded)
			{
				Debug.LogWarning("UnloadScene was called, but the scene " + scene.name + " is not currently loaded!");
				return SceneEventProgressStatus.SceneNotLoaded;
			}
			SceneEventProgress sceneEventProgress = this.ValidateSceneEventUnloading(scene);
			if (sceneEventProgress.Status != SceneEventProgressStatus.Started)
			{
				return sceneEventProgress.Status;
			}
			if (!this.ScenesLoaded.ContainsKey(handle))
			{
				Debug.LogError(string.Format("{0} internal error! {1} with handle {2} is not within the internal scenes loaded dictionary!", "UnloadScene", name, scene.handle));
				return SceneEventProgressStatus.InternalNetcodeError;
			}
			NetworkManager networkManager = this.NetworkManager;
			this.SceneManagerHandler.MoveObjectsFromSceneToDontDestroyOnLoad(ref networkManager, scene);
			SceneEventData sceneEventData = this.BeginSceneEvent();
			sceneEventData.SceneEventProgressId = sceneEventProgress.Guid;
			sceneEventData.SceneEventType = SceneEventType.Unload;
			sceneEventData.SceneHash = this.SceneHashFromNameOrPath(name);
			sceneEventData.LoadSceneMode = LoadSceneMode.Additive;
			sceneEventData.SceneHandle = handle;
			sceneEventProgress.SceneEventType = SceneEventType.UnloadEventCompleted;
			this.ScenesLoaded.Remove(scene.handle);
			sceneEventProgress.SceneEventId = sceneEventData.SceneEventId;
			sceneEventProgress.OnSceneEventCompleted = new Action<uint>(this.OnSceneUnloaded);
			AsyncOperation asyncOperation = this.SceneManagerHandler.UnloadSceneAsync(scene, sceneEventProgress);
			NetworkSceneManager.SceneEventDelegate onSceneEvent = this.OnSceneEvent;
			if (onSceneEvent != null)
			{
				onSceneEvent(new SceneEvent
				{
					AsyncOperation = asyncOperation,
					SceneEventType = sceneEventData.SceneEventType,
					LoadSceneMode = sceneEventData.LoadSceneMode,
					SceneName = name,
					ClientId = 0UL
				});
			}
			NetworkSceneManager.OnUnloadDelegateHandler onUnload = this.OnUnload;
			if (onUnload != null)
			{
				onUnload(0UL, name, asyncOperation);
			}
			return sceneEventProgress.Status;
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x0001789C File Offset: 0x00015A9C
		private void OnClientUnloadScene(uint sceneEventId)
		{
			SceneEventData sceneEventData = this.SceneEventDataStore[sceneEventId];
			string text = this.SceneNameFromHash(sceneEventData.SceneHash);
			if (!this.ServerSceneHandleToClientSceneHandle.ContainsKey(sceneEventData.SceneHandle))
			{
				Debug.Log("Client failed to unload scene " + text + " " + string.Format("because we are missing the client scene handle due to the server scene handle {0} not being found.", sceneEventData.SceneHandle));
				this.EndSceneEvent(sceneEventId);
				return;
			}
			int num = this.ServerSceneHandleToClientSceneHandle[sceneEventData.SceneHandle];
			if (!this.ScenesLoaded.ContainsKey(num))
			{
				throw new Exception("Client failed to unload scene " + text + " " + string.Format("because the client scene handle {0} was not found in ScenesLoaded!", num));
			}
			Scene scene = this.ScenesLoaded[num];
			NetworkManager networkManager = this.NetworkManager;
			this.SceneManagerHandler.MoveObjectsFromSceneToDontDestroyOnLoad(ref networkManager, scene);
			this.m_IsSceneEventActive = true;
			SceneEventProgress sceneEventProgress = new SceneEventProgress(this.NetworkManager, SceneEventProgressStatus.Started)
			{
				SceneEventId = sceneEventData.SceneEventId,
				OnSceneEventCompleted = new Action<uint>(this.OnSceneUnloaded)
			};
			AsyncOperation asyncOperation = this.SceneManagerHandler.UnloadSceneAsync(scene, sceneEventProgress);
			this.SceneManagerHandler.StopTrackingScene(num, text, this.NetworkManager);
			if (!this.RemoveServerClientSceneHandle(sceneEventData.SceneHandle, num))
			{
				throw new Exception(string.Format("Failed to remove server scene handle ({0}) or client scene handle({1})! Happened during scene unload for {2}.", sceneEventData.SceneHandle, num, text));
			}
			NetworkSceneManager.SceneEventDelegate onSceneEvent = this.OnSceneEvent;
			if (onSceneEvent != null)
			{
				onSceneEvent(new SceneEvent
				{
					AsyncOperation = asyncOperation,
					SceneEventType = sceneEventData.SceneEventType,
					LoadSceneMode = LoadSceneMode.Additive,
					SceneName = text,
					ClientId = this.NetworkManager.LocalClientId
				});
			}
			NetworkSceneManager.OnUnloadDelegateHandler onUnload = this.OnUnload;
			if (onUnload == null)
			{
				return;
			}
			onUnload(this.NetworkManager.LocalClientId, text, asyncOperation);
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x00017A60 File Offset: 0x00015C60
		private void OnSceneUnloaded(uint sceneEventId)
		{
			if (!this.NetworkManager.IsListening || this.NetworkManager.ShutdownInProgress)
			{
				return;
			}
			this.MoveObjectsFromDontDestroyOnLoadToScene(SceneManager.GetActiveScene());
			SceneEventData sceneEventData = this.SceneEventDataStore[sceneEventId];
			if (this.NetworkManager.IsServer)
			{
				this.SendSceneEventData(sceneEventId, (from c in this.NetworkManager.ConnectedClientsIds
				where c > 0UL
				select c).ToArray<ulong>());
				if (this.SceneEventProgressTracking.ContainsKey(sceneEventData.SceneEventProgressId) && this.NetworkManager.IsHost)
				{
					this.SceneEventProgressTracking[sceneEventData.SceneEventProgressId].ClientFinishedSceneEvent(0UL);
				}
			}
			sceneEventData.SceneEventType = SceneEventType.UnloadComplete;
			NetworkSceneManager.SceneEventDelegate onSceneEvent = this.OnSceneEvent;
			if (onSceneEvent != null)
			{
				onSceneEvent(new SceneEvent
				{
					SceneEventType = sceneEventData.SceneEventType,
					LoadSceneMode = sceneEventData.LoadSceneMode,
					SceneName = this.SceneNameFromHash(sceneEventData.SceneHash),
					ClientId = (this.NetworkManager.IsServer ? 0UL : this.NetworkManager.LocalClientId)
				});
			}
			NetworkSceneManager.OnUnloadCompleteDelegateHandler onUnloadComplete = this.OnUnloadComplete;
			if (onUnloadComplete != null)
			{
				onUnloadComplete(this.NetworkManager.LocalClientId, this.SceneNameFromHash(sceneEventData.SceneHash));
			}
			if (!this.NetworkManager.IsServer)
			{
				this.SendSceneEventData(sceneEventId, new ulong[1]);
			}
			this.EndSceneEvent(sceneEventId);
			this.m_IsSceneEventActive = false;
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00004E3E File Offset: 0x0000303E
		private void EmptySceneUnloadedOperation(uint sceneEventId)
		{
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00017BE4 File Offset: 0x00015DE4
		internal void UnloadAdditivelyLoadedScenes(uint sceneEventId)
		{
			SceneEventData sceneEventData = this.SceneEventDataStore[sceneEventId];
			Scene activeScene = SceneManager.GetActiveScene();
			foreach (KeyValuePair<int, Scene> keyValuePair in this.ScenesLoaded)
			{
				if (activeScene.name != keyValuePair.Value.name && keyValuePair.Value.buildIndex >= 0)
				{
					SceneEventProgress sceneEventProgress = new SceneEventProgress(this.NetworkManager, SceneEventProgressStatus.Started)
					{
						SceneEventId = sceneEventId,
						OnSceneEventCompleted = new Action<uint>(this.EmptySceneUnloadedOperation)
					};
					AsyncOperation asyncOperation = this.SceneManagerHandler.UnloadSceneAsync(keyValuePair.Value, sceneEventProgress);
					NetworkSceneManager.SceneUnloadEventHandler.RegisterScene(this, keyValuePair.Value, LoadSceneMode.Additive, asyncOperation);
				}
			}
			this.ScenesLoaded.Clear();
			this.SceneManagerHandler.ClearSceneTracking(this.NetworkManager);
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00017CE4 File Offset: 0x00015EE4
		public SceneEventProgressStatus LoadScene(string sceneName, LoadSceneMode loadSceneMode)
		{
			SceneEventProgress sceneEventProgress = this.ValidateSceneEventLoading(sceneName);
			if (sceneEventProgress.Status != SceneEventProgressStatus.Started)
			{
				return sceneEventProgress.Status;
			}
			sceneEventProgress.SceneEventType = SceneEventType.LoadEventCompleted;
			sceneEventProgress.LoadSceneMode = loadSceneMode;
			SceneEventData sceneEventData = this.BeginSceneEvent();
			sceneEventData.SceneEventProgressId = sceneEventProgress.Guid;
			sceneEventData.SceneEventType = SceneEventType.Load;
			sceneEventData.SceneHash = this.SceneHashFromNameOrPath(sceneName);
			sceneEventData.LoadSceneMode = loadSceneMode;
			uint sceneEventId = sceneEventData.SceneEventId;
			this.m_IsSceneEventActive = this.ValidateSceneBeforeLoading(sceneEventData.SceneHash, loadSceneMode);
			if (!this.m_IsSceneEventActive)
			{
				this.EndSceneEvent(sceneEventId);
				return SceneEventProgressStatus.SceneFailedVerification;
			}
			if (sceneEventData.LoadSceneMode == LoadSceneMode.Single)
			{
				NetworkSceneManager.IsSpawnedObjectsPendingInDontDestroyOnLoad = true;
				this.NetworkManager.SpawnManager.ServerDestroySpawnedSceneObjects();
				this.MoveObjectsToDontDestroyOnLoad();
				this.UnloadAdditivelyLoadedScenes(sceneEventId);
				NetworkSceneManager.SceneUnloadEventHandler.RegisterScene(this, SceneManager.GetActiveScene(), LoadSceneMode.Single, null);
			}
			sceneEventProgress.SceneEventId = sceneEventId;
			sceneEventProgress.OnSceneEventCompleted = new Action<uint>(this.OnSceneLoaded);
			AsyncOperation asyncOperation = this.SceneManagerHandler.LoadSceneAsync(sceneName, loadSceneMode, sceneEventProgress);
			NetworkSceneManager.SceneEventDelegate onSceneEvent = this.OnSceneEvent;
			if (onSceneEvent != null)
			{
				onSceneEvent(new SceneEvent
				{
					AsyncOperation = asyncOperation,
					SceneEventType = sceneEventData.SceneEventType,
					LoadSceneMode = sceneEventData.LoadSceneMode,
					SceneName = sceneName,
					ClientId = 0UL
				});
			}
			NetworkSceneManager.OnLoadDelegateHandler onLoad = this.OnLoad;
			if (onLoad != null)
			{
				onLoad(0UL, sceneName, sceneEventData.LoadSceneMode, asyncOperation);
			}
			return sceneEventProgress.Status;
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00017E3C File Offset: 0x0001603C
		private void OnClientSceneLoadingEvent(uint sceneEventId)
		{
			SceneEventData sceneEventData = this.SceneEventDataStore[sceneEventId];
			string sceneName = this.SceneNameFromHash(sceneEventData.SceneHash);
			if (!this.ValidateSceneBeforeLoading(sceneEventData.SceneHash, sceneEventData.LoadSceneMode))
			{
				this.EndSceneEvent(sceneEventId);
				return;
			}
			if (sceneEventData.LoadSceneMode == LoadSceneMode.Single)
			{
				this.MoveObjectsToDontDestroyOnLoad();
				this.UnloadAdditivelyLoadedScenes(sceneEventData.SceneEventId);
			}
			if (sceneEventData.LoadSceneMode == LoadSceneMode.Single)
			{
				NetworkSceneManager.IsSpawnedObjectsPendingInDontDestroyOnLoad = true;
				NetworkSceneManager.SceneUnloadEventHandler.RegisterScene(this, SceneManager.GetActiveScene(), LoadSceneMode.Single, null);
			}
			SceneEventProgress sceneEventProgress = new SceneEventProgress(this.NetworkManager, SceneEventProgressStatus.Started)
			{
				SceneEventId = sceneEventId,
				OnSceneEventCompleted = new Action<uint>(this.OnSceneLoaded)
			};
			AsyncOperation asyncOperation = this.SceneManagerHandler.LoadSceneAsync(sceneName, sceneEventData.LoadSceneMode, sceneEventProgress);
			NetworkSceneManager.SceneEventDelegate onSceneEvent = this.OnSceneEvent;
			if (onSceneEvent != null)
			{
				onSceneEvent(new SceneEvent
				{
					AsyncOperation = asyncOperation,
					SceneEventType = sceneEventData.SceneEventType,
					LoadSceneMode = sceneEventData.LoadSceneMode,
					SceneName = sceneName,
					ClientId = this.NetworkManager.LocalClientId
				});
			}
			NetworkSceneManager.OnLoadDelegateHandler onLoad = this.OnLoad;
			if (onLoad == null)
			{
				return;
			}
			onLoad(this.NetworkManager.LocalClientId, sceneName, sceneEventData.LoadSceneMode, asyncOperation);
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x00017F60 File Offset: 0x00016160
		private void OnSceneLoaded(uint sceneEventId)
		{
			if (!this.NetworkManager.IsListening || this.NetworkManager.ShutdownInProgress)
			{
				return;
			}
			SceneEventData sceneEventData = this.SceneEventDataStore[sceneEventId];
			Scene andAddNewlyLoadedSceneByName = this.GetAndAddNewlyLoadedSceneByName(this.SceneNameFromHash(sceneEventData.SceneHash));
			if (!andAddNewlyLoadedSceneByName.isLoaded || !andAddNewlyLoadedSceneByName.IsValid())
			{
				throw new Exception("Failed to find valid scene internal Unity.Netcode for GameObjects error!");
			}
			if (sceneEventData.LoadSceneMode == LoadSceneMode.Single)
			{
				SceneManager.SetActiveScene(andAddNewlyLoadedSceneByName);
			}
			this.PopulateScenePlacedObjects(andAddNewlyLoadedSceneByName, true);
			if (sceneEventData.LoadSceneMode == LoadSceneMode.Single)
			{
				this.MoveObjectsFromDontDestroyOnLoadToScene(andAddNewlyLoadedSceneByName);
			}
			NetworkSceneManager.IsSpawnedObjectsPendingInDontDestroyOnLoad = false;
			if (this.NetworkManager.IsServer)
			{
				this.OnServerLoadedScene(sceneEventId, andAddNewlyLoadedSceneByName);
				return;
			}
			if (!this.UpdateServerClientSceneHandle(sceneEventData.SceneHandle, andAddNewlyLoadedSceneByName.handle, andAddNewlyLoadedSceneByName))
			{
				throw new Exception(string.Format("Server Scene Handle ({0}) already exist!  Happened during scene load of {1} with Client Handle ({2})", sceneEventData.SceneHandle, andAddNewlyLoadedSceneByName.name, andAddNewlyLoadedSceneByName.handle));
			}
			this.OnClientLoadedScene(sceneEventId, andAddNewlyLoadedSceneByName);
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x00018054 File Offset: 0x00016254
		private void OnServerLoadedScene(uint sceneEventId, Scene scene)
		{
			SceneEventData sceneEventData = this.SceneEventDataStore[sceneEventId];
			foreach (KeyValuePair<uint, Dictionary<int, NetworkObject>> keyValuePair in this.ScenePlacedObjects)
			{
				foreach (KeyValuePair<int, NetworkObject> keyValuePair2 in keyValuePair.Value)
				{
					if (!keyValuePair2.Value.IsPlayerObject)
					{
						this.NetworkManager.SpawnManager.SpawnNetworkObjectLocally(keyValuePair2.Value, this.NetworkManager.SpawnManager.GetNetworkObjectId(), true, false, 0UL, true);
					}
				}
			}
			foreach (KeyValuePair<uint, Dictionary<int, NetworkObject>> keyValuePair3 in this.ScenePlacedObjects)
			{
				foreach (KeyValuePair<int, NetworkObject> keyValuePair4 in keyValuePair3.Value)
				{
					if (!keyValuePair4.Value.IsPlayerObject)
					{
						keyValuePair4.Value.InternalInSceneNetworkObjectsSpawned();
					}
				}
			}
			sceneEventData.AddDespawnedInSceneNetworkObjects();
			sceneEventData.SceneHandle = scene.handle;
			for (int i = 0; i < this.NetworkManager.ConnectedClientsList.Count; i++)
			{
				ulong clientId = this.NetworkManager.ConnectedClientsList[i].ClientId;
				if (clientId != 0UL)
				{
					sceneEventData.TargetClientId = clientId;
					SceneEventMessage sceneEventMessage = new SceneEventMessage
					{
						EventData = sceneEventData
					};
					int num = this.NetworkManager.ConnectionManager.SendMessage<SceneEventMessage>(ref sceneEventMessage, NetworkDelivery.ReliableFragmentedSequenced, clientId);
					this.NetworkManager.NetworkMetrics.TrackSceneEventSent(clientId, (uint)sceneEventData.SceneEventType, scene.name, (long)num);
				}
			}
			this.m_IsSceneEventActive = false;
			NetworkSceneManager.SceneEventDelegate onSceneEvent = this.OnSceneEvent;
			if (onSceneEvent != null)
			{
				onSceneEvent(new SceneEvent
				{
					SceneEventType = SceneEventType.LoadComplete,
					LoadSceneMode = sceneEventData.LoadSceneMode,
					SceneName = this.SceneNameFromHash(sceneEventData.SceneHash),
					ClientId = 0UL,
					Scene = scene
				});
			}
			NetworkSceneManager.OnLoadCompleteDelegateHandler onLoadComplete = this.OnLoadComplete;
			if (onLoadComplete != null)
			{
				onLoadComplete(0UL, this.SceneNameFromHash(sceneEventData.SceneHash), sceneEventData.LoadSceneMode);
			}
			if (this.SceneEventProgressTracking.ContainsKey(sceneEventData.SceneEventProgressId) && this.NetworkManager.IsHost)
			{
				this.SceneEventProgressTracking[sceneEventData.SceneEventProgressId].ClientFinishedSceneEvent(0UL);
			}
			this.EndSceneEvent(sceneEventId);
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x00018320 File Offset: 0x00016520
		private void OnClientLoadedScene(uint sceneEventId, Scene scene)
		{
			SceneEventData sceneEventData = this.SceneEventDataStore[sceneEventId];
			sceneEventData.DeserializeScenePlacedObjects();
			sceneEventData.SceneEventType = SceneEventType.LoadComplete;
			this.SendSceneEventData(sceneEventId, new ulong[1]);
			this.m_IsSceneEventActive = false;
			this.ProcessDeferredCreateObjectMessages();
			NetworkSceneManager.SceneEventDelegate onSceneEvent = this.OnSceneEvent;
			if (onSceneEvent != null)
			{
				onSceneEvent(new SceneEvent
				{
					SceneEventType = SceneEventType.LoadComplete,
					LoadSceneMode = sceneEventData.LoadSceneMode,
					SceneName = this.SceneNameFromHash(sceneEventData.SceneHash),
					ClientId = this.NetworkManager.LocalClientId,
					Scene = scene
				});
			}
			NetworkSceneManager.OnLoadCompleteDelegateHandler onLoadComplete = this.OnLoadComplete;
			if (onLoadComplete != null)
			{
				onLoadComplete(this.NetworkManager.LocalClientId, this.SceneNameFromHash(sceneEventData.SceneHash), sceneEventData.LoadSceneMode);
			}
			this.EndSceneEvent(sceneEventId);
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x000183EC File Offset: 0x000165EC
		internal void SynchronizeNetworkObjects(ulong clientId)
		{
			this.NetworkManager.SpawnManager.UpdateObservedNetworkObjects(clientId);
			SceneEventData sceneEventData = this.BeginSceneEvent();
			sceneEventData.ClientSynchronizationMode = this.ClientSynchronizationMode;
			sceneEventData.InitializeForSynch();
			sceneEventData.TargetClientId = clientId;
			sceneEventData.LoadSceneMode = this.ClientSynchronizationMode;
			Scene activeScene = SceneManager.GetActiveScene();
			sceneEventData.SceneEventType = SceneEventType.Synchronize;
			if (this.BuildIndexToHash.ContainsKey(activeScene.buildIndex))
			{
				sceneEventData.ActiveSceneHash = this.BuildIndexToHash[activeScene.buildIndex];
			}
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				if ((this.ExcludeSceneFromSychronization == null || this.ExcludeSceneFromSychronization(sceneAt)) && !(sceneAt == this.DontDestroyOnLoadScene))
				{
					if (activeScene == sceneAt)
					{
						if (!this.ValidateSceneBeforeLoading(sceneAt.buildIndex, sceneAt.name, sceneEventData.LoadSceneMode))
						{
							goto IL_129;
						}
						sceneEventData.SceneHash = this.SceneHashFromNameOrPath(sceneAt.path);
						sceneEventData.SceneHandle = sceneAt.handle;
					}
					else if (!this.ValidateSceneBeforeLoading(sceneAt.buildIndex, sceneAt.name, LoadSceneMode.Additive))
					{
						goto IL_129;
					}
					sceneEventData.AddSceneToSynchronize(this.SceneHashFromNameOrPath(sceneAt.path), sceneAt.handle);
				}
				IL_129:;
			}
			sceneEventData.AddSpawnedNetworkObjects();
			sceneEventData.AddDespawnedInSceneNetworkObjects();
			SceneEventMessage sceneEventMessage = new SceneEventMessage
			{
				EventData = sceneEventData
			};
			int num = this.NetworkManager.ConnectionManager.SendMessage<SceneEventMessage>(ref sceneEventMessage, NetworkDelivery.ReliableFragmentedSequenced, clientId);
			this.NetworkManager.NetworkMetrics.TrackSceneEventSent(clientId, (uint)sceneEventData.SceneEventType, "", (long)num);
			NetworkSceneManager.SceneEventDelegate onSceneEvent = this.OnSceneEvent;
			if (onSceneEvent != null)
			{
				onSceneEvent(new SceneEvent
				{
					SceneEventType = sceneEventData.SceneEventType,
					ClientId = clientId
				});
			}
			NetworkSceneManager.OnSynchronizeDelegateHandler onSynchronize = this.OnSynchronize;
			if (onSynchronize != null)
			{
				onSynchronize(clientId);
			}
			this.EndSceneEvent(sceneEventData.SceneEventId);
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x000185D0 File Offset: 0x000167D0
		private void OnClientBeginSync(uint sceneEventId)
		{
			SceneEventData sceneEventData = this.SceneEventDataStore[sceneEventId];
			uint nextSceneSynchronizationHash = sceneEventData.GetNextSceneSynchronizationHash();
			int nextSceneSynchronizationHandle = sceneEventData.GetNextSceneSynchronizationHandle();
			string text = this.SceneNameFromHash(nextSceneSynchronizationHash);
			SceneManager.GetActiveScene();
			LoadSceneMode loadSceneMode = (nextSceneSynchronizationHash == sceneEventData.SceneHash) ? sceneEventData.LoadSceneMode : LoadSceneMode.Additive;
			sceneEventData.NetworkSceneHandle = nextSceneSynchronizationHandle;
			sceneEventData.ClientSceneHash = nextSceneSynchronizationHash;
			if (nextSceneSynchronizationHash == sceneEventData.SceneHash)
			{
				NetworkSceneManager.SceneEventDelegate onSceneEvent = this.OnSceneEvent;
				if (onSceneEvent != null)
				{
					onSceneEvent(new SceneEvent
					{
						SceneEventType = SceneEventType.Synchronize,
						ClientId = this.NetworkManager.LocalClientId
					});
				}
				NetworkSceneManager.OnSynchronizeDelegateHandler onSynchronize = this.OnSynchronize;
				if (onSynchronize != null)
				{
					onSynchronize(this.NetworkManager.LocalClientId);
				}
			}
			if (!this.ValidateSceneBeforeLoading(nextSceneSynchronizationHash, loadSceneMode))
			{
				this.HandleClientSceneEvent(sceneEventId);
				if (this.NetworkManager.LogLevel == LogLevel.Developer)
				{
					NetworkLog.LogInfo("Client declined to load the scene " + text + ", continuing with synchronization.");
				}
				return;
			}
			if (this.SceneManagerHandler.ClientShouldPassThrough(text, nextSceneSynchronizationHash == sceneEventData.SceneHash, this.ClientSynchronizationMode, this.NetworkManager))
			{
				this.ClientLoadedSynchronization(sceneEventId);
				return;
			}
			SceneEventProgress sceneEventProgress = new SceneEventProgress(this.NetworkManager, SceneEventProgressStatus.Started)
			{
				SceneEventId = sceneEventId,
				OnSceneEventCompleted = new Action<uint>(this.ClientLoadedSynchronization)
			};
			AsyncOperation asyncOperation = this.SceneManagerHandler.LoadSceneAsync(text, loadSceneMode, sceneEventProgress);
			NetworkSceneManager.SceneEventDelegate onSceneEvent2 = this.OnSceneEvent;
			if (onSceneEvent2 != null)
			{
				onSceneEvent2(new SceneEvent
				{
					AsyncOperation = asyncOperation,
					SceneEventType = SceneEventType.Load,
					LoadSceneMode = loadSceneMode,
					SceneName = text,
					ClientId = this.NetworkManager.LocalClientId
				});
			}
			NetworkSceneManager.OnLoadDelegateHandler onLoad = this.OnLoad;
			if (onLoad == null)
			{
				return;
			}
			onLoad(this.NetworkManager.LocalClientId, text, loadSceneMode, asyncOperation);
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x00018780 File Offset: 0x00016980
		private void ClientLoadedSynchronization(uint sceneEventId)
		{
			SceneEventData sceneEventData = this.SceneEventDataStore[sceneEventId];
			string sceneName = this.SceneNameFromHash(sceneEventData.ClientSceneHash);
			Scene scene = this.SceneManagerHandler.GetSceneFromLoadedScenes(sceneName, this.NetworkManager);
			if (!scene.IsValid())
			{
				scene = this.GetAndAddNewlyLoadedSceneByName(sceneName);
			}
			if (!scene.isLoaded || !scene.IsValid())
			{
				throw new Exception("Failed to find valid scene internal Unity.Netcode for GameObjects error!");
			}
			LoadSceneMode loadSceneMode = (sceneEventData.ClientSceneHash == sceneEventData.SceneHash) ? sceneEventData.LoadSceneMode : LoadSceneMode.Additive;
			if (loadSceneMode == LoadSceneMode.Single)
			{
				SceneManager.SetActiveScene(scene);
			}
			if (!this.UpdateServerClientSceneHandle(sceneEventData.NetworkSceneHandle, scene.handle, scene))
			{
				throw new Exception(string.Format("Server Scene Handle ({0}) already exist!  Happened during scene load of {1} with Client Handle ({2})", sceneEventData.SceneHandle, scene.name, scene.handle));
			}
			this.PopulateScenePlacedObjects(scene, false);
			SceneEventData sceneEventData2 = this.BeginSceneEvent();
			sceneEventData2.LoadSceneMode = loadSceneMode;
			sceneEventData2.SceneEventType = SceneEventType.LoadComplete;
			sceneEventData2.SceneHash = sceneEventData.ClientSceneHash;
			SceneEventMessage sceneEventMessage = new SceneEventMessage
			{
				EventData = sceneEventData2
			};
			int num = this.NetworkManager.ConnectionManager.SendMessage<SceneEventMessage>(ref sceneEventMessage, NetworkDelivery.ReliableFragmentedSequenced, 0UL);
			this.NetworkManager.NetworkMetrics.TrackSceneEventSent(0UL, (uint)sceneEventData2.SceneEventType, sceneName, (long)num);
			this.EndSceneEvent(sceneEventData2.SceneEventId);
			NetworkSceneManager.SceneEventDelegate onSceneEvent = this.OnSceneEvent;
			if (onSceneEvent != null)
			{
				onSceneEvent(new SceneEvent
				{
					SceneEventType = SceneEventType.LoadComplete,
					LoadSceneMode = loadSceneMode,
					SceneName = sceneName,
					Scene = scene,
					ClientId = this.NetworkManager.LocalClientId
				});
			}
			NetworkSceneManager.OnLoadCompleteDelegateHandler onLoadComplete = this.OnLoadComplete;
			if (onLoadComplete != null)
			{
				onLoadComplete(this.NetworkManager.LocalClientId, sceneName, loadSceneMode);
			}
			this.HandleClientSceneEvent(sceneEventId);
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x0001893C File Offset: 0x00016B3C
		private void SynchronizeNetworkObjectScene()
		{
			foreach (NetworkObject networkObject in this.NetworkManager.SpawnManager.SpawnedObjectsList)
			{
				if (!networkObject.IsSceneObject.Value && this.ServerSceneHandleToClientSceneHandle.ContainsKey(networkObject.NetworkSceneHandle))
				{
					networkObject.SceneOriginHandle = this.ServerSceneHandleToClientSceneHandle[networkObject.NetworkSceneHandle];
					if (networkObject.gameObject.scene.handle != networkObject.SceneOriginHandle && networkObject.transform.parent == null)
					{
						if (this.ScenesLoaded.ContainsKey(networkObject.SceneOriginHandle))
						{
							Scene scene = this.ScenesLoaded[networkObject.SceneOriginHandle];
							if (scene == this.DontDestroyOnLoadScene)
							{
								Debug.Log(networkObject.gameObject.name + " migrating into DDOL!");
							}
							SceneManager.MoveGameObjectToScene(networkObject.gameObject, scene);
						}
						else if (this.NetworkManager.LogLevel <= LogLevel.Normal)
						{
							NetworkLog.LogWarningServer(string.Format("[Client-{0}][{1}] Server - ", this.NetworkManager.LocalClientId, networkObject.gameObject.name) + string.Format("client scene mismatch detected! Client-side has no scene loaded with handle ({0})!", networkObject.SceneOriginHandle));
						}
					}
				}
			}
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x00018AC8 File Offset: 0x00016CC8
		private void HandleClientSceneEvent(uint sceneEventId)
		{
			SceneEventData sceneEventData = this.SceneEventDataStore[sceneEventId];
			switch (sceneEventData.SceneEventType)
			{
			case SceneEventType.Load:
				this.OnClientSceneLoadingEvent(sceneEventId);
				return;
			case SceneEventType.Unload:
				this.OnClientUnloadScene(sceneEventId);
				return;
			case SceneEventType.Synchronize:
			{
				if (!sceneEventData.IsDoneWithSynchronization())
				{
					this.OnClientBeginSync(sceneEventId);
					return;
				}
				this.PopulateScenePlacedObjects(this.DontDestroyOnLoadScene, false);
				if (this.HashToBuildIndex.ContainsKey(sceneEventData.ActiveSceneHash))
				{
					Scene sceneByBuildIndex = SceneManager.GetSceneByBuildIndex(this.HashToBuildIndex[sceneEventData.ActiveSceneHash]);
					if (sceneByBuildIndex.isLoaded && sceneByBuildIndex.handle != SceneManager.GetActiveScene().handle)
					{
						SceneManager.SetActiveScene(sceneByBuildIndex);
					}
				}
				sceneEventData.SynchronizeSceneNetworkObjects(this.NetworkManager);
				this.SynchronizeNetworkObjectScene();
				this.ProcessDeferredCreateObjectMessages();
				sceneEventData.SceneEventType = SceneEventType.SynchronizeComplete;
				this.SendSceneEventData(sceneEventId, new ulong[1]);
				this.NetworkManager.IsConnectedClient = true;
				this.NetworkManager.ConnectionManager.InvokeOnClientConnectedCallback(this.NetworkManager.LocalClientId);
				NetworkSceneManager.SceneEventDelegate onSceneEvent = this.OnSceneEvent;
				if (onSceneEvent != null)
				{
					onSceneEvent(new SceneEvent
					{
						SceneEventType = sceneEventData.SceneEventType,
						ClientId = this.NetworkManager.LocalClientId
					});
				}
				sceneEventData.ProcessDeferredObjectSceneChangedEvents();
				if (this.PostSynchronizationSceneUnloading && this.ClientSynchronizationMode == LoadSceneMode.Additive)
				{
					this.SceneManagerHandler.UnloadUnassignedScenes(this.NetworkManager);
				}
				NetworkSceneManager.OnSynchronizeCompleteDelegateHandler onSynchronizeComplete = this.OnSynchronizeComplete;
				if (onSynchronizeComplete != null)
				{
					onSynchronizeComplete(this.NetworkManager.LocalClientId);
				}
				foreach (NetworkObject networkObject in this.NetworkManager.SpawnManager.SpawnedObjectsList)
				{
					networkObject.InternalNetworkSessionSynchronized();
				}
				this.EndSceneEvent(sceneEventId);
				return;
			}
			case SceneEventType.ReSynchronize:
			{
				NetworkSceneManager.SceneEventDelegate onSceneEvent2 = this.OnSceneEvent;
				if (onSceneEvent2 != null)
				{
					onSceneEvent2(new SceneEvent
					{
						SceneEventType = sceneEventData.SceneEventType,
						ClientId = 0UL
					});
				}
				this.EndSceneEvent(sceneEventId);
				return;
			}
			case SceneEventType.LoadEventCompleted:
			case SceneEventType.UnloadEventCompleted:
			{
				NetworkSceneManager.SceneEventDelegate onSceneEvent3 = this.OnSceneEvent;
				if (onSceneEvent3 != null)
				{
					onSceneEvent3(new SceneEvent
					{
						SceneEventType = sceneEventData.SceneEventType,
						LoadSceneMode = sceneEventData.LoadSceneMode,
						SceneName = this.SceneNameFromHash(sceneEventData.SceneHash),
						ClientId = 0UL,
						ClientsThatCompleted = sceneEventData.ClientsCompleted,
						ClientsThatTimedOut = sceneEventData.ClientsTimedOut
					});
				}
				if (sceneEventData.SceneEventType == SceneEventType.LoadEventCompleted)
				{
					NetworkSceneManager.OnEventCompletedDelegateHandler onLoadEventCompleted = this.OnLoadEventCompleted;
					if (onLoadEventCompleted != null)
					{
						onLoadEventCompleted(this.SceneNameFromHash(sceneEventData.SceneHash), sceneEventData.LoadSceneMode, sceneEventData.ClientsCompleted, sceneEventData.ClientsTimedOut);
					}
				}
				else
				{
					NetworkSceneManager.OnEventCompletedDelegateHandler onUnloadEventCompleted = this.OnUnloadEventCompleted;
					if (onUnloadEventCompleted != null)
					{
						onUnloadEventCompleted(this.SceneNameFromHash(sceneEventData.SceneHash), sceneEventData.LoadSceneMode, sceneEventData.ClientsCompleted, sceneEventData.ClientsTimedOut);
					}
				}
				this.EndSceneEvent(sceneEventId);
				return;
			}
			case SceneEventType.ActiveSceneChanged:
			{
				if (!this.HashToBuildIndex.ContainsKey(sceneEventData.ActiveSceneHash))
				{
					return;
				}
				Scene sceneByBuildIndex2 = SceneManager.GetSceneByBuildIndex(this.HashToBuildIndex[sceneEventData.ActiveSceneHash]);
				if (sceneByBuildIndex2.isLoaded)
				{
					SceneManager.SetActiveScene(sceneByBuildIndex2);
					return;
				}
				return;
			}
			case SceneEventType.ObjectSceneChanged:
				this.MigrateNetworkObjectsIntoScenes();
				return;
			}
			Debug.LogWarning(string.Format("{0} is not currently supported!", sceneEventData.SceneEventType));
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x00018E24 File Offset: 0x00017024
		private void HandleServerSceneEvent(uint sceneEventId, ulong clientId)
		{
			SceneEventData sceneEventData = this.SceneEventDataStore[sceneEventId];
			switch (sceneEventData.SceneEventType)
			{
			case SceneEventType.LoadComplete:
			{
				NetworkSceneManager.SceneEventDelegate onSceneEvent = this.OnSceneEvent;
				if (onSceneEvent != null)
				{
					onSceneEvent(new SceneEvent
					{
						SceneEventType = sceneEventData.SceneEventType,
						LoadSceneMode = sceneEventData.LoadSceneMode,
						SceneName = this.SceneNameFromHash(sceneEventData.SceneHash),
						ClientId = clientId
					});
				}
				NetworkSceneManager.OnLoadCompleteDelegateHandler onLoadComplete = this.OnLoadComplete;
				if (onLoadComplete != null)
				{
					onLoadComplete(clientId, this.SceneNameFromHash(sceneEventData.SceneHash), sceneEventData.LoadSceneMode);
				}
				if (this.SceneEventProgressTracking.ContainsKey(sceneEventData.SceneEventProgressId))
				{
					this.SceneEventProgressTracking[sceneEventData.SceneEventProgressId].ClientFinishedSceneEvent(clientId);
				}
				this.EndSceneEvent(sceneEventId);
				return;
			}
			case SceneEventType.UnloadComplete:
			{
				if (this.SceneEventProgressTracking.ContainsKey(sceneEventData.SceneEventProgressId))
				{
					this.SceneEventProgressTracking[sceneEventData.SceneEventProgressId].ClientFinishedSceneEvent(clientId);
				}
				NetworkSceneManager.SceneEventDelegate onSceneEvent2 = this.OnSceneEvent;
				if (onSceneEvent2 != null)
				{
					onSceneEvent2(new SceneEvent
					{
						SceneEventType = sceneEventData.SceneEventType,
						LoadSceneMode = sceneEventData.LoadSceneMode,
						SceneName = this.SceneNameFromHash(sceneEventData.SceneHash),
						ClientId = clientId
					});
				}
				NetworkSceneManager.OnUnloadCompleteDelegateHandler onUnloadComplete = this.OnUnloadComplete;
				if (onUnloadComplete != null)
				{
					onUnloadComplete(clientId, this.SceneNameFromHash(sceneEventData.SceneHash));
				}
				this.EndSceneEvent(sceneEventId);
				return;
			}
			case SceneEventType.SynchronizeComplete:
			{
				NetworkSceneManager.SceneEventDelegate onSceneEvent3 = this.OnSceneEvent;
				if (onSceneEvent3 != null)
				{
					onSceneEvent3(new SceneEvent
					{
						SceneEventType = sceneEventData.SceneEventType,
						SceneName = string.Empty,
						ClientId = clientId
					});
				}
				this.NetworkManager.ConnectedClients[clientId].IsConnected = true;
				NetworkSceneManager.OnSynchronizeCompleteDelegateHandler onSynchronizeComplete = this.OnSynchronizeComplete;
				if (onSynchronizeComplete != null)
				{
					onSynchronizeComplete(clientId);
				}
				this.NetworkManager.ConnectionManager.InvokeOnClientConnectedCallback(clientId);
				if (this.NetworkManager.IsHost)
				{
					this.NetworkManager.ConnectionManager.InvokeOnPeerConnectedCallback(clientId);
				}
				if (sceneEventData.ClientNeedsReSynchronization() && !NetworkSceneManager.DisableReSynchronization && this.NetworkManager.ConnectedClients.ContainsKey(clientId))
				{
					sceneEventData.SceneEventType = SceneEventType.ReSynchronize;
					this.SendSceneEventData(sceneEventId, new ulong[]
					{
						clientId
					});
					NetworkSceneManager.SceneEventDelegate onSceneEvent4 = this.OnSceneEvent;
					if (onSceneEvent4 != null)
					{
						onSceneEvent4(new SceneEvent
						{
							SceneEventType = sceneEventData.SceneEventType,
							SceneName = string.Empty,
							ClientId = clientId
						});
					}
				}
				this.EndSceneEvent(sceneEventId);
				return;
			}
			default:
				Debug.LogWarning(string.Format("{0} is not currently supported!", sceneEventData.SceneEventType));
				return;
			}
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x000190C4 File Offset: 0x000172C4
		internal void HandleSceneEvent(ulong clientId, FastBufferReader reader)
		{
			if (!(this.NetworkManager != null))
			{
				Debug.LogError("HandleSceneEvent was invoked but NetworkManager reference was null!");
				return;
			}
			SceneEventData sceneEventData = this.BeginSceneEvent();
			sceneEventData.Deserialize(reader);
			this.NetworkManager.NetworkMetrics.TrackSceneEventReceived(clientId, (uint)sceneEventData.SceneEventType, this.SceneNameFromHash(sceneEventData.SceneHash), (long)reader.Length);
			if (sceneEventData.IsSceneEventClientSide())
			{
				if (sceneEventData.SceneEventType == SceneEventType.Synchronize)
				{
					this.ScenePlacedObjects.Clear();
					this.ClientSynchronizationMode = sceneEventData.ClientSynchronizationMode;
					if (this.ClientSynchronizationMode == LoadSceneMode.Additive)
					{
						this.SceneManagerHandler.PopulateLoadedScenes(ref this.ScenesLoaded, this.NetworkManager);
					}
				}
				this.HandleClientSceneEvent(sceneEventData.SceneEventId);
				return;
			}
			this.HandleServerSceneEvent(sceneEventData.SceneEventId, clientId);
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x00019188 File Offset: 0x00017388
		internal void MoveObjectsToDontDestroyOnLoad()
		{
			foreach (NetworkObject networkObject in new HashSet<NetworkObject>(this.NetworkManager.SpawnManager.SpawnedObjectsList))
			{
				if (!(networkObject == null) && (!(networkObject != null) || !(networkObject.gameObject.scene == this.DontDestroyOnLoadScene)))
				{
					if (!networkObject.DestroyWithScene)
					{
						if (networkObject.gameObject.transform.parent == null && networkObject.IsSceneObject != null && !networkObject.IsSceneObject.Value)
						{
							Object.DontDestroyOnLoad(networkObject.gameObject);
						}
					}
					else if (this.NetworkManager.IsServer)
					{
						networkObject.Despawn(true);
					}
				}
			}
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x00019278 File Offset: 0x00017478
		internal void PopulateScenePlacedObjects(Scene sceneToFilterBy, bool clearScenePlacedObjects = true)
		{
			if (clearScenePlacedObjects)
			{
				this.ScenePlacedObjects.Clear();
			}
			foreach (NetworkObject networkObject in Object.FindObjectsOfType<NetworkObject>())
			{
				uint globalObjectIdHash = networkObject.GlobalObjectIdHash;
				int handle = networkObject.gameObject.scene.handle;
				bool? isSceneObject = networkObject.IsSceneObject;
				bool flag = false;
				if (!(isSceneObject.GetValueOrDefault() == flag & isSceneObject != null) && (networkObject.NetworkManager == this.NetworkManager || networkObject.NetworkManagerOwner == null) && handle == sceneToFilterBy.handle)
				{
					if (!this.ScenePlacedObjects.ContainsKey(globalObjectIdHash))
					{
						this.ScenePlacedObjects.Add(globalObjectIdHash, new Dictionary<int, NetworkObject>());
					}
					if (this.ScenePlacedObjects[globalObjectIdHash].ContainsKey(handle))
					{
						string arg = (this.ScenePlacedObjects[globalObjectIdHash][handle] != null) ? this.ScenePlacedObjects[globalObjectIdHash][handle].name : "Null Entry";
						throw new Exception(networkObject.name + " tried to registered with ScenePlacedObjects which already contains " + string.Format("the same {0} value {1} for {2}!", "GlobalObjectIdHash", globalObjectIdHash, arg));
					}
					this.ScenePlacedObjects[globalObjectIdHash].Add(handle, networkObject);
				}
			}
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x000193D8 File Offset: 0x000175D8
		internal void MoveObjectsFromDontDestroyOnLoadToScene(Scene scene)
		{
			foreach (NetworkObject networkObject in this.NetworkManager.SpawnManager.SpawnedObjectsList)
			{
				if (!(networkObject == null) && networkObject.gameObject.scene == this.DontDestroyOnLoadScene && !networkObject.DestroyWithScene && networkObject.gameObject.transform.parent == null && networkObject.IsSceneObject != null && !networkObject.IsSceneObject.Value)
				{
					SceneManager.MoveGameObjectToScene(networkObject.gameObject, scene);
				}
			}
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0001949C File Offset: 0x0001769C
		internal void NotifyNetworkObjectSceneChanged(NetworkObject networkObject)
		{
			if (!this.NetworkManager.IsServer)
			{
				if (this.NetworkManager.LogLevel == LogLevel.Developer)
				{
					NetworkLog.LogErrorServer("[Please Report This Error][NotifyNetworkObjectSceneChanged] A client is trying to notify of an object's scene change!");
				}
				return;
			}
			bool? isSceneObject = networkObject.IsSceneObject;
			bool flag = false;
			if (!(isSceneObject.GetValueOrDefault() == flag & isSceneObject != null))
			{
				if (this.NetworkManager.LogLevel == LogLevel.Developer)
				{
					NetworkLog.LogErrorServer("[Please Report This Error][NotifyNetworkObjectSceneChanged] Trying to notify in-scene placed object scene change!");
				}
				return;
			}
			if (networkObject.gameObject.scene == SceneManager.GetActiveScene() && networkObject.ActiveSceneSynchronization)
			{
				return;
			}
			foreach (KeyValuePair<Guid, SceneEventProgress> keyValuePair in this.SceneEventProgressTracking)
			{
				if (!keyValuePair.Value.HasTimedOut() && keyValuePair.Value.Status == SceneEventProgressStatus.Started)
				{
					return;
				}
			}
			if (!this.ObjectsMigratedIntoNewScene.ContainsKey(networkObject.gameObject.scene.handle))
			{
				this.ObjectsMigratedIntoNewScene.Add(networkObject.gameObject.scene.handle, new List<NetworkObject>());
			}
			this.ObjectsMigratedIntoNewScene[networkObject.gameObject.scene.handle].Add(networkObject);
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x000195F0 File Offset: 0x000177F0
		internal void MigrateNetworkObjectsIntoScenes()
		{
			try
			{
				foreach (KeyValuePair<int, List<NetworkObject>> keyValuePair in this.ObjectsMigratedIntoNewScene)
				{
					if (this.ServerSceneHandleToClientSceneHandle.ContainsKey(keyValuePair.Key))
					{
						int key = this.ServerSceneHandleToClientSceneHandle[keyValuePair.Key];
						if (this.ScenesLoaded.ContainsKey(this.ServerSceneHandleToClientSceneHandle[keyValuePair.Key]))
						{
							Scene scene = this.ScenesLoaded[key];
							foreach (NetworkObject networkObject in keyValuePair.Value)
							{
								SceneManager.MoveGameObjectToScene(networkObject.gameObject, scene);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				NetworkLog.LogErrorServer(ex.Message + "\n Stack Trace:\n " + ex.StackTrace);
			}
			this.ObjectsMigratedIntoNewScene.Clear();
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x00019718 File Offset: 0x00017918
		internal void CheckForAndSendNetworkObjectSceneChanged()
		{
			if (!this.NetworkManager.IsServer || this.ObjectsMigratedIntoNewScene.Count == 0)
			{
				return;
			}
			this.m_ScenesToRemoveFromObjectMigration.Clear();
			foreach (KeyValuePair<int, List<NetworkObject>> keyValuePair in this.ObjectsMigratedIntoNewScene)
			{
				for (int i = keyValuePair.Value.Count - 1; i >= 0; i--)
				{
					if (!keyValuePair.Value[i].IsSpawned)
					{
						keyValuePair.Value.RemoveAt(i);
					}
				}
				if (keyValuePair.Value.Count == 0)
				{
					this.m_ScenesToRemoveFromObjectMigration.Add(keyValuePair.Key);
				}
			}
			foreach (int key in this.m_ScenesToRemoveFromObjectMigration)
			{
				this.ObjectsMigratedIntoNewScene.Remove(key);
			}
			if (this.ObjectsMigratedIntoNewScene.Count == 0)
			{
				return;
			}
			SceneEventData sceneEventData = this.BeginSceneEvent();
			sceneEventData.SceneEventType = SceneEventType.ObjectSceneChanged;
			this.SendSceneEventData(sceneEventData.SceneEventId, (from c in this.NetworkManager.ConnectedClientsIds
			where c > 0UL
			select c).ToArray<ulong>());
			this.EndSceneEvent(sceneEventData.SceneEventId);
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x00019898 File Offset: 0x00017A98
		internal void DeferCreateObject(ulong senderId, uint messageSize, NetworkObject.SceneObject sceneObject, FastBufferReader fastBufferReader)
		{
			NetworkSceneManager.DeferredObjectCreation item = new NetworkSceneManager.DeferredObjectCreation
			{
				SenderId = senderId,
				MessageSize = messageSize,
				SceneObject = sceneObject
			};
			item.FastBufferReader = new FastBufferReader(fastBufferReader.GetUnsafePtrAtCurrentPosition(), Allocator.Persistent, fastBufferReader.Length - fastBufferReader.Position, 0, Allocator.Temp);
			this.DeferredObjectCreationList.Add(item);
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x000198F8 File Offset: 0x00017AF8
		private void ProcessDeferredCreateObjectMessages()
		{
			if (this.DeferredObjectCreationList.Count == 0)
			{
				return;
			}
			NetworkManager networkManager = this.NetworkManager;
			foreach (NetworkSceneManager.DeferredObjectCreation deferredObjectCreation in this.DeferredObjectCreationList)
			{
				CreateObjectMessage.CreateObject(ref networkManager, deferredObjectCreation.SenderId, deferredObjectCreation.MessageSize, deferredObjectCreation.SceneObject, deferredObjectCreation.FastBufferReader);
			}
			this.DeferredObjectCreationCount = this.DeferredObjectCreationList.Count;
			this.DeferredObjectCreationList.Clear();
		}

		// Token: 0x0400027F RID: 639
		private const NetworkDelivery k_DeliveryType = NetworkDelivery.ReliableFragmentedSequenced;

		// Token: 0x04000280 RID: 640
		internal const int InvalidSceneNameOrPath = -1;

		// Token: 0x04000281 RID: 641
		internal static bool DisableReSynchronization;

		// Token: 0x04000282 RID: 642
		private bool m_IsSceneEventActive;

		// Token: 0x0400028C RID: 652
		public NetworkSceneManager.VerifySceneBeforeLoadingDelegateHandler VerifySceneBeforeLoading;

		// Token: 0x0400028D RID: 653
		public NetworkSceneManager.VerifySceneBeforeUnloadingDelegateHandler VerifySceneBeforeUnloading;

		// Token: 0x0400028E RID: 654
		public bool PostSynchronizationSceneUnloading;

		// Token: 0x0400028F RID: 655
		private bool m_ActiveSceneSynchronizationEnabled;

		// Token: 0x04000290 RID: 656
		internal ISceneManagerHandler SceneManagerHandler = new DefaultSceneManagerHandler();

		// Token: 0x04000291 RID: 657
		internal readonly Dictionary<Guid, SceneEventProgress> SceneEventProgressTracking = new Dictionary<Guid, SceneEventProgress>();

		// Token: 0x04000292 RID: 658
		internal readonly Dictionary<uint, Dictionary<int, NetworkObject>> ScenePlacedObjects = new Dictionary<uint, Dictionary<int, NetworkObject>>();

		// Token: 0x04000293 RID: 659
		internal Scene SceneBeingSynchronized;

		// Token: 0x04000294 RID: 660
		internal Dictionary<int, Scene> ScenesLoaded = new Dictionary<int, Scene>();

		// Token: 0x04000295 RID: 661
		internal Dictionary<int, int> ServerSceneHandleToClientSceneHandle = new Dictionary<int, int>();

		// Token: 0x04000296 RID: 662
		internal Dictionary<int, int> ClientSceneHandleToServerSceneHandle = new Dictionary<int, int>();

		// Token: 0x04000297 RID: 663
		internal Dictionary<uint, int> HashToBuildIndex = new Dictionary<uint, int>();

		// Token: 0x04000298 RID: 664
		internal Dictionary<int, uint> BuildIndexToHash = new Dictionary<int, uint>();

		// Token: 0x04000299 RID: 665
		internal static bool IsSpawnedObjectsPendingInDontDestroyOnLoad;

		// Token: 0x0400029A RID: 666
		internal Dictionary<uint, SceneEventData> SceneEventDataStore;

		// Token: 0x0400029B RID: 667
		internal readonly NetworkManager NetworkManager;

		// Token: 0x0400029C RID: 668
		internal Scene DontDestroyOnLoadScene;

		// Token: 0x0400029E RID: 670
		private bool m_DisableValidationWarningMessages;

		// Token: 0x0400029F RID: 671
		internal LoadSceneMode DeferLoadingFilter;

		// Token: 0x040002A0 RID: 672
		internal Func<string, Scene> OverrideGetAndAddNewlyLoadedSceneByName;

		// Token: 0x040002A1 RID: 673
		internal Func<Scene, bool> ExcludeSceneFromSychronization;

		// Token: 0x040002A2 RID: 674
		internal Dictionary<int, List<NetworkObject>> ObjectsMigratedIntoNewScene = new Dictionary<int, List<NetworkObject>>();

		// Token: 0x040002A3 RID: 675
		private List<int> m_ScenesToRemoveFromObjectMigration = new List<int>();

		// Token: 0x040002A4 RID: 676
		internal List<NetworkSceneManager.DeferredObjectsMovedEvent> DeferredObjectsMovedEvents = new List<NetworkSceneManager.DeferredObjectsMovedEvent>();

		// Token: 0x040002A5 RID: 677
		internal List<NetworkSceneManager.DeferredObjectCreation> DeferredObjectCreationList = new List<NetworkSceneManager.DeferredObjectCreation>();

		// Token: 0x040002A6 RID: 678
		internal int DeferredObjectCreationCount;

		// Token: 0x020000E1 RID: 225
		// (Invoke) Token: 0x060005A5 RID: 1445
		public delegate void SceneEventDelegate(SceneEvent sceneEvent);

		// Token: 0x020000E2 RID: 226
		// (Invoke) Token: 0x060005A9 RID: 1449
		public delegate void OnLoadDelegateHandler(ulong clientId, string sceneName, LoadSceneMode loadSceneMode, AsyncOperation asyncOperation);

		// Token: 0x020000E3 RID: 227
		// (Invoke) Token: 0x060005AD RID: 1453
		public delegate void OnUnloadDelegateHandler(ulong clientId, string sceneName, AsyncOperation asyncOperation);

		// Token: 0x020000E4 RID: 228
		// (Invoke) Token: 0x060005B1 RID: 1457
		public delegate void OnSynchronizeDelegateHandler(ulong clientId);

		// Token: 0x020000E5 RID: 229
		// (Invoke) Token: 0x060005B5 RID: 1461
		public delegate void OnEventCompletedDelegateHandler(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut);

		// Token: 0x020000E6 RID: 230
		// (Invoke) Token: 0x060005B9 RID: 1465
		public delegate void OnLoadCompleteDelegateHandler(ulong clientId, string sceneName, LoadSceneMode loadSceneMode);

		// Token: 0x020000E7 RID: 231
		// (Invoke) Token: 0x060005BD RID: 1469
		public delegate void OnUnloadCompleteDelegateHandler(ulong clientId, string sceneName);

		// Token: 0x020000E8 RID: 232
		// (Invoke) Token: 0x060005C1 RID: 1473
		public delegate void OnSynchronizeCompleteDelegateHandler(ulong clientId);

		// Token: 0x020000E9 RID: 233
		// (Invoke) Token: 0x060005C5 RID: 1477
		public delegate bool VerifySceneBeforeLoadingDelegateHandler(int sceneIndex, string sceneName, LoadSceneMode loadSceneMode);

		// Token: 0x020000EA RID: 234
		// (Invoke) Token: 0x060005C9 RID: 1481
		public delegate bool VerifySceneBeforeUnloadingDelegateHandler(Scene scene);

		// Token: 0x020000EB RID: 235
		internal class SceneUnloadEventHandler
		{
			// Token: 0x060005CC RID: 1484 RVA: 0x00019994 File Offset: 0x00017B94
			internal static void RegisterScene(NetworkSceneManager networkSceneManager, Scene scene, LoadSceneMode loadSceneMode, AsyncOperation asyncOperation = null)
			{
				NetworkManager networkManager = networkSceneManager.NetworkManager;
				if (!NetworkSceneManager.SceneUnloadEventHandler.s_Instances.ContainsKey(networkManager))
				{
					NetworkSceneManager.SceneUnloadEventHandler.s_Instances.Add(networkManager, new List<NetworkSceneManager.SceneUnloadEventHandler>());
				}
				ulong clientId = networkManager.IsServer ? 0UL : networkManager.LocalClientId;
				NetworkSceneManager.SceneUnloadEventHandler.s_Instances[networkManager].Add(new NetworkSceneManager.SceneUnloadEventHandler(networkSceneManager, scene, clientId, loadSceneMode, asyncOperation));
			}

			// Token: 0x060005CD RID: 1485 RVA: 0x000199F4 File Offset: 0x00017BF4
			private static void SceneUnloadComplete(NetworkSceneManager.SceneUnloadEventHandler sceneUnloadEventHandler)
			{
				if (sceneUnloadEventHandler == null || sceneUnloadEventHandler.m_NetworkSceneManager == null || sceneUnloadEventHandler.m_NetworkSceneManager.NetworkManager == null)
				{
					return;
				}
				NetworkManager networkManager = sceneUnloadEventHandler.m_NetworkSceneManager.NetworkManager;
				if (NetworkSceneManager.SceneUnloadEventHandler.s_Instances.ContainsKey(networkManager))
				{
					NetworkSceneManager.SceneUnloadEventHandler.s_Instances[networkManager].Remove(sceneUnloadEventHandler);
					if (NetworkSceneManager.SceneUnloadEventHandler.s_Instances[networkManager].Count == 0)
					{
						NetworkSceneManager.SceneUnloadEventHandler.s_Instances.Remove(networkManager);
					}
				}
			}

			// Token: 0x060005CE RID: 1486 RVA: 0x00019A6C File Offset: 0x00017C6C
			internal static void Shutdown()
			{
				foreach (KeyValuePair<NetworkManager, List<NetworkSceneManager.SceneUnloadEventHandler>> keyValuePair in NetworkSceneManager.SceneUnloadEventHandler.s_Instances)
				{
					foreach (NetworkSceneManager.SceneUnloadEventHandler sceneUnloadEventHandler in keyValuePair.Value)
					{
						sceneUnloadEventHandler.OnShutdown();
					}
					keyValuePair.Value.Clear();
				}
				NetworkSceneManager.SceneUnloadEventHandler.s_Instances.Clear();
			}

			// Token: 0x060005CF RID: 1487 RVA: 0x00019B10 File Offset: 0x00017D10
			private void OnShutdown()
			{
				this.m_ShuttingDown = true;
				SceneManager.sceneUnloaded -= this.SceneUnloaded;
			}

			// Token: 0x060005D0 RID: 1488 RVA: 0x00019B2C File Offset: 0x00017D2C
			private void SceneUnloaded(Scene scene)
			{
				if (this.m_Scene.handle == scene.handle && !this.m_ShuttingDown)
				{
					if (this.m_NetworkSceneManager != null && this.m_NetworkSceneManager.NetworkManager != null)
					{
						NetworkSceneManager.SceneEventDelegate onSceneEvent = this.m_NetworkSceneManager.OnSceneEvent;
						if (onSceneEvent != null)
						{
							onSceneEvent(new SceneEvent
							{
								AsyncOperation = this.m_AsyncOperation,
								SceneEventType = SceneEventType.UnloadComplete,
								SceneName = this.m_Scene.name,
								LoadSceneMode = this.m_LoadSceneMode,
								ClientId = this.m_ClientId
							});
						}
						NetworkSceneManager.OnUnloadCompleteDelegateHandler onUnloadComplete = this.m_NetworkSceneManager.OnUnloadComplete;
						if (onUnloadComplete != null)
						{
							onUnloadComplete(this.m_ClientId, this.m_Scene.name);
						}
					}
					SceneManager.sceneUnloaded -= this.SceneUnloaded;
					NetworkSceneManager.SceneUnloadEventHandler.SceneUnloadComplete(this);
				}
			}

			// Token: 0x060005D1 RID: 1489 RVA: 0x00019C10 File Offset: 0x00017E10
			private SceneUnloadEventHandler(NetworkSceneManager networkSceneManager, Scene scene, ulong clientId, LoadSceneMode loadSceneMode, AsyncOperation asyncOperation = null)
			{
				this.m_LoadSceneMode = loadSceneMode;
				this.m_AsyncOperation = asyncOperation;
				this.m_NetworkSceneManager = networkSceneManager;
				this.m_ClientId = clientId;
				this.m_Scene = scene;
				SceneManager.sceneUnloaded += this.SceneUnloaded;
				NetworkSceneManager.SceneEventDelegate onSceneEvent = this.m_NetworkSceneManager.OnSceneEvent;
				if (onSceneEvent != null)
				{
					onSceneEvent(new SceneEvent
					{
						AsyncOperation = this.m_AsyncOperation,
						SceneEventType = SceneEventType.Unload,
						SceneName = this.m_Scene.name,
						LoadSceneMode = this.m_LoadSceneMode,
						ClientId = clientId
					});
				}
				NetworkSceneManager.OnUnloadDelegateHandler onUnload = this.m_NetworkSceneManager.OnUnload;
				if (onUnload == null)
				{
					return;
				}
				onUnload(networkSceneManager.NetworkManager.LocalClientId, this.m_Scene.name, null);
			}

			// Token: 0x040002A7 RID: 679
			private static Dictionary<NetworkManager, List<NetworkSceneManager.SceneUnloadEventHandler>> s_Instances = new Dictionary<NetworkManager, List<NetworkSceneManager.SceneUnloadEventHandler>>();

			// Token: 0x040002A8 RID: 680
			private NetworkSceneManager m_NetworkSceneManager;

			// Token: 0x040002A9 RID: 681
			private AsyncOperation m_AsyncOperation;

			// Token: 0x040002AA RID: 682
			private LoadSceneMode m_LoadSceneMode;

			// Token: 0x040002AB RID: 683
			private ulong m_ClientId;

			// Token: 0x040002AC RID: 684
			private Scene m_Scene;

			// Token: 0x040002AD RID: 685
			private bool m_ShuttingDown;
		}

		// Token: 0x020000EC RID: 236
		internal struct DeferredObjectsMovedEvent
		{
			// Token: 0x040002AE RID: 686
			internal Dictionary<int, List<ulong>> ObjectsMigratedTable;
		}

		// Token: 0x020000ED RID: 237
		internal struct DeferredObjectCreation
		{
			// Token: 0x040002AF RID: 687
			internal ulong SenderId;

			// Token: 0x040002B0 RID: 688
			internal uint MessageSize;

			// Token: 0x040002B1 RID: 689
			internal NetworkObject.SceneObject SceneObject;

			// Token: 0x040002B2 RID: 690
			internal FastBufferReader FastBufferReader;
		}
	}
}
