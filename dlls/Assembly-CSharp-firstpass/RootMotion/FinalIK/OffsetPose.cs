using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000136 RID: 310
	public class OffsetPose : MonoBehaviour
	{
		// Token: 0x060009E0 RID: 2528 RVA: 0x0003D914 File Offset: 0x0003BB14
		public void Apply(IKSolverFullBodyBiped solver, float weight)
		{
			for (int i = 0; i < this.effectorLinks.Length; i++)
			{
				this.effectorLinks[i].Apply(solver, weight, solver.GetRoot().rotation);
			}
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x0003D950 File Offset: 0x0003BB50
		public void Apply(IKSolverFullBodyBiped solver, float weight, Quaternion rotation)
		{
			for (int i = 0; i < this.effectorLinks.Length; i++)
			{
				this.effectorLinks[i].Apply(solver, weight, rotation);
			}
		}

		// Token: 0x0400091C RID: 2332
		public OffsetPose.EffectorLink[] effectorLinks = new OffsetPose.EffectorLink[0];

		// Token: 0x02000137 RID: 311
		[Serializable]
		public class EffectorLink
		{
			// Token: 0x060009E3 RID: 2531 RVA: 0x0003D994 File Offset: 0x0003BB94
			public void Apply(IKSolverFullBodyBiped solver, float weight, Quaternion rotation)
			{
				solver.GetEffector(this.effector).positionOffset += rotation * this.offset * weight;
				Vector3 vector = solver.GetRoot().position + rotation * this.pin - solver.GetEffector(this.effector).bone.position;
				Vector3 vector2 = this.pinWeight * Mathf.Abs(weight);
				solver.GetEffector(this.effector).positionOffset = new Vector3(Mathf.Lerp(solver.GetEffector(this.effector).positionOffset.x, vector.x, vector2.x), Mathf.Lerp(solver.GetEffector(this.effector).positionOffset.y, vector.y, vector2.y), Mathf.Lerp(solver.GetEffector(this.effector).positionOffset.z, vector.z, vector2.z));
			}

			// Token: 0x0400091D RID: 2333
			public FullBodyBipedEffector effector;

			// Token: 0x0400091E RID: 2334
			public Vector3 offset;

			// Token: 0x0400091F RID: 2335
			public Vector3 pin;

			// Token: 0x04000920 RID: 2336
			public Vector3 pinWeight;
		}
	}
}
