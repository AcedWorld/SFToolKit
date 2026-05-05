using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
	// Token: 0x020000E5 RID: 229
	public interface IVolume
	{
		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000793 RID: 1939
		// (set) Token: 0x06000794 RID: 1940
		bool isGlobal { get; set; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000795 RID: 1941
		List<Collider> colliders { get; }
	}
}
