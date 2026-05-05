using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000063 RID: 99
	[Serializable]
	public sealed class FogDenoisingModeParameter : VolumeParameter<FogDenoisingMode>
	{
		// Token: 0x0600026E RID: 622 RVA: 0x0000E44E File Offset: 0x0000C64E
		public FogDenoisingModeParameter(FogDenoisingMode value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
