using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000068 RID: 104
public class LobbyViewer : MonoBehaviour
{
	// Token: 0x06000199 RID: 409 RVA: 0x0000CF69 File Offset: 0x0000B169
	private void Awake()
	{
		LobbyViewer.Instance = this;
	}

	// Token: 0x0600019A RID: 410 RVA: 0x0000CF74 File Offset: 0x0000B174
	private void Start()
	{
		LobbyViewer.<Start>d__24 <Start>d__;
		<Start>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
		<Start>d__.<>4__this = this;
		<Start>d__.<>1__state = -1;
		<Start>d__.<>t__builder.Start<LobbyViewer.<Start>d__24>(ref <Start>d__);
	}

	// Token: 0x0600019B RID: 411 RVA: 0x0000CFAC File Offset: 0x0000B1AC
	public void SetSelectedLobby(LobbyInfoViewer info)
	{
		this.lobbyInfoViewer = info;
		if (this.enableDebugLogs)
		{
			if (info == null)
			{
				Debug.Log("[LobbyViewer] Selected lobby set: <null>");
				return;
			}
			Debug.Log(string.Concat(new string[]
			{
				"[LobbyViewer] Selected lobby set: scene='",
				info.sceneName,
				"', host='",
				info.steamName,
				"', id='",
				info.lobbyId,
				"'"
			}));
		}
	}

	// Token: 0x0600019C RID: 412 RVA: 0x0000D024 File Offset: 0x0000B224
	public void SquarePressed()
	{
		LobbyViewer.<SquarePressed>d__26 <SquarePressed>d__;
		<SquarePressed>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
		<SquarePressed>d__.<>4__this = this;
		<SquarePressed>d__.<>1__state = -1;
		<SquarePressed>d__.<>t__builder.Start<LobbyViewer.<SquarePressed>d__26>(ref <SquarePressed>d__);
	}

	// Token: 0x0600019D RID: 413 RVA: 0x0000D05B File Offset: 0x0000B25B
	private void Update()
	{
		if (this.windowManagerTrigger != this.windowManager.currentWindowIndex)
		{
			this.displayRefreshButton();
			if (this.windowManager.currentWindowIndex == 3)
			{
				this.SquarePressed();
			}
			this.windowManagerTrigger = this.windowManager.currentWindowIndex;
		}
	}

	// Token: 0x0600019E RID: 414 RVA: 0x0000D09C File Offset: 0x0000B29C
	public void displayRefreshButton()
	{
		if (this.windowManager.currentWindowIndex == 3)
		{
			if (this.SquareButton != null)
			{
				this.SquareButton.SetActive(!this.isRefreshing);
			}
			if (this.SquareButtonText != null)
			{
				this.SquareButtonText.text = "Refresh";
				return;
			}
		}
		else
		{
			if (this.SquareButton != null)
			{
				this.SquareButton.SetActive(false);
			}
			if (this.SquareButtonText != null)
			{
				this.SquareButtonText.text = "Pegs";
			}
		}
	}

	// Token: 0x0600019F RID: 415 RVA: 0x0000D130 File Offset: 0x0000B330
	public void UpdateLobbyList()
	{
		this.SquarePressed();
	}

	// Token: 0x060001A0 RID: 416 RVA: 0x0000D138 File Offset: 0x0000B338
	private Task InitializeServices()
	{
		LobbyViewer.<InitializeServices>d__30 <InitializeServices>d__;
		<InitializeServices>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
		<InitializeServices>d__.<>4__this = this;
		<InitializeServices>d__.<>1__state = -1;
		<InitializeServices>d__.<>t__builder.Start<LobbyViewer.<InitializeServices>d__30>(ref <InitializeServices>d__);
		return <InitializeServices>d__.<>t__builder.Task;
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x0000D17C File Offset: 0x0000B37C
	public Task UpdateDiscoveredLobbies()
	{
		LobbyViewer.<UpdateDiscoveredLobbies>d__31 <UpdateDiscoveredLobbies>d__;
		<UpdateDiscoveredLobbies>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
		<UpdateDiscoveredLobbies>d__.<>4__this = this;
		<UpdateDiscoveredLobbies>d__.<>1__state = -1;
		<UpdateDiscoveredLobbies>d__.<>t__builder.Start<LobbyViewer.<UpdateDiscoveredLobbies>d__31>(ref <UpdateDiscoveredLobbies>d__);
		return <UpdateDiscoveredLobbies>d__.<>t__builder.Task;
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x0000D1C0 File Offset: 0x0000B3C0
	public string GetRealSceneName(string maskedSceneName)
	{
		foreach (SceneNameMaskViewer sceneNameMaskViewer in this.sceneNameMasks)
		{
			if (sceneNameMaskViewer.maskedSceneName == maskedSceneName)
			{
				return sceneNameMaskViewer.realSceneName;
			}
		}
		return maskedSceneName;
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x0000D228 File Offset: 0x0000B428
	public void OpenWindowPrompt()
	{
		this.modalWindowManager.OpenWindow();
		EventSystem.current.SetSelectedGameObject(this.loadButton);
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x0000D248 File Offset: 0x0000B448
	public void LoadMultiplayerLevel()
	{
		if (this.lobbyInfoViewer == null)
		{
			if (this.enableDebugLogs)
			{
				Debug.LogWarning("[LobbyViewer] Load requested with no selected lobby.");
			}
			return;
		}
		if (this.LobbyJoiner == null)
		{
			Debug.LogError("[LobbyViewer] LobbyJoiner prefab not assigned.");
			return;
		}
		if (this.modalWindowManager != null)
		{
			this.modalWindowManager.CloseWindow();
		}
		LoadMPScene component = Object.Instantiate<GameObject>(this.LobbyJoiner).GetComponent<LoadMPScene>();
		if (component == null)
		{
			Debug.LogError("[LobbyViewer] LobbyJoiner prefab does not contain a LoadMPScene component.");
			return;
		}
		component.lobbyInfo = this.lobbyInfoViewer;
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x0000D2D3 File Offset: 0x0000B4D3
	public void CancelLoad()
	{
		if (this.modalWindowManager != null)
		{
			this.modalWindowManager.CloseWindow();
		}
		if (this.mainMenuLogic != null)
		{
			this.mainMenuLogic.updateSelectedButton();
		}
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x0000D308 File Offset: 0x0000B508
	private void CreateLobbyButton(LobbyInfoViewer lobbyInfo)
	{
		if (this.lobbyButtonPrefab == null || this.buttonParent == null)
		{
			Debug.LogWarning("[LobbyViewer] Missing button prefab or parent.");
			return;
		}
		MPMapButton component = Object.Instantiate<GameObject>(this.lobbyButtonPrefab, this.buttonParent).GetComponent<MPMapButton>();
		if (component != null)
		{
			component.Initialize(lobbyInfo);
			component.lobbyViewer = this;
			return;
		}
		Debug.LogWarning("[LobbyViewer] Spawned prefab is missing MPMapButton script.");
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x0000D378 File Offset: 0x0000B578
	private void ClearExistingButtons()
	{
		if (this.buttonParent == null)
		{
			return;
		}
		foreach (object obj in this.buttonParent)
		{
			Object.Destroy(((Transform)obj).gameObject);
		}
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x0000D3E4 File Offset: 0x0000B5E4
	public string GetMaskedSceneName(string realSceneName)
	{
		foreach (SceneNameMaskViewer sceneNameMaskViewer in this.sceneNameMasks)
		{
			if (sceneNameMaskViewer.realSceneName == realSceneName)
			{
				return sceneNameMaskViewer.maskedSceneName;
			}
		}
		return realSceneName;
	}

	// Token: 0x060001A9 RID: 425 RVA: 0x0000D130 File Offset: 0x0000B330
	[ContextMenu("Refresh Lobby List")]
	public void RefreshLobbiesInspector()
	{
		this.SquarePressed();
	}

	// Token: 0x040001BF RID: 447
	public static LobbyViewer Instance;

	// Token: 0x040001C0 RID: 448
	[Header("Debugging")]
	public bool enableDebugLogs;

	// Token: 0x040001C1 RID: 449
	[Header("Scene Name Masks")]
	public List<SceneNameMaskViewer> sceneNameMasks = new List<SceneNameMaskViewer>();

	// Token: 0x040001C2 RID: 450
	[Header("Lobby Data")]
	public List<LobbyInfoViewer> discoveredLobbies = new List<LobbyInfoViewer>();

	// Token: 0x040001C3 RID: 451
	public int selectedLobbyIndex = -1;

	// Token: 0x040001C4 RID: 452
	[Header("UI")]
	public GameObject lobbyButtonPrefab;

	// Token: 0x040001C5 RID: 453
	public Transform buttonParent;

	// Token: 0x040001C6 RID: 454
	public WindowManager windowManager;

	// Token: 0x040001C7 RID: 455
	public ModalWindowManager modalWindowManager;

	// Token: 0x040001C8 RID: 456
	public GameObject RefreshLoadscreen;

	// Token: 0x040001C9 RID: 457
	public GameObject SquareButton;

	// Token: 0x040001CA RID: 458
	public TMP_Text SquareButtonText;

	// Token: 0x040001CB RID: 459
	public CanvasGroup squareButtonCanvasGroup;

	// Token: 0x040001CC RID: 460
	public CanvasGroup ListCanvasGroup;

	// Token: 0x040001CD RID: 461
	public MainMenuLogic mainMenuLogic;

	// Token: 0x040001CE RID: 462
	public GameObject loadButton;

	// Token: 0x040001CF RID: 463
	private bool isRefreshing;

	// Token: 0x040001D0 RID: 464
	[SerializeField]
	private float refreshDelay = 2f;

	// Token: 0x040001D1 RID: 465
	private bool initialized;

	// Token: 0x040001D2 RID: 466
	private int windowManagerTrigger;

	// Token: 0x040001D3 RID: 467
	public LobbyInfoViewer lobbyInfoViewer;

	// Token: 0x040001D4 RID: 468
	public GameObject LobbyJoiner;

	// Token: 0x040001D5 RID: 469
	private bool updateSelectedTrigger;
}
