using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Collections;

namespace UnityEngine.Rendering
{
	// Token: 0x02000082 RID: 130
	internal class ProbeBrickIndex
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x0001145F File Offset: 0x0000F65F
		// (set) Token: 0x0600040E RID: 1038 RVA: 0x00011467 File Offset: 0x0000F667
		internal int estimatedVMemCost { get; private set; }

		// Token: 0x0600040F RID: 1039 RVA: 0x00011470 File Offset: 0x0000F670
		private int GetVoxelSubdivLevel()
		{
			return Mathf.Min(3, ProbeReferenceVolume.instance.GetMaxSubdivision() - 1);
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00011484 File Offset: 0x0000F684
		private int SizeOfPhysicalIndexFromBudget(ProbeVolumeTextureMemoryBudget memoryBudget)
		{
			if (memoryBudget == ProbeVolumeTextureMemoryBudget.MemoryBudgetLow)
			{
				return 16000000;
			}
			if (memoryBudget == ProbeVolumeTextureMemoryBudget.MemoryBudgetMedium)
			{
				return 32000000;
			}
			if (memoryBudget != ProbeVolumeTextureMemoryBudget.MemoryBudgetHigh)
			{
				return 32000000;
			}
			return 64000000;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x000114B8 File Offset: 0x0000F6B8
		internal ProbeBrickIndex(ProbeVolumeTextureMemoryBudget memoryBudget)
		{
			this.m_CenterRS = new Vector3Int(0, 0, 0);
			this.m_VoxelToBricks = new Dictionary<Vector3Int, List<ProbeBrickIndex.VoxelMeta>>();
			this.m_BricksToVoxels = new Dictionary<ProbeReferenceVolume.Cell, ProbeBrickIndex.BrickMeta>();
			this.m_NeedUpdateIndexComputeBuffer = false;
			this.m_IndexInChunks = Mathf.CeilToInt((float)this.SizeOfPhysicalIndexFromBudget(memoryBudget) / 243f);
			this.m_AvailableChunkCount = this.m_IndexInChunks;
			this.m_IndexChunks = new BitArray(Mathf.Max(1, this.m_IndexInChunks));
			int num = this.m_IndexInChunks * 243;
			this.m_PhysicalIndexBufferData = new int[num];
			this.m_PhysicalIndexBuffer = new ComputeBuffer(num, 4, ComputeBufferType.Structured);
			this.m_NextFreeChunk = 0;
			this.estimatedVMemCost = num * 4;
			this.Clear();
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0001160A File Offset: 0x0000F80A
		public int GetRemainingChunkCount()
		{
			return this.m_AvailableChunkCount;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00011614 File Offset: 0x0000F814
		internal void UploadIndexData()
		{
			int count = this.m_UpdateMaxIndex - this.m_UpdateMinIndex + 1;
			this.m_PhysicalIndexBuffer.SetData(this.m_PhysicalIndexBufferData, this.m_UpdateMinIndex, this.m_UpdateMinIndex, count);
			this.m_NeedUpdateIndexComputeBuffer = false;
			this.m_UpdateMaxIndex = int.MinValue;
			this.m_UpdateMinIndex = int.MaxValue;
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x0001166C File Offset: 0x0000F86C
		internal void Clear()
		{
			for (int i = 0; i < this.m_PhysicalIndexBufferData.Length; i++)
			{
				this.m_PhysicalIndexBufferData[i] = -1;
			}
			this.m_NeedUpdateIndexComputeBuffer = true;
			this.m_UpdateMinIndex = 0;
			this.m_UpdateMaxIndex = this.m_PhysicalIndexBufferData.Length - 1;
			this.m_NextFreeChunk = 0;
			this.m_IndexChunks.SetAll(false);
			foreach (List<ProbeBrickIndex.VoxelMeta> list in this.m_VoxelToBricks.Values)
			{
				foreach (ProbeBrickIndex.VoxelMeta element in list)
				{
					this.m_VoxelMetaPool.Release(element);
				}
				this.m_VoxelMetaListPool.Release(list);
			}
			this.m_VoxelToBricks.Clear();
			foreach (ProbeBrickIndex.BrickMeta element2 in this.m_BricksToVoxels.Values)
			{
				this.m_BrickMetaPool.Release(element2);
			}
			this.m_BricksToVoxels.Clear();
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x000117C0 File Offset: 0x0000F9C0
		private void MapBrickToVoxels(ProbeBrickIndex.Brick brick, HashSet<Vector3Int> voxels)
		{
			int subdivisionLevel = brick.subdivisionLevel;
			int num = (int)Mathf.Pow(3f, (float)Mathf.Max(0, subdivisionLevel - this.GetVoxelSubdivLevel()));
			Vector3Int position = brick.position;
			int num2 = ProbeReferenceVolume.CellSize(brick.subdivisionLevel);
			int num3 = ProbeReferenceVolume.CellSize(this.GetVoxelSubdivLevel());
			if (num <= 1)
			{
				Vector3 vector = brick.position;
				vector *= 1f / (float)num3;
				position = new Vector3Int(Mathf.FloorToInt(vector.x) * num3, Mathf.FloorToInt(vector.y) * num3, Mathf.FloorToInt(vector.z) * num3);
			}
			for (int i = position.z; i < position.z + num2; i += num3)
			{
				for (int j = position.y; j < position.y + num2; j += num3)
				{
					for (int k = position.x; k < position.x + num2; k += num3)
					{
						voxels.Add(new Vector3Int(k, j, i));
					}
				}
			}
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x000118CC File Offset: 0x0000FACC
		private void ClearVoxel(Vector3Int pos, ProbeBrickIndex.CellIndexUpdateInfo cellInfo)
		{
			Vector3Int brickMin;
			Vector3Int brickMax;
			this.ClipToIndexSpace(pos, this.GetVoxelSubdivLevel(), out brickMin, out brickMax, cellInfo);
			this.UpdatePhysicalIndex(brickMin, brickMax, -1, cellInfo);
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x000118F5 File Offset: 0x0000FAF5
		internal void GetRuntimeResources(ref ProbeReferenceVolume.RuntimeResources rr)
		{
			if (this.m_NeedUpdateIndexComputeBuffer)
			{
				this.UploadIndexData();
			}
			rr.index = this.m_PhysicalIndexBuffer;
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00011911 File Offset: 0x0000FB11
		internal void Cleanup()
		{
			CoreUtils.SafeRelease(this.m_PhysicalIndexBuffer);
			this.m_PhysicalIndexBuffer = null;
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00011925 File Offset: 0x0000FB25
		private int MergeIndex(int index, int size)
		{
			return (index & -1879048193) | (size & 7) << 28;
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00011938 File Offset: 0x0000FB38
		internal bool AssignIndexChunksToCell(int bricksCount, ref ProbeBrickIndex.CellIndexUpdateInfo cellUpdateInfo, bool ignoreErrorLog)
		{
			int num = Mathf.CeilToInt((float)bricksCount / 243f);
			int num2 = -1;
			for (int i = 0; i < this.m_IndexInChunks; i++)
			{
				if (!this.m_IndexChunks[i] && i + num < this.m_IndexInChunks)
				{
					int num3 = 0;
					int num4 = i;
					while (num4 < i + num && !this.m_IndexChunks[num4])
					{
						num3++;
						num4++;
					}
					if (num3 == num)
					{
						num2 = i;
						break;
					}
				}
			}
			if (num2 < 0)
			{
				if (!ignoreErrorLog)
				{
					Debug.LogError("APV Index Allocation failed.");
				}
				return false;
			}
			cellUpdateInfo.firstChunkIndex = num2;
			cellUpdateInfo.numberOfChunks = num;
			for (int j = num2; j < num2 + num; j++)
			{
				this.m_IndexChunks[j] = true;
			}
			this.m_NextFreeChunk += Mathf.Max(0, num2 + num - this.m_NextFreeChunk);
			this.m_AvailableChunkCount -= num;
			return true;
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00011A1C File Offset: 0x0000FC1C
		public void AddBricks(ProbeReferenceVolume.Cell cell, NativeArray<ProbeBrickIndex.Brick> bricks, List<ProbeBrickPool.BrickChunkAlloc> allocations, int allocationSize, int poolWidth, int poolHeight, ProbeBrickIndex.CellIndexUpdateInfo cellInfo)
		{
			int a = ProbeReferenceVolume.CellSize(7);
			ProbeBrickIndex.g_Cell = cell;
			ProbeBrickIndex.BrickMeta brickMeta = this.m_BrickMetaPool.Get();
			this.m_BricksToVoxels.Add(cell, brickMeta);
			int num = 0;
			for (int i = 0; i < allocations.Count; i++)
			{
				ProbeBrickPool.BrickChunkAlloc brickChunkAlloc = allocations[i];
				int num2 = Mathf.Min(allocationSize, bricks.Length - num);
				int j = 0;
				while (j < num2)
				{
					ProbeBrickIndex.Brick brick = bricks[num];
					int b = ProbeReferenceVolume.CellSize(brick.subdivisionLevel);
					a = Mathf.Min(a, b);
					this.MapBrickToVoxels(brick, brickMeta.voxels);
					ProbeBrickIndex.ReservedBrick item = default(ProbeBrickIndex.ReservedBrick);
					item.brick = brick;
					item.flattenedIdx = this.MergeIndex(brickChunkAlloc.flattenIndex(poolWidth, poolHeight), brick.subdivisionLevel);
					brickMeta.bricks.Add(item);
					foreach (Vector3Int key in brickMeta.voxels)
					{
						List<ProbeBrickIndex.VoxelMeta> list;
						if (!this.m_VoxelToBricks.TryGetValue(key, out list))
						{
							list = this.m_VoxelMetaListPool.Get();
							this.m_VoxelToBricks.Add(key, list);
						}
						int num3 = list.FindIndex((ProbeBrickIndex.VoxelMeta lhs) => lhs.cell == ProbeBrickIndex.g_Cell);
						ProbeBrickIndex.VoxelMeta voxelMeta;
						if (num3 == -1)
						{
							voxelMeta = this.m_VoxelMetaPool.Get();
							voxelMeta.cell = cell;
							list.Add(voxelMeta);
						}
						else
						{
							voxelMeta = list[num3];
						}
						voxelMeta.brickIndices.Add((ushort)num);
					}
					j++;
					num++;
					brickChunkAlloc.x += 4;
				}
			}
			foreach (Vector3Int voxel in brickMeta.voxels)
			{
				this.UpdateIndexForVoxel(voxel, cellInfo);
			}
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00011C3C File Offset: 0x0000FE3C
		public void RemoveBricks(ProbeReferenceVolume.CellInfo cellInfo)
		{
			if (!this.m_BricksToVoxels.ContainsKey(cellInfo.cell))
			{
				return;
			}
			ProbeBrickIndex.CellIndexUpdateInfo updateInfo = cellInfo.updateInfo;
			ProbeBrickIndex.g_Cell = cellInfo.cell;
			ProbeBrickIndex.BrickMeta brickMeta = this.m_BricksToVoxels[cellInfo.cell];
			foreach (Vector3Int vector3Int in brickMeta.voxels)
			{
				List<ProbeBrickIndex.VoxelMeta> list = this.m_VoxelToBricks[vector3Int];
				int num = list.FindIndex((ProbeBrickIndex.VoxelMeta lhs) => lhs.cell == ProbeBrickIndex.g_Cell);
				if (num >= 0)
				{
					this.m_VoxelMetaPool.Release(list[num]);
					list.RemoveAt(num);
					if (list.Count > 0)
					{
						this.UpdateIndexForVoxel(vector3Int, updateInfo);
					}
					else
					{
						this.ClearVoxel(vector3Int, updateInfo);
						this.m_VoxelMetaListPool.Release(list);
						this.m_VoxelToBricks.Remove(vector3Int);
					}
				}
			}
			this.m_BrickMetaPool.Release(brickMeta);
			this.m_BricksToVoxels.Remove(cellInfo.cell);
			for (int i = updateInfo.firstChunkIndex; i < updateInfo.firstChunkIndex + updateInfo.numberOfChunks; i++)
			{
				this.m_IndexChunks[i] = false;
			}
			this.m_AvailableChunkCount += updateInfo.numberOfChunks;
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00011DB4 File Offset: 0x0000FFB4
		private void UpdateIndexForVoxel(Vector3Int voxel, ProbeBrickIndex.CellIndexUpdateInfo cellInfo)
		{
			this.ClearVoxel(voxel, cellInfo);
			foreach (ProbeBrickIndex.VoxelMeta voxelMeta in this.m_VoxelToBricks[voxel])
			{
				List<ProbeBrickIndex.ReservedBrick> bricks = this.m_BricksToVoxels[voxelMeta.cell].bricks;
				List<ushort> brickIndices = voxelMeta.brickIndices;
				this.UpdateIndexForVoxel(voxel, bricks, brickIndices, cellInfo);
			}
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00011E38 File Offset: 0x00010038
		private void UpdatePhysicalIndex(Vector3Int brickMin, Vector3Int brickMax, int value, ProbeBrickIndex.CellIndexUpdateInfo cellInfo)
		{
			brickMin -= cellInfo.cellPositionInBricksAtMaxRes;
			brickMax -= cellInfo.cellPositionInBricksAtMaxRes;
			brickMin /= ProbeReferenceVolume.CellSize(cellInfo.minSubdivInCell);
			brickMax /= ProbeReferenceVolume.CellSize(cellInfo.minSubdivInCell);
			ProbeReferenceVolume.CellSize(ProbeReferenceVolume.instance.GetMaxSubdivision() - 1 - cellInfo.minSubdivInCell);
			Vector3Int b = cellInfo.minValidBrickIndexForCellAtMaxRes / ProbeReferenceVolume.CellSize(cellInfo.minSubdivInCell);
			Vector3Int a = cellInfo.maxValidBrickIndexForCellAtMaxResPlusOne / ProbeReferenceVolume.CellSize(cellInfo.minSubdivInCell);
			brickMin -= b;
			brickMax -= b;
			Vector3Int vector3Int = a - b;
			int num = cellInfo.firstChunkIndex * 243;
			int val = num + brickMin.z * (vector3Int.x * vector3Int.y) + brickMin.x * vector3Int.y + brickMin.y;
			int val2 = num + Math.Max(0, brickMax.z - 1) * (vector3Int.x * vector3Int.y) + Math.Max(0, brickMax.x - 1) * vector3Int.y + Math.Max(0, brickMax.y - 1);
			this.m_UpdateMinIndex = Math.Min(this.m_UpdateMinIndex, val);
			this.m_UpdateMaxIndex = Math.Max(this.m_UpdateMaxIndex, val2);
			for (int i = brickMin.x; i < brickMax.x; i++)
			{
				for (int j = brickMin.z; j < brickMax.z; j++)
				{
					for (int k = brickMin.y; k < brickMax.y; k++)
					{
						int num2 = j * (vector3Int.x * vector3Int.y) + i * vector3Int.y + k;
						int num3 = num + num2;
						this.m_PhysicalIndexBufferData[num3] = value;
					}
				}
			}
			this.m_NeedUpdateIndexComputeBuffer = true;
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0001202C File Offset: 0x0001022C
		private void ClipToIndexSpace(Vector3Int pos, int subdiv, out Vector3Int outMinpos, out Vector3Int outMaxpos, ProbeBrickIndex.CellIndexUpdateInfo cellInfo)
		{
			int num = ProbeReferenceVolume.CellSize(subdiv);
			Vector3Int vector3Int = cellInfo.cellPositionInBricksAtMaxRes + cellInfo.minValidBrickIndexForCellAtMaxRes;
			Vector3Int vector3Int2 = cellInfo.cellPositionInBricksAtMaxRes + cellInfo.maxValidBrickIndexForCellAtMaxResPlusOne - Vector3Int.one;
			int num2 = pos.x - this.m_CenterRS.x;
			int num3 = pos.y;
			int num4 = pos.z - this.m_CenterRS.z;
			int num5 = num2 + num;
			int num6 = num3 + num;
			int num7 = num4 + num;
			num2 = Mathf.Max(num2, vector3Int.x);
			num3 = Mathf.Max(num3, vector3Int.y);
			num4 = Mathf.Max(num4, vector3Int.z);
			num5 = Mathf.Min(num5, vector3Int2.x);
			num6 = Mathf.Min(num6, vector3Int2.y);
			num7 = Mathf.Min(num7, vector3Int2.z);
			outMinpos = new Vector3Int(num2, num3, num4);
			outMaxpos = new Vector3Int(num5, num6, num7);
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00012138 File Offset: 0x00010338
		private void UpdateIndexForVoxel(Vector3Int voxel, List<ProbeBrickIndex.ReservedBrick> bricks, List<ushort> indices, ProbeBrickIndex.CellIndexUpdateInfo cellInfo)
		{
			Vector3Int vector3Int;
			Vector3Int vector3Int2;
			this.ClipToIndexSpace(voxel, this.GetVoxelSubdivLevel(), out vector3Int, out vector3Int2, cellInfo);
			foreach (ProbeBrickIndex.ReservedBrick reservedBrick in bricks)
			{
				int b = ProbeReferenceVolume.CellSize(reservedBrick.brick.subdivisionLevel);
				Vector3Int position = reservedBrick.brick.position;
				Vector3Int brickMax = reservedBrick.brick.position + Vector3Int.one * b;
				position.x = Mathf.Max(vector3Int.x, position.x - this.m_CenterRS.x);
				position.y = Mathf.Max(vector3Int.y, position.y);
				position.z = Mathf.Max(vector3Int.z, position.z - this.m_CenterRS.z);
				brickMax.x = Mathf.Min(vector3Int2.x, brickMax.x - this.m_CenterRS.x);
				brickMax.y = Mathf.Min(vector3Int2.y, brickMax.y);
				brickMax.z = Mathf.Min(vector3Int2.z, brickMax.z - this.m_CenterRS.z);
				this.UpdatePhysicalIndex(position, brickMax, reservedBrick.flattenedIdx, cellInfo);
			}
		}

		// Token: 0x0400023F RID: 575
		internal const int kMaxSubdivisionLevels = 7;

		// Token: 0x04000240 RID: 576
		internal const int kIndexChunkSize = 243;

		// Token: 0x04000241 RID: 577
		private BitArray m_IndexChunks;

		// Token: 0x04000242 RID: 578
		private int m_IndexInChunks;

		// Token: 0x04000243 RID: 579
		private int m_NextFreeChunk;

		// Token: 0x04000244 RID: 580
		private int m_AvailableChunkCount;

		// Token: 0x04000245 RID: 581
		private ComputeBuffer m_PhysicalIndexBuffer;

		// Token: 0x04000246 RID: 582
		private int[] m_PhysicalIndexBufferData;

		// Token: 0x04000248 RID: 584
		private Vector3Int m_CenterRS;

		// Token: 0x04000249 RID: 585
		private Dictionary<Vector3Int, List<ProbeBrickIndex.VoxelMeta>> m_VoxelToBricks;

		// Token: 0x0400024A RID: 586
		private Dictionary<ProbeReferenceVolume.Cell, ProbeBrickIndex.BrickMeta> m_BricksToVoxels;

		// Token: 0x0400024B RID: 587
		private ObjectPool<ProbeBrickIndex.BrickMeta> m_BrickMetaPool = new ObjectPool<ProbeBrickIndex.BrickMeta>(delegate(ProbeBrickIndex.BrickMeta x)
		{
			x.Clear();
		}, null, false);

		// Token: 0x0400024C RID: 588
		private ObjectPool<List<ProbeBrickIndex.VoxelMeta>> m_VoxelMetaListPool = new ObjectPool<List<ProbeBrickIndex.VoxelMeta>>(delegate(List<ProbeBrickIndex.VoxelMeta> x)
		{
			x.Clear();
		}, null, false);

		// Token: 0x0400024D RID: 589
		private ObjectPool<ProbeBrickIndex.VoxelMeta> m_VoxelMetaPool = new ObjectPool<ProbeBrickIndex.VoxelMeta>(delegate(ProbeBrickIndex.VoxelMeta x)
		{
			x.Clear();
		}, null, false);

		// Token: 0x0400024E RID: 590
		private bool m_NeedUpdateIndexComputeBuffer;

		// Token: 0x0400024F RID: 591
		private int m_UpdateMinIndex = int.MaxValue;

		// Token: 0x04000250 RID: 592
		private int m_UpdateMaxIndex = int.MinValue;

		// Token: 0x04000251 RID: 593
		private static ProbeReferenceVolume.Cell g_Cell;

		// Token: 0x02000194 RID: 404
		[DebuggerDisplay("Brick [{position}, {subdivisionLevel}]")]
		[Serializable]
		public struct Brick : IEquatable<ProbeBrickIndex.Brick>
		{
			// Token: 0x06000ABE RID: 2750 RVA: 0x0002DD6A File Offset: 0x0002BF6A
			internal Brick(Vector3Int position, int subdivisionLevel)
			{
				this.position = position;
				this.subdivisionLevel = subdivisionLevel;
			}

			// Token: 0x06000ABF RID: 2751 RVA: 0x0002DD7A File Offset: 0x0002BF7A
			public bool Equals(ProbeBrickIndex.Brick other)
			{
				return this.position == other.position && this.subdivisionLevel == other.subdivisionLevel;
			}

			// Token: 0x04000683 RID: 1667
			public Vector3Int position;

			// Token: 0x04000684 RID: 1668
			public int subdivisionLevel;
		}

		// Token: 0x02000195 RID: 405
		[DebuggerDisplay("Brick [{brick.position}, {brick.subdivisionLevel}], {flattenedIdx}")]
		private struct ReservedBrick
		{
			// Token: 0x04000685 RID: 1669
			public ProbeBrickIndex.Brick brick;

			// Token: 0x04000686 RID: 1670
			public int flattenedIdx;
		}

		// Token: 0x02000196 RID: 406
		private class VoxelMeta
		{
			// Token: 0x06000AC0 RID: 2752 RVA: 0x0002DD9F File Offset: 0x0002BF9F
			public void Clear()
			{
				this.cell = null;
				this.brickIndices.Clear();
			}

			// Token: 0x04000687 RID: 1671
			public ProbeReferenceVolume.Cell cell;

			// Token: 0x04000688 RID: 1672
			public List<ushort> brickIndices = new List<ushort>();
		}

		// Token: 0x02000197 RID: 407
		private class BrickMeta
		{
			// Token: 0x06000AC2 RID: 2754 RVA: 0x0002DDC6 File Offset: 0x0002BFC6
			public void Clear()
			{
				this.voxels.Clear();
				this.bricks.Clear();
			}

			// Token: 0x04000689 RID: 1673
			public HashSet<Vector3Int> voxels = new HashSet<Vector3Int>();

			// Token: 0x0400068A RID: 1674
			public List<ProbeBrickIndex.ReservedBrick> bricks = new List<ProbeBrickIndex.ReservedBrick>();
		}

		// Token: 0x02000198 RID: 408
		public struct CellIndexUpdateInfo
		{
			// Token: 0x0400068B RID: 1675
			public int firstChunkIndex;

			// Token: 0x0400068C RID: 1676
			public int numberOfChunks;

			// Token: 0x0400068D RID: 1677
			public int minSubdivInCell;

			// Token: 0x0400068E RID: 1678
			public Vector3Int minValidBrickIndexForCellAtMaxRes;

			// Token: 0x0400068F RID: 1679
			public Vector3Int maxValidBrickIndexForCellAtMaxResPlusOne;

			// Token: 0x04000690 RID: 1680
			public Vector3Int cellPositionInBricksAtMaxRes;
		}
	}
}
