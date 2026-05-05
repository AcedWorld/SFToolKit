using System;
using UnityEngine.Rendering.HighDefinition.Attributes;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000116 RID: 278
	internal class Unlit : RenderPipelineMaterial
	{
		// Token: 0x0200039F RID: 927
		[GenerateHLSL(PackingRules.Exact, false, false, true, 300, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Unlit\\Unlit.cs")]
		public struct SurfaceData
		{
			// Token: 0x040025CE RID: 9678
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Albedo)]
			[SurfaceDataAttributes("Color", false, true, FieldPrecision.Default, false, "")]
			public Vector3 color;

			// Token: 0x040025CF RID: 9679
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Normal)]
			[SurfaceDataAttributes(new string[]
			{
				"Normal",
				"Normal View Space"
			}, true, false, FieldPrecision.Default, false, "")]
			public Vector3 normalWS;

			// Token: 0x040025D0 RID: 9680
			[SurfaceDataAttributes("Shadow Tint", false, true, FieldPrecision.Default, false, "defined(_ENABLE_SHADOW_MATTE) && (SHADERPASS == SHADERPASS_PATH_TRACING)")]
			public Vector4 shadowTint;
		}

		// Token: 0x020003A0 RID: 928
		[GenerateHLSL(PackingRules.Exact, false, false, true, 350, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Unlit\\Unlit.cs")]
		public struct BSDFData
		{
			// Token: 0x040025D1 RID: 9681
			[SurfaceDataAttributes("", false, true, FieldPrecision.Default, false, "")]
			public Vector3 color;
		}
	}
}
