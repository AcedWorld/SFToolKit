using System;
using UnityEditor.Rendering.HighDefinition;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000F7 RID: 247
	internal static class DecalAPI
	{
		// Token: 0x06000990 RID: 2448 RVA: 0x00053EF0 File Offset: 0x000520F0
		internal static void SetupCommonDecalMaterialKeywordsAndPass(Material material)
		{
			bool flag = false;
			flag |= (material.HasProperty("_AffectMetal") && material.GetFloat("_AffectMetal") == 1f);
			flag |= (material.HasProperty("_AffectAO") && material.GetFloat("_AffectAO") == 1f);
			flag |= (material.HasProperty("_AffectSmoothness") && material.GetFloat("_AffectSmoothness") == 1f);
			CoreUtils.SetKeyword(material, "_MATERIAL_AFFECTS_ALBEDO", material.HasProperty("_AffectAlbedo") && material.GetFloat("_AffectAlbedo") == 1f);
			CoreUtils.SetKeyword(material, "_MATERIAL_AFFECTS_NORMAL", material.HasProperty("_AffectNormal") && material.GetFloat("_AffectNormal") == 1f);
			CoreUtils.SetKeyword(material, "_MATERIAL_AFFECTS_MASKMAP", flag);
			ColorWriteMask colorWriteMask = (ColorWriteMask)0;
			ColorWriteMask colorWriteMask2 = (ColorWriteMask)0;
			ColorWriteMask colorWriteMask3 = (ColorWriteMask)0;
			ColorWriteMask colorWriteMask4 = (ColorWriteMask)0;
			if (material.HasProperty("_AffectAlbedo") && material.GetFloat("_AffectAlbedo") == 1f)
			{
				colorWriteMask |= ColorWriteMask.All;
			}
			if (material.HasProperty("_AffectNormal") && material.GetFloat("_AffectNormal") == 1f)
			{
				colorWriteMask2 |= ColorWriteMask.All;
			}
			if (material.HasProperty("_AffectMetal") && material.GetFloat("_AffectMetal") == 1f)
			{
				colorWriteMask3 |= (colorWriteMask4 |= ColorWriteMask.Red);
			}
			if (material.HasProperty("_AffectAO") && material.GetFloat("_AffectAO") == 1f)
			{
				colorWriteMask3 |= (colorWriteMask4 |= ColorWriteMask.Green);
			}
			if (material.HasProperty("_AffectSmoothness") && material.GetFloat("_AffectSmoothness") == 1f)
			{
				colorWriteMask3 |= (ColorWriteMask.Alpha | ColorWriteMask.Blue);
			}
			material.SetInt(HDShaderIDs._DecalColorMask0, (int)colorWriteMask);
			material.SetInt(HDShaderIDs._DecalColorMask1, (int)colorWriteMask2);
			material.SetInt(HDShaderIDs._DecalColorMask2, (int)colorWriteMask3);
			material.SetInt(HDShaderIDs._DecalColorMask3, (int)colorWriteMask4);
			bool enabled = colorWriteMask + (int)colorWriteMask2 + (int)colorWriteMask3 + (int)colorWriteMask4 > (ColorWriteMask)0;
			bool enabled2 = material.HasProperty("_AffectEmission") && material.GetFloat("_AffectEmission") == 1f;
			if (material.FindPass(HDShaderPassNames.s_DBufferMeshStr) != -1)
			{
				material.SetShaderPassEnabled(HDShaderPassNames.s_DBufferMeshStr, enabled);
			}
			if (material.FindPass(HDShaderPassNames.s_DBufferProjectorStr) != -1)
			{
				material.SetShaderPassEnabled(HDShaderPassNames.s_DBufferProjectorStr, enabled);
			}
			if (material.FindPass(HDShaderPassNames.s_DecalMeshForwardEmissiveStr) != -1)
			{
				material.SetShaderPassEnabled(HDShaderPassNames.s_DecalMeshForwardEmissiveStr, enabled2);
			}
			if (material.FindPass(HDShaderPassNames.s_DecalProjectorForwardEmissiveStr) != -1)
			{
				material.SetShaderPassEnabled(HDShaderPassNames.s_DecalProjectorForwardEmissiveStr, enabled2);
			}
			material.SetInt("_DecalStencilWriteMask", 16);
			material.SetInt("_DecalStencilRef", 16);
			int renderQueue = -1;
			if (material.HasProperty(HDShaderIDs._DrawOrder))
			{
				renderQueue = 2000 + material.GetInt(HDShaderIDs._DrawOrder);
			}
			material.renderQueue = renderQueue;
			material.enableInstancing = true;
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x000541B4 File Offset: 0x000523B4
		internal static void ValidateMaterial(Material material)
		{
			DecalAPI.SetupCommonDecalMaterialKeywordsAndPass(material);
			CoreUtils.SetKeyword(material, "_COLORMAP", material.GetTexture("_BaseColorMap"));
			CoreUtils.SetKeyword(material, "_NORMALMAP", material.GetTexture("_NormalMap"));
			CoreUtils.SetKeyword(material, "_MASKMAP", material.GetTexture("_MaskMap"));
			CoreUtils.SetKeyword(material, "_EMISSIVEMAP", material.GetTexture("_EmissiveColorMap"));
			if (material.GetFloat("_UseEmissiveIntensity") == 0f)
			{
				material.SetColor("_EmissiveColor", material.GetColor("_EmissiveColorHDR"));
				return;
			}
			material.UpdateEmissiveColorFromIntensityAndEmissiveColorLDR();
		}
	}
}
