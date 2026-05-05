using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000D5 RID: 213
public class CompletesButton : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	// Token: 0x060003AC RID: 940 RVA: 0x0001B670 File Offset: 0x00019870
	private void Start()
	{
		this.partName_ = GameObject.Find("Part_Brand_And_Title");
		this.partName = this.partName_.GetComponent<TMP_Text>();
		this.BrandName = this.Brand.ToString();
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.LoadComplete));
		this._scooterBuilderBrain = GameObject.Find("ScooterBuilderBrain");
		this.scooterBuilderBrain = this._scooterBuilderBrain.GetComponent<ScooterBuilderBrain>();
	}

	// Token: 0x060003AD RID: 941 RVA: 0x0001B6FE File Offset: 0x000198FE
	private void LoadComplete()
	{
		this.completeScooter.ApplyCompleteScooter();
	}

	// Token: 0x060003AE RID: 942 RVA: 0x0001B70B File Offset: 0x0001990B
	public void OnSelect(BaseEventData eventData)
	{
		this.scooterBuilderBrain.CurrentlySelectedBrand = this.BrandName;
		this.partName.text = this.completeScooter.CompleteName;
	}

	// Token: 0x04000527 RID: 1319
	[SerializeField]
	private ScooterBrands Brand;

	// Token: 0x04000528 RID: 1320
	private string BrandName;

	// Token: 0x04000529 RID: 1321
	public CompleteScooter completeScooter;

	// Token: 0x0400052A RID: 1322
	private GameObject _scooterBuilderBrain;

	// Token: 0x0400052B RID: 1323
	public ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x0400052C RID: 1324
	private Button button;

	// Token: 0x0400052D RID: 1325
	private GameObject partName_;

	// Token: 0x0400052E RID: 1326
	private TMP_Text partName;
}
