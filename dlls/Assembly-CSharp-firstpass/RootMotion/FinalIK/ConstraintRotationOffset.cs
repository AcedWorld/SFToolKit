using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000098 RID: 152
	[Serializable]
	public class ConstraintRotationOffset : Constraint
	{
		// Token: 0x06000499 RID: 1177 RVA: 0x0001C360 File Offset: 0x0001A560
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
			if (!this.initiated)
			{
				this.defaultLocalRotation = this.transform.localRotation;
				this.lastLocalRotation = this.transform.localRotation;
				this.initiated = true;
			}
			if (this.rotationChanged)
			{
				this.defaultLocalRotation = this.transform.localRotation;
			}
			this.transform.localRotation = this.defaultLocalRotation;
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.offset, this.weight);
			this.lastLocalRotation = this.transform.localRotation;
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0001C239 File Offset: 0x0001A439
		public ConstraintRotationOffset()
		{
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0001C241 File Offset: 0x0001A441
		public ConstraintRotationOffset(Transform transform)
		{
			this.transform = transform;
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600049C RID: 1180 RVA: 0x0001C417 File Offset: 0x0001A617
		private bool rotationChanged
		{
			get
			{
				return this.transform.localRotation != this.lastLocalRotation;
			}
		}

		// Token: 0x04000412 RID: 1042
		public Quaternion offset;

		// Token: 0x04000413 RID: 1043
		private Quaternion defaultRotation;

		// Token: 0x04000414 RID: 1044
		private Quaternion defaultLocalRotation;

		// Token: 0x04000415 RID: 1045
		private Quaternion lastLocalRotation;

		// Token: 0x04000416 RID: 1046
		private Quaternion defaultTargetLocalRotation;

		// Token: 0x04000417 RID: 1047
		private bool initiated;
	}
}
