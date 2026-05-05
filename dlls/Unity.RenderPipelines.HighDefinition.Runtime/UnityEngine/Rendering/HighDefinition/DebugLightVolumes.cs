using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000039 RID: 57
	internal class DebugLightVolumes
	{
		// Token: 0x06000206 RID: 518 RVA: 0x0000BA98 File Offset: 0x00009C98
		public void InitData(HDRenderPipelineRuntimeResources renderPipelineResources)
		{
			this.m_DebugLightVolumeMaterial = CoreUtils.CreateEngineMaterial(renderPipelineResources.shaders.debugLightVolumePS);
			this.m_DebugLightVolumeCompute = renderPipelineResources.shaders.debugLightVolumeCS;
			this.m_DebugLightVolumeGradientKernel = this.m_DebugLightVolumeCompute.FindKernel("LightVolumeGradient");
			this.m_DebugLightVolumeColorsKernel = this.m_DebugLightVolumeCompute.FindKernel("LightVolumeColors");
			this.m_ColorGradientTexture = renderPipelineResources.textures.colorGradient;
			this.m_Blit = Blitter.GetBlitMaterial(TextureDimension.Tex2D, false);
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000BB16 File Offset: 0x00009D16
		public void ReleaseData()
		{
			CoreUtils.Destroy(this.m_DebugLightVolumeMaterial);
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0000BB24 File Offset: 0x00009D24
		public void RenderLightVolumes(RenderGraph renderGraph, LightingDebugSettings lightingDebugSettings, TextureHandle destination, TextureHandle depthBuffer, CullingResults cullResults, HDCamera hdCamera)
		{
			DebugLightVolumes.RenderLightVolumesPassData renderLightVolumesPassData;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<DebugLightVolumes.RenderLightVolumesPassData>("LightVolumes", out renderLightVolumesPassData))
			{
				bool flag = CoreUtils.IsLightOverlapDebugEnabled(hdCamera.camera);
				bool flag2 = lightingDebugSettings.lightVolumeDebugByCategory == LightVolumeDebug.ColorAndEdge || flag;
				renderLightVolumesPassData.hdCamera = hdCamera;
				renderLightVolumesPassData.cullResults = cullResults;
				renderLightVolumesPassData.debugLightVolumeMaterial = this.m_DebugLightVolumeMaterial;
				renderLightVolumesPassData.debugLightVolumeCS = this.m_DebugLightVolumeCompute;
				renderLightVolumesPassData.debugLightVolumeKernel = (flag2 ? this.m_DebugLightVolumeColorsKernel : this.m_DebugLightVolumeGradientKernel);
				renderLightVolumesPassData.maxDebugLightCount = (int)lightingDebugSettings.maxDebugLightCount;
				renderLightVolumesPassData.borderRadius = (flag ? 0.5f : 1f);
				renderLightVolumesPassData.colorGradientTexture = this.m_ColorGradientTexture;
				renderLightVolumesPassData.lightOverlapEnabled = flag;
				DebugLightVolumes.RenderLightVolumesPassData renderLightVolumesPassData2 = renderLightVolumesPassData;
				TextureDesc textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.R32_SFloat;
				textureDesc.clearBuffer = true;
				textureDesc.clearColor = Color.black;
				textureDesc.name = "LightVolumeCount";
				renderLightVolumesPassData2.lightCountBuffer = renderGraphBuilder.CreateTransientTexture(textureDesc);
				DebugLightVolumes.RenderLightVolumesPassData renderLightVolumesPassData3 = renderLightVolumesPassData;
				textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
				textureDesc.clearBuffer = true;
				textureDesc.clearColor = Color.black;
				textureDesc.name = "LightVolumeColorAccumulation";
				renderLightVolumesPassData3.colorAccumulationBuffer = renderGraphBuilder.CreateTransientTexture(textureDesc);
				DebugLightVolumes.RenderLightVolumesPassData renderLightVolumesPassData4 = renderLightVolumesPassData;
				textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
				textureDesc.clearBuffer = true;
				textureDesc.clearColor = Color.black;
				textureDesc.enableRandomWrite = true;
				textureDesc.name = "LightVolumeDebugLightVolumesTexture";
				renderLightVolumesPassData4.debugLightVolumesTexture = renderGraphBuilder.CreateTransientTexture(textureDesc);
				renderLightVolumesPassData.depthBuffer = renderGraphBuilder.UseDepthBuffer(depthBuffer, DepthAccess.ReadWrite);
				renderLightVolumesPassData.destination = renderGraphBuilder.WriteTexture(destination);
				renderGraphBuilder.SetRenderFunc<DebugLightVolumes.RenderLightVolumesPassData>(delegate(DebugLightVolumes.RenderLightVolumesPassData data, RenderGraphContext ctx)
				{
					MaterialPropertyBlock tempMaterialPropertyBlock = ctx.renderGraphPool.GetTempMaterialPropertyBlock();
					RenderTargetIdentifier[] tempArray = ctx.renderGraphPool.GetTempArray<RenderTargetIdentifier>(2);
					tempArray[0] = data.lightCountBuffer;
					tempArray[1] = data.colorAccumulationBuffer;
					if (data.lightOverlapEnabled)
					{
						CoreUtils.SetRenderTarget(ctx.cmd, tempArray[0], depthBuffer, 0, CubemapFace.Unknown, -1);
						using (HashSet<HDAdditionalLightData>.Enumerator enumerator = HDAdditionalLightData.s_overlappingHDLights.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								HDAdditionalLightData hdadditionalLightData = enumerator.Current;
								DebugLightVolumes.RenderLightVolume(ctx.cmd, data.debugLightVolumeMaterial, hdadditionalLightData, hdadditionalLightData.legacyLight, tempMaterialPropertyBlock);
							}
							goto IL_2DF;
						}
					}
					CoreUtils.SetRenderTarget(ctx.cmd, tempArray, depthBuffer);
					int length = data.cullResults.visibleLights.Length;
					for (int i = 0; i < length; i++)
					{
						Light light = data.cullResults.visibleLights[i].light;
						if (!(light == null))
						{
							HDAdditionalLightData component = light.GetComponent<HDAdditionalLightData>();
							if (!(component == null))
							{
								DebugLightVolumes.RenderLightVolume(ctx.cmd, data.debugLightVolumeMaterial, component, light, tempMaterialPropertyBlock);
							}
						}
					}
					if (!data.lightOverlapEnabled)
					{
						int length2 = data.cullResults.visibleReflectionProbes.Length;
						for (int j = 0; j < length2; j++)
						{
							ReflectionProbe reflectionProbe = data.cullResults.visibleReflectionProbes[j].reflectionProbe;
							HDAdditionalReflectionData component2 = reflectionProbe.GetComponent<HDAdditionalReflectionData>();
							if (component2)
							{
								MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
								Mesh mesh;
								if (component2.influenceVolume.shape == InfluenceShape.Sphere)
								{
									materialPropertyBlock.SetVector(DebugLightVolumes._RangeShaderID, new Vector3(component2.influenceVolume.sphereRadius, component2.influenceVolume.sphereRadius, component2.influenceVolume.sphereRadius));
									mesh = DebugShapes.instance.RequestSphereMesh();
								}
								else
								{
									materialPropertyBlock.SetVector(DebugLightVolumes._RangeShaderID, new Vector3(component2.influenceVolume.boxSize.x, component2.influenceVolume.boxSize.y, component2.influenceVolume.boxSize.z));
									mesh = DebugShapes.instance.RequestBoxMesh();
								}
								materialPropertyBlock.SetColor(DebugLightVolumes._ColorShaderID, new Color(1f, 1f, 0f, 1f));
								materialPropertyBlock.SetVector(DebugLightVolumes._OffsetShaderID, new Vector3(0f, 0f, 0f));
								Matrix4x4 matrix = Matrix4x4.Translate(reflectionProbe.transform.position);
								ctx.cmd.DrawMesh(mesh, matrix, data.debugLightVolumeMaterial, 0, 0, materialPropertyBlock);
							}
						}
					}
					IL_2DF:
					ctx.cmd.SetComputeTextureParam(data.debugLightVolumeCS, data.debugLightVolumeKernel, DebugLightVolumes._DebugLightCountBufferShaderID, data.lightCountBuffer);
					ctx.cmd.SetComputeTextureParam(data.debugLightVolumeCS, data.debugLightVolumeKernel, DebugLightVolumes._DebugColorAccumulationBufferShaderID, data.colorAccumulationBuffer);
					ctx.cmd.SetComputeTextureParam(data.debugLightVolumeCS, data.debugLightVolumeKernel, DebugLightVolumes._DebugLightVolumesTextureShaderID, data.debugLightVolumesTexture);
					ctx.cmd.SetComputeTextureParam(data.debugLightVolumeCS, data.debugLightVolumeKernel, DebugLightVolumes._ColorGradientTextureShaderID, data.colorGradientTexture);
					ctx.cmd.SetComputeIntParam(data.debugLightVolumeCS, DebugLightVolumes._MaxDebugLightCountShaderID, data.maxDebugLightCount);
					ctx.cmd.SetComputeFloatParam(data.debugLightVolumeCS, DebugLightVolumes._BorderRadiusShaderID, data.borderRadius);
					int actualWidth = data.hdCamera.actualWidth;
					int actualHeight = data.hdCamera.actualHeight;
					int num = 8;
					int threadGroupsX = (actualWidth + (num - 1)) / num;
					int threadGroupsY = (actualHeight + (num - 1)) / num;
					ctx.cmd.DispatchCompute(data.debugLightVolumeCS, data.debugLightVolumeKernel, threadGroupsX, threadGroupsY, data.hdCamera.viewCount);
					CoreUtils.SetRenderTarget(ctx.cmd, destination, ClearFlag.None, 0, CubemapFace.Unknown, -1);
					tempMaterialPropertyBlock.SetTexture(HDShaderIDs._BlitTexture, data.debugLightVolumesTexture);
					ctx.cmd.DrawProcedural(Matrix4x4.identity, data.debugLightVolumeMaterial, 1, MeshTopology.Triangles, 3, 1, tempMaterialPropertyBlock);
				});
			}
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0000BD24 File Offset: 0x00009F24
		private static void RenderLightVolume(CommandBuffer cmd, Material debugLightVolumeMaterial, HDAdditionalLightData currentHDRLight, Light currentLegacyLight, MaterialPropertyBlock mpb)
		{
			Matrix4x4 matrix = Matrix4x4.Translate(currentLegacyLight.transform.position);
			switch (currentHDRLight.ComputeLightType(currentLegacyLight))
			{
			case HDLightType.Spot:
				switch (currentHDRLight.spotLightShape)
				{
				case SpotLightShape.Cone:
				{
					float num = Mathf.Tan(currentLegacyLight.spotAngle * 3.1415927f / 360f) * currentLegacyLight.range;
					mpb.SetColor(DebugLightVolumes._ColorShaderID, new Color(1f, 0.5f, 0f, 1f));
					mpb.SetVector(DebugLightVolumes._RangeShaderID, new Vector3(num, num, currentLegacyLight.range));
					mpb.SetVector(DebugLightVolumes._OffsetShaderID, new Vector3(0f, 0f, 0f));
					cmd.DrawMesh(DebugShapes.instance.RequestConeMesh(), currentLegacyLight.gameObject.transform.localToWorldMatrix, debugLightVolumeMaterial, 0, 0, mpb);
					return;
				}
				case SpotLightShape.Pyramid:
				{
					float num2 = Mathf.Tan(currentLegacyLight.spotAngle * 3.1415927f / 360f) * currentLegacyLight.range;
					mpb.SetColor(DebugLightVolumes._ColorShaderID, new Color(1f, 0.5f, 0f, 1f));
					mpb.SetVector(DebugLightVolumes._RangeShaderID, new Vector3(currentHDRLight.aspectRatio * num2 * 2f, num2 * 2f, currentLegacyLight.range));
					mpb.SetVector(DebugLightVolumes._OffsetShaderID, new Vector3(0f, 0f, 0f));
					cmd.DrawMesh(DebugShapes.instance.RequestPyramidMesh(), currentLegacyLight.gameObject.transform.localToWorldMatrix, debugLightVolumeMaterial, 0, 0, mpb);
					return;
				}
				case SpotLightShape.Box:
					mpb.SetColor(DebugLightVolumes._ColorShaderID, new Color(1f, 0.5f, 0f, 1f));
					mpb.SetVector(DebugLightVolumes._RangeShaderID, new Vector3(currentHDRLight.shapeWidth, currentHDRLight.shapeHeight, currentLegacyLight.range));
					mpb.SetVector(DebugLightVolumes._OffsetShaderID, new Vector3(0f, 0f, currentLegacyLight.range / 2f));
					cmd.DrawMesh(DebugShapes.instance.RequestBoxMesh(), currentLegacyLight.gameObject.transform.localToWorldMatrix, debugLightVolumeMaterial, 0, 0, mpb);
					return;
				default:
					return;
				}
				break;
			case HDLightType.Directional:
				break;
			case HDLightType.Point:
				mpb.SetColor(DebugLightVolumes._ColorShaderID, new Color(0f, 0.5f, 0f, 1f));
				mpb.SetVector(DebugLightVolumes._OffsetShaderID, new Vector3(0f, 0f, 0f));
				mpb.SetVector(DebugLightVolumes._RangeShaderID, new Vector3(currentLegacyLight.range, currentLegacyLight.range, currentLegacyLight.range));
				cmd.DrawMesh(DebugShapes.instance.RequestSphereMesh(), matrix, debugLightVolumeMaterial, 0, 0, mpb);
				return;
			case HDLightType.Area:
			{
				AreaLightShape areaLightShape = currentHDRLight.areaLightShape;
				if (areaLightShape == AreaLightShape.Rectangle)
				{
					mpb.SetColor(DebugLightVolumes._ColorShaderID, new Color(0f, 1f, 1f, 1f));
					mpb.SetVector(DebugLightVolumes._OffsetShaderID, new Vector3(0f, 0f, 0f));
					mpb.SetVector(DebugLightVolumes._RangeShaderID, new Vector3(currentLegacyLight.range, currentLegacyLight.range, currentLegacyLight.range));
					cmd.DrawMesh(DebugShapes.instance.RequestSphereMesh(), matrix, debugLightVolumeMaterial, 0, 0, mpb);
					return;
				}
				if (areaLightShape != AreaLightShape.Tube)
				{
					return;
				}
				mpb.SetColor(DebugLightVolumes._ColorShaderID, new Color(1f, 0f, 0.5f, 1f));
				mpb.SetVector(DebugLightVolumes._OffsetShaderID, new Vector3(0f, 0f, 0f));
				mpb.SetVector(DebugLightVolumes._RangeShaderID, new Vector3(currentLegacyLight.range, currentLegacyLight.range, currentLegacyLight.range));
				cmd.DrawMesh(DebugShapes.instance.RequestSphereMesh(), matrix, debugLightVolumeMaterial, 0, 0, mpb);
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x0400015D RID: 349
		private Material m_Blit;

		// Token: 0x0400015E RID: 350
		private Material m_DebugLightVolumeMaterial;

		// Token: 0x0400015F RID: 351
		private ComputeShader m_DebugLightVolumeCompute;

		// Token: 0x04000160 RID: 352
		private int m_DebugLightVolumeGradientKernel;

		// Token: 0x04000161 RID: 353
		private int m_DebugLightVolumeColorsKernel;

		// Token: 0x04000162 RID: 354
		private Texture2D m_ColorGradientTexture;

		// Token: 0x04000163 RID: 355
		public static readonly int _ColorShaderID = Shader.PropertyToID("_Color");

		// Token: 0x04000164 RID: 356
		public static readonly int _OffsetShaderID = Shader.PropertyToID("_Offset");

		// Token: 0x04000165 RID: 357
		public static readonly int _RangeShaderID = Shader.PropertyToID("_Range");

		// Token: 0x04000166 RID: 358
		public static readonly int _DebugLightCountBufferShaderID = Shader.PropertyToID("_DebugLightCountBuffer");

		// Token: 0x04000167 RID: 359
		public static readonly int _DebugColorAccumulationBufferShaderID = Shader.PropertyToID("_DebugColorAccumulationBuffer");

		// Token: 0x04000168 RID: 360
		public static readonly int _DebugLightVolumesTextureShaderID = Shader.PropertyToID("_DebugLightVolumesTexture");

		// Token: 0x04000169 RID: 361
		public static readonly int _ColorGradientTextureShaderID = Shader.PropertyToID("_ColorGradientTexture");

		// Token: 0x0400016A RID: 362
		public static readonly int _MaxDebugLightCountShaderID = Shader.PropertyToID("_MaxDebugLightCount");

		// Token: 0x0400016B RID: 363
		public static readonly int _BorderRadiusShaderID = Shader.PropertyToID("_BorderRadius");

		// Token: 0x0400016C RID: 364
		private MaterialPropertyBlock m_MaterialProperty = new MaterialPropertyBlock();

		// Token: 0x02000262 RID: 610
		private class RenderLightVolumesPassData
		{
			// Token: 0x04001AF3 RID: 6899
			public HDCamera hdCamera;

			// Token: 0x04001AF4 RID: 6900
			public CullingResults cullResults;

			// Token: 0x04001AF5 RID: 6901
			public Material debugLightVolumeMaterial;

			// Token: 0x04001AF6 RID: 6902
			public ComputeShader debugLightVolumeCS;

			// Token: 0x04001AF7 RID: 6903
			public int debugLightVolumeKernel;

			// Token: 0x04001AF8 RID: 6904
			public int maxDebugLightCount;

			// Token: 0x04001AF9 RID: 6905
			public float borderRadius;

			// Token: 0x04001AFA RID: 6906
			public Texture2D colorGradientTexture;

			// Token: 0x04001AFB RID: 6907
			public bool lightOverlapEnabled;

			// Token: 0x04001AFC RID: 6908
			public TextureHandle lightCountBuffer;

			// Token: 0x04001AFD RID: 6909
			public TextureHandle colorAccumulationBuffer;

			// Token: 0x04001AFE RID: 6910
			public TextureHandle debugLightVolumesTexture;

			// Token: 0x04001AFF RID: 6911
			public TextureHandle depthBuffer;

			// Token: 0x04001B00 RID: 6912
			public TextureHandle destination;
		}
	}
}
