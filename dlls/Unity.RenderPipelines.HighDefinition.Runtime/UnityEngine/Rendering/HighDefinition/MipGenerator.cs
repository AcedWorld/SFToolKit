using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001A4 RID: 420
	internal class MipGenerator
	{
		// Token: 0x06000D35 RID: 3381 RVA: 0x0006BE2C File Offset: 0x0006A02C
		public MipGenerator(HDRenderPipelineRuntimeResources defaultResources)
		{
			this.m_TempColorTargets = new RTHandle[this.tmpTargetCount];
			this.m_TempDownsamplePyramid = new RTHandle[this.tmpTargetCount];
			this.m_DepthPyramidCS = defaultResources.shaders.depthPyramidCS;
			this.m_DepthDownsampleKernel = this.m_DepthPyramidCS.FindKernel("KDepthDownsample8DualUav");
			this.m_SrcOffset = new int[4];
			this.m_DstOffset = new int[4];
			this.m_ColorPyramidPS = defaultResources.shaders.colorPyramidPS;
			this.m_ColorPyramidPSMat = CoreUtils.CreateEngineMaterial(this.m_ColorPyramidPS);
			this.m_PropertyBlock = new MaterialPropertyBlock();
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x0006BED0 File Offset: 0x0006A0D0
		public void Release()
		{
			for (int i = 0; i < this.tmpTargetCount; i++)
			{
				RTHandles.Release(this.m_TempColorTargets[i]);
				this.m_TempColorTargets[i] = null;
				RTHandles.Release(this.m_TempDownsamplePyramid[i]);
				this.m_TempDownsamplePyramid[i] = null;
			}
			CoreUtils.Destroy(this.m_ColorPyramidPSMat);
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000D37 RID: 3383 RVA: 0x0006BF25 File Offset: 0x0006A125
		private int tmpTargetCount
		{
			get
			{
				if (TextureXR.useTexArray)
				{
					return 2;
				}
				return 1;
			}
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x0006BF34 File Offset: 0x0006A134
		public void RenderMinDepthPyramid(CommandBuffer cmd, RenderTexture texture, HDUtils.PackedMipChainInfo info, bool mip1AlreadyComputed)
		{
			HDUtils.CheckRTCreated(texture);
			ComputeShader depthPyramidCS = this.m_DepthPyramidCS;
			int depthDownsampleKernel = this.m_DepthDownsampleKernel;
			for (int i = 1; i < info.mipLevelCount; i++)
			{
				if (!mip1AlreadyComputed || i != 1)
				{
					Vector2Int vector2Int = info.mipLevelSizes[i];
					Vector2Int vector2Int2 = info.mipLevelOffsets[i];
					Vector2Int b = info.mipLevelSizes[i - 1];
					Vector2Int a = info.mipLevelOffsets[i - 1];
					Vector2Int vector2Int3 = a + b - Vector2Int.one;
					this.m_SrcOffset[0] = a.x;
					this.m_SrcOffset[1] = a.y;
					this.m_SrcOffset[2] = vector2Int3.x;
					this.m_SrcOffset[3] = vector2Int3.y;
					this.m_DstOffset[0] = vector2Int2.x;
					this.m_DstOffset[1] = vector2Int2.y;
					this.m_DstOffset[2] = 0;
					this.m_DstOffset[3] = 0;
					cmd.SetComputeIntParams(depthPyramidCS, HDShaderIDs._SrcOffsetAndLimit, this.m_SrcOffset);
					cmd.SetComputeIntParams(depthPyramidCS, HDShaderIDs._DstOffset, this.m_DstOffset);
					cmd.SetComputeTextureParam(depthPyramidCS, depthDownsampleKernel, HDShaderIDs._DepthMipChain, texture);
					cmd.DispatchCompute(depthPyramidCS, depthDownsampleKernel, HDUtils.DivRoundUp(vector2Int.x, 8), HDUtils.DivRoundUp(vector2Int.y, 8), texture.volumeDepth);
				}
			}
		}

		// Token: 0x06000D39 RID: 3385 RVA: 0x0006C094 File Offset: 0x0006A294
		public int RenderColorGaussianPyramid(CommandBuffer cmd, Vector2Int size, Texture source, RenderTexture destination)
		{
			bool flag = source.dimension == TextureDimension.Tex2DArray;
			int num = flag ? 1 : 0;
			if (this.m_TempColorTargets[num] != null && this.m_TempColorTargets[num].rt.graphicsFormat != destination.graphicsFormat)
			{
				RTHandles.Release(this.m_TempColorTargets[num]);
				this.m_TempColorTargets[num] = null;
			}
			if (this.m_TempColorTargets[num] == null)
			{
				RTHandle[] tempColorTargets = this.m_TempColorTargets;
				int num2 = num;
				Vector2 scaleFactor = Vector2.one * 0.5f;
				int slices = flag ? TextureXR.slices : 1;
				DepthBits depthBufferBits = DepthBits.None;
				TextureDimension dimension = source.dimension;
				tempColorTargets[num2] = RTHandles.Alloc(scaleFactor, slices, depthBufferBits, destination.graphicsFormat, FilterMode.Bilinear, TextureWrapMode.Repeat, dimension, true, false, true, false, 1, 0f, MSAASamples.None, false, true, RenderTextureMemoryless.None, VRTextureUsage.None, "Temp Gaussian Pyramid Target");
			}
			int num3 = 0;
			int num4 = size.x;
			int num5 = size.y;
			int volumeDepth = destination.volumeDepth;
			if (this.m_TempDownsamplePyramid[num] != null && this.m_TempDownsamplePyramid[num].rt.graphicsFormat != destination.graphicsFormat)
			{
				RTHandles.Release(this.m_TempDownsamplePyramid[num]);
				this.m_TempDownsamplePyramid[num] = null;
			}
			if (this.m_TempDownsamplePyramid[num] == null)
			{
				RTHandle[] tempDownsamplePyramid = this.m_TempDownsamplePyramid;
				int num6 = num;
				Vector2 scaleFactor2 = Vector2.one * 0.5f;
				int slices2 = flag ? TextureXR.slices : 1;
				DepthBits depthBufferBits2 = DepthBits.None;
				TextureDimension dimension = source.dimension;
				tempDownsamplePyramid[num6] = RTHandles.Alloc(scaleFactor2, slices2, depthBufferBits2, destination.graphicsFormat, FilterMode.Bilinear, TextureWrapMode.Repeat, dimension, false, false, true, false, 1, 0f, MSAASamples.None, false, true, RenderTextureMemoryless.None, VRTextureUsage.None, "Temporary Downsampled Pyramid");
				cmd.SetRenderTarget(this.m_TempDownsamplePyramid[num]);
				cmd.ClearRenderTarget(false, true, Color.black);
			}
			bool flag2 = DynamicResolutionHandler.instance.HardwareDynamicResIsEnabled();
			Vector2Int size2 = new Vector2Int(source.width, source.height);
			if (flag2)
			{
				size2 = DynamicResolutionHandler.instance.ApplyScalesOnSize(size2);
			}
			float x = (float)size.x / (float)size2.x;
			float y = (float)size.y / (float)size2.y;
			this.m_PropertyBlock.SetTexture(HDShaderIDs._BlitTexture, source);
			this.m_PropertyBlock.SetVector(HDShaderIDs._BlitScaleBias, new Vector4(x, y, 0f, 0f));
			this.m_PropertyBlock.SetFloat(HDShaderIDs._BlitMipLevel, 0f);
			cmd.SetRenderTarget(destination, 0, CubemapFace.Unknown, -1);
			cmd.SetViewport(new Rect(0f, 0f, (float)num4, (float)num5));
			cmd.DrawProcedural(Matrix4x4.identity, HDUtils.GetBlitMaterial(source.dimension, false), 0, MeshTopology.Triangles, 3, 1, this.m_PropertyBlock);
			Vector2Int size3 = new Vector2Int(destination.width, destination.height);
			if (destination.useDynamicScale && flag2)
			{
				size3 = DynamicResolutionHandler.instance.ApplyScalesOnSize(size3);
			}
			while (num4 >= 8 || num5 >= 8)
			{
				int num7 = Mathf.Max(1, num4 >> 1);
				int num8 = Mathf.Max(1, num5 >> 1);
				float x2 = (float)num4 / (float)size3.x;
				float y2 = (float)num5 / (float)size3.y;
				this.m_PropertyBlock.SetTexture(HDShaderIDs._BlitTexture, destination);
				this.m_PropertyBlock.SetVector(HDShaderIDs._BlitScaleBias, new Vector4(x2, y2, 0f, 0f));
				this.m_PropertyBlock.SetFloat(HDShaderIDs._BlitMipLevel, (float)num3);
				cmd.SetRenderTarget(this.m_TempDownsamplePyramid[num], 0, CubemapFace.Unknown, -1);
				cmd.SetViewport(new Rect(0f, 0f, (float)num7, (float)num8));
				cmd.DrawProcedural(Matrix4x4.identity, HDUtils.GetBlitMaterial(source.dimension, false), 1, MeshTopology.Triangles, 3, 1, this.m_PropertyBlock);
				Vector2Int size4 = new Vector2Int(this.m_TempDownsamplePyramid[num].rt.width, this.m_TempDownsamplePyramid[num].rt.height);
				if (flag2)
				{
					size4 = DynamicResolutionHandler.instance.ApplyScalesOnSize(size4);
				}
				float num9 = (float)size4.x;
				float num10 = (float)size4.y;
				x2 = (float)num7 / num9;
				y2 = (float)num8 / num10;
				this.m_PropertyBlock.SetTexture(HDShaderIDs._Source, this.m_TempDownsamplePyramid[num]);
				this.m_PropertyBlock.SetVector(HDShaderIDs._SrcScaleBias, new Vector4(x2, y2, 0f, 0f));
				this.m_PropertyBlock.SetVector(HDShaderIDs._SrcUvLimits, new Vector4(((float)num7 - 0.5f) / num9, ((float)num8 - 0.5f) / num10, 1f / num9, 0f));
				this.m_PropertyBlock.SetFloat(HDShaderIDs._SourceMip, 0f);
				cmd.SetRenderTarget(this.m_TempColorTargets[num], 0, CubemapFace.Unknown, -1);
				cmd.SetViewport(new Rect(0f, 0f, (float)num7, (float)num8));
				cmd.DrawProcedural(Matrix4x4.identity, this.m_ColorPyramidPSMat, num, MeshTopology.Triangles, 3, 1, this.m_PropertyBlock);
				this.m_PropertyBlock.SetTexture(HDShaderIDs._Source, this.m_TempColorTargets[num]);
				this.m_PropertyBlock.SetVector(HDShaderIDs._SrcScaleBias, new Vector4(x2, y2, 0f, 0f));
				this.m_PropertyBlock.SetVector(HDShaderIDs._SrcUvLimits, new Vector4(((float)num7 - 0.5f) / num9, ((float)num8 - 0.5f) / num10, 0f, 1f / num10));
				this.m_PropertyBlock.SetFloat(HDShaderIDs._SourceMip, 0f);
				cmd.SetRenderTarget(destination, num3 + 1, CubemapFace.Unknown, -1);
				cmd.SetViewport(new Rect(0f, 0f, (float)num7, (float)num8));
				cmd.DrawProcedural(Matrix4x4.identity, this.m_ColorPyramidPSMat, num, MeshTopology.Triangles, 3, 1, this.m_PropertyBlock);
				num3++;
				num4 >>= 1;
				num5 >>= 1;
				size3.x >>= 1;
				size3.y >>= 1;
			}
			return num3 + 1;
		}

		// Token: 0x04001439 RID: 5177
		private RTHandle[] m_TempColorTargets;

		// Token: 0x0400143A RID: 5178
		private RTHandle[] m_TempDownsamplePyramid;

		// Token: 0x0400143B RID: 5179
		private ComputeShader m_DepthPyramidCS;

		// Token: 0x0400143C RID: 5180
		private Shader m_ColorPyramidPS;

		// Token: 0x0400143D RID: 5181
		private Material m_ColorPyramidPSMat;

		// Token: 0x0400143E RID: 5182
		private MaterialPropertyBlock m_PropertyBlock;

		// Token: 0x0400143F RID: 5183
		private int m_DepthDownsampleKernel;

		// Token: 0x04001440 RID: 5184
		private int[] m_SrcOffset;

		// Token: 0x04001441 RID: 5185
		private int[] m_DstOffset;
	}
}
