using System;

namespace Rewired.ComponentControls.Data
{
	// Token: 0x02000423 RID: 1059
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[Serializable]
	public abstract class CustomControllerElementTargetSet
	{
		// Token: 0x17000A0C RID: 2572
		// (get) Token: 0x06002AAA RID: 10922
		internal abstract int targetCount { get; }

		// Token: 0x17000A0D RID: 2573
		internal abstract CustomControllerElementTarget this[int index]
		{
			get;
		}

		// Token: 0x06002AAC RID: 10924
		internal abstract void ClearElementCaches();
	}
}
