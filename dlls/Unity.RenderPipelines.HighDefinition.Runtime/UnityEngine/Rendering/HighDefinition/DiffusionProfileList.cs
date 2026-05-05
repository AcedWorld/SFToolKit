using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000065 RID: 101
	[VolumeComponentMenuForRenderPipeline("Material/Diffusion Profile List", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public class DiffusionProfileList : VolumeComponent
	{
		// Token: 0x0400029F RID: 671
		[Tooltip("List of diffusion profiles used inside the volume.")]
		[SerializeField]
		public DiffusionProfileSettingsParameter diffusionProfiles = new DiffusionProfileSettingsParameter(null, true);
	}
}
