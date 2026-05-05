using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000D9 RID: 217
	[Serializable]
	public class IKSolverLeg : IKSolver
	{
		// Token: 0x0600070C RID: 1804 RVA: 0x0002B100 File Offset: 0x00029300
		public override bool IsValid(ref string message)
		{
			if (this.pelvis.transform == null || this.thigh.transform == null || this.calf.transform == null || this.foot.transform == null || this.toe.transform == null)
			{
				message = "Please assign all bone slots of the Leg IK solver.";
				return false;
			}
			Object[] objects = new Transform[]
			{
				this.pelvis.transform,
				this.thigh.transform,
				this.calf.transform,
				this.foot.transform,
				this.toe.transform
			};
			Transform transform = (Transform)Hierarchy.ContainsDuplicate(objects);
			if (transform != null)
			{
				message = transform.name + " is represented multiple times in the LegIK.";
				return false;
			}
			return true;
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x0002B1EC File Offset: 0x000293EC
		public void SetRotationWeight(float weight)
		{
			this.IKRotationWeight = weight;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x0002B1F8 File Offset: 0x000293F8
		public bool SetChain(Transform pelvis, Transform thigh, Transform calf, Transform foot, Transform toe, Transform root)
		{
			this.pelvis.transform = pelvis;
			this.thigh.transform = thigh;
			this.calf.transform = calf;
			this.foot.transform = foot;
			this.toe.transform = toe;
			base.Initiate(root);
			return base.initiated;
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x0002B251 File Offset: 0x00029451
		public override IKSolver.Point[] GetPoints()
		{
			return new IKSolver.Point[]
			{
				this.pelvis,
				this.thigh,
				this.calf,
				this.foot,
				this.toe
			};
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x0002B288 File Offset: 0x00029488
		public override IKSolver.Point GetPoint(Transform transform)
		{
			if (this.pelvis.transform == transform)
			{
				return this.pelvis;
			}
			if (this.thigh.transform == transform)
			{
				return this.thigh;
			}
			if (this.calf.transform == transform)
			{
				return this.calf;
			}
			if (this.foot.transform == transform)
			{
				return this.foot;
			}
			if (this.toe.transform == transform)
			{
				return this.toe;
			}
			return null;
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x0002B318 File Offset: 0x00029518
		public override void StoreDefaultLocalState()
		{
			this.thigh.StoreDefaultLocalState();
			this.calf.StoreDefaultLocalState();
			this.foot.StoreDefaultLocalState();
			this.toe.StoreDefaultLocalState();
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x0002B346 File Offset: 0x00029546
		public override void FixTransforms()
		{
			if (!base.initiated)
			{
				return;
			}
			this.thigh.FixTransform();
			this.calf.FixTransform();
			this.foot.FixTransform();
			this.toe.FixTransform();
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x0002B37D File Offset: 0x0002957D
		protected override void OnInitiate()
		{
			this.IKPosition = this.toe.transform.position;
			this.IKRotation = this.toe.transform.rotation;
			this.Read();
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x0002B3B1 File Offset: 0x000295B1
		protected override void OnUpdate()
		{
			this.Read();
			this.Solve();
			this.Write();
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x0002B3C8 File Offset: 0x000295C8
		private void Solve()
		{
			this.leg.heelPositionOffset += this.heelOffset;
			this.leg.PreSolve(1f);
			this.leg.ApplyOffsets(1f);
			this.leg.Solve(true);
			this.leg.ResetOffsets();
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x0002B428 File Offset: 0x00029628
		private void Read()
		{
			this.leg.IKPosition = this.IKPosition;
			this.leg.positionWeight = this.IKPositionWeight;
			this.leg.IKRotation = this.IKRotation;
			this.leg.rotationWeight = this.IKRotationWeight;
			this.positions[0] = this.root.position;
			this.positions[1] = this.pelvis.transform.position;
			this.positions[2] = this.thigh.transform.position;
			this.positions[3] = this.calf.transform.position;
			this.positions[4] = this.foot.transform.position;
			this.positions[5] = this.toe.transform.position;
			this.rotations[0] = this.root.rotation;
			this.rotations[1] = this.pelvis.transform.rotation;
			this.rotations[2] = this.thigh.transform.rotation;
			this.rotations[3] = this.calf.transform.rotation;
			this.rotations[4] = this.foot.transform.rotation;
			this.rotations[5] = this.toe.transform.rotation;
			this.leg.Read(this.positions, this.rotations, false, false, false, true, true, 1, 2);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x0002B5E0 File Offset: 0x000297E0
		private void Write()
		{
			this.leg.Write(ref this.positions, ref this.rotations);
			this.thigh.transform.rotation = this.rotations[2];
			this.calf.transform.rotation = this.rotations[3];
			this.foot.transform.rotation = this.rotations[4];
			this.toe.transform.rotation = this.rotations[5];
			this.calf.transform.position = this.positions[3];
			this.foot.transform.position = this.positions[4];
		}

		// Token: 0x04000615 RID: 1557
		[Range(0f, 1f)]
		public float IKRotationWeight = 1f;

		// Token: 0x04000616 RID: 1558
		public Quaternion IKRotation = Quaternion.identity;

		// Token: 0x04000617 RID: 1559
		public IKSolver.Point pelvis = new IKSolver.Point();

		// Token: 0x04000618 RID: 1560
		public IKSolver.Point thigh = new IKSolver.Point();

		// Token: 0x04000619 RID: 1561
		public IKSolver.Point calf = new IKSolver.Point();

		// Token: 0x0400061A RID: 1562
		public IKSolver.Point foot = new IKSolver.Point();

		// Token: 0x0400061B RID: 1563
		public IKSolver.Point toe = new IKSolver.Point();

		// Token: 0x0400061C RID: 1564
		public IKSolverVR.Leg leg = new IKSolverVR.Leg();

		// Token: 0x0400061D RID: 1565
		public Vector3 heelOffset;

		// Token: 0x0400061E RID: 1566
		private Vector3[] positions = new Vector3[6];

		// Token: 0x0400061F RID: 1567
		private Quaternion[] rotations = new Quaternion[6];
	}
}
