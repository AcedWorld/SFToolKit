using System;
using UnityEngine;

// Token: 0x02000214 RID: 532
public class TutTarget : MonoBehaviour
{
	// Token: 0x06000869 RID: 2153 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x0600086A RID: 2154 RVA: 0x000020BE File Offset: 0x000002BE
	private void Update()
	{
	}

	// Token: 0x0600086B RID: 2155 RVA: 0x0003B4DF File Offset: 0x000396DF
	private void OnTriggerEnter(Collider other)
	{
		this.targetReached = true;
	}

	// Token: 0x0600086C RID: 2156 RVA: 0x0003B4E8 File Offset: 0x000396E8
	private void OnTriggerExit(Collider other)
	{
		this.targetReached = false;
	}

	// Token: 0x04000EA6 RID: 3750
	public bool targetReached;
}
