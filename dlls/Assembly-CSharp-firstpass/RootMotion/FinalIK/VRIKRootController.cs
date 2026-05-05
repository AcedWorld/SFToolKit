using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000145 RID: 325
	public class VRIKRootController : MonoBehaviour
	{
		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000A19 RID: 2585 RVA: 0x0003FFC4 File Offset: 0x0003E1C4
		// (set) Token: 0x06000A1A RID: 2586 RVA: 0x0003FFCC File Offset: 0x0003E1CC
		public Vector3 pelvisTargetRight { get; private set; }

		// Token: 0x06000A1B RID: 2587 RVA: 0x0003FFD5 File Offset: 0x0003E1D5
		private void Awake()
		{
			this.ik = base.GetComponent<VRIK>();
			IKSolverVR solver = this.ik.solver;
			solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnPreUpdate));
			this.Calibrate();
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x00040018 File Offset: 0x0003E218
		public void Calibrate()
		{
			if (this.ik == null)
			{
				Debug.LogError("No VRIK found on VRIKRootController's GameObject.", base.transform);
				return;
			}
			this.pelvisTarget = this.ik.solver.spine.pelvisTarget;
			this.leftFootTarget = this.ik.solver.leftLeg.target;
			this.rightFootTarget = this.ik.solver.rightLeg.target;
			if (this.pelvisTarget != null)
			{
				this.pelvisTargetRight = Quaternion.Inverse(this.pelvisTarget.rotation) * this.ik.references.root.right;
			}
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x000400D4 File Offset: 0x0003E2D4
		public void Calibrate(VRIKCalibrator.CalibrationData data)
		{
			if (this.ik == null)
			{
				Debug.LogError("No VRIK found on VRIKRootController's GameObject.", base.transform);
				return;
			}
			this.pelvisTarget = this.ik.solver.spine.pelvisTarget;
			this.leftFootTarget = this.ik.solver.leftLeg.target;
			this.rightFootTarget = this.ik.solver.rightLeg.target;
			if (this.pelvisTarget != null)
			{
				this.pelvisTargetRight = data.pelvisTargetRight;
			}
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x0004016C File Offset: 0x0003E36C
		private void OnPreUpdate()
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.pelvisTarget != null)
			{
				this.ik.references.root.position = new Vector3(this.pelvisTarget.position.x, this.ik.references.root.position.y, this.pelvisTarget.position.z);
				Vector3 forward = Vector3.Cross(this.pelvisTarget.rotation * this.pelvisTargetRight, this.ik.references.root.up);
				forward.y = 0f;
				this.ik.references.root.rotation = Quaternion.LookRotation(forward);
				this.ik.references.pelvis.position = Vector3.Lerp(this.ik.references.pelvis.position, this.pelvisTarget.position, this.ik.solver.spine.pelvisPositionWeight);
				this.ik.references.pelvis.rotation = Quaternion.Slerp(this.ik.references.pelvis.rotation, this.pelvisTarget.rotation, this.ik.solver.spine.pelvisRotationWeight);
				return;
			}
			if (this.leftFootTarget != null && this.rightFootTarget != null)
			{
				this.ik.references.root.position = Vector3.Lerp(this.leftFootTarget.position, this.rightFootTarget.position, 0.5f);
			}
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x0004032F File Offset: 0x0003E52F
		private void OnDestroy()
		{
			if (this.ik != null)
			{
				IKSolverVR solver = this.ik.solver;
				solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnPreUpdate));
			}
		}

		// Token: 0x04000977 RID: 2423
		private Transform pelvisTarget;

		// Token: 0x04000978 RID: 2424
		private Transform leftFootTarget;

		// Token: 0x04000979 RID: 2425
		private Transform rightFootTarget;

		// Token: 0x0400097A RID: 2426
		private VRIK ik;
	}
}
