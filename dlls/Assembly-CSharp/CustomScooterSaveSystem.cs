using System;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000146 RID: 326
public class CustomScooterSaveSystem : MonoBehaviour
{
	// Token: 0x06000525 RID: 1317 RVA: 0x000232B8 File Offset: 0x000214B8
	private void Awake()
	{
		if (PlayerPrefs.HasKey("CustomScooterSelected"))
		{
			this.scooterBuilderBrain.customScooterSelected = PlayerPrefs.GetInt("CustomScooterSelected");
		}
		if (PlayerPrefs.HasKey("CustomScooter1Saved"))
		{
			this.LoadCustomScooter1();
		}
		if (PlayerPrefs.HasKey("CustomScooter2Saved"))
		{
			this.LoadCustomScooter2();
		}
		if (PlayerPrefs.HasKey("CustomScooter3Saved"))
		{
			this.LoadCustomScooter3();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.scooterBuilderBrain.scooterPegs.pegOption = PlayerPrefs.GetInt("CustomScooter1PegOption");
			this.scooterBuilderBrain.ApplyPegOption();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.scooterBuilderBrain.scooterPegs.pegOption = PlayerPrefs.GetInt("CustomScooter2PegOption");
			this.scooterBuilderBrain.ApplyPegOption();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.scooterBuilderBrain.scooterPegs.pegOption = PlayerPrefs.GetInt("CustomScooter3PegOption");
			this.scooterBuilderBrain.ApplyPegOption();
		}
	}

	// Token: 0x06000526 RID: 1318 RVA: 0x000233B5 File Offset: 0x000215B5
	private void Update()
	{
		if (this.customScooterSaveTrigger != this.scooterBuilderBrain.customScooterSelected)
		{
			this.saveCustomScooterSelected();
			this.customScooterSaveTrigger = this.scooterBuilderBrain.customScooterSelected;
		}
	}

	// Token: 0x06000527 RID: 1319 RVA: 0x000233E1 File Offset: 0x000215E1
	public void saveCustomScooterSelected()
	{
		PlayerPrefs.SetInt("CustomScooterSelected", this.scooterBuilderBrain.customScooterSelected);
	}

	// Token: 0x06000528 RID: 1320 RVA: 0x000233F8 File Offset: 0x000215F8
	public void OpenSavePanel()
	{
		this.cachedButton = EventSystem.current.currentSelectedGameObject;
		this.savePanel.OpenWindow();
		EventSystem.current.SetSelectedGameObject(this.saveButton);
	}

	// Token: 0x06000529 RID: 1321 RVA: 0x00023425 File Offset: 0x00021625
	public void CloseSavePanel()
	{
		this.savePanel.CloseWindow();
		this.mainMenuLogic.allowInput = true;
		EventSystem.current.SetSelectedGameObject(this.cachedButton);
	}

	// Token: 0x0600052A RID: 1322 RVA: 0x00023450 File Offset: 0x00021650
	public void SaveCustomScooter()
	{
		this.CloseSavePanel();
		this.createScooterThumbnail.SaveNewImage();
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.SaveCustomScooter1();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.SaveCustomScooter2();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.SaveCustomScooter3();
		}
	}

	// Token: 0x0600052B RID: 1323 RVA: 0x000234AC File Offset: 0x000216AC
	public void UpdateClothing()
	{
		Debug.Log("Clothing Updated");
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.clothingSlot1.customHead = this.customOutfitAsset.outfit.hat;
			this.clothingSlot1.customTorso = this.customOutfitAsset.outfit.top;
			this.clothingSlot1.customPants = this.customOutfitAsset.outfit.pants;
			this.clothingSlot1.customShoes = this.customOutfitAsset.outfit.shoes;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.clothingSlot2.customHead = this.customOutfitAsset.outfit.hat;
			this.clothingSlot2.customTorso = this.customOutfitAsset.outfit.top;
			this.clothingSlot2.customPants = this.customOutfitAsset.outfit.pants;
			this.clothingSlot2.customShoes = this.customOutfitAsset.outfit.shoes;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.clothingSlot3.customHead = this.customOutfitAsset.outfit.hat;
			this.clothingSlot3.customTorso = this.customOutfitAsset.outfit.top;
			this.clothingSlot3.customPants = this.customOutfitAsset.outfit.pants;
			this.clothingSlot3.customShoes = this.customOutfitAsset.outfit.shoes;
		}
	}

	// Token: 0x0600052C RID: 1324 RVA: 0x00023634 File Offset: 0x00021834
	public void LoadClothing()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.customOutfitAsset.outfit.hat = this.clothingSlot1.customHead;
			this.customOutfitAsset.outfit.top = this.clothingSlot1.customTorso;
			this.customOutfitAsset.outfit.pants = this.clothingSlot1.customPants;
			this.customOutfitAsset.outfit.shoes = this.clothingSlot1.customShoes;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.customOutfitAsset.outfit.hat = this.clothingSlot2.customHead;
			this.customOutfitAsset.outfit.top = this.clothingSlot2.customTorso;
			this.customOutfitAsset.outfit.pants = this.clothingSlot2.customPants;
			this.customOutfitAsset.outfit.shoes = this.clothingSlot2.customShoes;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.customOutfitAsset.outfit.hat = this.clothingSlot3.customHead;
			this.customOutfitAsset.outfit.top = this.clothingSlot3.customTorso;
			this.customOutfitAsset.outfit.pants = this.clothingSlot3.customPants;
			this.customOutfitAsset.outfit.shoes = this.clothingSlot3.customShoes;
		}
		this.outfitController.ApplyCurrentToAnchors();
	}

	// Token: 0x0600052D RID: 1325 RVA: 0x000237BC File Offset: 0x000219BC
	private void SaveCustomScooter1()
	{
		PlayerPrefs.SetString("CustomScooter1Saved", "CustomScooter1Saved");
		PlayerPrefs.SetString("CustomScooter1Deck", this.scooterBuilderBrain.customScooter1.DeckName);
		PlayerPrefs.SetString("CustomScooter1Bars", this.scooterBuilderBrain.customScooter1.BarsName);
		PlayerPrefs.SetString("CustomScooter1Forks", this.scooterBuilderBrain.customScooter1.ForksName);
		PlayerPrefs.SetString("CustomScooter1Clamp", this.scooterBuilderBrain.customScooter1.ClampName);
		PlayerPrefs.SetString("CustomScooter1FrontWheel", this.scooterBuilderBrain.customScooter1.FrontWheelName);
		PlayerPrefs.SetString("CustomScooter1RearWheel", this.scooterBuilderBrain.customScooter1.RearWheelName);
		PlayerPrefs.SetString("CustomScooter1Grips", this.scooterBuilderBrain.customScooter1.GripsName);
		PlayerPrefs.SetString("CustomScooter1BarEnds", this.scooterBuilderBrain.customScooter1.BarEndsName);
		PlayerPrefs.SetString("CustomScooter1GripTape", this.scooterBuilderBrain.customScooter1.GripTapeName);
		PlayerPrefs.SetString("CustomScooter1Pegs", this.scooterBuilderBrain.customScooter1.PegsName);
		PlayerPrefs.SetString("CustomScooter1Headset", this.scooterBuilderBrain.customScooter1.HeadsetName);
		PlayerPrefs.SetInt("CustomScooter1PegOption", this.scooterBuilderBrain.customScooter1.pegOption);
		PlayerPrefs.SetString("CustomClothing1Head", this.clothingSlot1.customHead);
		PlayerPrefs.SetString("CustomClothing1Torso", this.clothingSlot1.customTorso);
		PlayerPrefs.SetString("CustomClothing1Pants", this.clothingSlot1.customPants);
		PlayerPrefs.SetString("CustomClothing1Shoes", this.clothingSlot1.customShoes);
	}

	// Token: 0x0600052E RID: 1326 RVA: 0x00023964 File Offset: 0x00021B64
	private void LoadCustomScooter1()
	{
		this.scooterBuilderBrain.customScooter1.DeckName = PlayerPrefs.GetString("CustomScooter1Deck");
		this.scooterBuilderBrain.customScooter1.BarsName = PlayerPrefs.GetString("CustomScooter1Bars");
		this.scooterBuilderBrain.customScooter1.ForksName = PlayerPrefs.GetString("CustomScooter1Forks");
		this.scooterBuilderBrain.customScooter1.ClampName = PlayerPrefs.GetString("CustomScooter1Clamp");
		this.scooterBuilderBrain.customScooter1.FrontWheelName = PlayerPrefs.GetString("CustomScooter1FrontWheel");
		this.scooterBuilderBrain.customScooter1.RearWheelName = PlayerPrefs.GetString("CustomScooter1RearWheel");
		this.scooterBuilderBrain.customScooter1.GripsName = PlayerPrefs.GetString("CustomScooter1Grips");
		this.scooterBuilderBrain.customScooter1.BarEndsName = PlayerPrefs.GetString("CustomScooter1BarEnds");
		this.scooterBuilderBrain.customScooter1.GripTapeName = PlayerPrefs.GetString("CustomScooter1GripTape");
		this.scooterBuilderBrain.customScooter1.PegsName = PlayerPrefs.GetString("CustomScooter1Pegs");
		this.scooterBuilderBrain.customScooter1.HeadsetName = PlayerPrefs.GetString("CustomScooter1Headset");
		this.scooterBuilderBrain.customScooter1.pegOption = PlayerPrefs.GetInt("CustomScooter1PegOption");
		this.clothingSlot1.customHead = PlayerPrefs.GetString("CustomClothing1Head");
		this.clothingSlot1.customTorso = PlayerPrefs.GetString("CustomClothing1Torso");
		this.clothingSlot1.customPants = PlayerPrefs.GetString("CustomClothing1Pants");
		this.clothingSlot1.customShoes = PlayerPrefs.GetString("CustomClothing1Shoes");
		this.LoadClothing();
	}

	// Token: 0x0600052F RID: 1327 RVA: 0x00023B04 File Offset: 0x00021D04
	private void SaveCustomScooter2()
	{
		PlayerPrefs.SetString("CustomScooter2Saved", "CustomScooter1Saved");
		PlayerPrefs.SetString("CustomScooter2Deck", this.scooterBuilderBrain.customScooter2.DeckName);
		PlayerPrefs.SetString("CustomScooter2Bars", this.scooterBuilderBrain.customScooter2.BarsName);
		PlayerPrefs.SetString("CustomScooter2Forks", this.scooterBuilderBrain.customScooter2.ForksName);
		PlayerPrefs.SetString("CustomScooter2Clamp", this.scooterBuilderBrain.customScooter2.ClampName);
		PlayerPrefs.SetString("CustomScooter2FrontWheel", this.scooterBuilderBrain.customScooter2.FrontWheelName);
		PlayerPrefs.SetString("CustomScooter2RearWheel", this.scooterBuilderBrain.customScooter2.RearWheelName);
		PlayerPrefs.SetString("CustomScooter2Grips", this.scooterBuilderBrain.customScooter2.GripsName);
		PlayerPrefs.SetString("CustomScooter2BarEnds", this.scooterBuilderBrain.customScooter2.BarEndsName);
		PlayerPrefs.SetString("CustomScooter2GripTape", this.scooterBuilderBrain.customScooter2.GripTapeName);
		PlayerPrefs.SetString("CustomScooter2Pegs", this.scooterBuilderBrain.customScooter2.PegsName);
		PlayerPrefs.SetString("CustomScooter2Headset", this.scooterBuilderBrain.customScooter2.HeadsetName);
		PlayerPrefs.SetInt("CustomScooter2PegOption", this.scooterBuilderBrain.customScooter2.pegOption);
		PlayerPrefs.SetString("CustomClothing2Head", this.clothingSlot2.customHead);
		PlayerPrefs.SetString("CustomClothing2Torso", this.clothingSlot2.customTorso);
		PlayerPrefs.SetString("CustomClothing2Pants", this.clothingSlot2.customPants);
		PlayerPrefs.SetString("CustomClothing2Shoes", this.clothingSlot2.customShoes);
	}

	// Token: 0x06000530 RID: 1328 RVA: 0x00023CAC File Offset: 0x00021EAC
	private void LoadCustomScooter2()
	{
		this.scooterBuilderBrain.customScooter2.DeckName = PlayerPrefs.GetString("CustomScooter2Deck");
		this.scooterBuilderBrain.customScooter2.BarsName = PlayerPrefs.GetString("CustomScooter2Bars");
		this.scooterBuilderBrain.customScooter2.ForksName = PlayerPrefs.GetString("CustomScooter2Forks");
		this.scooterBuilderBrain.customScooter2.ClampName = PlayerPrefs.GetString("CustomScooter2Clamp");
		this.scooterBuilderBrain.customScooter2.FrontWheelName = PlayerPrefs.GetString("CustomScooter2FrontWheel");
		this.scooterBuilderBrain.customScooter2.RearWheelName = PlayerPrefs.GetString("CustomScooter2RearWheel");
		this.scooterBuilderBrain.customScooter2.GripsName = PlayerPrefs.GetString("CustomScooter2Grips");
		this.scooterBuilderBrain.customScooter2.BarEndsName = PlayerPrefs.GetString("CustomScooter2BarEnds");
		this.scooterBuilderBrain.customScooter2.GripTapeName = PlayerPrefs.GetString("CustomScooter2GripTape");
		this.scooterBuilderBrain.customScooter2.PegsName = PlayerPrefs.GetString("CustomScooter2Pegs");
		this.scooterBuilderBrain.customScooter2.HeadsetName = PlayerPrefs.GetString("CustomScooter2Headset");
		this.scooterBuilderBrain.customScooter2.pegOption = PlayerPrefs.GetInt("CustomScooter2PegOption");
		this.clothingSlot2.customHead = PlayerPrefs.GetString("CustomClothing2Head");
		this.clothingSlot2.customTorso = PlayerPrefs.GetString("CustomClothing2Torso");
		this.clothingSlot2.customPants = PlayerPrefs.GetString("CustomClothing2Pants");
		this.clothingSlot2.customShoes = PlayerPrefs.GetString("CustomClothing2Shoes");
		this.LoadClothing();
	}

	// Token: 0x06000531 RID: 1329 RVA: 0x00023E4C File Offset: 0x0002204C
	private void SaveCustomScooter3()
	{
		PlayerPrefs.SetString("CustomScooter3Saved", "CustomScooter1Saved");
		PlayerPrefs.SetString("CustomScooter3Deck", this.scooterBuilderBrain.customScooter3.DeckName);
		PlayerPrefs.SetString("CustomScooter3Bars", this.scooterBuilderBrain.customScooter3.BarsName);
		PlayerPrefs.SetString("CustomScooter3Forks", this.scooterBuilderBrain.customScooter3.ForksName);
		PlayerPrefs.SetString("CustomScooter3Clamp", this.scooterBuilderBrain.customScooter3.ClampName);
		PlayerPrefs.SetString("CustomScooter3FrontWheel", this.scooterBuilderBrain.customScooter3.FrontWheelName);
		PlayerPrefs.SetString("CustomScooter3RearWheel", this.scooterBuilderBrain.customScooter3.RearWheelName);
		PlayerPrefs.SetString("CustomScooter3Grips", this.scooterBuilderBrain.customScooter3.GripsName);
		PlayerPrefs.SetString("CustomScooter3BarEnds", this.scooterBuilderBrain.customScooter3.BarEndsName);
		PlayerPrefs.SetString("CustomScooter3GripTape", this.scooterBuilderBrain.customScooter3.GripTapeName);
		PlayerPrefs.SetString("CustomScooter3Pegs", this.scooterBuilderBrain.customScooter3.PegsName);
		PlayerPrefs.SetString("CustomScooter3Headset", this.scooterBuilderBrain.customScooter3.HeadsetName);
		PlayerPrefs.SetInt("CustomScooter3PegOption", this.scooterBuilderBrain.customScooter3.pegOption);
		PlayerPrefs.SetString("CustomClothing3Head", this.clothingSlot3.customHead);
		PlayerPrefs.SetString("CustomClothing3Torso", this.clothingSlot3.customTorso);
		PlayerPrefs.SetString("CustomClothing3Pants", this.clothingSlot3.customPants);
		PlayerPrefs.SetString("CustomClothing3Shoes", this.clothingSlot3.customShoes);
	}

	// Token: 0x06000532 RID: 1330 RVA: 0x00023FF4 File Offset: 0x000221F4
	private void LoadCustomScooter3()
	{
		this.scooterBuilderBrain.customScooter3.DeckName = PlayerPrefs.GetString("CustomScooter3Deck");
		this.scooterBuilderBrain.customScooter3.BarsName = PlayerPrefs.GetString("CustomScooter3Bars");
		this.scooterBuilderBrain.customScooter3.ForksName = PlayerPrefs.GetString("CustomScooter3Forks");
		this.scooterBuilderBrain.customScooter3.ClampName = PlayerPrefs.GetString("CustomScooter3Clamp");
		this.scooterBuilderBrain.customScooter3.FrontWheelName = PlayerPrefs.GetString("CustomScooter3FrontWheel");
		this.scooterBuilderBrain.customScooter3.RearWheelName = PlayerPrefs.GetString("CustomScooter3RearWheel");
		this.scooterBuilderBrain.customScooter3.GripsName = PlayerPrefs.GetString("CustomScooter3Grips");
		this.scooterBuilderBrain.customScooter3.BarEndsName = PlayerPrefs.GetString("CustomScooter3BarEnds");
		this.scooterBuilderBrain.customScooter3.GripTapeName = PlayerPrefs.GetString("CustomScooter3GripTape");
		this.scooterBuilderBrain.customScooter3.PegsName = PlayerPrefs.GetString("CustomScooter3Pegs");
		this.scooterBuilderBrain.customScooter3.HeadsetName = PlayerPrefs.GetString("CustomScooter3Headset");
		this.scooterBuilderBrain.customScooter3.pegOption = PlayerPrefs.GetInt("CustomScooter3PegOption");
		this.clothingSlot3.customHead = PlayerPrefs.GetString("CustomClothing3Head");
		this.clothingSlot3.customTorso = PlayerPrefs.GetString("CustomClothing3Torso");
		this.clothingSlot3.customPants = PlayerPrefs.GetString("CustomClothing3Pants");
		this.clothingSlot3.customShoes = PlayerPrefs.GetString("CustomClothing3Shoes");
		this.LoadClothing();
	}

	// Token: 0x0400082E RID: 2094
	public ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x0400082F RID: 2095
	public MainMenuLogic mainMenuLogic;

	// Token: 0x04000830 RID: 2096
	public CreateScooterThumbnail createScooterThumbnail;

	// Token: 0x04000831 RID: 2097
	public ModalWindowManager savePanel;

	// Token: 0x04000832 RID: 2098
	public GameObject saveButton;

	// Token: 0x04000833 RID: 2099
	private GameObject cachedButton;

	// Token: 0x04000834 RID: 2100
	private int customScooterSaveTrigger;

	// Token: 0x04000835 RID: 2101
	public CustomClothing clothingSlot1;

	// Token: 0x04000836 RID: 2102
	public CustomClothing clothingSlot2;

	// Token: 0x04000837 RID: 2103
	public CustomClothing clothingSlot3;

	// Token: 0x04000838 RID: 2104
	public CustomOutfit customOutfitAsset;

	// Token: 0x04000839 RID: 2105
	public OutfitController outfitController;
}
