using System;
using UnityEngine;

// Token: 0x02000210 RID: 528
public class VertCheck : MonoBehaviour
{
	// Token: 0x06000850 RID: 2128 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x06000851 RID: 2129 RVA: 0x0003B1CC File Offset: 0x000393CC
	private void FixedUpdate()
	{
		if (this.scooterController.isGrounded)
		{
			Vector3 vector = this.playerTransform.position + this.playerTransform.up * this.initialRayOffset + -this.playerTransform.up * this.secondRayOffset;
			RaycastHit raycastHit;
			if (Physics.Raycast(vector, Vector3.down, out raycastHit, float.PositiveInfinity, this.layerMask))
			{
				if (this.debug)
				{
					Debug.DrawRay(vector, Vector3.down * raycastHit.distance, Color.red);
				}
				this.angleOfGroundBelow = Vector3.Angle(raycastHit.normal, Vector3.up);
				this.FinalCheck();
			}
		}
	}

	// Token: 0x06000852 RID: 2130 RVA: 0x0003B290 File Offset: 0x00039490
	private void FinalCheck()
	{
		this.wall = (this.angleOfGroundBelow < this.minimumAngle || this.angleOfGroundBelow > this.maximumAngle);
	}

	// Token: 0x04000E8D RID: 3725
	public bool debug;

	// Token: 0x04000E8E RID: 3726
	public bool wall;

	// Token: 0x04000E8F RID: 3727
	public ScooterController scooterController;

	// Token: 0x04000E90 RID: 3728
	public float initialRayOffset;

	// Token: 0x04000E91 RID: 3729
	public float secondRayOffset;

	// Token: 0x04000E92 RID: 3730
	public LayerMask layerMask;

	// Token: 0x04000E93 RID: 3731
	public Transform playerTransform;

	// Token: 0x04000E94 RID: 3732
	public float minimumAngle;

	// Token: 0x04000E95 RID: 3733
	public float maximumAngle;

	// Token: 0x04000E96 RID: 3734
	public float angleOfGroundBelow;
}
