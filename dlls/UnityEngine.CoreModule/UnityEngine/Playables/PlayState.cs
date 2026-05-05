using System;

namespace UnityEngine.Playables
{
	// Token: 0x020004A4 RID: 1188
	public enum PlayState
	{
		// Token: 0x04000F77 RID: 3959
		Paused,
		// Token: 0x04000F78 RID: 3960
		Playing,
		// Token: 0x04000F79 RID: 3961
		[Obsolete("Delayed is obsolete; use a custom ScriptPlayable to implement this feature", false)]
		Delayed
	}
}
