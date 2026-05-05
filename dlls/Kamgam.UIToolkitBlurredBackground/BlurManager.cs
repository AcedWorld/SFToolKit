using System;
using System.Collections.Generic;
using Kamgam.UGUIBlurredBackground.EditorSingleton;
using UnityEngine;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x0200000B RID: 11
	public class BlurManager
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000019 RID: 25 RVA: 0x000024A0 File Offset: 0x000006A0
		public static BlurManager Instance
		{
			get
			{
				if (BlurManager._instance == null)
				{
					BlurManager._instance = new BlurManager();
					BlurManager._instance.ApplyValues();
					BlurManagerUpdater instance = EditorMonoBehaviourSingleton<BlurManagerUpdater>.Instance;
					instance.OnUpdate = (Action)Delegate.Combine(instance.OnUpdate, new Action(BlurManager._instance.Update));
				}
				return BlurManager._instance;
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000024F7 File Offset: 0x000006F7
		public static bool HasInstance()
		{
			return BlurManager._instance != null;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002504 File Offset: 0x00000704
		~BlurManager()
		{
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000252C File Offset: 0x0000072C
		// (set) Token: 0x0600001D RID: 29 RVA: 0x00002534 File Offset: 0x00000734
		public int Iterations
		{
			get
			{
				return this._iterations;
			}
			set
			{
				if (value < 0)
				{
					value = 0;
				}
				this._iterations = value;
				this.Renderer.Iterations = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002550 File Offset: 0x00000750
		// (set) Token: 0x0600001F RID: 31 RVA: 0x00002558 File Offset: 0x00000758
		public float Offset
		{
			get
			{
				return this._offset;
			}
			set
			{
				if (value < 0f)
				{
					value = 0f;
				}
				this._offset = value;
				this.Renderer.Offset = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000020 RID: 32 RVA: 0x0000257C File Offset: 0x0000077C
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00002584 File Offset: 0x00000784
		public Vector2Int Resolution
		{
			get
			{
				return this._resolution;
			}
			set
			{
				if (value.x < 2 || value.y < 2)
				{
					value = new Vector2Int(2, 2);
				}
				this._resolution = value;
				this.Renderer.Resolution = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000022 RID: 34 RVA: 0x000025B6 File Offset: 0x000007B6
		// (set) Token: 0x06000023 RID: 35 RVA: 0x000025BE File Offset: 0x000007BE
		public ShaderQuality Quality
		{
			get
			{
				return this._quality;
			}
			set
			{
				this._quality = value;
				this.Renderer.Quality = this._quality;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000024 RID: 36 RVA: 0x000025D8 File Offset: 0x000007D8
		// (set) Token: 0x06000025 RID: 37 RVA: 0x000025E0 File Offset: 0x000007E0
		public Color AdditiveColor
		{
			get
			{
				return this._additiveColor;
			}
			set
			{
				this._additiveColor = value;
				this.Renderer.AdditiveColor = this._additiveColor;
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000025FC File Offset: 0x000007FC
		public void ApplyValues()
		{
			this.Renderer.Iterations = this.Iterations;
			this.Renderer.Offset = this.Offset;
			this.Renderer.Resolution = this.Resolution;
			this.Renderer.Quality = this.Quality;
			this.Renderer.AdditiveColor = this.AdditiveColor;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002660 File Offset: 0x00000860
		public void ApplyValues(BlurredBackgroundImage img)
		{
			this.Iterations = img.Iterations;
			this.Offset = img.Strength;
			this.Resolution = img.Resolution.ToResolution();
			this.Quality = img.Quality;
			this.AdditiveColor = img.AdditiveColor;
			this.ApplyValues();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000026B4 File Offset: 0x000008B4
		public Texture GetBlurredTexture(RenderMode renderMode)
		{
			return this.Renderer.GetBlurredTexture(renderMode);
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000026C2 File Offset: 0x000008C2
		// (set) Token: 0x0600002A RID: 42 RVA: 0x000026F6 File Offset: 0x000008F6
		public IBlurRenderer Renderer
		{
			get
			{
				if (this._renderer == null)
				{
					if (RenderPipelineDetector.IsBuiltIn())
					{
						this._renderer = new BlurRendererBuiltIn();
					}
					if (RenderPipelineDetector.IsHDRP())
					{
						this._renderer = new BlurRendererHDRP();
					}
				}
				return this._renderer;
			}
			set
			{
				this._renderer = value;
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002700 File Offset: 0x00000900
		public void RegisterImage(BlurredBackgroundImage img)
		{
			if (!this._images.Contains(img))
			{
				this._images.Add(img);
			}
			this._lastRegisteredImage = img;
			if (this.Renderer != null)
			{
				this.Renderer.SetImage(img);
				this.Renderer.Active = this.shouldBeActive();
				this.RefreshRenderModeInfos();
			}
			EditorMonoBehaviourSingleton<BlurManagerUpdater>.Instance.Refresh();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002763 File Offset: 0x00000963
		public void RefreshRenderModeInfos()
		{
			if (this.Renderer != null)
			{
				this._usesWorldOrCameraSpaceCanvases = null;
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000277C File Offset: 0x0000097C
		public bool UsesWorldOrCameraSpaceCanvases()
		{
			if (this._usesWorldOrCameraSpaceCanvases != null)
			{
				return this._usesWorldOrCameraSpaceCanvases.Value;
			}
			foreach (BlurredBackgroundImage blurredBackgroundImage in this._images)
			{
				RenderMode renderMode = blurredBackgroundImage.GetRenderMode();
				if (renderMode == RenderMode.ScreenSpaceCamera || renderMode == RenderMode.WorldSpace)
				{
					this._usesWorldOrCameraSpaceCanvases = new bool?(true);
					return true;
				}
			}
			this._usesWorldOrCameraSpaceCanvases = new bool?(false);
			return false;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002810 File Offset: 0x00000A10
		public void UnregisterImage(BlurredBackgroundImage img)
		{
			if (this._images.Contains(img))
			{
				this._images.Remove(img);
			}
			if (this.Renderer != null)
			{
				this.Renderer.Active = this.shouldBeActive();
				this.RefreshRenderModeInfos();
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000284C File Offset: 0x00000A4C
		protected bool shouldBeActive()
		{
			int num = 0;
			foreach (BlurredBackgroundImage blurredBackgroundImage in this._images)
			{
				if (blurredBackgroundImage != null && blurredBackgroundImage.gameObject != null && blurredBackgroundImage.isActiveAndEnabled && blurredBackgroundImage.gameObject.activeInHierarchy)
				{
					num++;
					break;
				}
			}
			return num > 0 && this._iterations > 0 && this._offset > 0f;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000028E8 File Offset: 0x00000AE8
		public void Update()
		{
			this.Renderer.Active = this.shouldBeActive();
			if (this.Renderer.Active)
			{
				this.Renderer.Update();
			}
		}

		// Token: 0x0400001C RID: 28
		private static BlurManager _instance;

		// Token: 0x0400001D RID: 29
		[NonSerialized]
		protected int _iterations = 1;

		// Token: 0x0400001E RID: 30
		[NonSerialized]
		protected float _offset = 10f;

		// Token: 0x0400001F RID: 31
		[NonSerialized]
		protected Vector2Int _resolution = new Vector2Int(512, 512);

		// Token: 0x04000020 RID: 32
		[NonSerialized]
		protected ShaderQuality _quality = ShaderQuality.Medium;

		// Token: 0x04000021 RID: 33
		[NonSerialized]
		protected Color _additiveColor = new Color(0f, 0f, 0f, 0f);

		// Token: 0x04000022 RID: 34
		[NonSerialized]
		protected IBlurRenderer _renderer;

		// Token: 0x04000023 RID: 35
		protected List<BlurredBackgroundImage> _images = new List<BlurredBackgroundImage>();

		// Token: 0x04000024 RID: 36
		protected BlurredBackgroundImage _lastRegisteredImage;

		// Token: 0x04000025 RID: 37
		protected bool? _usesWorldOrCameraSpaceCanvases;
	}
}
