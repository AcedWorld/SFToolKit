using System;
using UnityEditor.Rendering.HighDefinition;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000115 RID: 277
	internal static class TerrainLitAPI
	{
		// Token: 0x06000A7E RID: 2686 RVA: 0x000592E8 File Offset: 0x000574E8
		public static void ValidateMaterial(Material material)
		{
			BaseLitAPI.SetupBaseLitKeywords(material);
			BaseLitAPI.SetupBaseLitMaterialPass(material);
			bool receivesSSR;
			if (material.HasProperty("_SurfaceType") && (int)material.GetFloat("_SurfaceType") == 1)
			{
				receivesSSR = (material.HasProperty("_ReceivesSSRTransparent") && material.GetFloat("_ReceivesSSRTransparent") != 0f);
			}
			else
			{
				receivesSSR = (material.HasProperty("_ReceivesSSR") && material.GetFloat("_ReceivesSSR") != 0f);
			}
			BaseLitAPI.SetupStencil(material, true, receivesSSR, material.GetMaterialId() == MaterialId.LitSSS, false);
			bool state = material.HasProperty("_EnableHeightBlend") && material.GetFloat("_EnableHeightBlend") > 0f;
			CoreUtils.SetKeyword(material, "_TERRAIN_BLEND_HEIGHT", state);
			bool state2 = material.HasProperty("_EnableInstancedPerPixelNormal") && material.GetFloat("_EnableInstancedPerPixelNormal") > 0f;
			CoreUtils.SetKeyword(material, "_TERRAIN_INSTANCED_PERPIXEL_NORMAL", state2);
			int @int = material.GetInt("_SpecularOcclusionMode");
			CoreUtils.SetKeyword(material, "_SPECULAR_OCCLUSION_NONE", @int == 0);
		}
	}
}
