using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000C5 RID: 197
	[Serializable]
	public class IKMappingBone : IKMapping
	{
		// Token: 0x06000629 RID: 1577 RVA: 0x000254BF File Offset: 0x000236BF
		public override bool IsValid(IKSolver solver, ref string message)
		{
			if (!base.IsValid(solver, ref message))
			{
				return false;
			}
			if (this.bone == null)
			{
				message = "IKMappingBone's bone is null.";
				return false;
			}
			return true;
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x000254E5 File Offset: 0x000236E5
		public IKMappingBone()
		{
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x00025503 File Offset: 0x00023703
		public IKMappingBone(Transform bone)
		{
			this.bone = bone;
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x00025528 File Offset: 0x00023728
		public void StoreDefaultLocalState()
		{
			this.boneMap.StoreDefaultLocalState();
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x00025535 File Offset: 0x00023735
		public void FixTransforms()
		{
			this.boneMap.FixTransform(false);
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x00025543 File Offset: 0x00023743
		public override void Initiate(IKSolverFullBody solver)
		{
			if (this.boneMap == null)
			{
				this.boneMap = new IKMapping.BoneMap();
			}
			this.boneMap.Initiate(this.bone, solver);
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x0002556A File Offset: 0x0002376A
		public void ReadPose()
		{
			this.boneMap.MaintainRotation();
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x00025577 File Offset: 0x00023777
		public void WritePose(float solverWeight)
		{
			this.boneMap.RotateToMaintain(solverWeight * this.maintainRotationWeight);
		}

		// Token: 0x0400058D RID: 1421
		public Transform bone;

		// Token: 0x0400058E RID: 1422
		[Range(0f, 1f)]
		public float maintainRotationWeight = 1f;

		// Token: 0x0400058F RID: 1423
		private IKMapping.BoneMap boneMap = new IKMapping.BoneMap();
	}
}
