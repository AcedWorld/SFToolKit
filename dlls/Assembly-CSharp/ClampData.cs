using System;
using UnityEngine;

// Token: 0x0200010C RID: 268
[Serializable]
public class ClampData
{
	// Token: 0x04000688 RID: 1672
	[Header("Basic Info")]
	public string clampName;

	// Token: 0x04000689 RID: 1673
	public ScooterBrands brand;

	// Token: 0x0400068A RID: 1674
	[Header("Clamp Components")]
	public Mesh clampMesh;

	// Token: 0x0400068B RID: 1675
	public Material clampMaterial;

	// Token: 0x0400068C RID: 1676
	[Header("UI")]
	public Sprite thumbnail;
}
