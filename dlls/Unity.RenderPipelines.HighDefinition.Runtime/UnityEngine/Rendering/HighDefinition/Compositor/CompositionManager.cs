using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition.Compositor
{
	// Token: 0x02000241 RID: 577
	[AddComponentMenu("")]
	[ExecuteAlways]
	internal class CompositionManager : MonoBehaviour
	{
		// Token: 0x1700026D RID: 621
		// (get) Token: 0x0600104C RID: 4172 RVA: 0x0007DC98 File Offset: 0x0007BE98
		// (set) Token: 0x0600104D RID: 4173 RVA: 0x0007DCA0 File Offset: 0x0007BEA0
		public bool enableInternal
		{
			get
			{
				return this.m_Enable;
			}
			set
			{
				this.m_Enable = value;
			}
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x0600104E RID: 4174 RVA: 0x0007DCA9 File Offset: 0x0007BEA9
		public List<CompositorLayer> layers
		{
			get
			{
				return this.m_InputLayers;
			}
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x0600104F RID: 4175 RVA: 0x0007DCB1 File Offset: 0x0007BEB1
		public CompositionManager.AlphaChannelSupport alphaSupport
		{
			get
			{
				return this.m_AlphaSupport;
			}
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06001050 RID: 4176 RVA: 0x0007DCB9 File Offset: 0x0007BEB9
		// (set) Token: 0x06001051 RID: 4177 RVA: 0x0007DCD8 File Offset: 0x0007BED8
		public bool enableOutput
		{
			get
			{
				return this.m_OutputCamera && this.m_OutputCamera.enabled;
			}
			set
			{
				if (this.m_OutputCamera)
				{
					if (this.m_OutputCamera.enabled == value)
					{
						return;
					}
					this.m_OutputCamera.enabled = value;
					foreach (CompositorLayer compositorLayer in this.m_InputLayers)
					{
						if (compositorLayer.camera && compositorLayer.isUsingACameraClone)
						{
							compositorLayer.camera.enabled = value;
						}
						else if (compositorLayer.camera && !value)
						{
							compositorLayer.camera.targetTexture = null;
						}
					}
					if (value)
					{
						CompositionManager.RegisterCustomPasses();
						return;
					}
					CompositionManager.UnRegisterCustomPasses();
				}
			}
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06001052 RID: 4178 RVA: 0x0007DD9C File Offset: 0x0007BF9C
		public int numLayers
		{
			get
			{
				return this.m_InputLayers.Count;
			}
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06001053 RID: 4179 RVA: 0x0007DDA9 File Offset: 0x0007BFA9
		// (set) Token: 0x06001054 RID: 4180 RVA: 0x0007DDB1 File Offset: 0x0007BFB1
		public Shader shader
		{
			get
			{
				return this.m_Shader;
			}
			set
			{
				this.m_Shader = value;
			}
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06001055 RID: 4181 RVA: 0x0007DDBA File Offset: 0x0007BFBA
		// (set) Token: 0x06001056 RID: 4182 RVA: 0x0007DDC2 File Offset: 0x0007BFC2
		public CompositionProfile profile
		{
			get
			{
				return this.m_CompositionProfile;
			}
			set
			{
				this.m_CompositionProfile = value;
			}
		}

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06001057 RID: 4183 RVA: 0x0007DDCB File Offset: 0x0007BFCB
		// (set) Token: 0x06001058 RID: 4184 RVA: 0x0007DDD3 File Offset: 0x0007BFD3
		public Camera outputCamera
		{
			get
			{
				return this.m_OutputCamera;
			}
			set
			{
				this.m_OutputCamera = value;
			}
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06001059 RID: 4185 RVA: 0x0007DDDC File Offset: 0x0007BFDC
		public float aspectRatio
		{
			get
			{
				if (this.m_OutputCamera)
				{
					return (float)this.m_OutputCamera.pixelWidth / (float)this.m_OutputCamera.pixelHeight;
				}
				return 1f;
			}
		}

		// Token: 0x17000276 RID: 630
		// (set) Token: 0x0600105A RID: 4186 RVA: 0x0007DE0A File Offset: 0x0007C00A
		public bool shaderPropertiesAreDirty
		{
			set
			{
				this.m_ShaderPropertiesAreDirty = true;
			}
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x0007DE14 File Offset: 0x0007C014
		public bool ValidateLayerListOrder(int oldIndex, int newIndex)
		{
			if (this.m_InputLayers.Count > 1 && this.m_InputLayers[0].outputTarget == CompositorLayer.OutputTarget.CameraStack)
			{
				CompositorLayer item = this.m_InputLayers[newIndex];
				this.m_InputLayers.RemoveAt(newIndex);
				this.m_InputLayers.Insert(oldIndex, item);
				return false;
			}
			return true;
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x0007DE6C File Offset: 0x0007C06C
		public bool RuntimeCheck()
		{
			for (int i = 0; i < this.m_InputLayers.Count; i++)
			{
				if (!this.m_InputLayers[i].Validate())
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600105D RID: 4189 RVA: 0x0007DEA8 File Offset: 0x0007C0A8
		private bool ValidatePipeline()
		{
			HDRenderPipeline hdrenderPipeline = RenderPipelineManager.currentPipeline as HDRenderPipeline;
			if (hdrenderPipeline != null)
			{
				this.m_AlphaSupport = CompositionManager.AlphaChannelSupport.RenderingAndPostProcessing;
				if (hdrenderPipeline.GetColorBufferFormat() == GraphicsFormat.B10G11R11_UFloatPack32)
				{
					this.m_AlphaSupport = CompositionManager.AlphaChannelSupport.None;
				}
				else if (hdrenderPipeline.GetColorBufferFormat() == GraphicsFormat.B10G11R11_UFloatPack32)
				{
					this.m_AlphaSupport = CompositionManager.AlphaChannelSupport.Rendering;
				}
				CompositionManager.RegisterCustomPasses();
				return true;
			}
			return false;
		}

		// Token: 0x0600105E RID: 4190 RVA: 0x0007DEF6 File Offset: 0x0007C0F6
		private bool ValidateCompositionShader()
		{
			if (this.m_Shader == null)
			{
				return false;
			}
			if (this.m_CompositionProfile == null)
			{
				Debug.Log("A composition profile was not found. Set the composition graph from the Compositor window to create one.");
				return false;
			}
			return true;
		}

		// Token: 0x0600105F RID: 4191 RVA: 0x0007DF23 File Offset: 0x0007C123
		private bool ValidateProfile()
		{
			if (this.m_CompositionProfile)
			{
				return true;
			}
			Debug.LogError("No composition profile was found! Use the compositor tool to create one.");
			return false;
		}

		// Token: 0x06001060 RID: 4192 RVA: 0x0007DF40 File Offset: 0x0007C140
		private bool ValidateMainCompositorCamera()
		{
			if (this.m_OutputCamera == null)
			{
				return false;
			}
			HDAdditionalCameraData component = this.m_OutputCamera.GetComponent<HDAdditionalCameraData>();
			if (component == null)
			{
				this.m_OutputCamera.gameObject.AddComponent(typeof(HDAdditionalCameraData));
				component = this.m_OutputCamera.GetComponent<HDAdditionalCameraData>();
			}
			if (component)
			{
				component.customRender += this.CustomRender;
			}
			else
			{
				Debug.Log("Null additional data in compositor output");
			}
			return true;
		}

		// Token: 0x06001061 RID: 4193 RVA: 0x0007DFC0 File Offset: 0x0007C1C0
		private bool ValidateAndFixRuntime()
		{
			if (this.m_OutputCamera == null)
			{
				return false;
			}
			if (this.m_Shader == null)
			{
				this.m_InputLayers.Clear();
				this.m_CompositionProfile = null;
				return false;
			}
			if (this.m_CompositionProfile == null)
			{
				return false;
			}
			if (this.m_Material == null)
			{
				this.SetupCompositionMaterial();
			}
			HDAdditionalCameraData component = this.m_OutputCamera.GetComponent<HDAdditionalCameraData>();
			if (component && !component.hasCustomRender)
			{
				component.customRender += this.CustomRender;
			}
			return true;
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x0007E054 File Offset: 0x0007C254
		public void DropCompositorCamera()
		{
			if (this.m_OutputCamera)
			{
				HDAdditionalCameraData component = this.m_OutputCamera.GetComponent<HDAdditionalCameraData>();
				if (component && component.hasCustomRender)
				{
					component.customRender -= this.CustomRender;
				}
			}
		}

		// Token: 0x06001063 RID: 4195 RVA: 0x0007E09C File Offset: 0x0007C29C
		public void Init()
		{
			if (this.ValidateCompositionShader() && this.ValidateProfile() && this.ValidateMainCompositorCamera())
			{
				this.UpdateDisplayNumber();
				this.SetupCompositionMaterial();
				this.SetupCompositorLayers(false);
				this.SetupGlobalCompositorVolume();
				this.SetupCompositorConstants();
				this.SetupLayerPriorities();
				return;
			}
			Debug.LogError("The compositor was disabled due to a validation error in the configuration.");
			this.enableInternal = false;
		}

		// Token: 0x06001064 RID: 4196 RVA: 0x0007E0F8 File Offset: 0x0007C2F8
		private void Start()
		{
			this.Init();
		}

		// Token: 0x06001065 RID: 4197 RVA: 0x0007E100 File Offset: 0x0007C300
		private void OnValidate()
		{
			if (this.shader == null)
			{
				this.m_InputLayers.Clear();
				this.m_CompositionProfile = null;
			}
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x0007E122 File Offset: 0x0007C322
		public void OnEnable()
		{
			this.enableOutput = true;
			CompositionManager.s_CompositorInstance = null;
			RenderPipelineManager.beginContextRendering += this.ResizeCallback;
		}

		// Token: 0x06001067 RID: 4199 RVA: 0x0007E144 File Offset: 0x0007C344
		public void DeleteLayerRTs()
		{
			for (int i = this.m_InputLayers.Count - 1; i >= 0; i--)
			{
				this.m_InputLayers[i].DestroyCameras();
			}
			for (int j = this.m_InputLayers.Count - 1; j >= 0; j--)
			{
				this.m_InputLayers[j].DestroyRT();
			}
		}

		// Token: 0x06001068 RID: 4200 RVA: 0x0007E1A3 File Offset: 0x0007C3A3
		public bool IsOutputLayer(int layerID)
		{
			return layerID < 0 || layerID >= this.m_InputLayers.Count || this.m_InputLayers[layerID].outputTarget != CompositorLayer.OutputTarget.CameraStack;
		}

		// Token: 0x06001069 RID: 4201 RVA: 0x0007E1CE File Offset: 0x0007C3CE
		public void UpdateDisplayNumber()
		{
			if (this.m_OutputCamera)
			{
				this.m_OutputCamera.targetDisplay = (int)this.m_OutputDisplay;
			}
		}

		// Token: 0x0600106A RID: 4202 RVA: 0x0007E1F0 File Offset: 0x0007C3F0
		private void SetupCompositorLayers(bool allowUndo = true)
		{
			for (int i = 0; i < this.m_InputLayers.Count; i++)
			{
				this.m_InputLayers[i].Init(string.Format("Layer{0}", i), allowUndo);
			}
			this.SetLayerRenderTargets();
		}

		// Token: 0x0600106B RID: 4203 RVA: 0x0007E23B File Offset: 0x0007C43B
		public void SetNewCompositionShader()
		{
			this.m_Material = null;
			this.SetupCompositionMaterial();
		}

		// Token: 0x0600106C RID: 4204 RVA: 0x0007E24C File Offset: 0x0007C44C
		public void SetupCompositionMaterial()
		{
			if (this.m_Shader)
			{
				this.m_Material = new Material(this.m_Shader);
				this.m_CompositionProfile.AddPropertiesFromShaderAndMaterial(this, this.m_Shader, this.m_Material);
				this.m_CompositionProfile.hideFlags = HideFlags.NotEditable;
				return;
			}
			this.m_CompositionProfile = null;
			this.m_Material = null;
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x0007E2AC File Offset: 0x0007C4AC
		public void SetupLayerPriorities()
		{
			int num = 0;
			foreach (CompositorLayer compositorLayer in this.m_InputLayers)
			{
				compositorLayer.SetPriotiry((float)num * 1f);
				num++;
			}
		}

		// Token: 0x0600106E RID: 4206 RVA: 0x0007E30C File Offset: 0x0007C50C
		public void OnAfterAssemblyReload()
		{
			if (this.m_OutputCamera)
			{
				HDAdditionalCameraData component = this.m_OutputCamera.GetComponent<HDAdditionalCameraData>();
				if (component && !component.hasCustomRender)
				{
					component.customRender += this.CustomRender;
				}
			}
		}

		// Token: 0x0600106F RID: 4207 RVA: 0x0007E354 File Offset: 0x0007C554
		public void OnDisable()
		{
			this.enableOutput = false;
		}

		// Token: 0x06001070 RID: 4208 RVA: 0x0007E360 File Offset: 0x0007C560
		private void SetupGlobalCompositorVolume()
		{
			Resources.FindObjectsOfTypeAll(typeof(CustomPassVolume));
			this.m_CompositorGameObject = new GameObject(CompositionManager.s_CompositorGlobalVolumeName)
			{
				hideFlags = HideFlags.HideAndDontSave
			};
			Volume volume = this.m_CompositorGameObject.AddComponent<Volume>();
			volume.gameObject.layer = 31;
			volume.profile.Add<AlphaInjection>(false);
			volume.profile.Add<ChromaKeying>(false).activate.Override(true);
			CustomPassVolume customPassVolume = this.m_CompositorGameObject.AddComponent<CustomPassVolume>();
			customPassVolume.injectionPoint = CustomPassInjectionPoint.BeforeRendering;
			customPassVolume.AddPassOfType(typeof(CustomClear));
		}

		// Token: 0x06001071 RID: 4209 RVA: 0x0007E3F4 File Offset: 0x0007C5F4
		private void SetupCompositorConstants()
		{
			this.m_ViewProjMatrix = Matrix4x4.Scale(new Vector3(2f, 2f, 0f)) * Matrix4x4.Translate(new Vector3(-0.5f, -0.5f, 0f));
			this.m_ViewProjMatrixFlipped = Matrix4x4.Scale(new Vector3(2f, -2f, 0f)) * Matrix4x4.Translate(new Vector3(-0.5f, -0.5f, 0f));
		}

		// Token: 0x06001072 RID: 4210 RVA: 0x0007E47B File Offset: 0x0007C67B
		public void UpdateLayerSetup()
		{
			this.SetupCompositorLayers(true);
			this.SetupLayerPriorities();
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x0007E48C File Offset: 0x0007C68C
		private void LateUpdate()
		{
			if (!this.enableOutput || !this.ValidatePipeline() || !this.ValidateAndFixRuntime() || !this.RuntimeCheck())
			{
				return;
			}
			this.UpdateDisplayNumber();
			if (this.m_CompositionProfile)
			{
				foreach (CompositorLayer compositorLayer in this.m_InputLayers)
				{
					compositorLayer.Update();
				}
				this.SetLayerRenderTargets();
			}
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x0007E518 File Offset: 0x0007C718
		private void OnDestroy()
		{
			this.DeleteLayerRTs();
			if (this.m_CompositorGameObject != null)
			{
				CoreUtils.Destroy(this.m_CompositorGameObject);
				this.m_CompositorGameObject = null;
			}
			foreach (CustomPassVolume customPassVolume in Resources.FindObjectsOfTypeAll(typeof(CustomPassVolume)))
			{
				if (customPassVolume.name == "Global Composition Volume" && customPassVolume.injectionPoint == CustomPassInjectionPoint.BeforeRendering)
				{
					CoreUtils.Destroy(customPassVolume);
				}
			}
			CompositionManager.UnRegisterCustomPasses();
			CompositorCameraRegistry.GetInstance().CleanUpCameraOrphans(null);
			RenderPipelineManager.beginContextRendering -= this.ResizeCallback;
		}

		// Token: 0x06001075 RID: 4213 RVA: 0x0007E5B3 File Offset: 0x0007C7B3
		public void AddInputFilterAtLayer(CompositionFilter filter, int index)
		{
			this.m_InputLayers[index].AddInputFilter(filter);
		}

		// Token: 0x06001076 RID: 4214 RVA: 0x0007E5C8 File Offset: 0x0007C7C8
		private int GetBaseLayerForSubLayerAtIndex(int index)
		{
			int result = 0;
			index = ((index > this.m_InputLayers.Count - 1) ? (this.m_InputLayers.Count - 1) : index);
			for (int i = index; i >= 0; i--)
			{
				if (this.m_InputLayers[i].outputTarget == CompositorLayer.OutputTarget.CompositorLayer)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x06001077 RID: 4215 RVA: 0x0007E61D File Offset: 0x0007C81D
		private static string GetSubLayerName(int count)
		{
			if (count == 0)
			{
				return "New SubLayer";
			}
			return string.Format("New SubLayer ({0})", count + 1);
		}

		// Token: 0x06001078 RID: 4216 RVA: 0x0007E63C File Offset: 0x0007C83C
		public string GetNewSubLayerName(int index, CompositorLayer.LayerType type = CompositorLayer.LayerType.Camera)
		{
			int baseLayerForSubLayerAtIndex = this.GetBaseLayerForSubLayerAtIndex(index - 1);
			int num = 0;
			string subLayerName = CompositionManager.GetSubLayerName(num);
			int num2 = baseLayerForSubLayerAtIndex + 1;
			while (num2 < this.m_InputLayers.Count && this.m_InputLayers[num2].outputTarget != CompositorLayer.OutputTarget.CompositorLayer)
			{
				if (this.m_InputLayers[num2].name == subLayerName)
				{
					subLayerName = CompositionManager.GetSubLayerName(++num);
					num2 = baseLayerForSubLayerAtIndex + 1;
				}
				else
				{
					num2++;
				}
			}
			return subLayerName;
		}

		// Token: 0x06001079 RID: 4217 RVA: 0x0007E6B4 File Offset: 0x0007C8B4
		public void AddNewLayer(int index, CompositorLayer.LayerType type = CompositorLayer.LayerType.Camera)
		{
			CompositorLayer item = CompositorLayer.CreateStackLayer(type, this.GetNewSubLayerName(index, type));
			if (index >= 0 && index < this.m_InputLayers.Count)
			{
				this.m_InputLayers.Insert(index, item);
				return;
			}
			this.m_InputLayers.Add(item);
		}

		// Token: 0x0600107A RID: 4218 RVA: 0x0007E6FC File Offset: 0x0007C8FC
		private int GetNumChildrenForLayerAtIndex(int indx)
		{
			if (this.m_InputLayers[indx].outputTarget == CompositorLayer.OutputTarget.CameraStack)
			{
				return 0;
			}
			int num = 0;
			int num2 = indx + 1;
			while (num2 < this.m_InputLayers.Count && this.m_InputLayers[num2].outputTarget == CompositorLayer.OutputTarget.CameraStack)
			{
				num++;
				num2++;
			}
			return num;
		}

		// Token: 0x0600107B RID: 4219 RVA: 0x0007E754 File Offset: 0x0007C954
		public void RemoveLayerAtIndex(int indx)
		{
			for (int i = this.GetNumChildrenForLayerAtIndex(indx); i >= 0; i--)
			{
				this.m_InputLayers[indx + i].Destroy();
				this.m_InputLayers.RemoveAt(indx + i);
			}
		}

		// Token: 0x0600107C RID: 4220 RVA: 0x0007E794 File Offset: 0x0007C994
		public void SetLayerRenderTargets()
		{
			int num = 0;
			CompositorLayer targetLayer = null;
			for (int i = 0; i < this.m_InputLayers.Count; i++)
			{
				if (this.m_InputLayers[i].outputTarget != CompositorLayer.OutputTarget.CameraStack)
				{
					targetLayer = this.m_InputLayers[i];
					this.m_InputLayers[i].clearsBackGround = (i + 1 >= this.m_InputLayers.Count || this.m_InputLayers[i + 1].outputTarget == CompositorLayer.OutputTarget.CompositorLayer);
				}
				if (this.m_InputLayers[i].outputTarget == CompositorLayer.OutputTarget.CameraStack && i > 0)
				{
					this.m_InputLayers[i].SetupLayerCamera(targetLayer, num);
					if (!this.m_InputLayers[i].enabled && num == 0)
					{
						this.m_InputLayers[i].SetupClearColor();
					}
					num++;
				}
				else
				{
					num = 0;
				}
			}
		}

		// Token: 0x0600107D RID: 4221 RVA: 0x0007E878 File Offset: 0x0007CA78
		public void ReorderChildren(int oldIndex, int newIndex)
		{
			if (this.m_InputLayers[newIndex].outputTarget == CompositorLayer.OutputTarget.CompositorLayer)
			{
				if (oldIndex > newIndex)
				{
					int num = 1;
					while (oldIndex + num < this.m_InputLayers.Count)
					{
						if (this.m_InputLayers[oldIndex + num].outputTarget != CompositorLayer.OutputTarget.CameraStack)
						{
							return;
						}
						CompositorLayer item = this.m_InputLayers[oldIndex + num];
						this.m_InputLayers.RemoveAt(oldIndex + num);
						this.m_InputLayers.Insert(newIndex + num, item);
						num++;
					}
					return;
				}
				while (this.m_InputLayers[oldIndex].outputTarget == CompositorLayer.OutputTarget.CameraStack)
				{
					CompositorLayer item2 = this.m_InputLayers[oldIndex];
					this.m_InputLayers.RemoveAt(oldIndex);
					this.m_InputLayers.Insert(newIndex, item2);
				}
			}
		}

		// Token: 0x0600107E RID: 4222 RVA: 0x0007E937 File Offset: 0x0007CB37
		public RenderTexture GetRenderTarget(int indx)
		{
			if (indx >= 0 && indx < this.m_InputLayers.Count)
			{
				return this.m_InputLayers[indx].GetRenderTarget(true, true);
			}
			return null;
		}

		// Token: 0x0600107F RID: 4223 RVA: 0x0007E960 File Offset: 0x0007CB60
		public void Repaint()
		{
			for (int i = 0; i < this.m_InputLayers.Count; i++)
			{
				if (this.m_InputLayers[i].camera)
				{
					this.m_InputLayers[i].camera.Render();
				}
			}
		}

		// Token: 0x06001080 RID: 4224 RVA: 0x0007E9B4 File Offset: 0x0007CBB4
		private void ResizeCallback(ScriptableRenderContext cntx, List<Camera> cameras)
		{
			if (this.m_OutputCamera && this.enableOutput)
			{
				using (List<CompositorLayer>.Enumerator enumerator = this.m_InputLayers.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (!enumerator.Current.ValidateRTSize(this.m_OutputCamera.pixelWidth, this.m_OutputCamera.pixelHeight))
						{
							for (int i = this.m_InputLayers.Count - 1; i >= 0; i--)
							{
								if (this.m_InputLayers[i].camera)
								{
									this.m_InputLayers[i].camera.targetTexture = null;
								}
								this.m_InputLayers[i].DestroyRT();
							}
							this.SetupCompositorLayers(true);
							this.InternalRender(cntx);
							break;
						}
					}
				}
			}
		}

		// Token: 0x06001081 RID: 4225 RVA: 0x0007EAA8 File Offset: 0x0007CCA8
		private void InternalRender(ScriptableRenderContext cntx)
		{
			HDRenderPipeline hdrenderPipeline = RenderPipelineManager.currentPipeline as HDRenderPipeline;
			if (this.enableOutput && hdrenderPipeline != null)
			{
				List<Camera> list = new List<Camera>(1);
				foreach (CompositorLayer compositorLayer in this.m_InputLayers)
				{
					if (compositorLayer.camera && compositorLayer.camera.enabled)
					{
						list.Clear();
						ScriptableRenderContext.EmitGeometryForCamera(compositorLayer.camera);
						list.Add(compositorLayer.camera);
						hdrenderPipeline.InternalRender(cntx, list);
					}
				}
			}
		}

		// Token: 0x06001082 RID: 4226 RVA: 0x0007EB50 File Offset: 0x0007CD50
		private void CustomRender(ScriptableRenderContext context, HDCamera camera)
		{
			if (camera == null || camera.camera == null || this.m_Material == null || this.m_Shader == null)
			{
				CommandBufferPool.Get("Compositor Blit").ClearRenderTarget(false, true, Color.black);
				return;
			}
			this.timeSinceLastRepaint = 0f;
			this.m_CompositionProfile.CopyPropertiesToMaterial(this.m_Material);
			int num = 0;
			foreach (CompositorLayer compositorLayer in this.m_InputLayers)
			{
				if (compositorLayer.outputTarget != CompositorLayer.OutputTarget.CameraStack)
				{
					this.m_Material.SetTexture(compositorLayer.name, compositorLayer.GetRenderTarget(true, false), RenderTextureSubElement.Color);
				}
				num++;
			}
			CommandBuffer commandBuffer = CommandBufferPool.Get("Compositor Blit");
			camera.UpdateShaderVariablesGlobalCB(ref this.m_ShaderVariablesGlobalCB, 0);
			this.m_ShaderVariablesGlobalCB._WorldSpaceCameraPos_Internal = new Vector3(0f, 0f, 0f);
			commandBuffer.SetViewport(new Rect(0f, 0f, (float)camera.camera.pixelWidth, (float)camera.camera.pixelHeight));
			commandBuffer.ClearRenderTarget(true, false, Color.red);
			foreach (CompositorLayer compositorLayer2 in this.m_InputLayers)
			{
				if (compositorLayer2.clearsBackGround)
				{
					commandBuffer.SetRenderTarget(compositorLayer2.GetRenderTarget(true, false));
					commandBuffer.ClearRenderTarget(false, true, CompositionManager.s_TransparentBlack);
				}
			}
			int num2 = this.m_Material.FindPass("DrawProcedural");
			bool flag = num2 != -1;
			if (!flag)
			{
				num2 = this.m_Material.FindPass("ForwardOnly");
			}
			if (camera.camera.targetTexture)
			{
				if (flag)
				{
					CoreUtils.DrawFullScreen(commandBuffer, this.m_Material, camera.camera.targetTexture, null, num2);
				}
				else
				{
					this.m_ShaderVariablesGlobalCB._ViewProjMatrix = this.m_ViewProjMatrixFlipped;
					ConstantBuffer.PushGlobal<ShaderVariablesGlobal>(commandBuffer, this.m_ShaderVariablesGlobalCB, HDShaderIDs._ShaderVariablesGlobal);
					commandBuffer.Blit(null, camera.camera.targetTexture, this.m_Material, num2);
				}
				IEnumerator<Action<RenderTargetIdentifier, CommandBuffer>> captureActions = CameraCaptureBridge.GetCaptureActions(camera.camera);
				if (captureActions != null)
				{
					captureActions.Reset();
					while (captureActions.MoveNext())
					{
						Action<RenderTargetIdentifier, CommandBuffer> action = captureActions.Current;
						action(camera.camera.targetTexture, commandBuffer);
					}
				}
			}
			else
			{
				IEnumerator<Action<RenderTargetIdentifier, CommandBuffer>> captureActions2 = CameraCaptureBridge.GetCaptureActions(camera.camera);
				if (captureActions2 != null)
				{
					RenderTextureFormat format = this.m_InputLayers[0].GetRenderTarget(true, false).format;
					commandBuffer.GetTemporaryRT(this.m_RecorderTempRT, camera.camera.pixelWidth, camera.camera.pixelHeight, 0, FilterMode.Point, format);
					if (flag)
					{
						CoreUtils.DrawFullScreen(commandBuffer, this.m_Material, this.m_RecorderTempRT, null, num2);
					}
					else
					{
						this.m_ShaderVariablesGlobalCB._ViewProjMatrix = this.m_ViewProjMatrixFlipped;
						ConstantBuffer.PushGlobal<ShaderVariablesGlobal>(commandBuffer, this.m_ShaderVariablesGlobalCB, HDShaderIDs._ShaderVariablesGlobal);
						commandBuffer.Blit(null, this.m_RecorderTempRT, this.m_Material, num2);
						captureActions2.Reset();
						while (captureActions2.MoveNext())
						{
							Action<RenderTargetIdentifier, CommandBuffer> action2 = captureActions2.Current;
							action2(this.m_RecorderTempRT, commandBuffer);
						}
					}
				}
				if (flag)
				{
					if (this.fullscreenProperties == null)
					{
						this.fullscreenProperties = new MaterialPropertyBlock();
					}
					this.fullscreenProperties.SetFloat("_FlipY", 1f);
					CoreUtils.DrawFullScreen(commandBuffer, this.m_Material, BuiltinRenderTextureType.CameraTarget, this.fullscreenProperties, num2);
				}
				else
				{
					this.m_ShaderVariablesGlobalCB._ViewProjMatrix = this.m_ViewProjMatrix;
					ConstantBuffer.PushGlobal<ShaderVariablesGlobal>(commandBuffer, this.m_ShaderVariablesGlobalCB, HDShaderIDs._ShaderVariablesGlobal);
					commandBuffer.Blit(null, BuiltinRenderTextureType.CameraTarget, this.m_Material, num2);
				}
			}
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		// Token: 0x06001083 RID: 4227 RVA: 0x0007EF58 File Offset: 0x0007D158
		internal bool IsThisCameraShared(Camera camera)
		{
			if (camera == null)
			{
				return false;
			}
			int num = 0;
			foreach (CompositorLayer compositorLayer in this.m_InputLayers)
			{
				if (compositorLayer.outputTarget == CompositorLayer.OutputTarget.CameraStack && camera.Equals(compositorLayer.sourceCamera))
				{
					num++;
				}
			}
			return num > 1;
		}

		// Token: 0x06001084 RID: 4228 RVA: 0x0007EFD0 File Offset: 0x0007D1D0
		public static Camera GetSceneCamera()
		{
			if (Camera.main != null)
			{
				return Camera.main;
			}
			foreach (Camera camera in Camera.allCameras)
			{
				if (camera != CompositionManager.GetInstance().outputCamera)
				{
					return camera;
				}
			}
			return null;
		}

		// Token: 0x06001085 RID: 4229 RVA: 0x0007F020 File Offset: 0x0007D220
		public static Camera CreateCamera(string cameraName)
		{
			GameObject gameObject = new GameObject(cameraName);
			gameObject.hideFlags = (HideFlags.HideInHierarchy | HideFlags.HideInInspector | HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild | HideFlags.DontUnloadUnusedAsset);
			Camera result = gameObject.AddComponent<Camera>();
			gameObject.AddComponent<HDAdditionalCameraData>();
			return result;
		}

		// Token: 0x06001086 RID: 4230 RVA: 0x0007F049 File Offset: 0x0007D249
		public static CompositionManager GetInstance()
		{
			CompositionManager result;
			if ((result = CompositionManager.s_CompositorInstance) == null)
			{
				result = (CompositionManager.s_CompositorInstance = Object.FindObjectOfType<CompositionManager>(true));
			}
			return result;
		}

		// Token: 0x06001087 RID: 4231 RVA: 0x0007F060 File Offset: 0x0007D260
		public static Vector4 GetAlphaScaleAndBiasForCamera(HDCamera hdCamera)
		{
			AdditionalCompositorData additionalCompositorData = null;
			hdCamera.camera.TryGetComponent<AdditionalCompositorData>(out additionalCompositorData);
			if (additionalCompositorData)
			{
				float alphaMin = additionalCompositorData.alphaMin;
				float num = additionalCompositorData.alphaMax;
				if (num == alphaMin)
				{
					num += 0.0001f;
				}
				float num2 = 1f / (num - alphaMin);
				float y = -alphaMin * num2;
				return new Vector4(num2, y, 0f, 0f);
			}
			return new Vector4(1f, 0f, 0f, 0f);
		}

		// Token: 0x06001088 RID: 4232 RVA: 0x0007F0DC File Offset: 0x0007D2DC
		internal static Texture GetClearTextureForStackedCamera(HDCamera hdCamera)
		{
			AdditionalCompositorData additionalCompositorData = null;
			hdCamera.camera.TryGetComponent<AdditionalCompositorData>(out additionalCompositorData);
			if (additionalCompositorData)
			{
				return additionalCompositorData.clearColorTexture;
			}
			return null;
		}

		// Token: 0x06001089 RID: 4233 RVA: 0x0007F10C File Offset: 0x0007D30C
		internal static RenderTexture GetClearDepthForStackedCamera(HDCamera hdCamera)
		{
			AdditionalCompositorData additionalCompositorData = null;
			hdCamera.camera.TryGetComponent<AdditionalCompositorData>(out additionalCompositorData);
			if (additionalCompositorData)
			{
				return additionalCompositorData.clearDepthTexture;
			}
			return null;
		}

		// Token: 0x0600108A RID: 4234 RVA: 0x0007F13C File Offset: 0x0007D33C
		internal static void RegisterCustomPasses()
		{
			if (CompositionManager.m_globalSettings != HDRenderPipelineGlobalSettings.instance)
			{
				CompositionManager.UnRegisterCustomPasses();
				CompositionManager.m_globalSettings = null;
			}
			if (CompositionManager.m_globalSettings == null)
			{
				CompositionManager.m_globalSettings = HDRenderPipelineGlobalSettings.instance;
			}
			if (CompositionManager.m_globalSettings == null)
			{
				return;
			}
			if (CompositionManager.m_globalSettings.beforePostProcessCustomPostProcesses == null)
			{
				return;
			}
			if (!CompositionManager.m_globalSettings.beforePostProcessCustomPostProcesses.Contains(typeof(ChromaKeying).AssemblyQualifiedName))
			{
				CompositionManager.m_globalSettings.beforePostProcessCustomPostProcesses.Add(typeof(ChromaKeying).AssemblyQualifiedName);
			}
			if (!CompositionManager.m_globalSettings.beforePostProcessCustomPostProcesses.Contains(typeof(AlphaInjection).AssemblyQualifiedName))
			{
				CompositionManager.m_globalSettings.beforePostProcessCustomPostProcesses.Add(typeof(AlphaInjection).AssemblyQualifiedName);
			}
		}

		// Token: 0x0600108B RID: 4235 RVA: 0x0007F214 File Offset: 0x0007D414
		internal static void UnRegisterCustomPasses()
		{
			if (CompositionManager.m_globalSettings == null || CompositionManager.m_globalSettings.beforePostProcessCustomPostProcesses == null)
			{
				return;
			}
			if (CompositionManager.m_globalSettings.beforePostProcessCustomPostProcesses.Contains(typeof(ChromaKeying).AssemblyQualifiedName))
			{
				CompositionManager.m_globalSettings.beforePostProcessCustomPostProcesses.Remove(typeof(ChromaKeying).AssemblyQualifiedName);
			}
			if (CompositionManager.m_globalSettings.beforePostProcessCustomPostProcesses.Contains(typeof(AlphaInjection).AssemblyQualifiedName))
			{
				CompositionManager.m_globalSettings.beforePostProcessCustomPostProcesses.Remove(typeof(AlphaInjection).AssemblyQualifiedName);
			}
		}

		// Token: 0x040019A7 RID: 6567
		[SerializeField]
		private bool m_Enable = true;

		// Token: 0x040019A8 RID: 6568
		[SerializeField]
		private Material m_Material;

		// Token: 0x040019A9 RID: 6569
		[SerializeField]
		private CompositionManager.OutputDisplay m_OutputDisplay;

		// Token: 0x040019AA RID: 6570
		[SerializeField]
		private List<CompositorLayer> m_InputLayers = new List<CompositorLayer>();

		// Token: 0x040019AB RID: 6571
		internal CompositionManager.AlphaChannelSupport m_AlphaSupport = CompositionManager.AlphaChannelSupport.RenderingAndPostProcessing;

		// Token: 0x040019AC RID: 6572
		internal float timeSinceLastRepaint;

		// Token: 0x040019AD RID: 6573
		[SerializeField]
		private Shader m_Shader;

		// Token: 0x040019AE RID: 6574
		[HideInInspector]
		[SerializeField]
		private CompositionProfile m_CompositionProfile;

		// Token: 0x040019AF RID: 6575
		[SerializeField]
		private Camera m_OutputCamera;

		// Token: 0x040019B0 RID: 6576
		internal bool m_ShaderPropertiesAreDirty;

		// Token: 0x040019B1 RID: 6577
		internal Matrix4x4 m_ViewProjMatrix;

		// Token: 0x040019B2 RID: 6578
		internal Matrix4x4 m_ViewProjMatrixFlipped;

		// Token: 0x040019B3 RID: 6579
		internal GameObject m_CompositorGameObject;

		// Token: 0x040019B4 RID: 6580
		internal MaterialPropertyBlock fullscreenProperties;

		// Token: 0x040019B5 RID: 6581
		private ShaderVariablesGlobal m_ShaderVariablesGlobalCB;

		// Token: 0x040019B6 RID: 6582
		private int m_RecorderTempRT = Shader.PropertyToID("TempRecorder");

		// Token: 0x040019B7 RID: 6583
		private static CompositionManager s_CompositorInstance;

		// Token: 0x040019B8 RID: 6584
		private static Color s_TransparentBlack = new Color(0f, 0f, 0f, 0f);

		// Token: 0x040019B9 RID: 6585
		private static string s_CompositorGlobalVolumeName = "__Internal_Global_Composition_Volume";

		// Token: 0x040019BA RID: 6586
		private static HDRenderPipelineGlobalSettings m_globalSettings;

		// Token: 0x0200045C RID: 1116
		public enum OutputDisplay
		{
			// Token: 0x040029EC RID: 10732
			Display1,
			// Token: 0x040029ED RID: 10733
			Display2,
			// Token: 0x040029EE RID: 10734
			Display3,
			// Token: 0x040029EF RID: 10735
			Display4,
			// Token: 0x040029F0 RID: 10736
			Display5,
			// Token: 0x040029F1 RID: 10737
			Display6,
			// Token: 0x040029F2 RID: 10738
			Display7,
			// Token: 0x040029F3 RID: 10739
			Display8
		}

		// Token: 0x0200045D RID: 1117
		public enum AlphaChannelSupport
		{
			// Token: 0x040029F5 RID: 10741
			None,
			// Token: 0x040029F6 RID: 10742
			Rendering,
			// Token: 0x040029F7 RID: 10743
			RenderingAndPostProcessing
		}
	}
}
