using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000C6 RID: 198
	[Serializable]
	public class IKMappingLimb : IKMapping
	{
		// Token: 0x06000631 RID: 1585 RVA: 0x0002558C File Offset: 0x0002378C
		public override bool IsValid(IKSolver solver, ref string message)
		{
			return base.IsValid(solver, ref message) && base.BoneIsValid(this.bone1, solver, ref message, null) && base.BoneIsValid(this.bone2, solver, ref message, null) && base.BoneIsValid(this.bone3, solver, ref message, null);
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x000255E0 File Offset: 0x000237E0
		public IKMapping.BoneMap GetBoneMap(IKMappingLimb.BoneMapType boneMap)
		{
			switch (boneMap)
			{
			case IKMappingLimb.BoneMapType.Parent:
				if (this.parentBone == null)
				{
					Warning.Log("This limb does not have a parent (shoulder) bone", this.bone1, false);
				}
				return this.boneMapParent;
			case IKMappingLimb.BoneMapType.Bone1:
				return this.boneMap1;
			case IKMappingLimb.BoneMapType.Bone2:
				return this.boneMap2;
			default:
				return this.boneMap3;
			}
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0002563C File Offset: 0x0002383C
		public void SetLimbOrientation(Vector3 upper, Vector3 lower)
		{
			this.boneMap1.defaultLocalTargetRotation = Quaternion.Inverse(Quaternion.Inverse(this.bone1.rotation) * Quaternion.LookRotation(this.bone2.position - this.bone1.position, this.bone1.rotation * -upper));
			this.boneMap2.defaultLocalTargetRotation = Quaternion.Inverse(Quaternion.Inverse(this.bone2.rotation) * Quaternion.LookRotation(this.bone3.position - this.bone2.position, this.bone2.rotation * -lower));
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00025700 File Offset: 0x00023900
		public IKMappingLimb()
		{
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x00025754 File Offset: 0x00023954
		public IKMappingLimb(Transform bone1, Transform bone2, Transform bone3, Transform parentBone = null)
		{
			this.SetBones(bone1, bone2, bone3, parentBone);
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x000257B0 File Offset: 0x000239B0
		public void SetBones(Transform bone1, Transform bone2, Transform bone3, Transform parentBone = null)
		{
			this.bone1 = bone1;
			this.bone2 = bone2;
			this.bone3 = bone3;
			this.parentBone = parentBone;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x000257CF File Offset: 0x000239CF
		public void StoreDefaultLocalState()
		{
			if (this.parentBone != null)
			{
				this.boneMapParent.StoreDefaultLocalState();
			}
			this.boneMap1.StoreDefaultLocalState();
			this.boneMap2.StoreDefaultLocalState();
			this.boneMap3.StoreDefaultLocalState();
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x0002580B File Offset: 0x00023A0B
		public void FixTransforms()
		{
			if (this.parentBone != null)
			{
				this.boneMapParent.FixTransform(false);
			}
			this.boneMap1.FixTransform(true);
			this.boneMap2.FixTransform(false);
			this.boneMap3.FixTransform(false);
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0002584C File Offset: 0x00023A4C
		public override void Initiate(IKSolverFullBody solver)
		{
			if (this.boneMapParent == null)
			{
				this.boneMapParent = new IKMapping.BoneMap();
			}
			if (this.boneMap1 == null)
			{
				this.boneMap1 = new IKMapping.BoneMap();
			}
			if (this.boneMap2 == null)
			{
				this.boneMap2 = new IKMapping.BoneMap();
			}
			if (this.boneMap3 == null)
			{
				this.boneMap3 = new IKMapping.BoneMap();
			}
			if (this.parentBone != null)
			{
				this.boneMapParent.Initiate(this.parentBone, solver);
			}
			this.boneMap1.Initiate(this.bone1, solver);
			this.boneMap2.Initiate(this.bone2, solver);
			this.boneMap3.Initiate(this.bone3, solver);
			this.boneMap1.SetPlane(solver, this.boneMap1.transform, this.boneMap2.transform, this.boneMap3.transform);
			this.boneMap2.SetPlane(solver, this.boneMap2.transform, this.boneMap3.transform, this.boneMap1.transform);
			if (this.parentBone != null)
			{
				this.boneMapParent.SetLocalSwingAxis(this.boneMap1);
			}
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x00025974 File Offset: 0x00023B74
		public void ReadPose()
		{
			this.boneMap1.UpdatePlane(this.updatePlaneRotations, true);
			this.boneMap2.UpdatePlane(this.updatePlaneRotations, false);
			this.weight = Mathf.Clamp(this.weight, 0f, 1f);
			this.boneMap3.MaintainRotation();
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x000259CC File Offset: 0x00023BCC
		public void WritePose(IKSolverFullBody solver, bool fullBody)
		{
			if (this.weight <= 0f)
			{
				return;
			}
			if (fullBody)
			{
				if (this.parentBone != null)
				{
					this.boneMapParent.Swing(solver.GetNode(this.boneMap1.chainIndex, this.boneMap1.nodeIndex).solverPosition, this.weight);
				}
				this.boneMap1.FixToNode(solver, this.weight, null);
			}
			this.boneMap1.RotateToPlane(solver, this.weight);
			this.boneMap2.RotateToPlane(solver, this.weight);
			this.boneMap3.RotateToMaintain(this.maintainRotationWeight * this.weight * solver.IKPositionWeight);
			this.boneMap3.RotateToEffector(solver, this.weight);
		}

		// Token: 0x04000590 RID: 1424
		public Transform parentBone;

		// Token: 0x04000591 RID: 1425
		public Transform bone1;

		// Token: 0x04000592 RID: 1426
		public Transform bone2;

		// Token: 0x04000593 RID: 1427
		public Transform bone3;

		// Token: 0x04000594 RID: 1428
		[Range(0f, 1f)]
		public float maintainRotationWeight;

		// Token: 0x04000595 RID: 1429
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x04000596 RID: 1430
		[NonSerialized]
		public bool updatePlaneRotations = true;

		// Token: 0x04000597 RID: 1431
		private IKMapping.BoneMap boneMapParent = new IKMapping.BoneMap();

		// Token: 0x04000598 RID: 1432
		private IKMapping.BoneMap boneMap1 = new IKMapping.BoneMap();

		// Token: 0x04000599 RID: 1433
		private IKMapping.BoneMap boneMap2 = new IKMapping.BoneMap();

		// Token: 0x0400059A RID: 1434
		private IKMapping.BoneMap boneMap3 = new IKMapping.BoneMap();

		// Token: 0x020000C7 RID: 199
		[Serializable]
		public enum BoneMapType
		{
			// Token: 0x0400059C RID: 1436
			Parent,
			// Token: 0x0400059D RID: 1437
			Bone1,
			// Token: 0x0400059E RID: 1438
			Bone2,
			// Token: 0x0400059F RID: 1439
			Bone3
		}
	}
}
