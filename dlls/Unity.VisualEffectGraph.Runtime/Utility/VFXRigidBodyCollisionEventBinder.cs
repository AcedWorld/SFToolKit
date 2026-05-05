using System;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000022 RID: 34
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(Collider))]
	internal class VFXRigidBodyCollisionEventBinder : VFXEventBinderBase
	{
		// Token: 0x060000B7 RID: 183 RVA: 0x00006A00 File Offset: 0x00004C00
		protected override void SetEventAttribute(object[] parameters)
		{
			ContactPoint contactPoint = (ContactPoint)parameters[0];
			this.eventAttribute.SetVector3(this.positionParameter, contactPoint.point);
			this.eventAttribute.SetVector3(this.directionParameter, contactPoint.normal);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00006A50 File Offset: 0x00004C50
		private void OnCollisionEnter(Collision collision)
		{
			foreach (ContactPoint contactPoint in collision.contacts)
			{
				base.SendEventToVisualEffect(new object[]
				{
					contactPoint
				});
			}
		}

		// Token: 0x0400008A RID: 138
		private ExposedProperty positionParameter = "position";

		// Token: 0x0400008B RID: 139
		private ExposedProperty directionParameter = "velocity";
	}
}
