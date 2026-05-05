using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000181 RID: 385
	[Serializable]
	public sealed class RayCastingModeParameter : VolumeParameter<RayCastingMode>
	{
		// Token: 0x06000C72 RID: 3186 RVA: 0x000683C5 File Offset: 0x000665C5
		public RayCastingModeParameter(RayCastingMode value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
