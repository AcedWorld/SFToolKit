using System;
using UnityEngine;

// Token: 0x020001F3 RID: 499
public class RopeSwing : MonoBehaviour
{
	// Token: 0x060007CF RID: 1999 RVA: 0x00038997 File Offset: 0x00036B97
	private void Start()
	{
		this.initialRotationX = base.transform.localEulerAngles.x;
	}

	// Token: 0x060007D0 RID: 2000 RVA: 0x000389B0 File Offset: 0x00036BB0
	private void FixedUpdate()
	{
		float num = Mathf.Sin(Time.time * this.swingSpeed) * this.swingAngle;
		base.transform.localEulerAngles = new Vector3(this.initialRotationX + num, base.transform.localEulerAngles.y, base.transform.localEulerAngles.z);
	}

	// Token: 0x04000D8E RID: 3470
	public float swingSpeed = 1f;

	// Token: 0x04000D8F RID: 3471
	public float swingAngle = 5f;

	// Token: 0x04000D90 RID: 3472
	private float initialRotationX;
}
