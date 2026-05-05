using System;
using UnityEngine;

// Token: 0x02000096 RID: 150
[Serializable]
public class HatData
{
	// Token: 0x0400031E RID: 798
	[Header("Basic Info")]
	public string name;

	// Token: 0x0400031F RID: 799
	[Header("Visuals")]
	public Mesh mesh;

	// Token: 0x04000320 RID: 800
	public Material material;
}
