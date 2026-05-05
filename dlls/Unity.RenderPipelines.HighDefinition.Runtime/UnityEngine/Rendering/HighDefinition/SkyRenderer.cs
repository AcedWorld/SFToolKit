using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001ED RID: 493
	public abstract class SkyRenderer
	{
		// Token: 0x06000EFB RID: 3835
		public abstract void Build();

		// Token: 0x06000EFC RID: 3836
		public abstract void Cleanup();

		// Token: 0x06000EFD RID: 3837 RVA: 0x00076D37 File Offset: 0x00074F37
		protected virtual bool Update(BuiltinSkyParameters builtinParams)
		{
			return false;
		}

		// Token: 0x06000EFE RID: 3838 RVA: 0x00076D3A File Offset: 0x00074F3A
		[Obsolete("Please override PreRenderSky(BuiltinSkyParameters) instead.")]
		public virtual void PreRenderSky(BuiltinSkyParameters builtinParams, bool renderForCubemap, bool renderSunDisk)
		{
			this.PreRenderSky(builtinParams);
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x00076D43 File Offset: 0x00074F43
		public virtual void PreRenderSky(BuiltinSkyParameters builtinParams)
		{
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x00076D45 File Offset: 0x00074F45
		[Obsolete("Please implement RequiresPreRender instead")]
		public virtual bool RequiresPreRenderSky(BuiltinSkyParameters builtinParams)
		{
			return false;
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x00076D48 File Offset: 0x00074F48
		public virtual bool RequiresPreRender(SkySettings skySettings)
		{
			return false;
		}

		// Token: 0x06000F02 RID: 3842
		public abstract void RenderSky(BuiltinSkyParameters builtinParams, bool renderForCubemap, bool renderSunDisk);

		// Token: 0x06000F03 RID: 3843 RVA: 0x00076D4B File Offset: 0x00074F4B
		protected static float GetSkyIntensity(SkySettings skySettings, DebugDisplaySettings debugSettings)
		{
			return skySettings.GetIntensityFromSettings();
		}

		// Token: 0x06000F04 RID: 3844 RVA: 0x00076D53 File Offset: 0x00074F53
		public virtual void SetGlobalSkyData(CommandBuffer cmd, BuiltinSkyParameters builtinParams)
		{
		}

		// Token: 0x06000F05 RID: 3845 RVA: 0x00076D58 File Offset: 0x00074F58
		internal bool DoUpdate(BuiltinSkyParameters parameters)
		{
			if (this.m_LastFrameUpdate < parameters.frameIndex)
			{
				CommandBuffer commandBuffer = parameters.commandBuffer;
				CommandBuffer commandBuffer2 = CommandBufferPool.Get("SkyUpdate");
				parameters.commandBuffer = commandBuffer2;
				this.m_LastFrameUpdate = parameters.frameIndex;
				bool result = this.Update(parameters);
				Graphics.ExecuteCommandBuffer(commandBuffer2);
				CommandBufferPool.Release(commandBuffer2);
				parameters.commandBuffer = commandBuffer;
				return result;
			}
			return false;
		}

		// Token: 0x06000F06 RID: 3846 RVA: 0x00076DB4 File Offset: 0x00074FB4
		internal void Reset()
		{
			this.m_LastFrameUpdate = -1;
		}

		// Token: 0x04001793 RID: 6035
		private int m_LastFrameUpdate = -1;

		// Token: 0x04001794 RID: 6036
		public bool SupportDynamicSunLight = true;
	}
}
