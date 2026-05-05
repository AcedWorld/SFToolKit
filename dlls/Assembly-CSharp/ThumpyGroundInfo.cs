using System;
using UnityEngine;

// Token: 0x020001CF RID: 463
public class ThumpyGroundInfo : MonoBehaviour
{
	// Token: 0x0600073D RID: 1853 RVA: 0x0003685E File Offset: 0x00034A5E
	private void Update()
	{
		this.GetGroundPosition();
	}

	// Token: 0x0600073E RID: 1854 RVA: 0x00036868 File Offset: 0x00034A68
	public void GetGroundPosition()
	{
		if (Physics.Raycast(base.transform.position, base.transform.TransformDirection(Vector3.forward), out this.hit, float.PositiveInfinity, this.layerMask))
		{
			Debug.DrawRay(base.transform.position, base.transform.TransformDirection(Vector3.forward) * this.hit.distance, Color.yellow);
		}
	}

	// Token: 0x04000CD6 RID: 3286
	public LayerMask layerMask;

	// Token: 0x04000CD7 RID: 3287
	public RaycastHit hit;
}
