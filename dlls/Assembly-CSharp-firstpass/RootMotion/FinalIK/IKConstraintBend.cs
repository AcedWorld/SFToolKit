using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000C1 RID: 193
	[Serializable]
	public class IKConstraintBend
	{
		// Token: 0x060005EF RID: 1519 RVA: 0x00023D38 File Offset: 0x00021F38
		public bool IsValid(IKSolverFullBody solver, Warning.Logger logger)
		{
			if (this.bone1 == null || this.bone2 == null || this.bone3 == null)
			{
				if (logger != null)
				{
					logger("Bend Constraint contains a null reference.");
				}
				return false;
			}
			if (solver.GetPoint(this.bone1) == null)
			{
				if (logger != null)
				{
					logger("Bend Constraint is referencing to a bone '" + this.bone1.name + "' that does not excist in the Node Chain.");
				}
				return false;
			}
			if (solver.GetPoint(this.bone2) == null)
			{
				if (logger != null)
				{
					logger("Bend Constraint is referencing to a bone '" + this.bone2.name + "' that does not excist in the Node Chain.");
				}
				return false;
			}
			if (solver.GetPoint(this.bone3) == null)
			{
				if (logger != null)
				{
					logger("Bend Constraint is referencing to a bone '" + this.bone3.name + "' that does not excist in the Node Chain.");
				}
				return false;
			}
			return true;
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x00023E19 File Offset: 0x00022019
		// (set) Token: 0x060005F1 RID: 1521 RVA: 0x00023E21 File Offset: 0x00022021
		public bool initiated { get; private set; }

		// Token: 0x060005F2 RID: 1522 RVA: 0x00023E2A File Offset: 0x0002202A
		public IKConstraintBend()
		{
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x00023E48 File Offset: 0x00022048
		public IKConstraintBend(Transform bone1, Transform bone2, Transform bone3)
		{
			this.SetBones(bone1, bone2, bone3);
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x00023E6F File Offset: 0x0002206F
		public void SetBones(Transform bone1, Transform bone2, Transform bone3)
		{
			this.bone1 = bone1;
			this.bone2 = bone2;
			this.bone3 = bone3;
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x00023E88 File Offset: 0x00022088
		public void Initiate(IKSolverFullBody solver)
		{
			solver.GetChainAndNodeIndexes(this.bone1, out this.chainIndex1, out this.nodeIndex1);
			solver.GetChainAndNodeIndexes(this.bone2, out this.chainIndex2, out this.nodeIndex2);
			solver.GetChainAndNodeIndexes(this.bone3, out this.chainIndex3, out this.nodeIndex3);
			this.direction = this.OrthoToBone1(solver, this.OrthoToLimb(solver, this.bone2.position - this.bone1.position));
			if (!this.limbOrientationsSet)
			{
				this.defaultLocalDirection = Quaternion.Inverse(this.bone1.rotation) * this.direction;
				Vector3 point = Vector3.Cross((this.bone3.position - this.bone1.position).normalized, this.direction);
				this.defaultChildDirection = Quaternion.Inverse(this.bone3.rotation) * point;
			}
			this.initiated = true;
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x00023F88 File Offset: 0x00022188
		public void SetLimbOrientation(Vector3 upper, Vector3 lower, Vector3 last)
		{
			if (upper == Vector3.zero)
			{
				Debug.LogError("Attempting to set limb orientation to Vector3.zero axis");
			}
			if (lower == Vector3.zero)
			{
				Debug.LogError("Attempting to set limb orientation to Vector3.zero axis");
			}
			if (last == Vector3.zero)
			{
				Debug.LogError("Attempting to set limb orientation to Vector3.zero axis");
			}
			this.defaultLocalDirection = upper.normalized;
			this.defaultChildDirection = last.normalized;
			this.limbOrientationsSet = true;
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x00023FFC File Offset: 0x000221FC
		public void LimitBend(float solverWeight, float positionWeight)
		{
			if (!this.initiated)
			{
				return;
			}
			Vector3 vector = this.bone1.rotation * -this.defaultLocalDirection;
			Vector3 fromDirection = this.bone3.position - this.bone2.position;
			bool flag = false;
			Vector3 toDirection = V3Tools.ClampDirection(fromDirection, vector, this.clampF * solverWeight, 0, out flag);
			Quaternion rotation = this.bone3.rotation;
			if (flag)
			{
				Quaternion lhs = Quaternion.FromToRotation(fromDirection, toDirection);
				this.bone2.rotation = lhs * this.bone2.rotation;
			}
			if (positionWeight > 0f)
			{
				Vector3 vector2 = this.bone2.position - this.bone1.position;
				Vector3 fromDirection2 = this.bone3.position - this.bone2.position;
				Vector3.OrthoNormalize(ref vector2, ref fromDirection2);
				Quaternion lhs2 = Quaternion.FromToRotation(fromDirection2, vector);
				this.bone2.rotation = Quaternion.Lerp(this.bone2.rotation, lhs2 * this.bone2.rotation, positionWeight * solverWeight);
			}
			if (flag || positionWeight > 0f)
			{
				this.bone3.rotation = rotation;
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x00024134 File Offset: 0x00022334
		public Vector3 GetDir(IKSolverFullBody solver)
		{
			if (!this.initiated)
			{
				return Vector3.zero;
			}
			float num = this.weight * solver.IKPositionWeight;
			if (this.bendGoal != null)
			{
				Vector3 lhs = this.bendGoal.position - solver.GetNode(this.chainIndex1, this.nodeIndex1).solverPosition;
				if (lhs != Vector3.zero)
				{
					this.direction = lhs;
				}
			}
			if (num >= 1f)
			{
				return this.direction.normalized;
			}
			Vector3 vector = solver.GetNode(this.chainIndex3, this.nodeIndex3).solverPosition - solver.GetNode(this.chainIndex1, this.nodeIndex1).solverPosition;
			Vector3 vector2 = Quaternion.FromToRotation(this.bone3.position - this.bone1.position, vector) * (this.bone2.position - this.bone1.position);
			if (solver.GetNode(this.chainIndex3, this.nodeIndex3).effectorRotationWeight > 0f)
			{
				Vector3 b = -Vector3.Cross(vector, solver.GetNode(this.chainIndex3, this.nodeIndex3).solverRotation * this.defaultChildDirection);
				vector2 = Vector3.Lerp(vector2, b, solver.GetNode(this.chainIndex3, this.nodeIndex3).effectorRotationWeight);
			}
			if (this.rotationOffset != Quaternion.identity)
			{
				vector2 = Quaternion.FromToRotation(this.rotationOffset * vector, vector) * this.rotationOffset * vector2;
			}
			if (num <= 0f)
			{
				return vector2;
			}
			return Vector3.Lerp(vector2, this.direction.normalized, num);
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x000242F0 File Offset: 0x000224F0
		private Vector3 OrthoToLimb(IKSolverFullBody solver, Vector3 tangent)
		{
			Vector3 vector = solver.GetNode(this.chainIndex3, this.nodeIndex3).solverPosition - solver.GetNode(this.chainIndex1, this.nodeIndex1).solverPosition;
			Vector3.OrthoNormalize(ref vector, ref tangent);
			return tangent;
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x0002433C File Offset: 0x0002253C
		private Vector3 OrthoToBone1(IKSolverFullBody solver, Vector3 tangent)
		{
			Vector3 vector = solver.GetNode(this.chainIndex2, this.nodeIndex2).solverPosition - solver.GetNode(this.chainIndex1, this.nodeIndex1).solverPosition;
			Vector3.OrthoNormalize(ref vector, ref tangent);
			return tangent;
		}

		// Token: 0x04000545 RID: 1349
		public Transform bone1;

		// Token: 0x04000546 RID: 1350
		public Transform bone2;

		// Token: 0x04000547 RID: 1351
		public Transform bone3;

		// Token: 0x04000548 RID: 1352
		public Transform bendGoal;

		// Token: 0x04000549 RID: 1353
		public Vector3 direction = Vector3.right;

		// Token: 0x0400054A RID: 1354
		public Quaternion rotationOffset;

		// Token: 0x0400054B RID: 1355
		[Range(0f, 1f)]
		public float weight;

		// Token: 0x0400054C RID: 1356
		public Vector3 defaultLocalDirection;

		// Token: 0x0400054D RID: 1357
		public Vector3 defaultChildDirection;

		// Token: 0x0400054E RID: 1358
		[NonSerialized]
		public float clampF = 0.505f;

		// Token: 0x0400054F RID: 1359
		private int chainIndex1;

		// Token: 0x04000550 RID: 1360
		private int nodeIndex1;

		// Token: 0x04000551 RID: 1361
		private int chainIndex2;

		// Token: 0x04000552 RID: 1362
		private int nodeIndex2;

		// Token: 0x04000553 RID: 1363
		private int chainIndex3;

		// Token: 0x04000554 RID: 1364
		private int nodeIndex3;

		// Token: 0x04000556 RID: 1366
		private bool limbOrientationsSet;
	}
}
