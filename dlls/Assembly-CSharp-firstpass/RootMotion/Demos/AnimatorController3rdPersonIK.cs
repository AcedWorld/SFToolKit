using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000157 RID: 343
	public class AnimatorController3rdPersonIK : AnimatorController3rdPerson
	{
		// Token: 0x06000A60 RID: 2656 RVA: 0x00041F0C File Offset: 0x0004010C
		protected override void Start()
		{
			base.Start();
			this.aim = base.GetComponent<AimIK>();
			this.ik = base.GetComponent<FullBodyBipedIK>();
			IKSolverFullBodyBiped solver = this.ik.solver;
			solver.OnPreRead = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreRead, new IKSolver.UpdateDelegate(this.OnPreRead));
			this.aim.enabled = false;
			this.ik.enabled = false;
			this.headLookAxis = this.ik.references.head.InverseTransformVector(this.ik.references.root.forward);
			this.animator.SetLayerWeight(1, 1f);
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x00041FBC File Offset: 0x000401BC
		public override void Move(Vector3 moveInput, bool isMoving, Vector3 faceDirection, Vector3 aimTarget)
		{
			base.Move(moveInput, isMoving, faceDirection, aimTarget);
			this.aimTarget = aimTarget;
			this.Read();
			this.AimIK();
			this.FBBIK();
			this.AimIK();
			this.HeadLookAt(aimTarget);
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x00041FF4 File Offset: 0x000401F4
		private void Read()
		{
			this.leftHandPosRelToRightHand = this.ik.references.rightHand.InverseTransformPoint(this.ik.references.leftHand.position);
			this.leftHandRotRelToRightHand = Quaternion.Inverse(this.ik.references.rightHand.rotation) * this.ik.references.leftHand.rotation;
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x0004206B File Offset: 0x0004026B
		private void AimIK()
		{
			this.aim.solver.IKPosition = this.aimTarget;
			this.aim.solver.Update();
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x00042094 File Offset: 0x00040294
		private void FBBIK()
		{
			this.rightHandRotation = this.ik.references.rightHand.rotation;
			Vector3 b = this.ik.references.rightHand.rotation * this.gunHoldOffset;
			this.ik.solver.rightHandEffector.positionOffset += b;
			if (this.recoil != null)
			{
				this.recoil.SetHandRotations(this.rightHandRotation * this.leftHandRotRelToRightHand, this.rightHandRotation);
			}
			this.ik.solver.Update();
			if (this.recoil != null)
			{
				this.ik.references.rightHand.rotation = this.recoil.rotationOffset * this.rightHandRotation;
				this.ik.references.leftHand.rotation = this.recoil.rotationOffset * this.rightHandRotation * this.leftHandRotRelToRightHand;
				return;
			}
			this.ik.references.rightHand.rotation = this.rightHandRotation;
			this.ik.references.leftHand.rotation = this.rightHandRotation * this.leftHandRotRelToRightHand;
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x000421F0 File Offset: 0x000403F0
		private void OnPreRead()
		{
			Quaternion rotation = (this.recoil != null) ? (this.recoil.rotationOffset * this.rightHandRotation) : this.rightHandRotation;
			Vector3 a = this.ik.references.rightHand.position + this.ik.solver.rightHandEffector.positionOffset + rotation * this.leftHandPosRelToRightHand;
			this.ik.solver.leftHandEffector.positionOffset += a - this.ik.references.leftHand.position - this.ik.solver.leftHandEffector.positionOffset + rotation * this.leftHandOffset;
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x000422D4 File Offset: 0x000404D4
		private void HeadLookAt(Vector3 lookAtTarget)
		{
			Quaternion b = Quaternion.FromToRotation(this.ik.references.head.rotation * this.headLookAxis, lookAtTarget - this.ik.references.head.position);
			this.ik.references.head.rotation = Quaternion.Lerp(Quaternion.identity, b, this.headLookWeight) * this.ik.references.head.rotation;
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x00042362 File Offset: 0x00040562
		private void OnDestroy()
		{
			if (this.ik != null)
			{
				IKSolverFullBodyBiped solver = this.ik.solver;
				solver.OnPreRead = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPreRead, new IKSolver.UpdateDelegate(this.OnPreRead));
			}
		}

		// Token: 0x040009FA RID: 2554
		[Range(0f, 1f)]
		public float headLookWeight = 1f;

		// Token: 0x040009FB RID: 2555
		public Vector3 gunHoldOffset;

		// Token: 0x040009FC RID: 2556
		public Vector3 leftHandOffset;

		// Token: 0x040009FD RID: 2557
		public Recoil recoil;

		// Token: 0x040009FE RID: 2558
		private AimIK aim;

		// Token: 0x040009FF RID: 2559
		private FullBodyBipedIK ik;

		// Token: 0x04000A00 RID: 2560
		private Vector3 headLookAxis;

		// Token: 0x04000A01 RID: 2561
		private Vector3 leftHandPosRelToRightHand;

		// Token: 0x04000A02 RID: 2562
		private Quaternion leftHandRotRelToRightHand;

		// Token: 0x04000A03 RID: 2563
		private Vector3 aimTarget;

		// Token: 0x04000A04 RID: 2564
		private Quaternion rightHandRotation;
	}
}
