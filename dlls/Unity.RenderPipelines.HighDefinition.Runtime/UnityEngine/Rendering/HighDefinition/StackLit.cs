using System;
using UnityEngine.Rendering.HighDefinition.Attributes;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000113 RID: 275
	internal class StackLit : RenderPipelineMaterial
	{
		// Token: 0x06000A79 RID: 2681 RVA: 0x00059244 File Offset: 0x00057444
		public override void Build(HDRenderPipelineAsset hdAsset, HDRenderPipelineRuntimeResources defaultResources)
		{
			PreIntegratedFGD.instance.Build(PreIntegratedFGD.FGDIndex.FGD_GGXAndDisneyDiffuse);
			LTCAreaLight.instance.Build();
			SPTDistribution.instance.Build();
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x00059265 File Offset: 0x00057465
		public override void Cleanup()
		{
			PreIntegratedFGD.instance.Cleanup(PreIntegratedFGD.FGDIndex.FGD_GGXAndDisneyDiffuse);
			LTCAreaLight.instance.Cleanup();
			SPTDistribution.instance.Cleanup();
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x00059286 File Offset: 0x00057486
		public override void RenderInit(CommandBuffer cmd)
		{
			PreIntegratedFGD.instance.RenderInit(PreIntegratedFGD.FGDIndex.FGD_GGXAndDisneyDiffuse, cmd);
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x00059294 File Offset: 0x00057494
		public override void Bind(CommandBuffer cmd)
		{
			PreIntegratedFGD.instance.Bind(cmd, PreIntegratedFGD.FGDIndex.FGD_GGXAndDisneyDiffuse);
			LTCAreaLight.instance.Bind(cmd);
			SPTDistribution.instance.Bind(cmd);
		}

		// Token: 0x0200039A RID: 922
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\StackLit\\StackLit.cs")]
		public enum MaterialFeatureFlags
		{
			// Token: 0x04002571 RID: 9585
			StackLitStandard = 1,
			// Token: 0x04002572 RID: 9586
			StackLitDualSpecularLobe,
			// Token: 0x04002573 RID: 9587
			StackLitAnisotropy = 4,
			// Token: 0x04002574 RID: 9588
			StackLitCoat = 8,
			// Token: 0x04002575 RID: 9589
			StackLitIridescence = 16,
			// Token: 0x04002576 RID: 9590
			StackLitSubsurfaceScattering = 32,
			// Token: 0x04002577 RID: 9591
			StackLitTransmission = 64,
			// Token: 0x04002578 RID: 9592
			StackLitCoatNormalMap = 128,
			// Token: 0x04002579 RID: 9593
			StackLitSpecularColor = 256,
			// Token: 0x0400257A RID: 9594
			StackLitHazyGloss = 512
		}

		// Token: 0x0200039B RID: 923
		public enum BaseParametrization
		{
			// Token: 0x0400257C RID: 9596
			BaseMetallic,
			// Token: 0x0400257D RID: 9597
			SpecularColor
		}

		// Token: 0x0200039C RID: 924
		public enum DualSpecularLobeParametrization
		{
			// Token: 0x0400257F RID: 9599
			Direct,
			// Token: 0x04002580 RID: 9600
			HazyGloss
		}

		// Token: 0x0200039D RID: 925
		[GenerateHLSL(PackingRules.Exact, false, false, true, 1100, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\StackLit\\StackLit.cs")]
		public struct SurfaceData
		{
			// Token: 0x04002581 RID: 9601
			[SurfaceDataAttributes("Material Features", false, false, FieldPrecision.Default, false, "")]
			public uint materialFeatures;

			// Token: 0x04002582 RID: 9602
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Albedo)]
			[SurfaceDataAttributes("Base Color", false, true, FieldPrecision.Default, false, "")]
			public Vector3 baseColor;

			// Token: 0x04002583 RID: 9603
			[MaterialSharedPropertyMapping(MaterialSharedProperty.AmbientOcclusion)]
			[SurfaceDataAttributes("Ambient Occlusion", false, false, FieldPrecision.Default, false, "")]
			public float ambientOcclusion;

			// Token: 0x04002584 RID: 9604
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Metal)]
			[SurfaceDataAttributes("Metallic", false, false, FieldPrecision.Default, false, "")]
			public float metallic;

			// Token: 0x04002585 RID: 9605
			[SurfaceDataAttributes("Dielectric IOR", false, false, FieldPrecision.Default, false, "")]
			public float dielectricIor;

			// Token: 0x04002586 RID: 9606
			[SurfaceDataAttributes("Use Profile IOR", false, false, FieldPrecision.Default, false, "")]
			public bool useProfileIor;

			// Token: 0x04002587 RID: 9607
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Specular)]
			[SurfaceDataAttributes("Specular Color", false, true, FieldPrecision.Default, false, "")]
			public Vector3 specularColor;

			// Token: 0x04002588 RID: 9608
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Normal)]
			[SurfaceDataAttributes(new string[]
			{
				"Normal",
				"Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 normalWS;

			// Token: 0x04002589 RID: 9609
			[SurfaceDataAttributes(new string[]
			{
				"Geometric Normal",
				"Geometric Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 geomNormalWS;

			// Token: 0x0400258A RID: 9610
			[SurfaceDataAttributes(new string[]
			{
				"Coat Normal",
				"Coat Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 coatNormalWS;

			// Token: 0x0400258B RID: 9611
			[SurfaceDataAttributes(new string[]
			{
				"Bent Normal",
				"Bent Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 bentNormalWS;

			// Token: 0x0400258C RID: 9612
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Smoothness)]
			[SurfaceDataAttributes("Smoothness A", false, false, FieldPrecision.Default, false, "")]
			public float perceptualSmoothnessA;

			// Token: 0x0400258D RID: 9613
			[SurfaceDataAttributes("Smoothness B", false, false, FieldPrecision.Default, false, "")]
			public float perceptualSmoothnessB;

			// Token: 0x0400258E RID: 9614
			[SurfaceDataAttributes("Lobe Mixing", false, false, FieldPrecision.Default, false, "")]
			public float lobeMix;

			// Token: 0x0400258F RID: 9615
			[SurfaceDataAttributes("Haziness", false, false, FieldPrecision.Default, false, "")]
			public float haziness;

			// Token: 0x04002590 RID: 9616
			[SurfaceDataAttributes("Haze Extent", false, false, FieldPrecision.Default, false, "")]
			public float hazeExtent;

			// Token: 0x04002591 RID: 9617
			[SurfaceDataAttributes("Hazy Gloss Max Dielectric f0 When Using Metallic Input", false, false, FieldPrecision.Default, false, "")]
			public float hazyGlossMaxDielectricF0;

			// Token: 0x04002592 RID: 9618
			[SurfaceDataAttributes("Tangent", true, false, FieldPrecision.Default, false, "")]
			public Vector3 tangentWS;

			// Token: 0x04002593 RID: 9619
			[SurfaceDataAttributes("AnisotropyA", false, false, FieldPrecision.Default, false, "")]
			public float anisotropyA;

			// Token: 0x04002594 RID: 9620
			[SurfaceDataAttributes("AnisotropyB", false, false, FieldPrecision.Default, false, "")]
			public float anisotropyB;

			// Token: 0x04002595 RID: 9621
			[SurfaceDataAttributes("Iridescence Ior", false, false, FieldPrecision.Default, false, "")]
			public float iridescenceIor;

			// Token: 0x04002596 RID: 9622
			[SurfaceDataAttributes("Iridescence Layer Thickness", false, false, FieldPrecision.Default, false, "")]
			public float iridescenceThickness;

			// Token: 0x04002597 RID: 9623
			[SurfaceDataAttributes("Iridescence Mask", false, false, FieldPrecision.Default, false, "")]
			public float iridescenceMask;

			// Token: 0x04002598 RID: 9624
			[SurfaceDataAttributes("Iridescence Coat Fixup TIR", false, false, FieldPrecision.Default, false, "")]
			public float iridescenceCoatFixupTIR;

			// Token: 0x04002599 RID: 9625
			[SurfaceDataAttributes("Iridescence Coat Fixup TIR Clamp", false, false, FieldPrecision.Default, false, "")]
			public float iridescenceCoatFixupTIRClamp;

			// Token: 0x0400259A RID: 9626
			[SurfaceDataAttributes("Coat Smoothness", false, false, FieldPrecision.Default, false, "")]
			public float coatPerceptualSmoothness;

			// Token: 0x0400259B RID: 9627
			[SurfaceDataAttributes("Coat mask", false, false, FieldPrecision.Default, false, "")]
			public float coatMask;

			// Token: 0x0400259C RID: 9628
			[SurfaceDataAttributes("Coat IOR", false, false, FieldPrecision.Default, false, "")]
			public float coatIor;

			// Token: 0x0400259D RID: 9629
			[SurfaceDataAttributes("Coat Thickness", false, false, FieldPrecision.Default, false, "")]
			public float coatThickness;

			// Token: 0x0400259E RID: 9630
			[SurfaceDataAttributes("Coat Extinction Coefficient", false, false, FieldPrecision.Default, false, "")]
			public Vector3 coatExtinction;

			// Token: 0x0400259F RID: 9631
			[SurfaceDataAttributes("Diffusion Profile Hash", false, false, FieldPrecision.Default, false, "")]
			public uint diffusionProfileHash;

			// Token: 0x040025A0 RID: 9632
			[SurfaceDataAttributes("Subsurface Mask", false, false, FieldPrecision.Default, false, "")]
			public float subsurfaceMask;

			// Token: 0x040025A1 RID: 9633
			[SurfaceDataAttributes("Transmission Mask", false, false, FieldPrecision.Default, false, "")]
			public float transmissionMask;

			// Token: 0x040025A2 RID: 9634
			[SurfaceDataAttributes("Thickness", false, false, FieldPrecision.Default, false, "")]
			public float thickness;

			// Token: 0x040025A3 RID: 9635
			[SurfaceDataAttributes("Specular Occlusion From Custom Input", false, false, FieldPrecision.Default, false, "")]
			public float specularOcclusionCustomInput;

			// Token: 0x040025A4 RID: 9636
			[SurfaceDataAttributes("Specular Occlusion Fixup Visibility Ratio Threshold", false, false, FieldPrecision.Default, false, "")]
			public float soFixupVisibilityRatioThreshold;

			// Token: 0x040025A5 RID: 9637
			[SurfaceDataAttributes("Specular Occlusion Fixup Strength", false, false, FieldPrecision.Default, false, "")]
			public float soFixupStrengthFactor;

			// Token: 0x040025A6 RID: 9638
			[SurfaceDataAttributes("Specular Occlusion Fixup Max Added Roughness", false, false, FieldPrecision.Default, false, "")]
			public float soFixupMaxAddedRoughness;
		}

		// Token: 0x0200039E RID: 926
		[GenerateHLSL(PackingRules.Exact, false, false, true, 1150, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\StackLit\\StackLit.cs")]
		public struct BSDFData
		{
			// Token: 0x040025A7 RID: 9639
			public uint materialFeatures;

			// Token: 0x040025A8 RID: 9640
			[SurfaceDataAttributes("", false, true, FieldPrecision.Default, false, "")]
			public Vector3 diffuseColor;

			// Token: 0x040025A9 RID: 9641
			public Vector3 fresnel0;

			// Token: 0x040025AA RID: 9642
			public float ambientOcclusion;

			// Token: 0x040025AB RID: 9643
			[SurfaceDataAttributes(new string[]
			{
				"Normal WS",
				"Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 normalWS;

			// Token: 0x040025AC RID: 9644
			[SurfaceDataAttributes(new string[]
			{
				"Geometric Normal",
				"Geometric Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 geomNormalWS;

			// Token: 0x040025AD RID: 9645
			[SurfaceDataAttributes(new string[]
			{
				"Coat Normal",
				"Coat Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 coatNormalWS;

			// Token: 0x040025AE RID: 9646
			[SurfaceDataAttributes(new string[]
			{
				"Bent Normal",
				"Bent Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 bentNormalWS;

			// Token: 0x040025AF RID: 9647
			public float perceptualRoughnessA;

			// Token: 0x040025B0 RID: 9648
			public float perceptualRoughnessB;

			// Token: 0x040025B1 RID: 9649
			public float lobeMix;

			// Token: 0x040025B2 RID: 9650
			[SurfaceDataAttributes("", true, false, FieldPrecision.Default, false, "")]
			public Vector3 tangentWS;

			// Token: 0x040025B3 RID: 9651
			[SurfaceDataAttributes("", true, false, FieldPrecision.Default, false, "")]
			public Vector3 bitangentWS;

			// Token: 0x040025B4 RID: 9652
			public float roughnessAT;

			// Token: 0x040025B5 RID: 9653
			public float roughnessAB;

			// Token: 0x040025B6 RID: 9654
			public float roughnessBT;

			// Token: 0x040025B7 RID: 9655
			public float roughnessBB;

			// Token: 0x040025B8 RID: 9656
			public float anisotropyA;

			// Token: 0x040025B9 RID: 9657
			public float anisotropyB;

			// Token: 0x040025BA RID: 9658
			public float coatRoughness;

			// Token: 0x040025BB RID: 9659
			public float coatPerceptualRoughness;

			// Token: 0x040025BC RID: 9660
			public float coatMask;

			// Token: 0x040025BD RID: 9661
			public float coatIor;

			// Token: 0x040025BE RID: 9662
			public float coatThickness;

			// Token: 0x040025BF RID: 9663
			public Vector3 coatExtinction;

			// Token: 0x040025C0 RID: 9664
			public float iridescenceIor;

			// Token: 0x040025C1 RID: 9665
			public float iridescenceThickness;

			// Token: 0x040025C2 RID: 9666
			public float iridescenceMask;

			// Token: 0x040025C3 RID: 9667
			public float iridescenceCoatFixupTIR;

			// Token: 0x040025C4 RID: 9668
			public float iridescenceCoatFixupTIRClamp;

			// Token: 0x040025C5 RID: 9669
			public uint diffusionProfileIndex;

			// Token: 0x040025C6 RID: 9670
			public float subsurfaceMask;

			// Token: 0x040025C7 RID: 9671
			public float thickness;

			// Token: 0x040025C8 RID: 9672
			public bool useThickObjectMode;

			// Token: 0x040025C9 RID: 9673
			public Vector3 transmittance;

			// Token: 0x040025CA RID: 9674
			public float specularOcclusionCustomInput;

			// Token: 0x040025CB RID: 9675
			public float soFixupVisibilityRatioThreshold;

			// Token: 0x040025CC RID: 9676
			public float soFixupStrengthFactor;

			// Token: 0x040025CD RID: 9677
			public float soFixupMaxAddedRoughness;
		}
	}
}
