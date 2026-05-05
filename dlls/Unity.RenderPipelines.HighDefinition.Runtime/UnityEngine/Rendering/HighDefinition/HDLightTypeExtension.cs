using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000077 RID: 119
	public static class HDLightTypeExtension
	{
		// Token: 0x060006AC RID: 1708 RVA: 0x00044998 File Offset: 0x00042B98
		public static bool IsSpot(this HDLightTypeAndShape type)
		{
			return type == HDLightTypeAndShape.BoxSpot || type == HDLightTypeAndShape.PyramidSpot || type == HDLightTypeAndShape.ConeSpot;
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x000449A8 File Offset: 0x00042BA8
		public static bool IsArea(this HDLightTypeAndShape type)
		{
			return type == HDLightTypeAndShape.TubeArea || type == HDLightTypeAndShape.RectangleArea || type == HDLightTypeAndShape.DiscArea;
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x000449B8 File Offset: 0x00042BB8
		public static bool SupportsRuntimeOnly(this HDLightTypeAndShape type)
		{
			return type != HDLightTypeAndShape.DiscArea;
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x000449C1 File Offset: 0x00042BC1
		public static bool SupportsBakedOnly(this HDLightTypeAndShape type)
		{
			return type != HDLightTypeAndShape.TubeArea;
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x000449CA File Offset: 0x00042BCA
		public static bool SupportsMixed(this HDLightTypeAndShape type)
		{
			return type != HDLightTypeAndShape.TubeArea && type != HDLightTypeAndShape.DiscArea;
		}
	}
}
