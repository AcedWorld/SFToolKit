using System;
using System.Collections;
using UnityEngine;

// Token: 0x020001ED RID: 493
public class CameraZoomAndPoleWithActivation : MonoBehaviour
{
	// Token: 0x060007AF RID: 1967 RVA: 0x0003845C File Offset: 0x0003665C
	private void Update()
	{
		if (!this.hasStarted && Input.GetKeyDown(KeyCode.Space))
		{
			this.hasStarted = true;
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(true);
			}
			base.StartCoroutine(this.CameraZoomAndRotatePole());
		}
	}

	// Token: 0x060007B0 RID: 1968 RVA: 0x000384A8 File Offset: 0x000366A8
	private IEnumerator CameraZoomAndRotatePole()
	{
		while (this.cinematicCamera.transform.position != this.cameraTargetPosition)
		{
			this.cinematicCamera.transform.position = Vector3.MoveTowards(this.cinematicCamera.transform.position, this.cameraTargetPosition, this.zoomSpeed * Time.deltaTime);
			this.cameraPole.transform.Rotate(0f, this.rotationSpeed * Time.deltaTime, 0f);
			yield return null;
		}
		yield break;
	}

	// Token: 0x04000D69 RID: 3433
	[Header("Camera Settings")]
	public Camera cinematicCamera;

	// Token: 0x04000D6A RID: 3434
	public float zoomSpeed = 1f;

	// Token: 0x04000D6B RID: 3435
	public Vector3 cameraTargetPosition;

	// Token: 0x04000D6C RID: 3436
	[Header("Camera Pole")]
	public GameObject cameraPole;

	// Token: 0x04000D6D RID: 3437
	public float rotationSpeed = 30f;

	// Token: 0x04000D6E RID: 3438
	[Header("GameObject Activation")]
	public GameObject objectToActivate;

	// Token: 0x04000D6F RID: 3439
	private bool hasStarted;
}
