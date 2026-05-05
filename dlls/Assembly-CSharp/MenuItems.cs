using System;
using Cinemachine;
using Invector.vCharacterController;
using Michsky.UI.ModernUIPack;
using UnityEngine;

// Token: 0x020000C6 RID: 198
[Serializable]
public class MenuItems
{
	// Token: 0x040004BF RID: 1215
	public string mainMenuSceneName;

	// Token: 0x040004C0 RID: 1216
	public CanvasGroup inGameMenu;

	// Token: 0x040004C1 RID: 1217
	public GameplaySettings gameplaySettings;

	// Token: 0x040004C2 RID: 1218
	public TimeSpeed timeSpeed;

	// Token: 0x040004C3 RID: 1219
	[Header("Menu Pages")]
	public CanvasGroup mainMenuCanvasGroup;

	// Token: 0x040004C4 RID: 1220
	public GameObject menuButtonsFirstSelected;

	// Token: 0x040004C5 RID: 1221
	public CanvasGroup optionsCanvasGroup;

	// Token: 0x040004C6 RID: 1222
	public GameObject optionsFirstSelected;

	// Token: 0x040004C7 RID: 1223
	public CanvasGroup controlsCanvasGroup;

	// Token: 0x040004C8 RID: 1224
	public GameObject controlsFirstSelected;

	// Token: 0x040004C9 RID: 1225
	public ModalWindowManager exitGameModalWindow;

	// Token: 0x040004CA RID: 1226
	public ModalWindowManager mainMenuModalWindow;

	// Token: 0x040004CB RID: 1227
	public ModalWindowManager hostSessionWindow;

	// Token: 0x040004CC RID: 1228
	public GameObject loadScreen;

	// Token: 0x040004CD RID: 1229
	[Header("Disable During Menu")]
	public AnimationTrigger animationTrigger;

	// Token: 0x040004CE RID: 1230
	public vThirdPersonController thirdPersonController;

	// Token: 0x040004CF RID: 1231
	public CinemachineBrain cinemachineBrain;

	// Token: 0x040004D0 RID: 1232
	public GameObject SoundManager;

	// Token: 0x040004D1 RID: 1233
	[Header("Prompt Buttons")]
	public GameObject exitGamePromptButton;

	// Token: 0x040004D2 RID: 1234
	public GameObject mainMenuPromptButton;

	// Token: 0x040004D3 RID: 1235
	public GameObject hoseSessionPromptButton;
}
