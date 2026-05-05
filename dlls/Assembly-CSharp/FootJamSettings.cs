using System;

// Token: 0x02000196 RID: 406
[Serializable]
public class FootJamSettings
{
	// Token: 0x04000AD6 RID: 2774
	public float MaxJamVel = 7f;

	// Token: 0x04000AD7 RID: 2775
	public float MaxJamFall = 8f;

	// Token: 0x04000AD8 RID: 2776
	public float MaxJamAngle = 30f;

	// Token: 0x04000AD9 RID: 2777
	public float JamHopVelTheshold = 1f;

	// Token: 0x04000ADA RID: 2778
	public float WheelDamp = 15f;

	// Token: 0x04000ADB RID: 2779
	public float DefaultWheelDamp = 0.02f;

	// Token: 0x04000ADC RID: 2780
	public bool JamisRotating;

	// Token: 0x04000ADD RID: 2781
	public float JamTime;

	// Token: 0x04000ADE RID: 2782
	public bool FootJamSpun;

	// Token: 0x04000ADF RID: 2783
	public float previousYRotation;
}
