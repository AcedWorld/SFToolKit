using System;
using System.Collections.Generic;

namespace UnityEngine.UI
{
	// Token: 0x0200003A RID: 58
	[RequireComponent(typeof(CanvasRenderer))]
	[AddComponentMenu("UI/Legacy/Text", 100)]
	public class Text : MaskableGraphic, ILayoutElement
	{
		// Token: 0x0600043E RID: 1086 RVA: 0x00014FD2 File Offset: 0x000131D2
		protected Text()
		{
			base.useLegacyMeshGeneration = false;
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x00015004 File Offset: 0x00013204
		public TextGenerator cachedTextGenerator
		{
			get
			{
				TextGenerator result;
				if ((result = this.m_TextCache) == null)
				{
					result = (this.m_TextCache = ((this.m_Text.Length != 0) ? new TextGenerator(this.m_Text.Length) : new TextGenerator()));
				}
				return result;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x00015048 File Offset: 0x00013248
		public TextGenerator cachedTextGeneratorForLayout
		{
			get
			{
				TextGenerator result;
				if ((result = this.m_TextCacheForLayout) == null)
				{
					result = (this.m_TextCacheForLayout = new TextGenerator());
				}
				return result;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x00015070 File Offset: 0x00013270
		public override Texture mainTexture
		{
			get
			{
				if (this.font != null && this.font.material != null && this.font.material.mainTexture != null)
				{
					return this.font.material.mainTexture;
				}
				if (this.m_Material != null)
				{
					return this.m_Material.mainTexture;
				}
				return base.mainTexture;
			}
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x000150E8 File Offset: 0x000132E8
		public void FontTextureChanged()
		{
			if (!this)
			{
				return;
			}
			if (this.m_DisableFontTextureRebuiltCallback)
			{
				return;
			}
			this.cachedTextGenerator.Invalidate();
			if (!this.IsActive())
			{
				return;
			}
			if (CanvasUpdateRegistry.IsRebuildingGraphics() || CanvasUpdateRegistry.IsRebuildingLayout())
			{
				this.UpdateGeometry();
				return;
			}
			this.SetAllDirty();
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x00015136 File Offset: 0x00013336
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x00015144 File Offset: 0x00013344
		public Font font
		{
			get
			{
				return this.m_FontData.font;
			}
			set
			{
				if (this.m_FontData.font == value)
				{
					return;
				}
				if (base.isActiveAndEnabled)
				{
					FontUpdateTracker.UntrackText(this);
				}
				this.m_FontData.font = value;
				if (base.isActiveAndEnabled)
				{
					FontUpdateTracker.TrackText(this);
				}
				this.SetAllDirty();
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x00015193 File Offset: 0x00013393
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x0001519C File Offset: 0x0001339C
		public virtual string text
		{
			get
			{
				return this.m_Text;
			}
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					if (this.m_Text != value)
					{
						this.m_Text = value;
						this.SetVerticesDirty();
						this.SetLayoutDirty();
					}
					return;
				}
				if (string.IsNullOrEmpty(this.m_Text))
				{
					return;
				}
				this.m_Text = "";
				this.SetVerticesDirty();
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x000151F2 File Offset: 0x000133F2
		// (set) Token: 0x06000448 RID: 1096 RVA: 0x000151FF File Offset: 0x000133FF
		public bool supportRichText
		{
			get
			{
				return this.m_FontData.richText;
			}
			set
			{
				if (this.m_FontData.richText == value)
				{
					return;
				}
				this.m_FontData.richText = value;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x00015228 File Offset: 0x00013428
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x00015235 File Offset: 0x00013435
		public bool resizeTextForBestFit
		{
			get
			{
				return this.m_FontData.bestFit;
			}
			set
			{
				if (this.m_FontData.bestFit == value)
				{
					return;
				}
				this.m_FontData.bestFit = value;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x0001525E File Offset: 0x0001345E
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x0001526B File Offset: 0x0001346B
		public int resizeTextMinSize
		{
			get
			{
				return this.m_FontData.minSize;
			}
			set
			{
				if (this.m_FontData.minSize == value)
				{
					return;
				}
				this.m_FontData.minSize = value;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x00015294 File Offset: 0x00013494
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x000152A1 File Offset: 0x000134A1
		public int resizeTextMaxSize
		{
			get
			{
				return this.m_FontData.maxSize;
			}
			set
			{
				if (this.m_FontData.maxSize == value)
				{
					return;
				}
				this.m_FontData.maxSize = value;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x000152CA File Offset: 0x000134CA
		// (set) Token: 0x06000450 RID: 1104 RVA: 0x000152D7 File Offset: 0x000134D7
		public TextAnchor alignment
		{
			get
			{
				return this.m_FontData.alignment;
			}
			set
			{
				if (this.m_FontData.alignment == value)
				{
					return;
				}
				this.m_FontData.alignment = value;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x00015300 File Offset: 0x00013500
		// (set) Token: 0x06000452 RID: 1106 RVA: 0x0001530D File Offset: 0x0001350D
		public bool alignByGeometry
		{
			get
			{
				return this.m_FontData.alignByGeometry;
			}
			set
			{
				if (this.m_FontData.alignByGeometry == value)
				{
					return;
				}
				this.m_FontData.alignByGeometry = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x00015330 File Offset: 0x00013530
		// (set) Token: 0x06000454 RID: 1108 RVA: 0x0001533D File Offset: 0x0001353D
		public int fontSize
		{
			get
			{
				return this.m_FontData.fontSize;
			}
			set
			{
				if (this.m_FontData.fontSize == value)
				{
					return;
				}
				this.m_FontData.fontSize = value;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x00015366 File Offset: 0x00013566
		// (set) Token: 0x06000456 RID: 1110 RVA: 0x00015373 File Offset: 0x00013573
		public HorizontalWrapMode horizontalOverflow
		{
			get
			{
				return this.m_FontData.horizontalOverflow;
			}
			set
			{
				if (this.m_FontData.horizontalOverflow == value)
				{
					return;
				}
				this.m_FontData.horizontalOverflow = value;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x0001539C File Offset: 0x0001359C
		// (set) Token: 0x06000458 RID: 1112 RVA: 0x000153A9 File Offset: 0x000135A9
		public VerticalWrapMode verticalOverflow
		{
			get
			{
				return this.m_FontData.verticalOverflow;
			}
			set
			{
				if (this.m_FontData.verticalOverflow == value)
				{
					return;
				}
				this.m_FontData.verticalOverflow = value;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x000153D2 File Offset: 0x000135D2
		// (set) Token: 0x0600045A RID: 1114 RVA: 0x000153DF File Offset: 0x000135DF
		public float lineSpacing
		{
			get
			{
				return this.m_FontData.lineSpacing;
			}
			set
			{
				if (this.m_FontData.lineSpacing == value)
				{
					return;
				}
				this.m_FontData.lineSpacing = value;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x00015408 File Offset: 0x00013608
		// (set) Token: 0x0600045C RID: 1116 RVA: 0x00015415 File Offset: 0x00013615
		public FontStyle fontStyle
		{
			get
			{
				return this.m_FontData.fontStyle;
			}
			set
			{
				if (this.m_FontData.fontStyle == value)
				{
					return;
				}
				this.m_FontData.fontStyle = value;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600045D RID: 1117 RVA: 0x00015440 File Offset: 0x00013640
		public float pixelsPerUnit
		{
			get
			{
				Canvas canvas = base.canvas;
				if (!canvas)
				{
					return 1f;
				}
				if (!this.font || this.font.dynamic)
				{
					return canvas.scaleFactor;
				}
				if (this.m_FontData.fontSize <= 0 || this.font.fontSize <= 0)
				{
					return 1f;
				}
				return (float)this.font.fontSize / (float)this.m_FontData.fontSize;
			}
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x000154BE File Offset: 0x000136BE
		protected override void OnEnable()
		{
			base.OnEnable();
			this.cachedTextGenerator.Invalidate();
			FontUpdateTracker.TrackText(this);
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x000154D7 File Offset: 0x000136D7
		protected override void OnDisable()
		{
			FontUpdateTracker.UntrackText(this);
			base.OnDisable();
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x000154E5 File Offset: 0x000136E5
		protected override void UpdateGeometry()
		{
			if (this.font != null)
			{
				base.UpdateGeometry();
			}
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x000154FB File Offset: 0x000136FB
		internal void AssignDefaultFont()
		{
			this.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0001550D File Offset: 0x0001370D
		internal void AssignDefaultFontIfNecessary()
		{
			if (this.font == null)
			{
				this.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
			}
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00015530 File Offset: 0x00013730
		public TextGenerationSettings GetGenerationSettings(Vector2 extents)
		{
			TextGenerationSettings result = default(TextGenerationSettings);
			result.generationExtents = extents;
			if (this.font != null && this.font.dynamic)
			{
				result.fontSize = this.m_FontData.fontSize;
				result.resizeTextMinSize = this.m_FontData.minSize;
				result.resizeTextMaxSize = this.m_FontData.maxSize;
			}
			result.textAnchor = this.m_FontData.alignment;
			result.alignByGeometry = this.m_FontData.alignByGeometry;
			result.scaleFactor = this.pixelsPerUnit;
			result.color = this.color;
			result.font = this.font;
			result.pivot = base.rectTransform.pivot;
			result.richText = this.m_FontData.richText;
			result.lineSpacing = this.m_FontData.lineSpacing;
			result.fontStyle = this.m_FontData.fontStyle;
			result.resizeTextForBestFit = this.m_FontData.bestFit;
			result.updateBounds = false;
			result.horizontalOverflow = this.m_FontData.horizontalOverflow;
			result.verticalOverflow = this.m_FontData.verticalOverflow;
			return result;
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00015670 File Offset: 0x00013870
		public static Vector2 GetTextAnchorPivot(TextAnchor anchor)
		{
			switch (anchor)
			{
			case TextAnchor.UpperLeft:
				return new Vector2(0f, 1f);
			case TextAnchor.UpperCenter:
				return new Vector2(0.5f, 1f);
			case TextAnchor.UpperRight:
				return new Vector2(1f, 1f);
			case TextAnchor.MiddleLeft:
				return new Vector2(0f, 0.5f);
			case TextAnchor.MiddleCenter:
				return new Vector2(0.5f, 0.5f);
			case TextAnchor.MiddleRight:
				return new Vector2(1f, 0.5f);
			case TextAnchor.LowerLeft:
				return new Vector2(0f, 0f);
			case TextAnchor.LowerCenter:
				return new Vector2(0.5f, 0f);
			case TextAnchor.LowerRight:
				return new Vector2(1f, 0f);
			default:
				return Vector2.zero;
			}
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00015744 File Offset: 0x00013944
		protected override void OnPopulateMesh(VertexHelper toFill)
		{
			if (this.font == null)
			{
				return;
			}
			this.m_DisableFontTextureRebuiltCallback = true;
			Vector2 size = base.rectTransform.rect.size;
			TextGenerationSettings generationSettings = this.GetGenerationSettings(size);
			this.cachedTextGenerator.PopulateWithErrors(this.text, generationSettings, base.gameObject);
			IList<UIVertex> verts = this.cachedTextGenerator.verts;
			float d = 1f / this.pixelsPerUnit;
			int count = verts.Count;
			if (count <= 0)
			{
				toFill.Clear();
				return;
			}
			Vector2 vector = new Vector2(verts[0].position.x, verts[0].position.y) * d;
			vector = base.PixelAdjustPoint(vector) - vector;
			toFill.Clear();
			if (vector != Vector2.zero)
			{
				for (int i = 0; i < count; i++)
				{
					int num = i & 3;
					this.m_TempVerts[num] = verts[i];
					UIVertex[] tempVerts = this.m_TempVerts;
					int num2 = num;
					tempVerts[num2].position = tempVerts[num2].position * d;
					UIVertex[] tempVerts2 = this.m_TempVerts;
					int num3 = num;
					tempVerts2[num3].position.x = tempVerts2[num3].position.x + vector.x;
					UIVertex[] tempVerts3 = this.m_TempVerts;
					int num4 = num;
					tempVerts3[num4].position.y = tempVerts3[num4].position.y + vector.y;
					if (num == 3)
					{
						toFill.AddUIVertexQuad(this.m_TempVerts);
					}
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					int num5 = j & 3;
					this.m_TempVerts[num5] = verts[j];
					UIVertex[] tempVerts4 = this.m_TempVerts;
					int num6 = num5;
					tempVerts4[num6].position = tempVerts4[num6].position * d;
					if (num5 == 3)
					{
						toFill.AddUIVertexQuad(this.m_TempVerts);
					}
				}
			}
			this.m_DisableFontTextureRebuiltCallback = false;
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x00015934 File Offset: 0x00013B34
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00015936 File Offset: 0x00013B36
		public virtual void CalculateLayoutInputVertical()
		{
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000468 RID: 1128 RVA: 0x00015938 File Offset: 0x00013B38
		public virtual float minWidth
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x00015940 File Offset: 0x00013B40
		public virtual float preferredWidth
		{
			get
			{
				TextGenerationSettings generationSettings = this.GetGenerationSettings(Vector2.zero);
				return this.cachedTextGeneratorForLayout.GetPreferredWidth(this.m_Text, generationSettings) / this.pixelsPerUnit;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x0600046A RID: 1130 RVA: 0x00015972 File Offset: 0x00013B72
		public virtual float flexibleWidth
		{
			get
			{
				return -1f;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x00015979 File Offset: 0x00013B79
		public virtual float minHeight
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x00015980 File Offset: 0x00013B80
		public virtual float preferredHeight
		{
			get
			{
				TextGenerationSettings generationSettings = this.GetGenerationSettings(new Vector2(base.GetPixelAdjustedRect().size.x, 0f));
				return this.cachedTextGeneratorForLayout.GetPreferredHeight(this.m_Text, generationSettings) / this.pixelsPerUnit;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600046D RID: 1133 RVA: 0x000159CA File Offset: 0x00013BCA
		public virtual float flexibleHeight
		{
			get
			{
				return -1f;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x000159D1 File Offset: 0x00013BD1
		public virtual int layoutPriority
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0400016F RID: 367
		[SerializeField]
		private FontData m_FontData = FontData.defaultFontData;

		// Token: 0x04000170 RID: 368
		[TextArea(3, 10)]
		[SerializeField]
		protected string m_Text = string.Empty;

		// Token: 0x04000171 RID: 369
		private TextGenerator m_TextCache;

		// Token: 0x04000172 RID: 370
		private TextGenerator m_TextCacheForLayout;

		// Token: 0x04000173 RID: 371
		protected static Material s_DefaultText;

		// Token: 0x04000174 RID: 372
		[NonSerialized]
		protected bool m_DisableFontTextureRebuiltCallback;

		// Token: 0x04000175 RID: 373
		private readonly UIVertex[] m_TempVerts = new UIVertex[4];
	}
}
