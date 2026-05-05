using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000097 RID: 151
	[Serializable]
	public class ConstraintRotation : Constraint
	{
		// Token: 0x06000496 RID: 1174 RVA: 0x0001C31F File Offset: 0x0001A51F
		public override void UpdateConstraint()
		{
			if (this.weight <= 0f)
			{
				return;
			}
			if (!base.isValid)
			{
				return;
			}
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.rotation, this.weight);
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0001C239 File Offset: 0x0001A439
		public ConstraintRotation()
		{
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0001C241 File Offset: 0x0001A441
		public ConstraintRotation(Transform transform)
		{
			this.transform = transform;
		}

		// Token: 0x04000411 RID: 1041
		public Quaternion rotation;
	}
}
