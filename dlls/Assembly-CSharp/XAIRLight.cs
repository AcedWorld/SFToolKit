using System;
using UnityEngine;

// Token: 0x020001E7 RID: 487
public class XAIRLight : MonoBehaviour
{
	// Token: 0x0600079B RID: 1947 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x0600079C RID: 1948 RVA: 0x00037F97 File Offset: 0x00036197
	private void Update()
	{
		base.transform.Rotate(this.Axis * this.speed * Time.deltaTime, Space.Self);
	}

	// Token: 0x04000D4A RID: 3402
	public Vector3 Axis;

	// Token: 0x04000D4B RID: 3403
	public float speed;
}
