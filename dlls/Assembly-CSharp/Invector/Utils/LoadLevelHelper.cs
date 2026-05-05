using System;
using System.Collections;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Invector.Utils
{
	// Token: 0x020003B1 RID: 945
	public static class LoadLevelHelper
	{
		// Token: 0x060012E5 RID: 4837 RVA: 0x00064180 File Offset: 0x00062380
		public static void LoadScene(string _sceneName, string _spawnPointName, vThirdPersonInput tpInput)
		{
			if (!tpInput)
			{
				return;
			}
			LoadLevelHelper.targetCharacter = tpInput;
			LoadLevelHelper.spawnPointName = _spawnPointName;
			LoadLevelHelper.sceneName = _sceneName;
			if (LoadLevelHelper.targetCharacter.tpCamera)
			{
				LoadLevelHelper.targetCharacter.tpCamera.transform.parent = LoadLevelHelper.targetCharacter.transform;
			}
			if (LoadLevelHelper.targetCharacter)
			{
				vISceneLoadListener[] components = LoadLevelHelper.targetCharacter.GetComponents<vISceneLoadListener>();
				for (int i = 0; i < components.Length; i++)
				{
					components[i].OnStartLoadScene(_sceneName);
				}
				LoadLevelHelper.targetCharacter.StartCoroutine(LoadLevelHelper.LoadAsyncScene());
			}
		}

		// Token: 0x060012E6 RID: 4838 RVA: 0x00064215 File Offset: 0x00062415
		private static IEnumerator LoadAsyncScene()
		{
			Scene currentScene = SceneManager.GetActiveScene();
			if (!currentScene.name.Equals(LoadLevelHelper.sceneName))
			{
				SceneManager.sceneUnloaded += LoadLevelHelper.OnSceneLoaded;
				AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(LoadLevelHelper.sceneName, LoadSceneMode.Additive);
				while (!asyncLoad.isDone)
				{
					yield return null;
				}
				SceneManager.MoveGameObjectToScene(LoadLevelHelper.targetCharacter.gameObject, SceneManager.GetSceneByName(LoadLevelHelper.sceneName));
				SceneManager.UnloadSceneAsync(currentScene);
				asyncLoad = null;
			}
			else
			{
				LoadLevelHelper.MoveCharaterToSpawnPoint();
			}
			yield break;
		}

		// Token: 0x060012E7 RID: 4839 RVA: 0x00064220 File Offset: 0x00062420
		private static void OnSceneLoaded(Scene arg0)
		{
			vISceneLoadListener[] components = LoadLevelHelper.targetCharacter.GetComponents<vISceneLoadListener>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i].OnFinishLoadScene(arg0.name);
			}
			LoadLevelHelper.MoveCharaterToSpawnPoint();
			SceneManager.sceneUnloaded -= LoadLevelHelper.OnSceneLoaded;
		}

		// Token: 0x060012E8 RID: 4840 RVA: 0x0006426C File Offset: 0x0006246C
		private static void MoveCharaterToSpawnPoint()
		{
			GameObject gameObject = GameObject.Find(LoadLevelHelper.spawnPointName);
			if (gameObject && LoadLevelHelper.targetCharacter)
			{
				LoadLevelHelper.targetCharacter.lockCameraInput = true;
				if (LoadLevelHelper.targetCharacter.tpCamera)
				{
					LoadLevelHelper.targetCharacter.tpCamera.FreezeCamera();
				}
				LoadLevelHelper.targetCharacter.transform.position = gameObject.transform.position;
				LoadLevelHelper.targetCharacter.transform.rotation = gameObject.transform.rotation;
				if (LoadLevelHelper.targetCharacter.tpCamera)
				{
					LoadLevelHelper.targetCharacter.tpCamera.transform.parent = null;
					LoadLevelHelper.targetCharacter.tpCamera.UnFreezeCamera();
				}
				LoadLevelHelper.targetCharacter.lockCameraInput = false;
			}
		}

		// Token: 0x040018BB RID: 6331
		public static vThirdPersonInput targetCharacter;

		// Token: 0x040018BC RID: 6332
		public static string spawnPointName;

		// Token: 0x040018BD RID: 6333
		public static string sceneName;
	}
}
