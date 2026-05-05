using System;
using UnityEngine;

// Token: 0x020001F8 RID: 504
public class DestroyWithDelay : MonoBehaviour
{
	// Token: 0x060007E3 RID: 2019 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x060007E4 RID: 2020 RVA: 0x00038CFD File Offset: 0x00036EFD
	private void Update()
	{
		Object.Destroy(base.gameObject, this.timeToDestroy);
	}

	// Token: 0x04000DA2 RID: 3490
	public float timeToDestroy;
}
