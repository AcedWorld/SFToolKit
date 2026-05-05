using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000160 RID: 352
	public class FBIKHandsOnProp : MonoBehaviour
	{
		// Token: 0x06000A84 RID: 2692 RVA: 0x00042DBF File Offset: 0x00040FBF
		private void Awake()
		{
			IKSolverFullBodyBiped solver = this.ik.solver;
			solver.OnPreRead = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreRead, new IKSolver.UpdateDelegate(this.OnPreRead));
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00042DF0 File Offset: 0x00040FF0
		private void OnPreRead()
		{
			if (this.leftHanded)
			{
				this.HandsOnProp(this.ik.solver.leftHandEffector, this.ik.solver.rightHandEffector);
				return;
			}
			this.HandsOnProp(this.ik.solver.rightHandEffector, this.ik.solver.leftHandEffector);
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x00042E54 File Offset: 0x00041054
		private void HandsOnProp(IKEffector mainHand, IKEffector otherHand)
		{
			Vector3 vector = otherHand.bone.position - mainHand.bone.position;
			Vector3 point = Quaternion.Inverse(mainHand.bone.rotation) * vector;
			Vector3 b = mainHand.bone.position + vector * 0.5f;
			Quaternion rhs = Quaternion.Inverse(mainHand.bone.rotation) * otherHand.bone.rotation;
			Vector3 toDirection = otherHand.bone.position + otherHand.positionOffset - (mainHand.bone.position + mainHand.positionOffset);
			Vector3 a = mainHand.bone.position + mainHand.positionOffset + vector * 0.5f;
			mainHand.position = mainHand.bone.position + mainHand.positionOffset + (a - b);
			mainHand.positionWeight = 1f;
			Quaternion lhs = Quaternion.FromToRotation(vector, toDirection);
			mainHand.bone.rotation = lhs * mainHand.bone.rotation;
			otherHand.position = mainHand.position + mainHand.bone.rotation * point;
			otherHand.positionWeight = 1f;
			otherHand.bone.rotation = mainHand.bone.rotation * rhs;
			this.ik.solver.leftArmMapping.maintainRotationWeight = 1f;
			this.ik.solver.rightArmMapping.maintainRotationWeight = 1f;
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x00043004 File Offset: 0x00041204
		private void OnDestroy()
		{
			if (this.ik != null)
			{
				IKSolverFullBodyBiped solver = this.ik.solver;
				solver.OnPreRead = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPreRead, new IKSolver.UpdateDelegate(this.OnPreRead));
			}
		}

		// Token: 0x04000A33 RID: 2611
		public FullBodyBipedIK ik;

		// Token: 0x04000A34 RID: 2612
		public bool leftHanded;
	}
}
