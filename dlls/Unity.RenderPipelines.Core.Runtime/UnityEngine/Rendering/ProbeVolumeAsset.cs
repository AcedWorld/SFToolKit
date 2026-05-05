using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace UnityEngine.Rendering
{
	// Token: 0x02000091 RID: 145
	[PreferBinarySerialization]
	internal class ProbeVolumeAsset : ScriptableObject
	{
		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x000174AE File Offset: 0x000156AE
		public int Version
		{
			get
			{
				return this.m_Version;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x000174B6 File Offset: 0x000156B6
		internal int maxSubdivision
		{
			get
			{
				return this.simplificationLevels + 1;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x000174C0 File Offset: 0x000156C0
		internal float minBrickSize
		{
			get
			{
				return Mathf.Max(0.01f, this.minDistanceBetweenProbes * 3f);
			}
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x000174D8 File Offset: 0x000156D8
		internal bool CompatibleWith(ProbeVolumeAsset otherAsset)
		{
			return this.maxSubdivision == otherAsset.maxSubdivision && this.minBrickSize == otherAsset.minBrickSize && this.cellSizeInBricks == otherAsset.cellSizeInBricks && this.chunkSizeInBricks == otherAsset.chunkSizeInBricks;
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00017514 File Offset: 0x00015714
		internal bool IsInvalid()
		{
			return this.maxCellPosition.x < this.minCellPosition.x || this.maxCellPosition.y < this.minCellPosition.y || this.maxCellPosition.z < this.minCellPosition.z;
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0001756B File Offset: 0x0001576B
		public string GetSerializedFullPath()
		{
			return this.m_AssetFullPath;
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00017574 File Offset: 0x00015774
		private static int AlignUp16(int count)
		{
			int num = 16;
			int num2 = count % num;
			return count + ((num2 == 0) ? 0 : (num - num2));
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00017594 File Offset: 0x00015794
		private NativeArray<T> GetSubArray<T>(NativeArray<byte> input, int count, ref int offset) where T : struct
		{
			int num = count * UnsafeUtility.SizeOf<T>();
			if (offset + num > input.Length)
			{
				return default(NativeArray<T>);
			}
			NativeArray<T> result = input.GetSubArray(offset, num).Reinterpret<T>(1);
			offset = ProbeVolumeAsset.AlignUp16(offset + num);
			return result;
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x000175E0 File Offset: 0x000157E0
		internal bool ResolveSharedCellData(TextAsset cellSharedDataAsset, TextAsset cellSupportDataAsset)
		{
			if (cellSharedDataAsset == null)
			{
				return false;
			}
			int num = this.chunkSizeInBricks * 64;
			int count = this.totalCellCounts.chunksCount * num;
			NativeArray<byte> data = cellSharedDataAsset.GetData<byte>();
			int num2 = 0;
			NativeArray<ProbeBrickIndex.Brick> subArray = this.GetSubArray<ProbeBrickIndex.Brick>(data, this.totalCellCounts.bricksCount, ref num2);
			NativeArray<byte> subArray2 = this.GetSubArray<byte>(data, count, ref num2);
			if (num2 != ProbeVolumeAsset.AlignUp16(data.Length))
			{
				return false;
			}
			NativeArray<byte> input = cellSupportDataAsset ? cellSupportDataAsset.GetData<byte>() : default(NativeArray<byte>);
			bool isCreated = input.IsCreated;
			num2 = 0;
			NativeArray<Vector3> nativeArray = isCreated ? this.GetSubArray<Vector3>(input, count, ref num2) : default(NativeArray<Vector3>);
			NativeArray<float> nativeArray2 = isCreated ? this.GetSubArray<float>(input, count, ref num2) : default(NativeArray<float>);
			NativeArray<float> nativeArray3 = isCreated ? this.GetSubArray<float>(input, count, ref num2) : default(NativeArray<float>);
			NativeArray<Vector3> nativeArray4 = isCreated ? this.GetSubArray<Vector3>(input, count, ref num2) : default(NativeArray<Vector3>);
			if (isCreated && num2 != ProbeVolumeAsset.AlignUp16(input.Length))
			{
				return false;
			}
			ProbeVolumeAsset.CellCounts cellCounts = default(ProbeVolumeAsset.CellCounts);
			for (int i = 0; i < this.cells.Length; i++)
			{
				ProbeReferenceVolume.Cell cell = this.cells[i];
				ProbeVolumeAsset.CellCounts cellCounts2 = this.cellCounts[i];
				int start = cellCounts.chunksCount * num;
				int length = cellCounts2.chunksCount * num;
				cell.bricks = subArray.GetSubArray(cellCounts.bricksCount, cellCounts2.bricksCount);
				cell.validityNeighMaskData = subArray2.GetSubArray(start, length);
				if (isCreated)
				{
					cell.probePositions = nativeArray.GetSubArray(start, length);
					cell.touchupVolumeInteraction = nativeArray2.GetSubArray(start, length);
					cell.offsetVectors = nativeArray4.GetSubArray(start, length);
					cell.validity = nativeArray3.GetSubArray(start, length);
				}
				cellCounts.Add(cellCounts2);
			}
			return true;
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x000177D8 File Offset: 0x000159D8
		internal bool ResolvePerScenarioCellData(TextAsset cellDataAsset, TextAsset cellOptionalDataAsset, int stateIndex)
		{
			if (cellDataAsset == null)
			{
				return false;
			}
			int num = this.chunkSizeInBricks * 64;
			int num2 = this.totalCellCounts.chunksCount * num;
			NativeArray<byte> data = cellDataAsset.GetData<byte>();
			int num3 = 0;
			NativeArray<ushort> subArray = this.GetSubArray<ushort>(data, num2 * 4, ref num3);
			NativeArray<byte> subArray2 = this.GetSubArray<byte>(data, num2 * 4, ref num3);
			NativeArray<byte> subArray3 = this.GetSubArray<byte>(data, num2 * 4, ref num3);
			if (num3 != ProbeVolumeAsset.AlignUp16(data.Length))
			{
				return false;
			}
			NativeArray<byte> input = cellOptionalDataAsset ? cellOptionalDataAsset.GetData<byte>() : default(NativeArray<byte>);
			bool isCreated = input.IsCreated;
			num3 = 0;
			NativeArray<byte> subArray4 = this.GetSubArray<byte>(input, num2 * 4, ref num3);
			NativeArray<byte> subArray5 = this.GetSubArray<byte>(input, num2 * 4, ref num3);
			NativeArray<byte> subArray6 = this.GetSubArray<byte>(input, num2 * 4, ref num3);
			NativeArray<byte> subArray7 = this.GetSubArray<byte>(input, num2 * 4, ref num3);
			if (isCreated && num3 != ProbeVolumeAsset.AlignUp16(input.Length))
			{
				return false;
			}
			ProbeVolumeAsset.CellCounts cellCounts = default(ProbeVolumeAsset.CellCounts);
			for (int i = 0; i < this.cells.Length; i++)
			{
				ProbeVolumeAsset.CellCounts cellCounts2 = this.cellCounts[i];
				ProbeReferenceVolume.Cell.PerScenarioData perScenarioData = default(ProbeReferenceVolume.Cell.PerScenarioData);
				int start = cellCounts.chunksCount * num * 4;
				int length = cellCounts2.chunksCount * num * 4;
				perScenarioData.shL0L1RxData = subArray.GetSubArray(start, length);
				perScenarioData.shL1GL1RyData = subArray2.GetSubArray(start, length);
				perScenarioData.shL1BL1RzData = subArray3.GetSubArray(start, length);
				if (isCreated)
				{
					perScenarioData.shL2Data_0 = subArray4.GetSubArray(start, length);
					perScenarioData.shL2Data_1 = subArray5.GetSubArray(start, length);
					perScenarioData.shL2Data_2 = subArray6.GetSubArray(start, length);
					perScenarioData.shL2Data_3 = subArray7.GetSubArray(start, length);
				}
				if (stateIndex == 0)
				{
					this.cells[i].scenario0 = perScenarioData;
				}
				else
				{
					this.cells[i].scenario1 = perScenarioData;
				}
				cellCounts.Add(cellCounts2);
			}
			return true;
		}

		// Token: 0x04000322 RID: 802
		[SerializeField]
		protected internal int m_Version = 5;

		// Token: 0x04000323 RID: 803
		[SerializeField]
		internal ProbeReferenceVolume.Cell[] cells;

		// Token: 0x04000324 RID: 804
		[SerializeField]
		internal ProbeVolumeAsset.CellCounts[] cellCounts;

		// Token: 0x04000325 RID: 805
		[SerializeField]
		internal ProbeVolumeAsset.CellCounts totalCellCounts;

		// Token: 0x04000326 RID: 806
		[SerializeField]
		internal Vector3Int maxCellPosition;

		// Token: 0x04000327 RID: 807
		[SerializeField]
		internal Vector3Int minCellPosition;

		// Token: 0x04000328 RID: 808
		[SerializeField]
		internal Bounds globalBounds;

		// Token: 0x04000329 RID: 809
		[SerializeField]
		internal ProbeVolumeSHBands bands;

		// Token: 0x0400032A RID: 810
		[SerializeField]
		internal int chunkSizeInBricks;

		// Token: 0x0400032B RID: 811
		[SerializeField]
		private string m_AssetFullPath = "UNINITIALIZED!";

		// Token: 0x0400032C RID: 812
		[SerializeField]
		internal int cellSizeInBricks;

		// Token: 0x0400032D RID: 813
		[SerializeField]
		internal int simplificationLevels;

		// Token: 0x0400032E RID: 814
		[SerializeField]
		internal float minDistanceBetweenProbes;

		// Token: 0x020001AB RID: 427
		[Serializable]
		internal enum AssetVersion
		{
			// Token: 0x0400070C RID: 1804
			First,
			// Token: 0x0400070D RID: 1805
			AddProbeVolumesAtlasEncodingModes,
			// Token: 0x0400070E RID: 1806
			PV2,
			// Token: 0x0400070F RID: 1807
			ChunkBasedIndex,
			// Token: 0x04000710 RID: 1808
			BinaryRuntimeDebugSplit,
			// Token: 0x04000711 RID: 1809
			BinaryTextureData,
			// Token: 0x04000712 RID: 1810
			Max,
			// Token: 0x04000713 RID: 1811
			Current = 5
		}

		// Token: 0x020001AC RID: 428
		[Serializable]
		internal struct CellCounts
		{
			// Token: 0x06000B32 RID: 2866 RVA: 0x0002EDC8 File Offset: 0x0002CFC8
			public void Add(ProbeVolumeAsset.CellCounts o)
			{
				this.bricksCount += o.bricksCount;
				this.probesCount += o.probesCount;
				this.offsetsCount += o.offsetsCount;
				this.chunksCount += o.chunksCount;
			}

			// Token: 0x04000714 RID: 1812
			public int bricksCount;

			// Token: 0x04000715 RID: 1813
			public int probesCount;

			// Token: 0x04000716 RID: 1814
			public int offsetsCount;

			// Token: 0x04000717 RID: 1815
			public int chunksCount;
		}
	}
}
