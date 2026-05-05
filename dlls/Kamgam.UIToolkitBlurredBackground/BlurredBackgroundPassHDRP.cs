using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x0200000F RID: 15
	public class BlurredBackgroundPassHDRP : CustomPass
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00003A14 File Offset: 0x00001C14
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00003B98 File Offset: 0x00001D98
		public Material Material
		{
			get
			{
				if (this._material == null)
				{
					Shader shader = Shader.Find("Kamgam/UGUI/HDRP/Blur Shader");
					if (shader != null)
					{
						this._material = CoreUtils.CreateEngineMaterial(shader);
						this._material.color = Color.white;
						switch (this._quality)
						{
						case ShaderQuality.Low:
						{
							Material material = this._material;
							LocalKeyword localKeyword = new LocalKeyword(shader, "_SAMPLES_LOW");
							material.SetKeyword(localKeyword, true);
							Material material2 = this._material;
							localKeyword = new LocalKeyword(shader, "_SAMPLES_MEDIUM");
							material2.SetKeyword(localKeyword, false);
							Material material3 = this._material;
							localKeyword = new LocalKeyword(shader, "_SAMPLES_HIGH");
							material3.SetKeyword(localKeyword, false);
							break;
						}
						case ShaderQuality.Medium:
						{
							Material material4 = this._material;
							LocalKeyword localKeyword = new LocalKeyword(shader, "_SAMPLES_LOW");
							material4.SetKeyword(localKeyword, false);
							Material material5 = this._material;
							localKeyword = new LocalKeyword(shader, "_SAMPLES_MEDIUM");
							material5.SetKeyword(localKeyword, true);
							Material material6 = this._material;
							localKeyword = new LocalKeyword(shader, "_SAMPLES_HIGH");
							material6.SetKeyword(localKeyword, false);
							break;
						}
						case ShaderQuality.High:
						{
							Material material7 = this._material;
							LocalKeyword localKeyword = new LocalKeyword(shader, "_SAMPLES_LOW");
							material7.SetKeyword(localKeyword, false);
							Material material8 = this._material;
							localKeyword = new LocalKeyword(shader, "_SAMPLES_MEDIUM");
							material8.SetKeyword(localKeyword, false);
							Material material9 = this._material;
							localKeyword = new LocalKeyword(shader, "_SAMPLES_HIGH");
							material9.SetKeyword(localKeyword, true);
							break;
						}
						}
						this.setOffset(this.Offset);
						this.setAdditiveColor(this._material, this.AdditiveColor);
					}
				}
				return this._material;
			}
			set
			{
				this._material = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00003BA1 File Offset: 0x00001DA1
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00003BA9 File Offset: 0x00001DA9
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

		// Token: 0x06000076 RID: 118 RVA: 0x00003BBF File Offset: 0x00001DBF
		private void setAdditiveColor(Material material, Color color)
		{
			if (material == null)
			{
				return;
			}
			material.SetColor("_AdditiveColor", color);
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00003BD7 File Offset: 0x00001DD7
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00003BDF File Offset: 0x00001DDF
		public int Iterations
		{
			get
			{
				return this._iterations;
			}
			set
			{
				if (this._iterations != value)
				{
					this._iterations = value;
					this.enabled = (this._iterations > 0);
				}
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00003C00 File Offset: 0x00001E00
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00003C08 File Offset: 0x00001E08
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

		// Token: 0x0600007B RID: 123 RVA: 0x00003C18 File Offset: 0x00001E18
		private void setOffset(float value)
		{
			if (this.Material != null)
			{
				this.Material.SetVector("_BlurOffset", new Vector4(value, value, 0f, 0f));
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00003C49 File Offset: 0x00001E49
		// (set) Token: 0x0600007D RID: 125 RVA: 0x00003C51 File Offset: 0x00001E51
		public ShaderQuality Quality
		{
			get
			{
				return this._quality;
			}
			set
			{
				this._quality = value;
				this._material = null;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00003C61 File Offset: 0x00001E61
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00003C69 File Offset: 0x00001E69
		public Vector2Int Resolution
		{
			get
			{
				return this._resolution;
			}
			set
			{
				if (this._resolution != value)
				{
					this._resolution = value;
					this.UpdateRenderTextureResolutions();
				}
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003C88 File Offset: 0x00001E88
		public void UpdateRenderTextureResolutions()
		{
			if (this._renderTargetBlurredA != null)
			{
				this._renderTargetBlurredA.Release();
				this._renderTargetBlurredA.width = this.Resolution.x;
				this._renderTargetBlurredA.height = this.Resolution.y;
				this._renderTargetBlurredA.Create();
			}
			if (this._renderTargetBlurredB != null)
			{
				this._renderTargetBlurredB.Release();
				this._renderTargetBlurredB.width = this.Resolution.x;
				this._renderTargetBlurredB.height = this.Resolution.y;
				this._renderTargetBlurredB.Create();
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00003D43 File Offset: 0x00001F43
		public RenderTexture RenderTargetBlurredA
		{
			get
			{
				if (this._renderTargetBlurredA == null)
				{
					this._renderTargetBlurredA = this.createRenderTexture();
					if (this._renderTargetHandleA != null)
					{
						this._renderTargetHandleA.Release();
						this._renderTargetHandleA = null;
					}
				}
				return this._renderTargetBlurredA;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00003D7F File Offset: 0x00001F7F
		public RenderTexture RenderTargetBlurredB
		{
			get
			{
				if (this._renderTargetBlurredB == null)
				{
					this._renderTargetBlurredB = this.createRenderTexture();
					if (this._renderTargetHandleB != null)
					{
						this._renderTargetHandleB.Release();
						this._renderTargetHandleB = null;
					}
				}
				return this._renderTargetBlurredB;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00003DBB File Offset: 0x00001FBB
		public RTHandle RenderTargetHandleA
		{
			get
			{
				if (this._renderTargetHandleA == null)
				{
					this._renderTargetHandleA = RTHandles.Alloc(this.RenderTargetBlurredA);
				}
				return this._renderTargetHandleA;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00003DDC File Offset: 0x00001FDC
		public RTHandle RenderTargetHandleB
		{
			get
			{
				if (this._renderTargetHandleB == null)
				{
					this._renderTargetHandleB = RTHandles.Alloc(this.RenderTargetBlurredB);
				}
				return this._renderTargetHandleB;
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003E00 File Offset: 0x00002000
		private RenderTexture createRenderTexture()
		{
			return new RenderTexture(this.Resolution.x, this.Resolution.y, 0)
			{
				filterMode = FilterMode.Bilinear
			};
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003E36 File Offset: 0x00002036
		public Texture GetBlurredTexture()
		{
			return this.RenderTargetBlurredA;
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00003E3E File Offset: 0x0000203E
		protected override bool executeInSceneView
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003E41 File Offset: 0x00002041
		protected override void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
		{
			base.name = "UGUI Blurred Background";
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003E50 File Offset: 0x00002050
		protected override void Execute(CustomPassContext ctx)
		{
			if (this.Material == null || this.Iterations == 0 || this.Offset == 0f)
			{
				return;
			}
			RTHandle cameraColorBuffer = ctx.cameraColorBuffer;
			Vector4 rtHandleScale = RTHandles.rtHandleProperties.rtHandleScale;
			ctx.cmd.Blit(cameraColorBuffer, this.RenderTargetBlurredA, new Vector2(rtHandleScale.x, rtHandleScale.y), Vector2.zero, 0, 0);
			for (int i = 0; i < this.Iterations; i++)
			{
				ctx.cmd.Blit(this.RenderTargetBlurredA, this.RenderTargetBlurredB, this.Material, 0);
				ctx.cmd.Blit(this.RenderTargetBlurredB, this.RenderTargetBlurredA, this.Material, 1);
			}
			Action onPostRender = this.OnPostRender;
			if (onPostRender == null)
			{
				return;
			}
			onPostRender();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003F30 File Offset: 0x00002130
		protected override void Cleanup()
		{
			CoreUtils.Destroy(this._material);
			if (this._renderTargetBlurredA != null)
			{
				this._renderTargetBlurredA.Release();
				this._renderTargetBlurredA = null;
			}
			if (this._renderTargetBlurredB != null)
			{
				this._renderTargetBlurredB.Release();
				this._renderTargetBlurredB = null;
			}
			if (this._renderTargetHandleA != null)
			{
				this._renderTargetHandleA.Release();
				this._renderTargetHandleA = null;
			}
			if (this._renderTargetHandleB != null)
			{
				this._renderTargetHandleB.Release();
				this._renderTargetHandleB = null;
			}
			base.Cleanup();
		}

		// Token: 0x04000044 RID: 68
		public Action OnPostRender;

		// Token: 0x04000045 RID: 69
		public const string ShaderName = "Kamgam/UGUI/HDRP/Blur Shader";

		// Token: 0x04000046 RID: 70
		[NonSerialized]
		protected Material _material;

		// Token: 0x04000047 RID: 71
		protected Color _additiveColor = new Color(0f, 0f, 0f, 0f);

		// Token: 0x04000048 RID: 72
		[NonSerialized]
		protected int _iterations;

		// Token: 0x04000049 RID: 73
		protected float _offset;

		// Token: 0x0400004A RID: 74
		protected ShaderQuality _quality;

		// Token: 0x0400004B RID: 75
		protected Vector2Int _resolution = new Vector2Int(512, 512);

		// Token: 0x0400004C RID: 76
		[NonSerialized]
		protected RenderTexture _renderTargetBlurredA;

		// Token: 0x0400004D RID: 77
		[NonSerialized]
		protected RenderTexture _renderTargetBlurredB;

		// Token: 0x0400004E RID: 78
		[NonSerialized]
		protected RTHandle _renderTargetHandleA;

		// Token: 0x0400004F RID: 79
		[NonSerialized]
		protected RTHandle _renderTargetHandleB;
	}
}
