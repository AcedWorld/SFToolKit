using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000034 RID: 52
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Debug\\DebugDisplay.cs", needAccessors = false, generateCBuffer = true)]
	internal struct ShaderVariablesDebugDisplay
	{
		// Token: 0x040000ED RID: 237
		[FixedBuffer(typeof(float), 128)]
		[HLSLArray(32, typeof(Vector4))]
		public ShaderVariablesDebugDisplay.<_DebugRenderingLayersColors>e__FixedBuffer _DebugRenderingLayersColors;

		// Token: 0x040000EE RID: 238
		[FixedBuffer(typeof(uint), 44)]
		[HLSLArray(11, typeof(ShaderGenUInt4))]
		public ShaderVariablesDebugDisplay.<_DebugViewMaterialArray>e__FixedBuffer _DebugViewMaterialArray;

		// Token: 0x040000EF RID: 239
		[FixedBuffer(typeof(float), 28)]
		[HLSLArray(7, typeof(Vector4))]
		public ShaderVariablesDebugDisplay.<_DebugAPVSubdivColors>e__FixedBuffer _DebugAPVSubdivColors;

		// Token: 0x040000F0 RID: 240
		public int _DebugLightingMode;

		// Token: 0x040000F1 RID: 241
		public int _DebugLightLayersMask;

		// Token: 0x040000F2 RID: 242
		public int _DebugShadowMapMode;

		// Token: 0x040000F3 RID: 243
		public int _DebugMipMapMode;

		// Token: 0x040000F4 RID: 244
		public int _DebugFullScreenMode;

		// Token: 0x040000F5 RID: 245
		public float _DebugTransparencyOverdrawWeight;

		// Token: 0x040000F6 RID: 246
		public int _DebugMipMapModeTerrainTexture;

		// Token: 0x040000F7 RID: 247
		public int _ColorPickerMode;

		// Token: 0x040000F8 RID: 248
		public Vector4 _DebugViewportSize;

		// Token: 0x040000F9 RID: 249
		public Vector4 _DebugLightingAlbedo;

		// Token: 0x040000FA RID: 250
		public Vector4 _DebugLightingSmoothness;

		// Token: 0x040000FB RID: 251
		public Vector4 _DebugLightingNormal;

		// Token: 0x040000FC RID: 252
		public Vector4 _DebugLightingAmbientOcclusion;

		// Token: 0x040000FD RID: 253
		public Vector4 _DebugLightingSpecularColor;

		// Token: 0x040000FE RID: 254
		public Vector4 _DebugLightingEmissiveColor;

		// Token: 0x040000FF RID: 255
		public Vector4 _DebugLightingMaterialValidateHighColor;

		// Token: 0x04000100 RID: 256
		public Vector4 _DebugLightingMaterialValidateLowColor;

		// Token: 0x04000101 RID: 257
		public Vector4 _DebugLightingMaterialValidatePureMetalColor;

		// Token: 0x04000102 RID: 258
		public Vector4 _MousePixelCoord;

		// Token: 0x04000103 RID: 259
		public Vector4 _MouseClickPixelCoord;

		// Token: 0x04000104 RID: 260
		public int _MatcapMixAlbedo;

		// Token: 0x04000105 RID: 261
		public float _MatcapViewScale;

		// Token: 0x04000106 RID: 262
		public int _DebugSingleShadowIndex;

		// Token: 0x04000107 RID: 263
		public int _DebugIsLitShaderModeDeferred;

		// Token: 0x04000108 RID: 264
		public int _DebugAOVOutput;

		// Token: 0x04000109 RID: 265
		public float _ShaderVariablesDebugDisplayPad0;

		// Token: 0x0400010A RID: 266
		public float _ShaderVariablesDebugDisplayPad1;

		// Token: 0x0400010B RID: 267
		public float _ShaderVariablesDebugDisplayPad2;

		// Token: 0x02000253 RID: 595
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 112)]
		public struct <_DebugAPVSubdivColors>e__FixedBuffer
		{
			// Token: 0x04001A06 RID: 6662
			public float FixedElementField;
		}

		// Token: 0x02000254 RID: 596
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 512)]
		public struct <_DebugRenderingLayersColors>e__FixedBuffer
		{
			// Token: 0x04001A07 RID: 6663
			public float FixedElementField;
		}

		// Token: 0x02000255 RID: 597
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 176)]
		public struct <_DebugViewMaterialArray>e__FixedBuffer
		{
			// Token: 0x04001A08 RID: 6664
			public uint FixedElementField;
		}
	}
}
