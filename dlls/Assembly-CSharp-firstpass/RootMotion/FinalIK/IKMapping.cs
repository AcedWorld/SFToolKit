using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000C3 RID: 195
	[Serializable]
	public class IKMapping
	{
		// Token: 0x0600060A RID: 1546 RVA: 0x0000E2C5 File Offset: 0x0000C4C5
		public virtual bool IsValid(IKSolver solver, ref string message)
		{
			return true;
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x0000223E File Offset: 0x0000043E
		public virtual void Initiate(IKSolverFullBody solver)
		{
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x00024E40 File Offset: 0x00023040
		protected bool BoneIsValid(Transform bone, IKSolver solver, ref string message, Warning.Logger logger = null)
		{
			if (bone == null)
			{
				message = "IKMappingLimb contains a null reference.";
				if (logger != null)
				{
					logger(message);
				}
				return false;
			}
			if (solver.GetPoint(bone) == null)
			{
				message = "IKMappingLimb is referencing to a bone '" + bone.name + "' that does not excist in the Node Chain.";
				if (logger != null)
				{
					logger(message);
				}
				return false;
			}
			return true;
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x00024E9C File Offset: 0x0002309C
		protected Vector3 SolveFABRIKJoint(Vector3 pos1, Vector3 pos2, float length)
		{
			return pos2 + (pos1 - pos2).normalized * length;
		}

		// Token: 0x020000C4 RID: 196
		[Serializable]
		public class BoneMap
		{
			// Token: 0x0600060F RID: 1551 RVA: 0x00024EC4 File Offset: 0x000230C4
			public void Initiate(Transform transform, IKSolverFullBody solver)
			{
				this.transform = transform;
				solver.GetChainAndNodeIndexes(transform, out this.chainIndex, out this.nodeIndex);
			}

			// Token: 0x170000A3 RID: 163
			// (get) Token: 0x06000610 RID: 1552 RVA: 0x00024EE0 File Offset: 0x000230E0
			public Vector3 swingDirection
			{
				get
				{
					return this.transform.rotation * this.localSwingAxis;
				}
			}

			// Token: 0x06000611 RID: 1553 RVA: 0x00024EF8 File Offset: 0x000230F8
			public void StoreDefaultLocalState()
			{
				this.defaultLocalPosition = this.transform.localPosition;
				this.defaultLocalRotation = this.transform.localRotation;
			}

			// Token: 0x06000612 RID: 1554 RVA: 0x00024F1C File Offset: 0x0002311C
			public void FixTransform(bool position)
			{
				if (position)
				{
					this.transform.localPosition = this.defaultLocalPosition;
				}
				this.transform.localRotation = this.defaultLocalRotation;
			}

			// Token: 0x170000A4 RID: 164
			// (get) Token: 0x06000613 RID: 1555 RVA: 0x00024F43 File Offset: 0x00023143
			public bool isNodeBone
			{
				get
				{
					return this.nodeIndex != -1;
				}
			}

			// Token: 0x06000614 RID: 1556 RVA: 0x00024F51 File Offset: 0x00023151
			public void SetLength(IKMapping.BoneMap nextBone)
			{
				this.length = Vector3.Distance(this.transform.position, nextBone.transform.position);
			}

			// Token: 0x06000615 RID: 1557 RVA: 0x00024F74 File Offset: 0x00023174
			public void SetLocalSwingAxis(IKMapping.BoneMap swingTarget)
			{
				this.SetLocalSwingAxis(swingTarget, this);
			}

			// Token: 0x06000616 RID: 1558 RVA: 0x00024F7E File Offset: 0x0002317E
			public void SetLocalSwingAxis(IKMapping.BoneMap bone1, IKMapping.BoneMap bone2)
			{
				this.localSwingAxis = Quaternion.Inverse(this.transform.rotation) * (bone1.transform.position - bone2.transform.position);
			}

			// Token: 0x06000617 RID: 1559 RVA: 0x00024FB6 File Offset: 0x000231B6
			public void SetLocalTwistAxis(Vector3 twistDirection, Vector3 normalDirection)
			{
				Vector3.OrthoNormalize(ref normalDirection, ref twistDirection);
				this.localTwistAxis = Quaternion.Inverse(this.transform.rotation) * twistDirection;
			}

			// Token: 0x06000618 RID: 1560 RVA: 0x00024FE0 File Offset: 0x000231E0
			public void SetPlane(IKSolverFullBody solver, Transform planeBone1, Transform planeBone2, Transform planeBone3)
			{
				this.planeBone1 = planeBone1;
				this.planeBone2 = planeBone2;
				this.planeBone3 = planeBone3;
				solver.GetChainAndNodeIndexes(planeBone1, out this.plane1ChainIndex, out this.plane1NodeIndex);
				solver.GetChainAndNodeIndexes(planeBone2, out this.plane2ChainIndex, out this.plane2NodeIndex);
				solver.GetChainAndNodeIndexes(planeBone3, out this.plane3ChainIndex, out this.plane3NodeIndex);
				this.UpdatePlane(true, true);
			}

			// Token: 0x06000619 RID: 1561 RVA: 0x00025048 File Offset: 0x00023248
			public void UpdatePlane(bool rotation, bool position)
			{
				Quaternion lastAnimatedTargetRotation = this.lastAnimatedTargetRotation;
				if (rotation)
				{
					this.defaultLocalTargetRotation = QuaTools.RotationToLocalSpace(this.transform.rotation, lastAnimatedTargetRotation);
				}
				if (position)
				{
					this.planePosition = Quaternion.Inverse(lastAnimatedTargetRotation) * (this.transform.position - this.planeBone1.position);
				}
			}

			// Token: 0x0600061A RID: 1562 RVA: 0x000250A5 File Offset: 0x000232A5
			public void SetIKPosition()
			{
				this.ikPosition = this.transform.position;
			}

			// Token: 0x0600061B RID: 1563 RVA: 0x000250B8 File Offset: 0x000232B8
			public void MaintainRotation()
			{
				this.maintainRotation = this.transform.rotation;
			}

			// Token: 0x0600061C RID: 1564 RVA: 0x000250CB File Offset: 0x000232CB
			public void SetToIKPosition()
			{
				this.transform.position = this.ikPosition;
			}

			// Token: 0x0600061D RID: 1565 RVA: 0x000250E0 File Offset: 0x000232E0
			public void FixToNode(IKSolverFullBody solver, float weight, IKSolver.Node fixNode = null)
			{
				if (fixNode == null)
				{
					fixNode = solver.GetNode(this.chainIndex, this.nodeIndex);
				}
				if (weight >= 1f)
				{
					this.transform.position = fixNode.solverPosition;
					return;
				}
				this.transform.position = Vector3.Lerp(this.transform.position, fixNode.solverPosition, weight);
			}

			// Token: 0x0600061E RID: 1566 RVA: 0x00025140 File Offset: 0x00023340
			public Vector3 GetPlanePosition(IKSolverFullBody solver)
			{
				return solver.GetNode(this.plane1ChainIndex, this.plane1NodeIndex).solverPosition + this.GetTargetRotation(solver) * this.planePosition;
			}

			// Token: 0x0600061F RID: 1567 RVA: 0x00025170 File Offset: 0x00023370
			public void PositionToPlane(IKSolverFullBody solver)
			{
				this.transform.position = this.GetPlanePosition(solver);
			}

			// Token: 0x06000620 RID: 1568 RVA: 0x00025184 File Offset: 0x00023384
			public void RotateToPlane(IKSolverFullBody solver, float weight)
			{
				Quaternion quaternion = this.GetTargetRotation(solver) * this.defaultLocalTargetRotation;
				if (weight >= 1f)
				{
					this.transform.rotation = quaternion;
					return;
				}
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation, quaternion, weight);
			}

			// Token: 0x06000621 RID: 1569 RVA: 0x000251D6 File Offset: 0x000233D6
			public void Swing(Vector3 swingTarget, float weight)
			{
				this.Swing(swingTarget, this.transform.position, weight);
			}

			// Token: 0x06000622 RID: 1570 RVA: 0x000251EC File Offset: 0x000233EC
			public void Swing(Vector3 pos1, Vector3 pos2, float weight)
			{
				Quaternion quaternion = Quaternion.FromToRotation(this.transform.rotation * this.localSwingAxis, pos1 - pos2) * this.transform.rotation;
				if (weight >= 1f)
				{
					this.transform.rotation = quaternion;
					return;
				}
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation, quaternion, weight);
			}

			// Token: 0x06000623 RID: 1571 RVA: 0x00025260 File Offset: 0x00023460
			public void Twist(Vector3 twistDirection, Vector3 normalDirection, float weight)
			{
				Vector3.OrthoNormalize(ref normalDirection, ref twistDirection);
				Quaternion quaternion = Quaternion.FromToRotation(this.transform.rotation * this.localTwistAxis, twistDirection) * this.transform.rotation;
				if (weight >= 1f)
				{
					this.transform.rotation = quaternion;
					return;
				}
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation, quaternion, weight);
			}

			// Token: 0x06000624 RID: 1572 RVA: 0x000252D5 File Offset: 0x000234D5
			public void RotateToMaintain(float weight)
			{
				if (weight <= 0f)
				{
					return;
				}
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.maintainRotation, weight);
			}

			// Token: 0x06000625 RID: 1573 RVA: 0x00025304 File Offset: 0x00023504
			public void RotateToEffector(IKSolverFullBody solver, float weight)
			{
				if (!this.isNodeBone)
				{
					return;
				}
				float num = weight * solver.GetNode(this.chainIndex, this.nodeIndex).effectorRotationWeight;
				if (num <= 0f)
				{
					return;
				}
				if (num >= 1f)
				{
					this.transform.rotation = solver.GetNode(this.chainIndex, this.nodeIndex).solverRotation;
					return;
				}
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation, solver.GetNode(this.chainIndex, this.nodeIndex).solverRotation, num);
			}

			// Token: 0x06000626 RID: 1574 RVA: 0x0002539C File Offset: 0x0002359C
			private Quaternion GetTargetRotation(IKSolverFullBody solver)
			{
				Vector3 solverPosition = solver.GetNode(this.plane1ChainIndex, this.plane1NodeIndex).solverPosition;
				Vector3 solverPosition2 = solver.GetNode(this.plane2ChainIndex, this.plane2NodeIndex).solverPosition;
				Vector3 solverPosition3 = solver.GetNode(this.plane3ChainIndex, this.plane3NodeIndex).solverPosition;
				if (solverPosition == solverPosition3)
				{
					return Quaternion.identity;
				}
				return Quaternion.LookRotation(solverPosition2 - solverPosition, solverPosition3 - solverPosition);
			}

			// Token: 0x170000A5 RID: 165
			// (get) Token: 0x06000627 RID: 1575 RVA: 0x00025414 File Offset: 0x00023614
			private Quaternion lastAnimatedTargetRotation
			{
				get
				{
					if (this.planeBone1.position == this.planeBone3.position)
					{
						return Quaternion.identity;
					}
					return Quaternion.LookRotation(this.planeBone2.position - this.planeBone1.position, this.planeBone3.position - this.planeBone1.position);
				}
			}

			// Token: 0x04000577 RID: 1399
			public Transform transform;

			// Token: 0x04000578 RID: 1400
			public int chainIndex = -1;

			// Token: 0x04000579 RID: 1401
			public int nodeIndex = -1;

			// Token: 0x0400057A RID: 1402
			public Vector3 defaultLocalPosition;

			// Token: 0x0400057B RID: 1403
			public Quaternion defaultLocalRotation;

			// Token: 0x0400057C RID: 1404
			public Vector3 localSwingAxis;

			// Token: 0x0400057D RID: 1405
			public Vector3 localTwistAxis;

			// Token: 0x0400057E RID: 1406
			public Vector3 planePosition;

			// Token: 0x0400057F RID: 1407
			public Vector3 ikPosition;

			// Token: 0x04000580 RID: 1408
			public Quaternion defaultLocalTargetRotation;

			// Token: 0x04000581 RID: 1409
			private Quaternion maintainRotation;

			// Token: 0x04000582 RID: 1410
			public float length;

			// Token: 0x04000583 RID: 1411
			public Quaternion animatedRotation;

			// Token: 0x04000584 RID: 1412
			private Transform planeBone1;

			// Token: 0x04000585 RID: 1413
			private Transform planeBone2;

			// Token: 0x04000586 RID: 1414
			private Transform planeBone3;

			// Token: 0x04000587 RID: 1415
			private int plane1ChainIndex = -1;

			// Token: 0x04000588 RID: 1416
			private int plane1NodeIndex = -1;

			// Token: 0x04000589 RID: 1417
			private int plane2ChainIndex = -1;

			// Token: 0x0400058A RID: 1418
			private int plane2NodeIndex = -1;

			// Token: 0x0400058B RID: 1419
			private int plane3ChainIndex = -1;

			// Token: 0x0400058C RID: 1420
			private int plane3NodeIndex = -1;
		}
	}
}
