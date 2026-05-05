using System;
using UnityEngine;

// Token: 0x020001EB RID: 491
public class MinirampFans : MonoBehaviour
{
	// Token: 0x060007A8 RID: 1960 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x060007A9 RID: 1961 RVA: 0x00038234 File Offset: 0x00036434
	private void Update()
	{
		if (this.reverse)
		{
			this.fan1.Rotate(0f, 0f, 1f * this.speed * Time.deltaTime);
			this.fan2.Rotate(0f, 0f, 1f * this.speed * Time.deltaTime);
		}
		if (!this.reverse)
		{
			this.fan1.Rotate(0f, 0f, -1f * this.speed * Time.deltaTime);
			this.fan2.Rotate(0f, 0f, -1f * this.speed * Time.deltaTime);
		}
	}

	// Token: 0x04000D5E RID: 3422
	public float speed;

	// Token: 0x04000D5F RID: 3423
	public bool reverse;

	// Token: 0x04000D60 RID: 3424
	public Transform fan1;

	// Token: 0x04000D61 RID: 3425
	public Transform fan2;
}
