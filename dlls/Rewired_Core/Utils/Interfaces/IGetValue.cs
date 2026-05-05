using System;

namespace Rewired.Utils.Interfaces
{
	// Token: 0x02000533 RID: 1331
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IGetValue<T>
	{
		// Token: 0x06003662 RID: 13922
		T GetValue();
	}
}
