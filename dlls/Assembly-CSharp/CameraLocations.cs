using System;
using UnityEngine;

// Token: 0x02000127 RID: 295
[Serializable]
public class CameraLocations
{
	// Token: 0x04000766 RID: 1894
	public Transform CinamachineBrainTransform;

	// Token: 0x04000767 RID: 1895
	public Transform ragdollCamera;

	// Token: 0x04000768 RID: 1896
	public Transform Camera1Target;

	// Token: 0x04000769 RID: 1897
	public Transform Camera2Target;

	// Token: 0x0400076A RID: 1898
	public Transform Camera3Target;

	// Token: 0x0400076B RID: 1899
	public GameObject cameraParent;

	// Token: 0x0400076C RID: 1900
	public Transform FirstPersonTarget;

	// Token: 0x0400076D RID: 1901
	[Header("Reparenting")]
	public Transform characterParent;

	// Token: 0x0400076E RID: 1902
	public Transform playerParent;

	// Token: 0x0400076F RID: 1903
	public Transform cameraTargets;

	// Token: 0x04000770 RID: 1904
	public Transform PlayerComponents;
}
