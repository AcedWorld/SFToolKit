using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000156 RID: 342
	[DebuggerDisplay("({camera.name})")]
	public class HDCamera
	{
		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000B2E RID: 2862 RVA: 0x0005BD4A File Offset: 0x00059F4A
		// (set) Token: 0x06000B2F RID: 2863 RVA: 0x0005BD52 File Offset: 0x00059F52
		public string name { get; private set; }

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000B30 RID: 2864 RVA: 0x0005BD5B File Offset: 0x00059F5B
		public Vector4 postProcessScreenSize
		{
			get
			{
				return this.m_PostProcessScreenSize;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000B31 RID: 2865 RVA: 0x0005BD63 File Offset: 0x00059F63
		// (set) Token: 0x06000B32 RID: 2866 RVA: 0x0005BD6B File Offset: 0x00059F6B
		public int actualWidth { get; private set; }

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000B33 RID: 2867 RVA: 0x0005BD74 File Offset: 0x00059F74
		// (set) Token: 0x06000B34 RID: 2868 RVA: 0x0005BD7C File Offset: 0x00059F7C
		public int actualHeight { get; private set; }

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000B35 RID: 2869 RVA: 0x0005BD85 File Offset: 0x00059F85
		// (set) Token: 0x06000B36 RID: 2870 RVA: 0x0005BD8D File Offset: 0x00059F8D
		public MSAASamples msaaSamples { get; private set; }

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000B37 RID: 2871 RVA: 0x0005BD96 File Offset: 0x00059F96
		public bool msaaEnabled
		{
			get
			{
				return this.msaaSamples != MSAASamples.None;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000B38 RID: 2872 RVA: 0x0005BDA4 File Offset: 0x00059FA4
		// (set) Token: 0x06000B39 RID: 2873 RVA: 0x0005BDAC File Offset: 0x00059FAC
		public FrameSettings frameSettings { get; private set; }

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000B3A RID: 2874 RVA: 0x0005BDB5 File Offset: 0x00059FB5
		public RTHandleProperties historyRTHandleProperties
		{
			get
			{
				return this.m_HistoryRTSystem.rtHandleProperties;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000B3B RID: 2875 RVA: 0x0005BDC2 File Offset: 0x00059FC2
		// (set) Token: 0x06000B3C RID: 2876 RVA: 0x0005BDCA File Offset: 0x00059FCA
		public VolumeStack volumeStack { get; private set; }

		// Token: 0x06000B3D RID: 2877 RVA: 0x0005BDD4 File Offset: 0x00059FD4
		public static HDCamera GetOrCreate(Camera camera, int xrMultipassId = 0)
		{
			HDCamera hdcamera;
			if (!HDCamera.s_Cameras.TryGetValue(new ValueTuple<Camera, int>(camera, xrMultipassId), out hdcamera))
			{
				hdcamera = new HDCamera(camera);
				HDCamera.s_Cameras.Add(new ValueTuple<Camera, int>(camera, xrMultipassId), hdcamera);
			}
			return hdcamera;
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x0005BE10 File Offset: 0x0005A010
		public void Reset()
		{
			this.isFirstFrame = true;
			this.cameraFrameCount = 0U;
			this.resetPostProcessingHistory = true;
			this.volumetricHistoryIsValid = false;
			this.volumetricValidFrames = 0;
			this.colorPyramidHistoryIsValid = false;
			this.colorPyramidHistoryValidFrames = 0;
			this.dofHistoryIsValid = false;
			if (this.visualSky != null)
			{
				this.visualSky.Reset();
			}
			if (this.lightingSky != null && this.visualSky != this.lightingSky)
			{
				this.lightingSky.Reset();
			}
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x0005BE8C File Offset: 0x0005A08C
		public RTHandle AllocHistoryFrameRT(int id, Func<string, int, RTHandleSystem, RTHandle> allocator, int bufferCount)
		{
			this.m_HistoryRTSystem.AllocBuffer(id, (RTHandleSystem rts, int i) => allocator(this.camera.name, i, rts), bufferCount);
			return this.m_HistoryRTSystem.GetFrameRT(id, 0);
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x0005BED3 File Offset: 0x0005A0D3
		public RTHandle GetPreviousFrameRT(int id)
		{
			return this.m_HistoryRTSystem.GetFrameRT(id, 1);
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0005BEE2 File Offset: 0x0005A0E2
		public RTHandle GetCurrentFrameRT(int id)
		{
			return this.m_HistoryRTSystem.GetFrameRT(id, 0);
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000B42 RID: 2882 RVA: 0x0005BEF1 File Offset: 0x0005A0F1
		internal Camera parentCamera
		{
			get
			{
				return this.m_parentCamera;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000B43 RID: 2883 RVA: 0x0005BEF9 File Offset: 0x0005A0F9
		internal Vector2 lowResDrsFactor
		{
			get
			{
				if (!DynamicResolutionHandler.instance.HardwareDynamicResIsEnabled())
				{
					return new Vector2(RTHandles.rtHandleProperties.rtHandleScale.x, RTHandles.rtHandleProperties.rtHandleScale.y);
				}
				return this.m_LowResHWDRSFactor;
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000B44 RID: 2884 RVA: 0x0005BF31 File Offset: 0x0005A131
		internal bool isLowResScaleHalf
		{
			get
			{
				return this.lowResScale == 0.5f;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000B45 RID: 2885 RVA: 0x0005BF40 File Offset: 0x0005A140
		internal Rect lowResViewport
		{
			get
			{
				return new Rect(0f, 0f, (float)Mathf.RoundToInt((float)this.actualWidth * this.lowResScale), (float)Mathf.RoundToInt((float)this.actualHeight * this.lowResScale));
			}
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x0005BF7C File Offset: 0x0005A17C
		private static Vector2 CalculateLowResHWDrsFactor(Vector2Int scaledSize, DynamicResolutionHandler resolutionHandler, float lowResFactor)
		{
			Vector2Int size = new Vector2Int(Mathf.RoundToInt((float)RTHandles.maxWidth * lowResFactor), Mathf.RoundToInt((float)RTHandles.maxHeight * lowResFactor));
			Vector2Int scaledSize2 = resolutionHandler.GetScaledSize(size);
			return new Vector2((float)Mathf.RoundToInt((float)scaledSize.x * lowResFactor), (float)Mathf.RoundToInt((float)scaledSize.y * lowResFactor)) / scaledSize2;
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x0005BFE4 File Offset: 0x0005A1E4
		internal void SetParentCamera(HDCamera parentHdCam, bool useGpuFetchedExposure, float fetchedGpuExposure)
		{
			if (parentHdCam == null)
			{
				this.m_ExposureTextures.clear();
				this.m_ExposureTextures.useCurrentCamera = true;
				this.m_parentCamera = null;
				return;
			}
			this.m_parentCamera = parentHdCam.camera;
			if (!this.m_ExposureControlFS)
			{
				this.m_ExposureTextures.clear();
				this.m_ExposureTextures.useCurrentCamera = true;
				return;
			}
			this.m_ExposureTextures.clear();
			this.m_ExposureTextures.useCurrentCamera = false;
			this.m_ExposureTextures.parent = parentHdCam.currentExposureTextures.current;
			if (useGpuFetchedExposure)
			{
				this.m_ExposureTextures.useFetchedExposure = true;
				this.m_ExposureTextures.fetchedGpuExposure = fetchedGpuExposure;
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000B48 RID: 2888 RVA: 0x0005C087 File Offset: 0x0005A287
		internal Vector2 postProcessRTScales
		{
			get
			{
				return new Vector2(this.m_PostProcessRTScales.x, this.m_PostProcessRTScales.y);
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000B49 RID: 2889 RVA: 0x0005C0A4 File Offset: 0x0005A2A4
		internal Vector4 postProcessRTScalesHistory
		{
			get
			{
				return this.m_PostProcessRTScalesHistory;
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000B4A RID: 2890 RVA: 0x0005C0AC File Offset: 0x0005A2AC
		internal Vector2Int postProcessRTHistoryMaxReference
		{
			get
			{
				return this.m_PostProcessRTHistoryMaxReference;
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000B4B RID: 2891 RVA: 0x0005C0B4 File Offset: 0x0005A2B4
		internal ref HDUtils.PackedMipChainInfo depthBufferMipChainInfo
		{
			get
			{
				return ref this.m_DepthBufferMipChainInfo;
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000B4C RID: 2892 RVA: 0x0005C0BC File Offset: 0x0005A2BC
		internal Vector2Int depthMipChainSize
		{
			get
			{
				return this.m_DepthBufferMipChainInfo.textureSize;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000B4D RID: 2893 RVA: 0x0005C0C9 File Offset: 0x0005A2C9
		// (set) Token: 0x06000B4E RID: 2894 RVA: 0x0005C0D1 File Offset: 0x0005A2D1
		internal SkyUpdateContext visualSky { get; private set; } = new SkyUpdateContext();

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000B4F RID: 2895 RVA: 0x0005C0DA File Offset: 0x0005A2DA
		// (set) Token: 0x06000B50 RID: 2896 RVA: 0x0005C0E2 File Offset: 0x0005A2E2
		internal SkyUpdateContext lightingSky { get; private set; }

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000B51 RID: 2897 RVA: 0x0005C0EB File Offset: 0x0005A2EB
		// (set) Token: 0x06000B52 RID: 2898 RVA: 0x0005C0F3 File Offset: 0x0005A2F3
		internal SkyAmbientMode skyAmbientMode { get; private set; }

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000B53 RID: 2899 RVA: 0x0005C0FC File Offset: 0x0005A2FC
		// (set) Token: 0x06000B54 RID: 2900 RVA: 0x0005C104 File Offset: 0x0005A304
		internal XRPass xr { get; private set; }

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000B56 RID: 2902 RVA: 0x0005C116 File Offset: 0x0005A316
		// (set) Token: 0x06000B55 RID: 2901 RVA: 0x0005C10D File Offset: 0x0005A30D
		internal float globalMipBias { get; set; }

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000B57 RID: 2903 RVA: 0x0005C11E File Offset: 0x0005A31E
		internal float deltaTime
		{
			get
			{
				return this.time - this.lastTime;
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000B58 RID: 2904 RVA: 0x0005C12D File Offset: 0x0005A32D
		// (set) Token: 0x06000B59 RID: 2905 RVA: 0x0005C135 File Offset: 0x0005A335
		internal float animateMaterialsTime { get; set; } = -1f;

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000B5A RID: 2906 RVA: 0x0005C13E File Offset: 0x0005A33E
		// (set) Token: 0x06000B5B RID: 2907 RVA: 0x0005C146 File Offset: 0x0005A346
		internal float animateMaterialsTimeLast { get; set; } = -1f;

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000B5C RID: 2908 RVA: 0x0005C14F File Offset: 0x0005A34F
		internal Matrix4x4 nonObliqueProjMatrix
		{
			get
			{
				if (!(this.m_AdditionalCameraData != null))
				{
					return GeometryUtils.CalculateProjectionMatrix(this.camera);
				}
				return this.m_AdditionalCameraData.GetNonObliqueProjection(this.camera);
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000B5D RID: 2909 RVA: 0x0005C17C File Offset: 0x0005A37C
		// (set) Token: 0x06000B5E RID: 2910 RVA: 0x0005C184 File Offset: 0x0005A384
		internal bool isFirstFrame { get; private set; }

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000B5F RID: 2911 RVA: 0x0005C18D File Offset: 0x0005A38D
		internal bool isMainGameView
		{
			get
			{
				return this.camera.cameraType == CameraType.Game && this.camera.targetTexture == null;
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000B60 RID: 2912 RVA: 0x0005C1B0 File Offset: 0x0005A3B0
		internal bool canDoDynamicResolution
		{
			get
			{
				return this.camera.cameraType == CameraType.Game;
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000B61 RID: 2913 RVA: 0x0005C1C0 File Offset: 0x0005A3C0
		internal int viewCount
		{
			get
			{
				return Math.Max(1, this.xr.viewCount);
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000B62 RID: 2914 RVA: 0x0005C1D3 File Offset: 0x0005A3D3
		internal bool clearDepth
		{
			get
			{
				if (!(this.m_AdditionalCameraData != null))
				{
					return this.camera.clearFlags != CameraClearFlags.Nothing;
				}
				return this.m_AdditionalCameraData.clearDepth;
			}
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x0005C200 File Offset: 0x0005A400
		internal bool CameraIsSceneFiltering()
		{
			return CoreUtils.IsSceneFilteringEnabled() && this.camera.cameraType == CameraType.SceneView;
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000B64 RID: 2916 RVA: 0x0005C21C File Offset: 0x0005A41C
		internal HDAdditionalCameraData.ClearColorMode clearColorMode
		{
			get
			{
				if (this.CameraIsSceneFiltering())
				{
					return HDAdditionalCameraData.ClearColorMode.Color;
				}
				if (this.m_AdditionalCameraData != null)
				{
					return this.m_AdditionalCameraData.clearColorMode;
				}
				if (this.camera.clearFlags == CameraClearFlags.Skybox)
				{
					return HDAdditionalCameraData.ClearColorMode.Sky;
				}
				if (this.camera.clearFlags == CameraClearFlags.Color)
				{
					return HDAdditionalCameraData.ClearColorMode.Color;
				}
				return HDAdditionalCameraData.ClearColorMode.None;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000B65 RID: 2917 RVA: 0x0005C270 File Offset: 0x0005A470
		internal Color backgroundColorHDR
		{
			get
			{
				if (this.m_AdditionalCameraData != null)
				{
					return this.m_AdditionalCameraData.backgroundColorHDR;
				}
				return this.camera.backgroundColor.linear;
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000B66 RID: 2918 RVA: 0x0005C2AA File Offset: 0x0005A4AA
		internal HDAdditionalCameraData.FlipYMode flipYMode
		{
			get
			{
				if (this.m_AdditionalCameraData != null)
				{
					return this.m_AdditionalCameraData.flipYMode;
				}
				return HDAdditionalCameraData.FlipYMode.Automatic;
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000B67 RID: 2919 RVA: 0x0005C2C7 File Offset: 0x0005A4C7
		internal GameObject exposureTarget
		{
			get
			{
				if (this.m_AdditionalCameraData != null)
				{
					return this.m_AdditionalCameraData.exposureTarget;
				}
				return null;
			}
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x0005C2E4 File Offset: 0x0005A4E4
		internal void RequestGpuExposureValue(RTHandle exposureTexture)
		{
			this.RequestGpuTexelValue(exposureTexture, false);
		}

		// Token: 0x06000B69 RID: 2921 RVA: 0x0005C2EE File Offset: 0x0005A4EE
		internal void RequestGpuDeExposureValue(RTHandle exposureTexture)
		{
			this.RequestGpuTexelValue(exposureTexture, true);
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x0005C2F8 File Offset: 0x0005A4F8
		private void RequestGpuTexelValue(RTHandle exposureTexture, bool isDeExposure)
		{
			HDCamera.ExposureGpuReadbackRequest item = default(HDCamera.ExposureGpuReadbackRequest);
			item.request = AsyncGPUReadback.Request(exposureTexture.rt, 0, 0, 1, 0, 1, 0, 1, null);
			item.isDeExposure = isDeExposure;
			this.m_ExposureAsyncRequest.Enqueue(item);
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x0005C33C File Offset: 0x0005A53C
		private void PumpReadbackQueue()
		{
			while (this.m_ExposureAsyncRequest.Count != 0)
			{
				HDCamera.ExposureGpuReadbackRequest exposureGpuReadbackRequest = this.m_ExposureAsyncRequest.Peek();
				ref AsyncGPUReadbackRequest ptr = ref exposureGpuReadbackRequest.request;
				if (!ptr.done && !ptr.hasError)
				{
					break;
				}
				if (!ptr.hasError)
				{
					NativeArray<float> data = ptr.GetData<float>(0);
					if (exposureGpuReadbackRequest.isDeExposure)
					{
						this.m_GpuDeExposureValue = data[0];
					}
					else
					{
						this.m_GpuExposureValue = data[0];
					}
				}
				this.m_ExposureAsyncRequest.Dequeue();
			}
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x0005C3BE File Offset: 0x0005A5BE
		internal float GpuExposureValue()
		{
			this.PumpReadbackQueue();
			return this.m_GpuExposureValue;
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x0005C3CC File Offset: 0x0005A5CC
		internal float GpuDeExposureValue()
		{
			this.PumpReadbackQueue();
			return this.m_GpuDeExposureValue;
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000B6E RID: 2926 RVA: 0x0005C3DA File Offset: 0x0005A5DA
		internal bool exposureControlFS
		{
			get
			{
				return this.m_ExposureControlFS;
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000B6F RID: 2927 RVA: 0x0005C3E2 File Offset: 0x0005A5E2
		internal HDCamera.ExposureTextures currentExposureTextures
		{
			get
			{
				return this.m_ExposureTextures;
			}
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x0005C3EC File Offset: 0x0005A5EC
		internal void SetupExposureTextures()
		{
			if (!this.m_ExposureControlFS)
			{
				this.m_ExposureTextures.current = null;
				this.m_ExposureTextures.previous = null;
				return;
			}
			RTHandle rthandle = this.GetCurrentFrameRT(1);
			if (rthandle == null)
			{
				rthandle = this.AllocHistoryFrameRT(1, new Func<string, int, RTHandleSystem, RTHandle>(HDCamera.<SetupExposureTextures>g__Allocator|188_0), 2);
			}
			this.m_ExposureTextures.current = this.GetPreviousFrameRT(1);
			this.m_ExposureTextures.previous = rthandle;
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000B71 RID: 2929 RVA: 0x0005C458 File Offset: 0x0005A658
		// (set) Token: 0x06000B72 RID: 2930 RVA: 0x0005C460 File Offset: 0x0005A660
		internal HDAdditionalCameraData.AntialiasingMode antialiasing { get; private set; }

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000B73 RID: 2931 RVA: 0x0005C469 File Offset: 0x0005A669
		// (set) Token: 0x06000B74 RID: 2932 RVA: 0x0005C471 File Offset: 0x0005A671
		internal HDAdditionalCameraData.SMAAQualityLevel SMAAQuality { get; private set; } = HDAdditionalCameraData.SMAAQualityLevel.Medium;

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000B75 RID: 2933 RVA: 0x0005C47A File Offset: 0x0005A67A
		// (set) Token: 0x06000B76 RID: 2934 RVA: 0x0005C482 File Offset: 0x0005A682
		internal HDAdditionalCameraData.TAAQualityLevel TAAQuality { get; private set; } = HDAdditionalCameraData.TAAQualityLevel.Medium;

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06000B77 RID: 2935 RVA: 0x0005C48B File Offset: 0x0005A68B
		internal bool dithering
		{
			get
			{
				return this.m_AdditionalCameraData != null && this.m_AdditionalCameraData.dithering;
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000B78 RID: 2936 RVA: 0x0005C4A8 File Offset: 0x0005A6A8
		internal bool stopNaNs
		{
			get
			{
				return this.m_AdditionalCameraData != null && this.m_AdditionalCameraData.stopNaNs;
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000B79 RID: 2937 RVA: 0x0005C4C5 File Offset: 0x0005A6C5
		internal bool allowDynamicResolution
		{
			get
			{
				return this.m_AdditionalCameraData != null && this.m_AdditionalCameraData.allowDynamicResolution;
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000B7A RID: 2938 RVA: 0x0005C4E2 File Offset: 0x0005A6E2
		internal IEnumerable<AOVRequestData> aovRequests
		{
			get
			{
				if (!(this.m_AdditionalCameraData != null) || this.m_AdditionalCameraData.Equals(null))
				{
					return Enumerable.Empty<AOVRequestData>();
				}
				return this.m_AdditionalCameraData.aovRequests;
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000B7B RID: 2939 RVA: 0x0005C511 File Offset: 0x0005A711
		internal LayerMask probeLayerMask
		{
			get
			{
				if (!(this.m_AdditionalCameraData != null))
				{
					return -1;
				}
				return this.m_AdditionalCameraData.probeLayerMask;
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000B7C RID: 2940 RVA: 0x0005C533 File Offset: 0x0005A733
		internal float probeRangeCompressionFactor
		{
			get
			{
				if (!(this.m_AdditionalCameraData != null))
				{
					return 1f;
				}
				return this.m_AdditionalCameraData.probeCustomFixedExposure;
			}
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x0005C554 File Offset: 0x0005A754
		internal bool ValidShadowHistory(HDAdditionalLightData lightData, int screenSpaceShadowIndex, GPULightType lightType)
		{
			return this.shadowHistoryUsage[screenSpaceShadowIndex].lightInstanceID == lightData.GetInstanceID() && this.shadowHistoryUsage[screenSpaceShadowIndex].frameCount == this.cameraFrameCount - 1U && this.shadowHistoryUsage[screenSpaceShadowIndex].lightType == lightType;
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x0005C5AC File Offset: 0x0005A7AC
		internal void PropagateShadowHistory(HDAdditionalLightData lightData, int screenSpaceShadowIndex, GPULightType lightType)
		{
			this.shadowHistoryUsage[screenSpaceShadowIndex].lightInstanceID = lightData.GetInstanceID();
			this.shadowHistoryUsage[screenSpaceShadowIndex].frameCount = this.cameraFrameCount;
			this.shadowHistoryUsage[screenSpaceShadowIndex].lightType = lightType;
			this.shadowHistoryUsage[screenSpaceShadowIndex].transform = lightData.transform.localToWorldMatrix;
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x0005C618 File Offset: 0x0005A818
		internal bool EffectHistoryValidity(HDCamera.HistoryEffectSlot slot, int flagMask)
		{
			flagMask |= (this.exposureControlFS ? 4 : 0);
			return (long)this.historyEffectUsage[(int)slot].frameCount == (long)((ulong)(this.cameraFrameCount - 1U)) && this.historyEffectUsage[(int)slot].flagMask == flagMask;
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x0005C668 File Offset: 0x0005A868
		internal void PropagateEffectHistoryValidity(HDCamera.HistoryEffectSlot slot, int flagMask)
		{
			flagMask |= (this.exposureControlFS ? 4 : 0);
			this.historyEffectUsage[(int)slot].frameCount = (int)this.cameraFrameCount;
			this.historyEffectUsage[(int)slot].flagMask = flagMask;
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x0005C6A3 File Offset: 0x0005A8A3
		internal uint GetCameraFrameCount()
		{
			return this.cameraFrameCount;
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000B83 RID: 2947 RVA: 0x0005C6B4 File Offset: 0x0005A8B4
		// (set) Token: 0x06000B82 RID: 2946 RVA: 0x0005C6AB File Offset: 0x0005A8AB
		internal HDCamera.DynamicResolutionRequest DynResRequest { get; set; }

		// Token: 0x06000B84 RID: 2948 RVA: 0x0005C6BC File Offset: 0x0005A8BC
		internal void RequestDynamicResolution(bool cameraRequestedDynamicRes, DynamicResolutionHandler dynResHandler)
		{
			this.DynResRequest = new HDCamera.DynamicResolutionRequest
			{
				enabled = dynResHandler.DynamicResolutionEnabled(),
				cameraRequested = cameraRequestedDynamicRes,
				hardwareEnabled = dynResHandler.HardwareDynamicResIsEnabled(),
				filter = dynResHandler.filter
			};
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000B85 RID: 2949 RVA: 0x0005C707 File Offset: 0x0005A907
		internal ProfilingSampler profilingSampler
		{
			get
			{
				HDAdditionalCameraData additionalCameraData = this.m_AdditionalCameraData;
				return ((additionalCameraData != null) ? additionalCameraData.profilingSampler : null) ?? ProfilingSampler.Get<HDProfileId>(HDProfileId.HDRenderPipelineRenderCamera);
			}
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x0005C728 File Offset: 0x0005A928
		internal HDCamera(Camera cam)
		{
			this.camera = cam;
			this.name = cam.name;
			this.frustum = default(Frustum);
			this.frustum.planes = new Plane[6];
			this.frustum.corners = new Vector3[8];
			this.frustumPlaneEquations = new Vector4[6];
			this.volumeStack = VolumeManager.instance.CreateStack();
			this.m_DepthBufferMipChainInfo.Allocate();
			this.Reset();
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x0005C94B File Offset: 0x0005AB4B
		internal bool IsDLSSEnabled()
		{
			return !(this.m_AdditionalCameraData == null) && this.m_AdditionalCameraData.cameraCanRenderDLSS;
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x0005C968 File Offset: 0x0005AB68
		internal bool IsTAAUEnabled()
		{
			return DynamicResolutionHandler.instance.DynamicResolutionEnabled() && DynamicResolutionHandler.instance.filter == DynamicResUpscaleFilter.TAAU && !this.IsDLSSEnabled();
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x0005C990 File Offset: 0x0005AB90
		internal bool IsPathTracingEnabled()
		{
			PathTracing component = this.volumeStack.GetComponent<PathTracing>();
			return component && component.enable.value;
		}

		// Token: 0x06000B8A RID: 2954 RVA: 0x0005C9BE File Offset: 0x0005ABBE
		internal DynamicResolutionHandler.UpsamplerScheduleType UpsampleSyncPoint()
		{
			if (this.IsDLSSEnabled())
			{
				return HDRenderPipeline.currentAsset.currentPlatformRenderPipelineSettings.dynamicResolutionSettings.DLSSInjectionPoint;
			}
			if (this.IsTAAUEnabled())
			{
				return DynamicResolutionHandler.UpsamplerScheduleType.BeforePost;
			}
			return DynamicResolutionHandler.UpsamplerScheduleType.AfterPost;
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000B8B RID: 2955 RVA: 0x0005C9E8 File Offset: 0x0005ABE8
		internal bool allowDeepLearningSuperSampling
		{
			get
			{
				return !(this.m_AdditionalCameraData == null) && this.m_AdditionalCameraData.allowDeepLearningSuperSampling;
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000B8C RID: 2956 RVA: 0x0005CA05 File Offset: 0x0005AC05
		internal bool deepLearningSuperSamplingUseCustomQualitySettings
		{
			get
			{
				return !(this.m_AdditionalCameraData == null) && this.m_AdditionalCameraData.deepLearningSuperSamplingUseCustomQualitySettings;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000B8D RID: 2957 RVA: 0x0005CA22 File Offset: 0x0005AC22
		internal uint deepLearningSuperSamplingQuality
		{
			get
			{
				if (!(this.m_AdditionalCameraData == null))
				{
					return this.m_AdditionalCameraData.deepLearningSuperSamplingQuality;
				}
				return 0U;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000B8E RID: 2958 RVA: 0x0005CA3F File Offset: 0x0005AC3F
		internal bool deepLearningSuperSamplingUseCustomAttributes
		{
			get
			{
				return !(this.m_AdditionalCameraData == null) && this.m_AdditionalCameraData.deepLearningSuperSamplingUseCustomAttributes;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000B8F RID: 2959 RVA: 0x0005CA5C File Offset: 0x0005AC5C
		internal bool deepLearningSuperSamplingUseOptimalSettings
		{
			get
			{
				return !(this.m_AdditionalCameraData == null) && this.m_AdditionalCameraData.deepLearningSuperSamplingUseOptimalSettings;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000B90 RID: 2960 RVA: 0x0005CA79 File Offset: 0x0005AC79
		internal float deepLearningSuperSamplingSharpening
		{
			get
			{
				if (!(this.m_AdditionalCameraData == null))
				{
					return this.m_AdditionalCameraData.deepLearningSuperSamplingSharpening;
				}
				return 0f;
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000B91 RID: 2961 RVA: 0x0005CA9A File Offset: 0x0005AC9A
		internal bool fsrOverrideSharpness
		{
			get
			{
				return !(this.m_AdditionalCameraData == null) && this.m_AdditionalCameraData.fsrOverrideSharpness;
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000B92 RID: 2962 RVA: 0x0005CAB7 File Offset: 0x0005ACB7
		internal float fsrSharpness
		{
			get
			{
				if (!(this.m_AdditionalCameraData == null))
				{
					return this.m_AdditionalCameraData.fsrSharpness;
				}
				return 0.92f;
			}
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x0005CAD8 File Offset: 0x0005ACD8
		internal bool RequiresCameraJitter()
		{
			return (this.antialiasing == HDAdditionalCameraData.AntialiasingMode.TemporalAntialiasing || this.IsDLSSEnabled() || this.IsTAAUEnabled()) && !this.IsPathTracingEnabled();
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x0005CB00 File Offset: 0x0005AD00
		internal bool IsSSREnabled(bool transparent = false)
		{
			ScreenSpaceReflection component = this.volumeStack.GetComponent<ScreenSpaceReflection>();
			if (!transparent)
			{
				return this.frameSettings.IsEnabled(FrameSettingsField.SSR) && component.enabled.value && this.frameSettings.IsEnabled(FrameSettingsField.OpaqueObjects);
			}
			return this.frameSettings.IsEnabled(FrameSettingsField.TransparentSSR) && component.enabledTransparent.value;
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x0005CB6C File Offset: 0x0005AD6C
		internal bool IsSSGIEnabled()
		{
			GlobalIllumination component = this.volumeStack.GetComponent<GlobalIllumination>();
			return this.frameSettings.IsEnabled(FrameSettingsField.SSGI) && component.enable.value;
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x0005CBA4 File Offset: 0x0005ADA4
		internal bool IsVolumetricReprojectionEnabled()
		{
			bool flag = Fog.IsVolumetricFogEnabled(this);
			bool flag2 = this.camera.cameraType == CameraType.Game || (this.camera.cameraType == CameraType.SceneView && CoreUtils.AreAnimatedMaterialsEnabled(this.camera));
			bool flag3 = this.frameSettings.IsEnabled(FrameSettingsField.ReprojectionForVolumetrics);
			return flag && flag2 && flag3;
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x0005CBFC File Offset: 0x0005ADFC
		internal void Update(FrameSettings currentFrameSettings, HDRenderPipeline hdrp, XRPass xrPass, bool allocateHistoryBuffers = true)
		{
			Camera camera = (this.parentCamera != null) ? this.parentCamera : this.camera;
			this.animateMaterials = CoreUtils.AreAnimatedMaterialsEnabled(camera);
			if (this.animateMaterials)
			{
				float num = Time.time;
				float deltaTime = Time.deltaTime;
				this.time = num;
				this.lastTime = num - deltaTime;
			}
			else
			{
				this.time = 0f;
				this.lastTime = 0f;
			}
			if (this.shadowHistoryUsage == null || this.shadowHistoryUsage.Length != hdrp.currentPlatformRenderPipelineSettings.hdShadowInitParams.maxScreenSpaceShadowSlots)
			{
				this.shadowHistoryUsage = new HDCamera.ShadowHistoryUsage[hdrp.currentPlatformRenderPipelineSettings.hdShadowInitParams.maxScreenSpaceShadowSlots];
			}
			if (this.historyEffectUsage == null || this.historyEffectUsage.Length != 5)
			{
				this.historyEffectUsage = new HDCamera.HistoryEffectValidity[5];
				for (int i = 0; i < 5; i++)
				{
					this.historyEffectUsage[i].frameCount = -1;
				}
			}
			this.camera.TryGetComponent<HDAdditionalCameraData>(out this.m_AdditionalCameraData);
			this.globalMipBias = ((this.m_AdditionalCameraData == null) ? 0f : this.m_AdditionalCameraData.materialMipBias);
			this.UpdateVolumeAndPhysicalParameters();
			this.xr = xrPass;
			this.frameSettings = currentFrameSettings;
			this.m_ExposureControlFS = this.frameSettings.IsEnabled(FrameSettingsField.ExposureControl);
			this.UpdateAntialiasing();
			DynamicResolutionHandler.instance.upsamplerSchedule = this.UpsampleSyncPoint();
			if (allocateHistoryBuffers)
			{
				HDRenderPipeline.ReinitializeVolumetricBufferParams(this);
				bool flag = this.frameSettings.IsEnabled(FrameSettingsField.Refraction) || this.frameSettings.IsEnabled(FrameSettingsField.Distortion) || this.frameSettings.IsEnabled(FrameSettingsField.Water);
				bool flag2 = this.IsSSREnabled(false) || this.IsSSREnabled(true) || this.IsSSGIEnabled();
				bool flag3 = this.IsVolumetricReprojectionEnabled();
				HDRenderPipeline hdrenderPipeline = (HDRenderPipeline)RenderPipelineManager.currentPipeline;
				bool flag4 = false;
				int num2 = 0;
				int numFramesAllocated = this.m_HistoryRTSystem.GetNumFramesAllocated(num2);
				if (numFramesAllocated > 0)
				{
					RTHandle currentFrameRT = this.GetCurrentFrameRT(num2);
					if (currentFrameRT != null && currentFrameRT.rt.graphicsFormat != hdrenderPipeline.GetColorBufferFormat())
					{
						flag4 = true;
					}
				}
				int num3 = 0;
				if (flag)
				{
					num3 = 1;
				}
				if (flag2)
				{
					num3 = 2;
				}
				foreach (AOVRequestData aovRequest in this.aovRequests)
				{
					if (this.GetHistoryRTHandleSystem(aovRequest).GetNumFramesAllocated(num2) != num3)
					{
						flag4 = true;
						break;
					}
				}
				if (this.m_PrevUpsamplerSchedule != DynamicResolutionHandler.instance.upsamplerSchedule || this.previousFrameWasTAAUpsampled != this.IsTAAUEnabled())
				{
					flag4 = true;
					this.m_PrevUpsamplerSchedule = DynamicResolutionHandler.instance.upsamplerSchedule;
				}
				if (this.viewCount != this.m_HistoryViewCount)
				{
					flag4 = true;
					this.m_HistoryViewCount = this.viewCount;
				}
				if (numFramesAllocated != num3 || flag4)
				{
					this.colorPyramidHistoryIsValid = false;
					this.resetPostProcessingHistory = true;
					if (flag4)
					{
						this.m_HistoryRTSystem.Dispose();
						this.m_HistoryRTSystem = new BufferedRTHandleSystem();
					}
					else
					{
						this.m_HistoryRTSystem.ReleaseBuffer(0);
					}
					this.m_ExposureTextures.clear();
					if (num3 != 0 || flag4)
					{
						bool flag5 = num3 > 0;
						if (flag5)
						{
							this.AllocHistoryFrameRT(0, new Func<string, int, RTHandleSystem, RTHandle>(HDCamera.HistoryBufferAllocatorFunction), num3);
						}
						BufferedRTHandleSystem historyRTHandleSystem = this.GetHistoryRTHandleSystem();
						foreach (AOVRequestData aovRequest2 in this.aovRequests)
						{
							BufferedRTHandleSystem historyRTHandleSystem2 = this.GetHistoryRTHandleSystem(aovRequest2);
							this.BindHistoryRTHandleSystem(historyRTHandleSystem2);
							if (flag5)
							{
								this.AllocHistoryFrameRT(0, new Func<string, int, RTHandleSystem, RTHandle>(HDCamera.HistoryBufferAllocatorFunction), num3);
							}
						}
						this.BindHistoryRTHandleSystem(historyRTHandleSystem);
					}
				}
				int num4 = flag3 ? 2 : 0;
				if (this.m_NumVolumetricBuffersAllocated != num4)
				{
					HDRenderPipeline.DestroyVolumetricHistoryBuffers(this);
					if (num4 != 0)
					{
						HDRenderPipeline.CreateVolumetricHistoryBuffers(this, num4);
					}
					this.m_NumVolumetricBuffersAllocated = num4;
				}
			}
			this.prevFinalViewport = this.finalViewport;
			if (this.xr.enabled)
			{
				this.finalViewport = this.xr.GetViewport(0);
			}
			else
			{
				this.finalViewport = this.GetPixelRect();
			}
			this.actualWidth = Math.Max((int)this.finalViewport.size.x, 1);
			this.actualHeight = Math.Max((int)this.finalViewport.size.y, 1);
			DynamicResolutionHandler.instance.finalViewport = new Vector2Int((int)this.finalViewport.width, (int)this.finalViewport.height);
			Vector2Int vector2Int = new Vector2Int(this.actualWidth, this.actualHeight);
			this.m_DepthBufferMipChainInfo.ComputePackedMipChainInfo(vector2Int);
			this.historyLowResScale = (this.resetPostProcessingHistory ? 0.5f : this.lowResScale);
			this.historyLowResScaleForScreenSpaceLighting = (this.resetPostProcessingHistory ? 0.5f : this.lowResScaleForScreenSpaceLighting);
			this.lowResScale = 0.5f;
			this.lowResScaleForScreenSpaceLighting = 0.5f;
			this.m_LowResHWDRSFactor = Vector2.one;
			if (this.canDoDynamicResolution)
			{
				Vector2Int size = new Vector2Int(this.actualWidth, this.actualHeight);
				Vector2Int scaledSize = DynamicResolutionHandler.instance.GetScaledSize(size);
				this.actualWidth = scaledSize.x;
				this.actualHeight = scaledSize.y;
				this.globalMipBias += DynamicResolutionHandler.instance.CalculateMipBias(scaledSize, vector2Int, this.UpsampleSyncPoint() <= DynamicResolutionHandler.UpsamplerScheduleType.AfterDepthOfField);
				this.lowResScale = DynamicResolutionHandler.instance.GetLowResMultiplier(this.lowResScale);
				this.lowResScaleForScreenSpaceLighting = DynamicResolutionHandler.instance.GetLowResMultiplier(this.lowResScaleForScreenSpaceLighting, hdrp.currentPlatformRenderPipelineSettings.dynamicResolutionSettings.lowResSSGIMinimumThreshold);
				this.m_LowResHWDRSFactor = HDCamera.CalculateLowResHWDrsFactor(scaledSize, DynamicResolutionHandler.instance, this.lowResScale);
			}
			int actualWidth = this.actualWidth;
			int actualHeight = this.actualHeight;
			this.msaaSamples = this.frameSettings.GetResolvedMSAAMode(hdrp.asset);
			this.screenSize = new Vector4((float)actualWidth, (float)actualHeight, 1f / (float)actualWidth, 1f / (float)actualHeight);
			this.SetPostProcessScreenSize(actualWidth, actualHeight);
			this.screenParams = new Vector4(this.screenSize.x, this.screenSize.y, 1f + this.screenSize.z, 1f + this.screenSize.w);
			int num5 = this.taaFrameIndex + 1;
			this.taaFrameIndex = num5;
			if (num5 >= 8)
			{
				this.taaFrameIndex = 0;
			}
			this.UpdateAllViewConstants();
			this.isFirstFrame = false;
			this.cameraFrameCount += 1U;
			HDRenderPipeline.UpdateVolumetricBufferParams(this);
			HDRenderPipeline.ResizeVolumetricHistoryBuffers(this);
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x0005D2A8 File Offset: 0x0005B4A8
		internal void SetReferenceSize()
		{
			RTHandles.SetReferenceSize(this.actualWidth, this.actualHeight);
			this.m_HistoryRTSystem.SwapAndSetReferenceSize(this.actualWidth, this.actualHeight);
			this.SetPostProcessScreenSize(this.actualWidth, this.actualHeight);
			foreach (KeyValuePair<AOVRequestData, BufferedRTHandleSystem> keyValuePair in this.m_AOVHistoryRTSystem)
			{
				keyValuePair.Value.SwapAndSetReferenceSize(this.actualWidth, this.actualHeight);
			}
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x0005D348 File Offset: 0x0005B548
		internal void SetPostProcessScreenSize(int width, int height)
		{
			this.m_PostProcessScreenSize = new Vector4((float)width, (float)height, 1f / (float)width, 1f / (float)height);
			Vector2 vector = RTHandles.CalculateRatioAgainstMaxSize(width, height);
			this.m_PostProcessRTScales = new Vector4(vector.x, vector.y, this.m_PostProcessRTScales.x, this.m_PostProcessRTScales.y);
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x0005D3AC File Offset: 0x0005B5AC
		internal void SetPostProcessHistorySizeAndReference(int width, int height, int referenceWidth, int referenceHeight)
		{
			this.m_PostProcessRTHistoryMaxReference = new Vector2Int(Math.Max(referenceWidth, this.m_PostProcessRTHistoryMaxReference.x), Math.Max(referenceHeight, this.m_PostProcessRTHistoryMaxReference.y));
			this.m_PostProcessRTScalesHistory = new Vector4((float)width / (float)this.m_PostProcessRTHistoryMaxReference.x, (float)height / (float)this.m_PostProcessRTHistoryMaxReference.y, this.m_PostProcessRTScalesHistory.x, this.m_PostProcessRTScalesHistory.y);
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x0005D426 File Offset: 0x0005B626
		internal void BeginRender(CommandBuffer cmd)
		{
			this.SetReferenceSize();
			this.m_RecorderCaptureActions = CameraCaptureBridge.GetCaptureActions(this.camera);
			this.SetupCurrentMaterialQuality(cmd);
			this.SetupExposureTextures();
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x0005D44C File Offset: 0x0005B64C
		internal void UpdateAllViewConstants(bool jitterProjectionMatrix)
		{
			this.UpdateAllViewConstants(jitterProjectionMatrix, false);
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x0005D458 File Offset: 0x0005B658
		internal void GetPixelCoordToViewDirWS(Vector4 resolution, float aspect, ref Matrix4x4[] transforms)
		{
			if (this.xr.singlePassEnabled)
			{
				for (int i = 0; i < this.viewCount; i++)
				{
					transforms[i] = this.ComputePixelCoordToWorldSpaceViewDirectionMatrix(this.m_XRViewConstants[i], resolution, aspect, ShaderConfig.s_CameraRelativeRendering);
				}
				return;
			}
			transforms[0] = this.ComputePixelCoordToWorldSpaceViewDirectionMatrix(this.mainViewConstants, resolution, aspect, ShaderConfig.s_CameraRelativeRendering);
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x0005D4C0 File Offset: 0x0005B6C0
		internal static void ClearAll()
		{
			foreach (KeyValuePair<ValueTuple<Camera, int>, HDCamera> keyValuePair in HDCamera.s_Cameras)
			{
				keyValuePair.Value.ReleaseHistoryBuffer();
				keyValuePair.Value.Dispose();
			}
			HDCamera.s_Cameras.Clear();
			HDCamera.s_Cleanup.Clear();
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x0005D538 File Offset: 0x0005B738
		internal static void CleanUnused()
		{
			foreach (ValueTuple<Camera, int> valueTuple in HDCamera.s_Cameras.Keys)
			{
				HDCamera hdcamera = HDCamera.s_Cameras[valueTuple];
				if (!(hdcamera.camera != null) || hdcamera.camera.cameraType != CameraType.SceneView)
				{
					bool flag = hdcamera.m_AdditionalCameraData != null && hdcamera.m_AdditionalCameraData.hasPersistentHistory;
					if (hdcamera.camera == null || (!hdcamera.camera.isActiveAndEnabled && hdcamera.camera.cameraType != CameraType.Preview && !flag && !hdcamera.isPersistent))
					{
						HDCamera.s_Cleanup.Add(valueTuple);
					}
				}
			}
			foreach (ValueTuple<Camera, int> key in HDCamera.s_Cleanup)
			{
				HDCamera.s_Cameras[key].Dispose();
				HDCamera.s_Cameras.Remove(key);
			}
			HDCamera.s_Cleanup.Clear();
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x0005D678 File Offset: 0x0005B878
		internal static void ResetAllHistoryRTHandleSystems(int width, int height)
		{
			foreach (KeyValuePair<ValueTuple<Camera, int>, HDCamera> keyValuePair in HDCamera.s_Cameras)
			{
				HDCamera value = keyValuePair.Value;
				Vector2Int currentRenderTargetSize = value.m_HistoryRTSystem.rtHandleProperties.currentRenderTargetSize;
				if (width < currentRenderTargetSize.x || height < currentRenderTargetSize.y)
				{
					value.m_HistoryRTSystem.ResetReferenceSize(width, height);
					foreach (KeyValuePair<AOVRequestData, BufferedRTHandleSystem> keyValuePair2 in value.m_AOVHistoryRTSystem)
					{
						keyValuePair2.Value.ResetReferenceSize(width, height);
					}
				}
			}
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x0005D750 File Offset: 0x0005B950
		internal void UpdateScalesAndScreenSizesCB(ref ShaderVariablesGlobal cb)
		{
			cb._ScreenSize = this.screenSize;
			cb._PostProcessScreenSize = this.postProcessScreenSize;
			cb._RTHandleScale = RTHandles.rtHandleProperties.rtHandleScale;
			cb._RTHandleScaleHistory = this.m_HistoryRTSystem.rtHandleProperties.rtHandleScale;
			cb._RTHandlePostProcessScale = this.m_PostProcessRTScales;
			cb._RTHandlePostProcessScaleHistory = this.m_PostProcessRTScalesHistory;
			cb._DynamicResolutionFullscreenScale = new Vector4((float)this.actualWidth / this.finalViewport.width, (float)this.actualHeight / this.finalViewport.height, 0f, 0f);
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x0005D7EE File Offset: 0x0005B9EE
		internal void UpdateShaderVariablesGlobalCB(ref ShaderVariablesGlobal cb)
		{
			this.UpdateShaderVariablesGlobalCB(ref cb, (int)this.cameraFrameCount);
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x0005D800 File Offset: 0x0005BA00
		internal unsafe void UpdateShaderVariablesGlobalCB(ref ShaderVariablesGlobal cb, int frameCount)
		{
			bool flag = this.frameSettings.IsEnabled(FrameSettingsField.Postprocess) && this.antialiasing == HDAdditionalCameraData.AntialiasingMode.TemporalAntialiasing && this.camera.cameraType == CameraType.Game;
			bool flag2 = this.m_AdditionalCameraData == null;
			cb._ViewMatrix = this.mainViewConstants.viewMatrix;
			cb._CameraViewMatrix = this.mainViewConstants.viewMatrix;
			cb._InvViewMatrix = this.mainViewConstants.invViewMatrix;
			cb._ProjMatrix = this.mainViewConstants.projMatrix;
			cb._InvProjMatrix = this.mainViewConstants.invProjMatrix;
			cb._ViewProjMatrix = this.mainViewConstants.viewProjMatrix;
			cb._CameraViewProjMatrix = this.mainViewConstants.viewProjMatrix;
			cb._InvViewProjMatrix = this.mainViewConstants.invViewProjMatrix;
			cb._NonJitteredViewProjMatrix = this.mainViewConstants.nonJitteredViewProjMatrix;
			cb._PrevViewProjMatrix = this.mainViewConstants.prevViewProjMatrix;
			cb._PrevInvViewProjMatrix = this.mainViewConstants.prevInvViewProjMatrix;
			cb._WorldSpaceCameraPos_Internal = this.mainViewConstants.worldSpaceCameraPos;
			cb._PrevCamPosRWS_Internal = this.mainViewConstants.prevWorldSpaceCameraPos;
			this.UpdateScalesAndScreenSizesCB(ref cb);
			cb._ZBufferParams = this.zBufferParams;
			cb._ProjectionParams = this.projectionParams;
			cb.unity_OrthoParams = this.unity_OrthoParams;
			cb._ScreenParams = this.screenParams;
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					*(ref cb._FrustumPlanes.FixedElementField + (IntPtr)(i * 4 + j) * 4) = this.frustumPlaneEquations[i][j];
				}
			}
			cb._TaaFrameInfo = new Vector4(this.taaSharpenStrength, 0f, (float)this.taaFrameIndex, (float)(flag ? 1 : 0));
			cb._TaaJitterStrength = this.taaJitter;
			cb._ColorPyramidLodCount = (float)this.colorPyramidHistoryMipCount;
			cb._GlobalMipBias = this.globalMipBias;
			cb._GlobalMipBiasPow2 = (float)Math.Pow(2.0, (double)this.globalMipBias);
			float num = this.time;
			float num2 = this.lastTime;
			float deltaTime = Time.deltaTime;
			float smoothDeltaTime = Time.smoothDeltaTime;
			cb._Time = new Vector4(num * 0.05f, num, num * 2f, num * 3f);
			cb._SinTime = new Vector4(Mathf.Sin(num * 0.125f), Mathf.Sin(num * 0.25f), Mathf.Sin(num * 0.5f), Mathf.Sin(num));
			cb._CosTime = new Vector4(Mathf.Cos(num * 0.125f), Mathf.Cos(num * 0.25f), Mathf.Cos(num * 0.5f), Mathf.Cos(num));
			cb.unity_DeltaTime = new Vector4(deltaTime, 1f / deltaTime, smoothDeltaTime, 1f / smoothDeltaTime);
			cb._TimeParameters = new Vector4(num, Mathf.Sin(num), Mathf.Cos(num), 0f);
			cb._LastTimeParameters = new Vector4(num2, Mathf.Sin(num2), Mathf.Cos(num2), 0f);
			cb._FrameCount = frameCount;
			cb._XRViewCount = (uint)this.viewCount;
			float probeExposureScale = 1f / Mathf.Max(this.probeRangeCompressionFactor, 1E-06f);
			cb._ProbeExposureScale = probeExposureScale;
			cb._DeExposureMultiplier = (flag2 ? 1f : this.m_AdditionalCameraData.deExposureMultiplier);
			cb._TransparentCameraOnlyMotionVectors = ((this.frameSettings.IsEnabled(FrameSettingsField.MotionVectors) && !this.frameSettings.IsEnabled(FrameSettingsField.TransparentsWriteMotionVector)) ? 1 : 0);
			cb._ScreenSizeOverride = (flag2 ? cb._ScreenSize : this.m_AdditionalCameraData.screenSizeOverride);
			cb._ScreenCoordScaleBias = (flag2 ? new Vector4(1f, 1f, 0f, 0f) : this.m_AdditionalCameraData.screenCoordScaleBias);
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x0005DBE0 File Offset: 0x0005BDE0
		internal void PushBuiltinShaderConstantsXR(CommandBuffer cmd)
		{
			if (this.xr.enabled)
			{
				cmd.SetViewProjectionMatrices(this.xr.GetViewMatrix(0), this.xr.GetProjMatrix(0));
				if (this.xr.singlePassEnabled)
				{
					for (int i = 0; i < this.viewCount; i++)
					{
						XRBuiltinShaderConstants.UpdateBuiltinShaderConstants(this.xr.GetViewMatrix(i), this.xr.GetProjMatrix(i), true, i);
					}
					XRBuiltinShaderConstants.SetBuiltinShaderConstants(cmd);
				}
			}
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x0005DC5C File Offset: 0x0005BE5C
		internal unsafe void UpdateShaderVariablesXRCB(ref ShaderVariablesXR cb)
		{
			for (int i = 0; i < this.viewCount; i++)
			{
				for (int j = 0; j < 16; j++)
				{
					*(ref cb._XRViewMatrix.FixedElementField + (IntPtr)(i * 16 + j) * 4) = this.m_XRViewConstants[i].viewMatrix[j];
					*(ref cb._XRInvViewMatrix.FixedElementField + (IntPtr)(i * 16 + j) * 4) = this.m_XRViewConstants[i].invViewMatrix[j];
					*(ref cb._XRProjMatrix.FixedElementField + (IntPtr)(i * 16 + j) * 4) = this.m_XRViewConstants[i].projMatrix[j];
					*(ref cb._XRInvProjMatrix.FixedElementField + (IntPtr)(i * 16 + j) * 4) = this.m_XRViewConstants[i].invProjMatrix[j];
					*(ref cb._XRViewProjMatrix.FixedElementField + (IntPtr)(i * 16 + j) * 4) = this.m_XRViewConstants[i].viewProjMatrix[j];
					*(ref cb._XRInvViewProjMatrix.FixedElementField + (IntPtr)(i * 16 + j) * 4) = this.m_XRViewConstants[i].invViewProjMatrix[j];
					*(ref cb._XRNonJitteredViewProjMatrix.FixedElementField + (IntPtr)(i * 16 + j) * 4) = this.m_XRViewConstants[i].nonJitteredViewProjMatrix[j];
					*(ref cb._XRPrevViewProjMatrix.FixedElementField + (IntPtr)(i * 16 + j) * 4) = this.m_XRViewConstants[i].prevViewProjMatrix[j];
					*(ref cb._XRPrevInvViewProjMatrix.FixedElementField + (IntPtr)(i * 16 + j) * 4) = this.m_XRViewConstants[i].prevInvViewProjMatrix[j];
					*(ref cb._XRViewProjMatrixNoCameraTrans.FixedElementField + (IntPtr)(i * 16 + j) * 4) = this.m_XRViewConstants[i].viewProjectionNoCameraTrans[j];
					*(ref cb._XRPrevViewProjMatrixNoCameraTrans.FixedElementField + (IntPtr)(i * 16 + j) * 4) = this.m_XRViewConstants[i].prevViewProjMatrixNoCameraTrans[j];
					*(ref cb._XRPixelCoordToViewDirWS.FixedElementField + (IntPtr)(i * 16 + j) * 4) = this.m_XRViewConstants[i].pixelCoordToViewDirWS[j];
				}
				for (int k = 0; k < 3; k++)
				{
					*(ref cb._XRWorldSpaceCameraPos.FixedElementField + (IntPtr)(i * 4 + k) * 4) = this.m_XRViewConstants[i].worldSpaceCameraPos[k];
					*(ref cb._XRWorldSpaceCameraPosViewOffset.FixedElementField + (IntPtr)(i * 4 + k) * 4) = this.m_XRViewConstants[i].worldSpaceCameraPosViewOffset[k];
					*(ref cb._XRPrevWorldSpaceCameraPos.FixedElementField + (IntPtr)(i * 4 + k) * 4) = this.m_XRViewConstants[i].prevWorldSpaceCameraPos[k];
				}
			}
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x0005DF48 File Offset: 0x0005C148
		internal bool AllocateAmbientOcclusionHistoryBuffer(float scaleFactor)
		{
			if (scaleFactor != this.m_AmbientOcclusionResolutionScale || this.GetCurrentFrameRT(8) == null)
			{
				this.ReleaseHistoryFrameRT(8);
				HDCamera.CustomHistoryAllocator customHistoryAllocator = new HDCamera.CustomHistoryAllocator(new Vector2(scaleFactor, scaleFactor), GraphicsFormat.R8G8B8A8_UNorm, "AO Packed history");
				this.AllocHistoryFrameRT(8, new Func<string, int, RTHandleSystem, RTHandle>(customHistoryAllocator.Allocator), 2);
				this.m_AmbientOcclusionResolutionScale = scaleFactor;
				return true;
			}
			return false;
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x0005DFA8 File Offset: 0x0005C1A8
		internal void AllocateScreenSpaceAccumulationHistoryBuffer(float scaleFactor)
		{
			if (scaleFactor != this.m_ScreenSpaceAccumulationResolutionScale || this.GetCurrentFrameRT(21) == null)
			{
				this.ReleaseHistoryFrameRT(21);
				HDCamera.CustomHistoryAllocator customHistoryAllocator = new HDCamera.CustomHistoryAllocator(new Vector2(scaleFactor, scaleFactor), GraphicsFormat.R16G16B16A16_SFloat, "SSR_Accum Packed history");
				this.AllocHistoryFrameRT(21, new Func<string, int, RTHandleSystem, RTHandle>(customHistoryAllocator.Allocator), 2);
				this.m_ScreenSpaceAccumulationResolutionScale = scaleFactor;
			}
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x0005E007 File Offset: 0x0005C207
		internal void ReleaseHistoryFrameRT(int id)
		{
			this.m_HistoryRTSystem.ReleaseBuffer(id);
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x0005E018 File Offset: 0x0005C218
		internal void ExecuteCaptureActions(RenderGraph renderGraph, TextureHandle input)
		{
			if (this.m_RecorderCaptureActions == null || !this.m_RecorderCaptureActions.MoveNext())
			{
				return;
			}
			HDCamera.ExecuteCaptureActionsPassData executeCaptureActionsPassData;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<HDCamera.ExecuteCaptureActionsPassData>("Execute Capture Actions", out executeCaptureActionsPassData))
			{
				TextureDesc textureDesc = renderGraph.GetTextureDesc(input);
				Vector2Int currentRenderTargetSize = RTHandles.rtHandleProperties.currentRenderTargetSize;
				executeCaptureActionsPassData.viewportScale = new Vector2(this.finalViewport.width / (float)currentRenderTargetSize.x, this.finalViewport.height / (float)currentRenderTargetSize.y);
				executeCaptureActionsPassData.blitMaterial = HDUtils.GetBlitMaterial(textureDesc.dimension, false);
				executeCaptureActionsPassData.recorderCaptureActions = this.m_RecorderCaptureActions;
				executeCaptureActionsPassData.input = renderGraphBuilder.ReadTexture(input);
				executeCaptureActionsPassData.viewportSize = this.finalViewport;
				HDCamera.ExecuteCaptureActionsPassData executeCaptureActionsPassData2 = executeCaptureActionsPassData;
				TextureDesc textureDesc2 = new TextureDesc((int)this.finalViewport.width, (int)this.finalViewport.height, false, false);
				textureDesc2.colorFormat = textureDesc.colorFormat;
				textureDesc2.name = "TempCaptureActions";
				executeCaptureActionsPassData2.tempTexture = renderGraphBuilder.CreateTransientTexture(textureDesc2);
				renderGraphBuilder.SetRenderFunc<HDCamera.ExecuteCaptureActionsPassData>(delegate(HDCamera.ExecuteCaptureActionsPassData data, RenderGraphContext ctx)
				{
					MaterialPropertyBlock tempMaterialPropertyBlock = ctx.renderGraphPool.GetTempMaterialPropertyBlock();
					tempMaterialPropertyBlock.SetTexture(HDShaderIDs._BlitTexture, data.input);
					tempMaterialPropertyBlock.SetVector(HDShaderIDs._BlitScaleBias, data.viewportScale);
					tempMaterialPropertyBlock.SetFloat(HDShaderIDs._BlitMipLevel, 0f);
					ctx.cmd.SetRenderTarget(data.tempTexture);
					ctx.cmd.SetViewport(data.viewportSize);
					ctx.cmd.DrawProcedural(Matrix4x4.identity, data.blitMaterial, 0, MeshTopology.Triangles, 3, 1, tempMaterialPropertyBlock);
					data.recorderCaptureActions.Reset();
					while (data.recorderCaptureActions.MoveNext())
					{
						data.recorderCaptureActions.Current(data.tempTexture, ctx.cmd);
					}
				});
			}
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x0005E158 File Offset: 0x0005C358
		internal void UpdateCurrentSky(SkyManager skyManager)
		{
			this.skyAmbientMode = this.volumeStack.GetComponent<VisualEnvironment>().skyAmbientMode.value;
			this.visualSky.skySettings = SkyManager.GetSkySetting(this.volumeStack);
			this.visualSky.cloudSettings = SkyManager.GetCloudSetting(this.volumeStack);
			this.visualSky.volumetricClouds = SkyManager.GetVolumetricClouds(this.volumeStack);
			this.lightingSky = this.visualSky;
			if (skyManager.lightingOverrideLayerMask != 0)
			{
				VolumeManager.instance.Update(skyManager.lightingOverrideVolumeStack, this.volumeAnchor, skyManager.lightingOverrideLayerMask);
				if (VolumeManager.instance.IsComponentActiveInMask<VisualEnvironment>(skyManager.lightingOverrideLayerMask))
				{
					SkySettings skySetting = SkyManager.GetSkySetting(skyManager.lightingOverrideVolumeStack);
					CloudSettings cloudSetting = SkyManager.GetCloudSetting(skyManager.lightingOverrideVolumeStack);
					VolumetricClouds volumetricClouds = SkyManager.GetVolumetricClouds(skyManager.lightingOverrideVolumeStack);
					if ((this.m_LightingOverrideSky.skySettings != null && skySetting == null) || (this.m_LightingOverrideSky.cloudSettings != null && cloudSetting == null) || (this.m_LightingOverrideSky.volumetricClouds != null && volumetricClouds == null))
					{
						this.visualSky.skyParametersHash = -1;
					}
					this.m_LightingOverrideSky.skySettings = skySetting;
					this.m_LightingOverrideSky.cloudSettings = cloudSetting;
					this.m_LightingOverrideSky.volumetricClouds = volumetricClouds;
					this.lightingSky = this.m_LightingOverrideSky;
				}
			}
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x0005E2C3 File Offset: 0x0005C4C3
		internal void OverridePixelRect(Rect newPixelRect)
		{
			this.m_OverridePixelRect = new Rect?(newPixelRect);
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x0005E2D1 File Offset: 0x0005C4D1
		internal void ResetPixelRect()
		{
			this.m_OverridePixelRect = null;
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000BAD RID: 2989 RVA: 0x0005E2DF File Offset: 0x0005C4DF
		internal bool hasCaptureActions
		{
			get
			{
				return this.m_RecorderCaptureActions != null;
			}
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x0005E2EC File Offset: 0x0005C4EC
		private void SetupCurrentMaterialQuality(CommandBuffer cmd)
		{
			HDRenderPipelineAsset currentAsset = HDRenderPipeline.currentAsset;
			MaterialQuality availableMaterialQualityLevels = currentAsset.availableMaterialQualityLevels;
			MaterialQuality requestedLevel = (this.frameSettings.materialQuality == (MaterialQuality)0) ? currentAsset.defaultMaterialQualityLevel : this.frameSettings.materialQuality;
			availableMaterialQualityLevels.GetClosestQuality(requestedLevel).SetGlobalShaderKeywords(cmd);
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x0005E334 File Offset: 0x0005C534
		private void UpdateAntialiasing()
		{
			HDAdditionalCameraData.AntialiasingMode antialiasing = this.antialiasing;
			if (!this.frameSettings.IsEnabled(FrameSettingsField.Postprocess) || !CoreUtils.ArePostProcessesEnabled(this.camera))
			{
				this.antialiasing = HDAdditionalCameraData.AntialiasingMode.None;
			}
			else if (this.m_AdditionalCameraData != null)
			{
				this.antialiasing = this.m_AdditionalCameraData.antialiasing;
				this.SMAAQuality = this.m_AdditionalCameraData.SMAAQuality;
				this.TAAQuality = this.m_AdditionalCameraData.TAAQuality;
				this.taaSharpenStrength = this.m_AdditionalCameraData.taaSharpenStrength;
				this.taaHistorySharpening = this.m_AdditionalCameraData.taaHistorySharpening;
				this.taaAntiFlicker = this.m_AdditionalCameraData.taaAntiFlicker;
				this.taaAntiRinging = this.m_AdditionalCameraData.taaAntiHistoryRinging;
				this.taaJitterScale = this.m_AdditionalCameraData.taaJitterScale;
				this.taaMotionVectorRejection = this.m_AdditionalCameraData.taaMotionVectorRejection;
				this.taaBaseBlendFactor = this.m_AdditionalCameraData.taaBaseBlendFactor;
			}
			else
			{
				this.antialiasing = HDAdditionalCameraData.AntialiasingMode.None;
			}
			if (!this.RequiresCameraJitter())
			{
				this.taaFrameIndex = 0;
				this.taaJitter = Vector4.zero;
			}
			if (this.IsTAAUEnabled())
			{
				this.antialiasing = HDAdditionalCameraData.AntialiasingMode.TemporalAntialiasing;
			}
			if ((antialiasing != this.antialiasing && this.antialiasing == HDAdditionalCameraData.AntialiasingMode.TemporalAntialiasing) || this.m_PreviousClearColorMode != this.clearColorMode)
			{
				this.resetPostProcessingHistory = true;
				this.m_PreviousClearColorMode = this.clearColorMode;
			}
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x0005E494 File Offset: 0x0005C694
		private void GetXrViewParameters(int xrViewIndex, out Matrix4x4 proj, out Matrix4x4 view, out Vector3 cameraPosition)
		{
			proj = this.xr.GetProjMatrix(xrViewIndex);
			view = this.xr.GetViewMatrix(xrViewIndex);
			cameraPosition = view.inverse.GetColumn(3);
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x0005E4E0 File Offset: 0x0005C6E0
		private void UpdateAllViewConstants()
		{
			if (this.m_XRViewConstants == null || this.m_XRViewConstants.Length != this.viewCount)
			{
				this.m_XRViewConstants = new HDCamera.ViewConstants[this.viewCount];
				this.resetPostProcessingHistory = true;
				this.isFirstFrame = true;
			}
			this.UpdateAllViewConstants(this.RequiresCameraJitter(), true);
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0005E534 File Offset: 0x0005C734
		private void UpdateAllViewConstants(bool jitterProjectionMatrix, bool updatePreviousFrameConstants)
		{
			Matrix4x4 projectionMatrix = this.camera.projectionMatrix;
			Matrix4x4 worldToCameraMatrix = this.camera.worldToCameraMatrix;
			Vector3 position = this.camera.transform.position;
			if (this.xr.enabled && this.viewCount == 1)
			{
				this.GetXrViewParameters(0, out projectionMatrix, out worldToCameraMatrix, out position);
			}
			this.UpdateViewConstants(ref this.mainViewConstants, projectionMatrix, worldToCameraMatrix, position, jitterProjectionMatrix, updatePreviousFrameConstants);
			if (this.xr.singlePassEnabled)
			{
				for (int i = 0; i < this.viewCount; i++)
				{
					this.GetXrViewParameters(i, out projectionMatrix, out worldToCameraMatrix, out position);
					this.UpdateViewConstants(ref this.m_XRViewConstants[i], projectionMatrix, worldToCameraMatrix, position, jitterProjectionMatrix, updatePreviousFrameConstants);
					this.m_XRViewConstants[i].worldSpaceCameraPosViewOffset = this.m_XRViewConstants[i].worldSpaceCameraPos - this.mainViewConstants.worldSpaceCameraPos;
				}
			}
			else
			{
				this.m_XRViewConstants[0] = this.mainViewConstants;
			}
			this.UpdateFrustum(this.mainViewConstants);
			this.m_RecorderCaptureActions = CameraCaptureBridge.GetCaptureActions(this.camera);
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x0005E644 File Offset: 0x0005C844
		private void UpdateViewConstants(ref HDCamera.ViewConstants viewConstants, Matrix4x4 projMatrix, Matrix4x4 viewMatrix, Vector3 cameraPosition, bool jitterProjectionMatrix, bool updatePreviousFrameConstants)
		{
			Matrix4x4 gpuprojectionMatrix = GL.GetGPUProjectionMatrix(jitterProjectionMatrix ? this.GetJitteredProjectionMatrix(projMatrix) : projMatrix, true);
			Matrix4x4 matrix4x = viewMatrix;
			Matrix4x4 gpuprojectionMatrix2 = GL.GetGPUProjectionMatrix(projMatrix, true);
			if (ShaderConfig.s_CameraRelativeRendering != 0)
			{
				matrix4x.SetColumn(3, new Vector4(0f, 0f, 0f, 1f));
			}
			Matrix4x4 prevViewProjMatrix = gpuprojectionMatrix2 * matrix4x;
			Matrix4x4 rhs = matrix4x;
			if (ShaderConfig.s_CameraRelativeRendering == 0)
			{
				rhs.SetColumn(3, new Vector4(0f, 0f, 0f, 1f));
			}
			Matrix4x4 matrix4x2 = gpuprojectionMatrix2 * rhs;
			if (updatePreviousFrameConstants)
			{
				if (this.isFirstFrame)
				{
					viewConstants.prevWorldSpaceCameraPos = cameraPosition;
					viewConstants.prevViewMatrix = matrix4x;
					viewConstants.prevViewProjMatrix = prevViewProjMatrix;
					viewConstants.prevInvViewProjMatrix = viewConstants.prevViewProjMatrix.inverse;
					viewConstants.prevViewProjMatrixNoCameraTrans = matrix4x2;
				}
				else
				{
					viewConstants.prevWorldSpaceCameraPos = viewConstants.worldSpaceCameraPos;
					viewConstants.prevViewMatrix = viewConstants.viewMatrix;
					viewConstants.prevViewProjMatrix = viewConstants.nonJitteredViewProjMatrix;
					viewConstants.prevViewProjMatrixNoCameraTrans = viewConstants.viewProjectionNoCameraTrans;
				}
			}
			viewConstants.viewMatrix = matrix4x;
			viewConstants.invViewMatrix = matrix4x.inverse;
			viewConstants.projMatrix = gpuprojectionMatrix;
			viewConstants.invProjMatrix = gpuprojectionMatrix.inverse;
			viewConstants.viewProjMatrix = gpuprojectionMatrix * matrix4x;
			viewConstants.invViewProjMatrix = viewConstants.viewProjMatrix.inverse;
			viewConstants.nonJitteredViewProjMatrix = gpuprojectionMatrix2 * matrix4x;
			viewConstants.worldSpaceCameraPos = cameraPosition;
			viewConstants.worldSpaceCameraPosViewOffset = Vector3.zero;
			viewConstants.viewProjectionNoCameraTrans = matrix4x2;
			float aspect = HDUtils.ProjectionMatrixAspect(gpuprojectionMatrix);
			viewConstants.pixelCoordToViewDirWS = this.ComputePixelCoordToWorldSpaceViewDirectionMatrix(viewConstants, this.screenSize, aspect, ShaderConfig.s_CameraRelativeRendering);
			if (updatePreviousFrameConstants)
			{
				Vector3 vector = viewConstants.worldSpaceCameraPos - viewConstants.prevWorldSpaceCameraPos;
				viewConstants.prevWorldSpaceCameraPos -= viewConstants.worldSpaceCameraPos;
				viewConstants.prevViewProjMatrix *= Matrix4x4.Translate(vector);
				viewConstants.prevInvViewProjMatrix = viewConstants.prevViewProjMatrix.inverse;
			}
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x0005E840 File Offset: 0x0005CA40
		private void UpdateFrustum(in HDCamera.ViewConstants viewConstants)
		{
			Matrix4x4 lhs = this.mainViewConstants.projMatrix;
			Matrix4x4 matrix4x = this.mainViewConstants.invProjMatrix;
			Matrix4x4 matrix4x2 = this.mainViewConstants.viewProjMatrix;
			if (this.xr.enabled)
			{
				Matrix4x4 stereoProjectionMatrix = this.xr.cullingParams.stereoProjectionMatrix;
				Matrix4x4 stereoViewMatrix = this.xr.cullingParams.stereoViewMatrix;
				if (ShaderConfig.s_CameraRelativeRendering != 0)
				{
					Vector4 column = stereoViewMatrix.inverse.GetColumn(3) - this.camera.transform.position;
					stereoViewMatrix.SetColumn(3, column);
				}
				lhs = GL.GetGPUProjectionMatrix(stereoProjectionMatrix, true);
				matrix4x = lhs.inverse;
				matrix4x2 = lhs * stereoViewMatrix;
			}
			float nearClipPlane = this.camera.nearClipPlane;
			float farClipPlane = this.camera.farClipPlane;
			float num = lhs[2, 3] / (farClipPlane * nearClipPlane) * (farClipPlane - nearClipPlane);
			Mathf.Abs(num);
			bool flag = num > 0f;
			bool flag2 = matrix4x.MultiplyPoint(new Vector3(0f, 1f, 0f)).y < 0f;
			if (flag)
			{
				this.zBufferParams = new Vector4(-1f + farClipPlane / nearClipPlane, 1f, -1f / farClipPlane + 1f / nearClipPlane, 1f / farClipPlane);
			}
			else
			{
				this.zBufferParams = new Vector4(1f - farClipPlane / nearClipPlane, farClipPlane / nearClipPlane, 1f / farClipPlane - 1f / nearClipPlane, 1f / nearClipPlane);
			}
			this.projectionParams = new Vector4((float)(flag2 ? -1 : 1), nearClipPlane, farClipPlane, 1f / farClipPlane);
			float num2 = this.camera.orthographic ? (2f * this.camera.orthographicSize) : 0f;
			float x = num2 * this.camera.aspect;
			this.unity_OrthoParams = new Vector4(x, num2, 0f, (float)(this.camera.orthographic ? 1 : 0));
			Matrix4x4 invViewMatrix = viewConstants.invViewMatrix;
			Vector3 viewDir = -invViewMatrix.GetColumn(2);
			viewDir.Normalize();
			Matrix4x4 viewProjMatrix = matrix4x2;
			invViewMatrix = viewConstants.invViewMatrix;
			Frustum.Create(ref this.frustum, viewProjMatrix, invViewMatrix.GetColumn(3), viewDir, nearClipPlane, farClipPlane);
			for (int i = 0; i < 6; i++)
			{
				this.frustumPlaneEquations[i] = new Vector4(this.frustum.planes[i].normal.x, this.frustum.planes[i].normal.y, this.frustum.planes[i].normal.z, this.frustum.planes[i].distance);
			}
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x0005EB24 File Offset: 0x0005CD24
		internal static int GetSceneViewLayerMaskFallback()
		{
			HDRenderPipeline hdrenderPipeline = RenderPipelineManager.currentPipeline as HDRenderPipeline;
			if (hdrenderPipeline.asset.currentPlatformRenderPipelineSettings.lightLoopSettings.skyLightingOverrideLayerMask == -1)
			{
				return -1;
			}
			return -1 & ~(hdrenderPipeline.asset.currentPlatformRenderPipelineSettings.lightLoopSettings.skyLightingOverrideLayerMask | int.MinValue);
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x0005EB80 File Offset: 0x0005CD80
		private void UpdateVolumeAndPhysicalParameters()
		{
			this.volumeAnchor = null;
			this.volumeLayerMask = -1;
			if (this.m_AdditionalCameraData != null)
			{
				this.volumeLayerMask = this.m_AdditionalCameraData.volumeLayerMask;
				this.volumeAnchor = this.m_AdditionalCameraData.volumeAnchorOverride;
			}
			else if (this.camera.cameraType == CameraType.SceneView)
			{
				Camera main = Camera.main;
				bool flag = true;
				HDAdditionalCameraData hdadditionalCameraData;
				if (main != null && main.TryGetComponent<HDAdditionalCameraData>(out hdadditionalCameraData))
				{
					this.volumeLayerMask = hdadditionalCameraData.volumeLayerMask;
					this.volumeAnchor = hdadditionalCameraData.volumeAnchorOverride;
					flag = false;
				}
				if (flag)
				{
					this.volumeLayerMask = HDCamera.GetSceneViewLayerMaskFallback();
				}
			}
			if (this.volumeAnchor == null)
			{
				this.volumeAnchor = this.camera.transform;
			}
			using (new ProfilingScope(null, ProfilingSampler.Get<HDProfileId>(HDProfileId.VolumeUpdate)))
			{
				VolumeManager.instance.Update(this.volumeStack, this.volumeAnchor, this.volumeLayerMask);
			}
			switch (this.volumeStack.GetComponent<Exposure>().targetMidGray.value)
			{
			case TargetMidGray.Grey125:
				ColorUtils.s_LightMeterCalibrationConstant = 12.5f;
				return;
			case TargetMidGray.Grey14:
				ColorUtils.s_LightMeterCalibrationConstant = 14f;
				return;
			case TargetMidGray.Grey18:
				ColorUtils.s_LightMeterCalibrationConstant = 18f;
				return;
			default:
				ColorUtils.s_LightMeterCalibrationConstant = 12.5f;
				return;
			}
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x0005ECF0 File Offset: 0x0005CEF0
		internal Matrix4x4 GetJitteredProjectionMatrix(Matrix4x4 origProj)
		{
			if (this.xr.enabled && !HDRenderPipeline.currentAsset.currentPlatformRenderPipelineSettings.xrSettings.cameraJitter)
			{
				this.taaJitter = Vector4.zero;
				return origProj;
			}
			if (FrameDebugger.enabled)
			{
				this.taaJitter = Vector4.zero;
				return origProj;
			}
			float num = HaltonSequence.Get((this.taaFrameIndex & 1023) + 1, 2) - 0.5f;
			float num2 = HaltonSequence.Get((this.taaFrameIndex & 1023) + 1, 3) - 0.5f;
			if (!this.IsDLSSEnabled() && !this.IsTAAUEnabled() && this.camera.cameraType != CameraType.SceneView)
			{
				num *= this.taaJitterScale;
				num2 *= this.taaJitterScale;
			}
			this.taaJitter = new Vector4(num, num2, num / (float)this.actualWidth, num2 / (float)this.actualHeight);
			Matrix4x4 result;
			if (this.camera.orthographic)
			{
				float orthographicSize = this.camera.orthographicSize;
				float num3 = orthographicSize * this.camera.aspect;
				Vector4 vector = this.taaJitter;
				vector.x *= num3 / (0.5f * (float)this.actualWidth);
				vector.y *= orthographicSize / (0.5f * (float)this.actualHeight);
				float left = vector.x - num3;
				float right = vector.x + num3;
				float top = vector.y + orthographicSize;
				float bottom = vector.y - orthographicSize;
				result = Matrix4x4.Ortho(left, right, bottom, top, this.camera.nearClipPlane, this.camera.farClipPlane);
			}
			else
			{
				FrustumPlanes decomposeProjection = origProj.decomposeProjection;
				float num4 = Math.Abs(decomposeProjection.top) + Math.Abs(decomposeProjection.bottom);
				float num5 = Math.Abs(decomposeProjection.left) + Math.Abs(decomposeProjection.right);
				Vector2 vector2 = new Vector2(num * num5 / (float)this.actualWidth, num2 * num4 / (float)this.actualHeight);
				decomposeProjection.left += vector2.x;
				decomposeProjection.right += vector2.x;
				decomposeProjection.top += vector2.y;
				decomposeProjection.bottom += vector2.y;
				if (float.IsInfinity(decomposeProjection.zFar))
				{
					decomposeProjection.zFar = this.frustum.planes[5].distance;
				}
				result = Matrix4x4.Frustum(decomposeProjection);
			}
			return result;
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x0005EF5C File Offset: 0x0005D15C
		internal Matrix4x4 ComputePixelCoordToWorldSpaceViewDirectionMatrix(HDCamera.ViewConstants viewConstants, Vector4 resolution, float aspect = -1f, int cameraRelativeRendering = 1)
		{
			if ((this.xr.enabled || this.frameSettings.IsEnabled(FrameSettingsField.AsymmetricProjection)) | (HDUtils.IsProjectionMatrixAsymmetric(viewConstants.projMatrix) && !this.camera.usePhysicalProperties))
			{
				Matrix4x4 lhs = new Matrix4x4(new Vector4(2f * resolution.z, 0f, 0f, -1f), new Vector4(0f, -2f * resolution.w, 0f, 1f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));
				Matrix4x4 rhs;
				if (cameraRelativeRendering == 0)
				{
					Matrix4x4 viewMatrix = viewConstants.viewMatrix;
					viewMatrix.SetColumn(3, new Vector4(0f, 0f, 0f, 1f));
					rhs = (viewConstants.projMatrix * viewMatrix).inverse.transpose * Matrix4x4.Scale(new Vector3(-1f, -1f, -1f));
				}
				else
				{
					rhs = viewConstants.invViewProjMatrix.transpose * Matrix4x4.Scale(new Vector3(-1f, -1f, -1f));
				}
				return lhs * rhs;
			}
			float verticalFoV = this.camera.GetGateFittedFieldOfView() * 0.017453292f;
			if (!this.camera.usePhysicalProperties)
			{
				verticalFoV = Mathf.Atan(-1f / viewConstants.projMatrix[1, 1]) * 2f;
			}
			Vector2 gateFittedLensShift = this.camera.GetGateFittedLensShift();
			return HDUtils.ComputePixelCoordToWorldSpaceViewDirectionMatrix(verticalFoV, gateFittedLensShift, resolution, viewConstants.viewMatrix, false, aspect, this.camera.orthographic);
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x0005F12C File Offset: 0x0005D32C
		private void Dispose()
		{
			HDRenderPipeline.DestroyVolumetricHistoryBuffers(this);
			VolumeManager.instance.DestroyStack(this.volumeStack);
			if (this.m_HistoryRTSystem != null)
			{
				this.m_HistoryRTSystem.Dispose();
				this.m_HistoryRTSystem = null;
			}
			foreach (KeyValuePair<AOVRequestData, BufferedRTHandleSystem> keyValuePair in this.m_AOVHistoryRTSystem)
			{
				keyValuePair.Value.Dispose();
			}
			this.m_AOVHistoryRTSystem.Clear();
			if (this.lightingSky != null && this.lightingSky != this.visualSky)
			{
				this.lightingSky.Cleanup();
			}
			if (this.visualSky != null)
			{
				this.visualSky.Cleanup();
			}
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x0005F1F4 File Offset: 0x0005D3F4
		private static RTHandle HistoryBufferAllocatorFunction(string viewName, int frameIndex, RTHandleSystem rtHandleSystem)
		{
			frameIndex &= 1;
			HDRenderPipeline hdrenderPipeline = (HDRenderPipeline)RenderPipelineManager.currentPipeline;
			return rtHandleSystem.Alloc(Vector2.one, TextureXR.slices, DepthBits.None, hdrenderPipeline.GetColorBufferFormat(), FilterMode.Point, TextureWrapMode.Repeat, TextureXR.dimension, true, true, false, false, 1, 0f, MSAASamples.None, false, true, RenderTextureMemoryless.None, VRTextureUsage.None, string.Format("{0}_CameraColorBufferMipChain{1}", viewName, frameIndex));
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x0005F250 File Offset: 0x0005D450
		private void ReleaseHistoryBuffer()
		{
			this.m_HistoryRTSystem.ReleaseAll();
			foreach (KeyValuePair<AOVRequestData, BufferedRTHandleSystem> keyValuePair in this.m_AOVHistoryRTSystem)
			{
				keyValuePair.Value.ReleaseAll();
			}
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x0005F2B4 File Offset: 0x0005D4B4
		private Rect GetPixelRect()
		{
			if (this.m_OverridePixelRect != null)
			{
				return this.m_OverridePixelRect.Value;
			}
			return new Rect(this.camera.pixelRect.x, this.camera.pixelRect.y, (float)this.camera.pixelWidth, (float)this.camera.pixelHeight);
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x0005F31D File Offset: 0x0005D51D
		internal BufferedRTHandleSystem GetHistoryRTHandleSystem()
		{
			return this.m_HistoryRTSystem;
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x0005F325 File Offset: 0x0005D525
		internal void BindHistoryRTHandleSystem(BufferedRTHandleSystem historyRTSystem)
		{
			this.m_HistoryRTSystem = historyRTSystem;
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x0005F330 File Offset: 0x0005D530
		internal BufferedRTHandleSystem GetHistoryRTHandleSystem(AOVRequestData aovRequest)
		{
			BufferedRTHandleSystem result;
			if (this.m_AOVHistoryRTSystem.TryGetValue(aovRequest, out result))
			{
				return result;
			}
			BufferedRTHandleSystem bufferedRTHandleSystem = new BufferedRTHandleSystem();
			this.m_AOVHistoryRTSystem.Add(aovRequest, bufferedRTHandleSystem);
			return bufferedRTHandleSystem;
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x0005F37C File Offset: 0x0005D57C
		[CompilerGenerated]
		internal static RTHandle <SetupExposureTextures>g__Allocator|188_0(string id, int frameIndex, RTHandleSystem rtHandleSystem)
		{
			RTHandle rthandle = rtHandleSystem.Alloc(1, 1, 1, DepthBits.None, GraphicsFormat.R32G32_SFloat, FilterMode.Point, TextureWrapMode.Repeat, TextureDimension.Tex2D, true, false, true, false, 1, 0f, MSAASamples.None, false, false, RenderTextureMemoryless.None, VRTextureUsage.None, string.Format("{0} Exposure Texture {1}", id, frameIndex));
			HDRenderPipeline.SetExposureTextureToEmpty(rthandle);
			return rthandle;
		}

		// Token: 0x04000C75 RID: 3189
		public Vector4 screenSize;

		// Token: 0x04000C76 RID: 3190
		public Frustum frustum;

		// Token: 0x04000C77 RID: 3191
		public Camera camera;

		// Token: 0x04000C78 RID: 3192
		public Vector4 taaJitter;

		// Token: 0x04000C79 RID: 3193
		public HDCamera.ViewConstants mainViewConstants;

		// Token: 0x04000C7A RID: 3194
		public bool colorPyramidHistoryIsValid;

		// Token: 0x04000C7B RID: 3195
		public bool volumetricHistoryIsValid;

		// Token: 0x04000C7C RID: 3196
		internal int volumetricValidFrames;

		// Token: 0x04000C7D RID: 3197
		internal int colorPyramidHistoryValidFrames;

		// Token: 0x04000C7E RID: 3198
		internal float intermediateDownscaling = 0.5f;

		// Token: 0x04000C7F RID: 3199
		internal bool volumetricCloudsFullscaleHistory;

		// Token: 0x04000C85 RID: 3205
		public float time;

		// Token: 0x04000C86 RID: 3206
		internal bool dofHistoryIsValid;

		// Token: 0x04000C87 RID: 3207
		internal bool previousFrameWasTAAUpsampled;

		// Token: 0x04000C88 RID: 3208
		public RayTracingAccelerationStructure rayTracingAccelerationStructure;

		// Token: 0x04000C89 RID: 3209
		public bool transformsDirty;

		// Token: 0x04000C8A RID: 3210
		public bool materialsDirty;

		// Token: 0x04000C8B RID: 3211
		internal Vector4[] frustumPlaneEquations;

		// Token: 0x04000C8C RID: 3212
		internal int taaFrameIndex;

		// Token: 0x04000C8D RID: 3213
		internal float taaSharpenStrength;

		// Token: 0x04000C8E RID: 3214
		internal float taaHistorySharpening;

		// Token: 0x04000C8F RID: 3215
		internal float taaAntiFlicker;

		// Token: 0x04000C90 RID: 3216
		internal float taaMotionVectorRejection;

		// Token: 0x04000C91 RID: 3217
		internal float taaBaseBlendFactor;

		// Token: 0x04000C92 RID: 3218
		internal float taaJitterScale;

		// Token: 0x04000C93 RID: 3219
		internal bool taaAntiRinging;

		// Token: 0x04000C94 RID: 3220
		internal Vector4 zBufferParams;

		// Token: 0x04000C95 RID: 3221
		internal Vector4 unity_OrthoParams;

		// Token: 0x04000C96 RID: 3222
		internal Vector4 projectionParams;

		// Token: 0x04000C97 RID: 3223
		internal Vector4 screenParams;

		// Token: 0x04000C98 RID: 3224
		internal int volumeLayerMask;

		// Token: 0x04000C99 RID: 3225
		internal Transform volumeAnchor;

		// Token: 0x04000C9A RID: 3226
		internal Rect finalViewport = new Rect(Vector2.zero, -1f * Vector2.one);

		// Token: 0x04000C9B RID: 3227
		internal Rect prevFinalViewport;

		// Token: 0x04000C9C RID: 3228
		internal int colorPyramidHistoryMipCount;

		// Token: 0x04000C9D RID: 3229
		internal VBufferParameters[] vBufferParams;

		// Token: 0x04000C9E RID: 3230
		internal RTHandle[] volumetricHistoryBuffers;

		// Token: 0x04000C9F RID: 3231
		internal uint cameraFrameCount;

		// Token: 0x04000CA0 RID: 3232
		internal bool animateMaterials;

		// Token: 0x04000CA1 RID: 3233
		internal float lastTime;

		// Token: 0x04000CA2 RID: 3234
		private Camera m_parentCamera;

		// Token: 0x04000CA3 RID: 3235
		private Vector2 m_LowResHWDRSFactor = new Vector2(0f, 0f);

		// Token: 0x04000CA4 RID: 3236
		internal float lowResScale = 0.5f;

		// Token: 0x04000CA5 RID: 3237
		internal float historyLowResScale = 0.5f;

		// Token: 0x04000CA6 RID: 3238
		internal float lowResScaleForScreenSpaceLighting = 0.5f;

		// Token: 0x04000CA7 RID: 3239
		internal float historyLowResScaleForScreenSpaceLighting = 0.5f;

		// Token: 0x04000CA8 RID: 3240
		private Vector4 m_PostProcessScreenSize = new Vector4(0f, 0f, 0f, 0f);

		// Token: 0x04000CA9 RID: 3241
		private Vector4 m_PostProcessRTScales = new Vector4(1f, 1f, 1f, 1f);

		// Token: 0x04000CAA RID: 3242
		private Vector4 m_PostProcessRTScalesHistory = new Vector4(1f, 1f, 1f, 1f);

		// Token: 0x04000CAB RID: 3243
		private Vector2Int m_PostProcessRTHistoryMaxReference = new Vector2Int(1, 1);

		// Token: 0x04000CAC RID: 3244
		internal HDCamera.ShadowHistoryUsage[] shadowHistoryUsage;

		// Token: 0x04000CAD RID: 3245
		internal HDCamera.HistoryEffectValidity[] historyEffectUsage;

		// Token: 0x04000CAE RID: 3246
		internal bool realtimeReflectionProbe;

		// Token: 0x04000CAF RID: 3247
		internal SkyUpdateContext m_LightingOverrideSky = new SkyUpdateContext();

		// Token: 0x04000CB0 RID: 3248
		internal bool isPersistent;

		// Token: 0x04000CB1 RID: 3249
		internal HDUtils.PackedMipChainInfo m_DepthBufferMipChainInfo;

		// Token: 0x04000CBA RID: 3258
		private HDAdditionalCameraData.ClearColorMode m_PreviousClearColorMode = HDAdditionalCameraData.ClearColorMode.None;

		// Token: 0x04000CBB RID: 3259
		private float m_GpuExposureValue = 1f;

		// Token: 0x04000CBC RID: 3260
		private float m_GpuDeExposureValue = 1f;

		// Token: 0x04000CBD RID: 3261
		private Queue<HDCamera.ExposureGpuReadbackRequest> m_ExposureAsyncRequest = new Queue<HDCamera.ExposureGpuReadbackRequest>();

		// Token: 0x04000CBE RID: 3262
		private bool m_ExposureControlFS;

		// Token: 0x04000CBF RID: 3263
		private HDCamera.ExposureTextures m_ExposureTextures = new HDCamera.ExposureTextures
		{
			useCurrentCamera = true,
			current = null,
			previous = null
		};

		// Token: 0x04000CC3 RID: 3267
		internal bool resetPostProcessingHistory = true;

		// Token: 0x04000CC4 RID: 3268
		internal bool didResetPostProcessingHistoryInLastFrame;

		// Token: 0x04000CC6 RID: 3270
		private static Dictionary<ValueTuple<Camera, int>, HDCamera> s_Cameras = new Dictionary<ValueTuple<Camera, int>, HDCamera>();

		// Token: 0x04000CC7 RID: 3271
		private static List<ValueTuple<Camera, int>> s_Cleanup = new List<ValueTuple<Camera, int>>();

		// Token: 0x04000CC8 RID: 3272
		private HDAdditionalCameraData m_AdditionalCameraData;

		// Token: 0x04000CC9 RID: 3273
		private BufferedRTHandleSystem m_HistoryRTSystem = new BufferedRTHandleSystem();

		// Token: 0x04000CCA RID: 3274
		private int m_HistoryViewCount;

		// Token: 0x04000CCB RID: 3275
		private int m_NumVolumetricBuffersAllocated;

		// Token: 0x04000CCC RID: 3276
		private float m_AmbientOcclusionResolutionScale;

		// Token: 0x04000CCD RID: 3277
		private float m_ScreenSpaceAccumulationResolutionScale;

		// Token: 0x04000CCE RID: 3278
		private Dictionary<AOVRequestData, BufferedRTHandleSystem> m_AOVHistoryRTSystem = new Dictionary<AOVRequestData, BufferedRTHandleSystem>(new AOVRequestDataComparer());

		// Token: 0x04000CCF RID: 3279
		public ScreenSpaceReflectionAlgorithm currentSSRAlgorithm;

		// Token: 0x04000CD0 RID: 3280
		internal HDCamera.ViewConstants[] m_XRViewConstants;

		// Token: 0x04000CD1 RID: 3281
		private IEnumerator<Action<RenderTargetIdentifier, CommandBuffer>> m_RecorderCaptureActions;

		// Token: 0x04000CD2 RID: 3282
		private int m_RecorderTempRT = Shader.PropertyToID("TempRecorder");

		// Token: 0x04000CD3 RID: 3283
		private MaterialPropertyBlock m_RecorderPropertyBlock = new MaterialPropertyBlock();

		// Token: 0x04000CD4 RID: 3284
		private Rect? m_OverridePixelRect;

		// Token: 0x04000CD5 RID: 3285
		private DynamicResolutionHandler.UpsamplerScheduleType m_PrevUpsamplerSchedule = DynamicResolutionHandler.UpsamplerScheduleType.AfterPost;

		// Token: 0x020003AF RID: 943
		public struct ViewConstants
		{
			// Token: 0x0400260B RID: 9739
			public Matrix4x4 viewMatrix;

			// Token: 0x0400260C RID: 9740
			public Matrix4x4 invViewMatrix;

			// Token: 0x0400260D RID: 9741
			public Matrix4x4 projMatrix;

			// Token: 0x0400260E RID: 9742
			public Matrix4x4 invProjMatrix;

			// Token: 0x0400260F RID: 9743
			public Matrix4x4 viewProjMatrix;

			// Token: 0x04002610 RID: 9744
			public Matrix4x4 invViewProjMatrix;

			// Token: 0x04002611 RID: 9745
			public Matrix4x4 nonJitteredViewProjMatrix;

			// Token: 0x04002612 RID: 9746
			public Matrix4x4 prevViewMatrix;

			// Token: 0x04002613 RID: 9747
			public Matrix4x4 prevViewProjMatrix;

			// Token: 0x04002614 RID: 9748
			public Matrix4x4 prevInvViewProjMatrix;

			// Token: 0x04002615 RID: 9749
			public Matrix4x4 prevViewProjMatrixNoCameraTrans;

			// Token: 0x04002616 RID: 9750
			public Matrix4x4 pixelCoordToViewDirWS;

			// Token: 0x04002617 RID: 9751
			internal Matrix4x4 viewProjectionNoCameraTrans;

			// Token: 0x04002618 RID: 9752
			public Vector3 worldSpaceCameraPos;

			// Token: 0x04002619 RID: 9753
			internal float pad0;

			// Token: 0x0400261A RID: 9754
			public Vector3 worldSpaceCameraPosViewOffset;

			// Token: 0x0400261B RID: 9755
			internal float pad1;

			// Token: 0x0400261C RID: 9756
			public Vector3 prevWorldSpaceCameraPos;

			// Token: 0x0400261D RID: 9757
			internal float pad2;
		}

		// Token: 0x020003B0 RID: 944
		internal struct ShadowHistoryUsage
		{
			// Token: 0x0400261E RID: 9758
			public int lightInstanceID;

			// Token: 0x0400261F RID: 9759
			public uint frameCount;

			// Token: 0x04002620 RID: 9760
			public GPULightType lightType;

			// Token: 0x04002621 RID: 9761
			public Matrix4x4 transform;
		}

		// Token: 0x020003B1 RID: 945
		internal enum HistoryEffectSlot
		{
			// Token: 0x04002623 RID: 9763
			GlobalIllumination0,
			// Token: 0x04002624 RID: 9764
			GlobalIllumination1,
			// Token: 0x04002625 RID: 9765
			RayTracedReflections,
			// Token: 0x04002626 RID: 9766
			VolumetricClouds,
			// Token: 0x04002627 RID: 9767
			RayTracedAmbientOcclusion,
			// Token: 0x04002628 RID: 9768
			Count
		}

		// Token: 0x020003B2 RID: 946
		internal enum HistoryEffectFlags
		{
			// Token: 0x0400262A RID: 9770
			FullResolution = 1,
			// Token: 0x0400262B RID: 9771
			RayTraced,
			// Token: 0x0400262C RID: 9772
			ExposureControl = 4,
			// Token: 0x0400262D RID: 9773
			CustomBit0 = 8,
			// Token: 0x0400262E RID: 9774
			CustomBit1 = 16,
			// Token: 0x0400262F RID: 9775
			CustomBit2 = 32,
			// Token: 0x04002630 RID: 9776
			CustomBit3 = 64,
			// Token: 0x04002631 RID: 9777
			CustomBit4 = 128
		}

		// Token: 0x020003B3 RID: 947
		internal struct HistoryEffectValidity
		{
			// Token: 0x04002632 RID: 9778
			public int frameCount;

			// Token: 0x04002633 RID: 9779
			public int flagMask;
		}

		// Token: 0x020003B4 RID: 948
		internal struct VolumetricCloudsAnimationData
		{
			// Token: 0x04002634 RID: 9780
			public float lastTime;

			// Token: 0x04002635 RID: 9781
			public Vector2 cloudOffset;

			// Token: 0x04002636 RID: 9782
			public float verticalShapeOffset;

			// Token: 0x04002637 RID: 9783
			public float verticalErosionOffset;
		}

		// Token: 0x020003B5 RID: 949
		private struct ExposureGpuReadbackRequest
		{
			// Token: 0x04002638 RID: 9784
			public bool isDeExposure;

			// Token: 0x04002639 RID: 9785
			public AsyncGPUReadbackRequest request;
		}

		// Token: 0x020003B6 RID: 950
		internal struct ExposureTextures
		{
			// Token: 0x06001341 RID: 4929 RVA: 0x00092F8C File Offset: 0x0009118C
			public void clear()
			{
				this.parent = null;
				this.current = null;
				this.previous = null;
				this.useFetchedExposure = false;
				this.fetchedGpuExposure = 1f;
			}

			// Token: 0x0400263A RID: 9786
			public bool useCurrentCamera;

			// Token: 0x0400263B RID: 9787
			public RTHandle parent;

			// Token: 0x0400263C RID: 9788
			public RTHandle current;

			// Token: 0x0400263D RID: 9789
			public RTHandle previous;

			// Token: 0x0400263E RID: 9790
			public bool useFetchedExposure;

			// Token: 0x0400263F RID: 9791
			public float fetchedGpuExposure;
		}

		// Token: 0x020003B7 RID: 951
		internal struct DynamicResolutionRequest
		{
			// Token: 0x04002640 RID: 9792
			public bool enabled;

			// Token: 0x04002641 RID: 9793
			public bool cameraRequested;

			// Token: 0x04002642 RID: 9794
			public bool hardwareEnabled;

			// Token: 0x04002643 RID: 9795
			public DynamicResUpscaleFilter filter;
		}

		// Token: 0x020003B8 RID: 952
		private class ExecuteCaptureActionsPassData
		{
			// Token: 0x04002644 RID: 9796
			public TextureHandle input;

			// Token: 0x04002645 RID: 9797
			public TextureHandle tempTexture;

			// Token: 0x04002646 RID: 9798
			public IEnumerator<Action<RenderTargetIdentifier, CommandBuffer>> recorderCaptureActions;

			// Token: 0x04002647 RID: 9799
			public Vector2 viewportScale;

			// Token: 0x04002648 RID: 9800
			public Material blitMaterial;

			// Token: 0x04002649 RID: 9801
			public Rect viewportSize;
		}

		// Token: 0x020003B9 RID: 953
		internal struct CustomHistoryAllocator
		{
			// Token: 0x06001343 RID: 4931 RVA: 0x00092FBD File Offset: 0x000911BD
			public CustomHistoryAllocator(Vector2 scaleFactor, GraphicsFormat format, string name)
			{
				this.scaleFactor = scaleFactor;
				this.format = format;
				this.name = name;
			}

			// Token: 0x06001344 RID: 4932 RVA: 0x00092FD4 File Offset: 0x000911D4
			public RTHandle Allocator(string id, int frameIndex, RTHandleSystem rtHandleSystem)
			{
				return rtHandleSystem.Alloc(Vector2.one * this.scaleFactor, TextureXR.slices, DepthBits.None, this.format, FilterMode.Point, TextureWrapMode.Repeat, TextureXR.dimension, true, false, true, false, 1, 0f, MSAASamples.None, false, true, RenderTextureMemoryless.None, VRTextureUsage.None, string.Format("{0}_{1}_{2}", id, this.name, frameIndex));
			}

			// Token: 0x0400264A RID: 9802
			private Vector2 scaleFactor;

			// Token: 0x0400264B RID: 9803
			private GraphicsFormat format;

			// Token: 0x0400264C RID: 9804
			private string name;
		}
	}
}
