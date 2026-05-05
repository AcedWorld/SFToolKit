using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x0200001B RID: 27
	[Serializable]
	public class BipedLimbOrientations
	{
		// Token: 0x06000083 RID: 131 RVA: 0x00004BAA File Offset: 0x00002DAA
		public BipedLimbOrientations(BipedLimbOrientations.LimbOrientation leftArm, BipedLimbOrientations.LimbOrientation rightArm, BipedLimbOrientations.LimbOrientation leftLeg, BipedLimbOrientations.LimbOrientation rightLeg)
		{
			this.leftArm = leftArm;
			this.rightArm = rightArm;
			this.leftLeg = leftLeg;
			this.rightLeg = rightLeg;
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00004BD0 File Offset: 0x00002DD0
		public static BipedLimbOrientations UMA
		{
			get
			{
				return new BipedLimbOrientations(new BipedLimbOrientations.LimbOrientation(Vector3.forward, Vector3.forward, Vector3.forward), new BipedLimbOrientations.LimbOrientation(Vector3.forward, Vector3.forward, Vector3.back), new BipedLimbOrientations.LimbOrientation(Vector3.forward, Vector3.forward, Vector3.down), new BipedLimbOrientations.LimbOrientation(Vector3.forward, Vector3.forward, Vector3.down));
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00004C34 File Offset: 0x00002E34
		public static BipedLimbOrientations MaxBiped
		{
			get
			{
				return new BipedLimbOrientations(new BipedLimbOrientations.LimbOrientation(Vector3.down, Vector3.down, Vector3.down), new BipedLimbOrientations.LimbOrientation(Vector3.down, Vector3.down, Vector3.up), new BipedLimbOrientations.LimbOrientation(Vector3.up, Vector3.up, Vector3.back), new BipedLimbOrientations.LimbOrientation(Vector3.up, Vector3.up, Vector3.back));
			}
		}

		// Token: 0x040000AE RID: 174
		public BipedLimbOrientations.LimbOrientation leftArm;

		// Token: 0x040000AF RID: 175
		public BipedLimbOrientations.LimbOrientation rightArm;

		// Token: 0x040000B0 RID: 176
		public BipedLimbOrientations.LimbOrientation leftLeg;

		// Token: 0x040000B1 RID: 177
		public BipedLimbOrientations.LimbOrientation rightLeg;

		// Token: 0x0200001C RID: 28
		[Serializable]
		public class LimbOrientation
		{
			// Token: 0x06000086 RID: 134 RVA: 0x00004C96 File Offset: 0x00002E96
			public LimbOrientation(Vector3 upperBoneForwardAxis, Vector3 lowerBoneForwardAxis, Vector3 lastBoneLeftAxis)
			{
				this.upperBoneForwardAxis = upperBoneForwardAxis;
				this.lowerBoneForwardAxis = lowerBoneForwardAxis;
				this.lastBoneLeftAxis = lastBoneLeftAxis;
			}

			// Token: 0x040000B2 RID: 178
			public Vector3 upperBoneForwardAxis;

			// Token: 0x040000B3 RID: 179
			public Vector3 lowerBoneForwardAxis;

			// Token: 0x040000B4 RID: 180
			public Vector3 lastBoneLeftAxis;
		}
	}
}
