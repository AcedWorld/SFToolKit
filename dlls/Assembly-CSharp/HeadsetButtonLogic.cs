using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000E6 RID: 230
public class HeadsetButtonLogic : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	// Token: 0x060003DF RID: 991 RVA: 0x0001C74C File Offset: 0x0001A94C
	private void Start()
	{
		this.partName_ = GameObject.Find("Part_Brand_And_Title");
		this.Headset = GameObject.Find("Headset_Mesh");
		this._scooterBuilderBrain = GameObject.Find("ScooterBuilderBrain");
		this.partName = this.partName_.GetComponent<TMP_Text>();
		this.BrandName = this.Brand.ToString();
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.ApplyPart));
		this.meshRenderer = this.Headset.GetComponent<MeshRenderer>();
		this.meshFilter = this.Headset.GetComponent<MeshFilter>();
		this.scooterBuilderBrain = this._scooterBuilderBrain.GetComponent<ScooterBuilderBrain>();
		this.LoadHeadset();
	}

	// Token: 0x060003E0 RID: 992 RVA: 0x0001C812 File Offset: 0x0001AA12
	private void Update()
	{
		if (this.scooterBuilderBrain.loadTrigger.Headset)
		{
			this.LoadHeadset();
		}
	}

	// Token: 0x060003E1 RID: 993 RVA: 0x0001C82C File Offset: 0x0001AA2C
	private void ApplyPart()
	{
		if (this.headsetComponents.headsetMesh != null)
		{
			this.meshFilter.mesh = this.headsetComponents.headsetMesh;
		}
		if (this.headsetComponents.headsetMaterial != null)
		{
			this.meshRenderer.material = this.headsetComponents.headsetMaterial;
		}
		this.UpdateSaveSystem();
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x0001C894 File Offset: 0x0001AA94
	private void LoadHeadset()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1 && this.scooterBuilderBrain.customScooter1.HeadsetName == this.headsetName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2 && this.scooterBuilderBrain.customScooter2.HeadsetName == this.headsetName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3 && this.scooterBuilderBrain.customScooter3.HeadsetName == this.headsetName)
		{
			this.ApplyPart();
		}
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x0001C934 File Offset: 0x0001AB34
	public void OnSelect(BaseEventData eventData)
	{
		this.scooterBuilderBrain.CurrentlySelectedBrand = this.BrandName;
		this.partName.text = this.headsetName;
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x0001C958 File Offset: 0x0001AB58
	public void UpdateSaveSystem()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.scooterBuilderBrain.customScooter1.HeadsetName = this.headsetName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.scooterBuilderBrain.customScooter2.HeadsetName = this.headsetName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.scooterBuilderBrain.customScooter3.HeadsetName = this.headsetName;
		}
		this.scooterBuilderBrain.loadTrigger.Headset = false;
	}

	// Token: 0x04000598 RID: 1432
	[SerializeField]
	private ScooterBrands Brand;

	// Token: 0x04000599 RID: 1433
	public string headsetName;

	// Token: 0x0400059A RID: 1434
	private string BrandName;

	// Token: 0x0400059B RID: 1435
	private GameObject _scooterBuilderBrain;

	// Token: 0x0400059C RID: 1436
	private ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x0400059D RID: 1437
	private GameObject Headset;

	// Token: 0x0400059E RID: 1438
	private MeshFilter meshFilter;

	// Token: 0x0400059F RID: 1439
	private MeshRenderer meshRenderer;

	// Token: 0x040005A0 RID: 1440
	private Button button;

	// Token: 0x040005A1 RID: 1441
	public HeadsetComponents headsetComponents;

	// Token: 0x040005A2 RID: 1442
	private GameObject partName_;

	// Token: 0x040005A3 RID: 1443
	private TMP_Text partName;

	// Token: 0x040005A4 RID: 1444
	public HeadsetUIReference UI;
}
