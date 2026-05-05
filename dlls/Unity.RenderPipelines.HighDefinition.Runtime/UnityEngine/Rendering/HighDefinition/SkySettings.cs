using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001F5 RID: 501
	public abstract class SkySettings : VolumeComponent
	{
		// Token: 0x06000F21 RID: 3873 RVA: 0x00077022 File Offset: 0x00075222
		public virtual int GetHashCode(Camera camera)
		{
			return this.GetHashCode();
		}

		// Token: 0x06000F22 RID: 3874 RVA: 0x0007702C File Offset: 0x0007522C
		public override int GetHashCode()
		{
			return (((((13 * 23 + this.rotation.GetHashCode()) * 23 + this.exposure.GetHashCode()) * 23 + this.multiplier.GetHashCode()) * 23 + this.desiredLuxValue.GetHashCode()) * 23 + this.skyIntensityMode.GetHashCode()) * 23 + this.includeSunInBaking.GetHashCode();
		}

		// Token: 0x06000F23 RID: 3875 RVA: 0x00077095 File Offset: 0x00075295
		public static int GetUniqueID<T>()
		{
			return SkySettings.GetUniqueID(typeof(T));
		}

		// Token: 0x06000F24 RID: 3876 RVA: 0x000770A8 File Offset: 0x000752A8
		public static int GetUniqueID(Type type)
		{
			int num;
			if (!SkySettings.skyUniqueIDs.TryGetValue(type, out num))
			{
				object[] customAttributes = type.GetCustomAttributes(typeof(SkyUniqueID), false);
				num = ((customAttributes.Length == 0) ? -1 : ((SkyUniqueID)customAttributes[0]).uniqueID);
				SkySettings.skyUniqueIDs[type] = num;
			}
			return num;
		}

		// Token: 0x06000F25 RID: 3877 RVA: 0x000770F8 File Offset: 0x000752F8
		public float GetIntensityFromSettings()
		{
			float num = 1f;
			switch (this.skyIntensityMode.value)
			{
			case SkyIntensityMode.Exposure:
				num *= ColorUtils.ConvertEV100ToExposure(-this.exposure.value);
				break;
			case SkyIntensityMode.Lux:
				num *= this.desiredLuxValue.value / Mathf.Max(this.upperHemisphereLuxValue.value, 1E-05f);
				break;
			case SkyIntensityMode.Multiplier:
				num *= this.multiplier.value;
				break;
			}
			return num;
		}

		// Token: 0x06000F26 RID: 3878 RVA: 0x00077178 File Offset: 0x00075378
		public virtual bool SignificantlyDivergesFrom(SkySettings otherSettings)
		{
			if (otherSettings == null || otherSettings.GetSkyRendererType() != this.GetSkyRendererType())
			{
				return true;
			}
			float intensityFromSettings = this.GetIntensityFromSettings();
			float intensityFromSettings2 = otherSettings.GetIntensityFromSettings();
			return ((intensityFromSettings > intensityFromSettings2) ? (intensityFromSettings / intensityFromSettings2) : (intensityFromSettings2 / intensityFromSettings)) > 3f;
		}

		// Token: 0x06000F27 RID: 3879
		public abstract Type GetSkyRendererType();

		// Token: 0x06000F28 RID: 3880 RVA: 0x000771C4 File Offset: 0x000753C4
		internal virtual Vector3 EvaluateAtmosphericAttenuation(Vector3 sunDirection, Vector3 cameraPosition)
		{
			return Vector3.one;
		}

		// Token: 0x040017A8 RID: 6056
		[Tooltip("Sets the rotation of the sky.")]
		public ClampedFloatParameter rotation = new ClampedFloatParameter(0f, 0f, 360f, false);

		// Token: 0x040017A9 RID: 6057
		[Tooltip("Specifies the intensity mode HDRP uses for the sky.")]
		public SkyIntensityParameter skyIntensityMode = new SkyIntensityParameter(SkyIntensityMode.Exposure, false);

		// Token: 0x040017AA RID: 6058
		[Tooltip("Sets the exposure of the sky in EV.")]
		public FloatParameter exposure = new FloatParameter(0f, false);

		// Token: 0x040017AB RID: 6059
		[Tooltip("Sets the intensity multiplier for the sky.")]
		public MinFloatParameter multiplier = new MinFloatParameter(1f, 0f, false);

		// Token: 0x040017AC RID: 6060
		[Tooltip("Informative helper that displays the relative intensity (in Lux) for the current HDR texture set in HDRI Sky.")]
		public MinFloatParameter upperHemisphereLuxValue = new MinFloatParameter(1f, 0f, false);

		// Token: 0x040017AD RID: 6061
		[Tooltip("Informative helper that displays Show the color of Shadow.")]
		public Vector3Parameter upperHemisphereLuxColor = new Vector3Parameter(new Vector3(0f, 0f, 0f), false);

		// Token: 0x040017AE RID: 6062
		[Tooltip("Sets the absolute intensity (in Lux) of the current HDR texture set in HDRI Sky. Functions as a Lux intensity multiplier for the sky.")]
		public FloatParameter desiredLuxValue = new FloatParameter(20000f, false);

		// Token: 0x040017AF RID: 6063
		[Tooltip("Specifies when HDRP updates the environment lighting. When set to OnDemand, use HDRenderPipeline.RequestSkyEnvironmentUpdate() to request an update.")]
		public EnvUpdateParameter updateMode = new EnvUpdateParameter(EnvironmentUpdateMode.OnChanged, false);

		// Token: 0x040017B0 RID: 6064
		[Tooltip("Sets the period, in seconds, at which HDRP updates the environment ligting (0 means HDRP updates it every frame).")]
		public MinFloatParameter updatePeriod = new MinFloatParameter(0f, 0f, false);

		// Token: 0x040017B1 RID: 6065
		[Tooltip("When enabled, HDRP uses the Sun Disk in baked lighting.")]
		public BoolParameter includeSunInBaking = new BoolParameter(false, false);

		// Token: 0x040017B2 RID: 6066
		private static Dictionary<Type, int> skyUniqueIDs = new Dictionary<Type, int>();
	}
}
