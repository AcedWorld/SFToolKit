using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000084 RID: 132
	[GenerateHLSL(PackingRules.Exact, false, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\LightDefinition.cs")]
	internal struct DirectionalLightData
	{
		// Token: 0x0400062A RID: 1578
		public Vector3 positionRWS;

		// Token: 0x0400062B RID: 1579
		public uint lightLayers;

		// Token: 0x0400062C RID: 1580
		public float lightDimmer;

		// Token: 0x0400062D RID: 1581
		public float volumetricLightDimmer;

		// Token: 0x0400062E RID: 1582
		public Vector3 forward;

		// Token: 0x0400062F RID: 1583
		public CookieMode cookieMode;

		// Token: 0x04000630 RID: 1584
		public Vector4 cookieScaleOffset;

		// Token: 0x04000631 RID: 1585
		public Vector3 right;

		// Token: 0x04000632 RID: 1586
		public int shadowIndex;

		// Token: 0x04000633 RID: 1587
		public Vector3 up;

		// Token: 0x04000634 RID: 1588
		public int contactShadowIndex;

		// Token: 0x04000635 RID: 1589
		public Vector3 color;

		// Token: 0x04000636 RID: 1590
		public int contactShadowMask;

		// Token: 0x04000637 RID: 1591
		public Vector3 shadowTint;

		// Token: 0x04000638 RID: 1592
		public float shadowDimmer;

		// Token: 0x04000639 RID: 1593
		public float volumetricShadowDimmer;

		// Token: 0x0400063A RID: 1594
		public int nonLightMappedOnly;

		// Token: 0x0400063B RID: 1595
		[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
		public float minRoughness;

		// Token: 0x0400063C RID: 1596
		public int screenSpaceShadowIndex;

		// Token: 0x0400063D RID: 1597
		[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
		public Vector4 shadowMaskSelector;

		// Token: 0x0400063E RID: 1598
		public float diffuseDimmer;

		// Token: 0x0400063F RID: 1599
		public float specularDimmer;

		// Token: 0x04000640 RID: 1600
		public float penumbraTint;

		// Token: 0x04000641 RID: 1601
		public float isRayTracedContactShadow;

		// Token: 0x04000642 RID: 1602
		public float distanceFromCamera;

		// Token: 0x04000643 RID: 1603
		public float angularDiameter;

		// Token: 0x04000644 RID: 1604
		public float flareFalloff;

		// Token: 0x04000645 RID: 1605
		public float flareCosInner;

		// Token: 0x04000646 RID: 1606
		public float flareCosOuter;

		// Token: 0x04000647 RID: 1607
		public float __unused__;

		// Token: 0x04000648 RID: 1608
		public Vector3 flareTint;

		// Token: 0x04000649 RID: 1609
		public float flareSize;

		// Token: 0x0400064A RID: 1610
		public Vector3 surfaceTint;

		// Token: 0x0400064B RID: 1611
		public Vector4 surfaceTextureScaleOffset;
	}
}
