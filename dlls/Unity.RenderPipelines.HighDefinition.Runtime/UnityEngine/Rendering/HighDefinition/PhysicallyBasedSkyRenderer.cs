using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001E4 RID: 484
	internal class PhysicallyBasedSkyRenderer : SkyRenderer
	{
		// Token: 0x06000EB0 RID: 3760 RVA: 0x000743D8 File Offset: 0x000725D8
		public override void Build()
		{
			HDRenderPipelineRuntimeResources renderPipelineResources = HDRenderPipelineGlobalSettings.instance.renderPipelineResources;
			HDRenderPipeline hdrenderPipeline = RenderPipelineManager.currentPipeline as HDRenderPipeline;
			if (hdrenderPipeline != null)
			{
				PhysicallyBasedSkyRenderer.s_ColorFormat = hdrenderPipeline.GetColorBufferFormat();
			}
			PhysicallyBasedSkyRenderer.s_SkyLUTGenerator = renderPipelineResources.shaders.skyLUTGenerator;
			PhysicallyBasedSkyRenderer.s_MultiScatteringKernel = PhysicallyBasedSkyRenderer.s_SkyLUTGenerator.FindKernel("MultiScatteringLUT");
			PhysicallyBasedSkyRenderer.s_GroundIrradiancePrecomputationCS = renderPipelineResources.shaders.groundIrradiancePrecomputationCS;
			PhysicallyBasedSkyRenderer.s_InScatteredRadiancePrecomputationCS = renderPipelineResources.shaders.inScatteredRadiancePrecomputationCS;
			this.m_PbrSkyMaterial = CoreUtils.CreateEngineMaterial(renderPipelineResources.shaders.physicallyBasedSkyPS);
			PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties = new MaterialPropertyBlock();
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x0007446D File Offset: 0x0007266D
		public override void SetGlobalSkyData(CommandBuffer cmd, BuiltinSkyParameters builtinParams)
		{
			this.UpdateGlobalConstantBuffer(cmd, builtinParams);
			if (this.m_PrecomputedData != null)
			{
				this.m_PrecomputedData.BindGlobalBuffers(builtinParams.commandBuffer);
			}
		}

		// Token: 0x06000EB2 RID: 3762 RVA: 0x00074490 File Offset: 0x00072690
		public override void Cleanup()
		{
			if (this.m_PrecomputedData != null)
			{
				PhysicallyBasedSkyRenderer.s_PrecomputaionCache.Release(this.m_LastPrecomputationParamHash);
				this.m_LastPrecomputationParamHash = 0;
				this.m_PrecomputedData = null;
			}
			CoreUtils.Destroy(this.m_PbrSkyMaterial);
		}

		// Token: 0x06000EB3 RID: 3763 RVA: 0x000744C4 File Offset: 0x000726C4
		private static float CornetteShanksPhasePartConstant(float anisotropy)
		{
			return 0.119366206f * (1f - anisotropy * anisotropy) / (2f + anisotropy * anisotropy);
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x000744EC File Offset: 0x000726EC
		private static Vector2 ComputeExponentialInterpolationParams(float k)
		{
			if (k == 0f)
			{
				k = 1E-06f;
			}
			float num = 10f * k;
			float y = 1f / (Mathf.Exp(num) - 1f);
			return new Vector2(num, y);
		}

		// Token: 0x06000EB5 RID: 3765 RVA: 0x0007452C File Offset: 0x0007272C
		private void UpdateGlobalConstantBuffer(CommandBuffer cmd, BuiltinSkyParameters builtinParams)
		{
			PhysicallyBasedSky physicallyBasedSky = builtinParams.skySettings as PhysicallyBasedSky;
			float planetaryRadius = physicallyBasedSky.GetPlanetaryRadius();
			float maximumAltitude = physicallyBasedSky.GetMaximumAltitude();
			float airScaleHeight = physicallyBasedSky.GetAirScaleHeight();
			float aerosolScaleHeight = physicallyBasedSky.GetAerosolScaleHeight();
			float aerosolAnisotropy = physicallyBasedSky.GetAerosolAnisotropy();
			float skyIntensity = SkyRenderer.GetSkyIntensity(physicallyBasedSky, builtinParams.debugSettings);
			Vector2 vector = PhysicallyBasedSkyRenderer.ComputeExponentialInterpolationParams(physicallyBasedSky.horizonZenithShift.value);
			this.m_ConstantBuffer._PlanetaryRadius = planetaryRadius;
			this.m_ConstantBuffer._RcpPlanetaryRadius = 1f / planetaryRadius;
			this.m_ConstantBuffer._AtmosphericDepth = maximumAltitude;
			this.m_ConstantBuffer._RcpAtmosphericDepth = 1f / maximumAltitude;
			this.m_ConstantBuffer._AtmosphericRadius = planetaryRadius + maximumAltitude;
			this.m_ConstantBuffer._AerosolAnisotropy = aerosolAnisotropy;
			this.m_ConstantBuffer._AerosolPhasePartConstant = PhysicallyBasedSkyRenderer.CornetteShanksPhasePartConstant(aerosolAnisotropy);
			this.m_ConstantBuffer._Unused = 0f;
			this.m_ConstantBuffer._Unused2 = 0f;
			this.m_ConstantBuffer._AirDensityFalloff = 1f / airScaleHeight;
			this.m_ConstantBuffer._AirScaleHeight = airScaleHeight;
			this.m_ConstantBuffer._AerosolDensityFalloff = 1f / aerosolScaleHeight;
			this.m_ConstantBuffer._AerosolScaleHeight = aerosolScaleHeight;
			this.m_ConstantBuffer._AirSeaLevelExtinction = physicallyBasedSky.GetAirExtinctionCoefficient();
			this.m_ConstantBuffer._AerosolSeaLevelExtinction = physicallyBasedSky.GetAerosolExtinctionCoefficient();
			this.m_ConstantBuffer._AirSeaLevelScattering = physicallyBasedSky.GetAirScatteringCoefficient();
			this.m_ConstantBuffer._IntensityMultiplier = skyIntensity;
			this.m_ConstantBuffer._AerosolSeaLevelScattering = physicallyBasedSky.GetAerosolScatteringCoefficient();
			this.m_ConstantBuffer._ColorSaturation = physicallyBasedSky.colorSaturation.value;
			Vector3 v = new Vector3(physicallyBasedSky.groundTint.value.r, physicallyBasedSky.groundTint.value.g, physicallyBasedSky.groundTint.value.b);
			this.m_ConstantBuffer._GroundAlbedo = v;
			this.m_ConstantBuffer._AlphaSaturation = physicallyBasedSky.alphaSaturation.value;
			this.m_ConstantBuffer._PlanetCenterPosition = physicallyBasedSky.GetPlanetCenterPosition(builtinParams.worldSpaceCameraPos);
			this.m_ConstantBuffer._AlphaMultiplier = physicallyBasedSky.alphaMultiplier.value;
			Vector3 v2 = new Vector3(physicallyBasedSky.horizonTint.value.r, physicallyBasedSky.horizonTint.value.g, physicallyBasedSky.horizonTint.value.b);
			this.m_ConstantBuffer._HorizonTint = v2;
			this.m_ConstantBuffer._HorizonZenithShiftPower = vector.x;
			Vector3 v3 = new Vector3(physicallyBasedSky.zenithTint.value.r, physicallyBasedSky.zenithTint.value.g, physicallyBasedSky.zenithTint.value.b);
			this.m_ConstantBuffer._ZenithTint = v3;
			this.m_ConstantBuffer._HorizonZenithShiftScale = vector.y;
			ConstantBuffer.PushGlobal<ShaderVariablesPhysicallyBasedSky>(cmd, this.m_ConstantBuffer, this.m_ShaderVariablesPhysicallyBasedSkyID);
		}

		// Token: 0x06000EB6 RID: 3766 RVA: 0x00074820 File Offset: 0x00072A20
		protected override bool Update(BuiltinSkyParameters builtinParams)
		{
			this.UpdateGlobalConstantBuffer(builtinParams.commandBuffer, builtinParams);
			int precomputationHashCode = (builtinParams.skySettings as PhysicallyBasedSky).GetPrecomputationHashCode();
			if (precomputationHashCode != this.m_LastPrecomputationParamHash)
			{
				if (this.m_LastPrecomputationParamHash != 0)
				{
					PhysicallyBasedSkyRenderer.s_PrecomputaionCache.Release(this.m_LastPrecomputationParamHash);
				}
				this.m_PrecomputedData = PhysicallyBasedSkyRenderer.s_PrecomputaionCache.Get(builtinParams, precomputationHashCode);
				this.m_LastPrecomputationParamHash = precomputationHashCode;
			}
			return false;
		}

		// Token: 0x06000EB7 RID: 3767 RVA: 0x00074888 File Offset: 0x00072A88
		public override void RenderSky(BuiltinSkyParameters builtinParams, bool renderForCubemap, bool renderSunDisk)
		{
			PhysicallyBasedSky physicallyBasedSky = builtinParams.skySettings as PhysicallyBasedSky;
			this.m_PrecomputedData.BindGlobalBuffers(builtinParams.commandBuffer);
			this.m_PrecomputedData.BindBuffers(PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties);
			Vector3 vector = builtinParams.worldSpaceCameraPos;
			Vector3 planetCenterPosition = physicallyBasedSky.GetPlanetCenterPosition(vector);
			float planetaryRadius = physicallyBasedSky.GetPlanetaryRadius();
			Vector3 vector2 = planetCenterPosition - vector;
			float magnitude = vector2.magnitude;
			vector = planetCenterPosition - Mathf.Max(planetaryRadius, magnitude) * vector2.normalized;
			bool flag = physicallyBasedSky.type.value == PhysicallyBasedSkyModel.EarthSimple;
			Quaternion q = Quaternion.Euler(physicallyBasedSky.planetRotation.value.x, physicallyBasedSky.planetRotation.value.y, physicallyBasedSky.planetRotation.value.z);
			Quaternion q2 = Quaternion.Euler(physicallyBasedSky.spaceRotation.value.x, physicallyBasedSky.spaceRotation.value.y, physicallyBasedSky.spaceRotation.value.z);
			Matrix4x4 value = Matrix4x4.Rotate(q);
			ref Matrix4x4 ptr = ref value;
			ptr[0] = ptr[0] * -1f;
			ptr = ref value;
			ptr[1] = ptr[1] * -1f;
			ptr = ref value;
			ptr[2] = ptr[2] * -1f;
			PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties.SetMatrix(HDShaderIDs._PixelCoordToViewDirWS, builtinParams.pixelCoordToViewDirMatrix);
			PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties.SetVector(HDShaderIDs._WorldSpaceCameraPos1, vector);
			PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties.SetMatrix(HDShaderIDs._ViewMatrix1, builtinParams.viewMatrix);
			PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties.SetMatrix(HDShaderIDs._PlanetRotation, value);
			PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties.SetMatrix(HDShaderIDs._SpaceRotation, Matrix4x4.Rotate(q2));
			int value2 = 0;
			if (physicallyBasedSky.groundColorTexture.value != null && !flag)
			{
				value2 = 1;
				PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties.SetTexture(HDShaderIDs._GroundAlbedoTexture, physicallyBasedSky.groundColorTexture.value);
			}
			PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties.SetInt(HDShaderIDs._HasGroundAlbedoTexture, value2);
			int value3 = 0;
			if (physicallyBasedSky.groundEmissionTexture.value != null && !flag)
			{
				value3 = 1;
				PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties.SetTexture(HDShaderIDs._GroundEmissionTexture, physicallyBasedSky.groundEmissionTexture.value);
				PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties.SetFloat(HDShaderIDs._GroundEmissionMultiplier, physicallyBasedSky.groundEmissionMultiplier.value);
			}
			PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties.SetInt(HDShaderIDs._HasGroundEmissionTexture, value3);
			int value4 = 0;
			if (physicallyBasedSky.spaceEmissionTexture.value != null && !flag)
			{
				value4 = 1;
				PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties.SetTexture(HDShaderIDs._SpaceEmissionTexture, physicallyBasedSky.spaceEmissionTexture.value);
				PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties.SetFloat(HDShaderIDs._SpaceEmissionMultiplier, physicallyBasedSky.spaceEmissionMultiplier.value);
			}
			PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties.SetInt(HDShaderIDs._HasSpaceEmissionTexture, value4);
			PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties.SetInt(HDShaderIDs._RenderSunDisk, renderSunDisk ? 1 : 0);
			int shaderPassId = renderForCubemap ? 0 : 2;
			CoreUtils.DrawFullScreen(builtinParams.commandBuffer, this.m_PbrSkyMaterial, PhysicallyBasedSkyRenderer.s_PbrSkyMaterialProperties, shaderPassId);
		}

		// Token: 0x04001719 RID: 5913
		private int m_LastPrecomputationParamHash;

		// Token: 0x0400171A RID: 5914
		private PhysicallyBasedSkyRenderer.PrecomputationData m_PrecomputedData;

		// Token: 0x0400171B RID: 5915
		private Material m_PbrSkyMaterial;

		// Token: 0x0400171C RID: 5916
		private static MaterialPropertyBlock s_PbrSkyMaterialProperties;

		// Token: 0x0400171D RID: 5917
		private static PhysicallyBasedSkyRenderer.PrecomputationCache s_PrecomputaionCache = new PhysicallyBasedSkyRenderer.PrecomputationCache();

		// Token: 0x0400171E RID: 5918
		private ShaderVariablesPhysicallyBasedSky m_ConstantBuffer;

		// Token: 0x0400171F RID: 5919
		private int m_ShaderVariablesPhysicallyBasedSkyID = Shader.PropertyToID("ShaderVariablesPhysicallyBasedSky");

		// Token: 0x04001720 RID: 5920
		private static GraphicsFormat s_ColorFormat = GraphicsFormat.B10G11R11_UFloatPack32;

		// Token: 0x04001721 RID: 5921
		private static ComputeShader s_SkyLUTGenerator;

		// Token: 0x04001722 RID: 5922
		private static int s_MultiScatteringKernel;

		// Token: 0x04001723 RID: 5923
		private static ComputeShader s_GroundIrradiancePrecomputationCS;

		// Token: 0x04001724 RID: 5924
		private static ComputeShader s_InScatteredRadiancePrecomputationCS;

		// Token: 0x0200042E RID: 1070
		private class PrecomputationCache
		{
			// Token: 0x0600141C RID: 5148 RVA: 0x00098758 File Offset: 0x00096958
			public PhysicallyBasedSkyRenderer.PrecomputationData Get(BuiltinSkyParameters builtinParams, int hash)
			{
				PhysicallyBasedSkyRenderer.PrecomputationCache.RefCountedData refCountedData;
				if (this.m_CachedData.TryGetValue(hash, out refCountedData))
				{
					refCountedData.refCount++;
					return refCountedData.data;
				}
				refCountedData = this.m_DataPool.Get();
				refCountedData.refCount = 1;
				refCountedData.data.Allocate(builtinParams);
				this.m_CachedData.Add(hash, refCountedData);
				return refCountedData.data;
			}

			// Token: 0x0600141D RID: 5149 RVA: 0x000987BC File Offset: 0x000969BC
			public void Release(int hash)
			{
				PhysicallyBasedSkyRenderer.PrecomputationCache.RefCountedData refCountedData;
				if (this.m_CachedData.TryGetValue(hash, out refCountedData))
				{
					refCountedData.refCount--;
					if (refCountedData.refCount == 0)
					{
						refCountedData.data.Release();
						this.m_CachedData.Remove(hash);
						this.m_DataPool.Release(refCountedData);
					}
				}
			}

			// Token: 0x0400292A RID: 10538
			private ObjectPool<PhysicallyBasedSkyRenderer.PrecomputationCache.RefCountedData> m_DataPool = new ObjectPool<PhysicallyBasedSkyRenderer.PrecomputationCache.RefCountedData>(null, null, true);

			// Token: 0x0400292B RID: 10539
			private Dictionary<int, PhysicallyBasedSkyRenderer.PrecomputationCache.RefCountedData> m_CachedData = new Dictionary<int, PhysicallyBasedSkyRenderer.PrecomputationCache.RefCountedData>();

			// Token: 0x0200047D RID: 1149
			private class RefCountedData
			{
				// Token: 0x04002A1C RID: 10780
				public int refCount;

				// Token: 0x04002A1D RID: 10781
				public PhysicallyBasedSkyRenderer.PrecomputationData data = new PhysicallyBasedSkyRenderer.PrecomputationData();
			}
		}

		// Token: 0x0200042F RID: 1071
		private class PrecomputationData
		{
			// Token: 0x0600141F RID: 5151 RVA: 0x00098834 File Offset: 0x00096A34
			private RTHandle AllocateGroundIrradianceTable()
			{
				return RTHandles.Alloc(256, 1, 1, DepthBits.None, PhysicallyBasedSkyRenderer.s_ColorFormat, FilterMode.Point, TextureWrapMode.Repeat, TextureDimension.Tex2D, true, false, true, false, 1, 0f, MSAASamples.None, false, false, RenderTextureMemoryless.None, VRTextureUsage.None, "GroundIrradianceTable");
			}

			// Token: 0x06001420 RID: 5152 RVA: 0x0009886C File Offset: 0x00096A6C
			private RTHandle AllocateInScatteredRadianceTable(int index)
			{
				return RTHandles.Alloc(128, 32, 1024, DepthBits.None, PhysicallyBasedSkyRenderer.s_ColorFormat, FilterMode.Point, TextureWrapMode.Repeat, TextureDimension.Tex3D, true, false, true, false, 1, 0f, MSAASamples.None, false, false, RenderTextureMemoryless.None, VRTextureUsage.None, string.Format("InScatteredRadianceTable{0}", index));
			}

			// Token: 0x06001421 RID: 5153 RVA: 0x000988B4 File Offset: 0x00096AB4
			public void Allocate(BuiltinSkyParameters builtinParams)
			{
				CommandBuffer commandBuffer = builtinParams.commandBuffer;
				SkySettings skySettings = builtinParams.skySettings;
				this.m_MultiScatteringLut = RTHandles.Alloc(32, 32, 1, DepthBits.None, PhysicallyBasedSkyRenderer.s_ColorFormat, FilterMode.Point, TextureWrapMode.Clamp, TextureDimension.Tex2D, true, false, true, false, 1, 0f, MSAASamples.None, false, false, RenderTextureMemoryless.None, VRTextureUsage.None, "MultiScatteringLUT");
				this.RenderMultiScatteringLut(commandBuffer);
				this.m_GroundIrradianceTable = this.AllocateGroundIrradianceTable();
				this.m_InScatteredRadianceTables = new RTHandle[3];
				this.m_InScatteredRadianceTables[0] = this.AllocateInScatteredRadianceTable(0);
				this.m_InScatteredRadianceTables[1] = this.AllocateInScatteredRadianceTable(1);
				this.m_InScatteredRadianceTables[2] = this.AllocateInScatteredRadianceTable(2);
				this.PrecomputeTables(commandBuffer);
			}

			// Token: 0x06001422 RID: 5154 RVA: 0x00098950 File Offset: 0x00096B50
			public void Release()
			{
				if (this.m_MultiScatteringLut != null)
				{
					RTHandles.Release(this.m_MultiScatteringLut);
					this.m_MultiScatteringLut = null;
				}
				RTHandles.Release(this.m_GroundIrradianceTable);
				RTHandles.Release(this.m_InScatteredRadianceTables[0]);
				RTHandles.Release(this.m_InScatteredRadianceTables[1]);
				RTHandles.Release(this.m_InScatteredRadianceTables[2]);
				this.m_GroundIrradianceTable = null;
				this.m_InScatteredRadianceTables = null;
			}

			// Token: 0x06001423 RID: 5155 RVA: 0x000989B7 File Offset: 0x00096BB7
			private void RenderMultiScatteringLut(CommandBuffer cmd)
			{
				cmd.SetComputeTextureParam(PhysicallyBasedSkyRenderer.s_SkyLUTGenerator, PhysicallyBasedSkyRenderer.s_MultiScatteringKernel, HDShaderIDs._MultiScatteringLUT_RW, this.m_MultiScatteringLut);
				cmd.DispatchCompute(PhysicallyBasedSkyRenderer.s_SkyLUTGenerator, PhysicallyBasedSkyRenderer.s_MultiScatteringKernel, 32, 32, 1);
			}

			// Token: 0x06001424 RID: 5156 RVA: 0x000989F0 File Offset: 0x00096BF0
			private void PrecomputeTables(CommandBuffer cmd)
			{
				using (new ProfilingScope(cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.InScatteredRadiancePrecomputation)))
				{
					cmd.SetComputeTextureParam(PhysicallyBasedSkyRenderer.s_InScatteredRadiancePrecomputationCS, 0, HDShaderIDs._AirSingleScatteringTable, this.m_InScatteredRadianceTables[0]);
					cmd.SetComputeTextureParam(PhysicallyBasedSkyRenderer.s_InScatteredRadiancePrecomputationCS, 0, HDShaderIDs._AerosolSingleScatteringTable, this.m_InScatteredRadianceTables[1]);
					cmd.SetComputeTextureParam(PhysicallyBasedSkyRenderer.s_InScatteredRadiancePrecomputationCS, 0, HDShaderIDs._MultipleScatteringTable, this.m_InScatteredRadianceTables[2]);
					cmd.SetComputeTextureParam(PhysicallyBasedSkyRenderer.s_InScatteredRadiancePrecomputationCS, 0, HDShaderIDs._MultiScatteringLUT, this.m_MultiScatteringLut);
					cmd.DispatchCompute(PhysicallyBasedSkyRenderer.s_InScatteredRadiancePrecomputationCS, 0, 32, 8, 256);
					cmd.SetComputeTextureParam(PhysicallyBasedSkyRenderer.s_GroundIrradiancePrecomputationCS, 0, HDShaderIDs._AirSingleScatteringTexture, this.m_InScatteredRadianceTables[0]);
					cmd.SetComputeTextureParam(PhysicallyBasedSkyRenderer.s_GroundIrradiancePrecomputationCS, 0, HDShaderIDs._AerosolSingleScatteringTexture, this.m_InScatteredRadianceTables[1]);
					cmd.SetComputeTextureParam(PhysicallyBasedSkyRenderer.s_GroundIrradiancePrecomputationCS, 0, HDShaderIDs._MultipleScatteringTexture, this.m_InScatteredRadianceTables[2]);
					cmd.SetComputeTextureParam(PhysicallyBasedSkyRenderer.s_GroundIrradiancePrecomputationCS, 0, HDShaderIDs._GroundIrradianceTable, this.m_GroundIrradianceTable);
					cmd.DispatchCompute(PhysicallyBasedSkyRenderer.s_GroundIrradiancePrecomputationCS, 0, 4, 1, 1);
				}
			}

			// Token: 0x06001425 RID: 5157 RVA: 0x00098B48 File Offset: 0x00096D48
			public void BindGlobalBuffers(CommandBuffer cmd)
			{
			}

			// Token: 0x06001426 RID: 5158 RVA: 0x00098B4C File Offset: 0x00096D4C
			public void BindBuffers(MaterialPropertyBlock mpb)
			{
				mpb.SetTexture(HDShaderIDs._GroundIrradianceTexture, this.m_GroundIrradianceTable);
				mpb.SetTexture(HDShaderIDs._AirSingleScatteringTexture, this.m_InScatteredRadianceTables[0]);
				mpb.SetTexture(HDShaderIDs._AerosolSingleScatteringTexture, this.m_InScatteredRadianceTables[1]);
				mpb.SetTexture(HDShaderIDs._MultipleScatteringTexture, this.m_InScatteredRadianceTables[2]);
			}

			// Token: 0x0400292C RID: 10540
			private RTHandle m_GroundIrradianceTable;

			// Token: 0x0400292D RID: 10541
			private RTHandle m_MultiScatteringLut;

			// Token: 0x0400292E RID: 10542
			private RTHandle[] m_InScatteredRadianceTables;
		}
	}
}
