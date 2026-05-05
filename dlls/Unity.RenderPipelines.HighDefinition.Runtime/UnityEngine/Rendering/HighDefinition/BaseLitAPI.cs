using System;
using UnityEditor.Rendering.HighDefinition;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200010A RID: 266
	internal abstract class BaseLitAPI
	{
		// Token: 0x06000A3F RID: 2623 RVA: 0x0005783B File Offset: 0x00055A3B
		public static DisplacementMode GetFilteredDisplacementMode(Material material)
		{
			return material.GetFilteredDisplacementMode((DisplacementMode)material.GetFloat("_DisplacementMode"));
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x00057850 File Offset: 0x00055A50
		public static void SetupBaseLitKeywords(Material material)
		{
			material.SetupBaseUnlitKeywords();
			if (material.HasProperty("_DoubleSidedEnable") && material.GetFloat("_DoubleSidedEnable") > 0f)
			{
				switch ((int)material.GetFloat("_DoubleSidedNormalMode"))
				{
				case 0:
					material.SetVector("_DoubleSidedConstants", new Vector4(-1f, -1f, -1f, 0f));
					break;
				case 1:
					material.SetVector("_DoubleSidedConstants", new Vector4(1f, 1f, -1f, 0f));
					break;
				case 2:
					material.SetVector("_DoubleSidedConstants", new Vector4(1f, 1f, 1f, 0f));
					break;
				}
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool state = false;
			bool flag7 = material.HasProperty("_DisplacementMode") && BaseLitAPI.GetFilteredDisplacementMode(material) > DisplacementMode.None;
			if (flag7)
			{
				DisplacementMode filteredDisplacementMode = BaseLitAPI.GetFilteredDisplacementMode(material);
				flag = (filteredDisplacementMode == DisplacementMode.Vertex);
				flag2 = (filteredDisplacementMode == DisplacementMode.Pixel);
				flag3 = (filteredDisplacementMode == DisplacementMode.Tessellation);
				flag4 = (material.GetFloat("_DisplacementLockObjectScale") > 0f);
				flag5 = (material.GetFloat("_DisplacementLockTilingScale") > 0f);
			}
			if (flag2 || (!material.HasProperty("_DisplacementMode") && material.HasProperty("_DepthOffsetEnable")))
			{
				flag6 = (material.GetFloat("_DepthOffsetEnable") > 0f);
			}
			if (flag6 && material.HasProperty("_ConservativeDepthOffsetEnable"))
			{
				state = (material.GetFloat("_ConservativeDepthOffsetEnable") > 0f);
			}
			CoreUtils.SetKeyword(material, "_VERTEX_DISPLACEMENT", flag);
			CoreUtils.SetKeyword(material, "_PIXEL_DISPLACEMENT", flag2);
			CoreUtils.SetKeyword(material, "_TESSELLATION_DISPLACEMENT", flag3);
			CoreUtils.SetKeyword(material, "_VERTEX_DISPLACEMENT_LOCK_OBJECT_SCALE", flag4 && (flag || flag3));
			CoreUtils.SetKeyword(material, "_PIXEL_DISPLACEMENT_LOCK_OBJECT_SCALE", flag4 && flag2);
			CoreUtils.SetKeyword(material, "_DISPLACEMENT_LOCK_TILING_SCALE", flag5 && flag7);
			CoreUtils.SetKeyword(material, "_DEPTHOFFSET_ON", flag6);
			CoreUtils.SetKeyword(material, "_CONSERVATIVE_DEPTH_OFFSET", state);
			CoreUtils.SetKeyword(material, "_VERTEX_WIND", false);
			material.SetupMainTexForAlphaTestGI("_BaseColorMap", "_BaseColor");
			CoreUtils.SetKeyword(material, "_DISABLE_DECALS", material.HasProperty("_SupportDecals") && material.GetFloat("_SupportDecals") == 0f);
			CoreUtils.SetKeyword(material, "_DISABLE_SSR", material.HasProperty("_ReceivesSSR") && material.GetFloat("_ReceivesSSR") == 0f);
			CoreUtils.SetKeyword(material, "_DISABLE_SSR_TRANSPARENT", material.HasProperty("_ReceivesSSRTransparent") && material.GetFloat("_ReceivesSSRTransparent") == 0f);
			CoreUtils.SetKeyword(material, "_ENABLE_GEOMETRIC_SPECULAR_AA", material.HasProperty("_EnableGeometricSpecularAA") && material.GetFloat("_EnableGeometricSpecularAA") == 1f);
			if (material.HasProperty("_RefractionModel"))
			{
				ScreenSpaceRefraction.RefractionModel refractionModel = (ScreenSpaceRefraction.RefractionModel)material.GetFloat("_RefractionModel");
				bool flag8 = material.GetSurfaceType() == SurfaceType.Transparent && !HDRenderQueue.k_RenderQueue_PreRefraction.Contains(material.renderQueue);
				CoreUtils.SetKeyword(material, "_REFRACTION_PLANE", refractionModel == ScreenSpaceRefraction.RefractionModel.Planar && flag8);
				CoreUtils.SetKeyword(material, "_REFRACTION_SPHERE", refractionModel == ScreenSpaceRefraction.RefractionModel.Sphere && flag8);
				CoreUtils.SetKeyword(material, "_REFRACTION_THIN", refractionModel == ScreenSpaceRefraction.RefractionModel.Thin && flag8);
			}
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x00057B95 File Offset: 0x00055D95
		public static bool CompatibleWithExcludeFromTUAndAA(SurfaceType surfaceType, int renderQueue)
		{
			return surfaceType == SurfaceType.Transparent && HDRenderQueue.k_RenderQueue_Transparent.Contains(renderQueue);
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x00057BA8 File Offset: 0x00055DA8
		public static bool CompatibleWithExcludeFromTUAndAA(Material material)
		{
			return BaseLitAPI.CompatibleWithExcludeFromTUAndAA(material.GetSurfaceType(), material.renderQueue) && material.HasProperty("_ExcludeFromTUAndAA");
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x00057BCC File Offset: 0x00055DCC
		public static void SetupStencil(Material material, bool receivesLighting, bool receivesSSR, bool useSplitLighting, bool excludeFromTUAndAA = false)
		{
			bool forwardOnly = material.shader.FindPropertyIndex("_ZTestGBuffer") == -1;
			int value;
			int value2;
			int value3;
			int value4;
			int value5;
			int value6;
			int value7;
			int value8;
			BaseLitAPI.ComputeStencilProperties(receivesLighting, forwardOnly, receivesSSR, useSplitLighting, excludeFromTUAndAA, out value, out value2, out value3, out value4, out value5, out value6, out value7, out value8);
			if (material.HasProperty("_StencilRef"))
			{
				material.SetInt("_StencilRef", value);
				material.SetInt("_StencilWriteMask", value2);
			}
			if (material.HasProperty("_StencilRefDepth"))
			{
				material.SetInt("_StencilRefDepth", value3);
				material.SetInt("_StencilWriteMaskDepth", value4);
			}
			if (material.HasProperty("_StencilRefGBuffer"))
			{
				material.SetInt("_StencilRefGBuffer", value5);
				material.SetInt("_StencilWriteMaskGBuffer", value6);
			}
			if (material.HasProperty("_StencilRefDistortionVec"))
			{
				material.SetInt("_StencilRefDistortionVec", 4);
				material.SetInt("_StencilWriteMaskDistortionVec", 4);
			}
			if (material.HasProperty("_StencilRefMV"))
			{
				material.SetInt("_StencilRefMV", value7);
				material.SetInt("_StencilWriteMaskMV", value8);
			}
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x00057CC8 File Offset: 0x00055EC8
		public static void ComputeStencilProperties(bool receivesLighting, bool forwardOnly, bool receivesSSR, bool useSplitLighting, bool excludeFromTUAndAA, out int stencilRef, out int stencilWriteMask, out int stencilRefDepth, out int stencilWriteMaskDepth, out int stencilRefGBuffer, out int stencilWriteMaskGBuffer, out int stencilRefMV, out int stencilWriteMaskMV)
		{
			stencilRef = 0;
			stencilWriteMask = 6;
			stencilRefDepth = 0;
			stencilWriteMaskDepth = 0;
			stencilRefGBuffer = 2;
			stencilWriteMaskGBuffer = 6;
			stencilRefMV = 32;
			stencilWriteMaskMV = 32;
			if (forwardOnly)
			{
				stencilWriteMaskMV |= 2;
			}
			if (useSplitLighting)
			{
				stencilRefGBuffer |= 4;
				stencilRef |= 4;
			}
			if (receivesSSR)
			{
				stencilRefDepth |= 8;
				stencilRefGBuffer |= 8;
				stencilRefMV |= 8;
			}
			stencilWriteMaskDepth |= 8;
			stencilWriteMaskGBuffer |= 8;
			stencilWriteMaskMV |= 8;
			if (!receivesLighting)
			{
				stencilRefDepth |= 1;
				stencilWriteMaskDepth |= 1;
				stencilRefMV |= 1;
			}
			if (excludeFromTUAndAA)
			{
				stencilRefDepth |= 2;
				stencilRef |= 2;
				stencilWriteMask |= 2;
				stencilWriteMaskDepth |= 2;
			}
			stencilWriteMaskDepth |= 1;
			stencilWriteMaskGBuffer |= 1;
			stencilWriteMaskMV |= 1;
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x00057D9F File Offset: 0x00055F9F
		public static void SetupBaseLitMaterialPass(Material material)
		{
			material.SetupBaseUnlitPass();
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x00057DA8 File Offset: 0x00055FA8
		public static void SetupDisplacement(Material material, int layerCount = 1)
		{
			DisplacementMode filteredDisplacementMode = BaseLitAPI.GetFilteredDisplacementMode(material);
			for (int i = 0; i < layerCount; i++)
			{
				string name = (layerCount > 1) ? ("_HeightAmplitude" + i.ToString()) : "_HeightAmplitude";
				string name2 = (layerCount > 1) ? ("_HeightCenter" + i.ToString()) : "_HeightCenter";
				if (material.HasProperty(name) && material.HasProperty(name2))
				{
					string name3 = (layerCount > 1) ? ("_HeightPoMAmplitude" + i.ToString()) : "_HeightPoMAmplitude";
					string name4 = (layerCount > 1) ? ("_HeightMapParametrization" + i.ToString()) : "_HeightMapParametrization";
					string name5 = (layerCount > 1) ? ("_HeightTessAmplitude" + i.ToString()) : "_HeightTessAmplitude";
					string name6 = (layerCount > 1) ? ("_HeightTessCenter" + i.ToString()) : "_HeightTessCenter";
					string name7 = (layerCount > 1) ? ("_HeightOffset" + i.ToString()) : "_HeightOffset";
					string name8 = (layerCount > 1) ? ("_HeightMin" + i.ToString()) : "_HeightMin";
					string name9 = (layerCount > 1) ? ("_HeightMax" + i.ToString()) : "_HeightMax";
					if (filteredDisplacementMode == DisplacementMode.Pixel)
					{
						material.SetFloat(name, material.GetFloat(name3) * 0.01f);
						material.SetFloat(name2, 1f);
					}
					else if ((int)material.GetFloat(name4) == 0)
					{
						float @float = material.GetFloat(name7);
						float float2 = material.GetFloat(name8);
						float num = material.GetFloat(name9) - float2;
						material.SetFloat(name, num * 0.01f);
						material.SetFloat(name2, -(float2 + @float) / Mathf.Max(1E-06f, num));
					}
					else
					{
						float float3 = material.GetFloat(name7);
						float float4 = material.GetFloat(name6);
						float float5 = material.GetFloat(name5);
						material.SetFloat(name, float5 * 0.01f);
						material.SetFloat(name2, -float3 / Mathf.Max(1E-06f, float5) + float4);
					}
				}
			}
		}

		// Token: 0x04000B0B RID: 2827
		protected const string kWindEnabled = "_EnableWind";
	}
}
