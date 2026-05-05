using System;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x0200047A RID: 1146
	public class SupportedRenderingFeatures
	{
		// Token: 0x1700072E RID: 1838
		// (get) Token: 0x06002715 RID: 10005 RVA: 0x000433BC File Offset: 0x000415BC
		// (set) Token: 0x06002716 RID: 10006 RVA: 0x000433E9 File Offset: 0x000415E9
		public static SupportedRenderingFeatures active
		{
			get
			{
				bool flag = SupportedRenderingFeatures.s_Active == null;
				if (flag)
				{
					SupportedRenderingFeatures.s_Active = new SupportedRenderingFeatures();
				}
				return SupportedRenderingFeatures.s_Active;
			}
			set
			{
				SupportedRenderingFeatures.s_Active = value;
			}
		}

		// Token: 0x1700072F RID: 1839
		// (get) Token: 0x06002717 RID: 10007 RVA: 0x000433F2 File Offset: 0x000415F2
		// (set) Token: 0x06002718 RID: 10008 RVA: 0x000433FA File Offset: 0x000415FA
		public SupportedRenderingFeatures.ReflectionProbeModes reflectionProbeModes { get; set; } = SupportedRenderingFeatures.ReflectionProbeModes.None;

		// Token: 0x17000730 RID: 1840
		// (get) Token: 0x06002719 RID: 10009 RVA: 0x00043403 File Offset: 0x00041603
		// (set) Token: 0x0600271A RID: 10010 RVA: 0x0004340B File Offset: 0x0004160B
		public SupportedRenderingFeatures.LightmapMixedBakeModes defaultMixedLightingModes { get; set; } = SupportedRenderingFeatures.LightmapMixedBakeModes.None;

		// Token: 0x17000731 RID: 1841
		// (get) Token: 0x0600271B RID: 10011 RVA: 0x00043414 File Offset: 0x00041614
		// (set) Token: 0x0600271C RID: 10012 RVA: 0x0004341C File Offset: 0x0004161C
		public SupportedRenderingFeatures.LightmapMixedBakeModes mixedLightingModes { get; set; } = SupportedRenderingFeatures.LightmapMixedBakeModes.IndirectOnly | SupportedRenderingFeatures.LightmapMixedBakeModes.Subtractive | SupportedRenderingFeatures.LightmapMixedBakeModes.Shadowmask;

		// Token: 0x17000732 RID: 1842
		// (get) Token: 0x0600271D RID: 10013 RVA: 0x00043425 File Offset: 0x00041625
		// (set) Token: 0x0600271E RID: 10014 RVA: 0x0004342D File Offset: 0x0004162D
		public LightmapBakeType lightmapBakeTypes { get; set; } = LightmapBakeType.Realtime | LightmapBakeType.Baked | LightmapBakeType.Mixed;

		// Token: 0x17000733 RID: 1843
		// (get) Token: 0x0600271F RID: 10015 RVA: 0x00043436 File Offset: 0x00041636
		// (set) Token: 0x06002720 RID: 10016 RVA: 0x0004343E File Offset: 0x0004163E
		public LightmapsMode lightmapsModes { get; set; } = LightmapsMode.CombinedDirectional;

		// Token: 0x17000734 RID: 1844
		// (get) Token: 0x06002721 RID: 10017 RVA: 0x00043447 File Offset: 0x00041647
		// (set) Token: 0x06002722 RID: 10018 RVA: 0x0004344F File Offset: 0x0004164F
		[Obsolete("Bake with the Progressive Lightmapper. The backend that uses Enlighten to bake is deprecated.", false)]
		public bool enlightenLightmapper { get; set; } = true;

		// Token: 0x17000735 RID: 1845
		// (get) Token: 0x06002723 RID: 10019 RVA: 0x00043458 File Offset: 0x00041658
		// (set) Token: 0x06002724 RID: 10020 RVA: 0x00043460 File Offset: 0x00041660
		public bool enlighten { get; set; } = true;

		// Token: 0x17000736 RID: 1846
		// (get) Token: 0x06002725 RID: 10021 RVA: 0x00043469 File Offset: 0x00041669
		// (set) Token: 0x06002726 RID: 10022 RVA: 0x00043471 File Offset: 0x00041671
		public bool lightProbeProxyVolumes { get; set; } = true;

		// Token: 0x17000737 RID: 1847
		// (get) Token: 0x06002727 RID: 10023 RVA: 0x0004347A File Offset: 0x0004167A
		// (set) Token: 0x06002728 RID: 10024 RVA: 0x00043482 File Offset: 0x00041682
		public bool motionVectors { get; set; } = true;

		// Token: 0x17000738 RID: 1848
		// (get) Token: 0x06002729 RID: 10025 RVA: 0x0004348B File Offset: 0x0004168B
		// (set) Token: 0x0600272A RID: 10026 RVA: 0x00043493 File Offset: 0x00041693
		public bool receiveShadows { get; set; } = true;

		// Token: 0x17000739 RID: 1849
		// (get) Token: 0x0600272B RID: 10027 RVA: 0x0004349C File Offset: 0x0004169C
		// (set) Token: 0x0600272C RID: 10028 RVA: 0x000434A4 File Offset: 0x000416A4
		public bool reflectionProbes { get; set; } = true;

		// Token: 0x1700073A RID: 1850
		// (get) Token: 0x0600272D RID: 10029 RVA: 0x000434AD File Offset: 0x000416AD
		// (set) Token: 0x0600272E RID: 10030 RVA: 0x000434B5 File Offset: 0x000416B5
		public bool reflectionProbesBlendDistance { get; set; } = true;

		// Token: 0x1700073B RID: 1851
		// (get) Token: 0x0600272F RID: 10031 RVA: 0x000434BE File Offset: 0x000416BE
		// (set) Token: 0x06002730 RID: 10032 RVA: 0x000434C6 File Offset: 0x000416C6
		public bool rendererPriority { get; set; } = false;

		// Token: 0x1700073C RID: 1852
		// (get) Token: 0x06002731 RID: 10033 RVA: 0x000434CF File Offset: 0x000416CF
		// (set) Token: 0x06002732 RID: 10034 RVA: 0x000434D7 File Offset: 0x000416D7
		public bool rendersUIOverlay { get; set; } = false;

		// Token: 0x1700073D RID: 1853
		// (get) Token: 0x06002733 RID: 10035 RVA: 0x000434E0 File Offset: 0x000416E0
		// (set) Token: 0x06002734 RID: 10036 RVA: 0x000434E8 File Offset: 0x000416E8
		public bool overridesEnvironmentLighting { get; set; } = false;

		// Token: 0x1700073E RID: 1854
		// (get) Token: 0x06002735 RID: 10037 RVA: 0x000434F1 File Offset: 0x000416F1
		// (set) Token: 0x06002736 RID: 10038 RVA: 0x000434F9 File Offset: 0x000416F9
		public bool overridesFog { get; set; } = false;

		// Token: 0x1700073F RID: 1855
		// (get) Token: 0x06002737 RID: 10039 RVA: 0x00043502 File Offset: 0x00041702
		// (set) Token: 0x06002738 RID: 10040 RVA: 0x0004350A File Offset: 0x0004170A
		public bool overridesRealtimeReflectionProbes { get; set; } = false;

		// Token: 0x17000740 RID: 1856
		// (get) Token: 0x06002739 RID: 10041 RVA: 0x00043513 File Offset: 0x00041713
		// (set) Token: 0x0600273A RID: 10042 RVA: 0x0004351B File Offset: 0x0004171B
		public bool overridesOtherLightingSettings { get; set; } = false;

		// Token: 0x17000741 RID: 1857
		// (get) Token: 0x0600273B RID: 10043 RVA: 0x00043524 File Offset: 0x00041724
		// (set) Token: 0x0600273C RID: 10044 RVA: 0x0004352C File Offset: 0x0004172C
		public bool editableMaterialRenderQueue { get; set; } = true;

		// Token: 0x17000742 RID: 1858
		// (get) Token: 0x0600273D RID: 10045 RVA: 0x00043535 File Offset: 0x00041735
		// (set) Token: 0x0600273E RID: 10046 RVA: 0x0004353D File Offset: 0x0004173D
		public bool overridesLODBias { get; set; } = false;

		// Token: 0x17000743 RID: 1859
		// (get) Token: 0x0600273F RID: 10047 RVA: 0x00043546 File Offset: 0x00041746
		// (set) Token: 0x06002740 RID: 10048 RVA: 0x0004354E File Offset: 0x0004174E
		public bool overridesMaximumLODLevel { get; set; } = false;

		// Token: 0x17000744 RID: 1860
		// (get) Token: 0x06002741 RID: 10049 RVA: 0x00043557 File Offset: 0x00041757
		// (set) Token: 0x06002742 RID: 10050 RVA: 0x0004355F File Offset: 0x0004175F
		public bool overridesEnableLODCrossFade { get; set; } = false;

		// Token: 0x17000745 RID: 1861
		// (get) Token: 0x06002743 RID: 10051 RVA: 0x00043568 File Offset: 0x00041768
		// (set) Token: 0x06002744 RID: 10052 RVA: 0x00043570 File Offset: 0x00041770
		public bool rendererProbes { get; set; } = true;

		// Token: 0x17000746 RID: 1862
		// (get) Token: 0x06002745 RID: 10053 RVA: 0x00043579 File Offset: 0x00041779
		// (set) Token: 0x06002746 RID: 10054 RVA: 0x00043581 File Offset: 0x00041781
		public bool particleSystemInstancing { get; set; } = true;

		// Token: 0x17000747 RID: 1863
		// (get) Token: 0x06002747 RID: 10055 RVA: 0x0004358A File Offset: 0x0004178A
		// (set) Token: 0x06002748 RID: 10056 RVA: 0x00043592 File Offset: 0x00041792
		public bool autoAmbientProbeBaking { get; set; } = true;

		// Token: 0x17000748 RID: 1864
		// (get) Token: 0x06002749 RID: 10057 RVA: 0x0004359B File Offset: 0x0004179B
		// (set) Token: 0x0600274A RID: 10058 RVA: 0x000435A3 File Offset: 0x000417A3
		public bool autoDefaultReflectionProbeBaking { get; set; } = true;

		// Token: 0x17000749 RID: 1865
		// (get) Token: 0x0600274B RID: 10059 RVA: 0x000435AC File Offset: 0x000417AC
		// (set) Token: 0x0600274C RID: 10060 RVA: 0x000435B4 File Offset: 0x000417B4
		public bool overridesShadowmask { get; set; } = false;

		// Token: 0x1700074A RID: 1866
		// (get) Token: 0x0600274D RID: 10061 RVA: 0x000435BD File Offset: 0x000417BD
		// (set) Token: 0x0600274E RID: 10062 RVA: 0x000435C5 File Offset: 0x000417C5
		public bool overridesLightProbeSystem { get; set; } = false;

		// Token: 0x1700074B RID: 1867
		// (get) Token: 0x0600274F RID: 10063 RVA: 0x000435CE File Offset: 0x000417CE
		// (set) Token: 0x06002750 RID: 10064 RVA: 0x000435D6 File Offset: 0x000417D6
		public bool supportsHDR { get; set; } = false;

		// Token: 0x1700074C RID: 1868
		// (get) Token: 0x06002751 RID: 10065 RVA: 0x000435DF File Offset: 0x000417DF
		// (set) Token: 0x06002752 RID: 10066 RVA: 0x000435E7 File Offset: 0x000417E7
		public string overridesLightProbeSystemWarningMessage { get; set; } = "The rendering pipeline used has an alternative method to handle light probes. Please consult the documentation for the used SRP to setup the alternative.";

		// Token: 0x06002753 RID: 10067 RVA: 0x000435F0 File Offset: 0x000417F0
		internal unsafe static MixedLightingMode FallbackMixedLightingMode()
		{
			MixedLightingMode result;
			SupportedRenderingFeatures.FallbackMixedLightingModeByRef(new IntPtr((void*)(&result)));
			return result;
		}

		// Token: 0x06002754 RID: 10068 RVA: 0x00043614 File Offset: 0x00041814
		[RequiredByNativeCode]
		internal unsafe static void FallbackMixedLightingModeByRef(IntPtr fallbackModePtr)
		{
			MixedLightingMode* ptr = (MixedLightingMode*)((void*)fallbackModePtr);
			bool flag = SupportedRenderingFeatures.active.defaultMixedLightingModes != SupportedRenderingFeatures.LightmapMixedBakeModes.None && (SupportedRenderingFeatures.active.mixedLightingModes & SupportedRenderingFeatures.active.defaultMixedLightingModes) == SupportedRenderingFeatures.active.defaultMixedLightingModes;
			if (flag)
			{
				SupportedRenderingFeatures.LightmapMixedBakeModes defaultMixedLightingModes = SupportedRenderingFeatures.active.defaultMixedLightingModes;
				SupportedRenderingFeatures.LightmapMixedBakeModes lightmapMixedBakeModes = defaultMixedLightingModes;
				if (lightmapMixedBakeModes != SupportedRenderingFeatures.LightmapMixedBakeModes.Subtractive)
				{
					if (lightmapMixedBakeModes != SupportedRenderingFeatures.LightmapMixedBakeModes.Shadowmask)
					{
						*ptr = MixedLightingMode.IndirectOnly;
					}
					else
					{
						*ptr = MixedLightingMode.Shadowmask;
					}
				}
				else
				{
					*ptr = MixedLightingMode.Subtractive;
				}
			}
			else
			{
				bool flag2 = SupportedRenderingFeatures.IsMixedLightingModeSupported(MixedLightingMode.Shadowmask);
				if (flag2)
				{
					*ptr = MixedLightingMode.Shadowmask;
				}
				else
				{
					bool flag3 = SupportedRenderingFeatures.IsMixedLightingModeSupported(MixedLightingMode.Subtractive);
					if (flag3)
					{
						*ptr = MixedLightingMode.Subtractive;
					}
					else
					{
						*ptr = MixedLightingMode.IndirectOnly;
					}
				}
			}
		}

		// Token: 0x06002755 RID: 10069 RVA: 0x000436B0 File Offset: 0x000418B0
		internal unsafe static bool IsMixedLightingModeSupported(MixedLightingMode mixedMode)
		{
			bool result;
			SupportedRenderingFeatures.IsMixedLightingModeSupportedByRef(mixedMode, new IntPtr((void*)(&result)));
			return result;
		}

		// Token: 0x06002756 RID: 10070 RVA: 0x000436D4 File Offset: 0x000418D4
		[RequiredByNativeCode]
		internal unsafe static void IsMixedLightingModeSupportedByRef(MixedLightingMode mixedMode, IntPtr isSupportedPtr)
		{
			bool* ptr = (bool*)((void*)isSupportedPtr);
			bool flag = !SupportedRenderingFeatures.IsLightmapBakeTypeSupported(LightmapBakeType.Mixed);
			if (flag)
			{
				*ptr = false;
			}
			else
			{
				*ptr = ((mixedMode == MixedLightingMode.IndirectOnly && (SupportedRenderingFeatures.active.mixedLightingModes & SupportedRenderingFeatures.LightmapMixedBakeModes.IndirectOnly) == SupportedRenderingFeatures.LightmapMixedBakeModes.IndirectOnly) || (mixedMode == MixedLightingMode.Subtractive && (SupportedRenderingFeatures.active.mixedLightingModes & SupportedRenderingFeatures.LightmapMixedBakeModes.Subtractive) == SupportedRenderingFeatures.LightmapMixedBakeModes.Subtractive) || (mixedMode == MixedLightingMode.Shadowmask && (SupportedRenderingFeatures.active.mixedLightingModes & SupportedRenderingFeatures.LightmapMixedBakeModes.Shadowmask) == SupportedRenderingFeatures.LightmapMixedBakeModes.Shadowmask));
			}
		}

		// Token: 0x06002757 RID: 10071 RVA: 0x0004373C File Offset: 0x0004193C
		internal unsafe static bool IsLightmapBakeTypeSupported(LightmapBakeType bakeType)
		{
			bool result;
			SupportedRenderingFeatures.IsLightmapBakeTypeSupportedByRef(bakeType, new IntPtr((void*)(&result)));
			return result;
		}

		// Token: 0x06002758 RID: 10072 RVA: 0x00043760 File Offset: 0x00041960
		[RequiredByNativeCode]
		internal unsafe static void IsLightmapBakeTypeSupportedByRef(LightmapBakeType bakeType, IntPtr isSupportedPtr)
		{
			bool* ptr = (bool*)((void*)isSupportedPtr);
			bool flag = bakeType == LightmapBakeType.Mixed;
			if (flag)
			{
				bool flag2 = SupportedRenderingFeatures.IsLightmapBakeTypeSupported(LightmapBakeType.Baked);
				bool flag3 = !flag2 || SupportedRenderingFeatures.active.mixedLightingModes == SupportedRenderingFeatures.LightmapMixedBakeModes.None;
				if (flag3)
				{
					*ptr = false;
					return;
				}
			}
			*ptr = ((SupportedRenderingFeatures.active.lightmapBakeTypes & bakeType) == bakeType);
			bool flag4 = bakeType == LightmapBakeType.Realtime && !SupportedRenderingFeatures.active.enlighten;
			if (flag4)
			{
				*ptr = false;
			}
		}

		// Token: 0x06002759 RID: 10073 RVA: 0x000437D4 File Offset: 0x000419D4
		internal unsafe static bool IsLightmapsModeSupported(LightmapsMode mode)
		{
			bool result;
			SupportedRenderingFeatures.IsLightmapsModeSupportedByRef(mode, new IntPtr((void*)(&result)));
			return result;
		}

		// Token: 0x0600275A RID: 10074 RVA: 0x000437F8 File Offset: 0x000419F8
		[RequiredByNativeCode]
		internal unsafe static void IsLightmapsModeSupportedByRef(LightmapsMode mode, IntPtr isSupportedPtr)
		{
			bool* ptr = (bool*)((void*)isSupportedPtr);
			*ptr = ((SupportedRenderingFeatures.active.lightmapsModes & mode) == mode);
		}

		// Token: 0x0600275B RID: 10075 RVA: 0x00043820 File Offset: 0x00041A20
		internal unsafe static bool IsLightmapperSupported(int lightmapper)
		{
			bool result;
			SupportedRenderingFeatures.IsLightmapperSupportedByRef(lightmapper, new IntPtr((void*)(&result)));
			return result;
		}

		// Token: 0x0600275C RID: 10076 RVA: 0x00043844 File Offset: 0x00041A44
		[RequiredByNativeCode]
		internal unsafe static void IsLightmapperSupportedByRef(int lightmapper, IntPtr isSupportedPtr)
		{
			bool* ptr = (bool*)((void*)isSupportedPtr);
			*ptr = (lightmapper != 0 || SupportedRenderingFeatures.active.enlightenLightmapper);
		}

		// Token: 0x0600275D RID: 10077 RVA: 0x0004386C File Offset: 0x00041A6C
		[RequiredByNativeCode]
		internal unsafe static void IsUIOverlayRenderedBySRP(IntPtr isSupportedPtr)
		{
			bool* ptr = (bool*)((void*)isSupportedPtr);
			*ptr = SupportedRenderingFeatures.active.rendersUIOverlay;
		}

		// Token: 0x0600275E RID: 10078 RVA: 0x00043890 File Offset: 0x00041A90
		[RequiredByNativeCode]
		internal unsafe static void IsAutoAmbientProbeBakingSupported(IntPtr isSupportedPtr)
		{
			bool* ptr = (bool*)((void*)isSupportedPtr);
			*ptr = SupportedRenderingFeatures.active.autoAmbientProbeBaking;
		}

		// Token: 0x0600275F RID: 10079 RVA: 0x000438B4 File Offset: 0x00041AB4
		[RequiredByNativeCode]
		internal unsafe static void IsAutoDefaultReflectionProbeBakingSupported(IntPtr isSupportedPtr)
		{
			bool* ptr = (bool*)((void*)isSupportedPtr);
			*ptr = SupportedRenderingFeatures.active.autoDefaultReflectionProbeBaking;
		}

		// Token: 0x06002760 RID: 10080 RVA: 0x000438D8 File Offset: 0x00041AD8
		[RequiredByNativeCode]
		internal unsafe static void OverridesLightProbeSystem(IntPtr overridesPtr)
		{
			bool* ptr = (bool*)((void*)overridesPtr);
			*ptr = SupportedRenderingFeatures.active.overridesLightProbeSystem;
		}

		// Token: 0x06002761 RID: 10081 RVA: 0x000438FC File Offset: 0x00041AFC
		internal unsafe static int FallbackLightmapper()
		{
			int result;
			SupportedRenderingFeatures.FallbackLightmapperByRef(new IntPtr((void*)(&result)));
			return result;
		}

		// Token: 0x06002762 RID: 10082 RVA: 0x00043920 File Offset: 0x00041B20
		[RequiredByNativeCode]
		internal unsafe static void FallbackLightmapperByRef(IntPtr lightmapperPtr)
		{
			int* ptr = (int*)((void*)lightmapperPtr);
			*ptr = 1;
		}

		// Token: 0x1700074D RID: 1869
		// (get) Token: 0x06002763 RID: 10083 RVA: 0x00043938 File Offset: 0x00041B38
		// (set) Token: 0x06002764 RID: 10084 RVA: 0x00002669 File Offset: 0x00000869
		[Obsolete("terrainDetailUnsupported is deprecated.")]
		public bool terrainDetailUnsupported
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		// Token: 0x04000EC4 RID: 3780
		private static SupportedRenderingFeatures s_Active = new SupportedRenderingFeatures();

		// Token: 0x0200047B RID: 1147
		[Flags]
		public enum ReflectionProbeModes
		{
			// Token: 0x04000EE4 RID: 3812
			None = 0,
			// Token: 0x04000EE5 RID: 3813
			Rotation = 1
		}

		// Token: 0x0200047C RID: 1148
		[Flags]
		public enum LightmapMixedBakeModes
		{
			// Token: 0x04000EE7 RID: 3815
			None = 0,
			// Token: 0x04000EE8 RID: 3816
			IndirectOnly = 1,
			// Token: 0x04000EE9 RID: 3817
			Subtractive = 2,
			// Token: 0x04000EEA RID: 3818
			Shadowmask = 4
		}
	}
}
