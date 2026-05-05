using System;
using System.Collections.Generic;
using UnityEngine.Rendering.RendererUtils;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001A2 RID: 418
	[Serializable]
	public class DrawRenderersCustomPass : CustomPass
	{
		// Token: 0x06000D2B RID: 3371 RVA: 0x0006B8E0 File Offset: 0x00069AE0
		protected override void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
		{
			this.fadeValueId = Shader.PropertyToID("_FadeValue");
			if (string.IsNullOrEmpty(this.overrideMaterialPassName) && this.overrideMaterial != null)
			{
				this.overrideMaterialPassName = this.overrideMaterial.GetPassName(this.overrideMaterialPassIndex);
			}
			if (string.IsNullOrEmpty(this.overrideShaderPassName) && this.overrideShader != null)
			{
				this.overrideShaderPassName = new Material(this.overrideShader).GetPassName(this.overrideShaderPassIndex);
			}
			DrawRenderersCustomPass.forwardShaderTags = new ShaderTagId[]
			{
				HDShaderPassNames.s_ForwardName,
				HDShaderPassNames.s_ForwardOnlyName,
				HDShaderPassNames.s_SRPDefaultUnlitName,
				HDShaderPassNames.s_EmptyName
			};
			DrawRenderersCustomPass.depthShaderTags = new ShaderTagId[]
			{
				HDShaderPassNames.s_DepthForwardOnlyName,
				HDShaderPassNames.s_DepthOnlyName,
				HDShaderPassNames.s_EmptyName
			};
		}

		// Token: 0x06000D2C RID: 3372 RVA: 0x0006B9D0 File Offset: 0x00069BD0
		protected override void AggregateCullingParameters(ref ScriptableCullingParameters cullingParameters, HDCamera hdCamera)
		{
			cullingParameters.cullingMask |= (uint)this.layerMask;
		}

		// Token: 0x06000D2D RID: 3373 RVA: 0x0006B9EA File Offset: 0x00069BEA
		private ShaderTagId[] GetShaderTagIds()
		{
			if (this.shaderPass == DrawRenderersCustomPass.ShaderPass.DepthPrepass)
			{
				return DrawRenderersCustomPass.depthShaderTags;
			}
			return DrawRenderersCustomPass.forwardShaderTags;
		}

		// Token: 0x06000D2E RID: 3374 RVA: 0x0006BA00 File Offset: 0x00069C00
		protected override void Execute(CustomPassContext ctx)
		{
			ShaderTagId[] shaderTagIds = this.GetShaderTagIds();
			if (this.overrideMaterial != null)
			{
				shaderTagIds[shaderTagIds.Length - 1] = new ShaderTagId(this.overrideMaterialPassName);
				this.overrideMaterial.SetFloat(this.fadeValueId, base.fadeValue);
			}
			if (shaderTagIds.Length == 0)
			{
				Debug.LogWarning("Attempt to call DrawRenderers with an empty shader passes. Skipping the call to avoid errors");
				return;
			}
			RenderStateMask renderStateMask = this.overrideDepthState ? RenderStateMask.Depth : RenderStateMask.Nothing;
			renderStateMask |= ((this.overrideDepthState && !this.depthWrite) ? RenderStateMask.Stencil : RenderStateMask.Nothing);
			if (this.overrideStencil)
			{
				renderStateMask |= RenderStateMask.Stencil;
			}
			RenderStateBlock value = new RenderStateBlock(renderStateMask)
			{
				depthState = new DepthState(this.depthWrite, this.depthCompareFunction),
				stencilState = new StencilState(this.overrideStencil, (byte)this.stencilReadMask, (byte)this.stencilWriteMask, this.stencilCompareFunction, this.stencilPassOperation, this.stencilFailOperation, this.stencilDepthFailOperation),
				stencilReference = (this.overrideStencil ? this.stencilReferenceValue : 0)
			};
			PerObjectData rendererConfiguration = HDUtils.GetRendererConfiguration(ctx.hdCamera.frameSettings.IsEnabled(FrameSettingsField.ProbeVolume), ctx.hdCamera.frameSettings.IsEnabled(FrameSettingsField.Shadowmask));
			Material material = (this.overrideShader != null) ? new Material(this.overrideShader) : null;
			RendererListDesc desc = new RendererListDesc(shaderTagIds, ctx.cullingResults, ctx.hdCamera.camera)
			{
				rendererConfiguration = rendererConfiguration,
				renderQueueRange = base.GetRenderQueueRange(this.renderQueueType),
				sortingCriteria = this.sortingCriteria,
				excludeObjectMotionVectors = false,
				overrideShader = ((this.overrideMode == DrawRenderersCustomPass.OverrideMaterialMode.Shader) ? this.overrideShader : null),
				overrideMaterial = ((this.overrideMode == DrawRenderersCustomPass.OverrideMaterialMode.Material) ? this.overrideMaterial : null),
				overrideMaterialPassIndex = ((this.overrideMaterial != null) ? this.overrideMaterial.FindPass(this.overrideMaterialPassName) : 0),
				overrideShaderPassIndex = ((this.overrideShader != null) ? material.FindPass(this.overrideShaderPassName) : 0),
				stateBlock = new RenderStateBlock?(value),
				layerMask = this.layerMask
			};
			Object.DestroyImmediate(material);
			RendererList rendererList = ctx.renderContext.CreateRendererList(desc);
			bool opaque = this.renderQueueType == CustomPass.RenderQueueType.AllOpaque || this.renderQueueType == CustomPass.RenderQueueType.OpaqueAlphaTest || this.renderQueueType == CustomPass.RenderQueueType.OpaqueNoAlphaTest;
			HDRenderPipeline.RenderForwardRendererList(ctx.hdCamera.frameSettings, rendererList, opaque, ctx.renderContext, ctx.cmd);
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x0006BC97 File Offset: 0x00069E97
		public override IEnumerable<Material> RegisterMaterialForInspector()
		{
			yield return this.overrideMaterial;
			yield break;
		}

		// Token: 0x04001418 RID: 5144
		[SerializeField]
		internal bool filterFoldout;

		// Token: 0x04001419 RID: 5145
		[SerializeField]
		internal bool rendererFoldout;

		// Token: 0x0400141A RID: 5146
		public CustomPass.RenderQueueType renderQueueType = CustomPass.RenderQueueType.AllOpaque;

		// Token: 0x0400141B RID: 5147
		public LayerMask layerMask = 1;

		// Token: 0x0400141C RID: 5148
		public SortingCriteria sortingCriteria = SortingCriteria.SortingLayer | SortingCriteria.RenderQueue | SortingCriteria.OptimizeStateChanges | SortingCriteria.CanvasOrder;

		// Token: 0x0400141D RID: 5149
		public DrawRenderersCustomPass.OverrideMaterialMode overrideMode = DrawRenderersCustomPass.OverrideMaterialMode.Material;

		// Token: 0x0400141E RID: 5150
		public Material overrideMaterial;

		// Token: 0x0400141F RID: 5151
		[SerializeField]
		private int overrideMaterialPassIndex;

		// Token: 0x04001420 RID: 5152
		public string overrideMaterialPassName = "Forward";

		// Token: 0x04001421 RID: 5153
		public Shader overrideShader;

		// Token: 0x04001422 RID: 5154
		[SerializeField]
		private int overrideShaderPassIndex;

		// Token: 0x04001423 RID: 5155
		public string overrideShaderPassName = "Forward";

		// Token: 0x04001424 RID: 5156
		public bool overrideDepthState;

		// Token: 0x04001425 RID: 5157
		public CompareFunction depthCompareFunction = CompareFunction.LessEqual;

		// Token: 0x04001426 RID: 5158
		public bool depthWrite = true;

		// Token: 0x04001427 RID: 5159
		public bool overrideStencil;

		// Token: 0x04001428 RID: 5160
		public int stencilReferenceValue = 64;

		// Token: 0x04001429 RID: 5161
		public int stencilWriteMask = 192;

		// Token: 0x0400142A RID: 5162
		public int stencilReadMask = 192;

		// Token: 0x0400142B RID: 5163
		public CompareFunction stencilCompareFunction = CompareFunction.Always;

		// Token: 0x0400142C RID: 5164
		public StencilOp stencilPassOperation;

		// Token: 0x0400142D RID: 5165
		public StencilOp stencilFailOperation;

		// Token: 0x0400142E RID: 5166
		public StencilOp stencilDepthFailOperation;

		// Token: 0x0400142F RID: 5167
		public DrawRenderersCustomPass.ShaderPass shaderPass;

		// Token: 0x04001430 RID: 5168
		private int fadeValueId;

		// Token: 0x04001431 RID: 5169
		private static ShaderTagId[] forwardShaderTags;

		// Token: 0x04001432 RID: 5170
		private static ShaderTagId[] depthShaderTags;

		// Token: 0x04001433 RID: 5171
		private ShaderTagId[] cachedShaderTagIDs;

		// Token: 0x020003F5 RID: 1013
		public enum ShaderPass
		{
			// Token: 0x04002895 RID: 10389
			DepthPrepass = 1,
			// Token: 0x04002896 RID: 10390
			Forward = 0
		}

		// Token: 0x020003F6 RID: 1014
		public enum OverrideMaterialMode
		{
			// Token: 0x04002898 RID: 10392
			None,
			// Token: 0x04002899 RID: 10393
			Material,
			// Token: 0x0400289A RID: 10394
			Shader
		}
	}
}
