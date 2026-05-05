using System;
using System.Collections.Generic;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000104 RID: 260
public class OutfitButtonLogic : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
{
	// Token: 0x06000452 RID: 1106 RVA: 0x0001E140 File Offset: 0x0001C340
	private void Awake()
	{
		this._brandName = this.Brand.ToString();
		GameObject gameObject = GameObject.Find("Part_Brand_And_Title");
		if (gameObject)
		{
			this.partName = gameObject.GetComponent<TMP_Text>();
		}
		GameObject gameObject2 = GameObject.Find("ScooterBuilderBrain");
		if (gameObject2)
		{
			this.scooterBuilderBrain = gameObject2.GetComponent<ScooterBuilderBrain>();
		}
	}

	// Token: 0x06000453 RID: 1107 RVA: 0x0001E1A2 File Offset: 0x0001C3A2
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
		this._brandName == "Unassigned";
		this.UpdateItemNameAndUI();
	}

	// Token: 0x06000454 RID: 1108 RVA: 0x0001E1D4 File Offset: 0x0001C3D4
	private void Update()
	{
		if (this.requireSelection)
		{
			if (!this._isSelected)
			{
				return;
			}
			if (EventSystem.current && EventSystem.current.currentSelectedGameObject != base.gameObject)
			{
				return;
			}
		}
		if (this.player == null)
		{
			return;
		}
		if (this.player.GetButtonDown("D-PadLeft"))
		{
			this.ChangeSelection(-1);
		}
		if (this.player.GetButtonDown("D-PadRight"))
		{
			this.ChangeSelection(1);
		}
	}

	// Token: 0x06000455 RID: 1109 RVA: 0x0001E251 File Offset: 0x0001C451
	public void OnSelect(BaseEventData eventData)
	{
		this._isSelected = true;
		if (this.scooterBuilderBrain)
		{
			this.scooterBuilderBrain.CurrentlySelectedBrand = this._brandName;
		}
		this.UpdateItemNameAndUI();
	}

	// Token: 0x06000456 RID: 1110 RVA: 0x0001E27E File Offset: 0x0001C47E
	public void OnDeselect(BaseEventData eventData)
	{
		this._isSelected = false;
	}

	// Token: 0x06000457 RID: 1111 RVA: 0x0001E288 File Offset: 0x0001C488
	private void ChangeSelection(int dir)
	{
		if (!this.controller || !this.controller.partsLibrary || !this.controller.customOutfitAsset)
		{
			Debug.LogWarning("[OutfitButtonLogic] Missing controller/partsLibrary/customOutfitAsset.");
			return;
		}
		CharacterPartsLibrary partsLibrary = this.controller.partsLibrary;
		CustomOutfitData outfit = this.controller.customOutfitAsset.outfit;
		if (outfit == null)
		{
			return;
		}
		switch (this.targetPart)
		{
		case OutfitPart.Top:
		{
			OutfitController outfitController = this.controller;
			List<TopData> tops = partsLibrary.tops;
			OutfitButtonLogic.Cycle(ref outfitController.topIndex, (tops != null) ? tops.Count : 0, dir);
			outfit.top = OutfitButtonLogic.GetName(partsLibrary.tops, this.controller.topIndex);
			break;
		}
		case OutfitPart.Hat:
		{
			OutfitController outfitController2 = this.controller;
			List<HatData> hats = partsLibrary.hats;
			OutfitButtonLogic.Cycle(ref outfitController2.hatIndex, (hats != null) ? hats.Count : 0, dir);
			outfit.hat = OutfitButtonLogic.GetName(partsLibrary.hats, this.controller.hatIndex);
			break;
		}
		case OutfitPart.Pants:
		{
			OutfitController outfitController3 = this.controller;
			List<PantsData> pants = partsLibrary.pants;
			OutfitButtonLogic.Cycle(ref outfitController3.pantsIndex, (pants != null) ? pants.Count : 0, dir);
			outfit.pants = OutfitButtonLogic.GetName(partsLibrary.pants, this.controller.pantsIndex);
			break;
		}
		case OutfitPart.Shoes:
		{
			OutfitController outfitController4 = this.controller;
			List<ShoesData> shoes = partsLibrary.shoes;
			OutfitButtonLogic.Cycle(ref outfitController4.shoesIndex, (shoes != null) ? shoes.Count : 0, dir);
			outfit.shoes = OutfitButtonLogic.GetName(partsLibrary.shoes, this.controller.shoesIndex);
			break;
		}
		}
		OutfitButtonLogic.ApplyCurrentToAnchors(this.controller);
		this.UpdateItemNameAndUI();
		this.controller.UpdateSaveSystem();
	}

	// Token: 0x06000458 RID: 1112 RVA: 0x0001E438 File Offset: 0x0001C638
	private void UpdateItemNameAndUI()
	{
		string currentSelectedName = this.GetCurrentSelectedName();
		this.itemName = currentSelectedName;
		if (this.partName)
		{
			this.partName.text = currentSelectedName;
		}
	}

	// Token: 0x06000459 RID: 1113 RVA: 0x0001E46C File Offset: 0x0001C66C
	private string GetCurrentSelectedName()
	{
		if (!this.controller || !this.controller.partsLibrary)
		{
			return string.Empty;
		}
		switch (this.targetPart)
		{
		case OutfitPart.Top:
			return OutfitButtonLogic.GetName(this.controller.partsLibrary.tops, this.controller.topIndex);
		case OutfitPart.Hat:
			return OutfitButtonLogic.GetName(this.controller.partsLibrary.hats, this.controller.hatIndex);
		case OutfitPart.Pants:
			return OutfitButtonLogic.GetName(this.controller.partsLibrary.pants, this.controller.pantsIndex);
		case OutfitPart.Shoes:
			return OutfitButtonLogic.GetName(this.controller.partsLibrary.shoes, this.controller.shoesIndex);
		default:
			return string.Empty;
		}
	}

	// Token: 0x0600045A RID: 1114 RVA: 0x000157F9 File Offset: 0x000139F9
	private static void Cycle(ref int idx, int count, int dir)
	{
		if (count <= 0)
		{
			idx = 0;
			return;
		}
		idx = (idx + dir) % count;
		if (idx < 0)
		{
			idx += count;
		}
	}

	// Token: 0x0600045B RID: 1115 RVA: 0x0001E549 File Offset: 0x0001C749
	private static string GetName(List<TopData> list, int idx)
	{
		if (list == null || list.Count <= 0)
		{
			return "";
		}
		TopData topData = list[Mathf.Clamp(idx, 0, list.Count - 1)];
		return ((topData != null) ? topData.name : null) ?? "";
	}

	// Token: 0x0600045C RID: 1116 RVA: 0x0001E587 File Offset: 0x0001C787
	private static string GetName(List<HatData> list, int idx)
	{
		if (list == null || list.Count <= 0)
		{
			return "";
		}
		HatData hatData = list[Mathf.Clamp(idx, 0, list.Count - 1)];
		return ((hatData != null) ? hatData.name : null) ?? "";
	}

	// Token: 0x0600045D RID: 1117 RVA: 0x0001E5C5 File Offset: 0x0001C7C5
	private static string GetName(List<PantsData> list, int idx)
	{
		if (list == null || list.Count <= 0)
		{
			return "";
		}
		PantsData pantsData = list[Mathf.Clamp(idx, 0, list.Count - 1)];
		return ((pantsData != null) ? pantsData.name : null) ?? "";
	}

	// Token: 0x0600045E RID: 1118 RVA: 0x0001E603 File Offset: 0x0001C803
	private static string GetName(List<ShoesData> list, int idx)
	{
		if (list == null || list.Count <= 0)
		{
			return "";
		}
		ShoesData shoesData = list[Mathf.Clamp(idx, 0, list.Count - 1)];
		return ((shoesData != null) ? shoesData.name : null) ?? "";
	}

	// Token: 0x0600045F RID: 1119 RVA: 0x0001E644 File Offset: 0x0001C844
	private static void ApplyCurrentToAnchors(OutfitController c)
	{
		OutfitButtonLogic.<>c__DisplayClass24_0 CS$<>8__locals1 = new OutfitButtonLogic.<>c__DisplayClass24_0();
		OutfitButtonLogic.<>c__DisplayClass24_0 CS$<>8__locals2 = CS$<>8__locals1;
		CustomOutfit customOutfitAsset = c.customOutfitAsset;
		CS$<>8__locals2.data = ((customOutfitAsset != null) ? customOutfitAsset.outfit : null);
		if (CS$<>8__locals1.data == null)
		{
			return;
		}
		TopData topData = string.IsNullOrEmpty(CS$<>8__locals1.data.top) ? null : c.partsLibrary.tops.Find((TopData t) => t.name == CS$<>8__locals1.data.top);
		HatData hatData = string.IsNullOrEmpty(CS$<>8__locals1.data.hat) ? null : c.partsLibrary.hats.Find((HatData h) => h.name == CS$<>8__locals1.data.hat);
		PantsData pantsData = string.IsNullOrEmpty(CS$<>8__locals1.data.pants) ? null : c.partsLibrary.pants.Find((PantsData p) => p.name == CS$<>8__locals1.data.pants);
		ShoesData shoesData = string.IsNullOrEmpty(CS$<>8__locals1.data.shoes) ? null : c.partsLibrary.shoes.Find((ShoesData s) => s.name == CS$<>8__locals1.data.shoes);
		if (c.topAnchor && topData != null)
		{
			OutfitButtonLogic.SetMesh(c.topAnchor, topData.mesh);
			Material material = CS$<>8__locals1.data.topMaterial1Override ? CS$<>8__locals1.data.topMaterial1Override : topData.material1;
			Material material2 = CS$<>8__locals1.data.topMaterial2Override ? CS$<>8__locals1.data.topMaterial2Override : topData.material2;
			OutfitButtonLogic.SetMaterials(c.topAnchor, new Material[]
			{
				material,
				material2
			});
		}
		if (c.hatAnchor && hatData != null)
		{
			OutfitButtonLogic.SetMesh(c.hatAnchor, hatData.mesh);
			OutfitButtonLogic.SetMaterials(c.hatAnchor, new Material[]
			{
				hatData.material
			});
		}
		if (c.pantsAnchor && pantsData != null)
		{
			OutfitButtonLogic.SetMesh(c.pantsAnchor, pantsData.mesh);
			OutfitButtonLogic.SetMaterials(c.pantsAnchor, new Material[]
			{
				pantsData.material
			});
		}
		if (c.shoesAnchor && shoesData != null)
		{
			OutfitButtonLogic.SetMesh(c.shoesAnchor, shoesData.mesh);
			OutfitButtonLogic.SetMaterials(c.shoesAnchor, new Material[]
			{
				shoesData.material
			});
		}
	}

	// Token: 0x06000460 RID: 1120 RVA: 0x0001E880 File Offset: 0x0001CA80
	private static void SetMesh(GameObject go, Mesh mesh)
	{
		if (!go || !mesh)
		{
			return;
		}
		SkinnedMeshRenderer component = go.GetComponent<SkinnedMeshRenderer>();
		if (component)
		{
			component.sharedMesh = mesh;
			return;
		}
		MeshFilter component2 = go.GetComponent<MeshFilter>();
		if (component2)
		{
			component2.sharedMesh = mesh;
		}
	}

	// Token: 0x06000461 RID: 1121 RVA: 0x0001E8CC File Offset: 0x0001CACC
	private static void SetMaterials(GameObject go, params Material[] provided)
	{
		if (!go || provided == null || provided.Length == 0)
		{
			return;
		}
		Renderer component = go.GetComponent<SkinnedMeshRenderer>();
		if (!component)
		{
			component = go.GetComponent<MeshRenderer>();
		}
		if (!component)
		{
			return;
		}
		Material[] sharedMaterials = component.sharedMaterials;
		int num = Mathf.Max((sharedMaterials != null) ? sharedMaterials.Length : 0, provided.Length);
		if (num == 0)
		{
			return;
		}
		Material[] array = new Material[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = ((sharedMaterials != null && i < sharedMaterials.Length) ? sharedMaterials[i] : null);
		}
		for (int j = 0; j < provided.Length; j++)
		{
			if (provided[j] != null)
			{
				array[j] = provided[j];
			}
		}
		component.sharedMaterials = array;
	}

	// Token: 0x0400064B RID: 1611
	[Header("Button Controls")]
	public OutfitPart targetPart;

	// Token: 0x0400064C RID: 1612
	[Header("Meta")]
	[SerializeField]
	private ScooterBrands Brand;

	// Token: 0x0400064D RID: 1613
	[SerializeField]
	private string _brandName;

	// Token: 0x0400064E RID: 1614
	[SerializeField]
	public string itemName = "";

	// Token: 0x0400064F RID: 1615
	[Header("Scene / Controller")]
	public OutfitController controller;

	// Token: 0x04000650 RID: 1616
	[Header("Input")]
	public int playerId;

	// Token: 0x04000651 RID: 1617
	public bool requireSelection = true;

	// Token: 0x04000652 RID: 1618
	private TMP_Text partName;

	// Token: 0x04000653 RID: 1619
	private ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x04000654 RID: 1620
	private Player player;

	// Token: 0x04000655 RID: 1621
	private bool _isSelected;
}
