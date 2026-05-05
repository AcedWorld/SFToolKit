using System;
using UnityEngine;

// Token: 0x02000206 RID: 518
[Serializable]
public class GrindSettings
{
	// Token: 0x04000E50 RID: 3664
	[Header("Rotation Settings")]
	public float rotationSpeed;

	// Token: 0x04000E51 RID: 3665
	[Header("Wheel Settings While Grinding")]
	public float asymptoteSlip;

	// Token: 0x04000E52 RID: 3666
	public float extremumSlip;
}
