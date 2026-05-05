using System;
using System.Collections;
using UnityEngine;

// Token: 0x020001B9 RID: 441
public class ScooterBuilderBrain : MonoBehaviour
{
	// Token: 0x060006CF RID: 1743 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x060006D0 RID: 1744 RVA: 0x00032F54 File Offset: 0x00031154
	private void Update()
	{
		if (this.logoTrigger != this.CurrentlySelectedBrand)
		{
			this.logoLogic.BrandName = this.CurrentlySelectedBrand;
			this.logoLogic.UpdateLogo();
			this.logoTrigger = this.CurrentlySelectedBrand;
		}
		if (this.customScooterSelected == 1 && this.tapeTrigger2 != this.customScooter1.GripTapeName)
		{
			this.RenderTapeCamera();
			this.tapeTrigger2 = this.customScooter1.GripTapeName;
			this.UpdateCustomScooter();
		}
		if (this.customScooterSelected == 2 && this.tapeTrigger2 != this.customScooter2.GripTapeName)
		{
			this.RenderTapeCamera();
			this.tapeTrigger2 = this.customScooter2.GripTapeName;
			this.UpdateCustomScooter();
		}
		if (this.customScooterSelected == 3 && this.tapeTrigger2 != this.customScooter3.GripTapeName)
		{
			this.RenderTapeCamera();
			this.tapeTrigger2 = this.customScooter3.GripTapeName;
			this.UpdateCustomScooter();
		}
	}

	// Token: 0x060006D1 RID: 1745 RVA: 0x00033058 File Offset: 0x00031258
	public void UpdateCustomScooter()
	{
		if (this.customScootersAsset == null)
		{
			return;
		}
		if (this.customScootersAsset.scooter1 == null)
		{
			this.customScootersAsset.scooter1 = new CustomScooterData();
		}
		if (this.customScootersAsset.scooter2 == null)
		{
			this.customScootersAsset.scooter2 = new CustomScooterData();
		}
		if (this.customScootersAsset.scooter3 == null)
		{
			this.customScootersAsset.scooter3 = new CustomScooterData();
		}
		this.customScootersAsset.scooter1.deck = this.customScooter1.DeckName;
		this.customScootersAsset.scooter1.bars = this.customScooter1.BarsName;
		this.customScootersAsset.scooter1.fork = this.customScooter1.ForksName;
		this.customScootersAsset.scooter1.clamp = this.customScooter1.ClampName;
		this.customScootersAsset.scooter1.frontWheel = this.customScooter1.FrontWheelName;
		this.customScootersAsset.scooter1.rearWheel = this.customScooter1.RearWheelName;
		this.customScootersAsset.scooter1.grips = this.customScooter1.GripsName;
		this.customScootersAsset.scooter1.barEnds = this.customScooter1.BarEndsName;
		this.customScootersAsset.scooter1.headset = this.customScooter1.HeadsetName;
		this.customScootersAsset.scooter1.gripTape = this.customScooter1.GripTapeName;
		this.customScootersAsset.scooter1.pegs = this.customScooter1.PegsName;
		this.customScootersAsset.scooter1.pegOption = this.customScooter1.pegOption;
		this.customScootersAsset.scooter1.hasDeckPegs = this.customScooter1.hasDeckPegs;
		this.customScootersAsset.scooter2.deck = this.customScooter2.DeckName;
		this.customScootersAsset.scooter2.bars = this.customScooter2.BarsName;
		this.customScootersAsset.scooter2.fork = this.customScooter2.ForksName;
		this.customScootersAsset.scooter2.clamp = this.customScooter2.ClampName;
		this.customScootersAsset.scooter2.frontWheel = this.customScooter2.FrontWheelName;
		this.customScootersAsset.scooter2.rearWheel = this.customScooter2.RearWheelName;
		this.customScootersAsset.scooter2.grips = this.customScooter2.GripsName;
		this.customScootersAsset.scooter2.barEnds = this.customScooter2.BarEndsName;
		this.customScootersAsset.scooter2.headset = this.customScooter2.HeadsetName;
		this.customScootersAsset.scooter2.gripTape = this.customScooter2.GripTapeName;
		this.customScootersAsset.scooter2.pegs = this.customScooter2.PegsName;
		this.customScootersAsset.scooter2.pegOption = this.customScooter2.pegOption;
		this.customScootersAsset.scooter2.hasDeckPegs = this.customScooter2.hasDeckPegs;
		this.customScootersAsset.scooter3.deck = this.customScooter3.DeckName;
		this.customScootersAsset.scooter3.bars = this.customScooter3.BarsName;
		this.customScootersAsset.scooter3.fork = this.customScooter3.ForksName;
		this.customScootersAsset.scooter3.clamp = this.customScooter3.ClampName;
		this.customScootersAsset.scooter3.frontWheel = this.customScooter3.FrontWheelName;
		this.customScootersAsset.scooter3.rearWheel = this.customScooter3.RearWheelName;
		this.customScootersAsset.scooter3.grips = this.customScooter3.GripsName;
		this.customScootersAsset.scooter3.barEnds = this.customScooter3.BarEndsName;
		this.customScootersAsset.scooter3.headset = this.customScooter3.HeadsetName;
		this.customScootersAsset.scooter3.gripTape = this.customScooter3.GripTapeName;
		this.customScootersAsset.scooter3.pegs = this.customScooter3.PegsName;
		this.customScootersAsset.scooter3.pegOption = this.customScooter3.pegOption;
		this.customScootersAsset.scooter3.hasDeckPegs = this.customScooter3.hasDeckPegs;
		if (this.partIdentification != null)
		{
			this.customScootersAsset.scooter1.gripTapeId = this.partIdentification.GripTapeIdentificationNumber;
			this.customScootersAsset.scooter2.gripTapeId = this.partIdentification.GripTapeIdentificationNumber;
			this.customScootersAsset.scooter3.gripTapeId = this.partIdentification.GripTapeIdentificationNumber;
		}
	}

	// Token: 0x060006D2 RID: 1746 RVA: 0x00033544 File Offset: 0x00031744
	public void CustomScooter1()
	{
		if (this.customScooterSelected != 1)
		{
			this.scooterPegs.pegOption = this.customScooter1.pegOption;
			this.customScooterSelected = 1;
			this.ApplySelectedSlotToSO();
			this.LoadContents();
		}
		else
		{
			this.DisableContents();
		}
		this.customScooterSaveSystem.LoadClothing();
	}

	// Token: 0x060006D3 RID: 1747 RVA: 0x00033598 File Offset: 0x00031798
	public void CustomScooter2()
	{
		if (this.customScooterSelected != 2)
		{
			this.scooterPegs.pegOption = this.customScooter2.pegOption;
			this.customScooterSelected = 2;
			this.ApplySelectedSlotToSO();
			this.LoadContents();
		}
		else
		{
			this.DisableContents();
		}
		this.customScooterSaveSystem.LoadClothing();
	}

	// Token: 0x060006D4 RID: 1748 RVA: 0x000335EC File Offset: 0x000317EC
	public void CustomScooter3()
	{
		if (this.customScooterSelected != 3)
		{
			this.scooterPegs.pegOption = this.customScooter3.pegOption;
			this.customScooterSelected = 3;
			this.ApplySelectedSlotToSO();
			this.LoadContents();
		}
		else
		{
			this.DisableContents();
		}
		this.customScooterSaveSystem.LoadClothing();
	}

	// Token: 0x060006D5 RID: 1749 RVA: 0x0003363E File Offset: 0x0003183E
	private void ApplySelectedSlotToSO()
	{
		if (this.customScootersAsset == null)
		{
			return;
		}
		this.customScootersAsset.activeSlot = Mathf.Clamp(this.customScooterSelected, 1, 3);
	}

	// Token: 0x060006D6 RID: 1750 RVA: 0x00033667 File Offset: 0x00031867
	public void RenderTapeCamera()
	{
		this.gripTapeCamera.Render();
	}

	// Token: 0x060006D7 RID: 1751 RVA: 0x00033674 File Offset: 0x00031874
	public void ChangePegOption()
	{
		if (this.customScooterSelected == 1)
		{
			this.customScooter1.pegOption++;
			this.scooterPegs.pegOption = this.customScooter1.pegOption;
		}
		if (this.customScooterSelected == 2)
		{
			this.customScooter2.pegOption++;
			this.scooterPegs.pegOption = this.customScooter2.pegOption;
		}
		if (this.customScooterSelected == 3)
		{
			this.customScooter3.pegOption++;
			this.scooterPegs.pegOption = this.customScooter3.pegOption;
		}
		this.ApplyPegOption();
		this.UpdateCustomScooter();
	}

	// Token: 0x060006D8 RID: 1752 RVA: 0x00033724 File Offset: 0x00031924
	public void ApplyPegOption()
	{
		if (this.scooterPegs.pegOption == 0)
		{
			this.scooterPegs.frontLeftPeg.SetActive(true);
			this.scooterPegs.frontRightPeg.SetActive(true);
			this.scooterPegs.rearLeftPeg.SetActive(true);
			this.scooterPegs.rearRightPeg.SetActive(true);
		}
		if (this.scooterPegs.pegOption == 1)
		{
			this.scooterPegs.frontLeftPeg.SetActive(true);
			this.scooterPegs.frontRightPeg.SetActive(false);
			this.scooterPegs.rearLeftPeg.SetActive(true);
			this.scooterPegs.rearRightPeg.SetActive(false);
		}
		if (this.scooterPegs.pegOption == 2)
		{
			this.scooterPegs.frontLeftPeg.SetActive(false);
			this.scooterPegs.frontRightPeg.SetActive(true);
			this.scooterPegs.rearLeftPeg.SetActive(false);
			this.scooterPegs.rearRightPeg.SetActive(true);
		}
		if (this.scooterPegs.pegOption == 3)
		{
			this.scooterPegs.frontLeftPeg.SetActive(true);
			this.scooterPegs.frontRightPeg.SetActive(true);
			this.scooterPegs.rearLeftPeg.SetActive(false);
			this.scooterPegs.rearRightPeg.SetActive(false);
		}
		if (this.scooterPegs.pegOption == 4)
		{
			this.scooterPegs.frontLeftPeg.SetActive(false);
			this.scooterPegs.frontRightPeg.SetActive(false);
			this.scooterPegs.rearLeftPeg.SetActive(true);
			this.scooterPegs.rearRightPeg.SetActive(true);
		}
		if (this.scooterPegs.pegOption == 5)
		{
			this.scooterPegs.frontLeftPeg.SetActive(false);
			this.scooterPegs.frontRightPeg.SetActive(false);
			this.scooterPegs.rearLeftPeg.SetActive(false);
			this.scooterPegs.rearRightPeg.SetActive(false);
		}
		if (this.scooterPegs.pegOption == 6)
		{
			if (this.customScooterSelected == 1)
			{
				this.customScooter1.pegOption = 0;
				this.scooterPegs.pegOption = 0;
			}
			if (this.customScooterSelected == 2)
			{
				this.customScooter2.pegOption = 0;
				this.scooterPegs.pegOption = 0;
			}
			if (this.customScooterSelected == 3)
			{
				this.customScooter3.pegOption = 0;
				this.scooterPegs.pegOption = 0;
			}
			this.ApplyPegOption();
		}
	}

	// Token: 0x060006D9 RID: 1753 RVA: 0x00033994 File Offset: 0x00031B94
	public void SetDeckPegs(bool hasDeckPegs)
	{
		this.scooterDetails.hasDeckPegs = hasDeckPegs;
		if (this.customScooterSelected == 1)
		{
			this.customScooter1.hasDeckPegs = hasDeckPegs;
		}
		if (this.customScooterSelected == 2)
		{
			this.customScooter2.hasDeckPegs = hasDeckPegs;
		}
		if (this.customScooterSelected == 3)
		{
			this.customScooter3.hasDeckPegs = hasDeckPegs;
		}
		this.UpdateCustomScooter();
	}

	// Token: 0x060006DA RID: 1754 RVA: 0x000339F4 File Offset: 0x00031BF4
	public void SetTriggers()
	{
		this.loadTrigger.Deck = true;
		this.loadTrigger.Bars = true;
		this.loadTrigger.Forks = true;
		this.loadTrigger.Clamp = true;
		this.loadTrigger.FrontWheel = true;
		this.loadTrigger.RearWheel = true;
		this.loadTrigger.Grips = true;
		this.loadTrigger.BarEnds = true;
		this.loadTrigger.GripTape = true;
		this.loadTrigger.Pegs = true;
		this.loadTrigger.Headset = true;
	}

	// Token: 0x060006DB RID: 1755 RVA: 0x00033A88 File Offset: 0x00031C88
	private void LoadContents()
	{
		this.mainMenuLogic.allowInput = false;
		this.partWindows.loadPanel.SetActive(true);
		GameObject[] partWindow = this.partWindows.partWindow;
		for (int i = 0; i < partWindow.Length; i++)
		{
			partWindow[i].SetActive(true);
		}
		this.ApplyPegOption();
		this.UpdateCustomScooter();
		base.StartCoroutine(this.disableWindows());
	}

	// Token: 0x060006DC RID: 1756 RVA: 0x00033AEE File Offset: 0x00031CEE
	private IEnumerator disableWindows()
	{
		yield return new WaitForSecondsRealtime(1f);
		this.SetTriggers();
		yield return new WaitForSecondsRealtime(1f);
		this.DisableContents();
		yield break;
	}

	// Token: 0x060006DD RID: 1757 RVA: 0x00033B00 File Offset: 0x00031D00
	private void DisableContents()
	{
		this.mainMenuLogic.allowInput = true;
		this.partWindows.loadPanel.SetActive(false);
		GameObject[] partWindow = this.partWindows.partWindow;
		for (int i = 0; i < partWindow.Length; i++)
		{
			partWindow[i].SetActive(false);
		}
	}

	// Token: 0x04000C2F RID: 3119
	[Header("ScriptableObject Sync")]
	public CustomScooter customScootersAsset;

	// Token: 0x04000C30 RID: 3120
	public MainMenuLogic mainMenuLogic;

	// Token: 0x04000C31 RID: 3121
	public ScooterDetails scooterDetails;

	// Token: 0x04000C32 RID: 3122
	public PartWindowsToLoad partWindows;

	// Token: 0x04000C33 RID: 3123
	public Camera gripTapeCamera;

	// Token: 0x04000C34 RID: 3124
	public LogoLogic logoLogic;

	// Token: 0x04000C35 RID: 3125
	[Header("Identification")]
	public int customScooterSelected;

	// Token: 0x04000C36 RID: 3126
	public string CurrentlySelectedBrand;

	// Token: 0x04000C37 RID: 3127
	public LoadDuringGameplay loadTrigger;

	// Token: 0x04000C38 RID: 3128
	[HideInInspector]
	public PartIdentification partIdentification;

	// Token: 0x04000C39 RID: 3129
	public ScooterPegs scooterPegs;

	// Token: 0x04000C3A RID: 3130
	private int windowTrigger;

	// Token: 0x04000C3B RID: 3131
	private string logoTrigger;

	// Token: 0x04000C3C RID: 3132
	private string tapeTrigger2;

	// Token: 0x04000C3D RID: 3133
	[Header("Custom Scooters")]
	public CustomScooter1 customScooter1;

	// Token: 0x04000C3E RID: 3134
	public CustomScooter2 customScooter2;

	// Token: 0x04000C3F RID: 3135
	public CustomScooter3 customScooter3;

	// Token: 0x04000C40 RID: 3136
	public CustomScooterSaveSystem customScooterSaveSystem;
}
