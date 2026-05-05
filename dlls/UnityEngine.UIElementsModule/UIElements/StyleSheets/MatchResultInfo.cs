using System;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x02000491 RID: 1169
	internal struct MatchResultInfo
	{
		// Token: 0x0600249F RID: 9375 RVA: 0x000995E2 File Offset: 0x000977E2
		public MatchResultInfo(bool success, PseudoStates triggerPseudoMask, PseudoStates dependencyPseudoMask)
		{
			this.success = success;
			this.triggerPseudoMask = triggerPseudoMask;
			this.dependencyPseudoMask = dependencyPseudoMask;
		}

		// Token: 0x0400118E RID: 4494
		public readonly bool success;

		// Token: 0x0400118F RID: 4495
		public readonly PseudoStates triggerPseudoMask;

		// Token: 0x04001190 RID: 4496
		public readonly PseudoStates dependencyPseudoMask;
	}
}
