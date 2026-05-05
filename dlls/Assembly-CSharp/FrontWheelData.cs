using System;
using UnityEngine;

// Token: 0x0200010D RID: 269
[Serializable]
public class FrontWheelData
{
	// Token: 0x0400068D RID: 1677
	[Header("Basic Info")]
	public string wheelName;

	// Token: 0x0400068E RID: 1678
	public ScooterBrands brand;

	// Token: 0x0400068F RID: 1679
	[Header("Wheel Components")]
	public Mesh wheelMesh;

	// Token: 0x04000690 RID: 1680
	public Material hubMaterial;

	// Token: 0x04000691 RID: 1681
	public Material tyreMaterial;

	// Token: 0x04000692 RID: 1682
	[Header("UI")]
	public Sprite thumbnail;
}
