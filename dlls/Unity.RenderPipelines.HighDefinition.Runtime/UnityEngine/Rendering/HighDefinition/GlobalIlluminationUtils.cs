using System;
using Unity.Collections;
using UnityEngine.Experimental.GlobalIllumination;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000068 RID: 104
	internal static class GlobalIlluminationUtils
	{
		// Token: 0x06000294 RID: 660 RVA: 0x0000EBFC File Offset: 0x0000CDFC
		public static bool LightDataGIExtract(Light light, ref LightDataGI lightDataGI)
		{
			HDAdditionalLightData hdadditionalLightData = light.GetComponent<HDAdditionalLightData>();
			if (hdadditionalLightData == null)
			{
				hdadditionalLightData = HDUtils.s_DefaultHDAdditionalLightData;
			}
			Cookie cookie;
			LightmapperUtils.Extract(light, out cookie);
			lightDataGI.cookieID = cookie.instanceID;
			lightDataGI.cookieScale = cookie.scale;
			Color color = new Color(1f, 1f, 1f);
			if (hdadditionalLightData.useColorTemperature)
			{
				color = Mathf.CorrelatedColorTemperatureToRGB(light.colorTemperature);
			}
			LightMode lightMode = LightmapperUtils.Extract(light.bakingOutput.lightmapBakeType);
			float num = 1f;
			if (lightMode == LightMode.Realtime || lightMode == LightMode.Mixed)
			{
				num = hdadditionalLightData.lightDimmer;
			}
			lightDataGI.instanceID = light.GetInstanceID();
			LinearColor color2 = hdadditionalLightData.affectDiffuse ? LinearColor.Convert(light.color, light.intensity) : LinearColor.Black();
			color2.red *= color.r;
			color2.green *= color.g;
			color2.blue *= color.b;
			color2.intensity *= num;
			LinearColor indirectColor = hdadditionalLightData.affectDiffuse ? LightmapperUtils.ExtractIndirect(light) : LinearColor.Black();
			indirectColor.red *= color.r;
			indirectColor.green *= color.g;
			indirectColor.blue *= color.b;
			indirectColor.intensity *= num;
			lightDataGI.color = color2;
			lightDataGI.indirectColor = indirectColor;
			if (hdadditionalLightData.interactsWithSky)
			{
				StaticLightingSky staticLightingSky = SkyManager.GetStaticLightingSky();
				SkySettings skySettings = (staticLightingSky != null) ? staticLightingSky.skySettings : null;
				if (skySettings != null)
				{
					Vector3 vector = skySettings.EvaluateAtmosphericAttenuation(-light.transform.forward, Vector3.zero);
					lightDataGI.color.red = lightDataGI.color.red * vector.x;
					lightDataGI.color.green = lightDataGI.color.green * vector.y;
					lightDataGI.color.blue = lightDataGI.color.blue * vector.z;
					lightDataGI.indirectColor.red = lightDataGI.indirectColor.red * vector.x;
					lightDataGI.indirectColor.green = lightDataGI.indirectColor.green * vector.y;
					lightDataGI.indirectColor.blue = lightDataGI.indirectColor.blue * vector.z;
				}
			}
			lightDataGI.mode = LightmapperUtils.Extract(light.bakingOutput.lightmapBakeType);
			lightDataGI.shadow = ((light.shadows != LightShadows.None) ? 1 : 0);
			HDLightType hdlightType = hdadditionalLightData.ComputeLightType(light);
			if (hdlightType != HDLightType.Area)
			{
				lightDataGI.color.intensity = lightDataGI.color.intensity / 3.1415927f;
				lightDataGI.indirectColor.intensity = lightDataGI.indirectColor.intensity / 3.1415927f;
				color2.intensity /= 3.1415927f;
				indirectColor.intensity /= 3.1415927f;
			}
			switch (hdlightType)
			{
			case HDLightType.Spot:
				switch (hdadditionalLightData.spotLightShape)
				{
				case SpotLightShape.Cone:
				{
					SpotLight spotLight;
					spotLight.instanceID = light.GetInstanceID();
					spotLight.shadow = (light.shadows > LightShadows.None);
					spotLight.mode = lightMode;
					spotLight.sphereRadius = 0f;
					spotLight.position = light.transform.position;
					spotLight.orientation = light.transform.rotation;
					spotLight.color = color2;
					spotLight.indirectColor = indirectColor;
					spotLight.range = light.range;
					spotLight.coneAngle = light.spotAngle * 0.017453292f;
					spotLight.innerConeAngle = light.spotAngle * 0.017453292f * hdadditionalLightData.innerSpotPercent01;
					spotLight.falloff = (hdadditionalLightData.applyRangeAttenuation ? FalloffType.InverseSquared : FalloffType.InverseSquaredNoRangeAttenuation);
					spotLight.angularFalloff = AngularFalloffType.AnalyticAndInnerAngle;
					lightDataGI.Init(ref spotLight, ref cookie);
					lightDataGI.shape1 = 1f;
					if (light.cookie != null)
					{
						lightDataGI.cookieID = light.cookie.GetInstanceID();
					}
					else if (hdadditionalLightData.IESSpot != null)
					{
						lightDataGI.cookieID = hdadditionalLightData.IESSpot.GetInstanceID();
					}
					else
					{
						lightDataGI.cookieID = 0;
					}
					break;
				}
				case SpotLightShape.Pyramid:
				{
					SpotLightPyramidShape spotLightPyramidShape;
					spotLightPyramidShape.instanceID = light.GetInstanceID();
					spotLightPyramidShape.shadow = (light.shadows > LightShadows.None);
					spotLightPyramidShape.mode = lightMode;
					spotLightPyramidShape.position = light.transform.position;
					spotLightPyramidShape.orientation = light.transform.rotation;
					spotLightPyramidShape.color = color2;
					spotLightPyramidShape.indirectColor = indirectColor;
					spotLightPyramidShape.range = light.range;
					spotLightPyramidShape.angle = light.spotAngle * 0.017453292f;
					spotLightPyramidShape.aspectRatio = hdadditionalLightData.aspectRatio;
					spotLightPyramidShape.falloff = (hdadditionalLightData.applyRangeAttenuation ? FalloffType.InverseSquared : FalloffType.InverseSquaredNoRangeAttenuation);
					lightDataGI.Init(ref spotLightPyramidShape, ref cookie);
					if (light.cookie != null)
					{
						lightDataGI.cookieID = light.cookie.GetInstanceID();
					}
					else if (hdadditionalLightData.IESSpot != null)
					{
						lightDataGI.cookieID = hdadditionalLightData.IESSpot.GetInstanceID();
					}
					else
					{
						lightDataGI.cookieID = 0;
					}
					break;
				}
				case SpotLightShape.Box:
				{
					SpotLightBoxShape spotLightBoxShape;
					spotLightBoxShape.instanceID = light.GetInstanceID();
					spotLightBoxShape.shadow = (light.shadows > LightShadows.None);
					spotLightBoxShape.mode = lightMode;
					spotLightBoxShape.position = light.transform.position;
					spotLightBoxShape.orientation = light.transform.rotation;
					spotLightBoxShape.color = color2;
					spotLightBoxShape.indirectColor = indirectColor;
					spotLightBoxShape.range = light.range;
					spotLightBoxShape.width = hdadditionalLightData.shapeWidth;
					spotLightBoxShape.height = hdadditionalLightData.shapeHeight;
					lightDataGI.Init(ref spotLightBoxShape, ref cookie);
					if (light.cookie != null)
					{
						lightDataGI.cookieID = light.cookie.GetInstanceID();
					}
					else if (hdadditionalLightData.IESSpot != null)
					{
						lightDataGI.cookieID = hdadditionalLightData.IESSpot.GetInstanceID();
					}
					else
					{
						lightDataGI.cookieID = 0;
					}
					break;
				}
				}
				break;
			case HDLightType.Directional:
				lightDataGI.orientation = light.transform.rotation;
				lightDataGI.position = light.transform.position;
				lightDataGI.range = 0f;
				lightDataGI.coneAngle = hdadditionalLightData.shapeWidth;
				lightDataGI.innerConeAngle = hdadditionalLightData.shapeHeight;
				lightDataGI.shape0 = 0f;
				lightDataGI.shape1 = 0f;
				lightDataGI.type = LightType.Directional;
				lightDataGI.falloff = FalloffType.Undefined;
				lightDataGI.coneAngle = hdadditionalLightData.shapeWidth;
				lightDataGI.innerConeAngle = hdadditionalLightData.shapeHeight;
				break;
			case HDLightType.Point:
				lightDataGI.orientation = light.transform.rotation;
				lightDataGI.position = light.transform.position;
				lightDataGI.range = light.range;
				lightDataGI.coneAngle = 0f;
				lightDataGI.innerConeAngle = 0f;
				lightDataGI.shape0 = 0f;
				lightDataGI.shape1 = 0f;
				lightDataGI.type = LightType.Point;
				lightDataGI.falloff = (hdadditionalLightData.applyRangeAttenuation ? FalloffType.InverseSquared : FalloffType.InverseSquaredNoRangeAttenuation);
				break;
			case HDLightType.Area:
				switch (hdadditionalLightData.areaLightShape)
				{
				case AreaLightShape.Rectangle:
					lightDataGI.orientation = light.transform.rotation;
					lightDataGI.position = light.transform.position;
					lightDataGI.range = light.range;
					lightDataGI.coneAngle = 0f;
					lightDataGI.innerConeAngle = 0f;
					lightDataGI.shape0 = hdadditionalLightData.shapeWidth;
					lightDataGI.shape1 = hdadditionalLightData.shapeHeight;
					lightDataGI.type = LightType.Rectangle;
					lightDataGI.falloff = (hdadditionalLightData.applyRangeAttenuation ? FalloffType.InverseSquared : FalloffType.InverseSquaredNoRangeAttenuation);
					if (hdadditionalLightData.areaLightCookie != null)
					{
						lightDataGI.cookieID = hdadditionalLightData.areaLightCookie.GetInstanceID();
					}
					else if (hdadditionalLightData.IESSpot != null)
					{
						lightDataGI.cookieID = hdadditionalLightData.IESSpot.GetInstanceID();
					}
					else
					{
						lightDataGI.cookieID = 0;
					}
					break;
				case AreaLightShape.Tube:
					lightDataGI.InitNoBake(lightDataGI.instanceID);
					break;
				case AreaLightShape.Disc:
					lightDataGI.orientation = light.transform.rotation;
					lightDataGI.position = light.transform.position;
					lightDataGI.range = light.range;
					lightDataGI.coneAngle = 0f;
					lightDataGI.innerConeAngle = 0f;
					lightDataGI.shape0 = 0f;
					lightDataGI.shape1 = 0f;
					lightDataGI.type = LightType.Disc;
					lightDataGI.falloff = (hdadditionalLightData.applyRangeAttenuation ? FalloffType.InverseSquared : FalloffType.InverseSquaredNoRangeAttenuation);
					lightDataGI.cookieID = (hdadditionalLightData.areaLightCookie ? hdadditionalLightData.areaLightCookie.GetInstanceID() : 0);
					break;
				}
				break;
			}
			return true;
		}

		// Token: 0x040002BD RID: 701
		public static Lightmapping.RequestLightsDelegate hdLightsDelegate = delegate(Light[] requests, NativeArray<LightDataGI> lightsOutput)
		{
			LightDataGI value = default(LightDataGI);
			for (int i = 0; i < requests.Length; i++)
			{
				Light light = requests[i];
				if (LightmapperUtils.Extract(light.bakingOutput.lightmapBakeType) == LightMode.Realtime)
				{
					GlobalIlluminationUtils.LightDataGIExtract(light, ref value);
				}
				else
				{
					value.InitNoBake(light.GetInstanceID());
				}
				lightsOutput[i] = value;
			}
		};
	}
}
