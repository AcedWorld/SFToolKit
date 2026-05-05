using System;
using Cinemachine;
using UnityEngine;

// Token: 0x02000126 RID: 294
[Serializable]
public class Cameras
{
	// Token: 0x04000760 RID: 1888
	public bool ToggleCamera;

	// Token: 0x04000761 RID: 1889
	public int cameraSelected = 3;

	// Token: 0x04000762 RID: 1890
	public Camera mainCam;

	// Token: 0x04000763 RID: 1891
	public GameObject cinemachineBrain;

	// Token: 0x04000764 RID: 1892
	public CinemachineFreeLook[] gameCameras;

	// Token: 0x04000765 RID: 1893
	public CinemachineFreeLook ragdollCam;
}
