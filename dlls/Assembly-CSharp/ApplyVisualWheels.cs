using System;
using UnityEngine;

// Token: 0x02000122 RID: 290
public class ApplyVisualWheels : MonoBehaviour
{
	// Token: 0x060004BF RID: 1215 RVA: 0x00021020 File Offset: 0x0001F220
	private void Update()
	{
		float num = 1f;
		if (this.scooterController.localVelocity.z < 0f)
		{
			num = -1f;
		}
		float xAngle = this.playerRigidbody.velocity.magnitude * Time.deltaTime / this.WheelRadius * 57.29578f * num;
		this.frontWheel.transform.Rotate(xAngle, 0f, 0f);
		this.backWheel.transform.Rotate(xAngle, 0f, 0f);
	}

	// Token: 0x0400071C RID: 1820
	public GameObject frontWheel;

	// Token: 0x0400071D RID: 1821
	public GameObject backWheel;

	// Token: 0x0400071E RID: 1822
	public Rigidbody playerRigidbody;

	// Token: 0x0400071F RID: 1823
	public float WheelRadius = 0.12f;

	// Token: 0x04000720 RID: 1824
	public ScooterController scooterController;
}
