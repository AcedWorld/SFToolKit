using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000B5 RID: 181
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\ScreenSpaceLighting\\BilateralUpsampleDef.cs", needAccessors = false, generateCBuffer = true)]
	internal struct ShaderVariablesBilateralUpsample
	{
		// Token: 0x040007F4 RID: 2036
		public Vector4 _HalfScreenSize;

		// Token: 0x040007F5 RID: 2037
		[FixedBuffer(typeof(float), 48)]
		[HLSLArray(12, typeof(Vector4))]
		public ShaderVariablesBilateralUpsample.<_DistanceBasedWeights>e__FixedBuffer _DistanceBasedWeights;

		// Token: 0x040007F6 RID: 2038
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(8, typeof(Vector4))]
		public ShaderVariablesBilateralUpsample.<_TapOffsets>e__FixedBuffer _TapOffsets;

		// Token: 0x02000349 RID: 841
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 192)]
		public struct <_DistanceBasedWeights>e__FixedBuffer
		{
			// Token: 0x04002346 RID: 9030
			public float FixedElementField;
		}

		// Token: 0x0200034A RID: 842
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <_TapOffsets>e__FixedBuffer
		{
			// Token: 0x04002347 RID: 9031
			public float FixedElementField;
		}
	}
}
