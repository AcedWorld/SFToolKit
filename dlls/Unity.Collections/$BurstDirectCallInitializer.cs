using System;
using Unity.Collections;
using UnityEngine;

// Token: 0x0200012F RID: 303
internal static class $BurstDirectCallInitializer
{
	// Token: 0x06000B16 RID: 2838 RVA: 0x00022E15 File Offset: 0x00021015
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	private static void Initialize()
	{
		AllocatorManager.Initialize$StackAllocator_Try_00000980$BurstDirectCall();
		AllocatorManager.Initialize$SlabAllocator_Try_0000098E$BurstDirectCall();
		RewindableAllocator.Try_000006E8$BurstDirectCall.Initialize();
		xxHash3.Hash64Long_0000071F$BurstDirectCall.Initialize();
		xxHash3.Hash128Long_00000726$BurstDirectCall.Initialize();
	}
}
