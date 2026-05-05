using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace UnityEditor.Rendering.HighDefinition
{
	// Token: 0x02000016 RID: 22
	internal static class MaterialExtension
	{
		// Token: 0x0600000F RID: 15 RVA: 0x0000234A File Offset: 0x0000054A
		public static SurfaceType GetSurfaceType(this Material material)
		{
			if (!material.HasProperty("_SurfaceType"))
			{
				return SurfaceType.Opaque;
			}
			return (SurfaceType)material.GetFloat("_SurfaceType");
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002367 File Offset: 0x00000567
		public static MaterialId GetMaterialId(this Material material)
		{
			if (!material.HasProperty("_MaterialID"))
			{
				return MaterialId.LitStandard;
			}
			return (MaterialId)material.GetFloat("_MaterialID");
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002384 File Offset: 0x00000584
		public static BlendMode GetBlendMode(this Material material)
		{
			if (!material.HasProperty("_BlendMode"))
			{
				return BlendMode.Additive;
			}
			return (BlendMode)material.GetFloat("_BlendMode");
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000023A1 File Offset: 0x000005A1
		public static int GetLayerCount(this Material material)
		{
			if (!material.HasProperty("_LayerCount"))
			{
				return 1;
			}
			return material.GetInt("_LayerCount");
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000023BD File Offset: 0x000005BD
		public static bool GetZWrite(this Material material)
		{
			return material.HasProperty("_ZWrite") && material.GetInt("_ZWrite") == 1;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000023DC File Offset: 0x000005DC
		public static bool GetTransparentZWrite(this Material material)
		{
			return material.HasProperty("_TransparentZWrite") && material.GetInt("_TransparentZWrite") == 1;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000023FB File Offset: 0x000005FB
		public static CullMode GetTransparentCullMode(this Material material)
		{
			if (!material.HasProperty("_TransparentCullMode"))
			{
				return CullMode.Back;
			}
			return (CullMode)material.GetInt("_TransparentCullMode");
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002417 File Offset: 0x00000617
		public static CullMode GetOpaqueCullMode(this Material material)
		{
			if (!material.HasProperty("_OpaqueCullMode"))
			{
				return CullMode.Back;
			}
			return (CullMode)material.GetInt("_OpaqueCullMode");
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002433 File Offset: 0x00000633
		public static CompareFunction GetTransparentZTest(this Material material)
		{
			if (!material.HasProperty("_ZTestTransparent"))
			{
				return CompareFunction.LessEqual;
			}
			return (CompareFunction)material.GetInt("_ZTestTransparent");
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000244F File Offset: 0x0000064F
		public static bool GetAddPrecomputedVelocity(this Material material)
		{
			return material.HasProperty("_AddPrecomputedVelocity") && material.GetInt("_AddPrecomputedVelocity") == 1;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002470 File Offset: 0x00000670
		public static void ResetMaterialCustomRenderQueue(this Material material)
		{
			SurfaceType surfaceType = material.GetSurfaceType();
			HDRenderQueue.RenderQueueType targetType;
			if (surfaceType != SurfaceType.Opaque)
			{
				if (surfaceType != SurfaceType.Transparent)
				{
					throw new ArgumentException("Unknown SurfaceType");
				}
				targetType = HDRenderQueue.GetTransparentEquivalent(HDRenderQueue.GetTypeByRenderQueueValue(material.renderQueue));
			}
			else
			{
				targetType = HDRenderQueue.GetOpaqueEquivalent(HDRenderQueue.GetTypeByRenderQueueValue(material.renderQueue));
			}
			float num = material.HasProperty("_TransparentSortPriority") ? material.GetFloat("_TransparentSortPriority") : 0f;
			bool alphaTest = material.HasProperty("_AlphaCutoffEnable") && material.GetFloat("_AlphaCutoffEnable") > 0f;
			bool receiveDecal = material.HasProperty("_SupportDecals") && material.GetFloat("_SupportDecals") > 0f;
			material.renderQueue = HDRenderQueue.ChangeType(targetType, (int)num, alphaTest, receiveDecal);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002538 File Offset: 0x00000738
		public static void UpdateEmissiveColorFromIntensityAndEmissiveColorLDR(this Material material)
		{
			if (material.HasProperty("_EmissiveColorLDR") && material.HasProperty("_EmissiveIntensity") && material.HasProperty("_EmissiveColor"))
			{
				Color color = material.GetColor("_EmissiveColorLDR");
				Color a = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
				material.SetColor("_EmissiveColor", a * material.GetFloat("_EmissiveIntensity"));
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000025BC File Offset: 0x000007BC
		public static DisplacementMode GetFilteredDisplacementMode(this Material material, DisplacementMode displacementMode)
		{
			if (material.HasProperty("_TessellationMode"))
			{
				if (displacementMode == DisplacementMode.Pixel || displacementMode == DisplacementMode.Vertex)
				{
					return DisplacementMode.None;
				}
			}
			else if (displacementMode == DisplacementMode.Tessellation)
			{
				return DisplacementMode.None;
			}
			return displacementMode;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000025DC File Offset: 0x000007DC
		public static bool HasPass(this Material material, string pass)
		{
			int i = 0;
			int passCount = material.passCount;
			while (i < passCount)
			{
				if (material.GetPassName(i).Equals(pass, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
				i++;
			}
			return false;
		}
	}
}
