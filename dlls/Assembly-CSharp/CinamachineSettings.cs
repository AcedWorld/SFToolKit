using System;
using Cinemachine;
using UnityEngine;

// Token: 0x02000131 RID: 305
public class CinamachineSettings : MonoBehaviour
{
	// Token: 0x060004EE RID: 1262 RVA: 0x0002222B File Offset: 0x0002042B
	private void Start()
	{
		this.cinemachineBrain.m_UpdateMethod = CinemachineBrain.UpdateMethod.FixedUpdate;
	}

	// Token: 0x040007BD RID: 1981
	public CinemachineBrain cinemachineBrain;
}
