using System;

// Token: 0x02000197 RID: 407
[Serializable]
public class VelocityMagnitudeSettings
{
	// Token: 0x04000AE0 RID: 2784
	public float AngularVelocityMagnitude;

	// Token: 0x04000AE1 RID: 2785
	public float currentVelocityMagnitude;

	// Token: 0x04000AE2 RID: 2786
	public float previousVelocityMagnitude;

	// Token: 0x04000AE3 RID: 2787
	public float currentFallMagnitude;

	// Token: 0x04000AE4 RID: 2788
	public float previousFallMagnitude;

	// Token: 0x04000AE5 RID: 2789
	public float VelocityMagnitudeTime;

	// Token: 0x04000AE6 RID: 2790
	public float VelocityMagnitudeDelay = 0.25f;
}
