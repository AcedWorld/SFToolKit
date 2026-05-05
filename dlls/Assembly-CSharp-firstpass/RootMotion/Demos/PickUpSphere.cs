using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000173 RID: 371
	public class PickUpSphere : PickUp2Handed
	{
		// Token: 0x06000ACF RID: 2767 RVA: 0x0004529C File Offset: 0x0004349C
		protected override void RotatePivot()
		{
			Vector3 b = Vector3.Lerp(this.interactionSystem.ik.solver.leftHandEffector.bone.position, this.interactionSystem.ik.solver.rightHandEffector.bone.position, 0.5f);
			Vector3 forward = this.obj.transform.position - b;
			this.pivot.rotation = Quaternion.LookRotation(forward);
		}
	}
}
