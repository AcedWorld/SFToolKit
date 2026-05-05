using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x02000011 RID: 17
	public class BlurRendererBuiltIn : IBlurRenderer
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000090 RID: 144 RVA: 0x0000419C File Offset: 0x0000239C
		// (remove) Token: 0x06000091 RID: 145 RVA: 0x000041D4 File Offset: 0x000023D4
		public event Action OnPostRender;

		// Token: 0x06000092 RID: 146 RVA: 0x00004209 File Offset: 0x00002409
		public void SetImage(BlurredBackgroundImage image)
		{
			this._image = image;
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00004212 File Offset: 0x00002412
		public BlurredBackgroundBufferBuiltIn ScreenSpaceBuffer
		{
			get
			{
				if (this._screenSpaceBuffer == null)
				{
					this._screenSpaceBuffer = new BlurredBackgroundBufferBuiltIn(CameraEvent.AfterEverything);
				}
				return this._screenSpaceBuffer;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00004230 File Offset: 0x00002430
		public BlurredBackgroundBufferBuiltIn WorldAndCameraSpaceBuffer
		{
			get
			{
				if (this._worldAndCameraSpaceBuffer == null)
				{
					this._worldAndCameraSpaceBuffer = new BlurredBackgroundBufferBuiltIn(CameraEvent.BeforeForwardAlpha);
					this._worldAndCameraSpaceBuffer.Active = this._screenSpaceBuffer.Active;
					this._worldAndCameraSpaceBuffer.Iterations = this._screenSpaceBuffer.Iterations;
					this._worldAndCameraSpaceBuffer.Offset = this._screenSpaceBuffer.Offset;
					this._worldAndCameraSpaceBuffer.Resolution = this._screenSpaceBuffer.Resolution;
					this._worldAndCameraSpaceBuffer.Quality = this._screenSpaceBuffer.Quality;
				}
				return this._worldAndCameraSpaceBuffer;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000095 RID: 149 RVA: 0x000042C6 File Offset: 0x000024C6
		// (set) Token: 0x06000096 RID: 150 RVA: 0x000042D0 File Offset: 0x000024D0
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
						this.ScreenSpaceBuffer.Active = value;
						this.ScreenSpaceBuffer.ClearBuffers();
						if (this._worldAndCameraSpaceBuffer != null)
						{
							this._worldAndCameraSpaceBuffer.Active = value;
							this._worldAndCameraSpaceBuffer.ClearBuffers();
							return;
						}
					}
					else
					{
						Camera gameViewCamera = RenderUtils.GetGameViewCamera(this._image);
						this.ScreenSpaceBuffer.Active = value;
						this.ScreenSpaceBuffer.AddBuffer(gameViewCamera);
						if (this._worldAndCameraSpaceBuffer != null)
						{
							this._worldAndCameraSpaceBuffer.Active = value;
							this._worldAndCameraSpaceBuffer.AddBuffer(gameViewCamera);
						}
					}
				}
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00004373 File Offset: 0x00002573
		// (set) Token: 0x06000098 RID: 152 RVA: 0x00004380 File Offset: 0x00002580
		public int Iterations
		{
			get
			{
				return this.ScreenSpaceBuffer.Iterations;
			}
			set
			{
				this.ScreenSpaceBuffer.Iterations = value;
				if (this._worldAndCameraSpaceBuffer != null)
				{
					this._worldAndCameraSpaceBuffer.Iterations = value;
				}
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000099 RID: 153 RVA: 0x000043A2 File Offset: 0x000025A2
		// (set) Token: 0x0600009A RID: 154 RVA: 0x000043AF File Offset: 0x000025AF
		public float Offset
		{
			get
			{
				return this.ScreenSpaceBuffer.Offset;
			}
			set
			{
				this.ScreenSpaceBuffer.Offset = value;
				if (this._worldAndCameraSpaceBuffer != null)
				{
					this._worldAndCameraSpaceBuffer.Offset = value;
				}
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600009B RID: 155 RVA: 0x000043D1 File Offset: 0x000025D1
		// (set) Token: 0x0600009C RID: 156 RVA: 0x000043DE File Offset: 0x000025DE
		public Vector2Int Resolution
		{
			get
			{
				return this.ScreenSpaceBuffer.Resolution;
			}
			set
			{
				this.ScreenSpaceBuffer.Resolution = value;
				if (this._worldAndCameraSpaceBuffer != null)
				{
					this._worldAndCameraSpaceBuffer.Resolution = value;
				}
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00004400 File Offset: 0x00002600
		// (set) Token: 0x0600009E RID: 158 RVA: 0x0000440D File Offset: 0x0000260D
		public ShaderQuality Quality
		{
			get
			{
				return this.ScreenSpaceBuffer.Quality;
			}
			set
			{
				this.ScreenSpaceBuffer.Quality = value;
				if (this._worldAndCameraSpaceBuffer != null)
				{
					this._worldAndCameraSpaceBuffer.Quality = value;
				}
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000442F File Offset: 0x0000262F
		public Material GetMaterial(RenderMode renderMode)
		{
			if (renderMode == RenderMode.ScreenSpaceOverlay)
			{
				return this.ScreenSpaceBuffer.Material;
			}
			return this.WorldAndCameraSpaceBuffer.Material;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000444B File Offset: 0x0000264B
		public Texture GetBlurredTexture(RenderMode renderMode)
		{
			if (renderMode == RenderMode.ScreenSpaceOverlay)
			{
				return this.ScreenSpaceBuffer.GetBlurredTexture();
			}
			return this.WorldAndCameraSpaceBuffer.GetBlurredTexture();
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00004467 File Offset: 0x00002667
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x0000446F File Offset: 0x0000266F
		public Color AdditiveColor
		{
			get
			{
				return this._additiveColor;
			}
			set
			{
				this._additiveColor = value;
				this.ScreenSpaceBuffer.AdditiveColor = value;
				if (this._worldAndCameraSpaceBuffer != null)
				{
					this.WorldAndCameraSpaceBuffer.AdditiveColor = value;
				}
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004498 File Offset: 0x00002698
		public void Update()
		{
			Camera gameViewCamera = RenderUtils.GetGameViewCamera(this._image);
			BlurredBackgroundBufferBuiltIn screenSpaceBuffer = this._screenSpaceBuffer;
			if (screenSpaceBuffer != null)
			{
				screenSpaceBuffer.UpdateActiveCamera(gameViewCamera);
			}
			BlurredBackgroundBufferBuiltIn worldAndCameraSpaceBuffer = this._worldAndCameraSpaceBuffer;
			if (worldAndCameraSpaceBuffer != null)
			{
				worldAndCameraSpaceBuffer.UpdateActiveCamera(gameViewCamera);
			}
			Action onPostRender = this.OnPostRender;
			if (onPostRender == null)
			{
				return;
			}
			onPostRender();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000044E8 File Offset: 0x000026E8
		protected override void Finalize()
		{
			try
			{
				BlurredBackgroundBufferBuiltIn screenSpaceBuffer = this._screenSpaceBuffer;
				if (screenSpaceBuffer != null)
				{
					screenSpaceBuffer.ClearBuffers();
				}
				BlurredBackgroundBufferBuiltIn worldAndCameraSpaceBuffer = this._worldAndCameraSpaceBuffer;
				if (worldAndCameraSpaceBuffer != null)
				{
					worldAndCameraSpaceBuffer.ClearBuffers();
				}
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x04000055 RID: 85
		public BlurredBackgroundImage _image;

		// Token: 0x04000056 RID: 86
		protected BlurredBackgroundBufferBuiltIn _screenSpaceBuffer;

		// Token: 0x04000057 RID: 87
		protected BlurredBackgroundBufferBuiltIn _worldAndCameraSpaceBuffer;

		// Token: 0x04000058 RID: 88
		protected bool _active;

		// Token: 0x04000059 RID: 89
		protected Color _additiveColor = new Color(0f, 0f, 0f, 0f);
	}
}
