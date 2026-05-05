using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020001EC RID: 492
	[UsedByNativeCode]
	public struct GradientAlphaKey
	{
		// Token: 0x06001527 RID: 5415 RVA: 0x0001FBBE File Offset: 0x0001DDBE
		public GradientAlphaKey(float alpha, float time)
		{
			this.alpha = alpha;
			this.time = time;
		}

		// Token: 0x040007DD RID: 2013
		public float alpha;

		// Token: 0x040007DE RID: 2014
		public float time;
	}
}
