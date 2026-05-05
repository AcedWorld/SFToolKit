using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001D7 RID: 471
	[VolumeComponentMenuForRenderPipeline("Sky/Cloud Layer", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[CloudUniqueID(1)]
	public class CloudLayer : CloudSettings
	{
		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000E4F RID: 3663 RVA: 0x00071DF5 File Offset: 0x0006FFF5
		internal int NumLayers
		{
			get
			{
				if (!(this.layers == CloudMapMode.Single))
				{
					return 2;
				}
				return 1;
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000E50 RID: 3664 RVA: 0x00071E08 File Offset: 0x00070008
		internal bool CastShadows
		{
			get
			{
				return this.layerA.castShadows.value || (this.layers.value == CloudMapMode.Double && this.layerB.castShadows.value);
			}
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x00071E3E File Offset: 0x0007003E
		private Vector3Int CastToInt3(Vector3 vec)
		{
			return new Vector3Int((int)vec.x, (int)vec.y, (int)vec.z);
		}

		// Token: 0x06000E52 RID: 3666 RVA: 0x00071E5C File Offset: 0x0007005C
		internal int GetBakingHashCode(Light sunLight)
		{
			int num = 17;
			bool flag = this.layerA.lighting.value;
			bool flag2 = sunLight != null && this.layerA.castShadows.value;
			num = num * 23 + this.upperHemisphereOnly.GetHashCode();
			num = num * 23 + this.layers.GetHashCode();
			num = num * 23 + this.resolution.GetHashCode();
			num = num * 23 + this.layerA.GetBakingHashCode();
			if (this.layers.value == CloudMapMode.Double)
			{
				num = num * 23 + this.layerB.GetBakingHashCode();
				flag |= this.layerB.lighting.value;
				flag2 |= this.layerB.castShadows.value;
			}
			if (flag && sunLight != null)
			{
				num = num * 23 + this.CastToInt3(sunLight.transform.rotation.eulerAngles).GetHashCode();
			}
			if (flag2)
			{
				num = num * 23 + this.shadowResolution.GetHashCode();
			}
			return num;
		}

		// Token: 0x06000E53 RID: 3667 RVA: 0x00071F74 File Offset: 0x00070174
		public override int GetHashCode()
		{
			int num = 17;
			num = num * 23 + this.opacity.GetHashCode();
			num = num * 23 + this.upperHemisphereOnly.GetHashCode();
			num = num * 23 + this.layers.GetHashCode();
			num = num * 23 + this.resolution.GetHashCode();
			num = num * 23 + this.layerA.GetHashCode();
			if (this.layers.value == CloudMapMode.Double)
			{
				num = num * 23 + this.layerB.GetHashCode();
			}
			return num;
		}

		// Token: 0x06000E54 RID: 3668 RVA: 0x00071FF9 File Offset: 0x000701F9
		public override Type GetCloudRendererType()
		{
			return typeof(CloudLayerRenderer);
		}

		// Token: 0x06000E55 RID: 3669 RVA: 0x00072008 File Offset: 0x00070208
		private static void Init()
		{
			HDRenderPipelineGlobalSettings instance = HDRenderPipelineGlobalSettings.instance;
			if (instance != null)
			{
				HDRenderPipelineRuntimeResources renderPipelineResources = instance.renderPipelineResources;
				CloudLayer.CloudMap.s_DefaultTexture = ((renderPipelineResources != null) ? renderPipelineResources.textures.defaultCloudMap : null);
			}
		}

		// Token: 0x0400169B RID: 5787
		[Tooltip("Controls the global opacity of the cloud layer.")]
		public ClampedFloatParameter opacity = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x0400169C RID: 5788
		[AdditionalProperty]
		[Tooltip("Check this box if the cloud layer covers only the upper part of the sky.")]
		public BoolParameter upperHemisphereOnly = new BoolParameter(true, false);

		// Token: 0x0400169D RID: 5789
		public VolumeParameter<CloudMapMode> layers = new VolumeParameter<CloudMapMode>();

		// Token: 0x0400169E RID: 5790
		[AdditionalProperty]
		[Tooltip("Specifies the resolution of the texture HDRP uses to represent the clouds.")]
		public CloudLayerEnumParameter<CloudResolution> resolution = new CloudLayerEnumParameter<CloudResolution>(CloudResolution.CloudResolution1024, false);

		// Token: 0x0400169F RID: 5791
		[Header("Cloud Shadows")]
		[Tooltip("Controls the opacity of the cloud shadows.")]
		public MinFloatParameter shadowMultiplier = new MinFloatParameter(1f, 0f, false);

		// Token: 0x040016A0 RID: 5792
		[Tooltip("Controls the tint of the cloud shadows.")]
		public ColorParameter shadowTint = new ColorParameter(Color.black, false, false, true, false);

		// Token: 0x040016A1 RID: 5793
		[AdditionalProperty]
		[Tooltip("Specifies the resolution of the texture HDRP uses to represent the cloud shadows.")]
		public CloudLayerEnumParameter<CloudShadowsResolution> shadowResolution = new CloudLayerEnumParameter<CloudShadowsResolution>(CloudShadowsResolution.Medium, false);

		// Token: 0x040016A2 RID: 5794
		[Tooltip("Specifies the size of the projected shadows.")]
		public MinFloatParameter shadowSize = new MinFloatParameter(500f, 0f, false);

		// Token: 0x040016A3 RID: 5795
		public CloudLayer.CloudMap layerA = new CloudLayer.CloudMap();

		// Token: 0x040016A4 RID: 5796
		public CloudLayer.CloudMap layerB = new CloudLayer.CloudMap();

		// Token: 0x02000426 RID: 1062
		[Serializable]
		public class CloudMap
		{
			// Token: 0x1700029F RID: 671
			// (get) Token: 0x06001406 RID: 5126 RVA: 0x00097978 File Offset: 0x00095B78
			internal int NumSteps
			{
				get
				{
					if (!this.lighting.value)
					{
						return 0;
					}
					return this.steps.value;
				}
			}

			// Token: 0x170002A0 RID: 672
			// (get) Token: 0x06001407 RID: 5127 RVA: 0x00097994 File Offset: 0x00095B94
			internal Vector4 Opacities
			{
				get
				{
					return new Vector4(this.opacityR.value, this.opacityG.value, this.opacityB.value, this.opacityA.value);
				}
			}

			// Token: 0x170002A1 RID: 673
			// (get) Token: 0x06001408 RID: 5128 RVA: 0x000979C7 File Offset: 0x00095BC7
			internal Color Color
			{
				get
				{
					return this.tint.value * ColorUtils.ConvertEV100ToExposure(-this.exposure.value);
				}
			}

			// Token: 0x06001409 RID: 5129 RVA: 0x000979EC File Offset: 0x00095BEC
			internal Vector4 GetRenderingParameters(HDCamera camera)
			{
				float f = 0.017453292f * this.scrollOrientation.GetValue(camera);
				return new Vector3(-Mathf.Cos(f), -Mathf.Sin(f), this.scrollFactor);
			}

			// Token: 0x0600140A RID: 5130 RVA: 0x00097A2C File Offset: 0x00095C2C
			internal ValueTuple<Vector4, Vector4> GetBakingParameters()
			{
				Vector4 item = new Vector4(this.rotation.value / 360f, (float)this.NumSteps, this.thickness.value * 0.095f + 0.005f, this.altitude.value);
				return new ValueTuple<Vector4, Vector4>(this.Opacities, item);
			}

			// Token: 0x0600140B RID: 5131 RVA: 0x00097A88 File Offset: 0x00095C88
			internal int GetBakingHashCode()
			{
				int num = 17;
				num = num * 23 + this.cloudMap.GetHashCode();
				num = num * 23 + this.opacityR.GetHashCode();
				num = num * 23 + this.opacityG.GetHashCode();
				num = num * 23 + this.opacityB.GetHashCode();
				num = num * 23 + this.opacityA.GetHashCode();
				num = num * 23 + this.rotation.GetHashCode();
				num = num * 23 + this.castShadows.GetHashCode();
				if (this.lighting.value)
				{
					num = num * 23 + this.lighting.GetHashCode();
					num = num * 23 + this.steps.GetHashCode();
					num = num * 23 + this.altitude.GetHashCode();
					num = num * 23 + this.thickness.GetHashCode();
				}
				return num;
			}

			// Token: 0x0600140C RID: 5132 RVA: 0x00097B64 File Offset: 0x00095D64
			public override int GetHashCode()
			{
				return (((((((((((((((((17 * 23 + this.cloudMap.GetHashCode()) * 23 + this.opacityR.GetHashCode()) * 23 + this.opacityG.GetHashCode()) * 23 + this.opacityB.GetHashCode()) * 23 + this.opacityA.GetHashCode()) * 23 + this.altitude.GetHashCode()) * 23 + this.rotation.GetHashCode()) * 23 + this.tint.GetHashCode()) * 23 + this.exposure.GetHashCode()) * 23 + this.distortionMode.GetHashCode()) * 23 + this.scrollOrientation.GetHashCode()) * 23 + this.scrollSpeed.GetHashCode()) * 23 + this.flowmap.GetHashCode()) * 23 + this.lighting.GetHashCode()) * 23 + this.steps.GetHashCode()) * 23 + this.thickness.GetHashCode()) * 23 + this.ambientProbeDimmer.GetHashCode()) * 23 + this.castShadows.GetHashCode();
			}

			// Token: 0x04002900 RID: 10496
			internal static Texture s_DefaultTexture;

			// Token: 0x04002901 RID: 10497
			[Tooltip("Specify the texture HDRP uses to render the clouds (in LatLong layout).")]
			public Texture2DParameter cloudMap = new Texture2DParameter(CloudLayer.CloudMap.s_DefaultTexture, false);

			// Token: 0x04002902 RID: 10498
			[Tooltip("Opacity multiplier for the red channel.")]
			public ClampedFloatParameter opacityR = new ClampedFloatParameter(1f, 0f, 1f, false);

			// Token: 0x04002903 RID: 10499
			[Tooltip("Opacity multiplier for the green channel.")]
			public ClampedFloatParameter opacityG = new ClampedFloatParameter(0f, 0f, 1f, false);

			// Token: 0x04002904 RID: 10500
			[Tooltip("Opacity multiplier for the blue channel.")]
			public ClampedFloatParameter opacityB = new ClampedFloatParameter(0f, 0f, 1f, false);

			// Token: 0x04002905 RID: 10501
			[Tooltip("Opacity multiplier for the alpha channel.")]
			public ClampedFloatParameter opacityA = new ClampedFloatParameter(0f, 0f, 1f, false);

			// Token: 0x04002906 RID: 10502
			[Tooltip("Altitude of the bottom of the cloud layer in meters.")]
			public MinFloatParameter altitude = new MinFloatParameter(2000f, 0f, false);

			// Token: 0x04002907 RID: 10503
			[Tooltip("Sets the rotation of the clouds (in degrees).")]
			public ClampedFloatParameter rotation = new ClampedFloatParameter(0f, 0f, 360f, false);

			// Token: 0x04002908 RID: 10504
			[Tooltip("Specifies the color HDRP uses to tint the clouds.")]
			public ColorParameter tint = new ColorParameter(Color.white, false, false, true, false);

			// Token: 0x04002909 RID: 10505
			[InspectorName("Exposure Compensation")]
			[Tooltip("Sets the exposure compensation of the clouds in EV.")]
			public FloatParameter exposure = new FloatParameter(0f, false);

			// Token: 0x0400290A RID: 10506
			[InspectorName("Wind")]
			[Tooltip("Distortion mode used to simulate cloud movement.\nIn Scene View, requires Always Refresh to be enabled.")]
			public VolumeParameter<CloudDistortionMode> distortionMode = new VolumeParameter<CloudDistortionMode>();

			// Token: 0x0400290B RID: 10507
			[InspectorName("Orientation")]
			[Tooltip("Controls the orientation of the wind relative to the X world vector.\nThis value can be relative to the Global Wind Orientation defined in the Visual Environment.")]
			public WindOrientationParameter scrollOrientation = new WindOrientationParameter(0f, WindParameter.WindOverrideMode.Global, false);

			// Token: 0x0400290C RID: 10508
			[InspectorName("Speed")]
			[Tooltip("Sets the wind speed in kilometers per hour.\nThis value can be relative to the Global Wind Speed defined in the Visual Environment.")]
			public WindSpeedParameter scrollSpeed = new WindSpeedParameter(100f, WindParameter.WindOverrideMode.Global, false);

			// Token: 0x0400290D RID: 10509
			[Tooltip("Specify the flowmap HDRP uses for cloud distortion (in LatLong layout).")]
			public Texture2DParameter flowmap = new Texture2DParameter(null, false);

			// Token: 0x0400290E RID: 10510
			[InspectorName("Raymarching")]
			[Tooltip("Simulates cloud self-shadowing using raymarching.")]
			public BoolParameter lighting = new BoolParameter(true, false);

			// Token: 0x0400290F RID: 10511
			[Tooltip("Number of raymarching steps.")]
			public ClampedIntParameter steps = new ClampedIntParameter(6, 2, 32, false);

			// Token: 0x04002910 RID: 10512
			[InspectorName("Density")]
			[Tooltip("Density of the cloud layer.")]
			public ClampedFloatParameter thickness = new ClampedFloatParameter(0.5f, 0f, 1f, false);

			// Token: 0x04002911 RID: 10513
			[Tooltip("Controls the influence of the ambient probe on the cloud layer volume. A lower value will suppress the ambient light and produce darker clouds overall.")]
			public ClampedFloatParameter ambientProbeDimmer = new ClampedFloatParameter(1f, 0f, 1f, false);

			// Token: 0x04002912 RID: 10514
			[Tooltip("Projects a portion of the clouds around the sun light to simulate cloud shadows. This will override the cookie of your directional light.")]
			public BoolParameter castShadows = new BoolParameter(false, false);

			// Token: 0x04002913 RID: 10515
			internal float scrollFactor;
		}
	}
}
