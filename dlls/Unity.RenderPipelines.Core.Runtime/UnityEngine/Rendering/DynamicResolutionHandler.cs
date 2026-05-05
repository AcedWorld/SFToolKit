using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
	// Token: 0x02000044 RID: 68
	public class DynamicResolutionHandler
	{
		// Token: 0x0600025C RID: 604 RVA: 0x0000B4D0 File Offset: 0x000096D0
		private void Reset()
		{
			this.m_Enabled = false;
			this.m_UseMipBias = false;
			this.m_MinScreenFraction = 1f;
			this.m_MaxScreenFraction = 1f;
			this.m_CurrentFraction = 1f;
			this.m_ForcingRes = false;
			this.m_CurrentCameraRequest = true;
			this.m_PrevFraction = -1f;
			this.m_ForceSoftwareFallback = false;
			this.m_RunUpscalerFilterOnFullResolution = false;
			this.m_PrevHWScaleWidth = 1f;
			this.m_PrevHWScaleHeight = 1f;
			this.m_LastScaledSize = new Vector2Int(0, 0);
			this.filter = DynamicResUpscaleFilter.CatmullRom;
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600025D RID: 605 RVA: 0x0000B55D File Offset: 0x0000975D
		// (set) Token: 0x0600025E RID: 606 RVA: 0x0000B565 File Offset: 0x00009765
		public DynamicResUpscaleFilter filter { get; private set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600025F RID: 607 RVA: 0x0000B56E File Offset: 0x0000976E
		// (set) Token: 0x06000260 RID: 608 RVA: 0x0000B576 File Offset: 0x00009776
		public Vector2Int finalViewport { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000262 RID: 610 RVA: 0x0000B588 File Offset: 0x00009788
		// (set) Token: 0x06000261 RID: 609 RVA: 0x0000B57F File Offset: 0x0000977F
		public bool runUpscalerFilterOnFullResolution
		{
			get
			{
				return this.m_RunUpscalerFilterOnFullResolution || this.filter == DynamicResUpscaleFilter.EdgeAdaptiveScalingUpres;
			}
			set
			{
				this.m_RunUpscalerFilterOnFullResolution = value;
			}
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000B5A0 File Offset: 0x000097A0
		private bool FlushScalableBufferManagerState()
		{
			if (DynamicResolutionHandler.s_GlobalHwUpresActive == this.HardwareDynamicResIsEnabled() && DynamicResolutionHandler.s_GlobalHwFraction == this.m_CurrentFraction)
			{
				return false;
			}
			DynamicResolutionHandler.s_GlobalHwUpresActive = this.HardwareDynamicResIsEnabled();
			DynamicResolutionHandler.s_GlobalHwFraction = this.m_CurrentFraction;
			float num = DynamicResolutionHandler.s_GlobalHwUpresActive ? DynamicResolutionHandler.s_GlobalHwFraction : 1f;
			ScalableBufferManager.ResizeBuffers(num, num);
			return true;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000B5FC File Offset: 0x000097FC
		private static DynamicResolutionHandler GetOrCreateDrsInstanceHandler(Camera camera)
		{
			if (camera == null)
			{
				return null;
			}
			DynamicResolutionHandler dynamicResolutionHandler = null;
			int instanceID = camera.GetInstanceID();
			if (!DynamicResolutionHandler.s_CameraInstances.TryGetValue(instanceID, out dynamicResolutionHandler))
			{
				if (DynamicResolutionHandler.s_CameraInstances.Count >= 32)
				{
					int key = 0;
					DynamicResolutionHandler dynamicResolutionHandler2 = null;
					foreach (KeyValuePair<int, DynamicResolutionHandler> keyValuePair in DynamicResolutionHandler.s_CameraInstances)
					{
						if (keyValuePair.Value.m_OwnerCameraWeakRef == null || !keyValuePair.Value.m_OwnerCameraWeakRef.IsAlive)
						{
							dynamicResolutionHandler2 = keyValuePair.Value;
							key = keyValuePair.Key;
							break;
						}
					}
					if (dynamicResolutionHandler2 != null)
					{
						dynamicResolutionHandler = dynamicResolutionHandler2;
						DynamicResolutionHandler.s_CameraInstances.Remove(key);
						DynamicResolutionHandler.s_CameraUpscaleFilters.Remove(key);
					}
				}
				if (dynamicResolutionHandler == null)
				{
					dynamicResolutionHandler = new DynamicResolutionHandler();
					dynamicResolutionHandler.m_OwnerCameraWeakRef = new WeakReference(camera);
				}
				else
				{
					dynamicResolutionHandler.Reset();
					dynamicResolutionHandler.m_OwnerCameraWeakRef.Target = camera;
				}
				DynamicResolutionHandler.s_CameraInstances.Add(instanceID, dynamicResolutionHandler);
			}
			return dynamicResolutionHandler;
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000266 RID: 614 RVA: 0x0000B715 File Offset: 0x00009915
		// (set) Token: 0x06000265 RID: 613 RVA: 0x0000B70C File Offset: 0x0000990C
		public DynamicResolutionHandler.UpsamplerScheduleType upsamplerSchedule
		{
			get
			{
				return this.m_UpsamplerSchedule;
			}
			set
			{
				this.m_UpsamplerSchedule = value;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000267 RID: 615 RVA: 0x0000B71D File Offset: 0x0000991D
		public static DynamicResolutionHandler instance
		{
			get
			{
				return DynamicResolutionHandler.s_ActiveInstance;
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000B724 File Offset: 0x00009924
		private DynamicResolutionHandler()
		{
			this.Reset();
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000B744 File Offset: 0x00009944
		private static float DefaultDynamicResMethod()
		{
			return 1f;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000B74C File Offset: 0x0000994C
		private void ProcessSettings(GlobalDynamicResolutionSettings settings)
		{
			this.m_Enabled = (settings.enabled && (Application.isPlaying || settings.forceResolution));
			if (!this.m_Enabled)
			{
				this.m_CurrentFraction = 1f;
			}
			else
			{
				this.type = settings.dynResType;
				this.m_UseMipBias = settings.useMipBias;
				float minScreenFraction = Mathf.Clamp(settings.minPercentage / 100f, 0.1f, 1f);
				this.m_MinScreenFraction = minScreenFraction;
				float maxScreenFraction = Mathf.Clamp(settings.maxPercentage / 100f, this.m_MinScreenFraction, 3f);
				this.m_MaxScreenFraction = maxScreenFraction;
				DynamicResUpscaleFilter dynamicResUpscaleFilter;
				this.filter = (DynamicResolutionHandler.s_CameraUpscaleFilters.TryGetValue(DynamicResolutionHandler.s_ActiveCameraId, out dynamicResUpscaleFilter) ? dynamicResUpscaleFilter : settings.upsampleFilter);
				this.m_ForcingRes = settings.forceResolution;
				if (this.m_ForcingRes)
				{
					float currentFraction = Mathf.Clamp(settings.forcedPercentage / 100f, 0.1f, 1.5f);
					this.m_CurrentFraction = currentFraction;
				}
			}
			this.m_CachedSettings = settings;
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000B858 File Offset: 0x00009A58
		public Vector2 GetResolvedScale()
		{
			if (!this.m_Enabled || !this.m_CurrentCameraRequest)
			{
				return new Vector2(1f, 1f);
			}
			float x = this.m_CurrentFraction;
			float y = this.m_CurrentFraction;
			if (!this.m_ForceSoftwareFallback && this.type == DynamicResolutionType.Hardware)
			{
				x = ScalableBufferManager.widthScaleFactor;
				y = ScalableBufferManager.heightScaleFactor;
			}
			return new Vector2(x, y);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000B8B7 File Offset: 0x00009AB7
		public float CalculateMipBias(Vector2Int inputResolution, Vector2Int outputResolution, bool forceApply = false)
		{
			if (!this.m_UseMipBias && !forceApply)
			{
				return 0f;
			}
			return (float)Math.Log((double)inputResolution.x / (double)outputResolution.x, 2.0);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000B8EC File Offset: 0x00009AEC
		public static void SetDynamicResScaler(PerformDynamicRes scaler, DynamicResScalePolicyType scalerType = DynamicResScalePolicyType.ReturnsMinMaxLerpFactor)
		{
			DynamicResolutionHandler.s_ScalerContainers[0] = new DynamicResolutionHandler.ScalerContainer
			{
				type = scalerType,
				method = scaler
			};
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000B920 File Offset: 0x00009B20
		public static void SetSystemDynamicResScaler(PerformDynamicRes scaler, DynamicResScalePolicyType scalerType = DynamicResScalePolicyType.ReturnsMinMaxLerpFactor)
		{
			DynamicResolutionHandler.s_ScalerContainers[1] = new DynamicResolutionHandler.ScalerContainer
			{
				type = scalerType,
				method = scaler
			};
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000B951 File Offset: 0x00009B51
		public static void SetActiveDynamicScalerSlot(DynamicResScalerSlot slot)
		{
			DynamicResolutionHandler.s_ActiveScalerSlot = slot;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000B959 File Offset: 0x00009B59
		public static void ClearSelectedCamera()
		{
			DynamicResolutionHandler.s_ActiveInstance = DynamicResolutionHandler.s_DefaultInstance;
			DynamicResolutionHandler.s_ActiveCameraId = 0;
			DynamicResolutionHandler.s_ActiveInstanceDirty = true;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000B974 File Offset: 0x00009B74
		public static void SetUpscaleFilter(Camera camera, DynamicResUpscaleFilter filter)
		{
			int instanceID = camera.GetInstanceID();
			if (DynamicResolutionHandler.s_CameraUpscaleFilters.ContainsKey(instanceID))
			{
				DynamicResolutionHandler.s_CameraUpscaleFilters[instanceID] = filter;
				return;
			}
			DynamicResolutionHandler.s_CameraUpscaleFilters.Add(instanceID, filter);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000B9AE File Offset: 0x00009BAE
		public void SetCurrentCameraRequest(bool cameraRequest)
		{
			this.m_CurrentCameraRequest = cameraRequest;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000B9B8 File Offset: 0x00009BB8
		public static void UpdateAndUseCamera(Camera camera, GlobalDynamicResolutionSettings? settings = null, Action OnResolutionChange = null)
		{
			int num;
			if (camera == null)
			{
				DynamicResolutionHandler.s_ActiveInstance = DynamicResolutionHandler.s_DefaultInstance;
				num = 0;
			}
			else
			{
				DynamicResolutionHandler.s_ActiveInstance = DynamicResolutionHandler.GetOrCreateDrsInstanceHandler(camera);
				num = camera.GetInstanceID();
			}
			DynamicResolutionHandler.s_ActiveInstanceDirty = (num != DynamicResolutionHandler.s_ActiveCameraId);
			DynamicResolutionHandler.s_ActiveCameraId = num;
			DynamicResolutionHandler.s_ActiveInstance.Update((settings != null) ? settings.Value : DynamicResolutionHandler.s_ActiveInstance.m_CachedSettings, OnResolutionChange);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000BA2C File Offset: 0x00009C2C
		public void Update(GlobalDynamicResolutionSettings settings, Action OnResolutionChange = null)
		{
			this.ProcessSettings(settings);
			if (!this.m_Enabled || !DynamicResolutionHandler.s_ActiveInstanceDirty)
			{
				this.FlushScalableBufferManagerState();
				DynamicResolutionHandler.s_ActiveInstanceDirty = false;
				return;
			}
			if (!this.m_ForcingRes)
			{
				ref DynamicResolutionHandler.ScalerContainer ptr = ref DynamicResolutionHandler.s_ScalerContainers[(int)DynamicResolutionHandler.s_ActiveScalerSlot];
				if (ptr.type == DynamicResScalePolicyType.ReturnsMinMaxLerpFactor)
				{
					float t = Mathf.Clamp(ptr.method(), 0f, 1f);
					this.m_CurrentFraction = Mathf.Lerp(this.m_MinScreenFraction, this.m_MaxScreenFraction, t);
				}
				else if (ptr.type == DynamicResScalePolicyType.ReturnsPercentage)
				{
					float num = Mathf.Max(ptr.method(), 5f);
					this.m_CurrentFraction = Mathf.Clamp(num / 100f, this.m_MinScreenFraction, this.m_MaxScreenFraction);
				}
			}
			bool flag = false;
			bool flag2 = this.m_CurrentFraction != this.m_PrevFraction;
			this.m_PrevFraction = this.m_CurrentFraction;
			if (!this.m_ForceSoftwareFallback && this.type == DynamicResolutionType.Hardware)
			{
				flag = this.FlushScalableBufferManagerState();
				if (ScalableBufferManager.widthScaleFactor != this.m_PrevHWScaleWidth || ScalableBufferManager.heightScaleFactor != this.m_PrevHWScaleHeight)
				{
					flag = true;
				}
			}
			if ((flag2 || flag) && OnResolutionChange != null)
			{
				OnResolutionChange();
			}
			DynamicResolutionHandler.s_ActiveInstanceDirty = false;
			this.m_PrevHWScaleWidth = ScalableBufferManager.widthScaleFactor;
			this.m_PrevHWScaleHeight = ScalableBufferManager.heightScaleFactor;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000BB6E File Offset: 0x00009D6E
		public bool SoftwareDynamicResIsEnabled()
		{
			return this.m_CurrentCameraRequest && this.m_Enabled && (this.m_CurrentFraction != 1f || this.runUpscalerFilterOnFullResolution) && (this.m_ForceSoftwareFallback || this.type == DynamicResolutionType.Software);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000BBAA File Offset: 0x00009DAA
		public bool HardwareDynamicResIsEnabled()
		{
			return !this.m_ForceSoftwareFallback && this.m_CurrentCameraRequest && this.m_Enabled && this.type == DynamicResolutionType.Hardware;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000BBCF File Offset: 0x00009DCF
		public bool RequestsHardwareDynamicResolution()
		{
			return !this.m_ForceSoftwareFallback && this.type == DynamicResolutionType.Hardware;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000BBE4 File Offset: 0x00009DE4
		public bool DynamicResolutionEnabled()
		{
			return this.m_CurrentCameraRequest && this.m_Enabled && (this.m_CurrentFraction != 1f || this.runUpscalerFilterOnFullResolution);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000BC0D File Offset: 0x00009E0D
		public void ForceSoftwareFallback()
		{
			this.m_ForceSoftwareFallback = true;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000BC18 File Offset: 0x00009E18
		public Vector2Int GetScaledSize(Vector2Int size)
		{
			this.cachedOriginalSize = size;
			if (!this.m_Enabled || !this.m_CurrentCameraRequest)
			{
				return size;
			}
			Vector2Int vector2Int = this.ApplyScalesOnSize(size);
			this.m_LastScaledSize = vector2Int;
			return vector2Int;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000BC4E File Offset: 0x00009E4E
		public Vector2Int ApplyScalesOnSize(Vector2Int size)
		{
			return this.ApplyScalesOnSize(size, this.GetResolvedScale());
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000BC60 File Offset: 0x00009E60
		internal Vector2Int ApplyScalesOnSize(Vector2Int size, Vector2 scales)
		{
			Vector2Int result = new Vector2Int(Mathf.CeilToInt((float)size.x * scales.x), Mathf.CeilToInt((float)size.y * scales.y));
			if (this.m_ForceSoftwareFallback || this.type != DynamicResolutionType.Hardware)
			{
				result.x += (1 & result.x);
				result.y += (1 & result.y);
			}
			result.x = Math.Min(result.x, size.x);
			result.y = Math.Min(result.y, size.y);
			return result;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000BD10 File Offset: 0x00009F10
		public float GetCurrentScale()
		{
			if (!this.m_Enabled || !this.m_CurrentCameraRequest)
			{
				return 1f;
			}
			return this.m_CurrentFraction;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000BD2E File Offset: 0x00009F2E
		public Vector2Int GetLastScaledSize()
		{
			return this.m_LastScaledSize;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000BD36 File Offset: 0x00009F36
		public float GetLowResMultiplier(float targetLowRes)
		{
			return this.GetLowResMultiplier(targetLowRes, this.m_CachedSettings.lowResTransparencyMinimumThreshold);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000BD4C File Offset: 0x00009F4C
		public float GetLowResMultiplier(float targetLowRes, float minimumThreshold)
		{
			if (!this.m_Enabled)
			{
				return targetLowRes;
			}
			float num = Math.Min(minimumThreshold / 100f, targetLowRes);
			if (targetLowRes * this.m_CurrentFraction >= num)
			{
				return targetLowRes;
			}
			return Mathf.Clamp(num / this.m_CurrentFraction, 0f, 1f);
		}

		// Token: 0x04000155 RID: 341
		private bool m_Enabled;

		// Token: 0x04000156 RID: 342
		private bool m_UseMipBias;

		// Token: 0x04000157 RID: 343
		private float m_MinScreenFraction;

		// Token: 0x04000158 RID: 344
		private float m_MaxScreenFraction;

		// Token: 0x04000159 RID: 345
		private float m_CurrentFraction;

		// Token: 0x0400015A RID: 346
		private bool m_ForcingRes;

		// Token: 0x0400015B RID: 347
		private bool m_CurrentCameraRequest;

		// Token: 0x0400015C RID: 348
		private float m_PrevFraction;

		// Token: 0x0400015D RID: 349
		private bool m_ForceSoftwareFallback;

		// Token: 0x0400015E RID: 350
		private bool m_RunUpscalerFilterOnFullResolution;

		// Token: 0x0400015F RID: 351
		private float m_PrevHWScaleWidth;

		// Token: 0x04000160 RID: 352
		private float m_PrevHWScaleHeight;

		// Token: 0x04000161 RID: 353
		private Vector2Int m_LastScaledSize;

		// Token: 0x04000162 RID: 354
		private static DynamicResScalerSlot s_ActiveScalerSlot = DynamicResScalerSlot.User;

		// Token: 0x04000163 RID: 355
		private static DynamicResolutionHandler.ScalerContainer[] s_ScalerContainers = new DynamicResolutionHandler.ScalerContainer[]
		{
			new DynamicResolutionHandler.ScalerContainer
			{
				type = DynamicResScalePolicyType.ReturnsMinMaxLerpFactor,
				method = new PerformDynamicRes(DynamicResolutionHandler.DefaultDynamicResMethod)
			},
			new DynamicResolutionHandler.ScalerContainer
			{
				type = DynamicResScalePolicyType.ReturnsMinMaxLerpFactor,
				method = new PerformDynamicRes(DynamicResolutionHandler.DefaultDynamicResMethod)
			}
		};

		// Token: 0x04000164 RID: 356
		private Vector2Int cachedOriginalSize;

		// Token: 0x04000166 RID: 358
		private static Dictionary<int, DynamicResUpscaleFilter> s_CameraUpscaleFilters = new Dictionary<int, DynamicResUpscaleFilter>();

		// Token: 0x04000168 RID: 360
		private DynamicResolutionType type;

		// Token: 0x04000169 RID: 361
		private GlobalDynamicResolutionSettings m_CachedSettings = GlobalDynamicResolutionSettings.NewDefault();

		// Token: 0x0400016A RID: 362
		private const int CameraDictionaryMaxcCapacity = 32;

		// Token: 0x0400016B RID: 363
		private WeakReference m_OwnerCameraWeakRef;

		// Token: 0x0400016C RID: 364
		private static Dictionary<int, DynamicResolutionHandler> s_CameraInstances = new Dictionary<int, DynamicResolutionHandler>(32);

		// Token: 0x0400016D RID: 365
		private static DynamicResolutionHandler s_DefaultInstance = new DynamicResolutionHandler();

		// Token: 0x0400016E RID: 366
		private static int s_ActiveCameraId = 0;

		// Token: 0x0400016F RID: 367
		private static DynamicResolutionHandler s_ActiveInstance = DynamicResolutionHandler.s_DefaultInstance;

		// Token: 0x04000170 RID: 368
		private static bool s_ActiveInstanceDirty = true;

		// Token: 0x04000171 RID: 369
		private static float s_GlobalHwFraction = 1f;

		// Token: 0x04000172 RID: 370
		private static bool s_GlobalHwUpresActive = false;

		// Token: 0x04000173 RID: 371
		private DynamicResolutionHandler.UpsamplerScheduleType m_UpsamplerSchedule = DynamicResolutionHandler.UpsamplerScheduleType.AfterPost;

		// Token: 0x0200015B RID: 347
		private struct ScalerContainer
		{
			// Token: 0x040005E9 RID: 1513
			public DynamicResScalePolicyType type;

			// Token: 0x040005EA RID: 1514
			public PerformDynamicRes method;
		}

		// Token: 0x0200015C RID: 348
		public enum UpsamplerScheduleType
		{
			// Token: 0x040005EC RID: 1516
			BeforePost,
			// Token: 0x040005ED RID: 1517
			AfterDepthOfField,
			// Token: 0x040005EE RID: 1518
			AfterPost
		}
	}
}
