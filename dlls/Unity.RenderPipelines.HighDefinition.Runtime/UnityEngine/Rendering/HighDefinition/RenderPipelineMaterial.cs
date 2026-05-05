using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000110 RID: 272
	internal class RenderPipelineMaterial : Object
	{
		// Token: 0x06000A65 RID: 2661 RVA: 0x00058F62 File Offset: 0x00057162
		public virtual bool IsDefferedMaterial()
		{
			return false;
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x00058F65 File Offset: 0x00057165
		public virtual void Build(HDRenderPipelineAsset hdAsset, HDRenderPipelineRuntimeResources defaultResources)
		{
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x00058F67 File Offset: 0x00057167
		public virtual void Cleanup()
		{
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x00058F69 File Offset: 0x00057169
		public virtual void RenderInit(CommandBuffer cmd)
		{
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x00058F6B File Offset: 0x0005716B
		public virtual void Bind(CommandBuffer cmd)
		{
		}
	}
}
