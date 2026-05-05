using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000DF RID: 223
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\VolumetricLighting\\HDRenderPipeline.VolumetricLighting.cs", needAccessors = false)]
	internal struct VolumetricMaterialRenderingData
	{
		// Token: 0x04000972 RID: 2418
		public Vector4 viewSpaceBounds;

		// Token: 0x04000973 RID: 2419
		public uint startSliceIndex;

		// Token: 0x04000974 RID: 2420
		public uint sliceCount;

		// Token: 0x04000975 RID: 2421
		public uint padding0;

		// Token: 0x04000976 RID: 2422
		public uint padding1;

		// Token: 0x04000977 RID: 2423
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(8, typeof(Vector4))]
		public VolumetricMaterialRenderingData.<obbVertexPositionWS>e__FixedBuffer obbVertexPositionWS;

		// Token: 0x0200035F RID: 863
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <obbVertexPositionWS>e__FixedBuffer
		{
			// Token: 0x04002397 RID: 9111
			public float FixedElementField;
		}
	}
}
