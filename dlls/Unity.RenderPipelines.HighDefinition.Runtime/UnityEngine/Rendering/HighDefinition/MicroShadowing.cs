using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000D8 RID: 216
	[VolumeComponentMenuForRenderPipeline("Shadowing/Micro Shadows", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public class MicroShadowing : VolumeComponent
	{
		// Token: 0x06000942 RID: 2370 RVA: 0x00051B9F File Offset: 0x0004FD9F
		private MicroShadowing()
		{
			base.displayName = "Micro Shadows";
		}

		// Token: 0x0400093B RID: 2363
		[Tooltip("Enables micro shadows for directional lights.")]
		[DisplayInfo(name = "State")]
		public BoolParameter enable = new BoolParameter(false, BoolParameter.DisplayType.EnumPopup, false);

		// Token: 0x0400093C RID: 2364
		[Tooltip("Controls the opacity of the micro shadows.")]
		public ClampedFloatParameter opacity = new ClampedFloatParameter(1f, 0f, 1f, false);
	}
}
