using System;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x02000012 RID: 18
	public class BlurRendererHDRP : IBlurRenderer
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000A6 RID: 166 RVA: 0x00004558 File Offset: 0x00002758
		// (remove) Token: 0x060000A7 RID: 167 RVA: 0x00004590 File Offset: 0x00002790
		public event Action OnPostRender;

		// Token: 0x060000A8 RID: 168 RVA: 0x000045C5 File Offset: 0x000027C5
		public void SetImage(BlurredBackgroundImage image)
		{
			this._image = image;
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x000045D0 File Offset: 0x000027D0
		public BlurredBackgroundPassHDRPVolume ScreenSpaceVolume
		{
			get
			{
				if (this._screenSpaceVolume == null || this._screenSpaceVolume.gameObject == null)
				{
					BlurredBackgroundPassHDRPVolume blurredBackgroundPassHDRPVolume = BlurredBackgroundPassHDRPVolume.FindOrCreate(CustomPassInjectionPoint.AfterPostProcess, RenderUtils.GetGameViewCamera(this._image));
					if (blurredBackgroundPassHDRPVolume != null)
					{
						BlurredBackgroundPassHDRP orCreatePass = blurredBackgroundPassHDRPVolume.GetOrCreatePass(this.Quality, this.Resolution, this.Offset, this.Iterations, this.AdditiveColor);
						orCreatePass.enabled = this.Active;
						orCreatePass.Iterations = this.Iterations;
						orCreatePass.Offset = this.Offset;
						orCreatePass.Resolution = this.Resolution;
						orCreatePass.Quality = this.Quality;
						orCreatePass.AdditiveColor = this.AdditiveColor;
						orCreatePass.OnPostRender = (Action)Delegate.Combine(orCreatePass.OnPostRender, new Action(this.onPostRender));
					}
					this._screenSpaceVolume = blurredBackgroundPassHDRPVolume;
				}
				return this._screenSpaceVolume;
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000046B9 File Offset: 0x000028B9
		protected void onPostRender()
		{
			Action onPostRender = this.OnPostRender;
			if (onPostRender == null)
			{
				return;
			}
			onPostRender();
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000046CB File Offset: 0x000028CB
		protected BlurredBackgroundPassHDRP getScreenSpacePass()
		{
			if (this.ScreenSpaceVolume == null)
			{
				return null;
			}
			return this.ScreenSpaceVolume.GetOrCreatePass(this.Quality, this.Resolution, this.Offset, this.Iterations, this.AdditiveColor);
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00004708 File Offset: 0x00002908
		public BlurredBackgroundPassHDRPVolume WorldAndCameraSpaceVolume
		{
			get
			{
				if (this._worldAndCameraSpaceVolume == null || this._worldAndCameraSpaceVolume.gameObject == null)
				{
					BlurredBackgroundPassHDRPVolume blurredBackgroundPassHDRPVolume = BlurredBackgroundPassHDRPVolume.FindOrCreate(CustomPassInjectionPoint.BeforePreRefraction, RenderUtils.GetGameViewCamera(this._image));
					if (blurredBackgroundPassHDRPVolume != null)
					{
						BlurredBackgroundPassHDRP orCreatePass = blurredBackgroundPassHDRPVolume.GetOrCreatePass(this.Quality, this.Resolution, this.Offset, this.Iterations, this.AdditiveColor);
						BlurredBackgroundPassHDRP orCreatePass2 = this.ScreenSpaceVolume.GetOrCreatePass(this.Quality, this.Resolution, this.Offset, this.Iterations, this.AdditiveColor);
						if (orCreatePass2 != null)
						{
							orCreatePass.enabled = orCreatePass2.enabled;
							orCreatePass.Iterations = orCreatePass2.Iterations;
							orCreatePass.Offset = orCreatePass2.Offset;
							orCreatePass.Resolution = orCreatePass2.Resolution;
							orCreatePass.Quality = orCreatePass2.Quality;
							orCreatePass.AdditiveColor = orCreatePass2.AdditiveColor;
						}
					}
					this._worldAndCameraSpaceVolume = blurredBackgroundPassHDRPVolume;
				}
				return this._worldAndCameraSpaceVolume;
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000047FE File Offset: 0x000029FE
		protected BlurredBackgroundPassHDRP getWorldSpacePass()
		{
			if (this.WorldAndCameraSpaceVolume == null)
			{
				return null;
			}
			return this.WorldAndCameraSpaceVolume.GetOrCreatePass(this.Quality, this.Resolution, this.Offset, this.Iterations, this.AdditiveColor);
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00004839 File Offset: 0x00002A39
		// (set) Token: 0x060000AF RID: 175 RVA: 0x00004844 File Offset: 0x00002A44
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
					if (this._screenSpaceVolume != null)
					{
						this._screenSpaceVolume.enabled = value;
					}
					if (this._worldAndCameraSpaceVolume != null)
					{
						this._worldAndCameraSpaceVolume.enabled = value;
					}
				}
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00004895 File Offset: 0x00002A95
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x0000489D File Offset: 0x00002A9D
		public int Iterations
		{
			get
			{
				return this._iterations;
			}
			set
			{
				this._iterations = value;
				if (this._screenSpaceVolume != null)
				{
					this.getScreenSpacePass().Iterations = value;
				}
				if (this._worldAndCameraSpaceVolume != null)
				{
					this.getWorldSpacePass().Iterations = value;
				}
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x000048DA File Offset: 0x00002ADA
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x000048E2 File Offset: 0x00002AE2
		public float Offset
		{
			get
			{
				return this._offset;
			}
			set
			{
				this._offset = value;
				if (this._screenSpaceVolume != null)
				{
					this.getScreenSpacePass().Offset = value;
				}
				if (this._worldAndCameraSpaceVolume != null)
				{
					this.getWorldSpacePass().Offset = value;
				}
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x0000491F File Offset: 0x00002B1F
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x00004927 File Offset: 0x00002B27
		public Vector2Int Resolution
		{
			get
			{
				return this._resolution;
			}
			set
			{
				this._resolution = value;
				if (this._screenSpaceVolume != null)
				{
					this.getScreenSpacePass().Resolution = value;
				}
				if (this._worldAndCameraSpaceVolume != null)
				{
					this.getWorldSpacePass().Resolution = value;
				}
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x00004964 File Offset: 0x00002B64
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x0000496C File Offset: 0x00002B6C
		public ShaderQuality Quality
		{
			get
			{
				return this._quality;
			}
			set
			{
				this._quality = value;
				if (this._screenSpaceVolume != null)
				{
					this.getScreenSpacePass().Quality = value;
				}
				if (this._worldAndCameraSpaceVolume != null)
				{
					this.getWorldSpacePass().Quality = value;
				}
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x000049A9 File Offset: 0x00002BA9
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x000049B1 File Offset: 0x00002BB1
		public Color AdditiveColor
		{
			get
			{
				return this._additiveColor;
			}
			set
			{
				this._additiveColor = value;
				if (this._screenSpaceVolume != null)
				{
					this.getScreenSpacePass().AdditiveColor = value;
				}
				if (this._worldAndCameraSpaceVolume != null)
				{
					this.getWorldSpacePass().AdditiveColor = value;
				}
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000049EE File Offset: 0x00002BEE
		public Texture GetBlurredTexture(RenderMode renderMode)
		{
			if (renderMode == RenderMode.ScreenSpaceOverlay)
			{
				return this.getScreenSpacePass().GetBlurredTexture();
			}
			return this.getWorldSpacePass().GetBlurredTexture();
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00004A6C File Offset: 0x00002C6C
		public void ClearVolumeCache()
		{
			this._screenSpaceVolume = null;
			this._worldAndCameraSpaceVolume = null;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00004A7C File Offset: 0x00002C7C
		public void Update()
		{
			if (this._screenSpaceVolume != null && !this._screenSpaceVolume.Volume.isGlobal && (this._screenSpaceVolume.Volume.targetCamera == null || !this._screenSpaceVolume.Volume.targetCamera.isActiveAndEnabled))
			{
				this._screenSpaceVolume.Volume.targetCamera = RenderUtils.GetGameViewCamera(this._image);
			}
			if (this._worldAndCameraSpaceVolume != null && !this._worldAndCameraSpaceVolume.Volume.isGlobal && (this._worldAndCameraSpaceVolume.Volume.targetCamera == null || !this._worldAndCameraSpaceVolume.Volume.targetCamera.isActiveAndEnabled))
			{
				this._worldAndCameraSpaceVolume.Volume.targetCamera = RenderUtils.GetGameViewCamera(this._image);
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00004B60 File Offset: 0x00002D60
		protected override void Finalize()
		{
			try
			{
				if (this._screenSpaceVolume != null && this._screenSpaceVolume.GetPass() != null)
				{
					BlurredBackgroundPassHDRP pass = this._screenSpaceVolume.GetPass();
					pass.OnPostRender = (Action)Delegate.Remove(pass.OnPostRender, new Action(this.onPostRender));
					Utils.SmartDestroy(this._screenSpaceVolume);
					this._screenSpaceVolume = null;
				}
				if (this._worldAndCameraSpaceVolume != null)
				{
					Utils.SmartDestroy(this._worldAndCameraSpaceVolume.gameObject);
					this._worldAndCameraSpaceVolume = null;
				}
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x0400005B RID: 91
		public BlurredBackgroundImage _image;

		// Token: 0x0400005C RID: 92
		protected BlurredBackgroundPassHDRPVolume _screenSpaceVolume;

		// Token: 0x0400005D RID: 93
		protected BlurredBackgroundPassHDRPVolume _worldAndCameraSpaceVolume;

		// Token: 0x0400005E RID: 94
		protected bool _active;

		// Token: 0x0400005F RID: 95
		protected int _iterations = 1;

		// Token: 0x04000060 RID: 96
		protected float _offset = 1.5f;

		// Token: 0x04000061 RID: 97
		protected Vector2Int _resolution = new Vector2Int(512, 512);

		// Token: 0x04000062 RID: 98
		protected ShaderQuality _quality = ShaderQuality.Medium;

		// Token: 0x04000063 RID: 99
		protected Color _additiveColor = new Color(0f, 0f, 0f, 0f);
	}
}
