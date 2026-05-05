using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000096 RID: 150
	[Serializable]
	public class ConstraintPositionOffset : Constraint
	{
		// Token: 0x06000492 RID: 1170 RVA: 0x0001C250 File Offset: 0x0001A450
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
				this.defaultLocalPosition = this.transform.localPosition;
				this.lastLocalPosition = this.transform.localPosition;
				this.initiated = true;
			}
			if (this.positionChanged)
			{
				this.defaultLocalPosition = this.transform.localPosition;
			}
			this.transform.localPosition = this.defaultLocalPosition;
			this.transform.position += this.offset * this.weight;
			this.lastLocalPosition = this.transform.localPosition;
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0001C239 File Offset: 0x0001A439
		public ConstraintPositionOffset()
		{
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0001C241 File Offset: 0x0001A441
		public ConstraintPositionOffset(Transform transform)
		{
			this.transform = transform;
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x0001C307 File Offset: 0x0001A507
		private bool positionChanged
		{
			get
			{
				return this.transform.localPosition != this.lastLocalPosition;
			}
		}

		// Token: 0x0400040D RID: 1037
		public Vector3 offset;

		// Token: 0x0400040E RID: 1038
		private Vector3 defaultLocalPosition;

		// Token: 0x0400040F RID: 1039
		private Vector3 lastLocalPosition;

		// Token: 0x04000410 RID: 1040
		private bool initiated;
	}
}
