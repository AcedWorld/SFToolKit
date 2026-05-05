using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000D8 RID: 216
public class DeckButtonLogic : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	// Token: 0x060003B2 RID: 946 RVA: 0x0001B734 File Offset: 0x00019934
	private void Start()
	{
		this.partName_ = GameObject.Find("Part_Brand_And_Title");
		this.Deck = GameObject.Find("Deck_Mesh");
		this.GripTape = GameObject.Find("GripTape_Mesh");
		this.addOnParent = GameObject.Find("DeckAddOn_Parent");
		this._scooterBuilderBrain = GameObject.Find("ScooterBuilderBrain");
		this.Brake = GameObject.Find("Brake_Mesh");
		this.rearPegs = this.Deck.transform.GetChild(0);
		this.partName = this.partName_.GetComponent<TMP_Text>();
		this.BrandName = this.Brand.ToString();
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.ApplyPart));
		this.gripTapeMeshFilter = this.GripTape.GetComponent<MeshFilter>();
		this.meshRenderer = this.Deck.GetComponent<MeshRenderer>();
		this.meshFilter = this.Deck.GetComponent<MeshFilter>();
		this.BrakeRenderer = this.Brake.GetComponent<MeshRenderer>();
		this.brakeMeshFilter = this.Brake.GetComponent<MeshFilter>();
		this.scooterBuilderBrain = this._scooterBuilderBrain.GetComponent<ScooterBuilderBrain>();
		this.BrandName == "Unassigned";
		this.LoadDeck();
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x0001B885 File Offset: 0x00019A85
	private void Update()
	{
		if (this.scooterBuilderBrain.loadTrigger.Deck)
		{
			this.LoadDeck();
		}
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x0001B89F File Offset: 0x00019A9F
	public void RunApply()
	{
		this.ApplyPart();
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x0001B8A8 File Offset: 0x00019AA8
	private void ApplyPart()
	{
		if (this.addOnParent.transform.childCount > 0)
		{
			foreach (object obj in this.addOnParent.transform)
			{
				Object.Destroy(((Transform)obj).gameObject);
			}
		}
		if (this.deckComponents.deckMesh != null)
		{
			this.meshFilter.mesh = this.deckComponents.deckMesh;
			this.gripTapeMeshFilter.mesh = this.deckComponents.gripTapeMesh;
		}
		if (this.deckComponents.deckMaterial != null)
		{
			this.meshRenderer.material = this.deckComponents.deckMaterial;
		}
		if (this.deckComponents.hasAddOns)
		{
			Object.Instantiate<GameObject>(this.deckComponents.deckAddOns[0], this.addOnParent.transform);
		}
		if (this.deckComponents.brakeMesh != null)
		{
			this.brakeMeshFilter.mesh = this.deckComponents.brakeMesh;
			this.BrakeRenderer.material = this.deckComponents.deckMaterial;
		}
		if (this.deckComponents.brakeMesh == null)
		{
			this.brakeMeshFilter.mesh = null;
		}
		if (this.deckComponents.hasInbuiltPegs)
		{
			this.rearPegs.gameObject.SetActive(false);
		}
		if (!this.deckComponents.hasInbuiltPegs)
		{
			this.rearPegs.gameObject.SetActive(true);
		}
		this.UpdateSaveSystem();
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x0001BA50 File Offset: 0x00019C50
	private void LoadDeck()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1 && this.scooterBuilderBrain.customScooter1.DeckName == this.deckName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2 && this.scooterBuilderBrain.customScooter2.DeckName == this.deckName)
		{
			this.ApplyPart();
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3 && this.scooterBuilderBrain.customScooter3.DeckName == this.deckName)
		{
			this.ApplyPart();
		}
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x0001BAF0 File Offset: 0x00019CF0
	public void OnSelect(BaseEventData eventData)
	{
		this.scooterBuilderBrain.CurrentlySelectedBrand = this.BrandName;
		this.partName.text = this.deckName;
	}

	// Token: 0x060003B8 RID: 952 RVA: 0x0001BB14 File Offset: 0x00019D14
	public void UpdateSaveSystem()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.scooterBuilderBrain.customScooter1.DeckName = this.deckName;
			this.scooterBuilderBrain.customScooter1.hasDeckPegs = this.deckComponents.hasInbuiltPegs;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.scooterBuilderBrain.customScooter2.DeckName = this.deckName;
			this.scooterBuilderBrain.customScooter2.hasDeckPegs = this.deckComponents.hasInbuiltPegs;
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.scooterBuilderBrain.customScooter3.DeckName = this.deckName;
			this.scooterBuilderBrain.customScooter3.hasDeckPegs = this.deckComponents.hasInbuiltPegs;
		}
		this.scooterBuilderBrain.SetDeckPegs(this.deckComponents.hasInbuiltPegs);
		this.scooterBuilderBrain.loadTrigger.Deck = false;
	}

	// Token: 0x04000538 RID: 1336
	[SerializeField]
	private ScooterBrands Brand;

	// Token: 0x04000539 RID: 1337
	public string deckName;

	// Token: 0x0400053A RID: 1338
	private string BrandName;

	// Token: 0x0400053B RID: 1339
	private GameObject _scooterBuilderBrain;

	// Token: 0x0400053C RID: 1340
	private ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x0400053D RID: 1341
	private GameObject Deck;

	// Token: 0x0400053E RID: 1342
	private MeshFilter meshFilter;

	// Token: 0x0400053F RID: 1343
	private MeshRenderer meshRenderer;

	// Token: 0x04000540 RID: 1344
	private GameObject GripTape;

	// Token: 0x04000541 RID: 1345
	private MeshFilter gripTapeMeshFilter;

	// Token: 0x04000542 RID: 1346
	private GameObject Brake;

	// Token: 0x04000543 RID: 1347
	private MeshFilter brakeMeshFilter;

	// Token: 0x04000544 RID: 1348
	private MeshRenderer BrakeRenderer;

	// Token: 0x04000545 RID: 1349
	private Button button;

	// Token: 0x04000546 RID: 1350
	private GameObject addOnParent;

	// Token: 0x04000547 RID: 1351
	public DeckComponents deckComponents;

	// Token: 0x04000548 RID: 1352
	private GameObject partName_;

	// Token: 0x04000549 RID: 1353
	private TMP_Text partName;

	// Token: 0x0400054A RID: 1354
	private Transform rearPegs;

	// Token: 0x0400054B RID: 1355
	public DeckUIReference UI;
}
