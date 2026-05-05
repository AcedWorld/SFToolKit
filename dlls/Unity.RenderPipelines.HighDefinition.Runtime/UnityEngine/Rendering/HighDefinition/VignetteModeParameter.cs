using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000148 RID: 328
	[Serializable]
	public sealed class VignetteModeParameter : VolumeParameter<VignetteMode>
	{
		// Token: 0x06000AD0 RID: 2768 RVA: 0x0005ACED File Offset: 0x00058EED
		public VignetteModeParameter(VignetteMode value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
