using System;
using UnityEngine.Rendering;

namespace UnityEngine.Experimental.GlobalIllumination
{
	// Token: 0x020004C6 RID: 1222
	public static class LightmapperUtils
	{
		// Token: 0x06002ACE RID: 10958 RVA: 0x0004841C File Offset: 0x0004661C
		public static LightMode Extract(LightmapBakeType baketype)
		{
			return (baketype == LightmapBakeType.Realtime) ? LightMode.Realtime : ((baketype == LightmapBakeType.Mixed) ? LightMode.Mixed : LightMode.Baked);
		}

		// Token: 0x06002ACF RID: 10959 RVA: 0x00048440 File Offset: 0x00046640
		public static LinearColor ExtractIndirect(Light l)
		{
			return LinearColor.Convert(l.color, l.intensity * l.bounceIntensity);
		}

		// Token: 0x06002AD0 RID: 10960 RVA: 0x0004846C File Offset: 0x0004666C
		public static float ExtractInnerCone(Light l)
		{
			return 2f * Mathf.Atan(Mathf.Tan(l.spotAngle * 0.5f * 0.017453292f) * 46f / 64f);
		}

		// Token: 0x06002AD1 RID: 10961 RVA: 0x000484AC File Offset: 0x000466AC
		private static Color ExtractColorTemperature(Light l)
		{
			Color result = new Color(1f, 1f, 1f);
			bool flag = l.useColorTemperature && GraphicsSettings.lightsUseLinearIntensity;
			if (flag)
			{
				result = Mathf.CorrelatedColorTemperatureToRGB(l.colorTemperature);
			}
			return result;
		}

		// Token: 0x06002AD2 RID: 10962 RVA: 0x000484F5 File Offset: 0x000466F5
		private static void ApplyColorTemperature(Color cct, ref LinearColor lightColor)
		{
			lightColor.red *= cct.r;
			lightColor.green *= cct.g;
			lightColor.blue *= cct.b;
		}

		// Token: 0x06002AD3 RID: 10963 RVA: 0x00048534 File Offset: 0x00046734
		public static void Extract(Light l, ref DirectionalLight dir)
		{
			dir.instanceID = l.GetInstanceID();
			dir.mode = LightmapperUtils.Extract(l.bakingOutput.lightmapBakeType);
			dir.shadow = (l.shadows > LightShadows.None);
			dir.position = l.transform.position;
			dir.orientation = l.transform.rotation;
			Color cct = LightmapperUtils.ExtractColorTemperature(l);
			LinearColor color = LinearColor.Convert(l.color, l.intensity);
			LinearColor indirectColor = LightmapperUtils.ExtractIndirect(l);
			LightmapperUtils.ApplyColorTemperature(cct, ref color);
			LightmapperUtils.ApplyColorTemperature(cct, ref indirectColor);
			dir.color = color;
			dir.indirectColor = indirectColor;
			dir.penumbraWidthRadian = 0f;
		}

		// Token: 0x06002AD4 RID: 10964 RVA: 0x000485E0 File Offset: 0x000467E0
		public static void Extract(Light l, ref PointLight point)
		{
			point.instanceID = l.GetInstanceID();
			point.mode = LightmapperUtils.Extract(l.bakingOutput.lightmapBakeType);
			point.shadow = (l.shadows > LightShadows.None);
			point.position = l.transform.position;
			point.orientation = l.transform.rotation;
			Color cct = LightmapperUtils.ExtractColorTemperature(l);
			LinearColor color = LinearColor.Convert(l.color, l.intensity);
			LinearColor indirectColor = LightmapperUtils.ExtractIndirect(l);
			LightmapperUtils.ApplyColorTemperature(cct, ref color);
			LightmapperUtils.ApplyColorTemperature(cct, ref indirectColor);
			point.color = color;
			point.indirectColor = indirectColor;
			point.range = l.range;
			point.sphereRadius = 0f;
			point.falloff = FalloffType.Legacy;
		}

		// Token: 0x06002AD5 RID: 10965 RVA: 0x000486A0 File Offset: 0x000468A0
		public static void Extract(Light l, ref SpotLight spot)
		{
			spot.instanceID = l.GetInstanceID();
			spot.mode = LightmapperUtils.Extract(l.bakingOutput.lightmapBakeType);
			spot.shadow = (l.shadows > LightShadows.None);
			spot.position = l.transform.position;
			spot.orientation = l.transform.rotation;
			Color cct = LightmapperUtils.ExtractColorTemperature(l);
			LinearColor color = LinearColor.Convert(l.color, l.intensity);
			LinearColor indirectColor = LightmapperUtils.ExtractIndirect(l);
			LightmapperUtils.ApplyColorTemperature(cct, ref color);
			LightmapperUtils.ApplyColorTemperature(cct, ref indirectColor);
			spot.color = color;
			spot.indirectColor = indirectColor;
			spot.range = l.range;
			spot.sphereRadius = 0f;
			spot.coneAngle = l.spotAngle * 0.017453292f;
			spot.innerConeAngle = LightmapperUtils.ExtractInnerCone(l);
			spot.falloff = FalloffType.Legacy;
			spot.angularFalloff = AngularFalloffType.LUT;
		}

		// Token: 0x06002AD6 RID: 10966 RVA: 0x00048784 File Offset: 0x00046984
		public static void Extract(Light l, ref RectangleLight rect)
		{
			rect.instanceID = l.GetInstanceID();
			rect.mode = LightmapperUtils.Extract(l.bakingOutput.lightmapBakeType);
			rect.shadow = (l.shadows > LightShadows.None);
			rect.position = l.transform.position;
			rect.orientation = l.transform.rotation;
			Color cct = LightmapperUtils.ExtractColorTemperature(l);
			LinearColor color = LinearColor.Convert(l.color, l.intensity);
			LinearColor indirectColor = LightmapperUtils.ExtractIndirect(l);
			LightmapperUtils.ApplyColorTemperature(cct, ref color);
			LightmapperUtils.ApplyColorTemperature(cct, ref indirectColor);
			rect.color = color;
			rect.indirectColor = indirectColor;
			rect.range = l.range;
			rect.width = 0f;
			rect.height = 0f;
			rect.falloff = FalloffType.Legacy;
		}

		// Token: 0x06002AD7 RID: 10967 RVA: 0x00048850 File Offset: 0x00046A50
		public static void Extract(Light l, ref DiscLight disc)
		{
			disc.instanceID = l.GetInstanceID();
			disc.mode = LightmapperUtils.Extract(l.bakingOutput.lightmapBakeType);
			disc.shadow = (l.shadows > LightShadows.None);
			disc.position = l.transform.position;
			disc.orientation = l.transform.rotation;
			Color cct = LightmapperUtils.ExtractColorTemperature(l);
			LinearColor color = LinearColor.Convert(l.color, l.intensity);
			LinearColor indirectColor = LightmapperUtils.ExtractIndirect(l);
			LightmapperUtils.ApplyColorTemperature(cct, ref color);
			LightmapperUtils.ApplyColorTemperature(cct, ref indirectColor);
			disc.color = color;
			disc.indirectColor = indirectColor;
			disc.range = l.range;
			disc.radius = 0f;
			disc.falloff = FalloffType.Legacy;
		}

		// Token: 0x06002AD8 RID: 10968 RVA: 0x00048910 File Offset: 0x00046B10
		public static void Extract(Light l, out Cookie cookie)
		{
			cookie.instanceID = (l.cookie ? l.cookie.GetInstanceID() : 0);
			cookie.scale = 1f;
			cookie.sizes = ((l.type == LightType.Directional && l.cookie) ? new Vector2(l.cookieSize, l.cookieSize) : new Vector2(1f, 1f));
		}
	}
}
