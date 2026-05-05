using System;
using UnityEngine;

// Token: 0x0200013E RID: 318
public class ControllerType : MonoBehaviour
{
	// Token: 0x06000510 RID: 1296 RVA: 0x00022A00 File Offset: 0x00020C00
	public void Start()
	{
		if (PlayerPrefs.HasKey("PlayerControllerType"))
		{
			this.controllerType = PlayerPrefs.GetInt("PlayerControllerType");
		}
		this.UpdateControllerType();
	}

	// Token: 0x06000511 RID: 1297 RVA: 0x000020BE File Offset: 0x000002BE
	public void Update()
	{
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x00022A24 File Offset: 0x00020C24
	public void ToggleControllerType()
	{
		this.UpdateControllerType();
	}

	// Token: 0x06000513 RID: 1299 RVA: 0x00022A2C File Offset: 0x00020C2C
	private void UpdateControllerType()
	{
		if (this.controllerType == 0)
		{
			this.ApplyPS4();
			this.controlsGuide.ps4Layout.SetActive(true);
			this.controlsGuide.xboxLayout.SetActive(false);
			this.UpdateTrickButtons();
		}
		if (this.controllerType == 1)
		{
			this.ApplyXbox();
			this.controlsGuide.ps4Layout.SetActive(false);
			this.controlsGuide.xboxLayout.SetActive(true);
			this.UpdateTrickButtons();
		}
	}

	// Token: 0x06000514 RID: 1300 RVA: 0x00022AA8 File Offset: 0x00020CA8
	public void ApplyPS4()
	{
		this.controllerType = 0;
		this.UI_Vectors_MainMenu.L1.sprite = this.pS4_Assets.L1;
		this.UI_Vectors_MainMenu.L1.SetNativeSize();
		this.UI_Vectors_MainMenu.L1.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.25f, 0.25f);
		this.UI_Vectors_MainMenu.R1.sprite = this.pS4_Assets.R1;
		this.UI_Vectors_MainMenu.R1.SetNativeSize();
		this.UI_Vectors_MainMenu.R1.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.25f, 0.25f);
		this.uI_Vectors_Customizor.L1.sprite = this.pS4_Assets.L1;
		this.uI_Vectors_Customizor.L1.SetNativeSize();
		this.uI_Vectors_Customizor.L1.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.25f, 0.25f);
		this.uI_Vectors_Customizor.R1.sprite = this.pS4_Assets.R1;
		this.uI_Vectors_Customizor.R1.SetNativeSize();
		this.uI_Vectors_Customizor.R1.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.25f, 0.25f);
		this.UI_Vectors_MainMenu.Triangle.sprite = this.pS4_Assets.Triangle;
		this.UI_Vectors_MainMenu.Circle.sprite = this.pS4_Assets.Circle;
		this.UI_Vectors_MainMenu.Cross.sprite = this.pS4_Assets.Cross;
		this.UI_Vectors_MainMenu.Square.sprite = this.pS4_Assets.Square;
	}

	// Token: 0x06000515 RID: 1301 RVA: 0x00022C78 File Offset: 0x00020E78
	public void ApplyXbox()
	{
		this.controllerType = 1;
		this.UI_Vectors_MainMenu.L1.sprite = this.xbox_Assets.L1;
		this.UI_Vectors_MainMenu.L1.SetNativeSize();
		this.UI_Vectors_MainMenu.L1.GetComponent<RectTransform>().localScale = new Vector3(0.45f, 0.45f, 0.45f);
		this.UI_Vectors_MainMenu.R1.sprite = this.xbox_Assets.R1;
		this.UI_Vectors_MainMenu.R1.SetNativeSize();
		this.UI_Vectors_MainMenu.R1.GetComponent<RectTransform>().localScale = new Vector3(0.45f, 0.45f, 0.45f);
		this.uI_Vectors_Customizor.L1.sprite = this.xbox_Assets.L1;
		this.uI_Vectors_Customizor.L1.SetNativeSize();
		this.uI_Vectors_Customizor.L1.GetComponent<RectTransform>().localScale = new Vector3(0.45f, 0.45f, 0.45f);
		this.uI_Vectors_Customizor.R1.sprite = this.xbox_Assets.R1;
		this.uI_Vectors_Customizor.R1.SetNativeSize();
		this.uI_Vectors_Customizor.R1.GetComponent<RectTransform>().localScale = new Vector3(0.45f, 0.45f, 0.45f);
		this.UI_Vectors_MainMenu.Triangle.sprite = this.xbox_Assets.Triangle;
		this.UI_Vectors_MainMenu.Circle.sprite = this.xbox_Assets.Circle;
		this.UI_Vectors_MainMenu.Cross.sprite = this.xbox_Assets.Cross;
		this.UI_Vectors_MainMenu.Square.sprite = this.xbox_Assets.Square;
	}

	// Token: 0x06000516 RID: 1302 RVA: 0x00022E48 File Offset: 0x00021048
	public void UpdateTrickButtons()
	{
		foreach (object obj in this.controlsGuide.TrickButtonParent)
		{
			TrickButtonLogic component = ((Transform)obj).GetComponent<TrickButtonLogic>();
			component.ControllerType = this.controllerType;
			component.UpdateTrickIcons();
		}
	}

	// Token: 0x040007F6 RID: 2038
	public PS4_Assets pS4_Assets;

	// Token: 0x040007F7 RID: 2039
	public Xbox_Assets xbox_Assets;

	// Token: 0x040007F8 RID: 2040
	public UI_Vectors_MainMenu UI_Vectors_MainMenu;

	// Token: 0x040007F9 RID: 2041
	public UI_Vectors_Customizor uI_Vectors_Customizor;

	// Token: 0x040007FA RID: 2042
	public ControlsGuide controlsGuide;

	// Token: 0x040007FB RID: 2043
	public int controllerType;
}
