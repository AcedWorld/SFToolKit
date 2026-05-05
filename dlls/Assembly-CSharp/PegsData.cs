using System;
using UnityEngine;

// Token: 0x02000112 RID: 274
[Serializable]
public class PegsData
{
	// Token: 0x040006AA RID: 1706
	[Header("Basic Info")]
	public string pegsName;

	// Token: 0x040006AB RID: 1707
	public ScooterBrands brand;

	// Token: 0x040006AC RID: 1708
	[Header("Peg Components")]
	public Mesh frontLeftPegMesh;

	// Token: 0x040006AD RID: 1709
	public Mesh frontRightPegMesh;

	// Token: 0x040006AE RID: 1710
	public Mesh rearLeftPegMesh;

	// Token: 0x040006AF RID: 1711
	public Mesh rearRightPegMesh;

	// Token: 0x040006B0 RID: 1712
	public Material pegsMaterial;

	// Token: 0x040006B1 RID: 1713
	[Header("UI")]
	public Sprite thumbnail;
}
