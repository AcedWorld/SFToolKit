using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.RenderGraphModule;
using UnityEngine.NVIDIA;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001A1 RID: 417
	internal class DLSSPass
	{
		// Token: 0x06000D18 RID: 3352 RVA: 0x0006B030 File Offset: 0x00069230
		public static DLSSPass.ViewResources GetViewResources(in DLSSPass.ViewResourceHandles handles)
		{
			DLSSPass.ViewResources result = new DLSSPass.ViewResources
			{
				source = handles.source,
				output = handles.output,
				depth = handles.depth,
				motionVectors = handles.motionVectors
			};
			TextureHandle biasColorMask = handles.biasColorMask;
			result.biasColorMask = (biasColorMask.IsValid() ? handles.biasColorMask : null);
			return result;
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x0006B0B8 File Offset: 0x000692B8
		public static DLSSPass.CameraResourcesHandles CreateCameraResources(HDCamera camera, RenderGraph renderGraph, RenderGraphBuilder builder, in DLSSPass.ViewResourceHandles resources)
		{
			DLSSPass.<>c__DisplayClass3_0 CS$<>8__locals1;
			CS$<>8__locals1.renderGraph = renderGraph;
			CS$<>8__locals1.builder = builder;
			DLSSPass.CameraResourcesHandles cameraResourcesHandles = new DLSSPass.CameraResourcesHandles
			{
				resources = resources,
				copyToViews = (camera.xr.enabled && camera.xr.singlePassEnabled && camera.xr.viewCount > 1)
			};
			if (cameraResourcesHandles.copyToViews)
			{
				DLSSPass.<CreateCameraResources>g__CreateCopyNoXR|3_1(resources, out cameraResourcesHandles.tmpView0, ref CS$<>8__locals1);
				DLSSPass.<CreateCameraResources>g__CreateCopyNoXR|3_1(resources, out cameraResourcesHandles.tmpView1, ref CS$<>8__locals1);
			}
			return cameraResourcesHandles;
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x0006B144 File Offset: 0x00069344
		public static DLSSPass.CameraResources GetCameraResources(in DLSSPass.CameraResourcesHandles handles)
		{
			DLSSPass.CameraResources cameraResources = new DLSSPass.CameraResources
			{
				resources = DLSSPass.GetViewResources(handles.resources),
				copyToViews = handles.copyToViews
			};
			if (cameraResources.copyToViews)
			{
				cameraResources.tmpView0 = DLSSPass.GetViewResources(handles.tmpView0);
				cameraResources.tmpView1 = DLSSPass.GetViewResources(handles.tmpView1);
			}
			return cameraResources;
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x0006B1A8 File Offset: 0x000693A8
		public static bool SetupFeature(HDRenderPipelineGlobalSettings pipelineSettings = null)
		{
			if (!NVUnityPlugin.IsLoaded())
			{
				return false;
			}
			if (DLSSPass.s_ExpectedDeviceVersion != GraphicsDevice.version)
			{
				Debug.LogWarning("Cannot instantiate NVIDIA device because the version HDRP expects does not match the backend version.");
				return false;
			}
			if (!SystemInfo.graphicsDeviceVendor.ToLowerInvariant().Contains("nvidia"))
			{
				return false;
			}
			GraphicsDevice graphicsDevice;
			if (pipelineSettings != null && pipelineSettings.useDLSSCustomProjectId)
			{
				graphicsDevice = GraphicsDevice.CreateGraphicsDevice(pipelineSettings.DLSSProjectId);
			}
			else
			{
				graphicsDevice = GraphicsDevice.CreateGraphicsDevice();
			}
			return graphicsDevice != null && graphicsDevice.IsFeatureAvailable(GraphicsDeviceFeature.DLSS);
		}

		// Token: 0x06000D1C RID: 3356 RVA: 0x0006B221 File Offset: 0x00069421
		public static DLSSPass Create(HDRenderPipelineGlobalSettings pipelineSettings = null)
		{
			if (!DLSSPass.SetupFeature(pipelineSettings))
			{
				return null;
			}
			return new DLSSPass(GraphicsDevice.device);
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x0006B237 File Offset: 0x00069437
		public void BeginFrame(HDCamera hdCamera)
		{
			this.InternalNVIDIABeginFrame(hdCamera);
		}

		// Token: 0x06000D1E RID: 3358 RVA: 0x0006B240 File Offset: 0x00069440
		public void SetupDRSScaling(bool enableAutomaticSettings, Camera camera, XRPass xrPass, ref GlobalDynamicResolutionSettings dynamicResolutionSettings)
		{
			this.InternalNVIDIASetupDRSScaling(enableAutomaticSettings, camera, xrPass, ref dynamicResolutionSettings);
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x0006B24D File Offset: 0x0006944D
		public void Render(DLSSPass.Parameters parameters, DLSSPass.CameraResources resources, CommandBuffer cmdBuffer)
		{
			this.InternalNVIDIARender(parameters, resources, cmdBuffer);
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x0006B259 File Offset: 0x00069459
		private DLSSPass(GraphicsDevice device)
		{
			this.m_Device = device;
		}

		// Token: 0x06000D21 RID: 3361 RVA: 0x0006B28C File Offset: 0x0006948C
		private static bool IsOptimalSettingsValid(in OptimalDLSSSettingsData optimalSettings)
		{
			return optimalSettings.maxHeight >= optimalSettings.minHeight && optimalSettings.maxWidth >= optimalSettings.minWidth && optimalSettings.maxWidth != 0U && optimalSettings.maxHeight != 0U && optimalSettings.minWidth != 0U && optimalSettings.minHeight > 0U;
		}

		// Token: 0x06000D22 RID: 3362 RVA: 0x0006B2D8 File Offset: 0x000694D8
		private bool HasCameraStateExpired(DLSSPass.CameraState cameraState)
		{
			return this.m_FrameId - cameraState.LastFrameId >= DLSSPass.sMaximumFrameExpiration;
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x0006B2F4 File Offset: 0x000694F4
		private void ProcessInvalidCameras()
		{
			foreach (KeyValuePair<int, DLSSPass.CameraState> keyValuePair in this.m_CameraStates)
			{
				if (!keyValuePair.Value.IsAlive() || this.HasCameraStateExpired(keyValuePair.Value))
				{
					this.m_InvalidCameraKeys.Add(keyValuePair.Key);
				}
			}
		}

		// Token: 0x06000D24 RID: 3364 RVA: 0x0006B370 File Offset: 0x00069570
		private void CleanupCameraStates()
		{
			if (this.m_InvalidCameraKeys.Count == 0)
			{
				return;
			}
			this.m_CommandBuffer.Clear();
			foreach (int key in this.m_InvalidCameraKeys)
			{
				DLSSPass.CameraState cameraState;
				if (this.m_CameraStates.TryGetValue(key, out cameraState))
				{
					cameraState.Cleanup(this.m_CommandBuffer);
					this.m_CameraStates.Remove(key);
					GenericPool<DLSSPass.CameraState>.Release(cameraState);
				}
			}
			Graphics.ExecuteCommandBuffer(this.m_CommandBuffer);
			this.m_InvalidCameraKeys.Clear();
		}

		// Token: 0x06000D25 RID: 3365 RVA: 0x0006B41C File Offset: 0x0006961C
		private unsafe void InternalNVIDIASetupDRSScaling(bool enableAutomaticSettings, Camera camera, XRPass xrPass, ref GlobalDynamicResolutionSettings dynamicResolutionSettings)
		{
			if (this.m_Device == null)
			{
				return;
			}
			int instanceID = camera.GetInstanceID();
			DLSSPass.CameraState cameraState = null;
			if (!this.m_CameraStates.TryGetValue(instanceID, out cameraState))
			{
				return;
			}
			if (cameraState.ViewStates == null || cameraState.ViewStates.Count == 0)
			{
				return;
			}
			if (cameraState.ViewStates[0].DLSSContext == null)
			{
				return;
			}
			DLSSCommandInitializationData dlsscommandInitializationData = *cameraState.ViewStates[0].DLSSContext.initData;
			DLSSQuality quality = dlsscommandInitializationData.quality;
			Rect viewport = (xrPass != null && xrPass.enabled) ? xrPass.GetViewport(0) : new Rect(camera.pixelRect.x, camera.pixelRect.y, (float)camera.pixelWidth, (float)camera.pixelHeight);
			OptimalDLSSSettingsData optimalDLSSSettingsData = default(OptimalDLSSSettingsData);
			this.m_Device.GetOptimalSettings((uint)viewport.width, (uint)viewport.height, quality, out optimalDLSSSettingsData);
			foreach (DLSSPass.ViewState viewState in cameraState.ViewStates)
			{
				if (viewState != null)
				{
					viewState.RequestUseAutomaticSettings(enableAutomaticSettings, quality, viewport, optimalDLSSSettingsData);
				}
			}
			if (enableAutomaticSettings)
			{
				if (DLSSPass.IsOptimalSettingsValid(optimalDLSSSettingsData) && enableAutomaticSettings)
				{
					dynamicResolutionSettings.maxPercentage = Mathf.Min(optimalDLSSSettingsData.maxWidth / viewport.width, optimalDLSSSettingsData.maxHeight / viewport.height) * 100f;
					dynamicResolutionSettings.minPercentage = Mathf.Max(optimalDLSSSettingsData.minWidth / viewport.width, optimalDLSSSettingsData.minHeight / viewport.height) * 100f;
					DynamicResolutionHandler.SetSystemDynamicResScaler(cameraState.ScaleDelegate, DynamicResScalePolicyType.ReturnsPercentage);
					DynamicResolutionHandler.SetActiveDynamicScalerSlot(DynamicResScalerSlot.System);
					return;
				}
			}
			else
			{
				cameraState.ClearAutomaticSettings();
			}
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x0006B5F0 File Offset: 0x000697F0
		private void InternalNVIDIABeginFrame(HDCamera hdCamera)
		{
			if (this.m_Device == null)
			{
				return;
			}
			this.ProcessInvalidCameras();
			int instanceID = hdCamera.camera.GetInstanceID();
			DLSSPass.CameraState cameraState = null;
			this.m_CameraStates.TryGetValue(instanceID, out cameraState);
			bool flag = hdCamera.IsDLSSEnabled();
			if (cameraState == null && flag)
			{
				cameraState = GenericPool<DLSSPass.CameraState>.Get();
				cameraState.Init(this.m_Device, hdCamera.camera);
				this.m_CameraStates.Add(instanceID, cameraState);
			}
			else if (cameraState != null && !flag)
			{
				this.m_InvalidCameraKeys.Add(instanceID);
			}
			if (cameraState != null)
			{
				cameraState.LastFrameId = this.m_FrameId;
			}
			this.CleanupCameraStates();
			this.m_FrameId += 1UL;
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x0006B698 File Offset: 0x00069898
		private void InternalNVIDIARender(in DLSSPass.Parameters parameters, DLSSPass.CameraResources resources, CommandBuffer cmdBuffer)
		{
			if (this.m_Device == null || this.m_CameraStates.Count == 0)
			{
				return;
			}
			DLSSPass.CameraState cameraState;
			if (!this.m_CameraStates.TryGetValue(parameters.hdCamera.camera.GetInstanceID(), out cameraState))
			{
				return;
			}
			DLSSPass.DlssViewData dlssViewData = default(DLSSPass.DlssViewData);
			dlssViewData.perfQuality = (DLSSQuality)(parameters.hdCamera.deepLearningSuperSamplingUseCustomQualitySettings ? parameters.hdCamera.deepLearningSuperSamplingQuality : parameters.drsSettings.DLSSPerfQualitySetting);
			dlssViewData.sharpness = (parameters.hdCamera.deepLearningSuperSamplingUseCustomAttributes ? parameters.hdCamera.deepLearningSuperSamplingSharpening : parameters.drsSettings.DLSSSharpness);
			dlssViewData.inputRes = new DLSSPass.Resolution
			{
				width = (uint)parameters.hdCamera.actualWidth,
				height = (uint)parameters.hdCamera.actualHeight
			};
			dlssViewData.outputRes = new DLSSPass.Resolution
			{
				width = (uint)DynamicResolutionHandler.instance.finalViewport.x,
				height = (uint)DynamicResolutionHandler.instance.finalViewport.y
			};
			dlssViewData.jitterX = -parameters.hdCamera.taaJitter.x;
			dlssViewData.jitterY = -parameters.hdCamera.taaJitter.y;
			dlssViewData.reset = parameters.resetHistory;
			cameraState.SubmitCommands(parameters.hdCamera, parameters.preExposure, dlssViewData, resources, cmdBuffer);
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x0006B818 File Offset: 0x00069A18
		[CompilerGenerated]
		internal static TextureHandle <CreateCameraResources>g__GetTmpViewXrTex|3_0(in TextureHandle handle, ref DLSSPass.<>c__DisplayClass3_0 A_1)
		{
			TextureHandle textureHandle = handle;
			if (!textureHandle.IsValid())
			{
				return TextureHandle.nullHandle;
			}
			TextureDesc textureDesc = A_1.renderGraph.GetTextureDesc(handle);
			textureDesc.slices = 1;
			textureDesc.dimension = TextureDimension.Tex2D;
			return A_1.renderGraph.CreateTexture(textureDesc);
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x0006B86C File Offset: 0x00069A6C
		[CompilerGenerated]
		internal static void <CreateCameraResources>g__CreateCopyNoXR|3_1(in DLSSPass.ViewResourceHandles input, out DLSSPass.ViewResourceHandles newResources, ref DLSSPass.<>c__DisplayClass3_0 A_2)
		{
			newResources.source = DLSSPass.<CreateCameraResources>g__GetTmpViewXrTex|3_0(input.source, ref A_2);
			newResources.output = DLSSPass.<CreateCameraResources>g__GetTmpViewXrTex|3_0(input.output, ref A_2);
			newResources.depth = DLSSPass.<CreateCameraResources>g__GetTmpViewXrTex|3_0(input.depth, ref A_2);
			newResources.motionVectors = DLSSPass.<CreateCameraResources>g__GetTmpViewXrTex|3_0(input.motionVectors, ref A_2);
			newResources.biasColorMask = DLSSPass.<CreateCameraResources>g__GetTmpViewXrTex|3_0(input.biasColorMask, ref A_2);
			newResources.WriteResources(A_2.builder);
		}

		// Token: 0x04001411 RID: 5137
		private static uint s_ExpectedDeviceVersion = 4U;

		// Token: 0x04001412 RID: 5138
		private Dictionary<int, DLSSPass.CameraState> m_CameraStates = new Dictionary<int, DLSSPass.CameraState>();

		// Token: 0x04001413 RID: 5139
		private List<int> m_InvalidCameraKeys = new List<int>();

		// Token: 0x04001414 RID: 5140
		private CommandBuffer m_CommandBuffer = new CommandBuffer();

		// Token: 0x04001415 RID: 5141
		private ulong m_FrameId;

		// Token: 0x04001416 RID: 5142
		private GraphicsDevice m_Device;

		// Token: 0x04001417 RID: 5143
		private static ulong sMaximumFrameExpiration = 400UL;

		// Token: 0x020003EA RID: 1002
		public struct ViewResourceHandles
		{
			// Token: 0x0600139F RID: 5023 RVA: 0x00095A74 File Offset: 0x00093C74
			public void WriteResources(RenderGraphBuilder builder)
			{
				this.source = builder.WriteTexture(this.source);
				this.output = builder.WriteTexture(this.output);
				this.depth = builder.WriteTexture(this.depth);
				this.motionVectors = builder.WriteTexture(this.motionVectors);
				if (this.biasColorMask.IsValid())
				{
					this.biasColorMask = builder.WriteTexture(this.biasColorMask);
				}
			}

			// Token: 0x04002864 RID: 10340
			public TextureHandle source;

			// Token: 0x04002865 RID: 10341
			public TextureHandle output;

			// Token: 0x04002866 RID: 10342
			public TextureHandle depth;

			// Token: 0x04002867 RID: 10343
			public TextureHandle motionVectors;

			// Token: 0x04002868 RID: 10344
			public TextureHandle biasColorMask;
		}

		// Token: 0x020003EB RID: 1003
		public struct CameraResourcesHandles
		{
			// Token: 0x04002869 RID: 10345
			internal DLSSPass.ViewResourceHandles resources;

			// Token: 0x0400286A RID: 10346
			internal bool copyToViews;

			// Token: 0x0400286B RID: 10347
			internal DLSSPass.ViewResourceHandles tmpView0;

			// Token: 0x0400286C RID: 10348
			internal DLSSPass.ViewResourceHandles tmpView1;
		}

		// Token: 0x020003EC RID: 1004
		public struct Parameters
		{
			// Token: 0x0400286D RID: 10349
			public bool resetHistory;

			// Token: 0x0400286E RID: 10350
			public float preExposure;

			// Token: 0x0400286F RID: 10351
			public HDCamera hdCamera;

			// Token: 0x04002870 RID: 10352
			public GlobalDynamicResolutionSettings drsSettings;
		}

		// Token: 0x020003ED RID: 1005
		public struct ViewResources
		{
			// Token: 0x04002871 RID: 10353
			public Texture source;

			// Token: 0x04002872 RID: 10354
			public Texture output;

			// Token: 0x04002873 RID: 10355
			public Texture depth;

			// Token: 0x04002874 RID: 10356
			public Texture motionVectors;

			// Token: 0x04002875 RID: 10357
			public Texture biasColorMask;
		}

		// Token: 0x020003EE RID: 1006
		public struct CameraResources
		{
			// Token: 0x04002876 RID: 10358
			internal DLSSPass.ViewResources resources;

			// Token: 0x04002877 RID: 10359
			internal bool copyToViews;

			// Token: 0x04002878 RID: 10360
			internal DLSSPass.ViewResources tmpView0;

			// Token: 0x04002879 RID: 10361
			internal DLSSPass.ViewResources tmpView1;
		}

		// Token: 0x020003EF RID: 1007
		private struct Resolution
		{
			// Token: 0x060013A0 RID: 5024 RVA: 0x00095AED File Offset: 0x00093CED
			public static bool operator ==(DLSSPass.Resolution a, DLSSPass.Resolution b)
			{
				return a.width == b.width && a.height == b.height;
			}

			// Token: 0x060013A1 RID: 5025 RVA: 0x00095B0D File Offset: 0x00093D0D
			public static bool operator !=(DLSSPass.Resolution a, DLSSPass.Resolution b)
			{
				return !(a == b);
			}

			// Token: 0x060013A2 RID: 5026 RVA: 0x00095B19 File Offset: 0x00093D19
			public override bool Equals(object obj)
			{
				return obj is DLSSPass.Resolution && (DLSSPass.Resolution)obj == this;
			}

			// Token: 0x060013A3 RID: 5027 RVA: 0x00095B36 File Offset: 0x00093D36
			public override int GetHashCode()
			{
				return (int)(this.width ^ this.height);
			}

			// Token: 0x0400287A RID: 10362
			public uint width;

			// Token: 0x0400287B RID: 10363
			public uint height;
		}

		// Token: 0x020003F0 RID: 1008
		private struct DlssViewData
		{
			// Token: 0x060013A4 RID: 5028 RVA: 0x00095B45 File Offset: 0x00093D45
			public bool CanFitInput(in DLSSPass.Resolution inputRect)
			{
				return this.inputRes.width >= inputRect.width && this.inputRes.height > inputRect.height;
			}

			// Token: 0x0400287C RID: 10364
			public DLSSQuality perfQuality;

			// Token: 0x0400287D RID: 10365
			public DLSSPass.Resolution inputRes;

			// Token: 0x0400287E RID: 10366
			public DLSSPass.Resolution outputRes;

			// Token: 0x0400287F RID: 10367
			public float sharpness;

			// Token: 0x04002880 RID: 10368
			public float jitterX;

			// Token: 0x04002881 RID: 10369
			public float jitterY;

			// Token: 0x04002882 RID: 10370
			public bool reset;
		}

		// Token: 0x020003F1 RID: 1009
		private struct OptimalSettingsRequest
		{
			// Token: 0x060013A5 RID: 5029 RVA: 0x00095B70 File Offset: 0x00093D70
			public bool CanFit(DLSSPass.Resolution rect)
			{
				return rect.width >= this.optimalSettings.minWidth && rect.height >= this.optimalSettings.minHeight && rect.width <= this.optimalSettings.maxWidth && rect.height <= this.optimalSettings.maxHeight;
			}

			// Token: 0x04002883 RID: 10371
			public DLSSQuality quality;

			// Token: 0x04002884 RID: 10372
			public Rect viewport;

			// Token: 0x04002885 RID: 10373
			public OptimalDLSSSettingsData optimalSettings;
		}

		// Token: 0x020003F2 RID: 1010
		private class ViewState
		{
			// Token: 0x17000294 RID: 660
			// (get) Token: 0x060013A6 RID: 5030 RVA: 0x00095BCE File Offset: 0x00093DCE
			public DLSSContext DLSSContext
			{
				get
				{
					return this.m_DlssContext;
				}
			}

			// Token: 0x17000295 RID: 661
			// (get) Token: 0x060013A7 RID: 5031 RVA: 0x00095BD6 File Offset: 0x00093DD6
			public bool useAutomaticSettings
			{
				get
				{
					return this.m_UseAutomaticSettings;
				}
			}

			// Token: 0x17000296 RID: 662
			// (get) Token: 0x060013A8 RID: 5032 RVA: 0x00095BDE File Offset: 0x00093DDE
			public DLSSPass.OptimalSettingsRequest OptimalSettingsRequestData
			{
				get
				{
					return this.m_OptimalSettingsRequest;
				}
			}

			// Token: 0x060013AA RID: 5034 RVA: 0x00095BEE File Offset: 0x00093DEE
			public void Init(GraphicsDevice device)
			{
				this.m_Device = device;
				this.m_DlssContext = null;
			}

			// Token: 0x060013AB RID: 5035 RVA: 0x00095BFE File Offset: 0x00093DFE
			public void RequestUseAutomaticSettings(bool useAutomaticSettings, DLSSQuality quality, Rect viewport, in OptimalDLSSSettingsData optimalSettings)
			{
				this.m_UseAutomaticSettings = useAutomaticSettings;
				this.m_OptimalSettingsRequest.quality = quality;
				this.m_OptimalSettingsRequest.viewport = viewport;
				this.m_OptimalSettingsRequest.optimalSettings = optimalSettings;
			}

			// Token: 0x060013AC RID: 5036 RVA: 0x00095C31 File Offset: 0x00093E31
			public void ClearAutomaticSettings()
			{
				this.m_UseAutomaticSettings = false;
			}

			// Token: 0x060013AD RID: 5037 RVA: 0x00095C3C File Offset: 0x00093E3C
			private unsafe bool ShouldUseAutomaticSettings()
			{
				if (!this.m_UseAutomaticSettings || this.m_DlssContext == null)
				{
					return false;
				}
				DLSSCommandInitializationData dlsscommandInitializationData = *this.m_DlssContext.initData;
				if (dlsscommandInitializationData.quality == this.m_OptimalSettingsRequest.quality)
				{
					dlsscommandInitializationData = *this.m_DlssContext.initData;
					if (dlsscommandInitializationData.outputRTHeight == (uint)this.m_OptimalSettingsRequest.viewport.height)
					{
						dlsscommandInitializationData = *this.m_DlssContext.initData;
						if (dlsscommandInitializationData.outputRTWidth == (uint)this.m_OptimalSettingsRequest.viewport.width)
						{
							return DLSSPass.IsOptimalSettingsValid(this.m_OptimalSettingsRequest.optimalSettings);
						}
					}
				}
				return false;
			}

			// Token: 0x060013AE RID: 5038 RVA: 0x00095CE8 File Offset: 0x00093EE8
			public void UpdateViewState(in DLSSPass.DlssViewData viewData, CommandBuffer cmdBuffer)
			{
				if (this.m_Device == null)
				{
					return;
				}
				bool flag = this.ShouldUseAutomaticSettings();
				bool flag2 = false;
				if (viewData.outputRes != this.m_Data.outputRes || viewData.inputRes.width > this.m_BackbufferRes.width || viewData.inputRes.height > this.m_BackbufferRes.height || (viewData.inputRes != this.m_BackbufferRes && !this.m_OptimalSettingsRequest.CanFit(viewData.inputRes)) || viewData.perfQuality != this.m_Data.perfQuality || this.m_DlssContext == null || flag != this.m_UsingOptimalSettings)
				{
					flag2 = true;
					this.m_BackbufferRes = viewData.inputRes;
					if (this.m_DlssContext != null)
					{
						this.m_Device.DestroyFeature(cmdBuffer, this.m_DlssContext);
						this.m_DlssContext = null;
					}
					DLSSCommandInitializationData dlsscommandInitializationData = default(DLSSCommandInitializationData);
					dlsscommandInitializationData.SetFlag(DLSSFeatureFlags.IsHDR, true);
					dlsscommandInitializationData.SetFlag(DLSSFeatureFlags.MVLowRes, true);
					dlsscommandInitializationData.SetFlag(DLSSFeatureFlags.DepthInverted, true);
					dlsscommandInitializationData.SetFlag(DLSSFeatureFlags.DoSharpening, true);
					dlsscommandInitializationData.inputRTWidth = this.m_BackbufferRes.width;
					dlsscommandInitializationData.inputRTHeight = this.m_BackbufferRes.height;
					dlsscommandInitializationData.outputRTWidth = viewData.outputRes.width;
					dlsscommandInitializationData.outputRTHeight = viewData.outputRes.height;
					dlsscommandInitializationData.quality = viewData.perfQuality;
					this.m_UsingOptimalSettings = flag;
					this.m_DlssContext = this.m_Device.CreateFeature(cmdBuffer, dlsscommandInitializationData);
				}
				this.m_Data = viewData;
				this.m_Data.reset = (flag2 || viewData.reset);
			}

			// Token: 0x060013AF RID: 5039 RVA: 0x00095E8C File Offset: 0x0009408C
			public void SubmitDlssCommands(Texture source, Texture depth, Texture motionVectors, Texture biasColorMask, Texture output, float preExposure, CommandBuffer cmdBuffer)
			{
				if (this.m_DlssContext == null)
				{
					return;
				}
				this.m_DlssContext.executeData.sharpness = (this.m_UsingOptimalSettings ? this.m_OptimalSettingsRequest.optimalSettings.sharpness : this.m_Data.sharpness);
				this.m_DlssContext.executeData.mvScaleX = -this.m_Data.inputRes.width;
				this.m_DlssContext.executeData.mvScaleY = -this.m_Data.inputRes.height;
				this.m_DlssContext.executeData.subrectOffsetX = 0U;
				this.m_DlssContext.executeData.subrectOffsetY = 0U;
				this.m_DlssContext.executeData.subrectWidth = this.m_Data.inputRes.width;
				this.m_DlssContext.executeData.subrectHeight = this.m_Data.inputRes.height;
				this.m_DlssContext.executeData.jitterOffsetX = this.m_Data.jitterX;
				this.m_DlssContext.executeData.jitterOffsetY = this.m_Data.jitterY;
				this.m_DlssContext.executeData.preExposure = preExposure;
				this.m_DlssContext.executeData.invertYAxis = 1U;
				this.m_DlssContext.executeData.invertXAxis = 0U;
				this.m_DlssContext.executeData.reset = (this.m_Data.reset ? 1 : 0);
				DLSSTextureTable dlsstextureTable = new DLSSTextureTable
				{
					colorInput = source,
					colorOutput = output,
					depth = depth,
					motionVectors = motionVectors,
					biasColorMask = biasColorMask
				};
				this.m_Device.ExecuteDLSS(cmdBuffer, this.m_DlssContext, dlsstextureTable);
			}

			// Token: 0x060013B0 RID: 5040 RVA: 0x00096054 File Offset: 0x00094254
			public void Cleanup(CommandBuffer cmdBuffer)
			{
				if (this.m_DlssContext != null)
				{
					this.m_Device.DestroyFeature(cmdBuffer, this.m_DlssContext);
					this.m_DlssContext = null;
				}
				this.m_Device = null;
				this.m_Data = default(DLSSPass.DlssViewData);
				this.m_UsingOptimalSettings = false;
				this.m_UseAutomaticSettings = false;
				this.m_BackbufferRes = default(DLSSPass.Resolution);
				this.m_OptimalSettingsRequest = default(DLSSPass.OptimalSettingsRequest);
			}

			// Token: 0x04002886 RID: 10374
			private DLSSContext m_DlssContext;

			// Token: 0x04002887 RID: 10375
			private GraphicsDevice m_Device;

			// Token: 0x04002888 RID: 10376
			private DLSSPass.DlssViewData m_Data;

			// Token: 0x04002889 RID: 10377
			private bool m_UsingOptimalSettings;

			// Token: 0x0400288A RID: 10378
			private bool m_UseAutomaticSettings;

			// Token: 0x0400288B RID: 10379
			private DLSSPass.Resolution m_BackbufferRes;

			// Token: 0x0400288C RID: 10380
			private DLSSPass.OptimalSettingsRequest m_OptimalSettingsRequest;
		}

		// Token: 0x020003F3 RID: 1011
		private class CameraState
		{
			// Token: 0x17000297 RID: 663
			// (get) Token: 0x060013B1 RID: 5041 RVA: 0x000960BB File Offset: 0x000942BB
			public PerformDynamicRes ScaleDelegate
			{
				get
				{
					return this.m_ScaleDelegate;
				}
			}

			// Token: 0x17000298 RID: 664
			// (get) Token: 0x060013B2 RID: 5042 RVA: 0x000960C3 File Offset: 0x000942C3
			public List<DLSSPass.ViewState> ViewStates
			{
				get
				{
					return this.m_Views;
				}
			}

			// Token: 0x17000299 RID: 665
			// (get) Token: 0x060013B4 RID: 5044 RVA: 0x000960D4 File Offset: 0x000942D4
			// (set) Token: 0x060013B3 RID: 5043 RVA: 0x000960CB File Offset: 0x000942CB
			public ulong LastFrameId { get; set; }

			// Token: 0x060013B5 RID: 5045 RVA: 0x000960DC File Offset: 0x000942DC
			public CameraState()
			{
				this.m_ScaleDelegate = new PerformDynamicRes(this.ScaleFn);
			}

			// Token: 0x060013B6 RID: 5046 RVA: 0x00096102 File Offset: 0x00094302
			public void Init(GraphicsDevice device, Camera camera)
			{
				this.m_CamReference.SetTarget(camera);
				this.m_Device = device;
			}

			// Token: 0x060013B7 RID: 5047 RVA: 0x00096118 File Offset: 0x00094318
			public bool IsAlive()
			{
				Camera camera;
				return this.m_CamReference.TryGetTarget(out camera);
			}

			// Token: 0x060013B8 RID: 5048 RVA: 0x00096134 File Offset: 0x00094334
			public void ClearAutomaticSettings()
			{
				if (this.m_Views == null)
				{
					return;
				}
				foreach (DLSSPass.ViewState viewState in this.m_Views)
				{
					viewState.ClearAutomaticSettings();
				}
			}

			// Token: 0x060013B9 RID: 5049 RVA: 0x00096190 File Offset: 0x00094390
			private float ScaleFn()
			{
				if (this.m_Views == null || this.m_Views.Count == 0)
				{
					return 100f;
				}
				DLSSPass.ViewState viewState = this.m_Views[0];
				if (!viewState.useAutomaticSettings)
				{
					return 100f;
				}
				OptimalDLSSSettingsData optimalSettings = viewState.OptimalSettingsRequestData.optimalSettings;
				Rect viewport = viewState.OptimalSettingsRequestData.viewport;
				float a = optimalSettings.outRenderWidth / viewport.width;
				float b = optimalSettings.outRenderHeight / viewport.height;
				return Mathf.Min(a, b) * 100f;
			}

			// Token: 0x060013BA RID: 5050 RVA: 0x0009621C File Offset: 0x0009441C
			public void SubmitCommands(HDCamera camera, float preExposure, in DLSSPass.DlssViewData viewData, in DLSSPass.CameraResources camResources, CommandBuffer cmdBuffer)
			{
				DLSSPass.CameraState.<>c__DisplayClass17_0 CS$<>8__locals1;
				CS$<>8__locals1.preExposure = preExposure;
				int num = 1;
				int index = 0;
				if (camera.xr.enabled)
				{
					num = (camera.xr.singlePassEnabled ? camera.xr.viewCount : 2);
					index = camera.xr.multipassId;
				}
				if (this.m_Views == null || this.m_Views.Count != num)
				{
					if (this.m_Views != null)
					{
						this.Cleanup(cmdBuffer);
					}
					this.m_Views = ListPool<DLSSPass.ViewState>.Get();
					for (int i = 0; i < num; i++)
					{
						DLSSPass.ViewState viewState = GenericPool<DLSSPass.ViewState>.Get();
						viewState.Init(this.m_Device);
						this.m_Views.Add(viewState);
					}
				}
				if (camResources.copyToViews)
				{
					for (int j = 0; j < this.m_Views.Count; j++)
					{
						DLSSPass.ViewState viewState2 = this.m_Views[j];
						DLSSPass.ViewResources viewResources = (j == 0) ? camResources.tmpView0 : camResources.tmpView1;
						cmdBuffer.CopyTexture(camResources.resources.source, j, viewResources.source, 0);
						cmdBuffer.CopyTexture(camResources.resources.depth, j, viewResources.depth, 0);
						cmdBuffer.CopyTexture(camResources.resources.motionVectors, j, viewResources.motionVectors, 0);
						if (camResources.resources.biasColorMask != null)
						{
							cmdBuffer.CopyTexture(camResources.resources.biasColorMask, j, viewResources.biasColorMask, 0);
						}
					}
					for (int k = 0; k < this.m_Views.Count; k++)
					{
						DLSSPass.ViewState viewState3 = this.m_Views[k];
						DLSSPass.ViewResources viewResources2 = (k == 0) ? camResources.tmpView0 : camResources.tmpView1;
						DLSSPass.CameraState.<SubmitCommands>g__RunPass|17_0(viewState3, cmdBuffer, viewData, viewResources2, ref CS$<>8__locals1);
						cmdBuffer.CopyTexture(viewResources2.output, 0, camResources.resources.output, k);
					}
					return;
				}
				DLSSPass.CameraState.<SubmitCommands>g__RunPass|17_0(this.m_Views[index], cmdBuffer, viewData, camResources.resources, ref CS$<>8__locals1);
			}

			// Token: 0x060013BB RID: 5051 RVA: 0x00096458 File Offset: 0x00094658
			public void Cleanup(CommandBuffer cmdBuffer)
			{
				if (this.m_Views == null)
				{
					return;
				}
				foreach (DLSSPass.ViewState viewState in this.m_Views)
				{
					viewState.Cleanup(cmdBuffer);
					GenericPool<DLSSPass.ViewState>.Release(viewState);
				}
				ListPool<DLSSPass.ViewState>.Release(this.m_Views);
				this.m_Views = null;
				this.m_CamReference.SetTarget(null);
				this.m_Device = null;
			}

			// Token: 0x060013BC RID: 5052 RVA: 0x000964E0 File Offset: 0x000946E0
			[CompilerGenerated]
			internal static void <SubmitCommands>g__RunPass|17_0(DLSSPass.ViewState viewState, CommandBuffer cmdBuffer, in DLSSPass.DlssViewData viewData, in DLSSPass.ViewResources viewResources, ref DLSSPass.CameraState.<>c__DisplayClass17_0 A_4)
			{
				viewState.UpdateViewState(viewData, cmdBuffer);
				viewState.SubmitDlssCommands(viewResources.source, viewResources.depth, viewResources.motionVectors, viewResources.biasColorMask, viewResources.output, A_4.preExposure, cmdBuffer);
			}

			// Token: 0x0400288D RID: 10381
			private WeakReference<Camera> m_CamReference = new WeakReference<Camera>(null);

			// Token: 0x0400288E RID: 10382
			private List<DLSSPass.ViewState> m_Views;

			// Token: 0x0400288F RID: 10383
			private GraphicsDevice m_Device;

			// Token: 0x04002890 RID: 10384
			private PerformDynamicRes m_ScaleDelegate;
		}
	}
}
