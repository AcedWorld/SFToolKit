using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200009F RID: 159
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\LightLoop\\LightLoop.cs", needAccessors = false, generateCBuffer = true)]
	internal struct ShaderVariablesLightList
	{
		// Token: 0x04000744 RID: 1860
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesLightList.<g_mInvScrProjectionArr>e__FixedBuffer g_mInvScrProjectionArr;

		// Token: 0x04000745 RID: 1861
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesLightList.<g_mScrProjectionArr>e__FixedBuffer g_mScrProjectionArr;

		// Token: 0x04000746 RID: 1862
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesLightList.<g_mInvProjectionArr>e__FixedBuffer g_mInvProjectionArr;

		// Token: 0x04000747 RID: 1863
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesLightList.<g_mProjectionArr>e__FixedBuffer g_mProjectionArr;

		// Token: 0x04000748 RID: 1864
		public Vector4 g_screenSize;

		// Token: 0x04000749 RID: 1865
		public Vector2Int g_viDimensions;

		// Token: 0x0400074A RID: 1866
		public int g_iNrVisibLights;

		// Token: 0x0400074B RID: 1867
		public uint g_isOrthographic;

		// Token: 0x0400074C RID: 1868
		public uint g_BaseFeatureFlags;

		// Token: 0x0400074D RID: 1869
		public int g_iNumSamplesMSAA;

		// Token: 0x0400074E RID: 1870
		public uint _EnvLightIndexShift;

		// Token: 0x0400074F RID: 1871
		public uint _DecalIndexShift;

		// Token: 0x02000337 RID: 823
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <g_mInvProjectionArr>e__FixedBuffer
		{
			// Token: 0x0400230C RID: 8972
			public float FixedElementField;
		}

		// Token: 0x02000338 RID: 824
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <g_mInvScrProjectionArr>e__FixedBuffer
		{
			// Token: 0x0400230D RID: 8973
			public float FixedElementField;
		}

		// Token: 0x02000339 RID: 825
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <g_mProjectionArr>e__FixedBuffer
		{
			// Token: 0x0400230E RID: 8974
			public float FixedElementField;
		}

		// Token: 0x0200033A RID: 826
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <g_mScrProjectionArr>e__FixedBuffer
		{
			// Token: 0x0400230F RID: 8975
			public float FixedElementField;
		}
	}
}
