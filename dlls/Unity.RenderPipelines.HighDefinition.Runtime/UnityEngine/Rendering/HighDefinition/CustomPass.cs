using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.RenderGraphModule;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200019C RID: 412
	[Serializable]
	public abstract class CustomPass : IVersionable<CustomPass.Version>
	{
		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000CB9 RID: 3257 RVA: 0x00068F05 File Offset: 0x00067105
		// (set) Token: 0x06000CBA RID: 3258 RVA: 0x00068F0D File Offset: 0x0006710D
		public string name
		{
			get
			{
				return this.m_Name;
			}
			set
			{
				this.m_Name = value;
				this.m_ProfilingSampler = new ProfilingSampler(this.m_Name);
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000CBB RID: 3259 RVA: 0x00068F27 File Offset: 0x00067127
		internal ProfilingSampler profilingSampler
		{
			get
			{
				if (this.m_ProfilingSampler == null)
				{
					this.m_ProfilingSampler = new ProfilingSampler(this.m_Name ?? "Custom Pass");
				}
				return this.m_ProfilingSampler;
			}
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x00068F51 File Offset: 0x00067151
		private void Awake()
		{
			if (this.m_MSAAResolveMPB == null)
			{
				this.m_MSAAResolveMPB = new MaterialPropertyBlock();
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000CBD RID: 3261 RVA: 0x00068F66 File Offset: 0x00067166
		protected float fadeValue
		{
			get
			{
				return this.owner.fadeValue;
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000CBE RID: 3262 RVA: 0x00068F73 File Offset: 0x00067173
		protected CustomPassInjectionPoint injectionPoint
		{
			get
			{
				return this.owner.injectionPoint;
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000CBF RID: 3263 RVA: 0x00068F80 File Offset: 0x00067180
		protected virtual bool executeInSceneView
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000CC0 RID: 3264 RVA: 0x00068F83 File Offset: 0x00067183
		// (set) Token: 0x06000CC1 RID: 3265 RVA: 0x00068F8B File Offset: 0x0006718B
		CustomPass.Version IVersionable<CustomPass.Version>.version
		{
			get
			{
				return this.m_Version;
			}
			set
			{
				this.m_Version = value;
			}
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x00068F94 File Offset: 0x00067194
		internal bool WillBeExecuted(HDCamera hdCamera)
		{
			return this.enabled && (hdCamera.camera.cameraType != CameraType.SceneView || this.executeInSceneView);
		}

		// Token: 0x06000CC3 RID: 3267 RVA: 0x00068FBC File Offset: 0x000671BC
		private CustomPass.RenderTargets ReadRenderTargets(in RenderGraphBuilder builder, in CustomPass.RenderTargets targets)
		{
			CustomPass.RenderTargets result = default(CustomPass.RenderTargets);
			result.customColorBuffer = targets.customColorBuffer;
			result.customDepthBuffer = targets.customDepthBuffer;
			TextureHandle textureHandle = targets.colorBufferRG;
			if (textureHandle.IsValid())
			{
				RenderGraphBuilder renderGraphBuilder = builder;
				result.colorBufferRG = renderGraphBuilder.ReadWriteTexture(targets.colorBufferRG);
			}
			textureHandle = targets.nonMSAAColorBufferRG;
			if (textureHandle.IsValid())
			{
				RenderGraphBuilder renderGraphBuilder = builder;
				result.nonMSAAColorBufferRG = renderGraphBuilder.ReadWriteTexture(targets.nonMSAAColorBufferRG);
			}
			textureHandle = targets.depthBufferRG;
			if (textureHandle.IsValid())
			{
				RenderGraphBuilder renderGraphBuilder = builder;
				result.depthBufferRG = renderGraphBuilder.ReadWriteTexture(targets.depthBufferRG);
			}
			textureHandle = targets.normalBufferRG;
			if (textureHandle.IsValid())
			{
				RenderGraphBuilder renderGraphBuilder = builder;
				result.normalBufferRG = renderGraphBuilder.ReadWriteTexture(targets.normalBufferRG);
			}
			textureHandle = targets.motionVectorBufferRG;
			if (textureHandle.IsValid())
			{
				RenderGraphBuilder renderGraphBuilder = builder;
				result.motionVectorBufferRG = renderGraphBuilder.ReadWriteTexture(targets.motionVectorBufferRG);
			}
			return result;
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x000690C4 File Offset: 0x000672C4
		internal virtual void ExecuteInternal(RenderGraph renderGraph, HDCamera hdCamera, CullingResults cullingResult, CullingResults cameraCullingResult, in CustomPass.RenderTargets targets, CustomPassVolume owner)
		{
			this.owner = owner;
			this.currentRenderTarget = targets;
			this.currentHDCamera = hdCamera;
			CustomPass.ExecutePassData executePassData;
			RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<CustomPass.ExecutePassData>(this.name, out executePassData, this.profilingSampler);
			try
			{
				executePassData.customPass = this;
				executePassData.cullingResult = cullingResult;
				executePassData.cameraCullingResult = cameraCullingResult;
				executePassData.hdCamera = hdCamera;
				executePassData.shaderVariablesGlobal = HDRenderPipeline.currentPipeline.GetShaderVariablesGlobalCB();
				this.currentRenderTarget = this.ReadRenderTargets(renderGraphBuilder, targets);
				renderGraphBuilder.SetRenderFunc<CustomPass.ExecutePassData>(delegate(CustomPass.ExecutePassData data, RenderGraphContext ctx)
				{
					CustomPass customPass = data.customPass;
					ctx.cmd.SetGlobalFloat(HDShaderIDs._CustomPassInjectionPoint, (float)customPass.injectionPoint);
					if (customPass.currentRenderTarget.colorBufferRG.IsValid() && customPass.injectionPoint == CustomPassInjectionPoint.AfterPostProcess)
					{
						ctx.cmd.SetGlobalTexture(HDShaderIDs._AfterPostProcessColorBuffer, customPass.currentRenderTarget.colorBufferRG);
					}
					if (customPass.currentRenderTarget.motionVectorBufferRG.IsValid() && customPass.injectionPoint != CustomPassInjectionPoint.BeforeRendering)
					{
						ctx.cmd.SetGlobalTexture(HDShaderIDs._CameraMotionVectorsTexture, customPass.currentRenderTarget.motionVectorBufferRG);
					}
					if (customPass.currentRenderTarget.normalBufferRG.IsValid() && customPass.injectionPoint != CustomPassInjectionPoint.AfterPostProcess)
					{
						ctx.cmd.SetGlobalTexture(HDShaderIDs._NormalBufferTexture, customPass.currentRenderTarget.normalBufferRG);
					}
					if (customPass.currentRenderTarget.customColorBuffer.IsValueCreated)
					{
						ctx.cmd.SetGlobalTexture(HDShaderIDs._CustomColorTexture, customPass.currentRenderTarget.customColorBuffer.Value);
					}
					if (customPass.currentRenderTarget.customDepthBuffer.IsValueCreated)
					{
						ctx.cmd.SetGlobalTexture(HDShaderIDs._CustomDepthTexture, customPass.currentRenderTarget.customDepthBuffer.Value);
					}
					if (!customPass.isSetup)
					{
						customPass.Setup(ctx.renderContext, ctx.cmd);
						customPass.isSetup = true;
					}
					customPass.SetCustomPassTarget(ctx.cmd);
					TextureHandle colorBufferRG = customPass.currentRenderTarget.colorBufferRG;
					CustomPassContext ctx2 = new CustomPassContext(ctx.renderContext, ctx.cmd, data.hdCamera, data.cullingResult, data.cameraCullingResult, colorBufferRG, customPass.currentRenderTarget.depthBufferRG, customPass.currentRenderTarget.normalBufferRG, customPass.currentRenderTarget.motionVectorBufferRG, customPass.currentRenderTarget.customColorBuffer, customPass.currentRenderTarget.customDepthBuffer, ctx.renderGraphPool.GetTempMaterialPropertyBlock(), customPass.injectionPoint, data.shaderVariablesGlobal);
					customPass.isExecuting = true;
					customPass.Execute(ctx2);
					customPass.isExecuting = false;
					if (customPass.targetDepthBuffer != CustomPass.TargetBuffer.Camera)
					{
						CoreUtils.SetRenderTarget(ctx.cmd, colorBufferRG, ClearFlag.None, 0, CubemapFace.Unknown, -1);
					}
				});
			}
			finally
			{
				((IDisposable)renderGraphBuilder).Dispose();
			}
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x00069188 File Offset: 0x00067388
		internal void InternalAggregateCullingParameters(ref ScriptableCullingParameters cullingParameters, HDCamera hdCamera)
		{
			this.AggregateCullingParameters(ref cullingParameters, hdCamera);
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x00069194 File Offset: 0x00067394
		~CustomPass()
		{
			this.CleanupPassInternal();
		}

		// Token: 0x06000CC7 RID: 3271 RVA: 0x000691C0 File Offset: 0x000673C0
		internal void CleanupPassInternal()
		{
			if (this.isSetup)
			{
				this.Cleanup();
				this.isSetup = false;
			}
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x000691D7 File Offset: 0x000673D7
		private bool IsMSAAEnabled(HDCamera hdCamera)
		{
			return hdCamera.msaaEnabled & (this.injectionPoint == CustomPassInjectionPoint.BeforePreRefraction || this.injectionPoint == CustomPassInjectionPoint.BeforeTransparent || this.injectionPoint == CustomPassInjectionPoint.AfterOpaqueDepthAndNormal);
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x00069200 File Offset: 0x00067400
		private void SetCustomPassTarget(CommandBuffer cmd)
		{
			if (this.targetColorBuffer == CustomPass.TargetBuffer.None && this.targetDepthBuffer == CustomPass.TargetBuffer.None)
			{
				return;
			}
			RTHandle rthandle = (this.targetColorBuffer == CustomPass.TargetBuffer.Custom) ? this.currentRenderTarget.customColorBuffer.Value : this.currentRenderTarget.colorBufferRG;
			RTHandle rthandle2 = (this.targetDepthBuffer == CustomPass.TargetBuffer.Custom) ? this.currentRenderTarget.customDepthBuffer.Value : this.currentRenderTarget.depthBufferRG;
			if (this.targetColorBuffer == CustomPass.TargetBuffer.None && this.targetDepthBuffer != CustomPass.TargetBuffer.None)
			{
				CoreUtils.SetRenderTarget(cmd, rthandle2, this.clearFlags, 0, CubemapFace.Unknown, -1);
				return;
			}
			if (this.targetColorBuffer != CustomPass.TargetBuffer.None && this.targetDepthBuffer == CustomPass.TargetBuffer.None)
			{
				CoreUtils.SetRenderTarget(cmd, rthandle, this.clearFlags, 0, CubemapFace.Unknown, -1);
				return;
			}
			if (rthandle.isMSAAEnabled != rthandle2.isMSAAEnabled)
			{
				Debug.LogError("Color and Depth buffer MSAA flags doesn't match, no rendering will occur.");
			}
			CoreUtils.SetRenderTarget(cmd, rthandle, rthandle2, this.clearFlags, 0, CubemapFace.Unknown, -1);
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x000692E7 File Offset: 0x000674E7
		protected virtual void AggregateCullingParameters(ref ScriptableCullingParameters cullingParameters, HDCamera hdCamera)
		{
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x000692E9 File Offset: 0x000674E9
		[Obsolete("This Execute signature is obsolete and will be removed in the future. Please use Execute(CustomPassContext) instead")]
		protected virtual void Execute(ScriptableRenderContext renderContext, CommandBuffer cmd, HDCamera hdCamera, CullingResults cullingResult)
		{
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x000692EB File Offset: 0x000674EB
		protected virtual void Execute(CustomPassContext ctx)
		{
			this.Execute(ctx.renderContext, ctx.cmd, ctx.hdCamera, ctx.cullingResults);
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x0006930B File Offset: 0x0006750B
		protected virtual void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
		{
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x0006930D File Offset: 0x0006750D
		protected virtual void Cleanup()
		{
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x00069310 File Offset: 0x00067510
		[Obsolete("Use directly CoreUtils.SetRenderTarget with the render target of your choice.")]
		protected void SetCameraRenderTarget(CommandBuffer cmd, bool bindDepth = true, ClearFlag clearFlags = ClearFlag.None)
		{
			if (!this.isExecuting)
			{
				throw new Exception("SetCameraRenderTarget can only be called inside the CustomPass.Execute function");
			}
			RTHandle rthandle = this.currentRenderTarget.colorBufferRG;
			RTHandle depthBuffer = this.currentRenderTarget.depthBufferRG;
			if (bindDepth)
			{
				CoreUtils.SetRenderTarget(cmd, rthandle, depthBuffer, clearFlags, 0, CubemapFace.Unknown, -1);
				return;
			}
			CoreUtils.SetRenderTarget(cmd, rthandle, clearFlags, 0, CubemapFace.Unknown, -1);
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x00069370 File Offset: 0x00067570
		[Obsolete("Use directly CoreUtils.SetRenderTarget with the render target of your choice.")]
		protected void SetCustomRenderTarget(CommandBuffer cmd, bool bindDepth = true, ClearFlag clearFlags = ClearFlag.None)
		{
			if (!this.isExecuting)
			{
				throw new Exception("SetCameraRenderTarget can only be called inside the CustomPass.Execute function");
			}
			if (bindDepth)
			{
				CoreUtils.SetRenderTarget(cmd, this.currentRenderTarget.customColorBuffer.Value, this.currentRenderTarget.customDepthBuffer.Value, clearFlags, 0, CubemapFace.Unknown, -1);
				return;
			}
			CoreUtils.SetRenderTarget(cmd, this.currentRenderTarget.customColorBuffer.Value, clearFlags, 0, CubemapFace.Unknown, -1);
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x000693D8 File Offset: 0x000675D8
		protected void SetRenderTargetAuto(CommandBuffer cmd)
		{
			this.SetCustomPassTarget(cmd);
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x000693E4 File Offset: 0x000675E4
		protected void ResolveMSAAColorBuffer(CommandBuffer cmd, HDCamera hdCamera)
		{
			if (!this.isExecuting)
			{
				throw new Exception("ResolveMSAAColorBuffer can only be called inside the CustomPass.Execute function");
			}
			if (this.IsMSAAEnabled(hdCamera))
			{
				CoreUtils.SetRenderTarget(cmd, this.currentRenderTarget.nonMSAAColorBufferRG, ClearFlag.None, 0, CubemapFace.Unknown, -1);
				this.m_MSAAResolveMPB.SetTexture(HDShaderIDs._ColorTextureMS, this.currentRenderTarget.colorBufferRG);
				cmd.DrawProcedural(Matrix4x4.identity, HDRenderPipeline.currentPipeline.GetMSAAColorResolveMaterial(), HDRenderPipeline.SampleCountToPassIndex(hdCamera.msaaSamples), MeshTopology.Triangles, 3, 1, this.m_MSAAResolveMPB);
			}
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x00069470 File Offset: 0x00067670
		protected void ResolveMSAAColorBuffer(CustomPassContext ctx)
		{
			this.ResolveMSAAColorBuffer(ctx.cmd, ctx.hdCamera);
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x00069484 File Offset: 0x00067684
		[Obsolete("GetCameraBuffers is obsolete and will be removed in the future. All camera buffers are now avaliable directly in the CustomPassContext in parameter of the Execute function")]
		protected void GetCameraBuffers(out RTHandle colorBuffer, out RTHandle depthBuffer)
		{
			if (!this.isExecuting)
			{
				throw new Exception("GetCameraBuffers can only be called inside the CustomPass.Execute function");
			}
			colorBuffer = this.currentRenderTarget.colorBufferRG;
			depthBuffer = this.currentRenderTarget.depthBufferRG;
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x000694BD File Offset: 0x000676BD
		[Obsolete("GetCustomBuffers is obsolete and will be removed in the future. All custom buffers are now avaliable directly in the CustomPassContext in parameter of the Execute function")]
		protected void GetCustomBuffers(out RTHandle colorBuffer, out RTHandle depthBuffer)
		{
			if (!this.isExecuting)
			{
				throw new Exception("GetCustomBuffers can only be called inside the CustomPass.Execute function");
			}
			colorBuffer = this.currentRenderTarget.customColorBuffer.Value;
			depthBuffer = this.currentRenderTarget.customDepthBuffer.Value;
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x000694F6 File Offset: 0x000676F6
		[Obsolete("GetNormalBuffer is obsolete and will be removed in the future. Normal buffer is now avaliable directly in the CustomPassContext in parameter of the Execute function")]
		protected RTHandle GetNormalBuffer()
		{
			if (!this.isExecuting)
			{
				throw new Exception("GetNormalBuffer can only be called inside the CustomPass.Execute function");
			}
			return this.currentRenderTarget.normalBufferRG;
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x0006951B File Offset: 0x0006771B
		public virtual IEnumerable<Material> RegisterMaterialForInspector()
		{
			yield break;
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x00069524 File Offset: 0x00067724
		protected RenderQueueRange GetRenderQueueRange(CustomPass.RenderQueueType type)
		{
			return CustomPassUtils.GetRenderQueueRangeFromRenderQueueType(type);
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x0006952C File Offset: 0x0006772C
		public static FullScreenCustomPass CreateFullScreenPass(Material fullScreenMaterial, CustomPass.TargetBuffer targetColorBuffer = CustomPass.TargetBuffer.Camera, CustomPass.TargetBuffer targetDepthBuffer = CustomPass.TargetBuffer.Camera)
		{
			return new FullScreenCustomPass
			{
				name = "FullScreen Pass",
				targetColorBuffer = targetColorBuffer,
				targetDepthBuffer = targetDepthBuffer,
				fullscreenPassMaterial = fullScreenMaterial
			};
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x00069554 File Offset: 0x00067754
		public static DrawRenderersCustomPass CreateDrawRenderersPass(CustomPass.RenderQueueType queue, LayerMask mask, Material overrideMaterial, string overrideMaterialPassName = "Forward", SortingCriteria sorting = SortingCriteria.SortingLayer | SortingCriteria.RenderQueue | SortingCriteria.OptimizeStateChanges | SortingCriteria.CanvasOrder, ClearFlag clearFlags = ClearFlag.None, CustomPass.TargetBuffer targetColorBuffer = CustomPass.TargetBuffer.Camera, CustomPass.TargetBuffer targetDepthBuffer = CustomPass.TargetBuffer.Camera)
		{
			return new DrawRenderersCustomPass
			{
				name = "DrawRenderers Pass",
				renderQueueType = queue,
				layerMask = mask,
				overrideMaterial = overrideMaterial,
				overrideMaterialPassName = overrideMaterialPassName,
				sortingCriteria = sorting,
				clearFlags = clearFlags,
				targetColorBuffer = targetColorBuffer,
				targetDepthBuffer = targetDepthBuffer
			};
		}

		// Token: 0x040013C7 RID: 5063
		[SerializeField]
		[FormerlySerializedAs("name")]
		private string m_Name = "Custom Pass";

		// Token: 0x040013C8 RID: 5064
		private ProfilingSampler m_ProfilingSampler;

		// Token: 0x040013C9 RID: 5065
		public bool enabled = true;

		// Token: 0x040013CA RID: 5066
		public CustomPass.TargetBuffer targetColorBuffer;

		// Token: 0x040013CB RID: 5067
		public CustomPass.TargetBuffer targetDepthBuffer;

		// Token: 0x040013CC RID: 5068
		public ClearFlag clearFlags;

		// Token: 0x040013CD RID: 5069
		[SerializeField]
		private bool passFoldout;

		// Token: 0x040013CE RID: 5070
		[NonSerialized]
		private bool isSetup;

		// Token: 0x040013CF RID: 5071
		private bool isExecuting;

		// Token: 0x040013D0 RID: 5072
		private CustomPass.RenderTargets currentRenderTarget;

		// Token: 0x040013D1 RID: 5073
		private CustomPassVolume owner;

		// Token: 0x040013D2 RID: 5074
		private HDCamera currentHDCamera;

		// Token: 0x040013D3 RID: 5075
		private MaterialPropertyBlock m_MSAAResolveMPB;

		// Token: 0x040013D4 RID: 5076
		[SerializeField]
		private CustomPass.Version m_Version = MigrationDescription.LastVersion<CustomPass.Version>();

		// Token: 0x020003DF RID: 991
		public enum TargetBuffer
		{
			// Token: 0x04002835 RID: 10293
			Camera,
			// Token: 0x04002836 RID: 10294
			Custom,
			// Token: 0x04002837 RID: 10295
			None
		}

		// Token: 0x020003E0 RID: 992
		public enum RenderQueueType
		{
			// Token: 0x04002839 RID: 10297
			OpaqueNoAlphaTest,
			// Token: 0x0400283A RID: 10298
			OpaqueAlphaTest,
			// Token: 0x0400283B RID: 10299
			AllOpaque,
			// Token: 0x0400283C RID: 10300
			AfterPostProcessOpaque,
			// Token: 0x0400283D RID: 10301
			PreRefraction,
			// Token: 0x0400283E RID: 10302
			Transparent,
			// Token: 0x0400283F RID: 10303
			LowTransparent,
			// Token: 0x04002840 RID: 10304
			AllTransparent,
			// Token: 0x04002841 RID: 10305
			AllTransparentWithLowRes,
			// Token: 0x04002842 RID: 10306
			AfterPostProcessTransparent,
			// Token: 0x04002843 RID: 10307
			Overlay = 11,
			// Token: 0x04002844 RID: 10308
			All = 10
		}

		// Token: 0x020003E1 RID: 993
		internal struct RenderTargets
		{
			// Token: 0x04002845 RID: 10309
			public Lazy<RTHandle> customColorBuffer;

			// Token: 0x04002846 RID: 10310
			public Lazy<RTHandle> customDepthBuffer;

			// Token: 0x04002847 RID: 10311
			public TextureHandle colorBufferRG;

			// Token: 0x04002848 RID: 10312
			public TextureHandle nonMSAAColorBufferRG;

			// Token: 0x04002849 RID: 10313
			public TextureHandle depthBufferRG;

			// Token: 0x0400284A RID: 10314
			public TextureHandle normalBufferRG;

			// Token: 0x0400284B RID: 10315
			public TextureHandle motionVectorBufferRG;
		}

		// Token: 0x020003E2 RID: 994
		private enum Version
		{
			// Token: 0x0400284D RID: 10317
			Initial
		}

		// Token: 0x020003E3 RID: 995
		private class ExecutePassData
		{
			// Token: 0x0400284E RID: 10318
			public CustomPass customPass;

			// Token: 0x0400284F RID: 10319
			public CullingResults cullingResult;

			// Token: 0x04002850 RID: 10320
			public CullingResults cameraCullingResult;

			// Token: 0x04002851 RID: 10321
			public HDCamera hdCamera;

			// Token: 0x04002852 RID: 10322
			public ShaderVariablesGlobal shaderVariablesGlobal;
		}
	}
}
