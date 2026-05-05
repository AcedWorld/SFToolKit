using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200005B RID: 91
	[Obsolete]
	internal class ExponentialFog : AtmosphericScattering
	{
		// Token: 0x0600025A RID: 602 RVA: 0x0000DDC0 File Offset: 0x0000BFC0
		internal override void PushShaderParameters(HDCamera hdCamera, CommandBuffer cmd)
		{
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000DDC4 File Offset: 0x0000BFC4
		private ExponentialFog()
		{
			base.displayName = "Exponential Fog (Deprecated)";
		}

		// Token: 0x0400026D RID: 621
		private static readonly int m_ExpFogParam = Shader.PropertyToID("_ExpFogParameters");

		// Token: 0x0400026E RID: 622
		[Tooltip("Sets the distance from the Camera at which the fog reaches its maximum thickness.")]
		public MinFloatParameter fogDistance = new MinFloatParameter(200f, 0f, false);

		// Token: 0x0400026F RID: 623
		[Tooltip("Sets the height, in world space, at which HDRP begins to decrease the fog density from 1.0.")]
		public FloatParameter fogBaseHeight = new FloatParameter(0f, false);

		// Token: 0x04000270 RID: 624
		[Tooltip("Controls the falloff of height fog attenuation, larger values result in sharper attenuation.")]
		public ClampedFloatParameter fogHeightAttenuation = new ClampedFloatParameter(0.2f, 0f, 1f, false);
	}
}
