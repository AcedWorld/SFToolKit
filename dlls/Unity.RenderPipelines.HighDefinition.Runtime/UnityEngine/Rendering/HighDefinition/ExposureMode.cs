using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000128 RID: 296
	public enum ExposureMode
	{
		// Token: 0x04000B84 RID: 2948
		Fixed,
		// Token: 0x04000B85 RID: 2949
		Automatic,
		// Token: 0x04000B86 RID: 2950
		AutomaticHistogram = 4,
		// Token: 0x04000B87 RID: 2951
		CurveMapping = 2,
		// Token: 0x04000B88 RID: 2952
		[InspectorName("Physical Camera")]
		UsePhysicalCamera
	}
}
