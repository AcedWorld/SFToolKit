using System;
using UnityEngine;

// Token: 0x020001A4 RID: 420
[Serializable]
public class PuppetVelocitySettings
{
	// Token: 0x04000B7E RID: 2942
	public Vector3 PreviousVelocity;

	// Token: 0x04000B7F RID: 2943
	public Vector3 PreviousAngularVelocity;

	// Token: 0x04000B80 RID: 2944
	public Vector3 CachedAngularVelocity;

	// Token: 0x04000B81 RID: 2945
	public float VelocityTime;

	// Token: 0x04000B82 RID: 2946
	public float VelocityDelay = 0.25f;

	// Token: 0x04000B83 RID: 2947
	public float localXAngularVelocity;
}
