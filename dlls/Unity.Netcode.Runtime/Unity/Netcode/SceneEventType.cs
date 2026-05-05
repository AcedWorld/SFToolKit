using System;

namespace Unity.Netcode
{
	// Token: 0x020000EF RID: 239
	public enum SceneEventType : byte
	{
		// Token: 0x040002B8 RID: 696
		Load,
		// Token: 0x040002B9 RID: 697
		Unload,
		// Token: 0x040002BA RID: 698
		Synchronize,
		// Token: 0x040002BB RID: 699
		ReSynchronize,
		// Token: 0x040002BC RID: 700
		LoadEventCompleted,
		// Token: 0x040002BD RID: 701
		UnloadEventCompleted,
		// Token: 0x040002BE RID: 702
		LoadComplete,
		// Token: 0x040002BF RID: 703
		UnloadComplete,
		// Token: 0x040002C0 RID: 704
		SynchronizeComplete,
		// Token: 0x040002C1 RID: 705
		ActiveSceneChanged,
		// Token: 0x040002C2 RID: 706
		ObjectSceneChanged
	}
}
