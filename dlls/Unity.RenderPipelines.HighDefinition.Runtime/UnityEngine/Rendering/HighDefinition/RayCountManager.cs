using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200004F RID: 79
	internal class RayCountManager
	{
		// Token: 0x06000241 RID: 577 RVA: 0x0000D560 File Offset: 0x0000B760
		public void Init(HDRenderPipelineRayTracingResources rayTracingResources)
		{
			this.m_RayCountCS = rayTracingResources.countTracedRays;
			this.m_ReducedRayCountBufferOutput = new ComputeBuffer(10, 4);
			for (int i = 0; i < 9; i++)
			{
				this.m_ReducedRayCountValues[i] = 0U;
			}
			this.m_IsActive = false;
			this.m_RayTracingSupported = true;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000D5AB File Offset: 0x0000B7AB
		public void Release()
		{
			CoreUtils.SafeRelease(this.m_ReducedRayCountBufferOutput);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000D5B8 File Offset: 0x0000B7B8
		public int RayCountIsEnabled()
		{
			if (!this.m_IsActive)
			{
				return 0;
			}
			return 1;
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000D5C5 File Offset: 0x0000B7C5
		internal void SetRayCountEnabled(bool value)
		{
			this.m_IsActive = value;
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000D5D0 File Offset: 0x0000B7D0
		public static TextureHandle CreateRayCountTexture(RenderGraph renderGraph)
		{
			TextureDesc textureDesc = new TextureDesc(Vector2.one, true, true);
			textureDesc.colorFormat = GraphicsFormat.R16_UInt;
			textureDesc.slices = TextureXR.slices * 9;
			textureDesc.dimension = TextureDimension.Tex2DArray;
			textureDesc.clearBuffer = true;
			textureDesc.enableRandomWrite = true;
			textureDesc.name = "RayCountTextureDebug";
			return renderGraph.CreateTexture(textureDesc);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000D630 File Offset: 0x0000B830
		private void PrepareEvaluateRayCountPassData(in RenderGraphBuilder builder, RayCountManager.EvaluateRayCountPassData data, HDCamera hdCamera, TextureHandle colorBuffer, TextureHandle depthBuffer, TextureHandle rayCountTexture)
		{
			RenderGraphBuilder renderGraphBuilder = builder;
			data.colorBuffer = renderGraphBuilder.UseColorBuffer(colorBuffer, 0);
			renderGraphBuilder = builder;
			data.depthBuffer = renderGraphBuilder.UseDepthBuffer(depthBuffer, DepthAccess.ReadWrite);
			renderGraphBuilder = builder;
			data.rayCountTexture = renderGraphBuilder.ReadTexture(rayCountTexture);
			renderGraphBuilder = builder;
			ComputeBufferDesc computeBufferDesc = new ComputeBufferDesc(589824, 4);
			data.reducedRayCountBuffer0 = renderGraphBuilder.CreateTransientComputeBuffer(computeBufferDesc);
			renderGraphBuilder = builder;
			computeBufferDesc = new ComputeBufferDesc(9216, 4);
			data.reducedRayCountBuffer1 = renderGraphBuilder.CreateTransientComputeBuffer(computeBufferDesc);
			data.reducedRayCountBufferOutput = this.m_ReducedRayCountBufferOutput;
			data.rayCountCS = this.m_RayCountCS;
			data.rayCountKernel = this.m_RayCountCS.FindKernel("TextureReduction");
			data.clearKernel = this.m_RayCountCS.FindKernel("ClearBuffer");
			data.width = hdCamera.actualWidth;
			data.height = hdCamera.actualHeight;
			data.rayCountReadbacks = this.m_RayCountReadbacks;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000D730 File Offset: 0x0000B930
		public void EvaluateRayCount(RenderGraph renderGraph, HDCamera hdCamera, TextureHandle colorBuffer, TextureHandle depthBuffer, TextureHandle rayCountTexture)
		{
			if (this.m_IsActive)
			{
				RayCountManager.EvaluateRayCountPassData data2;
				RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<RayCountManager.EvaluateRayCountPassData>("RenderRayCountOverlay", out data2, ProfilingSampler.Get<HDProfileId>(HDProfileId.RaytracingDebugOverlay));
				try
				{
					this.PrepareEvaluateRayCountPassData(renderGraphBuilder, data2, hdCamera, colorBuffer, depthBuffer, rayCountTexture);
					renderGraphBuilder.SetRenderFunc<RayCountManager.EvaluateRayCountPassData>(delegate(RayCountManager.EvaluateRayCountPassData data, RenderGraphContext ctx)
					{
						int num = data.width;
						int num2 = data.height;
						ComputeShader rayCountCS = data.rayCountCS;
						int kernelIndex = data.rayCountKernel;
						int num3 = 32;
						int num4 = Mathf.Max(1, (num + (num3 - 1)) / num3);
						int num5 = Mathf.Max(1, (num2 + (num3 - 1)) / num3);
						if (num5 > 32 || num4 > 32)
						{
							ctx.cmd.SetComputeBufferParam(rayCountCS, kernelIndex, HDShaderIDs._OutputRayCountBuffer, data.reducedRayCountBuffer0);
							ctx.cmd.SetComputeIntParam(rayCountCS, HDShaderIDs._OutputBufferDimension, 2304);
							int num6 = 8;
							ctx.cmd.DispatchCompute(rayCountCS, kernelIndex, num6, num6, 1);
							ctx.cmd.SetComputeTextureParam(rayCountCS, kernelIndex, HDShaderIDs._InputRayCountTexture, data.rayCountTexture);
							ctx.cmd.SetComputeBufferParam(rayCountCS, kernelIndex, HDShaderIDs._OutputRayCountBuffer, data.reducedRayCountBuffer0);
							ctx.cmd.SetComputeIntParam(rayCountCS, HDShaderIDs._OutputBufferDimension, 2304);
							ctx.cmd.DispatchCompute(rayCountCS, kernelIndex, num4, num5, 1);
							num /= 32;
							num2 /= 32;
							kernelIndex = rayCountCS.FindKernel("BufferReduction");
							num4 = Mathf.Max(1, (num + (num3 - 1)) / num3);
							num5 = Mathf.Max(1, (num2 + (num3 - 1)) / num3);
							ctx.cmd.SetComputeBufferParam(rayCountCS, kernelIndex, HDShaderIDs._InputRayCountBuffer, data.reducedRayCountBuffer0);
							ctx.cmd.SetComputeBufferParam(rayCountCS, kernelIndex, HDShaderIDs._OutputRayCountBuffer, data.reducedRayCountBuffer1);
							ctx.cmd.SetComputeIntParam(rayCountCS, HDShaderIDs._InputBufferDimension, 2304);
							ctx.cmd.SetComputeIntParam(rayCountCS, HDShaderIDs._OutputBufferDimension, 288);
							ctx.cmd.DispatchCompute(rayCountCS, kernelIndex, num4, num5, 1);
							num /= 32;
							num2 /= 32;
							num4 = Mathf.Max(1, (num + (num3 - 1)) / num3);
							num5 = Mathf.Max(1, (num2 + (num3 - 1)) / num3);
							ctx.cmd.SetComputeBufferParam(rayCountCS, kernelIndex, HDShaderIDs._InputRayCountBuffer, data.reducedRayCountBuffer1);
							ctx.cmd.SetComputeBufferParam(rayCountCS, kernelIndex, HDShaderIDs._OutputRayCountBuffer, data.reducedRayCountBufferOutput);
							ctx.cmd.SetComputeIntParam(rayCountCS, HDShaderIDs._InputBufferDimension, 288);
							ctx.cmd.SetComputeIntParam(rayCountCS, HDShaderIDs._OutputBufferDimension, 9);
							ctx.cmd.DispatchCompute(rayCountCS, kernelIndex, num4, num5, 1);
						}
						else
						{
							ctx.cmd.SetComputeBufferParam(rayCountCS, kernelIndex, HDShaderIDs._OutputRayCountBuffer, data.reducedRayCountBuffer1);
							ctx.cmd.SetComputeIntParam(rayCountCS, HDShaderIDs._OutputBufferDimension, 288);
							ctx.cmd.DispatchCompute(rayCountCS, kernelIndex, 1, 1, 1);
							ctx.cmd.SetComputeTextureParam(rayCountCS, kernelIndex, HDShaderIDs._InputRayCountTexture, data.rayCountTexture);
							ctx.cmd.SetComputeBufferParam(rayCountCS, kernelIndex, HDShaderIDs._OutputRayCountBuffer, data.reducedRayCountBuffer1);
							ctx.cmd.SetComputeIntParam(rayCountCS, HDShaderIDs._OutputBufferDimension, 288);
							ctx.cmd.DispatchCompute(rayCountCS, kernelIndex, num4, num5, 1);
							num /= 32;
							num2 /= 32;
							kernelIndex = rayCountCS.FindKernel("BufferReduction");
							num4 = Mathf.Max(1, (num + (num3 - 1)) / num3);
							num5 = Mathf.Max(1, (num2 + (num3 - 1)) / num3);
							ctx.cmd.SetComputeBufferParam(rayCountCS, kernelIndex, HDShaderIDs._InputRayCountBuffer, data.reducedRayCountBuffer1);
							ctx.cmd.SetComputeBufferParam(rayCountCS, kernelIndex, HDShaderIDs._OutputRayCountBuffer, data.reducedRayCountBufferOutput);
							ctx.cmd.SetComputeIntParam(rayCountCS, HDShaderIDs._InputBufferDimension, 288);
							ctx.cmd.SetComputeIntParam(rayCountCS, HDShaderIDs._OutputBufferDimension, 9);
							ctx.cmd.DispatchCompute(rayCountCS, kernelIndex, num4, num5, 1);
						}
						AsyncGPUReadbackRequest item = AsyncGPUReadback.Request(data.reducedRayCountBufferOutput, 36, 0, null);
						data.rayCountReadbacks.Enqueue(item);
					});
				}
				finally
				{
					((IDisposable)renderGraphBuilder).Dispose();
				}
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000D7B0 File Offset: 0x0000B9B0
		public uint GetRaysPerFrame(RayCountValues rayCountValue)
		{
			if (!this.m_RayTracingSupported || !this.m_IsActive)
			{
				return 0U;
			}
			while (this.m_RayCountReadbacks.Peek().done || this.m_RayCountReadbacks.Peek().hasError)
			{
				if (!this.m_RayCountReadbacks.Peek().hasError)
				{
					NativeArray<uint> data = this.m_RayCountReadbacks.Peek().GetData<uint>(0);
					for (int i = 0; i < 9; i++)
					{
						this.m_ReducedRayCountValues[i] = data[i];
					}
				}
				this.m_RayCountReadbacks.Dequeue();
			}
			if (rayCountValue != RayCountValues.Total)
			{
				return this.m_ReducedRayCountValues[(int)rayCountValue];
			}
			uint num = 0U;
			for (int j = 0; j < 9; j++)
			{
				num += this.m_ReducedRayCountValues[j];
			}
			return num;
		}

		// Token: 0x04000242 RID: 578
		private ComputeBuffer m_ReducedRayCountBufferOutput;

		// Token: 0x04000243 RID: 579
		private uint[] m_ReducedRayCountValues = new uint[9];

		// Token: 0x04000244 RID: 580
		private ComputeShader m_RayCountCS;

		// Token: 0x04000245 RID: 581
		private bool m_IsActive;

		// Token: 0x04000246 RID: 582
		private bool m_RayTracingSupported;

		// Token: 0x04000247 RID: 583
		private Queue<AsyncGPUReadbackRequest> m_RayCountReadbacks = new Queue<AsyncGPUReadbackRequest>();

		// Token: 0x02000266 RID: 614
		private class EvaluateRayCountPassData
		{
			// Token: 0x04001B08 RID: 6920
			public TextureHandle colorBuffer;

			// Token: 0x04001B09 RID: 6921
			public TextureHandle depthBuffer;

			// Token: 0x04001B0A RID: 6922
			public TextureHandle rayCountTexture;

			// Token: 0x04001B0B RID: 6923
			public ComputeBufferHandle reducedRayCountBuffer0;

			// Token: 0x04001B0C RID: 6924
			public ComputeBufferHandle reducedRayCountBuffer1;

			// Token: 0x04001B0D RID: 6925
			public ComputeBuffer reducedRayCountBufferOutput;

			// Token: 0x04001B0E RID: 6926
			public ComputeShader rayCountCS;

			// Token: 0x04001B0F RID: 6927
			public int rayCountKernel;

			// Token: 0x04001B10 RID: 6928
			public int clearKernel;

			// Token: 0x04001B11 RID: 6929
			public int width;

			// Token: 0x04001B12 RID: 6930
			public int height;

			// Token: 0x04001B13 RID: 6931
			public Queue<AsyncGPUReadbackRequest> rayCountReadbacks;
		}
	}
}
