using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x0200011C RID: 284
	public class CCDBendGoal : MonoBehaviour
	{
		// Token: 0x0600095E RID: 2398 RVA: 0x0003B719 File Offset: 0x00039919
		private void Start()
		{
			IKSolverCCD solver = this.ik.solver;
			solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.BeforeIK));
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0003B748 File Offset: 0x00039948
		private void BeforeIK()
		{
			if (!base.enabled)
			{
				return;
			}
			float num = this.ik.solver.IKPositionWeight * this.weight;
			if (num <= 0f)
			{
				return;
			}
			Vector3 position = this.ik.solver.bones[0].transform.position;
			Quaternion quaternion = Quaternion.FromToRotation(this.ik.solver.bones[this.ik.solver.bones.Length - 1].transform.position - position, base.transform.position - position);
			if (num < 1f)
			{
				quaternion = Quaternion.Slerp(Quaternion.identity, quaternion, num);
			}
			this.ik.solver.bones[0].transform.rotation = quaternion * this.ik.solver.bones[0].transform.rotation;
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x0003B83B File Offset: 0x00039A3B
		private void OnDestroy()
		{
			if (this.ik != null)
			{
				IKSolverCCD solver = this.ik.solver;
				solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.BeforeIK));
			}
		}

		// Token: 0x0400089F RID: 2207
		public CCDIK ik;

		// Token: 0x040008A0 RID: 2208
		[Range(0f, 1f)]
		public float weight = 1f;
	}
}
