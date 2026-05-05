using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000172 RID: 370
	public class PickUpBox : PickUp2Handed
	{
		// Token: 0x06000ACD RID: 2765 RVA: 0x000451C4 File Offset: 0x000433C4
		protected override void RotatePivot()
		{
			Vector3 normalized = (this.pivot.position - this.interactionSystem.transform.position).normalized;
			normalized.y = 0f;
			Vector3 axis = QuaTools.GetAxis(this.obj.transform.InverseTransformDirection(normalized));
			Vector3 axis2 = QuaTools.GetAxis(this.obj.transform.InverseTransformDirection(this.interactionSystem.transform.up));
			this.pivot.localRotation = Quaternion.LookRotation(axis, axis2);
			Quaternion lhs = QuaTools.FromToRotation(this.pivot.rotation, this.interactionSystem.transform.rotation);
			this.holdPoint.rotation = lhs * this.holdPoint.rotation;
		}
	}
}
