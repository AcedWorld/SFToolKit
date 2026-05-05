using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000CD RID: 205
public class BarEndsButtonLogic : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	// Token: 0x06000390 RID: 912 RVA: 0x0001ADBC File Offset: 0x00018FBC
	private void Start()
	{
		this.partName_ = GameObject.Find("Part_Brand_And_Title");
		this.LeftEnd = GameObject.Find("LeftBarEnd_Mesh");
		this.RightEnd = GameObject.Find("RightBarEnd_Mesh");
		this._scooterBuilderBrain = GameObject.Find("ScooterBuilderBrain");
		this.partName = this.partName_.GetComponent<TMP_Text>();
		this.BrandName = this.Brand.ToString();
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.ApplyPart));
		this.leftEndRenderer = this.LeftEnd.GetComponent<MeshRenderer>();
		this.rightEndRenderer = this.RightEnd.GetComponent<MeshRenderer>();
		this.leftEndFilter = this.LeftEnd.GetComponent<MeshFilter>();
		this.rightEndFilter = this.RightEnd.GetComponent<MeshFilter>();
		this.scooterBuilderBrain = this._scooterBuilderBrain.GetComponent<ScooterBuilderBrain>();
		this.LoadBarEnd();
	}

	// Token: 0x06000391 RID: 913 RVA: 0x0001AEB4 File Offset: 0x000190B4
	private void Update()
	{
		if (this.scooterBuilderBrain.loadTrigger.BarEnds)
		{
			this.LoadBarEnd();
		}
	}

	// Token: 0x06000392 RID: 914 RVA: 0x0001AED0 File Offset: 0x000190D0
	private void ApplyPart()
	{
		if (this.barEndComponents.LeftEndMesh != null)
		{
			this.leftEndFilter.mesh = this.barEndComponents.LeftEndMesh;
			this.rightEndFilter.mesh = this.barEndComponents.RightEndMesh;
		}
		if (this.barEndComponents.barEndMaterial != null)
		{
			this.leftEndRenderer.material = this.barEndComponents.barEndMaterial;
			this.rightEndRenderer.material = this.barEndComponents.barEndMaterial;
		}
		this.UpdateSaveSystem();
	}

	// Token: 0x06000393 RID: 915 RVA: 0x0001AF64 File Offset: 0x00019164
	private void LoadBarEnd()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1 && this.scooterBuilderBrain.customScooter1.BarEndsName == this.barEndsName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2 && this.scooterBuilderBrain.customScooter2.BarEndsName == this.barEndsName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3 && this.scooterBuilderBrain.customScooter3.BarEndsName == this.barEndsName)
		{
			this.ApplyPart();
		}
	}

	// Token: 0x06000394 RID: 916 RVA: 0x0001B004 File Offset: 0x00019204
	public void OnSelect(BaseEventData eventData)
	{
		this.scooterBuilderBrain.CurrentlySelectedBrand = this.BrandName;
		this.partName.text = this.barEndsName;
	}

	// Token: 0x06000395 RID: 917 RVA: 0x0001B028 File Offset: 0x00019228
	public void UpdateSaveSystem()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.scooterBuilderBrain.customScooter1.BarEndsName = this.barEndsName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.scooterBuilderBrain.customScooter2.BarEndsName = this.barEndsName;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.scooterBuilderBrain.customScooter3.BarEndsName = this.barEndsName;
		}
		this.scooterBuilderBrain.loadTrigger.BarEnds = false;
	}

	// Token: 0x040004EE RID: 1262
	[SerializeField]
	private ScooterBrands Brand;

	// Token: 0x040004EF RID: 1263
	public string barEndsName;

	// Token: 0x040004F0 RID: 1264
	private string BrandName;

	// Token: 0x040004F1 RID: 1265
	private GameObject _scooterBuilderBrain;

	// Token: 0x040004F2 RID: 1266
	private ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x040004F3 RID: 1267
	private GameObject LeftEnd;

	// Token: 0x040004F4 RID: 1268
	private GameObject RightEnd;

	// Token: 0x040004F5 RID: 1269
	private MeshFilter leftEndFilter;

	// Token: 0x040004F6 RID: 1270
	private MeshFilter rightEndFilter;

	// Token: 0x040004F7 RID: 1271
	private MeshRenderer leftEndRenderer;

	// Token: 0x040004F8 RID: 1272
	private MeshRenderer rightEndRenderer;

	// Token: 0x040004F9 RID: 1273
	private Button button;

	// Token: 0x040004FA RID: 1274
	public BarEndsComponents barEndComponents;

	// Token: 0x040004FB RID: 1275
	private GameObject partName_;

	// Token: 0x040004FC RID: 1276
	private TMP_Text partName;

	// Token: 0x040004FD RID: 1277
	public BarEndsUIReference UI;
}
