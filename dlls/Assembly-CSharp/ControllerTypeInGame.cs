using System;
using UnityEngine;

// Token: 0x02000144 RID: 324
public class ControllerTypeInGame : MonoBehaviour
{
	// Token: 0x0600051D RID: 1309 RVA: 0x00022EB4 File Offset: 0x000210B4
	private void Start()
	{
		this.LoadControllerType();
	}

	// Token: 0x0600051E RID: 1310 RVA: 0x00022EBC File Offset: 0x000210BC
	public void LoadControllerType()
	{
		if (PlayerPrefs.HasKey("PlayerControllerType"))
		{
			this.controllerType = PlayerPrefs.GetInt("PlayerControllerType");
			this.SetControllerType();
		}
	}

	// Token: 0x0600051F RID: 1311 RVA: 0x00022EE0 File Offset: 0x000210E0
	public void SetControllerType()
	{
		if (this.controllerType == 0)
		{
			this.ApplyPS4();
			this.controlsGuide.ps4Layout.SetActive(true);
			this.controlsGuide.xboxLayout.SetActive(false);
		}
		if (this.controllerType == 1)
		{
			this.ApplyXbox();
			this.controlsGuide.ps4Layout.SetActive(false);
			this.controlsGuide.xboxLayout.SetActive(true);
		}
		this.UpdateTrickButtons();
	}

	// Token: 0x06000520 RID: 1312 RVA: 0x00022F54 File Offset: 0x00021154
	public void ApplyPS4()
	{
		this.UI_Vectors_MainMenu.Circle.sprite = this.pS4_Assets.Circle;
		this.UI_Vectors_MainMenu.Cross.sprite = this.pS4_Assets.Cross;
		this.UI_Vectors_Replay.Triangle.sprite = this.pS4_Assets.Triangle;
		this.UI_Vectors_Replay.Cross.sprite = this.pS4_Assets.Cross;
		this.UI_Vectors_Replay.L2.sprite = this.pS4_Assets.L2;
		this.UI_Vectors_Replay.R2.sprite = this.pS4_Assets.R2;
		this.UI_Vectors_Replay.Share.sprite = this.pS4_Assets.Share;
		RectTransform component = this.UI_Vectors_Replay.Share.GetComponent<RectTransform>();
		if (component != null)
		{
			component.sizeDelta = new Vector2(this.pS4_Assets.shareWidth, this.pS4_Assets.shareHeight);
		}
		RectTransform component2 = this.UI_Vectors_Replay.L2.GetComponent<RectTransform>();
		RectTransform component3 = this.UI_Vectors_Replay.R2.GetComponent<RectTransform>();
		if (component2 != null)
		{
			component2.sizeDelta = new Vector2(this.pS4_Assets.L2R2Width, this.pS4_Assets.L2R2eight);
		}
		if (component3 != null)
		{
			component3.sizeDelta = new Vector2(this.pS4_Assets.L2R2Width, this.pS4_Assets.L2R2eight);
		}
	}

	// Token: 0x06000521 RID: 1313 RVA: 0x000230D0 File Offset: 0x000212D0
	public void ApplyXbox()
	{
		this.UI_Vectors_MainMenu.Circle.sprite = this.xbox_Assets.Circle;
		this.UI_Vectors_MainMenu.Cross.sprite = this.xbox_Assets.Cross;
		this.UI_Vectors_Replay.Triangle.sprite = this.xbox_Assets.Triangle;
		this.UI_Vectors_Replay.Cross.sprite = this.xbox_Assets.Cross;
		this.UI_Vectors_Replay.L2.sprite = this.xbox_Assets.L2;
		this.UI_Vectors_Replay.R2.sprite = this.xbox_Assets.R2;
		this.UI_Vectors_Replay.Share.sprite = this.xbox_Assets.Share;
		RectTransform component = this.UI_Vectors_Replay.Share.GetComponent<RectTransform>();
		if (component != null)
		{
			component.sizeDelta = new Vector2(this.xbox_Assets.shareWidth, this.xbox_Assets.shareHeight);
		}
		RectTransform component2 = this.UI_Vectors_Replay.L2.GetComponent<RectTransform>();
		RectTransform component3 = this.UI_Vectors_Replay.R2.GetComponent<RectTransform>();
		if (component2 != null)
		{
			component2.sizeDelta = new Vector2(this.xbox_Assets.L2R2Width, this.xbox_Assets.L2R2eight);
		}
		if (component3 != null)
		{
			component3.sizeDelta = new Vector2(this.xbox_Assets.L2R2Width, this.xbox_Assets.L2R2eight);
		}
	}

	// Token: 0x06000522 RID: 1314 RVA: 0x0002324C File Offset: 0x0002144C
	public void UpdateTrickButtons()
	{
		foreach (object obj in this.controlsGuide.TrickButtonParent)
		{
			TrickButtonLogic component = ((Transform)obj).GetComponent<TrickButtonLogic>();
			component.ControllerType = this.controllerType;
			component.UpdateTrickIcons();
		}
	}

	// Token: 0x04000824 RID: 2084
	public PS4_Assets_InGame pS4_Assets;

	// Token: 0x04000825 RID: 2085
	public Xbox_Assets_InGame xbox_Assets;

	// Token: 0x04000826 RID: 2086
	public UI_Vectors_MainMenu_Ingame UI_Vectors_MainMenu;

	// Token: 0x04000827 RID: 2087
	public UI_Vectors_Replay_Ingame UI_Vectors_Replay;

	// Token: 0x04000828 RID: 2088
	public ControlsGuide_InGame controlsGuide;

	// Token: 0x04000829 RID: 2089
	public int controllerType;
}
