using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200015A RID: 346
	public class EffectorOffset : OffsetModifier
	{
		// Token: 0x06000A72 RID: 2674 RVA: 0x000425C0 File Offset: 0x000407C0
		protected override void OnModifyOffset()
		{
			this.ik.solver.leftHandEffector.maintainRelativePositionWeight = this.handsMaintainRelativePositionWeight;
			this.ik.solver.rightHandEffector.maintainRelativePositionWeight = this.handsMaintainRelativePositionWeight;
			this.ik.solver.bodyEffector.positionOffset += base.transform.rotation * this.bodyOffset * this.weight;
			this.ik.solver.leftShoulderEffector.positionOffset += base.transform.rotation * this.leftShoulderOffset * this.weight;
			this.ik.solver.rightShoulderEffector.positionOffset += base.transform.rotation * this.rightShoulderOffset * this.weight;
			this.ik.solver.leftThighEffector.positionOffset += base.transform.rotation * this.leftThighOffset * this.weight;
			this.ik.solver.rightThighEffector.positionOffset += base.transform.rotation * this.rightThighOffset * this.weight;
			this.ik.solver.leftHandEffector.positionOffset += base.transform.rotation * this.leftHandOffset * this.weight;
			this.ik.solver.rightHandEffector.positionOffset += base.transform.rotation * this.rightHandOffset * this.weight;
			this.ik.solver.leftFootEffector.positionOffset += base.transform.rotation * this.leftFootOffset * this.weight;
			this.ik.solver.rightFootEffector.positionOffset += base.transform.rotation * this.rightFootOffset * this.weight;
		}

		// Token: 0x04000A08 RID: 2568
		[Range(0f, 1f)]
		public float handsMaintainRelativePositionWeight;

		// Token: 0x04000A09 RID: 2569
		public Vector3 bodyOffset;

		// Token: 0x04000A0A RID: 2570
		public Vector3 leftShoulderOffset;

		// Token: 0x04000A0B RID: 2571
		public Vector3 rightShoulderOffset;

		// Token: 0x04000A0C RID: 2572
		public Vector3 leftThighOffset;

		// Token: 0x04000A0D RID: 2573
		public Vector3 rightThighOffset;

		// Token: 0x04000A0E RID: 2574
		public Vector3 leftHandOffset;

		// Token: 0x04000A0F RID: 2575
		public Vector3 rightHandOffset;

		// Token: 0x04000A10 RID: 2576
		public Vector3 leftFootOffset;

		// Token: 0x04000A11 RID: 2577
		public Vector3 rightFootOffset;
	}
}
