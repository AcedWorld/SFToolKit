using System;
using UnityEngine;

// Token: 0x02000199 RID: 409
[Serializable]
public class RevertSettings
{
	// Token: 0x04000AEE RID: 2798
	[Header("Main Bools")]
	public bool RevertActivated;

	// Token: 0x04000AEF RID: 2799
	public bool RevertSetup;

	// Token: 0x04000AF0 RID: 2800
	public bool RevertFakieCache;

	// Token: 0x04000AF1 RID: 2801
	public bool RevertLeft;

	// Token: 0x04000AF2 RID: 2802
	public bool RevertRight;

	// Token: 0x04000AF3 RID: 2803
	public bool RevertInverted;

	// Token: 0x04000AF4 RID: 2804
	public bool RevertPushCancel;

	// Token: 0x04000AF5 RID: 2805
	[Header("Torque Parameters")]
	public float RevertTorque = 1000f;

	// Token: 0x04000AF6 RID: 2806
	public float torqueStart = 0.5f;

	// Token: 0x04000AF7 RID: 2807
	public float torqueEnd = 12.5f;

	// Token: 0x04000AF8 RID: 2808
	public float torqueStrength;

	// Token: 0x04000AF9 RID: 2809
	[Header("Rotation Checking")]
	public float angleDifference;

	// Token: 0x04000AFA RID: 2810
	public float OriginalDirection;

	// Token: 0x04000AFB RID: 2811
	public float CurrentRotation;

	// Token: 0x04000AFC RID: 2812
	[Header("Timers")]
	public float AngleCrashTimer;

	// Token: 0x04000AFD RID: 2813
	[Header("Wheel Friction Cache")]
	public float stiffnessCache;

	// Token: 0x04000AFE RID: 2814
	public float extremumSlipCache;

	// Token: 0x04000AFF RID: 2815
	public float extremumValueCache;

	// Token: 0x04000B00 RID: 2816
	public float asymptoteSlipCache;

	// Token: 0x04000B01 RID: 2817
	public float asymptoteValueCache;

	// Token: 0x04000B02 RID: 2818
	[Header("Centre Of Mass")]
	public float RevertY = -1.5f;

	// Token: 0x04000B03 RID: 2819
	public float RevertZ = 0.2f;

	// Token: 0x04000B04 RID: 2820
	[Header("Crash Settings")]
	public float CrashAngle = 17f;

	// Token: 0x04000B05 RID: 2821
	public float CrashTime = 0.2f;
}
