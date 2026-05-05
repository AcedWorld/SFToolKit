using System;
using UnityEngine;

// Token: 0x02000174 RID: 372
public class LC_RaycastDownCheck : MonoBehaviour
{
	// Token: 0x06000600 RID: 1536 RVA: 0x0002BBDA File Offset: 0x00029DDA
	private void Start()
	{
		this.PerformRaycastDown();
	}

	// Token: 0x06000601 RID: 1537 RVA: 0x0002BBE4 File Offset: 0x00029DE4
	private void PerformRaycastDown()
	{
		Vector3 down = Vector3.down;
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, down, out raycastHit))
		{
			if (raycastHit.distance < this.minimumDistance)
			{
				this.landLocation.landNormal = new Vector3(0f, 0f, 0f);
			}
			Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040009F0 RID: 2544
	public float minimumDistance;

	// Token: 0x040009F1 RID: 2545
	public LandCorrection landLocation;
}
