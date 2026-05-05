using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000ED RID: 237
public class RearWheelButtonLogic : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	// Token: 0x060003F2 RID: 1010 RVA: 0x0001CD80 File Offset: 0x0001AF80
	private void Start()
	{
		this.partName_ = GameObject.Find("Part_Brand_And_Title");
		this.Wheel = GameObject.Find("RearWheel_Mesh");
		this.Tyre = GameObject.Find("RearTyre_Mesh");
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

	// Token: 0x060003F3 RID: 1011 RVA: 0x0001CE67 File Offset: 0x0001B067
	private void Update()
	{
		if (this.scooterBuilderBrain.loadTrigger.RearWheel)
		{
			this.LoadWheel();
		}
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x0001CE84 File Offset: 0x0001B084
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

	// Token: 0x060003F5 RID: 1013 RVA: 0x0001CF00 File Offset: 0x0001B100
	private void LoadWheel()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1 && this.scooterBuilderBrain.customScooter1.RearWheelName == this.wheelName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2 && this.scooterBuilderBrain.customScooter2.RearWheelName == this.wheelName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3 && this.scooterBuilderBrain.customScooter3.RearWheelName == this.wheelName)
		{
			this.ApplyPart();
		}
	}

	// Token: 0x060003F6 RID: 1014 RVA: 0x0001CFA0 File Offset: 0x0001B1A0
	public void OnSelect(BaseEventData eventData)
	{
		this.scooterBuilderBrain.CurrentlySelectedBrand = this.BrandName;
		this.partName.text = this.wheelName;
	}

	// Token: 0x060003F7 RID: 1015 RVA: 0x0001CFC4 File Offset: 0x0001B1C4
	public void UpdateSaveSystem()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.scooterBuilderBrain.customScooter1.RearWheelName = this.wheelName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.scooterBuilderBrain.customScooter2.RearWheelName = this.wheelName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.scooterBuilderBrain.customScooter3.RearWheelName = this.wheelName;
		}
		this.scooterBuilderBrain.loadTrigger.RearWheel = false;
	}

	// Token: 0x040005C8 RID: 1480
	[SerializeField]
	private ScooterBrands Brand;

	// Token: 0x040005C9 RID: 1481
	public string wheelName;

	// Token: 0x040005CA RID: 1482
	private string BrandName;

	// Token: 0x040005CB RID: 1483
	private GameObject _scooterBuilderBrain;

	// Token: 0x040005CC RID: 1484
	private ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x040005CD RID: 1485
	private GameObject Wheel;

	// Token: 0x040005CE RID: 1486
	private GameObject Tyre;

	// Token: 0x040005CF RID: 1487
	private MeshFilter meshFilter;

	// Token: 0x040005D0 RID: 1488
	private MeshRenderer meshRenderer;

	// Token: 0x040005D1 RID: 1489
	private MeshRenderer TyreMeshRenderer;

	// Token: 0x040005D2 RID: 1490
	private Button button;

	// Token: 0x040005D3 RID: 1491
	public RearWheelComponents wheelComponents;

	// Token: 0x040005D4 RID: 1492
	private GameObject partName_;

	// Token: 0x040005D5 RID: 1493
	private TMP_Text partName;

	// Token: 0x040005D6 RID: 1494
	public RearWheelUIReference UI;
}
