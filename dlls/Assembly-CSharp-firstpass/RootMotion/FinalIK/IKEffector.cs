using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000C2 RID: 194
	[Serializable]
	public class IKEffector
	{
		// Token: 0x060005FB RID: 1531 RVA: 0x00024387 File Offset: 0x00022587
		public IKSolver.Node GetNode(IKSolverFullBody solver)
		{
			return solver.chain[this.chainIndex].nodes[this.nodeIndex];
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060005FC RID: 1532 RVA: 0x000243A2 File Offset: 0x000225A2
		// (set) Token: 0x060005FD RID: 1533 RVA: 0x000243AA File Offset: 0x000225AA
		public bool isEndEffector { get; private set; }

		// Token: 0x060005FE RID: 1534 RVA: 0x000243B4 File Offset: 0x000225B4
		public void PinToBone(float positionWeight, float rotationWeight)
		{
			this.position = this.bone.position;
			this.positionWeight = Mathf.Clamp(positionWeight, 0f, 1f);
			this.rotation = this.bone.rotation;
			this.rotationWeight = Mathf.Clamp(rotationWeight, 0f, 1f);
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x00024410 File Offset: 0x00022610
		public IKEffector()
		{
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x000244B8 File Offset: 0x000226B8
		public IKEffector(Transform bone, Transform[] childBones)
		{
			this.bone = bone;
			this.childBones = childBones;
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x00024570 File Offset: 0x00022770
		public bool IsValid(IKSolver solver, ref string message)
		{
			if (this.bone == null)
			{
				message = "IK Effector bone is null.";
				return false;
			}
			if (solver.GetPoint(this.bone) == null)
			{
				message = "IK Effector is referencing to a bone '" + this.bone.name + "' that does not excist in the Node Chain.";
				return false;
			}
			Transform[] array = this.childBones;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == null)
				{
					message = "IK Effector contains a null reference.";
					return false;
				}
			}
			foreach (Transform transform in this.childBones)
			{
				if (solver.GetPoint(transform) == null)
				{
					message = "IK Effector is referencing to a bone '" + transform.name + "' that does not excist in the Node Chain.";
					return false;
				}
			}
			if (this.planeBone1 != null && solver.GetPoint(this.planeBone1) == null)
			{
				message = "IK Effector is referencing to a bone '" + this.planeBone1.name + "' that does not excist in the Node Chain.";
				return false;
			}
			if (this.planeBone2 != null && solver.GetPoint(this.planeBone2) == null)
			{
				message = "IK Effector is referencing to a bone '" + this.planeBone2.name + "' that does not excist in the Node Chain.";
				return false;
			}
			if (this.planeBone3 != null && solver.GetPoint(this.planeBone3) == null)
			{
				message = "IK Effector is referencing to a bone '" + this.planeBone3.name + "' that does not excist in the Node Chain.";
				return false;
			}
			return true;
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x000246D4 File Offset: 0x000228D4
		public void Initiate(IKSolverFullBody solver)
		{
			this.position = this.bone.position;
			this.rotation = this.bone.rotation;
			this.animatedPlaneRotation = Quaternion.identity;
			solver.GetChainAndNodeIndexes(this.bone, out this.chainIndex, out this.nodeIndex);
			this.childChainIndexes = new int[this.childBones.Length];
			this.childNodeIndexes = new int[this.childBones.Length];
			for (int i = 0; i < this.childBones.Length; i++)
			{
				solver.GetChainAndNodeIndexes(this.childBones[i], out this.childChainIndexes[i], out this.childNodeIndexes[i]);
			}
			this.localPositions = new Vector3[this.childBones.Length];
			this.usePlaneNodes = false;
			if (this.planeBone1 != null)
			{
				solver.GetChainAndNodeIndexes(this.planeBone1, out this.plane1ChainIndex, out this.plane1NodeIndex);
				if (this.planeBone2 != null)
				{
					solver.GetChainAndNodeIndexes(this.planeBone2, out this.plane2ChainIndex, out this.plane2NodeIndex);
					if (this.planeBone3 != null)
					{
						solver.GetChainAndNodeIndexes(this.planeBone3, out this.plane3ChainIndex, out this.plane3NodeIndex);
						this.usePlaneNodes = true;
					}
				}
				this.isEndEffector = true;
				return;
			}
			this.isEndEffector = false;
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x00024828 File Offset: 0x00022A28
		public void ResetOffset(IKSolverFullBody solver)
		{
			solver.GetNode(this.chainIndex, this.nodeIndex).offset = Vector3.zero;
			for (int i = 0; i < this.childChainIndexes.Length; i++)
			{
				solver.GetNode(this.childChainIndexes[i], this.childNodeIndexes[i]).offset = Vector3.zero;
			}
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x00024884 File Offset: 0x00022A84
		public void SetToTarget()
		{
			if (this.target == null)
			{
				return;
			}
			this.position = this.target.position;
			this.rotation = this.target.rotation;
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x000248B8 File Offset: 0x00022AB8
		public void OnPreSolve(IKSolverFullBody solver)
		{
			this.positionWeight = Mathf.Clamp(this.positionWeight, 0f, 1f);
			this.rotationWeight = Mathf.Clamp(this.rotationWeight, 0f, 1f);
			this.maintainRelativePositionWeight = Mathf.Clamp(this.maintainRelativePositionWeight, 0f, 1f);
			this.posW = this.positionWeight * solver.IKPositionWeight;
			this.rotW = this.rotationWeight * solver.IKPositionWeight;
			solver.GetNode(this.chainIndex, this.nodeIndex).effectorPositionWeight = this.posW;
			solver.GetNode(this.chainIndex, this.nodeIndex).effectorRotationWeight = this.rotW;
			solver.GetNode(this.chainIndex, this.nodeIndex).solverRotation = this.rotation;
			if (float.IsInfinity(this.positionOffset.x) || float.IsInfinity(this.positionOffset.y) || float.IsInfinity(this.positionOffset.z))
			{
				Debug.LogError("Invalid IKEffector.positionOffset (contains Infinity)! Please make sure not to set IKEffector.positionOffset to infinite values.", this.bone);
			}
			if (float.IsNaN(this.positionOffset.x) || float.IsNaN(this.positionOffset.y) || float.IsNaN(this.positionOffset.z))
			{
				Debug.LogError("Invalid IKEffector.positionOffset (contains NaN)! Please make sure not to set IKEffector.positionOffset to NaN values.", this.bone);
			}
			if (this.positionOffset.sqrMagnitude > 1E+10f)
			{
				Debug.LogError("Additive effector positionOffset detected in Full Body IK (extremely large value). Make sure you are not circularily adding to effector positionOffset each frame.", this.bone);
			}
			if (float.IsInfinity(this.position.x) || float.IsInfinity(this.position.y) || float.IsInfinity(this.position.z))
			{
				Debug.LogError("Invalid IKEffector.position (contains Infinity)!");
			}
			solver.GetNode(this.chainIndex, this.nodeIndex).offset += this.positionOffset * solver.IKPositionWeight;
			if (this.effectChildNodes && solver.iterations > 0)
			{
				for (int i = 0; i < this.childBones.Length; i++)
				{
					this.localPositions[i] = this.childBones[i].transform.position - this.bone.transform.position;
					solver.GetNode(this.childChainIndexes[i], this.childNodeIndexes[i]).offset += this.positionOffset * solver.IKPositionWeight;
				}
			}
			if (this.usePlaneNodes && this.maintainRelativePositionWeight > 0f)
			{
				this.animatedPlaneRotation = Quaternion.LookRotation(this.planeBone2.position - this.planeBone1.position, this.planeBone3.position - this.planeBone1.position);
			}
			this.firstUpdate = true;
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x00024BA2 File Offset: 0x00022DA2
		public void OnPostWrite()
		{
			this.positionOffset = Vector3.zero;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x00024BB0 File Offset: 0x00022DB0
		private Quaternion GetPlaneRotation(IKSolverFullBody solver)
		{
			Vector3 solverPosition = solver.GetNode(this.plane1ChainIndex, this.plane1NodeIndex).solverPosition;
			Vector3 solverPosition2 = solver.GetNode(this.plane2ChainIndex, this.plane2NodeIndex).solverPosition;
			Vector3 solverPosition3 = solver.GetNode(this.plane3ChainIndex, this.plane3NodeIndex).solverPosition;
			Vector3 vector = solverPosition2 - solverPosition;
			Vector3 upwards = solverPosition3 - solverPosition;
			if (vector == Vector3.zero)
			{
				Warning.Log("Make sure you are not placing 2 or more FBBIK effectors of the same chain to exactly the same position.", this.bone, false);
				return Quaternion.identity;
			}
			return Quaternion.LookRotation(vector, upwards);
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x00024C40 File Offset: 0x00022E40
		public void Update(IKSolverFullBody solver)
		{
			if (this.firstUpdate)
			{
				this.animatedPosition = this.bone.position + solver.GetNode(this.chainIndex, this.nodeIndex).offset;
				this.firstUpdate = false;
			}
			solver.GetNode(this.chainIndex, this.nodeIndex).solverPosition = Vector3.Lerp(this.GetPosition(solver, out this.planeRotationOffset), this.position, this.posW);
			if (!this.effectChildNodes)
			{
				return;
			}
			for (int i = 0; i < this.childBones.Length; i++)
			{
				solver.GetNode(this.childChainIndexes[i], this.childNodeIndexes[i]).solverPosition = Vector3.Lerp(solver.GetNode(this.childChainIndexes[i], this.childNodeIndexes[i]).solverPosition, solver.GetNode(this.chainIndex, this.nodeIndex).solverPosition + this.localPositions[i], this.posW);
			}
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00024D44 File Offset: 0x00022F44
		private Vector3 GetPosition(IKSolverFullBody solver, out Quaternion planeRotationOffset)
		{
			planeRotationOffset = Quaternion.identity;
			if (!this.isEndEffector)
			{
				return solver.GetNode(this.chainIndex, this.nodeIndex).solverPosition;
			}
			if (this.maintainRelativePositionWeight <= 0f)
			{
				return this.animatedPosition;
			}
			Vector3 a = this.bone.position;
			Vector3 point = a - this.planeBone1.position;
			planeRotationOffset = this.GetPlaneRotation(solver) * Quaternion.Inverse(this.animatedPlaneRotation);
			a = solver.GetNode(this.plane1ChainIndex, this.plane1NodeIndex).solverPosition + planeRotationOffset * point;
			planeRotationOffset = Quaternion.Lerp(Quaternion.identity, planeRotationOffset, this.maintainRelativePositionWeight);
			return Vector3.Lerp(this.animatedPosition, a + solver.GetNode(this.chainIndex, this.nodeIndex).offset, this.maintainRelativePositionWeight);
		}

		// Token: 0x04000557 RID: 1367
		public Transform bone;

		// Token: 0x04000558 RID: 1368
		public Transform target;

		// Token: 0x04000559 RID: 1369
		[Range(0f, 1f)]
		public float positionWeight;

		// Token: 0x0400055A RID: 1370
		[Range(0f, 1f)]
		public float rotationWeight;

		// Token: 0x0400055B RID: 1371
		public Vector3 position = Vector3.zero;

		// Token: 0x0400055C RID: 1372
		public Quaternion rotation = Quaternion.identity;

		// Token: 0x0400055D RID: 1373
		public Vector3 positionOffset;

		// Token: 0x0400055F RID: 1375
		public bool effectChildNodes = true;

		// Token: 0x04000560 RID: 1376
		[Range(0f, 1f)]
		public float maintainRelativePositionWeight;

		// Token: 0x04000561 RID: 1377
		public Transform[] childBones = new Transform[0];

		// Token: 0x04000562 RID: 1378
		public Transform planeBone1;

		// Token: 0x04000563 RID: 1379
		public Transform planeBone2;

		// Token: 0x04000564 RID: 1380
		public Transform planeBone3;

		// Token: 0x04000565 RID: 1381
		public Quaternion planeRotationOffset = Quaternion.identity;

		// Token: 0x04000566 RID: 1382
		private float posW;

		// Token: 0x04000567 RID: 1383
		private float rotW;

		// Token: 0x04000568 RID: 1384
		private Vector3[] localPositions = new Vector3[0];

		// Token: 0x04000569 RID: 1385
		private bool usePlaneNodes;

		// Token: 0x0400056A RID: 1386
		private Quaternion animatedPlaneRotation = Quaternion.identity;

		// Token: 0x0400056B RID: 1387
		private Vector3 animatedPosition;

		// Token: 0x0400056C RID: 1388
		private bool firstUpdate;

		// Token: 0x0400056D RID: 1389
		private int chainIndex = -1;

		// Token: 0x0400056E RID: 1390
		private int nodeIndex = -1;

		// Token: 0x0400056F RID: 1391
		private int plane1ChainIndex;

		// Token: 0x04000570 RID: 1392
		private int plane1NodeIndex = -1;

		// Token: 0x04000571 RID: 1393
		private int plane2ChainIndex = -1;

		// Token: 0x04000572 RID: 1394
		private int plane2NodeIndex = -1;

		// Token: 0x04000573 RID: 1395
		private int plane3ChainIndex = -1;

		// Token: 0x04000574 RID: 1396
		private int plane3NodeIndex = -1;

		// Token: 0x04000575 RID: 1397
		private int[] childChainIndexes = new int[0];

		// Token: 0x04000576 RID: 1398
		private int[] childNodeIndexes = new int[0];
	}
}
