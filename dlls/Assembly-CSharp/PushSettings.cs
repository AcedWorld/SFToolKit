using System;
using UnityEngine;

// Token: 0x02000191 RID: 401
[Serializable]
public class PushSettings
{
	// Token: 0x04000AB4 RID: 2740
	public float initialPushForce = 20f;

	// Token: 0x04000AB5 RID: 2741
	public float delay;

	// Token: 0x04000AB6 RID: 2742
	public float duration;

	// Token: 0x04000AB7 RID: 2743
	public float maxSpeed;

	// Token: 0x04000AB8 RID: 2744
	[HideInInspector]
	public bool pushingForce;

	// Token: 0x04000AB9 RID: 2745
	public bool AddPushForceCoroutining;
}
