using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000D4 RID: 212
	[Serializable]
	public class IKSolverFullBody : IKSolver
	{
		// Token: 0x060006BB RID: 1723 RVA: 0x000290A8 File Offset: 0x000272A8
		public IKEffector GetEffector(Transform t)
		{
			for (int i = 0; i < this.effectors.Length; i++)
			{
				if (this.effectors[i].bone == t)
				{
					return this.effectors[i];
				}
			}
			return null;
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x000290E8 File Offset: 0x000272E8
		public FBIKChain GetChain(Transform transform)
		{
			int chainIndex = this.GetChainIndex(transform);
			if (chainIndex == -1)
			{
				return null;
			}
			return this.chain[chainIndex];
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x0002910C File Offset: 0x0002730C
		public int GetChainIndex(Transform transform)
		{
			for (int i = 0; i < this.chain.Length; i++)
			{
				for (int j = 0; j < this.chain[i].nodes.Length; j++)
				{
					if (this.chain[i].nodes[j].transform == transform)
					{
						return i;
					}
				}
			}
			return -1;
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00029165 File Offset: 0x00027365
		public IKSolver.Node GetNode(int chainIndex, int nodeIndex)
		{
			return this.chain[chainIndex].nodes[nodeIndex];
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00029176 File Offset: 0x00027376
		public void GetChainAndNodeIndexes(Transform transform, out int chainIndex, out int nodeIndex)
		{
			chainIndex = this.GetChainIndex(transform);
			if (chainIndex == -1)
			{
				nodeIndex = -1;
				return;
			}
			nodeIndex = this.chain[chainIndex].GetNodeIndex(transform);
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x0002919C File Offset: 0x0002739C
		public override IKSolver.Point[] GetPoints()
		{
			int num = 0;
			for (int i = 0; i < this.chain.Length; i++)
			{
				num += this.chain[i].nodes.Length;
			}
			IKSolver.Point[] array = new IKSolver.Point[num];
			int num2 = 0;
			for (int j = 0; j < this.chain.Length; j++)
			{
				for (int k = 0; k < this.chain[j].nodes.Length; k++)
				{
					array[num2] = this.chain[j].nodes[k];
					num2++;
				}
			}
			return array;
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x00029228 File Offset: 0x00027428
		public override IKSolver.Point GetPoint(Transform transform)
		{
			for (int i = 0; i < this.chain.Length; i++)
			{
				for (int j = 0; j < this.chain[i].nodes.Length; j++)
				{
					if (this.chain[i].nodes[j].transform == transform)
					{
						return this.chain[i].nodes[j];
					}
				}
			}
			return null;
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00029290 File Offset: 0x00027490
		public override bool IsValid(ref string message)
		{
			if (this.chain == null)
			{
				message = "FBIK chain is null, can't initiate solver.";
				return false;
			}
			if (this.chain.Length == 0)
			{
				message = "FBIK chain length is 0, can't initiate solver.";
				return false;
			}
			for (int i = 0; i < this.chain.Length; i++)
			{
				if (!this.chain[i].IsValid(ref message))
				{
					return false;
				}
			}
			IKEffector[] array = this.effectors;
			for (int j = 0; j < array.Length; j++)
			{
				if (!array[j].IsValid(this, ref message))
				{
					return false;
				}
			}
			if (!this.spineMapping.IsValid(this, ref message))
			{
				return false;
			}
			IKMappingLimb[] array2 = this.limbMappings;
			for (int j = 0; j < array2.Length; j++)
			{
				if (!array2[j].IsValid(this, ref message))
				{
					return false;
				}
			}
			IKMappingBone[] array3 = this.boneMappings;
			for (int j = 0; j < array3.Length; j++)
			{
				if (!array3[j].IsValid(this, ref message))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x00029364 File Offset: 0x00027564
		public override void StoreDefaultLocalState()
		{
			this.spineMapping.StoreDefaultLocalState();
			for (int i = 0; i < this.limbMappings.Length; i++)
			{
				this.limbMappings[i].StoreDefaultLocalState();
			}
			for (int j = 0; j < this.boneMappings.Length; j++)
			{
				this.boneMappings[j].StoreDefaultLocalState();
			}
			if (this.OnStoreDefaultLocalState != null)
			{
				this.OnStoreDefaultLocalState();
			}
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x000293D0 File Offset: 0x000275D0
		public override void FixTransforms()
		{
			if (!base.initiated)
			{
				return;
			}
			if (this.IKPositionWeight <= 0f)
			{
				return;
			}
			this.spineMapping.FixTransforms();
			for (int i = 0; i < this.limbMappings.Length; i++)
			{
				this.limbMappings[i].FixTransforms();
			}
			for (int j = 0; j < this.boneMappings.Length; j++)
			{
				this.boneMappings[j].FixTransforms();
			}
			if (this.OnFixTransforms != null)
			{
				this.OnFixTransforms();
			}
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x00029454 File Offset: 0x00027654
		protected override void OnInitiate()
		{
			for (int i = 0; i < this.chain.Length; i++)
			{
				this.chain[i].Initiate(this);
			}
			IKEffector[] array = this.effectors;
			for (int j = 0; j < array.Length; j++)
			{
				array[j].Initiate(this);
			}
			this.spineMapping.Initiate(this);
			IKMappingBone[] array2 = this.boneMappings;
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j].Initiate(this);
			}
			IKMappingLimb[] array3 = this.limbMappings;
			for (int j = 0; j < array3.Length; j++)
			{
				array3[j].Initiate(this);
			}
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x000294EC File Offset: 0x000276EC
		protected override void OnUpdate()
		{
			if (this.IKPositionWeight <= 0f)
			{
				for (int i = 0; i < this.effectors.Length; i++)
				{
					this.effectors[i].positionOffset = Vector3.zero;
				}
				return;
			}
			if (this.chain.Length == 0)
			{
				return;
			}
			this.IKPositionWeight = Mathf.Clamp(this.IKPositionWeight, 0f, 1f);
			if (this.OnPreRead != null)
			{
				this.OnPreRead();
			}
			this.ReadPose();
			if (this.OnPreSolve != null)
			{
				this.OnPreSolve();
			}
			this.Solve();
			if (this.OnPostSolve != null)
			{
				this.OnPostSolve();
			}
			this.WritePose();
			for (int j = 0; j < this.effectors.Length; j++)
			{
				this.effectors[j].OnPostWrite();
			}
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x000295BC File Offset: 0x000277BC
		protected virtual void ReadPose()
		{
			for (int i = 0; i < this.chain.Length; i++)
			{
				if (this.chain[i].bendConstraint.initiated)
				{
					this.chain[i].bendConstraint.LimitBend(this.IKPositionWeight, this.GetEffector(this.chain[i].nodes[2].transform).positionWeight);
				}
			}
			for (int j = 0; j < this.effectors.Length; j++)
			{
				this.effectors[j].ResetOffset(this);
			}
			for (int k = 0; k < this.effectors.Length; k++)
			{
				this.effectors[k].OnPreSolve(this);
			}
			for (int l = 0; l < this.chain.Length; l++)
			{
				this.chain[l].ReadPose(this, this.iterations > 0);
			}
			if (this.iterations > 0)
			{
				this.spineMapping.ReadPose();
				for (int m = 0; m < this.boneMappings.Length; m++)
				{
					this.boneMappings[m].ReadPose();
				}
			}
			for (int n = 0; n < this.limbMappings.Length; n++)
			{
				this.limbMappings[n].ReadPose();
			}
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x000296F4 File Offset: 0x000278F4
		protected virtual void Solve()
		{
			if (this.iterations > 0)
			{
				for (int i = 0; i < (this.FABRIKPass ? this.iterations : 1); i++)
				{
					if (this.OnPreIteration != null)
					{
						this.OnPreIteration(i);
					}
					for (int j = 0; j < this.effectors.Length; j++)
					{
						if (this.effectors[j].isEndEffector)
						{
							this.effectors[j].Update(this);
						}
					}
					if (this.FABRIKPass)
					{
						this.chain[0].Push(this);
						if (this.FABRIKPass)
						{
							this.chain[0].Reach(this);
						}
						for (int k = 0; k < this.effectors.Length; k++)
						{
							if (!this.effectors[k].isEndEffector)
							{
								this.effectors[k].Update(this);
							}
						}
					}
					this.chain[0].SolveTrigonometric(this, false);
					if (this.FABRIKPass)
					{
						this.chain[0].Stage1(this);
						for (int l = 0; l < this.effectors.Length; l++)
						{
							if (!this.effectors[l].isEndEffector)
							{
								this.effectors[l].Update(this);
							}
						}
						this.chain[0].Stage2(this, this.chain[0].nodes[0].solverPosition);
					}
					if (this.OnPostIteration != null)
					{
						this.OnPostIteration(i);
					}
				}
			}
			if (this.OnPreBend != null)
			{
				this.OnPreBend();
			}
			for (int m = 0; m < this.effectors.Length; m++)
			{
				if (this.effectors[m].isEndEffector)
				{
					this.effectors[m].Update(this);
				}
			}
			this.ApplyBendConstraints();
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x000298AA File Offset: 0x00027AAA
		protected virtual void ApplyBendConstraints()
		{
			this.chain[0].SolveTrigonometric(this, true);
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x000298BC File Offset: 0x00027ABC
		protected virtual void WritePose()
		{
			if (this.IKPositionWeight <= 0f)
			{
				return;
			}
			if (this.iterations > 0)
			{
				this.spineMapping.WritePose(this);
				for (int i = 0; i < this.boneMappings.Length; i++)
				{
					this.boneMappings[i].WritePose(this.IKPositionWeight);
				}
			}
			for (int j = 0; j < this.limbMappings.Length; j++)
			{
				this.limbMappings[j].WritePose(this, this.iterations > 0);
			}
		}

		// Token: 0x040005E9 RID: 1513
		[Range(0f, 10f)]
		public int iterations = 4;

		// Token: 0x040005EA RID: 1514
		public FBIKChain[] chain = new FBIKChain[0];

		// Token: 0x040005EB RID: 1515
		public IKEffector[] effectors = new IKEffector[0];

		// Token: 0x040005EC RID: 1516
		public IKMappingSpine spineMapping = new IKMappingSpine();

		// Token: 0x040005ED RID: 1517
		public IKMappingBone[] boneMappings = new IKMappingBone[0];

		// Token: 0x040005EE RID: 1518
		public IKMappingLimb[] limbMappings = new IKMappingLimb[0];

		// Token: 0x040005EF RID: 1519
		public bool FABRIKPass = true;

		// Token: 0x040005F0 RID: 1520
		public IKSolver.UpdateDelegate OnPreRead;

		// Token: 0x040005F1 RID: 1521
		public IKSolver.UpdateDelegate OnPreSolve;

		// Token: 0x040005F2 RID: 1522
		public IKSolver.IterationDelegate OnPreIteration;

		// Token: 0x040005F3 RID: 1523
		public IKSolver.IterationDelegate OnPostIteration;

		// Token: 0x040005F4 RID: 1524
		public IKSolver.UpdateDelegate OnPreBend;

		// Token: 0x040005F5 RID: 1525
		public IKSolver.UpdateDelegate OnPostSolve;

		// Token: 0x040005F6 RID: 1526
		public IKSolver.UpdateDelegate OnStoreDefaultLocalState;

		// Token: 0x040005F7 RID: 1527
		public IKSolver.UpdateDelegate OnFixTransforms;
	}
}
