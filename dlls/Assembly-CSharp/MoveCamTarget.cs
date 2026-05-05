using System;
using UnityEngine;

// Token: 0x0200012B RID: 299
public class MoveCamTarget : MonoBehaviour
{
	// Token: 0x060004DB RID: 1243 RVA: 0x00021A94 File Offset: 0x0001FC94
	private void LateUpdate()
	{
		if (this._camera.activeSelf)
		{
			if (this.scooterController.isGrounded)
			{
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, this.normalState, this.dampTime * Time.deltaTime);
			}
			if (!this.scooterController.isGrounded)
			{
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, this.airState, this.dampTime * Time.deltaTime);
			}
		}
	}

	// Token: 0x04000784 RID: 1924
	public ScooterController scooterController;

	// Token: 0x04000785 RID: 1925
	public GameObject _camera;

	// Token: 0x04000786 RID: 1926
	public float dampTime;

	// Token: 0x04000787 RID: 1927
	public Vector3 normalState;

	// Token: 0x04000788 RID: 1928
	public Vector3 airState;
}
