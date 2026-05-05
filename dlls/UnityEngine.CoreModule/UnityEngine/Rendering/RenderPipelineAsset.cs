using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000466 RID: 1126
	public abstract class RenderPipelineAsset : ScriptableObject
	{
		// Token: 0x060025C8 RID: 9672 RVA: 0x00040AE0 File Offset: 0x0003ECE0
		internal RenderPipeline InternalCreatePipeline()
		{
			RenderPipeline result = null;
			try
			{
				result = this.CreatePipeline();
			}
			catch (Exception ex)
			{
				bool flag = !ex.Data.Contains("InvalidImport") || !(ex.Data["InvalidImport"] is int) || (int)ex.Data["InvalidImport"] != 1;
				if (flag)
				{
					Debug.LogException(ex);
				}
			}
			return result;
		}

		// Token: 0x170006E3 RID: 1763
		// (get) Token: 0x060025C9 RID: 9673 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual string[] renderingLayerMaskNames
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006E4 RID: 1764
		// (get) Token: 0x060025CA RID: 9674 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual string[] prefixedRenderingLayerMaskNames
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006E5 RID: 1765
		// (get) Token: 0x060025CB RID: 9675 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Material defaultMaterial
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006E6 RID: 1766
		// (get) Token: 0x060025CC RID: 9676 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Shader autodeskInteractiveShader
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006E7 RID: 1767
		// (get) Token: 0x060025CD RID: 9677 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Shader autodeskInteractiveTransparentShader
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x060025CE RID: 9678 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Shader autodeskInteractiveMaskedShader
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x060025CF RID: 9679 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Shader terrainDetailLitShader
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x060025D0 RID: 9680 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Shader terrainDetailGrassShader
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x060025D1 RID: 9681 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Shader terrainDetailGrassBillboardShader
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006EC RID: 1772
		// (get) Token: 0x060025D2 RID: 9682 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Material defaultParticleMaterial
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x060025D3 RID: 9683 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Material defaultLineMaterial
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006EE RID: 1774
		// (get) Token: 0x060025D4 RID: 9684 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Material defaultTerrainMaterial
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006EF RID: 1775
		// (get) Token: 0x060025D5 RID: 9685 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Material defaultUIMaterial
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x060025D6 RID: 9686 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Material defaultUIOverdrawMaterial
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006F1 RID: 1777
		// (get) Token: 0x060025D7 RID: 9687 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Material defaultUIETC1SupportedMaterial
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006F2 RID: 1778
		// (get) Token: 0x060025D8 RID: 9688 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Material default2DMaterial
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006F3 RID: 1779
		// (get) Token: 0x060025D9 RID: 9689 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Material default2DMaskMaterial
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006F4 RID: 1780
		// (get) Token: 0x060025DA RID: 9690 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Shader defaultShader
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006F5 RID: 1781
		// (get) Token: 0x060025DB RID: 9691 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Shader defaultSpeedTree7Shader
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006F6 RID: 1782
		// (get) Token: 0x060025DC RID: 9692 RVA: 0x00035E9E File Offset: 0x0003409E
		public virtual Shader defaultSpeedTree8Shader
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006F7 RID: 1783
		// (get) Token: 0x060025DD RID: 9693 RVA: 0x00040B68 File Offset: 0x0003ED68
		public virtual string renderPipelineShaderTag
		{
			get
			{
				Debug.LogWarning("The property renderPipelineShaderTag has not been overridden. At build time, any shader variants that use any RenderPipeline tag will be stripped.");
				return string.Empty;
			}
		}

		// Token: 0x060025DE RID: 9694
		protected abstract RenderPipeline CreatePipeline();

		// Token: 0x060025DF RID: 9695 RVA: 0x00040B8C File Offset: 0x0003ED8C
		protected virtual void OnValidate()
		{
			bool flag = RenderPipelineManager.s_CurrentPipelineAsset == this;
			if (flag)
			{
				RenderPipelineManager.CleanupRenderPipeline();
				RenderPipelineManager.PrepareRenderPipeline(this);
			}
		}

		// Token: 0x060025E0 RID: 9696 RVA: 0x00040BB8 File Offset: 0x0003EDB8
		protected virtual void OnDisable()
		{
			RenderPipelineManager.CleanupRenderPipeline();
		}
	}
}
