using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.Netcode
{
	// Token: 0x020000DE RID: 222
	internal interface ISceneManagerHandler
	{
		// Token: 0x0600054F RID: 1359
		AsyncOperation LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode, SceneEventProgress sceneEventProgress);

		// Token: 0x06000550 RID: 1360
		AsyncOperation UnloadSceneAsync(Scene scene, SceneEventProgress sceneEventProgress);

		// Token: 0x06000551 RID: 1361
		void PopulateLoadedScenes(ref Dictionary<int, Scene> scenesLoaded, NetworkManager networkManager = null);

		// Token: 0x06000552 RID: 1362
		Scene GetSceneFromLoadedScenes(string sceneName, NetworkManager networkManager = null);

		// Token: 0x06000553 RID: 1363
		bool DoesSceneHaveUnassignedEntry(string sceneName, NetworkManager networkManager = null);

		// Token: 0x06000554 RID: 1364
		void StopTrackingScene(int handle, string name, NetworkManager networkManager = null);

		// Token: 0x06000555 RID: 1365
		void StartTrackingScene(Scene scene, bool assigned, NetworkManager networkManager = null);

		// Token: 0x06000556 RID: 1366
		void ClearSceneTracking(NetworkManager networkManager = null);

		// Token: 0x06000557 RID: 1367
		void UnloadUnassignedScenes(NetworkManager networkManager = null);

		// Token: 0x06000558 RID: 1368
		void MoveObjectsFromSceneToDontDestroyOnLoad(ref NetworkManager networkManager, Scene scene);

		// Token: 0x06000559 RID: 1369
		void SetClientSynchronizationMode(ref NetworkManager networkManager, LoadSceneMode mode);

		// Token: 0x0600055A RID: 1370
		bool ClientShouldPassThrough(string sceneName, bool isPrimaryScene, LoadSceneMode clientSynchronizationMode, NetworkManager networkManager);
	}
}
