using System;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering.HighDefinition.Attributes;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000EA RID: 234
	internal class AxF : RenderPipelineMaterial
	{
		// Token: 0x06000978 RID: 2424 RVA: 0x000532AC File Offset: 0x000514AC
		public override void Build(HDRenderPipelineAsset hdAsset, HDRenderPipelineRuntimeResources defaultResources)
		{
			this.m_preIntegratedFGDMaterial_Ward = CoreUtils.CreateEngineMaterial(defaultResources.shaders.preIntegratedFGD_WardPS);
			if (this.m_preIntegratedFGDMaterial_Ward == null)
			{
				throw new Exception("Failed to create material for Ward BRDF pre-integration!");
			}
			this.m_preIntegratedFGDMaterial_CookTorrance = CoreUtils.CreateEngineMaterial(defaultResources.shaders.preIntegratedFGD_CookTorrancePS);
			if (this.m_preIntegratedFGDMaterial_CookTorrance == null)
			{
				throw new Exception("Failed to create material for Cook-Torrance BRDF pre-integration!");
			}
			this.m_preIntegratedFGD_Ward = new RenderTexture(128, 128, 0, GraphicsFormat.A2B10G10R10_UNormPack32);
			this.m_preIntegratedFGD_Ward.hideFlags = HideFlags.HideAndDontSave;
			this.m_preIntegratedFGD_Ward.filterMode = FilterMode.Bilinear;
			this.m_preIntegratedFGD_Ward.wrapMode = TextureWrapMode.Clamp;
			this.m_preIntegratedFGD_Ward.hideFlags = HideFlags.DontSave;
			this.m_preIntegratedFGD_Ward.name = CoreUtils.GetRenderTargetAutoName(128, 128, 1, GraphicsFormat.A2B10G10R10_UNormPack32, "PreIntegratedFGD_Ward", false, false, MSAASamples.None);
			this.m_preIntegratedFGD_Ward.Create();
			this.m_preIntegratedFGD_CookTorrance = new RenderTexture(128, 128, 0, GraphicsFormat.A2B10G10R10_UNormPack32);
			this.m_preIntegratedFGD_CookTorrance.hideFlags = HideFlags.HideAndDontSave;
			this.m_preIntegratedFGD_CookTorrance.filterMode = FilterMode.Bilinear;
			this.m_preIntegratedFGD_CookTorrance.wrapMode = TextureWrapMode.Clamp;
			this.m_preIntegratedFGD_CookTorrance.hideFlags = HideFlags.DontSave;
			this.m_preIntegratedFGD_CookTorrance.name = CoreUtils.GetRenderTargetAutoName(128, 128, 1, GraphicsFormat.A2B10G10R10_UNormPack32, "PreIntegratedFGD_CookTorrance", false, false, MSAASamples.None);
			this.m_preIntegratedFGD_CookTorrance.Create();
			this.m_LtcData = new Texture2DArray(64, 64, 3, GraphicsFormat.R16G16B16A16_SFloat, TextureCreationFlags.None)
			{
				hideFlags = HideFlags.HideAndDontSave,
				wrapMode = TextureWrapMode.Clamp,
				filterMode = FilterMode.Bilinear,
				name = CoreUtils.GetTextureAutoName(64, 64, GraphicsFormat.R16G16B16A16_SFloat, TextureDimension.Tex2DArray, "LTC_LUT", false, 2)
			};
			LTCAreaLight.LoadLUT(this.m_LtcData, 0, GraphicsFormat.R16G16B16A16_SFloat, LTCAreaLight.s_LtcMatrixData_GGX);
			this.m_LtcData.Apply();
			LTCAreaLight.instance.Build();
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x00053478 File Offset: 0x00051678
		public override void Cleanup()
		{
			CoreUtils.Destroy(this.m_preIntegratedFGD_CookTorrance);
			CoreUtils.Destroy(this.m_preIntegratedFGD_Ward);
			CoreUtils.Destroy(this.m_preIntegratedFGDMaterial_CookTorrance);
			CoreUtils.Destroy(this.m_preIntegratedFGDMaterial_Ward);
			this.m_preIntegratedFGD_CookTorrance = null;
			this.m_preIntegratedFGD_Ward = null;
			this.m_preIntegratedFGDMaterial_Ward = null;
			this.m_preIntegratedFGDMaterial_CookTorrance = null;
			this.m_precomputedFGDTablesAreInit = false;
			CoreUtils.Destroy(this.m_LtcData);
			LTCAreaLight.instance.Cleanup();
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x000534EC File Offset: 0x000516EC
		public override void RenderInit(CommandBuffer cmd)
		{
			if (this.m_precomputedFGDTablesAreInit || this.m_preIntegratedFGDMaterial_Ward == null || this.m_preIntegratedFGDMaterial_CookTorrance == null)
			{
				return;
			}
			if (GL.wireframe)
			{
				this.m_preIntegratedFGD_Ward.Create();
				this.m_preIntegratedFGD_CookTorrance.Create();
				return;
			}
			using (new ProfilingScope(cmd, ProfilingSampler.Get<HDProfileId>(HDProfileId.PreIntegradeWardCookTorrance)))
			{
				CoreUtils.DrawFullScreen(cmd, this.m_preIntegratedFGDMaterial_Ward, new RenderTargetIdentifier(this.m_preIntegratedFGD_Ward), null, 0);
				CoreUtils.DrawFullScreen(cmd, this.m_preIntegratedFGDMaterial_CookTorrance, new RenderTargetIdentifier(this.m_preIntegratedFGD_CookTorrance), null, 0);
			}
			this.m_precomputedFGDTablesAreInit = true;
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x000535A8 File Offset: 0x000517A8
		public override void Bind(CommandBuffer cmd)
		{
			if (this.m_preIntegratedFGD_Ward == null || this.m_preIntegratedFGD_CookTorrance == null)
			{
				throw new Exception("Ward & Cook-Torrance BRDF pre-integration table not available!");
			}
			cmd.SetGlobalTexture(AxF._PreIntegratedFGD_Ward, this.m_preIntegratedFGD_Ward);
			cmd.SetGlobalTexture(AxF._PreIntegratedFGD_CookTorrance, this.m_preIntegratedFGD_CookTorrance);
			cmd.SetGlobalTexture(AxF._AxFLtcData, this.m_LtcData);
			LTCAreaLight.instance.Bind(cmd);
		}

		// Token: 0x04000A1E RID: 2590
		private Texture2DArray m_LtcData;

		// Token: 0x04000A1F RID: 2591
		private Material m_preIntegratedFGDMaterial_Ward;

		// Token: 0x04000A20 RID: 2592
		private Material m_preIntegratedFGDMaterial_CookTorrance;

		// Token: 0x04000A21 RID: 2593
		private RenderTexture m_preIntegratedFGD_Ward;

		// Token: 0x04000A22 RID: 2594
		private RenderTexture m_preIntegratedFGD_CookTorrance;

		// Token: 0x04000A23 RID: 2595
		private bool m_precomputedFGDTablesAreInit;

		// Token: 0x04000A24 RID: 2596
		public static readonly int _PreIntegratedFGD_Ward = Shader.PropertyToID("_PreIntegratedFGD_Ward");

		// Token: 0x04000A25 RID: 2597
		public static readonly int _PreIntegratedFGD_CookTorrance = Shader.PropertyToID("_PreIntegratedFGD_CookTorrance");

		// Token: 0x04000A26 RID: 2598
		public static readonly int _AxFLtcData = Shader.PropertyToID("_AxFLtcData");

		// Token: 0x02000371 RID: 881
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\AxF\\AxF.cs")]
		public enum FeatureFlags
		{
			// Token: 0x040023C0 RID: 9152
			AxfAnisotropy = 1,
			// Token: 0x040023C1 RID: 9153
			AxfClearCoat,
			// Token: 0x040023C2 RID: 9154
			AxfClearCoatRefraction = 4,
			// Token: 0x040023C3 RID: 9155
			AxfUseHeightMap = 8,
			// Token: 0x040023C4 RID: 9156
			AxfBRDFColorDiagonalClamp = 16,
			// Token: 0x040023C5 RID: 9157
			AxfHonorMinRoughness = 256,
			// Token: 0x040023C6 RID: 9158
			AxfHonorMinRoughnessCoat = 512,
			// Token: 0x040023C7 RID: 9159
			AxfDebugTest = 8388608
		}

		// Token: 0x02000372 RID: 882
		[GenerateHLSL(PackingRules.Exact, false, false, true, 1200, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\AxF\\AxF.cs")]
		public struct SurfaceData
		{
			// Token: 0x040023C8 RID: 9160
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Smoothness)]
			[SurfaceDataAttributes("Smoothness", false, false, FieldPrecision.Default, false, "", precision = FieldPrecision.Real)]
			public float perceptualSmoothness;

			// Token: 0x040023C9 RID: 9161
			[MaterialSharedPropertyMapping(MaterialSharedProperty.AmbientOcclusion)]
			[SurfaceDataAttributes("Ambient Occlusion", false, false, FieldPrecision.Default, false, "")]
			public float ambientOcclusion;

			// Token: 0x040023CA RID: 9162
			[SurfaceDataAttributes("Specular Occlusion", false, false, FieldPrecision.Default, false, "")]
			public float specularOcclusion;

			// Token: 0x040023CB RID: 9163
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Normal)]
			[SurfaceDataAttributes(new string[]
			{
				"Normal",
				"Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 normalWS;

			// Token: 0x040023CC RID: 9164
			[SurfaceDataAttributes("Tangent", true, false, FieldPrecision.Default, false, "")]
			public Vector3 tangentWS;

			// Token: 0x040023CD RID: 9165
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Albedo)]
			[SurfaceDataAttributes("Diffuse Color", false, true, FieldPrecision.Default, false, "")]
			public Vector3 diffuseColor;

			// Token: 0x040023CE RID: 9166
			[MaterialSharedPropertyMapping(MaterialSharedProperty.Specular)]
			[SurfaceDataAttributes("Specular Color", false, true, FieldPrecision.Default, false, "")]
			public Vector3 specularColor;

			// Token: 0x040023CF RID: 9167
			[SurfaceDataAttributes("Fresnel F0", false, false, FieldPrecision.Default, false, "")]
			public Vector3 fresnel0;

			// Token: 0x040023D0 RID: 9168
			[SurfaceDataAttributes("Specular Lobe", false, false, FieldPrecision.Default, false, "")]
			public Vector3 specularLobe;

			// Token: 0x040023D1 RID: 9169
			[SurfaceDataAttributes("Height", false, false, FieldPrecision.Default, false, "")]
			public float height_mm;

			// Token: 0x040023D2 RID: 9170
			[SurfaceDataAttributes("Anisotropic Angle", false, false, FieldPrecision.Default, false, "")]
			public float anisotropyAngle;

			// Token: 0x040023D3 RID: 9171
			[SurfaceDataAttributes("Flakes UV (or PlanarZY)", false, false, FieldPrecision.Default, false, "")]
			public Vector2 flakesUVZY;

			// Token: 0x040023D4 RID: 9172
			[SurfaceDataAttributes("Flakes PlanarXZ", false, false, FieldPrecision.Default, false, "")]
			public Vector2 flakesUVXZ;

			// Token: 0x040023D5 RID: 9173
			[SurfaceDataAttributes("Flakes PlanarXY", false, false, FieldPrecision.Default, false, "")]
			public Vector2 flakesUVXY;

			// Token: 0x040023D6 RID: 9174
			[SurfaceDataAttributes("Flakes Mip (and for PlanarZY)", false, false, FieldPrecision.Default, false, "")]
			public float flakesMipLevelZY;

			// Token: 0x040023D7 RID: 9175
			[SurfaceDataAttributes("Flakes Mip for PlanarXZ", false, false, FieldPrecision.Default, false, "")]
			public float flakesMipLevelXZ;

			// Token: 0x040023D8 RID: 9176
			[SurfaceDataAttributes("Flakes Mip for PlanarXY", false, false, FieldPrecision.Default, false, "")]
			public float flakesMipLevelXY;

			// Token: 0x040023D9 RID: 9177
			[SurfaceDataAttributes("Flakes Triplanar Weights", false, false, FieldPrecision.Default, false, "")]
			public Vector3 flakesTriplanarWeights;

			// Token: 0x040023DA RID: 9178
			[SurfaceDataAttributes("Flakes ddx (and for PlanarZY)", false, false, FieldPrecision.Default, false, "")]
			public Vector2 flakesDdxZY;

			// Token: 0x040023DB RID: 9179
			[SurfaceDataAttributes("Flakes ddy (and for PlanarZY)", false, false, FieldPrecision.Default, false, "")]
			public Vector2 flakesDdyZY;

			// Token: 0x040023DC RID: 9180
			[SurfaceDataAttributes("Flakes ddx for PlanarXZ", false, false, FieldPrecision.Default, false, "")]
			public Vector2 flakesDdxXZ;

			// Token: 0x040023DD RID: 9181
			[SurfaceDataAttributes("Flakes ddy for PlanarXZ", false, false, FieldPrecision.Default, false, "")]
			public Vector2 flakesDdyXZ;

			// Token: 0x040023DE RID: 9182
			[SurfaceDataAttributes("Flakes ddx for PlanarXY", false, false, FieldPrecision.Default, false, "")]
			public Vector2 flakesDdxXY;

			// Token: 0x040023DF RID: 9183
			[SurfaceDataAttributes("Flakes ddy for PlanarXY", false, false, FieldPrecision.Default, false, "")]
			public Vector2 flakesDdyXY;

			// Token: 0x040023E0 RID: 9184
			[SurfaceDataAttributes("Clearcoat Color", false, false, FieldPrecision.Default, false, "")]
			public Vector3 clearcoatColor;

			// Token: 0x040023E1 RID: 9185
			[SurfaceDataAttributes("Clearcoat Normal", true, false, FieldPrecision.Default, false, "")]
			public Vector3 clearcoatNormalWS;

			// Token: 0x040023E2 RID: 9186
			[SurfaceDataAttributes("Clearcoat IOR", false, false, FieldPrecision.Default, false, "")]
			public float clearcoatIOR;

			// Token: 0x040023E3 RID: 9187
			[SurfaceDataAttributes(new string[]
			{
				"Geometric Normal",
				"Geometric Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 geomNormalWS;

			// Token: 0x040023E4 RID: 9188
			[SurfaceDataAttributes("View Direction", true, false, FieldPrecision.Default, false, "")]
			public Vector3 viewWS;
		}

		// Token: 0x02000373 RID: 883
		[GenerateHLSL(PackingRules.Exact, false, false, true, 1250, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\AxF\\AxF.cs")]
		public struct BSDFData
		{
			// Token: 0x040023E5 RID: 9189
			public float ambientOcclusion;

			// Token: 0x040023E6 RID: 9190
			public float specularOcclusion;

			// Token: 0x040023E7 RID: 9191
			[SurfaceDataAttributes(new string[]
			{
				"Normal WS",
				"Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 normalWS;

			// Token: 0x040023E8 RID: 9192
			[SurfaceDataAttributes("", true, false, FieldPrecision.Default, false, "")]
			public Vector3 tangentWS;

			// Token: 0x040023E9 RID: 9193
			[SurfaceDataAttributes("", true, false, FieldPrecision.Default, false, "")]
			public Vector3 bitangentWS;

			// Token: 0x040023EA RID: 9194
			public Vector3 diffuseColor;

			// Token: 0x040023EB RID: 9195
			public Vector3 specularColor;

			// Token: 0x040023EC RID: 9196
			public Vector3 fresnel0;

			// Token: 0x040023ED RID: 9197
			public float perceptualRoughness;

			// Token: 0x040023EE RID: 9198
			public Vector3 roughness;

			// Token: 0x040023EF RID: 9199
			public float height_mm;

			// Token: 0x040023F0 RID: 9200
			public Vector2 flakesUVZY;

			// Token: 0x040023F1 RID: 9201
			public Vector2 flakesUVXZ;

			// Token: 0x040023F2 RID: 9202
			public Vector2 flakesUVXY;

			// Token: 0x040023F3 RID: 9203
			public float flakesMipLevelZY;

			// Token: 0x040023F4 RID: 9204
			public float flakesMipLevelXZ;

			// Token: 0x040023F5 RID: 9205
			public float flakesMipLevelXY;

			// Token: 0x040023F6 RID: 9206
			public Vector3 flakesTriplanarWeights;

			// Token: 0x040023F7 RID: 9207
			public Vector2 flakesDdxZY;

			// Token: 0x040023F8 RID: 9208
			public Vector2 flakesDdyZY;

			// Token: 0x040023F9 RID: 9209
			public Vector2 flakesDdxXZ;

			// Token: 0x040023FA RID: 9210
			public Vector2 flakesDdyXZ;

			// Token: 0x040023FB RID: 9211
			public Vector2 flakesDdxXY;

			// Token: 0x040023FC RID: 9212
			public Vector2 flakesDdyXY;

			// Token: 0x040023FD RID: 9213
			public Vector3 clearcoatColor;

			// Token: 0x040023FE RID: 9214
			[SurfaceDataAttributes("", true, false, FieldPrecision.Default, false, "")]
			public Vector3 clearcoatNormalWS;

			// Token: 0x040023FF RID: 9215
			public float clearcoatIOR;

			// Token: 0x04002400 RID: 9216
			[SurfaceDataAttributes(new string[]
			{
				"Geometric Normal",
				"Geometric Normal View Space"
			}, true, false, FieldPrecision.Default, false, "", checkIsNormalized = true)]
			public Vector3 geomNormalWS;

			// Token: 0x04002401 RID: 9217
			[SurfaceDataAttributes("View Direction", true, false, FieldPrecision.Default, false, "")]
			public Vector3 viewWS;
		}
	}
}
