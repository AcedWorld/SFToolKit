using System;
using UnityEngine;

// Token: 0x0200010F RID: 271
[Serializable]
public class GripsData
{
	// Token: 0x04000699 RID: 1689
	[Header("Basic Info")]
	public string gripsName;

	// Token: 0x0400069A RID: 1690
	public ScooterBrands brand;

	// Token: 0x0400069B RID: 1691
	[Header("Grips Components")]
	public Mesh leftGripMesh;

	// Token: 0x0400069C RID: 1692
	public Mesh rightGripMesh;

	// Token: 0x0400069D RID: 1693
	public Material gripsMaterial;

	// Token: 0x0400069E RID: 1694
	[Header("UI")]
	public Sprite thumbnail;
}
