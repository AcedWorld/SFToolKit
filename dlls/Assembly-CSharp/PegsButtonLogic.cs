using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000EA RID: 234
public class PegsButtonLogic : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	// Token: 0x060003E9 RID: 1001 RVA: 0x0001C9E4 File Offset: 0x0001ABE4
	private void Start()
	{
		this.partName_ = GameObject.Find("Part_Brand_And_Title");
		this.frontLeftPegmeshFilter = this.references.frontLeftPeg.GetComponent<MeshFilter>();
		this.frontLeftPegmeshRenderer = this.references.frontLeftPeg.GetComponent<MeshRenderer>();
		this.frontRightPegmeshFilter = this.references.frontRightPeg.GetComponent<MeshFilter>();
		this.frontRightPegmeshRenderer = this.references.frontRightPeg.GetComponent<MeshRenderer>();
		this.rearLeftPegmeshFilter = this.references.rearLeftPeg.GetComponent<MeshFilter>();
		this.rearLeftPegmeshRenderer = this.references.rearLeftPeg.GetComponent<MeshRenderer>();
		this.rearRightPegmeshFilter = this.references.rearRightPeg.GetComponent<MeshFilter>();
		this.rearRightPegmeshRenderer = this.references.rearRightPeg.GetComponent<MeshRenderer>();
		this.partName = this.partName_.GetComponent<TMP_Text>();
		this.BrandName = this.Brand.ToString();
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.ApplyPart));
		this._scooterBuilderBrain = GameObject.Find("ScooterBuilderBrain");
		this.scooterBuilderBrain = this._scooterBuilderBrain.GetComponent<ScooterBuilderBrain>();
		this.LoadPegs();
	}

	// Token: 0x060003EA RID: 1002 RVA: 0x0001CB28 File Offset: 0x0001AD28
	private void Update()
	{
		if (this.scooterBuilderBrain.loadTrigger.Pegs)
		{
			this.LoadPegs();
		}
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x0001CB44 File Offset: 0x0001AD44
	private void ApplyPart()
	{
		if (this.pegsComponents.frontLeftPegMesh != null)
		{
			this.frontLeftPegmeshFilter.mesh = this.pegsComponents.frontLeftPegMesh;
			this.frontRightPegmeshFilter.mesh = this.pegsComponents.frontRightPegMesh;
			this.rearLeftPegmeshFilter.mesh = this.pegsComponents.rearLeftPegMesh;
			this.rearRightPegmeshFilter.mesh = this.pegsComponents.rearRightPegMesh;
		}
		if (this.pegsComponents.pegsMaterial != null)
		{
			this.frontLeftPegmeshRenderer.material = this.pegsComponents.pegsMaterial;
			this.frontRightPegmeshRenderer.material = this.pegsComponents.pegsMaterial;
			this.rearLeftPegmeshRenderer.material = this.pegsComponents.pegsMaterial;
			this.rearRightPegmeshRenderer.material = this.pegsComponents.pegsMaterial;
		}
		this.UpdateSaveSystem();
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x0001CC30 File Offset: 0x0001AE30
	private void LoadPegs()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1 && this.scooterBuilderBrain.customScooter1.PegsName == this.pegsName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2 && this.scooterBuilderBrain.customScooter2.PegsName == this.pegsName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3 && this.scooterBuilderBrain.customScooter3.PegsName == this.pegsName)
		{
			this.ApplyPart();
		}
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x0001CCD0 File Offset: 0x0001AED0
	public void OnSelect(BaseEventData eventData)
	{
		this.scooterBuilderBrain.CurrentlySelectedBrand = this.BrandName;
		this.partName.text = this.pegsName;
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x0001CCF4 File Offset: 0x0001AEF4
	public void UpdateSaveSystem()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.scooterBuilderBrain.customScooter1.PegsName = this.pegsName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.scooterBuilderBrain.customScooter2.PegsName = this.pegsName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.scooterBuilderBrain.customScooter3.PegsName = this.pegsName;
		}
		this.scooterBuilderBrain.loadTrigger.Pegs = false;
	}

	// Token: 0x040005B0 RID: 1456
	[SerializeField]
	private ScooterBrands Brand;

	// Token: 0x040005B1 RID: 1457
	public string pegsName;

	// Token: 0x040005B2 RID: 1458
	private string BrandName;

	// Token: 0x040005B3 RID: 1459
	public PegsReferences references;

	// Token: 0x040005B4 RID: 1460
	private GameObject _scooterBuilderBrain;

	// Token: 0x040005B5 RID: 1461
	public ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x040005B6 RID: 1462
	private MeshFilter frontLeftPegmeshFilter;

	// Token: 0x040005B7 RID: 1463
	private MeshRenderer frontLeftPegmeshRenderer;

	// Token: 0x040005B8 RID: 1464
	private MeshFilter frontRightPegmeshFilter;

	// Token: 0x040005B9 RID: 1465
	private MeshRenderer frontRightPegmeshRenderer;

	// Token: 0x040005BA RID: 1466
	private MeshFilter rearLeftPegmeshFilter;

	// Token: 0x040005BB RID: 1467
	private MeshRenderer rearLeftPegmeshRenderer;

	// Token: 0x040005BC RID: 1468
	private MeshFilter rearRightPegmeshFilter;

	// Token: 0x040005BD RID: 1469
	private MeshRenderer rearRightPegmeshRenderer;

	// Token: 0x040005BE RID: 1470
	private Button button;

	// Token: 0x040005BF RID: 1471
	public PegsComponents pegsComponents;

	// Token: 0x040005C0 RID: 1472
	private GameObject partName_;

	// Token: 0x040005C1 RID: 1473
	private TMP_Text partName;

	// Token: 0x040005C2 RID: 1474
	public PegsUIReference UI;
}
