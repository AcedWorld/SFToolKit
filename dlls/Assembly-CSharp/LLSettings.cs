using System;
using UnityEngine;

// Token: 0x02000185 RID: 389
[Serializable]
public class LLSettings
{
	// Token: 0x04000A3E RID: 2622
	[Header("Rotation Speed")]
	public float speedBeforeInput;

	// Token: 0x04000A3F RID: 2623
	public float speedAfterInput;

	// Token: 0x04000A40 RID: 2624
	public float tempSpeedBeforeInput;

	// Token: 0x04000A41 RID: 2625
	[Header("Rotation Dampening")]
	public float dampeningAmount;

	// Token: 0x04000A42 RID: 2626
	[Header("Player Angle")]
	public float MinimumX;

	// Token: 0x04000A43 RID: 2627
	public float MaximumX;

	// Token: 0x04000A44 RID: 2628
	public float MinimumZ;

	// Token: 0x04000A45 RID: 2629
	public float MaximumZ;

	// Token: 0x04000A46 RID: 2630
	[Header("Wall Height")]
	public GameObject WallCheckPrefab;

	// Token: 0x04000A47 RID: 2631
	public float minimumHeightForWall;

	// Token: 0x04000A48 RID: 2632
	public float offsetFromWall;
}
