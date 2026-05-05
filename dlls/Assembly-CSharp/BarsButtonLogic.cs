using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000D0 RID: 208
public class BarsButtonLogic : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	// Token: 0x06000399 RID: 921 RVA: 0x0001B0B4 File Offset: 0x000192B4
	private void Start()
	{
		this.partName_ = GameObject.Find("Part_Brand_And_Title");
		this.Bars = GameObject.Find("Bars_Mesh");
		this._scooterBuilderBrain = GameObject.Find("ScooterBuilderBrain");
		this.partName = this.partName_.GetComponent<TMP_Text>();
		this.BrandName = this.Brand.ToString();
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.ApplyPart));
		this.meshRenderer = this.Bars.GetComponent<MeshRenderer>();
		this.meshFilter = this.Bars.GetComponent<MeshFilter>();
		this.scooterBuilderBrain = this._scooterBuilderBrain.GetComponent<ScooterBuilderBrain>();
		this.LoadBars();
	}

	// Token: 0x0600039A RID: 922 RVA: 0x0001B17A File Offset: 0x0001937A
	private void Update()
	{
		if (this.scooterBuilderBrain.loadTrigger.Bars)
		{
			this.LoadBars();
		}
	}

	// Token: 0x0600039B RID: 923 RVA: 0x0001B194 File Offset: 0x00019394
	private void ApplyPart()
	{
		if (this.barsComponents.barsMesh != null)
		{
			this.meshFilter.mesh = this.barsComponents.barsMesh;
		}
		if (this.barsComponents.barsMaterial != null)
		{
			this.meshRenderer.material = this.barsComponents.barsMaterial;
		}
		this.UpdateSaveSystem();
	}

	// Token: 0x0600039C RID: 924 RVA: 0x0001B1FC File Offset: 0x000193FC
	private void LoadBars()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1 && this.scooterBuilderBrain.customScooter1.BarsName == this.barsName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2 && this.scooterBuilderBrain.customScooter2.BarsName == this.barsName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3 && this.scooterBuilderBrain.customScooter3.BarsName == this.barsName)
		{
			this.ApplyPart();
		}
	}

	// Token: 0x0600039D RID: 925 RVA: 0x0001B29C File Offset: 0x0001949C
	public void OnSelect(BaseEventData eventData)
	{
		this.scooterBuilderBrain.CurrentlySelectedBrand = this.BrandName;
		this.partName.text = this.barsName;
	}

	// Token: 0x0600039E RID: 926 RVA: 0x0001B2C0 File Offset: 0x000194C0
	public void UpdateSaveSystem()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.scooterBuilderBrain.customScooter1.BarsName = this.barsName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.scooterBuilderBrain.customScooter2.BarsName = this.barsName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.scooterBuilderBrain.customScooter3.BarsName = this.barsName;
		}
		this.scooterBuilderBrain.loadTrigger.Bars = false;
	}

	// Token: 0x04000502 RID: 1282
	[SerializeField]
	private ScooterBrands Brand;

	// Token: 0x04000503 RID: 1283
	public string barsName;

	// Token: 0x04000504 RID: 1284
	private string BrandName;

	// Token: 0x04000505 RID: 1285
	private GameObject _scooterBuilderBrain;

	// Token: 0x04000506 RID: 1286
	private ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x04000507 RID: 1287
	private GameObject Bars;

	// Token: 0x04000508 RID: 1288
	private MeshFilter meshFilter;

	// Token: 0x04000509 RID: 1289
	private MeshRenderer meshRenderer;

	// Token: 0x0400050A RID: 1290
	private Button button;

	// Token: 0x0400050B RID: 1291
	public BarsComponents barsComponents;

	// Token: 0x0400050C RID: 1292
	private GameObject partName_;

	// Token: 0x0400050D RID: 1293
	private TMP_Text partName;

	// Token: 0x0400050E RID: 1294
	public BarsUIReference UI;
}
