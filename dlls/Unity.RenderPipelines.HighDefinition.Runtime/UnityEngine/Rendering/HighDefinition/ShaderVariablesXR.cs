using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001D1 RID: 465
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\ShaderLibrary\\ShaderVariablesXR.cs", needAccessors = false, generateCBuffer = true, constantRegister = 1)]
	internal struct ShaderVariablesXR
	{
		// Token: 0x04001679 RID: 5753
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesXR.<_XRViewMatrix>e__FixedBuffer _XRViewMatrix;

		// Token: 0x0400167A RID: 5754
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesXR.<_XRInvViewMatrix>e__FixedBuffer _XRInvViewMatrix;

		// Token: 0x0400167B RID: 5755
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesXR.<_XRProjMatrix>e__FixedBuffer _XRProjMatrix;

		// Token: 0x0400167C RID: 5756
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesXR.<_XRInvProjMatrix>e__FixedBuffer _XRInvProjMatrix;

		// Token: 0x0400167D RID: 5757
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesXR.<_XRViewProjMatrix>e__FixedBuffer _XRViewProjMatrix;

		// Token: 0x0400167E RID: 5758
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesXR.<_XRInvViewProjMatrix>e__FixedBuffer _XRInvViewProjMatrix;

		// Token: 0x0400167F RID: 5759
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesXR.<_XRNonJitteredViewProjMatrix>e__FixedBuffer _XRNonJitteredViewProjMatrix;

		// Token: 0x04001680 RID: 5760
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesXR.<_XRPrevViewProjMatrix>e__FixedBuffer _XRPrevViewProjMatrix;

		// Token: 0x04001681 RID: 5761
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesXR.<_XRPrevInvViewProjMatrix>e__FixedBuffer _XRPrevInvViewProjMatrix;

		// Token: 0x04001682 RID: 5762
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesXR.<_XRPrevViewProjMatrixNoCameraTrans>e__FixedBuffer _XRPrevViewProjMatrixNoCameraTrans;

		// Token: 0x04001683 RID: 5763
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesXR.<_XRViewProjMatrixNoCameraTrans>e__FixedBuffer _XRViewProjMatrixNoCameraTrans;

		// Token: 0x04001684 RID: 5764
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesXR.<_XRPixelCoordToViewDirWS>e__FixedBuffer _XRPixelCoordToViewDirWS;

		// Token: 0x04001685 RID: 5765
		[FixedBuffer(typeof(float), 8)]
		[HLSLArray(2, typeof(Vector4))]
		public ShaderVariablesXR.<_XRWorldSpaceCameraPos>e__FixedBuffer _XRWorldSpaceCameraPos;

		// Token: 0x04001686 RID: 5766
		[FixedBuffer(typeof(float), 8)]
		[HLSLArray(2, typeof(Vector4))]
		public ShaderVariablesXR.<_XRWorldSpaceCameraPosViewOffset>e__FixedBuffer _XRWorldSpaceCameraPosViewOffset;

		// Token: 0x04001687 RID: 5767
		[FixedBuffer(typeof(float), 8)]
		[HLSLArray(2, typeof(Vector4))]
		public ShaderVariablesXR.<_XRPrevWorldSpaceCameraPos>e__FixedBuffer _XRPrevWorldSpaceCameraPos;

		// Token: 0x02000417 RID: 1047
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <_XRInvProjMatrix>e__FixedBuffer
		{
			// Token: 0x040028F1 RID: 10481
			public float FixedElementField;
		}

		// Token: 0x02000418 RID: 1048
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <_XRInvViewMatrix>e__FixedBuffer
		{
			// Token: 0x040028F2 RID: 10482
			public float FixedElementField;
		}

		// Token: 0x02000419 RID: 1049
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <_XRInvViewProjMatrix>e__FixedBuffer
		{
			// Token: 0x040028F3 RID: 10483
			public float FixedElementField;
		}

		// Token: 0x0200041A RID: 1050
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <_XRNonJitteredViewProjMatrix>e__FixedBuffer
		{
			// Token: 0x040028F4 RID: 10484
			public float FixedElementField;
		}

		// Token: 0x0200041B RID: 1051
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <_XRPixelCoordToViewDirWS>e__FixedBuffer
		{
			// Token: 0x040028F5 RID: 10485
			public float FixedElementField;
		}

		// Token: 0x0200041C RID: 1052
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <_XRPrevInvViewProjMatrix>e__FixedBuffer
		{
			// Token: 0x040028F6 RID: 10486
			public float FixedElementField;
		}

		// Token: 0x0200041D RID: 1053
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <_XRPrevViewProjMatrix>e__FixedBuffer
		{
			// Token: 0x040028F7 RID: 10487
			public float FixedElementField;
		}

		// Token: 0x0200041E RID: 1054
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <_XRPrevViewProjMatrixNoCameraTrans>e__FixedBuffer
		{
			// Token: 0x040028F8 RID: 10488
			public float FixedElementField;
		}

		// Token: 0x0200041F RID: 1055
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct <_XRPrevWorldSpaceCameraPos>e__FixedBuffer
		{
			// Token: 0x040028F9 RID: 10489
			public float FixedElementField;
		}

		// Token: 0x02000420 RID: 1056
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <_XRProjMatrix>e__FixedBuffer
		{
			// Token: 0x040028FA RID: 10490
			public float FixedElementField;
		}

		// Token: 0x02000421 RID: 1057
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <_XRViewMatrix>e__FixedBuffer
		{
			// Token: 0x040028FB RID: 10491
			public float FixedElementField;
		}

		// Token: 0x02000422 RID: 1058
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <_XRViewProjMatrix>e__FixedBuffer
		{
			// Token: 0x040028FC RID: 10492
			public float FixedElementField;
		}

		// Token: 0x02000423 RID: 1059
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <_XRViewProjMatrixNoCameraTrans>e__FixedBuffer
		{
			// Token: 0x040028FD RID: 10493
			public float FixedElementField;
		}

		// Token: 0x02000424 RID: 1060
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct <_XRWorldSpaceCameraPos>e__FixedBuffer
		{
			// Token: 0x040028FE RID: 10494
			public float FixedElementField;
		}

		// Token: 0x02000425 RID: 1061
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct <_XRWorldSpaceCameraPosViewOffset>e__FixedBuffer
		{
			// Token: 0x040028FF RID: 10495
			public float FixedElementField;
		}
	}
}
