using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering
{
	// Token: 0x02000083 RID: 131
	internal class ProbeBrickPool
	{
		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x000122C0 File Offset: 0x000104C0
		// (set) Token: 0x06000422 RID: 1058 RVA: 0x000122C8 File Offset: 0x000104C8
		internal int estimatedVMemCost { get; private set; }

		// Token: 0x06000423 RID: 1059 RVA: 0x000122D4 File Offset: 0x000104D4
		internal ProbeBrickPool(ProbeVolumeTextureMemoryBudget memoryBudget, ProbeVolumeSHBands shBands, bool allocateValidityData = true)
		{
			this.m_NextFreeChunk.x = (this.m_NextFreeChunk.y = (this.m_NextFreeChunk.z = 0));
			this.m_SHBands = shBands;
			this.m_ContainsValidity = allocateValidityData;
			this.m_FreeList = new Stack<ProbeBrickPool.BrickChunkAlloc>(256);
			int num;
			int num2;
			int num3;
			this.DerivePoolSizeFromBudget(memoryBudget, out num, out num2, out num3);
			int estimatedVMemCost;
			this.m_Pool = ProbeBrickPool.CreateDataLocation(num * num2 * num3, false, shBands, "APV", true, allocateValidityData, out estimatedVMemCost);
			this.estimatedVMemCost = estimatedVMemCost;
			this.m_AvailableChunkCount = this.m_Pool.width / 512 * (this.m_Pool.height / 4) * (this.m_Pool.depth / 4);
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00012393 File Offset: 0x00010593
		public int GetRemainingChunkCount()
		{
			return this.m_AvailableChunkCount;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0001239C File Offset: 0x0001059C
		internal void EnsureTextureValidity()
		{
			if (this.m_Pool.TexL0_L1rx == null)
			{
				this.m_Pool.Cleanup();
				int estimatedVMemCost;
				this.m_Pool = ProbeBrickPool.CreateDataLocation(this.m_Pool.width * this.m_Pool.height * this.m_Pool.depth, false, this.m_SHBands, "APV", true, this.m_ContainsValidity, out estimatedVMemCost);
				this.estimatedVMemCost = estimatedVMemCost;
			}
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00012411 File Offset: 0x00010611
		internal static int GetChunkSizeInBrickCount()
		{
			return 128;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00012418 File Offset: 0x00010618
		internal static int GetChunkSizeInProbeCount()
		{
			return 8192;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0001241F File Offset: 0x0001061F
		internal int GetPoolWidth()
		{
			return this.m_Pool.width;
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0001242C File Offset: 0x0001062C
		internal int GetPoolHeight()
		{
			return this.m_Pool.height;
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00012439 File Offset: 0x00010639
		internal Vector3Int GetPoolDimensions()
		{
			return new Vector3Int(this.m_Pool.width, this.m_Pool.height, this.m_Pool.depth);
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00012464 File Offset: 0x00010664
		internal void GetRuntimeResources(ref ProbeReferenceVolume.RuntimeResources rr)
		{
			rr.L0_L1rx = (this.m_Pool.TexL0_L1rx as RenderTexture);
			rr.L1_G_ry = (this.m_Pool.TexL1_G_ry as RenderTexture);
			rr.L1_B_rz = (this.m_Pool.TexL1_B_rz as RenderTexture);
			rr.L2_0 = (this.m_Pool.TexL2_0 as RenderTexture);
			rr.L2_1 = (this.m_Pool.TexL2_1 as RenderTexture);
			rr.L2_2 = (this.m_Pool.TexL2_2 as RenderTexture);
			rr.L2_3 = (this.m_Pool.TexL2_3 as RenderTexture);
			rr.Validity = this.m_Pool.TexValidity;
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0001251C File Offset: 0x0001071C
		internal void Clear()
		{
			this.m_FreeList.Clear();
			this.m_NextFreeChunk.x = (this.m_NextFreeChunk.y = (this.m_NextFreeChunk.z = 0));
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0001255C File Offset: 0x0001075C
		internal static int GetChunkCount(int brickCount, int chunkSizeInBricks)
		{
			return (brickCount + chunkSizeInBricks - 1) / chunkSizeInBricks;
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x00012574 File Offset: 0x00010774
		internal bool Allocate(int numberOfBrickChunks, List<ProbeBrickPool.BrickChunkAlloc> outAllocations, bool ignoreErrorLog)
		{
			while (this.m_FreeList.Count > 0 && numberOfBrickChunks > 0)
			{
				outAllocations.Add(this.m_FreeList.Pop());
				numberOfBrickChunks--;
				this.m_AvailableChunkCount--;
			}
			uint num = 0U;
			while ((ulong)num < (ulong)((long)numberOfBrickChunks))
			{
				if (this.m_NextFreeChunk.z >= this.m_Pool.depth)
				{
					if (!ignoreErrorLog)
					{
						Debug.LogError("Cannot allocate more brick chunks, probe volume brick pool is full.");
					}
					return false;
				}
				outAllocations.Add(this.m_NextFreeChunk);
				this.m_AvailableChunkCount--;
				this.m_NextFreeChunk.x = this.m_NextFreeChunk.x + 512;
				if (this.m_NextFreeChunk.x >= this.m_Pool.width)
				{
					this.m_NextFreeChunk.x = 0;
					this.m_NextFreeChunk.y = this.m_NextFreeChunk.y + 4;
					if (this.m_NextFreeChunk.y >= this.m_Pool.height)
					{
						this.m_NextFreeChunk.y = 0;
						this.m_NextFreeChunk.z = this.m_NextFreeChunk.z + 4;
					}
				}
				num += 1U;
			}
			return true;
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0001268C File Offset: 0x0001088C
		internal void Deallocate(List<ProbeBrickPool.BrickChunkAlloc> allocations)
		{
			this.m_AvailableChunkCount += allocations.Count;
			foreach (ProbeBrickPool.BrickChunkAlloc item in allocations)
			{
				this.m_FreeList.Push(item);
			}
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x000126F4 File Offset: 0x000108F4
		internal void Update(ProbeBrickPool.DataLocation source, List<ProbeBrickPool.BrickChunkAlloc> srcLocations, List<ProbeBrickPool.BrickChunkAlloc> dstLocations, int destStartIndex, ProbeVolumeSHBands bands)
		{
			for (int i = 0; i < srcLocations.Count; i++)
			{
				ProbeBrickPool.BrickChunkAlloc brickChunkAlloc = srcLocations[i];
				ProbeBrickPool.BrickChunkAlloc brickChunkAlloc2 = dstLocations[destStartIndex + i];
				for (int j = 0; j < 4; j++)
				{
					int srcWidth = Mathf.Min(512, source.width - brickChunkAlloc.x);
					Graphics.CopyTexture(source.TexL0_L1rx, brickChunkAlloc.z + j, 0, brickChunkAlloc.x, brickChunkAlloc.y, srcWidth, 4, this.m_Pool.TexL0_L1rx, brickChunkAlloc2.z + j, 0, brickChunkAlloc2.x, brickChunkAlloc2.y);
					Graphics.CopyTexture(source.TexL1_G_ry, brickChunkAlloc.z + j, 0, brickChunkAlloc.x, brickChunkAlloc.y, srcWidth, 4, this.m_Pool.TexL1_G_ry, brickChunkAlloc2.z + j, 0, brickChunkAlloc2.x, brickChunkAlloc2.y);
					Graphics.CopyTexture(source.TexL1_B_rz, brickChunkAlloc.z + j, 0, brickChunkAlloc.x, brickChunkAlloc.y, srcWidth, 4, this.m_Pool.TexL1_B_rz, brickChunkAlloc2.z + j, 0, brickChunkAlloc2.x, brickChunkAlloc2.y);
					if (this.m_ContainsValidity)
					{
						Graphics.CopyTexture(source.TexValidity, brickChunkAlloc.z + j, 0, brickChunkAlloc.x, brickChunkAlloc.y, srcWidth, 4, this.m_Pool.TexValidity, brickChunkAlloc2.z + j, 0, brickChunkAlloc2.x, brickChunkAlloc2.y);
					}
					if (bands == ProbeVolumeSHBands.SphericalHarmonicsL2)
					{
						Graphics.CopyTexture(source.TexL2_0, brickChunkAlloc.z + j, 0, brickChunkAlloc.x, brickChunkAlloc.y, srcWidth, 4, this.m_Pool.TexL2_0, brickChunkAlloc2.z + j, 0, brickChunkAlloc2.x, brickChunkAlloc2.y);
						Graphics.CopyTexture(source.TexL2_1, brickChunkAlloc.z + j, 0, brickChunkAlloc.x, brickChunkAlloc.y, srcWidth, 4, this.m_Pool.TexL2_1, brickChunkAlloc2.z + j, 0, brickChunkAlloc2.x, brickChunkAlloc2.y);
						Graphics.CopyTexture(source.TexL2_2, brickChunkAlloc.z + j, 0, brickChunkAlloc.x, brickChunkAlloc.y, srcWidth, 4, this.m_Pool.TexL2_2, brickChunkAlloc2.z + j, 0, brickChunkAlloc2.x, brickChunkAlloc2.y);
						Graphics.CopyTexture(source.TexL2_3, brickChunkAlloc.z + j, 0, brickChunkAlloc.x, brickChunkAlloc.y, srcWidth, 4, this.m_Pool.TexL2_3, brickChunkAlloc2.z + j, 0, brickChunkAlloc2.x, brickChunkAlloc2.y);
					}
				}
			}
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00012980 File Offset: 0x00010B80
		internal void UpdateValidity(ProbeBrickPool.DataLocation source, List<ProbeBrickPool.BrickChunkAlloc> srcLocations, List<ProbeBrickPool.BrickChunkAlloc> dstLocations, int destStartIndex)
		{
			for (int i = 0; i < srcLocations.Count; i++)
			{
				ProbeBrickPool.BrickChunkAlloc brickChunkAlloc = srcLocations[i];
				ProbeBrickPool.BrickChunkAlloc brickChunkAlloc2 = dstLocations[destStartIndex + i];
				for (int j = 0; j < 4; j++)
				{
					int srcWidth = Mathf.Min(512, source.width - brickChunkAlloc.x);
					Graphics.CopyTexture(source.TexValidity, brickChunkAlloc.z + j, 0, brickChunkAlloc.x, brickChunkAlloc.y, srcWidth, 4, this.m_Pool.TexValidity, brickChunkAlloc2.z + j, 0, brickChunkAlloc2.x, brickChunkAlloc2.y);
				}
			}
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00012A1C File Offset: 0x00010C1C
		internal static Vector3Int ProbeCountToDataLocSize(int numProbes)
		{
			int num = numProbes / 64;
			int num2 = 512;
			int num3 = (num + num2 * num2 - 1) / (num2 * num2);
			int num5;
			int num4;
			if (num3 > 1)
			{
				num4 = (num5 = num2);
			}
			else
			{
				num4 = (num + num2 - 1) / num2;
				if (num4 > 1)
				{
					num5 = num2;
				}
				else
				{
					num5 = num;
				}
			}
			num5 *= 4;
			num4 *= 4;
			num3 *= 4;
			return new Vector3Int(num5, num4, num3);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00012A78 File Offset: 0x00010C78
		public static Texture CreateDataTexture(int width, int height, int depth, GraphicsFormat format, string name, bool allocateRendertexture, ref int allocatedBytes)
		{
			int num = (format == GraphicsFormat.R16G16B16A16_SFloat) ? 8 : ((format == GraphicsFormat.R8G8B8A8_UNorm) ? 4 : 1);
			allocatedBytes += width * height * depth * num;
			Texture texture;
			if (allocateRendertexture)
			{
				texture = new RenderTexture(new RenderTextureDescriptor
				{
					width = width,
					height = height,
					volumeDepth = depth,
					graphicsFormat = format,
					mipCount = 1,
					enableRandomWrite = true,
					dimension = TextureDimension.Tex3D,
					msaaSamples = 1
				});
			}
			else
			{
				texture = new Texture3D(width, height, depth, format, TextureCreationFlags.None, 1);
			}
			texture.hideFlags = HideFlags.HideAndDontSave;
			texture.name = name;
			if (allocateRendertexture)
			{
				(texture as RenderTexture).Create();
			}
			return texture;
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00012B28 File Offset: 0x00010D28
		public static ProbeBrickPool.DataLocation CreateDataLocation(int numProbes, bool compressed, ProbeVolumeSHBands bands, string name, bool allocateRendertexture, bool allocateValidityData, out int allocatedBytes)
		{
			Vector3Int vector3Int = ProbeBrickPool.ProbeCountToDataLocSize(numProbes);
			int x = vector3Int.x;
			int y = vector3Int.y;
			int z = vector3Int.z;
			GraphicsFormat format = GraphicsFormat.R16G16B16A16_SFloat;
			GraphicsFormat format2 = compressed ? GraphicsFormat.RGBA_BC7_UNorm : GraphicsFormat.R8G8B8A8_UNorm;
			allocatedBytes = 0;
			ProbeBrickPool.DataLocation result;
			result.TexL0_L1rx = ProbeBrickPool.CreateDataTexture(x, y, z, format, name + "_TexL0_L1rx", allocateRendertexture, ref allocatedBytes);
			result.TexL1_G_ry = ProbeBrickPool.CreateDataTexture(x, y, z, format2, name + "_TexL1_G_ry", allocateRendertexture, ref allocatedBytes);
			result.TexL1_B_rz = ProbeBrickPool.CreateDataTexture(x, y, z, format2, name + "_TexL1_B_rz", allocateRendertexture, ref allocatedBytes);
			if (allocateValidityData)
			{
				result.TexValidity = (ProbeBrickPool.CreateDataTexture(x, y, z, GraphicsFormat.R8_UNorm, name + "_Validity", false, ref allocatedBytes) as Texture3D);
			}
			else
			{
				result.TexValidity = null;
			}
			if (bands == ProbeVolumeSHBands.SphericalHarmonicsL2)
			{
				result.TexL2_0 = ProbeBrickPool.CreateDataTexture(x, y, z, format2, name + "_TexL2_0", allocateRendertexture, ref allocatedBytes);
				result.TexL2_1 = ProbeBrickPool.CreateDataTexture(x, y, z, format2, name + "_TexL2_1", allocateRendertexture, ref allocatedBytes);
				result.TexL2_2 = ProbeBrickPool.CreateDataTexture(x, y, z, format2, name + "_TexL2_2", allocateRendertexture, ref allocatedBytes);
				result.TexL2_3 = ProbeBrickPool.CreateDataTexture(x, y, z, format2, name + "_TexL2_3", allocateRendertexture, ref allocatedBytes);
			}
			else
			{
				result.TexL2_0 = null;
				result.TexL2_1 = null;
				result.TexL2_2 = null;
				result.TexL2_3 = null;
			}
			result.width = x;
			result.height = y;
			result.depth = z;
			return result;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00012CBA File Offset: 0x00010EBA
		private void DerivePoolSizeFromBudget(ProbeVolumeTextureMemoryBudget memoryBudget, out int width, out int height, out int depth)
		{
			width = (int)memoryBudget;
			height = (int)memoryBudget;
			depth = 4;
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00012CC6 File Offset: 0x00010EC6
		internal void Cleanup()
		{
			this.m_Pool.Cleanup();
		}

		// Token: 0x04000252 RID: 594
		private const int kProbePoolChunkSizeInBricks = 128;

		// Token: 0x04000253 RID: 595
		internal const int kBrickCellCount = 3;

		// Token: 0x04000254 RID: 596
		internal const int kBrickProbeCountPerDim = 4;

		// Token: 0x04000255 RID: 597
		internal const int kBrickProbeCountTotal = 64;

		// Token: 0x04000256 RID: 598
		internal const int kChunkProbeCountPerDim = 512;

		// Token: 0x04000258 RID: 600
		private const int kMaxPoolWidth = 2048;

		// Token: 0x04000259 RID: 601
		internal ProbeBrickPool.DataLocation m_Pool;

		// Token: 0x0400025A RID: 602
		private ProbeBrickPool.BrickChunkAlloc m_NextFreeChunk;

		// Token: 0x0400025B RID: 603
		private Stack<ProbeBrickPool.BrickChunkAlloc> m_FreeList;

		// Token: 0x0400025C RID: 604
		private int m_AvailableChunkCount;

		// Token: 0x0400025D RID: 605
		private ProbeVolumeSHBands m_SHBands;

		// Token: 0x0400025E RID: 606
		private bool m_ContainsValidity;

		// Token: 0x0200019A RID: 410
		[DebuggerDisplay("Chunk ({x}, {y}, {z})")]
		public struct BrickChunkAlloc
		{
			// Token: 0x06000ACB RID: 2763 RVA: 0x0002DE46 File Offset: 0x0002C046
			internal int flattenIndex(int sx, int sy)
			{
				return this.z * (sx * sy) + this.y * sx + this.x;
			}

			// Token: 0x04000697 RID: 1687
			public int x;

			// Token: 0x04000698 RID: 1688
			public int y;

			// Token: 0x04000699 RID: 1689
			public int z;
		}

		// Token: 0x0200019B RID: 411
		public struct DataLocation
		{
			// Token: 0x06000ACC RID: 2764 RVA: 0x0002DE64 File Offset: 0x0002C064
			internal void Cleanup()
			{
				CoreUtils.Destroy(this.TexL0_L1rx);
				CoreUtils.Destroy(this.TexL1_G_ry);
				CoreUtils.Destroy(this.TexL1_B_rz);
				CoreUtils.Destroy(this.TexL2_0);
				CoreUtils.Destroy(this.TexL2_1);
				CoreUtils.Destroy(this.TexL2_2);
				CoreUtils.Destroy(this.TexL2_3);
				CoreUtils.Destroy(this.TexValidity);
				this.TexL0_L1rx = null;
				this.TexL1_G_ry = null;
				this.TexL1_B_rz = null;
				this.TexL2_0 = null;
				this.TexL2_1 = null;
				this.TexL2_2 = null;
				this.TexL2_3 = null;
				this.TexValidity = null;
			}

			// Token: 0x0400069A RID: 1690
			internal Texture TexL0_L1rx;

			// Token: 0x0400069B RID: 1691
			internal Texture TexL1_G_ry;

			// Token: 0x0400069C RID: 1692
			internal Texture TexL1_B_rz;

			// Token: 0x0400069D RID: 1693
			internal Texture TexL2_0;

			// Token: 0x0400069E RID: 1694
			internal Texture TexL2_1;

			// Token: 0x0400069F RID: 1695
			internal Texture TexL2_2;

			// Token: 0x040006A0 RID: 1696
			internal Texture TexL2_3;

			// Token: 0x040006A1 RID: 1697
			internal Texture3D TexValidity;

			// Token: 0x040006A2 RID: 1698
			internal int width;

			// Token: 0x040006A3 RID: 1699
			internal int height;

			// Token: 0x040006A4 RID: 1700
			internal int depth;
		}
	}
}
