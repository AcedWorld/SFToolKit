using System;

namespace Unity.Netcode
{
	// Token: 0x0200009F RID: 159
	public enum SendTo
	{
		// Token: 0x040001DF RID: 479
		Owner,
		// Token: 0x040001E0 RID: 480
		NotOwner,
		// Token: 0x040001E1 RID: 481
		Server,
		// Token: 0x040001E2 RID: 482
		NotServer,
		// Token: 0x040001E3 RID: 483
		Me,
		// Token: 0x040001E4 RID: 484
		NotMe,
		// Token: 0x040001E5 RID: 485
		Everyone,
		// Token: 0x040001E6 RID: 486
		ClientsAndHost,
		// Token: 0x040001E7 RID: 487
		SpecifiedInParams
	}
}
