using System;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace UnityEngine.Device
{
	// Token: 0x020004B1 RID: 1201
	public static class SystemInfo
	{
		// Token: 0x170007D8 RID: 2008
		// (get) Token: 0x06002A3A RID: 10810 RVA: 0x0004733E File Offset: 0x0004553E
		public static float batteryLevel
		{
			get
			{
				return SystemInfo.batteryLevel;
			}
		}

		// Token: 0x170007D9 RID: 2009
		// (get) Token: 0x06002A3B RID: 10811 RVA: 0x00047345 File Offset: 0x00045545
		public static BatteryStatus batteryStatus
		{
			get
			{
				return SystemInfo.batteryStatus;
			}
		}

		// Token: 0x170007DA RID: 2010
		// (get) Token: 0x06002A3C RID: 10812 RVA: 0x0004734C File Offset: 0x0004554C
		public static string operatingSystem
		{
			get
			{
				return SystemInfo.operatingSystem;
			}
		}

		// Token: 0x170007DB RID: 2011
		// (get) Token: 0x06002A3D RID: 10813 RVA: 0x00047353 File Offset: 0x00045553
		public static OperatingSystemFamily operatingSystemFamily
		{
			get
			{
				return SystemInfo.operatingSystemFamily;
			}
		}

		// Token: 0x170007DC RID: 2012
		// (get) Token: 0x06002A3E RID: 10814 RVA: 0x0004735A File Offset: 0x0004555A
		public static string processorType
		{
			get
			{
				return SystemInfo.processorType;
			}
		}

		// Token: 0x170007DD RID: 2013
		// (get) Token: 0x06002A3F RID: 10815 RVA: 0x00047361 File Offset: 0x00045561
		public static int processorFrequency
		{
			get
			{
				return SystemInfo.processorFrequency;
			}
		}

		// Token: 0x170007DE RID: 2014
		// (get) Token: 0x06002A40 RID: 10816 RVA: 0x00047368 File Offset: 0x00045568
		public static int processorCount
		{
			get
			{
				return SystemInfo.processorCount;
			}
		}

		// Token: 0x170007DF RID: 2015
		// (get) Token: 0x06002A41 RID: 10817 RVA: 0x0004736F File Offset: 0x0004556F
		public static int systemMemorySize
		{
			get
			{
				return SystemInfo.systemMemorySize;
			}
		}

		// Token: 0x170007E0 RID: 2016
		// (get) Token: 0x06002A42 RID: 10818 RVA: 0x00047376 File Offset: 0x00045576
		public static string deviceUniqueIdentifier
		{
			get
			{
				return SystemInfo.deviceUniqueIdentifier;
			}
		}

		// Token: 0x170007E1 RID: 2017
		// (get) Token: 0x06002A43 RID: 10819 RVA: 0x0004737D File Offset: 0x0004557D
		public static string deviceName
		{
			get
			{
				return SystemInfo.deviceName;
			}
		}

		// Token: 0x170007E2 RID: 2018
		// (get) Token: 0x06002A44 RID: 10820 RVA: 0x00047384 File Offset: 0x00045584
		public static string deviceModel
		{
			get
			{
				return SystemInfo.deviceModel;
			}
		}

		// Token: 0x170007E3 RID: 2019
		// (get) Token: 0x06002A45 RID: 10821 RVA: 0x0004738B File Offset: 0x0004558B
		public static bool supportsAccelerometer
		{
			get
			{
				return SystemInfo.supportsAccelerometer;
			}
		}

		// Token: 0x170007E4 RID: 2020
		// (get) Token: 0x06002A46 RID: 10822 RVA: 0x00047392 File Offset: 0x00045592
		public static bool supportsGyroscope
		{
			get
			{
				return SystemInfo.supportsGyroscope;
			}
		}

		// Token: 0x170007E5 RID: 2021
		// (get) Token: 0x06002A47 RID: 10823 RVA: 0x00047399 File Offset: 0x00045599
		public static bool supportsLocationService
		{
			get
			{
				return SystemInfo.supportsLocationService;
			}
		}

		// Token: 0x170007E6 RID: 2022
		// (get) Token: 0x06002A48 RID: 10824 RVA: 0x000473A0 File Offset: 0x000455A0
		public static bool supportsVibration
		{
			get
			{
				return SystemInfo.supportsVibration;
			}
		}

		// Token: 0x170007E7 RID: 2023
		// (get) Token: 0x06002A49 RID: 10825 RVA: 0x000473A7 File Offset: 0x000455A7
		public static bool supportsAudio
		{
			get
			{
				return SystemInfo.supportsAudio;
			}
		}

		// Token: 0x170007E8 RID: 2024
		// (get) Token: 0x06002A4A RID: 10826 RVA: 0x000473AE File Offset: 0x000455AE
		public static DeviceType deviceType
		{
			get
			{
				return SystemInfo.deviceType;
			}
		}

		// Token: 0x170007E9 RID: 2025
		// (get) Token: 0x06002A4B RID: 10827 RVA: 0x000473B5 File Offset: 0x000455B5
		public static int graphicsMemorySize
		{
			get
			{
				return SystemInfo.graphicsMemorySize;
			}
		}

		// Token: 0x170007EA RID: 2026
		// (get) Token: 0x06002A4C RID: 10828 RVA: 0x000473BC File Offset: 0x000455BC
		public static string graphicsDeviceName
		{
			get
			{
				return SystemInfo.graphicsDeviceName;
			}
		}

		// Token: 0x170007EB RID: 2027
		// (get) Token: 0x06002A4D RID: 10829 RVA: 0x000473C3 File Offset: 0x000455C3
		public static string graphicsDeviceVendor
		{
			get
			{
				return SystemInfo.graphicsDeviceVendor;
			}
		}

		// Token: 0x170007EC RID: 2028
		// (get) Token: 0x06002A4E RID: 10830 RVA: 0x000473CA File Offset: 0x000455CA
		public static int graphicsDeviceID
		{
			get
			{
				return SystemInfo.graphicsDeviceID;
			}
		}

		// Token: 0x170007ED RID: 2029
		// (get) Token: 0x06002A4F RID: 10831 RVA: 0x000473D1 File Offset: 0x000455D1
		public static int graphicsDeviceVendorID
		{
			get
			{
				return SystemInfo.graphicsDeviceVendorID;
			}
		}

		// Token: 0x170007EE RID: 2030
		// (get) Token: 0x06002A50 RID: 10832 RVA: 0x000473D8 File Offset: 0x000455D8
		public static GraphicsDeviceType graphicsDeviceType
		{
			get
			{
				return SystemInfo.graphicsDeviceType;
			}
		}

		// Token: 0x170007EF RID: 2031
		// (get) Token: 0x06002A51 RID: 10833 RVA: 0x000473DF File Offset: 0x000455DF
		public static bool graphicsUVStartsAtTop
		{
			get
			{
				return SystemInfo.graphicsUVStartsAtTop;
			}
		}

		// Token: 0x170007F0 RID: 2032
		// (get) Token: 0x06002A52 RID: 10834 RVA: 0x000473E6 File Offset: 0x000455E6
		public static string graphicsDeviceVersion
		{
			get
			{
				return SystemInfo.graphicsDeviceVersion;
			}
		}

		// Token: 0x170007F1 RID: 2033
		// (get) Token: 0x06002A53 RID: 10835 RVA: 0x000473ED File Offset: 0x000455ED
		public static int graphicsShaderLevel
		{
			get
			{
				return SystemInfo.graphicsShaderLevel;
			}
		}

		// Token: 0x170007F2 RID: 2034
		// (get) Token: 0x06002A54 RID: 10836 RVA: 0x000473F4 File Offset: 0x000455F4
		public static bool graphicsMultiThreaded
		{
			get
			{
				return SystemInfo.graphicsMultiThreaded;
			}
		}

		// Token: 0x170007F3 RID: 2035
		// (get) Token: 0x06002A55 RID: 10837 RVA: 0x000473FB File Offset: 0x000455FB
		public static RenderingThreadingMode renderingThreadingMode
		{
			get
			{
				return SystemInfo.renderingThreadingMode;
			}
		}

		// Token: 0x170007F4 RID: 2036
		// (get) Token: 0x06002A56 RID: 10838 RVA: 0x00047402 File Offset: 0x00045602
		public static FoveatedRenderingCaps foveatedRenderingCaps
		{
			get
			{
				return SystemInfo.foveatedRenderingCaps;
			}
		}

		// Token: 0x170007F5 RID: 2037
		// (get) Token: 0x06002A57 RID: 10839 RVA: 0x00047409 File Offset: 0x00045609
		public static bool hasHiddenSurfaceRemovalOnGPU
		{
			get
			{
				return SystemInfo.hasHiddenSurfaceRemovalOnGPU;
			}
		}

		// Token: 0x170007F6 RID: 2038
		// (get) Token: 0x06002A58 RID: 10840 RVA: 0x00047410 File Offset: 0x00045610
		public static bool hasDynamicUniformArrayIndexingInFragmentShaders
		{
			get
			{
				return SystemInfo.hasDynamicUniformArrayIndexingInFragmentShaders;
			}
		}

		// Token: 0x170007F7 RID: 2039
		// (get) Token: 0x06002A59 RID: 10841 RVA: 0x00047417 File Offset: 0x00045617
		public static bool supportsShadows
		{
			get
			{
				return SystemInfo.supportsShadows;
			}
		}

		// Token: 0x170007F8 RID: 2040
		// (get) Token: 0x06002A5A RID: 10842 RVA: 0x0004741E File Offset: 0x0004561E
		public static bool supportsRawShadowDepthSampling
		{
			get
			{
				return SystemInfo.supportsRawShadowDepthSampling;
			}
		}

		// Token: 0x170007F9 RID: 2041
		// (get) Token: 0x06002A5B RID: 10843 RVA: 0x00047425 File Offset: 0x00045625
		public static bool supportsMotionVectors
		{
			get
			{
				return SystemInfo.supportsMotionVectors;
			}
		}

		// Token: 0x170007FA RID: 2042
		// (get) Token: 0x06002A5C RID: 10844 RVA: 0x0004742C File Offset: 0x0004562C
		public static bool supports3DTextures
		{
			get
			{
				return SystemInfo.supports3DTextures;
			}
		}

		// Token: 0x170007FB RID: 2043
		// (get) Token: 0x06002A5D RID: 10845 RVA: 0x00047433 File Offset: 0x00045633
		public static bool supportsCompressed3DTextures
		{
			get
			{
				return SystemInfo.supportsCompressed3DTextures;
			}
		}

		// Token: 0x170007FC RID: 2044
		// (get) Token: 0x06002A5E RID: 10846 RVA: 0x0004743A File Offset: 0x0004563A
		public static bool supports2DArrayTextures
		{
			get
			{
				return SystemInfo.supports2DArrayTextures;
			}
		}

		// Token: 0x170007FD RID: 2045
		// (get) Token: 0x06002A5F RID: 10847 RVA: 0x00047441 File Offset: 0x00045641
		public static bool supports3DRenderTextures
		{
			get
			{
				return SystemInfo.supports3DRenderTextures;
			}
		}

		// Token: 0x170007FE RID: 2046
		// (get) Token: 0x06002A60 RID: 10848 RVA: 0x00047448 File Offset: 0x00045648
		public static bool supportsCubemapArrayTextures
		{
			get
			{
				return SystemInfo.supportsCubemapArrayTextures;
			}
		}

		// Token: 0x170007FF RID: 2047
		// (get) Token: 0x06002A61 RID: 10849 RVA: 0x0004744F File Offset: 0x0004564F
		public static bool supportsAnisotropicFilter
		{
			get
			{
				return SystemInfo.supportsAnisotropicFilter;
			}
		}

		// Token: 0x17000800 RID: 2048
		// (get) Token: 0x06002A62 RID: 10850 RVA: 0x00047456 File Offset: 0x00045656
		public static CopyTextureSupport copyTextureSupport
		{
			get
			{
				return SystemInfo.copyTextureSupport;
			}
		}

		// Token: 0x17000801 RID: 2049
		// (get) Token: 0x06002A63 RID: 10851 RVA: 0x0004745D File Offset: 0x0004565D
		public static bool supportsComputeShaders
		{
			get
			{
				return SystemInfo.supportsComputeShaders;
			}
		}

		// Token: 0x17000802 RID: 2050
		// (get) Token: 0x06002A64 RID: 10852 RVA: 0x00047464 File Offset: 0x00045664
		public static bool supportsGeometryShaders
		{
			get
			{
				return SystemInfo.supportsGeometryShaders;
			}
		}

		// Token: 0x17000803 RID: 2051
		// (get) Token: 0x06002A65 RID: 10853 RVA: 0x0004746B File Offset: 0x0004566B
		public static bool supportsTessellationShaders
		{
			get
			{
				return SystemInfo.supportsTessellationShaders;
			}
		}

		// Token: 0x17000804 RID: 2052
		// (get) Token: 0x06002A66 RID: 10854 RVA: 0x00047472 File Offset: 0x00045672
		public static bool supportsRenderTargetArrayIndexFromVertexShader
		{
			get
			{
				return SystemInfo.supportsRenderTargetArrayIndexFromVertexShader;
			}
		}

		// Token: 0x17000805 RID: 2053
		// (get) Token: 0x06002A67 RID: 10855 RVA: 0x00047479 File Offset: 0x00045679
		public static bool supportsInstancing
		{
			get
			{
				return SystemInfo.supportsInstancing;
			}
		}

		// Token: 0x17000806 RID: 2054
		// (get) Token: 0x06002A68 RID: 10856 RVA: 0x00047480 File Offset: 0x00045680
		public static bool supportsHardwareQuadTopology
		{
			get
			{
				return SystemInfo.supportsHardwareQuadTopology;
			}
		}

		// Token: 0x17000807 RID: 2055
		// (get) Token: 0x06002A69 RID: 10857 RVA: 0x00047487 File Offset: 0x00045687
		public static bool supports32bitsIndexBuffer
		{
			get
			{
				return SystemInfo.supports32bitsIndexBuffer;
			}
		}

		// Token: 0x17000808 RID: 2056
		// (get) Token: 0x06002A6A RID: 10858 RVA: 0x0004748E File Offset: 0x0004568E
		public static bool supportsSparseTextures
		{
			get
			{
				return SystemInfo.supportsSparseTextures;
			}
		}

		// Token: 0x17000809 RID: 2057
		// (get) Token: 0x06002A6B RID: 10859 RVA: 0x00047495 File Offset: 0x00045695
		public static int supportedRenderTargetCount
		{
			get
			{
				return SystemInfo.supportedRenderTargetCount;
			}
		}

		// Token: 0x1700080A RID: 2058
		// (get) Token: 0x06002A6C RID: 10860 RVA: 0x0004749C File Offset: 0x0004569C
		public static bool supportsSeparatedRenderTargetsBlend
		{
			get
			{
				return SystemInfo.supportsSeparatedRenderTargetsBlend;
			}
		}

		// Token: 0x1700080B RID: 2059
		// (get) Token: 0x06002A6D RID: 10861 RVA: 0x000474A3 File Offset: 0x000456A3
		public static int supportedRandomWriteTargetCount
		{
			get
			{
				return SystemInfo.supportedRandomWriteTargetCount;
			}
		}

		// Token: 0x1700080C RID: 2060
		// (get) Token: 0x06002A6E RID: 10862 RVA: 0x000474AA File Offset: 0x000456AA
		public static int supportsMultisampledTextures
		{
			get
			{
				return SystemInfo.supportsMultisampledTextures;
			}
		}

		// Token: 0x1700080D RID: 2061
		// (get) Token: 0x06002A6F RID: 10863 RVA: 0x000474B1 File Offset: 0x000456B1
		public static bool supportsMultisampled2DArrayTextures
		{
			get
			{
				return SystemInfo.supportsMultisampled2DArrayTextures;
			}
		}

		// Token: 0x1700080E RID: 2062
		// (get) Token: 0x06002A70 RID: 10864 RVA: 0x000474B8 File Offset: 0x000456B8
		public static bool supportsMultisampleAutoResolve
		{
			get
			{
				return SystemInfo.supportsMultisampleAutoResolve;
			}
		}

		// Token: 0x1700080F RID: 2063
		// (get) Token: 0x06002A71 RID: 10865 RVA: 0x000474BF File Offset: 0x000456BF
		public static int supportsTextureWrapMirrorOnce
		{
			get
			{
				return SystemInfo.supportsTextureWrapMirrorOnce;
			}
		}

		// Token: 0x17000810 RID: 2064
		// (get) Token: 0x06002A72 RID: 10866 RVA: 0x000474C6 File Offset: 0x000456C6
		public static bool usesReversedZBuffer
		{
			get
			{
				return SystemInfo.usesReversedZBuffer;
			}
		}

		// Token: 0x06002A73 RID: 10867 RVA: 0x000474D0 File Offset: 0x000456D0
		public static bool SupportsRenderTextureFormat(RenderTextureFormat format)
		{
			return SystemInfo.SupportsRenderTextureFormat(format);
		}

		// Token: 0x06002A74 RID: 10868 RVA: 0x000474E8 File Offset: 0x000456E8
		public static bool SupportsBlendingOnRenderTextureFormat(RenderTextureFormat format)
		{
			return SystemInfo.SupportsBlendingOnRenderTextureFormat(format);
		}

		// Token: 0x06002A75 RID: 10869 RVA: 0x00047500 File Offset: 0x00045700
		public static bool SupportsTextureFormat(TextureFormat format)
		{
			return SystemInfo.SupportsTextureFormat(format);
		}

		// Token: 0x06002A76 RID: 10870 RVA: 0x00047518 File Offset: 0x00045718
		public static bool SupportsVertexAttributeFormat(VertexAttributeFormat format, int dimension)
		{
			return SystemInfo.SupportsVertexAttributeFormat(format, dimension);
		}

		// Token: 0x17000811 RID: 2065
		// (get) Token: 0x06002A77 RID: 10871 RVA: 0x00047531 File Offset: 0x00045731
		public static NPOTSupport npotSupport
		{
			get
			{
				return SystemInfo.npotSupport;
			}
		}

		// Token: 0x17000812 RID: 2066
		// (get) Token: 0x06002A78 RID: 10872 RVA: 0x00047538 File Offset: 0x00045738
		public static int maxTextureSize
		{
			get
			{
				return SystemInfo.maxTextureSize;
			}
		}

		// Token: 0x17000813 RID: 2067
		// (get) Token: 0x06002A79 RID: 10873 RVA: 0x0004753F File Offset: 0x0004573F
		public static int maxTexture3DSize
		{
			get
			{
				return SystemInfo.maxTexture3DSize;
			}
		}

		// Token: 0x17000814 RID: 2068
		// (get) Token: 0x06002A7A RID: 10874 RVA: 0x00047546 File Offset: 0x00045746
		public static int maxTextureArraySlices
		{
			get
			{
				return SystemInfo.maxTextureArraySlices;
			}
		}

		// Token: 0x17000815 RID: 2069
		// (get) Token: 0x06002A7B RID: 10875 RVA: 0x0004754D File Offset: 0x0004574D
		public static int maxCubemapSize
		{
			get
			{
				return SystemInfo.maxCubemapSize;
			}
		}

		// Token: 0x17000816 RID: 2070
		// (get) Token: 0x06002A7C RID: 10876 RVA: 0x00047554 File Offset: 0x00045754
		public static int maxAnisotropyLevel
		{
			get
			{
				return SystemInfo.maxAnisotropyLevel;
			}
		}

		// Token: 0x17000817 RID: 2071
		// (get) Token: 0x06002A7D RID: 10877 RVA: 0x0004755B File Offset: 0x0004575B
		public static int maxComputeBufferInputsVertex
		{
			get
			{
				return SystemInfo.maxComputeBufferInputsVertex;
			}
		}

		// Token: 0x17000818 RID: 2072
		// (get) Token: 0x06002A7E RID: 10878 RVA: 0x00047562 File Offset: 0x00045762
		public static int maxComputeBufferInputsFragment
		{
			get
			{
				return SystemInfo.maxComputeBufferInputsFragment;
			}
		}

		// Token: 0x17000819 RID: 2073
		// (get) Token: 0x06002A7F RID: 10879 RVA: 0x00047569 File Offset: 0x00045769
		public static int maxComputeBufferInputsGeometry
		{
			get
			{
				return SystemInfo.maxComputeBufferInputsGeometry;
			}
		}

		// Token: 0x1700081A RID: 2074
		// (get) Token: 0x06002A80 RID: 10880 RVA: 0x00047570 File Offset: 0x00045770
		public static int maxComputeBufferInputsDomain
		{
			get
			{
				return SystemInfo.maxComputeBufferInputsDomain;
			}
		}

		// Token: 0x1700081B RID: 2075
		// (get) Token: 0x06002A81 RID: 10881 RVA: 0x00047577 File Offset: 0x00045777
		public static int maxComputeBufferInputsHull
		{
			get
			{
				return SystemInfo.maxComputeBufferInputsHull;
			}
		}

		// Token: 0x1700081C RID: 2076
		// (get) Token: 0x06002A82 RID: 10882 RVA: 0x0004757E File Offset: 0x0004577E
		public static int maxComputeBufferInputsCompute
		{
			get
			{
				return SystemInfo.maxComputeBufferInputsCompute;
			}
		}

		// Token: 0x1700081D RID: 2077
		// (get) Token: 0x06002A83 RID: 10883 RVA: 0x00047585 File Offset: 0x00045785
		public static int maxComputeWorkGroupSize
		{
			get
			{
				return SystemInfo.maxComputeWorkGroupSize;
			}
		}

		// Token: 0x1700081E RID: 2078
		// (get) Token: 0x06002A84 RID: 10884 RVA: 0x0004758C File Offset: 0x0004578C
		public static int maxComputeWorkGroupSizeX
		{
			get
			{
				return SystemInfo.maxComputeWorkGroupSizeX;
			}
		}

		// Token: 0x1700081F RID: 2079
		// (get) Token: 0x06002A85 RID: 10885 RVA: 0x00047593 File Offset: 0x00045793
		public static int maxComputeWorkGroupSizeY
		{
			get
			{
				return SystemInfo.maxComputeWorkGroupSizeY;
			}
		}

		// Token: 0x17000820 RID: 2080
		// (get) Token: 0x06002A86 RID: 10886 RVA: 0x0004759A File Offset: 0x0004579A
		public static int maxComputeWorkGroupSizeZ
		{
			get
			{
				return SystemInfo.maxComputeWorkGroupSizeZ;
			}
		}

		// Token: 0x17000821 RID: 2081
		// (get) Token: 0x06002A87 RID: 10887 RVA: 0x000475A1 File Offset: 0x000457A1
		public static int computeSubGroupSize
		{
			get
			{
				return SystemInfo.computeSubGroupSize;
			}
		}

		// Token: 0x17000822 RID: 2082
		// (get) Token: 0x06002A88 RID: 10888 RVA: 0x000475A8 File Offset: 0x000457A8
		public static bool supportsAsyncCompute
		{
			get
			{
				return SystemInfo.supportsAsyncCompute;
			}
		}

		// Token: 0x17000823 RID: 2083
		// (get) Token: 0x06002A89 RID: 10889 RVA: 0x000475AF File Offset: 0x000457AF
		public static bool supportsGpuRecorder
		{
			get
			{
				return SystemInfo.supportsGpuRecorder;
			}
		}

		// Token: 0x17000824 RID: 2084
		// (get) Token: 0x06002A8A RID: 10890 RVA: 0x000475B6 File Offset: 0x000457B6
		public static bool supportsGraphicsFence
		{
			get
			{
				return SystemInfo.supportsGraphicsFence;
			}
		}

		// Token: 0x17000825 RID: 2085
		// (get) Token: 0x06002A8B RID: 10891 RVA: 0x000475BD File Offset: 0x000457BD
		public static bool supportsAsyncGPUReadback
		{
			get
			{
				return SystemInfo.supportsAsyncGPUReadback;
			}
		}

		// Token: 0x17000826 RID: 2086
		// (get) Token: 0x06002A8C RID: 10892 RVA: 0x000475C4 File Offset: 0x000457C4
		public static bool supportsRayTracing
		{
			get
			{
				return SystemInfo.supportsRayTracing;
			}
		}

		// Token: 0x17000827 RID: 2087
		// (get) Token: 0x06002A8D RID: 10893 RVA: 0x000475CB File Offset: 0x000457CB
		public static bool supportsSetConstantBuffer
		{
			get
			{
				return SystemInfo.supportsSetConstantBuffer;
			}
		}

		// Token: 0x17000828 RID: 2088
		// (get) Token: 0x06002A8E RID: 10894 RVA: 0x000475D2 File Offset: 0x000457D2
		public static int constantBufferOffsetAlignment
		{
			get
			{
				return SystemInfo.constantBufferOffsetAlignment;
			}
		}

		// Token: 0x17000829 RID: 2089
		// (get) Token: 0x06002A8F RID: 10895 RVA: 0x000475D9 File Offset: 0x000457D9
		public static int maxConstantBufferSize
		{
			get
			{
				return SystemInfo.maxConstantBufferSize;
			}
		}

		// Token: 0x1700082A RID: 2090
		// (get) Token: 0x06002A90 RID: 10896 RVA: 0x000475E0 File Offset: 0x000457E0
		public static long maxGraphicsBufferSize
		{
			get
			{
				return SystemInfo.maxGraphicsBufferSize;
			}
		}

		// Token: 0x1700082B RID: 2091
		// (get) Token: 0x06002A91 RID: 10897 RVA: 0x000475E7 File Offset: 0x000457E7
		public static bool hasMipMaxLevel
		{
			get
			{
				return SystemInfo.hasMipMaxLevel;
			}
		}

		// Token: 0x1700082C RID: 2092
		// (get) Token: 0x06002A92 RID: 10898 RVA: 0x000475EE File Offset: 0x000457EE
		public static bool supportsMipStreaming
		{
			get
			{
				return SystemInfo.supportsMipStreaming;
			}
		}

		// Token: 0x1700082D RID: 2093
		// (get) Token: 0x06002A93 RID: 10899 RVA: 0x000475F5 File Offset: 0x000457F5
		public static bool usesLoadStoreActions
		{
			get
			{
				return SystemInfo.usesLoadStoreActions;
			}
		}

		// Token: 0x1700082E RID: 2094
		// (get) Token: 0x06002A94 RID: 10900 RVA: 0x000475FC File Offset: 0x000457FC
		public static HDRDisplaySupportFlags hdrDisplaySupportFlags
		{
			get
			{
				return SystemInfo.hdrDisplaySupportFlags;
			}
		}

		// Token: 0x1700082F RID: 2095
		// (get) Token: 0x06002A95 RID: 10901 RVA: 0x00047603 File Offset: 0x00045803
		public static bool supportsConservativeRaster
		{
			get
			{
				return SystemInfo.supportsConservativeRaster;
			}
		}

		// Token: 0x17000830 RID: 2096
		// (get) Token: 0x06002A96 RID: 10902 RVA: 0x0004760A File Offset: 0x0004580A
		public static bool supportsMultiview
		{
			get
			{
				return SystemInfo.supportsMultiview;
			}
		}

		// Token: 0x17000831 RID: 2097
		// (get) Token: 0x06002A97 RID: 10903 RVA: 0x00047611 File Offset: 0x00045811
		public static bool supportsStoreAndResolveAction
		{
			get
			{
				return SystemInfo.supportsStoreAndResolveAction;
			}
		}

		// Token: 0x17000832 RID: 2098
		// (get) Token: 0x06002A98 RID: 10904 RVA: 0x00047618 File Offset: 0x00045818
		public static bool supportsMultisampleResolveDepth
		{
			get
			{
				return SystemInfo.supportsMultisampleResolveDepth;
			}
		}

		// Token: 0x17000833 RID: 2099
		// (get) Token: 0x06002A99 RID: 10905 RVA: 0x0004761F File Offset: 0x0004581F
		public static bool supportsMultisampleResolveStencil
		{
			get
			{
				return SystemInfo.supportsMultisampleResolveStencil;
			}
		}

		// Token: 0x17000834 RID: 2100
		// (get) Token: 0x06002A9A RID: 10906 RVA: 0x00047626 File Offset: 0x00045826
		public static bool supportsIndirectArgumentsBuffer
		{
			get
			{
				return SystemInfo.supportsIndirectArgumentsBuffer;
			}
		}

		// Token: 0x06002A9B RID: 10907 RVA: 0x00047630 File Offset: 0x00045830
		public static bool IsFormatSupported(GraphicsFormat format, FormatUsage usage)
		{
			return SystemInfo.IsFormatSupported(format, usage);
		}

		// Token: 0x06002A9C RID: 10908 RVA: 0x0004764C File Offset: 0x0004584C
		public static GraphicsFormat GetCompatibleFormat(GraphicsFormat format, FormatUsage usage)
		{
			return SystemInfo.GetCompatibleFormat(format, usage);
		}

		// Token: 0x06002A9D RID: 10909 RVA: 0x00047668 File Offset: 0x00045868
		public static GraphicsFormat GetGraphicsFormat(DefaultFormat format)
		{
			return SystemInfo.GetGraphicsFormat(format);
		}

		// Token: 0x06002A9E RID: 10910 RVA: 0x00047680 File Offset: 0x00045880
		public static int GetRenderTextureSupportedMSAASampleCount(RenderTextureDescriptor desc)
		{
			return SystemInfo.GetRenderTextureSupportedMSAASampleCount(desc);
		}

		// Token: 0x06002A9F RID: 10911 RVA: 0x00047698 File Offset: 0x00045898
		public static bool SupportsRandomWriteOnRenderTextureFormat(RenderTextureFormat format)
		{
			return SystemInfo.SupportsRandomWriteOnRenderTextureFormat(format);
		}

		// Token: 0x04000F8B RID: 3979
		public const string unsupportedIdentifier = "n/a";
	}
}
