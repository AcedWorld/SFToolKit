using System;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000160 RID: 352
	internal struct XRSinglePassScope : IDisposable
	{
		// Token: 0x06000BD4 RID: 3028 RVA: 0x0005FE6C File Offset: 0x0005E06C
		public XRSinglePassScope(RenderGraph renderGraph, HDCamera hdCamera)
		{
			this.m_RenderGraph = renderGraph;
			this.m_HDCamera = hdCamera;
			this.m_Disposed = false;
			HDRenderPipeline.StartXRSinglePass(renderGraph, hdCamera);
		}

		// Token: 0x06000BD5 RID: 3029 RVA: 0x0005FE8A File Offset: 0x0005E08A
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x0005FE93 File Offset: 0x0005E093
		private void Dispose(bool disposing)
		{
			if (this.m_Disposed)
			{
				return;
			}
			if (disposing)
			{
				HDRenderPipeline.StopXRSinglePass(this.m_RenderGraph, this.m_HDCamera);
			}
			this.m_Disposed = true;
		}

		// Token: 0x04000E07 RID: 3591
		private readonly RenderGraph m_RenderGraph;

		// Token: 0x04000E08 RID: 3592
		private readonly HDCamera m_HDCamera;

		// Token: 0x04000E09 RID: 3593
		private bool m_Disposed;
	}
}
