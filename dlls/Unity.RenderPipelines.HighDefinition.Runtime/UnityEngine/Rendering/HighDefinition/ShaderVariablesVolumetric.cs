using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000DC RID: 220
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Lighting\\VolumetricLighting\\HDRenderPipeline.VolumetricLighting.cs", needAccessors = false, generateCBuffer = true)]
	internal struct ShaderVariablesVolumetric
	{
		// Token: 0x04000956 RID: 2390
		[FixedBuffer(typeof(float), 32)]
		[HLSLArray(2, typeof(Matrix4x4))]
		public ShaderVariablesVolumetric.<_VBufferCoordToViewDirWS>e__FixedBuffer _VBufferCoordToViewDirWS;

		// Token: 0x04000957 RID: 2391
		public float _VBufferUnitDepthTexelSpacing;

		// Token: 0x04000958 RID: 2392
		public uint _NumVisibleLocalVolumetricFog;

		// Token: 0x04000959 RID: 2393
		public float _CornetteShanksConstant;

		// Token: 0x0400095A RID: 2394
		public uint _VBufferHistoryIsValid;

		// Token: 0x0400095B RID: 2395
		public Vector4 _VBufferSampleOffset;

		// Token: 0x0400095C RID: 2396
		public float _VBufferVoxelSize;

		// Token: 0x0400095D RID: 2397
		public float _HaveToPad;

		// Token: 0x0400095E RID: 2398
		public float _OtherwiseTheBuffer;

		// Token: 0x0400095F RID: 2399
		public float _IsFilledWithGarbage;

		// Token: 0x04000960 RID: 2400
		public Vector4 _VBufferPrevViewportSize;

		// Token: 0x04000961 RID: 2401
		public Vector4 _VBufferHistoryViewportScale;

		// Token: 0x04000962 RID: 2402
		public Vector4 _VBufferHistoryViewportLimit;

		// Token: 0x04000963 RID: 2403
		public Vector4 _VBufferPrevDistanceEncodingParams;

		// Token: 0x04000964 RID: 2404
		public Vector4 _VBufferPrevDistanceDecodingParams;

		// Token: 0x04000965 RID: 2405
		public uint _NumTileBigTileX;

		// Token: 0x04000966 RID: 2406
		public uint _NumTileBigTileY;

		// Token: 0x04000967 RID: 2407
		public uint _Pad0_SVV;

		// Token: 0x04000968 RID: 2408
		public uint _Pad1_SVV;

		// Token: 0x0200035E RID: 862
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <_VBufferCoordToViewDirWS>e__FixedBuffer
		{
			// Token: 0x04002396 RID: 9110
			public float FixedElementField;
		}
	}
}
