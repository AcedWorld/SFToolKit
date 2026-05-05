using System;
using UnityEngine;

// Token: 0x020001F2 RID: 498
public class CeilingFan : MonoBehaviour
{
	// Token: 0x060007CD RID: 1997 RVA: 0x00038974 File Offset: 0x00036B74
	private void FixedUpdate()
	{
		base.transform.Rotate(0f, this.speed, 0f * Time.deltaTime);
	}

	// Token: 0x04000D8D RID: 3469
	public float speed;
}
