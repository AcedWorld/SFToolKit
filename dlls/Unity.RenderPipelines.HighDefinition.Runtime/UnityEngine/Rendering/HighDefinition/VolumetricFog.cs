using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000064 RID: 100
	[Obsolete]
	internal class VolumetricFog : AtmosphericScattering
	{
		// Token: 0x0600026F RID: 623 RVA: 0x0000E458 File Offset: 0x0000C658
		internal override void PushShaderParameters(HDCamera hdCamera, CommandBuffer cmd)
		{
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000E45C File Offset: 0x0000C65C
		private VolumetricFog()
		{
			base.displayName = "Volumetric Fog (Deprecated)";
		}

		// Token: 0x04000298 RID: 664
		public ColorParameter albedo = new ColorParameter(Color.white, false);

		// Token: 0x04000299 RID: 665
		public MinFloatParameter meanFreePath = new MinFloatParameter(1000000f, 1f, false);

		// Token: 0x0400029A RID: 666
		public FloatParameter baseHeight = new FloatParameter(0f, false);

		// Token: 0x0400029B RID: 667
		public FloatParameter maximumHeight = new FloatParameter(10f, false);

		// Token: 0x0400029C RID: 668
		public ClampedFloatParameter anisotropy = new ClampedFloatParameter(0f, -1f, 1f, false);

		// Token: 0x0400029D RID: 669
		public ClampedFloatParameter globalLightProbeDimmer = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x0400029E RID: 670
		public BoolParameter enableDistantFog = new BoolParameter(false, false);
	}
}
