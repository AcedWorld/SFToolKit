using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000188 RID: 392
	public class VRIKArmMocap : MonoBehaviour
	{
		// Token: 0x06000B1F RID: 2847 RVA: 0x00046833 File Offset: 0x00044A33
		private void Start()
		{
			IKSolverVR solver = this.ik.solver;
			solver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPostUpdate, new IKSolver.UpdateDelegate(this.AfterVRIK));
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x00046864 File Offset: 0x00044A64
		private void AfterVRIK()
		{
			VRIKArmMocap.UpdateArm(this.ik.references.leftUpperArm, this.ik.references.leftForearm, this.ik.references.leftHand, this.leftElbowTarget, this.ik.solver.leftArm.target);
			VRIKArmMocap.UpdateArm(this.ik.references.rightUpperArm, this.ik.references.rightForearm, this.ik.references.rightHand, this.rightElbowTarget, this.ik.solver.rightArm.target);
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x00046914 File Offset: 0x00044B14
		private static void UpdateArm(Transform upperArm, Transform forearm, Transform hand, Transform elbowTarget, Transform handTarget)
		{
			if (elbowTarget == null)
			{
				return;
			}
			if (handTarget == null)
			{
				return;
			}
			upperArm.rotation = Quaternion.FromToRotation(forearm.position - upperArm.position, elbowTarget.position - upperArm.position) * upperArm.rotation;
			forearm.rotation = Quaternion.FromToRotation(hand.position - forearm.position, handTarget.position - forearm.position) * forearm.rotation;
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x000469A7 File Offset: 0x00044BA7
		private void OnDestroy()
		{
			if (this.ik != null)
			{
				IKSolverVR solver = this.ik.solver;
				solver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPostUpdate, new IKSolver.UpdateDelegate(this.AfterVRIK));
			}
		}

		// Token: 0x04000B0B RID: 2827
		public VRIK ik;

		// Token: 0x04000B0C RID: 2828
		public Transform leftElbowTarget;

		// Token: 0x04000B0D RID: 2829
		public Transform rightElbowTarget;
	}
}
