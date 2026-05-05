using System;
using UnityEngine;

// Token: 0x020001BE RID: 446
public class ScooterRagdoll : MonoBehaviour
{
	// Token: 0x060006ED RID: 1773 RVA: 0x00033C94 File Offset: 0x00031E94
	private void FixedUpdate()
	{
		if (this.references.ScooterForksJoint.transform.localPosition != this.normalPos)
		{
			this.references.ScooterForksJoint.transform.localPosition = this.normalPos;
		}
	}

	// Token: 0x060006EE RID: 1774 RVA: 0x00033CD4 File Offset: 0x00031ED4
	public void AddRagdollComponents()
	{
		this.references.playerRigidbody.ResetCenterOfMass();
		if (this.addedrb == null)
		{
			Rigidbody rigidbody = this.references.ScooterForksJoint.AddComponent<Rigidbody>();
			rigidbody.mass = this.mass;
			rigidbody.angularDrag = this.angularDrag;
			rigidbody.interpolation = this.interpolation;
			rigidbody.collisionDetectionMode = this.collisionDetectionMode;
			this.addedrb = rigidbody;
		}
		if (this.addedhingejoint == null)
		{
			HingeJoint hingeJoint = this.references.ScooterForksJoint.AddComponent<HingeJoint>();
			hingeJoint.connectedBody = this.references.playerRigidbody;
			hingeJoint.anchor = new Vector3(0f, 1f, 0f);
			hingeJoint.axis = new Vector3(0f, 1f, 0f);
			hingeJoint.autoConfigureConnectedAnchor = true;
			this.addedhingejoint = hingeJoint;
		}
	}

	// Token: 0x060006EF RID: 1775 RVA: 0x00033DB9 File Offset: 0x00031FB9
	public void RemoveRagdollComponents()
	{
		Object.Destroy(this.addedhingejoint);
		Object.Destroy(this.addedrb);
	}

	// Token: 0x04000C4D RID: 3149
	public ScooterRagdollReferences references;

	// Token: 0x04000C4E RID: 3150
	public Rigidbody addedrb;

	// Token: 0x04000C4F RID: 3151
	public HingeJoint addedhingejoint;

	// Token: 0x04000C50 RID: 3152
	public Vector3 normalPos;

	// Token: 0x04000C51 RID: 3153
	[Header("Settings")]
	public float mass;

	// Token: 0x04000C52 RID: 3154
	public float angularDrag;

	// Token: 0x04000C53 RID: 3155
	public float drag;

	// Token: 0x04000C54 RID: 3156
	public RigidbodyInterpolation interpolation;

	// Token: 0x04000C55 RID: 3157
	public CollisionDetectionMode collisionDetectionMode;
}
