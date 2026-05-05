using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000CC RID: 204
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\Shadow\\HDShadowManager.cs", needAccessors = false)]
	internal struct HDDirectionalShadowData
	{
		// Token: 0x040008BF RID: 2239
		[FixedBuffer(typeof(float), 16)]
		[HLSLArray(4, typeof(Vector4))]
		public HDDirectionalShadowData.<sphereCascades>e__FixedBuffer sphereCascades;

		// Token: 0x040008C0 RID: 2240
		[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
		public Vector4 cascadeDirection;

		// Token: 0x040008C1 RID: 2241
		[FixedBuffer(typeof(float), 4)]
		[HLSLArray(4, typeof(float))]
		[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
		public HDDirectionalShadowData.<cascadeBorders>e__FixedBuffer cascadeBorders;

		// Token: 0x040008C2 RID: 2242
		public float fadeScale;

		// Token: 0x040008C3 RID: 2243
		public float fadeBias;

		// Token: 0x02000359 RID: 857
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 16)]
		public struct <cascadeBorders>e__FixedBuffer
		{
			// Token: 0x0400238D RID: 9101
			public float FixedElementField;
		}

		// Token: 0x0200035A RID: 858
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 64)]
		public struct <sphereCascades>e__FixedBuffer
		{
			// Token: 0x0400238E RID: 9102
			public float FixedElementField;
		}
	}
}
