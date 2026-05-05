using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000093 RID: 147
	[Serializable]
	public class BipedIKSolvers
	{
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000488 RID: 1160 RVA: 0x0001BF7C File Offset: 0x0001A17C
		public IKSolverLimb[] limbs
		{
			get
			{
				if (this._limbs == null || (this._limbs != null && this._limbs.Length != 4))
				{
					this._limbs = new IKSolverLimb[]
					{
						this.leftFoot,
						this.rightFoot,
						this.leftHand,
						this.rightHand
					};
				}
				return this._limbs;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x0001BFDC File Offset: 0x0001A1DC
		public IKSolver[] ikSolvers
		{
			get
			{
				if (this._ikSolvers == null || (this._ikSolvers != null && this._ikSolvers.Length != 7))
				{
					this._ikSolvers = new IKSolver[]
					{
						this.leftFoot,
						this.rightFoot,
						this.leftHand,
						this.rightHand,
						this.spine,
						this.lookAt,
						this.aim
					};
				}
				return this._ikSolvers;
			}
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0001C058 File Offset: 0x0001A258
		public void AssignReferences(BipedReferences references)
		{
			this.leftHand.SetChain(references.leftUpperArm, references.leftForearm, references.leftHand, references.root);
			this.rightHand.SetChain(references.rightUpperArm, references.rightForearm, references.rightHand, references.root);
			this.leftFoot.SetChain(references.leftThigh, references.leftCalf, references.leftFoot, references.root);
			this.rightFoot.SetChain(references.rightThigh, references.rightCalf, references.rightFoot, references.root);
			this.spine.SetChain(references.spine, references.root);
			this.lookAt.SetChain(references.spine, references.head, references.eyes, references.root);
			this.aim.SetChain(references.spine, references.root);
			this.leftFoot.goal = AvatarIKGoal.LeftFoot;
			this.rightFoot.goal = AvatarIKGoal.RightFoot;
			this.leftHand.goal = AvatarIKGoal.LeftHand;
			this.rightHand.goal = AvatarIKGoal.RightHand;
		}

		// Token: 0x04000400 RID: 1024
		public IKSolverLimb leftFoot = new IKSolverLimb(AvatarIKGoal.LeftFoot);

		// Token: 0x04000401 RID: 1025
		public IKSolverLimb rightFoot = new IKSolverLimb(AvatarIKGoal.RightFoot);

		// Token: 0x04000402 RID: 1026
		public IKSolverLimb leftHand = new IKSolverLimb(AvatarIKGoal.LeftHand);

		// Token: 0x04000403 RID: 1027
		public IKSolverLimb rightHand = new IKSolverLimb(AvatarIKGoal.RightHand);

		// Token: 0x04000404 RID: 1028
		public IKSolverFABRIK spine = new IKSolverFABRIK();

		// Token: 0x04000405 RID: 1029
		public IKSolverLookAt lookAt = new IKSolverLookAt();

		// Token: 0x04000406 RID: 1030
		public IKSolverAim aim = new IKSolverAim();

		// Token: 0x04000407 RID: 1031
		public Constraints pelvis = new Constraints();

		// Token: 0x04000408 RID: 1032
		private IKSolverLimb[] _limbs;

		// Token: 0x04000409 RID: 1033
		private IKSolver[] _ikSolvers;
	}
}
