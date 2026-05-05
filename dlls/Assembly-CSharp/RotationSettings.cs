using System;
using UnityEngine;

// Token: 0x02000192 RID: 402
[Serializable]
public class RotationSettings
{
	// Token: 0x04000ABA RID: 2746
	public bool disableLandCorrectionOnFlip;

	// Token: 0x04000ABB RID: 2747
	public float flipSpeed;

	// Token: 0x04000ABC RID: 2748
	public float spinSpeed;

	// Token: 0x04000ABD RID: 2749
	public float fastSpin;

	// Token: 0x04000ABE RID: 2750
	public float spinDampen;

	// Token: 0x04000ABF RID: 2751
	public float normalToFastDampen;

	// Token: 0x04000AC0 RID: 2752
	[HideInInspector]
	public float flip;

	// Token: 0x04000AC1 RID: 2753
	public float finalFlip;

	// Token: 0x04000AC2 RID: 2754
	[HideInInspector]
	public float hinput;

	// Token: 0x04000AC3 RID: 2755
	[HideInInspector]
	public float spinSpeedAfter;
}
