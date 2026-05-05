using System;
using UnityEngine;

// Token: 0x0200003F RID: 63
public class vTeleport : MonoBehaviour
{
	// Token: 0x060000F1 RID: 241 RVA: 0x00008B2C File Offset: 0x00006D2C
	public void Teleport(Collider collider)
	{
		Vector3 vector = base.transform.InverseTransformPoint(this.includeRoot ? collider.transform.root.position : collider.transform.position);
		Vector3 direction = base.transform.InverseTransformDirection(this.includeRoot ? collider.transform.root.forward : collider.transform.forward);
		vector.Set(0f, vector.y, 0f);
		if (this.includeRoot)
		{
			collider.transform.root.position = this.targetPoint.TransformPoint(vector);
			if (this.rotateToTargetForward)
			{
				collider.transform.root.rotation = this.targetPoint.rotation;
				return;
			}
			collider.transform.root.forward = this.targetPoint.TransformDirection(direction);
			return;
		}
		else
		{
			collider.transform.position = this.targetPoint.TransformPoint(vector);
			if (this.rotateToTargetForward)
			{
				collider.transform.rotation = this.targetPoint.rotation;
				return;
			}
			collider.transform.forward = this.targetPoint.TransformDirection(direction);
			return;
		}
	}

	// Token: 0x04000120 RID: 288
	public Transform targetPoint;

	// Token: 0x04000121 RID: 289
	public bool includeRoot;

	// Token: 0x04000122 RID: 290
	public bool rotateToTargetForward = true;
}
