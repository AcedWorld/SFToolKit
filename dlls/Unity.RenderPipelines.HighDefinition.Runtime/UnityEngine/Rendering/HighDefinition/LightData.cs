using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000085 RID: 133
	[GenerateHLSL(PackingRules.Exact, false, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\LightDefinition.cs")]
	internal struct LightData
	{
		// Token: 0x0400064C RID: 1612
		public Vector3 positionRWS;

		// Token: 0x0400064D RID: 1613
		public uint lightLayers;

		// Token: 0x0400064E RID: 1614
		public float lightDimmer;

		// Token: 0x0400064F RID: 1615
		public float volumetricLightDimmer;

		// Token: 0x04000650 RID: 1616
		[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
		public float angleScale;

		// Token: 0x04000651 RID: 1617
		[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
		public float angleOffset;

		// Token: 0x04000652 RID: 1618
		public Vector3 forward;

		// Token: 0x04000653 RID: 1619
		public float iesCut;

		// Token: 0x04000654 RID: 1620
		public GPULightType lightType;

		// Token: 0x04000655 RID: 1621
		public Vector3 right;

		// Token: 0x04000656 RID: 1622
		public float penumbraTint;

		// Token: 0x04000657 RID: 1623
		[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
		public float range;

		// Token: 0x04000658 RID: 1624
		public CookieMode cookieMode;

		// Token: 0x04000659 RID: 1625
		public int shadowIndex;

		// Token: 0x0400065A RID: 1626
		public Vector3 up;

		// Token: 0x0400065B RID: 1627
		public float rangeAttenuationScale;

		// Token: 0x0400065C RID: 1628
		public Vector3 color;

		// Token: 0x0400065D RID: 1629
		public float rangeAttenuationBias;

		// Token: 0x0400065E RID: 1630
		public Vector4 cookieScaleOffset;

		// Token: 0x0400065F RID: 1631
		public Vector3 shadowTint;

		// Token: 0x04000660 RID: 1632
		public float shadowDimmer;

		// Token: 0x04000661 RID: 1633
		public float volumetricShadowDimmer;

		// Token: 0x04000662 RID: 1634
		public int nonLightMappedOnly;

		// Token: 0x04000663 RID: 1635
		[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
		public float minRoughness;

		// Token: 0x04000664 RID: 1636
		public int screenSpaceShadowIndex;

		// Token: 0x04000665 RID: 1637
		[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
		public Vector4 shadowMaskSelector;

		// Token: 0x04000666 RID: 1638
		[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
		public Vector4 size;

		// Token: 0x04000667 RID: 1639
		public int contactShadowMask;

		// Token: 0x04000668 RID: 1640
		public float diffuseDimmer;

		// Token: 0x04000669 RID: 1641
		public float specularDimmer;

		// Token: 0x0400066A RID: 1642
		public float __unused__;

		// Token: 0x0400066B RID: 1643
		public Vector2 padding;

		// Token: 0x0400066C RID: 1644
		public float isRayTracedContactShadow;

		// Token: 0x0400066D RID: 1645
		public float boxLightSafeExtent;
	}
}
