using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
	// Token: 0x02000464 RID: 1124
	public abstract class RenderPipeline
	{
		// Token: 0x060025B3 RID: 9651
		protected abstract void Render(ScriptableRenderContext context, Camera[] cameras);

		// Token: 0x060025B4 RID: 9652 RVA: 0x00002669 File Offset: 0x00000869
		protected virtual void ProcessRenderRequests<RequestData>(ScriptableRenderContext context, Camera camera, RequestData renderRequest)
		{
		}

		// Token: 0x060025B5 RID: 9653 RVA: 0x0004094C File Offset: 0x0003EB4C
		protected internal virtual bool IsRenderRequestSupported<RequestData>(Camera camera, RequestData data)
		{
			return false;
		}

		// Token: 0x060025B6 RID: 9654 RVA: 0x0004095F File Offset: 0x0003EB5F
		protected static void BeginFrameRendering(ScriptableRenderContext context, Camera[] cameras)
		{
			RenderPipelineManager.BeginContextRendering(context, new List<Camera>(cameras));
		}

		// Token: 0x060025B7 RID: 9655 RVA: 0x0004096F File Offset: 0x0003EB6F
		protected static void BeginContextRendering(ScriptableRenderContext context, List<Camera> cameras)
		{
			RenderPipelineManager.BeginContextRendering(context, cameras);
		}

		// Token: 0x060025B8 RID: 9656 RVA: 0x0004097A File Offset: 0x0003EB7A
		protected static void BeginCameraRendering(ScriptableRenderContext context, Camera camera)
		{
			RenderPipelineManager.BeginCameraRendering(context, camera);
		}

		// Token: 0x060025B9 RID: 9657 RVA: 0x00040985 File Offset: 0x0003EB85
		protected static void EndContextRendering(ScriptableRenderContext context, List<Camera> cameras)
		{
			RenderPipelineManager.EndContextRendering(context, cameras);
		}

		// Token: 0x060025BA RID: 9658 RVA: 0x00040990 File Offset: 0x0003EB90
		protected static void EndFrameRendering(ScriptableRenderContext context, Camera[] cameras)
		{
			RenderPipelineManager.EndContextRendering(context, new List<Camera>(cameras));
		}

		// Token: 0x060025BB RID: 9659 RVA: 0x000409A0 File Offset: 0x0003EBA0
		protected static void EndCameraRendering(ScriptableRenderContext context, Camera camera)
		{
			RenderPipelineManager.EndCameraRendering(context, camera);
		}

		// Token: 0x060025BC RID: 9660 RVA: 0x000409AB File Offset: 0x0003EBAB
		protected virtual void Render(ScriptableRenderContext context, List<Camera> cameras)
		{
			this.Render(context, cameras.ToArray());
		}

		// Token: 0x060025BD RID: 9661 RVA: 0x000409BC File Offset: 0x0003EBBC
		internal void InternalRender(ScriptableRenderContext context, List<Camera> cameras)
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				throw new ObjectDisposedException(string.Format("{0} has been disposed. Do not call Render on disposed a RenderPipeline.", this));
			}
			this.Render(context, cameras);
		}

		// Token: 0x060025BE RID: 9662 RVA: 0x000409F0 File Offset: 0x0003EBF0
		internal void InternalProcessRenderRequests<RequestData>(ScriptableRenderContext context, Camera camera, RequestData renderRequest)
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				throw new ObjectDisposedException(string.Format("{0} has been disposed. Do not call Render on disposed a RenderPipeline.", this));
			}
			this.ProcessRenderRequests<RequestData>(context, camera, renderRequest);
		}

		// Token: 0x060025BF RID: 9663 RVA: 0x00040A24 File Offset: 0x0003EC24
		public static bool SupportsRenderRequest<RequestData>(Camera camera, RequestData data)
		{
			bool result = false;
			bool flag = GraphicsSettings.currentRenderPipeline != null;
			if (flag)
			{
				bool flag2 = RenderPipelineManager.currentPipeline == null;
				if (flag2)
				{
					RenderPipelineManager.PrepareRenderPipeline(GraphicsSettings.currentRenderPipeline);
				}
				result = RenderPipelineManager.currentPipeline.IsRenderRequestSupported<RequestData>(camera, data);
			}
			return result;
		}

		// Token: 0x060025C0 RID: 9664 RVA: 0x00040A70 File Offset: 0x0003EC70
		public static void SubmitRenderRequest<RequestData>(Camera camera, RequestData data)
		{
			camera.SubmitRenderRequest<RequestData>(data);
		}

		// Token: 0x170006E1 RID: 1761
		// (get) Token: 0x060025C1 RID: 9665 RVA: 0x00040A7B File Offset: 0x0003EC7B
		// (set) Token: 0x060025C2 RID: 9666 RVA: 0x00040A83 File Offset: 0x0003EC83
		public bool disposed { get; private set; }

		// Token: 0x060025C3 RID: 9667 RVA: 0x00040A8C File Offset: 0x0003EC8C
		internal void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
			this.disposed = true;
		}

		// Token: 0x060025C4 RID: 9668 RVA: 0x00002669 File Offset: 0x00000869
		protected virtual void Dispose(bool disposing)
		{
		}

		// Token: 0x170006E2 RID: 1762
		// (get) Token: 0x060025C5 RID: 9669 RVA: 0x00040AA8 File Offset: 0x0003ECA8
		public virtual RenderPipelineGlobalSettings defaultSettings
		{
			get
			{
				return null;
			}
		}

		// Token: 0x02000465 RID: 1125
		public class StandardRequest
		{
			// Token: 0x04000E5B RID: 3675
			public RenderTexture destination = null;

			// Token: 0x04000E5C RID: 3676
			public int mipLevel = 0;

			// Token: 0x04000E5D RID: 3677
			public CubemapFace face = CubemapFace.Unknown;

			// Token: 0x04000E5E RID: 3678
			public int slice = 0;
		}
	}
}
