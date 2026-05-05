using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200019D RID: 413
	public struct CustomPassContext
	{
		// Token: 0x06000CDC RID: 3292 RVA: 0x000695D4 File Offset: 0x000677D4
		internal CustomPassContext(ScriptableRenderContext renderContext, CommandBuffer cmd, HDCamera hdCamera, CullingResults cullingResults, CullingResults cameraCullingResults, RTHandle cameraColorBuffer, RTHandle cameraDepthBuffer, RTHandle cameraNormalBuffer, RTHandle cameraMotionVectorsBuffer, Lazy<RTHandle> customColorBuffer, Lazy<RTHandle> customDepthBuffer, MaterialPropertyBlock propertyBlock, CustomPassInjectionPoint injectionPoint, ShaderVariablesGlobal currentGlobalState)
		{
			this.renderContext = renderContext;
			this.cmd = cmd;
			this.hdCamera = hdCamera;
			this.cullingResults = cullingResults;
			this.cameraCullingResults = cameraCullingResults;
			this.cameraColorBuffer = cameraColorBuffer;
			this.cameraDepthBuffer = cameraDepthBuffer;
			this.customColorBuffer = customColorBuffer;
			this.cameraNormalBuffer = cameraNormalBuffer;
			this.cameraMotionVectorsBuffer = cameraMotionVectorsBuffer;
			this.customDepthBuffer = customDepthBuffer;
			this.propertyBlock = propertyBlock;
			this.injectionPoint = injectionPoint;
			this.currentGlobalState = currentGlobalState;
		}

		// Token: 0x040013D5 RID: 5077
		public readonly ScriptableRenderContext renderContext;

		// Token: 0x040013D6 RID: 5078
		public readonly CommandBuffer cmd;

		// Token: 0x040013D7 RID: 5079
		public readonly HDCamera hdCamera;

		// Token: 0x040013D8 RID: 5080
		public CullingResults cullingResults;

		// Token: 0x040013D9 RID: 5081
		public readonly CullingResults cameraCullingResults;

		// Token: 0x040013DA RID: 5082
		public readonly RTHandle cameraColorBuffer;

		// Token: 0x040013DB RID: 5083
		public readonly RTHandle cameraDepthBuffer;

		// Token: 0x040013DC RID: 5084
		public readonly RTHandle cameraNormalBuffer;

		// Token: 0x040013DD RID: 5085
		public readonly RTHandle cameraMotionVectorsBuffer;

		// Token: 0x040013DE RID: 5086
		public readonly Lazy<RTHandle> customColorBuffer;

		// Token: 0x040013DF RID: 5087
		public readonly Lazy<RTHandle> customDepthBuffer;

		// Token: 0x040013E0 RID: 5088
		public readonly MaterialPropertyBlock propertyBlock;

		// Token: 0x040013E1 RID: 5089
		internal readonly CustomPassInjectionPoint injectionPoint;

		// Token: 0x040013E2 RID: 5090
		internal readonly ShaderVariablesGlobal currentGlobalState;
	}
}
