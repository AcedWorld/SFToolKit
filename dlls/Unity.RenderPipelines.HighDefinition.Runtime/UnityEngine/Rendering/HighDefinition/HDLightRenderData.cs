using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200007A RID: 122
	internal struct HDLightRenderData
	{
		// Token: 0x040005BE RID: 1470
		public HDAdditionalLightData.PointLightHDType pointLightType;

		// Token: 0x040005BF RID: 1471
		public SpotLightShape spotLightShape;

		// Token: 0x040005C0 RID: 1472
		public AreaLightShape areaLightShape;

		// Token: 0x040005C1 RID: 1473
		public LightLayerEnum lightLayer;

		// Token: 0x040005C2 RID: 1474
		public float fadeDistance;

		// Token: 0x040005C3 RID: 1475
		public float distance;

		// Token: 0x040005C4 RID: 1476
		public float angularDiameter;

		// Token: 0x040005C5 RID: 1477
		public float volumetricFadeDistance;

		// Token: 0x040005C6 RID: 1478
		public bool includeForRayTracing;

		// Token: 0x040005C7 RID: 1479
		public bool useScreenSpaceShadows;

		// Token: 0x040005C8 RID: 1480
		public bool useRayTracedShadows;

		// Token: 0x040005C9 RID: 1481
		public bool colorShadow;

		// Token: 0x040005CA RID: 1482
		public float lightDimmer;

		// Token: 0x040005CB RID: 1483
		public float volumetricDimmer;

		// Token: 0x040005CC RID: 1484
		public float shadowDimmer;

		// Token: 0x040005CD RID: 1485
		public float shadowFadeDistance;

		// Token: 0x040005CE RID: 1486
		public float volumetricShadowDimmer;

		// Token: 0x040005CF RID: 1487
		public float shapeWidth;

		// Token: 0x040005D0 RID: 1488
		public float shapeHeight;

		// Token: 0x040005D1 RID: 1489
		public float aspectRatio;

		// Token: 0x040005D2 RID: 1490
		public float innerSpotPercent;

		// Token: 0x040005D3 RID: 1491
		public float spotIESCutoffPercent;

		// Token: 0x040005D4 RID: 1492
		public float shapeRadius;

		// Token: 0x040005D5 RID: 1493
		public float barnDoorLength;

		// Token: 0x040005D6 RID: 1494
		public float barnDoorAngle;

		// Token: 0x040005D7 RID: 1495
		public float flareSize;

		// Token: 0x040005D8 RID: 1496
		public float flareFalloff;

		// Token: 0x040005D9 RID: 1497
		public bool affectVolumetric;

		// Token: 0x040005DA RID: 1498
		public bool affectDiffuse;

		// Token: 0x040005DB RID: 1499
		public bool affectSpecular;

		// Token: 0x040005DC RID: 1500
		public bool applyRangeAttenuation;

		// Token: 0x040005DD RID: 1501
		public bool penumbraTint;

		// Token: 0x040005DE RID: 1502
		public bool interactsWithSky;

		// Token: 0x040005DF RID: 1503
		public Color surfaceTint;

		// Token: 0x040005E0 RID: 1504
		public Color shadowTint;

		// Token: 0x040005E1 RID: 1505
		public Color flareTint;
	}
}
