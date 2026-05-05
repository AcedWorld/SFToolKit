using System;
using UnityEngine;

// Token: 0x020001F7 RID: 503
public class AntiRepeatSound : MonoBehaviour
{
	// Token: 0x060007E0 RID: 2016 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x060007E1 RID: 2017 RVA: 0x00038CE8 File Offset: 0x00036EE8
	private void Update()
	{
		int childCount = base.transform.childCount;
		int num = this.maxNumberOfSounds;
	}

	// Token: 0x04000DA0 RID: 3488
	public RagdollControl ragdollControl;

	// Token: 0x04000DA1 RID: 3489
	public int maxNumberOfSounds;
}
