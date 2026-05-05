using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000DE RID: 222
public class FrontWheelButtonLogic : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	// Token: 0x060003C5 RID: 965 RVA: 0x0001BEA0 File Offset: 0x0001A0A0
	private void Start()
	{
		this.partName_ = GameObject.Find("Part_Brand_And_Title");
		this.Wheel = GameObject.Find("FrontWheel_Mesh");
		this.Tyre = GameObject.Find("FrontTyre_Mesh");
		this._scooterBuilderBrain = GameObject.Find("ScooterBuilderBrain");
		this.partName = this.partName_.GetComponent<TMP_Text>();
		this.BrandName = this.Brand.ToString();
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.ApplyPart));
		this.meshRenderer = this.Wheel.GetComponent<MeshRenderer>();
		this.TyreMeshRenderer = this.Tyre.GetComponent<MeshRenderer>();
		this.meshFilter = this.Wheel.GetComponent<MeshFilter>();
		this.scooterBuilderBrain = this._scooterBuilderBrain.GetComponent<ScooterBuilderBrain>();
		this.LoadWheel();
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x0001BF87 File Offset: 0x0001A187
	private void Update()
	{
		if (this.scooterBuilderBrain.loadTrigger.FrontWheel)
		{
			this.LoadWheel();
		}
	}

	// Token: 0x060003C7 RID: 967 RVA: 0x0001BFA4 File Offset: 0x0001A1A4
	private void ApplyPart()
	{
		if (this.wheelComponents.wheelMesh != null)
		{
			this.meshFilter.mesh = this.wheelComponents.wheelMesh;
		}
		if (this.wheelComponents.wheelMaterial != null)
		{
			this.meshRenderer.material = this.wheelComponents.wheelMaterial;
			this.TyreMeshRenderer.material = this.wheelComponents.tyreMaterial;
		}
		this.UpdateSaveSystem();
	}

	// Token: 0x060003C8 RID: 968 RVA: 0x0001C020 File Offset: 0x0001A220
	private void LoadWheel()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1 && this.scooterBuilderBrain.customScooter1.FrontWheelName == this.wheelName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2 && this.scooterBuilderBrain.customScooter2.FrontWheelName == this.wheelName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3 && this.scooterBuilderBrain.customScooter3.FrontWheelName == this.wheelName)
		{
			this.ApplyPart();
		}
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x0001C0C0 File Offset: 0x0001A2C0
	public void OnSelect(BaseEventData eventData)
	{
		this.scooterBuilderBrain.CurrentlySelectedBrand = this.BrandName;
		this.partName.text = this.wheelName;
	}

	// Token: 0x060003CA RID: 970 RVA: 0x0001C0E4 File Offset: 0x0001A2E4
	public void UpdateSaveSystem()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.scooterBuilderBrain.customScooter1.FrontWheelName = this.wheelName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.scooterBuilderBrain.customScooter2.FrontWheelName = this.wheelName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.scooterBuilderBrain.customScooter3.FrontWheelName = this.wheelName;
		}
		this.scooterBuilderBrain.loadTrigger.FrontWheel = false;
	}

	// Token: 0x04000562 RID: 1378
	[SerializeField]
	private ScooterBrands Brand;

	// Token: 0x04000563 RID: 1379
	public string wheelName;

	// Token: 0x04000564 RID: 1380
	private string BrandName;

	// Token: 0x04000565 RID: 1381
	private GameObject _scooterBuilderBrain;

	// Token: 0x04000566 RID: 1382
	private ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x04000567 RID: 1383
	private GameObject Wheel;

	// Token: 0x04000568 RID: 1384
	private GameObject Tyre;

	// Token: 0x04000569 RID: 1385
	private MeshFilter meshFilter;

	// Token: 0x0400056A RID: 1386
	private MeshRenderer meshRenderer;

	// Token: 0x0400056B RID: 1387
	private MeshRenderer TyreMeshRenderer;

	// Token: 0x0400056C RID: 1388
	private Button button;

	// Token: 0x0400056D RID: 1389
	public FrontWheelComponents wheelComponents;

	// Token: 0x0400056E RID: 1390
	private GameObject partName_;

	// Token: 0x0400056F RID: 1391
	private TMP_Text partName;

	// Token: 0x04000570 RID: 1392
	public FrontWheelUIReference UI;
}
