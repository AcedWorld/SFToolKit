using System;
using UnityEngine;

// Token: 0x02000188 RID: 392
public class pushingForce : MonoBehaviour
{
	// Token: 0x0600062D RID: 1581 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x0600062E RID: 1582 RVA: 0x0002CF08 File Offset: 0x0002B108
	public void FixedUpdate()
	{
		this.rb.AddRelativeForce(Vector3.forward * -this.m_Thrust * Time.deltaTime, ForceMode.Impulse);
	}

	// Token: 0x04000A64 RID: 2660
	public Rigidbody rb;

	// Token: 0x04000A65 RID: 2661
	public float m_Thrust = 500f;
}
