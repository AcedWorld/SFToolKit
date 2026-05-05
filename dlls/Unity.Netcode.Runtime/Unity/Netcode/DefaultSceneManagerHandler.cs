using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.Netcode
{
	// Token: 0x020000DC RID: 220
	internal class DefaultSceneManagerHandler : ISceneManagerHandler
	{
		// Token: 0x06000541 RID: 1345 RVA: 0x00015D40 File Offset: 0x00013F40
		public AsyncOperation LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode, SceneEventProgress sceneEventProgress)
		{
			AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
			sceneEventProgress.SetAsyncOperation(asyncOperation);
			return asyncOperation;
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00015D60 File Offset: 0x00013F60
		public AsyncOperation UnloadSceneAsync(Scene scene, SceneEventProgress sceneEventProgress)
		{
			AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(scene);
			sceneEventProgress.SetAsyncOperation(asyncOperation);
			return asyncOperation;
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x00015D7C File Offset: 0x00013F7C
		public void ClearSceneTracking(NetworkManager networkManager)
		{
			this.SceneNameToSceneHandles.Clear();
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x00015D8C File Offset: 0x00013F8C
		public void StopTrackingScene(int handle, string name, NetworkManager networkManager)
		{
			if (this.SceneNameToSceneHandles.ContainsKey(name) && this.SceneNameToSceneHandles[name].ContainsKey(handle))
			{
				this.SceneNameToSceneHandles[name].Remove(handle);
				if (this.SceneNameToSceneHandles[name].Count == 0)
				{
					this.SceneNameToSceneHandles.Remove(name);
				}
			}
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00015DF0 File Offset: 0x00013FF0
		public void StartTrackingScene(Scene scene, bool assigned, NetworkManager networkManager)
		{
			if (!this.SceneNameToSceneHandles.ContainsKey(scene.name))
			{
				this.SceneNameToSceneHandles.Add(scene.name, new Dictionary<int, DefaultSceneManagerHandler.SceneEntry>());
			}
			if (!this.SceneNameToSceneHandles[scene.name].ContainsKey(scene.handle))
			{
				DefaultSceneManagerHandler.SceneEntry value = new DefaultSceneManagerHandler.SceneEntry
				{
					IsAssigned = true,
					Scene = scene
				};
				this.SceneNameToSceneHandles[scene.name].Add(scene.handle, value);
				return;
			}
			throw new Exception(string.Format("[Duplicate Handle] Scene {0} already has scene handle {1} registered!", scene.name, scene.handle));
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x00015EA4 File Offset: 0x000140A4
		public bool DoesSceneHaveUnassignedEntry(string sceneName, NetworkManager networkManager)
		{
			List<Scene> list = new List<Scene>();
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				if (sceneAt.name == sceneName)
				{
					list.Add(sceneAt);
				}
			}
			if (list.Count == 0)
			{
				return false;
			}
			if (list.Count > 0 && !this.SceneNameToSceneHandles.ContainsKey(sceneName))
			{
				return true;
			}
			foreach (Scene scene in list)
			{
				if (!this.SceneNameToSceneHandles[scene.name].ContainsKey(scene.handle))
				{
					return true;
				}
				if (!this.SceneNameToSceneHandles[scene.name][scene.handle].IsAssigned)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x00015F98 File Offset: 0x00014198
		public Scene GetSceneFromLoadedScenes(string sceneName, NetworkManager networkManager)
		{
			if (this.SceneNameToSceneHandles.ContainsKey(sceneName))
			{
				foreach (KeyValuePair<int, DefaultSceneManagerHandler.SceneEntry> keyValuePair in this.SceneNameToSceneHandles[sceneName])
				{
					if (!keyValuePair.Value.IsAssigned)
					{
						DefaultSceneManagerHandler.SceneEntry value = keyValuePair.Value;
						value.IsAssigned = true;
						this.SceneNameToSceneHandles[sceneName][keyValuePair.Key] = value;
						return value.Scene;
					}
				}
			}
			return this.m_InvalidScene;
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x00016040 File Offset: 0x00014240
		public void PopulateLoadedScenes(ref Dictionary<int, Scene> scenesLoaded, NetworkManager networkManager)
		{
			this.SceneNameToSceneHandles.Clear();
			int sceneCount = SceneManager.sceneCount;
			for (int i = 0; i < sceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				if (!this.SceneNameToSceneHandles.ContainsKey(sceneAt.name))
				{
					this.SceneNameToSceneHandles.Add(sceneAt.name, new Dictionary<int, DefaultSceneManagerHandler.SceneEntry>());
				}
				if (this.SceneNameToSceneHandles[sceneAt.name].ContainsKey(sceneAt.handle))
				{
					throw new Exception(string.Format("[Duplicate Handle] Scene {0} already has scene handle {1} registered!", sceneAt.name, sceneAt.handle));
				}
				DefaultSceneManagerHandler.SceneEntry value = new DefaultSceneManagerHandler.SceneEntry
				{
					IsAssigned = false,
					Scene = sceneAt
				};
				this.SceneNameToSceneHandles[sceneAt.name].Add(sceneAt.handle, value);
				if (!scenesLoaded.ContainsKey(sceneAt.handle))
				{
					scenesLoaded.Add(sceneAt.handle, sceneAt);
				}
			}
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x00016140 File Offset: 0x00014340
		public void UnloadUnassignedScenes(NetworkManager networkManager = null)
		{
			NetworkSceneManager sceneManager = networkManager.SceneManager;
			SceneManager.sceneUnloaded += this.SceneManager_SceneUnloaded;
			foreach (KeyValuePair<string, Dictionary<int, DefaultSceneManagerHandler.SceneEntry>> keyValuePair in this.SceneNameToSceneHandles)
			{
				foreach (KeyValuePair<int, DefaultSceneManagerHandler.SceneEntry> keyValuePair2 in this.SceneNameToSceneHandles[keyValuePair.Key])
				{
					if (!keyValuePair2.Value.IsAssigned && (sceneManager.VerifySceneBeforeUnloading == null || sceneManager.VerifySceneBeforeUnloading(keyValuePair2.Value.Scene)))
					{
						this.m_ScenesToUnload.Add(keyValuePair2.Value.Scene);
					}
				}
			}
			foreach (Scene scene in this.m_ScenesToUnload)
			{
				SceneManager.UnloadSceneAsync(scene);
				if (sceneManager.ScenesLoaded.ContainsKey(scene.handle))
				{
					sceneManager.ScenesLoaded.Remove(scene.handle);
				}
			}
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x000162A4 File Offset: 0x000144A4
		private void SceneManager_SceneUnloaded(Scene scene)
		{
			if (this.SceneNameToSceneHandles.ContainsKey(scene.name))
			{
				if (this.SceneNameToSceneHandles[scene.name].ContainsKey(scene.handle))
				{
					this.SceneNameToSceneHandles[scene.name].Remove(scene.handle);
				}
				if (this.SceneNameToSceneHandles[scene.name].Count == 0)
				{
					this.SceneNameToSceneHandles.Remove(scene.name);
				}
				this.m_ScenesToUnload.Remove(scene);
				if (this.m_ScenesToUnload.Count == 0)
				{
					SceneManager.sceneUnloaded -= this.SceneManager_SceneUnloaded;
				}
			}
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x00016360 File Offset: 0x00014560
		public bool ClientShouldPassThrough(string sceneName, bool isPrimaryScene, LoadSceneMode clientSynchronizationMode, NetworkManager networkManager)
		{
			bool flag = clientSynchronizationMode != LoadSceneMode.Single && this.DoesSceneHaveUnassignedEntry(sceneName, networkManager);
			Scene activeScene = SceneManager.GetActiveScene();
			if (!flag && sceneName == activeScene.name && (clientSynchronizationMode == LoadSceneMode.Additive || (isPrimaryScene && clientSynchronizationMode == LoadSceneMode.Single)))
			{
				flag = true;
			}
			return flag;
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x000163A4 File Offset: 0x000145A4
		public void MoveObjectsFromSceneToDontDestroyOnLoad(ref NetworkManager networkManager, Scene scene)
		{
			scene == SceneManager.GetActiveScene();
			foreach (NetworkObject networkObject in new HashSet<NetworkObject>(networkManager.SpawnManager.SpawnedObjectsList))
			{
				if (!(networkObject == null) && (!(networkObject != null) || networkObject.gameObject.scene.handle == scene.handle))
				{
					if (!networkObject.DestroyWithScene && networkObject.gameObject.scene != networkManager.SceneManager.DontDestroyOnLoadScene)
					{
						if (networkObject.gameObject.transform.parent == null && networkObject.IsSceneObject != null && !networkObject.IsSceneObject.Value)
						{
							Object.DontDestroyOnLoad(networkObject.gameObject);
						}
					}
					else if (networkManager.IsServer)
					{
						networkObject.Despawn(true);
					}
					else
					{
						Object.DontDestroyOnLoad(networkObject.gameObject);
					}
				}
			}
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x000164CC File Offset: 0x000146CC
		public void SetClientSynchronizationMode(ref NetworkManager networkManager, LoadSceneMode mode)
		{
			NetworkSceneManager sceneManager = networkManager.SceneManager;
			if (!networkManager.IsServer)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Clients should not set this value as it is automatically synchronized with the server's setting!");
				}
				return;
			}
			if (networkManager.ConnectedClientsIds.Count > (networkManager.IsHost ? 1 : 0) && sceneManager.ClientSynchronizationMode != mode && NetworkLog.CurrentLogLevel <= LogLevel.Normal)
			{
				NetworkLog.LogWarning("Server is changing client synchronization mode after clients have been synchronized! It is recommended to do this before clients are connected!");
			}
			if (mode == LoadSceneMode.Additive)
			{
				for (int i = 0; i < SceneManager.sceneCount; i++)
				{
					Scene sceneAt = SceneManager.GetSceneAt(i);
					if ((sceneManager.VerifySceneBeforeLoading == null || sceneManager.VerifySceneBeforeLoading(sceneAt.buildIndex, sceneAt.name, LoadSceneMode.Additive)) && !sceneManager.ScenesLoaded.ContainsKey(sceneAt.handle))
					{
						sceneManager.ScenesLoaded.Add(sceneAt.handle, sceneAt);
					}
				}
			}
			sceneManager.ClientSynchronizationMode = mode;
		}

		// Token: 0x04000272 RID: 626
		private Scene m_InvalidScene;

		// Token: 0x04000273 RID: 627
		internal Dictionary<string, Dictionary<int, DefaultSceneManagerHandler.SceneEntry>> SceneNameToSceneHandles = new Dictionary<string, Dictionary<int, DefaultSceneManagerHandler.SceneEntry>>();

		// Token: 0x04000274 RID: 628
		private List<Scene> m_ScenesToUnload = new List<Scene>();

		// Token: 0x020000DD RID: 221
		internal struct SceneEntry
		{
			// Token: 0x04000275 RID: 629
			public bool IsAssigned;

			// Token: 0x04000276 RID: 630
			public Scene Scene;
		}
	}
}
