using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000166 RID: 358
	internal abstract class HDRenderPipelineResources : RenderPipelineResources
	{
		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000C12 RID: 3090 RVA: 0x00060C9F File Offset: 0x0005EE9F
		protected override string packagePath
		{
			get
			{
				return HDUtils.GetHDRenderPipelinePath();
			}
		}
	}
}
