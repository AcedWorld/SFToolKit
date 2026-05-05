using System;
using UnityEngine;

// Token: 0x020001A1 RID: 417
public class BoundaryScript : MonoBehaviour
{
	// Token: 0x06000690 RID: 1680 RVA: 0x00031E2E File Offset: 0x0003002E
	private void Start()
	{
		this.ragdollControl = GameObject.Find("Player_Manager").GetComponent<RagdollControl>();
	}

	// Token: 0x06000691 RID: 1681 RVA: 0x00031E45 File Offset: 0x00030045
	private void OnTriggerEnter(Collider other)
	{
		this.ragdollControl.ragdollActive = true;
	}

	// Token: 0x04000B78 RID: 2936
	private RagdollControl ragdollControl;
}
