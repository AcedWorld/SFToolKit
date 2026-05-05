using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000E1 RID: 225
public class GripsButtonLogic : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	// Token: 0x060003CE RID: 974 RVA: 0x0001C170 File Offset: 0x0001A370
	private void Start()
	{
		this.partName_ = GameObject.Find("Part_Brand_And_Title");
		this.LeftGrip = GameObject.Find("LeftGrip_Mesh");
		this.RightGrip = GameObject.Find("RightGrip_Mesh");
		this._scooterBuilderBrain = GameObject.Find("ScooterBuilderBrain");
		this.partName = this.partName_.GetComponent<TMP_Text>();
		this.BrandName = this.Brand.ToString();
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.ApplyPart));
		this.leftGripRenderer = this.LeftGrip.GetComponent<MeshRenderer>();
		this.rightGripRenderer = this.RightGrip.GetComponent<MeshRenderer>();
		this.leftGripFilter = this.LeftGrip.GetComponent<MeshFilter>();
		this.rightGripFilter = this.RightGrip.GetComponent<MeshFilter>();
		this.scooterBuilderBrain = this._scooterBuilderBrain.GetComponent<ScooterBuilderBrain>();
		this.LoadGrips();
	}

	// Token: 0x060003CF RID: 975 RVA: 0x0001C268 File Offset: 0x0001A468
	private void Update()
	{
		if (this.scooterBuilderBrain.loadTrigger.Grips)
		{
			this.LoadGrips();
		}
	}

	// Token: 0x060003D0 RID: 976 RVA: 0x0001C284 File Offset: 0x0001A484
	private void ApplyPart()
	{
		if (this.gripsComponents.LeftGripMesh != null)
		{
			this.leftGripFilter.mesh = this.gripsComponents.LeftGripMesh;
			this.rightGripFilter.mesh = this.gripsComponents.RightGripMesh;
		}
		if (this.gripsComponents.gripMaterial != null)
		{
			this.leftGripRenderer.material = this.gripsComponents.gripMaterial;
			this.rightGripRenderer.material = this.gripsComponents.gripMaterial;
		}
		this.UpdateSaveSystem();
	}

	// Token: 0x060003D1 RID: 977 RVA: 0x0001C318 File Offset: 0x0001A518
	private void LoadGrips()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1 && this.scooterBuilderBrain.customScooter1.GripsName == this.gripsName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2 && this.scooterBuilderBrain.customScooter2.GripsName == this.gripsName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3 && this.scooterBuilderBrain.customScooter3.GripsName == this.gripsName)
		{
			this.ApplyPart();
		}
	}

	// Token: 0x060003D2 RID: 978 RVA: 0x0001C3B8 File Offset: 0x0001A5B8
	public void OnSelect(BaseEventData eventData)
	{
		this.scooterBuilderBrain.CurrentlySelectedBrand = this.BrandName;
		this.partName.text = this.gripsName;
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x0001C3DC File Offset: 0x0001A5DC
	public void UpdateSaveSystem()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.scooterBuilderBrain.customScooter1.GripsName = this.gripsName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.scooterBuilderBrain.customScooter2.GripsName = this.gripsName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.scooterBuilderBrain.customScooter3.GripsName = this.gripsName;
		}
		this.scooterBuilderBrain.loadTrigger.Grips = false;
	}

	// Token: 0x04000576 RID: 1398
	[SerializeField]
	private ScooterBrands Brand;

	// Token: 0x04000577 RID: 1399
	public string gripsName;

	// Token: 0x04000578 RID: 1400
	private string BrandName;

	// Token: 0x04000579 RID: 1401
	private GameObject _scooterBuilderBrain;

	// Token: 0x0400057A RID: 1402
	private ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x0400057B RID: 1403
	private GameObject LeftGrip;

	// Token: 0x0400057C RID: 1404
	private GameObject RightGrip;

	// Token: 0x0400057D RID: 1405
	private MeshFilter leftGripFilter;

	// Token: 0x0400057E RID: 1406
	private MeshFilter rightGripFilter;

	// Token: 0x0400057F RID: 1407
	private MeshRenderer leftGripRenderer;

	// Token: 0x04000580 RID: 1408
	private MeshRenderer rightGripRenderer;

	// Token: 0x04000581 RID: 1409
	private Button button;

	// Token: 0x04000582 RID: 1410
	public GripsComponents gripsComponents;

	// Token: 0x04000583 RID: 1411
	private GameObject partName_;

	// Token: 0x04000584 RID: 1412
	private TMP_Text partName;

	// Token: 0x04000585 RID: 1413
	public GripsUIReference UI;
}
