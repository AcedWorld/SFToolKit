using System;
using UnityEngine;

// Token: 0x02000189 RID: 393
[Serializable]
public class RampDirectionReferences
{
	// Token: 0x04000A66 RID: 2662
	public ScooterController scooterController;

	// Token: 0x04000A67 RID: 2663
	public upright upright;

	// Token: 0x04000A68 RID: 2664
	public Rigidbody playerRigidbody;

	// Token: 0x04000A69 RID: 2665
	public Hop hop;

	// Token: 0x04000A6A RID: 2666
	public LandCorrection landCorrection;

	// Token: 0x04000A6B RID: 2667
	public TrajectoryPrediction trajectoryPrediction;

	// Token: 0x04000A6C RID: 2668
	public GrindSystem grindSystem;
}
