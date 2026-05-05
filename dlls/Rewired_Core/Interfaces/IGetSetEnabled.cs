using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001E7 RID: 487
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IGetSetEnabled
	{
		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x060018C6 RID: 6342
		// (set) Token: 0x060018C7 RID: 6343
		bool enabled { get; set; }
	}
}
