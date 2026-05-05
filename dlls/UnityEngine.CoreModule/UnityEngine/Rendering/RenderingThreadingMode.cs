using System;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.Rendering
{
	// Token: 0x02000425 RID: 1061
	[MovedFrom("UnityEngine.Experimental.Rendering")]
	public enum RenderingThreadingMode
	{
		// Token: 0x04000CF6 RID: 3318
		Direct,
		// Token: 0x04000CF7 RID: 3319
		SingleThreaded,
		// Token: 0x04000CF8 RID: 3320
		MultiThreaded,
		// Token: 0x04000CF9 RID: 3321
		LegacyJobified,
		// Token: 0x04000CFA RID: 3322
		NativeGraphicsJobs,
		// Token: 0x04000CFB RID: 3323
		NativeGraphicsJobsWithoutRenderThread
	}
}
