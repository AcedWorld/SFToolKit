using System;

namespace RootMotion.FinalIK
{
	// Token: 0x020000B2 RID: 178
	public abstract class IK : SolverManager
	{
		// Token: 0x06000582 RID: 1410
		public abstract IKSolver GetIKSolver();

		// Token: 0x06000583 RID: 1411 RVA: 0x00020999 File Offset: 0x0001EB99
		protected override void UpdateSolver()
		{
			if (!this.GetIKSolver().initiated)
			{
				this.InitiateSolver();
			}
			if (!this.GetIKSolver().initiated)
			{
				return;
			}
			this.GetIKSolver().Update();
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x000209C7 File Offset: 0x0001EBC7
		protected override void InitiateSolver()
		{
			if (this.GetIKSolver().initiated)
			{
				return;
			}
			this.GetIKSolver().Initiate(base.transform);
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x000209E8 File Offset: 0x0001EBE8
		protected override void FixTransforms()
		{
			if (!this.GetIKSolver().initiated)
			{
				return;
			}
			this.GetIKSolver().FixTransforms();
		}

		// Token: 0x06000586 RID: 1414
		protected abstract void OpenUserManual();

		// Token: 0x06000587 RID: 1415
		protected abstract void OpenScriptReference();
	}
}
