using System;
using UnityEngine.Rendering.HighDefinition.Attributes;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200010B RID: 267
	internal class Lit : RenderPipelineMaterial
	{
		// Token: 0x06000A48 RID: 2632 RVA: 0x00057FC2 File Offset: 0x000561C2
		public override bool IsDefferedMaterial()
		{
			return true;
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x00057FCD File Offset: 0x000561CD
		public override void Build(HDRenderPipelineAsset hdAsset, HDRenderPipelineRuntimeResources defaultResources)
		{
			PreIntegratedFGD.instance.Build(PreIntegratedFGD.FGDIndex.FGD_GGXAndDisneyDiffuse);
			LTCAreaLight.instance.Build();
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x00057FE4 File Offset: 0x000561E4
		public override void Cleanup()
		{
			PreIntegratedFGD.instance.Cleanup(PreIntegratedFGD.FGDIndex.FGD_GGXAndDisneyDiffuse);
			LTCAreaLight.instance.Cleanup();
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x00057FFB File Offset: 0x000561FB
		public override void RenderInit(CommandBuffer cmd)
		{
			PreIntegratedFGD.instance.RenderInit(PreIntegratedFGD.FGDIndex.FGD_GGXAndDisneyDiffuse, cmd);
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x00058009 File Offset: 0x00056209
		public override void Bind(CommandBuffer cmd)
		{
			PreIntegratedFGD.instance.Bind(cmd, PreIntegratedFGD.FGDIndex.FGD_GGXAndDisneyDiffuse);
			LTCAreaLight.instance.Bind(cmd);
		}

		// Token: 0x02000390 RID: 912
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Lit\\Lit.cs")]
		public enum MaterialFeatureFlags
		{
			// Token: 0x04002516 RID: 9494
			LitStandard = 1,
			// Token: 0x04002517 RID: 9495
			LitSpecularColor,
			// Token: 0x04002518 RID: 9496
			LitSubsurfaceScattering = 4,
			// Token: 0x04002519 RID: 9497
			LitTransmission = 8,
			// Token: 0x0400251A RID: 9498
			LitAnisotropy = 16,
			// Token: 0x0400251B RID: 9499
			LitIridescence = 32,
			// Token: 0x0400251C RID: 9500
			LitClearCoat = 64
		}

		// Token: 0x02000391 RID: 913
		[GenerateHLSL(PackingRules.Exact, false, false, true, 1000, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Lit\\Lit.cs")]
		public struct SurfaceData
		{
			// Token: 0x0400251D RID: 9501
			[SurfaceDataAttributes("Material Features", false, false, FieldPrecision.Default, false, "")]
			public uint materialFeatures;

			// Token: 0x0400251E RID: 9502
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Albedo)]
			[SurfaceDataAttributes("Base Color", false, true, FieldPrecision.Real, false, "")]
			public Vector3 baseColor;

			// Token: 0x0400251F RID: 9503
			[SurfaceDataAttributes("Specular Occlusion", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float specularOcclusion;

			// Token: 0x04002520 RID: 9504
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Normal)]
			[SurfaceDataAttributes(new string[]
			{
				"Normal",
				"Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 normalWS;

			// Token: 0x04002521 RID: 9505
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Smoothness)]
			[SurfaceDataAttributes("Smoothness", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float perceptualSmoothness;

			// Token: 0x04002522 RID: 9506
			[MaterialSharedPropertyMapping(MaterialSharedProperty.AmbientOcclusion)]
			[SurfaceDataAttributes("Ambient Occlusion", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float ambientOcclusion;

			// Token: 0x04002523 RID: 9507
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Metal)]
			[SurfaceDataAttributes("Metallic", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float metallic;

			// Token: 0x04002524 RID: 9508
			[SurfaceDataAttributes("Coat mask", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float coatMask;

			// Token: 0x04002525 RID: 9509
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Specular)]
			[SurfaceDataAttributes("Specular Color", false, true, FieldPrecision.Real, false, "")]
			public Vector3 specularColor;

			// Token: 0x04002526 RID: 9510
			[SurfaceDataAttributes("Diffusion Profile Hash", false, false, FieldPrecision.Default, false, "")]
			public uint diffusionProfileHash;

			// Token: 0x04002527 RID: 9511
			[SurfaceDataAttributes("Subsurface Mask", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float subsurfaceMask;

			// Token: 0x04002528 RID: 9512
			[SurfaceDataAttributes("Transmission Mask", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float transmissionMask;

			// Token: 0x04002529 RID: 9513
			[SurfaceDataAttributes("Thickness", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float thickness;

			// Token: 0x0400252A RID: 9514
			[SurfaceDataAttributes("Tangent", true, false, FieldPrecision.Default, false, "")]
			public Vector3 tangentWS;

			// Token: 0x0400252B RID: 9515
			[SurfaceDataAttributes("Anisotropy", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float anisotropy;

			// Token: 0x0400252C RID: 9516
			[SurfaceDataAttributes("Iridescence Layer Thickness", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float iridescenceThickness;

			// Token: 0x0400252D RID: 9517
			[SurfaceDataAttributes("Iridescence Mask", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float iridescenceMask;

			// Token: 0x0400252E RID: 9518
			[SurfaceDataAttributes(new string[]
			{
				"Geometric Normal",
				"Geometric Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real, checkIsNormalized = true)]
			public Vector3 geomNormalWS;

			// Token: 0x0400252F RID: 9519
			[SurfaceDataAttributes("Index of refraction", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float ior;

			// Token: 0x04002530 RID: 9520
			[SurfaceDataAttributes("Transmittance Color", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public Vector3 transmittanceColor;

			// Token: 0x04002531 RID: 9521
			[SurfaceDataAttributes("Transmittance Absorption Distance", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float atDistance;

			// Token: 0x04002532 RID: 9522
			[SurfaceDataAttributes("Transmittance Mask", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float transmittanceMask;
		}

		// Token: 0x02000392 RID: 914
		[GenerateHLSL(PackingRules.Exact, false, false, true, 1050, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Lit\\Lit.cs")]
		public struct BSDFData
		{
			// Token: 0x04002533 RID: 9523
			public uint materialFeatures;

			// Token: 0x04002534 RID: 9524
			[SurfaceDataAttributes("", false, true, FieldPrecision.Real, false, "")]
			public Vector3 diffuseColor;

			// Token: 0x04002535 RID: 9525
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public Vector3 fresnel0;

			// Token: 0x04002536 RID: 9526
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float ambientOcclusion;

			// Token: 0x04002537 RID: 9527
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float specularOcclusion;

			// Token: 0x04002538 RID: 9528
			[SurfaceDataAttributes(new string[]
			{
				"Normal WS",
				"Normal View Space"
			}, true, false, FieldPrecision.Default, true, "")]
			public Vector3 normalWS;

			// Token: 0x04002539 RID: 9529
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float perceptualRoughness;

			// Token: 0x0400253A RID: 9530
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float coatMask;

			// Token: 0x0400253B RID: 9531
			public uint diffusionProfileIndex;

			// Token: 0x0400253C RID: 9532
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float subsurfaceMask;

			// Token: 0x0400253D RID: 9533
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float thickness;

			// Token: 0x0400253E RID: 9534
			public bool useThickObjectMode;

			// Token: 0x0400253F RID: 9535
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public Vector3 transmittance;

			// Token: 0x04002540 RID: 9536
			[SurfaceDataAttributes("", true, false, FieldPrecision.Default, false, "")]
			public Vector3 tangentWS;

			// Token: 0x04002541 RID: 9537
			[SurfaceDataAttributes("", true, false, FieldPrecision.Default, false, "")]
			public Vector3 bitangentWS;

			// Token: 0x04002542 RID: 9538
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float roughnessT;

			// Token: 0x04002543 RID: 9539
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float roughnessB;

			// Token: 0x04002544 RID: 9540
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float anisotropy;

			// Token: 0x04002545 RID: 9541
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float iridescenceThickness;

			// Token: 0x04002546 RID: 9542
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float iridescenceMask;

			// Token: 0x04002547 RID: 9543
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float coatRoughness;

			// Token: 0x04002548 RID: 9544
			[SurfaceDataAttributes(new string[]
			{
				"Geometric Normal",
				"Geometric Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real, checkIsNormalized = true)]
			public Vector3 geomNormalWS;

			// Token: 0x04002549 RID: 9545
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float ior;

			// Token: 0x0400254A RID: 9546
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public Vector3 absorptionCoefficient;

			// Token: 0x0400254B RID: 9547
			[SurfaceDataAttributes("", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float transmittanceMask;
		}
	}
}
