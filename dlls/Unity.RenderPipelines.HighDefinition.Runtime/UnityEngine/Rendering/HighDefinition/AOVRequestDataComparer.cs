using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000199 RID: 409
	internal class AOVRequestDataComparer : IEqualityComparer<AOVRequestData>
	{
		// Token: 0x06000CB0 RID: 3248 RVA: 0x00068E4D File Offset: 0x0006704D
		public bool Equals(AOVRequestData x, AOVRequestData y)
		{
			return x.HasSameSettings(y);
		}

		// Token: 0x06000CB1 RID: 3249 RVA: 0x00068E57 File Offset: 0x00067057
		public int GetHashCode(AOVRequestData obj)
		{
			return obj.GetHash();
		}
	}
}
