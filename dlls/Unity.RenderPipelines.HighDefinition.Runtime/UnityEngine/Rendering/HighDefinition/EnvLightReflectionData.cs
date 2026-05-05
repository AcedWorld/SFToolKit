using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000089 RID: 137
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\LightDefinition.cs", needAccessors = false, generateCBuffer = true)]
	internal struct EnvLightReflectionData
	{
		// Token: 0x04000694 RID: 1684
		public const int s_MaxPlanarReflections = 16;

		// Token: 0x04000695 RID: 1685
		public const int s_MaxCubeReflections = 128;

		// Token: 0x04000696 RID: 1686
		[FixedBuffer(typeof(float), 256)]
		[HLSLArray(16, typeof(Matrix4x4))]
		public EnvLightReflectionData.<_PlanarCaptureVP>e__FixedBuffer _PlanarCaptureVP;

		// Token: 0x04000697 RID: 1687
		[FixedBuffer(typeof(float), 64)]
		[HLSLArray(16, typeof(Vector4))]
		public EnvLightReflectionData.<_PlanarScaleOffset>e__FixedBuffer _PlanarScaleOffset;

		// Token: 0x04000698 RID: 1688
		[FixedBuffer(typeof(float), 512)]
		[HLSLArray(128, typeof(Vector4))]
		public EnvLightReflectionData.<_CubeScaleOffset>e__FixedBuffer _CubeScaleOffset;

		// Token: 0x02000330 RID: 816
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 2048)]
		public struct <_CubeScaleOffset>e__FixedBuffer
		{
			// Token: 0x04002302 RID: 8962
			public float FixedElementField;
		}

		// Token: 0x02000331 RID: 817
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 1024)]
		public struct <_PlanarCaptureVP>e__FixedBuffer
		{
			// Token: 0x04002303 RID: 8963
			public float FixedElementField;
		}

		// Token: 0x02000332 RID: 818
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 256)]
		public struct <_PlanarScaleOffset>e__FixedBuffer
		{
			// Token: 0x04002304 RID: 8964
			public float FixedElementField;
		}
	}
}
