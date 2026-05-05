using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.Rendering.RenderGraphModule;
using UnityEngine.NVIDIA;
using UnityEngine.Rendering.HighDefinition.Attributes;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000038 RID: 56
	public class DebugDisplaySettings : IDebugData
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000095 RID: 149 RVA: 0x0000608C File Offset: 0x0000428C
		internal DebugView nvidiaDebugView { get; } = new DebugView();

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00006094 File Offset: 0x00004294
		public DebugDisplaySettings.DebugData data
		{
			get
			{
				return this.m_Data;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000097 RID: 151 RVA: 0x0000609C File Offset: 0x0000429C
		public static GUIContent[] renderingFullScreenDebugStrings
		{
			get
			{
				return DebugDisplaySettings.s_RenderingFullScreenDebugStrings;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000098 RID: 152 RVA: 0x000060A3 File Offset: 0x000042A3
		public static int[] renderingFullScreenDebugValues
		{
			get
			{
				return DebugDisplaySettings.s_RenderingFullScreenDebugValues;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000099 RID: 153 RVA: 0x000060AA File Offset: 0x000042AA
		public static GUIContent[] lightingFullScreenDebugStrings
		{
			get
			{
				return DebugDisplaySettings.s_LightingFullScreenDebugStrings;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600009A RID: 154 RVA: 0x000060B1 File Offset: 0x000042B1
		public static int[] lightingFullScreenDebugValues
		{
			get
			{
				return DebugDisplaySettings.s_LightingFullScreenDebugValues;
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000060B8 File Offset: 0x000042B8
		internal DebugDisplaySettings()
		{
			this.FillFullScreenDebugEnum(ref DebugDisplaySettings.s_LightingFullScreenDebugStrings, ref DebugDisplaySettings.s_LightingFullScreenDebugValues, FullScreenDebugMode.MinLightingFullScreenDebug, FullScreenDebugMode.MaxLightingFullScreenDebug);
			this.FillFullScreenDebugEnum(ref DebugDisplaySettings.s_RenderingFullScreenDebugStrings, ref DebugDisplaySettings.s_RenderingFullScreenDebugValues, FullScreenDebugMode.MinRenderingFullScreenDebug, FullScreenDebugMode.MaxRenderingFullScreenDebug);
			this.FillFullScreenDebugEnum(ref DebugDisplaySettings.s_MaterialFullScreenDebugStrings, ref DebugDisplaySettings.s_MaterialFullScreenDebugValues, FullScreenDebugMode.MinMaterialFullScreenDebug, FullScreenDebugMode.MaxMaterialFullScreenDebug);
			GraphicsDeviceType graphicsDeviceType = SystemInfo.graphicsDeviceType;
			if (graphicsDeviceType == GraphicsDeviceType.Metal || graphicsDeviceType == GraphicsDeviceType.PlayStation4 || graphicsDeviceType == GraphicsDeviceType.PlayStation5 || graphicsDeviceType == GraphicsDeviceType.PlayStation5NGGC)
			{
				DebugDisplaySettings.s_RenderingFullScreenDebugStrings = DebugDisplaySettings.s_RenderingFullScreenDebugStrings.Where((GUIContent val, int idx) => idx + 22 != 31).ToArray<GUIContent>();
				DebugDisplaySettings.s_RenderingFullScreenDebugValues = DebugDisplaySettings.s_RenderingFullScreenDebugValues.Where((int val, int idx) => idx + 22 != 31).ToArray<int>();
				DebugDisplaySettings.s_RenderingFullScreenDebugStrings = DebugDisplaySettings.s_RenderingFullScreenDebugStrings.Where((GUIContent val, int idx) => idx + 22 != 29).ToArray<GUIContent>();
				DebugDisplaySettings.s_RenderingFullScreenDebugValues = DebugDisplaySettings.s_RenderingFullScreenDebugValues.Where((int val, int idx) => idx + 22 != 29).ToArray<int>();
			}
			DebugDisplaySettings.s_MaterialFullScreenDebugStrings[1] = new GUIContent("Diffuse Color");
			DebugDisplaySettings.s_MaterialFullScreenDebugStrings[2] = new GUIContent("Metal or SpecularColor");
			this.m_Data = new DebugDisplaySettings.DebugData();
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00006269 File Offset: 0x00004469
		Action IDebugData.GetReset()
		{
			return delegate()
			{
				this.m_Data = new DebugDisplaySettings.DebugData();
			};
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00006277 File Offset: 0x00004477
		internal float[] GetDebugMaterialIndexes()
		{
			return this.data.materialDebugSettings.GetDebugMaterialIndexes();
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00006289 File Offset: 0x00004489
		public DebugLightFilterMode GetDebugLightFilterMode()
		{
			return this.data.lightingDebugSettings.debugLightFilterMode;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000629B File Offset: 0x0000449B
		public DebugLightingMode GetDebugLightingMode()
		{
			return this.data.lightingDebugSettings.debugLightingMode;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000062B0 File Offset: 0x000044B0
		public DebugLightLayersMask GetDebugLightLayersMask()
		{
			LightingDebugSettings lightingDebugSettings = this.data.lightingDebugSettings;
			if (!lightingDebugSettings.debugLightLayers)
			{
				return DebugLightLayersMask.None;
			}
			return lightingDebugSettings.debugLightLayersFilterMask;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000062D9 File Offset: 0x000044D9
		public ShadowMapDebugMode GetDebugShadowMapMode()
		{
			return this.data.lightingDebugSettings.shadowDebugMode;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000062EB File Offset: 0x000044EB
		public DebugMipMapMode GetDebugMipMapMode()
		{
			return this.data.mipMapDebugSettings.debugMipMapMode;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000062FD File Offset: 0x000044FD
		public DebugMipMapModeTerrainTexture GetDebugMipMapModeTerrainTexture()
		{
			return this.data.mipMapDebugSettings.terrainTexture;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000630F File Offset: 0x0000450F
		public ColorPickerDebugMode GetDebugColorPickerMode()
		{
			return this.data.colorPickerDebugSettings.colorPickerMode;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00006321 File Offset: 0x00004521
		public bool IsCameraFreezeEnabled()
		{
			return this.data.debugCameraToFreeze != 0;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00006331 File Offset: 0x00004531
		public bool IsCameraFrozen(Camera camera)
		{
			return this.IsCameraFreezeEnabled() && camera.name.Equals(DebugDisplaySettings.s_CameraNamesStrings[this.data.debugCameraToFreeze].text);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000635E File Offset: 0x0000455E
		public bool IsDebugDisplayEnabled()
		{
			return this.data.materialDebugSettings.IsDebugDisplayEnabled() || this.data.lightingDebugSettings.IsDebugDisplayEnabled() || this.data.mipMapDebugSettings.IsDebugDisplayEnabled() || this.IsDebugFullScreenEnabled();
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000639E File Offset: 0x0000459E
		public bool IsDebugMaterialDisplayEnabled()
		{
			return this.data.materialDebugSettings.IsDebugDisplayEnabled();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000063B0 File Offset: 0x000045B0
		public bool IsDebugFullScreenEnabled()
		{
			return this.data.fullScreenDebugMode > FullScreenDebugMode.None;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000063C0 File Offset: 0x000045C0
		internal bool IsFullScreenDebugPassEnabled()
		{
			return this.data.fullScreenDebugMode == FullScreenDebugMode.QuadOverdraw || this.data.fullScreenDebugMode == FullScreenDebugMode.VertexDensity;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000063E2 File Offset: 0x000045E2
		public bool IsDebugExposureModeEnabled()
		{
			return this.data.lightingDebugSettings.exposureDebugMode > ExposureDebugMode.None;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000063F7 File Offset: 0x000045F7
		public bool IsHDRDebugModeEnabled()
		{
			return this.data.lightingDebugSettings.hdrDebugMode > HDRDebugMode.None;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000640C File Offset: 0x0000460C
		public bool IsMaterialValidationEnabled()
		{
			return this.data.fullScreenDebugMode == FullScreenDebugMode.ValidateDiffuseColor || this.data.fullScreenDebugMode == FullScreenDebugMode.ValidateSpecularColor;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000642E File Offset: 0x0000462E
		public bool IsDebugMipMapDisplayEnabled()
		{
			return this.data.mipMapDebugSettings.IsDebugDisplayEnabled();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00006440 File Offset: 0x00004640
		public bool IsMatcapViewEnabled(HDCamera camera)
		{
			return CoreUtils.IsSceneLightingDisabled(camera.camera) || this.GetDebugLightingMode() == DebugLightingMode.MatcapView;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000645C File Offset: 0x0000465C
		private void DisableNonMaterialDebugSettings()
		{
			this.data.fullScreenDebugMode = FullScreenDebugMode.None;
			this.data.lightingDebugSettings.debugLightingMode = DebugLightingMode.None;
			this.data.mipMapDebugSettings.debugMipMapMode = DebugMipMapMode.None;
			this.data.lightingDebugSettings.debugLightLayers = false;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000064A8 File Offset: 0x000046A8
		public void SetDebugViewCommonMaterialProperty(MaterialSharedProperty value)
		{
			if (value != MaterialSharedProperty.None)
			{
				this.DisableNonMaterialDebugSettings();
			}
			this.data.materialDebugSettings.SetDebugViewCommonMaterialProperty(value);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000064C4 File Offset: 0x000046C4
		public void SetDebugViewMaterial(int value)
		{
			if (value != 0)
			{
				this.DisableNonMaterialDebugSettings();
			}
			this.data.materialDebugSettings.SetDebugViewMaterial(value);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000064E0 File Offset: 0x000046E0
		public void SetDebugViewEngine(int value)
		{
			if (value != 0)
			{
				this.DisableNonMaterialDebugSettings();
			}
			this.data.materialDebugSettings.SetDebugViewEngine(value);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000064FC File Offset: 0x000046FC
		public void SetDebugViewVarying(DebugViewVarying value)
		{
			if (value != DebugViewVarying.None)
			{
				this.DisableNonMaterialDebugSettings();
			}
			this.data.materialDebugSettings.SetDebugViewVarying(value);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00006518 File Offset: 0x00004718
		public void SetDebugViewProperties(DebugViewProperties value)
		{
			if (value != DebugViewProperties.None)
			{
				this.DisableNonMaterialDebugSettings();
			}
			this.data.materialDebugSettings.SetDebugViewProperties(value);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00006534 File Offset: 0x00004734
		public void SetDebugViewGBuffer(int value)
		{
			if (value != 0)
			{
				this.DisableNonMaterialDebugSettings();
			}
			this.data.materialDebugSettings.SetDebugViewGBuffer(value);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00006550 File Offset: 0x00004750
		public void SetFullScreenDebugMode(FullScreenDebugMode value)
		{
			if (this.data.lightingDebugSettings.shadowDebugMode == ShadowMapDebugMode.SingleShadow)
			{
				value = FullScreenDebugMode.None;
			}
			if (value != FullScreenDebugMode.None)
			{
				this.data.lightingDebugSettings.debugLightingMode = DebugLightingMode.None;
				this.data.lightingDebugSettings.debugLightLayers = false;
				this.data.materialDebugSettings.DisableMaterialDebug();
				this.data.mipMapDebugSettings.debugMipMapMode = DebugMipMapMode.None;
			}
			this.data.fullScreenDebugMode = value;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000065C5 File Offset: 0x000047C5
		public void SetRTASDebugView(RTASDebugView value)
		{
			this.data.rtasDebugView = value;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000065D3 File Offset: 0x000047D3
		public void SetRTASDebugMode(RTASDebugMode value)
		{
			this.data.rtasDebugMode = value;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000065E1 File Offset: 0x000047E1
		public void SetShadowDebugMode(ShadowMapDebugMode value)
		{
			if (value == ShadowMapDebugMode.SingleShadow)
			{
				this.data.fullScreenDebugMode = FullScreenDebugMode.None;
			}
			this.data.lightingDebugSettings.shadowDebugMode = value;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00006604 File Offset: 0x00004804
		public void SetDebugLightFilterMode(DebugLightFilterMode value)
		{
			if (value != DebugLightFilterMode.None)
			{
				this.data.materialDebugSettings.DisableMaterialDebug();
				this.data.mipMapDebugSettings.debugMipMapMode = DebugMipMapMode.None;
				this.data.lightingDebugSettings.debugLightLayers = false;
			}
			this.data.lightingDebugSettings.debugLightFilterMode = value;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00006658 File Offset: 0x00004858
		public void SetDebugLightLayersMode(bool value)
		{
			if (value)
			{
				this.data.ResetExclusiveEnumIndices();
				this.data.lightingDebugSettings.debugLightFilterMode = DebugLightFilterMode.None;
				Type typeFromHandle = typeof(Builtin.BuiltinData);
				GenerateHLSL generateHLSL = typeFromHandle.GetCustomAttributes(true)[0] as GenerateHLSL;
				int num = Array.IndexOf<FieldInfo>(typeFromHandle.GetFields(), typeFromHandle.GetField("renderingLayers"));
				this.SetDebugViewMaterial(generateHLSL.paramDefinesStart + num);
			}
			else
			{
				this.SetDebugViewMaterial(0);
			}
			this.data.lightingDebugSettings.debugLightLayers = value;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000066E0 File Offset: 0x000048E0
		public void SetDebugLightingMode(DebugLightingMode value)
		{
			if (value != DebugLightingMode.None)
			{
				this.data.fullScreenDebugMode = FullScreenDebugMode.None;
				this.data.materialDebugSettings.DisableMaterialDebug();
				this.data.mipMapDebugSettings.debugMipMapMode = DebugMipMapMode.None;
				this.data.lightingDebugSettings.debugLightLayers = false;
			}
			this.data.lightingDebugSettings.debugLightingMode = value;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000673F File Offset: 0x0000493F
		internal void SetExposureDebugMode(ExposureDebugMode value)
		{
			this.data.lightingDebugSettings.exposureDebugMode = value;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00006752 File Offset: 0x00004952
		internal void SetHDRDebugMode(HDRDebugMode value)
		{
			this.data.lightingDebugSettings.hdrDebugMode = value;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00006768 File Offset: 0x00004968
		public void SetMipMapMode(DebugMipMapMode value)
		{
			if (value != DebugMipMapMode.None)
			{
				this.data.materialDebugSettings.DisableMaterialDebug();
				this.data.lightingDebugSettings.debugLightingMode = DebugLightingMode.None;
				this.data.lightingDebugSettings.debugLightLayers = false;
				this.data.fullScreenDebugMode = FullScreenDebugMode.None;
			}
			this.data.mipMapDebugSettings.debugMipMapMode = value;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000067C8 File Offset: 0x000049C8
		private void EnableProfilingRecorders()
		{
			this.m_RecordedSamplers.Add(HDProfileId.HDRenderPipelineAllRenderRequest);
			this.m_RecordedSamplers.Add(HDProfileId.VolumeUpdate);
			this.m_RecordedSamplers.Add(HDProfileId.RenderShadowMaps);
			this.m_RecordedSamplers.Add(HDProfileId.GBuffer);
			this.m_RecordedSamplers.Add(HDProfileId.PrepareLightsForGPU);
			this.m_RecordedSamplers.Add(HDProfileId.VolumeVoxelization);
			this.m_RecordedSamplers.Add(HDProfileId.VolumetricLighting);
			this.m_RecordedSamplers.Add(HDProfileId.VolumetricClouds);
			this.m_RecordedSamplers.Add(HDProfileId.VolumetricCloudsTrace);
			this.m_RecordedSamplers.Add(HDProfileId.VolumetricCloudsReproject);
			this.m_RecordedSamplers.Add(HDProfileId.VolumetricCloudsUpscaleAndCombine);
			this.m_RecordedSamplers.Add(HDProfileId.RenderDeferredLightingCompute);
			this.m_RecordedSamplers.Add(HDProfileId.ForwardOpaque);
			this.m_RecordedSamplers.Add(HDProfileId.ForwardTransparent);
			this.m_RecordedSamplers.Add(HDProfileId.ForwardPreRefraction);
			this.m_RecordedSamplers.Add(HDProfileId.ColorPyramid);
			this.m_RecordedSamplers.Add(HDProfileId.DepthPyramid);
			this.m_RecordedSamplers.Add(HDProfileId.PostProcessing);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000068CC File Offset: 0x00004ACC
		private void DisableProfilingRecorders(List<HDProfileId> samplers)
		{
			foreach (HDProfileId marker in samplers)
			{
				ProfilingSampler.Get<HDProfileId>(marker).enableRecording = false;
			}
			samplers.Clear();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00006924 File Offset: 0x00004B24
		private void EnableProfilingRecordersRT()
		{
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingBuildCluster);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingCullLights);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingBuildAccelerationStructure);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingReflectionDirectionGeneration);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingReflectionEvaluation);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingReflectionAdjustWeight);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingReflectionUpscale);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingReflectionFilter);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingAmbientOcclusion);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingFilterAmbientOcclusion);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingDirectionalLightShadow);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingLightShadow);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingIndirectDiffuseDirectionGeneration);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingIndirectDiffuseEvaluation);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingIndirectDiffuseUpscale);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingFilterIndirectDiffuse);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingDebugOverlay);
			this.m_RecordedSamplersRT.Add(HDProfileId.ForwardPreRefraction);
			this.m_RecordedSamplersRT.Add(HDProfileId.RayTracingRecursiveRendering);
			this.m_RecordedSamplersRT.Add(HDProfileId.RayTracingDepthPrepass);
			this.m_RecordedSamplersRT.Add(HDProfileId.RayTracingFlagMask);
			this.m_RecordedSamplersRT.Add(HDProfileId.RaytracingDeferredLighting);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00006A50 File Offset: 0x00004C50
		private float GetSamplerTiming(HDProfileId samplerId, ProfilingSampler sampler, DebugDisplaySettings.DebugProfilingType type)
		{
			if (this.data.averageProfilerTimingsOverASecond)
			{
				Dictionary<int, DebugDisplaySettings.AccumulatedTiming> dictionary = (type == DebugDisplaySettings.DebugProfilingType.CPU) ? this.m_AccumulatedCPUTiming : ((type == DebugDisplaySettings.DebugProfilingType.InlineCPU) ? this.m_AccumulatedInlineCPUTiming : this.m_AccumulatedGPUTiming);
				DebugDisplaySettings.AccumulatedTiming accumulatedTiming = null;
				if (dictionary.TryGetValue((int)samplerId, out accumulatedTiming))
				{
					return accumulatedTiming.lastAverage;
				}
				return 0f;
			}
			else
			{
				if (type == DebugDisplaySettings.DebugProfilingType.CPU)
				{
					return sampler.cpuElapsedTime;
				}
				if (type != DebugDisplaySettings.DebugProfilingType.GPU)
				{
					return sampler.inlineCpuElapsedTime;
				}
				return sampler.gpuElapsedTime;
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00006ABC File Offset: 0x00004CBC
		private ObservableList<DebugUI.Widget> BuildProfilingSamplerWidgetList(List<HDProfileId> samplerList)
		{
			ObservableList<DebugUI.Widget> observableList = new ObservableList<DebugUI.Widget>();
			foreach (HDProfileId hdprofileId in samplerList)
			{
				ProfilingSampler profilingSampler = ProfilingSampler.Get<HDProfileId>(hdprofileId);
				profilingSampler.enableRecording = true;
				observableList.Add(new DebugUI.ValueTuple
				{
					displayName = profilingSampler.name,
					values = new DebugUI.Value[]
					{
						this.<BuildProfilingSamplerWidgetList>g__CreateWidgetForSampler|88_0(hdprofileId, profilingSampler, DebugDisplaySettings.DebugProfilingType.CPU),
						this.<BuildProfilingSamplerWidgetList>g__CreateWidgetForSampler|88_0(hdprofileId, profilingSampler, DebugDisplaySettings.DebugProfilingType.InlineCPU),
						this.<BuildProfilingSamplerWidgetList>g__CreateWidgetForSampler|88_0(hdprofileId, profilingSampler, DebugDisplaySettings.DebugProfilingType.GPU)
					}
				});
			}
			return observableList;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00006B68 File Offset: 0x00004D68
		private void UpdateListOfAveragedProfilerTimings(List<HDProfileId> samplers, bool needUpdatingAverages)
		{
			foreach (HDProfileId hdprofileId in samplers)
			{
				ProfilingSampler profilingSampler = ProfilingSampler.Get<HDProfileId>(hdprofileId);
				DebugDisplaySettings.AccumulatedTiming accumulatedTiming = null;
				if (this.m_AccumulatedCPUTiming.TryGetValue((int)hdprofileId, out accumulatedTiming))
				{
					accumulatedTiming.accumulatedValue += profilingSampler.cpuElapsedTime;
				}
				DebugDisplaySettings.AccumulatedTiming accumulatedTiming2 = null;
				if (this.m_AccumulatedInlineCPUTiming.TryGetValue((int)hdprofileId, out accumulatedTiming2))
				{
					accumulatedTiming2.accumulatedValue += profilingSampler.inlineCpuElapsedTime;
				}
				DebugDisplaySettings.AccumulatedTiming accumulatedTiming3 = null;
				if (this.m_AccumulatedGPUTiming.TryGetValue((int)hdprofileId, out accumulatedTiming3))
				{
					accumulatedTiming3.accumulatedValue += profilingSampler.gpuElapsedTime;
				}
				if (needUpdatingAverages)
				{
					if (accumulatedTiming != null)
					{
						accumulatedTiming.UpdateLastAverage(this.m_AccumulatedFrames);
					}
					if (accumulatedTiming2 != null)
					{
						accumulatedTiming2.UpdateLastAverage(this.m_AccumulatedFrames);
					}
					if (accumulatedTiming3 != null)
					{
						accumulatedTiming3.UpdateLastAverage(this.m_AccumulatedFrames);
					}
				}
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00006C64 File Offset: 0x00004E64
		internal void UpdateAveragedProfilerTimings()
		{
			this.m_TimeSinceLastAvgValue += Time.unscaledDeltaTime;
			this.m_AccumulatedFrames++;
			bool flag = this.m_TimeSinceLastAvgValue >= 1f;
			this.UpdateListOfAveragedProfilerTimings(this.m_RecordedSamplers, flag);
			this.UpdateListOfAveragedProfilerTimings(this.m_RecordedSamplersRT, flag);
			if (flag)
			{
				this.m_TimeSinceLastAvgValue = 0f;
				this.m_AccumulatedFrames = 0;
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00006CD4 File Offset: 0x00004ED4
		private void RegisterDisplayStatsDebug()
		{
			List<DebugUI.Widget> list = new List<DebugUI.Widget>();
			this.debugFrameTiming.RegisterDebugUI(list);
			this.EnableProfilingRecorders();
			list.Add(new DebugUI.BoolField
			{
				displayName = "Update every second with average",
				getter = (() => this.data.averageProfilerTimingsOverASecond),
				setter = delegate(bool value)
				{
					this.data.averageProfilerTimingsOverASecond = value;
				}
			});
			list.Add(new DebugUI.Foldout("Detailed Stats", this.BuildProfilingSamplerWidgetList(this.m_RecordedSamplers), new string[]
			{
				"CPU",
				"CPUInline",
				"GPU"
			}, null));
			HDRenderPipelineAsset currentAsset = HDRenderPipeline.currentAsset;
			if (currentAsset == null || currentAsset.currentPlatformRenderPipelineSettings.supportRayTracing)
			{
				this.EnableProfilingRecordersRT();
				list.Add(new DebugUI.Foldout("Ray Tracing Stats", this.BuildProfilingSamplerWidgetList(this.m_RecordedSamplersRT), new string[]
				{
					"CPU",
					"CPUInline",
					"GPU"
				}, null));
			}
			list.Add(new DebugUI.BoolField
			{
				displayName = "Count Rays (MRays/Frame)",
				getter = (() => this.data.countRays),
				setter = delegate(bool value)
				{
					this.data.countRays = value;
				}
			});
			List<DebugUI.Widget> list2 = list;
			DebugUI.Container container = new DebugUI.Container();
			container.isHiddenCallback = (() => !this.data.countRays);
			ObservableList<DebugUI.Widget> children = container.children;
			DebugUI.Value value11 = new DebugUI.Value();
			value11.displayName = "Ambient Occlusion";
			value11.getter = (() => (RenderPipelineManager.currentPipeline as HDRenderPipeline).GetRaysPerFrame(RayCountValues.AmbientOcclusion) / 1000000f);
			value11.refreshRate = 0.033333335f;
			children.Add(value11);
			ObservableList<DebugUI.Widget> children2 = container.children;
			DebugUI.Value value2 = new DebugUI.Value();
			value2.displayName = "Shadows Directional";
			value2.getter = (() => (RenderPipelineManager.currentPipeline as HDRenderPipeline).GetRaysPerFrame(RayCountValues.ShadowDirectional) / 1000000f);
			value2.refreshRate = 0.033333335f;
			children2.Add(value2);
			ObservableList<DebugUI.Widget> children3 = container.children;
			DebugUI.Value value3 = new DebugUI.Value();
			value3.displayName = "Shadows Area";
			value3.getter = (() => (RenderPipelineManager.currentPipeline as HDRenderPipeline).GetRaysPerFrame(RayCountValues.ShadowAreaLight) / 1000000f);
			value3.refreshRate = 0.033333335f;
			children3.Add(value3);
			ObservableList<DebugUI.Widget> children4 = container.children;
			DebugUI.Value value4 = new DebugUI.Value();
			value4.displayName = "Shadows Point/Spot";
			value4.getter = (() => (RenderPipelineManager.currentPipeline as HDRenderPipeline).GetRaysPerFrame(RayCountValues.ShadowPointSpot) / 1000000f);
			value4.refreshRate = 0.033333335f;
			children4.Add(value4);
			ObservableList<DebugUI.Widget> children5 = container.children;
			DebugUI.Value value5 = new DebugUI.Value();
			value5.displayName = "Reflections Forward ";
			value5.getter = (() => (RenderPipelineManager.currentPipeline as HDRenderPipeline).GetRaysPerFrame(RayCountValues.ReflectionForward) / 1000000f);
			value5.refreshRate = 0.033333335f;
			children5.Add(value5);
			ObservableList<DebugUI.Widget> children6 = container.children;
			DebugUI.Value value6 = new DebugUI.Value();
			value6.displayName = "Reflections Deferred";
			value6.getter = (() => (RenderPipelineManager.currentPipeline as HDRenderPipeline).GetRaysPerFrame(RayCountValues.ReflectionDeferred) / 1000000f);
			value6.refreshRate = 0.033333335f;
			children6.Add(value6);
			ObservableList<DebugUI.Widget> children7 = container.children;
			DebugUI.Value value7 = new DebugUI.Value();
			value7.displayName = "Diffuse GI Forward";
			value7.getter = (() => (RenderPipelineManager.currentPipeline as HDRenderPipeline).GetRaysPerFrame(RayCountValues.DiffuseGI_Forward) / 1000000f);
			value7.refreshRate = 0.033333335f;
			children7.Add(value7);
			ObservableList<DebugUI.Widget> children8 = container.children;
			DebugUI.Value value8 = new DebugUI.Value();
			value8.displayName = "Diffuse GI Deferred";
			value8.getter = (() => (RenderPipelineManager.currentPipeline as HDRenderPipeline).GetRaysPerFrame(RayCountValues.DiffuseGI_Deferred) / 1000000f);
			value8.refreshRate = 0.033333335f;
			children8.Add(value8);
			ObservableList<DebugUI.Widget> children9 = container.children;
			DebugUI.Value value9 = new DebugUI.Value();
			value9.displayName = "Recursive Rendering";
			value9.getter = (() => (RenderPipelineManager.currentPipeline as HDRenderPipeline).GetRaysPerFrame(RayCountValues.Recursive) / 1000000f);
			value9.refreshRate = 0.033333335f;
			children9.Add(value9);
			ObservableList<DebugUI.Widget> children10 = container.children;
			DebugUI.Value value10 = new DebugUI.Value();
			value10.displayName = "Total";
			value10.getter = (() => (RenderPipelineManager.currentPipeline as HDRenderPipeline).GetRaysPerFrame(RayCountValues.Total) / 1000000f);
			value10.refreshRate = 0.033333335f;
			children10.Add(value10);
			list2.Add(container);
			this.m_DebugDisplayStatsItems = list.ToArray();
			DebugUI.Panel panel = DebugManager.instance.GetPanel(DebugDisplaySettings.k_PanelDisplayStats, true, int.MinValue, false);
			panel.flags = DebugUI.Flags.RuntimeOnly;
			panel.children.Add(this.m_DebugDisplayStatsItems);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00007145 File Offset: 0x00005345
		private DebugUI.Widget CreateMissingDebugShadersWarning()
		{
			DebugUI.MessageBox messageBox = new DebugUI.MessageBox();
			messageBox.displayName = "Warning: the debug shader variants are missing. Ensure that the \"Runtime Debug Shaders\" option is enabled in HDRP Global Settings.";
			messageBox.style = DebugUI.MessageBox.Style.Warning;
			messageBox.isHiddenCallback = (() => !(HDRenderPipelineGlobalSettings.instance != null) || HDRenderPipelineGlobalSettings.instance.supportRuntimeDebugDisplay);
			return messageBox;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00007184 File Offset: 0x00005384
		private void UnregisterDisplayStatsDebug()
		{
			this.DisableProfilingRecorders(this.m_RecordedSamplers);
			HDRenderPipelineAsset currentAsset = HDRenderPipeline.currentAsset;
			if (currentAsset == null || currentAsset.currentPlatformRenderPipelineSettings.supportRayTracing)
			{
				this.DisableProfilingRecorders(this.m_RecordedSamplersRT);
			}
			this.UnregisterDebugItems(DebugDisplaySettings.k_PanelDisplayStats, this.m_DebugDisplayStatsItems);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000071D4 File Offset: 0x000053D4
		private void RegisterMaterialDebug()
		{
			List<DebugUI.Widget> list = new List<DebugUI.Widget>();
			list.Add(this.CreateMissingDebugShadersWarning());
			list.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.MaterialStrings.CommonMaterialProperties,
				getter = (() => (int)this.data.materialDebugSettings.debugViewMaterialCommonValue),
				setter = delegate(int value)
				{
					this.SetDebugViewCommonMaterialProperty((MaterialSharedProperty)value);
				},
				autoEnum = typeof(MaterialSharedProperty),
				getIndex = (() => (int)this.data.materialDebugSettings.debugViewMaterialCommonValue),
				setIndex = delegate(int value)
				{
					this.data.ResetExclusiveEnumIndices();
					this.data.materialDebugSettings.debugViewMaterialCommonValue = (MaterialSharedProperty)value;
				}
			});
			list.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.MaterialStrings.Material,
				getter = delegate
				{
					if (this.data.materialDebugSettings.debugViewMaterial[0] != 0)
					{
						return this.data.materialDebugSettings.debugViewMaterial[1];
					}
					return 0;
				},
				setter = delegate(int value)
				{
					this.SetDebugViewMaterial(value);
				},
				enumNames = MaterialDebugSettings.debugViewMaterialStrings,
				enumValues = MaterialDebugSettings.debugViewMaterialValues,
				getIndex = (() => this.data.materialDebugSettings.materialEnumIndex),
				setIndex = delegate(int value)
				{
					this.data.ResetExclusiveEnumIndices();
					this.data.materialDebugSettings.materialEnumIndex = value;
				}
			});
			list.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.MaterialStrings.Engine,
				getter = (() => this.data.materialDebugSettings.debugViewEngine),
				setter = delegate(int value)
				{
					this.SetDebugViewEngine(value);
				},
				enumNames = MaterialDebugSettings.debugViewEngineStrings,
				enumValues = MaterialDebugSettings.debugViewEngineValues,
				getIndex = (() => this.data.engineEnumIndex),
				setIndex = delegate(int value)
				{
					this.data.ResetExclusiveEnumIndices();
					this.data.engineEnumIndex = value;
				}
			});
			list.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.MaterialStrings.Attributes,
				getter = (() => (int)this.data.materialDebugSettings.debugViewVarying),
				setter = delegate(int value)
				{
					this.SetDebugViewVarying((DebugViewVarying)value);
				},
				autoEnum = typeof(DebugViewVarying),
				getIndex = (() => this.data.attributesEnumIndex),
				setIndex = delegate(int value)
				{
					this.data.ResetExclusiveEnumIndices();
					this.data.attributesEnumIndex = value;
				}
			});
			list.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.MaterialStrings.Properties,
				getter = (() => (int)this.data.materialDebugSettings.debugViewProperties),
				setter = delegate(int value)
				{
					this.SetDebugViewProperties((DebugViewProperties)value);
				},
				autoEnum = typeof(DebugViewProperties),
				getIndex = (() => this.data.propertiesEnumIndex),
				setIndex = delegate(int value)
				{
					this.data.ResetExclusiveEnumIndices();
					this.data.propertiesEnumIndex = value;
				}
			});
			list.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.MaterialStrings.GBuffer,
				getter = (() => this.data.materialDebugSettings.debugViewGBuffer),
				setter = delegate(int value)
				{
					this.SetDebugViewGBuffer(value);
				},
				enumNames = MaterialDebugSettings.debugViewMaterialGBufferStrings,
				enumValues = MaterialDebugSettings.debugViewMaterialGBufferValues,
				getIndex = (() => this.data.gBufferEnumIndex),
				setIndex = delegate(int value)
				{
					this.data.ResetExclusiveEnumIndices();
					this.data.gBufferEnumIndex = value;
				}
			});
			list.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.MaterialStrings.MaterialValidator,
				getter = (() => (int)this.data.fullScreenDebugMode),
				setter = delegate(int value)
				{
					this.SetFullScreenDebugMode((FullScreenDebugMode)value);
				},
				enumNames = DebugDisplaySettings.s_MaterialFullScreenDebugStrings,
				enumValues = DebugDisplaySettings.s_MaterialFullScreenDebugValues,
				getIndex = (() => this.data.materialValidatorDebugModeEnumIndex),
				setIndex = delegate(int value)
				{
					this.data.ResetExclusiveEnumIndices();
					this.data.materialValidatorDebugModeEnumIndex = value;
				}
			});
			list.Add(new DebugUI.Container
			{
				isHiddenCallback = (() => this.data.fullScreenDebugMode != FullScreenDebugMode.ValidateDiffuseColor && this.data.fullScreenDebugMode != FullScreenDebugMode.ValidateSpecularColor),
				children = 
				{
					new DebugUI.ColorField
					{
						nameAndTooltip = DebugDisplaySettings.MaterialStrings.ValidatorTooHighColor,
						getter = (() => this.data.materialDebugSettings.materialValidateHighColor),
						setter = delegate(Color value)
						{
							this.data.materialDebugSettings.materialValidateHighColor = value;
						},
						showAlpha = false,
						hdr = true
					},
					new DebugUI.ColorField
					{
						nameAndTooltip = DebugDisplaySettings.MaterialStrings.ValidatorTooLowColor,
						getter = (() => this.data.materialDebugSettings.materialValidateLowColor),
						setter = delegate(Color value)
						{
							this.data.materialDebugSettings.materialValidateLowColor = value;
						},
						showAlpha = false,
						hdr = true
					},
					new DebugUI.ColorField
					{
						nameAndTooltip = DebugDisplaySettings.MaterialStrings.ValidatorNotAPureMetalColor,
						getter = (() => this.data.materialDebugSettings.materialValidateTrueMetalColor),
						setter = delegate(Color value)
						{
							this.data.materialDebugSettings.materialValidateTrueMetalColor = value;
						},
						showAlpha = false,
						hdr = true
					},
					new DebugUI.BoolField
					{
						nameAndTooltip = DebugDisplaySettings.MaterialStrings.ValidatorPureMetals,
						getter = (() => this.data.materialDebugSettings.materialValidateTrueMetal),
						setter = delegate(bool v)
						{
							this.data.materialDebugSettings.materialValidateTrueMetal = v;
						}
					}
				}
			});
			List<DebugUI.Widget> list2 = list;
			DebugUI.Container container = new DebugUI.Container();
			container.isHiddenCallback = (() => !ShaderConfig.s_GlobalMipBias);
			container.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.MaterialStrings.OverrideGlobalMaterialTextureMipBias,
				getter = (() => this.data.UseDebugGlobalMipBiasOverride()),
				setter = delegate(bool value)
				{
					this.data.SetUseDebugGlobalMipBiasOverride(value);
				}
			});
			container.children.Add(new DebugUI.FloatField
			{
				nameAndTooltip = DebugDisplaySettings.MaterialStrings.DebugGlobalMaterialTextureMipBiasValue,
				getter = (() => this.data.GetDebugGlobalMipBiasOverride()),
				setter = delegate(float value)
				{
					this.data.SetDebugGlobalMipBiasOverride(value);
				},
				isHiddenCallback = (() => !this.data.UseDebugGlobalMipBiasOverride())
			});
			list2.Add(container);
			this.m_DebugMaterialItems = list.ToArray();
			DebugManager.instance.GetPanel(DebugDisplaySettings.k_PanelMaterials, true, 0, false).children.Add(this.m_DebugMaterialItems);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000773E File Offset: 0x0000593E
		private void RefreshDisplayStatsDebug<T>(DebugUI.Field<T> field, T value)
		{
			this.UnregisterDisplayStatsDebug();
			this.RegisterDisplayStatsDebug();
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000774C File Offset: 0x0000594C
		private void RefreshLightingDebug<T>(DebugUI.Field<T> field, T value)
		{
			this.UnregisterDebugItems(DebugDisplaySettings.k_PanelLighting, this.m_DebugLightingItems);
			this.RegisterLightingDebug();
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00007765 File Offset: 0x00005965
		private void RefreshDecalsDebug<T>(DebugUI.Field<T> field, T value)
		{
			this.UnregisterDebugItems(DebugDisplaySettings.k_PanelDecals, this.m_DebugDecalsItems);
			this.RegisterDecalsDebug();
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000777E File Offset: 0x0000597E
		private void RefreshRenderingDebug<T>(DebugUI.Field<T> field, T value)
		{
			this.UnregisterRenderingDebug();
			this.RegisterRenderingDebug();
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000778C File Offset: 0x0000598C
		private void RefreshMaterialDebug<T>(DebugUI.Field<T> field, T value)
		{
			this.UnregisterDebugItems(DebugDisplaySettings.k_PanelMaterials, this.m_DebugMaterialItems);
			this.RegisterMaterialDebug();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000077A8 File Offset: 0x000059A8
		private void RegisterLightingDebug()
		{
			List<DebugUI.Widget> list = new List<DebugUI.Widget>();
			list.Add(this.CreateMissingDebugShadersWarning());
			DebugUI.Container container = new DebugUI.Container
			{
				displayName = "Shadows"
			};
			container.children.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.ShadowDebugMode,
				getter = (() => (int)this.data.lightingDebugSettings.shadowDebugMode),
				setter = delegate(int value)
				{
					this.SetShadowDebugMode((ShadowMapDebugMode)value);
				},
				autoEnum = typeof(ShadowMapDebugMode),
				getIndex = (() => this.data.shadowDebugModeEnumIndex),
				setIndex = delegate(int value)
				{
					this.data.shadowDebugModeEnumIndex = value;
				}
			});
			ObservableList<DebugUI.Widget> children = container.children;
			DebugUI.Container container2 = new DebugUI.Container();
			container2.isHiddenCallback = (() => this.data.lightingDebugSettings.shadowDebugMode != ShadowMapDebugMode.VisualizeShadowMap && this.data.lightingDebugSettings.shadowDebugMode != ShadowMapDebugMode.SingleShadow);
			container2.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.ShadowDebugUseSelection,
				getter = (() => this.data.lightingDebugSettings.shadowDebugUseSelection),
				setter = delegate(bool value)
				{
					this.data.lightingDebugSettings.shadowDebugUseSelection = value;
				},
				flags = DebugUI.Flags.EditorOnly
			});
			ObservableList<DebugUI.Widget> children2 = container2.children;
			DebugUI.UIntField uintField = new DebugUI.UIntField();
			uintField.nameAndTooltip = DebugDisplaySettings.LightingStrings.ShadowDebugShadowMapIndex;
			uintField.getter = (() => this.data.lightingDebugSettings.shadowMapIndex);
			uintField.setter = delegate(uint value)
			{
				this.data.lightingDebugSettings.shadowMapIndex = value;
			};
			uintField.min = (() => 0U);
			uintField.max = (() => (uint)Math.Max(0L, (long)(RenderPipelineManager.currentPipeline as HDRenderPipeline).GetCurrentShadowCount() - 1L));
			uintField.isHiddenCallback = (() => this.data.lightingDebugSettings.shadowDebugUseSelection);
			children2.Add(uintField);
			children.Add(container2);
			ObservableList<DebugUI.Widget> children3 = container.children;
			DebugUI.FloatField floatField = new DebugUI.FloatField();
			floatField.nameAndTooltip = DebugDisplaySettings.LightingStrings.GlobalShadowScaleFactor;
			floatField.getter = (() => this.data.lightingDebugSettings.shadowResolutionScaleFactor);
			floatField.setter = delegate(float v)
			{
				this.data.lightingDebugSettings.shadowResolutionScaleFactor = v;
			};
			floatField.min = (() => 0.01f);
			floatField.max = (() => 4f);
			children3.Add(floatField);
			container.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.ClearShadowAtlas,
				getter = (() => this.data.lightingDebugSettings.clearShadowAtlas),
				setter = delegate(bool v)
				{
					this.data.lightingDebugSettings.clearShadowAtlas = v;
				}
			});
			container.children.Add(new DebugUI.FloatField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.ShadowRangeMinimumValue,
				getter = (() => this.data.lightingDebugSettings.shadowMinValue),
				setter = delegate(float value)
				{
					this.data.lightingDebugSettings.shadowMinValue = value;
				}
			});
			container.children.Add(new DebugUI.FloatField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.ShadowRangeMaximumValue,
				getter = (() => this.data.lightingDebugSettings.shadowMaxValue),
				setter = delegate(float value)
				{
					this.data.lightingDebugSettings.shadowMaxValue = value;
				}
			});
			list.Add(container);
			DebugUI.Container container3 = new DebugUI.Container
			{
				displayName = "Lighting"
			};
			container3.children.Add(new DebugUI.Foldout
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.ShowLightsByType,
				children = 
				{
					new DebugUI.BoolField
					{
						nameAndTooltip = DebugDisplaySettings.LightingStrings.DirectionalLights,
						getter = (() => this.data.lightingDebugSettings.showDirectionalLight),
						setter = delegate(bool value)
						{
							this.data.lightingDebugSettings.showDirectionalLight = value;
						}
					},
					new DebugUI.BoolField
					{
						nameAndTooltip = DebugDisplaySettings.LightingStrings.PunctualLights,
						getter = (() => this.data.lightingDebugSettings.showPunctualLight),
						setter = delegate(bool value)
						{
							this.data.lightingDebugSettings.showPunctualLight = value;
						}
					},
					new DebugUI.BoolField
					{
						nameAndTooltip = DebugDisplaySettings.LightingStrings.AreaLights,
						getter = (() => this.data.lightingDebugSettings.showAreaLight),
						setter = delegate(bool value)
						{
							this.data.lightingDebugSettings.showAreaLight = value;
						}
					},
					new DebugUI.BoolField
					{
						nameAndTooltip = DebugDisplaySettings.LightingStrings.ReflectionProbes,
						getter = (() => this.data.lightingDebugSettings.showReflectionProbe),
						setter = delegate(bool value)
						{
							this.data.lightingDebugSettings.showReflectionProbe = value;
						}
					}
				}
			});
			DebugUI.Foldout item = new DebugUI.Foldout
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.Exposure,
				children = 
				{
					new DebugUI.EnumField
					{
						nameAndTooltip = DebugDisplaySettings.LightingStrings.ExposureDebugMode,
						getter = (() => (int)this.data.lightingDebugSettings.exposureDebugMode),
						setter = delegate(int value)
						{
							this.SetExposureDebugMode((ExposureDebugMode)value);
						},
						autoEnum = typeof(ExposureDebugMode),
						getIndex = (() => this.data.exposureDebugModeEnumIndex),
						setIndex = delegate(int value)
						{
							this.data.exposureDebugModeEnumIndex = value;
						}
					},
					new DebugUI.BoolField
					{
						nameAndTooltip = DebugDisplaySettings.LightingStrings.ExposureDisplayMaskOnly,
						getter = (() => this.data.lightingDebugSettings.displayMaskOnly),
						setter = delegate(bool value)
						{
							this.data.lightingDebugSettings.displayMaskOnly = value;
						},
						isHiddenCallback = (() => this.data.lightingDebugSettings.exposureDebugMode != ExposureDebugMode.MeteringWeighted)
					},
					new DebugUI.Container
					{
						isHiddenCallback = (() => this.data.lightingDebugSettings.exposureDebugMode != ExposureDebugMode.HistogramView),
						children = 
						{
							new DebugUI.BoolField
							{
								nameAndTooltip = DebugDisplaySettings.LightingStrings.DisplayHistogramSceneOverlay,
								getter = (() => this.data.lightingDebugSettings.displayOnSceneOverlay),
								setter = delegate(bool value)
								{
									this.data.lightingDebugSettings.displayOnSceneOverlay = value;
								}
							},
							new DebugUI.BoolField
							{
								nameAndTooltip = DebugDisplaySettings.LightingStrings.ExposureShowTonemapCurve,
								getter = (() => this.data.lightingDebugSettings.showTonemapCurveAlongHistogramView),
								setter = delegate(bool value)
								{
									this.data.lightingDebugSettings.showTonemapCurveAlongHistogramView = value;
								}
							},
							new DebugUI.BoolField
							{
								nameAndTooltip = DebugDisplaySettings.LightingStrings.ExposureCenterAroundExposure,
								getter = (() => this.data.lightingDebugSettings.centerHistogramAroundMiddleGrey),
								setter = delegate(bool value)
								{
									this.data.lightingDebugSettings.centerHistogramAroundMiddleGrey = value;
								}
							}
						}
					},
					new DebugUI.BoolField
					{
						nameAndTooltip = DebugDisplaySettings.LightingStrings.ExposureDisplayRGBHistogram,
						getter = (() => this.data.lightingDebugSettings.displayFinalImageHistogramAsRGB),
						setter = delegate(bool value)
						{
							this.data.lightingDebugSettings.displayFinalImageHistogramAsRGB = value;
						},
						isHiddenCallback = (() => this.data.lightingDebugSettings.exposureDebugMode != ExposureDebugMode.FinalImageHistogramView)
					},
					new DebugUI.FloatField
					{
						nameAndTooltip = DebugDisplaySettings.LightingStrings.DebugExposureCompensation,
						getter = (() => this.data.lightingDebugSettings.debugExposure),
						setter = delegate(float value)
						{
							this.data.lightingDebugSettings.debugExposure = value;
						}
					}
				}
			};
			container3.children.Add(item);
			DebugUI.Foldout foldout = new DebugUI.Foldout();
			foldout.nameAndTooltip = DebugDisplaySettings.LightingStrings.HDROutput;
			ObservableList<DebugUI.Widget> children4 = foldout.children;
			DebugUI.MessageBox messageBox = new DebugUI.MessageBox();
			messageBox.displayName = "No HDR monitor detected.";
			messageBox.style = DebugUI.MessageBox.Style.Warning;
			messageBox.isHiddenCallback = (() => HDRenderPipeline.HDROutputForMainDisplayIsActive());
			children4.Add(messageBox);
			ObservableList<DebugUI.Widget> children5 = foldout.children;
			DebugUI.MessageBox messageBox2 = new DebugUI.MessageBox();
			messageBox2.displayName = "To display the Gamut View, Gamut Clip, Paper White modes without affecting them, the overlay will be hidden.";
			messageBox2.style = DebugUI.MessageBox.Style.Info;
			messageBox2.isHiddenCallback = (() => !HDRenderPipeline.HDROutputForMainDisplayIsActive());
			children5.Add(messageBox2);
			foldout.children.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.HDROutputDebugMode,
				getter = (() => (int)this.data.lightingDebugSettings.hdrDebugMode),
				setter = delegate(int value)
				{
					this.SetHDRDebugMode((HDRDebugMode)value);
				},
				autoEnum = typeof(HDRDebugMode),
				getIndex = (() => this.data.hdrDebugModeEnumIndex),
				setIndex = delegate(int value)
				{
					this.data.hdrDebugModeEnumIndex = value;
				}
			});
			DebugUI.Foldout item2 = foldout;
			container3.children.Add(item2);
			container3.children.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.LightingDebugMode,
				getter = (() => (int)this.data.lightingDebugSettings.debugLightingMode),
				setter = delegate(int value)
				{
					this.SetDebugLightingMode((DebugLightingMode)value);
				},
				autoEnum = typeof(DebugLightingMode),
				getIndex = (() => this.data.lightingDebugModeEnumIndex),
				setIndex = delegate(int value)
				{
					this.data.ResetExclusiveEnumIndices();
					this.data.lightingDebugModeEnumIndex = value;
				}
			});
			container3.children.Add(new DebugUI.BitField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.LightHierarchyDebugMode,
				getter = (() => this.data.lightingDebugSettings.debugLightFilterMode),
				setter = delegate(Enum value)
				{
					this.SetDebugLightFilterMode((DebugLightFilterMode)value);
				},
				enumType = typeof(DebugLightFilterMode)
			});
			container3.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.LightLayersVisualization,
				getter = (() => this.data.lightingDebugSettings.debugLightLayers),
				setter = delegate(bool value)
				{
					this.SetDebugLightLayersMode(value);
				}
			});
			DebugUI.Container container4 = new DebugUI.Container
			{
				isHiddenCallback = (() => !this.data.lightingDebugSettings.debugLightLayers),
				children = 
				{
					new DebugUI.BoolField
					{
						nameAndTooltip = DebugDisplaySettings.LightingStrings.LightLayersUseSelectedLight,
						getter = (() => this.data.lightingDebugSettings.debugSelectionLightLayers),
						setter = delegate(bool value)
						{
							this.data.lightingDebugSettings.debugSelectionLightLayers = value;
						},
						flags = DebugUI.Flags.EditorOnly
					},
					new DebugUI.BoolField
					{
						nameAndTooltip = DebugDisplaySettings.LightingStrings.LightLayersSwitchToLightShadowLayers,
						getter = (() => this.data.lightingDebugSettings.debugSelectionShadowLayers),
						setter = delegate(bool value)
						{
							this.data.lightingDebugSettings.debugSelectionShadowLayers = value;
						},
						flags = DebugUI.Flags.EditorOnly,
						isHiddenCallback = (() => !this.data.lightingDebugSettings.debugSelectionLightLayers)
					}
				}
			};
			DebugUI.BitField bitField = new DebugUI.BitField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.LightLayersFilterLayers,
				getter = (() => this.data.lightingDebugSettings.debugLightLayersFilterMask),
				setter = delegate(Enum value)
				{
					this.data.lightingDebugSettings.debugLightLayersFilterMask = (DebugLightLayersMask)value;
				},
				enumType = typeof(DebugLightLayersMask),
				isHiddenCallback = (() => this.data.lightingDebugSettings.debugSelectionLightLayers)
			};
			for (int i = 0; i < 8; i++)
			{
				bitField.enumNames[i + 1].text = HDRenderPipelineGlobalSettings.instance.prefixedRenderingLayerMaskNames[i];
			}
			container4.children.Add(bitField);
			DebugUI.Foldout foldout2 = new DebugUI.Foldout
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.LightLayersColor,
				flags = DebugUI.Flags.EditorOnly
			};
			for (int j = 0; j < 8; j++)
			{
				int index = j;
				foldout2.children.Add(new DebugUI.ColorField
				{
					displayName = HDRenderPipelineGlobalSettings.instance.prefixedRenderingLayerMaskNames[j],
					flags = DebugUI.Flags.EditorOnly,
					getter = (() => this.data.lightingDebugSettings.debugRenderingLayersColors[index]),
					setter = delegate(Color value)
					{
						this.data.lightingDebugSettings.debugRenderingLayersColors[index] = value;
					}
				});
			}
			container4.children.Add(foldout2);
			container3.children.Add(container4);
			list.Add(container3);
			DebugUI.Container container5 = new DebugUI.Container();
			container5.displayName = "Material Overrides";
			container5.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.OverrideSmoothness,
				getter = (() => this.data.lightingDebugSettings.overrideSmoothness),
				setter = delegate(bool value)
				{
					this.data.lightingDebugSettings.overrideSmoothness = value;
				}
			});
			ObservableList<DebugUI.Widget> children6 = container5.children;
			DebugUI.Container container6 = new DebugUI.Container();
			container6.isHiddenCallback = (() => !this.data.lightingDebugSettings.overrideSmoothness);
			ObservableList<DebugUI.Widget> children7 = container6.children;
			DebugUI.FloatField floatField2 = new DebugUI.FloatField();
			floatField2.nameAndTooltip = DebugDisplaySettings.LightingStrings.Smoothness;
			floatField2.getter = (() => this.data.lightingDebugSettings.overrideSmoothnessValue);
			floatField2.setter = delegate(float value)
			{
				this.data.lightingDebugSettings.overrideSmoothnessValue = value;
			};
			floatField2.min = (() => 0f);
			floatField2.max = (() => 1f);
			floatField2.incStep = 0.025f;
			children7.Add(floatField2);
			children6.Add(container6);
			container5.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.OverrideAlbedo,
				getter = (() => this.data.lightingDebugSettings.overrideAlbedo),
				setter = delegate(bool value)
				{
					this.data.lightingDebugSettings.overrideAlbedo = value;
				}
			});
			container5.children.Add(new DebugUI.Container
			{
				isHiddenCallback = (() => !this.data.lightingDebugSettings.overrideAlbedo),
				children = 
				{
					new DebugUI.ColorField
					{
						nameAndTooltip = DebugDisplaySettings.LightingStrings.Albedo,
						getter = (() => this.data.lightingDebugSettings.overrideAlbedoValue),
						setter = delegate(Color value)
						{
							this.data.lightingDebugSettings.overrideAlbedoValue = value;
						},
						showAlpha = false,
						hdr = false
					}
				}
			});
			container5.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.OverrideNormal,
				getter = (() => this.data.lightingDebugSettings.overrideNormal),
				setter = delegate(bool value)
				{
					this.data.lightingDebugSettings.overrideNormal = value;
				}
			});
			container5.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.OverrideSpecularColor,
				getter = (() => this.data.lightingDebugSettings.overrideSpecularColor),
				setter = delegate(bool value)
				{
					this.data.lightingDebugSettings.overrideSpecularColor = value;
				}
			});
			container5.children.Add(new DebugUI.Container
			{
				isHiddenCallback = (() => !this.data.lightingDebugSettings.overrideSpecularColor),
				children = 
				{
					new DebugUI.ColorField
					{
						nameAndTooltip = DebugDisplaySettings.LightingStrings.SpecularColor,
						getter = (() => this.data.lightingDebugSettings.overrideSpecularColorValue),
						setter = delegate(Color value)
						{
							this.data.lightingDebugSettings.overrideSpecularColorValue = value;
						},
						showAlpha = false,
						hdr = false
					}
				}
			});
			container5.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.OverrideAmbientOcclusion,
				getter = (() => this.data.lightingDebugSettings.overrideAmbientOcclusion),
				setter = delegate(bool value)
				{
					this.data.lightingDebugSettings.overrideAmbientOcclusion = value;
				}
			});
			ObservableList<DebugUI.Widget> children8 = container5.children;
			DebugUI.Container container7 = new DebugUI.Container();
			container7.isHiddenCallback = (() => !this.data.lightingDebugSettings.overrideAmbientOcclusion);
			ObservableList<DebugUI.Widget> children9 = container7.children;
			DebugUI.FloatField floatField3 = new DebugUI.FloatField();
			floatField3.nameAndTooltip = DebugDisplaySettings.LightingStrings.AmbientOcclusion;
			floatField3.getter = (() => this.data.lightingDebugSettings.overrideAmbientOcclusionValue);
			floatField3.setter = delegate(float value)
			{
				this.data.lightingDebugSettings.overrideAmbientOcclusionValue = value;
			};
			floatField3.min = (() => 0f);
			floatField3.max = (() => 1f);
			floatField3.incStep = 0.025f;
			children9.Add(floatField3);
			children8.Add(container7);
			container5.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.OverrideEmissiveColor,
				getter = (() => this.data.lightingDebugSettings.overrideEmissiveColor),
				setter = delegate(bool value)
				{
					this.data.lightingDebugSettings.overrideEmissiveColor = value;
				}
			});
			container5.children.Add(new DebugUI.Container
			{
				isHiddenCallback = (() => !this.data.lightingDebugSettings.overrideEmissiveColor),
				children = 
				{
					new DebugUI.ColorField
					{
						nameAndTooltip = DebugDisplaySettings.LightingStrings.EmissiveColor,
						getter = (() => this.data.lightingDebugSettings.overrideEmissiveColorValue),
						setter = delegate(Color value)
						{
							this.data.lightingDebugSettings.overrideEmissiveColorValue = value;
						},
						showAlpha = false,
						hdr = true
					}
				}
			});
			DebugUI.Container item3 = container5;
			list.Add(item3);
			list.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.FullscreenDebugMode,
				getter = (() => (int)this.data.fullScreenDebugMode),
				setter = delegate(int value)
				{
					this.SetFullScreenDebugMode((FullScreenDebugMode)value);
				},
				enumNames = DebugDisplaySettings.s_LightingFullScreenDebugStrings,
				enumValues = DebugDisplaySettings.s_LightingFullScreenDebugValues,
				getIndex = (() => this.data.lightingFulscreenDebugModeEnumIndex),
				setIndex = delegate(int value)
				{
					this.data.ResetExclusiveEnumIndices();
					this.data.lightingFulscreenDebugModeEnumIndex = value;
				},
				onValueChanged = delegate(DebugUI.Field<int> _, int __)
				{
					FullScreenDebugMode fullScreenDebugMode = this.data.fullScreenDebugMode;
					if (fullScreenDebugMode != FullScreenDebugMode.ContactShadows && fullScreenDebugMode - FullScreenDebugMode.PreRefractionColorPyramid > 2)
					{
						this.data.fullscreenDebugMip = 0f;
					}
				}
			});
			List<DebugUI.Widget> list2 = list;
			DebugUI.Container container8 = new DebugUI.Container();
			ObservableList<DebugUI.Widget> children10 = container8.children;
			DebugUI.UIntField uintField2 = new DebugUI.UIntField();
			uintField2.nameAndTooltip = DebugDisplaySettings.LightingStrings.ScreenSpaceShadowIndex;
			uintField2.getter = (() => this.data.screenSpaceShadowIndex);
			uintField2.setter = delegate(uint value)
			{
				this.data.screenSpaceShadowIndex = value;
			};
			uintField2.min = (() => 0U);
			uintField2.max = (() => (uint)((RenderPipelineManager.currentPipeline as HDRenderPipeline).GetMaxScreenSpaceShadows() - 1));
			uintField2.isHiddenCallback = (() => this.data.fullScreenDebugMode != FullScreenDebugMode.ScreenSpaceShadows);
			children10.Add(uintField2);
			list2.Add(container8);
			list.Add(new DebugUI.Container
			{
				isHiddenCallback = (() => this.data.fullScreenDebugMode != FullScreenDebugMode.RayTracingAccelerationStructure),
				children = 
				{
					new DebugUI.EnumField
					{
						nameAndTooltip = DebugDisplaySettings.LightingStrings.RTASDebugView,
						getter = (() => (int)this.data.rtasDebugView),
						setter = delegate(int value)
						{
							this.SetRTASDebugView((RTASDebugView)value);
						},
						autoEnum = typeof(RTASDebugView),
						getIndex = (() => this.data.rtasDebugViewEnumIndex),
						setIndex = delegate(int value)
						{
							this.data.rtasDebugViewEnumIndex = value;
						}
					},
					new DebugUI.EnumField
					{
						nameAndTooltip = DebugDisplaySettings.LightingStrings.RTASDebugMode,
						getter = (() => (int)this.data.rtasDebugMode),
						setter = delegate(int value)
						{
							this.SetRTASDebugMode((RTASDebugMode)value);
						},
						autoEnum = typeof(RTASDebugMode),
						getIndex = (() => this.data.rtasDebugModeEnumIndex),
						setIndex = delegate(int value)
						{
							this.data.rtasDebugModeEnumIndex = value;
						}
					}
				}
			});
			List<DebugUI.Widget> list3 = list;
			DebugUI.Container container9 = new DebugUI.Container();
			container9.isHiddenCallback = (() => this.data.fullScreenDebugMode != FullScreenDebugMode.PreRefractionColorPyramid && this.data.fullScreenDebugMode != FullScreenDebugMode.FinalColorPyramid && this.data.fullScreenDebugMode != FullScreenDebugMode.DepthPyramid);
			ObservableList<DebugUI.Widget> children11 = container9.children;
			DebugUI.FloatField floatField4 = new DebugUI.FloatField();
			floatField4.nameAndTooltip = DebugDisplaySettings.LightingStrings.DepthPyramidDebugMip;
			floatField4.getter = (() => this.data.fullscreenDebugMip);
			floatField4.setter = delegate(float value)
			{
				this.data.fullscreenDebugMip = value;
			};
			floatField4.min = (() => 0f);
			floatField4.max = (() => 1f);
			floatField4.incStep = 0.05f;
			children11.Add(floatField4);
			container9.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.DepthPyramidEnableRemap,
				getter = (() => this.data.enableDebugDepthRemap),
				setter = delegate(bool value)
				{
					this.data.enableDebugDepthRemap = value;
				}
			});
			ObservableList<DebugUI.Widget> children12 = container9.children;
			DebugUI.Container container10 = new DebugUI.Container();
			container10.isHiddenCallback = (() => !this.data.enableDebugDepthRemap);
			ObservableList<DebugUI.Widget> children13 = container10.children;
			DebugUI.FloatField floatField5 = new DebugUI.FloatField();
			floatField5.nameAndTooltip = DebugDisplaySettings.LightingStrings.DepthPyramidRangeMin;
			floatField5.getter = (() => this.data.fullScreenDebugDepthRemap.x);
			floatField5.setter = delegate(float value)
			{
				this.data.fullScreenDebugDepthRemap.x = Mathf.Min(value, this.data.fullScreenDebugDepthRemap.y);
			};
			floatField5.min = (() => 0f);
			floatField5.max = (() => 1f);
			floatField5.incStep = 0.01f;
			children13.Add(floatField5);
			ObservableList<DebugUI.Widget> children14 = container10.children;
			DebugUI.FloatField floatField6 = new DebugUI.FloatField();
			floatField6.nameAndTooltip = DebugDisplaySettings.LightingStrings.DepthPyramidRangeMax;
			floatField6.getter = (() => this.data.fullScreenDebugDepthRemap.y);
			floatField6.setter = delegate(float value)
			{
				this.data.fullScreenDebugDepthRemap.y = Mathf.Max(value, this.data.fullScreenDebugDepthRemap.x);
			};
			floatField6.min = (() => 0.01f);
			floatField6.max = (() => 1f);
			floatField6.incStep = 0.01f;
			children14.Add(floatField6);
			children12.Add(container10);
			list3.Add(container9);
			List<DebugUI.Widget> list4 = list;
			DebugUI.Container container11 = new DebugUI.Container();
			container11.isHiddenCallback = (() => this.data.fullScreenDebugMode != FullScreenDebugMode.ContactShadows);
			ObservableList<DebugUI.Widget> children15 = container11.children;
			DebugUI.IntField intField = new DebugUI.IntField();
			intField.nameAndTooltip = DebugDisplaySettings.LightingStrings.ContactShadowsLightIndex;
			intField.getter = (() => this.data.fullScreenContactShadowLightIndex);
			intField.setter = delegate(int value)
			{
				this.data.fullScreenContactShadowLightIndex = value;
			};
			intField.min = (() => -1);
			intField.max = (() => ShaderConfig.FPTLMaxLightCount - 1);
			children15.Add(intField);
			list4.Add(container11);
			list.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.TileClusterDebug,
				getter = (() => (int)this.data.lightingDebugSettings.tileClusterDebug),
				setter = delegate(int value)
				{
					this.data.lightingDebugSettings.tileClusterDebug = (TileClusterDebug)value;
				},
				autoEnum = typeof(TileClusterDebug),
				getIndex = (() => this.data.tileClusterDebugEnumIndex),
				setIndex = delegate(int value)
				{
					this.data.tileClusterDebugEnumIndex = value;
				}
			});
			List<DebugUI.Widget> list5 = list;
			DebugUI.Container container12 = new DebugUI.Container();
			container12.isHiddenCallback = (() => this.data.lightingDebugSettings.tileClusterDebug == TileClusterDebug.None || this.data.lightingDebugSettings.tileClusterDebug == TileClusterDebug.MaterialFeatureVariants);
			container12.children.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.TileClusterDebugByCategory,
				getter = (() => (int)this.data.lightingDebugSettings.tileClusterDebugByCategory),
				setter = delegate(int value)
				{
					this.data.lightingDebugSettings.tileClusterDebugByCategory = (TileClusterCategoryDebug)value;
				},
				autoEnum = typeof(TileClusterCategoryDebug),
				getIndex = (() => this.data.tileClusterDebugByCategoryEnumIndex),
				setIndex = delegate(int value)
				{
					this.data.tileClusterDebugByCategoryEnumIndex = value;
				}
			});
			ObservableList<DebugUI.Widget> children16 = container12.children;
			DebugUI.Container container13 = new DebugUI.Container();
			container13.isHiddenCallback = (() => this.data.lightingDebugSettings.tileClusterDebug != TileClusterDebug.Cluster);
			container13.children.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.ClusterDebugMode,
				getter = (() => (int)this.data.lightingDebugSettings.clusterDebugMode),
				setter = delegate(int value)
				{
					this.data.lightingDebugSettings.clusterDebugMode = (ClusterDebugMode)value;
				},
				autoEnum = typeof(ClusterDebugMode),
				getIndex = (() => this.data.clusterDebugModeEnumIndex),
				setIndex = delegate(int value)
				{
					this.data.clusterDebugModeEnumIndex = value;
				}
			});
			ObservableList<DebugUI.Widget> children17 = container13.children;
			DebugUI.FloatField floatField7 = new DebugUI.FloatField();
			floatField7.isHiddenCallback = (() => this.data.lightingDebugSettings.clusterDebugMode != ClusterDebugMode.VisualizeSlice);
			floatField7.nameAndTooltip = DebugDisplaySettings.LightingStrings.ClusterDistance;
			floatField7.getter = (() => this.data.lightingDebugSettings.clusterDebugDistance);
			floatField7.setter = delegate(float value)
			{
				this.data.lightingDebugSettings.clusterDebugDistance = value;
			};
			floatField7.min = (() => 0f);
			floatField7.max = (() => 100f);
			floatField7.incStep = 0.05f;
			children17.Add(floatField7);
			children16.Add(container13);
			list5.Add(container12);
			list.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.DisplaySkyReflection,
				getter = (() => this.data.lightingDebugSettings.displaySkyReflection),
				setter = delegate(bool value)
				{
					this.data.lightingDebugSettings.displaySkyReflection = value;
				}
			});
			List<DebugUI.Widget> list6 = list;
			DebugUI.Container container14 = new DebugUI.Container();
			container14.isHiddenCallback = (() => !this.data.lightingDebugSettings.displaySkyReflection);
			ObservableList<DebugUI.Widget> children18 = container14.children;
			DebugUI.FloatField floatField8 = new DebugUI.FloatField();
			floatField8.nameAndTooltip = DebugDisplaySettings.LightingStrings.SkyReflectionMipmap;
			floatField8.getter = (() => this.data.lightingDebugSettings.skyReflectionMipmap);
			floatField8.setter = delegate(float value)
			{
				this.data.lightingDebugSettings.skyReflectionMipmap = value;
			};
			floatField8.min = (() => 0f);
			floatField8.max = (() => 1f);
			floatField8.incStep = 0.05f;
			children18.Add(floatField8);
			list6.Add(container14);
			list.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.DisplayLightVolumes,
				getter = (() => this.data.lightingDebugSettings.displayLightVolumes),
				setter = delegate(bool value)
				{
					this.data.lightingDebugSettings.displayLightVolumes = value;
				}
			});
			List<DebugUI.Widget> list7 = list;
			DebugUI.Container container15 = new DebugUI.Container();
			container15.isHiddenCallback = (() => !this.data.lightingDebugSettings.displayLightVolumes);
			container15.children.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.LightVolumeDebugType,
				getter = (() => (int)this.data.lightingDebugSettings.lightVolumeDebugByCategory),
				setter = delegate(int value)
				{
					this.data.lightingDebugSettings.lightVolumeDebugByCategory = (LightVolumeDebug)value;
				},
				autoEnum = typeof(LightVolumeDebug),
				getIndex = (() => this.data.lightVolumeDebugTypeEnumIndex),
				setIndex = delegate(int value)
				{
					this.data.lightVolumeDebugTypeEnumIndex = value;
				}
			});
			ObservableList<DebugUI.Widget> children19 = container15.children;
			DebugUI.UIntField uintField3 = new DebugUI.UIntField();
			uintField3.isHiddenCallback = (() => this.data.lightingDebugSettings.lightVolumeDebugByCategory > LightVolumeDebug.Gradient);
			uintField3.nameAndTooltip = DebugDisplaySettings.LightingStrings.MaxDebugLightCount;
			uintField3.getter = (() => this.data.lightingDebugSettings.maxDebugLightCount);
			uintField3.setter = delegate(uint value)
			{
				this.data.lightingDebugSettings.maxDebugLightCount = value;
			};
			uintField3.min = (() => 0U);
			uintField3.max = (() => 24U);
			uintField3.incStep = 1U;
			children19.Add(uintField3);
			list7.Add(container15);
			list.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.DisplayCookieAtlas,
				getter = (() => this.data.lightingDebugSettings.displayCookieAtlas),
				setter = delegate(bool value)
				{
					this.data.lightingDebugSettings.displayCookieAtlas = value;
				}
			});
			List<DebugUI.Widget> list8 = list;
			DebugUI.Container container16 = new DebugUI.Container();
			container16.isHiddenCallback = (() => !this.data.lightingDebugSettings.displayCookieAtlas);
			ObservableList<DebugUI.Widget> children20 = container16.children;
			DebugUI.UIntField uintField4 = new DebugUI.UIntField();
			uintField4.nameAndTooltip = DebugDisplaySettings.LightingStrings.CookieAtlasMipLevel;
			uintField4.getter = (() => this.data.lightingDebugSettings.cookieAtlasMipLevel);
			uintField4.setter = delegate(uint value)
			{
				this.data.lightingDebugSettings.cookieAtlasMipLevel = value;
			};
			uintField4.min = (() => 0U);
			uintField4.max = (() => (uint)(RenderPipelineManager.currentPipeline as HDRenderPipeline).GetCookieAtlasMipCount());
			children20.Add(uintField4);
			container16.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.ClearCookieAtlas,
				getter = (() => this.data.lightingDebugSettings.clearCookieAtlas),
				setter = delegate(bool value)
				{
					this.data.lightingDebugSettings.clearCookieAtlas = value;
				}
			});
			list8.Add(container16);
			list.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.DisplayReflectionProbeAtlas,
				getter = (() => this.data.lightingDebugSettings.displayReflectionProbeAtlas),
				setter = delegate(bool value)
				{
					this.data.lightingDebugSettings.displayReflectionProbeAtlas = value;
				},
				onValueChanged = new Action<DebugUI.Field<bool>, bool>(this.RefreshLightingDebug<bool>)
			});
			List<DebugUI.Widget> list9 = list;
			DebugUI.Container container17 = new DebugUI.Container();
			container17.isHiddenCallback = (() => !this.data.lightingDebugSettings.displayReflectionProbeAtlas);
			ObservableList<DebugUI.Widget> children21 = container17.children;
			DebugUI.UIntField uintField5 = new DebugUI.UIntField();
			uintField5.nameAndTooltip = DebugDisplaySettings.LightingStrings.ReflectionProbeAtlasSlice;
			uintField5.getter = (() => this.data.lightingDebugSettings.reflectionProbeSlice);
			uintField5.setter = delegate(uint value)
			{
				this.data.lightingDebugSettings.reflectionProbeSlice = value;
			};
			uintField5.min = (() => 0U);
			uintField5.max = (() => (uint)((RenderPipelineManager.currentPipeline as HDRenderPipeline).GetReflectionProbeArraySize() - 1));
			uintField5.isHiddenCallback = (() => (RenderPipelineManager.currentPipeline as HDRenderPipeline).GetReflectionProbeArraySize() == 1);
			children21.Add(uintField5);
			ObservableList<DebugUI.Widget> children22 = container17.children;
			DebugUI.UIntField uintField6 = new DebugUI.UIntField();
			uintField6.nameAndTooltip = DebugDisplaySettings.LightingStrings.ReflectionProbeAtlasMipLevel;
			uintField6.getter = (() => this.data.lightingDebugSettings.reflectionProbeMipLevel);
			uintField6.setter = delegate(uint value)
			{
				this.data.lightingDebugSettings.reflectionProbeMipLevel = value;
			};
			uintField6.min = (() => 0U);
			uintField6.max = (() => (uint)(RenderPipelineManager.currentPipeline as HDRenderPipeline).GetReflectionProbeMipCount());
			children22.Add(uintField6);
			container17.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.ClearReflectionProbeAtlas,
				getter = (() => this.data.lightingDebugSettings.clearReflectionProbeAtlas),
				setter = delegate(bool value)
				{
					this.data.lightingDebugSettings.clearReflectionProbeAtlas = value;
				}
			});
			container17.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.LightingStrings.ReflectionProbeApplyExposure,
				getter = (() => this.data.lightingDebugSettings.reflectionProbeApplyExposure),
				setter = delegate(bool value)
				{
					this.data.lightingDebugSettings.reflectionProbeApplyExposure = value;
				}
			});
			list9.Add(container17);
			List<DebugUI.Widget> list10 = list;
			DebugUI.FloatField floatField9 = new DebugUI.FloatField();
			floatField9.nameAndTooltip = DebugDisplaySettings.LightingStrings.DebugOverlayScreenRatio;
			floatField9.getter = (() => this.data.debugOverlayRatio);
			floatField9.setter = delegate(float v)
			{
				this.data.debugOverlayRatio = v;
			};
			floatField9.min = (() => 0.1f);
			floatField9.max = (() => 1f);
			list10.Add(floatField9);
			this.m_DebugLightingItems = list.ToArray();
			DebugManager.instance.GetPanel(DebugDisplaySettings.k_PanelLighting, true, 0, false).children.Add(this.m_DebugLightingItems);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00009410 File Offset: 0x00007610
		private void RegisterRenderingDebug()
		{
			List<DebugUI.Widget> list = new List<DebugUI.Widget>();
			list.Add(this.CreateMissingDebugShadersWarning());
			list.Add(new DebugUI.EnumField
			{
				nameAndTooltip = DebugDisplaySettings.RenderingStrings.FullscreenDebugMode,
				getter = (() => (int)this.data.fullScreenDebugMode),
				setter = delegate(int value)
				{
					this.SetFullScreenDebugMode((FullScreenDebugMode)value);
				},
				enumNames = DebugDisplaySettings.s_RenderingFullScreenDebugStrings,
				enumValues = DebugDisplaySettings.s_RenderingFullScreenDebugValues,
				getIndex = (() => this.data.renderingFulscreenDebugModeEnumIndex),
				setIndex = delegate(int value)
				{
					this.data.ResetExclusiveEnumIndices();
					this.data.renderingFulscreenDebugModeEnumIndex = value;
				}
			});
			List<DebugUI.Widget> list2 = list;
			DebugUI.Container container = new DebugUI.Container();
			container.isHiddenCallback = (() => this.data.fullScreenDebugMode != FullScreenDebugMode.TransparencyOverdraw);
			ObservableList<DebugUI.Widget> children = container.children;
			DebugUI.FloatField floatField = new DebugUI.FloatField();
			floatField.nameAndTooltip = DebugDisplaySettings.RenderingStrings.MaxOverdrawCount;
			floatField.getter = (() => this.data.transparencyDebugSettings.maxPixelCost);
			floatField.setter = delegate(float value)
			{
				this.data.transparencyDebugSettings.maxPixelCost = value;
			};
			floatField.min = (() => 0.25f);
			floatField.max = (() => 2048f);
			children.Add(floatField);
			list2.Add(container);
			List<DebugUI.Widget> list3 = list;
			DebugUI.Container container2 = new DebugUI.Container();
			container2.isHiddenCallback = (() => this.data.fullScreenDebugMode != FullScreenDebugMode.QuadOverdraw);
			ObservableList<DebugUI.Widget> children2 = container2.children;
			DebugUI.UIntField uintField = new DebugUI.UIntField();
			uintField.nameAndTooltip = DebugDisplaySettings.RenderingStrings.MaxQuadCost;
			uintField.getter = (() => this.data.maxQuadCost);
			uintField.setter = delegate(uint value)
			{
				this.data.maxQuadCost = value;
			};
			uintField.min = (() => 1U);
			uintField.max = (() => 10U);
			children2.Add(uintField);
			list3.Add(container2);
			List<DebugUI.Widget> list4 = list;
			DebugUI.Container container3 = new DebugUI.Container();
			container3.isHiddenCallback = (() => this.data.fullScreenDebugMode != FullScreenDebugMode.VertexDensity);
			ObservableList<DebugUI.Widget> children3 = container3.children;
			DebugUI.UIntField uintField2 = new DebugUI.UIntField();
			uintField2.nameAndTooltip = DebugDisplaySettings.RenderingStrings.MaxVertexDensity;
			uintField2.getter = (() => this.data.maxVertexDensity);
			uintField2.setter = delegate(uint value)
			{
				this.data.maxVertexDensity = value;
			};
			uintField2.min = (() => 1U);
			uintField2.max = (() => 100U);
			children3.Add(uintField2);
			list4.Add(container3);
			List<DebugUI.Widget> list5 = list;
			DebugUI.Container container4 = new DebugUI.Container();
			container4.isHiddenCallback = (() => this.data.fullScreenDebugMode != FullScreenDebugMode.MotionVectors);
			ObservableList<DebugUI.Widget> children4 = container4.children;
			DebugUI.FloatField floatField2 = new DebugUI.FloatField();
			floatField2.displayName = "Min Motion Vector Length (in pixels)";
			floatField2.getter = (() => this.data.minMotionVectorLength);
			floatField2.setter = delegate(float value)
			{
				this.data.minMotionVectorLength = value;
			};
			floatField2.min = (() => 0f);
			children4.Add(floatField2);
			list5.Add(container4);
			list.AddRange(new DebugUI.Widget[]
			{
				new DebugUI.EnumField
				{
					nameAndTooltip = DebugDisplaySettings.RenderingStrings.MipMaps,
					getter = (() => (int)this.data.mipMapDebugSettings.debugMipMapMode),
					setter = delegate(int value)
					{
						this.SetMipMapMode((DebugMipMapMode)value);
					},
					autoEnum = typeof(DebugMipMapMode),
					getIndex = (() => this.data.mipMapsEnumIndex),
					setIndex = delegate(int value)
					{
						this.data.ResetExclusiveEnumIndices();
						this.data.mipMapsEnumIndex = value;
					}
				}
			});
			list.Add(new DebugUI.Container
			{
				isHiddenCallback = (() => this.data.mipMapDebugSettings.debugMipMapMode == DebugMipMapMode.None),
				children = 
				{
					new DebugUI.EnumField
					{
						nameAndTooltip = DebugDisplaySettings.RenderingStrings.TerrainTexture,
						getter = (() => (int)this.data.mipMapDebugSettings.terrainTexture),
						setter = delegate(int value)
						{
							this.data.mipMapDebugSettings.terrainTexture = (DebugMipMapModeTerrainTexture)value;
						},
						autoEnum = typeof(DebugMipMapModeTerrainTexture),
						getIndex = (() => this.data.terrainTextureEnumIndex),
						setIndex = delegate(int value)
						{
							this.data.terrainTextureEnumIndex = value;
						}
					}
				}
			});
			list.AddRange(new DebugUI.Container[]
			{
				new DebugUI.Container
				{
					displayName = "Color Picker",
					flags = DebugUI.Flags.EditorOnly,
					children = 
					{
						new DebugUI.EnumField
						{
							nameAndTooltip = DebugDisplaySettings.RenderingStrings.ColorPickerDebugMode,
							getter = (() => (int)this.data.colorPickerDebugSettings.colorPickerMode),
							setter = delegate(int value)
							{
								this.data.colorPickerDebugSettings.colorPickerMode = (ColorPickerDebugMode)value;
							},
							autoEnum = typeof(ColorPickerDebugMode),
							getIndex = (() => this.data.colorPickerDebugModeEnumIndex),
							setIndex = delegate(int value)
							{
								this.data.colorPickerDebugModeEnumIndex = value;
							}
						},
						new DebugUI.ColorField
						{
							nameAndTooltip = DebugDisplaySettings.RenderingStrings.ColorPickerFontColor,
							flags = DebugUI.Flags.EditorOnly,
							getter = (() => this.data.colorPickerDebugSettings.fontColor),
							setter = delegate(Color value)
							{
								this.data.colorPickerDebugSettings.fontColor = value;
							}
						}
					}
				}
			});
			list.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.RenderingStrings.FalseColorMode,
				getter = (() => this.data.falseColorDebugSettings.falseColor),
				setter = delegate(bool value)
				{
					this.data.falseColorDebugSettings.falseColor = value;
				}
			});
			list.Add(new DebugUI.Container
			{
				isHiddenCallback = (() => !this.data.falseColorDebugSettings.falseColor),
				flags = DebugUI.Flags.EditorOnly,
				children = 
				{
					new DebugUI.FloatField
					{
						nameAndTooltip = DebugDisplaySettings.RenderingStrings.FalseColorRangeThreshold0,
						getter = (() => this.data.falseColorDebugSettings.colorThreshold0),
						setter = delegate(float value)
						{
							this.data.falseColorDebugSettings.colorThreshold0 = Mathf.Min(value, this.data.falseColorDebugSettings.colorThreshold1);
						}
					},
					new DebugUI.FloatField
					{
						nameAndTooltip = DebugDisplaySettings.RenderingStrings.FalseColorRangeThreshold1,
						getter = (() => this.data.falseColorDebugSettings.colorThreshold1),
						setter = delegate(float value)
						{
							this.data.falseColorDebugSettings.colorThreshold1 = Mathf.Clamp(value, this.data.falseColorDebugSettings.colorThreshold0, this.data.falseColorDebugSettings.colorThreshold2);
						}
					},
					new DebugUI.FloatField
					{
						nameAndTooltip = DebugDisplaySettings.RenderingStrings.FalseColorRangeThreshold2,
						getter = (() => this.data.falseColorDebugSettings.colorThreshold2),
						setter = delegate(float value)
						{
							this.data.falseColorDebugSettings.colorThreshold2 = Mathf.Clamp(value, this.data.falseColorDebugSettings.colorThreshold1, this.data.falseColorDebugSettings.colorThreshold3);
						}
					},
					new DebugUI.FloatField
					{
						nameAndTooltip = DebugDisplaySettings.RenderingStrings.FalseColorRangeThreshold3,
						getter = (() => this.data.falseColorDebugSettings.colorThreshold3),
						setter = delegate(float value)
						{
							this.data.falseColorDebugSettings.colorThreshold3 = Mathf.Max(value, this.data.falseColorDebugSettings.colorThreshold2);
						}
					}
				}
			});
			list.AddRange(new DebugUI.Widget[]
			{
				new DebugUI.EnumField
				{
					nameAndTooltip = DebugDisplaySettings.RenderingStrings.FreezeCameraForCulling,
					getter = (() => this.data.debugCameraToFreeze),
					setter = delegate(int value)
					{
						this.data.debugCameraToFreeze = value;
					},
					enumNames = DebugDisplaySettings.s_CameraNamesStrings,
					enumValues = DebugDisplaySettings.s_CameraNamesValues,
					getIndex = (() => this.data.debugCameraToFreezeEnumIndex),
					setIndex = delegate(int value)
					{
						this.data.debugCameraToFreezeEnumIndex = value;
					}
				}
			});
			List<DebugUI.Widget> list6 = list;
			DebugUI.Container container5 = new DebugUI.Container();
			container5.displayName = "Color Monitors";
			container5.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.RenderingStrings.WaveformToggle,
				getter = (() => this.data.monitorsDebugSettings.waveformToggle),
				setter = delegate(bool value)
				{
					this.data.monitorsDebugSettings.waveformToggle = value;
				}
			});
			ObservableList<DebugUI.Widget> children5 = container5.children;
			DebugUI.Container container6 = new DebugUI.Container("WaveformContainer");
			container6.isHiddenCallback = (() => !this.data.monitorsDebugSettings.waveformToggle);
			ObservableList<DebugUI.Widget> children6 = container6.children;
			DebugUI.FloatField floatField3 = new DebugUI.FloatField();
			floatField3.nameAndTooltip = DebugDisplaySettings.RenderingStrings.WaveformExposure;
			floatField3.getter = (() => this.data.monitorsDebugSettings.waveformExposure);
			floatField3.setter = delegate(float value)
			{
				this.data.monitorsDebugSettings.waveformExposure = value;
			};
			floatField3.min = (() => 0f);
			children6.Add(floatField3);
			container6.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.RenderingStrings.WaveformParade,
				getter = (() => this.data.monitorsDebugSettings.waveformParade),
				setter = delegate(bool value)
				{
					this.data.monitorsDebugSettings.waveformParade = value;
				}
			});
			children5.Add(container6);
			container5.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.RenderingStrings.VectorscopeToggle,
				getter = (() => this.data.monitorsDebugSettings.vectorscopeToggle),
				setter = delegate(bool value)
				{
					this.data.monitorsDebugSettings.vectorscopeToggle = value;
				}
			});
			ObservableList<DebugUI.Widget> children7 = container5.children;
			DebugUI.Container container7 = new DebugUI.Container("VectorscopeContainer");
			container7.isHiddenCallback = (() => !this.data.monitorsDebugSettings.vectorscopeToggle);
			ObservableList<DebugUI.Widget> children8 = container7.children;
			DebugUI.FloatField floatField4 = new DebugUI.FloatField();
			floatField4.nameAndTooltip = DebugDisplaySettings.RenderingStrings.VectorscopeExposure;
			floatField4.getter = (() => this.data.monitorsDebugSettings.vectorscopeExposure);
			floatField4.setter = delegate(float value)
			{
				this.data.monitorsDebugSettings.vectorscopeExposure = value;
			};
			floatField4.min = (() => 0f);
			children8.Add(floatField4);
			children7.Add(container7);
			ObservableList<DebugUI.Widget> children9 = container5.children;
			DebugUI.FloatField floatField5 = new DebugUI.FloatField();
			floatField5.nameAndTooltip = DebugDisplaySettings.RenderingStrings.MonitorsSize;
			floatField5.getter = (() => this.data.monitorsDebugSettings.monitorsSize);
			floatField5.setter = delegate(float value)
			{
				this.data.monitorsDebugSettings.monitorsSize = value;
			};
			floatField5.min = (() => 0.1f);
			floatField5.max = (() => 0.8f);
			children9.Add(floatField5);
			list6.Add(container5);
			list.Add(this.nvidiaDebugView.CreateWidget());
			this.m_DebugRenderingItems = list.ToArray();
			DebugUI.Panel panel = DebugManager.instance.GetPanel(DebugDisplaySettings.k_PanelRendering, true, 0, false);
			panel.children.Add(this.m_DebugRenderingItems);
			foreach (RenderGraph renderGraph in RenderGraph.GetRegisteredRenderGraphs())
			{
				renderGraph.RegisterDebug(panel);
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00009DCC File Offset: 0x00007FCC
		private void UnregisterRenderingDebug()
		{
			this.UnregisterDebugItems(DebugDisplaySettings.k_PanelRendering, this.m_DebugRenderingItems);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00009DE0 File Offset: 0x00007FE0
		private void RegisterDecalsDebug()
		{
			DebugUI.Container container = new DebugUI.Container();
			container.displayName = "Decals Affecting Transparent Objects";
			container.children.Add(new DebugUI.BoolField
			{
				nameAndTooltip = DebugDisplaySettings.DecalStrings.DisplayAtlas,
				getter = (() => this.data.decalsDebugSettings.displayAtlas),
				setter = delegate(bool value)
				{
					this.data.decalsDebugSettings.displayAtlas = value;
				}
			});
			ObservableList<DebugUI.Widget> children = container.children;
			DebugUI.UIntField uintField = new DebugUI.UIntField();
			uintField.nameAndTooltip = DebugDisplaySettings.DecalStrings.MipLevel;
			uintField.getter = (() => this.data.decalsDebugSettings.mipLevel);
			uintField.setter = delegate(uint value)
			{
				this.data.decalsDebugSettings.mipLevel = value;
			};
			uintField.min = (() => 0U);
			uintField.max = delegate()
			{
				HDRenderPipeline hdrenderPipeline = RenderPipelineManager.currentPipeline as HDRenderPipeline;
				return (uint)((hdrenderPipeline != null) ? new int?(hdrenderPipeline.GetDecalAtlasMipCount()) : null).Value;
			};
			children.Add(uintField);
			DebugUI.Container container2 = container;
			this.m_DebugDecalsItems = new DebugUI.Widget[]
			{
				this.CreateMissingDebugShadersWarning(),
				container2
			};
			DebugManager.instance.GetPanel(DebugDisplaySettings.k_PanelDecals, true, 0, false).children.Add(this.m_DebugDecalsItems);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00009F01 File Offset: 0x00008101
		internal void RegisterDebug()
		{
			this.RegisterDecalsDebug();
			this.RegisterDisplayStatsDebug();
			this.RegisterMaterialDebug();
			this.RegisterLightingDebug();
			this.RegisterRenderingDebug();
			DebugManager.instance.RegisterData(this);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00009F2C File Offset: 0x0000812C
		internal void UnregisterDebug()
		{
			this.UnregisterDebugItems(DebugDisplaySettings.k_PanelDecals, this.m_DebugDecalsItems);
			this.UnregisterDisplayStatsDebug();
			this.UnregisterDebugItems(DebugDisplaySettings.k_PanelMaterials, this.m_DebugMaterialItems);
			this.UnregisterDebugItems(DebugDisplaySettings.k_PanelLighting, this.m_DebugLightingItems);
			this.UnregisterRenderingDebug();
			DebugManager.instance.UnregisterData(this);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00009F84 File Offset: 0x00008184
		private void UnregisterDebugItems(string panelName, DebugUI.Widget[] items)
		{
			DebugUI.Panel panel = DebugManager.instance.GetPanel(panelName, false, 0, false);
			if (panel != null)
			{
				panel.children.Remove(items);
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00009FB0 File Offset: 0x000081B0
		private void FillFullScreenDebugEnum(ref GUIContent[] strings, ref int[] values, FullScreenDebugMode min, FullScreenDebugMode max)
		{
			int num = max - min - 1;
			strings = new GUIContent[num + 1];
			values = new int[num + 1];
			strings[0] = new GUIContent(FullScreenDebugMode.None.ToString());
			values[0] = 0;
			int num2 = 1;
			for (int i = (int)(min + 1); i < (int)max; i++)
			{
				GUIContent[] array = strings;
				int num3 = num2;
				FullScreenDebugMode fullScreenDebugMode = (FullScreenDebugMode)i;
				array[num3] = new GUIContent(fullScreenDebugMode.ToString());
				values[num2] = i;
				num2++;
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000A028 File Offset: 0x00008228
		internal static void RegisterCamera(IFrameSettingsHistoryContainer container)
		{
			string name = container.panelName;
			if (DebugDisplaySettings.s_CameraNames.FindIndex((GUIContent x) => x.text.Equals(name)) < 0)
			{
				DebugDisplaySettings.s_CameraNames.Add(new GUIContent(name));
				DebugDisplaySettings.needsRefreshingCameraFreezeList = true;
			}
			if (!FrameSettingsHistory.IsRegistered(container, false))
			{
				IDebugData data = FrameSettingsHistory.RegisterDebug(container, false);
				DebugManager.instance.RegisterData(data);
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000A098 File Offset: 0x00008298
		internal static void UnRegisterCamera(IFrameSettingsHistoryContainer container)
		{
			string name = container.panelName;
			int num = DebugDisplaySettings.s_CameraNames.FindIndex((GUIContent x) => x.text.Equals(name));
			if (num > 0)
			{
				DebugDisplaySettings.s_CameraNames.RemoveAt(num);
				DebugDisplaySettings.needsRefreshingCameraFreezeList = true;
			}
			if (FrameSettingsHistory.IsRegistered(container, false))
			{
				DebugManager.instance.UnregisterData(container);
				FrameSettingsHistory.UnRegisterDebug(container);
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000A0FD File Offset: 0x000082FD
		internal bool IsDebugDisplayRemovePostprocess()
		{
			return this.data.materialDebugSettings.IsDebugDisplayEnabled() || this.data.lightingDebugSettings.IsDebugDisplayRemovePostprocess() || this.data.mipMapDebugSettings.IsDebugDisplayEnabled();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000A135 File Offset: 0x00008335
		internal void UpdateMaterials()
		{
			if (this.data.mipMapDebugSettings.debugMipMapMode != DebugMipMapMode.None)
			{
				Texture.SetStreamingTextureMaterialDebugProperties();
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000A150 File Offset: 0x00008350
		internal void UpdateCameraFreezeOptions()
		{
			if (DebugDisplaySettings.needsRefreshingCameraFreezeList)
			{
				DebugDisplaySettings.s_CameraNames.Insert(0, new GUIContent("None"));
				DebugDisplaySettings.s_CameraNamesStrings = DebugDisplaySettings.s_CameraNames.ToArray();
				DebugDisplaySettings.s_CameraNamesValues = Enumerable.Range(0, DebugDisplaySettings.s_CameraNames.Count<GUIContent>()).ToArray<int>();
				this.UnregisterRenderingDebug();
				this.RegisterRenderingDebug();
				DebugDisplaySettings.needsRefreshingCameraFreezeList = false;
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000A1B4 File Offset: 0x000083B4
		internal bool DebugHideSky(HDCamera hdCamera)
		{
			return this.IsMatcapViewEnabled(hdCamera) || this.GetDebugLightingMode() == DebugLightingMode.DiffuseLighting || this.GetDebugLightingMode() == DebugLightingMode.SpecularLighting || this.GetDebugLightingMode() == DebugLightingMode.DirectDiffuseLighting || this.GetDebugLightingMode() == DebugLightingMode.DirectSpecularLighting || this.GetDebugLightingMode() == DebugLightingMode.IndirectDiffuseLighting || this.GetDebugLightingMode() == DebugLightingMode.ReflectionLighting || this.GetDebugLightingMode() == DebugLightingMode.RefractionLighting || this.GetDebugLightingMode() == DebugLightingMode.ProbeVolumeSampledSubdivision || this.GetDebugMipMapMode() > DebugMipMapMode.None;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000A220 File Offset: 0x00008420
		internal bool DebugNeedsExposure()
		{
			DebugLightingMode debugLightingMode = this.data.lightingDebugSettings.debugLightingMode;
			DebugViewGbuffer debugViewGBuffer = (DebugViewGbuffer)this.data.materialDebugSettings.debugViewGBuffer;
			return debugLightingMode == DebugLightingMode.DirectDiffuseLighting || debugLightingMode == DebugLightingMode.DirectSpecularLighting || debugLightingMode == DebugLightingMode.IndirectDiffuseLighting || debugLightingMode == DebugLightingMode.ReflectionLighting || debugLightingMode == DebugLightingMode.RefractionLighting || debugLightingMode == DebugLightingMode.EmissiveLighting || debugLightingMode == DebugLightingMode.DiffuseLighting || debugLightingMode == DebugLightingMode.SpecularLighting || debugLightingMode == DebugLightingMode.VisualizeCascade || debugLightingMode == DebugLightingMode.ProbeVolumeSampledSubdivision || this.data.lightingDebugSettings.overrideAlbedo || this.data.lightingDebugSettings.overrideNormal || this.data.lightingDebugSettings.overrideSmoothness || this.data.lightingDebugSettings.overrideSpecularColor || this.data.lightingDebugSettings.overrideEmissiveColor || this.data.lightingDebugSettings.overrideAmbientOcclusion || debugViewGBuffer == DebugViewGbuffer.BakeDiffuseLightingWithAlbedoPlusEmissive || this.data.lightingDebugSettings.debugLightFilterMode != DebugLightFilterMode.None || this.data.fullScreenDebugMode == FullScreenDebugMode.PreRefractionColorPyramid || this.data.fullScreenDebugMode == FullScreenDebugMode.FinalColorPyramid || this.data.fullScreenDebugMode == FullScreenDebugMode.VolumetricClouds || this.data.fullScreenDebugMode == FullScreenDebugMode.TransparentScreenSpaceReflections || this.data.fullScreenDebugMode == FullScreenDebugMode.ScreenSpaceReflections || this.data.fullScreenDebugMode == FullScreenDebugMode.ScreenSpaceReflectionsPrev || this.data.fullScreenDebugMode == FullScreenDebugMode.ScreenSpaceReflectionsAccum || this.data.fullScreenDebugMode == FullScreenDebugMode.ScreenSpaceReflectionSpeedRejection || this.data.fullScreenDebugMode == FullScreenDebugMode.LightCluster || this.data.fullScreenDebugMode == FullScreenDebugMode.ScreenSpaceShadows || this.data.fullScreenDebugMode == FullScreenDebugMode.NanTracker || this.data.fullScreenDebugMode == FullScreenDebugMode.ColorLog || this.data.fullScreenDebugMode == FullScreenDebugMode.ScreenSpaceGlobalIllumination;
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x0000A3FE File Offset: 0x000085FE
		[Obsolete("Use autoenum instead @from(2022.2)")]
		public static GUIContent[] lightingFullScreenRTASDebugViewStrings
		{
			get
			{
				return (from t in Enum.GetNames(typeof(RTASDebugView))
				select new GUIContent(t)).ToArray<GUIContent>();
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x0000A438 File Offset: 0x00008638
		[Obsolete("Use autoenum instead @from(2022.2)")]
		public static int[] lightingFullScreenRTASDebugViewValues
		{
			get
			{
				return (int[])Enum.GetValues(typeof(RTASDebugView));
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x0000A44E File Offset: 0x0000864E
		[Obsolete("Use autoenum instead @from(2022.2)")]
		public static GUIContent[] lightingFullScreenRTASDebugModeStrings
		{
			get
			{
				return (from t in Enum.GetNames(typeof(RTASDebugMode))
				select new GUIContent(t)).ToArray<GUIContent>();
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x0000A488 File Offset: 0x00008688
		[Obsolete("Use autoenum instead @from(2022.2)")]
		public static int[] lightingFullScreenRTASDebugModeValues
		{
			get
			{
				return (int[])Enum.GetValues(typeof(RTASDebugMode));
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000A544 File Offset: 0x00008744
		[CompilerGenerated]
		private DebugUI.Value <BuildProfilingSamplerWidgetList>g__CreateWidgetForSampler|88_0(HDProfileId samplerId, ProfilingSampler sampler, DebugDisplaySettings.DebugProfilingType type)
		{
			Dictionary<int, DebugDisplaySettings.AccumulatedTiming> dictionary = (type == DebugDisplaySettings.DebugProfilingType.CPU) ? this.m_AccumulatedCPUTiming : ((type == DebugDisplaySettings.DebugProfilingType.InlineCPU) ? this.m_AccumulatedInlineCPUTiming : this.m_AccumulatedGPUTiming);
			if (!dictionary.ContainsKey((int)samplerId))
			{
				dictionary.Add((int)samplerId, new DebugDisplaySettings.AccumulatedTiming());
			}
			return new DebugUI.Value
			{
				formatString = "{0:F2}ms",
				refreshRate = 0.2f,
				getter = (() => this.GetSamplerTiming(samplerId, sampler, type))
			};
		}

		// Token: 0x0400013E RID: 318
		private static string k_PanelDisplayStats = "Display Stats";

		// Token: 0x0400013F RID: 319
		private static string k_PanelMaterials = "Material";

		// Token: 0x04000140 RID: 320
		private static string k_PanelLighting = "Lighting";

		// Token: 0x04000141 RID: 321
		private static string k_PanelRendering = "Rendering";

		// Token: 0x04000142 RID: 322
		private static string k_PanelDecals = "Decals";

		// Token: 0x04000143 RID: 323
		private DebugUI.Widget[] m_DebugDisplayStatsItems;

		// Token: 0x04000144 RID: 324
		private DebugUI.Widget[] m_DebugMaterialItems;

		// Token: 0x04000145 RID: 325
		private DebugUI.Widget[] m_DebugLightingItems;

		// Token: 0x04000146 RID: 326
		private DebugUI.Widget[] m_DebugRenderingItems;

		// Token: 0x04000147 RID: 327
		private DebugUI.Widget[] m_DebugDecalsItems;

		// Token: 0x04000148 RID: 328
		private static GUIContent[] s_LightingFullScreenDebugStrings = null;

		// Token: 0x04000149 RID: 329
		private static int[] s_LightingFullScreenDebugValues = null;

		// Token: 0x0400014A RID: 330
		private static GUIContent[] s_RenderingFullScreenDebugStrings = null;

		// Token: 0x0400014B RID: 331
		private static int[] s_RenderingFullScreenDebugValues = null;

		// Token: 0x0400014C RID: 332
		private static GUIContent[] s_MaterialFullScreenDebugStrings = null;

		// Token: 0x0400014D RID: 333
		private static int[] s_MaterialFullScreenDebugValues = null;

		// Token: 0x0400014E RID: 334
		private static List<GUIContent> s_CameraNames = new List<GUIContent>();

		// Token: 0x0400014F RID: 335
		private static GUIContent[] s_CameraNamesStrings = new GUIContent[]
		{
			new GUIContent("No Visible Camera")
		};

		// Token: 0x04000150 RID: 336
		private static int[] s_CameraNamesValues = new int[1];

		// Token: 0x04000151 RID: 337
		private static bool needsRefreshingCameraFreezeList = true;

		// Token: 0x04000152 RID: 338
		private List<HDProfileId> m_RecordedSamplers = new List<HDProfileId>();

		// Token: 0x04000153 RID: 339
		private Dictionary<int, DebugDisplaySettings.AccumulatedTiming> m_AccumulatedGPUTiming = new Dictionary<int, DebugDisplaySettings.AccumulatedTiming>();

		// Token: 0x04000154 RID: 340
		private Dictionary<int, DebugDisplaySettings.AccumulatedTiming> m_AccumulatedCPUTiming = new Dictionary<int, DebugDisplaySettings.AccumulatedTiming>();

		// Token: 0x04000155 RID: 341
		private Dictionary<int, DebugDisplaySettings.AccumulatedTiming> m_AccumulatedInlineCPUTiming = new Dictionary<int, DebugDisplaySettings.AccumulatedTiming>();

		// Token: 0x04000156 RID: 342
		private float m_TimeSinceLastAvgValue;

		// Token: 0x04000157 RID: 343
		private int m_AccumulatedFrames;

		// Token: 0x04000158 RID: 344
		private const float k_AccumulationTimeInSeconds = 1f;

		// Token: 0x04000159 RID: 345
		private List<HDProfileId> m_RecordedSamplersRT = new List<HDProfileId>();

		// Token: 0x0400015A RID: 346
		internal DebugFrameTiming debugFrameTiming = new DebugFrameTiming();

		// Token: 0x0400015C RID: 348
		private DebugDisplaySettings.DebugData m_Data;

		// Token: 0x02000256 RID: 598
		private class AccumulatedTiming
		{
			// Token: 0x060010B3 RID: 4275 RVA: 0x0007FDE2 File Offset: 0x0007DFE2
			internal void UpdateLastAverage(int frameCount)
			{
				this.lastAverage = this.accumulatedValue / (float)frameCount;
				this.accumulatedValue = 0f;
			}

			// Token: 0x04001A09 RID: 6665
			public float accumulatedValue;

			// Token: 0x04001A0A RID: 6666
			public float lastAverage;
		}

		// Token: 0x02000257 RID: 599
		private enum DebugProfilingType
		{
			// Token: 0x04001A0C RID: 6668
			CPU,
			// Token: 0x04001A0D RID: 6669
			GPU,
			// Token: 0x04001A0E RID: 6670
			InlineCPU
		}

		// Token: 0x02000258 RID: 600
		public class DebugData
		{
			// Token: 0x060010B5 RID: 4277 RVA: 0x0007FE06 File Offset: 0x0007E006
			public float GetDebugGlobalMipBiasOverride()
			{
				return this.m_DebugGlobalMipBiasOverride;
			}

			// Token: 0x060010B6 RID: 4278 RVA: 0x0007FE0E File Offset: 0x0007E00E
			public void SetDebugGlobalMipBiasOverride(float value)
			{
				this.m_DebugGlobalMipBiasOverride = value;
			}

			// Token: 0x060010B7 RID: 4279 RVA: 0x0007FE17 File Offset: 0x0007E017
			internal bool UseDebugGlobalMipBiasOverride()
			{
				return this.m_UseDebugGlobalMipBiasOverride;
			}

			// Token: 0x060010B8 RID: 4280 RVA: 0x0007FE1F File Offset: 0x0007E01F
			internal void SetUseDebugGlobalMipBiasOverride(bool value)
			{
				this.m_UseDebugGlobalMipBiasOverride = value;
			}

			// Token: 0x060010B9 RID: 4281 RVA: 0x0007FE28 File Offset: 0x0007E028
			internal void ResetExclusiveEnumIndices()
			{
				this.materialDebugSettings.materialEnumIndex = 0;
				this.lightingDebugModeEnumIndex = 0;
				this.mipMapsEnumIndex = 0;
				this.engineEnumIndex = 0;
				this.attributesEnumIndex = 0;
				this.propertiesEnumIndex = 0;
				this.gBufferEnumIndex = 0;
				this.lightingFulscreenDebugModeEnumIndex = 0;
				this.renderingFulscreenDebugModeEnumIndex = 0;
			}

			// Token: 0x04001A0F RID: 6671
			public float debugOverlayRatio = 0.33f;

			// Token: 0x04001A10 RID: 6672
			public FullScreenDebugMode fullScreenDebugMode;

			// Token: 0x04001A11 RID: 6673
			public bool enableDebugDepthRemap;

			// Token: 0x04001A12 RID: 6674
			public Vector4 fullScreenDebugDepthRemap = new Vector4(0f, 1f, 0f, 0f);

			// Token: 0x04001A13 RID: 6675
			public float fullscreenDebugMip;

			// Token: 0x04001A14 RID: 6676
			public int fullScreenContactShadowLightIndex;

			// Token: 0x04001A15 RID: 6677
			[Obsolete]
			public bool xrSinglePassTestMode;

			// Token: 0x04001A16 RID: 6678
			public bool averageProfilerTimingsOverASecond;

			// Token: 0x04001A17 RID: 6679
			public MaterialDebugSettings materialDebugSettings = new MaterialDebugSettings();

			// Token: 0x04001A18 RID: 6680
			public LightingDebugSettings lightingDebugSettings = new LightingDebugSettings();

			// Token: 0x04001A19 RID: 6681
			public MipMapDebugSettings mipMapDebugSettings = new MipMapDebugSettings();

			// Token: 0x04001A1A RID: 6682
			public ColorPickerDebugSettings colorPickerDebugSettings = new ColorPickerDebugSettings();

			// Token: 0x04001A1B RID: 6683
			public MonitorsDebugSettings monitorsDebugSettings = new MonitorsDebugSettings();

			// Token: 0x04001A1C RID: 6684
			public FalseColorDebugSettings falseColorDebugSettings = new FalseColorDebugSettings();

			// Token: 0x04001A1D RID: 6685
			public DecalsDebugSettings decalsDebugSettings = new DecalsDebugSettings();

			// Token: 0x04001A1E RID: 6686
			public TransparencyDebugSettings transparencyDebugSettings = new TransparencyDebugSettings();

			// Token: 0x04001A1F RID: 6687
			public uint screenSpaceShadowIndex;

			// Token: 0x04001A20 RID: 6688
			public uint maxQuadCost = 5U;

			// Token: 0x04001A21 RID: 6689
			public uint maxVertexDensity = 10U;

			// Token: 0x04001A22 RID: 6690
			public bool countRays;

			// Token: 0x04001A23 RID: 6691
			public bool showLensFlareDataDrivenOnly;

			// Token: 0x04001A24 RID: 6692
			public int debugCameraToFreeze;

			// Token: 0x04001A25 RID: 6693
			internal RTASDebugView rtasDebugView;

			// Token: 0x04001A26 RID: 6694
			internal RTASDebugMode rtasDebugMode;

			// Token: 0x04001A27 RID: 6695
			public float minMotionVectorLength;

			// Token: 0x04001A28 RID: 6696
			internal int lightingDebugModeEnumIndex;

			// Token: 0x04001A29 RID: 6697
			internal int lightingFulscreenDebugModeEnumIndex;

			// Token: 0x04001A2A RID: 6698
			internal int materialValidatorDebugModeEnumIndex;

			// Token: 0x04001A2B RID: 6699
			internal int tileClusterDebugEnumIndex;

			// Token: 0x04001A2C RID: 6700
			internal int mipMapsEnumIndex;

			// Token: 0x04001A2D RID: 6701
			internal int engineEnumIndex;

			// Token: 0x04001A2E RID: 6702
			internal int attributesEnumIndex;

			// Token: 0x04001A2F RID: 6703
			internal int propertiesEnumIndex;

			// Token: 0x04001A30 RID: 6704
			internal int gBufferEnumIndex;

			// Token: 0x04001A31 RID: 6705
			internal int shadowDebugModeEnumIndex;

			// Token: 0x04001A32 RID: 6706
			internal int tileClusterDebugByCategoryEnumIndex;

			// Token: 0x04001A33 RID: 6707
			internal int clusterDebugModeEnumIndex;

			// Token: 0x04001A34 RID: 6708
			internal int lightVolumeDebugTypeEnumIndex;

			// Token: 0x04001A35 RID: 6709
			internal int renderingFulscreenDebugModeEnumIndex;

			// Token: 0x04001A36 RID: 6710
			internal int terrainTextureEnumIndex;

			// Token: 0x04001A37 RID: 6711
			internal int colorPickerDebugModeEnumIndex;

			// Token: 0x04001A38 RID: 6712
			internal int exposureDebugModeEnumIndex;

			// Token: 0x04001A39 RID: 6713
			internal int hdrDebugModeEnumIndex;

			// Token: 0x04001A3A RID: 6714
			internal int msaaSampleDebugModeEnumIndex;

			// Token: 0x04001A3B RID: 6715
			internal int debugCameraToFreezeEnumIndex;

			// Token: 0x04001A3C RID: 6716
			internal int rtasDebugViewEnumIndex;

			// Token: 0x04001A3D RID: 6717
			internal int rtasDebugModeEnumIndex;

			// Token: 0x04001A3E RID: 6718
			private float m_DebugGlobalMipBiasOverride;

			// Token: 0x04001A3F RID: 6719
			private bool m_UseDebugGlobalMipBiasOverride;

			// Token: 0x04001A40 RID: 6720
			[Obsolete("Moved to HDDebugDisplaySettings.Instance. Will be removed soon.")]
			public IVolumeDebugSettings volumeDebugSettings = new HDVolumeDebugSettings();
		}

		// Token: 0x02000259 RID: 601
		private static class MaterialStrings
		{
			// Token: 0x04001A41 RID: 6721
			public static readonly DebugUI.Widget.NameAndTooltip CommonMaterialProperties = new DebugUI.Widget.NameAndTooltip
			{
				name = "Common Material Properties",
				tooltip = "Use the drop-down to select and debug a Material property to visualize on every GameObject on screen."
			};

			// Token: 0x04001A42 RID: 6722
			public static readonly DebugUI.Widget.NameAndTooltip Material = new DebugUI.Widget.NameAndTooltip
			{
				name = "Material",
				tooltip = "Use the drop-down to select a Material property to visualize on every GameObject on screen using a specific Shader."
			};

			// Token: 0x04001A43 RID: 6723
			public static readonly DebugUI.Widget.NameAndTooltip Engine = new DebugUI.Widget.NameAndTooltip
			{
				name = "Engine",
				tooltip = "Use the drop-down to select a Material property to visualize on every GameObject on screen that uses a specific Shader."
			};

			// Token: 0x04001A44 RID: 6724
			public static readonly DebugUI.Widget.NameAndTooltip Attributes = new DebugUI.Widget.NameAndTooltip
			{
				name = "Attributes",
				tooltip = "Use the drop-down to select a 3D GameObject attribute, like Texture Coordinates or Vertex Color, to visualize on screen."
			};

			// Token: 0x04001A45 RID: 6725
			public static readonly DebugUI.Widget.NameAndTooltip Properties = new DebugUI.Widget.NameAndTooltip
			{
				name = "Properties",
				tooltip = "Use the drop-down to select a property that the debugger uses to highlight GameObjects on screen. The debugger highlights GameObjects that use a Material with the property that you select."
			};

			// Token: 0x04001A46 RID: 6726
			public static readonly DebugUI.Widget.NameAndTooltip GBuffer = new DebugUI.Widget.NameAndTooltip
			{
				name = "GBuffer",
				tooltip = "Use the drop-down to select a property from the GBuffer to visualize for deferred Materials."
			};

			// Token: 0x04001A47 RID: 6727
			public static readonly DebugUI.Widget.NameAndTooltip MaterialValidator = new DebugUI.Widget.NameAndTooltip
			{
				name = "Material Validator",
				tooltip = "Use the drop-down to select which properties show validation colors."
			};

			// Token: 0x04001A48 RID: 6728
			public static readonly DebugUI.Widget.NameAndTooltip ValidatorTooHighColor = new DebugUI.Widget.NameAndTooltip
			{
				name = "Too High Color",
				tooltip = "Select the color that the debugger displays when a Material's diffuse color is above the acceptable PBR range."
			};

			// Token: 0x04001A49 RID: 6729
			public static readonly DebugUI.Widget.NameAndTooltip ValidatorTooLowColor = new DebugUI.Widget.NameAndTooltip
			{
				name = "Too Low Color",
				tooltip = "Select the color that the debugger displays when a Material's diffuse color is below the acceptable PBR range."
			};

			// Token: 0x04001A4A RID: 6730
			public static readonly DebugUI.Widget.NameAndTooltip ValidatorNotAPureMetalColor = new DebugUI.Widget.NameAndTooltip
			{
				name = "Not A Pure Metal Color",
				tooltip = "Select the color that the debugger displays if a pixel defined as metallic has a non-zero albedo value."
			};

			// Token: 0x04001A4B RID: 6731
			public static readonly DebugUI.Widget.NameAndTooltip ValidatorPureMetals = new DebugUI.Widget.NameAndTooltip
			{
				name = "Pure Metals",
				tooltip = "Enable to make the debugger highlight any pixels which Unity defines as metallic, but which have a non-zero albedo value."
			};

			// Token: 0x04001A4C RID: 6732
			public static readonly DebugUI.Widget.NameAndTooltip OverrideGlobalMaterialTextureMipBias = new DebugUI.Widget.NameAndTooltip
			{
				name = "Override Global Material Texture Mip Bias",
				tooltip = "Enable to override the mipmap level bias of texture samplers in material shaders."
			};

			// Token: 0x04001A4D RID: 6733
			public static readonly DebugUI.Widget.NameAndTooltip DebugGlobalMaterialTextureMipBiasValue = new DebugUI.Widget.NameAndTooltip
			{
				name = "Debug Global Material Texture Mip Bias Value",
				tooltip = "Use the slider to control the amount of mip bias of texture samplers in material shaders."
			};
		}

		// Token: 0x0200025A RID: 602
		private static class LightingStrings
		{
			// Token: 0x04001A4E RID: 6734
			public static readonly DebugUI.Widget.NameAndTooltip ShadowDebugMode = new DebugUI.Widget.NameAndTooltip
			{
				name = "Shadow Debug Mode",
				tooltip = "Use the drop-down to select which shadow debug information to overlay on the screen."
			};

			// Token: 0x04001A4F RID: 6735
			public static readonly DebugUI.Widget.NameAndTooltip ShadowDebugUseSelection = new DebugUI.Widget.NameAndTooltip
			{
				name = "Use Selection",
				tooltip = "Enable the checkbox to display the shadow map for the Light you have selected in the Scene."
			};

			// Token: 0x04001A50 RID: 6736
			public static readonly DebugUI.Widget.NameAndTooltip ShadowDebugShadowMapIndex = new DebugUI.Widget.NameAndTooltip
			{
				name = "Shadow Map Index",
				tooltip = "Use the slider to view a specific index of the shadow map. To use this property, your scene must include a Light that uses a shadow map."
			};

			// Token: 0x04001A51 RID: 6737
			public static readonly DebugUI.Widget.NameAndTooltip GlobalShadowScaleFactor = new DebugUI.Widget.NameAndTooltip
			{
				name = "Global Shadow Scale Factor",
				tooltip = "Use the slider to set the global scale that HDRP applies to the shadow rendering resolution."
			};

			// Token: 0x04001A52 RID: 6738
			public static readonly DebugUI.Widget.NameAndTooltip ClearShadowAtlas = new DebugUI.Widget.NameAndTooltip
			{
				name = "Clear Shadow Atlas",
				tooltip = "Enable the checkbox to clear the shadow atlas every frame."
			};

			// Token: 0x04001A53 RID: 6739
			public static readonly DebugUI.Widget.NameAndTooltip ShadowRangeMinimumValue = new DebugUI.Widget.NameAndTooltip
			{
				name = "Shadow Range Minimum Value",
				tooltip = "Set the minimum shadow value to display in the various shadow debug overlays."
			};

			// Token: 0x04001A54 RID: 6740
			public static readonly DebugUI.Widget.NameAndTooltip ShadowRangeMaximumValue = new DebugUI.Widget.NameAndTooltip
			{
				name = "Shadow Range Maximum Value",
				tooltip = "Set the maximum shadow value to display in the various shadow debug overlays."
			};

			// Token: 0x04001A55 RID: 6741
			public static readonly DebugUI.Widget.NameAndTooltip LogCachedShadowAtlasStatus = new DebugUI.Widget.NameAndTooltip
			{
				name = "Log Cached Shadow Atlas Status",
				tooltip = "Displays a list of the Lights currently in the cached shadow atlas in the Console."
			};

			// Token: 0x04001A56 RID: 6742
			public static readonly DebugUI.Widget.NameAndTooltip ShowLightsByType = new DebugUI.Widget.NameAndTooltip
			{
				name = "Show Lights By Type",
				tooltip = "Allows the user to enable or disable lights in the scene based on their type. This will not change the actual settings of the light."
			};

			// Token: 0x04001A57 RID: 6743
			public static readonly DebugUI.Widget.NameAndTooltip DirectionalLights = new DebugUI.Widget.NameAndTooltip
			{
				name = "Directional Lights",
				tooltip = "Temporarily enables or disables Directional Lights in your Scene."
			};

			// Token: 0x04001A58 RID: 6744
			public static readonly DebugUI.Widget.NameAndTooltip PunctualLights = new DebugUI.Widget.NameAndTooltip
			{
				name = "Punctual Lights",
				tooltip = "Temporarily enables or disables Punctual Lights in your Scene."
			};

			// Token: 0x04001A59 RID: 6745
			public static readonly DebugUI.Widget.NameAndTooltip AreaLights = new DebugUI.Widget.NameAndTooltip
			{
				name = "Area Lights",
				tooltip = "Temporarily enables or disables Area Lights in your Scene."
			};

			// Token: 0x04001A5A RID: 6746
			public static readonly DebugUI.Widget.NameAndTooltip ReflectionProbes = new DebugUI.Widget.NameAndTooltip
			{
				name = "Reflection Probes",
				tooltip = "Temporarily enables or disables Reflection Probes in your Scene."
			};

			// Token: 0x04001A5B RID: 6747
			public static readonly DebugUI.Widget.NameAndTooltip Exposure = new DebugUI.Widget.NameAndTooltip
			{
				name = "Exposure",
				tooltip = "Allows the selection of an Exposure debug mode to use."
			};

			// Token: 0x04001A5C RID: 6748
			public static readonly DebugUI.Widget.NameAndTooltip HDROutput = new DebugUI.Widget.NameAndTooltip
			{
				name = "HDR",
				tooltip = "Allows the selection of an HDR debug mode to use."
			};

			// Token: 0x04001A5D RID: 6749
			public static readonly DebugUI.Widget.NameAndTooltip HDROutputDebugMode = new DebugUI.Widget.NameAndTooltip
			{
				name = "DebugMode",
				tooltip = "Use the drop-down to select a debug mode for HDR Output."
			};

			// Token: 0x04001A5E RID: 6750
			public static readonly DebugUI.Widget.NameAndTooltip ExposureDebugMode = new DebugUI.Widget.NameAndTooltip
			{
				name = "DebugMode",
				tooltip = "Use the drop-down to select a debug mode to validate the exposure."
			};

			// Token: 0x04001A5F RID: 6751
			public static readonly DebugUI.Widget.NameAndTooltip ExposureDisplayMaskOnly = new DebugUI.Widget.NameAndTooltip
			{
				name = "Display Mask Only",
				tooltip = "Display only the metering mask in the picture-in-picture. When disabled, the mask is visible after weighting the scene color instead."
			};

			// Token: 0x04001A60 RID: 6752
			public static readonly DebugUI.Widget.NameAndTooltip ExposureShowTonemapCurve = new DebugUI.Widget.NameAndTooltip
			{
				name = "Show Tonemap Curve",
				tooltip = "Overlay the tonemap curve to the histogram debug view."
			};

			// Token: 0x04001A61 RID: 6753
			public static readonly DebugUI.Widget.NameAndTooltip DisplayHistogramSceneOverlay = new DebugUI.Widget.NameAndTooltip
			{
				name = "Show Scene Overlay",
				tooltip = "Display the scene overlay showing pixels excluded by the exposure computation via histogram."
			};

			// Token: 0x04001A62 RID: 6754
			public static readonly DebugUI.Widget.NameAndTooltip ExposureCenterAroundExposure = new DebugUI.Widget.NameAndTooltip
			{
				name = "Center Around Exposure",
				tooltip = "Center the histogram around the current exposure value."
			};

			// Token: 0x04001A63 RID: 6755
			public static readonly DebugUI.Widget.NameAndTooltip ExposureDisplayRGBHistogram = new DebugUI.Widget.NameAndTooltip
			{
				name = "Display RGB Histogram",
				tooltip = "Display the Final Image Histogram as an RGB histogram instead of just luminance."
			};

			// Token: 0x04001A64 RID: 6756
			public static readonly DebugUI.Widget.NameAndTooltip DebugExposureCompensation = new DebugUI.Widget.NameAndTooltip
			{
				name = "Debug Exposure Compensation",
				tooltip = "Set an additional exposure on top of your current exposure for debug purposes."
			};

			// Token: 0x04001A65 RID: 6757
			public static readonly DebugUI.Widget.NameAndTooltip LightingDebugMode = new DebugUI.Widget.NameAndTooltip
			{
				name = "Lighting Debug Mode",
				tooltip = "Use the drop-down to select a lighting mode to debug."
			};

			// Token: 0x04001A66 RID: 6758
			public static readonly DebugUI.Widget.NameAndTooltip LightHierarchyDebugMode = new DebugUI.Widget.NameAndTooltip
			{
				name = "Light Hierarchy Debug Mode",
				tooltip = "Use the drop-down to select a light type to show the direct lighting for or a Reflection Probe type to show the indirect lighting for."
			};

			// Token: 0x04001A67 RID: 6759
			public static readonly DebugUI.Widget.NameAndTooltip LightLayersVisualization = new DebugUI.Widget.NameAndTooltip
			{
				name = "Light Layers Visualization",
				tooltip = "Visualize the light layers of GameObjects in your Scene."
			};

			// Token: 0x04001A68 RID: 6760
			public static readonly DebugUI.Widget.NameAndTooltip LightLayersUseSelectedLight = new DebugUI.Widget.NameAndTooltip
			{
				name = "Use Selected Light",
				tooltip = "Visualize GameObjects affected by the selected light."
			};

			// Token: 0x04001A69 RID: 6761
			public static readonly DebugUI.Widget.NameAndTooltip LightLayersSwitchToLightShadowLayers = new DebugUI.Widget.NameAndTooltip
			{
				name = "Switch To Light's Shadow Layers",
				tooltip = "Visualize GameObjects that cast shadows for the selected light."
			};

			// Token: 0x04001A6A RID: 6762
			public static readonly DebugUI.Widget.NameAndTooltip LightLayersFilterLayers = new DebugUI.Widget.NameAndTooltip
			{
				name = "Filter Layers",
				tooltip = "Use the drop-down to filter light layers that you want to visialize."
			};

			// Token: 0x04001A6B RID: 6763
			public static readonly DebugUI.Widget.NameAndTooltip LightLayersColor = new DebugUI.Widget.NameAndTooltip
			{
				name = "Layers Color",
				tooltip = "Select the display color of each light layer."
			};

			// Token: 0x04001A6C RID: 6764
			public static readonly DebugUI.Widget.NameAndTooltip OverrideSmoothness = new DebugUI.Widget.NameAndTooltip
			{
				name = "Override Smoothness",
				tooltip = "Enable the checkbox to override the smoothness for the entire Scene."
			};

			// Token: 0x04001A6D RID: 6765
			public static readonly DebugUI.Widget.NameAndTooltip OverrideAlbedo = new DebugUI.Widget.NameAndTooltip
			{
				name = "Override Albedo",
				tooltip = "Enable the checkbox to override the albedo for the entire Scene."
			};

			// Token: 0x04001A6E RID: 6766
			public static readonly DebugUI.Widget.NameAndTooltip OverrideNormal = new DebugUI.Widget.NameAndTooltip
			{
				name = "Override Normal",
				tooltip = "Enable the checkbox to override the normals for the entire Scene with object normals for lighting debug."
			};

			// Token: 0x04001A6F RID: 6767
			public static readonly DebugUI.Widget.NameAndTooltip OverrideSpecularColor = new DebugUI.Widget.NameAndTooltip
			{
				name = "Override Specular Color",
				tooltip = "Enable the checkbox to override the specular color for the entire Scene."
			};

			// Token: 0x04001A70 RID: 6768
			public static readonly DebugUI.Widget.NameAndTooltip OverrideAmbientOcclusion = new DebugUI.Widget.NameAndTooltip
			{
				name = "Override Ambient Occlusion",
				tooltip = "Enable the checkbox to override the ambient occlusion for the entire Scene."
			};

			// Token: 0x04001A71 RID: 6769
			public static readonly DebugUI.Widget.NameAndTooltip OverrideEmissiveColor = new DebugUI.Widget.NameAndTooltip
			{
				name = "Override Emissive Color",
				tooltip = "Enable the checkbox to override the emissive color for the entire Scene."
			};

			// Token: 0x04001A72 RID: 6770
			public static readonly DebugUI.Widget.NameAndTooltip Smoothness = new DebugUI.Widget.NameAndTooltip
			{
				name = "Smoothness",
				tooltip = "Use the slider to set the smoothness override value that HDRP uses for the entire Scene."
			};

			// Token: 0x04001A73 RID: 6771
			public static readonly DebugUI.Widget.NameAndTooltip Albedo = new DebugUI.Widget.NameAndTooltip
			{
				name = "Albedo",
				tooltip = "Use the color picker to set the albedo color that HDRP uses for the entire Scene."
			};

			// Token: 0x04001A74 RID: 6772
			public static readonly DebugUI.Widget.NameAndTooltip SpecularColor = new DebugUI.Widget.NameAndTooltip
			{
				name = "Specular Color",
				tooltip = "Use the color picker to set the specular color that HDRP uses for the entire Scene."
			};

			// Token: 0x04001A75 RID: 6773
			public static readonly DebugUI.Widget.NameAndTooltip AmbientOcclusion = new DebugUI.Widget.NameAndTooltip
			{
				name = "Ambient Occlusion",
				tooltip = "Use the slider to set the Ambient Occlusion override value that HDRP uses for the entire Scene."
			};

			// Token: 0x04001A76 RID: 6774
			public static readonly DebugUI.Widget.NameAndTooltip EmissiveColor = new DebugUI.Widget.NameAndTooltip
			{
				name = "Emissive Color",
				tooltip = "Use the color picker to set the emissive color that HDRP uses for the entire Scene."
			};

			// Token: 0x04001A77 RID: 6775
			public static readonly DebugUI.Widget.NameAndTooltip FullscreenDebugMode = new DebugUI.Widget.NameAndTooltip
			{
				name = "Fullscreen Debug Mode",
				tooltip = "Use the drop-down to select a rendering mode to display as an overlay on the screen."
			};

			// Token: 0x04001A78 RID: 6776
			public static readonly DebugUI.Widget.NameAndTooltip ScreenSpaceShadowIndex = new DebugUI.Widget.NameAndTooltip
			{
				name = "Screen Space Shadow Index",
				tooltip = "Select the index of the screen space shadows to view with the slider. There must be a Light in the scene that uses Screen Space Shadows."
			};

			// Token: 0x04001A79 RID: 6777
			public static readonly DebugUI.Widget.NameAndTooltip DepthPyramidDebugMip = new DebugUI.Widget.NameAndTooltip
			{
				name = "Debug Mip",
				tooltip = "Enable to view a lower-resolution mipmap."
			};

			// Token: 0x04001A7A RID: 6778
			public static readonly DebugUI.Widget.NameAndTooltip DepthPyramidEnableRemap = new DebugUI.Widget.NameAndTooltip
			{
				name = "Enable Depth Remap",
				tooltip = "Enable remapping of displayed depth values for better vizualization."
			};

			// Token: 0x04001A7B RID: 6779
			public static readonly DebugUI.Widget.NameAndTooltip DepthPyramidRangeMin = new DebugUI.Widget.NameAndTooltip
			{
				name = "Depth Range Min Value",
				tooltip = "Distance at which depth values remap starts (0 is near plane, 1 is far plane)"
			};

			// Token: 0x04001A7C RID: 6780
			public static readonly DebugUI.Widget.NameAndTooltip DepthPyramidRangeMax = new DebugUI.Widget.NameAndTooltip
			{
				name = "Depth Range Max Value",
				tooltip = "Distance at which depth values remap ends (0 is near plane, 1 is far plane)"
			};

			// Token: 0x04001A7D RID: 6781
			public static readonly DebugUI.Widget.NameAndTooltip ContactShadowsLightIndex = new DebugUI.Widget.NameAndTooltip
			{
				name = "Light Index",
				tooltip = "Enable to display Contact shadows for each Light individually."
			};

			// Token: 0x04001A7E RID: 6782
			public static readonly DebugUI.Widget.NameAndTooltip RTASDebugView = new DebugUI.Widget.NameAndTooltip
			{
				name = "Ray Tracing Acceleration Structure View",
				tooltip = "Use the drop-down to select a rendering view to display the ray tracing acceleration structure."
			};

			// Token: 0x04001A7F RID: 6783
			public static readonly DebugUI.Widget.NameAndTooltip RTASDebugMode = new DebugUI.Widget.NameAndTooltip
			{
				name = "Ray Tracing Acceleration Structure Mode",
				tooltip = "Use the drop-down to select a rendering mode to display the ray tracing acceleration structure."
			};

			// Token: 0x04001A80 RID: 6784
			public static readonly DebugUI.Widget.NameAndTooltip TileClusterDebug = new DebugUI.Widget.NameAndTooltip
			{
				name = "Tile/Cluster Debug",
				tooltip = "Use the drop-down to select the Light type that you want to show the Tile/Cluster debug information for."
			};

			// Token: 0x04001A81 RID: 6785
			public static readonly DebugUI.Widget.NameAndTooltip TileClusterDebugByCategory = new DebugUI.Widget.NameAndTooltip
			{
				name = "Tile/Cluster Debug By Category",
				tooltip = "Use the drop-down to select the visualization mode for the cluster."
			};

			// Token: 0x04001A82 RID: 6786
			public static readonly DebugUI.Widget.NameAndTooltip ClusterDebugMode = new DebugUI.Widget.NameAndTooltip
			{
				name = "Cluster Debug Mode",
				tooltip = "Select the debug visualization mode for the Cluster."
			};

			// Token: 0x04001A83 RID: 6787
			public static readonly DebugUI.Widget.NameAndTooltip ClusterDistance = new DebugUI.Widget.NameAndTooltip
			{
				name = "Cluster Distance",
				tooltip = "Set the distance from the camera that HDRP displays the Cluster slice."
			};

			// Token: 0x04001A84 RID: 6788
			public static readonly DebugUI.Widget.NameAndTooltip DisplaySkyReflection = new DebugUI.Widget.NameAndTooltip
			{
				name = "Display Sky Reflection",
				tooltip = "Enable the checkbox to display an overlay of the cube map that the current sky generates and HDRP uses for lighting."
			};

			// Token: 0x04001A85 RID: 6789
			public static readonly DebugUI.Widget.NameAndTooltip SkyReflectionMipmap = new DebugUI.Widget.NameAndTooltip
			{
				name = "Sky Reflection Mipmap",
				tooltip = "Use the slider to set the mipmap level of the sky reflection cubemap. Use this to view the sky reflection cubemap's different mipmap levels."
			};

			// Token: 0x04001A86 RID: 6790
			public static readonly DebugUI.Widget.NameAndTooltip DisplayLightVolumes = new DebugUI.Widget.NameAndTooltip
			{
				name = "Display Light Volumes",
				tooltip = "Enable the checkbox to show an overlay of all light bounding volumes."
			};

			// Token: 0x04001A87 RID: 6791
			public static readonly DebugUI.Widget.NameAndTooltip LightVolumeDebugType = new DebugUI.Widget.NameAndTooltip
			{
				name = "Light Volume Debug Type",
				tooltip = "Use the drop-down to select the method HDRP uses to display the light volumes."
			};

			// Token: 0x04001A88 RID: 6792
			public static readonly DebugUI.Widget.NameAndTooltip MaxDebugLightCount = new DebugUI.Widget.NameAndTooltip
			{
				name = "Max Debug Light Count",
				tooltip = "Use this property to change the maximum acceptable number of lights for your application and still see areas in red."
			};

			// Token: 0x04001A89 RID: 6793
			public static readonly DebugUI.Widget.NameAndTooltip DisplayCookieAtlas = new DebugUI.Widget.NameAndTooltip
			{
				name = "Display Cookie Atlas",
				tooltip = "Enable the checkbox to display an overlay of the cookie atlas."
			};

			// Token: 0x04001A8A RID: 6794
			public static readonly DebugUI.Widget.NameAndTooltip CookieAtlasMipLevel = new DebugUI.Widget.NameAndTooltip
			{
				name = "Mip Level",
				tooltip = "Use the slider to set the mipmap level of the cookie atlas."
			};

			// Token: 0x04001A8B RID: 6795
			public static readonly DebugUI.Widget.NameAndTooltip ClearCookieAtlas = new DebugUI.Widget.NameAndTooltip
			{
				name = "Clear Cookie Atlas",
				tooltip = "Enable to clear the cookie atlas at each frame."
			};

			// Token: 0x04001A8C RID: 6796
			public static readonly DebugUI.Widget.NameAndTooltip DisplayReflectionProbeAtlas = new DebugUI.Widget.NameAndTooltip
			{
				name = "Display Reflection Probe Atlas",
				tooltip = "Enable the checkbox to display an overlay of the reflection probe atlas."
			};

			// Token: 0x04001A8D RID: 6797
			public static readonly DebugUI.Widget.NameAndTooltip ReflectionProbeAtlasMipLevel = new DebugUI.Widget.NameAndTooltip
			{
				name = "Mip Level",
				tooltip = "Use the slider to set the mipmap level of the reflection probe atlas."
			};

			// Token: 0x04001A8E RID: 6798
			public static readonly DebugUI.Widget.NameAndTooltip ReflectionProbeAtlasSlice = new DebugUI.Widget.NameAndTooltip
			{
				name = "Slice",
				tooltip = "Use the slider to set the slice of the reflection probe atlas."
			};

			// Token: 0x04001A8F RID: 6799
			public static readonly DebugUI.Widget.NameAndTooltip ReflectionProbeApplyExposure = new DebugUI.Widget.NameAndTooltip
			{
				name = "Apply Exposure",
				tooltip = "Apply exposure to displayed atlas."
			};

			// Token: 0x04001A90 RID: 6800
			public static readonly DebugUI.Widget.NameAndTooltip ClearReflectionProbeAtlas = new DebugUI.Widget.NameAndTooltip
			{
				name = "Clear Reflection Probe Atlas",
				tooltip = "Enable to clear the reflection probe atlas each frame."
			};

			// Token: 0x04001A91 RID: 6801
			public static readonly DebugUI.Widget.NameAndTooltip DebugOverlayScreenRatio = new DebugUI.Widget.NameAndTooltip
			{
				name = "Debug Overlay Screen Ratio",
				tooltip = "Set the size of the debug overlay textures with a ratio of the screen size."
			};
		}

		// Token: 0x0200025B RID: 603
		private static class RenderingStrings
		{
			// Token: 0x04001A92 RID: 6802
			public static readonly DebugUI.Widget.NameAndTooltip FullscreenDebugMode = new DebugUI.Widget.NameAndTooltip
			{
				name = "Fullscreen Debug Mode",
				tooltip = "Use the drop-down to select a rendering mode to display as an overlay on the screen."
			};

			// Token: 0x04001A93 RID: 6803
			public static readonly DebugUI.Widget.NameAndTooltip MaxOverdrawCount = new DebugUI.Widget.NameAndTooltip
			{
				name = "Max Overdraw Count",
				tooltip = "Maximum overdraw count allowed for a single pixel."
			};

			// Token: 0x04001A94 RID: 6804
			public static readonly DebugUI.Widget.NameAndTooltip MaxQuadCost = new DebugUI.Widget.NameAndTooltip
			{
				name = "Max Quad Cost",
				tooltip = "The scale of the quad mode overdraw heat map."
			};

			// Token: 0x04001A95 RID: 6805
			public static readonly DebugUI.Widget.NameAndTooltip MaxVertexDensity = new DebugUI.Widget.NameAndTooltip
			{
				name = "Max Vertex Density",
				tooltip = "The scale of the vertex density mode overdraw heat map."
			};

			// Token: 0x04001A96 RID: 6806
			public static readonly DebugUI.Widget.NameAndTooltip MipMaps = new DebugUI.Widget.NameAndTooltip
			{
				name = "Mip Maps",
				tooltip = "Use the drop-down to select a mipmap property to debug."
			};

			// Token: 0x04001A97 RID: 6807
			public static readonly DebugUI.Widget.NameAndTooltip TerrainTexture = new DebugUI.Widget.NameAndTooltip
			{
				name = "Terrain Texture",
				tooltip = "Use the drop-down to select the terrain Texture to debug the mipmap for."
			};

			// Token: 0x04001A98 RID: 6808
			public static readonly DebugUI.Widget.NameAndTooltip ColorPickerDebugMode = new DebugUI.Widget.NameAndTooltip
			{
				name = "Debug Mode",
				tooltip = "Use the drop-down to select the format of the color picker display."
			};

			// Token: 0x04001A99 RID: 6809
			public static readonly DebugUI.Widget.NameAndTooltip ColorPickerFontColor = new DebugUI.Widget.NameAndTooltip
			{
				name = "Font Color",
				tooltip = "Use the color picker to select a color for the font that the Color Picker uses for its display."
			};

			// Token: 0x04001A9A RID: 6810
			public static readonly DebugUI.Widget.NameAndTooltip FalseColorMode = new DebugUI.Widget.NameAndTooltip
			{
				name = "False Color Mode",
				tooltip = "Enable the checkbox to define intensity ranges that the debugger uses to show a color temperature gradient for the current frame."
			};

			// Token: 0x04001A9B RID: 6811
			public static readonly DebugUI.Widget.NameAndTooltip FalseColorRangeThreshold0 = new DebugUI.Widget.NameAndTooltip
			{
				name = "Range Threshold 0",
				tooltip = "Set the split for the intensity range."
			};

			// Token: 0x04001A9C RID: 6812
			public static readonly DebugUI.Widget.NameAndTooltip FalseColorRangeThreshold1 = new DebugUI.Widget.NameAndTooltip
			{
				name = "Range Threshold 1",
				tooltip = "Set the split for the intensity range."
			};

			// Token: 0x04001A9D RID: 6813
			public static readonly DebugUI.Widget.NameAndTooltip FalseColorRangeThreshold2 = new DebugUI.Widget.NameAndTooltip
			{
				name = "Range Threshold 2",
				tooltip = "Set the split for the intensity range."
			};

			// Token: 0x04001A9E RID: 6814
			public static readonly DebugUI.Widget.NameAndTooltip FalseColorRangeThreshold3 = new DebugUI.Widget.NameAndTooltip
			{
				name = "Range Threshold 3",
				tooltip = "Set the split for the intensity range."
			};

			// Token: 0x04001A9F RID: 6815
			public static readonly DebugUI.Widget.NameAndTooltip FreezeCameraForCulling = new DebugUI.Widget.NameAndTooltip
			{
				name = "Freeze Camera For Culling",
				tooltip = "Use the drop-down to select a Camera to freeze in order to check its culling. To check if the Camera's culling works correctly, freeze the Camera and move occluders around it."
			};

			// Token: 0x04001AA0 RID: 6816
			public static readonly DebugUI.Widget.NameAndTooltip MonitorsSize = new DebugUI.Widget.NameAndTooltip
			{
				name = "Size",
				tooltip = "Sets the size ratio of the displayed monitors"
			};

			// Token: 0x04001AA1 RID: 6817
			public static readonly DebugUI.Widget.NameAndTooltip WaveformToggle = new DebugUI.Widget.NameAndTooltip
			{
				name = "Waveform",
				tooltip = "Toggles the waveform monitor, displaying the full range of luma information in the render."
			};

			// Token: 0x04001AA2 RID: 6818
			public static readonly DebugUI.Widget.NameAndTooltip WaveformExposure = new DebugUI.Widget.NameAndTooltip
			{
				name = "Exposure",
				tooltip = "Set the exposure of the waveform monitor."
			};

			// Token: 0x04001AA3 RID: 6819
			public static readonly DebugUI.Widget.NameAndTooltip WaveformParade = new DebugUI.Widget.NameAndTooltip
			{
				name = "Parade mode",
				tooltip = "Toggles the parade mode of the waveform monitor, splitting the waveform into the red, green and blue channels separately."
			};

			// Token: 0x04001AA4 RID: 6820
			public static readonly DebugUI.Widget.NameAndTooltip VectorscopeToggle = new DebugUI.Widget.NameAndTooltip
			{
				name = "Vectorscope",
				tooltip = "Toggles the vectorscope monitor, allowing to measure the overall range of hue and saturation within the image."
			};

			// Token: 0x04001AA5 RID: 6821
			public static readonly DebugUI.Widget.NameAndTooltip VectorscopeExposure = new DebugUI.Widget.NameAndTooltip
			{
				name = "Exposure",
				tooltip = "Set the exposure of the vectorscope monitor."
			};
		}

		// Token: 0x0200025C RID: 604
		private static class DecalStrings
		{
			// Token: 0x04001AA6 RID: 6822
			public static readonly DebugUI.Widget.NameAndTooltip DisplayAtlas = new DebugUI.Widget.NameAndTooltip
			{
				name = "Display Atlas",
				tooltip = "Enable the checkbox to debug and display the decal atlas for a Camera in the top left of that Camera's view."
			};

			// Token: 0x04001AA7 RID: 6823
			public static readonly DebugUI.Widget.NameAndTooltip MipLevel = new DebugUI.Widget.NameAndTooltip
			{
				name = "Mip Level",
				tooltip = "Use the slider to select the mip level for the decal atlas."
			};
		}
	}
}
