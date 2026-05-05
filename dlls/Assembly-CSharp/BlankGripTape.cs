using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020000D1 RID: 209
public class BlankGripTape : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	// Token: 0x060003A0 RID: 928 RVA: 0x0001B34C File Offset: 0x0001954C
	private void Start()
	{
		this.partName_ = GameObject.Find("Part_Brand_And_Title");
		this._scooterBuilderBrain = GameObject.Find("ScooterBuilderBrain");
		this.partName = this.partName_.GetComponent<TMP_Text>();
		this.BrandName = this.Brand.ToString();
		this.scooterBuilderBrain = this._scooterBuilderBrain.GetComponent<ScooterBuilderBrain>();
	}

	// Token: 0x060003A1 RID: 929 RVA: 0x0001B3B2 File Offset: 0x000195B2
	public void OnSelect(BaseEventData eventData)
	{
		this.scooterBuilderBrain.CurrentlySelectedBrand = this.BrandName;
		this.partName.text = this.gripTapeName;
	}

	// Token: 0x0400050F RID: 1295
	[SerializeField]
	private ScooterBrands Brand;

	// Token: 0x04000510 RID: 1296
	public string gripTapeName;

	// Token: 0x04000511 RID: 1297
	private string BrandName;

	// Token: 0x04000512 RID: 1298
	private GameObject _scooterBuilderBrain;

	// Token: 0x04000513 RID: 1299
	private ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x04000514 RID: 1300
	private GameObject partName_;

	// Token: 0x04000515 RID: 1301
	private TMP_Text partName;
}
