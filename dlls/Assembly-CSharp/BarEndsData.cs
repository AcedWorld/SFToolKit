using System;
using UnityEngine;

// Token: 0x02000110 RID: 272
[Serializable]
public class BarEndsData
{
	// Token: 0x0400069F RID: 1695
	[Header("Basic Info")]
	public string barEndsName;

	// Token: 0x040006A0 RID: 1696
	public ScooterBrands brand;

	// Token: 0x040006A1 RID: 1697
	[Header("Bar End Components")]
	public Mesh leftBarendMesh;

	// Token: 0x040006A2 RID: 1698
	public Mesh rightBarend;

	// Token: 0x040006A3 RID: 1699
	public Material barEndsMaterial;

	// Token: 0x040006A4 RID: 1700
	[Header("UI")]
	public Sprite thumbnail;
}
