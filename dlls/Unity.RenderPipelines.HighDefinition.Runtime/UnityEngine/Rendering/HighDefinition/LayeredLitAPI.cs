using System;
using UnityEditor.Rendering.HighDefinition;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000109 RID: 265
	internal static class LayeredLitAPI
	{
		// Token: 0x06000A3D RID: 2621 RVA: 0x00057084 File Offset: 0x00055284
		public static void SetupLayersMappingKeywords(Material material)
		{
			CoreUtils.SetKeyword(material, "_LAYER_TILING_COUPLED_WITH_UNIFORM_OBJECT_SCALE", material.GetFloat("_ObjectScaleAffectTile") > 0f);
			UVBaseMapping uvbaseMapping = (UVBaseMapping)material.GetFloat("_UVBlendMask");
			CoreUtils.SetKeyword(material, "_LAYER_MAPPING_PLANAR_BLENDMASK", uvbaseMapping == UVBaseMapping.Planar);
			CoreUtils.SetKeyword(material, "_LAYER_MAPPING_TRIPLANAR_BLENDMASK", uvbaseMapping == UVBaseMapping.Triplanar);
			int num = (int)material.GetFloat("_LayerCount");
			if (num == 4)
			{
				CoreUtils.SetKeyword(material, "_LAYEREDLIT_4_LAYERS", true);
				CoreUtils.SetKeyword(material, "_LAYEREDLIT_3_LAYERS", false);
			}
			else if (num == 3)
			{
				CoreUtils.SetKeyword(material, "_LAYEREDLIT_4_LAYERS", false);
				CoreUtils.SetKeyword(material, "_LAYEREDLIT_3_LAYERS", true);
			}
			else
			{
				CoreUtils.SetKeyword(material, "_LAYEREDLIT_4_LAYERS", false);
				CoreUtils.SetKeyword(material, "_LAYEREDLIT_3_LAYERS", false);
			}
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < num; i++)
			{
				string name = string.Format("{0}{1}", "_UVBase", i);
				UVBaseMapping uvbaseMapping2 = (UVBaseMapping)material.GetFloat(name);
				string keyword = string.Format("{0}{1}", "_LAYER_MAPPING_PLANAR", i);
				CoreUtils.SetKeyword(material, keyword, uvbaseMapping2 == UVBaseMapping.Planar);
				string keyword2 = string.Format("{0}{1}", "_LAYER_MAPPING_TRIPLANAR", i);
				CoreUtils.SetKeyword(material, keyword2, uvbaseMapping2 == UVBaseMapping.Triplanar);
				string name2 = string.Format("{0}{1}", "_UVBase", i);
				string name3 = string.Format("{0}{1}", "_UVDetail", i);
				if ((int)material.GetFloat(name3) == 2 || (int)material.GetFloat(name2) == 2)
				{
					flag2 = true;
				}
				if ((int)material.GetFloat(name3) == 3 || (int)material.GetFloat(name2) == 3)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				material.DisableKeyword("_REQUIRE_UV2");
				material.EnableKeyword("_REQUIRE_UV3");
				return;
			}
			if (flag2)
			{
				material.EnableKeyword("_REQUIRE_UV2");
				material.DisableKeyword("_REQUIRE_UV3");
				return;
			}
			material.DisableKeyword("_REQUIRE_UV2");
			material.DisableKeyword("_REQUIRE_UV3");
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00057274 File Offset: 0x00055474
		internal static void ValidateMaterial(Material material)
		{
			MaterialId materialId = material.GetMaterialId();
			if (material.HasProperty("_MaterialID") && materialId != MaterialId.LitStandard && materialId != MaterialId.LitSSS && materialId != MaterialId.LitTranslucent)
			{
				materialId = MaterialId.LitStandard;
				material.SetFloat("_MaterialID", (float)materialId);
			}
			BaseLitAPI.SetupBaseLitKeywords(material);
			BaseLitAPI.SetupBaseLitMaterialPass(material);
			LayeredLitAPI.SetupLayersMappingKeywords(material);
			bool receivesSSR = (material.GetSurfaceType() == SurfaceType.Opaque) ? (material.HasProperty("_ReceivesSSR") && material.GetInt("_ReceivesSSR") != 0) : (material.HasProperty("_ReceivesSSRTransparent") && material.GetInt("_ReceivesSSRTransparent") != 0);
			bool excludeFromTUAndAA = BaseLitAPI.CompatibleWithExcludeFromTUAndAA(material) && material.GetInt("_ExcludeFromTUAndAA") != 0;
			BaseLitAPI.SetupStencil(material, true, receivesSSR, materialId == MaterialId.LitSSS, excludeFromTUAndAA);
			for (int i = 0; i < 4; i++)
			{
				NormalMapSpace normalMapSpace = (NormalMapSpace)material.GetFloat("_NormalMapSpace" + i.ToString());
				CoreUtils.SetKeyword(material, "_NORMALMAP_TANGENT_SPACE" + i.ToString(), normalMapSpace == NormalMapSpace.TangentSpace);
				if (normalMapSpace == NormalMapSpace.TangentSpace)
				{
					CoreUtils.SetKeyword(material, "_NORMALMAP" + i.ToString(), material.GetTexture("_NormalMap" + i.ToString()) || material.GetTexture("_DetailMap" + i.ToString()));
					CoreUtils.SetKeyword(material, "_BENTNORMALMAP" + i.ToString(), material.GetTexture("_BentNormalMap" + i.ToString()));
				}
				else
				{
					CoreUtils.SetKeyword(material, "_NORMALMAP" + i.ToString(), material.GetTexture("_NormalMapOS" + i.ToString()) || material.GetTexture("_DetailMap" + i.ToString()));
					CoreUtils.SetKeyword(material, "_BENTNORMALMAP" + i.ToString(), material.GetTexture("_BentNormalMapOS" + i.ToString()));
				}
				CoreUtils.SetKeyword(material, "_MASKMAP" + i.ToString(), material.GetTexture("_MaskMap" + i.ToString()));
				CoreUtils.SetKeyword(material, "_DETAIL_MAP" + i.ToString(), material.GetTexture("_DetailMap" + i.ToString()));
				CoreUtils.SetKeyword(material, "_HEIGHTMAP" + i.ToString(), material.GetTexture("_HeightMap" + i.ToString()));
				CoreUtils.SetKeyword(material, "_SUBSURFACE_MASK_MAP" + i.ToString(), material.GetTexture("_SubsurfaceMaskMap" + i.ToString()));
				CoreUtils.SetKeyword(material, "_TRANSMISSION_MASK_MAP" + i.ToString(), material.GetTexture("_TransmissionMaskMap" + i.ToString()));
				CoreUtils.SetKeyword(material, "_THICKNESSMAP" + i.ToString(), material.GetTexture("_ThicknessMap" + i.ToString()));
			}
			CoreUtils.SetKeyword(material, "_INFLUENCEMASK_MAP", material.GetTexture("_LayerInfluenceMaskMap") && material.GetFloat("_UseMainLayerInfluence") != 0f);
			CoreUtils.SetKeyword(material, "_EMISSIVE_MAPPING_PLANAR", (int)material.GetFloat("_UVEmissive") == 4 && material.GetTexture("_EmissiveColorMap"));
			CoreUtils.SetKeyword(material, "_EMISSIVE_MAPPING_TRIPLANAR", (int)material.GetFloat("_UVEmissive") == 5 && material.GetTexture("_EmissiveColorMap"));
			CoreUtils.SetKeyword(material, "_EMISSIVE_MAPPING_BASE", (int)material.GetFloat("_UVEmissive") == 6 && material.GetTexture("_EmissiveColorMap"));
			CoreUtils.SetKeyword(material, "_EMISSIVE_COLOR_MAP", material.GetTexture("_EmissiveColorMap"));
			if (material.HasProperty("_UseEmissiveIntensity") && material.GetFloat("_UseEmissiveIntensity") != 0f)
			{
				material.UpdateEmissiveColorFromIntensityAndEmissiveColorLDR();
			}
			CoreUtils.SetKeyword(material, "_ENABLESPECULAROCCLUSION", false);
			int @int = material.GetInt("_SpecularOcclusionMode");
			CoreUtils.SetKeyword(material, "_SPECULAR_OCCLUSION_NONE", @int == 0);
			CoreUtils.SetKeyword(material, "_SPECULAR_OCCLUSION_FROM_BENT_NORMAL_MAP", @int == 2);
			CoreUtils.SetKeyword(material, "_MAIN_LAYER_INFLUENCE_MODE", material.GetFloat("_UseMainLayerInfluence") != 0f);
			VertexColorMode vertexColorMode = (VertexColorMode)material.GetFloat("_VertexColorMode");
			if (vertexColorMode == VertexColorMode.Multiply)
			{
				CoreUtils.SetKeyword(material, "_LAYER_MASK_VERTEX_COLOR_MUL", true);
				CoreUtils.SetKeyword(material, "_LAYER_MASK_VERTEX_COLOR_ADD", false);
			}
			else if (vertexColorMode == VertexColorMode.Add)
			{
				CoreUtils.SetKeyword(material, "_LAYER_MASK_VERTEX_COLOR_MUL", false);
				CoreUtils.SetKeyword(material, "_LAYER_MASK_VERTEX_COLOR_ADD", true);
			}
			else
			{
				CoreUtils.SetKeyword(material, "_LAYER_MASK_VERTEX_COLOR_MUL", false);
				CoreUtils.SetKeyword(material, "_LAYER_MASK_VERTEX_COLOR_ADD", false);
			}
			bool state = material.GetFloat("_UseHeightBasedBlend") != 0f;
			CoreUtils.SetKeyword(material, "_HEIGHT_BASED_BLEND", state);
			bool flag = false;
			for (int j = 0; j < material.GetInt("_LayerCount"); j++)
			{
				flag |= (material.GetFloat("_OpacityAsDensity" + j.ToString()) != 0f);
			}
			CoreUtils.SetKeyword(material, "_DENSITY_MODE", flag);
			CoreUtils.SetKeyword(material, "_MATERIAL_FEATURE_SUBSURFACE_SCATTERING", materialId == MaterialId.LitSSS);
			CoreUtils.SetKeyword(material, "_MATERIAL_FEATURE_TRANSMISSION", materialId == MaterialId.LitTranslucent || (materialId == MaterialId.LitSSS && material.GetFloat("_TransmissionEnable") > 0f));
			BaseLitAPI.SetupDisplacement(material, material.GetInt("_LayerCount"));
		}

		// Token: 0x04000B04 RID: 2820
		private const string kLayerInfluenceMaskMap = "_LayerInfluenceMaskMap";

		// Token: 0x04000B05 RID: 2821
		private const string kVertexColorMode = "_VertexColorMode";

		// Token: 0x04000B06 RID: 2822
		private const string kUVBlendMask = "_UVBlendMask";

		// Token: 0x04000B07 RID: 2823
		private const string kkUseMainLayerInfluence = "_UseMainLayerInfluence";

		// Token: 0x04000B08 RID: 2824
		private const string kUseHeightBasedBlend = "_UseHeightBasedBlend";

		// Token: 0x04000B09 RID: 2825
		private const string kObjectScaleAffectTile = "_ObjectScaleAffectTile";

		// Token: 0x04000B0A RID: 2826
		private const string kOpacityAsDensity = "_OpacityAsDensity";
	}
}
