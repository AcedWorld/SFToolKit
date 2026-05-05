using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000A1 RID: 161
	internal class LightUtils
	{
		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x00047E84 File Offset: 0x00046084
		private static float s_LuminanceToEvFactor
		{
			get
			{
				return Mathf.Log(100f / ColorUtils.s_LightMeterCalibrationConstant, 2f);
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000730 RID: 1840 RVA: 0x00047E9B File Offset: 0x0004609B
		private static float s_EvToLuminanceFactor
		{
			get
			{
				return -Mathf.Log(100f / ColorUtils.s_LightMeterCalibrationConstant, 2f);
			}
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x00047EB3 File Offset: 0x000460B3
		public static float ConvertPointLightLumenToCandela(float intensity)
		{
			return intensity / 12.566371f;
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x00047EBC File Offset: 0x000460BC
		public static float ConvertPointLightCandelaToLumen(float intensity)
		{
			return intensity * 12.566371f;
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x00047EC5 File Offset: 0x000460C5
		public static float ConvertSpotLightLumenToCandela(float intensity, float angle, bool exact)
		{
			if (!exact)
			{
				return intensity / 3.1415927f;
			}
			return intensity / (2f * (1f - Mathf.Cos(angle / 2f)) * 3.1415927f);
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x00047EF2 File Offset: 0x000460F2
		public static float ConvertSpotLightCandelaToLumen(float intensity, float angle, bool exact)
		{
			if (!exact)
			{
				return intensity * 3.1415927f;
			}
			return intensity * (2f * (1f - Mathf.Cos(angle / 2f)) * 3.1415927f);
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x00047F1F File Offset: 0x0004611F
		public static float ConvertFrustrumLightLumenToCandela(float intensity, float angleA, float angleB)
		{
			return intensity / (4f * Mathf.Asin(Mathf.Sin(angleA / 2f) * Mathf.Sin(angleB / 2f)));
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x00047F47 File Offset: 0x00046147
		public static float ConvertFrustrumLightCandelaToLumen(float intensity, float angleA, float angleB)
		{
			return intensity * (4f * Mathf.Asin(Mathf.Sin(angleA / 2f) * Mathf.Sin(angleB / 2f)));
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x00047F6F File Offset: 0x0004616F
		public static float ConvertSphereLightLumenToLuminance(float intensity, float sphereRadius)
		{
			return intensity / (12.566371f * sphereRadius * sphereRadius * 3.1415927f);
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x00047F82 File Offset: 0x00046182
		public static float ConvertSphereLightLuminanceToLumen(float intensity, float sphereRadius)
		{
			return intensity * (12.566371f * sphereRadius * sphereRadius * 3.1415927f);
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x00047F95 File Offset: 0x00046195
		public static float ConvertDiscLightLumenToLuminance(float intensity, float discRadius)
		{
			return intensity / (discRadius * discRadius * 3.1415927f * 3.1415927f);
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x00047FA8 File Offset: 0x000461A8
		public static float ConvertDiscLightLuminanceToLumen(float intensity, float discRadius)
		{
			return intensity * (discRadius * discRadius * 3.1415927f * 3.1415927f);
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00047FBB File Offset: 0x000461BB
		public static float ConvertRectLightLumenToLuminance(float intensity, float width, float height)
		{
			return intensity / (width * height * 3.1415927f);
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x00047FC8 File Offset: 0x000461C8
		public static float ConvertRectLightLuminanceToLumen(float intensity, float width, float height)
		{
			return intensity * (width * height * 3.1415927f);
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00047FD5 File Offset: 0x000461D5
		public static float ConvertLuxToCandela(float lux, float distance)
		{
			return lux * distance * distance;
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x00047FDC File Offset: 0x000461DC
		public static float ConvertCandelaToLux(float candela, float distance)
		{
			return candela / (distance * distance);
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x00047FE3 File Offset: 0x000461E3
		public static float ConvertEvToLuminance(float ev)
		{
			return Mathf.Pow(2f, ev + LightUtils.s_EvToLuminanceFactor);
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00047FF6 File Offset: 0x000461F6
		public static float ConvertEvToCandela(float ev)
		{
			return LightUtils.ConvertEvToLuminance(ev);
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00047FFE File Offset: 0x000461FE
		public static float ConvertEvToLux(float ev, float distance)
		{
			return LightUtils.ConvertCandelaToLux(LightUtils.ConvertEvToLuminance(ev), distance);
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x0004800C File Offset: 0x0004620C
		public static float ConvertLuminanceToEv(float luminance)
		{
			return Mathf.Log(luminance, 2f) + LightUtils.s_LuminanceToEvFactor;
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x0004801F File Offset: 0x0004621F
		public static float ConvertCandelaToEv(float candela)
		{
			return LightUtils.ConvertLuminanceToEv(candela);
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x00048027 File Offset: 0x00046227
		public static float ConvertLuxToEv(float lux, float distance)
		{
			return LightUtils.ConvertLuminanceToEv(LightUtils.ConvertLuxToCandela(lux, distance));
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x00048035 File Offset: 0x00046235
		public static float ConvertPunctualLightLumenToCandela(HDLightType lightType, float lumen, float initialIntensity, bool enableSpotReflector)
		{
			if (lightType == HDLightType.Spot && enableSpotReflector)
			{
				return initialIntensity;
			}
			return LightUtils.ConvertPointLightLumenToCandela(lumen);
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x00048047 File Offset: 0x00046247
		public static float ConvertPunctualLightLumenToLux(HDLightType lightType, float lumen, float initialIntensity, bool enableSpotReflector, float distance)
		{
			return LightUtils.ConvertCandelaToLux(LightUtils.ConvertPunctualLightLumenToCandela(lightType, lumen, initialIntensity, enableSpotReflector), distance);
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x0004805C File Offset: 0x0004625C
		public static float ConvertPunctualLightCandelaToLumen(HDLightType lightType, SpotLightShape spotLightShape, float candela, bool enableSpotReflector, float spotAngle, float aspectRatio)
		{
			if (lightType != HDLightType.Spot || !enableSpotReflector)
			{
				return LightUtils.ConvertPointLightCandelaToLumen(candela);
			}
			if (spotLightShape == SpotLightShape.Cone)
			{
				return LightUtils.ConvertSpotLightCandelaToLumen(candela, spotAngle * 0.017453292f, true);
			}
			if (spotLightShape == SpotLightShape.Pyramid)
			{
				float angleA;
				float angleB;
				LightUtils.CalculateAnglesForPyramid(aspectRatio, spotAngle * 0.017453292f, out angleA, out angleB);
				return LightUtils.ConvertFrustrumLightCandelaToLumen(candela, angleA, angleB);
			}
			return LightUtils.ConvertPointLightCandelaToLumen(candela);
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x000480B4 File Offset: 0x000462B4
		public static float ConvertPunctualLightLuxToLumen(HDLightType lightType, SpotLightShape spotLightShape, float lux, bool enableSpotReflector, float spotAngle, float aspectRatio, float distance)
		{
			float candela = LightUtils.ConvertLuxToCandela(lux, distance);
			return LightUtils.ConvertPunctualLightCandelaToLumen(lightType, spotLightShape, candela, enableSpotReflector, spotAngle, aspectRatio);
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x000480D8 File Offset: 0x000462D8
		public static float ConvertPunctualLightEvToLumen(HDLightType lightType, SpotLightShape spotLightShape, float ev, bool enableSpotReflector, float spotAngle, float aspectRatio)
		{
			float candela = LightUtils.ConvertEvToCandela(ev);
			return LightUtils.ConvertPunctualLightCandelaToLumen(lightType, spotLightShape, candela, enableSpotReflector, spotAngle, aspectRatio);
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x000480F9 File Offset: 0x000462F9
		public static float ConvertPunctualLightLumenToEv(HDLightType lightType, float lumen, float initialIntensity, bool enableSpotReflector)
		{
			return LightUtils.ConvertCandelaToEv(LightUtils.ConvertPunctualLightLumenToCandela(lightType, lumen, initialIntensity, enableSpotReflector));
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x00048109 File Offset: 0x00046309
		public static float ConvertAreaLightLumenToLuminance(AreaLightShape areaLightShape, float lumen, float width, float height = 0f)
		{
			switch (areaLightShape)
			{
			case AreaLightShape.Rectangle:
				return LightUtils.ConvertRectLightLumenToLuminance(lumen, width, height);
			case AreaLightShape.Tube:
				return LightUtils.CalculateLineLightLumenToLuminance(lumen, width);
			case AreaLightShape.Disc:
				return LightUtils.ConvertDiscLightLumenToLuminance(lumen, width);
			default:
				return lumen;
			}
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x00048139 File Offset: 0x00046339
		public static float ConvertAreaLightLuminanceToLumen(AreaLightShape areaLightShape, float luminance, float width, float height = 0f)
		{
			switch (areaLightShape)
			{
			case AreaLightShape.Rectangle:
				return LightUtils.ConvertRectLightLuminanceToLumen(luminance, width, height);
			case AreaLightShape.Tube:
				return LightUtils.CalculateLineLightLuminanceToLumen(luminance, width);
			case AreaLightShape.Disc:
				return LightUtils.ConvertDiscLightLuminanceToLumen(luminance, width);
			default:
				return luminance;
			}
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x00048169 File Offset: 0x00046369
		public static float ConvertAreaLightLumenToEv(AreaLightShape AreaLightShape, float lumen, float width, float height)
		{
			return LightUtils.ConvertLuminanceToEv(LightUtils.ConvertAreaLightLumenToLuminance(AreaLightShape, lumen, width, height));
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x0004817C File Offset: 0x0004637C
		public static float ConvertAreaLightEvToLumen(AreaLightShape AreaLightShape, float ev, float width, float height)
		{
			float luminance = LightUtils.ConvertEvToLuminance(ev);
			return LightUtils.ConvertAreaLightLuminanceToLumen(AreaLightShape, luminance, width, height);
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x00048199 File Offset: 0x00046399
		public static float CalculateLineLightLumenToLuminance(float intensity, float lineWidth)
		{
			return intensity / (12.566371f * lineWidth);
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x000481A4 File Offset: 0x000463A4
		public static float CalculateLineLightLuminanceToLumen(float intensity, float lineWidth)
		{
			return intensity * (12.566371f * lineWidth);
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x000481B0 File Offset: 0x000463B0
		public static void CalculateAnglesForPyramid(float aspectRatio, float spotAngle, out float angleA, out float angleB)
		{
			if (aspectRatio < 1f)
			{
				aspectRatio = 1f / aspectRatio;
			}
			angleA = spotAngle;
			float num = angleA * 0.5f;
			num = Mathf.Atan(Mathf.Tan(num) * aspectRatio);
			angleB = num * 2f;
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x000481F4 File Offset: 0x000463F4
		internal static void ConvertLightIntensity(LightUnit oldLightUnit, LightUnit newLightUnit, HDAdditionalLightData hdLight, Light light)
		{
			float num = hdLight.intensity;
			float luxAtDistance = hdLight.luxAtDistance;
			HDLightType hdlightType = hdLight.ComputeLightType(light);
			if (hdlightType != HDLightType.Area)
			{
				if (oldLightUnit == LightUnit.Lumen && newLightUnit == LightUnit.Candela)
				{
					num = LightUtils.ConvertPunctualLightLumenToCandela(hdlightType, num, light.intensity, hdLight.enableSpotReflector);
				}
				else if (oldLightUnit == LightUnit.Lumen && newLightUnit == LightUnit.Lux)
				{
					num = LightUtils.ConvertPunctualLightLumenToLux(hdlightType, num, light.intensity, hdLight.enableSpotReflector, hdLight.luxAtDistance);
				}
				else if (oldLightUnit == LightUnit.Lumen && newLightUnit == LightUnit.Ev100)
				{
					num = LightUtils.ConvertPunctualLightLumenToEv(hdlightType, num, light.intensity, hdLight.enableSpotReflector);
				}
				else if (oldLightUnit == LightUnit.Candela && newLightUnit == LightUnit.Lumen)
				{
					num = LightUtils.ConvertPunctualLightCandelaToLumen(hdlightType, hdLight.spotLightShape, num, hdLight.enableSpotReflector, light.spotAngle, hdLight.aspectRatio);
				}
				else if (oldLightUnit == LightUnit.Candela && newLightUnit == LightUnit.Lux)
				{
					num = LightUtils.ConvertCandelaToLux(num, hdLight.luxAtDistance);
				}
				else if (oldLightUnit == LightUnit.Candela && newLightUnit == LightUnit.Ev100)
				{
					num = LightUtils.ConvertCandelaToEv(num);
				}
				else if (oldLightUnit == LightUnit.Lux && newLightUnit == LightUnit.Lumen)
				{
					num = LightUtils.ConvertPunctualLightLuxToLumen(hdlightType, hdLight.spotLightShape, num, hdLight.enableSpotReflector, light.spotAngle, hdLight.aspectRatio, hdLight.luxAtDistance);
				}
				else if (oldLightUnit == LightUnit.Lux && newLightUnit == LightUnit.Candela)
				{
					num = LightUtils.ConvertLuxToCandela(num, hdLight.luxAtDistance);
				}
				else if (oldLightUnit == LightUnit.Lux && newLightUnit == LightUnit.Ev100)
				{
					num = LightUtils.ConvertLuxToEv(num, hdLight.luxAtDistance);
				}
				else if (oldLightUnit == LightUnit.Ev100 && newLightUnit == LightUnit.Lumen)
				{
					num = LightUtils.ConvertPunctualLightEvToLumen(hdlightType, hdLight.spotLightShape, num, hdLight.enableSpotReflector, light.spotAngle, hdLight.aspectRatio);
				}
				else if (oldLightUnit == LightUnit.Ev100 && newLightUnit == LightUnit.Candela)
				{
					num = LightUtils.ConvertEvToCandela(num);
				}
				else if (oldLightUnit == LightUnit.Ev100 && newLightUnit == LightUnit.Lux)
				{
					num = LightUtils.ConvertEvToLux(num, hdLight.luxAtDistance);
				}
			}
			else
			{
				if (oldLightUnit == LightUnit.Lumen && newLightUnit == LightUnit.Nits)
				{
					num = LightUtils.ConvertAreaLightLumenToLuminance(hdLight.areaLightShape, num, hdLight.shapeWidth, hdLight.shapeHeight);
				}
				if (oldLightUnit == LightUnit.Nits && newLightUnit == LightUnit.Lumen)
				{
					num = LightUtils.ConvertAreaLightLuminanceToLumen(hdLight.areaLightShape, num, hdLight.shapeWidth, hdLight.shapeHeight);
				}
				if (oldLightUnit == LightUnit.Nits && newLightUnit == LightUnit.Ev100)
				{
					num = LightUtils.ConvertLuminanceToEv(num);
				}
				if (oldLightUnit == LightUnit.Ev100 && newLightUnit == LightUnit.Nits)
				{
					num = LightUtils.ConvertEvToLuminance(num);
				}
				if (oldLightUnit == LightUnit.Ev100 && newLightUnit == LightUnit.Lumen)
				{
					num = LightUtils.ConvertAreaLightEvToLumen(hdLight.areaLightShape, num, hdLight.shapeWidth, hdLight.shapeHeight);
				}
				if (oldLightUnit == LightUnit.Lumen && newLightUnit == LightUnit.Ev100)
				{
					num = LightUtils.ConvertAreaLightLumenToEv(hdLight.areaLightShape, num, hdLight.shapeWidth, hdLight.shapeHeight);
				}
			}
			hdLight.intensity = num;
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x0004844C File Offset: 0x0004664C
		internal static Color EvaluateLightColor(Light light, HDAdditionalLightData hdLight)
		{
			Color color = light.color.linear * light.intensity;
			if (hdLight.useColorTemperature)
			{
				color *= Mathf.CorrelatedColorTemperatureToRGB(light.colorTemperature);
			}
			return color;
		}
	}
}
