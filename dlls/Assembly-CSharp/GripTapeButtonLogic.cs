using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000E3 RID: 227
public class GripTapeButtonLogic : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	// Token: 0x060003D6 RID: 982 RVA: 0x0001C468 File Offset: 0x0001A668
	private void Start()
	{
		this.partName_ = GameObject.Find("Part_Brand_And_Title");
		this.GripTape = GameObject.Find("GripTape_Mesh");
		this.gripTapeRenderer = this.GripTape.GetComponent<MeshRenderer>();
		this._scooterBuilderBrain = GameObject.Find("ScooterBuilderBrain");
		this.partName = this.partName_.GetComponent<TMP_Text>();
		this.BrandName = this.Brand.ToString();
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.ApplyPart));
		this.scooterBuilderBrain = this._scooterBuilderBrain.GetComponent<ScooterBuilderBrain>();
		this.gripTapeComponents.button.texture = this.gripTapeComponents.griptapeTexture;
		this.LoadGripTape();
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x0001C538 File Offset: 0x0001A738
	private void Update()
	{
		if (this.scooterBuilderBrain.loadTrigger.GripTape)
		{
			this.LoadGripTape();
		}
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x0001C552 File Offset: 0x0001A752
	private void ApplyPart()
	{
		if (this.gripTapeComponents.griptapeTexture != null)
		{
			this.gripTapeRenderer.material.mainTexture = this.gripTapeComponents.griptapeTexture;
		}
		this.UpdateSaveSystem();
	}

	// Token: 0x060003D9 RID: 985 RVA: 0x0001C588 File Offset: 0x0001A788
	private void LoadGripTape()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1 && this.scooterBuilderBrain.customScooter1.GripTapeName == this.gripTapeName + this.gripTapeIdentificationNumber.ToString())
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2 && this.scooterBuilderBrain.customScooter2.GripTapeName == this.gripTapeName + this.gripTapeIdentificationNumber.ToString())
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3 && this.scooterBuilderBrain.customScooter3.GripTapeName == this.gripTapeName + this.gripTapeIdentificationNumber.ToString())
		{
			this.ApplyPart();
		}
	}

	// Token: 0x060003DA RID: 986 RVA: 0x0001C658 File Offset: 0x0001A858
	public void OnSelect(BaseEventData eventData)
	{
		this.scooterBuilderBrain.CurrentlySelectedBrand = this.BrandName;
		this.partName.text = this.gripTapeName;
	}

	// Token: 0x060003DB RID: 987 RVA: 0x0001C67C File Offset: 0x0001A87C
	public void UpdateSaveSystem()
	{
		this.scooterBuilderBrain.partIdentification.GripTapeIdentificationNumber = this.gripTapeIdentificationNumber;
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.scooterBuilderBrain.customScooter1.GripTapeName = this.gripTapeName + this.gripTapeIdentificationNumber.ToString();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.scooterBuilderBrain.customScooter2.GripTapeName = this.gripTapeName + this.gripTapeIdentificationNumber.ToString();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.scooterBuilderBrain.customScooter3.GripTapeName = this.gripTapeName + this.gripTapeIdentificationNumber.ToString();
		}
		this.scooterBuilderBrain.loadTrigger.GripTape = false;
	}

	// Token: 0x04000588 RID: 1416
	[SerializeField]
	private ScooterBrands Brand;

	// Token: 0x04000589 RID: 1417
	public string gripTapeName;

	// Token: 0x0400058A RID: 1418
	private string BrandName;

	// Token: 0x0400058B RID: 1419
	public int gripTapeIdentificationNumber;

	// Token: 0x0400058C RID: 1420
	private GameObject _scooterBuilderBrain;

	// Token: 0x0400058D RID: 1421
	private ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x0400058E RID: 1422
	private GameObject GripTape;

	// Token: 0x0400058F RID: 1423
	private MeshRenderer gripTapeRenderer;

	// Token: 0x04000590 RID: 1424
	private Button button;

	// Token: 0x04000591 RID: 1425
	public GripTapeComponents gripTapeComponents;

	// Token: 0x04000592 RID: 1426
	private GameObject partName_;

	// Token: 0x04000593 RID: 1427
	private TMP_Text partName;
}
