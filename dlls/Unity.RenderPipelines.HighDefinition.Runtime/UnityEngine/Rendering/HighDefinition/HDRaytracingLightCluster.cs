using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000177 RID: 375
	internal class HDRaytracingLightCluster
	{
		// Token: 0x06000C3B RID: 3131 RVA: 0x000651B8 File Offset: 0x000633B8
		public void Initialize(HDRenderPipeline renderPipeline)
		{
			this.m_RenderPipelineResources = HDRenderPipelineGlobalSettings.instance.renderPipelineResources;
			this.m_RenderPipelineRayTracingResources = HDRenderPipelineGlobalSettings.instance.renderPipelineRayTracingResources;
			this.m_RenderPipeline = renderPipeline;
			this.m_LightDataGPUArray = new ComputeBuffer(1, Marshal.SizeOf(typeof(LightData)));
			this.m_EnvLightDataGPUArray = new ComputeBuffer(1, Marshal.SizeOf(typeof(EnvLightData)));
			this.m_NumLightsPerCell = renderPipeline.asset.currentPlatformRenderPipelineSettings.lightLoopSettings.maxLightsPerClusterCell;
			int bufferSize = 131072 * (renderPipeline.asset.currentPlatformRenderPipelineSettings.lightLoopSettings.maxLightsPerClusterCell + 4);
			this.ResizeClusterBuffer(bufferSize);
			this.m_DebugMaterial = CoreUtils.CreateEngineMaterial(this.m_RenderPipelineRayTracingResources.lightClusterDebugS);
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x00065278 File Offset: 0x00063478
		public void ReleaseResources()
		{
			CoreUtils.SafeRelease(this.m_LightVolumeGPUArray);
			this.m_LightVolumeGPUArray = null;
			CoreUtils.SafeRelease(this.m_LightCluster);
			this.m_LightCluster = null;
			CoreUtils.SafeRelease(this.m_LightCullResult);
			this.m_LightCullResult = null;
			CoreUtils.SafeRelease(this.m_LightDataGPUArray);
			this.m_LightDataGPUArray = null;
			CoreUtils.SafeRelease(this.m_EnvLightDataGPUArray);
			this.m_EnvLightDataGPUArray = null;
			CoreUtils.Destroy(this.m_DebugMaterial);
			this.m_DebugMaterial = null;
		}

		// Token: 0x06000C3D RID: 3133 RVA: 0x000652F1 File Offset: 0x000634F1
		private void ResizeClusterBuffer(int bufferSize)
		{
			if (this.m_LightCluster != null)
			{
				if (this.m_LightCluster.count == bufferSize)
				{
					return;
				}
				CoreUtils.SafeRelease(this.m_LightCluster);
				this.m_LightCluster = null;
			}
			if (bufferSize > 0)
			{
				this.m_LightCluster = new ComputeBuffer(bufferSize, 4);
			}
		}

		// Token: 0x06000C3E RID: 3134 RVA: 0x0006532D File Offset: 0x0006352D
		private void ResizeCullResultBuffer(int numLights)
		{
			if (this.m_LightCullResult != null)
			{
				if (this.m_LightCullResult.count == numLights)
				{
					return;
				}
				CoreUtils.SafeRelease(this.m_LightCullResult);
				this.m_LightCullResult = null;
			}
			if (numLights > 0)
			{
				this.m_LightCullResult = new ComputeBuffer(numLights, 4);
			}
		}

		// Token: 0x06000C3F RID: 3135 RVA: 0x0006536C File Offset: 0x0006356C
		private void ResizeVolumeBuffer(int numLights)
		{
			if (this.m_LightVolumeGPUArray != null)
			{
				if (this.m_LightVolumeGPUArray.count == numLights)
				{
					return;
				}
				CoreUtils.SafeRelease(this.m_LightVolumeGPUArray);
				this.m_LightVolumeGPUArray = null;
			}
			if (numLights > 0)
			{
				this.m_LightVolumesCPUArray = new LightVolume[numLights];
				this.m_LightVolumeGPUArray = new ComputeBuffer(numLights, Marshal.SizeOf(typeof(LightVolume)));
			}
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x000653D0 File Offset: 0x000635D0
		private void ResizeLightDataBuffer(int numLights)
		{
			if (this.m_LightDataGPUArray != null)
			{
				if (this.m_LightDataGPUArray.count == numLights)
				{
					return;
				}
				CoreUtils.SafeRelease(this.m_LightDataGPUArray);
				this.m_LightDataGPUArray = null;
			}
			if (numLights > 0)
			{
				this.m_LightDataGPUArray = new ComputeBuffer(numLights, Marshal.SizeOf(typeof(LightData)));
			}
		}

		// Token: 0x06000C41 RID: 3137 RVA: 0x00065428 File Offset: 0x00063628
		private void ResizeEnvLightDataBuffer(int numEnvLights)
		{
			if (this.m_EnvLightDataGPUArray != null)
			{
				if (this.m_EnvLightDataGPUArray.count == numEnvLights)
				{
					return;
				}
				CoreUtils.SafeRelease(this.m_EnvLightDataGPUArray);
				this.m_EnvLightDataGPUArray = null;
			}
			if (numEnvLights > 0)
			{
				this.m_EnvLightDataGPUArray = new ComputeBuffer(numEnvLights, Marshal.SizeOf(typeof(EnvLightData)));
			}
		}

		// Token: 0x06000C42 RID: 3138 RVA: 0x00065480 File Offset: 0x00063680
		private void OOBBToAABBBounds(Vector3 centerWS, Vector3 extents, Vector3 up, Vector3 right, Vector3 forward, ref Bounds outBounds)
		{
			this.bounds.min = this.minBounds;
			this.bounds.max = this.maxBounds;
			this.bounds.Encapsulate(centerWS + right * extents.x + up * extents.y + forward * extents.z);
			this.bounds.Encapsulate(centerWS + right * extents.x + up * extents.y - forward * extents.z);
			this.bounds.Encapsulate(centerWS + right * extents.x - up * extents.y + forward * extents.z);
			this.bounds.Encapsulate(centerWS + right * extents.x - up * extents.y - forward * extents.z);
			this.bounds.Encapsulate(centerWS - right * extents.x + up * extents.y + forward * extents.z);
			this.bounds.Encapsulate(centerWS - right * extents.x + up * extents.y - forward * extents.z);
			this.bounds.Encapsulate(centerWS - right * extents.x - up * extents.y + forward * extents.z);
			this.bounds.Encapsulate(centerWS - right * extents.x - up * extents.y - forward * extents.z);
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x000656B8 File Offset: 0x000638B8
		private unsafe void BuildGPULightVolumes(HDCamera hdCamera, HDRayTracingLights rayTracingLights)
		{
			int lightCount = rayTracingLights.lightCount;
			if (this.m_LightVolumesCPUArray == null || lightCount != this.m_LightVolumesCPUArray.Length)
			{
				this.ResizeVolumeBuffer(lightCount);
			}
			this.punctualLightCount = 0;
			this.areaLightCount = 0;
			this.envLightCount = 0;
			this.totalLightCount = 0;
			int num = 0;
			HDLightRenderDatabase instance = HDLightRenderDatabase.instance;
			for (int i = 0; i < rayTracingLights.hdLightEntityArray.Count; i++)
			{
				int entityDataIndex = instance.GetEntityDataIndex(rayTracingLights.hdLightEntityArray[i]);
				HDAdditionalLightData hdadditionalLightData = *instance.hdAdditionalLightData[entityDataIndex];
				if (hdadditionalLightData != null)
				{
					Light component = hdadditionalLightData.gameObject.GetComponent<Light>();
					if (!(component == null))
					{
						this.m_RenderPipeline.ReserveCookieAtlasTexture(hdadditionalLightData, component, hdadditionalLightData.type);
						Vector3 vector = hdadditionalLightData.gameObject.transform.position;
						if (ShaderConfig.s_CameraRelativeRendering != 0)
						{
							vector -= hdCamera.camera.transform.position;
						}
						float range = component.range;
						this.m_LightVolumesCPUArray[num].active = (hdadditionalLightData.gameObject.activeInHierarchy ? 1 : 0);
						this.m_LightVolumesCPUArray[num].lightIndex = (uint)i;
						bool flag = hdadditionalLightData.type == HDLightType.Area;
						bool flag2 = hdadditionalLightData.type == HDLightType.Spot && hdadditionalLightData.spotLightShape == SpotLightShape.Box;
						if (!flag && !flag2)
						{
							this.m_LightVolumesCPUArray[num].range = new Vector3(range, range, range);
							this.m_LightVolumesCPUArray[num].position = vector;
							this.m_LightVolumesCPUArray[num].shape = 0;
							this.m_LightVolumesCPUArray[num].lightType = 0U;
							this.punctualLightCount++;
						}
						else
						{
							Vector3 a = new Vector3(hdadditionalLightData.shapeWidth + 2f * range, hdadditionalLightData.shapeHeight + 2f * range, range);
							Vector3 vector2 = 0.5f * a;
							Vector3 centerWS = vector + vector2.z * hdadditionalLightData.gameObject.transform.forward;
							this.OOBBToAABBBounds(centerWS, vector2, hdadditionalLightData.gameObject.transform.up, hdadditionalLightData.gameObject.transform.right, hdadditionalLightData.gameObject.transform.forward, ref this.bounds);
							this.m_LightVolumesCPUArray[num].range = this.bounds.extents;
							this.m_LightVolumesCPUArray[num].position = this.bounds.center;
							this.m_LightVolumesCPUArray[num].shape = 1;
							if (flag)
							{
								this.m_LightVolumesCPUArray[num].lightType = 1U;
								this.areaLightCount++;
							}
							else
							{
								this.m_LightVolumesCPUArray[num].lightType = 0U;
								this.punctualLightCount++;
							}
						}
						num++;
					}
				}
			}
			int num2 = num;
			for (int j = 0; j < rayTracingLights.reflectionProbeArray.Count; j++)
			{
				HDProbe hdprobe = rayTracingLights.reflectionProbeArray[j];
				if (hdprobe != null && hdprobe.enabled && hdprobe.HasValidRenderedData())
				{
					Vector3 vector3 = hdprobe.influenceToWorld.GetColumn(3);
					if (ShaderConfig.s_CameraRelativeRendering != 0)
					{
						vector3 -= hdCamera.camera.transform.position;
					}
					if (hdprobe.influenceVolume.shape == InfluenceShape.Sphere)
					{
						this.m_LightVolumesCPUArray[j + num2].shape = 0;
						this.m_LightVolumesCPUArray[j + num2].range = new Vector3(hdprobe.influenceVolume.sphereRadius, hdprobe.influenceVolume.sphereRadius, hdprobe.influenceVolume.sphereRadius);
						this.m_LightVolumesCPUArray[j + num2].position = vector3;
					}
					else
					{
						this.m_LightVolumesCPUArray[j + num2].shape = 1;
						this.m_LightVolumesCPUArray[j + num2].range = new Vector3(hdprobe.influenceVolume.boxSize.x / 2f, hdprobe.influenceVolume.boxSize.y / 2f, hdprobe.influenceVolume.boxSize.z / 2f);
						this.m_LightVolumesCPUArray[j + num2].position = vector3;
					}
					this.m_LightVolumesCPUArray[j + num2].active = (hdprobe.gameObject.activeInHierarchy ? 1 : 0);
					this.m_LightVolumesCPUArray[j + num2].lightIndex = (uint)j;
					this.m_LightVolumesCPUArray[j + num2].lightType = 2U;
					this.envLightCount++;
				}
			}
			this.totalLightCount = this.punctualLightCount + this.areaLightCount + this.envLightCount;
			this.m_LightVolumeGPUArray.SetData(this.m_LightVolumesCPUArray);
		}

		// Token: 0x06000C44 RID: 3140 RVA: 0x00065BE4 File Offset: 0x00063DE4
		private void EvaluateClusterVolume(HDCamera hdCamera)
		{
			LightCluster component = hdCamera.volumeStack.GetComponent<LightCluster>();
			if (ShaderConfig.s_CameraRelativeRendering != 0)
			{
				this.clusterCenter.Set(0f, 0f, 0f);
			}
			else
			{
				this.clusterCenter = hdCamera.camera.gameObject.transform.position;
			}
			this.minClusterPos.Set(float.MaxValue, float.MaxValue, float.MaxValue);
			this.maxClusterPos.Set(float.MinValue, float.MinValue, float.MinValue);
			for (int i = 0; i < this.totalLightCount; i++)
			{
				this.minClusterPos.x = Mathf.Min(this.m_LightVolumesCPUArray[i].position.x - this.m_LightVolumesCPUArray[i].range.x, this.minClusterPos.x);
				this.minClusterPos.y = Mathf.Min(this.m_LightVolumesCPUArray[i].position.y - this.m_LightVolumesCPUArray[i].range.y, this.minClusterPos.y);
				this.minClusterPos.z = Mathf.Min(this.m_LightVolumesCPUArray[i].position.z - this.m_LightVolumesCPUArray[i].range.z, this.minClusterPos.z);
				this.maxClusterPos.x = Mathf.Max(this.m_LightVolumesCPUArray[i].position.x + this.m_LightVolumesCPUArray[i].range.x, this.maxClusterPos.x);
				this.maxClusterPos.y = Mathf.Max(this.m_LightVolumesCPUArray[i].position.y + this.m_LightVolumesCPUArray[i].range.y, this.maxClusterPos.y);
				this.maxClusterPos.z = Mathf.Max(this.m_LightVolumesCPUArray[i].position.z + this.m_LightVolumesCPUArray[i].range.z, this.maxClusterPos.z);
			}
			this.minClusterPos.x = ((this.minClusterPos.x < this.clusterCenter.x - component.cameraClusterRange.value) ? (this.clusterCenter.x - component.cameraClusterRange.value) : this.minClusterPos.x);
			this.minClusterPos.y = ((this.minClusterPos.y < this.clusterCenter.y - component.cameraClusterRange.value) ? (this.clusterCenter.y - component.cameraClusterRange.value) : this.minClusterPos.y);
			this.minClusterPos.z = ((this.minClusterPos.z < this.clusterCenter.z - component.cameraClusterRange.value) ? (this.clusterCenter.z - component.cameraClusterRange.value) : this.minClusterPos.z);
			this.maxClusterPos.x = ((this.maxClusterPos.x > this.clusterCenter.x + component.cameraClusterRange.value) ? (this.clusterCenter.x + component.cameraClusterRange.value) : this.maxClusterPos.x);
			this.maxClusterPos.y = ((this.maxClusterPos.y > this.clusterCenter.y + component.cameraClusterRange.value) ? (this.clusterCenter.y + component.cameraClusterRange.value) : this.maxClusterPos.y);
			this.maxClusterPos.z = ((this.maxClusterPos.z > this.clusterCenter.z + component.cameraClusterRange.value) ? (this.clusterCenter.z + component.cameraClusterRange.value) : this.maxClusterPos.z);
			this.clusterCellSize = this.maxClusterPos - this.minClusterPos;
			this.clusterCellSize.x = this.clusterCellSize.x / 64f;
			this.clusterCellSize.y = this.clusterCellSize.y / 64f;
			this.clusterCellSize.z = this.clusterCellSize.z / 32f;
			this.clusterCenter = (this.maxClusterPos + this.minClusterPos) / 2f;
			this.clusterDimension = this.maxClusterPos - this.minClusterPos;
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x000660B4 File Offset: 0x000642B4
		private void CullLights(CommandBuffer cmd)
		{
			using (new ProfilingScope(cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.RaytracingCullLights)))
			{
				if (this.m_LightCullResult == null || this.m_LightCullResult.count != this.totalLightCount)
				{
					this.ResizeCullResultBuffer(this.totalLightCount);
				}
				ComputeShader lightClusterBuildCS = this.m_RenderPipelineRayTracingResources.lightClusterBuildCS;
				int kernelIndex = lightClusterBuildCS.FindKernel("RaytracingLightCull");
				cmd.SetComputeVectorParam(lightClusterBuildCS, HDRaytracingLightCluster._ClusterCenterPosition, this.clusterCenter);
				cmd.SetComputeVectorParam(lightClusterBuildCS, HDRaytracingLightCluster._ClusterDimension, this.clusterDimension);
				cmd.SetComputeFloatParam(lightClusterBuildCS, HDRaytracingLightCluster._LightVolumeCount, (float)this.totalLightCount);
				cmd.SetComputeBufferParam(lightClusterBuildCS, kernelIndex, HDRaytracingLightCluster._LightVolumes, this.m_LightVolumeGPUArray);
				cmd.SetComputeBufferParam(lightClusterBuildCS, kernelIndex, HDRaytracingLightCluster._RaytracingLightCullResult, this.m_LightCullResult);
				int threadGroupsX = this.totalLightCount / 16 + 1;
				cmd.DispatchCompute(lightClusterBuildCS, kernelIndex, threadGroupsX, 1, 1);
			}
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x000661B0 File Offset: 0x000643B0
		private void BuildLightCluster(HDCamera hdCamera, CommandBuffer cmd)
		{
			using (new ProfilingScope(cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.RaytracingBuildCluster)))
			{
				ComputeShader lightClusterBuildCS = this.m_RenderPipelineRayTracingResources.lightClusterBuildCS;
				int kernelIndex = lightClusterBuildCS.FindKernel("RaytracingLightCluster");
				cmd.SetComputeBufferParam(lightClusterBuildCS, kernelIndex, HDShaderIDs._RaytracingLightClusterRW, this.m_LightCluster);
				cmd.SetComputeVectorParam(lightClusterBuildCS, HDRaytracingLightCluster._ClusterCellSize, this.clusterCellSize);
				cmd.SetComputeBufferParam(lightClusterBuildCS, kernelIndex, HDRaytracingLightCluster._LightVolumes, this.m_LightVolumeGPUArray);
				cmd.SetComputeFloatParam(lightClusterBuildCS, HDRaytracingLightCluster._LightVolumeCount, (float)this.totalLightCount);
				cmd.SetComputeBufferParam(lightClusterBuildCS, kernelIndex, HDRaytracingLightCluster._RaytracingLightCullResult, this.m_LightCullResult);
				int threadGroupsX = 8;
				int threadGroupsY = 8;
				int threadGroupsZ = 4;
				cmd.DispatchCompute(lightClusterBuildCS, kernelIndex, threadGroupsX, threadGroupsY, threadGroupsZ);
			}
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x0006627C File Offset: 0x0006447C
		private unsafe void BuildLightData(CommandBuffer cmd, HDCamera hdCamera, HDRayTracingLights rayTracingLights, DebugDisplaySettings debugDisplaySettings)
		{
			if (rayTracingLights.lightCount == 0)
			{
				this.ResizeLightDataBuffer(1);
				return;
			}
			if (this.m_LightDataGPUArray == null || this.m_LightDataGPUArray.count != rayTracingLights.lightCount)
			{
				this.ResizeLightDataBuffer(rayTracingLights.lightCount);
			}
			this.m_LightDataCPUArray.Clear();
			HDShadowSettings component = hdCamera.volumeStack.GetComponent<HDShadowSettings>();
			HDAdditionalLightData.ScalableSettings.UseContactShadow(this.m_RenderPipeline.asset);
			HDLightRenderDatabase instance = HDLightRenderDatabase.instance;
			HDProcessedVisibleLight hdprocessedVisibleLight = new HDProcessedVisibleLight
			{
				shadowMapFlags = HDProcessedVisibleLightsBuilder.ShadowMapFlags.None
			};
			HDGpuLightsBuilder.CreateGpuLightDataJobGlobalConfig createGpuLightDataJobGlobalConfig = HDGpuLightsBuilder.CreateGpuLightDataJobGlobalConfig.Create(hdCamera, component);
			HDShadowInitParameters hdShadowInitParams = this.m_RenderPipeline.currentPlatformRenderPipelineSettings.hdShadowInitParams;
			for (int i = 0; i < rayTracingLights.hdLightEntityArray.Count; i++)
			{
				int entityDataIndex = instance.GetEntityDataIndex(rayTracingLights.hdLightEntityArray[i]);
				HDAdditionalLightData hdadditionalLightData = *instance.hdAdditionalLightData[entityDataIndex];
				LightData item = default(LightData);
				if (hdadditionalLightData == null)
				{
					this.m_LightDataCPUArray.Add(item);
				}
				else
				{
					LightCategory lightCategory = LightCategory.Count;
					GPULightType gpulightType = GPULightType.Point;
					LightVolumeType lightVolumeType = LightVolumeType.Count;
					HDLightType type = hdadditionalLightData.type;
					HDRenderPipeline.EvaluateGPULightType(type, hdadditionalLightData.spotLightShape, hdadditionalLightData.areaLightShape, ref lightCategory, ref gpulightType, ref lightVolumeType);
					hdadditionalLightData.gameObject.TryGetComponent<Light>(out this.lightComponent);
					ref HDLightRenderData lightDataAsRef = ref instance.GetLightDataAsRef(entityDataIndex);
					hdprocessedVisibleLight.dataIndex = entityDataIndex;
					hdprocessedVisibleLight.gpuLightType = gpulightType;
					hdprocessedVisibleLight.lightType = hdadditionalLightData.type;
					Vector3 vector = hdadditionalLightData.transform.position - hdCamera.camera.transform.position;
					hdprocessedVisibleLight.distanceToCamera = vector.magnitude;
					hdprocessedVisibleLight.lightDistanceFade = HDUtils.ComputeLinearDistanceFade(hdprocessedVisibleLight.distanceToCamera, lightDataAsRef.fadeDistance);
					hdprocessedVisibleLight.lightVolumetricDistanceFade = HDUtils.ComputeLinearDistanceFade(hdprocessedVisibleLight.distanceToCamera, lightDataAsRef.volumetricFadeDistance);
					hdprocessedVisibleLight.isBakedShadowMask = HDRenderPipeline.IsBakedShadowMaskLight(this.lightComponent);
					this.visibleLight.finalColor = LightUtils.EvaluateLightColor(this.lightComponent, hdadditionalLightData);
					this.visibleLight.range = this.lightComponent.range;
					this.localToWorldMatrix.SetColumn(3, this.lightComponent.gameObject.transform.position);
					this.localToWorldMatrix.SetColumn(2, this.lightComponent.transform.forward);
					this.localToWorldMatrix.SetColumn(1, this.lightComponent.transform.up);
					this.localToWorldMatrix.SetColumn(0, this.lightComponent.transform.right);
					this.visibleLight.localToWorldMatrix = this.localToWorldMatrix;
					this.visibleLight.spotAngle = this.lightComponent.spotAngle;
					int shadowIndex = hdadditionalLightData.shadowIndex;
					new Vector3(0f, 0f, 0f);
					LightCategory lightCategory2 = lightCategory;
					GPULightType gpuLightType = gpulightType;
					LightShadowCasterMode lightShadowCasterMode = this.lightComponent.lightShadowCasterMode;
					LightBakingOutput bakingOutput = this.lightComponent.bakingOutput;
					HDGpuLightsBuilder.CreateGpuLightDataJob.ConvertLightToGPUFormat(lightCategory2, gpuLightType, createGpuLightDataJobGlobalConfig, lightShadowCasterMode, bakingOutput, this.visibleLight, hdprocessedVisibleLight, lightDataAsRef, out vector, ref item);
					this.m_RenderPipeline.gpuLightList.ProcessLightDataShadowIndex(cmd, hdShadowInitParams, type, this.lightComponent, hdadditionalLightData, shadowIndex, ref item);
					Vector3 worldSpaceCameraPos = hdCamera.mainViewConstants.worldSpaceCameraPos;
					HDRenderPipeline.UpdateLightCameraRelativetData(ref item, worldSpaceCameraPos);
					this.m_LightDataCPUArray.Add(item);
				}
			}
			this.m_LightDataGPUArray.SetData<LightData>(this.m_LightDataCPUArray);
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x000665E8 File Offset: 0x000647E8
		private unsafe void SetPlanarReflectionDataRT(int index, ref Matrix4x4 vp, ref Vector4 scaleOffset)
		{
			for (int i = 0; i < 16; i++)
			{
				*(ref this.m_EnvLightReflectionDataRT._PlanarCaptureVPRT.FixedElementField + (IntPtr)(index * 16 + i) * 4) = vp[i];
			}
			for (int j = 0; j < 4; j++)
			{
				*(ref this.m_EnvLightReflectionDataRT._PlanarScaleOffsetRT.FixedElementField + (IntPtr)(index * 4 + j) * 4) = scaleOffset[j];
			}
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x00066654 File Offset: 0x00064854
		private unsafe void SetCubeReflectionDataRT(int index, ref Vector4 scaleOffset)
		{
			for (int i = 0; i < 4; i++)
			{
				*(ref this.m_EnvLightReflectionDataRT._CubeScaleOffsetRT.FixedElementField + (IntPtr)(index * 4 + i) * 4) = scaleOffset[i];
			}
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x00066690 File Offset: 0x00064890
		private void BuildEnvLightData(CommandBuffer cmd, HDCamera hdCamera, HDRayTracingLights lights)
		{
			int count = lights.reflectionProbeArray.Count;
			if (count == 0)
			{
				this.ResizeEnvLightDataBuffer(1);
				return;
			}
			if (this.m_EnvLightDataCPUArray == null || this.m_EnvLightDataGPUArray == null || this.m_EnvLightDataGPUArray.count != count)
			{
				this.ResizeEnvLightDataBuffer(count);
			}
			this.m_EnvLightDataCPUArray.Clear();
			ProcessedProbeData processedProbeData = default(ProcessedProbeData);
			EnvLightData item = default(EnvLightData);
			for (int i = 0; i < lights.reflectionProbeArray.Count; i++)
			{
				HDProbe probe = lights.reflectionProbeArray[i];
				HDRenderPipeline.PreprocessProbeData(ref processedProbeData, probe, hdCamera);
				int index;
				Vector4 vector;
				Matrix4x4 matrix4x;
				this.m_RenderPipeline.GetEnvLightData(cmd, hdCamera, processedProbeData, ref item, out index, out vector, out matrix4x);
				HDProbe hdProbe = processedProbeData.hdProbe;
				if (!(hdProbe is PlanarReflectionProbe))
				{
					if (hdProbe is HDAdditionalReflectionData)
					{
						this.SetCubeReflectionDataRT(index, ref vector);
					}
				}
				else
				{
					this.SetPlanarReflectionDataRT(index, ref matrix4x, ref vector);
				}
				Vector3 worldSpaceCameraPos = hdCamera.mainViewConstants.worldSpaceCameraPos;
				HDRenderPipeline.UpdateEnvLighCameraRelativetData(ref item, worldSpaceCameraPos);
				this.m_EnvLightDataCPUArray.Add(item);
			}
			this.m_EnvLightDataGPUArray.SetData<EnvLightData>(this.m_EnvLightDataCPUArray);
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x000667AC File Offset: 0x000649AC
		public void EvaluateClusterDebugView(RenderGraph renderGraph, HDCamera hdCamera, TextureHandle depthStencilBuffer, TextureHandle depthPyramid)
		{
			if (FullScreenDebugMode.LightCluster != this.m_RenderPipeline.m_CurrentDebugDisplaySettings.data.fullScreenDebugMode)
			{
				return;
			}
			HDRaytracingLightCluster.LightClusterDebugPassData lightClusterDebugPassData;
			TextureHandle outputBuffer;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<HDRaytracingLightCluster.LightClusterDebugPassData>("Debug Texture for the Light Cluster", out lightClusterDebugPassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.RaytracingDebugCluster)))
			{
				renderGraphBuilder.EnableAsyncCompute(false);
				lightClusterDebugPassData.texWidth = hdCamera.actualWidth;
				lightClusterDebugPassData.texHeight = hdCamera.actualHeight;
				lightClusterDebugPassData.clusterCellSize = this.clusterCellSize;
				HDRaytracingLightCluster.LightClusterDebugPassData lightClusterDebugPassData2 = lightClusterDebugPassData;
				ComputeBufferHandle computeBufferHandle = renderGraph.ImportComputeBuffer(this.m_LightCluster);
				lightClusterDebugPassData2.lightCluster = renderGraphBuilder.ReadComputeBuffer(computeBufferHandle);
				lightClusterDebugPassData.lightClusterDebugCS = this.m_RenderPipelineRayTracingResources.lightClusterDebugCS;
				lightClusterDebugPassData.lightClusterDebugKernel = lightClusterDebugPassData.lightClusterDebugCS.FindKernel("DebugLightCluster");
				lightClusterDebugPassData.debugMaterial = this.m_DebugMaterial;
				lightClusterDebugPassData.depthStencilBuffer = renderGraphBuilder.UseDepthBuffer(depthStencilBuffer, DepthAccess.Read);
				lightClusterDebugPassData.depthPyramid = renderGraphBuilder.ReadTexture(depthStencilBuffer);
				HDRaytracingLightCluster.LightClusterDebugPassData lightClusterDebugPassData3 = lightClusterDebugPassData;
				TextureDesc textureDesc = new TextureDesc(Vector2.one, true, true);
				textureDesc.colorFormat = GraphicsFormat.R16G16B16A16_SFloat;
				textureDesc.enableRandomWrite = true;
				textureDesc.name = "Light Cluster Debug Texture";
				TextureHandle textureHandle = renderGraph.CreateTexture(textureDesc);
				lightClusterDebugPassData3.outputBuffer = renderGraphBuilder.WriteTexture(textureHandle);
				renderGraphBuilder.SetRenderFunc<HDRaytracingLightCluster.LightClusterDebugPassData>(delegate(HDRaytracingLightCluster.LightClusterDebugPassData data, RenderGraphContext ctx)
				{
					MaterialPropertyBlock tempMaterialPropertyBlock = ctx.renderGraphPool.GetTempMaterialPropertyBlock();
					CoreUtils.SetRenderTarget(ctx.cmd, data.outputBuffer, data.depthStencilBuffer, ClearFlag.Color, Color.black, 0, CubemapFace.Unknown, -1);
					ctx.cmd.SetComputeBufferParam(data.lightClusterDebugCS, data.lightClusterDebugKernel, HDShaderIDs._RaytracingLightCluster, data.lightCluster);
					ctx.cmd.SetComputeVectorParam(data.lightClusterDebugCS, HDRaytracingLightCluster._ClusterCellSize, data.clusterCellSize);
					ctx.cmd.SetComputeTextureParam(data.lightClusterDebugCS, data.lightClusterDebugKernel, HDShaderIDs._CameraDepthTexture, data.depthStencilBuffer);
					ctx.cmd.SetComputeTextureParam(data.lightClusterDebugCS, data.lightClusterDebugKernel, HDRaytracingLightCluster._DebutLightClusterTexture, data.outputBuffer);
					int num = 8;
					int threadGroupsX = (data.texWidth + (num - 1)) / num;
					int threadGroupsY = (data.texHeight + (num - 1)) / num;
					ctx.cmd.DispatchCompute(data.lightClusterDebugCS, data.lightClusterDebugKernel, threadGroupsX, threadGroupsY, 1);
					tempMaterialPropertyBlock.SetBuffer(HDShaderIDs._RaytracingLightCluster, data.lightCluster);
					tempMaterialPropertyBlock.SetVector(HDRaytracingLightCluster._ClusterCellSize, data.clusterCellSize);
					tempMaterialPropertyBlock.SetTexture(HDShaderIDs._CameraDepthTexture, data.depthPyramid);
					ctx.cmd.DrawProcedural(Matrix4x4.identity, data.debugMaterial, 1, MeshTopology.Lines, 48, 131072, tempMaterialPropertyBlock);
					ctx.cmd.DrawProcedural(Matrix4x4.identity, data.debugMaterial, 0, MeshTopology.Triangles, 36, 131072, tempMaterialPropertyBlock);
				});
				outputBuffer = lightClusterDebugPassData.outputBuffer;
			}
			this.m_RenderPipeline.PushFullScreenDebugTexture(renderGraph, outputBuffer, FullScreenDebugMode.LightCluster, GraphicsFormat.R16G16B16A16_SFloat, true);
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x00066934 File Offset: 0x00064B34
		public ComputeBuffer GetCluster()
		{
			return this.m_LightCluster;
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x0006693C File Offset: 0x00064B3C
		public ComputeBuffer GetLightDatas()
		{
			return this.m_LightDataGPUArray;
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x00066944 File Offset: 0x00064B44
		public ComputeBuffer GetEnvLightDatas()
		{
			return this.m_EnvLightDataGPUArray;
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x0006694C File Offset: 0x00064B4C
		public Vector3 GetMinClusterPos()
		{
			return this.minClusterPos;
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x00066954 File Offset: 0x00064B54
		public Vector3 GetMaxClusterPos()
		{
			return this.maxClusterPos;
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x0006695C File Offset: 0x00064B5C
		public Vector3 GetClusterCellSize()
		{
			return this.clusterCellSize;
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x00066964 File Offset: 0x00064B64
		public int GetPunctualLightCount()
		{
			return this.punctualLightCount;
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x0006696C File Offset: 0x00064B6C
		public int GetAreaLightCount()
		{
			return this.areaLightCount;
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x00066974 File Offset: 0x00064B74
		public int GetEnvLightCount()
		{
			return this.envLightCount;
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x0006697C File Offset: 0x00064B7C
		public int GetLightPerCellCount()
		{
			return this.m_NumLightsPerCell;
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x00066984 File Offset: 0x00064B84
		private void InvalidateCluster()
		{
			this.minClusterPos.Set(float.MaxValue, float.MaxValue, float.MaxValue);
			this.maxClusterPos.Set(float.MinValue, float.MinValue, float.MinValue);
			this.punctualLightCount = 0;
			this.areaLightCount = 0;
			this.envLightCount = 0;
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x000669DA File Offset: 0x00064BDA
		public void CullForRayTracing(HDCamera hdCamera, HDRayTracingLights rayTracingLights)
		{
			if (rayTracingLights.lightCount == 0 || !this.m_RenderPipeline.GetRayTracingState())
			{
				this.InvalidateCluster();
				return;
			}
			this.BuildGPULightVolumes(hdCamera, rayTracingLights);
			if (this.totalLightCount == 0)
			{
				this.InvalidateCluster();
				return;
			}
			this.EvaluateClusterVolume(hdCamera);
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x00066A16 File Offset: 0x00064C16
		public void BuildLightClusterBuffer(CommandBuffer cmd, HDCamera hdCamera, HDRayTracingLights rayTracingLights)
		{
			if (this.totalLightCount == 0 || rayTracingLights.lightCount == 0 || !this.m_RenderPipeline.GetRayTracingState())
			{
				return;
			}
			this.CullLights(cmd);
			this.BuildLightCluster(hdCamera, cmd);
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x00066A48 File Offset: 0x00064C48
		public unsafe void ReserveCookieAtlasSlots(HDRayTracingLights rayTracingLights)
		{
			HDLightRenderDatabase instance = HDLightRenderDatabase.instance;
			for (int i = 0; i < rayTracingLights.hdLightEntityArray.Count; i++)
			{
				int entityDataIndex = instance.GetEntityDataIndex(rayTracingLights.hdLightEntityArray[i]);
				HDAdditionalLightData hdadditionalLightData = *instance.hdAdditionalLightData[entityDataIndex];
				hdadditionalLightData.gameObject.TryGetComponent<Light>(out this.lightComponent);
				this.m_RenderPipeline.ReserveCookieAtlasTexture(hdadditionalLightData, this.lightComponent, hdadditionalLightData.type);
			}
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x00066ABC File Offset: 0x00064CBC
		public void BuildRayTracingLightData(CommandBuffer cmd, HDCamera hdCamera, HDRayTracingLights rayTracingLights, DebugDisplaySettings debugDisplaySettings)
		{
			this.BuildLightData(cmd, hdCamera, rayTracingLights, debugDisplaySettings);
			this.BuildEnvLightData(cmd, hdCamera, rayTracingLights);
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x00066AD4 File Offset: 0x00064CD4
		public void BindLightClusterData(CommandBuffer cmd)
		{
			ConstantBuffer.PushGlobal<EnvLightReflectionDataRT>(cmd, this.m_EnvLightReflectionDataRT, HDShaderIDs._EnvLightReflectionDataRT);
			cmd.SetGlobalBuffer(HDShaderIDs._RaytracingLightCluster, this.GetCluster());
			cmd.SetGlobalBuffer(HDShaderIDs._LightDatasRT, this.GetLightDatas());
			cmd.SetGlobalBuffer(HDShaderIDs._EnvLightDatasRT, this.GetEnvLightDatas());
		}

		// Token: 0x040012E5 RID: 4837
		private HDRenderPipelineRuntimeResources m_RenderPipelineResources;

		// Token: 0x040012E6 RID: 4838
		private HDRenderPipelineRayTracingResources m_RenderPipelineRayTracingResources;

		// Token: 0x040012E7 RID: 4839
		private HDRenderPipeline m_RenderPipeline;

		// Token: 0x040012E8 RID: 4840
		private LightVolume[] m_LightVolumesCPUArray;

		// Token: 0x040012E9 RID: 4841
		private ComputeBuffer m_LightVolumeGPUArray;

		// Token: 0x040012EA RID: 4842
		private ComputeBuffer m_LightCullResult;

		// Token: 0x040012EB RID: 4843
		private ComputeBuffer m_LightCluster;

		// Token: 0x040012EC RID: 4844
		private List<LightData> m_LightDataCPUArray = new List<LightData>();

		// Token: 0x040012ED RID: 4845
		private ComputeBuffer m_LightDataGPUArray;

		// Token: 0x040012EE RID: 4846
		private List<EnvLightData> m_EnvLightDataCPUArray = new List<EnvLightData>();

		// Token: 0x040012EF RID: 4847
		private ComputeBuffer m_EnvLightDataGPUArray;

		// Token: 0x040012F0 RID: 4848
		private Material m_DebugMaterial;

		// Token: 0x040012F1 RID: 4849
		private const string m_LightClusterKernelName = "RaytracingLightCluster";

		// Token: 0x040012F2 RID: 4850
		private const string m_LightCullKernelName = "RaytracingLightCull";

		// Token: 0x040012F3 RID: 4851
		public static readonly int _ClusterCellSize = Shader.PropertyToID("_ClusterCellSize");

		// Token: 0x040012F4 RID: 4852
		public static readonly int _LightVolumes = Shader.PropertyToID("_LightVolumes");

		// Token: 0x040012F5 RID: 4853
		public static readonly int _LightVolumeCount = Shader.PropertyToID("_LightVolumeCount");

		// Token: 0x040012F6 RID: 4854
		public static readonly int _DebugColorGradientTexture = Shader.PropertyToID("_DebugColorGradientTexture");

		// Token: 0x040012F7 RID: 4855
		public static readonly int _DebutLightClusterTexture = Shader.PropertyToID("_DebutLightClusterTexture");

		// Token: 0x040012F8 RID: 4856
		public static readonly int _RaytracingLightCullResult = Shader.PropertyToID("_RaytracingLightCullResult");

		// Token: 0x040012F9 RID: 4857
		public static readonly int _ClusterCenterPosition = Shader.PropertyToID("_ClusterCenterPosition");

		// Token: 0x040012FA RID: 4858
		public static readonly int _ClusterDimension = Shader.PropertyToID("_ClusterDimension");

		// Token: 0x040012FB RID: 4859
		private int m_NumLightsPerCell;

		// Token: 0x040012FC RID: 4860
		private Vector3 minClusterPos = new Vector3(0f, 0f, 0f);

		// Token: 0x040012FD RID: 4861
		private Vector3 maxClusterPos = new Vector3(0f, 0f, 0f);

		// Token: 0x040012FE RID: 4862
		private Vector3 clusterCellSize = new Vector3(0f, 0f, 0f);

		// Token: 0x040012FF RID: 4863
		private Vector3 clusterCenter = new Vector3(0f, 0f, 0f);

		// Token: 0x04001300 RID: 4864
		private Vector3 clusterDimension = new Vector3(0f, 0f, 0f);

		// Token: 0x04001301 RID: 4865
		private int punctualLightCount;

		// Token: 0x04001302 RID: 4866
		private int areaLightCount;

		// Token: 0x04001303 RID: 4867
		private int envLightCount;

		// Token: 0x04001304 RID: 4868
		private int totalLightCount;

		// Token: 0x04001305 RID: 4869
		private Bounds bounds;

		// Token: 0x04001306 RID: 4870
		private Vector3 minBounds = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);

		// Token: 0x04001307 RID: 4871
		private Vector3 maxBounds = new Vector3(float.MinValue, float.MinValue, float.MinValue);

		// Token: 0x04001308 RID: 4872
		private Matrix4x4 localToWorldMatrix;

		// Token: 0x04001309 RID: 4873
		private VisibleLight visibleLight;

		// Token: 0x0400130A RID: 4874
		private Light lightComponent;

		// Token: 0x0400130B RID: 4875
		internal const int k_MaxPlanarReflectionsOnScreen = 16;

		// Token: 0x0400130C RID: 4876
		internal const int k_MaxCubeReflectionsOnScreen = 64;

		// Token: 0x0400130D RID: 4877
		private EnvLightReflectionDataRT m_EnvLightReflectionDataRT;

		// Token: 0x020003D0 RID: 976
		private class LightClusterDebugPassData
		{
			// Token: 0x040027AA RID: 10154
			public int texWidth;

			// Token: 0x040027AB RID: 10155
			public int texHeight;

			// Token: 0x040027AC RID: 10156
			public int lightClusterDebugKernel;

			// Token: 0x040027AD RID: 10157
			public Vector3 clusterCellSize;

			// Token: 0x040027AE RID: 10158
			public Material debugMaterial;

			// Token: 0x040027AF RID: 10159
			public ComputeBufferHandle lightCluster;

			// Token: 0x040027B0 RID: 10160
			public ComputeShader lightClusterDebugCS;

			// Token: 0x040027B1 RID: 10161
			public TextureHandle depthStencilBuffer;

			// Token: 0x040027B2 RID: 10162
			public TextureHandle depthPyramid;

			// Token: 0x040027B3 RID: 10163
			public TextureHandle outputBuffer;
		}
	}
}
