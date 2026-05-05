using System;
using UnityEngine;

// Token: 0x02000098 RID: 152
[Serializable]
public class ShoesData
{
	// Token: 0x04000324 RID: 804
	[Header("Basic Info")]
	public string name;

	// Token: 0x04000325 RID: 805
	[Header("Visuals")]
	public Mesh mesh;

	// Token: 0x04000326 RID: 806
	public Material material;
}
