using System;
using UnityEngine;

// Token: 0x02000208 RID: 520
public class JumpDirection : MonoBehaviour
{
	// Token: 0x0600082C RID: 2092 RVA: 0x0003A94F File Offset: 0x00038B4F
	private void FixedUpdate()
	{
		this.CalculateWheelNormal();
	}

	// Token: 0x0600082D RID: 2093 RVA: 0x0003A958 File Offset: 0x00038B58
	public void CalculateWheelNormal()
	{
		if (!this.scooterController.frontWheelGrounded && !this.scooterController.rearWheelGrounded)
		{
			this.wheelNormal = (this.upright.frontHit.normal + this.upright.rearHit.normal).normalized;
		}
		else if (this.scooterController.rearWheelGrounded)
		{
			this.wheelNormal = this.upright.rearHit.normal.normalized;
		}
		else if (this.scooterController.frontWheelGrounded)
		{
			this.wheelNormal = this.upright.frontHit.normal.normalized;
		}
		this.UpdateJumpDirection();
	}

	// Token: 0x0600082E RID: 2094 RVA: 0x0003AA14 File Offset: 0x00038C14
	private void UpdateJumpDirection()
	{
		Quaternion rhs = Quaternion.Euler(0f, this.mainPlayer.rotation.eulerAngles.y, 0f);
		Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, this.wheelNormal) * rhs;
		quaternion *= Quaternion.Euler(this.jumpOffset);
		base.transform.rotation = quaternion;
	}

	// Token: 0x04000E5B RID: 3675
	public upright upright;

	// Token: 0x04000E5C RID: 3676
	public ScooterController scooterController;

	// Token: 0x04000E5D RID: 3677
	private Vector3 wheelNormal;

	// Token: 0x04000E5E RID: 3678
	public Transform mainPlayer;

	// Token: 0x04000E5F RID: 3679
	public Vector3 jumpOffset;
}
