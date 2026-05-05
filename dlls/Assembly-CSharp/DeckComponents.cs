using System;
using UnityEngine;

// Token: 0x020000D6 RID: 214
[Serializable]
public class DeckComponents
{
	// Token: 0x0400052F RID: 1327
	public Mesh deckMesh;

	// Token: 0x04000530 RID: 1328
	public Mesh gripTapeMesh;

	// Token: 0x04000531 RID: 1329
	public Mesh brakeMesh;

	// Token: 0x04000532 RID: 1330
	public Material deckMaterial;

	// Token: 0x04000533 RID: 1331
	public bool hasInbuiltPegs;

	// Token: 0x04000534 RID: 1332
	public bool hasAddOns;

	// Token: 0x04000535 RID: 1333
	public GameObject[] deckAddOns;
}
