using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000E3 RID: 227
	internal struct LocalVolumetricFogList
	{
		// Token: 0x0400098A RID: 2442
		public List<OrientedBBox> bounds;

		// Token: 0x0400098B RID: 2443
		public List<LocalVolumetricFogEngineData> density;

		// Token: 0x0400098C RID: 2444
		public int volumeCount;
	}
}
