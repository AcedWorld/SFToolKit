using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200017D RID: 381
	public class TwoHandedProp : MonoBehaviour
	{
		// Token: 0x06000AFB RID: 2811 RVA: 0x00045D88 File Offset: 0x00043F88
		private void Start()
		{
			this.ik = base.GetComponent<FullBodyBipedIK>();
			IKSolverFullBodyBiped solver = this.ik.solver;
			solver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPostUpdate, new IKSolver.UpdateDelegate(this.AfterFBBIK));
			if (this.ik.solver.rightHandEffector.target == null)
			{
				Debug.LogError("Right Hand Effector needs a Target in this demo.");
			}
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x00045DF4 File Offset: 0x00043FF4
		private void LateUpdate()
		{
			this.targetPosRelativeToRight = this.ik.references.rightHand.InverseTransformPoint(this.leftHandTarget.position);
			this.targetRotRelativeToRight = Quaternion.Inverse(this.ik.references.rightHand.rotation) * this.leftHandTarget.rotation;
			this.ik.solver.leftHandEffector.position = this.ik.solver.rightHandEffector.target.position + this.ik.solver.rightHandEffector.target.rotation * this.targetPosRelativeToRight;
			this.ik.solver.leftHandEffector.rotation = this.ik.solver.rightHandEffector.target.rotation * this.targetRotRelativeToRight;
			this.ik.solver.rightHandEffector.positionWeight = this.weight;
			float positionWeight = this.leftHandWeight * this.weight;
			this.ik.solver.leftHandEffector.positionWeight = positionWeight;
			this.leftHandPoser.weight = positionWeight;
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x00045F38 File Offset: 0x00044138
		private void AfterFBBIK()
		{
			this.ik.solver.leftHandEffector.bone.rotation = Quaternion.Slerp(this.ik.solver.leftHandEffector.bone.rotation, this.ik.solver.leftHandEffector.rotation, this.leftHandWeight * this.weight);
			this.ik.solver.rightHandEffector.bone.rotation = Quaternion.Slerp(this.ik.solver.rightHandEffector.bone.rotation, this.ik.solver.rightHandEffector.rotation, this.weight);
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x00045FF4 File Offset: 0x000441F4
		private void OnDestroy()
		{
			if (this.ik != null)
			{
				IKSolverFullBodyBiped solver = this.ik.solver;
				solver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPostUpdate, new IKSolver.UpdateDelegate(this.AfterFBBIK));
			}
		}

		// Token: 0x04000ADB RID: 2779
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x04000ADC RID: 2780
		[Tooltip("The left hand target parented to the right hand.")]
		public Transform leftHandTarget;

		// Token: 0x04000ADD RID: 2781
		[Tooltip("Left hand poser (poses fingers to match the left hand target).")]
		public Poser leftHandPoser;

		// Token: 0x04000ADE RID: 2782
		[Tooltip("The weight of pinning the left hand to the prop.")]
		[Range(0f, 1f)]
		public float leftHandWeight = 1f;

		// Token: 0x04000ADF RID: 2783
		private FullBodyBipedIK ik;

		// Token: 0x04000AE0 RID: 2784
		private Vector3 targetPosRelativeToRight;

		// Token: 0x04000AE1 RID: 2785
		private Quaternion targetRotRelativeToRight;
	}
}
