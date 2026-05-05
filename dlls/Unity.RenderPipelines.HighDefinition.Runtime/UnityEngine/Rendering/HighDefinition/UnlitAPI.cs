using System;
using UnityEditor.Rendering.HighDefinition;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000117 RID: 279
	internal static class UnlitAPI
	{
		// Token: 0x06000A80 RID: 2688 RVA: 0x00059400 File Offset: 0x00057600
		internal static void ValidateMaterial(Material material)
		{
			material.SetupBaseUnlitKeywords();
			material.SetupBaseUnlitPass();
			if (material.HasProperty("_EmissiveColorMap"))
			{
				CoreUtils.SetKeyword(material, "_EMISSIVE_COLOR_MAP", material.GetTexture("_EmissiveColorMap"));
			}
			if (material.HasProperty("_UseEmissiveIntensity") && material.GetFloat("_UseEmissiveIntensity") != 0f)
			{
				material.UpdateEmissiveColorFromIntensityAndEmissiveColorLDR();
			}
			bool receivesLighting = material.HasProperty("_ShadowMatteFilter") && material.GetFloat("_ShadowMatteFilter") != 0f;
			bool excludeFromTUAndAA = BaseLitAPI.CompatibleWithExcludeFromTUAndAA(material) && material.GetInt("_ExcludeFromTUAndAA") != 0;
			BaseLitAPI.SetupStencil(material, receivesLighting, false, false, excludeFromTUAndAA);
		}
	}
}
