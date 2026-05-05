using System;
using UnityEngine;

// Token: 0x020001A7 RID: 423
public class TriggerRagdoll : MonoBehaviour
{
	// Token: 0x060006A2 RID: 1698 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x060006A3 RID: 1699 RVA: 0x00032338 File Offset: 0x00030538
	private void Awake()
	{
		int layer = LayerMask.NameToLayer("RagdollTrigger");
		base.gameObject.layer = layer;
	}

	// Token: 0x060006A4 RID: 1700 RVA: 0x0003235C File Offset: 0x0003055C
	private void OnTriggerStay(Collider other)
	{
		if (!this.ragdollC.ragdollActive)
		{
			this.ragdollC.ActivateRagdoll();
		}
	}

	// Token: 0x04000B9B RID: 2971
	public RagdollControl ragdollC;
}
