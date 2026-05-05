using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001DF RID: 479
	[VolumeComponentMenuForRenderPipeline("Sky/HDRI Sky", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[SkyUniqueID(1)]
	public class HDRISky : SkySettings, IVersionable<HDRISky.Version>
	{
		// Token: 0x06000E7A RID: 3706 RVA: 0x00072C7D File Offset: 0x00070E7D
		protected override void OnEnable()
		{
			base.OnEnable();
			this.upperHemisphereLuxValue.overrideState = this.hdriSky.overrideState;
			this.upperHemisphereLuxColor.overrideState = this.hdriSky.overrideState;
		}

		// Token: 0x06000E7B RID: 3707 RVA: 0x00072CB4 File Offset: 0x00070EB4
		public override int GetHashCode()
		{
			return ((((((((((((((((((base.GetHashCode() * 23 + this.hdriSky.GetHashCode()) * 23 + this.flowmap.GetHashCode()) * 23 + this.distortionMode.GetHashCode()) * 23 + this.upperHemisphereOnly.GetHashCode()) * 23 + this.scrollOrientation.GetHashCode()) * 23 + this.scrollSpeed.GetHashCode()) * 23 + this.enableBackplate.GetHashCode()) * 23 + this.backplateType.GetHashCode()) * 23 + this.groundLevel.GetHashCode()) * 23 + this.scale.GetHashCode()) * 23 + this.projectionDistance.GetHashCode()) * 23 + this.plateRotation.GetHashCode()) * 23 + this.plateTexRotation.GetHashCode()) * 23 + this.plateTexOffset.GetHashCode()) * 23 + this.blendAmount.GetHashCode()) * 23 + this.shadowTint.GetHashCode()) * 23 + this.pointLightShadow.GetHashCode()) * 23 + this.dirLightShadow.GetHashCode()) * 23 + this.rectLightShadow.GetHashCode();
		}

		// Token: 0x06000E7C RID: 3708 RVA: 0x00072DE4 File Offset: 0x00070FE4
		public override bool SignificantlyDivergesFrom(SkySettings otherSettings)
		{
			HDRISky hdrisky = otherSettings as HDRISky;
			return base.SignificantlyDivergesFrom(otherSettings) || this.hdriSky.value != hdrisky.hdriSky.value;
		}

		// Token: 0x06000E7D RID: 3709 RVA: 0x00072E1E File Offset: 0x0007101E
		public override Type GetSkyRendererType()
		{
			return typeof(HDRISkyRenderer);
		}

		// Token: 0x06000E7E RID: 3710 RVA: 0x00072E2C File Offset: 0x0007102C
		private void Awake()
		{
			HDRISky.k_Migration.Migrate(this);
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000E7F RID: 3711 RVA: 0x00072E48 File Offset: 0x00071048
		// (set) Token: 0x06000E80 RID: 3712 RVA: 0x00072E50 File Offset: 0x00071050
		HDRISky.Version IVersionable<HDRISky.Version>.version
		{
			get
			{
				return this.m_SkyVersion;
			}
			set
			{
				this.m_SkyVersion = value;
			}
		}

		// Token: 0x040016CA RID: 5834
		[Tooltip("Specify the cubemap HDRP uses to render the sky.")]
		public CubemapParameter hdriSky = new CubemapParameter(null, false);

		// Token: 0x040016CB RID: 5835
		[Tooltip("Distortion mode to simulate sky movement.\nIn Scene View, requires Always Refresh to be enabled.")]
		public VolumeParameter<HDRISky.DistortionMode> distortionMode = new VolumeParameter<HDRISky.DistortionMode>();

		// Token: 0x040016CC RID: 5836
		[Tooltip("Specify the flowmap HDRP uses for sky distortion (in LatLong layout).")]
		public Texture2DParameter flowmap = new Texture2DParameter(null, false);

		// Token: 0x040016CD RID: 5837
		[Tooltip("Check this box if the flowmap covers only the upper part of the sky.")]
		public BoolParameter upperHemisphereOnly = new BoolParameter(true, false);

		// Token: 0x040016CE RID: 5838
		public WindOrientationParameter scrollOrientation = new WindOrientationParameter(0f, WindParameter.WindOverrideMode.Global, false);

		// Token: 0x040016CF RID: 5839
		public WindSpeedParameter scrollSpeed = new WindSpeedParameter(100f, WindParameter.WindOverrideMode.Global, false);

		// Token: 0x040016D0 RID: 5840
		[AdditionalProperty]
		[Tooltip("Enable or disable the backplate.")]
		public BoolParameter enableBackplate = new BoolParameter(false, false);

		// Token: 0x040016D1 RID: 5841
		[AdditionalProperty]
		[Tooltip("Backplate type.")]
		public BackplateTypeParameter backplateType = new BackplateTypeParameter(BackplateType.Disc, false);

		// Token: 0x040016D2 RID: 5842
		[AdditionalProperty]
		[Tooltip("Define the ground level of the Backplate.")]
		public FloatParameter groundLevel = new FloatParameter(0f, false);

		// Token: 0x040016D3 RID: 5843
		[AdditionalProperty]
		[Tooltip("Extent of the Backplate (if circle only the X value is considered).")]
		public Vector2Parameter scale = new Vector2Parameter(Vector2.one * 32f, false);

		// Token: 0x040016D4 RID: 5844
		[AdditionalProperty]
		[Tooltip("Backplate's projection distance to varying the cubemap projection on the plate.")]
		public MinFloatParameter projectionDistance = new MinFloatParameter(16f, 1E-07f, false);

		// Token: 0x040016D5 RID: 5845
		[AdditionalProperty]
		[Tooltip("Backplate rotation parameter for the geometry.")]
		public ClampedFloatParameter plateRotation = new ClampedFloatParameter(0f, 0f, 360f, false);

		// Token: 0x040016D6 RID: 5846
		[AdditionalProperty]
		[Tooltip("Backplate rotation parameter for the projected texture.")]
		public ClampedFloatParameter plateTexRotation = new ClampedFloatParameter(0f, 0f, 360f, false);

		// Token: 0x040016D7 RID: 5847
		[AdditionalProperty]
		[Tooltip("Backplate projection offset on the plane.")]
		public Vector2Parameter plateTexOffset = new Vector2Parameter(Vector2.zero, false);

		// Token: 0x040016D8 RID: 5848
		[AdditionalProperty]
		[Tooltip("Backplate blend parameter to blend the edge of the backplate with the background.")]
		public ClampedFloatParameter blendAmount = new ClampedFloatParameter(0f, 0f, 100f, false);

		// Token: 0x040016D9 RID: 5849
		[AdditionalProperty]
		[Tooltip("Backplate Shadow Tint projected on the plane.")]
		public ColorParameter shadowTint = new ColorParameter(Color.grey, false);

		// Token: 0x040016DA RID: 5850
		[AdditionalProperty]
		[Tooltip("Allow backplate to receive shadow from point light.")]
		public BoolParameter pointLightShadow = new BoolParameter(false, false);

		// Token: 0x040016DB RID: 5851
		[AdditionalProperty]
		[Tooltip("Allow backplate to receive shadow from directional light.")]
		public BoolParameter dirLightShadow = new BoolParameter(false, false);

		// Token: 0x040016DC RID: 5852
		[AdditionalProperty]
		[Tooltip("Allow backplate to receive shadow from Area light.")]
		public BoolParameter rectLightShadow = new BoolParameter(false, false);

		// Token: 0x040016DD RID: 5853
		protected static readonly MigrationDescription<HDRISky.Version, HDRISky> k_Migration = MigrationDescription.New<HDRISky.Version, HDRISky>(new MigrationStep<HDRISky.Version, HDRISky>[]
		{
			MigrationStep.New<HDRISky.Version, HDRISky>(HDRISky.Version.GlobalWind, delegate(HDRISky s)
			{
				float num = 0f;
				if (s.scrollDirection.overrideState)
				{
					num += s.scrollDirection.value + 90f;
				}
				if (s.rotation.overrideState)
				{
					num += s.rotation.value;
				}
				if (num != 0f)
				{
					s.scrollOrientation.Override(new WindParameter.WindParamaterValue
					{
						mode = WindParameter.WindOverrideMode.Custom,
						customValue = num % 360f
					});
				}
				if (s.m_ObsoleteScrollSpeed.overrideState)
				{
					s.scrollSpeed.Override(new WindParameter.WindParamaterValue
					{
						mode = WindParameter.WindOverrideMode.Custom,
						customValue = s.m_ObsoleteScrollSpeed.value * 200f
					});
				}
				s.distortionMode.value = ((!s.enableDistortion.value) ? HDRISky.DistortionMode.None : ((!s.procedural.value && s.procedural.overrideState) ? HDRISky.DistortionMode.Flowmap : HDRISky.DistortionMode.Procedural));
				s.distortionMode.overrideState = (s.enableDistortion.overrideState || s.procedural.overrideState);
			})
		});

		// Token: 0x040016DE RID: 5854
		[SerializeField]
		private HDRISky.Version m_SkyVersion;

		// Token: 0x040016DF RID: 5855
		[SerializeField]
		[Obsolete("For Data Migration")]
		public BoolParameter enableDistortion = new BoolParameter(false, false);

		// Token: 0x040016E0 RID: 5856
		[SerializeField]
		[Obsolete("For Data Migration")]
		public BoolParameter procedural = new BoolParameter(true, false);

		// Token: 0x040016E1 RID: 5857
		[SerializeField]
		[Obsolete("For Data Migration")]
		public ClampedFloatParameter scrollDirection = new ClampedFloatParameter(0f, 0f, 360f, false);

		// Token: 0x040016E2 RID: 5858
		[SerializeField]
		[FormerlySerializedAs("scrollSpeed")]
		[Obsolete("For Data Migration")]
		private MinFloatParameter m_ObsoleteScrollSpeed = new MinFloatParameter(1f, 0f, false);

		// Token: 0x02000429 RID: 1065
		public enum DistortionMode
		{
			// Token: 0x0400291F RID: 10527
			None,
			// Token: 0x04002920 RID: 10528
			Procedural,
			// Token: 0x04002921 RID: 10529
			Flowmap
		}

		// Token: 0x0200042A RID: 1066
		protected enum Version
		{
			// Token: 0x04002923 RID: 10531
			Initial,
			// Token: 0x04002924 RID: 10532
			GlobalWind
		}
	}
}
