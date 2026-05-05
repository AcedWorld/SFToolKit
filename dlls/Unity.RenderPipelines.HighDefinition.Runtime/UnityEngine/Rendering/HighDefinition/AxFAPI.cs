using System;
using UnityEditor.Rendering.HighDefinition;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000F2 RID: 242
	internal static class AxFAPI
	{
		// Token: 0x0600097D RID: 2429 RVA: 0x00053658 File Offset: 0x00051858
		public static Vector4 AxFMappingModeToMask(AxFMappingMode mappingMode)
		{
			Vector4 zero = Vector4.zero;
			if (mappingMode <= AxFMappingMode.UV3)
			{
				float x = (mappingMode == AxFMappingMode.UV0) ? 1f : 0f;
				float y = (mappingMode == AxFMappingMode.UV1) ? 1f : 0f;
				float z = (mappingMode == AxFMappingMode.UV2) ? 1f : 0f;
				float w = (mappingMode == AxFMappingMode.UV3) ? 1f : 0f;
				zero = new Vector4(x, y, z, w);
			}
			else if (mappingMode < AxFMappingMode.Triplanar)
			{
				float x2 = (mappingMode == AxFMappingMode.PlanarYZ) ? 1f : 0f;
				float y2 = (mappingMode == AxFMappingMode.PlanarZX) ? 1f : 0f;
				float z2 = (mappingMode == AxFMappingMode.PlanarXY) ? 1f : 0f;
				float w2 = 0f;
				zero = new Vector4(x2, y2, z2, w2);
			}
			return zero;
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x00053714 File Offset: 0x00051914
		public static void ValidateMaterial(Material material)
		{
			material.SetupBaseUnlitKeywords();
			material.SetupBaseUnlitPass();
			AxfBrdfType axfBrdfType = (AxfBrdfType)material.GetFloat("_AxF_BRDFType");
			CoreUtils.SetKeyword(material, "_AXF_BRDF_TYPE_SVBRDF", axfBrdfType == AxfBrdfType.SVBRDF);
			CoreUtils.SetKeyword(material, "_AXF_BRDF_TYPE_CAR_PAINT", axfBrdfType == AxfBrdfType.CAR_PAINT);
			AxFMappingMode axFMappingMode = (AxFMappingMode)material.GetFloat("_MappingMode");
			material.SetVector("_MappingMask", AxFAPI.AxFMappingModeToMask(axFMappingMode));
			bool flag = axFMappingMode >= AxFMappingMode.PlanarXY && axFMappingMode < AxFMappingMode.Triplanar;
			bool state = material.GetFloat("_PlanarSpace") > 0f;
			CoreUtils.SetKeyword(material, "_MAPPING_PLANAR", flag);
			CoreUtils.SetKeyword(material, "_MAPPING_TRIPLANAR", axFMappingMode == AxFMappingMode.Triplanar);
			if (flag || axFMappingMode == AxFMappingMode.Triplanar)
			{
				CoreUtils.SetKeyword(material, "_PLANAR_LOCAL", state);
			}
			CoreUtils.SetKeyword(material, "_REQUIRE_UV1", axFMappingMode == AxFMappingMode.UV1);
			CoreUtils.SetKeyword(material, "_REQUIRE_UV2", axFMappingMode == AxFMappingMode.UV2);
			CoreUtils.SetKeyword(material, "_REQUIRE_UV3", axFMappingMode == AxFMappingMode.UV3);
			bool flag2 = material.HasProperty("_SupportDecals") && material.GetFloat("_SupportDecals") > 0f;
			CoreUtils.SetKeyword(material, "_DISABLE_DECALS", !flag2);
			bool receivesSSR;
			if (material.GetSurfaceType() == SurfaceType.Transparent)
			{
				receivesSSR = (material.HasProperty("_ReceivesSSRTransparent") && material.GetFloat("_ReceivesSSRTransparent") != 0f);
			}
			else
			{
				receivesSSR = (material.HasProperty("_ReceivesSSR") && material.GetFloat("_ReceivesSSR") != 0f);
			}
			CoreUtils.SetKeyword(material, "_DISABLE_SSR", material.HasProperty("_ReceivesSSR") && material.GetFloat("_ReceivesSSR") == 0f);
			CoreUtils.SetKeyword(material, "_DISABLE_SSR_TRANSPARENT", material.HasProperty("_ReceivesSSRTransparent") && (double)material.GetFloat("_ReceivesSSRTransparent") == 0.0);
			CoreUtils.SetKeyword(material, "_ENABLE_GEOMETRIC_SPECULAR_AA", material.HasProperty("_EnableGeometricSpecularAA") && material.GetFloat("_EnableGeometricSpecularAA") > 0f);
			CoreUtils.SetKeyword(material, "_SPECULAR_OCCLUSION_NONE", material.HasProperty("_SpecularOcclusionMode") && material.GetFloat("_SpecularOcclusionMode") == 0f);
			bool excludeFromTUAndAA = BaseLitAPI.CompatibleWithExcludeFromTUAndAA(material) && material.GetInt("_ExcludeFromTUAndAA") != 0;
			BaseLitAPI.SetupStencil(material, true, receivesSSR, false, excludeFromTUAndAA);
			uint num = (uint)material.GetFloat("_Flags");
			num |= 8388608U;
			material.SetFloat("_FlagsB", num);
			uint num2 = (uint)material.GetFloat("_SVBRDF_BRDFType");
			uint num3 = (uint)material.GetFloat("_SVBRDF_BRDFVariants");
			SvbrdfDiffuseType svbrdfDiffuseType = (SvbrdfDiffuseType)(num2 & 1U);
			SvbrdfSpecularType svbrdfSpecularType = (SvbrdfSpecularType)(num2 >> 1 & 7U);
			SvbrdfFresnelVariant svbrdfFresnelVariant = (SvbrdfFresnelVariant)(num3 & 3U);
			SvbrdfSpecularVariantWard svbrdfSpecularVariantWard = (SvbrdfSpecularVariantWard)(num3 >> 2 & 3U);
			SvbrdfSpecularVariantBlinn svbrdfSpecularVariantBlinn = (SvbrdfSpecularVariantBlinn)(num3 >> 4 & 3U);
			material.SetFloat("_SVBRDF_BRDFType_DiffuseType", (float)svbrdfDiffuseType);
			material.SetFloat("_SVBRDF_BRDFType_SpecularType", (float)svbrdfSpecularType);
			material.SetFloat("_SVBRDF_BRDFVariants_FresnelType", (float)svbrdfFresnelVariant);
			material.SetFloat("_SVBRDF_BRDFVariants_WardType", (float)svbrdfSpecularVariantWard);
			material.SetFloat("_SVBRDF_BRDFVariants_BlinnType", (float)svbrdfSpecularVariantBlinn);
			material.SetFloat("_CarPaint2_FlakeMaxThetaIF", material.GetFloat("_CarPaint2_FlakeMaxThetaI"));
			material.SetFloat("_CarPaint2_FlakeNumThetaFF", material.GetFloat("_CarPaint2_FlakeNumThetaF"));
			material.SetFloat("_CarPaint2_FlakeNumThetaIF", material.GetFloat("_CarPaint2_FlakeNumThetaI"));
		}

		// Token: 0x04000A49 RID: 2633
		private const string kIntPropAsFloatSuffix = "F";

		// Token: 0x04000A4A RID: 2634
		private const string kFlags = "_Flags";

		// Token: 0x04000A4B RID: 2635
		private const string kFlagsB = "_FlagsB";

		// Token: 0x04000A4C RID: 2636
		private const string kSVBRDF_BRDFType = "_SVBRDF_BRDFType";

		// Token: 0x04000A4D RID: 2637
		private const string kSVBRDF_BRDFVariants = "_SVBRDF_BRDFVariants";

		// Token: 0x04000A4E RID: 2638
		private const string kSVBRDF_BRDFType_DiffuseType = "_SVBRDF_BRDFType_DiffuseType";

		// Token: 0x04000A4F RID: 2639
		private const string kSVBRDF_BRDFType_SpecularType = "_SVBRDF_BRDFType_SpecularType";

		// Token: 0x04000A50 RID: 2640
		private const string kSVBRDF_BRDFVariants_FresnelType = "_SVBRDF_BRDFVariants_FresnelType";

		// Token: 0x04000A51 RID: 2641
		private const string kSVBRDF_BRDFVariants_WardType = "_SVBRDF_BRDFVariants_WardType";

		// Token: 0x04000A52 RID: 2642
		private const string kSVBRDF_BRDFVariants_BlinnType = "_SVBRDF_BRDFVariants_BlinnType";

		// Token: 0x04000A53 RID: 2643
		private const string kCarPaint2_FlakeMaxThetaI = "_CarPaint2_FlakeMaxThetaI";

		// Token: 0x04000A54 RID: 2644
		private const string kCarPaint2_FlakeNumThetaF = "_CarPaint2_FlakeNumThetaF";

		// Token: 0x04000A55 RID: 2645
		private const string kCarPaint2_FlakeNumThetaI = "_CarPaint2_FlakeNumThetaI";

		// Token: 0x04000A56 RID: 2646
		private const string kAxF_BRDFType = "_AxF_BRDFType";

		// Token: 0x04000A57 RID: 2647
		private const string kMappingMode = "_MappingMode";

		// Token: 0x04000A58 RID: 2648
		private const string kMappingMask = "_MappingMask";

		// Token: 0x04000A59 RID: 2649
		private const string kPlanarSpace = "_PlanarSpace";
	}
}
