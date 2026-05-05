using System;
using UnityEngine;

// Token: 0x020000F8 RID: 248
public class CameraToggleByObject : MonoBehaviour
{
	// Token: 0x06000410 RID: 1040 RVA: 0x0001D698 File Offset: 0x0001B898
	private void Update()
	{
		if (this.virtualCamGameObject != null && this.targetObject != null && this.mainCam.activeInHierarchy)
		{
			this.virtualCamGameObject.SetActive(this.targetObject.activeInHierarchy);
		}
	}

	// Token: 0x04000606 RID: 1542
	[Header("References")]
	public GameObject mainCam;

	// Token: 0x04000607 RID: 1543
	public GameObject targetObject;

	// Token: 0x04000608 RID: 1544
	public GameObject virtualCamGameObject;
}
