using System;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000051 RID: 81
public class MPMapButton : MonoBehaviour
{
	// Token: 0x0600012F RID: 303 RVA: 0x0000A49C File Offset: 0x0000869C
	private void Awake()
	{
		if (this.button == null)
		{
			this.button = base.GetComponent<Button>();
		}
		if (this.button != null)
		{
			this.button.onClick.RemoveListener(new UnityAction(this.OnClick));
			this.button.onClick.AddListener(new UnityAction(this.OnClick));
			return;
		}
		Debug.LogWarning("[MPMapButton] No Button component found.");
	}

	// Token: 0x06000130 RID: 304 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x06000131 RID: 305 RVA: 0x0000A514 File Offset: 0x00008714
	private void OnDestroy()
	{
		if (this.button != null)
		{
			this.button.onClick.RemoveListener(new UnityAction(this.OnClick));
		}
	}

	// Token: 0x06000132 RID: 306 RVA: 0x0000A540 File Offset: 0x00008740
	private void Update()
	{
		if (EventSystem.current != null && this.button != null && EventSystem.current.currentSelectedGameObject == this.button.gameObject)
		{
			if (this.canvasGroup != null)
			{
				this.canvasGroup.alpha = 1f;
				return;
			}
		}
		else if (this.canvasGroup != null)
		{
			this.canvasGroup.alpha = 0f;
		}
	}

	// Token: 0x06000133 RID: 307 RVA: 0x0000A5C4 File Offset: 0x000087C4
	public void Initialize(LobbyInfoViewer info)
	{
		this.lobbyInfo = info;
		if (this.mapText != null)
		{
			this.mapText.text = info.sceneName;
		}
		if (this.hostText != null)
		{
			this.hostText.text = info.steamName;
		}
		if (this.playersText != null)
		{
			this.playersText.text = info.playerCount;
		}
		if (this.regionText != null)
		{
			this.regionText.text = info.region;
		}
		if (this.pingText != null)
		{
			this.pingText.text = ((info.pingMs >= 0) ? string.Format("{0}ms", info.pingMs) : "N/A");
		}
	}

	// Token: 0x06000134 RID: 308 RVA: 0x0000A694 File Offset: 0x00008894
	private void OnClick()
	{
		if (this.IsLobbyFull())
		{
			Debug.Log("[MPMapButton] Lobby is full. Click ignored.");
			return;
		}
		if (this._clicked)
		{
			return;
		}
		this._clicked = true;
		if (this.button != null)
		{
			this.button.interactable = false;
		}
		EventSystem current = EventSystem.current;
		if (current != null)
		{
			current.SetSelectedGameObject(null);
		}
		if (this.lobbyViewer == null)
		{
			this.lobbyViewer = LobbyViewer.Instance;
		}
		if (this.lobbyViewer == null)
		{
			Debug.LogWarning("[MPMapButton] LobbyViewer reference not set and Instance is null.", this);
			this.ResetClickable();
			return;
		}
		this.lobbyViewer.SetSelectedLobby(this.lobbyInfo);
		this.lobbyViewer.OpenWindowPrompt();
		this.ResetClickable();
		Debug.Log("Map Button Pressed");
	}

	// Token: 0x06000135 RID: 309 RVA: 0x0000A754 File Offset: 0x00008954
	private bool IsLobbyFull()
	{
		if (this.lobbyInfo == null || string.IsNullOrWhiteSpace(this.lobbyInfo.playerCount))
		{
			return false;
		}
		string text = this.lobbyInfo.playerCount.Trim();
		int num = text.IndexOf('/');
		int num2;
		int num3;
		return num >= 0 && int.TryParse(text.Substring(0, num).Trim(), out num2) && int.TryParse(text.Substring(num + 1).Trim(), out num3) && num3 > 0 && num2 >= num3;
	}

	// Token: 0x06000136 RID: 310 RVA: 0x0000A7DB File Offset: 0x000089DB
	private void ResetClickable()
	{
		this._clicked = false;
		if (this.button != null)
		{
			this.button.interactable = true;
		}
	}

	// Token: 0x04000171 RID: 369
	[Header("UI References")]
	public TMP_Text mapText;

	// Token: 0x04000172 RID: 370
	public TMP_Text hostText;

	// Token: 0x04000173 RID: 371
	public TMP_Text playersText;

	// Token: 0x04000174 RID: 372
	public TMP_Text regionText;

	// Token: 0x04000175 RID: 373
	public TMP_Text pingText;

	// Token: 0x04000176 RID: 374
	public CanvasGroup canvasGroup;

	// Token: 0x04000177 RID: 375
	public Button button;

	// Token: 0x04000178 RID: 376
	public LobbyViewer lobbyViewer;

	// Token: 0x04000179 RID: 377
	[HideInInspector]
	public ModalWindowManager mapLoadPrompt;

	// Token: 0x0400017A RID: 378
	[Header("Lobby Info")]
	public LobbyInfoViewer lobbyInfo;

	// Token: 0x0400017B RID: 379
	private bool _clicked;
}
