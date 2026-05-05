using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200015B RID: 347
	[NativeHeader("Runtime/Misc/PlayerSettings.h")]
	[NativeHeader("Runtime/Graphics/QualitySettings.h")]
	[StaticAccessor("GetQualitySettings()", StaticAccessorType.Dot)]
	public sealed class QualitySettings : Object
	{
		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000B03 RID: 2819 RVA: 0x00011BFC File Offset: 0x0000FDFC
		// (remove) Token: 0x06000B04 RID: 2820 RVA: 0x00011C30 File Offset: 0x0000FE30
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<int, int> activeQualityLevelChanged;

		// Token: 0x06000B05 RID: 2821 RVA: 0x00011C63 File Offset: 0x0000FE63
		[RequiredByNativeCode]
		internal static void OnActiveQualityLevelChanged(int previousQualityLevel, int currentQualityLevel)
		{
			Action<int, int> action = QualitySettings.activeQualityLevelChanged;
			if (action != null)
			{
				action(previousQualityLevel, currentQualityLevel);
			}
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x00011C79 File Offset: 0x0000FE79
		public static void IncreaseLevel([DefaultValue("false")] bool applyExpensiveChanges)
		{
			QualitySettings.SetQualityLevel(QualitySettings.GetQualityLevel() + 1, applyExpensiveChanges);
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x00011C8A File Offset: 0x0000FE8A
		public static void DecreaseLevel([DefaultValue("false")] bool applyExpensiveChanges)
		{
			QualitySettings.SetQualityLevel(QualitySettings.GetQualityLevel() - 1, applyExpensiveChanges);
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x00011C9B File Offset: 0x0000FE9B
		public static void SetQualityLevel(int index)
		{
			QualitySettings.SetQualityLevel(index, true);
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x00011CA6 File Offset: 0x0000FEA6
		public static void IncreaseLevel()
		{
			QualitySettings.IncreaseLevel(false);
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x00011CB0 File Offset: 0x0000FEB0
		public static void DecreaseLevel()
		{
			QualitySettings.DecreaseLevel(false);
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000B0B RID: 2827 RVA: 0x00011CBC File Offset: 0x0000FEBC
		// (set) Token: 0x06000B0C RID: 2828 RVA: 0x00011C9B File Offset: 0x0000FE9B
		[Obsolete("Use GetQualityLevel and SetQualityLevel", false)]
		public static QualityLevel currentLevel
		{
			get
			{
				return (QualityLevel)QualitySettings.GetQualityLevel();
			}
			set
			{
				QualitySettings.SetQualityLevel((int)value, true);
			}
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x00011CD4 File Offset: 0x0000FED4
		public static void ForEach(Action callback)
		{
			bool flag = callback == null;
			if (!flag)
			{
				int qualityLevel = QualitySettings.GetQualityLevel();
				try
				{
					for (int i = 0; i < QualitySettings.count; i++)
					{
						QualitySettings.SetQualityLevel(i, false);
						callback();
					}
				}
				finally
				{
					QualitySettings.SetQualityLevel(qualityLevel, false);
				}
			}
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x00011D38 File Offset: 0x0000FF38
		public static void ForEach(Action<int, string> callback)
		{
			bool flag = callback == null;
			if (!flag)
			{
				int qualityLevel = QualitySettings.GetQualityLevel();
				try
				{
					for (int i = 0; i < QualitySettings.count; i++)
					{
						QualitySettings.SetQualityLevel(i, false);
						callback(i, QualitySettings.names[i]);
					}
				}
				finally
				{
					QualitySettings.SetQualityLevel(qualityLevel, false);
				}
			}
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x0001117A File Offset: 0x0000F37A
		private QualitySettings()
		{
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000B10 RID: 2832
		// (set) Token: 0x06000B11 RID: 2833
		public static extern int pixelLightCount { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000B12 RID: 2834
		// (set) Token: 0x06000B13 RID: 2835
		[NativeProperty("ShadowQuality")]
		public static extern ShadowQuality shadows { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000B14 RID: 2836
		// (set) Token: 0x06000B15 RID: 2837
		public static extern ShadowProjection shadowProjection { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000B16 RID: 2838
		// (set) Token: 0x06000B17 RID: 2839
		public static extern int shadowCascades { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000B18 RID: 2840
		// (set) Token: 0x06000B19 RID: 2841
		public static extern float shadowDistance { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000B1A RID: 2842
		// (set) Token: 0x06000B1B RID: 2843
		[NativeProperty("ShadowResolution")]
		public static extern ShadowResolution shadowResolution { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000B1C RID: 2844
		// (set) Token: 0x06000B1D RID: 2845
		[NativeProperty("ShadowmaskMode")]
		public static extern ShadowmaskMode shadowmaskMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000B1E RID: 2846
		// (set) Token: 0x06000B1F RID: 2847
		public static extern float shadowNearPlaneOffset { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000B20 RID: 2848
		// (set) Token: 0x06000B21 RID: 2849
		public static extern float shadowCascade2Split { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000B22 RID: 2850 RVA: 0x00011DA4 File Offset: 0x0000FFA4
		// (set) Token: 0x06000B23 RID: 2851 RVA: 0x00011DB9 File Offset: 0x0000FFB9
		public static Vector3 shadowCascade4Split
		{
			get
			{
				Vector3 result;
				QualitySettings.get_shadowCascade4Split_Injected(out result);
				return result;
			}
			set
			{
				QualitySettings.set_shadowCascade4Split_Injected(ref value);
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000B24 RID: 2852
		// (set) Token: 0x06000B25 RID: 2853
		[NativeProperty("LODBias")]
		public static extern float lodBias { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000B26 RID: 2854
		// (set) Token: 0x06000B27 RID: 2855
		[NativeProperty("AnisotropicTextures")]
		public static extern AnisotropicFiltering anisotropicFiltering { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000B28 RID: 2856
		// (set) Token: 0x06000B29 RID: 2857
		[NativeProperty("GlobalTextureMipmapLimit")]
		[Obsolete("masterTextureLimit has been deprecated. Use globalTextureMipmapLimit instead (UnityUpgradable) -> globalTextureMipmapLimit", false)]
		public static extern int masterTextureLimit { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000B2A RID: 2858
		// (set) Token: 0x06000B2B RID: 2859
		public static extern int globalTextureMipmapLimit { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000B2C RID: 2860
		// (set) Token: 0x06000B2D RID: 2861
		public static extern int maximumLODLevel { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000B2E RID: 2862
		// (set) Token: 0x06000B2F RID: 2863
		public static extern bool enableLODCrossFade { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000B30 RID: 2864
		// (set) Token: 0x06000B31 RID: 2865
		public static extern int particleRaycastBudget { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000B32 RID: 2866
		// (set) Token: 0x06000B33 RID: 2867
		public static extern bool softParticles { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000B34 RID: 2868
		// (set) Token: 0x06000B35 RID: 2869
		public static extern bool softVegetation { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000B36 RID: 2870
		// (set) Token: 0x06000B37 RID: 2871
		public static extern int vSyncCount { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000B38 RID: 2872
		// (set) Token: 0x06000B39 RID: 2873
		public static extern int realtimeGICPUUsage { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000B3A RID: 2874
		// (set) Token: 0x06000B3B RID: 2875
		public static extern int antiAliasing { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000B3C RID: 2876
		// (set) Token: 0x06000B3D RID: 2877
		public static extern int asyncUploadTimeSlice { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000B3E RID: 2878
		// (set) Token: 0x06000B3F RID: 2879
		public static extern int asyncUploadBufferSize { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000B40 RID: 2880
		// (set) Token: 0x06000B41 RID: 2881
		public static extern bool asyncUploadPersistentBuffer { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06000B42 RID: 2882
		[NativeName("SetLODSettings")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetLODSettings(float lodBias, int maximumLODLevel, bool setDirty = true);

		// Token: 0x06000B43 RID: 2883 RVA: 0x00011DC2 File Offset: 0x0000FFC2
		[NativeName("SetTextureMipmapLimitSettings")]
		[NativeThrows]
		public static void SetTextureMipmapLimitSettings(string groupName, TextureMipmapLimitSettings textureMipmapLimitSettings)
		{
			QualitySettings.SetTextureMipmapLimitSettings_Injected(groupName, ref textureMipmapLimitSettings);
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x00011DCC File Offset: 0x0000FFCC
		[NativeThrows]
		[NativeName("GetTextureMipmapLimitSettings")]
		public static TextureMipmapLimitSettings GetTextureMipmapLimitSettings(string groupName)
		{
			TextureMipmapLimitSettings result;
			QualitySettings.GetTextureMipmapLimitSettings_Injected(groupName, out result);
			return result;
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000B45 RID: 2885
		// (set) Token: 0x06000B46 RID: 2886
		public static extern bool realtimeReflectionProbes { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000B47 RID: 2887
		// (set) Token: 0x06000B48 RID: 2888
		public static extern bool billboardsFaceCameraPosition { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000B49 RID: 2889
		// (set) Token: 0x06000B4A RID: 2890
		public static extern bool useLegacyDetailDistribution { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000B4B RID: 2891
		// (set) Token: 0x06000B4C RID: 2892
		public static extern float resolutionScalingFixedDPIFactor { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000B4D RID: 2893
		// (set) Token: 0x06000B4E RID: 2894
		public static extern TerrainQualityOverrides terrainQualityOverrides { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000B4F RID: 2895
		// (set) Token: 0x06000B50 RID: 2896
		public static extern float terrainPixelError { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000B51 RID: 2897
		// (set) Token: 0x06000B52 RID: 2898
		public static extern float terrainDetailDensityScale { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000B53 RID: 2899
		// (set) Token: 0x06000B54 RID: 2900
		public static extern float terrainBasemapDistance { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000B55 RID: 2901
		// (set) Token: 0x06000B56 RID: 2902
		public static extern float terrainDetailDistance { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06000B57 RID: 2903
		// (set) Token: 0x06000B58 RID: 2904
		public static extern float terrainTreeDistance { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000B59 RID: 2905
		// (set) Token: 0x06000B5A RID: 2906
		public static extern float terrainBillboardStart { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000B5B RID: 2907
		// (set) Token: 0x06000B5C RID: 2908
		public static extern float terrainFadeLength { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000B5D RID: 2909
		// (set) Token: 0x06000B5E RID: 2910
		public static extern float terrainMaxTrees { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000B5F RID: 2911
		// (set) Token: 0x06000B60 RID: 2912
		[NativeName("RenderPipeline")]
		private static extern ScriptableObject INTERNAL_renderPipeline { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000B61 RID: 2913 RVA: 0x00011DE4 File Offset: 0x0000FFE4
		// (set) Token: 0x06000B62 RID: 2914 RVA: 0x00011E00 File Offset: 0x00010000
		public static RenderPipelineAsset renderPipeline
		{
			get
			{
				return QualitySettings.INTERNAL_renderPipeline as RenderPipelineAsset;
			}
			set
			{
				QualitySettings.INTERNAL_renderPipeline = value;
			}
		}

		// Token: 0x06000B63 RID: 2915
		[NativeName("GetRenderPipelineAssetAt")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern ScriptableObject InternalGetRenderPipelineAssetAt(int index);

		// Token: 0x06000B64 RID: 2916 RVA: 0x00011E0C File Offset: 0x0001000C
		public static RenderPipelineAsset GetRenderPipelineAssetAt(int index)
		{
			bool flag = index < 0 || index >= QualitySettings.names.Length;
			if (flag)
			{
				throw new IndexOutOfRangeException(string.Format("{0} is out of range [0..{1}[", "index", QualitySettings.names.Length));
			}
			return QualitySettings.InternalGetRenderPipelineAssetAt(index) as RenderPipelineAsset;
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000B65 RID: 2917
		// (set) Token: 0x06000B66 RID: 2918
		[Obsolete("blendWeights is obsolete. Use skinWeights instead (UnityUpgradable) -> skinWeights", true)]
		public static extern BlendWeights blendWeights { [NativeName("GetSkinWeights")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeName("SetSkinWeights")] [NativeThrows] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000B67 RID: 2919
		// (set) Token: 0x06000B68 RID: 2920
		public static extern SkinWeights skinWeights { [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeThrows] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000B69 RID: 2921
		public static extern int count { [NativeName("GetQualitySettingsCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000B6A RID: 2922
		// (set) Token: 0x06000B6B RID: 2923
		public static extern bool streamingMipmapsActive { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000B6C RID: 2924
		// (set) Token: 0x06000B6D RID: 2925
		public static extern float streamingMipmapsMemoryBudget { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000B6E RID: 2926
		// (set) Token: 0x06000B6F RID: 2927
		public static extern int streamingMipmapsRenderersPerFrame { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000B70 RID: 2928
		// (set) Token: 0x06000B71 RID: 2929
		public static extern int streamingMipmapsMaxLevelReduction { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000B72 RID: 2930
		// (set) Token: 0x06000B73 RID: 2931
		public static extern bool streamingMipmapsAddAllCameras { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000B74 RID: 2932
		// (set) Token: 0x06000B75 RID: 2933
		public static extern int streamingMipmapsMaxFileIORequests { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000B76 RID: 2934
		// (set) Token: 0x06000B77 RID: 2935
		[StaticAccessor("QualitySettingsScripting", StaticAccessorType.DoubleColon)]
		public static extern int maxQueuedFrames { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06000B78 RID: 2936
		[NativeName("GetCurrentIndex")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetQualityLevel();

		// Token: 0x06000B79 RID: 2937
		[FreeFunction]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern Object GetQualitySettings();

		// Token: 0x06000B7A RID: 2938
		[NativeName("SetCurrentIndex")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetQualityLevel(int index, [DefaultValue("true")] bool applyExpensiveChanges);

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000B7B RID: 2939
		[NativeProperty("QualitySettingsNames")]
		public static extern string[] names { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000B7C RID: 2940
		public static extern ColorSpace desiredColorSpace { [StaticAccessor("GetPlayerSettings()", StaticAccessorType.Dot)] [NativeName("GetColorSpace")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000B7D RID: 2941
		public static extern ColorSpace activeColorSpace { [StaticAccessor("GetPlayerSettings()", StaticAccessorType.Dot)] [NativeName("GetColorSpace")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000B7E RID: 2942
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_shadowCascade4Split_Injected(out Vector3 ret);

		// Token: 0x06000B7F RID: 2943
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_shadowCascade4Split_Injected(ref Vector3 value);

		// Token: 0x06000B80 RID: 2944
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTextureMipmapLimitSettings_Injected(string groupName, ref TextureMipmapLimitSettings textureMipmapLimitSettings);

		// Token: 0x06000B81 RID: 2945
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetTextureMipmapLimitSettings_Injected(string groupName, out TextureMipmapLimitSettings ret);
	}
}
