using System;
using UnityEngine;

// Token: 0x020001F4 RID: 500
public class SwingingChain : MonoBehaviour
{
	// Token: 0x060007D2 RID: 2002 RVA: 0x00038A2C File Offset: 0x00036C2C
	private void Start()
	{
		this.initialRotation = base.transform.localEulerAngles;
	}

	// Token: 0x060007D3 RID: 2003 RVA: 0x00038A40 File Offset: 0x00036C40
	private void FixedUpdate()
	{
		float num = Mathf.Sin(Time.time * this.swingSpeed) * this.swingAngle;
		float num2 = Mathf.Cos(Time.time * this.swingSpeed) * this.swingAngle;
		base.transform.localEulerAngles = new Vector3(this.initialRotation.x + num, this.initialRotation.y, this.initialRotation.z + num2);
	}

	// Token: 0x04000D91 RID: 3473
	public float swingSpeed = 1f;

	// Token: 0x04000D92 RID: 3474
	public float swingAngle = 5f;

	// Token: 0x04000D93 RID: 3475
	private Vector3 initialRotation;
}
