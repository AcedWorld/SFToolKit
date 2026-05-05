using System;
using UnityEngine;

// Token: 0x02000111 RID: 273
[Serializable]
public class HeadsetData
{
	// Token: 0x040006A5 RID: 1701
	[Header("Basic Info")]
	public string headsetName;

	// Token: 0x040006A6 RID: 1702
	public ScooterBrands brand;

	// Token: 0x040006A7 RID: 1703
	[Header("Headset Components")]
	public Mesh headsetMesh;

	// Token: 0x040006A8 RID: 1704
	public Material headsetMaterial;

	// Token: 0x040006A9 RID: 1705
	[Header("UI")]
	public Sprite thumbnail;
}
