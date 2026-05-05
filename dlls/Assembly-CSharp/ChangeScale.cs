using System;
using UnityEngine;

// Token: 0x020001A9 RID: 425
public class ChangeScale : MonoBehaviour
{
	// Token: 0x060006A9 RID: 1705 RVA: 0x000323EE File Offset: 0x000305EE
	private void Start()
	{
		this.currentScale = base.transform.localScale;
	}

	// Token: 0x060006AA RID: 1706 RVA: 0x00032401 File Offset: 0x00030601
	public void ToggleScale()
	{
		if (!this.trigger)
		{
			base.transform.localScale = this.Scale;
		}
		else
		{
			base.transform.localScale = this.currentScale;
		}
		this.trigger = !this.trigger;
	}

	// Token: 0x04000B9E RID: 2974
	private Vector3 currentScale;

	// Token: 0x04000B9F RID: 2975
	public Vector3 Scale;

	// Token: 0x04000BA0 RID: 2976
	private bool trigger;
}
