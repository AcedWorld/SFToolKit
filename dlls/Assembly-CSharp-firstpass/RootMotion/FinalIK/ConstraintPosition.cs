using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000095 RID: 149
	[Serializable]
	public class ConstraintPosition : Constraint
	{
		// Token: 0x0600048F RID: 1167 RVA: 0x0001C1F9 File Offset: 0x0001A3F9
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
			this.transform.position = Vector3.Lerp(this.transform.position, this.position, this.weight);
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0001C239 File Offset: 0x0001A439
		public ConstraintPosition()
		{
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0001C241 File Offset: 0x0001A441
		public ConstraintPosition(Transform transform)
		{
			this.transform = transform;
		}

		// Token: 0x0400040C RID: 1036
		public Vector3 position;
	}
}
