using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200014A RID: 330
	public enum CustomPostProcessInjectionPoint
	{
		// Token: 0x04000C00 RID: 3072
		AfterOpaqueAndSky,
		// Token: 0x04000C01 RID: 3073
		BeforeTAA = 3,
		// Token: 0x04000C02 RID: 3074
		BeforePostProcess = 1,
		// Token: 0x04000C03 RID: 3075
		AfterPostProcessBlurs = 4,
		// Token: 0x04000C04 RID: 3076
		AfterPostProcess = 2
	}
}
