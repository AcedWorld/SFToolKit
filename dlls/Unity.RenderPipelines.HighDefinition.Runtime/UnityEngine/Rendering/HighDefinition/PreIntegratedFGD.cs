using System;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200010F RID: 271
	internal class PreIntegratedFGD
	{
		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000A5F RID: 2655 RVA: 0x00058BD9 File Offset: 0x00056DD9
		public static PreIntegratedFGD instance
		{
			get
			{
				if (PreIntegratedFGD.s_Instance == null)
				{
					PreIntegratedFGD.s_Instance = new PreIntegratedFGD();
				}
				return PreIntegratedFGD.s_Instance;
			}
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x00058BF4 File Offset: 0x00056DF4
		private PreIntegratedFGD()
		{
			for (int i = 0; i < 3; i++)
			{
				this.m_isInit[i] = false;
				this.m_refCounting[i] = 0;
			}
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x00058C58 File Offset: 0x00056E58
		public void Build(PreIntegratedFGD.FGDIndex index)
		{
			if (this.m_refCounting[(int)index] == 0)
			{
				int num = 64;
				switch (index)
				{
				case PreIntegratedFGD.FGDIndex.FGD_GGXAndDisneyDiffuse:
					this.m_PreIntegratedFGDMaterial[(int)index] = CoreUtils.CreateEngineMaterial(HDRenderPipelineGlobalSettings.instance.renderPipelineResources.shaders.preIntegratedFGD_GGXDisneyDiffusePS);
					this.m_PreIntegratedFGD[(int)index] = new RenderTexture(num, num, 0, GraphicsFormat.A2B10G10R10_UNormPack32);
					this.m_PreIntegratedFGD[(int)index].hideFlags = HideFlags.HideAndDontSave;
					this.m_PreIntegratedFGD[(int)index].filterMode = FilterMode.Bilinear;
					this.m_PreIntegratedFGD[(int)index].wrapMode = TextureWrapMode.Clamp;
					this.m_PreIntegratedFGD[(int)index].name = CoreUtils.GetRenderTargetAutoName(num, num, 1, GraphicsFormat.A2B10G10R10_UNormPack32, "preIntegratedFGD_GGXDisneyDiffuse", false, false, MSAASamples.None);
					this.m_PreIntegratedFGD[(int)index].Create();
					break;
				case PreIntegratedFGD.FGDIndex.FGD_CharlieAndFabricLambert:
					this.m_PreIntegratedFGDMaterial[(int)index] = CoreUtils.CreateEngineMaterial(HDRenderPipelineGlobalSettings.instance.renderPipelineResources.shaders.preIntegratedFGD_CharlieFabricLambertPS);
					this.m_PreIntegratedFGD[(int)index] = new RenderTexture(num, num, 0, GraphicsFormat.A2B10G10R10_UNormPack32);
					this.m_PreIntegratedFGD[(int)index].hideFlags = HideFlags.HideAndDontSave;
					this.m_PreIntegratedFGD[(int)index].filterMode = FilterMode.Bilinear;
					this.m_PreIntegratedFGD[(int)index].wrapMode = TextureWrapMode.Clamp;
					this.m_PreIntegratedFGD[(int)index].name = CoreUtils.GetRenderTargetAutoName(num, num, 1, GraphicsFormat.A2B10G10R10_UNormPack32, "preIntegratedFGD_CharlieFabricLambert", false, false, MSAASamples.None);
					this.m_PreIntegratedFGD[(int)index].Create();
					break;
				case PreIntegratedFGD.FGDIndex.FGD_Marschner:
					this.m_PreIntegratedFGDMaterial[(int)index] = CoreUtils.CreateEngineMaterial(HDRenderPipelineGlobalSettings.instance.renderPipelineResources.shaders.preIntegratedFGD_MarschnerPS);
					this.m_PreIntegratedFGD[(int)index] = new RenderTexture(num, num, 0, GraphicsFormat.A2B10G10R10_UNormPack32);
					this.m_PreIntegratedFGD[(int)index].hideFlags = HideFlags.HideAndDontSave;
					this.m_PreIntegratedFGD[(int)index].filterMode = FilterMode.Bilinear;
					this.m_PreIntegratedFGD[(int)index].wrapMode = TextureWrapMode.Clamp;
					this.m_PreIntegratedFGD[(int)index].name = CoreUtils.GetRenderTargetAutoName(num, num, 1, GraphicsFormat.A2B10G10R10_UNormPack32, "preIntegratedFGD_Marschner", false, false, MSAASamples.None);
					this.m_PreIntegratedFGD[(int)index].Create();
					break;
				}
				this.m_isInit[(int)index] = false;
			}
			this.m_refCounting[(int)index]++;
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x00058E54 File Offset: 0x00057054
		public void RenderInit(PreIntegratedFGD.FGDIndex index, CommandBuffer cmd)
		{
			if (this.m_isInit[(int)index] && this.m_PreIntegratedFGD[(int)index].IsCreated())
			{
				return;
			}
			if (GL.wireframe)
			{
				this.m_PreIntegratedFGD[(int)index].Create();
				return;
			}
			CoreUtils.DrawFullScreen(cmd, this.m_PreIntegratedFGDMaterial[(int)index], new RenderTargetIdentifier(this.m_PreIntegratedFGD[(int)index]), null, 0);
			this.m_isInit[(int)index] = true;
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x00058EB7 File Offset: 0x000570B7
		public void Cleanup(PreIntegratedFGD.FGDIndex index)
		{
			this.m_refCounting[(int)index]--;
			if (this.m_refCounting[(int)index] == 0)
			{
				CoreUtils.Destroy(this.m_PreIntegratedFGDMaterial[(int)index]);
				CoreUtils.Destroy(this.m_PreIntegratedFGD[(int)index]);
				this.m_isInit[(int)index] = false;
			}
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x00058EF8 File Offset: 0x000570F8
		public void Bind(CommandBuffer cmd, PreIntegratedFGD.FGDIndex index)
		{
			switch (index)
			{
			case PreIntegratedFGD.FGDIndex.FGD_GGXAndDisneyDiffuse:
				cmd.SetGlobalTexture(HDShaderIDs._PreIntegratedFGD_GGXDisneyDiffuse, this.m_PreIntegratedFGD[(int)index]);
				return;
			case PreIntegratedFGD.FGDIndex.FGD_CharlieAndFabricLambert:
				cmd.SetGlobalTexture(HDShaderIDs._PreIntegratedFGD_CharlieAndFabric, this.m_PreIntegratedFGD[(int)index]);
				return;
			case PreIntegratedFGD.FGDIndex.FGD_Marschner:
				cmd.SetGlobalTexture(HDShaderIDs._PreIntegratedFGD_CharlieAndFabric, this.m_PreIntegratedFGD[(int)index]);
				return;
			default:
				return;
			}
		}

		// Token: 0x04000B1B RID: 2843
		private static PreIntegratedFGD s_Instance;

		// Token: 0x04000B1C RID: 2844
		private bool[] m_isInit = new bool[3];

		// Token: 0x04000B1D RID: 2845
		private int[] m_refCounting = new int[3];

		// Token: 0x04000B1E RID: 2846
		private Material[] m_PreIntegratedFGDMaterial = new Material[3];

		// Token: 0x04000B1F RID: 2847
		private RenderTexture[] m_PreIntegratedFGD = new RenderTexture[3];

		// Token: 0x02000398 RID: 920
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\PreIntegratedFGD\\PreIntegratedFGD.cs")]
		public enum FGDTexture
		{
			// Token: 0x0400256A RID: 9578
			Resolution = 64
		}

		// Token: 0x02000399 RID: 921
		public enum FGDIndex
		{
			// Token: 0x0400256C RID: 9580
			FGD_GGXAndDisneyDiffuse,
			// Token: 0x0400256D RID: 9581
			FGD_CharlieAndFabricLambert,
			// Token: 0x0400256E RID: 9582
			FGD_Marschner,
			// Token: 0x0400256F RID: 9583
			Count
		}
	}
}
