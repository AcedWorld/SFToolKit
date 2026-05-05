using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000DB RID: 219
public class ForksButtonLogic : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	// Token: 0x060003BC RID: 956 RVA: 0x0001BC08 File Offset: 0x00019E08
	private void Start()
	{
		this.partName_ = GameObject.Find("Part_Brand_And_Title");
		this.Forks = GameObject.Find("Forks_Mesh");
		this._scooterBuilderBrain = GameObject.Find("ScooterBuilderBrain");
		this.partName = this.partName_.GetComponent<TMP_Text>();
		this.BrandName = this.Brand.ToString();
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.ApplyPart));
		this.meshRenderer = this.Forks.GetComponent<MeshRenderer>();
		this.meshFilter = this.Forks.GetComponent<MeshFilter>();
		this.scooterBuilderBrain = this._scooterBuilderBrain.GetComponent<ScooterBuilderBrain>();
		this.LoadForks();
	}

	// Token: 0x060003BD RID: 957 RVA: 0x0001BCCE File Offset: 0x00019ECE
	private void Update()
	{
		if (this.scooterBuilderBrain.loadTrigger.Forks)
		{
			this.LoadForks();
		}
	}

	// Token: 0x060003BE RID: 958 RVA: 0x0001BCE8 File Offset: 0x00019EE8
	private void ApplyPart()
	{
		if (this.forksComponents.forksMesh != null)
		{
			this.meshFilter.mesh = this.forksComponents.forksMesh;
		}
		if (this.forksComponents.forksMaterial != null)
		{
			this.meshRenderer.material = this.forksComponents.forksMaterial;
		}
		this.UpdateSaveSystem();
	}

	// Token: 0x060003BF RID: 959 RVA: 0x0001BD50 File Offset: 0x00019F50
	private void LoadForks()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1 && this.scooterBuilderBrain.customScooter1.ForksName == this.forksName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2 && this.scooterBuilderBrain.customScooter2.ForksName == this.forksName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3 && this.scooterBuilderBrain.customScooter3.ForksName == this.forksName)
		{
			this.ApplyPart();
		}
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x0001BDF0 File Offset: 0x00019FF0
	public void OnSelect(BaseEventData eventData)
	{
		this.scooterBuilderBrain.CurrentlySelectedBrand = this.BrandName;
		this.partName.text = this.forksName;
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x0001BE14 File Offset: 0x0001A014
	public void UpdateSaveSystem()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.scooterBuilderBrain.customScooter1.ForksName = this.forksName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.scooterBuilderBrain.customScooter2.ForksName = this.forksName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.scooterBuilderBrain.customScooter3.ForksName = this.forksName;
		}
		this.scooterBuilderBrain.loadTrigger.Forks = false;
	}

	// Token: 0x04000550 RID: 1360
	[SerializeField]
	private ScooterBrands Brand;

	// Token: 0x04000551 RID: 1361
	public string forksName;

	// Token: 0x04000552 RID: 1362
	private string BrandName;

	// Token: 0x04000553 RID: 1363
	private GameObject _scooterBuilderBrain;

	// Token: 0x04000554 RID: 1364
	private ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x04000555 RID: 1365
	private GameObject Forks;

	// Token: 0x04000556 RID: 1366
	private MeshFilter meshFilter;

	// Token: 0x04000557 RID: 1367
	private MeshRenderer meshRenderer;

	// Token: 0x04000558 RID: 1368
	private Button button;

	// Token: 0x04000559 RID: 1369
	public ForksComponents forksComponents;

	// Token: 0x0400055A RID: 1370
	private GameObject partName_;

	// Token: 0x0400055B RID: 1371
	private TMP_Text partName;

	// Token: 0x0400055C RID: 1372
	public ForksUIReference UI;
}
