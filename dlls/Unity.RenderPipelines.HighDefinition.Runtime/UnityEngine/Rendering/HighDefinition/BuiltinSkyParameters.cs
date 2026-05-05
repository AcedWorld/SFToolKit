using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001E9 RID: 489
	public class BuiltinSkyParameters
	{
		// Token: 0x06000EB9 RID: 3769 RVA: 0x00074B90 File Offset: 0x00072D90
		public void CopyTo(BuiltinSkyParameters other)
		{
			other.hdCamera = this.hdCamera;
			other.pixelCoordToViewDirMatrix = this.pixelCoordToViewDirMatrix;
			other.worldSpaceCameraPos = this.worldSpaceCameraPos;
			other.viewMatrix = this.viewMatrix;
			other.screenSize = this.screenSize;
			other.commandBuffer = this.commandBuffer;
			other.sunLight = this.sunLight;
			other.colorBuffer = this.colorBuffer;
			other.depthBuffer = this.depthBuffer;
			other.frameIndex = this.frameIndex;
			other.skySettings = this.skySettings;
			other.cloudSettings = this.cloudSettings;
			other.volumetricClouds = this.volumetricClouds;
			other.debugSettings = this.debugSettings;
			other.cubemapFace = this.cubemapFace;
		}

		// Token: 0x04001753 RID: 5971
		public HDCamera hdCamera;

		// Token: 0x04001754 RID: 5972
		public Matrix4x4 pixelCoordToViewDirMatrix;

		// Token: 0x04001755 RID: 5973
		public Vector3 worldSpaceCameraPos;

		// Token: 0x04001756 RID: 5974
		public Matrix4x4 viewMatrix;

		// Token: 0x04001757 RID: 5975
		public Vector4 screenSize;

		// Token: 0x04001758 RID: 5976
		public CommandBuffer commandBuffer;

		// Token: 0x04001759 RID: 5977
		public Light sunLight;

		// Token: 0x0400175A RID: 5978
		public RTHandle colorBuffer;

		// Token: 0x0400175B RID: 5979
		public RTHandle depthBuffer;

		// Token: 0x0400175C RID: 5980
		public RTHandle cloudOpacity;

		// Token: 0x0400175D RID: 5981
		public ComputeBuffer cloudAmbientProbe;

		// Token: 0x0400175E RID: 5982
		public int frameIndex;

		// Token: 0x0400175F RID: 5983
		public SkySettings skySettings;

		// Token: 0x04001760 RID: 5984
		public CloudSettings cloudSettings;

		// Token: 0x04001761 RID: 5985
		public VolumetricClouds volumetricClouds;

		// Token: 0x04001762 RID: 5986
		public DebugDisplaySettings debugSettings;

		// Token: 0x04001763 RID: 5987
		public static RenderTargetIdentifier nullRT = -1;

		// Token: 0x04001764 RID: 5988
		public CubemapFace cubemapFace = CubemapFace.Unknown;
	}
}
