using System;
using UnityEngine;

// Token: 0x02000190 RID: 400
[Serializable]
public class ScooterWheelSettings
{
	// Token: 0x04000AAF RID: 2735
	[Header("Scooter Wheel Settings")]
	public float maxMotorTorque;

	// Token: 0x04000AB0 RID: 2736
	public float maxSteeringAngle;

	// Token: 0x04000AB1 RID: 2737
	public float fakieSteerAngle;

	// Token: 0x04000AB2 RID: 2738
	public float steerDampen;

	// Token: 0x04000AB3 RID: 2739
	public float stopDrag;
}
