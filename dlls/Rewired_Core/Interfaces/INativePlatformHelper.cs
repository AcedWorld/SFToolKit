using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001E2 RID: 482
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface INativePlatformHelper
	{
		// Token: 0x170005EF RID: 1519
		// (get) Token: 0x060018AB RID: 6315
		bool isApplicationFocused { get; }
	}
}
