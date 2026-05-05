using System;
using UnityEngine;

// Token: 0x0200010A RID: 266
[Serializable]
public class BarsData
{
	// Token: 0x0400067E RID: 1662
	[Header("Basic Info")]
	public string barsName;

	// Token: 0x0400067F RID: 1663
	public ScooterBrands brand;

	// Token: 0x04000680 RID: 1664
	[Header("Bars Components")]
	public Mesh barsMesh;

	// Token: 0x04000681 RID: 1665
	public Material barsMaterial;

	// Token: 0x04000682 RID: 1666
	[Header("UI")]
	public Sprite thumbnail;
}
