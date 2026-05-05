using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200019B RID: 411
	public struct RenderOutputProperties
	{
		// Token: 0x06000CB7 RID: 3255 RVA: 0x00068EC0 File Offset: 0x000670C0
		public RenderOutputProperties(Vector2Int outputSize, Matrix4x4 cameraToWorldMatrixRhs, Matrix4x4 projectionMatrix)
		{
			this.outputSize = outputSize;
			this.cameraToWorldMatrixRHS = cameraToWorldMatrixRhs;
			this.projectionMatrix = projectionMatrix;
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x00068ED7 File Offset: 0x000670D7
		internal static RenderOutputProperties From(HDCamera hdCamera)
		{
			return new RenderOutputProperties(new Vector2Int(hdCamera.actualWidth, hdCamera.actualHeight), hdCamera.camera.cameraToWorldMatrix, hdCamera.mainViewConstants.projMatrix);
		}

		// Token: 0x040013C4 RID: 5060
		public readonly Vector2Int outputSize;

		// Token: 0x040013C5 RID: 5061
		public readonly Matrix4x4 cameraToWorldMatrixRHS;

		// Token: 0x040013C6 RID: 5062
		public readonly Matrix4x4 projectionMatrix;
	}
}
