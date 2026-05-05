using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001F8 RID: 504
	[VolumeComponentMenuForRenderPipeline("Visual Environment", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class VisualEnvironment : VolumeComponent
	{
		// Token: 0x040017CC RID: 6092
		[Header("Sky")]
		public NoInterpIntParameter skyType = new NoInterpIntParameter(0, false);

		// Token: 0x040017CD RID: 6093
		public NoInterpIntParameter cloudType = new NoInterpIntParameter(0, false);

		// Token: 0x040017CE RID: 6094
		public SkyAmbientModeParameter skyAmbientMode = new SkyAmbientModeParameter(SkyAmbientMode.Dynamic, false);

		// Token: 0x040017CF RID: 6095
		[Header("Wind")]
		public ClampedFloatParameter windOrientation = new ClampedFloatParameter(0f, 0f, 360f, false);

		// Token: 0x040017D0 RID: 6096
		public FloatParameter windSpeed = new FloatParameter(0f, false);

		// Token: 0x040017D1 RID: 6097
		[SerializeField]
		internal FogTypeParameter fogType = new FogTypeParameter(FogType.None, false);
	}
}
