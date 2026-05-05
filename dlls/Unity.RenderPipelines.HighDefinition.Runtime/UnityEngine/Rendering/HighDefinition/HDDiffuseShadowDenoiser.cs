using System;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000175 RID: 373
	internal class HDDiffuseShadowDenoiser
	{
		// Token: 0x06000C37 RID: 3127 RVA: 0x00064D08 File Offset: 0x00062F08
		public void Init(HDRenderPipelineRayTracingResources rpRTResources)
		{
			this.m_ShadowDenoiser = rpRTResources.diffuseShadowDenoiserCS;
			this.m_BilateralFilterHSingleDirectionalKernel = this.m_ShadowDenoiser.FindKernel("BilateralFilterHSingleDirectional");
			this.m_BilateralFilterVSingleDirectionalKernel = this.m_ShadowDenoiser.FindKernel("BilateralFilterVSingleDirectional");
			this.m_BilateralFilterHColorDirectionalKernel = this.m_ShadowDenoiser.FindKernel("BilateralFilterHColorDirectional");
			this.m_BilateralFilterVColorDirectionalKernel = this.m_ShadowDenoiser.FindKernel("BilateralFilterVColorDirectional");
			this.m_BilateralFilterHSinglePointKernel = this.m_ShadowDenoiser.FindKernel("BilateralFilterHSinglePoint");
			this.m_BilateralFilterVSinglePointKernel = this.m_ShadowDenoiser.FindKernel("BilateralFilterVSinglePoint");
			this.m_BilateralFilterHSingleSpotKernel = this.m_ShadowDenoiser.FindKernel("BilateralFilterHSingleSpot");
			this.m_BilateralFilterVSingleSpotKernel = this.m_ShadowDenoiser.FindKernel("BilateralFilterVSingleSpot");
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x00064DD1 File Offset: 0x00062FD1
		public void Release()
		{
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x00064DD4 File Offset: 0x00062FD4
		public TextureHandle DenoiseBufferDirectional(RenderGraph renderGraph, HDCamera hdCamera, TextureHandle depthBuffer, TextureHandle normalBuffer, TextureHandle noisyBuffer, TextureHandle distanceBuffer, int kernelSize, float angularDiameter, bool singleChannel = true)
		{
			HDDiffuseShadowDenoiser.DiffuseShadowDenoiserDirectionalPassData diffuseShadowDenoiserDirectionalPassData;
			TextureHandle result;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<HDDiffuseShadowDenoiser.DiffuseShadowDenoiserDirectionalPassData>("TemporalDenoiser", out diffuseShadowDenoiserDirectionalPassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.DiffuseFilter)))
			{
				renderGraphBuilder.EnableAsyncCompute(false);
				diffuseShadowDenoiserDirectionalPassData.texWidth = hdCamera.actualWidth;
				diffuseShadowDenoiserDirectionalPassData.texHeight = hdCamera.actualHeight;
				diffuseShadowDenoiserDirectionalPassData.viewCount = hdCamera.viewCount;
				diffuseShadowDenoiserDirectionalPassData.cameraFov = hdCamera.camera.fieldOfView * 3.1415927f / 180f;
				diffuseShadowDenoiserDirectionalPassData.lightAngle = angularDiameter * 3.1415927f / 180f;
				diffuseShadowDenoiserDirectionalPassData.kernelSize = kernelSize;
				diffuseShadowDenoiserDirectionalPassData.bilateralHKernel = (singleChannel ? this.m_BilateralFilterHSingleDirectionalKernel : this.m_BilateralFilterHColorDirectionalKernel);
				diffuseShadowDenoiserDirectionalPassData.bilateralVKernel = (singleChannel ? this.m_BilateralFilterVSingleDirectionalKernel : this.m_BilateralFilterVColorDirectionalKernel);
				diffuseShadowDenoiserDirectionalPassData.diffuseShadowDenoiserCS = this.m_ShadowDenoiser;
				diffuseShadowDenoiserDirectionalPassData.depthStencilBuffer = renderGraphBuilder.UseDepthBuffer(depthBuffer, DepthAccess.Read);
				diffuseShadowDenoiserDirectionalPassData.normalBuffer = renderGraphBuilder.ReadTexture(normalBuffer);
				diffuseShadowDenoiserDirectionalPassData.distanceBuffer = renderGraphBuilder.ReadTexture(distanceBuffer);
				diffuseShadowDenoiserDirectionalPassData.noisyBuffer = renderGraphBuilder.ReadTexture(noisyBuffer);
				HDDiffuseShadowDenoiser.DiffuseShadowDenoiserDirectionalPassData diffuseShadowDenoiserDirectionalPassData2 = diffuseShadowDenoiserDirectionalPassData;
				TextureDesc textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
				textureDesc.enableRandomWrite = true;
				textureDesc.name = "Intermediate buffer";
				diffuseShadowDenoiserDirectionalPassData2.intermediateBuffer = renderGraphBuilder.CreateTransientTexture(textureDesc);
				HDDiffuseShadowDenoiser.DiffuseShadowDenoiserDirectionalPassData diffuseShadowDenoiserDirectionalPassData3 = diffuseShadowDenoiserDirectionalPassData;
				textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
				textureDesc.enableRandomWrite = true;
				textureDesc.name = "Denoised Buffer";
				result = renderGraph.CreateTexture(textureDesc);
				diffuseShadowDenoiserDirectionalPassData3.outputBuffer = renderGraphBuilder.ReadWriteTexture(result);
				renderGraphBuilder.SetRenderFunc<HDDiffuseShadowDenoiser.DiffuseShadowDenoiserDirectionalPassData>(delegate(HDDiffuseShadowDenoiser.DiffuseShadowDenoiserDirectionalPassData data, RenderGraphContext ctx)
				{
					CoreUtils.SetKeyword(ctx.cmd, "DISTANCE_BASED_DENOISER", true);
					int num = 8;
					int threadGroupsX = (data.texWidth + (num - 1)) / num;
					int threadGroupsY = (data.texHeight + (num - 1)) / num;
					ctx.cmd.SetComputeFloatParam(data.diffuseShadowDenoiserCS, HDShaderIDs._RaytracingLightAngle, data.lightAngle);
					ctx.cmd.SetComputeIntParam(data.diffuseShadowDenoiserCS, HDShaderIDs._DenoiserFilterRadius, data.kernelSize);
					ctx.cmd.SetComputeFloatParam(data.diffuseShadowDenoiserCS, HDShaderIDs._CameraFOV, data.cameraFov);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralHKernel, HDShaderIDs._DepthTexture, data.depthStencilBuffer);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralHKernel, HDShaderIDs._NormalBufferTexture, data.normalBuffer);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralHKernel, HDShaderIDs._DenoiseInputTexture, data.noisyBuffer);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralHKernel, HDShaderIDs._DistanceTexture, data.distanceBuffer);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralHKernel, HDShaderIDs._DenoiseOutputTextureRW, data.intermediateBuffer);
					ctx.cmd.DispatchCompute(data.diffuseShadowDenoiserCS, data.bilateralHKernel, threadGroupsX, threadGroupsY, data.viewCount);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralVKernel, HDShaderIDs._DepthTexture, data.depthStencilBuffer);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralVKernel, HDShaderIDs._NormalBufferTexture, data.normalBuffer);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralVKernel, HDShaderIDs._DenoiseInputTexture, data.intermediateBuffer);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralVKernel, HDShaderIDs._DistanceTexture, data.distanceBuffer);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralVKernel, HDShaderIDs._DenoiseOutputTextureRW, data.outputBuffer);
					ctx.cmd.DispatchCompute(data.diffuseShadowDenoiserCS, data.bilateralVKernel, threadGroupsX, threadGroupsY, data.viewCount);
					CoreUtils.SetKeyword(ctx.cmd, "DISTANCE_BASED_DENOISER", false);
				});
				result = diffuseShadowDenoiserDirectionalPassData.outputBuffer;
			}
			return result;
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x00064FAC File Offset: 0x000631AC
		public TextureHandle DenoiseBufferSphere(RenderGraph renderGraph, HDCamera hdCamera, TextureHandle depthBuffer, TextureHandle normalBuffer, TextureHandle noisyBuffer, TextureHandle distanceBuffer, PunctualShadowProperties properties)
		{
			HDDiffuseShadowDenoiser.DiffuseShadowDenoiserSpherePassData diffuseShadowDenoiserSpherePassData;
			TextureHandle result;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<HDDiffuseShadowDenoiser.DiffuseShadowDenoiserSpherePassData>("DiffuseDenoiser", out diffuseShadowDenoiserSpherePassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.DiffuseFilter)))
			{
				renderGraphBuilder.EnableAsyncCompute(false);
				diffuseShadowDenoiserSpherePassData.texWidth = hdCamera.actualWidth;
				diffuseShadowDenoiserSpherePassData.texHeight = hdCamera.actualHeight;
				diffuseShadowDenoiserSpherePassData.viewCount = hdCamera.viewCount;
				diffuseShadowDenoiserSpherePassData.cameraFov = hdCamera.camera.fieldOfView * 3.1415927f / 180f;
				diffuseShadowDenoiserSpherePassData.properties = properties;
				if (ShaderConfig.s_CameraRelativeRendering != 0)
				{
					HDDiffuseShadowDenoiser.DiffuseShadowDenoiserSpherePassData diffuseShadowDenoiserSpherePassData2 = diffuseShadowDenoiserSpherePassData;
					diffuseShadowDenoiserSpherePassData2.properties.lightPosition = diffuseShadowDenoiserSpherePassData2.properties.lightPosition - hdCamera.camera.transform.position;
				}
				diffuseShadowDenoiserSpherePassData.bilateralHKernel = (properties.isSpot ? this.m_BilateralFilterHSingleSpotKernel : this.m_BilateralFilterHSinglePointKernel);
				diffuseShadowDenoiserSpherePassData.bilateralVKernel = (properties.isSpot ? this.m_BilateralFilterVSingleSpotKernel : this.m_BilateralFilterVSinglePointKernel);
				diffuseShadowDenoiserSpherePassData.diffuseShadowDenoiserCS = this.m_ShadowDenoiser;
				diffuseShadowDenoiserSpherePassData.depthStencilBuffer = renderGraphBuilder.UseDepthBuffer(depthBuffer, DepthAccess.Read);
				diffuseShadowDenoiserSpherePassData.normalBuffer = renderGraphBuilder.ReadTexture(normalBuffer);
				if (properties.distanceBasedDenoiser)
				{
					diffuseShadowDenoiserSpherePassData.distanceBuffer = renderGraphBuilder.ReadTexture(distanceBuffer);
				}
				diffuseShadowDenoiserSpherePassData.noisyBuffer = renderGraphBuilder.ReadTexture(noisyBuffer);
				HDDiffuseShadowDenoiser.DiffuseShadowDenoiserSpherePassData diffuseShadowDenoiserSpherePassData3 = diffuseShadowDenoiserSpherePassData;
				TextureDesc textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
				textureDesc.enableRandomWrite = true;
				textureDesc.name = "Intermediate buffer";
				diffuseShadowDenoiserSpherePassData3.intermediateBuffer = renderGraphBuilder.CreateTransientTexture(textureDesc);
				HDDiffuseShadowDenoiser.DiffuseShadowDenoiserSpherePassData diffuseShadowDenoiserSpherePassData4 = diffuseShadowDenoiserSpherePassData;
				textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
				textureDesc.enableRandomWrite = true;
				textureDesc.name = "Denoised Buffer";
				result = renderGraph.CreateTexture(textureDesc);
				diffuseShadowDenoiserSpherePassData4.outputBuffer = renderGraphBuilder.ReadWriteTexture(result);
				renderGraphBuilder.SetRenderFunc<HDDiffuseShadowDenoiser.DiffuseShadowDenoiserSpherePassData>(delegate(HDDiffuseShadowDenoiser.DiffuseShadowDenoiserSpherePassData data, RenderGraphContext ctx)
				{
					int num = 8;
					int threadGroupsX = (data.texWidth + (num - 1)) / num;
					int threadGroupsY = (data.texHeight + (num - 1)) / num;
					CoreUtils.SetKeyword(ctx.cmd, "DISTANCE_BASED_DENOISER", data.properties.distanceBasedDenoiser);
					ctx.cmd.SetComputeIntParam(data.diffuseShadowDenoiserCS, HDShaderIDs._RaytracingTargetLight, data.properties.lightIndex);
					ctx.cmd.SetComputeFloatParam(data.diffuseShadowDenoiserCS, HDShaderIDs._RaytracingLightAngle, data.properties.lightConeAngle);
					ctx.cmd.SetComputeFloatParam(data.diffuseShadowDenoiserCS, HDShaderIDs._RaytracingLightRadius, data.properties.lightRadius);
					ctx.cmd.SetComputeIntParam(data.diffuseShadowDenoiserCS, HDShaderIDs._DenoiserFilterRadius, data.properties.kernelSize);
					ctx.cmd.SetComputeVectorParam(data.diffuseShadowDenoiserCS, HDShaderIDs._SphereLightPosition, data.properties.lightPosition);
					ctx.cmd.SetComputeFloatParam(data.diffuseShadowDenoiserCS, HDShaderIDs._CameraFOV, data.cameraFov);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralHKernel, HDShaderIDs._DepthTexture, data.depthStencilBuffer);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralHKernel, HDShaderIDs._NormalBufferTexture, data.normalBuffer);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralHKernel, HDShaderIDs._DenoiseInputTexture, data.noisyBuffer);
					if (data.properties.distanceBasedDenoiser)
					{
						ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralHKernel, HDShaderIDs._DistanceTexture, data.distanceBuffer);
					}
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralHKernel, HDShaderIDs._DenoiseOutputTextureRW, data.intermediateBuffer);
					ctx.cmd.DispatchCompute(data.diffuseShadowDenoiserCS, data.bilateralHKernel, threadGroupsX, threadGroupsY, data.viewCount);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralVKernel, HDShaderIDs._DepthTexture, data.depthStencilBuffer);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralVKernel, HDShaderIDs._NormalBufferTexture, data.normalBuffer);
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralVKernel, HDShaderIDs._DenoiseInputTexture, data.intermediateBuffer);
					if (data.properties.distanceBasedDenoiser)
					{
						ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralVKernel, HDShaderIDs._DistanceTexture, data.distanceBuffer);
					}
					ctx.cmd.SetComputeTextureParam(data.diffuseShadowDenoiserCS, data.bilateralVKernel, HDShaderIDs._DenoiseOutputTextureRW, data.outputBuffer);
					ctx.cmd.DispatchCompute(data.diffuseShadowDenoiserCS, data.bilateralVKernel, threadGroupsX, threadGroupsY, data.viewCount);
					CoreUtils.SetKeyword(ctx.cmd, "DISTANCE_BASED_DENOISER", false);
				});
				result = diffuseShadowDenoiserSpherePassData.outputBuffer;
			}
			return result;
		}

		// Token: 0x040012D6 RID: 4822
		private ComputeShader m_ShadowDenoiser;

		// Token: 0x040012D7 RID: 4823
		private int m_BilateralFilterHSingleDirectionalKernel;

		// Token: 0x040012D8 RID: 4824
		private int m_BilateralFilterVSingleDirectionalKernel;

		// Token: 0x040012D9 RID: 4825
		private int m_BilateralFilterHColorDirectionalKernel;

		// Token: 0x040012DA RID: 4826
		private int m_BilateralFilterVColorDirectionalKernel;

		// Token: 0x040012DB RID: 4827
		private int m_BilateralFilterHSinglePointKernel;

		// Token: 0x040012DC RID: 4828
		private int m_BilateralFilterVSinglePointKernel;

		// Token: 0x040012DD RID: 4829
		private int m_BilateralFilterHSingleSpotKernel;

		// Token: 0x040012DE RID: 4830
		private int m_BilateralFilterVSingleSpotKernel;

		// Token: 0x020003CD RID: 973
		private class DiffuseShadowDenoiserDirectionalPassData
		{
			// Token: 0x0400278A RID: 10122
			public int texWidth;

			// Token: 0x0400278B RID: 10123
			public int texHeight;

			// Token: 0x0400278C RID: 10124
			public int viewCount;

			// Token: 0x0400278D RID: 10125
			public float lightAngle;

			// Token: 0x0400278E RID: 10126
			public float cameraFov;

			// Token: 0x0400278F RID: 10127
			public int kernelSize;

			// Token: 0x04002790 RID: 10128
			public int bilateralHKernel;

			// Token: 0x04002791 RID: 10129
			public int bilateralVKernel;

			// Token: 0x04002792 RID: 10130
			public ComputeShader diffuseShadowDenoiserCS;

			// Token: 0x04002793 RID: 10131
			public TextureHandle depthStencilBuffer;

			// Token: 0x04002794 RID: 10132
			public TextureHandle normalBuffer;

			// Token: 0x04002795 RID: 10133
			public TextureHandle distanceBuffer;

			// Token: 0x04002796 RID: 10134
			public TextureHandle noisyBuffer;

			// Token: 0x04002797 RID: 10135
			public TextureHandle intermediateBuffer;

			// Token: 0x04002798 RID: 10136
			public TextureHandle outputBuffer;
		}

		// Token: 0x020003CE RID: 974
		private class DiffuseShadowDenoiserSpherePassData
		{
			// Token: 0x04002799 RID: 10137
			public int texWidth;

			// Token: 0x0400279A RID: 10138
			public int texHeight;

			// Token: 0x0400279B RID: 10139
			public int viewCount;

			// Token: 0x0400279C RID: 10140
			public float cameraFov;

			// Token: 0x0400279D RID: 10141
			public PunctualShadowProperties properties;

			// Token: 0x0400279E RID: 10142
			public int bilateralHKernel;

			// Token: 0x0400279F RID: 10143
			public int bilateralVKernel;

			// Token: 0x040027A0 RID: 10144
			public ComputeShader diffuseShadowDenoiserCS;

			// Token: 0x040027A1 RID: 10145
			public TextureHandle depthStencilBuffer;

			// Token: 0x040027A2 RID: 10146
			public TextureHandle normalBuffer;

			// Token: 0x040027A3 RID: 10147
			public TextureHandle distanceBuffer;

			// Token: 0x040027A4 RID: 10148
			public TextureHandle noisyBuffer;

			// Token: 0x040027A5 RID: 10149
			public TextureHandle intermediateBuffer;

			// Token: 0x040027A6 RID: 10150
			public TextureHandle outputBuffer;
		}
	}
}
