using System;
using UnityEngine;

// Token: 0x02000204 RID: 516
public class GrindCollision : MonoBehaviour
{
	// Token: 0x0600081D RID: 2077 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x0600081E RID: 2078 RVA: 0x000020BE File Offset: 0x000002BE
	private void Update()
	{
	}

	// Token: 0x0600081F RID: 2079 RVA: 0x0003A7FD File Offset: 0x000389FD
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Rail"))
		{
			this.grinding = true;
		}
	}

	// Token: 0x06000820 RID: 2080 RVA: 0x0003A818 File Offset: 0x00038A18
	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Rail"))
		{
			this.grinding = false;
		}
	}

	// Token: 0x04000E48 RID: 3656
	public bool grinding;
}
