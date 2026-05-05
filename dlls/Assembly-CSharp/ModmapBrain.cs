using System;
using System.Collections;
using System.IO;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// Token: 0x020000FC RID: 252
public class ModmapBrain : MonoBehaviour
{
	// Token: 0x06000420 RID: 1056 RVA: 0x0001D8EC File Offset: 0x0001BAEC
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
		if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ScooterFlow/ModMaps/Thumbnails"))
		{
			Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ScooterFlow/ModMaps/Thumbnails");
		}
		this.LoadModMapFolder();
	}

	// Token: 0x06000421 RID: 1057 RVA: 0x0001D944 File Offset: 0x0001BB44
	private void Update()
	{
		if (this.modmapMenuOpen && this.modmapItems.modalWindowCanvasGroup.alpha == 0f && this.allowInput && this.player.GetButtonDown("Circle"))
		{
			this.CloseModMapLoader();
		}
	}

	// Token: 0x06000422 RID: 1058 RVA: 0x0001D990 File Offset: 0x0001BB90
	public void LoadModMapFolder()
	{
		foreach (FileInfo fileInfo in new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ScooterFlow/ModMaps/").GetFiles())
		{
			Object.Instantiate<GameObject>(this.modmapItems.buttonPrefab, this.modmapItems.buttonParent).name = fileInfo.Name;
		}
	}

	// Token: 0x06000423 RID: 1059 RVA: 0x0001D9F0 File Offset: 0x0001BBF0
	public void OpenModMapLoader()
	{
		if (this.modmapItems.buttonParent.childCount == 0)
		{
			this.OpenNoContentsPanel();
			return;
		}
		this.mainMenuLogic.CloseWindowManager();
		this.mainMenuLogic.allowInput = false;
		this.modmapItems.modmapLoader.SetActive(true);
		this.modmapMenuOpen = true;
		if (this.modmapItems.buttonParent.childCount != 0)
		{
			base.StartCoroutine(this.delaySelect());
		}
	}

	// Token: 0x06000424 RID: 1060 RVA: 0x0001DA64 File Offset: 0x0001BC64
	public void CloseModMapLoader()
	{
		this.mainMenuLogic.OpenWindowManager();
		this.mainMenuLogic.allowInput = true;
		this.modmapItems.modmapLoader.SetActive(false);
		this.modmapMenuOpen = false;
	}

	// Token: 0x06000425 RID: 1061 RVA: 0x0001DA98 File Offset: 0x0001BC98
	public void LoadModMap()
	{
		this.cashedButton = EventSystem.current.currentSelectedGameObject;
		this.modmapItems.modalWindow.OpenWindow();
		this.modmapItems.modalWindowTitle.text = this.modMapSelected;
		EventSystem.current.SetSelectedGameObject(this.modmapItems.modalWindowButton);
	}

	// Token: 0x06000426 RID: 1062 RVA: 0x0001DAF0 File Offset: 0x0001BCF0
	public void CancelLoadMap()
	{
		EventSystem.current.SetSelectedGameObject(this.cashedButton);
	}

	// Token: 0x06000427 RID: 1063 RVA: 0x0001DB02 File Offset: 0x0001BD02
	private IEnumerator delaySelect()
	{
		yield return new WaitForSecondsRealtime(0f);
		EventSystem.current.SetSelectedGameObject(this.modmapItems.buttonParent.GetChild(0).gameObject);
		yield break;
	}

	// Token: 0x06000428 RID: 1064 RVA: 0x0001DB14 File Offset: 0x0001BD14
	public void LoadLevel()
	{
		EventSystem.current.SetSelectedGameObject(null);
		this.SpawnedPlayerSpawner = Object.Instantiate<GameObject>(this.modmapItems.playerComponents);
		this.modmapItems.openTipLoadScreen.OpenLoadScreen();
		this.allowInput = false;
		base.StartCoroutine(this.LoadLevelCoroutine());
	}

	// Token: 0x06000429 RID: 1065 RVA: 0x0001DB66 File Offset: 0x0001BD66
	private IEnumerator LoadLevelCoroutine()
	{
		yield return this.LoadAssetBundleAsync(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ScooterFlow/ModMaps/" + this.modMapSelected);
		yield return this.LoadSceneAsync(this.myLoadedAssetBundle.GetAllScenePaths()[0]);
		yield break;
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x0001DB75 File Offset: 0x0001BD75
	private IEnumerator LoadAssetBundleAsync(string assetBundlePath)
	{
		AssetBundleCreateRequest asyncLoad = AssetBundle.LoadFromFileAsync(assetBundlePath);
		while (!asyncLoad.isDone)
		{
			float f = asyncLoad.progress * 100f;
			this.modmapItems.progressBar.currentPercent = (float)Mathf.FloorToInt(f);
			this.modmapItems.progressBar.UpdateUI();
			yield return null;
		}
		if (asyncLoad.assetBundle == null)
		{
			this.FailedToLoadModMap();
		}
		else
		{
			this.myLoadedAssetBundle = asyncLoad.assetBundle;
		}
		this.modmapItems.progressBar.currentPercent = 100f;
		this.modmapItems.progressBar.UpdateUI();
		this.myLoadedAssetBundle = asyncLoad.assetBundle;
		yield break;
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x0001DB8B File Offset: 0x0001BD8B
	private IEnumerator LoadSceneAsync(string scenePath)
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scenePath);
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
		yield break;
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x0001DB9A File Offset: 0x0001BD9A
	public void OpenNoContentsPanel()
	{
		this.mainMenuLogic.allowInput = false;
		this.modmapItems.noContentsWindow.OpenWindow();
		EventSystem.current.SetSelectedGameObject(this.modmapItems.noContentsButton);
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x0001DBCD File Offset: 0x0001BDCD
	public void CloseNoContentsPanel()
	{
		this.mainMenuLogic.allowInput = true;
		this.modmapItems.noContentsWindow.CloseWindow();
		EventSystem.current.SetSelectedGameObject(this.modmapItems.communityMapsButton);
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x0001DC00 File Offset: 0x0001BE00
	public void joinDiscord()
	{
		this.mainMenuLogic.allowInput = true;
		this.modmapItems.noContentsWindow.CloseWindow();
		EventSystem.current.SetSelectedGameObject(this.modmapItems.discordButton);
		this.mainMenuLogic.openTheURL();
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x0001DC3E File Offset: 0x0001BE3E
	public void FailedToLoadModMap()
	{
		this.modmapItems.openTipLoadScreen.CloseAllLoadScreens();
		Object.Destroy(this.SpawnedPlayerSpawner);
		this.CancelLoadMap();
	}

	// Token: 0x04000624 RID: 1572
	public AssetBundle myLoadedAssetBundle;

	// Token: 0x04000625 RID: 1573
	public GameObject SpawnedPlayerSpawner;

	// Token: 0x04000626 RID: 1574
	private int playerId;

	// Token: 0x04000627 RID: 1575
	private Player player;

	// Token: 0x04000628 RID: 1576
	public MainMenuLogic mainMenuLogic;

	// Token: 0x04000629 RID: 1577
	public ModMapItems modmapItems;

	// Token: 0x0400062A RID: 1578
	public string modMapSelected;

	// Token: 0x0400062B RID: 1579
	public bool modmapMenuOpen;

	// Token: 0x0400062C RID: 1580
	private GameObject cashedButton;

	// Token: 0x0400062D RID: 1581
	private string path;

	// Token: 0x0400062E RID: 1582
	public int loadSceneTime;

	// Token: 0x0400062F RID: 1583
	public bool allowInput;
}
