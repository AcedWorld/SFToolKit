using System;
using UnityEngine;

// Token: 0x02000099 RID: 153
[Serializable]
public class CustomOutfitData
{
	// Token: 0x04000327 RID: 807
	[Header("Selected Part Names (match CharacterPartsLibrary .name)")]
	public string top;

	// Token: 0x04000328 RID: 808
	public string hat;

	// Token: 0x04000329 RID: 809
	public string pants;

	// Token: 0x0400032A RID: 810
	public string shoes;

	// Token: 0x0400032B RID: 811
	[Header("Top Material Overrides (optional)")]
	public Material topMaterial1Override;

	// Token: 0x0400032C RID: 812
	public Material topMaterial2Override;
}
