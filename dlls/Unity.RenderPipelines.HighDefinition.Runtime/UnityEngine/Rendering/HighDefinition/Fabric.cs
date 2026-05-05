using System;
using UnityEngine.Rendering.HighDefinition.Attributes;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000102 RID: 258
	internal class Fabric : RenderPipelineMaterial
	{
		// Token: 0x06000A11 RID: 2577 RVA: 0x00055CCA File Offset: 0x00053ECA
		public override void Build(HDRenderPipelineAsset hdAsset, HDRenderPipelineRuntimeResources defaultResources)
		{
			PreIntegratedFGD.instance.Build(PreIntegratedFGD.FGDIndex.FGD_CharlieAndFabricLambert);
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x00055CD7 File Offset: 0x00053ED7
		public override void Cleanup()
		{
			PreIntegratedFGD.instance.Cleanup(PreIntegratedFGD.FGDIndex.FGD_CharlieAndFabricLambert);
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00055CE4 File Offset: 0x00053EE4
		public override void RenderInit(CommandBuffer cmd)
		{
			PreIntegratedFGD.instance.RenderInit(PreIntegratedFGD.FGDIndex.FGD_CharlieAndFabricLambert, cmd);
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x00055CF2 File Offset: 0x00053EF2
		public override void Bind(CommandBuffer cmd)
		{
			PreIntegratedFGD.instance.Bind(cmd, PreIntegratedFGD.FGDIndex.FGD_CharlieAndFabricLambert);
		}

		// Token: 0x02000389 RID: 905
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Fabric\\Fabric.cs")]
		public enum MaterialFeatureFlags
		{
			// Token: 0x040024A7 RID: 9383
			FabricCottonWool = 1,
			// Token: 0x040024A8 RID: 9384
			FabricSubsurfaceScattering,
			// Token: 0x040024A9 RID: 9385
			FabricTransmission = 4
		}

		// Token: 0x0200038A RID: 906
		[GenerateHLSL(PackingRules.Exact, false, false, true, 1300, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Fabric\\Fabric.cs")]
		public struct SurfaceData
		{
			// Token: 0x040024AA RID: 9386
			[SurfaceDataAttributes("Material Features", false, false, FieldPrecision.Default, false, "")]
			public uint materialFeatures;

			// Token: 0x040024AB RID: 9387
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Albedo)]
			[SurfaceDataAttributes("Base Color", false, true, FieldPrecision.Default, false, "")]
			public Vector3 baseColor;

			// Token: 0x040024AC RID: 9388
			[SurfaceDataAttributes("Specular Occlusion", false, false, FieldPrecision.Default, false, "")]
			public float specularOcclusion;

			// Token: 0x040024AD RID: 9389
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Normal)]
			[SurfaceDataAttributes(new string[]
			{
				"Normal",
				"Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 normalWS;

			// Token: 0x040024AE RID: 9390
			[SurfaceDataAttributes(new string[]
			{
				"Geometric Normal",
				"Geometric Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 geomNormalWS;

			// Token: 0x040024AF RID: 9391
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Smoothness)]
			[SurfaceDataAttributes("Smoothness", false, false, FieldPrecision.Default, false, "")]
			public float perceptualSmoothness;

			// Token: 0x040024B0 RID: 9392
			[MaterialSharedPropertyMapping(MaterialSharedProperty.AmbientOcclusion)]
			[SurfaceDataAttributes("Ambient Occlusion", false, false, FieldPrecision.Default, false, "")]
			public float ambientOcclusion;

			// Token: 0x040024B1 RID: 9393
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Specular)]
			[SurfaceDataAttributes("Specular Tint", false, true, FieldPrecision.Default, false, "")]
			public Vector3 specularColor;

			// Token: 0x040024B2 RID: 9394
			[SurfaceDataAttributes("Diffusion Profile Hash", false, false, FieldPrecision.Default, false, "")]
			public uint diffusionProfileHash;

			// Token: 0x040024B3 RID: 9395
			[SurfaceDataAttributes("Subsurface Mask", false, false, FieldPrecision.Default, false, "")]
			public float subsurfaceMask;

			// Token: 0x040024B4 RID: 9396
			[SurfaceDataAttributes("Transmission Mask", false, false, FieldPrecision.Default, false, "")]
			public float transmissionMask;

			// Token: 0x040024B5 RID: 9397
			[SurfaceDataAttributes("Thickness", false, false, FieldPrecision.Default, false, "")]
			public float thickness;

			// Token: 0x040024B6 RID: 9398
			[SurfaceDataAttributes("Tangent", true, false, FieldPrecision.Default, false, "")]
			public Vector3 tangentWS;

			// Token: 0x040024B7 RID: 9399
			[SurfaceDataAttributes("Anisotropy", false, false, FieldPrecision.Default, false, "")]
			public float anisotropy;
		}

		// Token: 0x0200038B RID: 907
		[GenerateHLSL(PackingRules.Exact, false, false, true, 1350, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Fabric\\Fabric.cs")]
		public struct BSDFData
		{
			// Token: 0x040024B8 RID: 9400
			public uint materialFeatures;

			// Token: 0x040024B9 RID: 9401
			[SurfaceDataAttributes("", false, true, FieldPrecision.Default, false, "")]
			public Vector3 diffuseColor;

			// Token: 0x040024BA RID: 9402
			public Vector3 fresnel0;

			// Token: 0x040024BB RID: 9403
			public float ambientOcclusion;

			// Token: 0x040024BC RID: 9404
			public float specularOcclusion;

			// Token: 0x040024BD RID: 9405
			[SurfaceDataAttributes(new string[]
			{
				"Normal WS",
				"Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 normalWS;

			// Token: 0x040024BE RID: 9406
			[SurfaceDataAttributes(new string[]
			{
				"Geometric Normal",
				"Geometric Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 geomNormalWS;

			// Token: 0x040024BF RID: 9407
			public float perceptualRoughness;

			// Token: 0x040024C0 RID: 9408
			public uint diffusionProfileIndex;

			// Token: 0x040024C1 RID: 9409
			public float subsurfaceMask;

			// Token: 0x040024C2 RID: 9410
			public float thickness;

			// Token: 0x040024C3 RID: 9411
			public bool useThickObjectMode;

			// Token: 0x040024C4 RID: 9412
			public Vector3 transmittance;

			// Token: 0x040024C5 RID: 9413
			[SurfaceDataAttributes("", true, false, FieldPrecision.Default, false, "")]
			public Vector3 tangentWS;

			// Token: 0x040024C6 RID: 9414
			[SurfaceDataAttributes("", true, false, FieldPrecision.Default, false, "")]
			public Vector3 bitangentWS;

			// Token: 0x040024C7 RID: 9415
			public float roughnessT;

			// Token: 0x040024C8 RID: 9416
			public float roughnessB;

			// Token: 0x040024C9 RID: 9417
			public float anisotropy;
		}
	}
}
