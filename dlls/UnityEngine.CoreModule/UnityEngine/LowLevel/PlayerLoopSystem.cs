using System;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.LowLevel
{
	// Token: 0x0200032B RID: 811
	[MovedFrom("UnityEngine.Experimental.LowLevel")]
	public struct PlayerLoopSystem
	{
		// Token: 0x060020CC RID: 8396 RVA: 0x000365F6 File Offset: 0x000347F6
		public override string ToString()
		{
			return this.type.Name;
		}

		// Token: 0x04000ACF RID: 2767
		public Type type;

		// Token: 0x04000AD0 RID: 2768
		public PlayerLoopSystem[] subSystemList;

		// Token: 0x04000AD1 RID: 2769
		public PlayerLoopSystem.UpdateFunction updateDelegate;

		// Token: 0x04000AD2 RID: 2770
		public IntPtr updateFunction;

		// Token: 0x04000AD3 RID: 2771
		public IntPtr loopConditionFunction;

		// Token: 0x0200032C RID: 812
		// (Invoke) Token: 0x060020CE RID: 8398
		public delegate void UpdateFunction();
	}
}
