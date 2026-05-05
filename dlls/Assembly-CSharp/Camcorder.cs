using System;
using UnityEngine;

// Token: 0x020000AA RID: 170
public class Camcorder : MonoBehaviour
{
	// Token: 0x060002D2 RID: 722 RVA: 0x000166F0 File Offset: 0x000148F0
	private void Start()
	{
		this.target = GameObject.Find("CameraTarget_Parent").transform;
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x00016707 File Offset: 0x00014907
	private void Update()
	{
		base.transform.LookAt(this.target);
	}

	// Token: 0x0400038F RID: 911
	private Transform target;
}
