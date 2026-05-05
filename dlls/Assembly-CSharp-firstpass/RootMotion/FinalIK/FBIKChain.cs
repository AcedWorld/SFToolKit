using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000BE RID: 190
	[Serializable]
	public class FBIKChain
	{
		// Token: 0x060005D3 RID: 1491 RVA: 0x00022B80 File Offset: 0x00020D80
		public FBIKChain()
		{
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x00022BE8 File Offset: 0x00020DE8
		public FBIKChain(float pin, float pull, params Transform[] nodeTransforms)
		{
			this.pin = pin;
			this.pull = pull;
			this.SetNodes(nodeTransforms);
			this.children = new int[0];
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x00022C70 File Offset: 0x00020E70
		public void SetNodes(params Transform[] boneTransforms)
		{
			this.nodes = new IKSolver.Node[boneTransforms.Length];
			for (int i = 0; i < boneTransforms.Length; i++)
			{
				this.nodes[i] = new IKSolver.Node(boneTransforms[i]);
			}
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x00022CAC File Offset: 0x00020EAC
		public int GetNodeIndex(Transform boneTransform)
		{
			for (int i = 0; i < this.nodes.Length; i++)
			{
				if (this.nodes[i].transform == boneTransform)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x00022CE4 File Offset: 0x00020EE4
		public bool IsValid(ref string message)
		{
			if (this.nodes.Length == 0)
			{
				message = "FBIK chain contains no nodes.";
				return false;
			}
			IKSolver.Node[] array = this.nodes;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].transform == null)
				{
					message = "Node transform is null in FBIK chain.";
					return false;
				}
			}
			return true;
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x00022D34 File Offset: 0x00020F34
		public void Initiate(IKSolverFullBody solver)
		{
			this.initiated = false;
			foreach (IKSolver.Node node in this.nodes)
			{
				node.solverPosition = node.transform.position;
			}
			this.CalculateBoneLengths(solver);
			FBIKChain.ChildConstraint[] array2 = this.childConstraints;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Initiate(solver);
			}
			if (this.nodes.Length == 3)
			{
				this.bendConstraint.SetBones(this.nodes[0].transform, this.nodes[1].transform, this.nodes[2].transform);
				this.bendConstraint.Initiate(solver);
			}
			this.crossFades = new float[this.children.Length];
			this.initiated = true;
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x00022DF8 File Offset: 0x00020FF8
		public void ReadPose(IKSolverFullBody solver, bool fullBody)
		{
			if (!this.initiated)
			{
				return;
			}
			for (int i = 0; i < this.nodes.Length; i++)
			{
				this.nodes[i].solverPosition = this.nodes[i].transform.position + this.nodes[i].offset;
			}
			this.CalculateBoneLengths(solver);
			if (fullBody)
			{
				for (int j = 0; j < this.childConstraints.Length; j++)
				{
					this.childConstraints[j].OnPreSolve(solver);
				}
				if (this.children.Length != 0)
				{
					float num = this.nodes[this.nodes.Length - 1].effectorPositionWeight;
					for (int k = 0; k < this.children.Length; k++)
					{
						num += solver.chain[this.children[k]].nodes[0].effectorPositionWeight * solver.chain[this.children[k]].pull;
					}
					num = Mathf.Clamp(num, 1f, float.PositiveInfinity);
					for (int l = 0; l < this.children.Length; l++)
					{
						this.crossFades[l] = solver.chain[this.children[l]].nodes[0].effectorPositionWeight * solver.chain[this.children[l]].pull / num;
					}
				}
				this.pullParentSum = 0f;
				for (int m = 0; m < this.children.Length; m++)
				{
					this.pullParentSum += solver.chain[this.children[m]].pull;
				}
				this.pullParentSum = Mathf.Clamp(this.pullParentSum, 1f, float.PositiveInfinity);
				if (this.nodes.Length == 3)
				{
					this.reachForce = this.reach * Mathf.Clamp(this.nodes[2].effectorPositionWeight, 0f, 1f);
				}
				else
				{
					this.reachForce = 0f;
				}
				if (this.push > 0f && this.nodes.Length > 1)
				{
					this.distance = Vector3.Distance(this.nodes[0].transform.position, this.nodes[this.nodes.Length - 1].transform.position);
				}
			}
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x00023040 File Offset: 0x00021240
		private void CalculateBoneLengths(IKSolverFullBody solver)
		{
			this.length = 0f;
			for (int i = 0; i < this.nodes.Length - 1; i++)
			{
				this.nodes[i].length = Vector3.Distance(this.nodes[i].transform.position, this.nodes[i + 1].transform.position);
				this.length += this.nodes[i].length;
				if (this.nodes[i].length == 0f)
				{
					Warning.Log(string.Concat(new string[]
					{
						"Bone ",
						this.nodes[i].transform.name,
						" - ",
						this.nodes[i + 1].transform.name,
						" length is zero, can not solve."
					}), this.nodes[i].transform, false);
					return;
				}
			}
			for (int j = 0; j < this.children.Length; j++)
			{
				solver.chain[this.children[j]].rootLength = (solver.chain[this.children[j]].nodes[0].transform.position - this.nodes[this.nodes.Length - 1].transform.position).magnitude;
				if (solver.chain[this.children[j]].rootLength == 0f)
				{
					return;
				}
			}
			if (this.nodes.Length == 3)
			{
				this.sqrMag1 = this.nodes[0].length * this.nodes[0].length;
				this.sqrMag2 = this.nodes[1].length * this.nodes[1].length;
				this.sqrMagDif = this.sqrMag1 - this.sqrMag2;
			}
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0002322C File Offset: 0x0002142C
		public void Reach(IKSolverFullBody solver)
		{
			if (!this.initiated)
			{
				return;
			}
			for (int i = 0; i < this.children.Length; i++)
			{
				solver.chain[this.children[i]].Reach(solver);
			}
			if (this.reachForce <= 0f)
			{
				return;
			}
			Vector3 vector = this.nodes[2].solverPosition - this.nodes[0].solverPosition;
			if (vector == Vector3.zero)
			{
				return;
			}
			float magnitude = vector.magnitude;
			Vector3 a = vector / magnitude * this.length;
			float num = Mathf.Clamp(magnitude / this.length, 1f - this.reachForce, 1f + this.reachForce) - 1f;
			num = Mathf.Clamp(num + this.reachForce, -1f, 1f);
			FBIKChain.Smoothing smoothing = this.reachSmoothing;
			if (smoothing != FBIKChain.Smoothing.Exponential)
			{
				if (smoothing == FBIKChain.Smoothing.Cubic)
				{
					num *= num * num;
				}
			}
			else
			{
				num *= num;
			}
			Vector3 vector2 = a * Mathf.Clamp(num, 0f, magnitude);
			this.nodes[0].solverPosition += vector2 * (1f - this.nodes[0].effectorPositionWeight);
			this.nodes[2].solverPosition += vector2;
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0002338C File Offset: 0x0002158C
		public Vector3 Push(IKSolverFullBody solver)
		{
			Vector3 vector = Vector3.zero;
			for (int i = 0; i < this.children.Length; i++)
			{
				vector += solver.chain[this.children[i]].Push(solver) * solver.chain[this.children[i]].pushParent;
			}
			this.nodes[this.nodes.Length - 1].solverPosition += vector;
			if (this.nodes.Length < 2)
			{
				return Vector3.zero;
			}
			if (this.push <= 0f)
			{
				return Vector3.zero;
			}
			Vector3 a = this.nodes[2].solverPosition - this.nodes[0].solverPosition;
			float magnitude = a.magnitude;
			if (magnitude == 0f)
			{
				return Vector3.zero;
			}
			float num = 1f - magnitude / this.distance;
			if (num <= 0f)
			{
				return Vector3.zero;
			}
			FBIKChain.Smoothing smoothing = this.pushSmoothing;
			if (smoothing != FBIKChain.Smoothing.Exponential)
			{
				if (smoothing == FBIKChain.Smoothing.Cubic)
				{
					num *= num * num;
				}
			}
			else
			{
				num *= num;
			}
			Vector3 vector2 = -a * num * this.push;
			this.nodes[0].solverPosition += vector2;
			return vector2;
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x000234DC File Offset: 0x000216DC
		public void SolveTrigonometric(IKSolverFullBody solver, bool calculateBendDirection = false)
		{
			if (!this.initiated)
			{
				return;
			}
			for (int i = 0; i < this.children.Length; i++)
			{
				solver.chain[this.children[i]].SolveTrigonometric(solver, calculateBendDirection);
			}
			if (this.nodes.Length != 3)
			{
				return;
			}
			Vector3 a = this.nodes[2].solverPosition - this.nodes[0].solverPosition;
			float magnitude = a.magnitude;
			if (magnitude == 0f)
			{
				return;
			}
			float num = Mathf.Clamp(magnitude, 0f, this.length * 0.99999f);
			Vector3 direction = a / magnitude * num;
			Vector3 bendDirection = (calculateBendDirection && this.bendConstraint.initiated) ? this.bendConstraint.GetDir(solver) : (this.nodes[1].solverPosition - this.nodes[0].solverPosition);
			Vector3 dirToBendPoint = this.GetDirToBendPoint(direction, bendDirection, num);
			this.nodes[1].solverPosition = this.nodes[0].solverPosition + dirToBendPoint;
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x000235F0 File Offset: 0x000217F0
		public void Stage1(IKSolverFullBody solver)
		{
			for (int i = 0; i < this.children.Length; i++)
			{
				solver.chain[this.children[i]].Stage1(solver);
			}
			if (this.children.Length == 0)
			{
				this.ForwardReach(this.nodes[this.nodes.Length - 1].solverPosition);
				return;
			}
			Vector3 a = this.nodes[this.nodes.Length - 1].solverPosition;
			this.SolveChildConstraints(solver);
			for (int j = 0; j < this.children.Length; j++)
			{
				Vector3 a2 = solver.chain[this.children[j]].nodes[0].solverPosition;
				if (solver.chain[this.children[j]].rootLength > 0f)
				{
					a2 = this.SolveFABRIKJoint(this.nodes[this.nodes.Length - 1].solverPosition, solver.chain[this.children[j]].nodes[0].solverPosition, solver.chain[this.children[j]].rootLength);
				}
				if (this.pullParentSum > 0f)
				{
					a += (a2 - this.nodes[this.nodes.Length - 1].solverPosition) * (solver.chain[this.children[j]].pull / this.pullParentSum);
				}
			}
			this.ForwardReach(Vector3.Lerp(a, this.nodes[this.nodes.Length - 1].solverPosition, this.pin));
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x00023780 File Offset: 0x00021980
		public void Stage2(IKSolverFullBody solver, Vector3 position)
		{
			this.BackwardReach(position);
			int num = Mathf.Clamp(solver.iterations, 2, 4);
			if (this.childConstraints.Length != 0)
			{
				for (int i = 0; i < num; i++)
				{
					this.SolveConstraintSystems(solver);
				}
			}
			for (int j = 0; j < this.children.Length; j++)
			{
				solver.chain[this.children[j]].Stage2(solver, this.nodes[this.nodes.Length - 1].solverPosition);
			}
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x000237FC File Offset: 0x000219FC
		public void SolveConstraintSystems(IKSolverFullBody solver)
		{
			this.SolveChildConstraints(solver);
			for (int i = 0; i < this.children.Length; i++)
			{
				this.SolveLinearConstraint(this.nodes[this.nodes.Length - 1], solver.chain[this.children[i]].nodes[0], this.crossFades[i], solver.chain[this.children[i]].rootLength);
			}
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0002386C File Offset: 0x00021A6C
		private Vector3 SolveFABRIKJoint(Vector3 pos1, Vector3 pos2, float length)
		{
			return pos2 + (pos1 - pos2).normalized * length;
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x00023894 File Offset: 0x00021A94
		protected Vector3 GetDirToBendPoint(Vector3 direction, Vector3 bendDirection, float directionMagnitude)
		{
			float num = (directionMagnitude * directionMagnitude + this.sqrMagDif) / 2f / directionMagnitude;
			float y = (float)Math.Sqrt((double)Mathf.Clamp(this.sqrMag1 - num * num, 0f, float.PositiveInfinity));
			if (direction == Vector3.zero)
			{
				return Vector3.zero;
			}
			return Quaternion.LookRotation(direction, bendDirection) * new Vector3(0f, y, num);
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x00023900 File Offset: 0x00021B00
		private void SolveChildConstraints(IKSolverFullBody solver)
		{
			for (int i = 0; i < this.childConstraints.Length; i++)
			{
				this.childConstraints[i].Solve(solver);
			}
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00023930 File Offset: 0x00021B30
		private void SolveLinearConstraint(IKSolver.Node node1, IKSolver.Node node2, float crossFade, float distance)
		{
			Vector3 a = node2.solverPosition - node1.solverPosition;
			float magnitude = a.magnitude;
			if (distance == magnitude)
			{
				return;
			}
			if (magnitude == 0f)
			{
				return;
			}
			Vector3 a2 = a * (1f - distance / magnitude);
			node1.solverPosition += a2 * crossFade;
			node2.solverPosition -= a2 * (1f - crossFade);
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x000239B0 File Offset: 0x00021BB0
		public void ForwardReach(Vector3 position)
		{
			this.nodes[this.nodes.Length - 1].solverPosition = position;
			for (int i = this.nodes.Length - 2; i > -1; i--)
			{
				this.nodes[i].solverPosition = this.SolveFABRIKJoint(this.nodes[i].solverPosition, this.nodes[i + 1].solverPosition, this.nodes[i].length);
			}
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x00023A28 File Offset: 0x00021C28
		private void BackwardReach(Vector3 position)
		{
			if (this.rootLength > 0f)
			{
				position = this.SolveFABRIKJoint(this.nodes[0].solverPosition, position, this.rootLength);
			}
			this.nodes[0].solverPosition = position;
			for (int i = 1; i < this.nodes.Length; i++)
			{
				this.nodes[i].solverPosition = this.SolveFABRIKJoint(this.nodes[i].solverPosition, this.nodes[i - 1].solverPosition, this.nodes[i - 1].length);
			}
		}

		// Token: 0x04000520 RID: 1312
		[Range(0f, 1f)]
		public float pin;

		// Token: 0x04000521 RID: 1313
		[Range(0f, 1f)]
		public float pull = 1f;

		// Token: 0x04000522 RID: 1314
		[Range(0f, 1f)]
		public float push;

		// Token: 0x04000523 RID: 1315
		[Range(-1f, 1f)]
		public float pushParent;

		// Token: 0x04000524 RID: 1316
		[Range(0f, 1f)]
		public float reach = 0.1f;

		// Token: 0x04000525 RID: 1317
		public FBIKChain.Smoothing reachSmoothing = FBIKChain.Smoothing.Exponential;

		// Token: 0x04000526 RID: 1318
		public FBIKChain.Smoothing pushSmoothing = FBIKChain.Smoothing.Exponential;

		// Token: 0x04000527 RID: 1319
		public IKSolver.Node[] nodes = new IKSolver.Node[0];

		// Token: 0x04000528 RID: 1320
		public int[] children = new int[0];

		// Token: 0x04000529 RID: 1321
		public FBIKChain.ChildConstraint[] childConstraints = new FBIKChain.ChildConstraint[0];

		// Token: 0x0400052A RID: 1322
		public IKConstraintBend bendConstraint = new IKConstraintBend();

		// Token: 0x0400052B RID: 1323
		private float rootLength;

		// Token: 0x0400052C RID: 1324
		private bool initiated;

		// Token: 0x0400052D RID: 1325
		private float length;

		// Token: 0x0400052E RID: 1326
		private float distance;

		// Token: 0x0400052F RID: 1327
		private IKSolver.Point p;

		// Token: 0x04000530 RID: 1328
		private float reachForce;

		// Token: 0x04000531 RID: 1329
		private float pullParentSum;

		// Token: 0x04000532 RID: 1330
		private float[] crossFades;

		// Token: 0x04000533 RID: 1331
		private float sqrMag1;

		// Token: 0x04000534 RID: 1332
		private float sqrMag2;

		// Token: 0x04000535 RID: 1333
		private float sqrMagDif;

		// Token: 0x04000536 RID: 1334
		private const float maxLimbLength = 0.99999f;

		// Token: 0x020000BF RID: 191
		[Serializable]
		public class ChildConstraint
		{
			// Token: 0x1700009F RID: 159
			// (get) Token: 0x060005E7 RID: 1511 RVA: 0x00023ABD File Offset: 0x00021CBD
			// (set) Token: 0x060005E8 RID: 1512 RVA: 0x00023AC5 File Offset: 0x00021CC5
			public float nominalDistance { get; private set; }

			// Token: 0x170000A0 RID: 160
			// (get) Token: 0x060005E9 RID: 1513 RVA: 0x00023ACE File Offset: 0x00021CCE
			// (set) Token: 0x060005EA RID: 1514 RVA: 0x00023AD6 File Offset: 0x00021CD6
			public bool isRigid { get; private set; }

			// Token: 0x060005EB RID: 1515 RVA: 0x00023ADF File Offset: 0x00021CDF
			public ChildConstraint(Transform bone1, Transform bone2, float pushElasticity = 0f, float pullElasticity = 0f)
			{
				this.bone1 = bone1;
				this.bone2 = bone2;
				this.pushElasticity = pushElasticity;
				this.pullElasticity = pullElasticity;
			}

			// Token: 0x060005EC RID: 1516 RVA: 0x00023B04 File Offset: 0x00021D04
			public void Initiate(IKSolverFullBody solver)
			{
				this.chain1Index = solver.GetChainIndex(this.bone1);
				this.chain2Index = solver.GetChainIndex(this.bone2);
				this.OnPreSolve(solver);
			}

			// Token: 0x060005ED RID: 1517 RVA: 0x00023B34 File Offset: 0x00021D34
			public void OnPreSolve(IKSolverFullBody solver)
			{
				this.nominalDistance = Vector3.Distance(solver.chain[this.chain1Index].nodes[0].transform.position, solver.chain[this.chain2Index].nodes[0].transform.position);
				this.isRigid = (this.pushElasticity <= 0f && this.pullElasticity <= 0f);
				if (this.isRigid)
				{
					float num = solver.chain[this.chain1Index].pull - solver.chain[this.chain2Index].pull;
					this.crossFade = 1f - (0.5f + num * 0.5f);
				}
				else
				{
					this.crossFade = 0.5f;
				}
				this.inverseCrossFade = 1f - this.crossFade;
			}

			// Token: 0x060005EE RID: 1518 RVA: 0x00023C14 File Offset: 0x00021E14
			public void Solve(IKSolverFullBody solver)
			{
				if (this.pushElasticity >= 1f && this.pullElasticity >= 1f)
				{
					return;
				}
				Vector3 a = solver.chain[this.chain2Index].nodes[0].solverPosition - solver.chain[this.chain1Index].nodes[0].solverPosition;
				float magnitude = a.magnitude;
				if (magnitude == this.nominalDistance)
				{
					return;
				}
				if (magnitude == 0f)
				{
					return;
				}
				float num = 1f;
				if (!this.isRigid)
				{
					float num2 = (magnitude > this.nominalDistance) ? this.pullElasticity : this.pushElasticity;
					num = 1f - num2;
				}
				num *= 1f - this.nominalDistance / magnitude;
				Vector3 a2 = a * num;
				solver.chain[this.chain1Index].nodes[0].solverPosition += a2 * this.crossFade;
				solver.chain[this.chain2Index].nodes[0].solverPosition -= a2 * this.inverseCrossFade;
			}

			// Token: 0x04000537 RID: 1335
			public float pushElasticity;

			// Token: 0x04000538 RID: 1336
			public float pullElasticity;

			// Token: 0x04000539 RID: 1337
			[SerializeField]
			private Transform bone1;

			// Token: 0x0400053A RID: 1338
			[SerializeField]
			private Transform bone2;

			// Token: 0x0400053D RID: 1341
			private float crossFade;

			// Token: 0x0400053E RID: 1342
			private float inverseCrossFade;

			// Token: 0x0400053F RID: 1343
			private int chain1Index;

			// Token: 0x04000540 RID: 1344
			private int chain2Index;
		}

		// Token: 0x020000C0 RID: 192
		[Serializable]
		public enum Smoothing
		{
			// Token: 0x04000542 RID: 1346
			None,
			// Token: 0x04000543 RID: 1347
			Exponential,
			// Token: 0x04000544 RID: 1348
			Cubic
		}
	}
}
