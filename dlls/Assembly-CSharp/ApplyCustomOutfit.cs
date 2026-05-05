using System;
using UnityEngine;

// Token: 0x02000092 RID: 146
public class ApplyCustomOutfit : MonoBehaviour
{
	// Token: 0x06000267 RID: 615 RVA: 0x000141BA File Offset: 0x000123BA
	private void Start()
	{
		if (this.applyOnStart)
		{
			this.ApplyOutfit();
		}
	}

	// Token: 0x06000268 RID: 616 RVA: 0x000141CC File Offset: 0x000123CC
	[ContextMenu("Apply Outfit Now")]
	public void ApplyOutfit()
	{
		if (this.partsLibrary == null || this.customOutfitAsset == null)
		{
			Debug.LogWarning("[ApplyCustomOutfit] Missing assets (partsLibrary/customOutfitAsset).");
			return;
		}
		CustomOutfitData data = this.customOutfitAsset.outfit;
		if (data == null)
		{
			Debug.LogWarning("[ApplyCustomOutfit] Outfit data is null.");
			return;
		}
		TopData topData = string.IsNullOrEmpty(data.top) ? null : this.partsLibrary.tops.Find((TopData t) => t.name == data.top);
		HatData hatData = string.IsNullOrEmpty(data.hat) ? null : this.partsLibrary.hats.Find((HatData h) => h.name == data.hat);
		PantsData pantsData = string.IsNullOrEmpty(data.pants) ? null : this.partsLibrary.pants.Find((PantsData p) => p.name == data.pants);
		ShoesData shoesData = string.IsNullOrEmpty(data.shoes) ? null : this.partsLibrary.shoes.Find((ShoesData s) => s.name == data.shoes);
		if (this.anchors.top && topData != null)
		{
			ApplyCustomOutfit.SetMesh(this.anchors.top, topData.mesh);
			Material material = data.topMaterial1Override ? data.topMaterial1Override : topData.material1;
			Material material2 = data.topMaterial2Override ? data.topMaterial2Override : topData.material2;
			ApplyCustomOutfit.SetMaterials(this.anchors.top, new Material[]
			{
				material,
				material2
			});
		}
		if (this.anchors.hat && hatData != null)
		{
			ApplyCustomOutfit.SetMesh(this.anchors.hat, hatData.mesh);
			ApplyCustomOutfit.SetMaterials(this.anchors.hat, new Material[]
			{
				hatData.material
			});
		}
		if (this.anchors.pants && pantsData != null)
		{
			ApplyCustomOutfit.SetMesh(this.anchors.pants, pantsData.mesh);
			ApplyCustomOutfit.SetMaterials(this.anchors.pants, new Material[]
			{
				pantsData.material
			});
		}
		if (this.anchors.shoes && shoesData != null)
		{
			ApplyCustomOutfit.SetMesh(this.anchors.shoes, shoesData.mesh);
			ApplyCustomOutfit.SetMaterials(this.anchors.shoes, new Material[]
			{
				shoesData.material
			});
		}
		Debug.Log("[ApplyCustomOutfit] Outfit applied.");
	}

	// Token: 0x06000269 RID: 617 RVA: 0x00014480 File Offset: 0x00012680
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

	// Token: 0x0600026A RID: 618 RVA: 0x000144CC File Offset: 0x000126CC
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

	// Token: 0x04000311 RID: 785
	[Header("Scene Targets")]
	public MyClothingAnchors anchors;

	// Token: 0x04000312 RID: 786
	[Header("Assets")]
	public CharacterPartsLibrary partsLibrary;

	// Token: 0x04000313 RID: 787
	public CustomOutfit customOutfitAsset;

	// Token: 0x04000314 RID: 788
	[Header("Options")]
	public bool applyOnStart = true;
}
