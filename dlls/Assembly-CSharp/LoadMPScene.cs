using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200004B RID: 75
public class LoadMPScene : MonoBehaviour
{
	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000110 RID: 272 RVA: 0x0000930F File Offset: 0x0000750F
	private static string ModMapsFolder
	{
		get
		{
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ScooterFlow", "ModMaps");
		}
	}

	// Token: 0x06000111 RID: 273 RVA: 0x00009328 File Offset: 0x00007528
	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		if (this.lobbyInfo != null && !string.IsNullOrEmpty(this.lobbyInfo.sceneName))
		{
			base.StartCoroutine(this.LoadThenDestroyAndJoin(this.lobbyInfo.sceneName, this.lobbyInfo.lobbyId));
			return;
		}
		this.SafeGoMenu("[LoadMPScene] Missing lobbyInfo or sceneName.");
	}

	// Token: 0x06000112 RID: 274 RVA: 0x00009389 File Offset: 0x00007589
	private IEnumerator LoadThenDestroyAndJoin(string maskedSceneName, string lobbyId)
	{
		string token = maskedSceneName;
		try
		{
			if (LobbyViewer.Instance != null)
			{
				token = LobbyViewer.Instance.GetRealSceneName(maskedSceneName);
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("[LoadMPScene] LobbyViewer resolve failed: " + ex.Message + ". Using raw token: " + maskedSceneName);
		}
		GameObject ui = null;
		if (this.loadingPrefab != null)
		{
			ui = Object.Instantiate<GameObject>(this.loadingPrefab);
			Object.DontDestroyOnLoad(ui);
		}
		if (LoadMPScene.IsModToken(token))
		{
			LoadMPScene.<>c__DisplayClass13_0 CS$<>8__locals1 = new LoadMPScene.<>c__DisplayClass13_0();
			string bundleFileName = token.Substring("mod:".Length).Trim();
			CS$<>8__locals1.ok = false;
			yield return this.TryLoadSceneFromBundleFile(bundleFileName, delegate(bool success)
			{
				CS$<>8__locals1.ok = success;
			});
			if (!CS$<>8__locals1.ok)
			{
				this.SafeGoMenu("[LoadMPScene] Explicit mod token failed: " + bundleFileName);
				yield break;
			}
			CS$<>8__locals1 = null;
			bundleFileName = null;
		}
		else
		{
			bool flag = false;
			bool flag2 = false;
			try
			{
				flag2 = (!string.IsNullOrEmpty(token) && Application.CanStreamedLevelBeLoaded(token));
			}
			catch (Exception ex2)
			{
				Debug.LogWarning("[LoadMPScene] CanStreamedLevelBeLoaded threw: " + ex2.Message);
				flag2 = false;
			}
			if (flag2)
			{
				AsyncOperation op = null;
				try
				{
					op = SceneManager.LoadSceneAsync(token);
				}
				catch (Exception ex3)
				{
					Debug.LogWarning("[LoadMPScene] LoadSceneAsync('" + token + "') threw: " + ex3.Message);
					op = null;
				}
				if (op != null)
				{
					while (!op.isDone)
					{
						yield return null;
					}
					flag = true;
					this._modMode = false;
					this._lastLoadedBundle = null;
				}
				op = null;
			}
			if (!flag)
			{
				LoadMPScene.<>c__DisplayClass13_1 CS$<>8__locals2 = new LoadMPScene.<>c__DisplayClass13_1();
				CS$<>8__locals2.ok = false;
				yield return this.TryFindAndLoadSceneFromAnyBundleBySceneName(token, delegate(bool success)
				{
					CS$<>8__locals2.ok = success;
				});
				if (!CS$<>8__locals2.ok)
				{
					this.SafeGoMenu("[LoadMPScene] Scene '" + token + "' not in Build Settings and not found in any local mod bundle.");
					yield break;
				}
				CS$<>8__locals2 = null;
			}
		}
		yield return null;
		GameObject newPCInstance = null;
		if (this._modMode)
		{
			GameObject spawnPoint = null;
			float spawnFindDeadline = Time.realtimeSinceStartup + 10f;
			while (spawnPoint == null && Time.realtimeSinceStartup < spawnFindDeadline)
			{
				spawnPoint = GameObject.Find("ModMap_Spawnpoint");
				if (spawnPoint != null)
				{
					break;
				}
				yield return null;
			}
			if (this.playerComponentsPrefab == null)
			{
				Debug.LogError("[LoadMPScene] playerComponentsPrefab is NOT assigned; cannot spawn PlayerComponents for modmap.");
			}
			else
			{
				Vector3 position = (spawnPoint != null) ? spawnPoint.transform.position : Vector3.zero;
				Quaternion rotation = (spawnPoint != null) ? spawnPoint.transform.rotation : Quaternion.identity;
				try
				{
					newPCInstance = Object.Instantiate<GameObject>(this.playerComponentsPrefab, position, rotation);
					Debug.Log("[LoadMPScene] Spawned PlayerComponents prefab for modmap (pre-cleanup).");
				}
				catch (Exception ex4)
				{
					this.SafeGoMenu("[LoadMPScene] Failed to instantiate PlayerComponents for modmap: " + ex4.Message);
					yield break;
				}
			}
			yield return new WaitForSecondsRealtime(1f);
			if (this._lastLoadedBundle != null)
			{
				try
				{
					this._lastLoadedBundle.Unload(false);
					LoadMPScene.s_RetainedBundles.Remove(this._lastLoadedBundle);
				}
				catch
				{
				}
				this._lastLoadedBundle = null;
			}
			float cleanupDeadline = Time.realtimeSinceStartup + 5f;
			bool allGone = false;
			while (Time.realtimeSinceStartup < cleanupDeadline)
			{
				bool flag3 = false;
				foreach (Transform transform in Object.FindObjectsOfType<Transform>(true))
				{
					if (transform != null && transform.name == "PlayerComponents")
					{
						try
						{
							Object.Destroy(transform.gameObject);
							flag3 = true;
							Debug.Log("[LoadMPScene] Destroyed a 'PlayerComponents' GameObject (modmap global cleanup).");
						}
						catch
						{
						}
					}
				}
				if (!flag3)
				{
					allGone = true;
					break;
				}
				yield return null;
			}
			if (!allGone)
			{
				this.SafeGoMenu("[LoadMPScene] Could not remove 'PlayerComponents' within timeout (modmap global cleanup).");
				yield break;
			}
			spawnPoint = null;
		}
		else
		{
			GameObject spawnPoint = null;
			float cleanupDeadline = Time.realtimeSinceStartup + 10f;
			while (spawnPoint == null && Time.realtimeSinceStartup < cleanupDeadline)
			{
				spawnPoint = GameObject.Find("PlayerComponents");
				if (spawnPoint != null)
				{
					break;
				}
				yield return null;
			}
			if (spawnPoint != null)
			{
				try
				{
					Object.Destroy(spawnPoint);
				}
				catch
				{
				}
				float spawnFindDeadline = Time.realtimeSinceStartup + 5f;
				while (spawnPoint != null && Time.realtimeSinceStartup < spawnFindDeadline)
				{
					yield return null;
				}
				if (GameObject.Find("PlayerComponents") != null)
				{
					this.SafeGoMenu("[LoadMPScene] Could not remove original PlayerComponents within timeout (build scene).");
					yield break;
				}
			}
			spawnPoint = null;
		}
		NetworkLobbyManager lobbyManager = null;
		try
		{
			lobbyManager = Object.FindObjectOfType<NetworkLobbyManager>();
		}
		catch
		{
		}
		if (lobbyManager == null)
		{
			float cleanupDeadline = Time.realtimeSinceStartup + 5f;
			while (Time.realtimeSinceStartup < cleanupDeadline)
			{
				yield return null;
			}
			try
			{
				lobbyManager = Object.FindObjectOfType<NetworkLobbyManager>();
			}
			catch
			{
			}
			if (lobbyManager == null && this._modMode && newPCInstance == null && this.playerComponentsPrefab != null)
			{
				try
				{
					newPCInstance = Object.Instantiate<GameObject>(this.playerComponentsPrefab, Vector3.zero, Quaternion.identity);
					Debug.Log("[LoadMPScene] Forced spawn of PlayerComponents prefab (modmap fallback).");
				}
				catch (Exception ex5)
				{
					this.SafeGoMenu("[LoadMPScene] Forced spawn failed: " + ex5.Message);
					yield break;
				}
				foreach (Transform transform2 in Object.FindObjectsOfType<Transform>(true))
				{
					if (transform2 != null && transform2.name == "PlayerComponents")
					{
						try
						{
							Object.Destroy(transform2.gameObject);
						}
						catch
						{
						}
					}
				}
				yield return null;
				try
				{
					lobbyManager = Object.FindObjectOfType<NetworkLobbyManager>();
				}
				catch
				{
				}
			}
		}
		if (lobbyManager == null)
		{
			float cleanupDeadline = Time.realtimeSinceStartup + 12f;
			while (lobbyManager == null && Time.realtimeSinceStartup < cleanupDeadline)
			{
				try
				{
					lobbyManager = Object.FindObjectOfType<NetworkLobbyManager>();
				}
				catch
				{
				}
				if (lobbyManager != null)
				{
					break;
				}
				yield return null;
			}
		}
		if (lobbyManager == null)
		{
			this.SafeGoMenu("[LoadMPScene] No NetworkLobbyManager found after loading scene (timed out).");
			yield break;
		}
		Task<bool> joinTask = null;
		try
		{
			joinTask = lobbyManager.JoinLobbyById(lobbyId, null);
		}
		catch (Exception ex6)
		{
			this.SafeGoMenu("[LoadMPScene] JoinLobbyById threw: " + ex6.Message);
			yield break;
		}
		float joinDeadline = Time.realtimeSinceStartup + 12f;
		while (joinTask != null && !joinTask.IsCompleted && Time.realtimeSinceStartup < joinDeadline)
		{
			yield return null;
		}
		if (joinTask == null || !joinTask.IsCompleted)
		{
			this.SafeGoMenu("[LoadMPScene] Join timed out.");
			yield break;
		}
		bool flag4 = false;
		try
		{
			flag4 = joinTask.Result;
		}
		catch (Exception ex7)
		{
			this.SafeGoMenu("[LoadMPScene] Join failed: " + ex7.Message);
			yield break;
		}
		if (!flag4)
		{
			this.SafeGoMenu("[LoadMPScene] Join failed.");
			yield break;
		}
		if (ui != null)
		{
			try
			{
				Object.Destroy(ui);
			}
			catch
			{
			}
		}
		Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x06000113 RID: 275 RVA: 0x000093A6 File Offset: 0x000075A6
	private static bool IsModToken(string token)
	{
		return !string.IsNullOrEmpty(token) && token.StartsWith("mod:", StringComparison.OrdinalIgnoreCase);
	}

	// Token: 0x06000114 RID: 276 RVA: 0x000093BE File Offset: 0x000075BE
	private IEnumerator TryLoadSceneFromBundleFile(string bundleFileName, Action<bool> done)
	{
		if (string.IsNullOrWhiteSpace(bundleFileName))
		{
			done(false);
			yield break;
		}
		string path = Path.Combine(LoadMPScene.ModMapsFolder, bundleFileName);
		if (!File.Exists(path))
		{
			Debug.LogWarning("[LoadMPScene] Missing mod bundle: " + path);
			done(false);
			yield break;
		}
		AssetBundleCreateRequest req = null;
		try
		{
			req = AssetBundle.LoadFromFileAsync(path);
			goto IL_E6;
		}
		catch (Exception ex)
		{
			Debug.LogWarning("[LoadMPScene] LoadFromFileAsync error: " + ex.Message);
			done(false);
			yield break;
		}
		IL_CF:
		yield return null;
		IL_E6:
		if (req != null && !req.isDone)
		{
			goto IL_CF;
		}
		AssetBundleCreateRequest assetBundleCreateRequest = req;
		AssetBundle assetBundle = (assetBundleCreateRequest != null) ? assetBundleCreateRequest.assetBundle : null;
		if (assetBundle == null)
		{
			Debug.LogWarning("[LoadMPScene] Failed to load AssetBundle: " + path);
			done(false);
			yield break;
		}
		this._modMode = true;
		this._lastLoadedBundle = assetBundle;
		string[] array = null;
		try
		{
			array = assetBundle.GetAllScenePaths();
		}
		catch
		{
		}
		if (array == null || array.Length == 0)
		{
			Debug.LogWarning("[LoadMPScene] Bundle has no scenes: " + path);
			done(false);
			yield break;
		}
		string sceneName = array[0];
		AsyncOperation load = null;
		try
		{
			load = SceneManager.LoadSceneAsync(sceneName);
		}
		catch (Exception ex2)
		{
			Debug.LogWarning("[LoadMPScene] LoadSceneAsync(bundle scene) error: " + ex2.Message);
			done(false);
			yield break;
		}
		if (load != null)
		{
			while (!load.isDone)
			{
				yield return null;
			}
			done(true);
		}
		else
		{
			done(false);
		}
		yield break;
	}

	// Token: 0x06000115 RID: 277 RVA: 0x000093DB File Offset: 0x000075DB
	private IEnumerator TryFindAndLoadSceneFromAnyBundleBySceneName(string token, Action<bool> done)
	{
		if (string.IsNullOrWhiteSpace(token))
		{
			done(false);
			yield break;
		}
		string wanted = token.Trim().ToLowerInvariant();
		if (!Directory.Exists(LoadMPScene.ModMapsFolder))
		{
			Debug.LogWarning("[LoadMPScene] ModMaps folder not found: " + LoadMPScene.ModMapsFolder);
			done(false);
			yield break;
		}
		string[] files;
		try
		{
			files = Directory.GetFiles(LoadMPScene.ModMapsFolder);
		}
		catch (Exception ex)
		{
			Debug.LogWarning("[LoadMPScene] Could not enumerate ModMaps: " + ex.Message);
			done(false);
			yield break;
		}
		foreach (string path in files)
		{
			AssetBundleCreateRequest req = null;
			try
			{
				req = AssetBundle.LoadFromFileAsync(path);
			}
			catch
			{
			}
			if (req != null)
			{
				while (!req.isDone)
				{
					yield return null;
				}
				AssetBundle bundle = req.assetBundle;
				if (!(bundle == null))
				{
					string[] array2 = null;
					try
					{
						array2 = bundle.GetAllScenePaths();
					}
					catch
					{
					}
					bool flag = false;
					if (array2 != null && array2.Length != 0)
					{
						int j = 0;
						while (j < array2.Length)
						{
							string text = array2[j];
							if (Path.GetFileNameWithoutExtension(text).ToLowerInvariant() == wanted)
							{
								this._modMode = true;
								this._lastLoadedBundle = bundle;
								AsyncOperation load = null;
								try
								{
									load = SceneManager.LoadSceneAsync(text);
								}
								catch (Exception ex2)
								{
									Debug.LogWarning("[LoadMPScene] LoadSceneAsync('" + text + "') error: " + ex2.Message);
									load = null;
								}
								if (load != null)
								{
									while (!load.isDone)
									{
										yield return null;
									}
									flag = true;
									break;
								}
								break;
							}
							else
							{
								j++;
							}
						}
					}
					if (flag)
					{
						done(true);
						yield break;
					}
					try
					{
						bundle.Unload(false);
					}
					catch
					{
					}
					req = null;
					bundle = null;
				}
			}
		}
		string[] array = null;
		done(false);
		yield break;
	}

	// Token: 0x06000116 RID: 278 RVA: 0x000093F8 File Offset: 0x000075F8
	private void SafeGoMenu(string msg)
	{
		try
		{
			Debug.LogWarning(msg);
		}
		catch
		{
		}
		if (!string.IsNullOrEmpty(this.NewMenu))
		{
			try
			{
				SceneManager.LoadSceneAsync(this.NewMenu);
				goto IL_53;
			}
			catch (Exception ex)
			{
				Debug.LogWarning("[LoadMPScene] Failed to load NewMenu '" + this.NewMenu + "': " + ex.Message);
				goto IL_53;
			}
		}
		Debug.LogWarning("[LoadMPScene] NewMenu is not set. Staying in current scene.");
		IL_53:
		if (this.loadingPrefab != null)
		{
			try
			{
				GameObject gameObject = GameObject.Find(this.loadingPrefab.name + "(Clone)");
				if (gameObject != null)
				{
					Object.Destroy(gameObject);
				}
			}
			catch
			{
			}
		}
		try
		{
			Object.Destroy(base.gameObject);
		}
		catch
		{
		}
	}

	// Token: 0x0400013F RID: 319
	[Header("Inputs")]
	public LobbyInfoViewer lobbyInfo;

	// Token: 0x04000140 RID: 320
	[Header("Menu / UI")]
	public string NewMenu;

	// Token: 0x04000141 RID: 321
	public GameObject loadingPrefab;

	// Token: 0x04000142 RID: 322
	[Header("Modmap Support")]
	[Tooltip("Prefab that contains PlayerComponents (and your NetworkLobbyManager) for modmaps.")]
	public GameObject playerComponentsPrefab;

	// Token: 0x04000143 RID: 323
	[Header("Timing")]
	private const float DestroyTimeoutSeconds = 5f;

	// Token: 0x04000144 RID: 324
	private const float FindPCSafetySeconds = 10f;

	// Token: 0x04000145 RID: 325
	private const float JoinTimeoutSeconds = 12f;

	// Token: 0x04000146 RID: 326
	private static readonly List<AssetBundle> s_RetainedBundles = new List<AssetBundle>();

	// Token: 0x04000147 RID: 327
	private bool _modMode;

	// Token: 0x04000148 RID: 328
	private AssetBundle _lastLoadedBundle;
}
