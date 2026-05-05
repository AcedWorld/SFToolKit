using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000BB RID: 187
	public class FBBIKArmBending : MonoBehaviour
	{
		// Token: 0x060005BD RID: 1469 RVA: 0x000215D8 File Offset: 0x0001F7D8
		private void LateUpdate()
		{
			if (this.ik == null)
			{
				return;
			}
			if (!this.initiated)
			{
				IKSolverFullBodyBiped solver = this.ik.solver;
				solver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostFBBIK));
				this.initiated = true;
			}
			if (this.ik.solver.leftHandEffector.target != null)
			{
				Vector3 left = Vector3.left;
				this.ik.solver.leftArmChain.bendConstraint.direction = this.ik.solver.leftHandEffector.target.rotation * left + this.ik.solver.leftHandEffector.target.rotation * this.bendDirectionOffsetLeft + this.ik.transform.rotation * this.characterSpaceBendOffsetLeft;
				this.ik.solver.leftArmChain.bendConstraint.weight = 1f;
			}
			if (this.ik.solver.rightHandEffector.target != null)
			{
				Vector3 right = Vector3.right;
				this.ik.solver.rightArmChain.bendConstraint.direction = this.ik.solver.rightHandEffector.target.rotation * right + this.ik.solver.rightHandEffector.target.rotation * this.bendDirectionOffsetRight + this.ik.transform.rotation * this.characterSpaceBendOffsetRight;
				this.ik.solver.rightArmChain.bendConstraint.weight = 1f;
			}
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x000217C4 File Offset: 0x0001F9C4
		private void OnPostFBBIK()
		{
			if (this.ik == null)
			{
				return;
			}
			if (this.ik.solver.leftHandEffector.target != null)
			{
				this.ik.references.leftHand.rotation = this.ik.solver.leftHandEffector.target.rotation;
			}
			if (this.ik.solver.rightHandEffector.target != null)
			{
				this.ik.references.rightHand.rotation = this.ik.solver.rightHandEffector.target.rotation;
			}
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x00021878 File Offset: 0x0001FA78
		private void OnDestroy()
		{
			if (this.ik != null)
			{
				IKSolverFullBodyBiped solver = this.ik.solver;
				solver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPostUpdate, new IKSolver.UpdateDelegate(this.OnPostFBBIK));
			}
		}

		// Token: 0x040004E7 RID: 1255
		public FullBodyBipedIK ik;

		// Token: 0x040004E8 RID: 1256
		public Vector3 bendDirectionOffsetLeft;

		// Token: 0x040004E9 RID: 1257
		public Vector3 bendDirectionOffsetRight;

		// Token: 0x040004EA RID: 1258
		public Vector3 characterSpaceBendOffsetLeft;

		// Token: 0x040004EB RID: 1259
		public Vector3 characterSpaceBendOffsetRight;

		// Token: 0x040004EC RID: 1260
		private Quaternion leftHandTargetRotation;

		// Token: 0x040004ED RID: 1261
		private Quaternion rightHandTargetRotation;

		// Token: 0x040004EE RID: 1262
		private bool initiated;
	}
}
