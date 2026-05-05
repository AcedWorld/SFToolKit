using System;
using UnityEngine;

// Token: 0x0200010B RID: 267
[Serializable]
public class ForksData
{
	// Token: 0x04000683 RID: 1667
	[Header("Basic Info")]
	public string forksName;

	// Token: 0x04000684 RID: 1668
	public ScooterBrands brand;

	// Token: 0x04000685 RID: 1669
	[Header("Forks Components")]
	public Mesh forksMesh;

	// Token: 0x04000686 RID: 1670
	public Material forksMaterial;

	// Token: 0x04000687 RID: 1671
	[Header("UI")]
	public Sprite thumbnail;
}
