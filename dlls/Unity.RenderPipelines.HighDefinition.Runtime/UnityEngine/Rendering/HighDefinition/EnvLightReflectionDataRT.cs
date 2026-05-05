using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200008A RID: 138
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\LightDefinition.cs", needAccessors = false, generateCBuffer = true)]
	internal struct EnvLightReflectionDataRT
	{
		// Token: 0x04000699 RID: 1689
		public const int s_MaxPlanarReflections = 16;

		// Token: 0x0400069A RID: 1690
		public const int s_MaxCubeReflections = 128;

		// Token: 0x0400069B RID: 1691
		[FixedBuffer(typeof(float), 256)]
		[HLSLArray(16, typeof(Matrix4x4))]
		public EnvLightReflectionDataRT.<_PlanarCaptureVPRT>e__FixedBuffer _PlanarCaptureVPRT;

		// Token: 0x0400069C RID: 1692
		[FixedBuffer(typeof(float), 64)]
		[HLSLArray(16, typeof(Vector4))]
		public EnvLightReflectionDataRT.<_PlanarScaleOffsetRT>e__FixedBuffer _PlanarScaleOffsetRT;

		// Token: 0x0400069D RID: 1693
		[FixedBuffer(typeof(float), 512)]
		[HLSLArray(128, typeof(Vector4))]
		public EnvLightReflectionDataRT.<_CubeScaleOffsetRT>e__FixedBuffer _CubeScaleOffsetRT;

		// Token: 0x02000333 RID: 819
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 2048)]
		public struct <_CubeScaleOffsetRT>e__FixedBuffer
		{
			// Token: 0x04002305 RID: 8965
			public float FixedElementField;
		}

		// Token: 0x02000334 RID: 820
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 1024)]
		public struct <_PlanarCaptureVPRT>e__FixedBuffer
		{
			// Token: 0x04002306 RID: 8966
			public float FixedElementField;
		}

		// Token: 0x02000335 RID: 821
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 256)]
		public struct <_PlanarScaleOffsetRT>e__FixedBuffer
		{
			// Token: 0x04002307 RID: 8967
			public float FixedElementField;
		}
	}
}
