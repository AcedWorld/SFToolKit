using System;

namespace Unity.Netcode
{
	// Token: 0x0200002E RID: 46
	public enum NetworkUpdateStage : byte
	{
		// Token: 0x040000EF RID: 239
		Unset,
		// Token: 0x040000F0 RID: 240
		Initialization,
		// Token: 0x040000F1 RID: 241
		EarlyUpdate,
		// Token: 0x040000F2 RID: 242
		FixedUpdate,
		// Token: 0x040000F3 RID: 243
		PreUpdate,
		// Token: 0x040000F4 RID: 244
		Update,
		// Token: 0x040000F5 RID: 245
		PreLateUpdate,
		// Token: 0x040000F6 RID: 246
		PostScriptLateUpdate = 8,
		// Token: 0x040000F7 RID: 247
		PostLateUpdate = 7
	}
}
