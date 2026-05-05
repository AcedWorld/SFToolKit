using System;
using System.Collections.Generic;
using UnityEditor.Rendering.HighDefinition;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200010E RID: 270
	public static class HDMaterial
	{
		// Token: 0x06000A4F RID: 2639 RVA: 0x00058618 File Offset: 0x00056818
		internal static HDMaterial.ShaderID GetShaderID(Material material)
		{
			if (!HDMaterial.IsShaderGraph(material))
			{
				string shaderName = material.shader.name;
				return (HDMaterial.ShaderID)Array.FindIndex<string>(HDMaterial.s_ShaderPaths, (string m) => m == shaderName);
			}
			string subTarget = material.GetTag("ShaderGraphTargetId", false, null);
			int num = Array.FindIndex<string>(HDMaterial.s_SubTargetIds, (string m) => m == subTarget);
			if (num != -1)
			{
				return num + HDMaterial.ShaderID.Count_Standard;
			}
			return HDMaterial.ShaderID.SG_External;
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x00058694 File Offset: 0x00056894
		internal static void RemoveMaterialKeyword(Material material, HDMaterial.ShaderID shaderID)
		{
			if (HDMaterial.ShaderID.Lit <= shaderID && shaderID < HDMaterial.ShaderID.Count_Standard)
			{
				material.shaderKeywords = null;
			}
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x000586A8 File Offset: 0x000568A8
		public static bool ValidateMaterial(Material material)
		{
			HDMaterial.ShaderID shaderID = HDMaterial.GetShaderID(material);
			HDMaterial.MaterialResetter materialResetter;
			HDMaterial.k_PlainShadersMaterialResetters.TryGetValue(shaderID, out materialResetter);
			if (materialResetter == null)
			{
				return false;
			}
			HDMaterial.RemoveMaterialKeyword(material, shaderID);
			materialResetter(material);
			return true;
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x000586DE File Offset: 0x000568DE
		private static HDRenderQueue.RenderQueueType RenderingPassToQueue(HDMaterial.RenderingPass pass, bool isTransparent)
		{
			switch (pass)
			{
			case HDMaterial.RenderingPass.BeforeRefraction:
				if (!isTransparent)
				{
					return HDRenderQueue.RenderQueueType.Opaque;
				}
				return HDRenderQueue.RenderQueueType.PreRefraction;
			case HDMaterial.RenderingPass.Default:
				if (!isTransparent)
				{
					return HDRenderQueue.RenderQueueType.Opaque;
				}
				return HDRenderQueue.RenderQueueType.Transparent;
			case HDMaterial.RenderingPass.AfterPostProcess:
				if (!isTransparent)
				{
					return HDRenderQueue.RenderQueueType.AfterPostProcessOpaque;
				}
				return HDRenderQueue.RenderQueueType.AfterPostprocessTransparent;
			case HDMaterial.RenderingPass.LowResolution:
				if (!isTransparent)
				{
					return HDRenderQueue.RenderQueueType.Opaque;
				}
				return HDRenderQueue.RenderQueueType.LowTransparent;
			default:
				return HDRenderQueue.RenderQueueType.Unknown;
			}
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x00058718 File Offset: 0x00056918
		public static void SetSurfaceType(Material material, bool transparent)
		{
			SurfaceType surfaceType = transparent ? SurfaceType.Transparent : SurfaceType.Opaque;
			material.SetFloat("_SurfaceType", (float)surfaceType);
			HDMaterial.ValidateMaterial(material);
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x00058744 File Offset: 0x00056944
		public static void SetRenderingPass(Material material, HDMaterial.RenderingPass value)
		{
			bool isTransparent = (int)material.GetFloat("_SurfaceType") == 1;
			HDRenderQueue.RenderQueueType targetType = HDMaterial.RenderingPassToQueue(value, isTransparent);
			int offset = material.HasProperty("_TransparentSortPriority") ? ((int)material.GetFloat("_TransparentSortPriority")) : 0;
			bool alphaTest = material.HasProperty("_AlphaCutoffEnable") && material.GetFloat("_AlphaCutoffEnable") > 0f;
			bool receiveDecal = material.HasProperty("_SupportDecals") && material.GetFloat("_SupportDecals") > 0f;
			material.renderQueue = HDRenderQueue.ChangeType(targetType, offset, alphaTest, receiveDecal);
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x000587E0 File Offset: 0x000569E0
		public static void SetEmissiveColor(Material material, Color value)
		{
			if (material.GetFloat("_UseEmissiveIntensity") > 0f)
			{
				material.SetColor("_EmissiveColorLDR", value);
				material.SetColor("_EmissiveColor", value.linear * material.GetFloat("_EmissiveIntensity"));
				return;
			}
			if (material.HasProperty("_EmissiveColorHDR"))
			{
				material.SetColor("_EmissiveColorHDR", value);
			}
			material.SetColor("_EmissiveColor", value);
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x00058854 File Offset: 0x00056A54
		public static void SetUseEmissiveIntensity(Material material, bool value)
		{
			material.SetFloat("_UseEmissiveIntensity", value ? 1f : 0f);
			if (value)
			{
				material.UpdateEmissiveColorFromIntensityAndEmissiveColorLDR();
				return;
			}
			if (material.HasProperty("_EmissiveColorHDR"))
			{
				material.SetColor("_EmissiveColor", material.GetColor("_EmissiveColorHDR"));
			}
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x000588A8 File Offset: 0x00056AA8
		public static bool GetUseEmissiveIntensity(Material material)
		{
			return material.GetFloat("_UseEmissiveIntensity") > 0f;
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x000588BC File Offset: 0x00056ABC
		public static void SetEmissiveIntensity(Material material, float intensity, EmissiveIntensityUnit unit)
		{
			if (unit == EmissiveIntensityUnit.EV100)
			{
				intensity = LightUtils.ConvertEvToLuminance(intensity);
			}
			material.SetFloat("_EmissiveIntensity", intensity);
			material.SetFloat("_EmissiveIntensityUnit", (float)unit);
			if (material.GetFloat("_UseEmissiveIntensity") > 0f)
			{
				material.SetColor("_EmissiveColor", material.GetColor("_EmissiveColorLDR").linear * intensity);
			}
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x00058924 File Offset: 0x00056B24
		public static void SetAlphaClipping(Material material, bool value)
		{
			material.SetFloat("_AlphaCutoffEnable", value ? 1f : 0f);
			material.SetupBaseUnlitKeywords();
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x00058946 File Offset: 0x00056B46
		public static void SetAlphaCutoff(Material material, float cutoff)
		{
			material.SetFloat("_AlphaCutoff", cutoff);
			material.SetFloat("_Cutoff", cutoff);
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x00058960 File Offset: 0x00056B60
		public static void SetDiffusionProfile(Material material, DiffusionProfileSettings profile)
		{
			float value = (profile != null) ? HDShadowUtils.Asfloat(profile.profile.hash) : 0f;
			material.SetFloat(HDShaderIDs._DiffusionProfileHash, value);
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x0005899C File Offset: 0x00056B9C
		public static void SetDiffusionProfileShaderGraph(Material material, DiffusionProfileSettings profile, string referenceName)
		{
			float value = (profile != null) ? HDShadowUtils.Asfloat(profile.profile.hash) : 0f;
			material.SetFloat(referenceName, value);
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x000589D2 File Offset: 0x00056BD2
		internal static bool IsShaderGraph(Material material)
		{
			return !string.IsNullOrEmpty(material.GetTag("ShaderGraphShader", false, null));
		}

		// Token: 0x04000B18 RID: 2840
		internal static readonly string[] s_ShaderPaths = new string[]
		{
			"HDRP/Lit",
			"HDRP/LitTessellation",
			"HDRP/LayeredLit",
			"HDRP/LayeredLitTessellation",
			"HDRP/Unlit",
			"HDRP/Decal",
			"HDRP/TerrainLit",
			"HDRP/AxF"
		};

		// Token: 0x04000B19 RID: 2841
		internal static readonly string[] s_SubTargetIds = new string[]
		{
			"HDUnlitSubTarget",
			"HDLitSubTarget",
			"HairSubTarget",
			"FabricSubTarget",
			"StackLitSubTarget",
			"DecalSubTarget",
			"EyeSubTarget",
			"WaterSubTarget",
			"FogVolumeSubTarget"
		};

		// Token: 0x04000B1A RID: 2842
		internal static Dictionary<HDMaterial.ShaderID, HDMaterial.MaterialResetter> k_PlainShadersMaterialResetters = new Dictionary<HDMaterial.ShaderID, HDMaterial.MaterialResetter>
		{
			{
				HDMaterial.ShaderID.Lit,
				new HDMaterial.MaterialResetter(LitAPI.ValidateMaterial)
			},
			{
				HDMaterial.ShaderID.LitTesselation,
				new HDMaterial.MaterialResetter(LitAPI.ValidateMaterial)
			},
			{
				HDMaterial.ShaderID.LayeredLit,
				new HDMaterial.MaterialResetter(LayeredLitAPI.ValidateMaterial)
			},
			{
				HDMaterial.ShaderID.LayeredLitTesselation,
				new HDMaterial.MaterialResetter(LayeredLitAPI.ValidateMaterial)
			},
			{
				HDMaterial.ShaderID.Unlit,
				new HDMaterial.MaterialResetter(UnlitAPI.ValidateMaterial)
			},
			{
				HDMaterial.ShaderID.Decal,
				new HDMaterial.MaterialResetter(DecalAPI.ValidateMaterial)
			},
			{
				HDMaterial.ShaderID.TerrainLit,
				new HDMaterial.MaterialResetter(TerrainLitAPI.ValidateMaterial)
			},
			{
				HDMaterial.ShaderID.AxF,
				new HDMaterial.MaterialResetter(AxFAPI.ValidateMaterial)
			},
			{
				HDMaterial.ShaderID.Count_Standard,
				new HDMaterial.MaterialResetter(ShaderGraphAPI.ValidateUnlitMaterial)
			},
			{
				HDMaterial.ShaderID.SG_Lit,
				new HDMaterial.MaterialResetter(ShaderGraphAPI.ValidateLightingMaterial)
			},
			{
				HDMaterial.ShaderID.SG_Hair,
				new HDMaterial.MaterialResetter(ShaderGraphAPI.ValidateLightingMaterial)
			},
			{
				HDMaterial.ShaderID.SG_Fabric,
				new HDMaterial.MaterialResetter(ShaderGraphAPI.ValidateLightingMaterial)
			},
			{
				HDMaterial.ShaderID.SG_StackLit,
				new HDMaterial.MaterialResetter(ShaderGraphAPI.ValidateLightingMaterial)
			},
			{
				HDMaterial.ShaderID.SG_Decal,
				new HDMaterial.MaterialResetter(ShaderGraphAPI.ValidateDecalMaterial)
			},
			{
				HDMaterial.ShaderID.SG_Eye,
				new HDMaterial.MaterialResetter(ShaderGraphAPI.ValidateLightingMaterial)
			},
			{
				HDMaterial.ShaderID.SG_FogVolume,
				new HDMaterial.MaterialResetter(ShaderGraphAPI.ValidateFogVolumeMaterial)
			}
		};

		// Token: 0x02000393 RID: 915
		internal enum ShaderID
		{
			// Token: 0x0400254D RID: 9549
			Lit,
			// Token: 0x0400254E RID: 9550
			LitTesselation,
			// Token: 0x0400254F RID: 9551
			LayeredLit,
			// Token: 0x04002550 RID: 9552
			LayeredLitTesselation,
			// Token: 0x04002551 RID: 9553
			Unlit,
			// Token: 0x04002552 RID: 9554
			Decal,
			// Token: 0x04002553 RID: 9555
			TerrainLit,
			// Token: 0x04002554 RID: 9556
			AxF,
			// Token: 0x04002555 RID: 9557
			Count_Standard,
			// Token: 0x04002556 RID: 9558
			SG_Unlit = 8,
			// Token: 0x04002557 RID: 9559
			SG_Lit,
			// Token: 0x04002558 RID: 9560
			SG_Hair,
			// Token: 0x04002559 RID: 9561
			SG_Fabric,
			// Token: 0x0400255A RID: 9562
			SG_StackLit,
			// Token: 0x0400255B RID: 9563
			SG_Decal,
			// Token: 0x0400255C RID: 9564
			SG_Eye,
			// Token: 0x0400255D RID: 9565
			SG_Water,
			// Token: 0x0400255E RID: 9566
			SG_FogVolume,
			// Token: 0x0400255F RID: 9567
			Count_All,
			// Token: 0x04002560 RID: 9568
			Count_ShaderGraph = 9,
			// Token: 0x04002561 RID: 9569
			SG_External = -1
		}

		// Token: 0x02000394 RID: 916
		// (Invoke) Token: 0x06001327 RID: 4903
		internal delegate void MaterialResetter(Material material);

		// Token: 0x02000395 RID: 917
		public enum RenderingPass
		{
			// Token: 0x04002563 RID: 9571
			BeforeRefraction,
			// Token: 0x04002564 RID: 9572
			Default,
			// Token: 0x04002565 RID: 9573
			AfterPostProcess,
			// Token: 0x04002566 RID: 9574
			LowResolution
		}
	}
}
