using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

// Token: 0x020000A1 RID: 161
public class OutfitController : MonoBehaviour
{
	// Token: 0x060002A2 RID: 674 RVA: 0x0001541B File Offset: 0x0001361B
	private void Start()
	{
		if (!this.partsLibrary || !this.customOutfitAsset)
		{
			Debug.LogWarning("[OutfitKeyboardPreviewController] Assign partsLibrary and customOutfitAsset.");
			return;
		}
		if (this.loadFromAssetOnStart)
		{
			this.LoadFromAsset();
		}
		this.ClampAll();
	}

	// Token: 0x060002A3 RID: 675 RVA: 0x00015456 File Offset: 0x00013656
	private void Update()
	{
		if (false)
		{
			this.ClampAll();
			this.PushSelectionIntoAsset();
			this.ApplyCurrentToAnchors();
		}
	}

	// Token: 0x060002A4 RID: 676 RVA: 0x00015470 File Offset: 0x00013670
	public void ApplyCurrentToAnchors()
	{
		CustomOutfitData data = this.customOutfitAsset.outfit;
		if (data == null)
		{
			return;
		}
		TopData topData = string.IsNullOrEmpty(data.top) ? null : this.partsLibrary.tops.Find((TopData t) => t.name == data.top);
		HatData hatData = string.IsNullOrEmpty(data.hat) ? null : this.partsLibrary.hats.Find((HatData h) => h.name == data.hat);
		PantsData pantsData = string.IsNullOrEmpty(data.pants) ? null : this.partsLibrary.pants.Find((PantsData p) => p.name == data.pants);
		ShoesData shoesData = string.IsNullOrEmpty(data.shoes) ? null : this.partsLibrary.shoes.Find((ShoesData s) => s.name == data.shoes);
		if (this.topAnchor && topData != null)
		{
			OutfitController.SetMesh(this.topAnchor, topData.mesh);
			Material material = data.topMaterial1Override ? data.topMaterial1Override : topData.material1;
			Material material2 = data.topMaterial2Override ? data.topMaterial2Override : topData.material2;
			OutfitController.SetMaterials(this.topAnchor, new Material[]
			{
				material,
				material2
			});
		}
		if (this.hatAnchor && hatData != null)
		{
			OutfitController.SetMesh(this.hatAnchor, hatData.mesh);
			OutfitController.SetMaterials(this.hatAnchor, new Material[]
			{
				hatData.material
			});
		}
		if (this.pantsAnchor && pantsData != null)
		{
			OutfitController.SetMesh(this.pantsAnchor, pantsData.mesh);
			OutfitController.SetMaterials(this.pantsAnchor, new Material[]
			{
				pantsData.material
			});
		}
		if (this.shoesAnchor && shoesData != null)
		{
			OutfitController.SetMesh(this.shoesAnchor, shoesData.mesh);
			OutfitController.SetMaterials(this.shoesAnchor, new Material[]
			{
				shoesData.material
			});
		}
	}

	// Token: 0x060002A5 RID: 677 RVA: 0x000156A4 File Offset: 0x000138A4
	private void LoadFromAsset()
	{
		CustomOutfitData outfit = this.customOutfitAsset.outfit;
		if (outfit == null)
		{
			return;
		}
		CharacterPartsLibrary characterPartsLibrary = this.partsLibrary;
		this.topIndex = OutfitController.IndexOfName<TopData>((characterPartsLibrary != null) ? characterPartsLibrary.tops : null, outfit.top);
		CharacterPartsLibrary characterPartsLibrary2 = this.partsLibrary;
		this.hatIndex = OutfitController.IndexOfName<HatData>((characterPartsLibrary2 != null) ? characterPartsLibrary2.hats : null, outfit.hat);
		CharacterPartsLibrary characterPartsLibrary3 = this.partsLibrary;
		this.pantsIndex = OutfitController.IndexOfName<PantsData>((characterPartsLibrary3 != null) ? characterPartsLibrary3.pants : null, outfit.pants);
		CharacterPartsLibrary characterPartsLibrary4 = this.partsLibrary;
		this.shoesIndex = OutfitController.IndexOfName<ShoesData>((characterPartsLibrary4 != null) ? characterPartsLibrary4.shoes : null, outfit.shoes);
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x00015750 File Offset: 0x00013950
	private void PushSelectionIntoAsset()
	{
		CustomOutfitData outfit = this.customOutfitAsset.outfit;
		if (outfit == null)
		{
			return;
		}
		CustomOutfitData customOutfitData = outfit;
		CharacterPartsLibrary characterPartsLibrary = this.partsLibrary;
		customOutfitData.top = OutfitController.SafeName<TopData>((characterPartsLibrary != null) ? characterPartsLibrary.tops : null, this.topIndex);
		CustomOutfitData customOutfitData2 = outfit;
		CharacterPartsLibrary characterPartsLibrary2 = this.partsLibrary;
		customOutfitData2.hat = OutfitController.SafeName<HatData>((characterPartsLibrary2 != null) ? characterPartsLibrary2.hats : null, this.hatIndex);
		CustomOutfitData customOutfitData3 = outfit;
		CharacterPartsLibrary characterPartsLibrary3 = this.partsLibrary;
		customOutfitData3.pants = OutfitController.SafeName<PantsData>((characterPartsLibrary3 != null) ? characterPartsLibrary3.pants : null, this.pantsIndex);
		CustomOutfitData customOutfitData4 = outfit;
		CharacterPartsLibrary characterPartsLibrary4 = this.partsLibrary;
		customOutfitData4.shoes = OutfitController.SafeName<ShoesData>((characterPartsLibrary4 != null) ? characterPartsLibrary4.shoes : null, this.shoesIndex);
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x000157F9 File Offset: 0x000139F9
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

	// Token: 0x060002A8 RID: 680 RVA: 0x00015818 File Offset: 0x00013A18
	private void ClampAll()
	{
		int idx = this.topIndex;
		CharacterPartsLibrary characterPartsLibrary = this.partsLibrary;
		int? num;
		if (characterPartsLibrary == null)
		{
			num = null;
		}
		else
		{
			List<TopData> tops = characterPartsLibrary.tops;
			num = ((tops != null) ? new int?(tops.Count) : null);
		}
		int? num2 = num;
		this.topIndex = OutfitController.ClampIndex(idx, num2.GetValueOrDefault());
		int idx2 = this.hatIndex;
		CharacterPartsLibrary characterPartsLibrary2 = this.partsLibrary;
		int? num3;
		if (characterPartsLibrary2 == null)
		{
			num3 = null;
		}
		else
		{
			List<HatData> hats = characterPartsLibrary2.hats;
			num3 = ((hats != null) ? new int?(hats.Count) : null);
		}
		num2 = num3;
		this.hatIndex = OutfitController.ClampIndex(idx2, num2.GetValueOrDefault());
		int idx3 = this.pantsIndex;
		CharacterPartsLibrary characterPartsLibrary3 = this.partsLibrary;
		int? num4;
		if (characterPartsLibrary3 == null)
		{
			num4 = null;
		}
		else
		{
			List<PantsData> pants = characterPartsLibrary3.pants;
			num4 = ((pants != null) ? new int?(pants.Count) : null);
		}
		num2 = num4;
		this.pantsIndex = OutfitController.ClampIndex(idx3, num2.GetValueOrDefault());
		int idx4 = this.shoesIndex;
		CharacterPartsLibrary characterPartsLibrary4 = this.partsLibrary;
		int? num5;
		if (characterPartsLibrary4 == null)
		{
			num5 = null;
		}
		else
		{
			List<ShoesData> shoes = characterPartsLibrary4.shoes;
			num5 = ((shoes != null) ? new int?(shoes.Count) : null);
		}
		num2 = num5;
		this.shoesIndex = OutfitController.ClampIndex(idx4, num2.GetValueOrDefault());
	}

	// Token: 0x060002A9 RID: 681 RVA: 0x00015955 File Offset: 0x00013B55
	public void UpdateSaveSystem()
	{
		this.customScooterSaveSystem.UpdateClothing();
	}

	// Token: 0x060002AA RID: 682 RVA: 0x00015962 File Offset: 0x00013B62
	private static int ClampIndex(int idx, int count)
	{
		return Mathf.Clamp(idx, 0, Mathf.Max(0, count - 1));
	}

	// Token: 0x060002AB RID: 683 RVA: 0x00015974 File Offset: 0x00013B74
	private static int IndexOfName<T>(List<T> list, string name) where T : class
	{
		if (list == null || list.Count == 0 || string.IsNullOrEmpty(name))
		{
			return 0;
		}
		FieldInfo field = typeof(T).GetField("name");
		if (field == null)
		{
			return 0;
		}
		for (int i = 0; i < list.Count; i++)
		{
			if ((string)field.GetValue(list[i]) == name)
			{
				return i;
			}
		}
		return 0;
	}

	// Token: 0x060002AC RID: 684 RVA: 0x000159EC File Offset: 0x00013BEC
	private static string SafeName<T>(List<T> list, int idx) where T : class
	{
		if (list == null || list.Count == 0)
		{
			return string.Empty;
		}
		idx = Mathf.Clamp(idx, 0, list.Count - 1);
		FieldInfo field = typeof(T).GetField("name");
		if (!(field != null))
		{
			return string.Empty;
		}
		return (string)field.GetValue(list[idx]);
	}

	// Token: 0x060002AD RID: 685 RVA: 0x00015A58 File Offset: 0x00013C58
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

	// Token: 0x060002AE RID: 686 RVA: 0x00015AA4 File Offset: 0x00013CA4
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

	// Token: 0x04000342 RID: 834
	[Header("Assets")]
	public CharacterPartsLibrary partsLibrary;

	// Token: 0x04000343 RID: 835
	public CustomOutfit customOutfitAsset;

	// Token: 0x04000344 RID: 836
	[Header("Anchors (target renderers)")]
	public GameObject topAnchor;

	// Token: 0x04000345 RID: 837
	public GameObject hatAnchor;

	// Token: 0x04000346 RID: 838
	public GameObject pantsAnchor;

	// Token: 0x04000347 RID: 839
	public GameObject shoesAnchor;

	// Token: 0x04000348 RID: 840
	[Header("Indices (runtime)")]
	public int topIndex;

	// Token: 0x04000349 RID: 841
	public int hatIndex;

	// Token: 0x0400034A RID: 842
	public int pantsIndex;

	// Token: 0x0400034B RID: 843
	public int shoesIndex;

	// Token: 0x0400034C RID: 844
	[Header("Options")]
	public bool loadFromAssetOnStart = true;

	// Token: 0x0400034D RID: 845
	public CustomScooterSaveSystem customScooterSaveSystem;
}
