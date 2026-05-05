using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x0200000D RID: 13
	[ExecuteAlways]
	[AddComponentMenu("UI/Kamgam/Blurred Background Image")]
	public class BlurredBackgroundImage : Image
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000034 RID: 52 RVA: 0x0000298E File Offset: 0x00000B8E
		// (set) Token: 0x06000035 RID: 53 RVA: 0x00002998 File Offset: 0x00000B98
		public float Strength
		{
			get
			{
				return this._strength;
			}
			set
			{
				if (value < 0f)
				{
					value = 0f;
				}
				if (value != this._strength)
				{
					if (Mathf.Approximately(value, 0f) || Mathf.Approximately(this._strength, 0f))
					{
						this.SetVerticesDirty();
					}
					this._strength = value;
				}
				if (value != BlurManager.Instance.Offset)
				{
					BlurManager.Instance.Offset = value;
				}
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002A01 File Offset: 0x00000C01
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00002A09 File Offset: 0x00000C09
		public ShaderQuality Quality
		{
			get
			{
				return this._quality;
			}
			set
			{
				this._quality = value;
				if (value != BlurManager.Instance.Quality)
				{
					BlurManager.Instance.Quality = value;
				}
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002A2A File Offset: 0x00000C2A
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00002A34 File Offset: 0x00000C34
		public SquareResolution Resolution
		{
			get
			{
				return this._resolution;
			}
			set
			{
				this._resolution = value;
				Vector2Int vector2Int = value.ToResolution();
				if (vector2Int != BlurManager.Instance.Resolution)
				{
					BlurManager.Instance.Resolution = vector2Int;
				}
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002A6C File Offset: 0x00000C6C
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00002A74 File Offset: 0x00000C74
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
				if (this._iterations != value)
				{
					if (value == 0 || this._strength == 0f)
					{
						this.SetVerticesDirty();
					}
					this._iterations = value;
				}
				if (value != BlurManager.Instance.Iterations)
				{
					BlurManager.Instance.Iterations = value;
				}
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002AC6 File Offset: 0x00000CC6
		// (set) Token: 0x0600003D RID: 61 RVA: 0x00002ACE File Offset: 0x00000CCE
		public Color AdditiveColor
		{
			get
			{
				return this._additiveColor;
			}
			set
			{
				if (value == BlurManager.Instance.Renderer.AdditiveColor)
				{
					return;
				}
				this._additiveColor = value;
				BlurManager.Instance.Renderer.AdditiveColor = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00002AFF File Offset: 0x00000CFF
		// (set) Token: 0x0600003F RID: 63 RVA: 0x00002B07 File Offset: 0x00000D07
		public Vector2 FOVScale
		{
			get
			{
				return this._FOVScale;
			}
			set
			{
				if (value == this._FOVScale)
				{
					return;
				}
				this._FOVScale = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002B28 File Offset: 0x00000D28
		internal void _EditorApplyChangedValues()
		{
			this.Iterations = this._iterations;
			this.Strength = this._strength;
			this.Resolution = this._resolution;
			this.Quality = this._quality;
			this.AdditiveColor = this._additiveColor;
			this.FOVScale = this._FOVScale;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002B80 File Offset: 0x00000D80
		public RenderMode GetRenderMode()
		{
			RenderMode renderMode;
			if (base.canvas == null)
			{
				renderMode = RenderMode.ScreenSpaceOverlay;
			}
			else
			{
				renderMode = base.canvas.renderMode;
			}
			if (renderMode == RenderMode.ScreenSpaceCamera && base.canvas != null && base.canvas.worldCamera == null)
			{
				renderMode = RenderMode.ScreenSpaceOverlay;
			}
			return renderMode;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002BD5 File Offset: 0x00000DD5
		protected override void OnCanvasHierarchyChanged()
		{
			base.OnCanvasHierarchyChanged();
			this.SetVerticesDirty();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002BE3 File Offset: 0x00000DE3
		protected override void Awake()
		{
			base.Awake();
			BlurManager.Instance.RegisterImage(this);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002BF6 File Offset: 0x00000DF6
		protected override void OnEnable()
		{
			base.OnEnable();
			BlurManager.Instance.RegisterImage(this);
			BlurManager.Instance.ApplyValues(this);
			BlurManager.Instance.Renderer.OnPostRender += this.onPostRender;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002C2F File Offset: 0x00000E2F
		protected override void Start()
		{
			base.Start();
			this.SetVerticesDirty();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002C40 File Offset: 0x00000E40
		protected void onPostRender()
		{
			if (this == null || base.gameObject == null)
			{
				return;
			}
			Texture blurredTexture = BlurManager.Instance.GetBlurredTexture(this.GetRenderMode());
			if (blurredTexture != null)
			{
				base.canvasRenderer.SetTexture(blurredTexture);
			}
			if (base.canvas != null && base.canvas.renderMode == RenderMode.WorldSpace)
			{
				Camera gameViewCamera = RenderUtils.GetGameViewCamera(this);
				if (gameViewCamera != null && gameViewCamera.cameraType == CameraType.Game && gameViewCamera.worldToCameraMatrix != this._lastWorldToCameraMatrix)
				{
					this._lastWorldToCameraMatrix = gameViewCamera.worldToCameraMatrix;
					this.SetVerticesDirty();
				}
			}
			if (base.transform.worldToLocalMatrix != this._lastWorldToLocalMatrix)
			{
				this._lastWorldToLocalMatrix = base.transform.worldToLocalMatrix;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002D14 File Offset: 0x00000F14
		public override Texture mainTexture
		{
			get
			{
				Texture blurredTexture = BlurManager.Instance.GetBlurredTexture(this.GetRenderMode());
				if (blurredTexture != null)
				{
					return blurredTexture;
				}
				return base.mainTexture;
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002D44 File Offset: 0x00000F44
		protected override void OnDisable()
		{
			if (BlurManager.HasInstance())
			{
				BlurManager.Instance.UnregisterImage(this);
				if (BlurManager.Instance.Renderer != null)
				{
					BlurManager.Instance.Renderer.OnPostRender -= this.onPostRender;
				}
			}
			this.material = null;
			base.OnDisable();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002D97 File Offset: 0x00000F97
		protected override void OnDestroy()
		{
			base.OnDestroy();
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002DA0 File Offset: 0x00000FA0
		protected override void OnPopulateMesh(VertexHelper vh)
		{
			if (this.Iterations == 0 || this.Strength == 0f)
			{
				vh.Clear();
				base.canvasRenderer.Clear();
				return;
			}
			if (this.UseCustomMesh)
			{
				this.drawCustomMesh(vh);
			}
			else
			{
				base.OnPopulateMesh(vh);
			}
			this.updateUVs(vh);
			Texture blurredTexture = BlurManager.Instance.GetBlurredTexture(this.GetRenderMode());
			if (blurredTexture != null)
			{
				base.canvasRenderer.SetTexture(blurredTexture);
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002E1C File Offset: 0x0000101C
		protected void drawCustomMesh(VertexHelper vh)
		{
			vh.Clear();
			Rect pixelAdjustedRect = base.GetPixelAdjustedRect();
			int customMeshDivisions = this.CustomMeshDivisions;
			int customMeshDivisions2 = this.CustomMeshDivisions;
			float num = pixelAdjustedRect.width / (float)customMeshDivisions;
			float num2 = pixelAdjustedRect.height / (float)customMeshDivisions2;
			Color color = this.color;
			for (int i = 0; i < customMeshDivisions; i++)
			{
				for (int j = 0; j < customMeshDivisions2; j++)
				{
					Vector3 vector = new Vector3(pixelAdjustedRect.xMin + (float)i * num, pixelAdjustedRect.yMin + (float)j * num2);
					Vector3 vector2 = new Vector3(pixelAdjustedRect.xMin + (float)(i + 1) * num, pixelAdjustedRect.yMin + (float)(j + 1) * num2);
					Vector2 uvMin = new Vector2(vector.x / pixelAdjustedRect.width, vector.y / pixelAdjustedRect.height);
					Vector2 uvMax = new Vector2(vector2.x / pixelAdjustedRect.width, vector2.y / pixelAdjustedRect.height);
					BlurredBackgroundImage.AddQuad(vh, vector, vector2, color, uvMin, uvMax);
				}
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002F40 File Offset: 0x00001140
		private static void AddQuad(VertexHelper vertexHelper, Vector2 posMin, Vector2 posMax, Color32 color, Vector2 uvMin, Vector2 uvMax)
		{
			int currentVertCount = vertexHelper.currentVertCount;
			vertexHelper.AddVert(new Vector3(posMin.x, posMin.y, 0f), color, new Vector2(uvMin.x, uvMin.y));
			vertexHelper.AddVert(new Vector3(posMin.x, posMax.y, 0f), color, new Vector2(uvMin.x, uvMax.y));
			vertexHelper.AddVert(new Vector3(posMax.x, posMax.y, 0f), color, new Vector2(uvMax.x, uvMax.y));
			vertexHelper.AddVert(new Vector3(posMax.x, posMin.y, 0f), color, new Vector2(uvMax.x, uvMin.y));
			vertexHelper.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
			vertexHelper.AddTriangle(currentVertCount + 2, currentVertCount + 3, currentVertCount);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003042 File Offset: 0x00001242
		protected static void cacheTypeInfo()
		{
			if (BlurredBackgroundImage._typeInfoCached)
			{
				return;
			}
			BlurredBackgroundImage._typeInfoCached = true;
			System.Type typeFromHandle = typeof(VertexHelper);
			BlurredBackgroundImage._uvField = typeFromHandle.GetField("m_Uv0S", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			BlurredBackgroundImage._vertexField = typeFromHandle.GetField("m_Positions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003080 File Offset: 0x00001280
		protected void updateUVs(VertexHelper vh)
		{
			BlurredBackgroundImage.cacheTypeInfo();
			if (BlurredBackgroundImage._uvField == null || BlurredBackgroundImage._vertexField == null)
			{
				return;
			}
			List<Vector3> list = BlurredBackgroundImage._vertexField.GetValue(vh) as List<Vector3>;
			List<Vector4> list2 = BlurredBackgroundImage._uvField.GetValue(vh) as List<Vector4>;
			if (list == null || list2 == null || list.Count != list2.Count)
			{
				return;
			}
			Camera gameViewCamera = RenderUtils.GetGameViewCamera(this);
			if (gameViewCamera == null)
			{
				return;
			}
			for (int i = 0; i < list2.Count; i++)
			{
				list2[i] = this.calculateFrontProjectedUV(list[i], gameViewCamera);
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000311C File Offset: 0x0000131C
		protected Vector4 calculateFrontProjectedUV(Vector3 vertexPos, Camera cam)
		{
			Vector4 vector = this.getWorldPosition(vertexPos);
			if (this.GetRenderMode() != RenderMode.ScreenSpaceOverlay)
			{
				vector = cam.WorldToScreenPoint(vector);
			}
			vector.x /= (float)cam.pixelWidth;
			vector.y /= (float)cam.pixelHeight;
			vector *= this.FOVScale;
			vector.x -= (this.FOVScale.x - 1f) * 0.5f;
			vector.y -= (this.FOVScale.y - 1f) * 0.5f;
			return vector;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000031CC File Offset: 0x000013CC
		protected Vector4 getWorldPosition(Vector3 localPos)
		{
			return base.transform.localToWorldMatrix.MultiplyPoint(localPos);
		}

		// Token: 0x04000026 RID: 38
		[Header("Blur")]
		[HelpBox("NOTICE: The settings below are global. They will affect all blurred images.\nThe most recently activated image will take precedence.", HelpBoxMessageType.Info)]
		[SerializeField]
		[Range(0f, 300f)]
		protected float _strength = 20f;

		// Token: 0x04000027 RID: 39
		[SerializeField]
		[Tooltip("If high blur strengths are used then you may notice visible artefacts. To avoid these increase the\n\nquality. NOTICE: The higher the quality the more performance it will cost. As a rule of thumb\n\n(low = a performance cost of 1, medium = a cost of 3, high = a cost of 10).")]
		protected ShaderQuality _quality;

		// Token: 0x04000028 RID: 40
		[SerializeField]
		[Tooltip("Reducing the resolution is a great way to increase the blurryness of your image while also saving a LOT of performance.\n\nHalfing the resolution usually makes the blur 4 times faster.")]
		protected SquareResolution _resolution = SquareResolution._512;

		// Token: 0x04000029 RID: 41
		[SerializeField]
		[Range(1f, 10f)]
		[Tooltip("Blur iterations should be kept at 1. This defines how often the blur filter will be applied.\n\nIn terms of performance this the most expensive setting you can increase. Use with care (avoid if you can).")]
		protected int _iterations = 1;

		// Token: 0x0400002A RID: 42
		[SerializeField]
		protected Color _additiveColor = new Color(0f, 0f, 0f, 0f);

		// Token: 0x0400002B RID: 43
		[SerializeField]
		protected Vector2 _FOVScale = new Vector2(1f, 1f);

		// Token: 0x0400002C RID: 44
		[Tooltip("If set then the blur renderer will use this camera´s output instead of auto-detecting the current camera.")]
		public Camera CameraOverride;

		// Token: 0x0400002D RID: 45
		[NonSerialized]
		protected Matrix4x4 _lastWorldToLocalMatrix = Matrix4x4.identity;

		// Token: 0x0400002E RID: 46
		[NonSerialized]
		protected Matrix4x4 _lastWorldToCameraMatrix = Matrix4x4.identity;

		// Token: 0x0400002F RID: 47
		[Header("Mesh")]
		public bool UseCustomMesh;

		// Token: 0x04000030 RID: 48
		[Range(1f, 32f)]
		public int CustomMeshDivisions = 16;

		// Token: 0x04000031 RID: 49
		protected static bool _typeInfoCached;

		// Token: 0x04000032 RID: 50
		protected static FieldInfo _uvField;

		// Token: 0x04000033 RID: 51
		protected static FieldInfo _vertexField;
	}
}
