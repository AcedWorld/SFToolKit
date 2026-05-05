using System;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering.HighDefinition.Attributes;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000F4 RID: 244
	internal class Builtin
	{
		// Token: 0x06000987 RID: 2439 RVA: 0x00053E59 File Offset: 0x00052059
		public static GraphicsFormat GetLightingBufferFormat()
		{
			return GraphicsFormat.B10G11R11_UFloatPack32;
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x00053E5D File Offset: 0x0005205D
		public static GraphicsFormat GetShadowMaskBufferFormat()
		{
			return GraphicsFormat.R8G8B8A8_UNorm;
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x00053E60 File Offset: 0x00052060
		public static GraphicsFormat GetMotionVectorFormat()
		{
			return GraphicsFormat.R16G16_SFloat;
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x00053E64 File Offset: 0x00052064
		public static GraphicsFormat GetDistortionBufferFormat()
		{
			return GraphicsFormat.R16G16B16A16_SFloat;
		}

		// Token: 0x02000374 RID: 884
		[GenerateHLSL(PackingRules.Exact, false, false, true, 100, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Builtin\\BuiltinData.cs")]
		public struct BuiltinData
		{
			// Token: 0x04002402 RID: 9218
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Alpha)]
			[SurfaceDataAttributes("Opacity", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float opacity;

			// Token: 0x04002403 RID: 9219
			[SurfaceDataAttributes("AlphaClipTreshold", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float alphaClipTreshold;

			// Token: 0x04002404 RID: 9220
			[SurfaceDataAttributes("Baked Diffuse Lighting", false, true, FieldPrecision.Real, false, "")]
			public Vector3 bakeDiffuseLighting;

			// Token: 0x04002405 RID: 9221
			[SurfaceDataAttributes("Back Baked Diffuse Lighting", false, true, FieldPrecision.Real, false, "")]
			public Vector3 backBakeDiffuseLighting;

			// Token: 0x04002406 RID: 9222
			[SurfaceDataAttributes("Shadowmask 0", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float shadowMask0;

			// Token: 0x04002407 RID: 9223
			[SurfaceDataAttributes("Shadowmask 1", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float shadowMask1;

			// Token: 0x04002408 RID: 9224
			[SurfaceDataAttributes("Shadowmask 2", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float shadowMask2;

			// Token: 0x04002409 RID: 9225
			[SurfaceDataAttributes("Shadowmask 3", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float shadowMask3;

			// Token: 0x0400240A RID: 9226
			[SurfaceDataAttributes("Emissive Color", false, false, FieldPrecision.Real, false, "")]
			public Vector3 emissiveColor;

			// Token: 0x0400240B RID: 9227
			[SurfaceDataAttributes("Motion Vector", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public Vector2 motionVector;

			// Token: 0x0400240C RID: 9228
			[SurfaceDataAttributes("Distortion", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public Vector2 distortion;

			// Token: 0x0400240D RID: 9229
			[SurfaceDataAttributes("Distortion Blur", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float distortionBlur;

			// Token: 0x0400240E RID: 9230
			[SurfaceDataAttributes("Is Lightmap", false, false, FieldPrecision.Default, false, "")]
			public uint isLightmap;

			// Token: 0x0400240F RID: 9231
			[SurfaceDataAttributes("Rendering Layers", false, false, FieldPrecision.Default, false, "")]
			public uint renderingLayers;

			// Token: 0x04002410 RID: 9232
			[SurfaceDataAttributes("Depth Offset", false, false, FieldPrecision.Default, false, "")]
			public float depthOffset;

			// Token: 0x04002411 RID: 9233
			[SurfaceDataAttributes("VT Packed Feedback", false, false, FieldPrecision.Real, false, "defined(UNITY_VIRTUAL_TEXTURING)")]
			public Vector4 vtPackedFeedback;
		}

		// Token: 0x02000375 RID: 885
		[GenerateHLSL(PackingRules.Exact, false, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Builtin\\BuiltinData.cs")]
		public struct LightTransportData
		{
			// Token: 0x04002412 RID: 9234
			[SurfaceDataAttributes("", false, true, FieldPrecision.Real, false, "")]
			public Vector3 diffuseColor;

			// Token: 0x04002413 RID: 9235
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public Vector3 emissiveColor;
		}
	}
}
