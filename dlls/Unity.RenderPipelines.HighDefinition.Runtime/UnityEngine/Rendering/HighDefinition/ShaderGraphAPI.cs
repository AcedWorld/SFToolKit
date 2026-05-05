using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000111 RID: 273
	internal static class ShaderGraphAPI
	{
		// Token: 0x06000A6B RID: 2667 RVA: 0x00058F78 File Offset: 0x00057178
		public static void SynchronizeShaderGraphProperties(Material material)
		{
			Material material2 = new Material(material.shader);
			foreach (string name in ShaderGraphAPI.floatPropertiesToSynchronize)
			{
				if (material.HasProperty(name) && material2.HasProperty(name))
				{
					material.SetFloat(name, material2.GetFloat(name));
				}
			}
			CoreUtils.Destroy(material2);
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x00058FD1 File Offset: 0x000571D1
		public static void ValidateUnlitMaterial(Material material)
		{
			ShaderGraphAPI.SynchronizeShaderGraphProperties(material);
			UnlitAPI.ValidateMaterial(material);
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x00058FE0 File Offset: 0x000571E0
		public static void ValidateLightingMaterial(Material material)
		{
			ShaderGraphAPI.SynchronizeShaderGraphProperties(material);
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
			bool useSplitLighting = false;
			int num = material.shader.FindPropertyIndex("_RequireSplitLighting");
			if (num != -1)
			{
				useSplitLighting = (material.shader.GetPropertyDefaultFloatValue(num) != 0f);
			}
			bool excludeFromTUAndAA = BaseLitAPI.CompatibleWithExcludeFromTUAndAA(material) && material.GetInt("_ExcludeFromTUAndAA") != 0;
			BaseLitAPI.SetupStencil(material, true, receivesSSR, useSplitLighting, excludeFromTUAndAA);
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x000590BD File Offset: 0x000572BD
		public static void ValidateDecalMaterial(Material material)
		{
			DecalAPI.SetupCommonDecalMaterialKeywordsAndPass(material);
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x000590C5 File Offset: 0x000572C5
		public static void ValidateFogVolumeMaterial(Material material)
		{
			FogVolumeAPI.SetupFogVolumeKeywordsAndProperties(material);
		}

		// Token: 0x04000B20 RID: 2848
		private static readonly string[] floatPropertiesToSynchronize = new string[]
		{
			"_RequireSplitLighting"
		};
	}
}
