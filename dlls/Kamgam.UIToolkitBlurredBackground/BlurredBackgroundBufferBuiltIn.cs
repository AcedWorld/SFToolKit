using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x0200000E RID: 14
	public class BlurredBackgroundBufferBuiltIn
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00003272 File Offset: 0x00001472
		// (set) Token: 0x06000053 RID: 83 RVA: 0x0000327C File Offset: 0x0000147C
		public bool Active
		{
			get
			{
				return this._active;
			}
			set
			{
				if (value != this._active)
				{
					this._active = value;
					if (!this._active)
					{
						this.ClearBuffers();
						return;
					}
					if (this._camera != null)
					{
						this.AddBuffer(this._camera, this._cameraEvent);
					}
				}
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000054 RID: 84 RVA: 0x000032C8 File Offset: 0x000014C8
		// (set) Token: 0x06000055 RID: 85 RVA: 0x000032D0 File Offset: 0x000014D0
		public int Iterations
		{
			get
			{
				return this._iterations;
			}
			set
			{
				if (value != this._iterations)
				{
					this._iterations = value;
					this.RecreateBuffers();
				}
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000056 RID: 86 RVA: 0x000032E8 File Offset: 0x000014E8
		// (set) Token: 0x06000057 RID: 87 RVA: 0x000032F0 File Offset: 0x000014F0
		public float Offset
		{
			get
			{
				return this._offset;
			}
			set
			{
				this._offset = value;
				this.setOffset(value);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00003300 File Offset: 0x00001500
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00003308 File Offset: 0x00001508
		public Vector2Int Resolution
		{
			get
			{
				return this._resolution;
			}
			set
			{
				this._resolution = value;
				this.updateRenderTextureResolutions();
				this.setOffset(this._offset);
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003324 File Offset: 0x00001524
		private void updateRenderTextureResolutions()
		{
			if (this._renderTargetBlurredA != null)
			{
				this._renderTargetBlurredA.Release();
				this._renderTargetBlurredA.width = this._resolution.x;
				this._renderTargetBlurredA.height = this._resolution.y;
				this._renderTargetBlurredA.Create();
			}
			if (this._renderTargetBlurredB != null)
			{
				this._renderTargetBlurredB.Release();
				this._renderTargetBlurredB.width = this._resolution.x;
				this._renderTargetBlurredB.height = this._resolution.y;
				this._renderTargetBlurredB.Create();
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600005B RID: 91 RVA: 0x000033D3 File Offset: 0x000015D3
		public Shader BlurShader
		{
			get
			{
				if (this._blurShader == null)
				{
					this._blurShader = Shader.Find("Kamgam/UGUI/BuiltIn/Blur Shader");
				}
				return this._blurShader;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600005C RID: 92 RVA: 0x000033F9 File Offset: 0x000015F9
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00003401 File Offset: 0x00001601
		public ShaderQuality Quality
		{
			get
			{
				return this._quality;
			}
			set
			{
				if (this._quality != value)
				{
					this._quality = value;
					this.setQualityOfMaterial(this._material, this._quality);
				}
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00003425 File Offset: 0x00001625
		// (set) Token: 0x0600005F RID: 95 RVA: 0x0000342D File Offset: 0x0000162D
		public Color AdditiveColor
		{
			get
			{
				return this._additiveColor;
			}
			set
			{
				this._additiveColor = value;
				this.setAdditiveColor(this._material, value);
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00003444 File Offset: 0x00001644
		// (set) Token: 0x06000061 RID: 97 RVA: 0x000034E4 File Offset: 0x000016E4
		public Material Material
		{
			get
			{
				if (this._material == null)
				{
					Shader shader = Shader.Find("Kamgam/UGUI/BuiltIn/Blur Shader");
					if (shader != null)
					{
						this._material = new Material(shader);
						this._material.color = Color.white;
						this._material.hideFlags = HideFlags.HideAndDontSave;
						this.setQualityOfMaterial(this._material, this._quality);
						this.setFlipVerticalOfMaterial(this._material, this.shouldFlipInShaderDependingOnProjectionParams());
						this.setAdditiveColor(this._material, this.AdditiveColor);
						this.setOffset(this._offset);
					}
				}
				return this._material;
			}
			set
			{
				this._material = value;
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000034F0 File Offset: 0x000016F0
		private void setQualityOfMaterial(Material material, ShaderQuality quality)
		{
			if (material == null)
			{
				return;
			}
			switch (quality)
			{
			case ShaderQuality.Low:
			{
				LocalKeyword localKeyword = new LocalKeyword(material.shader, "_SAMPLES_LOW");
				material.SetKeyword(localKeyword, true);
				localKeyword = new LocalKeyword(material.shader, "_SAMPLES_MEDIUM");
				material.SetKeyword(localKeyword, false);
				localKeyword = new LocalKeyword(material.shader, "_SAMPLES_HIGH");
				material.SetKeyword(localKeyword, false);
				return;
			}
			case ShaderQuality.Medium:
			{
				LocalKeyword localKeyword = new LocalKeyword(material.shader, "_SAMPLES_LOW");
				material.SetKeyword(localKeyword, false);
				localKeyword = new LocalKeyword(material.shader, "_SAMPLES_MEDIUM");
				material.SetKeyword(localKeyword, true);
				localKeyword = new LocalKeyword(material.shader, "_SAMPLES_HIGH");
				material.SetKeyword(localKeyword, false);
				return;
			}
			case ShaderQuality.High:
			{
				LocalKeyword localKeyword = new LocalKeyword(material.shader, "_SAMPLES_LOW");
				material.SetKeyword(localKeyword, false);
				localKeyword = new LocalKeyword(material.shader, "_SAMPLES_MEDIUM");
				material.SetKeyword(localKeyword, false);
				localKeyword = new LocalKeyword(material.shader, "_SAMPLES_HIGH");
				material.SetKeyword(localKeyword, true);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003608 File Offset: 0x00001808
		public BlurredBackgroundBufferBuiltIn(CameraEvent evt)
		{
			if (evt != CameraEvent.AfterEverything && evt != CameraEvent.BeforeForwardAlpha)
			{
				throw new Exception(string.Concat(new string[]
				{
					"Only ",
					CameraEvent.AfterEverything.ToString(),
					" and ",
					CameraEvent.BeforeForwardAlpha.ToString(),
					" events are supported."
				}));
			}
			this._cameraEvent = evt;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000036C8 File Offset: 0x000018C8
		private bool shouldFlipInShaderDependingOnProjectionParams()
		{
			return SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLCore || SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLES2 || SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLES3 || this._cameraEvent == CameraEvent.AfterEverything;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000036F0 File Offset: 0x000018F0
		private void setFlipVerticalOfMaterial(Material material, bool flip)
		{
			if (material == null)
			{
				return;
			}
			material.SetFloat("_FlipVertical", flip ? 1f : 0f);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003716 File Offset: 0x00001916
		private void setAdditiveColor(Material material, Color color)
		{
			if (material == null)
			{
				return;
			}
			material.SetColor("_AdditiveColor", color);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000372E File Offset: 0x0000192E
		private void setOffset(float value)
		{
			if (this._material != null)
			{
				this._material.SetVector("_BlurOffset", new Vector4(value, value, 0f, 0f));
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000068 RID: 104 RVA: 0x0000375F File Offset: 0x0000195F
		protected RenderTexture renderTargetBlurredA
		{
			get
			{
				if (this._renderTargetBlurredA == null)
				{
					this._renderTargetBlurredA = this.createRenderTexture();
				}
				return this._renderTargetBlurredA;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00003781 File Offset: 0x00001981
		protected RenderTexture renderTargetBlurredB
		{
			get
			{
				if (this._renderTargetBlurredB == null)
				{
					this._renderTargetBlurredB = this.createRenderTexture();
				}
				return this._renderTargetBlurredB;
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000037A4 File Offset: 0x000019A4
		private RenderTexture createRenderTexture()
		{
			RenderTextureReadWrite readWrite = (QualitySettings.activeColorSpace == ColorSpace.Linear) ? RenderTextureReadWrite.sRGB : RenderTextureReadWrite.Default;
			return new RenderTexture(this.Resolution.x, this.Resolution.y, 0, RenderTextureFormat.Default, readWrite)
			{
				filterMode = FilterMode.Bilinear,
				wrapMode = TextureWrapMode.Clamp
			};
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000037F0 File Offset: 0x000019F0
		public Texture GetBlurredTexture()
		{
			return this.renderTargetBlurredA;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000037F8 File Offset: 0x000019F8
		public void ClearBuffers()
		{
			if (this._camera != null && this._buffer != null)
			{
				this._camera.RemoveCommandBuffer(this._cameraEvent, this._buffer);
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003827 File Offset: 0x00001A27
		public void AddBuffer(Camera cam)
		{
			this.AddBuffer(cam, this._cameraEvent);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003838 File Offset: 0x00001A38
		public void AddBuffer(Camera cam, CameraEvent evt)
		{
			if (cam == null)
			{
				return;
			}
			foreach (CommandBuffer commandBuffer in cam.GetCommandBuffers(evt))
			{
				if (commandBuffer.name.StartsWith("Kamgam.UGUI Blur"))
				{
					cam.RemoveCommandBuffer(this._cameraEvent, commandBuffer);
					commandBuffer.Dispose();
				}
			}
			this._buffer = this.createBuffer("Kamgam.UGUI Blur (" + evt.ToString() + ")");
			cam.AddCommandBuffer(evt, this._buffer);
			cam.forceIntoRenderTexture = true;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000038CC File Offset: 0x00001ACC
		public CommandBuffer createBuffer(string name)
		{
			CommandBuffer commandBuffer = new CommandBuffer();
			commandBuffer.name = name;
			int nameID = Shader.PropertyToID("_ScreenCopyTexture");
			commandBuffer.GetTemporaryRT(nameID, new RenderTextureDescriptor(-1, -1)
			{
				depthBufferBits = 0,
				useMipMap = false,
				autoGenerateMips = false,
				colorFormat = RenderTextureFormat.Default,
				sRGB = (QualitySettings.activeColorSpace == ColorSpace.Linear)
			}, FilterMode.Bilinear);
			commandBuffer.Blit(BuiltinRenderTextureType.CurrentActive, nameID);
			commandBuffer.Blit(nameID, this.renderTargetBlurredA);
			int num = this.Iterations * 2 - 1;
			for (int i = 0; i < num; i++)
			{
				commandBuffer.Blit(this.renderTargetBlurredA, this.renderTargetBlurredB, this.Material, 0);
				commandBuffer.Blit(this.renderTargetBlurredB, this.renderTargetBlurredA, this.Material, 1);
			}
			commandBuffer.ReleaseTemporaryRT(nameID);
			return commandBuffer;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000039BA File Offset: 0x00001BBA
		public void UpdateActiveCamera(Camera cam)
		{
			if (cam != null && this._camera != cam)
			{
				this.ClearBuffers();
				this._camera = cam;
				this.AddBuffer(this._camera, this._cameraEvent);
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000039F2 File Offset: 0x00001BF2
		public void RecreateBuffers()
		{
			this.ClearBuffers();
			if (this._camera != null)
			{
				this.AddBuffer(this._camera);
			}
		}

		// Token: 0x04000034 RID: 52
		public const string ShaderName = "Kamgam/UGUI/BuiltIn/Blur Shader";

		// Token: 0x04000035 RID: 53
		public const CameraEvent CameraEventForScreenSpaceOverlayCanvases = CameraEvent.AfterEverything;

		// Token: 0x04000036 RID: 54
		public const CameraEvent CameraEventForWorldOrCameraCanvases = CameraEvent.BeforeForwardAlpha;

		// Token: 0x04000037 RID: 55
		protected Camera _camera;

		// Token: 0x04000038 RID: 56
		protected CameraEvent _cameraEvent;

		// Token: 0x04000039 RID: 57
		protected CommandBuffer _buffer;

		// Token: 0x0400003A RID: 58
		protected bool _active;

		// Token: 0x0400003B RID: 59
		protected int _iterations = 1;

		// Token: 0x0400003C RID: 60
		protected float _offset = 10f;

		// Token: 0x0400003D RID: 61
		protected Vector2Int _resolution = new Vector2Int(512, 512);

		// Token: 0x0400003E RID: 62
		protected Shader _blurShader;

		// Token: 0x0400003F RID: 63
		protected ShaderQuality _quality = ShaderQuality.Medium;

		// Token: 0x04000040 RID: 64
		protected Color _additiveColor = new Color(0f, 0f, 0f, 0f);

		// Token: 0x04000041 RID: 65
		[NonSerialized]
		protected Material _material;

		// Token: 0x04000042 RID: 66
		[NonSerialized]
		protected RenderTexture _renderTargetBlurredA;

		// Token: 0x04000043 RID: 67
		[NonSerialized]
		protected RenderTexture _renderTargetBlurredB;
	}
}
