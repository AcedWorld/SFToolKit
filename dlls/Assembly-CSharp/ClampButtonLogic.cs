using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000D4 RID: 212
public class ClampButtonLogic : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	// Token: 0x060003A5 RID: 933 RVA: 0x0001B3D8 File Offset: 0x000195D8
	private void Start()
	{
		this.partName_ = GameObject.Find("Part_Brand_And_Title");
		this.Clamp = GameObject.Find("Clamp_Mesh");
		this._scooterBuilderBrain = GameObject.Find("ScooterBuilderBrain");
		this.partName = this.partName_.GetComponent<TMP_Text>();
		this.BrandName = this.Brand.ToString();
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.ApplyPart));
		this.meshRenderer = this.Clamp.GetComponent<MeshRenderer>();
		this.meshFilter = this.Clamp.GetComponent<MeshFilter>();
		this.scooterBuilderBrain = this._scooterBuilderBrain.GetComponent<ScooterBuilderBrain>();
		this.LoadClamp();
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x0001B49E File Offset: 0x0001969E
	private void Update()
	{
		if (this.scooterBuilderBrain.loadTrigger.Clamp)
		{
			this.LoadClamp();
		}
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x0001B4B8 File Offset: 0x000196B8
	private void ApplyPart()
	{
		if (this.clampComponents.clampMesh != null)
		{
			this.meshFilter.mesh = this.clampComponents.clampMesh;
		}
		if (this.clampComponents.clampMaterial != null)
		{
			this.meshRenderer.material = this.clampComponents.clampMaterial;
		}
		this.UpdateSaveSystem();
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x0001B520 File Offset: 0x00019720
	private void LoadClamp()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1 && this.scooterBuilderBrain.customScooter1.ClampName == this.clampName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2 && this.scooterBuilderBrain.customScooter2.ClampName == this.clampName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3 && this.scooterBuilderBrain.customScooter3.ClampName == this.clampName)
		{
			this.ApplyPart();
		}
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x0001B5C0 File Offset: 0x000197C0
	public void OnSelect(BaseEventData eventData)
	{
		this.scooterBuilderBrain.CurrentlySelectedBrand = this.BrandName;
		this.partName.text = this.clampName;
	}

	// Token: 0x060003AA RID: 938 RVA: 0x0001B5E4 File Offset: 0x000197E4
	public void UpdateSaveSystem()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.scooterBuilderBrain.customScooter1.ClampName = this.clampName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.scooterBuilderBrain.customScooter2.ClampName = this.clampName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.scooterBuilderBrain.customScooter3.ClampName = this.clampName;
		}
		this.scooterBuilderBrain.loadTrigger.Clamp = false;
	}

	// Token: 0x0400051A RID: 1306
	[SerializeField]
	private ScooterBrands Brand;

	// Token: 0x0400051B RID: 1307
	public string clampName;

	// Token: 0x0400051C RID: 1308
	private string BrandName;

	// Token: 0x0400051D RID: 1309
	private GameObject _scooterBuilderBrain;

	// Token: 0x0400051E RID: 1310
	private ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x0400051F RID: 1311
	private GameObject Clamp;

	// Token: 0x04000520 RID: 1312
	private MeshFilter meshFilter;

	// Token: 0x04000521 RID: 1313
	private MeshRenderer meshRenderer;

	// Token: 0x04000522 RID: 1314
	private Button button;

	// Token: 0x04000523 RID: 1315
	public ClampComponents clampComponents;

	// Token: 0x04000524 RID: 1316
	private GameObject partName_;

	// Token: 0x04000525 RID: 1317
	private TMP_Text partName;

	// Token: 0x04000526 RID: 1318
	public ClampUIReference UI;
}
