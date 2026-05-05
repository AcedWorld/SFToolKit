using System;
using UnityEngine;

// Token: 0x0200010E RID: 270
[Serializable]
public class RearWheelData
{
	// Token: 0x04000693 RID: 1683
	[Header("Basic Info")]
	public string wheelName;

	// Token: 0x04000694 RID: 1684
	public ScooterBrands brand;

	// Token: 0x04000695 RID: 1685
	[Header("Wheel Components")]
	public Mesh wheelMesh;

	// Token: 0x04000696 RID: 1686
	public Material hubMaterial;

	// Token: 0x04000697 RID: 1687
	public Material tyreMaterial;

	// Token: 0x04000698 RID: 1688
	[Header("UI")]
	public Sprite thumbnail;
}
