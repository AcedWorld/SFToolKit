using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000059 RID: 89
	internal abstract class AtmosphericScattering : VolumeComponent
	{
		// Token: 0x06000258 RID: 600
		internal abstract void PushShaderParameters(HDCamera hdCamera, CommandBuffer cmd);

		// Token: 0x04000261 RID: 609
		public FogColorParameter colorMode = new FogColorParameter(FogColorMode.SkyColor, false);

		// Token: 0x04000262 RID: 610
		[Tooltip("Specifies the constant color of the fog.")]
		public ColorParameter color = new ColorParameter(Color.grey, true, false, true, false);

		// Token: 0x04000263 RID: 611
		[Tooltip("Specifies the tint of the fog.")]
		public ColorParameter tint = new ColorParameter(Color.white, true, false, true, false);

		// Token: 0x04000264 RID: 612
		[Tooltip("Controls the overall density of the fog. Acts as a global multiplier.")]
		public ClampedFloatParameter density = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x04000265 RID: 613
		[Tooltip("Sets the maximum fog distance HDRP uses when it shades the skybox or the Far Clipping Plane of the Camera.")]
		public MinFloatParameter maxFogDistance = new MinFloatParameter(5000f, 0f, false);

		// Token: 0x04000266 RID: 614
		[Tooltip("Controls the maximum mip map HDRP uses for mip fog (0 is the lowest mip and 1 is the highest mip).")]
		public ClampedFloatParameter mipFogMaxMip = new ClampedFloatParameter(0.5f, 0f, 1f, false);

		// Token: 0x04000267 RID: 615
		[Tooltip("Sets the distance at which HDRP uses the minimum mip image of the blurred sky texture as the fog color.")]
		public MinFloatParameter mipFogNear = new MinFloatParameter(0f, 0f, false);

		// Token: 0x04000268 RID: 616
		[Tooltip("Sets the distance at which HDRP uses the maximum mip image of the blurred sky texture as the fog color.")]
		public MinFloatParameter mipFogFar = new MinFloatParameter(1000f, 0f, false);
	}
}
