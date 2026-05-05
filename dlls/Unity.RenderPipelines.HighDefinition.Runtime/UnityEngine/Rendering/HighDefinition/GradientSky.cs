using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001DD RID: 477
	[VolumeComponentMenuForRenderPipeline("Sky/Gradient Sky", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[SkyUniqueID(3)]
	public class GradientSky : SkySettings
	{
		// Token: 0x06000E73 RID: 3699 RVA: 0x00072A40 File Offset: 0x00070C40
		public override int GetHashCode()
		{
			return (((base.GetHashCode() * 23 + this.bottom.GetHashCode()) * 23 + this.top.GetHashCode()) * 23 + this.middle.GetHashCode()) * 23 + this.gradientDiffusion.GetHashCode();
		}

		// Token: 0x06000E74 RID: 3700 RVA: 0x00072A8F File Offset: 0x00070C8F
		public override Type GetSkyRendererType()
		{
			return typeof(GradientSkyRenderer);
		}

		// Token: 0x040016C0 RID: 5824
		[Tooltip("Specifies the color of the upper hemisphere of the sky.")]
		public ColorParameter top = new ColorParameter(Color.blue, true, false, true, false);

		// Token: 0x040016C1 RID: 5825
		[Tooltip("Specifies the color at the horizon.")]
		public ColorParameter middle = new ColorParameter(new Color(0.3f, 0.7f, 1f), true, false, true, false);

		// Token: 0x040016C2 RID: 5826
		[Tooltip("Specifies the color of the lower hemisphere of the sky. This is below the horizon.")]
		public ColorParameter bottom = new ColorParameter(Color.white, true, false, true, false);

		// Token: 0x040016C3 RID: 5827
		[Tooltip("Sets the size of the horizon (Middle color).")]
		public MinFloatParameter gradientDiffusion = new MinFloatParameter(1f, 0f, false);
	}
}
