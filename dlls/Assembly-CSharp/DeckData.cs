using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000109 RID: 265
[Serializable]
public class DeckData
{
	// Token: 0x04000674 RID: 1652
	[Header("Basic Info")]
	public string deckName;

	// Token: 0x04000675 RID: 1653
	public ScooterBrands brand;

	// Token: 0x04000676 RID: 1654
	[Header("Deck Components")]
	public Mesh deckMesh;

	// Token: 0x04000677 RID: 1655
	public Mesh gripTapeMesh;

	// Token: 0x04000678 RID: 1656
	public Mesh brakeMesh;

	// Token: 0x04000679 RID: 1657
	public Material deckMaterial;

	// Token: 0x0400067A RID: 1658
	[Header("Flags")]
	public bool hasInbuiltPegs;

	// Token: 0x0400067B RID: 1659
	public bool hasAddOns;

	// Token: 0x0400067C RID: 1660
	[Header("Optional Add-Ons")]
	public List<GameObject> deckAddOns;

	// Token: 0x0400067D RID: 1661
	[Header("UI")]
	public Sprite thumbnail;
}
