using System;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000C5 RID: 197
public class MainMenuLogic : MonoBehaviour
{
	// Token: 0x06000351 RID: 849 RVA: 0x00019F23 File Offset: 0x00018123
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
		Time.timeScale = 1f;
	}

	// Token: 0x06000352 RID: 850 RVA: 0x00019F48 File Offset: 0x00018148
	private void Update()
	{
		if (this.allowInput)
		{
			if (!this.references.customizeMenu)
			{
				if (this.player.GetButtonDown("R1"))
				{
					this.mainMenuPanels.windowManager.NextPage();
					this.updateSelectedButton();
				}
				if (this.player.GetButtonDown("L1"))
				{
					this.mainMenuPanels.windowManager.PrevPage();
					this.updateSelectedButton();
				}
				if (this.mainMenuPanels.windowManager.currentWindowIndex == 3 && this.player.GetButtonDown("Square"))
				{
					this.lobbyViewer.SquarePressed();
				}
			}
			if (this.references.customizeMenu)
			{
				if (this.player.GetButtonDown("Circle"))
				{
					this.CloseCustomizeMenu();
					this.references.partSelector.index = 0;
					this.references.partSelector.UpdateUI();
				}
				if (this.player.GetButtonDown("R1"))
				{
					this.references.partSelector.ForwardClick();
					this.ResetScrollPostions();
				}
				if (this.player.GetButtonDown("L1"))
				{
					this.references.partSelector.PreviousClick();
					this.ResetScrollPostions();
				}
				if (this.partWindowTrigger != this.references.partSelector.index)
				{
					this.OpenPartWindow();
					if (this.references.partSelector.index == this.gripTapeWindowID)
					{
						this.references.scooterBuilderBrain.RenderTapeCamera();
						if (this.debugMode)
						{
							Debug.Log("Updated GripTape Camera");
						}
					}
					this.partWindowTrigger = this.references.partSelector.index;
				}
				if (this.player.GetButtonDown("Triangle"))
				{
					this.allowInput = false;
					this.references.customScooterSaveSystem.OpenSavePanel();
				}
				if (this.references.partSelector.index == 9 && this.player.GetButtonDown("Square"))
				{
					this.references.scooterBuilderBrain.ChangePegOption();
				}
			}
		}
	}

	// Token: 0x06000353 RID: 851 RVA: 0x0001A158 File Offset: 0x00018358
	public void ResetScrollPostions()
	{
		ScrollRect[] partWindowScrolls = this.partWindows.partWindowScrolls;
		for (int i = 0; i < partWindowScrolls.Length; i++)
		{
			partWindowScrolls[i].normalizedPosition = new Vector3(1f, 1f, 0f);
		}
	}

	// Token: 0x06000354 RID: 852 RVA: 0x0001A1A0 File Offset: 0x000183A0
	public void OpenCustomizeMenu()
	{
		this.references.customizeMenu = true;
		this.references.freelookCamera.SetActive(true);
		this.references.saveButton.SetActive(true);
		this.references.cameraButton.SetActive(true);
		this.mainMenuPanels.mainBlur.SetActive(false);
		this.mainMenuPanels.MainMenuPanel.alpha = 0f;
		this.mainMenuPanels.MainMenuPanel.interactable = false;
		this.mainMenuPanels.MainMenuPanel.blocksRaycasts = false;
		this.mainMenuPanels.customizePanel.SetActive(true);
		this.references.scooterBuilderBrain.RenderTapeCamera();
		EventSystem.current.SetSelectedGameObject(this.selectableButtons.customizeMenu);
	}

	// Token: 0x06000355 RID: 853 RVA: 0x0001A26C File Offset: 0x0001846C
	public void CloseCustomizeMenu()
	{
		this.references.customizeMenu = false;
		this.references.freelookCamera.SetActive(false);
		this.references.saveButton.SetActive(false);
		this.references.cameraButton.SetActive(false);
		this.mainMenuPanels.mainBlur.SetActive(true);
		this.mainMenuPanels.MainMenuPanel.alpha = 1f;
		this.mainMenuPanels.MainMenuPanel.interactable = true;
		this.mainMenuPanels.MainMenuPanel.blocksRaycasts = true;
		this.mainMenuPanels.customizePanel.SetActive(false);
		this.updateSelectedButton();
	}

	// Token: 0x06000356 RID: 854 RVA: 0x0001A317 File Offset: 0x00018517
	public void UnhideCustomizePanel()
	{
		this.mainMenuPanels.customizePanelCanvasGroup.alpha = 1f;
		this.mainMenuPanels.customizePanelCanvasGroup.interactable = true;
		this.mainMenuPanels.customizePanelCanvasGroup.blocksRaycasts = true;
	}

	// Token: 0x06000357 RID: 855 RVA: 0x0001A350 File Offset: 0x00018550
	public void updateSelectedButton()
	{
		if (this.mainMenuPanels.windowManager.currentWindowIndex == 0)
		{
			EventSystem.current.SetSelectedGameObject(this.selectableButtons.Play);
			return;
		}
		if (this.mainMenuPanels.windowManager.currentWindowIndex == 1)
		{
			switch (this.references.scooterBuilderBrain.customScooterSelected)
			{
			case 1:
				EventSystem.current.SetSelectedGameObject(this.selectableButtons.Customize1);
				return;
			case 2:
				EventSystem.current.SetSelectedGameObject(this.selectableButtons.Customize2);
				return;
			case 3:
				EventSystem.current.SetSelectedGameObject(this.selectableButtons.Customize3);
				return;
			default:
				return;
			}
		}
		else
		{
			if (this.mainMenuPanels.windowManager.currentWindowIndex == 2)
			{
				EventSystem.current.SetSelectedGameObject(this.selectableButtons.Controls);
				return;
			}
			if (this.mainMenuPanels.windowManager.currentWindowIndex == 3)
			{
				if (!(this.lobbyButtonParent != null) || this.lobbyButtonParent.transform.childCount <= 0)
				{
					EventSystem.current.SetSelectedGameObject(this.fallbackButton);
					return;
				}
				Transform child = this.lobbyButtonParent.transform.GetChild(0);
				if (child != null)
				{
					EventSystem.current.SetSelectedGameObject(child.gameObject);
					return;
				}
			}
			else if (this.mainMenuPanels.windowManager.currentWindowIndex == 4)
			{
				EventSystem.current.SetSelectedGameObject(this.selectableButtons.Options);
			}
			return;
		}
	}

	// Token: 0x06000358 RID: 856 RVA: 0x0001A4C4 File Offset: 0x000186C4
	public void OpenPartWindow()
	{
		foreach (CanvasGroup canvasGroup in this.partWindows.partWindow)
		{
			canvasGroup.gameObject.transform.GetChild(0).gameObject.SetActive(false);
			canvasGroup.interactable = false;
			canvasGroup.alpha = 0f;
			canvasGroup.blocksRaycasts = false;
		}
		this.partWindows.partWindow[this.references.partSelector.index].transform.GetChild(0).gameObject.SetActive(true);
		this.partWindows.partWindow[this.references.partSelector.index].interactable = true;
		this.partWindows.partWindow[this.references.partSelector.index].blocksRaycasts = true;
		this.partWindows.partWindow[this.references.partSelector.index].alpha = 1f;
		if (this.references.partSelector.index == 9)
		{
			this.DisplayPegOption();
			return;
		}
		this.RemovePegOption();
	}

	// Token: 0x06000359 RID: 857 RVA: 0x0001A5DF File Offset: 0x000187DF
	public void OpenWindowManager()
	{
		this.mainMenuPanels.MainMenuPanel.alpha = 1f;
		this.mainMenuPanels.MainMenuPanel.interactable = true;
		this.mainMenuPanels.MainMenuPanel.blocksRaycasts = true;
		this.updateSelectedButton();
	}

	// Token: 0x0600035A RID: 858 RVA: 0x0001A61E File Offset: 0x0001881E
	public void CloseWindowManager()
	{
		this.mainMenuPanels.MainMenuPanel.alpha = 0f;
		this.mainMenuPanels.MainMenuPanel.interactable = false;
		this.mainMenuPanels.MainMenuPanel.blocksRaycasts = false;
	}

	// Token: 0x0600035B RID: 859 RVA: 0x0001A657 File Offset: 0x00018857
	public void DisplayPegOption()
	{
		this.references.SquareButtonIcon.SetActive(true);
		this.references.squareButtonText.text = "Pegs";
	}

	// Token: 0x0600035C RID: 860 RVA: 0x0001A67F File Offset: 0x0001887F
	public void RemovePegOption()
	{
		this.references.SquareButtonIcon.SetActive(false);
	}

	// Token: 0x0600035D RID: 861 RVA: 0x0001A692 File Offset: 0x00018892
	public void ExitGame()
	{
		Application.Quit();
	}

	// Token: 0x0600035E RID: 862 RVA: 0x0001A699 File Offset: 0x00018899
	public void openTheURL()
	{
		Application.OpenURL(this.DiscordAddress);
	}

	// Token: 0x040004B1 RID: 1201
	public bool debugMode;

	// Token: 0x040004B2 RID: 1202
	public int gripTapeWindowID;

	// Token: 0x040004B3 RID: 1203
	public string DiscordAddress;

	// Token: 0x040004B4 RID: 1204
	public bool allowInput;

	// Token: 0x040004B5 RID: 1205
	private int playerId;

	// Token: 0x040004B6 RID: 1206
	private Player player;

	// Token: 0x040004B7 RID: 1207
	public MainMenuPanels mainMenuPanels;

	// Token: 0x040004B8 RID: 1208
	public MainMenuReferences references;

	// Token: 0x040004B9 RID: 1209
	public FirstSelected selectableButtons;

	// Token: 0x040004BA RID: 1210
	public PartWindows partWindows;

	// Token: 0x040004BB RID: 1211
	private int partWindowTrigger;

	// Token: 0x040004BC RID: 1212
	public GameObject lobbyButtonParent;

	// Token: 0x040004BD RID: 1213
	public GameObject fallbackButton;

	// Token: 0x040004BE RID: 1214
	public LobbyViewer lobbyViewer;
}
