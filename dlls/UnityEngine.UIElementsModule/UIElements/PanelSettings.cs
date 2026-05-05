using System;
using UnityEngine.UIElements.UIR;

namespace UnityEngine.UIElements
{
	// Token: 0x02000250 RID: 592
	[HelpURL("UIE-Runtime-Panel-Settings")]
	public class PanelSettings : ScriptableObject
	{
		// Token: 0x17000388 RID: 904
		// (get) Token: 0x060010D2 RID: 4306 RVA: 0x0003CECC File Offset: 0x0003B0CC
		// (set) Token: 0x060010D3 RID: 4307 RVA: 0x0003CEE4 File Offset: 0x0003B0E4
		public ThemeStyleSheet themeStyleSheet
		{
			get
			{
				return this.themeUss;
			}
			set
			{
				this.themeUss = value;
				this.ApplyThemeStyleSheet(null);
			}
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x060010D4 RID: 4308 RVA: 0x0003CEF6 File Offset: 0x0003B0F6
		// (set) Token: 0x060010D5 RID: 4309 RVA: 0x0003CEFE File Offset: 0x0003B0FE
		public RenderTexture targetTexture
		{
			get
			{
				return this.m_TargetTexture;
			}
			set
			{
				this.m_TargetTexture = value;
				this.m_PanelAccess.SetTargetTexture();
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x060010D6 RID: 4310 RVA: 0x0003CF14 File Offset: 0x0003B114
		// (set) Token: 0x060010D7 RID: 4311 RVA: 0x0003CF1C File Offset: 0x0003B11C
		public PanelScaleMode scaleMode
		{
			get
			{
				return this.m_ScaleMode;
			}
			set
			{
				this.m_ScaleMode = value;
			}
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x060010D8 RID: 4312 RVA: 0x0003CF28 File Offset: 0x0003B128
		// (set) Token: 0x060010D9 RID: 4313 RVA: 0x0003CF40 File Offset: 0x0003B140
		public float referenceSpritePixelsPerUnit
		{
			get
			{
				return this.m_ReferenceSpritePixelsPerUnit;
			}
			set
			{
				this.m_ReferenceSpritePixelsPerUnit = value;
			}
		}

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x060010DA RID: 4314 RVA: 0x0003CF4A File Offset: 0x0003B14A
		// (set) Token: 0x060010DB RID: 4315 RVA: 0x0003CF52 File Offset: 0x0003B152
		public float scale
		{
			get
			{
				return this.m_Scale;
			}
			set
			{
				this.m_Scale = value;
			}
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x060010DC RID: 4316 RVA: 0x0003CF5B File Offset: 0x0003B15B
		// (set) Token: 0x060010DD RID: 4317 RVA: 0x0003CF63 File Offset: 0x0003B163
		public float referenceDpi
		{
			get
			{
				return this.m_ReferenceDpi;
			}
			set
			{
				this.m_ReferenceDpi = ((value >= 1f) ? value : 96f);
			}
		}

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x060010DE RID: 4318 RVA: 0x0003CF7B File Offset: 0x0003B17B
		// (set) Token: 0x060010DF RID: 4319 RVA: 0x0003CF83 File Offset: 0x0003B183
		public float fallbackDpi
		{
			get
			{
				return this.m_FallbackDpi;
			}
			set
			{
				this.m_FallbackDpi = ((value >= 1f) ? value : 96f);
			}
		}

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x060010E0 RID: 4320 RVA: 0x0003CF9B File Offset: 0x0003B19B
		// (set) Token: 0x060010E1 RID: 4321 RVA: 0x0003CFA3 File Offset: 0x0003B1A3
		public Vector2Int referenceResolution
		{
			get
			{
				return this.m_ReferenceResolution;
			}
			set
			{
				this.m_ReferenceResolution = value;
			}
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x060010E2 RID: 4322 RVA: 0x0003CFAC File Offset: 0x0003B1AC
		// (set) Token: 0x060010E3 RID: 4323 RVA: 0x0003CFB4 File Offset: 0x0003B1B4
		public PanelScreenMatchMode screenMatchMode
		{
			get
			{
				return this.m_ScreenMatchMode;
			}
			set
			{
				this.m_ScreenMatchMode = value;
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x060010E4 RID: 4324 RVA: 0x0003CFBD File Offset: 0x0003B1BD
		// (set) Token: 0x060010E5 RID: 4325 RVA: 0x0003CFC5 File Offset: 0x0003B1C5
		public float match
		{
			get
			{
				return this.m_Match;
			}
			set
			{
				this.m_Match = value;
			}
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x060010E6 RID: 4326 RVA: 0x0003CFCE File Offset: 0x0003B1CE
		// (set) Token: 0x060010E7 RID: 4327 RVA: 0x0003CFD6 File Offset: 0x0003B1D6
		public float sortingOrder
		{
			get
			{
				return this.m_SortingOrder;
			}
			set
			{
				this.m_SortingOrder = value;
				this.ApplySortingOrder();
			}
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x0003CFE7 File Offset: 0x0003B1E7
		internal void ApplySortingOrder()
		{
			this.m_PanelAccess.SetSortingPriority();
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x060010E9 RID: 4329 RVA: 0x0003CFF6 File Offset: 0x0003B1F6
		// (set) Token: 0x060010EA RID: 4330 RVA: 0x0003CFFE File Offset: 0x0003B1FE
		public int targetDisplay
		{
			get
			{
				return this.m_TargetDisplay;
			}
			set
			{
				this.m_TargetDisplay = value;
				this.m_PanelAccess.SetTargetDisplay();
			}
		}

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x060010EB RID: 4331 RVA: 0x0003D014 File Offset: 0x0003B214
		// (set) Token: 0x060010EC RID: 4332 RVA: 0x0003D01C File Offset: 0x0003B21C
		public bool clearDepthStencil
		{
			get
			{
				return this.m_ClearDepthStencil;
			}
			set
			{
				this.m_ClearDepthStencil = value;
			}
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x060010ED RID: 4333 RVA: 0x0003D025 File Offset: 0x0003B225
		public float depthClearValue
		{
			get
			{
				return 0.99f;
			}
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x060010EE RID: 4334 RVA: 0x0003D02C File Offset: 0x0003B22C
		// (set) Token: 0x060010EF RID: 4335 RVA: 0x0003D034 File Offset: 0x0003B234
		public bool clearColor
		{
			get
			{
				return this.m_ClearColor;
			}
			set
			{
				this.m_ClearColor = value;
			}
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x060010F0 RID: 4336 RVA: 0x0003D03D File Offset: 0x0003B23D
		// (set) Token: 0x060010F1 RID: 4337 RVA: 0x0003D045 File Offset: 0x0003B245
		public Color colorClearValue
		{
			get
			{
				return this.m_ColorClearValue;
			}
			set
			{
				this.m_ColorClearValue = value;
			}
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x060010F2 RID: 4338 RVA: 0x0003D04E File Offset: 0x0003B24E
		internal BaseRuntimePanel panel
		{
			get
			{
				return this.m_PanelAccess.panel;
			}
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x060010F3 RID: 4339 RVA: 0x0003D05B File Offset: 0x0003B25B
		internal bool isInitialized
		{
			get
			{
				PanelSettings.RuntimePanelAccess panelAccess = this.m_PanelAccess;
				return panelAccess != null && panelAccess.isInitialized;
			}
		}

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x060010F4 RID: 4340 RVA: 0x0003D06F File Offset: 0x0003B26F
		internal VisualElement visualTree
		{
			get
			{
				return this.m_PanelAccess.panel.visualTree;
			}
		}

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x060010F5 RID: 4341 RVA: 0x0003D081 File Offset: 0x0003B281
		// (set) Token: 0x060010F6 RID: 4342 RVA: 0x0003D089 File Offset: 0x0003B289
		public DynamicAtlasSettings dynamicAtlasSettings
		{
			get
			{
				return this.m_DynamicAtlasSettings;
			}
			set
			{
				this.m_DynamicAtlasSettings = value;
			}
		}

		// Token: 0x060010F7 RID: 4343 RVA: 0x0003D094 File Offset: 0x0003B294
		private PanelSettings()
		{
			this.m_PanelAccess = new PanelSettings.RuntimePanelAccess(this);
		}

		// Token: 0x060010F8 RID: 4344 RVA: 0x00003CD2 File Offset: 0x00001ED2
		private void Reset()
		{
		}

		// Token: 0x060010F9 RID: 4345 RVA: 0x0003D140 File Offset: 0x0003B340
		private void OnEnable()
		{
			bool flag = this.themeUss == null;
			if (flag)
			{
				Debug.LogWarning("No Theme Style Sheet set to PanelSettings " + base.name + ", UI will not render properly", this);
			}
			this.UpdateScreenDPI();
			this.InitializeShaders();
		}

		// Token: 0x060010FA RID: 4346 RVA: 0x0003D18C File Offset: 0x0003B38C
		private void OnDisable()
		{
			this.m_PanelAccess.DisposePanel();
		}

		// Token: 0x060010FB RID: 4347 RVA: 0x0003D18C File Offset: 0x0003B38C
		internal void DisposePanel()
		{
			this.m_PanelAccess.DisposePanel();
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x060010FC RID: 4348 RVA: 0x0003D19B File Offset: 0x0003B39B
		// (set) Token: 0x060010FD RID: 4349 RVA: 0x0003D1A3 File Offset: 0x0003B3A3
		private float ScreenDPI { get; set; }

		// Token: 0x060010FE RID: 4350 RVA: 0x0003D1AC File Offset: 0x0003B3AC
		internal void UpdateScreenDPI()
		{
			this.ScreenDPI = Screen.dpi;
		}

		// Token: 0x060010FF RID: 4351 RVA: 0x0003D1BC File Offset: 0x0003B3BC
		private void ApplyThemeStyleSheet(VisualElement root = null)
		{
			bool flag = !this.m_PanelAccess.isInitialized;
			if (!flag)
			{
				bool flag2 = root == null;
				if (flag2)
				{
					root = this.visualTree;
				}
				bool flag3 = this.m_OldThemeUss != this.themeUss && this.m_OldThemeUss != null;
				if (flag3)
				{
					if (root != null)
					{
						root.styleSheets.Remove(this.m_OldThemeUss);
					}
				}
				bool flag4 = this.themeUss != null;
				if (flag4)
				{
					this.themeUss.isDefaultStyleSheet = true;
					if (root != null)
					{
						root.styleSheets.Add(this.themeUss);
					}
				}
				this.m_OldThemeUss = this.themeUss;
			}
		}

		// Token: 0x06001100 RID: 4352 RVA: 0x0003D280 File Offset: 0x0003B480
		private void InitializeShaders()
		{
			bool flag = this.m_AtlasBlitShader == null;
			if (flag)
			{
				this.m_AtlasBlitShader = Shader.Find(Shaders.k_AtlasBlit);
			}
			bool flag2 = this.m_RuntimeShader == null;
			if (flag2)
			{
				this.m_RuntimeShader = Shader.Find(Shaders.k_Runtime);
			}
			bool flag3 = this.m_RuntimeWorldShader == null;
			if (flag3)
			{
				this.m_RuntimeWorldShader = Shader.Find(Shaders.k_RuntimeWorld);
			}
			this.m_PanelAccess.SetTargetTexture();
		}

		// Token: 0x06001101 RID: 4353 RVA: 0x0003D300 File Offset: 0x0003B500
		internal void ApplyPanelSettings()
		{
			Rect targetRect = this.m_TargetRect;
			float resolvedScale = this.m_ResolvedScale;
			this.UpdateScreenDPI();
			this.m_TargetRect = this.GetDisplayRect();
			this.m_ResolvedScale = this.ResolveScale(this.m_TargetRect, this.ScreenDPI);
			bool flag = this.visualTree.style.width.value == 0f || this.m_ResolvedScale != resolvedScale || this.m_TargetRect.width != targetRect.width || this.m_TargetRect.height != targetRect.height;
			if (flag)
			{
				this.panel.scale = ((this.m_ResolvedScale == 0f) ? 0f : (1f / this.m_ResolvedScale));
				this.visualTree.style.left = 0f;
				this.visualTree.style.top = 0f;
				this.visualTree.style.width = this.m_TargetRect.width * this.m_ResolvedScale;
				this.visualTree.style.height = this.m_TargetRect.height * this.m_ResolvedScale;
			}
			this.panel.targetTexture = this.targetTexture;
			this.panel.targetDisplay = this.targetDisplay;
			this.panel.drawToCameras = false;
			this.panel.clearSettings = new PanelClearSettings
			{
				clearColor = this.m_ClearColor,
				clearDepthStencil = this.m_ClearDepthStencil,
				color = this.m_ColorClearValue
			};
			this.panel.referenceSpritePixelsPerUnit = this.referenceSpritePixelsPerUnit;
			DynamicAtlas dynamicAtlas = this.panel.atlas as DynamicAtlas;
			bool flag2 = dynamicAtlas != null;
			if (flag2)
			{
				dynamicAtlas.minAtlasSize = this.dynamicAtlasSettings.minAtlasSize;
				dynamicAtlas.maxAtlasSize = this.dynamicAtlasSettings.maxAtlasSize;
				dynamicAtlas.maxSubTextureSize = this.dynamicAtlasSettings.maxSubTextureSize;
				dynamicAtlas.activeFilters = this.dynamicAtlasSettings.activeFilters;
				dynamicAtlas.customFilter = this.dynamicAtlasSettings.customFilter;
			}
		}

		// Token: 0x06001102 RID: 4354 RVA: 0x0003D559 File Offset: 0x0003B759
		public void SetScreenToPanelSpaceFunction(Func<Vector2, Vector2> screentoPanelSpaceFunction)
		{
			this.m_AssignedScreenToPanel = screentoPanelSpaceFunction;
			this.panel.screenToPanelSpace = this.m_AssignedScreenToPanel;
		}

		// Token: 0x06001103 RID: 4355 RVA: 0x0003D578 File Offset: 0x0003B778
		internal float ResolveScale(Rect targetRect, float screenDpi)
		{
			float num = 1f;
			switch (this.scaleMode)
			{
			case PanelScaleMode.ConstantPhysicalSize:
			{
				float num2 = (screenDpi == 0f) ? this.fallbackDpi : screenDpi;
				bool flag = num2 != 0f;
				if (flag)
				{
					num = this.referenceDpi / num2;
				}
				break;
			}
			case PanelScaleMode.ScaleWithScreenSize:
			{
				bool flag2 = this.referenceResolution.x * this.referenceResolution.y != 0;
				if (flag2)
				{
					Vector2 vector = this.referenceResolution;
					Vector2 vector2 = new Vector2(targetRect.width / vector.x, targetRect.height / vector.y);
					PanelScreenMatchMode screenMatchMode = this.screenMatchMode;
					PanelScreenMatchMode panelScreenMatchMode = screenMatchMode;
					float num3;
					if (panelScreenMatchMode != PanelScreenMatchMode.Shrink)
					{
						if (panelScreenMatchMode != PanelScreenMatchMode.Expand)
						{
							float t = Mathf.Clamp01(this.match);
							num3 = Mathf.Lerp(vector2.x, vector2.y, t);
						}
						else
						{
							num3 = Mathf.Min(vector2.x, vector2.y);
						}
					}
					else
					{
						num3 = Mathf.Max(vector2.x, vector2.y);
					}
					bool flag3 = num3 != 0f;
					if (flag3)
					{
						num = 1f / num3;
					}
				}
				break;
			}
			}
			bool flag4 = this.scale > 0f;
			if (flag4)
			{
				num /= this.scale;
			}
			else
			{
				num = 0f;
			}
			return num;
		}

		// Token: 0x06001104 RID: 4356 RVA: 0x0003D704 File Offset: 0x0003B904
		internal Rect GetDisplayRect()
		{
			bool flag = this.m_TargetTexture != null;
			Rect result;
			if (flag)
			{
				result = new Rect(0f, 0f, (float)this.m_TargetTexture.width, (float)this.m_TargetTexture.height);
			}
			else
			{
				result = new Rect(0f, 0f, (float)BaseRuntimePanel.getScreenRenderingWidth(this.targetDisplay), (float)BaseRuntimePanel.getScreenRenderingHeight(this.targetDisplay));
			}
			return result;
		}

		// Token: 0x06001105 RID: 4357 RVA: 0x0003D778 File Offset: 0x0003B978
		internal void AttachAndInsertUIDocumentToVisualTree(UIDocument uiDocument)
		{
			bool flag = this.m_AttachedUIDocumentsList == null;
			if (flag)
			{
				this.m_AttachedUIDocumentsList = new UIDocumentList();
			}
			else
			{
				this.m_AttachedUIDocumentsList.RemoveFromListAndFromVisualTree(uiDocument);
			}
			this.m_AttachedUIDocumentsList.AddToListAndToVisualTree(uiDocument, this.visualTree, 0);
		}

		// Token: 0x06001106 RID: 4358 RVA: 0x0003D7C8 File Offset: 0x0003B9C8
		internal void DetachUIDocument(UIDocument uiDocument)
		{
			bool flag = this.m_AttachedUIDocumentsList == null;
			if (!flag)
			{
				this.m_AttachedUIDocumentsList.RemoveFromListAndFromVisualTree(uiDocument);
				bool flag2 = this.m_AttachedUIDocumentsList.m_AttachedUIDocuments.Count == 0;
				if (flag2)
				{
					this.m_PanelAccess.MarkPotentiallyEmpty();
				}
			}
		}

		// Token: 0x0400076A RID: 1898
		private const int k_DefaultSortingOrder = 0;

		// Token: 0x0400076B RID: 1899
		private const float k_DefaultScaleValue = 1f;

		// Token: 0x0400076C RID: 1900
		internal const string k_DefaultStyleSheetPath = "Packages/com.unity.ui/PackageResources/StyleSheets/Generated/Default.tss.asset";

		// Token: 0x0400076D RID: 1901
		[SerializeField]
		private ThemeStyleSheet themeUss;

		// Token: 0x0400076E RID: 1902
		[SerializeField]
		private RenderTexture m_TargetTexture;

		// Token: 0x0400076F RID: 1903
		[SerializeField]
		private PanelScaleMode m_ScaleMode = PanelScaleMode.ConstantPhysicalSize;

		// Token: 0x04000770 RID: 1904
		[SerializeField]
		private float m_ReferenceSpritePixelsPerUnit = 100f;

		// Token: 0x04000771 RID: 1905
		[SerializeField]
		private float m_Scale = 1f;

		// Token: 0x04000772 RID: 1906
		private const float DefaultDpi = 96f;

		// Token: 0x04000773 RID: 1907
		[SerializeField]
		private float m_ReferenceDpi = 96f;

		// Token: 0x04000774 RID: 1908
		[SerializeField]
		private float m_FallbackDpi = 96f;

		// Token: 0x04000775 RID: 1909
		[SerializeField]
		private Vector2Int m_ReferenceResolution = new Vector2Int(1200, 800);

		// Token: 0x04000776 RID: 1910
		[SerializeField]
		private PanelScreenMatchMode m_ScreenMatchMode = PanelScreenMatchMode.MatchWidthOrHeight;

		// Token: 0x04000777 RID: 1911
		[Range(0f, 1f)]
		[SerializeField]
		private float m_Match = 0f;

		// Token: 0x04000778 RID: 1912
		[SerializeField]
		private float m_SortingOrder = 0f;

		// Token: 0x04000779 RID: 1913
		[SerializeField]
		private int m_TargetDisplay = 0;

		// Token: 0x0400077A RID: 1914
		[SerializeField]
		private bool m_ClearDepthStencil = true;

		// Token: 0x0400077B RID: 1915
		[SerializeField]
		private bool m_ClearColor;

		// Token: 0x0400077C RID: 1916
		[SerializeField]
		private Color m_ColorClearValue = Color.clear;

		// Token: 0x0400077D RID: 1917
		private PanelSettings.RuntimePanelAccess m_PanelAccess;

		// Token: 0x0400077E RID: 1918
		internal UIDocumentList m_AttachedUIDocumentsList;

		// Token: 0x0400077F RID: 1919
		[HideInInspector]
		[SerializeField]
		private DynamicAtlasSettings m_DynamicAtlasSettings = DynamicAtlasSettings.defaults;

		// Token: 0x04000780 RID: 1920
		[SerializeField]
		[HideInInspector]
		private Shader m_AtlasBlitShader;

		// Token: 0x04000781 RID: 1921
		[HideInInspector]
		[SerializeField]
		private Shader m_RuntimeShader;

		// Token: 0x04000782 RID: 1922
		[HideInInspector]
		[SerializeField]
		private Shader m_RuntimeWorldShader;

		// Token: 0x04000783 RID: 1923
		[SerializeField]
		public PanelTextSettings textSettings;

		// Token: 0x04000784 RID: 1924
		private Rect m_TargetRect;

		// Token: 0x04000785 RID: 1925
		private float m_ResolvedScale;

		// Token: 0x04000786 RID: 1926
		private StyleSheet m_OldThemeUss;

		// Token: 0x04000788 RID: 1928
		private Func<Vector2, Vector2> m_AssignedScreenToPanel;

		// Token: 0x02000251 RID: 593
		private class RuntimePanelAccess
		{
			// Token: 0x06001107 RID: 4359 RVA: 0x0003D816 File Offset: 0x0003BA16
			internal RuntimePanelAccess(PanelSettings settings)
			{
				this.m_Settings = settings;
			}

			// Token: 0x1700039D RID: 925
			// (get) Token: 0x06001108 RID: 4360 RVA: 0x0003D827 File Offset: 0x0003BA27
			internal bool isInitialized
			{
				get
				{
					return this.m_RuntimePanel != null;
				}
			}

			// Token: 0x1700039E RID: 926
			// (get) Token: 0x06001109 RID: 4361 RVA: 0x0003D834 File Offset: 0x0003BA34
			internal BaseRuntimePanel panel
			{
				get
				{
					bool flag = this.m_RuntimePanel == null;
					if (flag)
					{
						this.m_RuntimePanel = this.CreateRelatedRuntimePanel();
						this.m_RuntimePanel.sortingPriority = this.m_Settings.m_SortingOrder;
						this.m_RuntimePanel.targetDisplay = this.m_Settings.m_TargetDisplay;
						VisualElement visualTree = this.m_RuntimePanel.visualTree;
						visualTree.name = this.m_Settings.name;
						this.m_Settings.ApplyThemeStyleSheet(visualTree);
						bool flag2 = this.m_Settings.m_TargetTexture != null;
						if (flag2)
						{
							this.m_RuntimePanel.targetTexture = this.m_Settings.m_TargetTexture;
						}
						bool flag3 = this.m_Settings.m_AssignedScreenToPanel != null;
						if (flag3)
						{
							this.m_Settings.SetScreenToPanelSpaceFunction(this.m_Settings.m_AssignedScreenToPanel);
						}
					}
					return this.m_RuntimePanel;
				}
			}

			// Token: 0x0600110A RID: 4362 RVA: 0x0003D920 File Offset: 0x0003BB20
			internal void DisposePanel()
			{
				bool flag = this.m_RuntimePanel != null;
				if (flag)
				{
					this.DisposeRelatedPanel();
					this.m_RuntimePanel = null;
				}
			}

			// Token: 0x0600110B RID: 4363 RVA: 0x0003D94C File Offset: 0x0003BB4C
			internal void SetTargetTexture()
			{
				bool flag = this.m_RuntimePanel != null;
				if (flag)
				{
					this.m_RuntimePanel.targetTexture = this.m_Settings.targetTexture;
				}
			}

			// Token: 0x0600110C RID: 4364 RVA: 0x0003D980 File Offset: 0x0003BB80
			internal void SetSortingPriority()
			{
				bool flag = this.m_RuntimePanel != null;
				if (flag)
				{
					this.m_RuntimePanel.sortingPriority = this.m_Settings.m_SortingOrder;
				}
			}

			// Token: 0x0600110D RID: 4365 RVA: 0x0003D9B4 File Offset: 0x0003BBB4
			internal void SetTargetDisplay()
			{
				bool flag = this.m_RuntimePanel != null;
				if (flag)
				{
					this.m_RuntimePanel.targetDisplay = this.m_Settings.m_TargetDisplay;
				}
			}

			// Token: 0x0600110E RID: 4366 RVA: 0x0003D9E8 File Offset: 0x0003BBE8
			private BaseRuntimePanel CreateRelatedRuntimePanel()
			{
				return (RuntimePanel)UIElementsRuntimeUtility.FindOrCreateRuntimePanel(this.m_Settings, new UIElementsRuntimeUtility.CreateRuntimePanelDelegate(RuntimePanel.Create));
			}

			// Token: 0x0600110F RID: 4367 RVA: 0x0003DA18 File Offset: 0x0003BC18
			private void DisposeRelatedPanel()
			{
				UIElementsRuntimeUtility.DisposeRuntimePanel(this.m_Settings);
			}

			// Token: 0x06001110 RID: 4368 RVA: 0x0003DA27 File Offset: 0x0003BC27
			internal void MarkPotentiallyEmpty()
			{
				UIElementsRuntimeUtility.MarkPotentiallyEmpty(this.m_Settings);
			}

			// Token: 0x04000789 RID: 1929
			private readonly PanelSettings m_Settings;

			// Token: 0x0400078A RID: 1930
			private BaseRuntimePanel m_RuntimePanel;
		}
	}
}
