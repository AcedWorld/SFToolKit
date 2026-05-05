using System;
using System.Collections;
using Rewired;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// Token: 0x020000C7 RID: 199
public class MenuLogic : MonoBehaviour
{
	// Token: 0x06000361 RID: 865 RVA: 0x0001A6A6 File Offset: 0x000188A6
	private void Start()
	{
		this.ridingSounds.SetFloat("RidingSounds", 0f);
		this.player = ReInput.players.GetPlayer(this.playerId);
	}

	// Token: 0x06000362 RID: 866 RVA: 0x0001A6D4 File Offset: 0x000188D4
	private void Update()
	{
		if (this.settingsMenu && this.player.GetButtonDown("Circle"))
		{
			this.closeOptionsPanel();
		}
		if (this.controlsMenu && this.player.GetButtonDown("Circle"))
		{
			this.closeControlsPanel();
		}
	}

	// Token: 0x06000363 RID: 867 RVA: 0x0001A724 File Offset: 0x00018924
	public void openMainMenuButtons()
	{
		this.menuItems.mainMenuCanvasGroup.alpha = 1f;
		this.menuItems.mainMenuCanvasGroup.interactable = true;
		this.menuItems.mainMenuCanvasGroup.blocksRaycasts = true;
		EventSystem.current.SetSelectedGameObject(this.menuItems.menuButtonsFirstSelected);
	}

	// Token: 0x06000364 RID: 868 RVA: 0x0001A780 File Offset: 0x00018980
	public void openOptionsPanel()
	{
		this.menuItems.optionsCanvasGroup.alpha = 1f;
		this.menuItems.optionsCanvasGroup.interactable = true;
		this.menuItems.optionsCanvasGroup.blocksRaycasts = true;
		EventSystem.current.SetSelectedGameObject(this.menuItems.optionsFirstSelected);
		this.closeMainMenuButtons();
		this.settingsMenu = true;
	}

	// Token: 0x06000365 RID: 869 RVA: 0x0001A7E8 File Offset: 0x000189E8
	public void openControlsPanel()
	{
		this.menuItems.controlsCanvasGroup.alpha = 1f;
		this.menuItems.controlsCanvasGroup.interactable = true;
		this.menuItems.controlsCanvasGroup.blocksRaycasts = true;
		EventSystem.current.SetSelectedGameObject(this.menuItems.controlsFirstSelected);
		this.closeMainMenuButtons();
		this.controlsMenu = true;
	}

	// Token: 0x06000366 RID: 870 RVA: 0x0001A84E File Offset: 0x00018A4E
	public void closeMainMenuButtons()
	{
		this.menuItems.mainMenuCanvasGroup.alpha = 0f;
		this.menuItems.mainMenuCanvasGroup.interactable = false;
		this.menuItems.mainMenuCanvasGroup.blocksRaycasts = false;
	}

	// Token: 0x06000367 RID: 871 RVA: 0x0001A888 File Offset: 0x00018A88
	public void closeOptionsPanel()
	{
		this.menuItems.optionsCanvasGroup.alpha = 0f;
		this.menuItems.optionsCanvasGroup.interactable = false;
		this.menuItems.optionsCanvasGroup.blocksRaycasts = false;
		EventSystem.current.SetSelectedGameObject(this.menuItems.menuButtonsFirstSelected);
		this.openMainMenuButtons();
		this.settingsMenu = false;
	}

	// Token: 0x06000368 RID: 872 RVA: 0x0001A8F0 File Offset: 0x00018AF0
	public void closeControlsPanel()
	{
		this.menuItems.controlsCanvasGroup.alpha = 0f;
		this.menuItems.controlsCanvasGroup.interactable = false;
		this.menuItems.controlsCanvasGroup.blocksRaycasts = false;
		EventSystem.current.SetSelectedGameObject(this.menuItems.menuButtonsFirstSelected);
		this.openMainMenuButtons();
		this.controlsMenu = false;
	}

	// Token: 0x06000369 RID: 873 RVA: 0x0001A956 File Offset: 0x00018B56
	public void openHostSessionWindow()
	{
		this.menuItems.hostSessionWindow.OpenWindow();
		EventSystem.current.SetSelectedGameObject(this.menuItems.hoseSessionPromptButton);
	}

	// Token: 0x0600036A RID: 874 RVA: 0x0001A97D File Offset: 0x00018B7D
	public void closeHostSessionWindow()
	{
		this.menuItems.hostSessionWindow.CloseWindow();
		EventSystem.current.SetSelectedGameObject(this.menuItems.menuButtonsFirstSelected);
	}

	// Token: 0x0600036B RID: 875 RVA: 0x0001A9A4 File Offset: 0x00018BA4
	public void hostOnlineSession()
	{
		this.menuItems.loadScreen.SetActive(true);
		this.menuItems.hostSessionWindow.CloseWindow();
		EventSystem.current.SetSelectedGameObject(null);
	}

	// Token: 0x0600036C RID: 876 RVA: 0x0001A9D2 File Offset: 0x00018BD2
	public void onLobbyHosted()
	{
		this.menuItems.loadScreen.SetActive(false);
		this.ToggleMenu();
	}

	// Token: 0x0600036D RID: 877 RVA: 0x0001A9D2 File Offset: 0x00018BD2
	public void onHostFailed()
	{
		this.menuItems.loadScreen.SetActive(false);
		this.ToggleMenu();
	}

	// Token: 0x0600036E RID: 878 RVA: 0x0001A9EB File Offset: 0x00018BEB
	public void openExitGameWindow()
	{
		this.menuItems.exitGameModalWindow.OpenWindow();
		EventSystem.current.SetSelectedGameObject(this.menuItems.exitGamePromptButton);
	}

	// Token: 0x0600036F RID: 879 RVA: 0x0001AA12 File Offset: 0x00018C12
	public void closeExitGameWindow()
	{
		this.menuItems.exitGameModalWindow.CloseWindow();
		EventSystem.current.SetSelectedGameObject(this.menuItems.menuButtonsFirstSelected);
	}

	// Token: 0x06000370 RID: 880 RVA: 0x0001AA39 File Offset: 0x00018C39
	public void openMainMenuWindow()
	{
		this.menuItems.mainMenuModalWindow.OpenWindow();
		EventSystem.current.SetSelectedGameObject(this.menuItems.mainMenuPromptButton);
	}

	// Token: 0x06000371 RID: 881 RVA: 0x0001AA60 File Offset: 0x00018C60
	public void closeMainMenuWindow()
	{
		this.menuItems.mainMenuModalWindow.CloseWindow();
		EventSystem.current.SetSelectedGameObject(null);
	}

	// Token: 0x06000372 RID: 882 RVA: 0x0001AA7D File Offset: 0x00018C7D
	public void exitToMainMenu()
	{
		base.StartCoroutine(this.ExitToMainMenuDelay());
	}

	// Token: 0x06000373 RID: 883 RVA: 0x0001AA8C File Offset: 0x00018C8C
	private IEnumerator ExitToMainMenuDelay()
	{
		this.menuItems.loadScreen.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		yield return new WaitForSecondsRealtime(0.5f);
		SceneManager.LoadSceneAsync(this.menuItems.mainMenuSceneName);
		yield break;
	}

	// Token: 0x06000374 RID: 884 RVA: 0x0001AA9B File Offset: 0x00018C9B
	public void closeGame()
	{
		base.StartCoroutine(this.CloseGameDelay());
	}

	// Token: 0x06000375 RID: 885 RVA: 0x0001AAAA File Offset: 0x00018CAA
	private IEnumerator CloseGameDelay()
	{
		this.menuItems.loadScreen.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
		yield return new WaitForSecondsRealtime(0.5f);
		Application.Quit();
		yield break;
	}

	// Token: 0x06000376 RID: 886 RVA: 0x0001AAB9 File Offset: 0x00018CB9
	public void ToggleMenu()
	{
		this.pauseMenu = !this.pauseMenu;
		if (this.pauseMenu)
		{
			this.OpenMenu();
			return;
		}
		this.CloseMenu();
	}

	// Token: 0x06000377 RID: 887 RVA: 0x0001AAE0 File Offset: 0x00018CE0
	public void OpenMenu()
	{
		this.simpleReplay.OnMainMenuOpen();
		this.openMainMenuButtons();
		this.menuItems.inGameMenu.alpha = 1f;
		this.menuItems.inGameMenu.interactable = true;
		this.menuItems.inGameMenu.blocksRaycasts = true;
		this.menuItems.timeSpeed.PauseTime();
		if (!this.firstTimeOpen)
		{
			this.menuItems.gameplaySettings.UpdateUI();
			this.firstTimeOpen = true;
		}
		this.ridingSounds.SetFloat("RidingSounds", -80f);
	}

	// Token: 0x06000378 RID: 888 RVA: 0x0001AB7C File Offset: 0x00018D7C
	public void CloseMenu()
	{
		this.simpleReplay.OnMainMenuClose();
		this.openMainMenuButtons();
		this.closeOptionsPanel();
		this.closeControlsPanel();
		this.menuItems.inGameMenu.alpha = 0f;
		this.menuItems.inGameMenu.interactable = false;
		this.menuItems.inGameMenu.blocksRaycasts = false;
		this.menuItems.timeSpeed.NormalTime();
		EventSystem.current.SetSelectedGameObject(null);
		this.menuItems.exitGameModalWindow.CloseWindow();
		this.ridingSounds.SetFloat("RidingSounds", 0f);
	}

	// Token: 0x06000379 RID: 889 RVA: 0x0001AC1E File Offset: 0x00018E1E
	public void ResumeGame()
	{
		base.StartCoroutine(this.ResumeDelay());
	}

	// Token: 0x0600037A RID: 890 RVA: 0x0001AC2D File Offset: 0x00018E2D
	private IEnumerator ResumeDelay()
	{
		yield return new WaitForSecondsRealtime(this.resumeDelay);
		this.ToggleMenu();
		yield break;
	}

	// Token: 0x040004D4 RID: 1236
	public AudioMixer ridingSounds;

	// Token: 0x040004D5 RID: 1237
	public MenuItems menuItems;

	// Token: 0x040004D6 RID: 1238
	public SimpleReplay simpleReplay;

	// Token: 0x040004D7 RID: 1239
	public CameraBrain cameraBrain;

	// Token: 0x040004D8 RID: 1240
	private int windowCount;

	// Token: 0x040004D9 RID: 1241
	private bool firstTimeOpen;

	// Token: 0x040004DA RID: 1242
	public float resumeDelay;

	// Token: 0x040004DB RID: 1243
	private int playerId;

	// Token: 0x040004DC RID: 1244
	private Player player;

	// Token: 0x040004DD RID: 1245
	[HideInInspector]
	public bool pauseMenu;

	// Token: 0x040004DE RID: 1246
	private bool settingsMenu;

	// Token: 0x040004DF RID: 1247
	private bool controlsMenu;
}
