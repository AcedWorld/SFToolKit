using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001E3 RID: 483
	[VolumeComponentMenuForRenderPipeline("Sky/Physically Based Sky", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[SkyUniqueID(4)]
	public class PhysicallyBasedSky : SkySettings, IVersionable<PhysicallyBasedSky.Version>
	{
		// Token: 0x06000E8E RID: 3726 RVA: 0x00073683 File Offset: 0x00071883
		internal static float ScaleHeightFromLayerDepth(float d)
		{
			return d * 0.144765f;
		}

		// Token: 0x06000E8F RID: 3727 RVA: 0x0007368C File Offset: 0x0007188C
		internal static float LayerDepthFromScaleHeight(float H)
		{
			return H / 0.144765f;
		}

		// Token: 0x06000E90 RID: 3728 RVA: 0x00073698 File Offset: 0x00071898
		internal static float ExtinctionFromZenithOpacityAndScaleHeight(float alpha, float H)
		{
			float num = Mathf.Min(alpha, 0.999999f);
			return -Mathf.Log(1f - num, 2.7182817f) / H;
		}

		// Token: 0x06000E91 RID: 3729 RVA: 0x000736C8 File Offset: 0x000718C8
		internal static float ZenithOpacityFromExtinctionAndScaleHeight(float ext, float H)
		{
			float num = ext * H;
			return 1f - Mathf.Exp(-num);
		}

		// Token: 0x06000E92 RID: 3730 RVA: 0x000736E6 File Offset: 0x000718E6
		internal float GetAirScaleHeight()
		{
			if (this.type.value != PhysicallyBasedSkyModel.Custom)
			{
				return 8000f;
			}
			return PhysicallyBasedSky.ScaleHeightFromLayerDepth(this.airMaximumAltitude.value);
		}

		// Token: 0x06000E93 RID: 3731 RVA: 0x0007370C File Offset: 0x0007190C
		internal float GetMaximumAltitude()
		{
			if (this.type.value == PhysicallyBasedSkyModel.Custom)
			{
				return Mathf.Max(this.airMaximumAltitude.value, this.aerosolMaximumAltitude.value);
			}
			float b = (this.type.value == PhysicallyBasedSkyModel.EarthSimple) ? PhysicallyBasedSky.k_DefaultAerosolMaximumAltitude : this.aerosolMaximumAltitude.value;
			return Mathf.Max(PhysicallyBasedSky.LayerDepthFromScaleHeight(8000f), b);
		}

		// Token: 0x06000E94 RID: 3732 RVA: 0x00073773 File Offset: 0x00071973
		internal float GetPlanetaryRadius()
		{
			if (this.type.value != PhysicallyBasedSkyModel.Custom)
			{
				return 6378100f;
			}
			return this.planetaryRadius.value;
		}

		// Token: 0x06000E95 RID: 3733 RVA: 0x00073794 File Offset: 0x00071994
		internal Vector3 GetPlanetCenterPosition(Vector3 camPosWS)
		{
			if (this.sphericalMode.value && this.type.value != PhysicallyBasedSkyModel.EarthSimple)
			{
				return this.planetCenterPosition.value;
			}
			float num = this.GetPlanetaryRadius();
			float value = this.seaLevel.value;
			return new Vector3(camPosWS.x, -num + value, camPosWS.z);
		}

		// Token: 0x06000E96 RID: 3734 RVA: 0x000737F0 File Offset: 0x000719F0
		internal Vector3 GetAirExtinctionCoefficient()
		{
			Vector3 result = default(Vector3);
			if (this.type.value != PhysicallyBasedSkyModel.Custom)
			{
				result.x = 5.8E-06f;
				result.y = 1.35E-05f;
				result.z = 3.3099997E-05f;
			}
			else
			{
				result.x = PhysicallyBasedSky.ExtinctionFromZenithOpacityAndScaleHeight(this.airDensityR.value, this.GetAirScaleHeight());
				result.y = PhysicallyBasedSky.ExtinctionFromZenithOpacityAndScaleHeight(this.airDensityG.value, this.GetAirScaleHeight());
				result.z = PhysicallyBasedSky.ExtinctionFromZenithOpacityAndScaleHeight(this.airDensityB.value, this.GetAirScaleHeight());
			}
			return result;
		}

		// Token: 0x06000E97 RID: 3735 RVA: 0x00073894 File Offset: 0x00071A94
		internal Vector3 GetAirAlbedo()
		{
			Vector3 result = default(Vector3);
			if (this.type.value != PhysicallyBasedSkyModel.Custom)
			{
				result.x = 0.9f;
				result.y = 0.9f;
				result.z = 1f;
			}
			else
			{
				result.x = this.airTint.value.r;
				result.y = this.airTint.value.g;
				result.z = this.airTint.value.b;
			}
			return result;
		}

		// Token: 0x06000E98 RID: 3736 RVA: 0x00073924 File Offset: 0x00071B24
		internal Vector3 GetAirScatteringCoefficient()
		{
			Vector3 airExtinctionCoefficient = this.GetAirExtinctionCoefficient();
			Vector3 airAlbedo = this.GetAirAlbedo();
			return new Vector3(airExtinctionCoefficient.x * airAlbedo.x, airExtinctionCoefficient.y * airAlbedo.y, airExtinctionCoefficient.z * airAlbedo.z);
		}

		// Token: 0x06000E99 RID: 3737 RVA: 0x0007396B File Offset: 0x00071B6B
		internal float GetAerosolScaleHeight()
		{
			if (this.type.value == PhysicallyBasedSkyModel.EarthSimple)
			{
				return 1200f;
			}
			return PhysicallyBasedSky.ScaleHeightFromLayerDepth(this.aerosolMaximumAltitude.value);
		}

		// Token: 0x06000E9A RID: 3738 RVA: 0x00073990 File Offset: 0x00071B90
		internal float GetAerosolAnisotropy()
		{
			if (this.type.value == PhysicallyBasedSkyModel.EarthSimple)
			{
				return 0f;
			}
			return this.aerosolAnisotropy.value;
		}

		// Token: 0x06000E9B RID: 3739 RVA: 0x000739B0 File Offset: 0x00071BB0
		internal float GetAerosolExtinctionCoefficient()
		{
			return PhysicallyBasedSky.ExtinctionFromZenithOpacityAndScaleHeight(this.aerosolDensity.value, this.GetAerosolScaleHeight());
		}

		// Token: 0x06000E9C RID: 3740 RVA: 0x000739C8 File Offset: 0x00071BC8
		internal Vector3 GetAerosolScatteringCoefficient()
		{
			float aerosolExtinctionCoefficient = this.GetAerosolExtinctionCoefficient();
			return new Vector3(aerosolExtinctionCoefficient * this.aerosolTint.value.r, aerosolExtinctionCoefficient * this.aerosolTint.value.g, aerosolExtinctionCoefficient * this.aerosolTint.value.b);
		}

		// Token: 0x06000E9D RID: 3741 RVA: 0x00073A18 File Offset: 0x00071C18
		private PhysicallyBasedSky()
		{
			base.displayName = "Physically Based Sky";
		}

		// Token: 0x06000E9E RID: 3742 RVA: 0x00073D08 File Offset: 0x00071F08
		internal int GetPrecomputationHashCode()
		{
			return (((((((((((base.GetHashCode() * 23 + this.type.GetHashCode()) * 23 + this.planetaryRadius.GetHashCode()) * 23 + this.groundTint.GetHashCode()) * 23 + this.airMaximumAltitude.GetHashCode()) * 23 + this.airDensityR.GetHashCode()) * 23 + this.airDensityG.GetHashCode()) * 23 + this.airDensityB.GetHashCode()) * 23 + this.airTint.GetHashCode()) * 23 + this.aerosolMaximumAltitude.GetHashCode()) * 23 + this.aerosolDensity.GetHashCode()) * 23 + this.aerosolTint.GetHashCode()) * 23 + this.aerosolAnisotropy.GetHashCode();
		}

		// Token: 0x06000E9F RID: 3743 RVA: 0x00073DD0 File Offset: 0x00071FD0
		public override int GetHashCode(Camera camera)
		{
			int hashCode = this.GetHashCode();
			Vector3 position = camera.transform.position;
			float num = Vector3.Distance(position, this.GetPlanetCenterPosition(position));
			float num2 = this.GetPlanetaryRadius();
			bool flag = num > num2;
			return hashCode * 23 + flag.GetHashCode();
		}

		// Token: 0x06000EA0 RID: 3744 RVA: 0x00073E14 File Offset: 0x00072014
		public override int GetHashCode()
		{
			int num = this.GetPrecomputationHashCode();
			num = num * 23 + this.sphericalMode.GetHashCode();
			num = num * 23 + this.seaLevel.GetHashCode();
			num = num * 23 + this.planetCenterPosition.GetHashCode();
			num = num * 23 + this.planetRotation.GetHashCode();
			if (this.groundColorTexture.value != null)
			{
				num = num * 23 + this.groundColorTexture.GetHashCode();
			}
			if (this.groundEmissionTexture.value != null)
			{
				num = num * 23 + this.groundEmissionTexture.GetHashCode();
			}
			num = num * 23 + this.groundEmissionMultiplier.GetHashCode();
			num = num * 23 + this.spaceRotation.GetHashCode();
			if (this.spaceEmissionTexture.value != null)
			{
				num = num * 23 + this.spaceEmissionTexture.GetHashCode();
			}
			num = num * 23 + this.spaceEmissionMultiplier.GetHashCode();
			num = num * 23 + this.colorSaturation.GetHashCode();
			num = num * 23 + this.alphaSaturation.GetHashCode();
			num = num * 23 + this.alphaMultiplier.GetHashCode();
			num = num * 23 + this.horizonTint.GetHashCode();
			num = num * 23 + this.zenithTint.GetHashCode();
			return num * 23 + this.horizonZenithShift.GetHashCode();
		}

		// Token: 0x06000EA1 RID: 3745 RVA: 0x00073F72 File Offset: 0x00072172
		private static float Saturate(float x)
		{
			return Mathf.Max(0f, Mathf.Min(x, 1f));
		}

		// Token: 0x06000EA2 RID: 3746 RVA: 0x00073F89 File Offset: 0x00072189
		private static float Rcp(float x)
		{
			return 1f / x;
		}

		// Token: 0x06000EA3 RID: 3747 RVA: 0x00073F92 File Offset: 0x00072192
		private static float Rsqrt(float x)
		{
			return PhysicallyBasedSky.Rcp(Mathf.Sqrt(x));
		}

		// Token: 0x06000EA4 RID: 3748 RVA: 0x00073FA0 File Offset: 0x000721A0
		private static float ComputeCosineOfHorizonAngle(float r, float R)
		{
			float num = R * PhysicallyBasedSky.Rcp(r);
			return -Mathf.Sqrt(PhysicallyBasedSky.Saturate(1f - num * num));
		}

		// Token: 0x06000EA5 RID: 3749 RVA: 0x00073FCC File Offset: 0x000721CC
		private static float ChapmanUpperApprox(float z, float cosTheta)
		{
			float num = 0.761643f * (1f + 2f * z - cosTheta * cosTheta * z);
			float x = cosTheta * z + Mathf.Sqrt(z * (1.47721f + 0.273828f * (cosTheta * cosTheta * z)));
			return 0.5f * cosTheta + num * PhysicallyBasedSky.Rcp(x);
		}

		// Token: 0x06000EA6 RID: 3750 RVA: 0x00074024 File Offset: 0x00072224
		private static float ChapmanHorizontal(float z)
		{
			float num = PhysicallyBasedSky.Rsqrt(z);
			float num2 = z * num;
			return 0.626657f * (num + 2f * num2);
		}

		// Token: 0x06000EA7 RID: 3751 RVA: 0x0007404C File Offset: 0x0007224C
		private static Vector3 ComputeAtmosphericOpticalDepth(float airScaleHeight, float aerosolScaleHeight, in Vector3 airExtinctionCoefficient, float aerosolExtinctionCoefficient, float R, float r, float cosTheta, bool alwaysAboveHorizon = false)
		{
			Vector2 vector = new Vector2(airScaleHeight, aerosolScaleHeight);
			Vector2 a = new Vector2(PhysicallyBasedSky.Rcp(vector.x), PhysicallyBasedSky.Rcp(vector.y));
			Vector2 vector2 = r * a;
			Vector2 vector3 = R * a;
			float num = PhysicallyBasedSky.ComputeCosineOfHorizonAngle(r, R);
			float num2 = Mathf.Sqrt(PhysicallyBasedSky.Saturate(1f - cosTheta * cosTheta));
			Vector2 vector4;
			vector4.x = PhysicallyBasedSky.ChapmanUpperApprox(vector2.x, Mathf.Abs(cosTheta)) * Mathf.Exp(vector3.x - vector2.x);
			vector4.y = PhysicallyBasedSky.ChapmanUpperApprox(vector2.y, Mathf.Abs(cosTheta)) * Mathf.Exp(vector3.y - vector2.y);
			if (!alwaysAboveHorizon && cosTheta < num)
			{
				float num3 = r / R * num2;
				float cosTheta2 = Mathf.Sqrt(PhysicallyBasedSky.Saturate(1f - num3 * num3));
				Vector2 a2;
				a2.x = PhysicallyBasedSky.ChapmanUpperApprox(vector3.x, cosTheta2);
				a2.y = PhysicallyBasedSky.ChapmanUpperApprox(vector3.y, cosTheta2);
				vector4 = a2 - vector4;
			}
			else if (cosTheta < 0f)
			{
				Vector2 vector5 = vector2 * num2;
				Vector2 b = new Vector2(Mathf.Exp(vector3.x - vector5.x), Mathf.Exp(vector3.x - vector5.x));
				Vector2 a3;
				a3.x = 2f * PhysicallyBasedSky.ChapmanHorizontal(vector5.x);
				a3.y = 2f * PhysicallyBasedSky.ChapmanHorizontal(vector5.y);
				vector4 = a3 * b - vector4;
			}
			Vector2 vector6 = vector4 * vector;
			Vector3 vector7 = airExtinctionCoefficient;
			return new Vector3(vector6.x * vector7.x + vector6.y * aerosolExtinctionCoefficient, vector6.x * vector7.y + vector6.y * aerosolExtinctionCoefficient, vector6.x * vector7.z + vector6.y * aerosolExtinctionCoefficient);
		}

		// Token: 0x06000EA8 RID: 3752 RVA: 0x0007425C File Offset: 0x0007245C
		internal static Vector3 EvaluateAtmosphericAttenuation(float airScaleHeight, float aerosolScaleHeight, in Vector3 airExtinctionCoefficient, float aerosolExtinctionCoefficient, in Vector3 C, float R, in Vector3 L, in Vector3 X)
		{
			float num = Vector3.Distance(X, C);
			float num2 = PhysicallyBasedSky.ComputeCosineOfHorizonAngle(num, R);
			float num3 = Vector3.Dot(X - C, L) * PhysicallyBasedSky.Rcp(num);
			if (num3 > num2)
			{
				Vector3 vector = PhysicallyBasedSky.ComputeAtmosphericOpticalDepth(airScaleHeight, aerosolScaleHeight, airExtinctionCoefficient, aerosolExtinctionCoefficient, R, num, num3, true);
				Vector3 result;
				result.x = Mathf.Exp(-vector.x);
				result.y = Mathf.Exp(-vector.y);
				result.z = Mathf.Exp(-vector.z);
				return result;
			}
			return Vector3.zero;
		}

		// Token: 0x06000EA9 RID: 3753 RVA: 0x00074304 File Offset: 0x00072504
		internal override Vector3 EvaluateAtmosphericAttenuation(Vector3 sunDirection, Vector3 cameraPosition)
		{
			float airScaleHeight = this.GetAirScaleHeight();
			float aerosolScaleHeight = this.GetAerosolScaleHeight();
			Vector3 airExtinctionCoefficient = this.GetAirExtinctionCoefficient();
			float aerosolExtinctionCoefficient = this.GetAerosolExtinctionCoefficient();
			Vector3 vector = this.GetPlanetCenterPosition(cameraPosition);
			return PhysicallyBasedSky.EvaluateAtmosphericAttenuation(airScaleHeight, aerosolScaleHeight, airExtinctionCoefficient, aerosolExtinctionCoefficient, vector, this.GetPlanetaryRadius(), sunDirection, cameraPosition);
		}

		// Token: 0x06000EAA RID: 3754 RVA: 0x00074345 File Offset: 0x00072545
		public override Type GetSkyRendererType()
		{
			return typeof(PhysicallyBasedSkyRenderer);
		}

		// Token: 0x06000EAB RID: 3755 RVA: 0x00074354 File Offset: 0x00072554
		private void Awake()
		{
			PhysicallyBasedSky.k_Migration.Migrate(this);
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000EAC RID: 3756 RVA: 0x00074370 File Offset: 0x00072570
		// (set) Token: 0x06000EAD RID: 3757 RVA: 0x00074378 File Offset: 0x00072578
		PhysicallyBasedSky.Version IVersionable<PhysicallyBasedSky.Version>.version
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

		// Token: 0x040016EF RID: 5871
		private const float k_DefaultEarthRadius = 6378100f;

		// Token: 0x040016F0 RID: 5872
		private const float k_DefaultAirScatteringR = 5.8E-06f;

		// Token: 0x040016F1 RID: 5873
		private const float k_DefaultAirScatteringG = 1.35E-05f;

		// Token: 0x040016F2 RID: 5874
		private const float k_DefaultAirScatteringB = 3.3099997E-05f;

		// Token: 0x040016F3 RID: 5875
		private const float k_DefaultAirScaleHeight = 8000f;

		// Token: 0x040016F4 RID: 5876
		private const float k_DefaultAirAlbedoR = 0.9f;

		// Token: 0x040016F5 RID: 5877
		private const float k_DefaultAirAlbedoG = 0.9f;

		// Token: 0x040016F6 RID: 5878
		private const float k_DefaultAirAlbedoB = 1f;

		// Token: 0x040016F7 RID: 5879
		private const float k_DefaultAerosolScaleHeight = 1200f;

		// Token: 0x040016F8 RID: 5880
		private static readonly float k_DefaultAerosolMaximumAltitude = PhysicallyBasedSky.LayerDepthFromScaleHeight(1200f);

		// Token: 0x040016F9 RID: 5881
		public PhysicallyBasedSkyModelParameter type = new PhysicallyBasedSkyModelParameter(PhysicallyBasedSkyModel.EarthAdvanced, false);

		// Token: 0x040016FA RID: 5882
		[Tooltip("When enabled, you can define the planet in terms of a world-space position and radius. Otherwise, the planet is always below the Camera in the world-space x-z plane.")]
		public BoolParameter sphericalMode = new BoolParameter(true, false);

		// Token: 0x040016FB RID: 5883
		[Tooltip("Sets the world-space y coordinate of the planet's sea level in meters.")]
		public FloatParameter seaLevel = new FloatParameter(0f, false);

		// Token: 0x040016FC RID: 5884
		[Tooltip("Sets the radius of the planet in meters. This is distance from the center of the planet to the sea level.")]
		public MinFloatParameter planetaryRadius = new MinFloatParameter(6378100f, 0f, false);

		// Token: 0x040016FD RID: 5885
		[Tooltip("Sets the world-space position of the planet's center in meters.")]
		public Vector3Parameter planetCenterPosition = new Vector3Parameter(new Vector3(0f, -6378100f, 0f), false);

		// Token: 0x040016FE RID: 5886
		[Tooltip("Controls the red color channel opacity of air at the point in the sky directly above the observer (zenith).")]
		public ClampedFloatParameter airDensityR = new ClampedFloatParameter(PhysicallyBasedSky.ZenithOpacityFromExtinctionAndScaleHeight(5.8E-06f, 8000f), 0f, 1f, false);

		// Token: 0x040016FF RID: 5887
		[Tooltip("Controls the green color channel opacity of air at the point in the sky directly above the observer (zenith).")]
		public ClampedFloatParameter airDensityG = new ClampedFloatParameter(PhysicallyBasedSky.ZenithOpacityFromExtinctionAndScaleHeight(1.35E-05f, 8000f), 0f, 1f, false);

		// Token: 0x04001700 RID: 5888
		[Tooltip("Controls the blue color channel opacity of air at the point in the sky directly above the observer (zenith).")]
		public ClampedFloatParameter airDensityB = new ClampedFloatParameter(PhysicallyBasedSky.ZenithOpacityFromExtinctionAndScaleHeight(3.3099997E-05f, 8000f), 0f, 1f, false);

		// Token: 0x04001701 RID: 5889
		[Tooltip("Specifies the color that HDRP tints the air to. This controls the single scattering albedo of air molecules (per color channel). A value of 0 results in absorbing molecules, and a value of 1 results in scattering ones.")]
		public ColorParameter airTint = new ColorParameter(new Color(0.9f, 0.9f, 1f), false, false, true, false);

		// Token: 0x04001702 RID: 5890
		[Tooltip("Sets the depth, in meters, of the atmospheric layer, from sea level, composed of air particles. Controls the rate of height-based density falloff.")]
		public MinFloatParameter airMaximumAltitude = new MinFloatParameter(PhysicallyBasedSky.LayerDepthFromScaleHeight(8000f), 0f, false);

		// Token: 0x04001703 RID: 5891
		[Tooltip("Controls the opacity of aerosols at the point in the sky directly above the observer (zenith).")]
		public ClampedFloatParameter aerosolDensity = new ClampedFloatParameter(PhysicallyBasedSky.ZenithOpacityFromExtinctionAndScaleHeight(1E-05f, 1200f), 0f, 1f, false);

		// Token: 0x04001704 RID: 5892
		[Tooltip("Specifies the color that HDRP tints aerosols to. This controls the single scattering albedo of aerosol molecules (per color channel). A value of 0 results in absorbing molecules, and a value of 1 results in scattering ones.")]
		public ColorParameter aerosolTint = new ColorParameter(new Color(0.9f, 0.9f, 0.9f), false, false, true, false);

		// Token: 0x04001705 RID: 5893
		[Tooltip("Sets the depth, in meters, of the atmospheric layer, from sea level, composed of aerosol particles. Controls the rate of height-based density falloff.")]
		public MinFloatParameter aerosolMaximumAltitude = new MinFloatParameter(PhysicallyBasedSky.k_DefaultAerosolMaximumAltitude, 0f, false);

		// Token: 0x04001706 RID: 5894
		[Tooltip("Controls the direction of anisotropy. Set this to a positive value for forward scattering, a negative value for backward scattering, or 0 for isotropic scattering.")]
		public ClampedFloatParameter aerosolAnisotropy = new ClampedFloatParameter(0f, -1f, 1f, false);

		// Token: 0x04001707 RID: 5895
		[Tooltip("Specifies a color that HDRP uses to tint the Ground Color Texture.")]
		public ColorParameter groundTint = new ColorParameter(new Color(0.4f, 0.25f, 0.15f), false, false, false, false);

		// Token: 0x04001708 RID: 5896
		[Tooltip("Specifies a Texture that represents the planet's surface. Does not affect the precomputation.")]
		public CubemapParameter groundColorTexture = new CubemapParameter(null, false);

		// Token: 0x04001709 RID: 5897
		[Tooltip("Specifies a Texture that represents the emissive areas of the planet's surface. Does not affect the precomputation.")]
		public CubemapParameter groundEmissionTexture = new CubemapParameter(null, false);

		// Token: 0x0400170A RID: 5898
		[Tooltip("Sets the multiplier that HDRP applies to the Ground Emission Texture.")]
		public MinFloatParameter groundEmissionMultiplier = new MinFloatParameter(1f, 0f, false);

		// Token: 0x0400170B RID: 5899
		[Tooltip("Sets the orientation of the planet. Does not affect the precomputation.")]
		public Vector3Parameter planetRotation = new Vector3Parameter(Vector3.zero, false);

		// Token: 0x0400170C RID: 5900
		[Tooltip("Specifies a Texture that represents the emissive areas of space. Does not affect the precomputation.")]
		public CubemapParameter spaceEmissionTexture = new CubemapParameter(null, false);

		// Token: 0x0400170D RID: 5901
		[Tooltip("Sets the multiplier that HDRP applies to the Space Emission Texture. Does not affect the precomputation.")]
		public MinFloatParameter spaceEmissionMultiplier = new MinFloatParameter(1f, 0f, false);

		// Token: 0x0400170E RID: 5902
		[Tooltip("Sets the orientation of space. Does not affect the precomputation.")]
		public Vector3Parameter spaceRotation = new Vector3Parameter(Vector3.zero, false);

		// Token: 0x0400170F RID: 5903
		[Tooltip("Controls the saturation of the sky color. Does not affect the precomputation.")]
		public ClampedFloatParameter colorSaturation = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x04001710 RID: 5904
		[Tooltip("Controls the saturation of the sky opacity. Does not affect the precomputation.")]
		public ClampedFloatParameter alphaSaturation = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x04001711 RID: 5905
		[Tooltip("Sets the multiplier that HDRP applies to the opacity of the sky. Does not affect the precomputation.")]
		public ClampedFloatParameter alphaMultiplier = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x04001712 RID: 5906
		[Tooltip("Specifies a color that HDRP uses to tint the sky at the horizon. Does not affect the precomputation.")]
		public ColorParameter horizonTint = new ColorParameter(Color.white, false, false, false, false);

		// Token: 0x04001713 RID: 5907
		[Tooltip("Specifies a color that HDRP uses to tint the point in the sky directly above the observer (the zenith). Does not affect the precomputation.")]
		public ColorParameter zenithTint = new ColorParameter(Color.white, false, false, false, false);

		// Token: 0x04001714 RID: 5908
		[Tooltip("Controls how HDRP blends between the Horizon Tint and Zenith Tint. Does not affect the precomputation.")]
		public ClampedFloatParameter horizonZenithShift = new ClampedFloatParameter(0f, -1f, 1f, false);

		// Token: 0x04001715 RID: 5909
		[SerializeField]
		[Obsolete("Obsolete parameter, will be removed in 2023.3")]
		public ClampedIntParameter numberOfBounces = new ClampedIntParameter(3, 1, 10, false);

		// Token: 0x04001716 RID: 5910
		protected static readonly MigrationDescription<PhysicallyBasedSky.Version, PhysicallyBasedSky> k_Migration = MigrationDescription.New<PhysicallyBasedSky.Version, PhysicallyBasedSky>(new MigrationStep<PhysicallyBasedSky.Version, PhysicallyBasedSky>[]
		{
			MigrationStep.New<PhysicallyBasedSky.Version, PhysicallyBasedSky>(PhysicallyBasedSky.Version.TypeEnum, delegate(PhysicallyBasedSky p)
			{
				p.type.value = (p.m_ObsoleteEarthPreset.value ? PhysicallyBasedSkyModel.EarthAdvanced : PhysicallyBasedSkyModel.Custom);
				p.type.overrideState = p.m_ObsoleteEarthPreset.overrideState;
			})
		});

		// Token: 0x04001717 RID: 5911
		[SerializeField]
		private PhysicallyBasedSky.Version m_SkyVersion;

		// Token: 0x04001718 RID: 5912
		[SerializeField]
		[FormerlySerializedAs("earthPreset")]
		[Obsolete("For Data Migration")]
		private BoolParameter m_ObsoleteEarthPreset = new BoolParameter(true, false);

		// Token: 0x0200042C RID: 1068
		protected enum Version
		{
			// Token: 0x04002927 RID: 10535
			Initial,
			// Token: 0x04002928 RID: 10536
			TypeEnum
		}
	}
}
