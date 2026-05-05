using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200020F RID: 527
	[Serializable]
	public struct ProbeSettings
	{
		// Token: 0x06000F98 RID: 3992 RVA: 0x000793E4 File Offset: 0x000775E4
		public static ProbeSettings NewDefault()
		{
			ProbeSettings probeSettings = new ProbeSettings
			{
				type = ProbeSettings.ProbeType.ReflectionProbe,
				realtimeMode = ProbeSettings.RealtimeMode.EveryFrame,
				timeSlicing = false,
				mode = ProbeSettings.Mode.Baked,
				cameraSettings = CameraSettings.NewDefault(),
				influence = null,
				lighting = ProbeSettings.Lighting.NewDefault(),
				proxy = null,
				proxySettings = ProbeSettings.ProxySettings.NewDefault(),
				frustum = ProbeSettings.Frustum.NewDefault(),
				resolutionScalable = new ProbeSettings.PlanarReflectionAtlasResolutionScalableSettingValue(),
				cubeResolution = new ProbeSettings.CubeReflectionResolutionScalableSettingValue(),
				roughReflections = true,
				distanceBasedRoughness = false
			};
			probeSettings.resolutionScalable.@override = PlanarReflectionAtlasResolution.Resolution512;
			probeSettings.cubeResolution.@override = CubeReflectionResolution.CubeReflectionResolution128;
			return probeSettings;
		}

		// Token: 0x06000F99 RID: 3993 RVA: 0x000794A4 File Offset: 0x000776A4
		public Hash128 ComputeHash()
		{
			Hash128 result = default(Hash128);
			Hash128 hash = default(Hash128);
			HashUtilities.ComputeHash128<ProbeSettings.ProbeType>(ref this.type, ref result);
			HashUtilities.ComputeHash128<ProbeSettings.Mode>(ref this.mode, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<ProbeSettings.Lighting>(ref this.lighting, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<ProbeSettings.ProxySettings>(ref this.proxySettings, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			hash = this.cameraSettings.GetHash();
			HashUtilities.AppendHash(ref hash, ref result);
			CubeReflectionResolution cubeReflectionResolution = CubeReflectionResolution.CubeReflectionResolution128;
			HDRenderPipeline hdrenderPipeline = RenderPipelineManager.currentPipeline as HDRenderPipeline;
			if (hdrenderPipeline != null)
			{
				cubeReflectionResolution = this.cubeResolution.Value(hdrenderPipeline.asset.currentPlatformRenderPipelineSettings.cubeReflectionResolution);
			}
			HashUtilities.ComputeHash128<CubeReflectionResolution>(ref cubeReflectionResolution, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			if (this.influence != null)
			{
				hash = this.influence.ComputeHash();
				HashUtilities.AppendHash(ref hash, ref result);
			}
			if (this.proxy != null)
			{
				hash = this.proxy.ComputeHash();
				HashUtilities.AppendHash(ref hash, ref result);
			}
			return result;
		}

		// Token: 0x04001829 RID: 6185
		internal const CubeReflectionResolution k_DefaultCubeResolution = CubeReflectionResolution.CubeReflectionResolution128;

		// Token: 0x0400182A RID: 6186
		[Obsolete("Since 2019.3, use ProbeSettings.NewDefault() instead.")]
		public static ProbeSettings @default;

		// Token: 0x0400182B RID: 6187
		public ProbeSettings.Frustum frustum;

		// Token: 0x0400182C RID: 6188
		public ProbeSettings.ProbeType type;

		// Token: 0x0400182D RID: 6189
		public ProbeSettings.Mode mode;

		// Token: 0x0400182E RID: 6190
		public ProbeSettings.RealtimeMode realtimeMode;

		// Token: 0x0400182F RID: 6191
		public bool timeSlicing;

		// Token: 0x04001830 RID: 6192
		public ProbeSettings.Lighting lighting;

		// Token: 0x04001831 RID: 6193
		public InfluenceVolume influence;

		// Token: 0x04001832 RID: 6194
		public ProxyVolume proxy;

		// Token: 0x04001833 RID: 6195
		public ProbeSettings.ProxySettings proxySettings;

		// Token: 0x04001834 RID: 6196
		public ProbeSettings.PlanarReflectionAtlasResolutionScalableSettingValue resolutionScalable;

		// Token: 0x04001835 RID: 6197
		[SerializeField]
		internal PlanarReflectionAtlasResolution resolution;

		// Token: 0x04001836 RID: 6198
		[SerializeField]
		public ProbeSettings.CubeReflectionResolutionScalableSettingValue cubeResolution;

		// Token: 0x04001837 RID: 6199
		[FormerlySerializedAs("camera")]
		public CameraSettings cameraSettings;

		// Token: 0x04001838 RID: 6200
		public bool roughReflections;

		// Token: 0x04001839 RID: 6201
		public bool distanceBasedRoughness;

		// Token: 0x02000440 RID: 1088
		public enum ProbeType
		{
			// Token: 0x04002984 RID: 10628
			ReflectionProbe,
			// Token: 0x04002985 RID: 10629
			PlanarProbe
		}

		// Token: 0x02000441 RID: 1089
		public enum Mode
		{
			// Token: 0x04002987 RID: 10631
			Baked,
			// Token: 0x04002988 RID: 10632
			Realtime,
			// Token: 0x04002989 RID: 10633
			Custom
		}

		// Token: 0x02000442 RID: 1090
		public enum RealtimeMode
		{
			// Token: 0x0400298B RID: 10635
			EveryFrame,
			// Token: 0x0400298C RID: 10636
			OnEnable,
			// Token: 0x0400298D RID: 10637
			OnDemand
		}

		// Token: 0x02000443 RID: 1091
		[Serializable]
		public struct Lighting
		{
			// Token: 0x06001446 RID: 5190 RVA: 0x0009946C File Offset: 0x0009766C
			public static ProbeSettings.Lighting NewDefault()
			{
				return new ProbeSettings.Lighting
				{
					multiplier = 1f,
					weight = 1f,
					lightLayer = LightLayerEnum.LightLayerDefault,
					fadeDistance = 10000f,
					rangeCompressionFactor = 1f
				};
			}

			// Token: 0x0400298E RID: 10638
			[Obsolete("Since 2019.3, use Lighting.NewDefault() instead.")]
			public static readonly ProbeSettings.Lighting @default;

			// Token: 0x0400298F RID: 10639
			public float multiplier;

			// Token: 0x04002990 RID: 10640
			[Range(0f, 1f)]
			public float weight;

			// Token: 0x04002991 RID: 10641
			public LightLayerEnum lightLayer;

			// Token: 0x04002992 RID: 10642
			public float fadeDistance;

			// Token: 0x04002993 RID: 10643
			[Min(1E-06f)]
			public float rangeCompressionFactor;
		}

		// Token: 0x02000444 RID: 1092
		[Serializable]
		public struct ProxySettings
		{
			// Token: 0x06001448 RID: 5192 RVA: 0x000994BC File Offset: 0x000976BC
			public static ProbeSettings.ProxySettings NewDefault()
			{
				return new ProbeSettings.ProxySettings
				{
					capturePositionProxySpace = Vector3.zero,
					captureRotationProxySpace = Quaternion.identity,
					useInfluenceVolumeAsProxyVolume = true
				};
			}

			// Token: 0x04002994 RID: 10644
			[Obsolete("Since 2019.3, use ProxySettings.NewDefault() instead.")]
			public static readonly ProbeSettings.ProxySettings @default;

			// Token: 0x04002995 RID: 10645
			public bool useInfluenceVolumeAsProxyVolume;

			// Token: 0x04002996 RID: 10646
			public Vector3 capturePositionProxySpace;

			// Token: 0x04002997 RID: 10647
			public Quaternion captureRotationProxySpace;

			// Token: 0x04002998 RID: 10648
			public Vector3 mirrorPositionProxySpace;

			// Token: 0x04002999 RID: 10649
			public Quaternion mirrorRotationProxySpace;
		}

		// Token: 0x02000445 RID: 1093
		[Serializable]
		public struct Frustum
		{
			// Token: 0x0600144A RID: 5194 RVA: 0x000994F4 File Offset: 0x000976F4
			public static ProbeSettings.Frustum NewDefault()
			{
				return new ProbeSettings.Frustum
				{
					fieldOfViewMode = ProbeSettings.Frustum.FOVMode.Viewer,
					fixedValue = 90f,
					automaticScale = 1f,
					viewerScale = 1f
				};
			}

			// Token: 0x0400299A RID: 10650
			[Obsolete("Since 2019.3, use Frustum.NewDefault() instead.")]
			public static readonly ProbeSettings.Frustum @default;

			// Token: 0x0400299B RID: 10651
			public ProbeSettings.Frustum.FOVMode fieldOfViewMode;

			// Token: 0x0400299C RID: 10652
			[Range(0f, 179f)]
			public float fixedValue;

			// Token: 0x0400299D RID: 10653
			[Min(0f)]
			public float automaticScale;

			// Token: 0x0400299E RID: 10654
			[Min(0f)]
			public float viewerScale;

			// Token: 0x0200047F RID: 1151
			public enum FOVMode
			{
				// Token: 0x04002A22 RID: 10786
				Fixed,
				// Token: 0x04002A23 RID: 10787
				Viewer,
				// Token: 0x04002A24 RID: 10788
				Automatic
			}
		}

		// Token: 0x02000446 RID: 1094
		[Serializable]
		public class CubeReflectionResolutionScalableSettingValue : ScalableSettingValue<CubeReflectionResolution>
		{
		}

		// Token: 0x02000447 RID: 1095
		[Serializable]
		public class PlanarReflectionAtlasResolutionScalableSettingValue : ScalableSettingValue<PlanarReflectionAtlasResolution>
		{
		}
	}
}
