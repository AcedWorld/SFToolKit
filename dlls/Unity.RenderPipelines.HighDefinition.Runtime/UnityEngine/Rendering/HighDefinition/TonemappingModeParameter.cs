using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000145 RID: 325
	[Serializable]
	public sealed class TonemappingModeParameter : VolumeParameter<TonemappingMode>
	{
		// Token: 0x06000ACD RID: 2765 RVA: 0x0005ABAA File Offset: 0x00058DAA
		public TonemappingModeParameter(TonemappingMode value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
