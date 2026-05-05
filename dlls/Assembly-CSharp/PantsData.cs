using System;
using UnityEngine;

// Token: 0x02000097 RID: 151
[Serializable]
public class PantsData
{
	// Token: 0x04000321 RID: 801
	[Header("Basic Info")]
	public string name;

	// Token: 0x04000322 RID: 802
	[Header("Visuals")]
	public Mesh mesh;

	// Token: 0x04000323 RID: 803
	public Material material;
}
