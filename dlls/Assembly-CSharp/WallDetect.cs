using System;
using UnityEngine;

// Token: 0x0200019E RID: 414
public class WallDetect : MonoBehaviour
{
	// Token: 0x0600067F RID: 1663 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x06000680 RID: 1664 RVA: 0x0003173C File Offset: 0x0002F93C
	private void FixedUpdate()
	{
		this.hit = default(RaycastHit);
		Physics.Raycast(base.transform.position, base.transform.TransformDirection(Vector3.down), out this.hit, float.PositiveInfinity, this.layerMask);
		if (this.scooterController.frontWheelGrounded && this.scooterController.rearWheelGrounded)
		{
			this.disc.transform.position = this.hit.point;
			Quaternion rhs = new Quaternion(0f, base.transform.rotation.y, 0f, base.transform.rotation.w);
			Quaternion rotation = Quaternion.FromToRotation(Vector3.up, this.hit.normal) * rhs;
			this.disc.transform.rotation = rotation;
			this.lastHitPoint = this.hit.point;
			return;
		}
		this.disc.transform.position = this.lastHitPoint;
	}

	// Token: 0x04000B57 RID: 2903
	public LayerMask layerMask;

	// Token: 0x04000B58 RID: 2904
	public RaycastHit hit;

	// Token: 0x04000B59 RID: 2905
	public float distance;

	// Token: 0x04000B5A RID: 2906
	public GameObject disc;

	// Token: 0x04000B5B RID: 2907
	public bool probablyNotWall;

	// Token: 0x04000B5C RID: 2908
	private Vector3 lastHitPoint;

	// Token: 0x04000B5D RID: 2909
	public ScooterController scooterController;
}
