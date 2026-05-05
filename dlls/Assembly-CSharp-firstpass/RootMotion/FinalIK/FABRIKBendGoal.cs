using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000120 RID: 288
	public class FABRIKBendGoal : MonoBehaviour
	{
		// Token: 0x06000972 RID: 2418 RVA: 0x0003BF49 File Offset: 0x0003A149
		private void Start()
		{
			IKSolverFABRIK solver = this.ik.solver;
			solver.OnPreIteration = (IKSolver.IterationDelegate)Delegate.Combine(solver.OnPreIteration, new IKSolver.IterationDelegate(this.OnPreIteration));
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x0003BF78 File Offset: 0x0003A178
		private void OnPreIteration(int it)
		{
			if (it != 0)
			{
				return;
			}
			if (this.weight <= 0f)
			{
				return;
			}
			Vector3 vector = base.transform.position - this.ik.solver.bones[0].transform.position;
			vector *= this.weight;
			IKSolver.Bone[] bones = this.ik.solver.bones;
			for (int i = 0; i < bones.Length; i++)
			{
				bones[i].solverPosition += vector;
			}
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x0003C004 File Offset: 0x0003A204
		private void OnDestroy()
		{
			if (this.ik != null)
			{
				IKSolverFABRIK solver = this.ik.solver;
				solver.OnPreIteration = (IKSolver.IterationDelegate)Delegate.Remove(solver.OnPreIteration, new IKSolver.IterationDelegate(this.OnPreIteration));
			}
		}

		// Token: 0x040008AB RID: 2219
		public FABRIK ik;

		// Token: 0x040008AC RID: 2220
		[Range(0f, 1f)]
		public float weight = 1f;
	}
}
