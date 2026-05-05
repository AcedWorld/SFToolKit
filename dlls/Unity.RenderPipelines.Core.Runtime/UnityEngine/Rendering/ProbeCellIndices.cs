using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000085 RID: 133
	internal class ProbeCellIndices
	{
		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600044A RID: 1098 RVA: 0x000134CC File Offset: 0x000116CC
		// (set) Token: 0x0600044B RID: 1099 RVA: 0x000134D4 File Offset: 0x000116D4
		internal int estimatedVMemCost { get; private set; }

		// Token: 0x0600044C RID: 1100 RVA: 0x000134DD File Offset: 0x000116DD
		internal Vector3Int GetCellIndexDimension()
		{
			return this.m_CellCount;
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x000134E5 File Offset: 0x000116E5
		internal Vector3Int GetCellMinPosition()
		{
			return this.m_CellMin;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x000134ED File Offset: 0x000116ED
		private int GetFlatIndex(Vector3Int normalizedPos)
		{
			return normalizedPos.z * (this.m_CellCount.x * this.m_CellCount.y) + normalizedPos.y * this.m_CellCount.x + normalizedPos.x;
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0001352C File Offset: 0x0001172C
		internal ProbeCellIndices(Vector3Int cellMin, Vector3Int cellMax, int cellSizeInMinBricks)
		{
			Vector3Int cellCount = cellMax + Vector3Int.one - cellMin;
			this.m_CellCount = cellCount;
			this.m_CellMin = cellMin;
			this.m_CellSizeInMinBricks = cellSizeInMinBricks;
			int num = cellCount.x * cellCount.y * cellCount.z;
			int num2 = 3 * num;
			this.m_IndexOfIndicesBuffer = new ComputeBuffer(num, 12);
			this.m_IndexOfIndicesData = new uint[num2];
			this.m_NeedUpdateComputeBuffer = false;
			this.estimatedVMemCost = num * 3 * 4;
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x000135B0 File Offset: 0x000117B0
		internal int GetFlatIdxForCell(Vector3Int cellPosition)
		{
			Vector3Int normalizedPos = cellPosition - this.m_CellMin;
			return this.GetFlatIndex(normalizedPos);
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x000135D4 File Offset: 0x000117D4
		internal void UpdateCell(int cellFlatIdx, ProbeBrickIndex.CellIndexUpdateInfo cellUpdateInfo)
		{
			int b = ProbeReferenceVolume.CellSize(cellUpdateInfo.minSubdivInCell);
			ProbeCellIndices.IndexMetaData indexMetaData = default(ProbeCellIndices.IndexMetaData);
			indexMetaData.minSubdiv = cellUpdateInfo.minSubdivInCell;
			indexMetaData.minLocalIdx = cellUpdateInfo.minValidBrickIndexForCellAtMaxRes / b;
			indexMetaData.maxLocalIdx = cellUpdateInfo.maxValidBrickIndexForCellAtMaxResPlusOne / b;
			indexMetaData.firstChunkIndex = cellUpdateInfo.firstChunkIndex;
			uint[] array;
			indexMetaData.Pack(out array);
			for (int i = 0; i < 3; i++)
			{
				this.m_IndexOfIndicesData[cellFlatIdx * 3 + i] = array[i];
			}
			this.m_NeedUpdateComputeBuffer = true;
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00013660 File Offset: 0x00011860
		internal void MarkCellAsUnloaded(int cellFlatIdx)
		{
			for (int i = 0; i < 3; i++)
			{
				this.m_IndexOfIndicesData[cellFlatIdx * 3 + i] = uint.MaxValue;
			}
			this.m_NeedUpdateComputeBuffer = true;
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x0001368D File Offset: 0x0001188D
		internal void PushComputeData()
		{
			this.m_IndexOfIndicesBuffer.SetData(this.m_IndexOfIndicesData);
			this.m_NeedUpdateComputeBuffer = false;
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x000136A7 File Offset: 0x000118A7
		internal void GetRuntimeResources(ref ProbeReferenceVolume.RuntimeResources rr)
		{
			if (this.m_NeedUpdateComputeBuffer)
			{
				this.PushComputeData();
			}
			rr.cellIndices = this.m_IndexOfIndicesBuffer;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x000136C3 File Offset: 0x000118C3
		internal void Cleanup()
		{
			CoreUtils.SafeRelease(this.m_IndexOfIndicesBuffer);
			this.m_IndexOfIndicesBuffer = null;
		}

		// Token: 0x0400027E RID: 638
		private const int kUintPerEntry = 3;

		// Token: 0x04000280 RID: 640
		private ComputeBuffer m_IndexOfIndicesBuffer;

		// Token: 0x04000281 RID: 641
		private uint[] m_IndexOfIndicesData;

		// Token: 0x04000282 RID: 642
		private Vector3Int m_CellCount;

		// Token: 0x04000283 RID: 643
		private Vector3Int m_CellMin;

		// Token: 0x04000284 RID: 644
		private int m_CellSizeInMinBricks;

		// Token: 0x04000285 RID: 645
		private bool m_NeedUpdateComputeBuffer;

		// Token: 0x0200019C RID: 412
		internal struct IndexMetaData
		{
			// Token: 0x06000ACD RID: 2765 RVA: 0x0002DF04 File Offset: 0x0002C104
			internal void Pack(out uint[] vals)
			{
				vals = ProbeCellIndices.IndexMetaData.s_PackedValues;
				for (int i = 0; i < 3; i++)
				{
					vals[i] = 0U;
				}
				vals[0] = (uint)(this.firstChunkIndex & 536870911);
				vals[0] |= (uint)((uint)(this.minSubdiv & 7) << 29);
				vals[1] = (uint)(this.minLocalIdx.x & 1023);
				vals[1] |= (uint)((uint)(this.minLocalIdx.y & 1023) << 10);
				vals[1] |= (uint)((uint)(this.minLocalIdx.z & 1023) << 20);
				vals[2] = (uint)(this.maxLocalIdx.x & 1023);
				vals[2] |= (uint)((uint)(this.maxLocalIdx.y & 1023) << 10);
				vals[2] |= (uint)((uint)(this.maxLocalIdx.z & 1023) << 20);
			}

			// Token: 0x040006A5 RID: 1701
			private static uint[] s_PackedValues = new uint[3];

			// Token: 0x040006A6 RID: 1702
			internal Vector3Int minLocalIdx;

			// Token: 0x040006A7 RID: 1703
			internal Vector3Int maxLocalIdx;

			// Token: 0x040006A8 RID: 1704
			internal int firstChunkIndex;

			// Token: 0x040006A9 RID: 1705
			internal int minSubdiv;
		}
	}
}
