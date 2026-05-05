using System;
using UnityEngine.Rendering.HighDefinition.Attributes;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000101 RID: 257
	internal class Eye : RenderPipelineMaterial
	{
		// Token: 0x06000A0B RID: 2571 RVA: 0x00055C7B File Offset: 0x00053E7B
		public override void Build(HDRenderPipelineAsset hdAsset, HDRenderPipelineRuntimeResources defaultResources)
		{
			this.m_EyeCausticLUT = defaultResources.textures.eyeCausticLUT;
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x00055C8E File Offset: 0x00053E8E
		public override void Cleanup()
		{
			this.m_EyeCausticLUT = null;
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x00055C97 File Offset: 0x00053E97
		public override void RenderInit(CommandBuffer cmd)
		{
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x00055C99 File Offset: 0x00053E99
		public override void Bind(CommandBuffer cmd)
		{
			cmd.SetGlobalTexture(Eye._PreIntegratedEyeCaustic, this.m_EyeCausticLUT);
		}

		// Token: 0x04000AD7 RID: 2775
		private Texture3D m_EyeCausticLUT;

		// Token: 0x04000AD8 RID: 2776
		public static readonly int _PreIntegratedEyeCaustic = Shader.PropertyToID("_PreIntegratedEyeCaustic");

		// Token: 0x02000386 RID: 902
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Eye\\Eye.cs")]
		public enum MaterialFeatureFlags
		{
			// Token: 0x04002481 RID: 9345
			EyeCinematic = 1,
			// Token: 0x04002482 RID: 9346
			EyeSubsurfaceScattering,
			// Token: 0x04002483 RID: 9347
			EyeCausticFromLUT = 4
		}

		// Token: 0x02000387 RID: 903
		[GenerateHLSL(PackingRules.Exact, false, false, true, 1500, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Eye\\Eye.cs")]
		public struct SurfaceData
		{
			// Token: 0x04002484 RID: 9348
			[SurfaceDataAttributes("Material Features", false, false, FieldPrecision.Default, false, "")]
			public uint materialFeatures;

			// Token: 0x04002485 RID: 9349
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Albedo)]
			[SurfaceDataAttributes("Base Color", false, true, FieldPrecision.Default, false, "")]
			public Vector3 baseColor;

			// Token: 0x04002486 RID: 9350
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Normal)]
			[SurfaceDataAttributes(new string[]
			{
				"Normal",
				"Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 normalWS;

			// Token: 0x04002487 RID: 9351
			[SurfaceDataAttributes(new string[]
			{
				"Iris Normal",
				"Iris Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 irisNormalWS;

			// Token: 0x04002488 RID: 9352
			[SurfaceDataAttributes(new string[]
			{
				"Geometric Normal",
				"Geometric Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 geomNormalWS;

			// Token: 0x04002489 RID: 9353
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Smoothness)]
			[SurfaceDataAttributes("Smoothness", false, false, FieldPrecision.Default, false, "")]
			public float perceptualSmoothness;

			// Token: 0x0400248A RID: 9354
			[MaterialSharedPropertyMapping(MaterialSharedProperty.AmbientOcclusion)]
			[SurfaceDataAttributes("Ambient Occlusion", false, false, FieldPrecision.Default, false, "")]
			public float ambientOcclusion;

			// Token: 0x0400248B RID: 9355
			[SurfaceDataAttributes("Specular Occlusion", false, false, FieldPrecision.Default, false, "")]
			public float specularOcclusion;

			// Token: 0x0400248C RID: 9356
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Specular)]
			[SurfaceDataAttributes("IOR", false, true, FieldPrecision.Default, false, "")]
			public float IOR;

			// Token: 0x0400248D RID: 9357
			[SurfaceDataAttributes("Mask", false, true, FieldPrecision.Default, false, "")]
			public Vector2 mask;

			// Token: 0x0400248E RID: 9358
			[SurfaceDataAttributes("Diffusion Profile Hash", false, false, FieldPrecision.Default, false, "")]
			public uint diffusionProfileHash;

			// Token: 0x0400248F RID: 9359
			[SurfaceDataAttributes("Subsurface Mask", false, false, FieldPrecision.Default, false, "")]
			public float subsurfaceMask;

			// Token: 0x04002490 RID: 9360
			[SurfaceDataAttributes("Iris Plane Offset", false, false, FieldPrecision.Default, false, "")]
			public float irisPlaneOffset;

			// Token: 0x04002491 RID: 9361
			[SurfaceDataAttributes("Iris Radius", false, false, FieldPrecision.Default, false, "")]
			public float irisRadius;

			// Token: 0x04002492 RID: 9362
			[SurfaceDataAttributes("Caustic intensity multiplier", false, false, FieldPrecision.Default, false, "")]
			public float causticIntensity;

			// Token: 0x04002493 RID: 9363
			[SurfaceDataAttributes("Blending factor between caustic and cinematic diffuse", false, false, FieldPrecision.Default, false, "")]
			public float causticBlend;
		}

		// Token: 0x02000388 RID: 904
		[GenerateHLSL(PackingRules.Exact, false, false, true, 1550, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Eye\\Eye.cs")]
		public struct BSDFData
		{
			// Token: 0x04002494 RID: 9364
			public uint materialFeatures;

			// Token: 0x04002495 RID: 9365
			[SurfaceDataAttributes("", false, true, FieldPrecision.Default, false, "")]
			public Vector3 diffuseColor;

			// Token: 0x04002496 RID: 9366
			public Vector3 fresnel0;

			// Token: 0x04002497 RID: 9367
			public float IOR;

			// Token: 0x04002498 RID: 9368
			public float ambientOcclusion;

			// Token: 0x04002499 RID: 9369
			public float specularOcclusion;

			// Token: 0x0400249A RID: 9370
			[SurfaceDataAttributes(new string[]
			{
				"Normal WS",
				"Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 normalWS;

			// Token: 0x0400249B RID: 9371
			[SurfaceDataAttributes(new string[]
			{
				"Diffuse Normal WS",
				"Diffuse Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 diffuseNormalWS;

			// Token: 0x0400249C RID: 9372
			[SurfaceDataAttributes(new string[]
			{
				"Geometric Normal",
				"Geometric Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 geomNormalWS;

			// Token: 0x0400249D RID: 9373
			public float perceptualRoughness;

			// Token: 0x0400249E RID: 9374
			public Vector2 mask;

			// Token: 0x0400249F RID: 9375
			public float irisPlaneOffset;

			// Token: 0x040024A0 RID: 9376
			public float irisRadius;

			// Token: 0x040024A1 RID: 9377
			public float causticIntensity;

			// Token: 0x040024A2 RID: 9378
			public float causticBlend;

			// Token: 0x040024A3 RID: 9379
			public uint diffusionProfileIndex;

			// Token: 0x040024A4 RID: 9380
			public float subsurfaceMask;

			// Token: 0x040024A5 RID: 9381
			public float roughness;
		}
	}
}
