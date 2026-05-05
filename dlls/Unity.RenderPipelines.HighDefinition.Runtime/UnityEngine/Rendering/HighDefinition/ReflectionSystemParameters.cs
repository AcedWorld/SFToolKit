using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000AE RID: 174
	internal struct ReflectionSystemParameters
	{
		// Token: 0x040007C5 RID: 1989
		public static ReflectionSystemParameters Default = new ReflectionSystemParameters
		{
			maxPlanarReflectionProbePerCamera = 128,
			maxActivePlanarReflectionProbe = 512,
			planarReflectionProbeSize = 128,
			maxActiveEnvReflectionProbe = 512
		};

		// Token: 0x040007C6 RID: 1990
		public int maxPlanarReflectionProbePerCamera;

		// Token: 0x040007C7 RID: 1991
		public int maxActivePlanarReflectionProbe;

		// Token: 0x040007C8 RID: 1992
		public int planarReflectionProbeSize;

		// Token: 0x040007C9 RID: 1993
		public int maxActiveEnvReflectionProbe;
	}
}
