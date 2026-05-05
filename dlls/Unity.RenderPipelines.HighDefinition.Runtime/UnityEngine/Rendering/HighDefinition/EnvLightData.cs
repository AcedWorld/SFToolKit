using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000088 RID: 136
	[GenerateHLSL(PackingRules.Exact, false, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\LightDefinition.cs")]
	internal struct EnvLightData
	{
		// Token: 0x04000675 RID: 1653
		public uint lightLayers;

		// Token: 0x04000676 RID: 1654
		public Vector3 capturePositionRWS;

		// Token: 0x04000677 RID: 1655
		public EnvShapeType influenceShapeType;

		// Token: 0x04000678 RID: 1656
		public Vector3 proxyExtents;

		// Token: 0x04000679 RID: 1657
		[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
		public float minProjectionDistance;

		// Token: 0x0400067A RID: 1658
		public Vector3 proxyPositionRWS;

		// Token: 0x0400067B RID: 1659
		public Vector3 proxyForward;

		// Token: 0x0400067C RID: 1660
		public Vector3 proxyUp;

		// Token: 0x0400067D RID: 1661
		public Vector3 proxyRight;

		// Token: 0x0400067E RID: 1662
		public Vector3 influencePositionRWS;

		// Token: 0x0400067F RID: 1663
		public Vector3 influenceForward;

		// Token: 0x04000680 RID: 1664
		public Vector3 influenceUp;

		// Token: 0x04000681 RID: 1665
		public Vector3 influenceRight;

		// Token: 0x04000682 RID: 1666
		public Vector3 influenceExtents;

		// Token: 0x04000683 RID: 1667
		public Vector3 blendDistancePositive;

		// Token: 0x04000684 RID: 1668
		public Vector3 blendDistanceNegative;

		// Token: 0x04000685 RID: 1669
		public Vector3 blendNormalDistancePositive;

		// Token: 0x04000686 RID: 1670
		public Vector3 blendNormalDistanceNegative;

		// Token: 0x04000687 RID: 1671
		[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
		public Vector3 boxSideFadePositive;

		// Token: 0x04000688 RID: 1672
		[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
		public Vector3 boxSideFadeNegative;

		// Token: 0x04000689 RID: 1673
		public float weight;

		// Token: 0x0400068A RID: 1674
		public float multiplier;

		// Token: 0x0400068B RID: 1675
		public float rangeCompressionFactorCompensation;

		// Token: 0x0400068C RID: 1676
		public float roughReflections;

		// Token: 0x0400068D RID: 1677
		public float distanceBasedRoughness;

		// Token: 0x0400068E RID: 1678
		public int envIndex;

		// Token: 0x0400068F RID: 1679
		public Vector4 L0L1;

		// Token: 0x04000690 RID: 1680
		public Vector4 L2_1;

		// Token: 0x04000691 RID: 1681
		public float L2_2;

		// Token: 0x04000692 RID: 1682
		public int normalizeWithAPV;

		// Token: 0x04000693 RID: 1683
		public Vector2 padding;
	}
}
