using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000108 RID: 264
	internal abstract class IBLFilterBSDF
	{
		// Token: 0x06000A36 RID: 2614
		public abstract bool IsInitialized();

		// Token: 0x06000A37 RID: 2615
		public abstract void Initialize(CommandBuffer cmd);

		// Token: 0x06000A38 RID: 2616
		public abstract void Cleanup();

		// Token: 0x06000A39 RID: 2617
		public abstract void FilterCubemap(CommandBuffer cmd, Texture source, RenderTexture target);

		// Token: 0x06000A3A RID: 2618
		public abstract void FilterPlanarTexture(CommandBuffer cmd, RenderTexture source, ref IBLFilterBSDF.PlanarTextureFilteringParameters planarTextureFilteringParameters, RenderTexture target);

		// Token: 0x06000A3B RID: 2619
		public abstract void FilterCubemapMIS(CommandBuffer cmd, Texture source, RenderTexture target, RenderTexture conditionalCdf, RenderTexture marginalRowCdf);

		// Token: 0x04000B00 RID: 2816
		protected Material m_convolveMaterial;

		// Token: 0x04000B01 RID: 2817
		protected Matrix4x4[] m_faceWorldToViewMatrixMatrices = new Matrix4x4[6];

		// Token: 0x04000B02 RID: 2818
		protected HDRenderPipelineRuntimeResources m_RenderPipelineResources;

		// Token: 0x04000B03 RID: 2819
		protected MipGenerator m_MipGenerator;

		// Token: 0x0200038F RID: 911
		internal struct PlanarTextureFilteringParameters
		{
			// Token: 0x04002509 RID: 9481
			public bool smoothPlanarReflection;

			// Token: 0x0400250A RID: 9482
			public RenderTexture captureCameraDepthBuffer;

			// Token: 0x0400250B RID: 9483
			public Matrix4x4 captureCameraIVP;

			// Token: 0x0400250C RID: 9484
			public Matrix4x4 captureCameraVP_NonOblique;

			// Token: 0x0400250D RID: 9485
			public Matrix4x4 captureCameraIVP_NonOblique;

			// Token: 0x0400250E RID: 9486
			public Vector3 captureCameraPosition;

			// Token: 0x0400250F RID: 9487
			public Vector4 captureCameraScreenSize;

			// Token: 0x04002510 RID: 9488
			public Vector3 probePosition;

			// Token: 0x04002511 RID: 9489
			public Vector3 probeNormal;

			// Token: 0x04002512 RID: 9490
			public float captureFOV;

			// Token: 0x04002513 RID: 9491
			public float captureNearPlane;

			// Token: 0x04002514 RID: 9492
			public float captureFarPlane;
		}
	}
}
