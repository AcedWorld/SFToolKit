using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000D0 RID: 208
	[Serializable]
	public class IKSolverArm : IKSolver
	{
		// Token: 0x06000685 RID: 1669 RVA: 0x00027300 File Offset: 0x00025500
		public override bool IsValid(ref string message)
		{
			if (this.chest.transform == null || this.shoulder.transform == null || this.upperArm.transform == null || this.forearm.transform == null || this.hand.transform == null)
			{
				message = "Please assign all bone slots of the Arm IK solver.";
				return false;
			}
			Object[] objects = new Transform[]
			{
				this.chest.transform,
				this.shoulder.transform,
				this.upperArm.transform,
				this.forearm.transform,
				this.hand.transform
			};
			Transform transform = (Transform)Hierarchy.ContainsDuplicate(objects);
			if (transform != null)
			{
				message = transform.name + " is represented multiple times in the ArmIK.";
				return false;
			}
			return true;
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x000273EC File Offset: 0x000255EC
		public void SetRotationWeight(float weight)
		{
			this.IKRotationWeight = weight;
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x000273F8 File Offset: 0x000255F8
		public bool SetChain(Transform chest, Transform shoulder, Transform upperArm, Transform forearm, Transform hand, Transform root)
		{
			this.chest.transform = chest;
			this.shoulder.transform = shoulder;
			this.upperArm.transform = upperArm;
			this.forearm.transform = forearm;
			this.hand.transform = hand;
			base.Initiate(root);
			return base.initiated;
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x00027451 File Offset: 0x00025651
		public override IKSolver.Point[] GetPoints()
		{
			return new IKSolver.Point[]
			{
				this.chest,
				this.shoulder,
				this.upperArm,
				this.forearm,
				this.hand
			};
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x00027488 File Offset: 0x00025688
		public override IKSolver.Point GetPoint(Transform transform)
		{
			if (this.chest.transform == transform)
			{
				return this.chest;
			}
			if (this.shoulder.transform == transform)
			{
				return this.shoulder;
			}
			if (this.upperArm.transform == transform)
			{
				return this.upperArm;
			}
			if (this.forearm.transform == transform)
			{
				return this.forearm;
			}
			if (this.hand.transform == transform)
			{
				return this.hand;
			}
			return null;
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x00027518 File Offset: 0x00025718
		public override void StoreDefaultLocalState()
		{
			this.shoulder.StoreDefaultLocalState();
			this.upperArm.StoreDefaultLocalState();
			this.forearm.StoreDefaultLocalState();
			this.hand.StoreDefaultLocalState();
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00027546 File Offset: 0x00025746
		public override void FixTransforms()
		{
			if (!base.initiated)
			{
				return;
			}
			this.shoulder.FixTransform();
			this.upperArm.FixTransform();
			this.forearm.FixTransform();
			this.hand.FixTransform();
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0002757D File Offset: 0x0002577D
		protected override void OnInitiate()
		{
			this.IKPosition = this.hand.transform.position;
			this.IKRotation = this.hand.transform.rotation;
			this.Read();
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x000275B1 File Offset: 0x000257B1
		protected override void OnUpdate()
		{
			this.Read();
			this.Solve();
			this.Write();
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x000275C5 File Offset: 0x000257C5
		private void Solve()
		{
			this.arm.PreSolve(1f);
			this.arm.ApplyOffsets(1f);
			this.arm.Solve(this.isLeft);
			this.arm.ResetOffsets();
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x00027604 File Offset: 0x00025804
		private void Read()
		{
			this.arm.IKPosition = this.IKPosition;
			this.arm.positionWeight = this.IKPositionWeight;
			this.arm.IKRotation = this.IKRotation;
			this.arm.rotationWeight = this.IKRotationWeight;
			this.positions[0] = this.root.position;
			this.positions[1] = this.chest.transform.position;
			this.positions[2] = this.shoulder.transform.position;
			this.positions[3] = this.upperArm.transform.position;
			this.positions[4] = this.forearm.transform.position;
			this.positions[5] = this.hand.transform.position;
			this.rotations[0] = this.root.rotation;
			this.rotations[1] = this.chest.transform.rotation;
			this.rotations[2] = this.shoulder.transform.rotation;
			this.rotations[3] = this.upperArm.transform.rotation;
			this.rotations[4] = this.forearm.transform.rotation;
			this.rotations[5] = this.hand.transform.rotation;
			this.arm.Read(this.positions, this.rotations, false, false, true, false, false, 1, 2);
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x000277BC File Offset: 0x000259BC
		private void Write()
		{
			this.arm.Write(ref this.positions, ref this.rotations);
			this.shoulder.transform.rotation = this.rotations[2];
			this.upperArm.transform.rotation = this.rotations[3];
			this.forearm.transform.rotation = this.rotations[4];
			this.hand.transform.rotation = this.rotations[5];
			this.forearm.transform.position = this.positions[4];
			this.hand.transform.position = this.positions[5];
		}

		// Token: 0x040005D4 RID: 1492
		[Range(0f, 1f)]
		public float IKRotationWeight = 1f;

		// Token: 0x040005D5 RID: 1493
		public Quaternion IKRotation = Quaternion.identity;

		// Token: 0x040005D6 RID: 1494
		public IKSolver.Point chest = new IKSolver.Point();

		// Token: 0x040005D7 RID: 1495
		public IKSolver.Point shoulder = new IKSolver.Point();

		// Token: 0x040005D8 RID: 1496
		public IKSolver.Point upperArm = new IKSolver.Point();

		// Token: 0x040005D9 RID: 1497
		public IKSolver.Point forearm = new IKSolver.Point();

		// Token: 0x040005DA RID: 1498
		public IKSolver.Point hand = new IKSolver.Point();

		// Token: 0x040005DB RID: 1499
		public bool isLeft;

		// Token: 0x040005DC RID: 1500
		public IKSolverVR.Arm arm = new IKSolverVR.Arm();

		// Token: 0x040005DD RID: 1501
		private Vector3[] positions = new Vector3[6];

		// Token: 0x040005DE RID: 1502
		private Quaternion[] rotations = new Quaternion[6];
	}
}
