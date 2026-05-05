using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000D3 RID: 211
	[Serializable]
	public class IKSolverFABRIKRoot : IKSolver
	{
		// Token: 0x060006B0 RID: 1712 RVA: 0x000289B4 File Offset: 0x00026BB4
		public override bool IsValid(ref string message)
		{
			if (this.chains.Length == 0)
			{
				message = "IKSolverFABRIKRoot contains no chains.";
				return false;
			}
			FABRIKChain[] array = this.chains;
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].IsValid(ref message))
				{
					return false;
				}
			}
			for (int j = 0; j < this.chains.Length; j++)
			{
				for (int k = 0; k < this.chains.Length; k++)
				{
					if (j != k && this.chains[j].ik == this.chains[k].ik)
					{
						message = this.chains[j].ik.name + " is represented more than once in IKSolverFABRIKRoot chain.";
						return false;
					}
				}
			}
			for (int l = 0; l < this.chains.Length; l++)
			{
				for (int m = 0; m < this.chains[l].children.Length; m++)
				{
					int num = this.chains[l].children[m];
					if (num < 0)
					{
						message = this.chains[l].ik.name + "IKSolverFABRIKRoot chain at index " + l.ToString() + " has invalid children array. Child index is < 0.";
						return false;
					}
					if (num == l)
					{
						message = this.chains[l].ik.name + "IKSolverFABRIKRoot chain at index " + l.ToString() + " has invalid children array. Child index is referencing to itself.";
						return false;
					}
					if (num >= this.chains.Length)
					{
						message = this.chains[l].ik.name + "IKSolverFABRIKRoot chain at index " + l.ToString() + " has invalid children array. Child index > number of chains";
						return false;
					}
					for (int n = 0; n < this.chains.Length; n++)
					{
						if (num == n)
						{
							for (int num2 = 0; num2 < this.chains[n].children.Length; num2++)
							{
								if (this.chains[n].children[num2] == l)
								{
									message = string.Concat(new string[]
									{
										"Circular parenting. ",
										this.chains[n].ik.name,
										" already has ",
										this.chains[l].ik.name,
										" listed as its child."
									});
									return false;
								}
							}
						}
					}
					for (int num3 = 0; num3 < this.chains[l].children.Length; num3++)
					{
						if (m != num3 && this.chains[l].children[num3] == num)
						{
							message = "Chain number " + num.ToString() + " is represented more than once in the children of " + this.chains[l].ik.name;
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x00028C6C File Offset: 0x00026E6C
		public override void StoreDefaultLocalState()
		{
			this.rootDefaultPosition = this.root.localPosition;
			for (int i = 0; i < this.chains.Length; i++)
			{
				this.chains[i].ik.solver.StoreDefaultLocalState();
			}
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x00028CB4 File Offset: 0x00026EB4
		public override void FixTransforms()
		{
			if (!base.initiated)
			{
				return;
			}
			this.root.localPosition = this.rootDefaultPosition;
			for (int i = 0; i < this.chains.Length; i++)
			{
				this.chains[i].ik.solver.FixTransforms();
			}
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x00028D08 File Offset: 0x00026F08
		protected override void OnInitiate()
		{
			for (int i = 0; i < this.chains.Length; i++)
			{
				this.chains[i].Initiate();
			}
			this.isRoot = new bool[this.chains.Length];
			for (int j = 0; j < this.chains.Length; j++)
			{
				this.isRoot[j] = this.IsRoot(j);
			}
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x00028D6C File Offset: 0x00026F6C
		private bool IsRoot(int index)
		{
			for (int i = 0; i < this.chains.Length; i++)
			{
				for (int j = 0; j < this.chains[i].children.Length; j++)
				{
					if (this.chains[i].children[j] == index)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x00028DBC File Offset: 0x00026FBC
		protected override void OnUpdate()
		{
			if (this.IKPositionWeight <= 0f && this.zeroWeightApplied)
			{
				return;
			}
			this.IKPositionWeight = Mathf.Clamp(this.IKPositionWeight, 0f, 1f);
			for (int i = 0; i < this.chains.Length; i++)
			{
				this.chains[i].ik.solver.IKPositionWeight = this.IKPositionWeight;
			}
			if (this.IKPositionWeight <= 0f)
			{
				this.zeroWeightApplied = true;
				return;
			}
			this.zeroWeightApplied = false;
			for (int j = 0; j < this.iterations; j++)
			{
				for (int k = 0; k < this.chains.Length; k++)
				{
					if (this.isRoot[k])
					{
						this.chains[k].Stage1(this.chains);
					}
				}
				Vector3 centroid = this.GetCentroid();
				this.root.position = centroid;
				for (int l = 0; l < this.chains.Length; l++)
				{
					if (this.isRoot[l])
					{
						this.chains[l].Stage2(centroid, this.chains);
					}
				}
			}
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x00028ED4 File Offset: 0x000270D4
		public override IKSolver.Point[] GetPoints()
		{
			IKSolver.Point[] result = new IKSolver.Point[0];
			for (int i = 0; i < this.chains.Length; i++)
			{
				this.AddPointsToArray(ref result, this.chains[i]);
			}
			return result;
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x00028F0C File Offset: 0x0002710C
		public override IKSolver.Point GetPoint(Transform transform)
		{
			for (int i = 0; i < this.chains.Length; i++)
			{
				IKSolver.Point point = this.chains[i].ik.solver.GetPoint(transform);
				if (point != null)
				{
					return point;
				}
			}
			return null;
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x00028F50 File Offset: 0x00027150
		private void AddPointsToArray(ref IKSolver.Point[] array, FABRIKChain chain)
		{
			IKSolver.Point[] points = chain.ik.solver.GetPoints();
			Array.Resize<IKSolver.Point>(ref array, array.Length + points.Length);
			int num = 0;
			for (int i = array.Length - points.Length; i < array.Length; i++)
			{
				array[i] = points[num];
				num++;
			}
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00028FA0 File Offset: 0x000271A0
		private Vector3 GetCentroid()
		{
			Vector3 vector = this.root.position;
			if (this.rootPin >= 1f)
			{
				return vector;
			}
			float num = 0f;
			for (int i = 0; i < this.chains.Length; i++)
			{
				if (this.isRoot[i])
				{
					num += this.chains[i].pull;
				}
			}
			for (int j = 0; j < this.chains.Length; j++)
			{
				if (this.isRoot[j] && num > 0f)
				{
					vector += (this.chains[j].ik.solver.bones[0].solverPosition - this.root.position) * (this.chains[j].pull / Mathf.Clamp(num, 1f, num));
				}
			}
			return Vector3.Lerp(vector, this.root.position, this.rootPin);
		}

		// Token: 0x040005E3 RID: 1507
		public int iterations = 4;

		// Token: 0x040005E4 RID: 1508
		[Range(0f, 1f)]
		public float rootPin;

		// Token: 0x040005E5 RID: 1509
		public FABRIKChain[] chains = new FABRIKChain[0];

		// Token: 0x040005E6 RID: 1510
		private bool zeroWeightApplied;

		// Token: 0x040005E7 RID: 1511
		private bool[] isRoot;

		// Token: 0x040005E8 RID: 1512
		private Vector3 rootDefaultPosition;
	}
}
