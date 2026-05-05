using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000136 RID: 310
	[VolumeComponentMenuForRenderPipeline("Post-processing/Lift, Gamma, Gain", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class LiftGammaGain : VolumeComponent, IPostProcessComponent
	{
		// Token: 0x06000AB9 RID: 2745 RVA: 0x0005A430 File Offset: 0x00058630
		public bool IsActive()
		{
			Vector4 rhs = new Vector4(1f, 1f, 1f, 0f);
			return this.lift != rhs || this.gamma != rhs || this.gain != rhs;
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x0005A484 File Offset: 0x00058684
		private LiftGammaGain()
		{
			base.displayName = "Lift, Gamma, Gain";
		}

		// Token: 0x04000BAE RID: 2990
		[Tooltip("Use this to control and apply a hue to the dark tones. This has a more exaggerated effect on shadows.")]
		public Vector4Parameter lift = new Vector4Parameter(new Vector4(1f, 1f, 1f, 0f), false);

		// Token: 0x04000BAF RID: 2991
		[Tooltip("Use this to control and apply a hue to the mid-range tones with a power function.")]
		public Vector4Parameter gamma = new Vector4Parameter(new Vector4(1f, 1f, 1f, 0f), false);

		// Token: 0x04000BB0 RID: 2992
		[Tooltip("Use this to increase and apply a hue to the signal and make highlights brighter.")]
		public Vector4Parameter gain = new Vector4Parameter(new Vector4(1f, 1f, 1f, 0f), false);
	}
}
