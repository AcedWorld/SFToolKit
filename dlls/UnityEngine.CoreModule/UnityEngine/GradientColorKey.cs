using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020001EB RID: 491
	[UsedByNativeCode]
	public struct GradientColorKey
	{
		// Token: 0x06001526 RID: 5414 RVA: 0x0001FBAD File Offset: 0x0001DDAD
		public GradientColorKey(Color col, float time)
		{
			this.color = col;
			this.time = time;
		}

		// Token: 0x040007DB RID: 2011
		public Color color;

		// Token: 0x040007DC RID: 2012
		public float time;
	}
}
