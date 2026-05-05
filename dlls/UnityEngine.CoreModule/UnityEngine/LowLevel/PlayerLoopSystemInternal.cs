using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.LowLevel
{
	// Token: 0x0200032A RID: 810
	[RequiredByNativeCode]
	[NativeType(Header = "Runtime/Misc/PlayerLoop.h")]
	[MovedFrom("UnityEngine.Experimental.LowLevel")]
	internal struct PlayerLoopSystemInternal
	{
		// Token: 0x04000ACA RID: 2762
		public Type type;

		// Token: 0x04000ACB RID: 2763
		public PlayerLoopSystem.UpdateFunction updateDelegate;

		// Token: 0x04000ACC RID: 2764
		public IntPtr updateFunction;

		// Token: 0x04000ACD RID: 2765
		public IntPtr loopConditionFunction;

		// Token: 0x04000ACE RID: 2766
		public int numSubSystems;
	}
}
