using System;
using UnityEngine;

// Token: 0x02000095 RID: 149
[Serializable]
public class TopData
{
	// Token: 0x0400031A RID: 794
	[Header("Basic Info")]
	public string name;

	// Token: 0x0400031B RID: 795
	[Header("Visuals")]
	public Mesh mesh;

	// Token: 0x0400031C RID: 796
	[Tooltip("Primary material for the top")]
	public Material material1;

	// Token: 0x0400031D RID: 797
	[Tooltip("Secondary material for the top (optional)")]
	public Material material2;
}
