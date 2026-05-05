using System;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering.HighDefinition.Attributes;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000107 RID: 263
	internal class Hair : RenderPipelineMaterial
	{
		// Token: 0x06000A31 RID: 2609 RVA: 0x00056D98 File Offset: 0x00054F98
		public override void Build(HDRenderPipelineAsset hdAsset, HDRenderPipelineRuntimeResources defaultResources)
		{
			PreIntegratedFGD.instance.Build(PreIntegratedFGD.FGDIndex.FGD_GGXAndDisneyDiffuse);
			LTCAreaLight.instance.Build();
			this.m_PreIntegratedFiberScatteringLUT = new RenderTexture(64, 64, 0, GraphicsFormat.R16G16_SFloat)
			{
				dimension = TextureDimension.Tex3D,
				volumeDepth = 64,
				enableRandomWrite = true,
				hideFlags = HideFlags.HideAndDontSave,
				filterMode = FilterMode.Point,
				wrapMode = TextureWrapMode.Clamp,
				name = CoreUtils.GetRenderTargetAutoName(64, 64, 0, GraphicsFormat.R16G16_SFloat, "PreIntegratedFiberScattering", false, false, MSAASamples.None)
			};
			this.m_PreIntegratedFiberScatteringLUT.Create();
			this.m_PreIntegratedFiberAverageScatteringLUT = new RenderTexture(64, 64, 0, GraphicsFormat.R16G16B16A16_SFloat)
			{
				dimension = TextureDimension.Tex3D,
				volumeDepth = 64,
				enableRandomWrite = true,
				hideFlags = HideFlags.HideAndDontSave,
				filterMode = FilterMode.Point,
				wrapMode = TextureWrapMode.Clamp,
				name = CoreUtils.GetRenderTargetAutoName(64, 64, 0, GraphicsFormat.R16G16B16A16_SFloat, "PreIntegratedAverageFiberScattering", false, false, MSAASamples.None)
			};
			this.m_PreIntegratedFiberAverageScatteringLUT.Create();
			this.m_PreIntegratedFiberScatteringCS = defaultResources.shaders.preIntegratedFiberScatteringCS;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00056E93 File Offset: 0x00055093
		public override void Cleanup()
		{
			PreIntegratedFGD.instance.Cleanup(PreIntegratedFGD.FGDIndex.FGD_GGXAndDisneyDiffuse);
			LTCAreaLight.instance.Cleanup();
			CoreUtils.Destroy(this.m_PreIntegratedFiberScatteringLUT);
			this.m_PreIntegratedFiberScatteringLUT = null;
			CoreUtils.Destroy(this.m_PreIntegratedFiberAverageScatteringLUT);
			this.m_PreIntegratedFiberAverageScatteringLUT = null;
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00056ED0 File Offset: 0x000550D0
		public override void RenderInit(CommandBuffer cmd)
		{
			PreIntegratedFGD.instance.RenderInit(PreIntegratedFGD.FGDIndex.FGD_GGXAndDisneyDiffuse, cmd);
			if (this.m_PreIntegratedFiberScatteringCS == null)
			{
				return;
			}
			if (!this.m_PreIntegratedFiberAverageScatteringIsInit)
			{
				cmd.SetComputeTextureParam(this.m_PreIntegratedFiberScatteringCS, 1, Hair._PreIntegratedAverageHairFiberScatteringUAV, this.m_PreIntegratedFiberAverageScatteringLUT);
				cmd.DispatchCompute(this.m_PreIntegratedFiberScatteringCS, 1, HDUtils.DivRoundUp(64, 8), HDUtils.DivRoundUp(64, 8), HDUtils.DivRoundUp(64, 8));
				this.m_PreIntegratedFiberAverageScatteringIsInit = true;
			}
			cmd.SetGlobalTexture(Hair._PreIntegratedAverageHairFiberScattering, this.m_PreIntegratedFiberAverageScatteringLUT);
			if (!this.m_PreIntegratedFiberScatteringIsInit)
			{
				cmd.SetComputeTextureParam(this.m_PreIntegratedFiberScatteringCS, 0, Hair._PreIntegratedHairFiberScatteringUAV, this.m_PreIntegratedFiberScatteringLUT);
				cmd.DispatchCompute(this.m_PreIntegratedFiberScatteringCS, 0, HDUtils.DivRoundUp(64, 8), HDUtils.DivRoundUp(64, 8), HDUtils.DivRoundUp(64, 8));
				this.m_PreIntegratedFiberScatteringIsInit = true;
			}
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00056FB0 File Offset: 0x000551B0
		public override void Bind(CommandBuffer cmd)
		{
			PreIntegratedFGD.instance.Bind(cmd, PreIntegratedFGD.FGDIndex.FGD_GGXAndDisneyDiffuse);
			LTCAreaLight.instance.Bind(cmd);
			if (this.m_PreIntegratedFiberScatteringLUT == null)
			{
				throw new Exception("Pre-Integrated Hair Fiber LUT not available!");
			}
			cmd.SetGlobalTexture(Hair._PreIntegratedHairFiberScattering, this.m_PreIntegratedFiberScatteringLUT);
			if (this.m_PreIntegratedFiberAverageScatteringLUT == null)
			{
				throw new Exception("Pre-Integrated Hair Fiber LUT not available!");
			}
			cmd.SetGlobalTexture(Hair._PreIntegratedAverageHairFiberScattering, this.m_PreIntegratedFiberAverageScatteringLUT);
		}

		// Token: 0x04000AF6 RID: 2806
		private const int m_Dim = 64;

		// Token: 0x04000AF7 RID: 2807
		private ComputeShader m_PreIntegratedFiberScatteringCS;

		// Token: 0x04000AF8 RID: 2808
		private RenderTexture m_PreIntegratedFiberScatteringLUT;

		// Token: 0x04000AF9 RID: 2809
		private bool m_PreIntegratedFiberScatteringIsInit;

		// Token: 0x04000AFA RID: 2810
		private RenderTexture m_PreIntegratedFiberAverageScatteringLUT;

		// Token: 0x04000AFB RID: 2811
		private bool m_PreIntegratedFiberAverageScatteringIsInit;

		// Token: 0x04000AFC RID: 2812
		public static readonly int _PreIntegratedHairFiberScatteringUAV = Shader.PropertyToID("_PreIntegratedHairFiberScatteringUAV");

		// Token: 0x04000AFD RID: 2813
		public static readonly int _PreIntegratedHairFiberScattering = Shader.PropertyToID("_PreIntegratedHairFiberScattering");

		// Token: 0x04000AFE RID: 2814
		public static readonly int _PreIntegratedAverageHairFiberScatteringUAV = Shader.PropertyToID("_PreIntegratedAverageHairFiberScatteringUAV");

		// Token: 0x04000AFF RID: 2815
		public static readonly int _PreIntegratedAverageHairFiberScattering = Shader.PropertyToID("_PreIntegratedAverageHairFiberScattering");

		// Token: 0x0200038C RID: 908
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Hair\\Hair.cs")]
		public enum MaterialFeatureFlags
		{
			// Token: 0x040024CB RID: 9419
			HairKajiyaKay = 1,
			// Token: 0x040024CC RID: 9420
			HairMarschner
		}

		// Token: 0x0200038D RID: 909
		[GenerateHLSL(PackingRules.Exact, false, false, true, 1400, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Hair\\Hair.cs")]
		public struct SurfaceData
		{
			// Token: 0x040024CD RID: 9421
			[SurfaceDataAttributes("Material Features", false, false, FieldPrecision.Default, false, "")]
			public uint materialFeatures;

			// Token: 0x040024CE RID: 9422
			[MaterialSharedPropertyMapping(MaterialSharedProperty.AmbientOcclusion)]
			[SurfaceDataAttributes("Ambient Occlusion", false, false, FieldPrecision.Default, false, "")]
			public float ambientOcclusion;

			// Token: 0x040024CF RID: 9423
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Albedo)]
			[SurfaceDataAttributes("Diffuse", false, true, FieldPrecision.Default, false, "")]
			public Vector3 diffuseColor;

			// Token: 0x040024D0 RID: 9424
			[SurfaceDataAttributes("Specular Occlusion", false, false, FieldPrecision.Default, false, "")]
			public float specularOcclusion;

			// Token: 0x040024D1 RID: 9425
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Normal)]
			[SurfaceDataAttributes(new string[]
			{
				"Normal",
				"Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 normalWS;

			// Token: 0x040024D2 RID: 9426
			[SurfaceDataAttributes(new string[]
			{
				"Geometric Normal",
				"Geometric Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 geomNormalWS;

			// Token: 0x040024D3 RID: 9427
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Smoothness)]
			[SurfaceDataAttributes("Smoothness", false, false, FieldPrecision.Default, false, "")]
			public float perceptualSmoothness;

			// Token: 0x040024D4 RID: 9428
			[SurfaceDataAttributes("Transmittance", false, false, FieldPrecision.Default, false, "")]
			public Vector3 transmittance;

			// Token: 0x040024D5 RID: 9429
			[SurfaceDataAttributes("Rim Transmission Intensity", false, false, FieldPrecision.Default, false, "")]
			public float rimTransmissionIntensity;

			// Token: 0x040024D6 RID: 9430
			[SurfaceDataAttributes("Hair Strand Direction", true, false, FieldPrecision.Default, false, "")]
			public Vector3 hairStrandDirectionWS;

			// Token: 0x040024D7 RID: 9431
			[SurfaceDataAttributes("Secondary Smoothness", false, false, FieldPrecision.Default, false, "")]
			public float secondaryPerceptualSmoothness;

			// Token: 0x040024D8 RID: 9432
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Specular)]
			[SurfaceDataAttributes("Specular Tint", false, true, FieldPrecision.Default, false, "")]
			public Vector3 specularTint;

			// Token: 0x040024D9 RID: 9433
			[SurfaceDataAttributes("Secondary Specular Tint", false, true, FieldPrecision.Default, false, "")]
			public Vector3 secondarySpecularTint;

			// Token: 0x040024DA RID: 9434
			[SurfaceDataAttributes("Specular Shift", false, false, FieldPrecision.Default, false, "")]
			public float specularShift;

			// Token: 0x040024DB RID: 9435
			[SurfaceDataAttributes("Secondary Specular Shift", false, false, FieldPrecision.Default, false, "")]
			public float secondarySpecularShift;

			// Token: 0x040024DC RID: 9436
			[SurfaceDataAttributes("Absorption Coefficient", false, false, FieldPrecision.Default, false, "")]
			public Vector3 absorption;

			// Token: 0x040024DD RID: 9437
			[SurfaceDataAttributes("Eumelanin", false, false, FieldPrecision.Default, false, "")]
			public float eumelanin;

			// Token: 0x040024DE RID: 9438
			[SurfaceDataAttributes("Pheomelanin", false, false, FieldPrecision.Default, false, "")]
			public float pheomelanin;

			// Token: 0x040024DF RID: 9439
			[SurfaceDataAttributes("Azimuthal Roughness", false, false, FieldPrecision.Default, false, "")]
			public float perceptualRadialSmoothness;

			// Token: 0x040024E0 RID: 9440
			[SurfaceDataAttributes("Cuticle Angle", false, false, FieldPrecision.Default, false, "")]
			public float cuticleAngle;

			// Token: 0x040024E1 RID: 9441
			[SurfaceDataAttributes("Strand Count Probe", false, false, FieldPrecision.Default, false, "")]
			public Vector4 strandCountProbe;

			// Token: 0x040024E2 RID: 9442
			[SurfaceDataAttributes("Strand Shadow Bias", false, false, FieldPrecision.Default, false, "")]
			public float strandShadowBias;
		}

		// Token: 0x0200038E RID: 910
		[GenerateHLSL(PackingRules.Exact, false, false, true, 1450, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Hair\\Hair.cs")]
		public struct BSDFData
		{
			// Token: 0x040024E3 RID: 9443
			public uint materialFeatures;

			// Token: 0x040024E4 RID: 9444
			public float ambientOcclusion;

			// Token: 0x040024E5 RID: 9445
			public float specularOcclusion;

			// Token: 0x040024E6 RID: 9446
			[SurfaceDataAttributes("", false, true, FieldPrecision.Default, false, "")]
			public Vector3 diffuseColor;

			// Token: 0x040024E7 RID: 9447
			public Vector3 fresnel0;

			// Token: 0x040024E8 RID: 9448
			public Vector3 specularTint;

			// Token: 0x040024E9 RID: 9449
			[SurfaceDataAttributes(new string[]
			{
				"Normal WS",
				"Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 normalWS;

			// Token: 0x040024EA RID: 9450
			[SurfaceDataAttributes(new string[]
			{
				"Geometric Normal",
				"Geometric Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 geomNormalWS;

			// Token: 0x040024EB RID: 9451
			public float perceptualRoughness;

			// Token: 0x040024EC RID: 9452
			public Vector3 transmittance;

			// Token: 0x040024ED RID: 9453
			public float rimTransmissionIntensity;

			// Token: 0x040024EE RID: 9454
			[SurfaceDataAttributes("", true, false, FieldPrecision.Default, false, "")]
			public Vector3 hairStrandDirectionWS;

			// Token: 0x040024EF RID: 9455
			public float anisotropy;

			// Token: 0x040024F0 RID: 9456
			public Vector3 tangentWS;

			// Token: 0x040024F1 RID: 9457
			public Vector3 bitangentWS;

			// Token: 0x040024F2 RID: 9458
			public float roughnessT;

			// Token: 0x040024F3 RID: 9459
			public float roughnessB;

			// Token: 0x040024F4 RID: 9460
			public float h;

			// Token: 0x040024F5 RID: 9461
			public float secondaryPerceptualRoughness;

			// Token: 0x040024F6 RID: 9462
			public Vector3 secondarySpecularTint;

			// Token: 0x040024F7 RID: 9463
			public float specularExponent;

			// Token: 0x040024F8 RID: 9464
			public float secondarySpecularExponent;

			// Token: 0x040024F9 RID: 9465
			public float specularShift;

			// Token: 0x040024FA RID: 9466
			public float secondarySpecularShift;

			// Token: 0x040024FB RID: 9467
			public Vector3 absorption;

			// Token: 0x040024FC RID: 9468
			public float lightPathLength;

			// Token: 0x040024FD RID: 9469
			public float cuticleAngle;

			// Token: 0x040024FE RID: 9470
			public float cuticleAngleR;

			// Token: 0x040024FF RID: 9471
			public float cuticleAngleTT;

			// Token: 0x04002500 RID: 9472
			public float cuticleAngleTRT;

			// Token: 0x04002501 RID: 9473
			public float roughnessR;

			// Token: 0x04002502 RID: 9474
			public float roughnessTT;

			// Token: 0x04002503 RID: 9475
			public float roughnessTRT;

			// Token: 0x04002504 RID: 9476
			public float perceptualRoughnessRadial;

			// Token: 0x04002505 RID: 9477
			public Vector3 distributionNormalizationFactor;

			// Token: 0x04002506 RID: 9478
			public Vector4 strandCountProbe;

			// Token: 0x04002507 RID: 9479
			public float strandShadowBias;

			// Token: 0x04002508 RID: 9480
			public float splineVisibility;
		}
	}
}
