using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering.HighDefinition.Attributes;
using UnityEngine.Video;

namespace UnityEngine.Rendering.HighDefinition.Compositor
{
	// Token: 0x02000240 RID: 576
	[Serializable]
	internal class CompositorLayer
	{
		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06001029 RID: 4137 RVA: 0x0007CCF3 File Offset: 0x0007AEF3
		public string name
		{
			get
			{
				return this.m_LayerName;
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x0600102A RID: 4138 RVA: 0x0007CCFB File Offset: 0x0007AEFB
		public CompositorLayer.OutputTarget outputTarget
		{
			get
			{
				return this.m_OutputTarget;
			}
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x0600102B RID: 4139 RVA: 0x0007CD03 File Offset: 0x0007AF03
		public Camera sourceCamera
		{
			get
			{
				return this.m_Camera;
			}
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x0600102C RID: 4140 RVA: 0x0007CD0B File Offset: 0x0007AF0B
		public bool hasLayerOverrides
		{
			get
			{
				return this.m_OverrideAntialiasing || this.m_OverrideCullingMask || this.m_OverrideVolumeMask || this.m_OverrideClearMode;
			}
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x0600102D RID: 4141 RVA: 0x0007CD2D File Offset: 0x0007AF2D
		// (set) Token: 0x0600102E RID: 4142 RVA: 0x0007CD35 File Offset: 0x0007AF35
		public bool clearsBackGround
		{
			get
			{
				return this.m_ClearsBackGround;
			}
			set
			{
				this.m_ClearsBackGround = value;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x0600102F RID: 4143 RVA: 0x0007CD3E File Offset: 0x0007AF3E
		// (set) Token: 0x06001030 RID: 4144 RVA: 0x0007CD46 File Offset: 0x0007AF46
		public bool enabled
		{
			get
			{
				return this.m_Show;
			}
			set
			{
				this.m_Show = value;
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06001031 RID: 4145 RVA: 0x0007CD50 File Offset: 0x0007AF50
		public float aspectRatio
		{
			get
			{
				CompositionManager instance = CompositionManager.GetInstance();
				if (instance != null && instance.outputCamera != null)
				{
					return (float)instance.outputCamera.pixelWidth / (float)instance.outputCamera.pixelHeight;
				}
				return 1f;
			}
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06001032 RID: 4146 RVA: 0x0007CD99 File Offset: 0x0007AF99
		public Camera camera
		{
			get
			{
				return this.m_LayerCamera;
			}
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06001033 RID: 4147 RVA: 0x0007CDA1 File Offset: 0x0007AFA1
		internal bool isUsingACameraClone
		{
			get
			{
				return !this.m_LayerCamera.Equals(this.m_Camera);
			}
		}

		// Token: 0x06001034 RID: 4148 RVA: 0x0007CDB8 File Offset: 0x0007AFB8
		private CompositorLayer()
		{
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x0007CE08 File Offset: 0x0007B008
		public static CompositorLayer CreateStackLayer(CompositorLayer.LayerType type = CompositorLayer.LayerType.Camera, string layerName = "New Layer")
		{
			CompositorLayer compositorLayer = new CompositorLayer();
			compositorLayer.m_LayerName = layerName;
			compositorLayer.m_Type = type;
			compositorLayer.m_Camera = CompositionManager.GetSceneCamera();
			compositorLayer.m_CullingMask = (compositorLayer.m_Camera ? compositorLayer.m_Camera.cullingMask : 0);
			compositorLayer.m_OutputTarget = CompositorLayer.OutputTarget.CameraStack;
			compositorLayer.m_ClearDepth = true;
			if (compositorLayer.m_Type == CompositorLayer.LayerType.Image || compositorLayer.m_Type == CompositorLayer.LayerType.Video)
			{
				if (compositorLayer.m_Camera == null)
				{
					compositorLayer.m_Camera = CompositionManager.CreateCamera(layerName);
				}
				compositorLayer.m_OverrideCullingMask = true;
				compositorLayer.m_CullingMask = 0;
				compositorLayer.m_OverrideVolumeMask = true;
				compositorLayer.m_VolumeMask = 0;
				compositorLayer.m_ClearAlpha = false;
				compositorLayer.m_OverrideAntialiasing = true;
				compositorLayer.m_Antialiasing = HDAdditionalCameraData.AntialiasingMode.None;
			}
			return compositorLayer;
		}

		// Token: 0x06001036 RID: 4150 RVA: 0x0007CED0 File Offset: 0x0007B0D0
		public static CompositorLayer CreateOutputLayer(string layerName)
		{
			return new CompositorLayer
			{
				m_LayerName = layerName,
				m_OutputTarget = CompositorLayer.OutputTarget.CompositorLayer
			};
		}

		// Token: 0x06001037 RID: 4151 RVA: 0x0007CEE5 File Offset: 0x0007B0E5
		private static float EnumToScale(CompositorLayer.ResolutionScale scale)
		{
			return 1f / (float)scale;
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x0007CEEF File Offset: 0x0007B0EF
		private static T AddComponent<T>(GameObject go, bool allowUndo = false) where T : Component
		{
			return go.AddComponent<T>();
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06001039 RID: 4153 RVA: 0x0007CEF8 File Offset: 0x0007B0F8
		public int pixelWidth
		{
			get
			{
				CompositionManager instance = CompositionManager.GetInstance();
				if (instance && instance.outputCamera)
				{
					return (int)(CompositorLayer.EnumToScale(this.m_ResolutionScale) * (float)instance.outputCamera.pixelWidth);
				}
				return 0;
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x0600103A RID: 4154 RVA: 0x0007CF3C File Offset: 0x0007B13C
		public int pixelHeight
		{
			get
			{
				CompositionManager instance = CompositionManager.GetInstance();
				if (instance && instance.outputCamera)
				{
					return (int)(CompositorLayer.EnumToScale(this.m_ResolutionScale) * (float)instance.outputCamera.pixelHeight);
				}
				return 0;
			}
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x0007CF80 File Offset: 0x0007B180
		public void Init(string layerID = "", bool allowUndo = false)
		{
			if (this.m_LayerName == "")
			{
				this.m_LayerName = layerID;
			}
			CompositionManager instance = CompositionManager.GetInstance();
			if (this.m_LayerCamera == null && this.m_OutputTarget == CompositorLayer.OutputTarget.CameraStack)
			{
				bool flag = !this.enabled && this.m_LayerPositionInStack == 0 && this.m_Camera;
				if (this.m_Type != CompositorLayer.LayerType.Image && this.m_Type != CompositorLayer.LayerType.Video && !this.hasLayerOverrides && !flag && !instance.IsThisCameraShared(this.m_Camera))
				{
					this.m_LayerCamera = this.m_Camera;
				}
				else
				{
					GameObject gameObject = new GameObject("Layer " + layerID)
					{
						hideFlags = (HideFlags.HideInHierarchy | HideFlags.HideInInspector | HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild | HideFlags.DontUnloadUnusedAsset)
					};
					this.m_LayerCamera = gameObject.AddComponent<Camera>();
					gameObject.AddComponent<HDAdditionalCameraData>();
					this.CopyInternalCameraData();
					CompositorCameraRegistry.GetInstance().RegisterInternalCamera(this.m_LayerCamera);
					this.m_LayerCamera.name = "Compositor" + layerID;
					this.m_LayerCamera.gameObject.hideFlags = (HideFlags.HideInHierarchy | HideFlags.HideInInspector | HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild | HideFlags.DontUnloadUnusedAsset);
					if (this.m_LayerCamera.tag == "MainCamera")
					{
						this.m_LayerCamera.tag = "Untagged";
					}
				}
			}
			this.m_ClearsBackGround = false;
			this.m_LayerPositionInStack = 0;
			if (this.m_ColorBufferFormat != CompositorLayer.UIColorBufferFormat.R11G11B10 && this.m_ColorBufferFormat != CompositorLayer.UIColorBufferFormat.R16G16B16A16 && this.m_ColorBufferFormat != CompositorLayer.UIColorBufferFormat.R32G32B32A32)
			{
				this.m_ColorBufferFormat = CompositorLayer.UIColorBufferFormat.R16G16B16A16;
			}
			if (this.m_OutputTarget != CompositorLayer.OutputTarget.CameraStack && this.m_RenderTarget == null && instance.outputCamera.pixelWidth > 0 && instance.outputCamera.pixelHeight > 0)
			{
				float num = CompositorLayer.EnumToScale(this.m_ResolutionScale);
				int width = (int)(num * (float)instance.outputCamera.pixelWidth);
				int height = (int)(num * (float)instance.outputCamera.pixelHeight);
				this.m_RenderTarget = new RenderTexture(width, height, 24, (GraphicsFormat)this.m_ColorBufferFormat);
			}
			if (this.m_OutputTarget != CompositorLayer.OutputTarget.CameraStack && this.m_RTHandle == null && this.m_RenderTarget != null)
			{
				this.m_RTHandle = RTHandles.Alloc(this.m_RenderTarget);
			}
			if (this.m_OutputTarget != CompositorLayer.OutputTarget.CameraStack && this.m_AOVBitmask != MaterialSharedProperty.None)
			{
				int num2 = 1 << (int)this.m_AOVBitmask;
				if (num2 > 1)
				{
					this.m_AOVMap = new Dictionary<string, int>();
					this.m_AOVRenderTargets = new List<RenderTexture>();
					this.m_AOVHandles = new List<RTHandle>();
					string[] names = Enum.GetNames(typeof(MaterialSharedProperty));
					int num3 = names.Length;
					int num4 = 0;
					for (int i = 0; i < num3; i++)
					{
						if ((num2 & 1 << i) != 0)
						{
							this.m_AOVMap[names[i]] = num4;
							this.m_AOVRenderTargets.Add(new RenderTexture(this.pixelWidth, this.pixelHeight, 24, (GraphicsFormat)this.m_ColorBufferFormat));
							this.m_AOVHandles.Add(RTHandles.Alloc(this.m_AOVRenderTargets[num4]));
							num4++;
						}
					}
				}
			}
			else
			{
				if (this.m_AOVRenderTargets != null)
				{
					foreach (RenderTexture obj in this.m_AOVRenderTargets)
					{
						CoreUtils.Destroy(obj);
					}
					this.m_AOVRenderTargets.Clear();
				}
				if (this.m_AOVMap != null)
				{
					this.m_AOVMap.Clear();
					this.m_AOVMap = null;
				}
			}
			if (this.m_OutputRenderer != null && Application.IsPlaying(instance.gameObject))
			{
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				materialPropertyBlock.SetTexture("_BaseColorMap", this.m_RenderTarget);
				this.m_OutputRenderer.SetPropertyBlock(materialPropertyBlock);
			}
			if (this.m_LayerCamera)
			{
				this.m_LayerCamera.enabled = this.m_Show;
				HDAdditionalCameraData hdadditionalCameraData = this.m_LayerCamera.GetComponent<HDAdditionalCameraData>() ?? CompositorLayer.AddComponent<HDAdditionalCameraData>(this.m_LayerCamera.gameObject, false);
				AdditionalCompositorData additionalCompositorData = this.m_LayerCamera.GetComponent<AdditionalCompositorData>();
				if (additionalCompositorData == null)
				{
					additionalCompositorData = CompositorLayer.AddComponent<AdditionalCompositorData>(this.m_LayerCamera.gameObject, allowUndo);
					additionalCompositorData.hideFlags = (HideFlags.HideInHierarchy | HideFlags.HideInInspector | HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild | HideFlags.DontUnloadUnusedAsset);
				}
				if (additionalCompositorData != null)
				{
					additionalCompositorData.ResetData();
				}
				this.SetLayerMaskOverrides();
				if (this.m_Type == CompositorLayer.LayerType.Video && this.m_InputVideo != null)
				{
					this.m_InputVideo.targetCamera = this.m_LayerCamera;
					this.m_InputVideo.renderMode = VideoRenderMode.CameraNearPlane;
				}
				else if (this.m_Type == CompositorLayer.LayerType.Image && this.m_InputTexture != null)
				{
					hdadditionalCameraData.clearColorMode = HDAdditionalCameraData.ClearColorMode.None;
					additionalCompositorData.clearColorTexture = this.m_InputTexture;
					additionalCompositorData.imageFitMode = this.m_BackgroundFit;
				}
				this.SetAdditionalLayerData();
				if (this.m_InputFilters == null)
				{
					this.m_InputFilters = new List<CompositionFilter>();
				}
			}
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x0007D438 File Offset: 0x0007B638
		public bool Validate()
		{
			if ((this.m_OutputTarget != CompositorLayer.OutputTarget.CameraStack && this.m_RenderTarget == null) || (this.m_OutputTarget != CompositorLayer.OutputTarget.CameraStack && this.m_RTHandle == null))
			{
				this.Init("", false);
			}
			if (this.m_OutputTarget == CompositorLayer.OutputTarget.CameraStack && this.m_LayerCamera == null)
			{
				this.Init("", false);
			}
			return true;
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x0007D4A0 File Offset: 0x0007B6A0
		public void DestroyCameras()
		{
			if (this.m_LayerCamera != null)
			{
				if (this.isUsingACameraClone)
				{
					HDAdditionalCameraData component = this.m_LayerCamera.GetComponent<HDAdditionalCameraData>();
					if (component)
					{
						CoreUtils.Destroy(component);
					}
					this.m_LayerCamera.targetTexture = null;
					CompositorCameraRegistry.GetInstance().UnregisterInternalCamera(this.m_LayerCamera);
					CoreUtils.Destroy(this.m_LayerCamera);
					this.m_LayerCamera = null;
					return;
				}
				this.m_LayerCamera.targetTexture = null;
				this.m_LayerCamera = null;
			}
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x0007D520 File Offset: 0x0007B720
		public void DestroyRT()
		{
			if (this.m_RTHandle != null)
			{
				RTHandles.Release(this.m_RTHandle);
				this.m_RTHandle = null;
			}
			if (this.m_RenderTarget != null)
			{
				CoreUtils.Destroy(this.m_RenderTarget);
				this.m_RenderTarget = null;
			}
			if (this.m_AOVHandles != null)
			{
				foreach (RTHandle rthandle in this.m_AOVHandles)
				{
					rthandle.Release();
				}
			}
			if (this.m_AOVRenderTargets != null)
			{
				foreach (RenderTexture obj in this.m_AOVRenderTargets)
				{
					CoreUtils.Destroy(obj);
				}
			}
			Dictionary<string, int> aovmap = this.m_AOVMap;
			if (aovmap != null)
			{
				aovmap.Clear();
			}
			this.m_AOVMap = null;
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x0007D614 File Offset: 0x0007B814
		public void Destroy()
		{
			this.DestroyCameras();
			this.DestroyRT();
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x0007D624 File Offset: 0x0007B824
		public void SetLayerMaskOverrides()
		{
			if (this.m_OverrideCullingMask && this.m_LayerCamera)
			{
				this.m_LayerCamera.cullingMask = (this.m_ClearsBackGround ? 0 : this.m_CullingMask);
			}
			if (this.m_LayerCamera)
			{
				HDAdditionalCameraData component = this.m_LayerCamera.GetComponent<HDAdditionalCameraData>();
				if (component)
				{
					if (this.m_OverrideVolumeMask && this.m_LayerCamera)
					{
						component.volumeLayerMask = this.m_VolumeMask;
					}
					HDAdditionalCameraData hdadditionalCameraData = component;
					hdadditionalCameraData.volumeLayerMask |= int.MinValue;
					if (this.m_OverrideAntialiasing)
					{
						component.antialiasing = this.m_Antialiasing;
					}
					if (this.m_OverrideClearMode)
					{
						component.clearColorMode = this.m_ClearMode;
					}
				}
			}
		}

		// Token: 0x06001041 RID: 4161 RVA: 0x0007D6F4 File Offset: 0x0007B8F4
		public void SetAdditionalLayerData()
		{
			if (this.m_LayerCamera)
			{
				AdditionalCompositorData component = this.m_LayerCamera.GetComponent<AdditionalCompositorData>();
				if (component != null)
				{
					component.Init(this.m_InputFilters, this.m_ClearAlpha);
					component.alphaMin = this.m_AlphaMin;
					component.alphaMax = this.m_AlphaMax;
				}
			}
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x0007D750 File Offset: 0x0007B950
		internal void CopyInternalCameraData()
		{
			if (!this.isUsingACameraClone)
			{
				return;
			}
			float depth = this.m_LayerCamera.depth;
			if (this.m_Camera)
			{
				this.m_LayerCamera.CopyFrom(this.m_Camera);
				this.m_LayerCamera.depth = depth;
				HDAdditionalCameraData component = this.m_Camera.GetComponent<HDAdditionalCameraData>();
				HDAdditionalCameraData component2 = this.m_LayerCamera.GetComponent<HDAdditionalCameraData>();
				if (component)
				{
					component.CopyTo(component2);
				}
			}
		}

		// Token: 0x06001043 RID: 4163 RVA: 0x0007D7C4 File Offset: 0x0007B9C4
		public void UpdateOutputCamera()
		{
			if (this.m_LayerCamera == null)
			{
				return;
			}
			CompositionManager instance = CompositionManager.GetInstance();
			this.m_LayerCamera.enabled = ((this.m_Show || this.m_ClearsBackGround) && instance.enableOutput);
			if (this.m_Type == CompositorLayer.LayerType.Image)
			{
				AdditionalCompositorData component = this.m_LayerCamera.GetComponent<AdditionalCompositorData>();
				if (component)
				{
					component.clearColorTexture = ((this.m_Show && this.m_InputTexture != null) ? this.m_InputTexture : ((this.m_LayerPositionInStack == 0) ? Texture2D.blackTexture : null));
				}
			}
			if (this.m_LayerCamera.enabled)
			{
				this.CopyInternalCameraData();
			}
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x0007D86E File Offset: 0x0007BA6E
		public void Update()
		{
			this.UpdateOutputCamera();
			this.SetLayerMaskOverrides();
			this.SetAdditionalLayerData();
		}

		// Token: 0x06001045 RID: 4165 RVA: 0x0007D882 File Offset: 0x0007BA82
		public void SetPriotiry(float priority)
		{
			if (this.m_LayerCamera)
			{
				this.m_LayerCamera.depth = priority;
			}
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x0007D8A0 File Offset: 0x0007BAA0
		public RenderTexture GetRenderTarget(bool allowAOV = true, bool alwaysShow = false)
		{
			if (this.m_Show || alwaysShow)
			{
				if (this.m_AOVMap != null && allowAOV)
				{
					using (Dictionary<string, int>.Enumerator enumerator = this.m_AOVMap.GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							KeyValuePair<string, int> keyValuePair = enumerator.Current;
							return this.m_AOVRenderTargets[keyValuePair.Value];
						}
					}
				}
				return this.m_RenderTarget;
			}
			return null;
		}

		// Token: 0x06001047 RID: 4167 RVA: 0x0007D924 File Offset: 0x0007BB24
		public bool ValidateRTSize(int referenceWidth, int referenceHeight)
		{
			if (this.m_RenderTarget == null)
			{
				return true;
			}
			float num = CompositorLayer.EnumToScale(this.m_ResolutionScale);
			return this.m_RenderTarget.width == Mathf.FloorToInt((float)referenceWidth * num) && this.m_RenderTarget.height == Mathf.FloorToInt((float)referenceHeight * num);
		}

		// Token: 0x06001048 RID: 4168 RVA: 0x0007D97C File Offset: 0x0007BB7C
		public void SetupClearColor()
		{
			if (this.m_LayerCamera && this.m_Camera)
			{
				this.m_LayerCamera.enabled = true;
				this.m_LayerCamera.cullingMask = 0;
				HDAdditionalCameraData component = this.m_LayerCamera.GetComponent<HDAdditionalCameraData>();
				HDAdditionalCameraData component2 = this.m_Camera.GetComponent<HDAdditionalCameraData>();
				component.clearColorMode = component2.clearColorMode;
				component.clearDepth = true;
				this.m_ClearsBackGround = true;
			}
		}

		// Token: 0x06001049 RID: 4169 RVA: 0x0007D9EC File Offset: 0x0007BBEC
		public void AddInputFilter(CompositionFilter filter)
		{
			using (List<CompositionFilter>.Enumerator enumerator = this.m_InputFilters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.filterType == filter.filterType)
					{
						return;
					}
				}
			}
			this.m_InputFilters.Add(filter);
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x0007DA54 File Offset: 0x0007BC54
		public void SetupLayerCamera(CompositorLayer targetLayer, int layerPositionInStack)
		{
			if (!this.m_LayerCamera || targetLayer == null)
			{
				return;
			}
			if (targetLayer.GetRenderTarget(true, false) == null)
			{
				this.m_LayerCamera.enabled = false;
				return;
			}
			this.m_LayerPositionInStack = layerPositionInStack;
			HDAdditionalCameraData component = this.m_LayerCamera.GetComponent<HDAdditionalCameraData>();
			this.m_LayerCamera.targetTexture = targetLayer.GetRenderTarget(false, false);
			if (layerPositionInStack != 0)
			{
				component.clearColorMode = HDAdditionalCameraData.ClearColorMode.None;
				AdditionalCompositorData additionalCompositorData = this.m_LayerCamera.GetComponent<AdditionalCompositorData>();
				if (!additionalCompositorData)
				{
					additionalCompositorData = this.m_LayerCamera.gameObject.AddComponent<AdditionalCompositorData>();
				}
				if (this.m_Type != CompositorLayer.LayerType.Image || (this.m_Type == CompositorLayer.LayerType.Image && this.m_InputTexture == null))
				{
					additionalCompositorData.clearColorTexture = targetLayer.GetRenderTarget(true, false);
					additionalCompositorData.clearDepthTexture = targetLayer.m_RTHandle;
				}
				HDAdditionalCameraData hdadditionalCameraData = component;
				hdadditionalCameraData.volumeLayerMask |= int.MinValue;
			}
			else
			{
				this.m_ClearDepth = true;
			}
			component.clearDepth = this.m_ClearDepth;
			int num = 1 << (int)targetLayer.m_AOVBitmask;
			if (this.m_Show && num > 1)
			{
				AOVRequestBuilder aovrequestBuilder = new AOVRequestBuilder();
				int num2 = 0;
				AOVRequestBufferAllocator <>9__0;
				for (int i = 0; i < CompositorLayer.k_AOVNames.Length; i++)
				{
					if ((num & 1 << i) != 0)
					{
						int fullscreenOutput = i;
						AOVRequest aovrequest = new AOVRequest(AOVRequest.NewDefault());
						aovrequest.SetFullscreenOutput((MaterialSharedProperty)fullscreenOutput);
						int indexLocalCopy = num2;
						AOVRequestBuilder aovrequestBuilder2 = aovrequestBuilder;
						AOVRequest settings = aovrequest;
						AOVRequestBufferAllocator bufferAllocator;
						if ((bufferAllocator = <>9__0) == null)
						{
							bufferAllocator = (<>9__0 = delegate(AOVBuffers bufferId)
							{
								RTHandle result;
								if ((result = targetLayer.m_AOVTmpRTHandle) == null)
								{
									result = (targetLayer.m_AOVTmpRTHandle = RTHandles.Alloc(targetLayer.pixelWidth, targetLayer.pixelHeight, 1, DepthBits.None, GraphicsFormat.R8G8B8A8_SRGB, FilterMode.Point, TextureWrapMode.Repeat, TextureDimension.Tex2D, false, false, true, false, 1, 0f, MSAASamples.None, false, false, RenderTextureMemoryless.None, VRTextureUsage.None, ""));
								}
								return result;
							});
						}
						aovrequestBuilder2.Add(settings, bufferAllocator, null, new AOVBuffers[]
						{
							AOVBuffers.Color
						}, delegate(CommandBuffer cmd, List<RTHandle> textures, RenderOutputProperties properties)
						{
							cmd.Blit(textures[0], targetLayer.m_AOVRenderTargets[indexLocalCopy]);
						});
						num2++;
					}
				}
				component.SetAOVRequests(aovrequestBuilder.Build());
				this.m_LayerCamera.enabled = true;
				return;
			}
			component.SetAOVRequests(null);
		}

		// Token: 0x04001984 RID: 6532
		[SerializeField]
		private string m_LayerName;

		// Token: 0x04001985 RID: 6533
		[SerializeField]
		private CompositorLayer.OutputTarget m_OutputTarget;

		// Token: 0x04001986 RID: 6534
		[SerializeField]
		private bool m_ClearDepth;

		// Token: 0x04001987 RID: 6535
		[SerializeField]
		private bool m_ClearAlpha = true;

		// Token: 0x04001988 RID: 6536
		[SerializeField]
		private Renderer m_OutputRenderer;

		// Token: 0x04001989 RID: 6537
		[SerializeField]
		private CompositorLayer.LayerType m_Type;

		// Token: 0x0400198A RID: 6538
		[SerializeField]
		private Camera m_Camera;

		// Token: 0x0400198B RID: 6539
		[SerializeField]
		private VideoPlayer m_InputVideo;

		// Token: 0x0400198C RID: 6540
		[SerializeField]
		private Texture m_InputTexture;

		// Token: 0x0400198D RID: 6541
		[SerializeField]
		private BackgroundFitMode m_BackgroundFit;

		// Token: 0x0400198E RID: 6542
		[SerializeField]
		private CompositorLayer.ResolutionScale m_ResolutionScale = CompositorLayer.ResolutionScale.Full;

		// Token: 0x0400198F RID: 6543
		[SerializeField]
		private CompositorLayer.UIColorBufferFormat m_ColorBufferFormat = CompositorLayer.UIColorBufferFormat.R16G16B16A16;

		// Token: 0x04001990 RID: 6544
		[SerializeField]
		private bool m_OverrideAntialiasing;

		// Token: 0x04001991 RID: 6545
		[SerializeField]
		private HDAdditionalCameraData.AntialiasingMode m_Antialiasing;

		// Token: 0x04001992 RID: 6546
		[SerializeField]
		private bool m_OverrideClearMode;

		// Token: 0x04001993 RID: 6547
		[SerializeField]
		private HDAdditionalCameraData.ClearColorMode m_ClearMode = HDAdditionalCameraData.ClearColorMode.Color;

		// Token: 0x04001994 RID: 6548
		[SerializeField]
		private bool m_OverrideCullingMask;

		// Token: 0x04001995 RID: 6549
		[SerializeField]
		private LayerMask m_CullingMask;

		// Token: 0x04001996 RID: 6550
		[SerializeField]
		private bool m_OverrideVolumeMask;

		// Token: 0x04001997 RID: 6551
		[SerializeField]
		private LayerMask m_VolumeMask;

		// Token: 0x04001998 RID: 6552
		[SerializeField]
		private int m_LayerPositionInStack;

		// Token: 0x04001999 RID: 6553
		[SerializeField]
		private List<CompositionFilter> m_InputFilters = new List<CompositionFilter>();

		// Token: 0x0400199A RID: 6554
		[SerializeField]
		private MaterialSharedProperty m_AOVBitmask;

		// Token: 0x0400199B RID: 6555
		[SerializeField]
		private Dictionary<string, int> m_AOVMap;

		// Token: 0x0400199C RID: 6556
		private List<RTHandle> m_AOVHandles;

		// Token: 0x0400199D RID: 6557
		[SerializeField]
		private List<RenderTexture> m_AOVRenderTargets;

		// Token: 0x0400199E RID: 6558
		private RTHandle m_RTHandle;

		// Token: 0x0400199F RID: 6559
		[SerializeField]
		private RenderTexture m_RenderTarget;

		// Token: 0x040019A0 RID: 6560
		[SerializeField]
		private RTHandle m_AOVTmpRTHandle;

		// Token: 0x040019A1 RID: 6561
		[SerializeField]
		private bool m_ClearsBackGround;

		// Token: 0x040019A2 RID: 6562
		private static readonly string[] k_AOVNames = Enum.GetNames(typeof(MaterialSharedProperty));

		// Token: 0x040019A3 RID: 6563
		[SerializeField]
		private bool m_Show = true;

		// Token: 0x040019A4 RID: 6564
		[SerializeField]
		private Camera m_LayerCamera;

		// Token: 0x040019A5 RID: 6565
		[SerializeField]
		private float m_AlphaMin;

		// Token: 0x040019A6 RID: 6566
		[SerializeField]
		private float m_AlphaMax = 1f;

		// Token: 0x02000456 RID: 1110
		public enum LayerType
		{
			// Token: 0x040029D9 RID: 10713
			Camera,
			// Token: 0x040029DA RID: 10714
			Video,
			// Token: 0x040029DB RID: 10715
			Image
		}

		// Token: 0x02000457 RID: 1111
		public enum UIColorBufferFormat
		{
			// Token: 0x040029DD RID: 10717
			R11G11B10 = 74,
			// Token: 0x040029DE RID: 10718
			R16G16B16A16 = 48,
			// Token: 0x040029DF RID: 10719
			R32G32B32A32 = 52
		}

		// Token: 0x02000458 RID: 1112
		public enum OutputTarget
		{
			// Token: 0x040029E1 RID: 10721
			CompositorLayer,
			// Token: 0x040029E2 RID: 10722
			CameraStack
		}

		// Token: 0x02000459 RID: 1113
		public enum ResolutionScale
		{
			// Token: 0x040029E4 RID: 10724
			Full = 1,
			// Token: 0x040029E5 RID: 10725
			Half,
			// Token: 0x040029E6 RID: 10726
			Quarter = 4
		}
	}
}
