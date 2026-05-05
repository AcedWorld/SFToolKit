using System;
using UnityEngine;

// Token: 0x02000153 RID: 339
[Serializable]
public class TeleportPlayerReferences
{
	// Token: 0x0400089E RID: 2206
	public Transform spawnpointTransform;

	// Token: 0x0400089F RID: 2207
	public Rigidbody playerRigidbody;

	// Token: 0x040008A0 RID: 2208
	public RagdollControl ragdollControl;

	// Token: 0x040008A1 RID: 2209
	public CameraBrain cameraBrain;

	// Token: 0x040008A2 RID: 2210
	public SoundManager soundManager;

	// Token: 0x040008A3 RID: 2211
	public ScooterController scooterController;

	// Token: 0x040008A4 RID: 2212
	public CharacterStates characterStates;

	// Token: 0x040008A5 RID: 2213
	public ScooterflowInputSystem scooterflowInputSystem;

	// Token: 0x040008A6 RID: 2214
	public GrindSystem grindSystem;

	// Token: 0x040008A7 RID: 2215
	public RampDirection rampDirection;

	// Token: 0x040008A8 RID: 2216
	public SimpleReplay simpleReplay;

	// Token: 0x040008A9 RID: 2217
	public TimeSpeed timespeed;

	// Token: 0x040008AA RID: 2218
	[Header("Loadscreen")]
	public GameObject loadscreenPrefab;

	// Token: 0x040008AB RID: 2219
	public Transform loadscreenParent;
}
